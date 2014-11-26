<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="ReserveWorksheetHistoryGrid.aspx.cs"
	Theme="Default"   Inherits="Liability_ReserveWorksheetHistoryGrid"
	Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="cntReserveWrkSht" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">

	<script src="../JavaScript/JFunctions.js" type="text/javascript"></script>

	<script language="javascript" src="../JavaScript/Calendar_new.js" type="text/javascript"></script>

	<script language="javascript" src="../JavaScript/calendar-en.js" type="text/javascript"></script>

	<script language="javascript" src="../JavaScript/Calendar.js" type="text/javascript"></script>

	<div>
		<asp:ValidationSummary ID="vsError" runat="server" BorderColor="DimGray" BorderWidth="1"
			CssClass="errormessage" EnableClientScript="true" HeaderText="Verify the following fields:"
			ShowMessageBox="true" ShowSummary="false" ValidationGroup="vsErrorGroup" />
		<asp:CustomValidator ID="cvErrorMsg" runat="server" Display="None" EnableClientScript="true"
			ErrorMessage="" ValidationGroup="vsErrorGroup"></asp:CustomValidator>
	</div>
	<asp:ScriptManager ID="scManager" runat="server">
	</asp:ScriptManager>

	<script type="text/javascript">
	function ValAttach()
	{
		document.getElementById("ctl00_ContentPlaceHolder1_fvWorkersRW_rfvAttachType").enabled =true;
		document.getElementById("ctl00_ContentPlaceHolder1_fvWorkersRW_rfvUpload").enabled =true;
		return true;
	}
	function ValSave()
	{
		document.getElementById("ctl00_ContentPlaceHolder1_fvWorkersRW_rfvAttachType").enabled =false;
		document.getElementById("ctl00_ContentPlaceHolder1_fvWorkersRW_rfvUpload").enabled =false;
		return true;
	}
	function openWindow(strURL)
    {
        oWnd=window.open(strURL,"Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=300");
        oWnd.moveTo(260,180);
        return false;
    }
    function openMailWindow(strURL)
    {
        oWnd=window.open(strURL,"Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=0,toolbar=0,width=500,height=280");
        oWnd.moveTo(260,180);
        return false; 
     } 
	</script>

	<div style="width: 100%" id="contmain" runat="server">
		<br />
		<div style="width: 100%; text-align: center" id="Div1" runat="server">
			<table cellspacing="0" cellpadding="1" width="99%" border="0">
				<tbody>
					<tr>
						<td align="center" style="background-image: url('../images/normal_btn.jpg')" class="normal_tab"
							valign="middle">
							<a class="main_menu" href="LiabilityClaim.aspx">Liability Claim</a></td>
						<td align="center" class="active_tab" style="background-image: url('../images/active_btn.jpg')"
							valign="middle">
							Reserve Worksheet</td>
						<td align="center" class="active_tab" style="background-image: url('../images/normal_btn.jpg')"
							valign="middle">
							<a class="main_menu" href="CareearData.aspx">Carrier Data</a></td>
						<td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
							valign="middle">
							<a class="main_menu" href="subrogation.aspx">Subrogation</a></td>
						<td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
							valign="middle">
							<a class="main_menu" href="subrogationDetails.aspx">Subrogation Detail</a></td>
						<td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
							valign="middle">
							<a class="main_menu" href="CheckRegister.aspx">Check Register</a></td>
						<td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
							valign="middle">
							<a class="main_menu" href="Diary.aspx">Diary</a></td>
						<td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
							valign="middle">
							<a class="main_menu" href="Adjuster.aspx">Adjustor Notes</a></td>
					</tr>
				</tbody>
			</table>
		</div>
		<div style="border-right: #7f7f7f 1px solid; border-top: #7f7f7f 1px solid; float: left;
			margin: 1px 1px 1px 4px; border-left: #7f7f7f 1px solid; width: 18%; border-bottom: #7f7f7f 1px solid;
			height: 350px" id="leftdiv" runat="server">
			<table cellspacing="0" cellpadding="0" width="90%" border="0">
				<tbody>
					<tr>
						<td style="width: 15px">
							&nbsp;</td>
						<td style="width: 85%">
							<asp:LinkButton ID="lbtnClaimDetail" OnClick="lbtnClaimDetail_Click" runat="server"
								Text="Claim Details" CssClass="left_menu_active"></asp:LinkButton>
						</td>
					</tr>
					<tr>
						<td>
							&nbsp;</td>
						<td>
							<asp:LinkButton ID="lbtnRHistory" OnClick="lbtnRHistory_Click" runat="server" Text="Reserve History"
								CssClass="left_menu"></asp:LinkButton>
						</td>
					</tr>
					<tr>
						<td>
							&nbsp;</td>
						<td>
							<asp:LinkButton ID="lbtnOutstanding" OnClick="lbtnOutstanding_Click" runat="server"
								Text="Outstanding" CssClass="left_menu"></asp:LinkButton>
						</td>
					</tr>
				</tbody>
			</table>
		</div>
		<div style="border-right: #7f7f7f 1px solid; padding-right: 5px; border-top: #7f7f7f 1px solid;
			padding-left: 5px; float: right; padding-bottom: 5px; margin: 1px 5px 1px 1px;
			border-left: #7f7f7f 1px solid; width: 79%; padding-top: 5px; border-bottom: #7f7f7f 1px solid"
			id="mainContent" runat="server">
			<div style="display: block" id="dvClaimDetail" runat="server">
				<table class="stylesheet" cellspacing="0" cellpadding="0" width="100%" border="0">
					<tbody>
						<tr>
							<td class="ghc" colspan="6">
								Claim Details<asp:Label ID="lblTemp" runat="server" Text=""></asp:Label>
							</td>
						</tr>
						<tr>
							<td style="width: 18%" class="lc" align="left">
								Claim Number</td>
							<td style="width: 5px" align="left">
								&nbsp;:</td>
							<td style="width: 30%" class="lc" align="left">
								<asp:Label ID="lblClaimNumber" runat="server"></asp:Label></td>
							<td style="width: 18%" class="lc" align="left">
								Employee
							</td>
							<td style="width: 5px" align="left">
								&nbsp;:</td>
							<td style="width: 30%" class="lc" align="left">
								<asp:RadioButtonList ID="rbtnEmployee" runat="server" RepeatDirection="Horizontal"
									Enabled="false">
									<asp:ListItem>Yes</asp:ListItem>
									<asp:ListItem>No</asp:ListItem>
								</asp:RadioButtonList>
							</td>
						</tr>
						<tr>
							<td class="lc" align="left">
								Last Name</td>
							<td align="center">
								:</td>
							<td class="lc" align="left">
								<asp:Label ID="lblLastName" runat="server"></asp:Label>
							</td>
							<td class="lc" align="left">
								First Name</td>
							<td align="center">
								:</td>
							<td class="lc" align="left">
								<asp:Label ID="lblFirstName" runat="server"></asp:Label></td>
						</tr>
						<tr>
							<td class="lc" align="left">
								Middle Name</td>
							<td align="center">
								:</td>
							<td class="lc" align="left">
								<asp:Label ID="lblMidleName" runat="server"></asp:Label></td>
							<td class="lc" align="left">
								Date of Incident</td>
							<td align="center">
								:</td>
							<td class="lc" align="left">
								<asp:Label ID="lblIncidentDt" runat="server"></asp:Label>
							</td>
						</tr>
					</tbody>
				</table>
			</div>
			<div style="display: none" id="dvReserveHistory" runat="server">
				<asp:MultiView ID="mvWorkersRW" runat="server">
					<asp:View ID="vwWorkersRWList" runat="server">
						<table class="stylesheet" cellspacing="4" cellpadding="4" width="100%" border="0">
							<tbody>
								<tr>
									<td class="ghc" colspan="8">
										Workers Compensation Reserve Worksheet History
									</td>
								</tr>
								<tr>
									<td align="left" class="lc" style="width: 30%" valign="middle">
										<asp:Label ID="lblRWTotal" runat="server" Text=""></asp:Label>
									</td>
									<td align="right" style="width: 70%">
										<table width="95%">
											<tbody>
												<tr>
													<td class="lc">
														No. of Records per page :
														<asp:DropDownList ID="ddlPage" runat="server" SkinID="dropGen" DataSourceID="xdsPaging"
															OnSelectedIndexChanged="ddlPage_SelectedIndexChanged" AutoPostBack="True" DataValueField="Value"
															DataTextField="Text">
														</asp:DropDownList>
														<asp:XmlDataSource ID="xdsPaging" runat="server" DataFile="~/App_Data/PagingTable.xml">
														</asp:XmlDataSource>
													</td>
													<td class="ic">
														<asp:Button ID="btnPrev" OnClick="btnPrev_Click" runat="server" SkinID="btnGen" Text=" < ">
														</asp:Button>
													</td>
													<td class="lc">
														<asp:Label ID="lblPageInfo" runat="server"></asp:Label>
													</td>
													<td class="ic">
														<asp:Button ID="btnNext" OnClick="btnNext_Click" runat="server" SkinID="btnGen" Text=" > ">
														</asp:Button>
													</td>
													<td class="lc">
														Go to Page:</td>
													<td class="ic">
														<asp:TextBox ID="txtPageNo" onkeypress="return numberOnly(event);" runat="server"
															Width="20px"></asp:TextBox>
													</td>
													<td class="ic">
														<asp:Button ID="btnGo" OnClick="btnGo_Click" runat="server" Text="Go"></asp:Button></td>
												</tr>
											</tbody>
										</table>
									</td>
								</tr>
								<tr>
									<td style="text-align: right" class="ic" colspan="8">
										<asp:Button ID="btnDelete" OnClick="btnDelete_Click" runat="server" Text="Delete"
											ToolTip="Click here to delete Diary Details"></asp:Button>
										<asp:Button ID="btnAddNew" OnClick="btnAddNew_Click" runat="server" Text="Add New"
											ToolTip="Add new Diary Details"></asp:Button>
									</td>
								</tr>
								<tr>
									<td colspan="8">
										<asp:GridView ID="gvWorkerRW" runat="server" Width="100%" OnSorting="gvWorkerRW_Sorting"
											OnRowCommand="gvWorkerRW_RowCommand" DataKeyNames="PK_Workers_Comp_RW_ID" AutoGenerateColumns="false"
											AllowSorting="True" AllowPaging="True" OnRowDataBound="gvWorkerRW_RowDataBound">
											<Columns>
												<asp:TemplateField>
													<ItemTemplate>
														<input name="chkItem" onclick="javascript:ErimsUnChekcHeader()" type="checkbox" value='<%# Eval("PK_Workers_Comp_RW_ID")%>' />
													</ItemTemplate>
													<ItemStyle Width="10px" />
													<HeaderTemplate>
														<input name="chkHeader" onclick="javascript:setCheck(aspnetForm,this.checked)" type="checkbox" />
													</HeaderTemplate>
													<HeaderStyle Width="10px" />
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Date Of Transaction" SortExpression="Transaction_Date">
													<ItemTemplate>
														<asp:Label ID="lblDOTransaction" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Transaction_Date", "{0:MM/dd/yyyy}")%>'></asp:Label>
													</ItemTemplate>
												</asp:TemplateField>
												<asp:BoundField DataField="Indemnity_Total" HeaderText="Indemnity in Reserve $" SortExpression="Indemnity_Total" />
												<asp:BoundField DataField="Medical_Total" HeaderText="Medical in Reserve $" SortExpression="Medical_Total" />
												<asp:BoundField DataField="Expenses_Total" HeaderText="Expense in Reserve $" SortExpression="Expenses_Total" />
												<asp:BoundField DataField="Total" HeaderText="Total $" SortExpression="Total" />
												<asp:TemplateField>
													<ItemTemplate>
														<asp:Button ID="btnEdit" runat="server" CommandArgument='<%#Eval("PK_Workers_Comp_RW_ID")%>'
															CommandName="EditItem" Text="Edit" ToolTip="Edit" />
													</ItemTemplate>
													<ItemStyle HorizontalAlign="Center" Width="60px" />
												</asp:TemplateField>
												<asp:TemplateField>
													<ItemTemplate>
														<asp:Button ID="btnView" runat="server" CommandArgument='<%#Eval("PK_Workers_Comp_RW_ID")%>'
															CommandName="View" Text="View" ToolTip="View" />
													</ItemTemplate>
													<ItemStyle HorizontalAlign="Center" Width="60px" />
												</asp:TemplateField>
											</Columns>
											<PagerSettings Visible="False" />
										</asp:GridView>
									</td>
								</tr>
							</tbody>
						</table>
					</asp:View>
					<asp:View ID="vwWorkersDetail" runat="server">
						<table style="width: 100%">
							<tbody>
								<tr>
									<td>
										<asp:FormView ID="fvWorkersRW" runat="server" Width="100%" OnDataBound="fvWorkersRW_DataBound">
											<InsertItemTemplate>
												<table border="0" cellpadding="4" cellspacing="0" class="stylesheet" width="100%">
													<tr>
														<td class="ghc" colspan="6">
															Reserve Worksheet History</td>
													</tr>
													<tr>
														<td class="lc" style="width: 18%;">
															Date
														</td>
														<td style="width: 5px;">
															:</td>
														<td class="ic" style="width: 30%;">
															<asp:TextBox ID="txtMTCDate" runat="server" Text=""></asp:TextBox>
															<img id="imgMTCDate" runat="Server" align="absmiddle" onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvWorkersRW_txtMTCDate','mm/dd/y');"
																onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif" />
															<cc1:MaskedEditExtender ID="mskExMTCDate" runat="server" AcceptNegative="Left" AutoComplete="true"
																AutoCompleteValue="05/23/1964" CultureName="en-US" DisplayMoney="Left" Mask="99/99/9999"
																MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
																OnInvalidCssClass="MaskedEditError" TargetControlID="txtMTCDate">
															</cc1:MaskedEditExtender>
															<asp:RegularExpressionValidator ID="revDtSBegin" runat="server" ControlToValidate="txtMTCDate"
																Display="none" ErrorMessage="Date Not Valid(MTC Date)" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
																ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
														</td>
														<td class="lc" style="width: 18%;">
															Idemnity</td>
														<td style="width: 5px;">
															:</td>
														<td class="ic" style="width: 30%;">
															$<asp:TextBox ID="txtIdemnity" runat="server" MaxLength="11" onKeyPress="return(currencyFormat(this,',','.',event))"
																SkinID="txtCarrier" Text="0">
															</asp:TextBox></td>
													</tr>
													<tr>
														<td class="lc">
															Medical</td>
														<td>
															:</td>
														<td class="ic">
															$<asp:TextBox ID="txtMedical" runat="server" MaxLength="11" onKeyPress="return(currencyFormat(this,',','.',event))"
																SkinID="txtCarrier" Text="0">
															</asp:TextBox></td>
														<td class="lc">
															Expenses
														</td>
														<td>
															:</td>
														<td class="ic">
															$<asp:TextBox ID="txtExpense" runat="server" MaxLength="11" onKeyPress="return(currencyFormat(this,',','.',event))"
																SkinID="txtCarrier" Text="0">
															</asp:TextBox>
														</td>
													</tr>
													<tr>
														<td class="lc">
															Total</td>
														<td>
															:</td>
														<td class="ic">
															$<asp:Label ID="txtExpenseTotal" runat="server" SkinID="lblText" Text="0.00"></asp:Label>
														</td>
														<td class="lc">
															&nbsp;</td>
														<td>
															&nbsp;</td>
														<td class="ic">
															&nbsp;</td>
													</tr>
													<%--attachment--%>
													<tr>
														<td class="ghc" colspan="6">
															Attachment
														</td>
													</tr>
													<tr>
														<td>
															&nbsp;</td>
													</tr>
													<tr>
														<td class="lc" style="width: 134px;">
															Attachment Type
														</td>
														<td style="width: 5px;">
															:
														</td>
														<td class="ic" colspan="4">
															<asp:DropDownList runat="server" SkinID="dropGen" ID="ddlAttachType">
															</asp:DropDownList>
															<asp:RequiredFieldValidator ID="rfvAttachType" runat="server" ControlToValidate="ddlAttachType"
																Display="none" EnableClientScript="true" ErrorMessage="Please Select the Attachment Type."
																InitialValue="--Select Attachment Type--" ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
														</td>
													</tr>
													<tr>
														<td class="lc" style="width: 134px;">
															Attachment Description
														</td>
														<td style="width: 5px;">
															:
														</td>
														<td colspan="4" class="ic">
															<asp:TextBox ID="txtAttachDesc" runat="server" TextMode="MultiLine" Width="93%"></asp:TextBox>
														</td>
													</tr>
													<tr>
														<td class="lc" style="width: 134px;">
															Select File
														</td>
														<td class="lc" style="width: 5px;">
															:
														</td>
														<td colspan="4" class="ic">
															<asp:FileUpload ID="uplCommon" runat="server" />
															<asp:RequiredFieldValidator ID="rfvUpload" runat="server" ControlToValidate="uplCommon"
																EnableClientScript="true" Display="none" ErrorMessage="Please Select File to Upload."
																ValidationGroup="vsErrorGroup"> 
															</asp:RequiredFieldValidator>
														</td>
													</tr>
													<tr>
														<td class="ic" style="width: 134px">
															&nbsp;
														</td>
														<td>
															&nbsp;
														</td>
														<td colspan="4">
															&nbsp;
														</td>
													</tr>
													<%--attachment--%>
													<tr align="center">
														<td colspan="6" valign="top">
															<asp:Button ID="btnAddAttachment" runat="server" OnClick="btnAddAttachment_Click"
																OnClientClick="javascript:ValAttach();" Text="Add Attachment" ValidationGroup="vsErrorGroup" />
															<asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" OnClientClick="javascript:ValSave();"
																Text="Save" ValidationGroup="vsErrorGroup" />
															<asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
														</td>
													</tr>
												</table>
											</InsertItemTemplate>
											<EditItemTemplate>
												<table border="0" cellpadding="4" cellspacing="0" class="stylesheet" width="100%">
													<tr>
														<td class="ghc" colspan="6">
															Medical Treatment Costs</td>
													</tr>
													<tr>
														<td class="lc" style="width: 18%;">
															Date
														</td>
														<td style="width: 5px;">
															:</td>
														<td class="ic" style="width: 30%;">
															<asp:TextBox ID="txtMTCDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Transaction_Date", "{0:MM/dd/yyyy}")%>'></asp:TextBox>
															<img id="imgMTCDate" runat="Server" align="absmiddle" onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvWorkersRW_txtMTCDate','mm/dd/y');"
																onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif" />
															<cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AcceptNegative="Left"
																AutoComplete="true" AutoCompleteValue="05/23/1964" CultureName="en-US" DisplayMoney="Left"
																Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
																OnInvalidCssClass="MaskedEditError" TargetControlID="txtMTCDate">
															</cc1:MaskedEditExtender>
															<asp:RegularExpressionValidator ID="revDtSBegin" runat="server" ControlToValidate="txtMTCDate"
																Display="none" ErrorMessage="Date Not Valid(MTC Date)" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
																ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
														</td>
														<td class="lc" style="width: 18%;">
															Idemnity</td>
														<td style="width: 5px;">
															:</td>
														<td class="ic" style="width: 30%;">
															$<asp:TextBox ID="txtIdemnity" runat="server" MaxLength="11" onKeyPress="return(currencyFormat(this,',','.',event))"
																SkinID="txtCarrier" Text="0">
															</asp:TextBox></td>
													</tr>
													<tr>
														<td class="lc">
															Medical</td>
														<td>
															:</td>
														<td class="ic">
															$<asp:TextBox ID="txtMedical" runat="server" MaxLength="11" onKeyPress="return(currencyFormat(this,',','.',event))"
																SkinID="txtCarrier" Text="0">
															</asp:TextBox></td>
														<td class="lc">
															Expenses
														</td>
														<td>
															:</td>
														<td class="ic">
															$<asp:TextBox ID="txtExpense" runat="server" MaxLength="11" onKeyPress="return(currencyFormat(this,',','.',event))"
																SkinID="txtCarrier" Text="0">
															</asp:TextBox>
														</td>
													</tr>
													<tr>
														<td class="lc">
															Total</td>
														<td>
															:</td>
														<td class="ic">
															$<asp:Label ID="Label1" runat="server" SkinID="lblText" Text="0.00"></asp:Label>
														</td>
														<td class="lc">
															&nbsp;</td>
														<td>
															&nbsp;</td>
														<td class="ic">
															&nbsp;</td>
													</tr>
												</table>
												<%--Attachment--%>
												<table cellpadding="2" cellspacing="0" class="stylesheet" width="100%">
													<tr>
														<td class="ghc" colspan="6">
															Attachment
														</td>
													</tr>
													<tr>
														<td>
															&nbsp;</td>
													</tr>
													<tr>
														<td class="lc" style="width: 134px;">
															Attachment Type
														</td>
														<td style="width: 5px;">
															:
														</td>
														<td class="ic" colspan="4">
															<asp:DropDownList ID="ddlAttachType" runat="server" SkinID="dropGen">
															</asp:DropDownList>
															<asp:RequiredFieldValidator ID="rfvAttachType" runat="server" ControlToValidate="ddlAttachType"
																Display="none" EnableClientScript="true" ErrorMessage="Please Select the Attachment Type."
																InitialValue="--Select Attachment Type--" ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
														</td>
													</tr>
													<tr>
														<td class="lc" style="width: 134px;">
															Attachment Description
														</td>
														<td style="width: 5px;">
															:
														</td>
														<td colspan="4" class="ic">
															<asp:TextBox ID="txtAttachDesc" runat="server" TextMode="MultiLine" Width="93%"></asp:TextBox>
														</td>
													</tr>
													<tr>
														<td class="lc" style="width: 134px;">
															Select File
														</td>
														<td class="lc" style="width: 5px;">
															:
														</td>
														<td colspan="4" class="ic">
															<asp:FileUpload runat="server" ID="uplCommon" />
															<asp:RequiredFieldValidator ID="rfvUpload" runat="server" ControlToValidate="uplCommon"
																InitialValue="" Display="None" ErrorMessage="Please Select File to Upload." ValidationGroup="vsErrorGroup">                                                                        
															</asp:RequiredFieldValidator>
														</td>
													</tr>
													<tr>
														<td class="ic" style="width: 134px">
															&nbsp;
														</td>
														<td>
															&nbsp;
														</td>
														<td colspan="4">
															&nbsp;
														</td>
													</tr>
													<tr align="center">
														<td colspan="6" valign="top">
															<asp:Button ID="btnAddAttachment" runat="server" Text="Add Attachment" OnClientClick="javascript:ValAttach();"
																OnClick="btnAddAttachment_Click" ValidationGroup="vsErrorGroup" />
															<asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" OnClientClick="javascript:ValSave();"
																Text="Save" ValidationGroup="vsErrorGroup" />
															<asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
														</td>
													</tr>
												</table>
											</EditItemTemplate>
											<ItemTemplate>
												<table border="0" cellpadding="4" cellspacing="0" class="stylesheet" width="100%">
													<tr>
														<td class="ghc" colspan="6">
															Medical Treatment Costs</td>
													</tr>
													<tr>
														<td class="lc" style="width: 18%;">
															Date
														</td>
														<td style="width: 5px;">
															:</td>
														<td class="ic" style="width: 30%;">
															<asp:Label ID="lblMTCDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Transaction_Date", "{0:MM/dd/yyyy}")%>'></asp:Label></td>
														<td class="lc">
															Hospital</td>
														<td width="10">
															:</td>
														<td class="ic">
															$<asp:Label ID="Label2" runat="server" Text='<%#Eval("Hospital")%>'></asp:Label>
														</td>
													</tr>
													<tr>
														<td class="lc">
															Hospital</td>
														<td width="10">
															:</td>
														<td class="ic">
															$<asp:Label ID="lblHospital" runat="server" Text='<%#Eval("Hospital")%>'></asp:Label>
														</td>
														<td class="lc">
															Physician
														</td>
														<td>
															:</td>
														<td class="ic">
															$<asp:Label ID="lblPhysician" runat="server" Text='<%#Eval("Physician")%>'></asp:Label></td>
													</tr>
													<tr>
														<td class="lc">
															Radiology</td>
														<td>
															:</td>
														<td class="ic">
															$<asp:Label ID="lblRadiology" runat="server" Text='<%#Eval("Radiology")%>'></asp:Label></td>
														<td class="lc">
															Pharmacy</td>
														<td>
															:</td>
														<td class="ic">
															$<asp:Label ID="lblPharmacy" runat="server" Text='<%#Eval("Pharmacy")%>'></asp:Label>
														</td>
													</tr>
													<tr align="center">
														<td colspan="6" valign="top">
															<asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Back" />
														</td>
													</tr>
												</table>
											</ItemTemplate>
										</asp:FormView>
									</td>
								</tr>
								<tr>
									<td>
										<div style="display: none" id="dvAttachDetails" runat="server">
											<table width="100%">
												<tbody>
													<tr>
														<td colspan="2">
															<table style="font-weight: bolder; font-size: 10pt; color: white; font-family: Tahoma;
																background-color: #7f7f7f" cellspacing="1" width="100%">
																<tbody>
																	<tr>
																		<td class="ghc">
																			Attachment Details
																		</td>
																	</tr>
																</tbody>
															</table>
														</td>
													</tr>
													<tr>
														<td colspan="2">
															<asp:GridView ID="gvAttachmentDetails" runat="server" Width="100%" DataKeyNames="PK_Attachment_ID"
																AutoGenerateColumns="false" AllowSorting="False" AllowPaging="True" OnRowDataBound="gvAttachmentDetails_RowDataBound">
																<Columns>
																	<asp:TemplateField>
																		<ItemTemplate>
																			<input name="chkItem" type="checkbox" value='<%# Eval("PK_Attachment_ID")%>' onclick="javascript:ErimsUnChekcHeader()" />
																		</ItemTemplate>
																		<ItemStyle Width="10px" />
																		<HeaderTemplate>
																			<input type="checkbox" name="chkHeader" onclick="javascript:setCheck(aspnetForm,this.checked)" />
																		</HeaderTemplate>
																		<HeaderStyle Width="10px" />
																	</asp:TemplateField>
																	<asp:BoundField DataField="Attachment_Type" HeaderText="Attachment Type"></asp:BoundField>
																	<asp:BoundField DataField="Attachment_Description" HeaderText="Attachment Description">
																	</asp:BoundField>
																	<asp:BoundField DataField="Attachment_Name1" HeaderText="File Name"></asp:BoundField>
																	<asp:TemplateField HeaderText="Icon">
																		<ItemTemplate>
																			<asp:ImageButton ID="imgbtnDwnld" CommandName="Download" CommandArgument='<%# Eval("Attachment_Name")%>'
																				runat="server" ImageAlign="Left" ImageUrl="~/Images/download.gif" />
																		</ItemTemplate>
																		<ItemStyle HorizontalAlign="Center" Width="60px" />
																	</asp:TemplateField>
																</Columns>
																<EmptyDataRowStyle ForeColor="red" HorizontalAlign="Center" />
																<EmptyDataTemplate>
																	There is no attachement.
																</EmptyDataTemplate>
																<PagerSettings Visible="False" />
																<PagerSettings Visible="False" />
															</asp:GridView>
														</td>
													</tr>
													<tr>
														<td colspan="2">
															<asp:Button ID="btnRemove" runat="server" OnClick="btnRemove_Click" Text="Remove" />
															<asp:Button ID="btnMail" runat="server" OnClientClick="javascript:return OpenWMail('gvAttachmentDetails','Workers_Comp_RW');"
																Text="Mail" />
														</td>
													</tr>
												</tbody>
											</table>
										</div>
									</td>
								</tr>
							</tbody>
						</table>
					</asp:View>
				</asp:MultiView>
			</div>
			<%--View mode--%>
			<div id="dvViewAll" runat="server" style="display: none">
				<table border="0" cellpadding="4" cellspacing="2" style="width: 100%;">
					<tr>
						<td colspan="6">
							<asp:GridView ID="gvViewAll" runat="server" AutoGenerateColumns="false" Width="100%">
								<Columns>
									<asp:TemplateField>
										<ItemTemplate>
											<table border="0" cellpadding="4" cellspacing="0" class="stylesheet" width="100%">
												<tr>
													<td class="ghc" colspan="6">
														Medical Treatment Costs</td>
												</tr>
												<tr>
													<td class="lc" style="width: 18%;">
														Date
													</td>
													<td style="width: 5px;">
														:</td>
													<td class="ic" style="width: 30%;">
														<asp:Label ID="lblMTCDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Transaction_Date", "{0:MM/dd/yyyy}")%>'></asp:Label></td>
													<td class="lc" style="width: 18%;">
														&nbsp;</td>
													<td style="width: 5px">
														&nbsp;</td>
													<td class="ic" style="width: 30%;">
														&nbsp;</td>
												</tr>
												<tr>
													<td class="lc">
														Hospital</td>
													<td width="10">
														:</td>
													<td class="ic">
														$<asp:Label ID="lblHospital" runat="server" Text='<%#Eval("Hospital")%>'></asp:Label>
													</td>
													<td class="lc">
														Physician
													</td>
													<td>
														:</td>
													<td class="ic">
														$<asp:Label ID="lblPhysician" runat="server" Text='<%#Eval("Physician")%>'></asp:Label></td>
												</tr>
												<tr>
													<td class="lc">
														Radiology</td>
													<td>
														:</td>
													<td class="ic">
														$<asp:Label ID="lblRadiology" runat="server" Text='<%#Eval("Radiology")%>'></asp:Label></td>
													<td class="lc">
														Pharmacy</td>
													<td>
														:</td>
													<td class="ic">
														$<asp:Label ID="lblPharmacy" runat="server" Text='<%#Eval("Pharmacy")%>'></asp:Label>
													</td>
												</tr>
												<tr>
													<td class="lc">
														IME</td>
													<td>
														:</td>
													<td class="ic">
														$<asp:Label ID="lblIME" runat="server" Text='<%#Eval("IME")%>'></asp:Label></td>
													<td class="lc">
														Anesthesiologist</td>
													<td>
														:</td>
													<td class="ic">
														$<asp:Label ID="lblAnesthesiologist" runat="server" Text='<%#Eval("Anesthesiologist")%>'></asp:Label></td>
												</tr>
												<tr>
													<td class="lc">
														Nursing Care</td>
													<td>
														:</td>
													<td class="ic">
														$
														<asp:Label ID="lblNursingCare" runat="server" Text='<%#Eval("Nursing_Care")%>'></asp:Label>
													</td>
													<td class="lc">
														Transportation</td>
													<td>
														:</td>
													<td class="ic">
														$<asp:Label ID="lblTransportation" runat="server" Text='<%#Eval("Transportation")%>'></asp:Label></td>
												</tr>
												<tr>
													<td class="lc">
														Medical Report</td>
													<td>
														:</td>
													<td class="ic">
														$<asp:Label ID="lblMedicalReport" runat="server" Text='<%#Eval("Medical_Report")%>'></asp:Label></td>
													<td class="lc">
														Total</td>
													<td>
														:</td>
													<td class="ic">
														$<asp:Label ID="lblTotal" runat="server" SkinID="lblText" Text='<%#Eval("Medical_Total")%>'></asp:Label></td>
												</tr>
												<tr>
													<td bgcolor="#f0f2e1" class="ghc" colspan="6">
														Indemnity</td>
												</tr>
												<tr>
													<td class="lc">
														TTD Total Per Week</td>
													<td>
														:</td>
													<td class="ic">
														$<asp:Label ID="lblTTDperweek" runat="server" Text='<%#Eval("TTD_Payment")%>'></asp:Label></td>
													<td class="lc">
														TTD Weeks</td>
													<td>
														:</td>
													<td class="ic">
														<asp:Label ID="lblTTDWeeks" runat="server" Text='<%#Eval("TTD_Weeks")%>'></asp:Label></td>
												</tr>
												<tr>
													<td class="lc">
														TTD Total</td>
													<td>
														:</td>
													<td class="ic">
														$<asp:Label ID="lblTTDTotal" runat="server" SkinID="lblText" Text='<%#Eval("TTD_Total")%>'></asp:Label></td>
													<td class="lc">
														TPD Total Per Week</td>
													<td>
														:</td>
													<td class="ic">
														$<asp:Label ID="lblTTDTotalperweek" runat="server" Text='<%#Eval("TPD_Payment")%>'></asp:Label></td>
												</tr>
												<tr>
													<td class="lc">
														TPD Weeks</td>
													<td>
														:</td>
													<td class="ic">
														<asp:Label ID="lblTPDWeeks" runat="server" Text='<%#Eval("TPD_Weeks")%>'></asp:Label>
													</td>
													<td class="lc">
														TPD Total
													</td>
													<td>
														:</td>
													<td class="ic">
														$<asp:Label ID="lblTPDTotal" runat="server" SkinID="lblText" Text='<%#Eval("TPD_Total")%>'></asp:Label></td>
												</tr>
												<tr>
													<td class="ghc" colspan="6">
														Permanent Disability</td>
												</tr>
												<tr>
													<td class="lc">
														Estimated Award</td>
													<td>
														:</td>
													<td class="ic">
														$
														<asp:Label ID="lblEstAward" runat="server" Text='<%#Eval("Estimated_Award")%>'></asp:Label></td>
													<td class="lc">
														Death Benefit</td>
													<td>
														:</td>
													<td class="ic">
														$<asp:Label ID="lblDeathBenefit" runat="server" Text='<%#Eval("Death_Benefit")%>'></asp:Label></td>
												</tr>
												<tr>
													<td class="lc">
														Vocational Rehabilitation</td>
													<td>
														:</td>
													<td class="ic">
														$
														<asp:Label ID="lblVocRehab" runat="server" Text='<%#Eval("Vocational_Rehab")%>'></asp:Label></td>
													<td class="lc">
														Funeral Expense</td>
													<td>
														:</td>
													<td class="ic">
														$
														<asp:Label ID="lblFuneralExp" runat="server" Text='<%#Eval("Funeral_Expense")%>'></asp:Label></td>
												</tr>
												<tr>
													<td class="lc">
														Total</td>
													<td>
														:</td>
													<td class="ic">
														$
														<asp:Label ID="lblPerDisabilityTotal" runat="server" SkinID="lblText" Text='<%#Eval("Disability_Total")%>'></asp:Label></td>
													<td class="lc">
														&nbsp;</td>
													<td>
														&nbsp;</td>
													<td class="ic">
														&nbsp;</td>
												</tr>
												<tr>
													<td class="ghc" colspan="6">
														Expenses</td>
												</tr>
												<tr>
													<td class="lc">
														Defense Cost</td>
													<td>
														:</td>
													<td class="ic">
														$
														<asp:Label ID="lblDefenseCost" runat="server" Text='<%#Eval("Defense_Cost")%>'></asp:Label></td>
													<td class="lc">
														Medical Case Management</td>
													<td>
														:</td>
													<td class="ic">
														$
														<asp:Label ID="lblMedicalCaseMgmt" runat="server" Text='<%#Eval("Medical_Case_Management")%>'></asp:Label></td>
												</tr>
												<tr>
													<td class="lc">
														Surveillance</td>
													<td>
														:</td>
													<td class="ic">
														$<asp:Label ID="lblSurveillance" runat="server" Text='<%#Eval("Surveillance")%>'></asp:Label></td>
													<td class="lc">
														Court Costs</td>
													<td>
														:</td>
													<td class="ic">
														$<asp:Label ID="lblCourtCase" runat="server" Text='<%#Eval("Court_Costs")%>'></asp:Label></td>
												</tr>
												<tr>
													<td class="lc">
														Bill Review</td>
													<td>
														:</td>
													<td class="ic">
														$<asp:Label ID="lblBillReview" runat="server" Text='<%#Eval("Bill_Review")%>'></asp:Label></td>
													<td class="lc">
														Depositions</td>
													<td>
														:</td>
													<td class="ic">
														$<asp:Label ID="lblDiposition" runat="server" Text='<%#Eval("Depositions")%>'></asp:Label></td>
												</tr>
												<tr>
													<td class="lc">
														Other (1) - Description</td>
													<td>
														:</td>
													<td class="ic">
														<asp:Label ID="lblOtherDesc1" runat="server" Text='<%#Eval("Expense_Other_1_Description")%>'></asp:Label>
													</td>
													<td class="lc">
														Other (1) - Expense</td>
													<td>
														:</td>
													<td class="ic">
														$<asp:Label ID="lblOtherExp1" runat="server" Text='<%#Eval("Expense_Other_1")%>'></asp:Label></td>
												</tr>
												<tr>
													<td class="lc">
														Other (2) - Description</td>
													<td>
														:</td>
													<td class="ic">
														<asp:Label ID="lblOtherDesc2" runat="server" Text='<%#Eval("Expense_Other_2_Description")%>'></asp:Label>
													</td>
													<td class="lc">
														Other (2) - Expense</td>
													<td>
														:</td>
													<td class="ic">
														$<asp:Label ID="lblOtherExp2" runat="server" Text='<%#Eval("Expense_Other_2")%>'></asp:Label>
													</td>
												</tr>
												<tr>
													<td class="lc">
														Other (3) - Description</td>
													<td>
														:</td>
													<td class="ic">
														<asp:Label ID="lblOtherDesc3" runat="server" Text='<%#Eval("Expense_Other_3_Description")%>'></asp:Label>
													</td>
													<td class="lc">
														Other (3) - Expense</td>
													<td>
														:</td>
													<td class="ic">
														$
														<asp:Label ID="lblOtherExp3" runat="server" Text='<%#Eval("Expense_Other_3")%>'></asp:Label></td>
												</tr>
												<tr>
													<td class="lc">
														Total</td>
													<td>
														:</td>
													<td class="ic">
														$<asp:Label ID="lblExpenseTotal" runat="server" Text='<%#Eval("Expenses_Total")%>'></asp:Label></td>
													<td class="lc">
														&nbsp;</td>
													<td>
														&nbsp;</td>
													<td class="ic">
														&nbsp;</td>
												</tr>
											</table>
										</ItemTemplate>
									</asp:TemplateField>
								</Columns>
								<PagerSettings Visible="false" />
								<EmptyDataRowStyle ForeColor="red" HorizontalAlign="Center" />
								<EmptyDataTemplate>
									<table border="0" cellpadding="2" cellspacing="4" style="width: 100%;">
										<tr>
											<td align="center">
												Currently there is no Reserve Workseet record for the following claim.
											</td>
										</tr>
									</table>
								</EmptyDataTemplate>
							</asp:GridView>
						</td>
					</tr>
				</table>
			</div>
			<%--End View mode--%>
			<div style="display: none" id="dvOutstanding" runat="server">
				<table cellspacing="1" cellpadding="4" width="100%" border="0">
					<tbody>
						<tr>
							<td class="ghc" align="left" colspan="4">
								Outstanding</td>
						</tr>
						<tr>
							<td class="lc" align="center">
								<strong>Indemnity $</strong></td>
							<td class="lc" align="center">
								<strong>Medical $</strong></td>
							<td class="lc" align="center">
								<strong>Expenses $</strong></td>
							<td class="lc" align="center">
								<strong>Total $</strong>
							</td>
						</tr>
						<tr>
							<td class="lc" align="center">
								<asp:Label ID="lblIOutStand" runat="server"></asp:Label>
							</td>
							<td class="lc" align="center">
								<asp:Label ID="lblMOutStand" runat="server"></asp:Label>
							</td>
							<td class="lc" align="center">
								<asp:Label ID="lblEOutStand" runat="server"></asp:Label>
							</td>
							<td class="lc" align="center">
								<asp:Label ID="lblOSTotal" runat="server"></asp:Label>
							</td>
						</tr>
					</tbody>
				</table>
			</div>
			<div id="dvAttachment" runat="server" style="display: none">
				<table width="100%">
					<tbody>
						<tr>
							<td colspan="2">
								<table cellspacing="1" style="font-weight: bolder; font-size: 10pt; color: white;
									font-family: Tahoma; background-color: #7f7f7f" width="100%">
									<tbody>
										<tr>
											<td class="ghc">
												Attachment Details
											</td>
										</tr>
									</tbody>
								</table>
							</td>
						</tr>
						<tr>
							<td colspan="2">
								<asp:GridView ID="gvViewAttachment" runat="server" AllowPaging="True" AllowSorting="False"
									AutoGenerateColumns="false" DataKeyNames="PK_Attachment_ID" OnRowDataBound="gvViewAttachment_RowDataBound"
									Width="100%">
									<Columns>
										<asp:TemplateField>
											<ItemTemplate>
												<input name="chkItem" onclick="javascript:ErimsUnChekcHeader()" type="checkbox" value='<%# Eval("PK_Attachment_ID")%>' />
											</ItemTemplate>
											<ItemStyle Width="10px" />
											<HeaderTemplate>
												<input name="chkHeader" onclick="javascript:setCheck(aspnetForm,this.checked)" type="checkbox" />
											</HeaderTemplate>
											<HeaderStyle Width="10px" />
										</asp:TemplateField>
										<asp:BoundField DataField="Attachment_Type" HeaderText="Attachment Type" />
										<asp:BoundField DataField="Attachment_Description" HeaderText="Attachment Description" />
										<asp:BoundField DataField="Attachment_Name1" HeaderText="File Name" />
										<asp:TemplateField HeaderText="Icon">
											<ItemTemplate>
												<asp:ImageButton ID="imgbtnDwnld" runat="server" CommandArgument='<%# Eval("Attachment_Name")%>'
													CommandName="Download" ImageAlign="Left" ImageUrl="~/Images/download.gif" />
											</ItemTemplate>
											<ItemStyle HorizontalAlign="Center" Width="60px" />
										</asp:TemplateField>
									</Columns>
									<EmptyDataRowStyle ForeColor="red" HorizontalAlign="Center" />
									<EmptyDataTemplate>
										There is no attachement.
									</EmptyDataTemplate>
									<PagerSettings Visible="False" />
									<PagerSettings Visible="False" />
								</asp:GridView>
							</td>
						</tr>
					</tbody>
				</table>
			</div>
		</div>
		<div id="divbtn" runat="server">
			<table style="width: 100%">
				<tbody>
					<tr>
						<td class="ic" align="center">
							<asp:Button ID="btnNextStep" OnClick="btnNextStep_Click" runat="server" Text="Next Step">
							</asp:Button>
						</td>
					</tr>
				</tbody>
			</table>
		</div>
	</div>
</asp:Content>
