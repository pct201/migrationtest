<%@ Page AutoEventWireup="true" CodeFile="WorkerCompensationReserve.aspx.cs" Inherits="WorkerCompensation_WorkerCompensationReserve"
    Language="C#" MasterPageFile="~/Default.master" Title="Risk Insurance Management System" %>

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
    <%--<asp:UpdatePanel ID="pnlWorkersRW" runat="server">
		<contenttemplate>--%>

    <script type="text/javascript">
    function MinMax()
    {
        if(document.getElementById("ctl00_ContentPlaceHolder1_fvWorkersRW_txtAttachDesc").style.height == "")
        {
            document.getElementById("ctl00_ContentPlaceHolder1_fvWorkersRW_ibtnAttachDesc").src = "../Images/minus.jpg";
            document.getElementById("ctl00_ContentPlaceHolder1_fvWorkersRW_txtAttachDesc").style.height = "200px";
            document.getElementById("pnlAttachDesc").style.display = "block";
        }
        else if(document.getElementById("ctl00_ContentPlaceHolder1_fvWorkersRW_txtAttachDesc").style.height == "200px")
        {
             document.getElementById("ctl00_ContentPlaceHolder1_fvWorkersRW_ibtnAttachDesc").src = "../Images/plus.jpg";
            document.getElementById("ctl00_ContentPlaceHolder1_fvWorkersRW_txtAttachDesc").style.height="";
            document.getElementById("pnlAttachDesc").style.display = "none";
        }
        return false;
    }
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
	function MTCTotal()
	{
		//document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtTotal').value = (
		document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtTotal').innerHTML = Math.round((
	 	parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtHospital').value.replace(",","").replace(",","")) + 
		parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtPhysician').value.replace(",","").replace(",","")) + 
		parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtRadiology').value.replace(",","").replace(",","")) + 
		parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtPharmacy').value.replace(",","").replace(",","")) + 
		parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtIME').value.replace(",","").replace(",","")) + 
		parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtAnesthesiologist').value.replace(",","").replace(",","")) + 
		parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtNursingCare').value.replace(",","").replace(",","")) + 
		parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtTransportation').value.replace(",","").replace(",","")) + 
		parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtMedicalReport').value.replace(",","").replace(",",""))) * Math.pow(10,2))/Math.pow(10,2);
		
	}
	
	function PerDisaTotal()
	{
	//EstAwd  + death benefit + voca rehab +Fun exp = Per DIs total 
		document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtPerDisabilityTotal').innerHTML = Math.round((
	 	parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtEstAward').value.replace(",","").replace(",","")) + 
		parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtDeathBenefit').value.replace(",","").replace(",","")) + 
		parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtVocRehab').value.replace(",","").replace(",","")) + 
		parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtFuneralExp').value.replace(",","").replace(",",""))  +
		parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtTTDTotal').innerHTML.replace(",","").replace(",","")) +
		parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtTPDTotal').innerHTML.replace(",","").replace(",","")) 		
		)* Math.pow(10,2))/Math.pow(10,2);
		
		document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtPDT').innerHTML = Math.round((
	 	parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtEstAward').value.replace(",","").replace(",","")) + 
		parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtDeathBenefit').value.replace(",","").replace(",","")) + 
		parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtVocRehab').value.replace(",","").replace(",","")) + 
		parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtFuneralExp').value.replace(",","").replace(",","")) 		
		)* Math.pow(10,2))/Math.pow(10,2);
	}
	
	function ExpenseTotal()
	{
	//Defense Cost+Medical Case Management+Surveillance+Court Costs+Bill Review+Depositions+Other (1) - Expense+Other (2) - Expense+Other (3) - Expense=Toal
		
		document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtExpenseTotal').innerHTML = Math.round((
	 	parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtDefenseCost').value.replace(",","").replace(",","")) + 
		parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtMedicalCaseMgmt').value.replace(",","").replace(",","")) + 
		parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtSurveillance').value.replace(",","").replace(",","")) + 
		parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtCourtCase').value.replace(",","").replace(",","")) + 
		parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtBillReview').value.replace(",","").replace(",","")) + 
		parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtDiposition').value.replace(",","").replace(",","")) + 
		parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtOtherExp1').value.replace(",","").replace(",","")) + 
		parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtOtherExp2').value.replace(",","").replace(",","")) + 
		parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtOtherExp3').value.replace(",","").replace(",","")))* Math.pow(10,2))/Math.pow(10,2);
	}
	function TTDCalculation()
	{
	//ttdtotalperweek * TTDWeeks = ttdtotal 
		if (document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtTTDWeeks').value == "")
			document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtTTDWeeks').value = "0";
		else
			document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtTTDWeeks').value = parseInt(document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtTTDWeeks').value.replace(",","").replace(",",""));
			
			
		document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtTTDTotal').innerHTML = (
	 	parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtTTDperweek').value.replace(",","").replace(",","")) * 
		parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtTTDWeeks').value.replace(",","").replace(",",""))  
		);
		PerDisaTotal();

	}
	function TPDCalculation()
	{
	/*
	tpdtotalperweek * TpDWeeks = tpdtotal*/
		if (document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtTPDWeeks').value == "")
			document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtTPDWeeks').value= "0";
		else
			document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtTPDWeeks').value= parseInt(document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtTPDWeeks').value.replace(",","").replace(",",""));
		
		document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtTPDTotal').innerHTML = (
	 	parseFloat(document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtTPDperweek').value.replace(",","").replace(",","")) * 
		parseInt(document.getElementById('ctl00_ContentPlaceHolder1_fvWorkersRW_txtTPDWeeks').value.replace(",","").replace(",","")) 
		);
		
		PerDisaTotal();
	}
	
	
 function openWindow(strURL)
    {
        oWnd=window.open(strURL,"Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=300");
        oWnd.moveTo(260,180);
        return false;
        
    }
    function openMailWindow(strURL)
    {
        //oWnd=window.open("Mail.aspx?AttName="+ strURL,"Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=0,toolbar=0,width=500,height=280");
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
                        <td style="background-image: url(../images/normal_btn.jpg)" class="normal_tab" valign="middle"
                            align="center">
                            <a class="main_menu" href="WorkersCompensation.aspx">Worker's Compensation</a></td>
                        <td style="background-image: url(../images/active_btn.jpg)" class="active_tab" valign="middle"
                            align="center">
                            Reserve Worksheets</td>
                        <td style="background-image: url(../images/normal_btn.jpg)" class="normal_tab" valign="middle"
                            align="center">
                            <a class="main_menu" href="Carrier.aspx">Carrier Data</a></td>
                        <td style="background-image: url(../images/normal_btn.jpg)" class="normal_tab" valign="middle"
                            align="center">
                            <a class="main_menu" href="subrogation.aspx">Subrogation</a></td>
                        <td style="background-image: url(../images/normal_btn.jpg)" class="normal_tab" valign="middle"
                            align="center">
                            <a class="main_menu" href="SubrogationDetail.aspx">Subrogation Detail</a></td>
                        <td style="background-image: url(../images/normal_btn.jpg)" class="normal_tab" valign="middle"
                            align="center">
                            <a class="main_menu" href="CheckRegister.aspx">Check Register</a></td>
                        <td style="background-image: url(../images/normal_btn.jpg)" class="normal_tab" valign="middle"
                            align="center">
                            <a class="main_menu" href="MainDiary.aspx">Diary</a></td>
                        <td style="background-image: url(../images/normal_btn.jpg)" class="normal_tab" valign="middle"
                            align="center">
                            <a class="main_menu" href="MainAdjuster.aspx">Adjustor Notes</a></td>
                        <td style="background-image: url(../images/normal_btn.jpg)" class="normal_tab" valign="middle"
                            align="center">
                            <a class="main_menu" href="Settlement.aspx">Settlement</a></td>
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
                            <asp:LinkButton ID="lbtnPaymentDetails" runat="server" CssClass="left_menu" OnClick="lbtnPaymentDetails_Click"
                                Text="Payment Details"></asp:LinkButton>
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
                <table class="stylesheet" cellspacing="2" cellpadding="2" width="100%" border="0">
                    <tbody>
                        <tr>
                            <td class="ghc" colspan="6">
                                Claim Details<asp:Label ID="lblTemp" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                       <%-- <tr>
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
                                    <asp:ListItem Selected="true">Yes</asp:ListItem>
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
                        </tr>--%>
                        <tr>
                                <td style="width:25%;" align="left" class="lc">
                                    <asp:Label runat="server" ID="lblClaimNo">Claim Number</asp:Label> 
                                </td>
                                <td  align="Center" class="lc">
                                    :
                                </td>
                                <td style="width:25%;" align="left" class="ic">
                                    <asp:Label runat="server" ID="lblClaimNumber"></asp:Label>
                                </td>
                                
                                 <td style="width:25%;" align="left" class="lc">
                                    <asp:Label runat="server" ID="lblMEmployee">Employee</asp:Label>
                                </td>
                                <td  align="Center" class="lc">
                                    :
                                </td>
                                <td style="width:25%;" align="left" class="ic">
                                    <asp:RadioButtonList ID="rbtnEmployee" runat="server" Enabled="false" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="true">Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                
                                
                                
                               
                                
                            </tr>
                            <tr>
                                <td style="width:25%;" align="left" class="lc">
                                    <asp:Label runat="server" ID="lblMLastName">Name</asp:Label>
                                </td>
                                <td  align="Center" class="lc">
                                    :
                                </td>
                                <td style="width:25%;" align="left" class="ic">
                                    <asp:Label runat="server" ID="lblLastName"></asp:Label>&nbsp;
                                    <asp:Label runat="server" ID="lblMidleName"></asp:Label>&nbsp;
                                    <asp:Label runat="server" ID="lblFirstName"></asp:Label>
                                </td>
                               
                                
                                <td style="width:25%;" align="left" class="lc">
                                    <asp:Label runat="server" ID="lblMDOIncident">Date of Incident</asp:Label> 
                                </td>
                                <td  align="Center" class="lc">
                                    :
                                </td>
                                <td style="width:25%;" align="left" class="ic">
                                    <asp:Label runat="server" ID="lblIncidentDt"></asp:Label>
                                </td>
                               
                               
                                <%--<td style="width:25%;" align="left" class="lc">
                                    <asp:Label runat="server" ID="lblMFirstName"> First Name</asp:Label>
                                </td>
                                <td  align="Center" class="lc">
                                    :
                                </td>
                                <td style="width:25%;" align="left" class="ic">
                                    <asp:Label runat="server" ID="lblFName"></asp:Label>
                                </td>--%>
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
                                    <td style="width: 70%" align="right">
                                        <table width="95%">
                                            <tbody>
                                                <tr>
                                                    <td class="lc" valign="middle">
                                                      <asp:Label runat="server" ID="lblNoOFPage"> No. of Records per page :&nbsp;</asp:Label> 
                                                       
                                                        <asp:DropDownList ID="ddlPage" runat="server" SkinID="dropGen" DataSourceID="xdsPaging"
                                                            OnSelectedIndexChanged="ddlPage_SelectedIndexChanged" AutoPostBack="True" DataValueField="Value"
                                                            DataTextField="Text">
                                                        </asp:DropDownList>
                                                        <asp:XmlDataSource ID="xdsPaging" runat="server" DataFile="~/App_Data/PagingTable.xml">
                                                        </asp:XmlDataSource>
                                                    </td>
                                                    <td class="ic" valign="middle">
                                                        <asp:Button ID="btnPrev" OnClick="btnPrev_Click" runat="server" SkinID="btnGen" Text=" < ">
                                                        </asp:Button>
                                                    </td>
                                                    <td class="lc" valign="middle">
                                                        <asp:Label ID="lblPageInfo" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="ic" valign="middle">
                                                        <asp:Button ID="btnNext" OnClick="btnNext_Click" runat="server" SkinID="btnGen" Text=" > ">
                                                        </asp:Button>
                                                    </td>
                                                    <td class="lc" valign="middle">
                                                     <asp:Label runat="server" ID="lblGoTOPage">  Go to Page:</asp:Label> 
                                                       </td>
                                                    <td class="ic" valign="middle">
                                                        <asp:TextBox ID="txtPageNo" onkeypress="return numberOnly(event);" runat="server"
                                                            Width="20px"></asp:TextBox>
                                                    </td>
                                                    <td class="ic" valign="middle">
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
                                            AllowSorting="True" AllowPaging="True" OnRowDataBound="gvWorkerRW_RowDataBound" OnRowCreated="gvWorkerRW_RowCreated">
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
                                                <asp:TemplateField HeaderText="Date Of Transaction" HeaderStyle-HorizontalAlign ="Right" ItemStyle-HorizontalAlign="Right" SortExpression="Transaction_Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDOTransaction" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Transaction_Date", "{0:MM/dd/yyyy}")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:BoundField DataField="Transaction_Date" HeaderText="Date of Transaction" SortExpression="Transaction_Date" />--%>
                                                <asp:BoundField DataField="Indemnity_Total" HeaderStyle-HorizontalAlign ="Right" ItemStyle-HorizontalAlign="Right" HeaderText="Property Damage in Reserve $" SortExpression="Indemnity_Total" />
                                                <asp:BoundField DataField="Medical_Total" HeaderStyle-HorizontalAlign ="Right" ItemStyle-HorizontalAlign="Right" HeaderText="Bodily Injury in Reserve $" SortExpression="Medical_Total" />
                                                <asp:BoundField DataField="Expenses_Total" HeaderStyle-HorizontalAlign ="Right" ItemStyle-HorizontalAlign="Right" HeaderText="Expense in Reserve $" SortExpression="Expenses_Total" />
                                                <asp:BoundField DataField="Total" HeaderStyle-HorizontalAlign ="Right" ItemStyle-HorizontalAlign="Right" HeaderText="Total $" SortExpression="Total" />
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
                                                            Bodily Injury Treatment Costs</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc" style="width: 18%;">
                                                          <asp:Label runat="server" ID="lblDate">Date</asp:Label> 
                                                            
                                                        </td>
                                                        <td style="width: 5px;">
                                                            :</td>
                                                        <td class="ic" style="width: 30%;">
                                                            <asp:TextBox ID="txtMTCDate" runat="server" Text="" SkinID="txtDate"></asp:TextBox>
                                                            <%--<asp:ImageButton ID="btnICal" runat="server" ImageUrl="~/Images/iconPicDate.gif" />--%>
                                                            <img id="imgMTCDate" runat="Server" align="absmiddle" onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvWorkersRW_txtMTCDate','mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif" />
                                                            <%--<cc1:CalendarExtender ID="ICalendarExtender1" runat="server" PopupButtonID="btnICal"
																	TargetControlID="txtMTCDate">
																</cc1:CalendarExtender>--%>
                                                            <cc1:MaskedEditExtender ID="mskExMTCDate" runat="server" AcceptNegative="Left" AutoComplete="true"
                                                                AutoCompleteValue="05/23/1964" CultureName="en-US" DisplayMoney="Left" Mask="99/99/9999"
                                                                MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                OnInvalidCssClass="MaskedEditError" TargetControlID="txtMTCDate">
                                                            </cc1:MaskedEditExtender>
                                                            <asp:RegularExpressionValidator ID="revDtSBegin" runat="server" ControlToValidate="txtMTCDate"
                                                                Display="dynamic" ErrorMessage="Date Not Valid(MTC Date)" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td class="lc" style="width: 18%;">
                                                            &nbsp;</td>
                                                        <td style="width: 5px;">
                                                            &nbsp;</td>
                                                        <td class="ic" style="width: 30%;">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                         <asp:Label runat="server" ID="lablHospital">Hospital</asp:Label> 
                                                            </td>
                                                        <td style="width: 10px">
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtHospital" SkinID="txtAmt" runat="server" MaxLength="13" onBlur="return MTCTotal();"
                                                                onKeyPress="return(currencyFormat(this,',','.',event))" Text="0">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td class="lc">
                                                         <asp:Label runat="server" ID="lablPhysician"> Physician</asp:Label> 
                                                           
                                                        </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtPhysician" SkinID="txtAmt" runat="server" MaxLength="14" onBlur="return MTCTotal();"
                                                                onKeyPress="return(currencyFormat(this,',','.',event))" Text="0">
                                                            </asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                           <asp:Label runat="server" ID="lablRadiology"> Radiology</asp:Label> 
                                                            </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtRadiology" SkinID="txtAmt" runat="server" MaxLength="14" onBlur="return MTCTotal();"
                                                                onKeyPress="return(currencyFormat(this,',','.',event))" Text="0">
                                                            </asp:TextBox></td>
                                                        <td class="lc">
                                                          <asp:Label runat="server" ID="lablPharmacy"> Pharmacy</asp:Label> 
                                                            </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtPharmacy" SkinID="txtAmt" runat="server" MaxLength="14" onBlur="return MTCTotal();"
                                                                onKeyPress="return(currencyFormat(this,',','.',event))" Text="0">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                         <asp:Label runat="server" ID="lablIME"> IME</asp:Label> 
                                                            </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtIME" SkinID="txtAmt" runat="server" MaxLength="14" onBlur="return MTCTotal();"
                                                                onKeyPress="return(currencyFormat(this,',','.',event))" Text="0">
                                                            </asp:TextBox></td>
                                                        <td class="lc">
                                                         <asp:Label runat="server" ID="lablAnesthesiologist"> Anesthesiologist</asp:Label> 
                                                            </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtAnesthesiologist" SkinID="txtAmt" runat="server" MaxLength="14"
                                                                onBlur="return MTCTotal();" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                                Text="0">
                                                            </asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                         <asp:Label runat="server" ID="lablNursing">  Nursing Care</asp:Label> 
                                                           </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtNursingCare" SkinID="txtAmt" runat="server" MaxLength="14" onBlur="return MTCTotal();"
                                                                onKeyPress="return(currencyFormat(this,',','.',event))" Text="0">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td class="lc">
                                                        <asp:Label runat="server" ID="lablTransportation">Transportation</asp:Label> 
                                                            </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtTransportation" SkinID="txtAmt" runat="server" MaxLength="14"
                                                                onBlur="return MTCTotal();" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                                Text="0">
                                                            </asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                         <asp:Label runat="server" ID="lablMedicalReport">Medical Report</asp:Label> 
                                                            </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtMedicalReport" SkinID="txtAmt" runat="server" MaxLength="14"
                                                                onBlur="return MTCTotal();" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                                Text="0">
                                                            </asp:TextBox></td>
                                                        <td class="lc">
                                                         <asp:Label runat="server" ID="Lab1MedicalTotal">Bodily Injury Total</asp:Label> 
                                                            </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:Label ID="txtTotal" runat="server" SkinID="lblText" Text="0.00"></asp:Label>
                                                            <%--<asp:TextBox ID="txtTotal" runat="server" MaxLength="14" onKeyPress="return(currencyFormat(this,',','.',event))"
																SkinID="txtAmt" Text="0">
															</asp:TextBox>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td bgcolor="#F0F2E1" class="ghc" colspan="6">
                                                          <asp:Label runat="server" ID="lablIndemnityHead">Property Damage</asp:Label> 
                                                            </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <table width="87%">
                                                                <tr>
                                                                    <td class="lc" style="width: 22%;" align="left">
                                                                     <asp:Label runat="server" ID="lablTTDTotalPerWeek">TTD Total Per Week</asp:Label> 
                                                                        </td>
                                                                    <td>
                                                                        :</td>
                                                                    <td class="ic" style="width: 32%;" align="left">
                                                                        $<asp:TextBox ID="txtTTDperweek" SkinID="txtAmt" MaxLength="13" runat="server"  onBlur="return TTDCalculation();"
                                                                            onKeyPress="return(currencyFormat(this,',','.',event))" Text="0">
                                                                        </asp:TextBox></td>
                                                                    <td class="lc" style="width: 12%;" align="left">
                                                                      <asp:Label runat="server" ID="lablTTDWeeks">TTD Weeks</asp:Label> 
                                                                        </td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 12%;" align="left">
                                                                        <asp:TextBox ID="txtTTDWeeks" runat="server" MaxLength="3" onBlur="return TTDCalculation();"
                                                                            onKeyPress="return numberOnly(event);" Text="0" Width="50px" >
                                                                        </asp:TextBox></td>
                                                                    <td class="lc" style="width: 12%;" align="left">
                                                                      <asp:Label runat="server" ID="lablTTDTotal">TTD Total</asp:Label> 
                                                                        </td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 12%;" align="left">
                                                                        $<asp:Label ID="txtTTDTotal" runat="server" SkinID="lblText" Text="0.00"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <table width="87%">
                                                                <tr>
                                                                    <td class="lc" style="width: 22%;" align="left">
                                                                      <asp:Label runat="server" ID="lablTPDTotalPerWeek"> TPD Total Per Week</asp:Label> 
                                                                       
                                                                    </td>
                                                                    <td>
                                                                        :</td>
                                                                    <td class="ic" style="width: 32%;" align="left">
                                                                        $<asp:TextBox ID="txtTPDperweek" SkinID="txtAmt" runat="server" MaxLength="13" onBlur="return TPDCalculation();"
                                                                            onKeyPress="return(currencyFormat(this,',','.',event))" Text="0">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                    <td class="lc" style="width: 12%;" align="left">
                                                                     <asp:Label runat="server" ID="lablTPDWeeks"> TPD Weeks</asp:Label> 
                                                                       
                                                                    </td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 12%;" align="left">
                                                                        <asp:TextBox ID="txtTPDWeeks" runat="server"  onBlur="return TPDCalculation();"
                                                                            onKeyPress="return numberOnly(event);" Text="0" Width="50px" MaxLength="3">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                    <td class="lc" style="width: 12%;" align="left">
                                                                       <asp:Label runat="server" ID="lablTPDTotal"> TPD Total</asp:Label> 
                                                                      
                                                                    </td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 12%;" align="left">
                                                                        $<asp:Label ID="txtTPDTotal" runat="server" SkinID="lblText" Text="0.00"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="ghc" colspan="6">
                                                            <asp:Label runat="server" ID="lablPermaDisability">Permanent Disability</asp:Label> 
                                                            </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                          <asp:Label runat="server" ID="lablEstimatedAward"> Estimated Award</asp:Label> 
                                                           </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtEstAward" SkinID="txtAmt" runat="server" MaxLength="14" onBlur="return PerDisaTotal();"
                                                                onKeyPress="return(currencyFormat(this,',','.',event))" Text="0">
                                                            </asp:TextBox></td>
                                                        <td class="lc">
                                                         <asp:Label runat="server" ID="lablDeathBenefit">Death Benefit</asp:Label> 
                                                            </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtDeathBenefit" SkinID="txtAmt" runat="server" MaxLength="14"
                                                                onBlur="return PerDisaTotal();" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                                Text="0">
                                                            </asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                          <asp:Label runat="server" ID="lablVocatRehabilitation"> Vocational Rehabilitation</asp:Label> 
                                                           </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtVocRehab" SkinID="txtAmt" runat="server" MaxLength="14" onBlur="return PerDisaTotal();"
                                                                onKeyPress="return(currencyFormat(this,',','.',event))" Text="0">
                                                            </asp:TextBox></td>
                                                        <td class="lc">
                                                         <asp:Label runat="server" ID="lablFuneralExpense">Funeral Expense</asp:Label> 
                                                            </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtFuneralExp" SkinID="txtAmt" runat="server" MaxLength="14" onBlur="return PerDisaTotal();"
                                                                onKeyPress="return(currencyFormat(this,',','.',event))" Text="0">
                                                            </asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        
                                                        <td class="lc">
                                                           <asp:Label runat="server" ID="lablPermenantDisaTotal"> Permanent Disability Total</asp:Label> 
                                                           </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:Label ID="txtPDT" runat="server" SkinID="lblText" Text="0.00"></asp:Label></td>
                                                        <td class="lc">
                                                        <asp:Label runat="server" ID="lablIndemnityTotal">Property Damage Total</asp:Label> 
                                                            </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:Label ID="txtPerDisabilityTotal" runat="server" SkinID="lblText" Text="0.00"></asp:Label>
                                                            <%--<asp:TextBox ID="txtPerDisabilityTotal" runat="server" MaxLength="14" onKeyPress="return(currencyFormat(this,',','.',event))"
																SkinID="txtAmt" Text="0">
															</asp:TextBox>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="ghc" colspan="6">
                                                          <asp:Label runat="server" ID="lablExpensesHead">Expenses</asp:Label> 
                                                            </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                           <asp:Label runat="server" ID="lablDefenseCost">Defense Cost</asp:Label> 
                                                            </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtDefenseCost" SkinID="txtAmt" runat="server" MaxLength="14" onBlur="return ExpenseTotal();"
                                                                onKeyPress="return(currencyFormat(this,',','.',event))" Text="0">
                                                            </asp:TextBox></td>
                                                        <td class="lc">
                                                           <asp:Label runat="server" ID="lablMedicalCaseManag"> Medical Case Management</asp:Label> 
                                                           </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtMedicalCaseMgmt" SkinID="txtAmt" runat="server" MaxLength="14"
                                                                onBlur="return ExpenseTotal();" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                                Text="0">
                                                            </asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                           <asp:Label runat="server" ID="lablSurveillance">Surveillance</asp:Label> 
                                                            </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtSurveillance" SkinID="txtAmt" runat="server" MaxLength="14"
                                                                onBlur="return ExpenseTotal();" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                                Text="0">
                                                            </asp:TextBox></td>
                                                        <td class="lc">
                                                          <asp:Label runat="server" ID="lablCourtCosts"> Court Costs</asp:Label> 
                                                           </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtCourtCase" SkinID="txtAmt" runat="server" MaxLength="14" onBlur="return ExpenseTotal();"
                                                                onKeyPress="return(currencyFormat(this,',','.',event))" Text="0">
                                                            </asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                          <asp:Label runat="server" ID="lablBillReview"> Bill Review</asp:Label> 
                                                           </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtBillReview" SkinID="txtAmt" runat="server" MaxLength="14" onBlur="return ExpenseTotal();"
                                                                onKeyPress="return(currencyFormat(this,',','.',event))" Text="0">
                                                            </asp:TextBox></td>
                                                        <td class="lc">
                                                          <asp:Label runat="server" ID="lablDepositions">Depositions</asp:Label> 
                                                            </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtDiposition" SkinID="txtAmt" runat="server" MaxLength="14" onBlur="return ExpenseTotal();"
                                                                onKeyPress="return(currencyFormat(this,',','.',event))" Text="0">
                                                            </asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                          <asp:Label runat="server" ID="lablOtherDescription1"> Other (1) - Description</asp:Label> 
                                                           </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            <asp:TextBox ID="txtOtherDesc1" runat="server" Text="">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td class="lc">
                                                         <asp:Label runat="server" ID="lablOtherExpense1"> Other (1) - Expense</asp:Label> 
                                                           </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtOtherExp1" SkinID="txtAmt" runat="server" MaxLength="14" onBlur="return ExpenseTotal();"
                                                                onKeyPress="return(currencyFormat(this,',','.',event))" Text="0">
                                                            </asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                          <asp:Label runat="server" ID="lablOtherDescription2"> Other (2) - Description</asp:Label> 
                                                           </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            <asp:TextBox ID="txtOtherDesc2" runat="server" Text="">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td class="lc">
                                                        <asp:Label runat="server" ID="lablOtherExpense2"> Other (2) - Expense</asp:Label> 
                                                           </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtOtherExp2" SkinID="txtAmt" runat="server" MaxLength="14" onBlur="return ExpenseTotal();"
                                                                onKeyPress="return(currencyFormat(this,',','.',event))" Text="0">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                           <asp:Label runat="server" ID="lablOtherDescription3">  Other (3) - Description</asp:Label> 
                                                           </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            <asp:TextBox ID="txtOtherDesc3" runat="server" Text="">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td class="lc">
                                                          <asp:Label runat="server" ID="lablOtherExpense3">    Other (3) - Expense</asp:Label> 
                                                        </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtOtherExp3" SkinID="txtAmt" runat="server" MaxLength="14" onBlur="return ExpenseTotal();"
                                                                onKeyPress="return(currencyFormat(this,',','.',event))" Text="0">
                                                            </asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                        <asp:Label runat="server" ID="lablExpenseTotal">Expense Total</asp:Label> 
                                                            </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:Label ID="txtExpenseTotal" runat="server" SkinID="lblText" Text="0.00"></asp:Label>
                                                            <%--<asp:TextBox ID="txtExpenseTotal" runat="server" MaxLength="14" onKeyPress="return(currencyFormat(this,',','.',event))"
																SkinID="txtAmt" Text="0">
															</asp:TextBox>--%>
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
                                                          <asp:Label runat="server" ID="lblAttachment">Attachment</asp:Label> 
                                                            
                                                        </td>
                                                    </tr>
                                                    <tr style="display:none;">
                                                        <td class="lc" style="width: 134px;" valign="top">
                                                          <asp:Label runat="server" ID="lablAttachmentType">  Attachment Type</asp:Label> 
                                                          
                                                        </td>
                                                        <td style="width: 5px;" valign="top" class="ic">
                                                            :
                                                        </td>
                                                        <td class="ic" colspan="4" valign="top">
                                                            <asp:DropDownList runat="server" SkinID="dropGen" ID="ddlAttachType">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfvAttachType" runat="server" ControlToValidate="ddlAttachType"
                                                                Display="none" Text="*" EnableClientScript="true" ErrorMessage="Please Select the Attachment Type."
                                                                InitialValue="--Select Attachment Type--" ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc" style="width: 134px;" valign="top">
                                                         <asp:Label runat="server" ID="lblAttachDesc">   Attachment Description</asp:Label> 
                                                         
                                                        </td>
                                                        <td style="width: 5px;" valign="top" class="lc">
                                                            :
                                                        </td>
                                                        <td colspan="4" class="ic" valign="top">
                                                            <asp:ImageButton ID="ibtnAttachDesc" ImageUrl="~/Images/minus.jpg" runat="server" OnClientClick="javascript:return MinMax();" />
                                                            <div id="pnlAttachDesc" style="display:block;">  
                                                                <asp:TextBox ID="txtAttachDesc" runat="server" TextMode="MultiLine" Width="93%" Height="200px" MaxLength="4000"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc" style="width: 134px;" valign="top">
                                                            Select File
                                                        </td>
                                                        <td class="lc" style="width: 5px;" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" class="ic" valign="top">
                                                            <asp:FileUpload ID="uplCommon" runat="server" />
                                                            <asp:RequiredFieldValidator ID="rfvUpload" runat="server" ControlToValidate="uplCommon"
                                                                EnableClientScript="true" Display="none" Text="*" ErrorMessage="Please Select File to Upload."
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
                                                            <%--				<asp:Button ID="btnAddAttachment" runat="server" CausesValidation="true" OnClick="btnAddAttachment_Click"
																Text="Add Attachment" ValidationGroup="vsErrorGroup" />
															<asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" />
															<asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
											--%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </InsertItemTemplate>
                                            <EditItemTemplate>
                                                <table border="0" cellpadding="4" cellspacing="0" class="stylesheet" width="100%">
                                                    <tr>
                                                        <td class="ghc" colspan="6">
                                                            Bodily Injury Treatment Costs</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc" style="width: 18%;">
                                                               <asp:Label runat="server" ID="lblDate">Date</asp:Label> 
                                                        </td>
                                                        <td style="width: 5px;">
                                                            :</td>
                                                        <td class="ic" style="width: 30%;">
                                                            <asp:TextBox ID="txtMTCDate" SkinID="txtDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Transaction_Date", "{0:MM/dd/yyyy}")%>'></asp:TextBox>
                                                            <%--<asp:ImageButton ID="btnICal" runat="server" ImageUrl="~/Images/iconPicDate.gif" />--%>
                                                            <img id="img1" runat="Server" align="absmiddle" onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvWorkersRW_txtMTCDate','mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif" />
                                                            <%--<cc1:CalendarExtender ID="ICalendarExtender1" runat="server" PopupButtonID="btnICal"
																	TargetControlID="txtMTCDate">
																</cc1:CalendarExtender>--%>
                                                            <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AcceptNegative="Left"
                                                                AutoComplete="true" AutoCompleteValue="05/23/1964" CultureName="en-US" DisplayMoney="Left"
                                                                Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                OnInvalidCssClass="MaskedEditError" TargetControlID="txtMTCDate">
                                                            </cc1:MaskedEditExtender>
                                                            <asp:RegularExpressionValidator ID="revDtSBegin" runat="server" ControlToValidate="txtMTCDate"
                                                                Display="dynamic" ErrorMessage="Date Not Valid(MTC Date)" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td class="lc" style="width: 18%;">
                                                            &nbsp;</td>
                                                        <td style="width: 5px;">
                                                            &nbsp;</td>
                                                        <td class="ic" style="width: 30%;">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                             <asp:Label runat="server" ID="lablHospital">Hospital</asp:Label> </td>
                                                        <td width="10">
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtHospital" SkinID="txtAmt" runat="server" MaxLength="14" onBlur="return MTCTotal();"
                                                                onKeyPress="return(currencyFormat(this,',','.',event))" Text='<%#Eval("Hospital")%>'>
																
                                                            </asp:TextBox>
                                                        </td>
                                                        <td class="lc">
                                                              <asp:Label runat="server" ID="lablPhysician"> Physician</asp:Label> 
                                                        </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtPhysician" SkinID="txtAmt" runat="server" MaxLength="14" onBlur="return MTCTotal();"
                                                                onKeyPress="return(currencyFormat(this,',','.',event))" Text='<%#Eval("Physician")%>'>
                                                            </asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                            <asp:Label runat="server" ID="lablRadiology"> Radiology</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtRadiology" SkinID="txtAmt" runat="server" MaxLength="14" onBlur="return MTCTotal();"
                                                                onKeyPress="return(currencyFormat(this,',','.',event))" Text='<%#Eval("Radiology")%>'>
                                                            </asp:TextBox></td>
                                                        <td class="lc">
                                                              <asp:Label runat="server" ID="lablPharmacy"> Pharmacy</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtPharmacy" SkinID="txtAmt" runat="server" MaxLength="14" onBlur="return MTCTotal();"
                                                                onKeyPress="return(currencyFormat(this,',','.',event))" Text='<%#Eval("Pharmacy")%>'>
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                            <asp:Label runat="server" ID="lablIME"> IME</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtIME" SkinID="txtAmt" runat="server" MaxLength="14" onBlur="return MTCTotal();"
                                                                onKeyPress="return(currencyFormat(this,',','.',event))" Text='<%#Eval("IME")%>'>
                                                            </asp:TextBox></td>
                                                        <td class="lc">
                                                            <asp:Label runat="server" ID="lablAnesthesiologist"> Anesthesiologist</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtAnesthesiologist" SkinID="txtAmt" runat="server" MaxLength="14"
                                                                onBlur="return MTCTotal();" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                                Text='<%#Eval("Anesthesiologist")%>'>
                                                            </asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                               <asp:Label runat="server" ID="lablNursing">  Nursing Care</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtNursingCare" SkinID="txtAmt" runat="server" MaxLength="14" onBlur="return MTCTotal();"
                                                                onKeyPress="return(currencyFormat(this,',','.',event))" Text='<%#Eval("Nursing_Care")%>'>
                                                            </asp:TextBox>
                                                        </td>
                                                        <td class="lc">
                                                        
                                                            
                                                        <asp:Label runat="server" ID="lablTransportation">Transportation</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtTransportation" SkinID="txtAmt" runat="server" MaxLength="14"
                                                                onBlur="return MTCTotal();" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                                Text='<%#Eval("Transportation")%>'>
                                                            </asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                               <asp:Label runat="server" ID="lablMedicalReport">Medical Report</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtMedicalReport" SkinID="txtAmt" runat="server" MaxLength="14"
                                                                onBlur="return MTCTotal();" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                                Text='<%#Eval("Medical_Report")%>'>
                                                            </asp:TextBox></td>
                                                        <td class="lc">
                                                             <asp:Label runat="server" ID="Lab1MedicalTotal">Bodily Injury Total</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:Label ID="txtTotal" runat="server" SkinID="lblText" Text='<%#Eval("Medical_Total")%>'></asp:Label>
                                                            <%--<asp:TextBox ID="txtTotal" runat="server" MaxLength="14" onKeyPress="return(currencyFormat(this,',','.',event))"
																 Text='<%#Eval("Medical_Total")%>'>
															</asp:TextBox>--%>
															
                                                        </td>
                                                    </tr>
                                                    
                                                    <tr>
                                                        <td bgcolor="#f0f2e1" class="ghc" colspan="6">
                                                            
                                                    <asp:Label runat="server" ID="lablIndemnity">Property Damage</asp:Label> </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <table width="87%">
                                                                <tr>
                                                                    <td class="lc" style="width: 22%;" align="left">
                                                                      <asp:Label runat="server" ID="lablTTDTotalPerWeek">TTD Total Per Week</asp:Label> 
                                                                       
                                                                    </td>
                                                                    <td>
                                                                        :</td>
                                                                    <td class="ic" style="width: 32%;" align="left">
                                                                        $<asp:TextBox ID="txtTTDperweek" runat="server" SkinID="txtAmt" MaxLength="13" onBlur="return TTDCalculation();"
                                                                            onKeyPress="return(currencyFormat(this,',','.',event))" Text='<%#Eval("TTD_Payment")%>'>
                                                                        </asp:TextBox>
                                                                    </td>
                                                                    <td class="lc" style="width: 12%;" align="left">
                                                                        <asp:Label runat="server" ID="lablTTDWeeks">TTD Weeks</asp:Label> 
                                                                    </td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 12%;" align="left">
                                                                        <asp:TextBox ID="txtTTDWeeks" runat="server" Width="50px"  onBlur="return TTDCalculation();"
                                                                            onkeypress="return numberOnly(event);" Text='<%#Eval("TTD_Weeks")%>' MaxLength="3">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                    <td class="lc" style="width: 12%;" align="left">
                                                                        <asp:Label runat="server" ID="lablTTDTotal">TTD Total</asp:Label> 
                                                                    </td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 12%;" align="left">
                                                                        $<asp:Label ID="txtTTDTotal" runat="server" SkinID="lblText" Text='<%#Eval("TTD_Total")%>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <table width="87%">
                                                                <tr>
                                                                    <td class="lc" style="width: 22%;" align="left">
                                                                        <asp:Label runat="server" ID="lablTPDTotalPerWeek"> TPD Total Per Week</asp:Label> 
                                                                    </td>
                                                                    <td>
                                                                        :</td>
                                                                    <td class="ic" style="width: 32%;" align="left">
                                                                        $<asp:TextBox ID="txtTPDperweek" runat="server" SkinID="txtAmt" MaxLength="13" onBlur="return TPDCalculation();"
                                                                            onKeyPress="return(currencyFormat(this,',','.',event))" Text='<%#Eval("TPD_Payment")%>'>
                                                                        </asp:TextBox>
                                                                    </td>
                                                                    <td class="lc" style="width: 12%;" align="left">
                                                                       <asp:Label runat="server" ID="lablTPDWeeks"> TPD Weeks</asp:Label> 
                                                                    </td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 12%;" align="left">
                                                                        <asp:TextBox ID="txtTPDWeeks" runat="server"  onBlur="return TPDCalculation();"
                                                                            onkeypress="return numberOnly(event);" Text='<%#Eval("TPD_Weeks")%>' MaxLength="3"
                                                                            Width="50px">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                    <td class="lc" style="width: 12%;" align="left">
                                                                         <asp:Label runat="server" ID="lablTPDTotal"> TPD Total</asp:Label> 
                                                                    </td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 12%;" align="left">
                                                                        $<asp:Label ID="txtTPDTotal" runat="server" SkinID="lblText" Text='<%#Eval("TPD_Total")%>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="ghc" colspan="6">
                                                            <asp:Label runat="server" ID="lablPermaDisability">Permanent Disability</asp:Label> 
                                                            </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                              <asp:Label runat="server" ID="lablEstimatedAward"> Estimated Award</asp:Label> 
                                                              </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $
                                                            <asp:TextBox ID="txtEstAward" runat="server" MaxLength="14" onBlur="return PerDisaTotal();"
                                                                onKeyPress="return(currencyFormat(this,',','.',event))" SkinID="txtAmt" Text='<%#Eval("Estimated_Award")%>'>
                                                            </asp:TextBox></td>
                                                        <td class="lc">
                                                            <asp:Label runat="server" ID="lablDeathBenefit">Death Benefit</asp:Label> 
                                                                    </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtDeathBenefit" runat="server" MaxLength="14" onBlur="return PerDisaTotal();"
                                                                onKeyPress="return(currencyFormat(this,',','.',event))" SkinID="txtAmt" Text='<%#Eval("Death_Benefit")%>'>
                                                            </asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                            <asp:Label runat="server" ID="lablVocatRehabilitation"> Vocational Rehabilitation</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $
                                                            <asp:TextBox ID="txtVocRehab" runat="server" MaxLength="14" onBlur="return PerDisaTotal();"
                                                                onKeyPress="return(currencyFormat(this,',','.',event))" SkinID="txtAmt" Text='<%#Eval("Vocational_Rehab")%>'>
                                                            </asp:TextBox></td>
                                                        <td class="lc">
                                                            <asp:Label runat="server" ID="lablFuneralExpense">Funeral Expense</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtFuneralExp" runat="server" MaxLength="14" onBlur="return PerDisaTotal();"
                                                                onKeyPress="return(currencyFormat(this,',','.',event))" SkinID="txtAmt" Text='<%#Eval("Funeral_Expense")%>'>
                                                            </asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                            <asp:Label runat="server" ID="lablPermenantDisaTotal"> Permenant Disability Total</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:Label ID="txtPDT" runat="server" SkinID="lblText" Text='<%#Eval("Disability_Total")%>'></asp:Label></td>
                                                        <td class="lc">
                                                            <asp:Label runat="server" ID="lablIndemnityTotal">Property Damage Total</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:Label ID="txtPerDisabilityTotal" runat="server" SkinID="lblText" Text='<%#Eval("Indemnity_Total")%>'></asp:Label>
                                                            <%--<asp:TextBox ID="txtPerDisabilityTotal" runat="server" MaxLength="14" onKeyPress="return(currencyFormat(this,',','.',event))"
																SkinID="txtAmt" Text='<%#Eval("Disability_Total")%>'>
															</asp:TextBox>--%>
                                                        </td>
                                                        
                                                    </tr>
                                                    <tr>
                                                        <td class="ghc" colspan="6">
                                                              <asp:Label runat="server" ID="lablExpensesHead">Expenses</asp:Label> </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                             <asp:Label runat="server" ID="lablDefenseCost">Defense Cost</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtDefenseCost" runat="server" MaxLength="14" onBlur="return ExpenseTotal();"
                                                                onKeyPress="return(currencyFormat(this,',','.',event))" SkinID="txtAmt" Text='<%#Eval("Defense_Cost")%>'>
                                                            </asp:TextBox></td>
                                                        <td class="lc">
                                                            <asp:Label runat="server" ID="lablMedicalCaseManag"> Medical Case Management</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtMedicalCaseMgmt" runat="server" MaxLength="14" onBlur="return ExpenseTotal();"
                                                                onKeyPress="return(currencyFormat(this,',','.',event))" SkinID="txtAmt" Text='<%#Eval("Medical_Case_Management")%>'>
                                                            </asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                          <asp:Label runat="server" ID="lablSurveillance">Surveillance</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtSurveillance" runat="server" MaxLength="14" onBlur="return ExpenseTotal();"
                                                                onKeyPress="return(currencyFormat(this,',','.',event))" SkinID="txtAmt" Text='<%#Eval("Surveillance")%>'>
                                                            </asp:TextBox></td>
                                                        <td class="lc">
                                                             <asp:Label runat="server" ID="lablCourtCosts"> Court Costs</asp:Label> 
                                                        </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtCourtCase" runat="server" MaxLength="14" onBlur="return ExpenseTotal();"
                                                                onKeyPress="return(currencyFormat(this,',','.',event))" SkinID="txtAmt" Text='<%#Eval("Court_Costs")%>'>
                                                            </asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                             <asp:Label runat="server" ID="lablBillReview"> Bill Review</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtBillReview" runat="server" MaxLength="14" onBlur="return ExpenseTotal();"
                                                                onKeyPress="return(currencyFormat(this,',','.',event))" SkinID="txtAmt" Text='<%#Eval("Bill_Review")%>'>
                                                            </asp:TextBox></td>
                                                        <td class="lc">
                                                             <asp:Label runat="server" ID="lablDepositions">Depositions</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtDiposition" runat="server" MaxLength="14" onBlur="return ExpenseTotal();"
                                                                onKeyPress="return(currencyFormat(this,',','.',event))" SkinID="txtAmt" Text='<%#Eval("Depositions")%>'>
                                                            </asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                            <asp:Label runat="server" ID="lablOtherDescription1"> Other (1) - Description</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            <asp:TextBox ID="txtOtherDesc1" runat="server" Text='<%#Eval("Expense_Other_1_Description")%>'>
                                                            </asp:TextBox>
                                                        </td>
                                                        <td class="lc">
                                                        <asp:Label ID="lablOtherExpense1" runat="server">  Other (1) - Expense</asp:Label>
                                                          </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtOtherExp1" runat="server" MaxLength="14" onBlur="return ExpenseTotal();"
                                                                onKeyPress="return(currencyFormat(this,',','.',event))" SkinID="txtAmt" Text='<%#Eval("Expense_Other_1")%>'>
                                                            </asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                             <asp:Label runat="server" ID="lablOtherDescription2"> Other (2) - Description</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            <asp:TextBox ID="txtOtherDesc2" runat="server" Text='<%#Eval("Expense_Other_2_Description")%>'>
                                                            </asp:TextBox>
                                                        </td>
                                                        <td class="lc">
                                                           <asp:Label runat="server" ID="lablOtherExpense2"> Other (2) - Expense</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtOtherExp2" runat="server" MaxLength="14" onBlur="return ExpenseTotal();"
                                                                onKeyPress="return(currencyFormat(this,',','.',event))" SkinID="txtAmt" Text='<%#Eval("Expense_Other_2")%>'>
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                            <asp:Label runat="server" ID="lablOtherDescription3">  Other (3) - Description</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            <asp:TextBox ID="txtOtherDesc3" runat="server" Text='<%#Eval("Expense_Other_3_Description")%>'>
                                                            </asp:TextBox>
                                                        </td>
                                                        <td class="lc">
                                                              <asp:Label runat="server" ID="lablOtherExpense3">    Other (3) - Expense</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:TextBox ID="txtOtherExp3" runat="server" MaxLength="14" onBlur="return ExpenseTotal();"
                                                                onKeyPress="return(currencyFormat(this,',','.',event))" SkinID="txtAmt" Text='<%#Eval("Expense_Other_3")%>'>
                                                            </asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                            <asp:Label runat="server" ID="lablExpenseTotal">Expense Total</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:Label ID="txtExpenseTotal" SkinID="lblText" runat="server" Text='<%#Eval("Expenses_Total")%>'></asp:Label>
                                                            <%--<asp:TextBox ID="txtExpenseTotal" runat="server" MaxLength="14" onKeyPress="return(currencyFormat(this,',','.',event))"
																SkinID="txtAmt" Text='<%#Eval("Expenses_Total")%>' </asp:TextBox>--%>
                                                        </td>
                                                        <td class="lc">
                                                            &nbsp;</td>
                                                        <td>
                                                            &nbsp;</td>
                                                        <td class="ic">
                                                            &nbsp;</td>
                                                    </tr>
                                                </table>
                                                <table cellpadding="2" cellspacing="2" class="stylesheet" width="100%">
                                                    <tr>
                                                        <td class="ghc" colspan="6">
                                                            Attachment
                                                        </td>
                                                    </tr>
                                                    <tr style="display:none;">
                                                        <td class="lc" style="width: 134px;" valign="top">
                                                            Attachment Type
                                                        </td>
                                                        <td style="width: 5px;" valign="top" class="lc">
                                                            :
                                                        </td>
                                                        <td class="ic" colspan="4" valign="top">
                                                            <%--<asp:DropDownList runat="server" SkinID="dropGen" ID="ddlAttachType">
															</asp:DropDownList>
															<asp:RequiredFieldValidator ID="rfvAttachType" runat="server" ControlToValidate="ddlAttachType"
																Display="none" EnableClientScript="true" ErrorMessage="Please Select the Attachment Type."
																InitialValue="0" ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>--%>
                                                            <asp:DropDownList ID="ddlAttachType" runat="server" SkinID="dropGen">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfvAttachType" runat="server" ControlToValidate="ddlAttachType"
                                                                Display="none" EnableClientScript="true" ErrorMessage="Please Select the Attachment Type."
                                                                InitialValue="--Select Attachment Type--" ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc" style="width: 134px;" valign="top">
                                                            Attachment Description
                                                        </td>
                                                        <td style="width: 5px;" valign="top" class="lc">
                                                            :
                                                        </td>
                                                        <td colspan="4" class="ic" valign="top">
                                                            <asp:ImageButton ID="ibtnAttachDesc" ImageUrl="~/Images/minus.jpg" runat="server" OnClientClick="javascript:return MinMax();" />
                                                            <div id="pnlAttachDesc" style="display:block;">
                                                                <asp:TextBox ID="txtAttachDesc" runat="server" TextMode="MultiLine" Width="93%" Height="200px" MaxLength="4000"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc" style="width: 134px;" valign="top">
                                                            Select File
                                                        </td>
                                                        <td class="lc" style="width: 5px;" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" class="ic" valign="top">
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
                                                <%--<table>
													<tr align="center">
														<td colspan="6" valign="top">
															<asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" />
															<asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
														</td>
													</tr>
												</table>--%>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <table border="0" cellpadding="4" cellspacing="0" class="stylesheet" width="100%">
                                                    <tr>
                                                        <td class="ghc" colspan="6">
                                                            Bodily Injury Treatment Costs</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc" style="width: 18%;">
                                                            <asp:Label runat="server" ID="lblDate">Date</asp:Label> 
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
                                                              <asp:Label runat="server" ID="lablHospital">Hospital</asp:Label> </td>
                                                        <td width="10">
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:Label ID="lblHospital" runat="server" Text='<%#Eval("Hospital")%>'></asp:Label>
                                                        </td>
                                                        <td class="lc">
                                                              <asp:Label runat="server" ID="lablPhysician"> Physician</asp:Label> 
                                                        </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:Label ID="lblPhysician" runat="server" Text='<%#Eval("Physician")%>'></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                             <asp:Label runat="server" ID="lablRadiology"> Radiology</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:Label ID="lblRadiology" runat="server" Text='<%#Eval("Radiology")%>'></asp:Label></td>
                                                        <td class="lc">
                                                             <asp:Label runat="server" ID="lablPharmacy"> Pharmacy</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:Label ID="lblPharmacy" runat="server" Text='<%#Eval("Pharmacy")%>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                             <asp:Label runat="server" ID="lablIME"> IME</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:Label ID="lblIME" runat="server" Text='<%#Eval("IME")%>'></asp:Label></td>
                                                        <td class="lc">
                                                            <asp:Label runat="server" ID="lablAnesthesiologist"> Anesthesiologist</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:Label ID="lblAnesthesiologist" runat="server" Text='<%#Eval("Anesthesiologist")%>'></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                               <asp:Label runat="server" ID="lablNursing">  Nursing Care</asp:Label></td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $
                                                            <asp:Label ID="lblNursingCare" runat="server" Text='<%#Eval("Nursing_Care")%>'></asp:Label>
                                                        </td>
                                                        <td class="lc">
                                                             <asp:Label runat="server" ID="lablTransportation">Transportation</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:Label ID="lblTransportation" runat="server" Text='<%#Eval("Transportation")%>'></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                              <asp:Label runat="server" ID="lablMedicalReport">Medical Report</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:Label ID="lblMedicalReport" runat="server" Text='<%#Eval("Medical_Report")%>'></asp:Label></td>
                                                        <td class="lc">
                                                              <asp:Label runat="server" ID="Lab1MedicalTotal">Bodily Injury Total</asp:Label></td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:Label ID="lblTotal" runat="server" SkinID="lblText" Text='<%#Eval("Medical_Total")%>'></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td bgcolor="#f0f2e1" class="ghc" colspan="6">
                                                            <asp:Label runat="server" ID="lablIndemnity">Property Damage</asp:Label> </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <table width="87%">
                                                                <tr>
                                                                    <td class="lc" style="width: 22%;" align="left">
                                                                       <asp:Label runat="server" ID="lablTTDTotalPerWeek">TTD Total Per Week</asp:Label> 

                                                                    </td>
                                                                    <td>
                                                                        :</td>
                                                                    <td class="ic" style="width: 32%;" align="left">
                                                                        $<asp:Label ID="lblTTDperweek" runat="server" Text='<%#Eval("TTD_Payment")%>'></asp:Label>
                                                                    </td>
                                                                    <td class="lc" style="width: 12%;" align="left">
                                                                         <asp:Label runat="server" ID="lablTTDWeeks">TTD Weeks</asp:Label> 
                                                                    </td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 12%;" align="left">
                                                                        <asp:Label ID="lblTTDWeeks" runat="server" Text='<%#Eval("TTD_Weeks")%>'></asp:Label>
                                                                    </td>
                                                                    <td class="lc" style="width: 12%;" align="left">
                                                                        <asp:Label runat="server" ID="lablTTDTotal">TTD Total</asp:Label> 

                                                                    </td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 12%;" align="left">
                                                                        $<asp:Label ID="lblTTDTotal" runat="server" SkinID="lblText" Text='<%#Eval("TTD_Total")%>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <table width="87%">
                                                                <tr>
                                                                    <td class="lc" style="width: 22%;" align="left">
                                                                       <asp:Label runat="server" ID="lablTPDTotalPerWeek"> TPD Total Per Week</asp:Label> 
                                                                    </td>
                                                                    <td>
                                                                        :</td>
                                                                    <td class="ic" style="width: 32%;" align="left">
                                                                        $<asp:Label ID="lblTTDTotalperweek" runat="server" Text='<%#Eval("TPD_Payment")%>'></asp:Label>
                                                                    </td>
                                                                    <td class="lc" style="width: 12%;" align="left">
                                                                          <asp:Label runat="server" ID="lablTPDWeeks"> TPD Weeks</asp:Label> 

                                                                    </td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 12%;" align="left">
                                                                        <asp:Label ID="lblTPDWeeks" runat="server" Text='<%#Eval("TPD_Weeks")%>'></asp:Label>
                                                                    </td>
                                                                    <td class="lc" style="width: 12%;" align="left">
                                                                        <asp:Label runat="server" ID="lablTPDTotal"> TPD Total</asp:Label> 
                                                                    </td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 12%;" align="left">
                                                                        $<asp:Label ID="lblTPDTotal" runat="server" SkinID="lblText" Text='<%#Eval("TPD_Total")%>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="ghc" colspan="6">
                                                            <asp:Label runat="server" ID="lablPermaDisability">Permanent Disability</asp:Label> </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                            <asp:Label runat="server" ID="lablEstimatedAward"> Estimated Award</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $
                                                            <asp:Label ID="lblEstAward" runat="server" Text='<%#Eval("Estimated_Award")%>'></asp:Label></td>
                                                        <td class="lc">
                                                           <asp:Label runat="server" ID="lablDeathBenefit">Death Benefit</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:Label ID="lblDeathBenefit" runat="server" Text='<%#Eval("Death_Benefit")%>'></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                              <asp:Label runat="server" ID="lablVocatRehabilitation"> Vocational Rehabilitation</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $
                                                            <asp:Label ID="lblVocRehab" runat="server" Text='<%#Eval("Vocational_Rehab")%>'></asp:Label></td>
                                                        <td class="lc">
                                                               <asp:Label runat="server" ID="lablFuneralExpense">Funeral Expense</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $
                                                            <asp:Label ID="lblFuneralExp" runat="server" Text='<%#Eval("Funeral_Expense")%>'></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                    <td class="lc">
                                                             <asp:Label runat="server" ID="lablPermenantDisaTotal"> Permenant Disability Total</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:Label ID="lblPDT" runat="server" SkinID="lblText" Text='<%#Eval("Disability_Total")%>'></asp:Label></td>
                                                        <td class="lc">
                                                             <asp:Label runat="server" ID="lablIndemnityTotal">Property Damage Total</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $
                                                            <asp:Label ID="lblPerDisabilityTotal" runat="server" SkinID="lblText" Text='<%#Eval("Indemnity_Total")%>'></asp:Label></td>
                                                        
                                                    </tr>
                                                    <tr>
                                                        <td class="ghc" colspan="6">
                                                              <asp:Label runat="server" ID="lablExpensesHead">Expenses</asp:Label> </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                            <asp:Label runat="server" ID="lablDefenseCost">Defense Cost</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $
                                                            <asp:Label ID="lblDefenseCost" runat="server" Text='<%#Eval("Defense_Cost")%>'></asp:Label></td>
                                                        <td class="lc">
                                                             <asp:Label runat="server" ID="lablMedicalCaseManag"> Medical Case Management</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $
                                                            <asp:Label ID="lblMedicalCaseMgmt" runat="server" Text='<%#Eval("Medical_Case_Management")%>'></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                            <asp:Label runat="server" ID="lablSurveillance">Surveillance</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:Label ID="lblSurveillance" runat="server" Text='<%#Eval("Surveillance")%>'></asp:Label></td>
                                                        <td class="lc">
                                                            <asp:Label runat="server" ID="lablCourtCosts"> Court Costs</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:Label ID="lblCourtCase" runat="server" Text='<%#Eval("Court_Costs")%>'></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                             <asp:Label runat="server" ID="lablBillReview"> Bill Review</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:Label ID="lblBillReview" runat="server" Text='<%#Eval("Bill_Review")%>'></asp:Label></td>
                                                        <td class="lc">
                                                              <asp:Label runat="server" ID="lablDepositions">Depositions</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:Label ID="lblDiposition" runat="server" Text='<%#Eval("Depositions")%>'></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                            <asp:Label runat="server" ID="lablOtherDescription1"> Other (1) - Description</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            <asp:Label ID="lblOtherDesc1" runat="server" Text='<%#Eval("Expense_Other_1_Description")%>'></asp:Label>
                                                        </td>
                                                        <td class="lc">
                                                            <asp:Label ID="lablOtherExpense1" runat="server">  Other (1) - Expense</asp:Label></td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:Label ID="lblOtherExp1" runat="server" Text='<%#Eval("Expense_Other_1")%>'></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                               <asp:Label runat="server" ID="lablOtherDescription2"> Other (2) - Description</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            <asp:Label ID="lblOtherDesc2" runat="server" Text='<%#Eval("Expense_Other_2_Description")%>'></asp:Label>
                                                        </td>
                                                        <td class="lc">
                                                           <asp:Label runat="server" ID="lablOtherExpense2"> Other (2) - Expense</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $<asp:Label ID="lblOtherExp2" runat="server" Text='<%#Eval("Expense_Other_2")%>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                           <asp:Label runat="server" ID="lablOtherDescription3">  Other (3) - Description</asp:Label></td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            <asp:Label ID="lblOtherDesc3" runat="server" Text='<%#Eval("Expense_Other_3_Description")%>'></asp:Label>
                                                        </td>
                                                        <td class="lc">
                                                            
                                                         <asp:Label runat="server" ID="lablOtherExpense3">    Other (3) - Expense</asp:Label> </td>
                                                        <td>
                                                            :</td>
                                                        <td class="ic">
                                                            $
                                                            <asp:Label ID="lblOtherExp3" runat="server" Text='<%#Eval("Expense_Other_3")%>'></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="lc">
                                                            <asp:Label runat="server" ID="lablExpenseTotal">Expense Total</asp:Label> </td>
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
                                                                            <input name="chkItem" type="checkbox" value='<%# Eval("PK_Attachment_ID")%>' onclick="javascript:UnCheckHeader('gvAttachmentDetails')"  />
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="10px" />
                                                                        <HeaderTemplate>
                                                                            <input type="checkbox"  id="chkHeader" runat="server" name="chkHeader" onclick="javascript:SelectAllCheckboxes(this)" />
                                                                        </HeaderTemplate>
                                                                        <HeaderStyle Width="10px" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Attachment_Type" HeaderText="Attachment Type" Visible="false"></asp:BoundField>
                                                                    <asp:BoundField DataField="Attachment_Description" HeaderText="Attachment Description">
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Attachment_Name1" HeaderText="File Name"></asp:BoundField>
                                                                    <asp:TemplateField HeaderText="View">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="imgbtnDwnld" CommandName="Download" CommandArgument='<%# Eval("Attachment_Name")%>'
                                                                                runat="server" ImageAlign="Left" ImageUrl="~/Images/download.gif" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                                    </asp:TemplateField>
                                                                    <%--<asp:TemplateField HeaderText="Mail">
																		<ItemTemplate>
																			<asp:ImageButton ID="imgbtnMail" CommandName="Mail" CommandArgument='<%# Eval("Attachment_Name")%>'
																				runat="server" ImageUrl="~/Images/emailicon.gif" ImageAlign="Left" />
																		</ItemTemplate>
																		<ItemStyle HorizontalAlign="Center" Width="60px" />
																	</asp:TemplateField>--%>
                                                                </Columns>
                                                                <EmptyDataRowStyle ForeColor="red" HorizontalAlign="Center" />
                                                                <EmptyDataTemplate>
                                                                    There is no attachment.
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
                            <asp:GridView ID="gvViewAll" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvViewAll_RowDataBound"
                                Width="100%">
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
                                                            <asp:Label runat="server" ID="lblDate">Date</asp:Label> 
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
                                                          <asp:Label runat="server" ID="lablHospital">Hospital</asp:Label> </td>
                                                    <td width="10">
                                                        :</td>
                                                    <td class="ic">
                                                        $<asp:Label ID="lblHospital" runat="server" Text='<%#Eval("Hospital")%>'></asp:Label>
                                                    </td>
                                                    <td class="lc">
                                                          <asp:Label runat="server" ID="lablPhysician"> Physician</asp:Label>
                                                    </td>
                                                    <td>
                                                        :</td>
                                                    <td class="ic">
                                                        $<asp:Label ID="lblPhysician" runat="server" Text='<%#Eval("Physician")%>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td class="lc">
                                                         <asp:Label runat="server" ID="lablRadiology"> Radiology</asp:Label> </td>
                                                    <td>
                                                        :</td>
                                                    <td class="ic">
                                                        $<asp:Label ID="lblRadiology" runat="server" Text='<%#Eval("Radiology")%>'></asp:Label></td>
                                                    <td class="lc">
                                                         <asp:Label runat="server" ID="lablPharmacy"> Pharmacy</asp:Label> </td>
                                                    <td>
                                                        :</td>
                                                    <td class="ic">
                                                        $<asp:Label ID="lblPharmacy" runat="server" Text='<%#Eval("Pharmacy")%>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="lc">
                                                        <asp:Label runat="server" ID="lablIME"> IME</asp:Label> </td>
                                                    <td>
                                                        :</td>
                                                    <td class="ic">
                                                        $<asp:Label ID="lblIME" runat="server" Text='<%#Eval("IME")%>'></asp:Label></td>
                                                    <td class="lc">
                                                        <asp:Label runat="server" ID="lablAnesthesiologist"> Anesthesiologist</asp:Label></td>
                                                    <td>
                                                        :</td>
                                                    <td class="ic">
                                                        $<asp:Label ID="lblAnesthesiologist" runat="server" Text='<%#Eval("Anesthesiologist")%>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td class="lc">
                                                         <asp:Label runat="server" ID="lablNursing">  Nursing Care</asp:Label> </td>
                                                    <td>
                                                        :</td>
                                                    <td class="ic">
                                                        $
                                                        <asp:Label ID="lblNursingCare" runat="server" Text='<%#Eval("Nursing_Care")%>'></asp:Label>
                                                    </td>
                                                    <td class="lc">
                                                        <asp:Label runat="server" ID="lablTransportation">Transportation</asp:Label> </td>
                                                    <td>
                                                        :</td>
                                                    <td class="ic">
                                                        $<asp:Label ID="lblTransportation" runat="server" Text='<%#Eval("Transportation")%>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td class="lc">
                                                       <asp:Label runat="server" ID="lablMedicalReport">Medical Report</asp:Label> </td>
                                                    <td>
                                                        :</td>
                                                    <td class="ic">
                                                        $<asp:Label ID="lblMedicalReport" runat="server" Text='<%#Eval("Medical_Report")%>'></asp:Label></td>
                                                    <td class="lc">
                                                         <asp:Label runat="server" ID="Lab1MedicalTotal">Medical Total</asp:Label> </td>
                                                    <td>
                                                        :</td>
                                                    <td class="ic">
                                                        $<asp:Label ID="lblTotal" runat="server" SkinID="lblText" Text='<%#Eval("Medical_Total")%>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td bgcolor="#f0f2e1" class="ghc" colspan="6">
                                                        <asp:Label runat="server" ID="lablIndemnity">Property Damage</asp:Label> </td>
                                                </tr>
                                                <tr>
                                                    <td class="lc">
                                                         <asp:Label runat="server" ID="lablTTDTotalPerWeek">TTD Total Per Week</asp:Label> </td>
                                                    <td>
                                                        :</td>
                                                    <td class="ic">
                                                        $<asp:Label ID="lblTTDperweek" runat="server" Text='<%#Eval("TTD_Payment")%>'></asp:Label></td>
                                                    <td class="lc">
                                                          <asp:Label runat="server" ID="lablTTDWeeks">TTD Weeks</asp:Label> </td>
                                                    <td>
                                                        :</td>
                                                    <td class="ic">
                                                        <asp:Label ID="lblTTDWeeks" runat="server" Text='<%#Eval("TTD_Weeks")%>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td class="lc">
                                                        <asp:Label runat="server" ID="lablTTDTotal">TTD Total</asp:Label> </td>
                                                    <td>
                                                        :</td>
                                                    <td class="ic">
                                                        $<asp:Label ID="lblTTDTotal" runat="server" SkinID="lblText" Text='<%#Eval("TTD_Total")%>'></asp:Label></td>
                                                    <td class="lc">
                                                         <asp:Label runat="server" ID="lablTPDTotalPerWeek"> TPD Total Per Week</asp:Label> </td>
                                                    <td>
                                                        :</td>
                                                    <td class="ic">
                                                        $<asp:Label ID="lblTTDTotalperweek" runat="server" Text='<%#Eval("TPD_Payment")%>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td class="lc">
                                                         <asp:Label runat="server" ID="lablTPDWeeks"> TPD Weeks</asp:Label> </td>
                                                    <td>
                                                        :</td>
                                                    <td class="ic">
                                                        <asp:Label ID="lblTPDWeeks" runat="server" Text='<%#Eval("TPD_Weeks")%>'></asp:Label>
                                                    </td>
                                                    <td class="lc">
                                                         <asp:Label runat="server" ID="lablTPDTotal"> TPD Total</asp:Label> 
                                                    </td>
                                                    <td>
                                                        :</td>
                                                    <td class="ic">
                                                        $<asp:Label ID="lblTPDTotal" runat="server" SkinID="lblText" Text='<%#Eval("TPD_Total")%>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td class="ghc" colspan="6">
                                                        <asp:Label runat="server" ID="lablPermaDisability">Permanent Disability</asp:Label> </td>
                                                </tr>
                                                <tr>
                                                    <td class="lc">
                                                       <asp:Label runat="server" ID="lablEstimatedAward"> Estimated Award</asp:Label> </td>
                                                    <td>
                                                        :</td>
                                                    <td class="ic">
                                                        $
                                                        <asp:Label ID="lblEstAward" runat="server" Text='<%#Eval("Estimated_Award")%>'></asp:Label></td>
                                                    <td class="lc">
                                                         <asp:Label runat="server" ID="lablDeathBenefit">Death Benefit</asp:Label> 
                                                    </td>
                                                    <td>
                                                        :</td>
                                                    <td class="ic">
                                                        $<asp:Label ID="lblDeathBenefit" runat="server" Text='<%#Eval("Death_Benefit")%>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td class="lc">
                                                       <asp:Label runat="server" ID="lablVocatRehabilitation"> Vocational Rehabilitation</asp:Label> 
                                                    </td>
                                                    <td>
                                                        :</td>
                                                    <td class="ic">
                                                        $
                                                        <asp:Label ID="lblVocRehab" runat="server" Text='<%#Eval("Vocational_Rehab")%>'></asp:Label></td>
                                                    <td class="lc">
                                                           <asp:Label runat="server" ID="lablFuneralExpense">Funeral Expense</asp:Label></td>
                                                    <td>
                                                        :</td>
                                                    <td class="ic">
                                                        $
                                                        <asp:Label ID="lblFuneralExp" runat="server" Text='<%#Eval("Funeral_Expense")%>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td class="lc">
                                                         <asp:Label runat="server" ID="lablPermenantDisaTotal"> Permenant Disability Total</asp:Label> 
