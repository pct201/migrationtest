<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
	CodeFile="ClaimReviewWorksheetSearchGrid.aspx.cs" Inherits="SONIC_Sedgwick_ClaimReviewWorksheetSearchGrid" %>

<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<script type="text/javascript">
		function SelectDeselectHeader(bFromGrid) {
			var ctrls = document.getElementsByTagName('input');
			var i, chkID;
			var cnt = 0;
			chkID = (bFromGrid == true ? "chkClaimNumber" : "chkRptNotesSelect");
			for (i = 0; i < ctrls.length; i++) {
				if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf(chkID) > 0) {
					if (ctrls[i].checked)
						cnt++;
				}
			}
			if(cnt > 0)
				document.getElementById('<%=btnAddToClaimReview.ClientID %>').style.display = "";
			else
				document.getElementById('<%=btnAddToClaimReview.ClientID %>').style.display = "none";
		}

	    function ConfirmAllCheck(isChecked,ChkAll)
	    {	        
	        if (isChecked)
	        {
	            if (confirm("Do you want to select all claims on all pages of the current search results?"))
	            {
	                __doPostBack('ctl00$ContentPlaceHolder1$btntest', '1');
	            }
	            else
	            {
	                //debugger;
	                //var gridViewCtlId = '<%=gvClaimReviewGroupSearchGrid.ClientID%>';
	                //var grid = document.getElementById(gridViewCtlId);
	                //var gridLength = grid.rows.length;
	                //for (var i = 1; i < gridLength; i++) {
	                //  cell = grid.rows[i].cells[0];
	                //  for (var j = 0; j < cell.childNodes.length; j++) {
	                //      if (cell.childNodes[j].type == 'checkbox') {
	                //          cell.childNodes[j].checked = false;
	                //      }
	                //  }
	                //}
	                __doPostBack('ctl00$ContentPlaceHolder1$btntest', '2');
	                //return false;
	            }
	        }
	        else
	        {
	            __doPostBack('ctl00$ContentPlaceHolder1$btntest', '0');
	        }	        
	    }
	</script>
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
									<td align="left"><span class="heading">Claims Review Worksheet Search Results</span>
									</td>
								</tr>
								<tr>
									<td align="left">&nbsp;
										<asp:Label ID="lblNumber" runat="server" Text="0"></asp:Label>&nbsp;Claim Review
										Worksheet Found </td>
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
							<%--<asp:GridView ID="gvSedgwickOffice" runat="server" DataKeyNames="PK_Sedgwick_Claim_Group"
								AutoGenerateColumns="false" Width="100%">
								<Columns>
									<asp:TemplateField HeaderText="Sedgwick Field Office">
										<ItemStyle HorizontalAlign="Left" Width="15%" />
										<ItemTemplate>
											<%#Eval("Fld_Desc")%>
										</ItemTemplate>
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Year">
										<ItemStyle HorizontalAlign="Left" Width="20%" />
										<ItemTemplate>
											<%#Eval("Year")%>
										</ItemTemplate>
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Quarter">
										<ItemStyle HorizontalAlign="Left" Width="15%" />
										<ItemTemplate>
											<%#Eval("Quarter")%>
										</ItemTemplate>
									</asp:TemplateField>
								</Columns>
							</asp:GridView>--%>
						</td>
					</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td class="Spacer" style="height: 20px;"></td>
		</tr>
		<tr>
			<td>
				<table cellpadding="0" cellspacing="0" border="0" width="100%">
					<tr>
						<td width="100%" colspan="7" valign="top">
							<asp:GridView ID="gvClaimReviewGroupSearchGrid" runat="server" DataKeyNames="PK_Workers_Comp_Claims_ID"
								AutoGenerateColumns="false" Width="100%" AllowSorting="True" OnRowCreated="gvClaimReviewGroupSearchGrid_RowCreated" OnRowDataBound="gvClaimReviewGroupSearchGrid_RowDataBound"
								OnSorting="gvClaimReviewGroupSearchGrid_Sorting" OnRowCommand="gvClaimReviewGroupSearchGrid_RowCommand">
								<Columns>
									<asp:TemplateField HeaderText="Select">
										<ItemStyle HorizontalAlign="Left" Width="10%" />
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkAllCheckClaim" runat="server" onclick="ConfirmAllCheck(this.checked,this.id);" />
                                        </HeaderTemplate>
										<ItemTemplate>
											<asp:CheckBox ID="chkClaimNumber" runat="server" onclick="SelectDeselectHeader(true);" />
											<input type="hidden" id="hdnPK_Workers_Comp_Claims_ID" runat="server" value='<%# Eval("PK_Workers_Comp_Claims_ID") %>' />
											<%--<input type="hidden" id="hdnPK_Sedgwick_Claim_Review" runat="server" value='<%# Eval("PK_Sedgwick_Claim_Review") %>' />--%>
											<%--<asp:LinkButton ID="lnkEdit" runat="server" Text='<%#Eval("Origin_Claim_Number")%>'
												CommandName="ClaimSummary" CommandArgument='<%#Eval("PK_Workers_Comp_Claims_ID") + ":" + Eval("PK_Sedgwick_Claim_Review") %>' />--%>
										</ItemTemplate>
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Claim Number" SortExpression="Origin_Claim_Number">
										<ItemStyle HorizontalAlign="Left" Width="10%" />
										<ItemTemplate>
											<asp:Label ID="lblClaimNumber" runat="server" Text='<%#Eval("Origin_Claim_Number")%>'></asp:Label>
											<%--<asp:LinkButton ID="lnkEdit" runat="server" Text='<%#Eval("Origin_Claim_Number")%>'
												CommandName="ClaimSummary" CommandArgument='<%#Eval("PK_Workers_Comp_Claims_ID") + ":" + Eval("PK_Sedgwick_Claim_Review") %>' />--%>
										</ItemTemplate>
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Associate Name" SortExpression="Employee_Name">
										<ItemStyle HorizontalAlign="Left" Width="15%" />
										<ItemTemplate>
											<%#Eval("Employee_Name")%>
										</ItemTemplate>
									</asp:TemplateField>
									<asp:TemplateField HeaderText="d/b/a" SortExpression="dba">
										<ItemStyle HorizontalAlign="Left" Width="15%" />
										<ItemTemplate>
											<%#Eval("dba")%>
										</ItemTemplate>
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Location Number" SortExpression="Sonic_Location_Code">
										<ItemStyle HorizontalAlign="Left" Width="10%" />
										<ItemTemplate>
											<%#Eval("Sonic_Location_Code")%>
										</ItemTemplate>
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Date of Loss" SortExpression="Date_of_Accident">
										<ItemStyle HorizontalAlign="Left" Width="10%" />
										<ItemTemplate>
											<%# clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("Date_Of_Accident"))%>
										</ItemTemplate>
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Claim Indicator" SortExpression="ClaimIndicator">
										<ItemStyle HorizontalAlign="Left" Width="10%" />
										<ItemTemplate>
											<%#Eval("ClaimIndicator")%>
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
							</asp:GridView>
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
							<asp:Button ID="btnAddToClaimReview" runat="server" Text="Add to Claim Review Worksheet Group"
								OnClick="btnAddToClaimReview_Click" ToolTip="Add to Claim Review Worksheet Group" style="display:none;" />
                            <asp:Button ID="btntest" runat="server" Visible="false" OnClick="btntest_Click" />
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
