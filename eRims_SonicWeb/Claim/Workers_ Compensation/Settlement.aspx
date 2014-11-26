<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Settlement.aspx.cs"
    Inherits="WorkerCompensation_Settlement" Title="Risk Management Insurance System"
    Theme="Default"   %>
    
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb"  %>
    
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="../JavaScript/JFunctions.js"></script>
    
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"></script> 
     
     <link href="../App_Themes/Default/stylecal.css" type="text/css" rel="Stylesheet" />
     
    <asp:ScriptManager runat="server" ID="scManager">
    </asp:ScriptManager>

    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
        <asp:CustomValidator ID="cvErrorMsg" runat="server" ErrorMessage="" EnableClientScript="false"
            ValidationGroup="vsErrorGroup" Display="None"></asp:CustomValidator>
    </div>
    
    <script type="text/javascript">
    
    function MinMax(name)
    {
        if(name == "comment")
        {
            if(document.getElementById("ctl00_ContentPlaceHolder1_txtComments").style.height == "")
            {
                document.getElementById("ctl00_ContentPlaceHolder1_ibtnComment").src = "../Images/minus.jpg";
                document.getElementById("ctl00_ContentPlaceHolder1_txtComments").style.height = "200px";
                document.getElementById("pnlComment").style.display = "block";
            }
            else if(document.getElementById("ctl00_ContentPlaceHolder1_txtComments").style.height == "200px")
            {
                document.getElementById("ctl00_ContentPlaceHolder1_ibtnComment").src = "../Images/plus.jpg";
                document.getElementById("ctl00_ContentPlaceHolder1_txtComments").style.height="";
                document.getElementById("pnlComment").style.display = "none";
            }
        }      
        if(name == "attachment")
        {
            if(document.getElementById("ctl00_ContentPlaceHolder1_txtDescription").style.height == "")
            {
                document.getElementById("ctl00_ContentPlaceHolder1_ibtnAttach").src = "../Images/minus.jpg";
                document.getElementById("ctl00_ContentPlaceHolder1_txtDescription").style.height = "200px";
                document.getElementById("pnlAttach").style.display = "block";
            }
            else if(document.getElementById("ctl00_ContentPlaceHolder1_txtDescription").style.height == "200px")
            {
                 document.getElementById("ctl00_ContentPlaceHolder1_ibtnAttach").src = "../Images/plus.jpg";
                document.getElementById("ctl00_ContentPlaceHolder1_txtDescription").style.height="";
                document.getElementById("pnlAttach").style.display = "none";
            }
        }
        return false;
    }
    
    function ValAttach()
    {    
    //ctl00_ContentPlaceHolder1_lblLResignationDate
    //ctl00_ContentPlaceHolder1_rbtnResignation_0  
        document.getElementById("ctl00_ContentPlaceHolder1_rfvAttachType").enabled =true;
        document.getElementById("ctl00_ContentPlaceHolder1_rfvUpload").enabled =true;
        
        if(document.getElementById("ctl00_ContentPlaceHolder1_rbtnResignation_0").checked==true)
        {
            if(document.getElementById("ctl00_ContentPlaceHolder1_txtResignationDate").value == "")
            {               
                document.getElementById("ctl00_ContentPlaceHolder1_rfvResignationDate").enabled =true;
            }
            else
            {
                document.getElementById("ctl00_ContentPlaceHolder1_rfvResignationDate").enabled =false;
            }
        }
       if(document.getElementById("ctl00_ContentPlaceHolder1_rbtnResignation_1").checked==true)
        {      
            document.getElementById("ctl00_ContentPlaceHolder1_rfvResignationDate").enabled =false;
        }
        if(document.getElementById("ctl00_ContentPlaceHolder1_rbtnResignation_1").checked==false && document.getElementById("ctl00_ContentPlaceHolder1_rbtnResignation_0").checked==false)
        {  
            document.getElementById("ctl00_ContentPlaceHolder1_rfvResignationDate").enabled =false;
        }
        return true;
    }
    function ValSave()
    {            
        document.getElementById("ctl00_ContentPlaceHolder1_rfvAttachType").enabled =false;
        document.getElementById("ctl00_ContentPlaceHolder1_rfvUpload").enabled =false;
        if(document.getElementById("ctl00_ContentPlaceHolder1_rbtnResignation_0").checked==true)
        {
            if(document.getElementById("ctl00_ContentPlaceHolder1_txtResignationDate").value == "")
            {               
                document.getElementById("ctl00_ContentPlaceHolder1_rfvResignationDate").enabled =true;
            }
            else
            {
                document.getElementById("ctl00_ContentPlaceHolder1_rfvResignationDate").enabled =false;
            }
        }
        if(document.getElementById("ctl00_ContentPlaceHolder1_rbtnResignation_1").checked==true)
        {      
            document.getElementById("ctl00_ContentPlaceHolder1_rfvResignationDate").enabled =false;
        }
        if(document.getElementById("ctl00_ContentPlaceHolder1_rbtnResignation_1").checked==false && document.getElementById("ctl00_ContentPlaceHolder1_rbtnResignation_0").checked==false)
        { 
            document.getElementById("ctl00_ContentPlaceHolder1_rfvResignationDate").enabled =false;
        }
        return true;
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
    }
    function getthird()
    {
        clearfocus();
        document.getElementById("third").className="left_menu_active"; 
        document.getElementById("ctl00_ContentPlaceHolder1_divthird").style.display ="block";       
    }
     function getfourth()
    {
        clearfocus();
        document.getElementById("fourth").className="left_menu_active";
        document.getElementById("ctl00_ContentPlaceHolder1_divfourth").style.display ="block";
    }
    function getfifth()
    {
        clearfocus();
        document.getElementById("fifth").className="left_menu_active";
        document.getElementById("ctl00_ContentPlaceHolder1_divfifth").style.display ="block";        
    }
    function getsix()
    {
        clearfocus();
        document.getElementById("six").className="left_menu_active"; 
        document.getElementById("ctl00_ContentPlaceHolder1_divsix").style.display ="block";       
    }
     function getseven()
    {
        clearfocus();
        document.getElementById("seven").className="left_menu_active";
        document.getElementById("ctl00_ContentPlaceHolder1_divseven").style.display ="block";        
    }
    function geteight()
    {
        clearfocus();
        document.getElementById("eight").className="left_menu_active"; 
        document.getElementById("ctl00_ContentPlaceHolder1_diveight").style.display ="block";       
    }
    function clearfocus()
    {
        document.getElementById("first").className="left_menu";     
        document.getElementById("second").className="left_menu";  
        document.getElementById("third").className="left_menu";     
        document.getElementById("fourth").className="left_menu"; 
        document.getElementById("fifth").className="left_menu";     
        document.getElementById("six").className="left_menu"; 
        document.getElementById("seven").className="left_menu";     
        document.getElementById("eight").className="left_menu";    
        
        document.getElementById("ctl00_ContentPlaceHolder1_divfirst").style.display ="none"; 
        document.getElementById("ctl00_ContentPlaceHolder1_divsecond").style.display ="none";
        document.getElementById("ctl00_ContentPlaceHolder1_divthird").style.display ="none";   
        document.getElementById("ctl00_ContentPlaceHolder1_divfourth").style.display ="none"; 
        document.getElementById("ctl00_ContentPlaceHolder1_divfifth").style.display ="none";
        document.getElementById("ctl00_ContentPlaceHolder1_divsix").style.display ="none";            
        document.getElementById("ctl00_ContentPlaceHolder1_divseven").style.display ="none";
        document.getElementById("ctl00_ContentPlaceHolder1_diveight").style.display ="none";   
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

    <div id="contmain" runat="server" style="width: 100%;">
        <br />
        <div id="Div1" runat="server" style="width: 100%; text-align: center;">
            <table border="0" cellpadding="1" cellspacing="0" width="99%">
                <tr>
                    <td align="center" style="background-image: url('../images/normal_btn.jpg')" class="normal_tab"
                        valign="middle">
                        <a class="main_menu" href="WorkersCompensation.aspx">Worker's Compensation</a></td>
                    <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="WorkerCompensationReserve.aspx">Reserve Worksheets</a></td>
                    <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="Carrier.aspx">Carrier Data</a></td>
                    <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
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
                    <td align="center" class="active_tab" style="background-image: url('../images/active_btn.jpg')"
                        valign="middle">
                        Settlement</td>
                </tr>
            </table>
        </div>
        <div id="leftdiv" runat="server" style="width: 18%; height: 350px; float: left; border: solid 1px #7F7F7F;
            margin: 1px 1px 1px 4px;">
            <table border="0" cellpadding="0" cellspacing="0" width="95%">
                <tr>
                    <td style="width: 1%">
                        &nbsp;</td>
                    <td style="width: 99%">
                        <a class="left_menu_active" id="first" onclick="javascript:getfirst();" href="#">Worker's
                            Compensation</a>                        
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu" id="second" onclick="javascript:getsecond();" href="#">Status</a>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu" id="third" onclick="javascript:getthird();" href="#">Reserves and
                            Payments</a></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu" id="fourth" onclick="javascript:getfourth();" href="#">Settlement
                            Request</a></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu" id="fifth" onclick="javascript:getfifth();" href="#">Classification</a></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu" id="six" onclick="javascript:getsix();" href="#">Legal</a></td>
                </tr>
                <tr style="display:none;">
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu" id="seven" onclick="javascript:getseven();" href="#">Settlement
                            Approvals</a></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <a class="left_menu" id="eight" onclick="javascript:geteight();" href="#">Attachment</a></td>
                </tr>
            </table>
        </div>
        <div id="mainContent" runat="server" style="border: solid 1px #7F7F7F; width: 79%;
            float: right; margin: 1px 5px 1px 1px; padding: 5px 5px 5px 5px">
            <div id="divfirst" runat="server" style="width: 100%; display: block;">
                <table cellpadding="2" cellspacing="2" border="0" width="100%">
                    <tr>
                        <td colspan="6" class="ghc">
                            Worker's Compensation</td>
                    </tr>
                    <tr>
                        <td style="width: 25%;" align="left" class="lc">
                            <asp:Label runat="server" ID="lblLClaimNum">Claim Number</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic" colspan="4">
                            <asp:Label runat="server" ID="lblClaimNum"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 25%" align="left" class="lc">
                            <asp:Label runat="server" ID="lblLLName">Last Name</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td style="width: 25%" align="left" class="ic">
                            <asp:Label runat="server" ID="lblLName"></asp:Label>
                        </td>
                        <td style="width: 25%" align="left" class="lc">
                            <asp:Label runat="server" ID="lblLFName">First Name</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td style="width: 25%" align="left" class="ic">
                            <asp:Label runat="server" ID="lblFName"></asp:Label>
                        </td>                        
                    </tr>
                    <tr>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLDOB">Date Of Birth</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:Label runat="server" ID="lblDOB"></asp:Label>
                        </td>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLDOH">Date of Hire</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:Label runat="server" ID="lblDOH"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLSubside">Subside</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:Label runat="server" ID="lblSubid"></asp:Label>
                        </td>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLLocation">Location</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:Label runat="server" ID="lblLoc"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLDept">Department</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:Label runat="server" ID="lblDept"></asp:Label>
                        </td>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLJOB">JOB</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:Label runat="server" ID="lblJob"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLCoverageState">State of Coverage</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:Label runat="server" ID="lblCoverageState"></asp:Label>
                        </td>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLStateAccident">State of Accident</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:Label runat="server" ID="lblAcciState"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLDOI">DOI</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:Label runat="server" ID="lblDOI"></asp:Label>
                        </td>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLBodyPart">Body Part</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td  align="left" class="ic">
                            <asp:Label runat="server" ID="lblBodyPart"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td  align="left" class="lc">
                            <asp:Label runat="server" ID="lblLInjury">Injury</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td  align="left" class="ic" colspan="4">
                            <asp:Label runat="server" ID="lblInjury"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td  align="left" class="lc">
                            <asp:Label runat="server" ID="lblLDesc">Description</asp:Label>
                        </td>
                        <td  align="Center" class="lc">
                            :
                        </td>
                        <td  align="left" class="ic" colspan="4">
                            <asp:Label runat="server" ID="lblDescription"></asp:Label>
                        </td>
                    </tr>                   
                </table>
            </div>
            <div id="divsecond" runat="server" style="width: 100%; display: none;">
                <table cellpadding="2" cellspacing="2" border="0" width="100%">
                    <tr>
                        <td colspan="6" class="ghc">
                            Status</td>
                    </tr>
                    <tr>
                        <td style="width: 25%" align="left" class="lc">
                            <asp:Label runat="server" ID="lblLTratingPhysician">Treating Physician</asp:Label>
                        </td>
                        <td  align="Center" class="lc">
                            :
                        </td>
                        <td style="width: 25%" align="left" class="ic">
                            <asp:Label runat="server" ID="lblTreatPhysician"></asp:Label>
                        </td>
                        <td style="width: 25%" align="left" class="lc">
                            <asp:Label runat="server" ID="lblLDiognosis">Diagnosis</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td style="width: 25%" align="left" class="ic">
                            <asp:Label runat="server" ID="lblDiagnosis"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLLastVisitDate">Last Office Visit Date</asp:Label>
                        </td>
                        <td  align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:Label runat="server" ID="lblLastVisit"></asp:Label>
                        </td>
                        <td  align="left" class="lc">
                            <asp:Label runat="server" ID="lblLNextVisit">Next Scheduled Visit</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:Label runat="server" ID="lblNextVisit"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLReferral">Referral</asp:Label>
                        </td>
                        <td  align="Center" class="lc">
                            :
                        </td>
                        <td  align="left" class="ic">
                            <asp:Label runat="server" ID="lblReferral"></asp:Label>
                        </td>
                        <td  align="left" class="lc">
                            <asp:Label runat="server" ID="lblLNewPhysician">New Treating Physician</asp:Label>
                        </td>
                        <td  align="Center" class="lc">
                            :
                        </td>
                        <td  align="left" class="ic">
                            <asp:Label runat="server" ID="lblNewPhysician"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLPhysicalTherapy">Physical Therapy</asp:Label>
                        </td>
                        <td  align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:Label runat="server" ID="lblPhyTheraphy"></asp:Label>
                        </td>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLSurgery">Surgery</asp:Label>
                        </td>
                        <td  align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:Label runat="server" ID="lblSurgery"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLOffWork">Off-Work</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:Label runat="server" ID="lblOffWork"></asp:Label>
                        </td>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLEstimateRTW">Estimated RTW</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:Label runat="server" ID="lblRTW"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLRetWorkFullDuty">Return to Work Full-Duty</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:Label runat="server" ID="lblFullDuty"></asp:Label>
                        </td>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLRTWDate">RTW Date</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:Label runat="server" ID="lblRTWDate"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLRetWorkRestDuty">Return to Work Restricted Duty</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic" colspan="4">
                            <asp:Label runat="server" ID="lblRestrictedDuty"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLTempFrom">Temporary From</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:Label runat="server" ID="lblTempFrom"></asp:Label>
                        </td>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLTempTo">To</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:Label runat="server" ID="lblTempTo"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLExplain">Explain</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic" colspan="4">
                            <asp:Label runat="server" ID="lblExplain"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLPermanent">Permanent</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic" colspan="4">
                            <asp:Label runat="server" ID="lblPermanent"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLEstimatedMMI">Estimated MMI</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:Label runat="server" ID="lblEstiMMI"></asp:Label>
                        </td>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLMMI">MMI</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:Label runat="server" ID="lblMMI"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLEstimateImpaire">Estimated Impairment</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td  align="left" class="ic">
                            <asp:Label runat="server" ID="lblEstImpair"></asp:Label>
                        </td>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLActualImpaire">Actual Impairment</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:Label runat="server" ID="lblActEmpair"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLPhyPanelReq">Physicians Panel Requested</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td  align="left" class="ic" colspan="4">
                            <asp:Label runat="server" ID="lblPanelReq"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="divthird" runat="server" style="width: 100%; display: none;">
                <table cellpadding="2" cellspacing="2" border="0" width="100%">
                    <tr>
                        <td class="ghc" align="left" >
                            Reserves and Payments
                        </td>
                    </tr>
                </table>
                <table cellpadding="2" cellspacing="2" border="0" width="75%">                    
                    <tr>
                        <td class="lc" align="left">
                            &nbsp;</td>
                        <td class="lc" align="right">
                            <b>Property Damage $</b></td>
                        <td class="lc" align="right">
                            <b>Bodily Injury $</b></td>
                        <td class="lc" align="right">
                            <b>Expenses $</b></td>
                        <td class="lc" align="right">
                            <b>Total $</b></td>
                    </tr>
                    <tr>
                        <td class="lc" align="left">
                            <b>Reserve</b></td>
                        <td class="lc" align="right">
                            <asp:Label runat="server" ID="lblIndemReserve"></asp:Label></td>
                        <td class="lc" align="right">
                            <asp:Label runat="server" ID="lblMedicalReserve"></asp:Label></td>
                        <td class="lc" align="right">
                            <asp:Label runat="server" ID="lblExpensesReserve"></asp:Label></td>
                        <td class="lc" align="right">
                            <asp:Label runat="server" ID="lblTotalReserve"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="lc" align="left">
                            <b>Paid</b></td>
                        <td class="lc" align="right">
                            <asp:Label runat="server" ID="lblIndemPaid"></asp:Label></td>
                        <td class="lc" align="right">
                            <asp:Label runat="server" ID="lblMedicalPaid"></asp:Label></td>
                        <td class="lc" align="right">
                            <asp:Label runat="server" ID="lblExpensesPaid"></asp:Label></td>
                        <td class="lc" align="right">
                            <asp:Label runat="server" ID="lblTotalPaid"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="lc" align="left">
                            <b>OutStanding</b></td>
                        <td class="lc" align="right">
                            <asp:Label runat="server" ID="lblIndemOS"></asp:Label></td>
                        <td class="lc" align="right">
                            <asp:Label runat="server" ID="lblMedicalOS"></asp:Label></td>
                        <td class="lc" align="right">
                            <asp:Label runat="server" ID="lblExpensesOS"></asp:Label></td>
                        <td class="lc" align="right">
                            <asp:Label runat="server" ID="lblTotalOS"></asp:Label></td>
                    </tr>
                </table>
            </div>
            <asp:UpdatePanel ID="pnlBankDetail" runat="server">
                <contenttemplate>
            <div style="width:100%;">              
            <div id="divfourth" runat="server" style="width: 100%; display: none;">
                <table cellpadding="2" cellspacing="2" border="0" width="100%">
                    <tr>
                        <td class="ghc" align="left" colspan="6">
                            Settlement Request
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 25%" align="left" class="lc">
                            <asp:Label runat="server" ID="lblLSettlementMethod">Settlement Method</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td style="width: 25%;" align="left" class="ic" colspan="4">
                            <asp:Label runat="server" ID="lblSettleMethod"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 25%" align="left" class="lc">
                            <asp:Label runat="server" ID="lblLMethodOfSettlement">Method of Settlement</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td style="width: 25%" align="left" class="ic">
                            <asp:Label runat="server" ID="lblMethodOfSettle"></asp:Label>
                        </td>
                        <td style="width: 25%" align="left" class="lc">
                            <asp:Label runat="server" ID="lblStatusOnly">Status Only / Action Plan</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td style="width: 25%" align="left" class="ic">
                            <asp:RadioButtonList ID="rbtnActionPaln" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rbtnActionPaln_SelectedIndexChanged">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem Selected="True">No</asp:ListItem>
                            </asp:RadioButtonList>   
                            <asp:Label runat="server" ID="lblHStatusOnly" Visible="false"></asp:Label>                         
                        </td>
                    </tr>
                </table>
                <table cellpadding="2" cellspacing="2" border="0" width="100%">
                    <tr>
                        <td class="ghc" align="left" colspan="6">
                            Settlement Approvals
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 25%" align="left" class="lc">
                            <asp:Label runat="server" ID="lblLReqAmt">Requested Amount</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td style="width: 25%" align="left" class="ic">
                            <span runat="server" id="Span3">$</span><asp:TextBox runat="server" ID="txtReqAmt" onKeyPress="return(currencyFormat(this,',','.',event))" MaxLength="11" SkinID="txtAmt"></asp:TextBox>
                            <asp:Label runat="server" ID="lblHReqAmt" Visible="false"></asp:Label>
                        </td>
                        <td style="width: 25%" align="left" class="lc">
                            <asp:Label runat="server" ID="lblLPotentialTotExp">Potential Total Exposure</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td style="width: 25%" align="left" class="ic">
                            <span runat="server" id="Span1">$</span><asp:TextBox runat="server" ID="txtPotential" onKeyPress="return(currencyFormat(this,',','.',event))" MaxLength="11" SkinID="txtAmt"></asp:TextBox>
                            <asp:Label runat="server" ID="lblHPotential" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLSettled">Settled</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:RadioButtonList ID="rbtnSettled" runat="server" >
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem Selected="True">No</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:Label runat="server" ID="lblHSettled" Visible="false"></asp:Label>
                        </td>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLAmt" >Amount</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <span runat="server" id="Span2">$</span><asp:TextBox runat="server" ID="txtAmt" onKeyPress="return(currencyFormat(this,',','.',event))" MaxLength="11" SkinID="txtAmt"></asp:TextBox>
                            <asp:Label runat="server" ID="lblHAmt" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" align="left" class="ghc">
                            Approvals</td>
                    </tr>
                    <tr>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLLocRepresent">Location Representative</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic" valign="top">
                            <asp:TextBox runat="server" ID="txtLocRepresent" ValidationGroup="vsErrorGroup"></asp:TextBox>                           
                            <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtLocRepresent', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                align="absmiddle" runat="server" id="imgLocRepresent" /><br />
                            <cc1:MaskedEditExtender ID="mskLocRepresen" runat="server" AcceptNegative="Left"
                                DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtLocRepresent"
                                CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                            </cc1:MaskedEditExtender>
                            <cc1:MaskedEditValidator ID="mskValLocRepresent" runat="server" ControlExtender="mskLocRepresen"
                                ControlToValidate="txtLocRepresent" Display="dynamic" IsValidEmpty="True" MaximumValue=""
                                EmptyValueMessage="" InvalidValueMessage="Date is invalid" MaximumValueMessage=""
                                MinimumValueMessage="" TooltipMessage="" MinimumValue="">
                            </cc1:MaskedEditValidator>
                            <asp:RegularExpressionValidator ID="revLocRepresent" runat="server" ControlToValidate="txtLocRepresent"
                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                ErrorMessage="[Settlement Request]/Location Representative Is Not Valid Date" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                        
                            <asp:Label runat="server" ID="lblHLocRepresent" Visible="false"></asp:Label>
                        </td>
                        <td align="left" class="lc" >
                            <asp:Label runat="server" ID="lblLClaimManager">Claims Manager</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:TextBox runat="server" ID="txtClaimManager" ValidationGroup="vsErrorGroup"></asp:TextBox>
                             <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtClaimManager', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                align="absmiddle" runat="server" id="imgClaimManager" /><br />
                            <cc1:MaskedEditExtender ID="mskClaimManager" runat="server" AcceptNegative="Left"
                                DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtClaimManager"
                                CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                            </cc1:MaskedEditExtender>
                            <cc1:MaskedEditValidator ID="mskValClaimManager" runat="server" ControlExtender="mskClaimManager"
                                ControlToValidate="txtClaimManager" Display="dynamic" IsValidEmpty="True" MaximumValue=""
                                EmptyValueMessage="" InvalidValueMessage="Date is invalid" MaximumValueMessage=""
                                MinimumValueMessage="" TooltipMessage="" MinimumValue="">
                            </cc1:MaskedEditValidator>
                            <asp:RegularExpressionValidator ID="revClaimManager" runat="server" ControlToValidate="txtClaimManager"
                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                ErrorMessage="[Settlement Request]/Claims Manager Is Not Valid Date" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                        
                            <asp:Label runat="server" ID="lblHClaimManager" Visible="false" valign="top"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLRiskMgr">Risk Manager</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:TextBox runat="server" ID="txtRiskManager" ValidationGroup="vsErrorGroup"></asp:TextBox>
                             <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtRiskManager', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                align="absmiddle" runat="server" id="imgRiskManager" /><br />
                            <cc1:MaskedEditExtender ID="mskRiskManager" runat="server" AcceptNegative="Left"
                                DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtRiskManager"
                                CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                            </cc1:MaskedEditExtender>
                            <cc1:MaskedEditValidator ID="mskValRiskManager" runat="server" ControlExtender="mskRiskManager"
                                ControlToValidate="txtRiskManager" Display="dynamic" IsValidEmpty="True" MaximumValue=""
                                EmptyValueMessage="" InvalidValueMessage="Date is invalid" MaximumValueMessage=""
                                MinimumValueMessage="" TooltipMessage="" MinimumValue="">
                            </cc1:MaskedEditValidator>
                            <asp:RegularExpressionValidator ID="revRiskManager" runat="server" ControlToValidate="txtRiskManager"
                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                ErrorMessage="[Settlement Request]/Risk Manager is Not Valid Date" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                        
                            <asp:Label runat="server" ID="lblHRiskManager" Visible="false" ></asp:Label>
                        </td>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLTreasury">Treasury</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:TextBox runat="server" ID="txtTreasury" ></asp:TextBox>
                             <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtTreasury', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                align="absmiddle" runat="server" id="imgTreasury" /><br />
                            <cc1:MaskedEditExtender ID="mskTreasury" runat="server" AcceptNegative="Left"
                                DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtTreasury"
                                CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                            </cc1:MaskedEditExtender>
                            <cc1:MaskedEditValidator ID="mskValTreasury" runat="server" ControlExtender="mskTreasury"
                                ControlToValidate="txtTreasury" Display="dynamic" IsValidEmpty="True" MaximumValue=""
                                EmptyValueMessage="" InvalidValueMessage="Date is invalid" MaximumValueMessage=""
                                MinimumValueMessage="" TooltipMessage="" MinimumValue="">
                            </cc1:MaskedEditValidator>
                            <asp:RegularExpressionValidator ID="revTreasury" runat="server" ControlToValidate="txtTreasury"
                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                ErrorMessage="[Settlement Request]/Treasury Is Not Valid Date" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                        
                            <asp:Label runat="server" ID="lblHTreasury" Visible="false" valign="top"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLCFO">CFO</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic" colspan="4" valign="middle">
                            <asp:TextBox runat="server" ID="txtCFO" ></asp:TextBox>
                             <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtCFO', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                align="absmiddle" runat="server" id="imgCFO"/><br />
                            <cc1:MaskedEditExtender ID="mskCFO" runat="server" AcceptNegative="Left"
                                DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtCFO"
                                CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                            </cc1:MaskedEditExtender>
                            <cc1:MaskedEditValidator ID="mskValCFO" runat="server" ControlExtender="mskCFO"
                                ControlToValidate="txtCFO" Display="dynamic" IsValidEmpty="True" MaximumValue=""
                                EmptyValueMessage="" InvalidValueMessage="Date is invalid" MaximumValueMessage=""
                                MinimumValueMessage="" TooltipMessage="" MinimumValue="">
                            </cc1:MaskedEditValidator>
                            <asp:RegularExpressionValidator ID="revCFO" runat="server" ControlToValidate="txtCFO"
                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                ErrorMessage="[Settlement Request]/CFO Is Not Valid Date" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                        
                            <asp:Label runat="server" ID="lblHCFO" Visible="false" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="lc" valign="top">
                            <asp:Label runat="server" ID="lblLComments">Comments</asp:Label>
                        </td>
                        <td align="Center" class="lc" valign="top">
                            :
                        </td>
                        <td align="left" class="ic" colspan="4" valign="top">
                            <asp:ImageButton ID="ibtnComment" ImageUrl="~/Images/minus.jpg" runat="server" OnClientClick="javascript:return MinMax('comment');" />
                                <div id="pnlComment" style="display:block;">
                                <asp:TextBox runat="server" ID="txtComments" Height="200px" Width="93%" TextMode="MultiLine" onKeyDown="javascript:return disableDeleteBackSpace();"></asp:TextBox>                                
                            </div>
                            <asp:Label runat="server" ID="lblHComments" Visible="false"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="divfifth" runat="server" style="width: 100%; display: none;">
                <table cellpadding="2" cellspacing="2" border="0" width="100%">
                    <tr>
                        <td class="ghc" align="left" colspan="6">
                            Classification
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 25%" align="left" class="lc">
                            <asp:Label runat="server" ID="lblLCompensationDenied">Compensation  Originally Denied</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td style="width: 25%" align="left" class="ic">
                            <asp:RadioButtonList ID="rbtnCompensatiton" runat="server">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem Selected="true">No</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:Label runat="server" ID="lblHCompensationDenied" Visible="false"></asp:Label>
                        </td>
                        <td style="width: 25%" align="left" class="lc">
                            <asp:Label runat="server" ID="lblLReimburseCost">L/S Reimbursement of Cost</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td style="width: 25%" align="left" class="ic">
                            <asp:RadioButtonList ID="rbtnReimbursement"  runat="server">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem Selected="true">No</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:Label runat="server" ID="lblHReimburseCost" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblWaiveSubrogation">Waive Subrogation</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:RadioButtonList ID="rbtnWaive" runat="server" >
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem Selected="true">No</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:Label runat="server" ID="lblHWaive" Visible="false"></asp:Label>
                        </td>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLCloseMedical">Close Medicals</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td  align="left" class="ic">
                            <asp:RadioButtonList ID="rbtnCloseMedical" runat="server">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem Selected="true">No</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:Label runat="server" ID="lblHCloseMedical" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLConfidentClause">Confidentiality Clause</asp:Label>
                        </td>
                        <td  align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:RadioButtonList ID="rbtnConfident" runat="server">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem Selected="true">No</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:Label runat="server" ID="lblHConfident" Visible="false"></asp:Label>
                        </td>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLOtherMedicals">Other Medicals</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:RadioButtonList ID="rbtnOtherMedi" runat="server">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem Selected="true">No</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:Label runat="server" ID="lblHOtherMedi" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLParmenantTot">Settlement of Permanent Total</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:RadioButtonList ID="rbtnSettlement" runat="server" >
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem Selected="true">No</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:Label runat="server" ID="lblHSettlement" Visible="false"></asp:Label>
                        </td>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLResignation">Resignation</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:RadioButtonList ID="rbtnResignation" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rbtnResignation_SelectedIndexChanged" >
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem Selected="true">No</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:Label runat="server" ID="lblHResignation" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLOther">Other</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:RadioButtonList ID="rbtnOther" runat="server">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem Selected="true">No</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:Label runat="server" ID="lblHOther" Visible="false"></asp:Label>
                        </td>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLResignationDate">Resignation Date</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:TextBox runat="server" ID="txtResignationDate" ValidationGroup="vsErrorGroup"></asp:TextBox>&nbsp;
                            <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtResignationDate', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                align="absmiddle" runat="server" id="imgResignationDate" /><br />
                            <cc1:MaskedEditExtender ID="mskResignationDate" runat="server" AcceptNegative="Left"
                                DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtResignationDate"
                                CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                            </cc1:MaskedEditExtender>
                            <cc1:MaskedEditValidator ID="mskValResignationDate" runat="server" ControlExtender="mskResignationDate"
                                ControlToValidate="txtResignationDate" Display="dynamic" IsValidEmpty="True" MaximumValue=""
                                EmptyValueMessage="" InvalidValueMessage="Date is invalid" MaximumValueMessage=""
                                MinimumValueMessage="" TooltipMessage="" MinimumValue="">
                            </cc1:MaskedEditValidator>
                            <asp:RegularExpressionValidator ID="revIDONoteEntry" runat="server" ControlToValidate="txtResignationDate"
                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                ErrorMessage="[Resignation Date]/ is Not Valid Date" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="rfvResignationDate" runat="server" ControlToValidate="txtResignationDate" InitialValue="" 
                            Display="None" ErrorMessage="Please Enter [Classification]/Resignation Date" ValidationGroup="vsErrorGroup">                                                                        
                            </asp:RequiredFieldValidator>
                            <asp:Label runat="server" ID="lblHResignationDate" Visible="false"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="divsix" runat="server" style="width: 100%; display: none;">
                <table cellpadding="2" cellspacing="2" border="0" width="100%">
                    <tr>
                        <td class="ghc" align="left" colspan="6">
                            Legal
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 25%" align="left" class="lc">
                            <asp:Label runat="server" ID="lblLDefenseName">Defense Council's Name</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td style="width: 25%" align="left" class="ic">
                            <asp:Label runat="server" ID="lblDefenseName"></asp:Label>
                        </td>
                        <td style="width: 25%" align="left" class="lc">
                            <asp:Label runat="server" ID="lblLDefensePhone">Phone</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td style="width: 25%" align="left" class="ic">
                            <asp:Label runat="server" ID="lblDefensePhone"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLClaimantAttorney">Claimant's Attorney</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:Label runat="server" ID="lblClaimant"></asp:Label>
                        </td>
                        <td align="left" class="lc">
                            <asp:Label runat="server" ID="lblLAttorneyPhone">Phone</asp:Label>
                        </td>
                        <td align="Center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:Label runat="server" ID="lblClaimantPhone"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="divseven" runat="server" style="width: 100%; display: none;">                
            </div>
            </div>
            </contenttemplate>
            </asp:UpdatePanel>  
            <div id="diveight" runat="server" style="width: 100%; display: none;">
                <div id="divAttachment" runat="server" style="width:100%;">
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
                    <tr style="display:none;">
                        <td class="lc" style="width: 25%;" valign="top">
                            Attachment Type
                        </td>
                        <td align="center" valign="top">
                            :
                        </td>
                        <td class="ic" colspan="4" valign="top">
                            <asp:DropDownList runat="server" SkinID="dropGen" ID="ddlAttachType">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvAttachType" ControlToValidate="ddlAttachType"
                            runat="server" InitialValue="--Select Attachment Type--" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select the Attachment Type."
                            Display="none"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc" valign="top" style="width: 25%;">
                            Attachment Description
                        </td>
                        <td align="center" valign="top" class="lc" style="width:5%;">
                            :
                        </td>
                        <td colspan="4" class="ic" valign="top">
                            <asp:ImageButton ID="ibtnAttach" ImageUrl="~/Images/minus.jpg" runat="server" OnClientClick="javascript:return MinMax('attachment');" />
                            <div id="pnlAttach" style="display:block;">
                                <asp:TextBox ID="txtDescription" Height="200px" SkinID="txtCarrier" runat="server" MaxLength="4000" TextMode="MultiLine" Width="93%"></asp:TextBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc" valign="top">
                            Select File
                        </td>
                        <td class="lc" align="center" valign="top">
                            :
                        </td>
                        <td colspan="4" class="ic" valign="top">
                            <asp:FileUpload runat="server" ID="uplCommon" />
                            <asp:RequiredFieldValidator ID="rfvUpload" runat="server" ControlToValidate="uplCommon" InitialValue="" 
                            Display="none" Text="*" ErrorMessage="Please Select [Attachment]/File To Upload" ValidationGroup="vsErrorGroup">                                                                        
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="ic">
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
                            <asp:Button ID="btnAddAttachment" runat="server" Text="Add Attachment" OnClientClick="javascript:ValAttach();" ValidationGroup="vsErrorGroup"
                            OnClick="btnAddAttachment_Click" />
                        </td>
                    </tr>
                </table>
                </div>
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
                                    <asp:BoundField DataField="Attachment_Type" HeaderText="Attachment Type" Visible="false">
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
                                    Currently there is no Attachment.                                    
                                </EmptyDataTemplate>
                                <PagerSettings Visible="False" />
                                <PagerSettings Visible="False" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnRemove" runat="server" Text="Remove" OnClick="btnRemove_Click" />
                            <asp:Button ID="btnMail" runat="server" Text="Mail" OnClientClick="javascript:return OpenWMail('gvAttachmentDetails','Worker_Comp_Settlement');" />
                        </td>
                    </tr>
                </table>
                <asp:HiddenField runat="server" ID="hdnDisplay" />
            </div>
        </div>
    </div>
    <div id="divbtn" runat="server">
        <table style="width: 100%;">
            <tr>
                <td align="center" class="ic">
                    <asp:Button runat="server" ID="btnSave" EnableTheming="false" SkinID="btnGen" Text="Save & View"
                        OnClick="btnSave_Click"  OnClientClick="javascript:ValSave();" ValidationGroup="vsErrorGroup"/>
                    <asp:Button runat="server" ID="btnBack" EnableTheming="false" SkinID="btnGen" Text="Back"
                        OnClick="btnBack_Click" Visible="false" />
                    <asp:Button runat="server" ID="btnPDF" EnableTheming="false" SkinID="btnGen" Text="Generate PDF" 
                        OnClick="btnPDF_Click" />
                </td>
            </tr>
        </table>
    </div>
    <table width="80%">
        <tr>
            <td>
            &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                <div style="width:500px;display:block;">
                <table width="50%">
                    <tr>
                        <td>
                            <rsweb:ReportViewer ID="rptViewer" runat="server" Width="100%"  ShowFindControls="false" ShowExportControls="true"  
                                DocumentMapCollapsed="True" BackColor="White" SizeToReportContent="true" ShowBackButton="True" ShowToolBar="true"
                                ShowParameterPrompts="False" ShowPromptAreaButton="False" AsyncRendering="False"
                                EnableTheming="false" 
                                Height="100%" >
                            </rsweb:ReportViewer>
                            
                        </td>
                    </tr>
                </table>
                </div>
            </td>
        </tr>
    </table>
    <script type="text/javascript">      
       
        if(document.getElementById("ctl00_ContentPlaceHolder1_hdnDisplay").value != '')
        {
            geteight();
        }
    </script>
</asp:Content>