</td>
                                                    <td>
                                                        :</td>
                                                    <td class="ic">
                                                        $
                                                        <asp:Label ID="lblPerDisabilityTotal" runat="server" SkinID="lblText" Text='<%#Eval("Disability_Total")%>'></asp:Label></td>
                                                    <td class="lc">
                                                    <asp:Label runat="server" ID="lablIndemnityTotal">Property Damage Total</asp:Label> 
                                                        </td>
                                                    <td>
                                                        :</td>
                                                    <td class="ic">
                                                          <asp:Label ID="lblIndemnityTotal" runat="server" SkinID="lblText" Text='<%#Eval("Indemnity_Total")%>'></asp:Label></td></td>
                                                </tr>
                                                <tr>
                                                    <td class="ghc" colspan="6">
                                                          <asp:Label runat="server" ID="lablExpensesHead">Expenses</asp:Label> </td>
                                                </tr>
                                                <tr>
                                                    <td class="lc">
                                                        <asp:Label runat="server" ID="lablDefenseCost">Defense Cost</asp:Label> t</td>
                                                    <td>
                                                        :</td>
                                                    <td class="ic">
                                                        $
                                                        <asp:Label ID="lblDefenseCost" runat="server" Text='<%#Eval("Defense_Cost")%>'></asp:Label></td>
                                                    <td class="lc">
                                                     <asp:Label runat="server" ID="lablMedicalCaseManag"> Medical Case Management</asp:Label> </td>
                                                    <td>
                                                        :</td>
                                                    <td class="ic">
                                                        $
                                                        <asp:Label ID="lblMedicalCaseMgmt" runat="server" Text='<%#Eval("Medical_Case_Management")%>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td class="lc">
                                                         <asp:Label runat="server" ID="lablSurveillance">Surveillance</asp:Label> </td>
                                                    <td>
                                                        :</td>
                                                    <td class="ic">
                                                        $<asp:Label ID="lblSurveillance" runat="server" Text='<%#Eval("Surveillance")%>'></asp:Label></td>
                                                    <td class="lc">
                                                         <asp:Label runat="server" ID="lablCourtCosts"> Court Costs</asp:Label> 
                                                        </td>
                                                    <td>
                                                        :</td>
                                                    <td class="ic">
                                                        $<asp:Label ID="lblCourtCase" runat="server" Text='<%#Eval("Court_Costs")%>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td class="lc">
                                                         <asp:Label runat="server" ID="lablBillReview"> Bill Review</asp:Label> </td>
                                                    <td>
                                                        :</td>
                                                    <td class="ic">
                                                        $<asp:Label ID="lblBillReview" runat="server" Text='<%#Eval("Bill_Review")%>'></asp:Label></td>
                                                    <td class="lc">
                                                        <asp:Label runat="server" ID="lablDepositions">Depositions</asp:Label> </td>
                                                    <td>
                                                        :</td>
                                                    <td class="ic">
                                                        $<asp:Label ID="lblDiposition" runat="server" Text='<%#Eval("Depositions")%>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td class="lc">
                                                          <asp:Label runat="server" ID="lablOtherDescription1"> Other (1) - Description</asp:Label> </td>
                                                    <td>
                                                        :</td>
                                                    <td class="ic">
                                                        <asp:Label ID="lblOtherDesc1" runat="server" Text='<%#Eval("Expense_Other_1_Description")%>'></asp:Label>
                                                    </td>
                                                    <td class="lc">
                                                       <asp:Label ID="lablOtherExpense1" runat="server">  Other (1) - Expense</asp:Label></td>
                                                    <td>
                                                        :</td>
                                                    <td class="ic">
                                                        $<asp:Label ID="lblOtherExp1" runat="server" Text='<%#Eval("Expense_Other_1")%>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td class="lc">
                                                        <asp:Label runat="server" ID="lablOtherDescription2"> Other (2) - Description</asp:Label> </td>
                                                    <td>
                                                        :</td>
                                                    <td class="ic">
                                                        <asp:Label ID="lblOtherDesc2" runat="server" Text='<%#Eval("Expense_Other_2_Description")%>'></asp:Label>
                                                    </td>
                                                    <td class="lc">
                                                       <asp:Label runat="server" ID="lablOtherExpense2"> Other (2) - Expense</asp:Label> 
