<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="ClaimSearchGrid.aspx.cs" Inherits="SONIC_Sedgwick_ClaimSearchGrid" %>

<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment_Sedgwick/Attachement_DetailWithClaim.ascx" TagName="ctrlAttachmentDetail" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function ShowMailPageForSLT() {
            var Year = document.getElementById('<%= hdnYear.ClientID %>').value;
            var Quarter = document.getElementById('<%= hdnQuarter.ClientID %>').value;
            var FKLUSedgwickFieldOffice = document.getElementById('<%= hdnFKLUSedgwickFieldOffice.ClientID %>').value;
            var SortBy = document.getElementById('<%= hdnSortBy.ClientID %>').value;
            var SortOrder = document.getElementById('<%= hdnSortOrder.ClientID %>').value;
            var oWnd = window.open('<%=AppConfig.SiteURL%>SONIC/Sedgwick/SendEmail.aspx?Year=' + Year + '&Quarter=' + Quarter + '&SedgwickFieldOffice=' + FKLUSedgwickFieldOffice + '&SortBy=' + SortBy + '&SortOrder=' + SortOrder, "Erims", "location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=600,height=300");
            //var oWnd = window.open('<%=AppConfig.SiteURL%>SONIC/Sedgwick/SendEmail.aspx', "Erims", "location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=600,height=300");
            oWnd.moveTo(260, 180);
            return false;
        }
    </script>
    <asp:HiddenField ID="hdnYear" runat="server" />
    <asp:HiddenField ID="hdnQuarter" runat="server" />
    <asp:HiddenField ID="hdnFKLUSedgwickFieldOffice" runat="server" />
    <asp:HiddenField ID="hdnSortBy" runat="server" />
    <asp:HiddenField ID="hdnSortOrder" runat="server" />
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
                            <uc:ctrlPaging ID="ctrlPageClaimInfo" runat="server" OnGetPage="GetPage" DefaultPageSize="50" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 10px;"></td>
        </tr>
        <tr>
            <td class="groupHeaderBar" align="right" style="padding-right:10px;">
                <asp:LinkButton ID="lnkClaimReviewExportToExcel" runat="server" OnClick="lnkClaimReviewExportToExcel_Click" Font-Size="10px"
                     Text="Export To Excel"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 10px;"></td>
        </tr>
        <%--		<tr>
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
		</tr>--%>
        <%--	<tr>
			<td class="Spacer" style="height: 20px;"></td>
		</tr>--%>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td width="100%" colspan="7" valign="top">
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
								<%--<EmptyDataTemplate>
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
            <td class="Spacer" style="height: 20px;"></td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td width="100%" colspan="7" valign="top">
                            <asp:GridView ID="gvClaimReviewGroupSearchGrid" runat="server" DataKeyNames="PK_Workers_Comp_Claims_ID"
                                AutoGenerateColumns="false" Width="100%" AllowSorting="True" OnRowCreated="gvClaimReviewGroupSearchGrid_RowCreated"
                                OnSorting="gvClaimReviewGroupSearchGrid_Sorting" OnRowCommand="gvClaimReviewGroupSearchGrid_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sedgwick Field Office" Visible="false">
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                        <ItemTemplate>
                                            <%= lblSedgwickOffice.Text%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Year" Visible="false">
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                        <ItemTemplate>
                                            <%= lblYear.Text %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quarter" Visible="false">
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                        <ItemTemplate>
                                            <%= lblQuarter.Text%>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="RLCM" SortExpression="RLCM">
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                        <ItemTemplate>
                                            <%#Eval("RLCM")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Claim Number" SortExpression="Origin_Claim_Number">
                                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkEdit" runat="server" Text='<%#Eval("Origin_Claim_Number")%>'
                                                CommandName="ClaimSummary" CommandArgument='<%#Eval("PK_Workers_Comp_Claims_ID") + ":" + Eval("PK_Sedgwick_Claim_Review")+":"+ clsGeneral.GetNullBooleanValue(Eval("IsEnable")) %>' /><%--Enabled='# '--%>
                                            <%--<%#Eval("Origin_Claim_Number")%>--%>
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
                                    <asp:TemplateField HeaderText="Review Complete?" SortExpression="Review_Complete">
                                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                                        <ItemTemplate>
                                            <%#Eval("Review_Complete")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remove" HeaderStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="imgRemove" ImageUrl="~/Images/grdimg_delete.gif"
                                                OnClientClick="javascript:return confirm('Do you want to permanently remove the selected claim’s Claim Review Worksheet and remove the claim from the Claim Review Worksheet Group?');"
                                                CommandName="Remove" CommandArgument='<%# Eval("PK_Sedgwick_Claim_Review") %>' Enabled='<%# clsGeneral.GetNullBooleanValue(Eval("IsEnable"))%>' />
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
            <td class="Spacer" style="height: 20px;"></td>
        </tr>
        <tr>
            <td class="groupHeaderBar" align="right" style="padding-right:10px;">
                <asp:LinkButton ID="lnkOpenActionItems" runat="server" OnClick="lnkOpenActionItems_Click" Font-Size="10px"
                     Text="Export To Excel"></asp:LinkButton>
            </td>
        </tr>
        <tr style="background-color: #606060; font-family: Tahoma; color: white; font-size: 10pt; font-weight: bold; ">
            <td style="padding: 5px;">Previous Claim Review Worksheets with Open Action Plan Items
                <%--<span style="color: white;font-family:Verdana; padding-left:52%;" ></span> --%>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td width="100%" colspan="7" valign="top">
                            <asp:GridView ID="grdPreviousClaimReview" runat="server" DataKeyNames="PK_Workers_Comp_Claims_ID"
                                AutoGenerateColumns="false" Width="100%" AllowSorting="True" OnRowCreated="grdPreviousClaimReview_RowCreated"
                                OnSorting="grdPreviousClaimReview_Sorting" OnRowCommand="grdPreviousClaimReview_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="RLCM" SortExpression="RLCM">
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                        <ItemTemplate>
                                            <%#Eval("RLCM")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sedgwick Field Office" Visible="false">
                                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                                        <ItemTemplate>
                                            <%= lblSedgwickOffice.Text %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Year" SortExpression="Year">
                                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                                        <ItemTemplate>
                                            <%#Eval("Year")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quarter" SortExpression="Quarter">
                                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                                        <ItemTemplate>
                                            <%#Eval("Quarter")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Claim Number" SortExpression="Origin_Claim_Number">
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkEdit" runat="server" Text='<%#Eval("Origin_Claim_Number")%>'
                                                CommandName="ClaimSummary" CommandArgument='<%#Eval("PK_Workers_Comp_Claims_ID") + ":" + Eval("PK_Sedgwick_Claim_Review") + ":" + clsGeneral.GetNullBooleanValue(Eval("IsEnable"))%>' />
                                            <%--Enabled='# clsGeneral.GetNullBooleanValue(Eval("IsEnable"))'--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Associate Name" SortExpression="Employee_Name">
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                        <ItemTemplate>
                                            <%#Eval("Employee_Name")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="d/b/a" SortExpression="dba">
                                        <ItemStyle HorizontalAlign="Left" Width="20%" />
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
                                    <asp:TemplateField HeaderText="Management Section(s) with Open Action Plan Items" SortExpression="MgtSection">
                                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                                        <ItemTemplate>
                                            <%#Eval("MgtSection").ToString() == "Disability" ? "Legal" : Eval("MgtSection")%>                                           
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
            <td>
                <table cellpadding="0" cellspacing="0" width="100%" align="center">
                    <tr>
                        <td width="100%" class="Spacer" style="height: 20px;"></td>
                    </tr>
                    <tr>
                        <td>
                            <table cellspacing="2" cellpadding="4" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td style="width: 20%; font-weight: bold;" align="left" colspan="4">Claim Review Worksheet
											Group </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%" align="left">Average Score </td>
                                        <td style="width: 4%" align="center">: </td>
                                        <td align="left">
                                            <asp:Label ID="lblAvgScore" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">Scoring Classification </td>
                                        <td align="center">: </td>
                                        <td align="left">
                                            <asp:Label ID="lblScoringClassification" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6" style="font-weight: bold;">Sedgwick Field Office Annual</td>
                                    </tr>
                                    <tr>
                                        <td align="left">Total of Average Scores</td>
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
                                        <td style="height: 20px" class="Spacer" colspan="6"></td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlAttachmentDetails" runat="server" Width="100%">
                    <table cellpadding="0" cellspacing="0" width="100%" style="min-height: 50px;">
                        <tr>
                            <td width="100%" valign="top">
                                <uc:ctrlAttachmentDetail ID="AttachDetails" runat="Server" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
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
                            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" ToolTip="Add" />
                            <asp:Button ID="btnSendEmail" runat="server" Text="Email" OnClientClick="return ShowMailPageForSLT();"
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
