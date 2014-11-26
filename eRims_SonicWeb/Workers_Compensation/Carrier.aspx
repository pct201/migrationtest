<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" Theme="Default"
      CodeFile="Carrier.aspx.cs" Inherits="WorkerCompensation_Carrier"
    Title="Risk Management Insurance System" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="../JavaScript/JFunctions.js"></script>
    
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"></script>

    <link href="../App_Themes/Default/stylecal.css" type="text/css" rel="Stylesheet" />

    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
        <asp:CustomValidator ID="cvErrorMsg" runat="server" ErrorMessage="" EnableClientScript="false"
            ValidationGroup="vsErrorGroup" Display="None"></asp:CustomValidator>
    </div>
    <asp:ScriptManager runat="server" id="scManager">
    </asp:ScriptManager>
        
    <script type="text/javascript">   
        function OpenWMail(grdName,attTbl)
{

    var isChecked = false;
	for(i=0;i<document.forms[0].elements.length;i++)
        {
            if((document.forms[0].elements[i].type=='checkbox') && (document.forms[0].elements[i].name !='chkHeader'))
            {
                if(document.forms[0].elements[i].checked  == true)
                       isChecked= true;
            }
        }   
	if(!isChecked)
	{
	    alert('Please select any attachment to mail.');
		return false;
	}
	
    var i,flag=0;
    var m_strAttIds="";  
    for(i=0;i<document.forms[0].elements.length;i++)
    {
        if((document.forms[0].elements[i].type=='checkbox'))
        {
             if(document.forms[0].elements[i].name !="ctl00$ContentPlaceHolder1$"+grdName+"$ctl01$chkHeader")
                {
                
                if(document.forms[0].elements[i].checked  == true)
                    {  
                        if(m_strAttIds=="")
                        {
                            m_strAttIds=document.forms[0].elements[i].value;
                        }
                        else
                        {
                           m_strAttIds=m_strAttIds+","+document.forms[0].elements[i].value; 
                        }
                    }
                }
        }
        
    }
    //alert(m_strClaimNo); 
    oWnd=window.open("../ErimsMail.aspx?AttMod="+attTbl+"&AttIds=" + m_strAttIds ,"Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=600,height=300");
    oWnd.moveTo(260,180);
    return false;
  }  
    function MinMax()
    {
        if(document.getElementById("ctl00_ContentPlaceHolder1_txtDescription").style.height == "")
        {
            document.getElementById("ctl00_ContentPlaceHolder1_ibtnDisplay").src = "../Images/minus.jpg";
            document.getElementById("ctl00_ContentPlaceHolder1_txtDescription").style.height = "200px";
            document.getElementById("pnlTemp").style.display = "block";
        }
        else if(document.getElementById("ctl00_ContentPlaceHolder1_txtDescription").style.height == "200px")
        {
             document.getElementById("ctl00_ContentPlaceHolder1_ibtnDisplay").src = "../Images/plus.jpg";
            document.getElementById("ctl00_ContentPlaceHolder1_txtDescription").style.height="";
            document.getElementById("pnlTemp").style.display = "none";
        }
        return false;
    }
    
     function ValAttach()
        {      
            document.getElementById("ctl00_ContentPlaceHolder1_rfvAttachType").enabled =true;
            document.getElementById("ctl00_ContentPlaceHolder1_rfvUpload").enabled =true;
            return true;
        }
        function ValSave()
        {            
            document.getElementById("ctl00_ContentPlaceHolder1_rfvAttachType").enabled =false;
            document.getElementById("ctl00_ContentPlaceHolder1_rfvUpload").enabled =false;
            return true;
        }
     
    function validation(type)
    {
        var strError = "";
        if(document.getElementById("ctl00_ContentPlaceHolder1_txtDefenseMedicalEva").value == "")
        {
            strError +="Please Enter the Defense Medical Evaluation paid to Date\n";
        }
        if(document.getElementById("ctl00_ContentPlaceHolder1_txtEmpLegalExp").value == "")
        {
            strError +="Please Enter the Employer Legal Expense to Date\n";
        }
        if(document.getElementById("ctl00_ContentPlaceHolder1_txtExpertWitnessPaid").value == "")
        {
            strError +="Please Enter the Expert Witness Paid To Date\n";
        }
        if(document.getElementById("ctl00_ContentPlaceHolder1_dwMajorClassCode").value == "--Select Major Class Code--")
        {
            strError +="Please Select the Major Class Code\n";
        }
        if(document.getElementById("ctl00_ContentPlaceHolder1_dwLossCondAct").value == "--Select Loss Condition Act--")
        {
            strError +="Please Select the Loss Condition Act\n";
        }
        if(document.getElementById("ctl00_ContentPlaceHolder1_dwLossCondRecovery").value == "--Select Loss Condition Type Recovery--")
        {
            strError +="Please Select the Loss Condition Type Recovery\n";
        }
        if(document.getElementById("ctl00_ContentPlaceHolder1_dwLossCoverageCode").value == "--Select Loss Coverage Code--")
        {
            strError +="Please Select the Loss Coverage Code\n";
        }
        if(document.getElementById("ctl00_ContentPlaceHolder1_txtLumpSumRemarriage").value == "")
        {
            strError +="Please Enter the Lump Sum Remarriage Payment\n";
        } 
        if(document.getElementById("ctl00_ContentPlaceHolder1_txtPenaltyPaid").value == "")
        {
            strError +="Please Enter the Penalties Paid To Date\n";
        }
        if(document.getElementById("ctl00_ContentPlaceHolder1_txtPensionIndem").value == "")
        {
            strError +="Please Enter the  Pension Indemnity Benefit Paid To Valuation Date\n";
        }
        if(document.getElementById("ctl00_ContentPlaceHolder1_dwGarageState").value == "--Select State--")
        {            
            strError +="Please Select the Garage State\n";
        }
        if(document.getElementById("ctl00_ContentPlaceHolder1_txtLumpSumSettleAmt").value == "")
        {
            strError +="Please Enter the  Lump Sum Settlement Amount\n";
        }
        if(document.getElementById("ctl00_ContentPlaceHolder1_rbtnContovertedcase_0").checked == false && document.getElementById("ctl00_ContentPlaceHolder1_rbtnContovertedcase_1").checked == false)
        {
            strError +="Please Select the Controverter Case\n";
        }
        if(document.getElementById("ctl00_ContentPlaceHolder1_dwLossCondLoss").value == "--Select Loss Condition Loss--")
        {
            strError +="Please Select the Loss Conditions Loss\n";
        }
        if(document.getElementById("ctl00_ContentPlaceHolder1_dwLossCondSettlement").value == "--Select Loss Condition Settlement--")
        {
           strError +="Please Select the Loss Condition Settlement\n"; 
        }
        if(document.getElementById("ctl00_ContentPlaceHolder1_rbtnDeductibleIndicator_0").checked == false && document.getElementById("ctl00_ContentPlaceHolder1_rbtnDeductibleIndicator_1").checked == false)
        {
            strError +="Please Select the Deductible Indicator\n";
        }       
        
         if(document.getElementById("ctl00_ContentPlaceHolder1_dwSettlementMethod").value == "--Select Method Of Settlement--")
        {
            strError +="Please Select the Settlement Method\n";
        }
        if(document.getElementById("ctl00_ContentPlaceHolder1_rbtnLegalRepresant_0").checked == false && document.getElementById("ctl00_ContentPlaceHolder1_rbtnLegalRepresant_1").checked == false)
        {
            strError +="Please Select the Legal Representation\n";
        }
        if(document.getElementById("ctl00_ContentPlaceHolder1_dwAttorneyForm").value == "--Select Loss Attorney--")
        {
            strError +="Please Select the Attorney form\n";
        }
        if(document.getElementById("ctl00_ContentPlaceHolder1_txtDeductRaimbursh").value == "")
        {
            strError +="Please Enter the Deductible Reimbursement Amount\n";
        }
        
        if(strError.length > 0)
        {
            //document.getElementById("spnMandetory").style.display="";
            if(type=="show")
                alert(strError);
            else
                alert("Please First Enter the Carrier Data Information");
                
            return false;
        }
        else
        {
            //document.getElementById("spnMandetory").style.display="none";
            return true;
        }
    }
    
     function ValidAttachment()
    {       
        var strError = "";
        if(validation('Hide'))
        {
            if(document.getElementById("ctl00_ContentPlaceHolder1_ddlAttachType").value == "--Select Attachment Type--")
            {
                 strError += "Please Select Attachment Type.\n";
            }
            if(document.getElementById("ctl00_ContentPlaceHolder1_uplCommon").value == "")
            {
                 strError += "Please Select File To Upload.\n";
            }
            if(strError.length > 0)
            {
                alert(strError);
                return false;
            }
            return true;
        }
        else
        {
            return false;
        }
    }
    
     function getfirst()
    {
        clearfocus();
        document.getElementById("first").className="left_menu_active";
        document.getElementById("ctl00_ContentPlaceHolder1_divfirst").style.display ="block";
    }
    function getsecond()
    {
   
        clearfocus();
        document.getElementById("second").className="left_menu_active";
        document.getElementById("ctl00_ContentPlaceHolder1_divsecond").style.display ="block";
//        document.getElementById("spnMandetory").style.display="none";
    }
    function getthird()
    {
        clearfocus();
        document.getElementById("third").className="left_menu_active"; 
        document.getElementById("ctl00_ContentPlaceHolder1_divthird").style.display ="block";
        document.getElementById("ctl00_ContentPlaceHolder1_dvAttachDetails").style.display ="block";
    }
    
    function clearfocus()
    { 
        document.getElementById("first").className="left_menu";     
        document.getElementById("second").className="left_menu";     
        document.getElementById("third").className="left_menu";     
        
        document.getElementById("ctl00_ContentPlaceHolder1_divfirst").style.display ="none"; 
        document.getElementById("ctl00_ContentPlaceHolder1_divsecond").style.display ="none";  
        document.getElementById("ctl00_ContentPlaceHolder1_divthird").style.display ="none";   
        document.getElementById("ctl00_ContentPlaceHolder1_divSaveView").style.display ="none"; 
        document.getElementById("ctl00_ContentPlaceHolder1_dvAttachDetails").style.display ="none";
        
       // document.getElementById("spnMandetory").style.display="none";
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

    <div style="width: 100%" id="contmain">
        <%--Menu DIV--%>
        <br />
        <div id="Div1" runat="server" style="width: 100%; text-align: center">
            <table border="0" cellpadding="1" cellspacing="0" width="99%">
                <tr>
                    <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="Workers_ Compensation.aspx">Worker's Compensation</a></td>
                    <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="WorkerCompensationReserve.aspx">Reserve Worksheets</a></td>
                    <td align="center" class="active_tab" style="background-image: url('../images/active_btn.jpg')"
                        valign="middle">
                        Carrier Data</td>
                    <td align="center" class="active_tab" style="background-image: url('../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="subrogation.aspx">Subrogation</a></td>
                    <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="SubrogationDetail.aspx">Subrogation Detail</a></td>
                    <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="CheckRegister.aspx">Check Register</a></td>
                    <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="MainDiary.aspx">Diary</a></td>
                    <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="MainAdjuster.aspx">Adjustor Notes</a></td>
                    <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="Settlement.aspx">Settlement</a></td>
                </tr>
            </table>
        </div>
        <div id="leftDiv" runat="server" style="width: 18%; height: 350px; float: left; border: solid 1px #7F7F7F;
            margin: 1px 1px 1px 4px;">
            <table border="0" cellpadding="5" cellspacing="5" width="100%">
                <tr>
                    
                    <td style="width: 100%">
                        <a class="left_menu_active" id="first" onclick="javascript:getfirst();" href="#">Claim
                            Details</a></td>
                </tr>
                <tr>
                 <%-- <td>
                        &nbsp;</td>--%>
                    <td style="width: 100%">
                        <a class="left_menu" id="second" onclick="javascript:getsecond();" href="#">Carrier Data
                            Info <span class="mf">*</span> </a>
                    </td>
                </tr>
                <tr>
                   <%-- <td>
                        &nbsp;</td>--%>
                    <td>
                        <a class="left_menu" id="third" onclick="javascript:getthird();" href="#">Attachment</a></td>
                </tr>
            </table>
        </div>
        <div id="mainContent" runat="server" style="border: solid 1px #7F7F7F; width: 79%;
            float: right; margin: 1px 5px 1px 1px; padding: 5px 5px 5px 5px">
            <div style="width: 100%; display: block;" id="divfirst" runat="server">
                <table id="Table1" runat="server" cellpadding="0" cellspacing="0" class="stylesheet"
                    width="100%">
                    <tr>
                        <td class="ghc" colspan="7">
                            Claim Details
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMClaimNumber">Claim Number</asp:Label> 
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            <asp:Label runat="server" ID="lblClaimNo"></asp:Label>
                        </td>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMDOIncident">Date of Incident</asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            <asp:Label runat="server" ID="lblDateIncident"></asp:Label>
                        </td>
                        
                        
                    </tr>
                    
                    <tr>
                        <%--<td class="lc">
                            <asp:Label runat="server" ID="lblMLastName">Last Name</asp:Label>
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:Label runat="server" ID="lblLName"></asp:Label>
                        </td>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMFirstName"> First Name</asp:Label>
                        </td>
                        <td>
                            :</td>
                        <td class="ic">
                            <asp:Label runat="server" ID="lblFName"></asp:Label>
                        </td>--%>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMLastName">Name</asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            <asp:Label runat="server" ID="lblLName"></asp:Label>&nbsp;
                            <asp:Label runat="server" ID="lblMName"></asp:Label>&nbsp;
                            <asp:Label runat="server" ID="lblFName"></asp:Label>
                            
                            
                        </td>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMEmployee">Employee</asp:Label> 
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            <asp:RadioButtonList ID="rbtnEmployee" runat="server" Enabled="false" RepeatDirection="Horizontal">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <%--<td class="lc">
                            
                        </td>
                        <td>
                            :
                        </td>
                        <td class="ic">
                            <asp:Label runat="server" ID="lblMName"></asp:Label>
                        </td>--%>
                        
                    </tr>
                </table>
            </div>
            <div style="width: 100%; display: none;" id="divsecond" runat="server">
                <table cellpadding="2" cellspacing="0" class="stylesheet" style="width:100%;">
                    <tr>
                        <td class="ghc" colspan="6">
                            Carrier Data Information
                        </td>
                    </tr>
                    <tr>
                        <td class="lc" style="width:21%;">
                            <asp:Label runat="server" ID="lblMClaimMode">Claim Mode</asp:Label>                            
                        </td>
                        <td style="width:2%;" align="left" class="lc">
                            :
                        </td>
                        <td class="ic" style="width:27%;">
                            <asp:RadioButtonList ID="rbtnClaimMode" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem Selected="True">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td class="lc" style="width:21%;">
                            <asp:Label runat="server" ID="lblMDefenseMedicalEva">Defense Medical Evaluation paid to
                            Date </asp:Label>
                            <span class="mf">*</span></td>
                        <td style="width:2%;" align="left" class="lc">
                            :
                        </td>
                        <td class="ic" style="width:27%;">
                            $<asp:TextBox ID="txtDefenseMedicalEva" SkinID="txtCarrier" runat="server" MaxLength="11" onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="rfvDefenseMedicalEva" Display="none" Text="*"
                                ErrorMessage="Please Enter [Carrier Data Information]/Defense Medical Evaluation Paid To Date" ValidationGroup="vsErrorGroup"
                                ControlToValidate="txtDefenseMedicalEva">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMEmpLegalExp">Employer Legal Expense to<br /> Date </asp:Label>
                            <span class="mf">*</span>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            $<asp:TextBox ID="txtEmpLegalExp" SkinID="txtCarrier" runat="server" MaxLength="20" onKeyPress="javascript:return(currencyFormat(this,',','.',event))"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="rfvEmpLegalExp" Display="none" Text="*" ErrorMessage="Please Enter [Carrier Data Information]/Employer Legal Expense To Date"
                                ValidationGroup="vsErrorGroup" ControlToValidate="txtEmpLegalExp">
                            </asp:RequiredFieldValidator>
                        </td>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMEmpPayroll">Employer Payroll Table</asp:Label>
                        </td>
                        <td class="lc">
                            :</td>
                        <td class="ic">
                            <asp:DropDownList runat="server" ID="dwEmpPayroll" SkinID="dropTextLen">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMEmpLiability">Employer's Liability </asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            $<asp:TextBox ID="txtEmpLiability" SkinID="txtCarrier" runat="server" MaxLength="11" onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                        </td>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMEmpLiabilityPaid">Employer Liability Paid To <br />Date </asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            $<asp:TextBox ID="txtEmpLiabilityPaid"  SkinID="txtCarrier" runat="server" MaxLength="11" onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMExpertWitnessPaid">Expert Witness Paid To<br /> Date </asp:Label>
                            <span class="mf">*</span></td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            $<asp:TextBox ID="txtExpertWitnessPaid" SkinID="txtCarrier" runat="server" MaxLength="11" onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="rfvExpertWitnessPaid" Display="none" Text="*"
                                ErrorMessage="Please Enter [Carrier Data Information]/Expert Witness Paid To Date" ValidationGroup="vsErrorGroup"
                                ControlToValidate="txtExpertWitnessPaid">
                            </asp:RequiredFieldValidator>
                        </td>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMFuneralExpPaid">Funeral Expenses Paid To<br /> Date </asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            $<asp:TextBox ID="txtFuneralExpPaid" SkinID="txtCarrier" runat="server" MaxLength="11" onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMHospitalCostPaid">Hospital Cost Paid To Date </asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            $<asp:TextBox ID="txtHospitalCostPaid"  SkinID="txtCarrier" runat="server" MaxLength="11" onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                        </td>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMIndependentSubContractNo">Independent Subcontractor Number</asp:Label>                            
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtIndependentSubContractNo" SkinID="txtNo$Carrier" runat="server" MaxLength="3"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMMajorClassCode">Major Class Code</asp:Label>
                            <span class="mf">*</span></td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic" colspan="4">
                            <asp:DropDownList runat="server" ID="dwMajorClassCode" SkinID="dropCarrierBig">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ID="rfvMajorClassCode" Display="none" Text="*"
                                ErrorMessage="Please Select [Carrier Data Information]/Major Class Code" InitialValue="--Select Major Class Code--"
                                ValidationGroup="vsErrorGroup" ControlToValidate="dwMajorClassCode">
                            </asp:RequiredFieldValidator>
                        </td>
                        
                    </tr>
                    <tr>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMProducerCode">Producer Code</asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtProducerCode" runat="server" SkinID="txtNo$Carrier" MaxLength="7" onkeypress="return numberOnly(event);"></asp:TextBox>
                        </td>
                         <td class="lc">
                            <asp:Label runat="server" ID="lblMLumpSumRemarriage">Lump Sum Remarriage<br /> Payment </asp:Label>
                            <span class="mf">*</span></td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            $<asp:TextBox ID="txtLumpSumRemarriage" SkinID="txtCarrier" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))" MaxLength="11"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="rfvLumpSumRemarriage" Display="none" Text="*"
                                ErrorMessage="Please Enter [Carrier Data Information]/Lump Sum Remarriage Payment" InitialValue="" ValidationGroup="vsErrorGroup"
                                ControlToValidate="txtLumpSumRemarriage">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMProductRecovery">Product Liability Recovery </asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            $<asp:TextBox ID="txtProductRecovery" SkinID="txtCarrier" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))" MaxLength="11"></asp:TextBox>
                        </td>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMProductName">Product Name</asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtProductName" SkinID="txtNo$Carrier" runat="server" MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMLossCondAct">Loss Condition Act</asp:Label>
                            <span class="mf">*</span></td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic" colspan="4">
                            <asp:DropDownList runat="server" ID="dwLossCondAct" SkinID="dropCarrierBig">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ID="rfvLossCondAct" Display="none" Text="*" ErrorMessage="Please Select [Carrier Data Information]/Loss Condition Act"
                                InitialValue="--Select Loss Condition Act--" ValidationGroup="vsErrorGroup" ControlToValidate="dwLossCondAct">
                            </asp:RequiredFieldValidator>
                        </td>
                        
                    </tr>
                    <tr>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMLossCondRecovery">Loss Condition Type<br /> Recovery </asp:Label>
                            <span class="mf">*</span></td>
                        <td class="lc">
                            :
                        </td>
                        <td colspan="4" class="ic">
                            <asp:DropDownList runat="server" ID="dwLossCondRecovery" SkinID="dropCarrierBig">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ID="rfvLossCondRecovery" Display="none" Text="*"
                                ErrorMessage="Please Select [Carrier Data Information]/Loss Condition Type Recovery" InitialValue="--Select Loss Condition Type Recovery--"
                                ValidationGroup="vsErrorGroup" ControlToValidate="dwLossCondRecovery">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMLossCoverageCode">Loss Coverage Code</asp:Label>
                            <span class="mf">*</span></td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic" colspan="4">
                            <asp:DropDownList runat="server" ID="dwLossCoverageCode" SkinID="dropCarrierBig">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ID="rfvLossCoverageCode" Display="none" Text="*"
                                ErrorMessage="Please Select [Carrier Data Information]/Loss Coverage Code" InitialValue="--Select Loss Coverage Code--"
                                ValidationGroup="vsErrorGroup" ControlToValidate="dwLossCoverageCode">
                            </asp:RequiredFieldValidator>
                        </td>
                       
                    </tr>
                    <tr>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMIncurredLoss">Incurred Loss </asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            $<asp:TextBox ID="txtIncurredLoss" SkinID="txtCarrier" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))" MaxLength="11"></asp:TextBox>
                        </td>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMOtherBenefit">Other Benefit Offset</asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            <asp:RadioButtonList ID="rbtnOtherBenefit" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem Selected="True">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMOtherMedicalPaid">Other Medical Paid To Date </asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            $<asp:TextBox ID="txtOtherMedicalPaid" SkinID="txtCarrier" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))" MaxLength="11"></asp:TextBox>
                        </td>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMOtherVocationRehap">Other Vocational Rehab Expenses Paid To Date </asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            $<asp:TextBox ID="txtOtherVocationRehap" SkinID="txtCarrier" onKeyPress="return(currencyFormat(this,',','.',event))" runat="server" MaxLength="11"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc" style="height: 40px">
                            <asp:Label runat="server" ID="lblMPenaltyPaid">Penalties Paid To Date  </asp:Label>
                            <span class="mf">*</span></td>
                        <td style="height: 40px" class="lc">
                            :
                        </td>
                        <td class="ic" style="height: 40px">
                            $<asp:TextBox ID="txtPenaltyPaid" SkinID="txtCarrier" runat="server" MaxLength="11" onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="rfvPenaltyPaid" Display="none" Text="*" ErrorMessage="Please Enter [Carrier Data Information]/Penalties Paid To Date"
                                InitialValue="" ValidationGroup="vsErrorGroup" ControlToValidate="txtPenaltyPaid">
                            </asp:RequiredFieldValidator>
                        </td>
                        <td class="lc" style="height: 40px">
                            <asp:Label runat="server" ID="lblMPensionIndem">Pension Indemnity Benefit Paid To Valuation Date  </asp:Label>
                            <span class="mf">*</span></td>
                        <td style="height: 40px" class="lc">
                            :
                        </td>
                        <td style="height: 40px" class="ic">
                            $<asp:TextBox ID="txtPensionIndem" SkinID="txtCarrier" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))" MaxLength="11"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="rfvPensionIndem" Display="none" Text="*" ErrorMessage="Please Enter [Carrier Data Information]/Pension Indemnity Benefit Paid To Valuation Date"
                                InitialValue="" ValidationGroup="vsErrorGroup" ControlToValidate="txtPensionIndem">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMPensionIndemNotPaid">Pension Indemnity Previously Reserved, Not Paid </asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            $<asp:TextBox ID="txtPensionIndemNotPaid" SkinID="txtCarrier" onKeyPress="return(currencyFormat(this,',','.',event))" runat="server" MaxLength="11"></asp:TextBox>
                        </td>
                        <td class="ic">
                            <asp:Label runat="server" ID="lblMPensionPlan">Pension Plane Benefit Offset?</asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            <asp:RadioButtonList ID="rbtnPensionPlan" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem Selected="True">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblGarageState">Garage State </asp:Label>
                            <span class="mf">*</span></td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            <asp:DropDownList runat="server" ID="dwGarageState" SkinID="dropTextLen">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ID="rfvGarageState" Display="none" Text="*" ErrorMessage="Please Select [Carrier Data Information]/Garage State"
                                InitialValue="--Select State--" ValidationGroup="vsErrorGroup" ControlToValidate="dwGarageState">
                            </asp:RequiredFieldValidator>
                        </td>
                         <td class="lc">
                            <asp:Label runat="server" ID="lblMReserveTypeCode">Reserve Type Code</asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtReserveTypeCode" SkinID="txtNo$Carrier" runat="server" onkeypress="return numberOnly(event);" MaxLength="2"></asp:TextBox>
                        </td>
                        
                    </tr>
                    <tr>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMInjurytype">Injury Type</asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td colspan="4">
                            <asp:DropDownList runat="server" ID="dwInjurytype" SkinID="dropCarrierBig">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMPropertyDamageType">Property Damage Type</asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic" colspan="4">
                            <asp:DropDownList runat="server" ID="dwPropertyDamageType" SkinID="dropCarrierBig">
                            </asp:DropDownList>
                        </td>
                       
                    </tr>                    
                    <tr>
                         <td class="lc">
                            <asp:Label runat="server" ID="lblMRecoveryCurrMonth">Recovery Current Month </asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            $<asp:TextBox ID="txtRecoveryCurrMonth" SkinID="txtCarrier" onKeyPress="return(currencyFormat(this,',','.',event))" runat="server" MaxLength="11"></asp:TextBox>
                        </td>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMRecoveryDate">Recovery To Date </asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            $<asp:TextBox ID="txtRecoveryDate" SkinID="txtCarrier" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))" MaxLength="11"></asp:TextBox>
                        </td>
                       
                    </tr>
                    <tr>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMSingleSumPaidDate">Date Single Sum Paid</asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtSingleSumPaidDate" runat="server" SkinID="txtDate"></asp:TextBox>
                            <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtSingleSumPaidDate', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                align="absmiddle" /><br />
                            <cc1:MaskedEditExtender ID="mskSingleSumPaidDate" runat="server" AcceptNegative="Left"
                                DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtSingleSumPaidDate"
                                CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                            </cc1:MaskedEditExtender>
                            <cc1:MaskedEditValidator ID="mskValDtStart" runat="server" ControlExtender="mskSingleSumPaidDate"
                                ControlToValidate="txtSingleSumPaidDate" Display="none" IsValidEmpty="true"
                                MaximumValue="" InvalidValueMessage="Date is invalid" MaximumValueMessage=""
                                MinimumValueMessage="" TooltipMessage="" MinimumValue="" >
                            </cc1:MaskedEditValidator>
                            <asp:RegularExpressionValidator id="revIDONoteEntry" runat="server" ControlToValidate="txtSingleSumPaidDate"
                            ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                            ErrorMessage="[Carrier Data Information]/Date Single Sum Paid Is Not Valid Date" Display="none" Text="*" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                        </td>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMSingleSum">Single Sum Paid </asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            $<asp:TextBox ID="txtSingleSum" SkinID="txtCarrier" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))" MaxLength="11"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMSocialSecBenifit">Social Security Benefit Offset?</asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            <asp:RadioButtonList ID="rbtnSocialSecBenifit" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem Selected="True">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMSSOffsetAmt">Social Security or Other Offset Amount </asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            $<asp:TextBox ID="txtSSOffsetAmt" SkinID="txtCarrier" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))" MaxLength="11"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblSpecialFundBeni">Special fund Benefit Offset?</asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            <asp:RadioButtonList ID="rbtnSpecialFundBeni" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem Selected="True">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMSymbol">Symbol</asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtSymbol" SkinID="txtNo$Carrier" runat="server" MaxLength="3" onkeypress="return numberOnly(event);"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMTaxState">Tax State</asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            <asp:DropDownList ID="dwTaxState" runat="server" SkinID="dropTextLen">
                            </asp:DropDownList>
                        </td>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMTpa">TPA internal Claim Code</asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtTpa" SkinID="txtNo$Carrier" runat="server" MaxLength="26"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMTempIndemIncurred">Temporary Indemnity Incurred </asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            $<asp:TextBox ID="txtTempIndemIncurred" SkinID="txtCarrier" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))" MaxLength="11"></asp:TextBox>
                        </td>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMTempIndemNoOfWeeks">Temporary Indemnity Number of weeks</asp:Label>                            
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtTempIndemNoOfWeeks" SkinID="txtNo$Carrier" runat="server" onkeypress="return numberOnly(event);" MaxLength="4"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMTimeExpCurrMonth">Time & Expense Of Current Month </asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            $<asp:TextBox ID="txtTimeExpCurrMonth" SkinID="txtCarrier" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))" MaxLength="11"></asp:TextBox>
                        </td>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblTimeExpDate">Time & Expense to Date </asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            $<asp:TextBox ID="txtTimeExpDate" SkinID="txtCarrier" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))" MaxLength="11"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMTotalGrossIncurred">Total Gross Incurred </asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            $<asp:TextBox ID="txtTotalGrossIncurred" SkinID="txtCarrier" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))" MaxLength="11"></asp:TextBox>
                        </td>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblTotIncVocRehab">Total Incurred Vocational Rehabilitation </asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            $<asp:TextBox ID="txtTotIncVocRehab" SkinID="txtCarrier" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))" MaxLength="11"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMTotIncVocRehabEduBeni">Total Incurred Vocational Rehabilitation Education Benefit </asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            $<asp:TextBox ID="txtTotIncVocRehabEduBeni" SkinID="txtCarrier" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))" MaxLength="11"></asp:TextBox>
                        </td>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMTotIncuocationRehabExp">Total Incurred Vocational Rehabilitation Evaluation<br /> Expense </asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            $<asp:TextBox ID="txtTotIncuocationRehabExp" SkinID="txtCarrier" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))" MaxLength="11"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMTotIncVocRehabMaintBen">Total Incurred Vocational Rehabilitation Maintenance Benefit</asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtTotIncVocRehabMaintBen" SkinID="txtNo$Carrier" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))" MaxLength="11"></asp:TextBox>
                        </td>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMTotPayToPhysician">Total Payments to Physicians </asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            $<asp:TextBox ID="txtTotPayToPhysician" SkinID="txtCarrier" onKeyPress="return(currencyFormat(this,',','.',event))" runat="server" MaxLength="11"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMTransactCode">Transaction Type Code</asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtTransactCode" SkinID="txtNo$Carrier" runat="server" onkeypress="return numberOnly(event);" MaxLength="1"></asp:TextBox>
                        </td>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMUnEmpBenifit">Unemployment Benefit Offset?</asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            <asp:RadioButtonList ID="rbtnUnEmpBenifit" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem Selected="True">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMUniqueOccurrence">Unique Occurrence Claim Indicator</asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            <asp:TextBox ID="txtUniqueOccurrence" SkinID="txtNo$Carrier" runat="server" MaxLength="1"></asp:TextBox>
                        </td>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMLumpSumSettleAmt">Lump Sum Settlement<br /> Amount  </asp:Label>
                            <span class="mf">*</span></td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            $<asp:TextBox ID="txtLumpSumSettleAmt" SkinID="txtCarrier" onKeyPress="return(currencyFormat(this,',','.',event))" runat="server" MaxLength="11"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="rfvLumpSumSettleAmt" Display="none" Text="*"
                                ErrorMessage="Please Enter [Carrier Data Information]/Lump Sum Settlement Amount" InitialValue="" ValidationGroup="vsErrorGroup"
                                ControlToValidate="txtLumpSumSettleAmt">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMOtherRecovery">Other Recovery </asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            $<asp:TextBox ID="txtOtherRecovery" SkinID="txtCarrier" onKeyPress="return(currencyFormat(this,',','.',event))" runat="server" MaxLength="11"></asp:TextBox>
                        </td>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMOtherWeekPayment">Other Weekly Payments </asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            $<asp:TextBox ID="txtOtherWeekPayment" SkinID="txtCarrier" onKeyPress="return(currencyFormat(this,',','.',event))" runat="server" MaxLength="11"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc" style="height: 44px">
                            <asp:Label runat="server" ID="lblMCatastropheNo">Worker's Compensation Catastrophe Number</asp:Label>
                        </td>
                        <td style="height: 44px" class="lc">
                            :
                        </td>
                        <td class="ic" style="height: 44px">
                            <asp:TextBox ID="txtCatastropheNo" SkinID="txtNo$Carrier" onkeypress="return numberOnly(event);" runat="server" MaxLength="2"></asp:TextBox>
                        </td>
                        <td class="lc" style="height: 44px">
                            <asp:Label runat="server" ID="lblMWorkCompIndemPay">Worker's Compensation Indemnity Payment </asp:Label>                            
                        </td>
                        <td style="height: 44px" class="lc">
                            :
                        </td>
                        <td style="height: 44px" class="lc">
                            $<asp:TextBox ID="txtWorkCompIndemPay" SkinID="txtCarrier" onKeyPress="return(currencyFormat(this,',','.',event))"  runat="server" MaxLength="11"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMIndemIncurred">Indemnity Incurred to Date </asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            $<asp:TextBox ID="txtIndemIncurred" SkinID="txtCarrier" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))" MaxLength="11"></asp:TextBox>
                        </td>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMIndemIncuCurrMonth">Indemnity Incurred Current Month </asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            $<asp:TextBox ID="txtIndemIncuCurrMonth" SkinID="txtCarrier" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))" MaxLength="11"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMIndemPaid">Indemnity Paid to Date </asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            $<asp:TextBox ID="txtIndemPaid" runat="server" SkinID="txtCarrier" onKeyPress="return(currencyFormat(this,',','.',event))" MaxLength="11"></asp:TextBox>
                        </td>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMMediIncurToDate">Medical Incurred To Date </asp:Label>
                        </td>
                        <td class="lc"> 
                            :
                        </td>
                        <td class="ic">
                            $<asp:TextBox ID="txtMediIncurToDate" runat="server" SkinID="txtCarrier" onKeyPress="return(currencyFormat(this,',','.',event))" MaxLength="11"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMMedicalIncuCurrMonth">Medical incurred Current Month </asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            $<asp:TextBox ID="txtMedicalIncuCurrMonth" SkinID="txtCarrier" onKeyPress="return(currencyFormat(this,',','.',event))" runat="server" MaxLength="11"></asp:TextBox>
                        </td>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMMediPaidToDate">Medical Paid To Date </asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            $<asp:TextBox ID="txtMediPaidToDate" SkinID="txtCarrier" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))" MaxLength="11"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMExpIncurred">Expense Incurred To Date </asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            $<asp:TextBox ID="txtExpIncurred" SkinID="txtCarrier" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))" MaxLength="11"></asp:TextBox>
                        </td>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMExpIncuCurrMonth">Expense Incurred Current<br /> Month </asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            $<asp:TextBox ID="txtExpIncuCurrMonth" SkinID="txtCarrier" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))" MaxLength="11"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMExpPaid">Expense Paid To Date </asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            $<asp:TextBox ID="txtExpPaid" runat="server" SkinID="txtCarrier" onKeyPress="return(currencyFormat(this,',','.',event))" MaxLength="11"></asp:TextBox>
                        </td>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMContovertedcase">Controverter Case? </asp:Label>
                            <span class="mf">*</span></td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            <table>
                                <tr>
                                    <td>
                                        <asp:RadioButtonList ID="rbtnContovertedcase" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem Selected="True">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator runat="server" ID="rfvContovertedcase" Display="none" Text="*"
                                            ErrorMessage="Please Select [Carrier Data Information]/Controverter Case?" InitialValue="" ValidationGroup="vsErrorGroup"
                                            ControlToValidate="rbtnContovertedcase">
                                        </asp:RequiredFieldValidator>                                    
                                    </td>
                                </tr>                            
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMInsurerRaimbursed">Insurer Reimbursed For All Or Part of Benefits Payable to Claimant? </asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            <asp:RadioButtonList ID="rbtnInsurerRaimbursed" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem Selected="True">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMAIGPolicyPrefix">AIG Policy Prefix </asp:Label>
                        </td>
                        <td class="lc">
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtAIGPolicyPrefix" SkinID="txtNo$Carrier" runat="server" MaxLength="4"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMLossCondLoss">Loss Conditions Loss</asp:Label>
                            <span class="mf">*</span></td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            <asp:DropDownList runat="server" ID="dwLossCondLoss" SkinID="dropTextLen">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ID="rfvLossCondLoss" Display="none" Text="*" ErrorMessage="Please Select [Carrier Data Information]/Loss Conditions Loss"
                                InitialValue="--Select Loss Condition Loss--" ValidationGroup="vsErrorGroup"
                                ControlToValidate="dwLossCondLoss">
                            </asp:RequiredFieldValidator>
                        </td>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMLossCondSettlement">Loss Condition<br /> Settlement </asp:Label>
                            <span class="mf">*</span></td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            <asp:DropDownList runat="server" ID="dwLossCondSettlement" SkinID="dropTextLen">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ID="rfvLossCondSettlement" Display="none" Text="*"
                                ErrorMessage="Please Select [Carrier Data Information]/Loss Condition Settlement" InitialValue="--Select Condition Settlement--"
                                ValidationGroup="vsErrorGroup" ControlToValidate="dwLossCondSettlement">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMDeductibleIndicator">Deductible Indicator</asp:Label>
                            <span class="mf">*</span></td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            <table>
                                <tr>
                                    <td>
                                        <asp:RadioButtonList ID="rbtnDeductibleIndicator" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem Selected="True">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator runat="server" ID="rfvDeductibleIndicator" Display="none" Text="*"
                                            ErrorMessage="Please Select [Carrier Data Information]/Deductible Indicator" InitialValue="" ValidationGroup="vsErrorGroup"
                                            ControlToValidate="rbtnDeductibleIndicator">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblDeductRaimbursh">Deductible Reimbursement Amount </asp:Label>
                            <span class="mf">*</span></td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            $<asp:TextBox ID="txtDeductRaimbursh" SkinID="txtCarrier" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))" MaxLength="11"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="rfvDeductRaimbursh" Display="none" Text="*"
                                ErrorMessage="Please Enter [Carrier Data Information]/Deductible Reimbursement Amount" InitialValue=""
                                ValidationGroup="vsErrorGroup" ControlToValidate="txtDeductRaimbursh">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr> 
                    <tr>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMSettlementMethod">Settlement Method</asp:Label>
                            <span class="mf">*</span></td>
                        <td class="lc">
                            :
                        </td>
                        <td colspan="4" class="ic">
                            <asp:DropDownList runat="server" ID="dwSettlementMethod" SkinID="dropCarrierBig">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ID="rfvSettlementMethod" Display="none" Text="*"
                                ErrorMessage="Please Select [Carrier Data Information]/Settlement Method" InitialValue="--Select Settlement Method--"
                                ValidationGroup="vsErrorGroup" ControlToValidate="dwSettlementMethod">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>                   
                    <tr>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMLegalRepresant">Legal Representation</asp:Label>
                            <span class="mf">*</span></td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            <table>
                                <tr>
                                    <td>
                                        <asp:RadioButtonList ID="rbtnLegalRepresant" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem Selected="True">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator runat="server" ID="rfvLegalRepresant" Display="none" Text="*"
                                            ErrorMessage="Please Select [Carrier Data Information]/Legal Representation" InitialValue="" ValidationGroup="vsErrorGroup"
                                            ControlToValidate="rbtnLegalRepresant">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="lc">
                            <asp:Label runat="server" ID="lblMAttorneyForm">Attorney form</asp:Label>
                            <span class="mf">*</span></td>
                        <td class="lc">
                            :
                        </td>
                        <td class="ic">
                            <asp:DropDownList runat="server" ID="dwAttorneyForm" SkinID="dropTextLen">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ID="rfvAttorneyForm" Display="none" Text="*" ErrorMessage="Please Select [Carrier Data Information]/Attorney form"
                                InitialValue="--Select Loss Attorney--" ValidationGroup="vsErrorGroup" ControlToValidate="dwAttorneyForm">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        
                    </tr>
                </table>
            </div>
            <div style="width: 100%; display: none;" id="divthird" runat="server">
                <table cellpadding="2" cellspacing="2" class="stylesheet" width="100%">
                    <tr>
                        <td class="ghc" colspan="6">
                            Attachment
                        </td>
                    </tr>
                   
                    <tr style="display:none;">
                        <td class="lc" valign="top" align="left">
                            Attachment Type
                        </td>
                        <td style="width: 5px;" valign="top" align="left">
                            :
                        </td>
                        <td class="ic" colspan="4" valign="top" align="left">
                            <asp:DropDownList runat="server" SkinID="dropGen" ID="ddlAttachType">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvAttachType" ControlToValidate="ddlAttachType"
                            runat="server" InitialValue="--Select Attachment Type--" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select the Attachment Type."
                            Display="none"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc" valign="top" align="left">
                            Attachment Description
                        </td>
                        <td style="width: 5px;" class="lc" valign="top" align="left">
                            :
                        </td>
                        <td colspan="4" class="ic">
                            <asp:ImageButton ID="ibtnDisplay" ImageUrl="~/Images/minus.jpg" runat="server" OnClientClick="javascript:return MinMax();" />                            
                            <div id="pnlTemp" style="display:block;">
                            <asp:TextBox ID="txtDescription" SkinID="txtCarrier" runat="server" MaxLength="4000" TextMode="MultiLine" Width="93%" Height="200px"></asp:TextBox>
                            </div>
                           
                        </td>
                    </tr>
                    <tr>
                        <td class="lc" valign="top" align="left">
                            Select File
                        </td>
                        <td class="lc" style="width: 5px;" valign="top" align="left">
                            :
                        </td>
                        <td colspan="4" class="ic" valign="top" align="left">
                            <asp:FileUpload runat="server" ID="uplCommon" />
                            <asp:RequiredFieldValidator ID="rfvUpload" runat="server" ControlToValidate="uplCommon" InitialValue="" 
                            Display="none" Text="*" ErrorMessage="Please Select [Attachment]/File To Upload" ValidationGroup="vsErrorGroup">                                                                        
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
                </table>
                <table cellpadding="5" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td class="ic" align="center">
                            <asp:Button ID="btnAddAttachment" runat="server" Text="Add Attachment" OnClientClick="javascript:ValAttach();"
                             ValidationGroup="vsErrorGroup"   OnClick="btnAddAttachment_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="dvAttachDetails" runat="server" style="display: none;">
                <table width="100%">
                    <tr>
                        <td colspan="2">
                            <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                font-weight: Bolder; font-family: Tahoma; font-size: 10pt;">
                                <tr>
                                    <td class="ghc">
                                        Attachment Details
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:GridView ID="gvAttachmentDetails" runat="server" AutoGenerateColumns="false"
                                DataKeyNames="PK_Attachment_ID" Width="100%" AllowPaging="True" AllowSorting="False"
                                OnRowDataBound="gvAttachmentDetails_RowDataBound">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <input name="chkItem" type="checkbox" value='<%# Eval("PK_Attachment_ID")%>' onclick="javascript:UnCheckHeader('gvAttachmentDetails')" />
                                        </ItemTemplate>
                                        <ItemStyle Width="10px" />
                                        <HeaderTemplate>
                                            <input id="chkHeader" type="checkbox" runat="Server" name="chkHeader" onclick="javascript:SelectAllCheckboxes(this)" />
                                        </HeaderTemplate>
                                        <HeaderStyle Width="10px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Attachment_Type" HeaderText="Attachment Type" Visible="false" >
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Attachment_Description" HeaderText="Attachment Description" ></asp:BoundField>
                                    <asp:BoundField DataField="Attachment_Name1" HeaderText="File Name" >
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="View">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbtnDwnld" CommandName="Download" CommandArgument='<%# Eval("Attachment_Name")%>'
                                                runat="server" ImageAlign="Left" ImageUrl="~/Images/download.gif" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                                    </asp:TemplateField>
                                  <%--  <asp:TemplateField HeaderText="Mail">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbtnMail" CommandName="Mail" CommandArgument='<%# Eval("Attachment_Name")%>'
                                                runat="server" ImageUrl="~/Images/emailicon.gif" ImageAlign="Left" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                                    </asp:TemplateField>--%>
                                </Columns>
                                <EmptyDataRowStyle ForeColor="red" HorizontalAlign="Center" />
                                <EmptyDataTemplate>
                                    Currently there is no Attachment.<br />
                                    Please add one or more Attachment.
                                </EmptyDataTemplate>
                                <PagerSettings Visible="False" />
                                <PagerSettings Visible="False" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnRemove" runat="server" Text="Remove" OnClick="btnRemove_Click" />
                            <asp:Button ID="btnMail" runat="server" Text="Mail" OnClientClick="javascript:return OpenWMail('gvAttachmentDetails','Carrier');" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div id="divbtn" runat="server">
        <table style="width: 100%;">
            <tr>
                <td align="center" class="ic">
                    <asp:Button runat="server" ID="btnView" EnableTheming="false" SkinID="btnGen" Text="Save & View"
                        ValidationGroup="vsErrorGroup" OnClientClick="javascript:ValSave();" OnClick="btnView_Click" />
                    <asp:Button ID="Next" runat="server" Text="Next step" OnClick="Next_Click" OnClientClick="javascript:ValSave();" ValidationGroup="vsErrorGroup"/>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div id="divSaveView" style="width: 100%; display: none;" runat="server">
        <div style="width: 100%;">
            <table id="Table2" runat="server" cellpadding="2" cellspacing="4" class="stylesheet"
                width="100%">
                <tr>
                    <td class="ghc" colspan="6">
                        Claim Details
                    </td>
                </tr>
                
                <tr>
                    <td class="lc" style="width: 20%;">
                        <asp:Label runat="server" ID="lblDClaimNo">Claim Number</asp:Label>
                    </td>
                    <td style="width: 5%;" align="center">
                        :
                    </td>
                    <td class="ic" style="width: 25%;">
                        <asp:Label runat="server" ID="lblClaim_No"></asp:Label>
                    </td>
                    <td class="lc">
                       <asp:Label runat="server" ID="lblDDOIncident">Date of Incident</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblDOIncident"></asp:Label>
                    </td>
                    
                    
                    
                </tr>
                <tr>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblDLastName">Name</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblLastName"></asp:Label>&nbsp;
                        <asp:Label runat="server" ID="lblMiddleName"></asp:Label>&nbsp;
                        <asp:Label runat="server" ID="lblFirName"></asp:Label>
                    </td>
                    <td class="lc" style="width: 20%;">
                        <asp:Label runat="server" ID="lblDEmployee">Employee</asp:Label>
                    </td>
                    <td style="width: 5%;" align="center">
                        :
                    </td>
                    <td class="ic" style="width: 25%;">
                        <asp:Label runat="server" ID="lblEmp"></asp:Label>
                        
                         
                    </td>
                    <%--<td class="lc">
                        <asp:Label runat="server" ID="lblDFirstName"> First Name</asp:Label>
                    </td>
                    <td align="center">
                        :</td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblFirName"></asp:Label>
                    </td>--%>
                </tr>
                <%--<tr>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblDMiddleName">Middle Name</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblMiddleName"></asp:Label>
                    </td>
                    
                </tr>--%>
                
            </table>
        </div>
        <div style="width: 100%;">
            <table cellpadding="2" cellspacing="4" class="stylesheet" width="100%">
                <tr>
                    <td class="ghc" colspan="6">
                        Carrier Data Information
                    </td>
                </tr>                
                <tr>
                    <td class="lc" style="width: 20%;">
                        <asp:Label runat="server" ID="lblVClaimMode">Claim Mode</asp:Label>                        
                    </td>
                    <td style="width: 5%;" align="center">
                        :
                    </td>
                    <td class="ic" style="width: 25%;">
                        <asp:Label runat="server" ID="lblClaimMode"></asp:Label>
                    </td>
                    <td class="lc" style="width: 20%;">
                        <asp:Label runat="server" ID="lblVDefenseMEdiEvaPTD">Defense Medical Evaluation paid to Date </asp:Label>  
                    </td>
                    <td style="width: 5%;" align="center">
                        :
                    </td>
                    <td class="ic" style="width: 25%;">
                        <asp:Label runat="server" ID="lblDefenseMEdiEvaPTD"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVempLegalExp">Employer Legal Expense to Date </asp:Label>
                        </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblempLegalExp"></asp:Label>
                    </td>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVEmpPayroll">Employer Payroll Table</asp:Label>
                    </td>
                    <td align="center">
                        :</td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblEmpPayroll"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVempLiability">Employer's Liability </asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblempLiability"></asp:Label>
                    </td>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVEmpLiaPTD">Employer Liability Paid To Date </asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblEmpLiaPTD"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVExprtWitPTD">Expert Witness Paid To Date </asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblExprtWitPTD"></asp:Label>
                    </td>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVFuneralExp">Funeral Expenses Paid To Date </asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblFuneralExp"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVHospitalCostPTD">Hospital Cost Paid To Date </asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblHospitalCostPTD"></asp:Label>
                    </td>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVIndependentSubNo">Independent Subcontractor Number</asp:Label>                        
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblIndependentSubNo"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVMajorClassCode">Major Class Code</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblMajorClassCode"></asp:Label>
                    </td>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVProducerCode">Producer Code</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblProducerCode"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVProductLiaRecover">Product Liability Recovery </asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblProductLiaRecover"></asp:Label>
                    </td>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVProductName">Product Name</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblProductName"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVLossCondAct">Loss Condition Act</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblLossCondAct"></asp:Label>
                    </td>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVLossCondRecover">Loss Condition Type Recovery</asp:Label>                        
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblLossCondRecover"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVLossCovCode">Loss Coverage Code</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblLossCovCode"></asp:Label>
                    </td>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVLumpSumRemarriage">Lump Sum Remarriage Payment </asp:Label>                        
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblLumpSumRemarriage"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVIncuLoss">Incurred Loss </asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblIncuLoss"></asp:Label>
                    </td>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVOtherBenefitOffset">Other Benefit Offset</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblOtherBenefitOffset"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVOtherMediPTD">Other Medical Paid To Date </asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblOtherMediPTD"></asp:Label>
                    </td>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVOtherVRExpDate">Other Vocational Rehab Expenses Paid To Date</asp:Label>
                        </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblOtherVRExpDate"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVPenaltyPTD">Penalties Paid To Date</asp:Label>                        
                    </td>
                    <td class="lc" align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblPenaltyPTD"></asp:Label>
                    </td>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVPensionIndemBenePTD">Pension Indemnity Benefit Paid To Valuation Date </asp:Label>
                    </td>
                    <td class="lc" align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblPensionIndemBenePTD"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVPensionResNotPaid">Pension Indemnity Previously Reserved, Not Paid </asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblPensionResNotPaid"></asp:Label>
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblVPensionBeniOffset">Pension Plane Benefit Offset?</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblPensionBeniOffset"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVGarrageState">Garage State</asp:Label>                        
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblGarrageState"></asp:Label>
                    </td>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVInjuryType">Injury Type</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblInjuryType"></asp:Label>
                    </td>
                </tr>                
                <tr>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVPropertyDamange">Property Damage Type</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblPropertyDamange"></asp:Label>
                    </td>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVRecocurrMth">Recovery Current Month </asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblRecocurrMth"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVRecoveryDate">Recovery To Date </asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblRecoveryDate"></asp:Label>
                    </td>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVTypeCode">Reserve Type Code</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblTypeCode"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVSingleSumPaidDate">Date Single Sum Paid</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblSingleSumPaidDate"></asp:Label>
                    </td>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVSingleSumPaid">Single Sum Paid </asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblSingleSumPaid"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVSSbeneOffset">Social Security Benefit Offset?</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblSSbeneOffset"></asp:Label>
                    </td>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVSSAmt">Social Security or Other Offset Amount </asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblSSAmt"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVSpecBeneOff">Special fund Benefit Offset?</asp:Label>
                        </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblSpecBeneOff"></asp:Label>
                    </td>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVSymbol">Symbol</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblSymbol"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVTaxState">Tax State</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblTaxState"></asp:Label>
                    </td>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVTPA">TPA internal Claim Code</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblTPA"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVTempIndemIncu">Temporary Indemnity<br /> Incurred </asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblTempIndemIncu"></asp:Label>
                    </td>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVTempIndemNoWeek">Temporary Indemnity Number of weeks</asp:Label>                        
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblTempIndemNoWeek"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVTECurrMonth">Time & Expense Of Current Month </asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblTECurrMonth"></asp:Label>
                    </td>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVTEDate">Time & Expense to Date </asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblTEDate"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVTotGrossIncu">Total Gross Incurred </asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblTotGrossIncu"></asp:Label>
                    </td>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVTotIVR">Total Incurred Vocational Rehabilitation </asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblTotIVR"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVTotIVREdu">Total Incurred Vocational Rehabilitation Education<br /> Benefit </asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblTotIVREdu"></asp:Label>
                    </td>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVTotIVRExp">Total Incurred Vocational Rehabilitation Evaluation Expense</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblTotIVRExp"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVTotalIVRMaintain">Total Incurred Vocational Rehabilitation Maintenance Benefit</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblTotalIVRMaintain"></asp:Label>
                    </td>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVTotPayPhysician">Total Payments to Physicians </asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblTotPayPhysician"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVTransCode">Transaction Type Code</asp:Label>
                        </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblTransCode"></asp:Label>
                    </td>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVUnEmpBeniOffset">Unemployment Benefit Offset?</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblUnEmpBeniOffset"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVUniqueOcc">Unique Occurrence Claim Indicator</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblUniqueOcc"></asp:Label>
                    </td>
                    <td class="lc">
                         <asp:Label runat="server" ID="lblVLumpSumSettleAmt">Lump Sum Settlement<br /> Amount</asp:Label>                        
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblLumpSumSettleAmt"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVOtherRecovery">Other Recovery</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblOtherRecovery"></asp:Label>
                    </td>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVOtherWeekPay">Other Weekly Payments</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblOtherWeekPay"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVCatastropheNo">Worker's Compensation Catastrophe Number</asp:Label>
                    </td>
                    <td class="lc" align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblCatastropheNo"></asp:Label>
                    </td>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVWorkCompIndemPay">Worker's Compensation Indemnity Payment</asp:Label>
                        
                    </td>
                    <td class="lc" align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblWorkCompIndemPay"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVIndemIncuDate">Indemnity Incurred to Date</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblIndemIncuDate"></asp:Label>
                    </td>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVIndemIncuCurrMonth">Indemnity Incurred Current Month</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblIndemIncuCurrMonth"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVIndemPTD">Indemnity Paid to Date</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblIndemPTD"></asp:Label>
                    </td>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVMediIncuDate">Medical Incurred To Date</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblMediIncuDate"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="lc">
                         <asp:Label runat="server" ID="lblVMediIncuCurrMonth">Medical incurred Current<br /> Month</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblMediIncuCurrMonth"></asp:Label>
                    </td>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVMediPTD">Medical Paid To Date</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblMediPTD"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVExpIncuDate">Expense Incurred To Date</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblExpIncuDate"></asp:Label>
                    </td>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVExpIncuCurrMonth">Expense Incurred Current Month</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblExpIncuCurrMonth"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVExpPTD">Expense Paid To Date</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblExpPTD"></asp:Label>
                    </td>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVControverted">Controverter Case?</asp:Label>                        
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblControverted"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVInsurerReimburse">Insurer Reimbursed For All Or Part of Benefits Payable to Claimant?</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblInsurerReimburse"></asp:Label>
                    </td>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVAIGPolicyPrefix">AIG Policy Prefix</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblAIGPolicyPrefix"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVLossCondLoss">Loss Conditions Loss</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblLossCondLoss"></asp:Label>
                    </td>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVLossCondSettle">Loss Condition Settlement</asp:Label>                        
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblLossCondSettle"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVDeductIndi">Deductible Indicator</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblDeductIndi"></asp:Label>
                    </td>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVSettleMethod">Settlement Method</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblSettleMethod"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVLegalRepresent">Legal Representation</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblLegalRepresent"></asp:Label>
                    </td>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVAttorney">Attorney form</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblAttorney"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="lc">
                        <asp:Label runat="server" ID="lblVDeductReimburse">Deductible Reimbursement Amount</asp:Label>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td class="ic">
                        <asp:Label runat="server" ID="lblDeductReimburse"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        &nbsp;</td>
                </tr>
            </table>
        </div>
        <div style="width: 100%">
            <table width="100%">
                <tr>
                    <td colspan="2">
                        <table cellspacing="4" cellpadding="2" width="100%" style="background-color: #7f7f7f;
                            color: White; font-weight: Bolder; font-family: Tahoma; font-size: 10pt;">
                            <tr>
                                <td class="ghc">
                                    Attachment Details
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="gvAttachView" runat="server" AutoGenerateColumns="false" DataKeyNames="PK_Attachment_ID"
                            Width="100%" AllowPaging="True" AllowSorting="False" OnRowDataBound="gvAttachView_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <input name="chkItem" type="checkbox" value='<%# Eval("PK_Attachment_ID")%>' onclick="javascript:UnCheckHeader('gvAttachView')" />
                                    </ItemTemplate>
                                    <ItemStyle Width="10px" />
                                    <HeaderTemplate>
                                        <input type="checkbox" name="chkHeader" id="chkHeader" runat="Server" onclick="javascript:SelectAllCheckboxes(this)" />
                                    </HeaderTemplate>
                                    <HeaderStyle Width="10px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Attachment_Type" HeaderText="Attachment Type" Visible="false">
                                </asp:BoundField>
                                <asp:BoundField DataField="Attachment_Description" HeaderText="Attachment Description"></asp:BoundField>
                                <asp:BoundField DataField="Attachment_Name1" HeaderText="File Name" >
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="View">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgbtnDwnld" CommandName="Download" CommandArgument='<%# Eval("Attachment_Name")%>'
                                            runat="server" ImageAlign="Left" ImageUrl="~/Images/download.gif" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="60px" />
                                </asp:TemplateField>                              
                            </Columns>
                            <EmptyDataRowStyle ForeColor="red" HorizontalAlign="Center" />
                            <EmptyDataTemplate>
                                Currently there is no Attachment.<br />                               
                            </EmptyDataTemplate>
                            <PagerSettings Visible="False" />
                            <PagerSettings Visible="False" />
                        </asp:GridView>
                    </td>
                </tr>
               <%-- <tr>
                    <td>
                        <asp:Button ID="btnViewMail" runat="server" Text="Mail" OnClientClick="javascript:return OpenWMail('gvAttachView','Carrier');" />
                    </td>
                </tr>--%>
                <tr>
                    <td colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="6" align="center">
                        <asp:Button runat="server" ID="btnBack" Text="Back" OnClick="btnBack_Click" />
                        <asp:Button runat="server" ID="btnViewNext" Text="Next Step" Visible="false" OnClick="btnViewNext_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <asp:HiddenField ID="dispTagName" runat="server" />

    <script language="javascript" type="text/javascript">

        var tagDisplay = document.getElementById("ctl00_ContentPlaceHolder1_dispTagName").value;
      
        if(tagDisplay !="")
        {  
                document.getElementById("third").className="left_menu_active";
                document.getElementById("first").className="left_menu";
                document.getElementById("second").className="left_menu";
        
//            document.getElementById("contmain").style.display ="none";   
//            document.getElementById("divSaveView").style.display ="none";
//            document.getElementById("divbtn").style.display ="none";
//            document.getElementById("ctl00_ContentPlaceHolder1_Div1").style.display ="none"; 
//            document.getElementById("ctl00_ContentPlaceHolder1_leftDiv").style.display ="none"; 
//            document.getElementById("ctl00_ContentPlaceHolder1_mainContent").style.display ="none";
//               
//            switch(tagDisplay)
//            {
//                case "contmain" :
//                        document.getElementById("contmain").style.display ="block";
//                        document.getElementById("divbtn").style.display ="block";
//                        document.getElementById("ctl00_ContentPlaceHolder1_leftDiv").style.display ="block"; 
//                        document.getElementById("ctl00_ContentPlaceHolder1_mainContent").style.display ="block";
//                        document.getElementById("ctl00_ContentPlaceHolder1_Div1").style.display ="block"; 
//                        break;
//                case "divSaveView" :
//                        document.getElementById("divSaveView").style.display ="block"; 
//                        document.getElementById("ctl00_ContentPlaceHolder1_Div1").style.display ="block"; 
//                        document.getElementById("contmain").style.display ="block"; 
//                        //document.getElementById("divfirst").style.display ="none";
//                        //document.getElementById("ctl00_ContentPlaceHolder1_mainContent").style.display ="block";                           
//                        break;
//                case "divthird" :
//                        document.getElementById("divThird").style.display ="block";
//                        document.getElementById("contmain").style.display ="block";
//                        document.getElementById("divbtn").style.display ="block";
//                        document.getElementById("ctl00_ContentPlaceHolder1_Div1").style.display ="block"; 
//                        document.getElementById("ctl00_ContentPlaceHolder1_leftDiv").style.display ="block"; 
//                        document.getElementById("ctl00_ContentPlaceHolder1_mainContent").style.display ="block";
//                        document.getElementById("divFirst").style.display ="none";
//                        document.getElementById("third").className="left_menu_active";
//                        document.getElementById("first").className="left_menu";
//                case "dvAttachDetails" :
//                        document.getElementById("contmain").style.display ="block";  
//                        document.getElementById("divbtn").style.display ="block";
//                        document.getElementById("ctl00_ContentPlaceHolder1_Div1").style.display ="block"; 
//                        document.getElementById("ctl00_ContentPlaceHolder1_leftDiv").style.display ="block"; 
//                        document.getElementById("ctl00_ContentPlaceHolder1_mainContent").style.display ="block";
//                        
//            }
        }
           

  
    </script>

</asp:Content>