</td>
                                                    <td>
                                                        :</td>
                                                    <td class="ic">
                                                        $<asp:Label ID="lblOtherExp2" runat="server" Text='<%#Eval("Expense_Other_2")%>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="lc">
                                                       <asp:Label runat="server" ID="lablOtherDescription3">  Other (3) - Description</asp:Label> </td>
                                                    <td>
                                                        :</td>
                                                    <td class="ic">
                                                        <asp:Label ID="lblOtherDesc3" runat="server" Text='<%#Eval("Expense_Other_3_Description")%>'></asp:Label>
                                                    </td>
                                                    <td class="lc">
                                                         <asp:Label runat="server" ID="lablOtherExpense3">    Other (3) - Expense</asp:Label> </td>
                                                    <td>
                                                        :</td>
                                                    <td class="ic">
                                                        $
                                                        <asp:Label ID="lblOtherExp3" runat="server" Text='<%#Eval("Expense_Other_3")%>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td class="lc">
                                                         <asp:Label runat="server" ID="lablExpenseTotal">Expense Total</asp:Label> </td>
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
            <div id="dvPaymentDetails" runat="server" style="display: none">
                <table border="0" cellpadding="4" cellspacing="1" width="100%">
                    <tbody>
                        <tr>
                            <td align="left" class="ghc" colspan="4">
                                Payment Details</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvPaymentDetails" runat="server" AllowPaging="false" AllowSorting="true"
                                    AutoGenerateColumns="false" DataKeyNames="pk_check_no" OnSorting="gvPaymentDetails_Sorting"
                                    Width="100%">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Issue Date" SortExpression="issue_date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblissue_date" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "issue_date", "{0:MM/dd/yyyy}")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Stop/Void Date" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign ="Right"  SortExpression="issue_date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStopDeleteDate"   runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Stop_Delete_Date", "{0:MM/dd/yyyy}")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="cdCheckNumber" HeaderStyle-HorizontalAlign ="Right" ItemStyle-HorizontalAlign="Right" HeaderText="Check Number" SortExpression="Check_Number" />
                                        <asp:BoundField DataField="Payment_Id" HeaderStyle-HorizontalAlign ="Right" ItemStyle-HorizontalAlign="Right" HeaderText="Payment ID" SortExpression="Payment_Id" />
                                        <asp:BoundField DataField="check_Amount" HeaderStyle-HorizontalAlign ="Right" ItemStyle-HorizontalAlign="Right" HeaderText="Check Amount" SortExpression="check_Amount" />
                                        <asp:BoundField DataField="Pay_Off" HeaderStyle-HorizontalAlign ="Right" ItemStyle-HorizontalAlign="Right" HeaderText="Pay Off" SortExpression="Pay_Off" />
                                    </Columns>
                                    <EmptyDataRowStyle ForeColor="red" HorizontalAlign="Center" />
                                    <EmptyDataTemplate>
                                        There is no Payment Detail for this claim.
                                    </EmptyDataTemplate>
                                    <PagerSettings Visible="False" />
                                    <PagerSettings Visible="False" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <%--End of Payment--%>
            <div style="display: none" id="dvOutstanding" runat="server">
                <table cellspacing="1" cellpadding="4" width="100%" border="0">
                    <tbody>
                        <tr>
                            <td class="ghc" align="left" colspan="4">
                                Outstanding</td>
                        </tr>
                        <tr>
                            <td class="lc" align="right">
                                <strong>Property Damage $</strong></td>
                            <td class="lc" align="right">
                                <strong>Bodily Injury $</strong></td>
                            <td class="lc" align="right">
                                <strong>Expenses $</strong></td>
                            <td class="lc" align="right">
                                <strong>Total $</strong>
                            </td>
                        </tr>
                        <tr>
                            <td class="lc" align="right">
                                <asp:Label ID="lblIOutStand" runat="server"></asp:Label>
                            </td>
                            <td class="lc" align="right">
                                <asp:Label ID="lblMOutStand" runat="server"></asp:Label>
                            </td>
                            <td class="lc" align="right">
                                <asp:Label ID="lblEOutStand" runat="server"></asp:Label>
                            </td>
                            <td class="lc" align="right">
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
                                                <input name="chkItem" onclick="javascript:UnCheckHeader('gvAttachmentDetails')" type="checkbox" value='<%# Eval("PK_Attachment_ID")%>' />
                                            </ItemTemplate>
                                            <ItemStyle Width="10px" />
                                            <HeaderTemplate>
                                                <input name="chkHeader" runat="server" id="chkHeader" onclick="javascript:SelectAllCheckboxes(this)"  type="checkbox" />
                                            </HeaderTemplate>
                                            <HeaderStyle Width="10px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Attachment_Type" HeaderText="Attachment Type" Visible="false" />
                                        <asp:BoundField DataField="Attachment_Description" HeaderText="Attachment Description" />
                                        <asp:BoundField DataField="Attachment_Name1" HeaderText="File Name" />
                                        <asp:TemplateField HeaderText="View">
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
            <%--end attachment--%>
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
    <%--</contenttemplate>
	</asp:UpdatePanel>--%>
</asp:Content>
