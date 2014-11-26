<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Settlement.aspx.cs"
 Inherits="Liability_Settlement" Title="Risk Management Insurance System"
    Theme="Default" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
    function changefocus(control)
    {
        clearfocus();        
        document.getElementById(control).className="left_menu_active";       
        var divname = 'div' + control;
        document.getElementById(divname).style.display ="block";  
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
        
        document.getElementById("divfirst").style.display ="none"; 
        document.getElementById("divsecond").style.display ="none";
        document.getElementById("divthird").style.display ="none";   
        document.getElementById("divfourth").style.display ="none"; 
        document.getElementById("divfifth").style.display ="none";
        document.getElementById("divsix").style.display ="none";   
        document.getElementById("divfirst").style.display ="none"; 
        document.getElementById("divseven").style.display ="none";
        document.getElementById("diveight").style.display ="none";   
    }
    function displayDetail()
    {
        document.getElementById("divfirst").style.display ="none"; 
        document.getElementById("divsecond").style.display ="none";  
        document.getElementById("divthird").style.display ="block";
        return false;
    }
</script>
 <br />
<div id="contmain" runat="server" style="width: 100%;">
<div id="Div1" runat="server" style="width: 100%; text-align: center">           
            <table border="0" cellpadding="1" cellspacing="0" width="99%">
                <tr>
                    <td align="center" style="background-image: url('../images/normal_btn.jpg')" class="normal_tab"
                        valign="middle">
                        <a class="main_menu" href="LiabilityClaim.aspx">Liability Claim</a></td>
                    <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
                        valign="middle">
                        <a class="main_menu" href="ReserveWorksheetHistoryGrid.aspx">Reserve Worksheet</a></td>
                    <td align="center" class="normal_tab" style="background-image: url('../images/normal_btn.jpg')"
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
                    <td align="center" class="active_tab" style="background-image: url('../images/active_btn.jpg')"
                        valign="middle">
                        Settlement</td>
                </tr>
            </table>
</div>    
<div id="leftDiv" runat="server" style="width: 20%; height: 350px; float: left;  border: solid 1px">
    <table border="0" cellpadding="0" cellspacing="0" width="90%">
        <tr>
            <td width="15%" style="height: 19px">&nbsp;</td>
            <td width="85%" style="height: 19px"><a class="left_menu_active" id="first" onclick="changefocus(this.id);" href="#">Worker's Compensation</a></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td><a class="left_menu" id="second" onclick="changefocus(this.id);" href="#">Status</a></td>
        </tr> 
        <tr>
            <td width="15%">&nbsp;</td>
            <td width="85%"><a class="left_menu" id="third" onclick="changefocus(this.id);" href="#">Reserves and Payments</a></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td><a class="left_menu" id="fourth" onclick="changefocus(this.id);" href="#">Settlement Request</a></td>
        </tr> 
        <tr>
            <td width="15%">&nbsp;</td>
            <td width="85%"><a class="left_menu" id="fifth" onclick="changefocus(this.id);" href="#">Classification</a></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td><a class="left_menu" id="six" onclick="changefocus(this.id);" href="#">Legal</a></td>
        </tr>    
        <tr>
            <td width="15%">&nbsp;</td>
            <td width="85%"><a class="left_menu" id="seven" onclick="changefocus(this.id);" href="#">Settlement Approvals</a></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td><a class="left_menu" id="eight" onclick="changefocus(this.id);" href="#">Attachment</a></td>
        </tr>             
    </table>
</div>          
<div id="rightDiv" runat="server" style="width: 79%; float: right;">
<table cellpadding="5" cellspacing="0" border="0" width="100%">
    <tr>
        <td>
            <div id="divfirst" style="width: 100%; display:block;">        
            <table cellpadding="2" cellspacing="0" border="0" width="100%">               
                <tr>
                    <td colspan="6" class="ghc">
                            Worker's Compensation</td>
                </tr>
                <tr>
                    <td  style="width:20%;" align="left" class="lc">
                        Claim #
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic" colspan="4">
                        <asp:Label runat="server" ID="lblClaimNum">07-01047-01</asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td style="width:20%" align="left" class="lc">
                        First Name
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label runat="server" ID="lblFName">First Name</asp:Label>
                    </td>
                    <td style="width:20%" align="left" class="lc">
                        Last Name
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label runat="server" ID="lblLName">Last Name</asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td style="width:20%" align="left" class="lc">
                        DOB
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label runat="server" ID="lblDOB">12/1/1990</asp:Label>
                    </td>
                    <td style="width:20%" align="left" class="lc">
                        DOH
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label runat="server" ID="lblDOH">12/1/2007</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width:20%" align="left" class="lc">
                        Subsid
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label runat="server" ID="lblSubid">US Pipe</asp:Label>
                    </td>
                    <td style="width:20%" align="left" class="lc">
                        Location
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label runat="server" ID="lblLoc">US Pipe</asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td style="width:20%" align="left" class="lc">
                        Dept
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label runat="server" ID="lblDept"></asp:Label>
                    </td>
                    <td style="width:20%" align="left" class="lc">
                        JOB
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label runat="server" ID="lblJob">Plumbing/Supply Dealer</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width:20%" align="left" class="lc">
                        State of Coverage
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label runat="server" ID="lblCoverageState"></asp:Label>
                    </td>
                    <td style="width:20%" align="left" class="lc">
                        State of Accident
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label runat="server" ID="lblAcciState">Alabama</asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td style="width:20%" align="left" class="lc">
                        DOI
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label runat="server" ID="lblDOI">1/4/2007</asp:Label>
                    </td>
                    <td style="width:20%" align="left" class="lc">
                        Body Part
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label runat="server" ID="lblBodyPart">Lower Leg</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width:20%" align="left" class="lc">
                        Injury
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic" colspan="4">
                        <asp:Label runat="server" ID="lblInjury"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width:20%" align="left" class="lc" >
                        Description
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%;height:50px;" align="left" class="ic" colspan="4">
                        <asp:Label runat="server" ID="lblDescription">Description </asp:Label>
                    </td>
                </tr>
                <tr><td colspan="6">&nbsp;</td></tr>
            </table>
            </div>
        </td>
    </tr>
    <tr>
        <td> 
            <div id="divsecond" style="width: 100%; display:none;">       
            <table cellpadding="2" cellspacing="0" border="0" width="100%">
                <tr>
                    <td colspan="6" class="ghc">
                        Status</td>
                </tr>
                <tr>
                    <td style="width:20%" align="left" class="lc">
                        Treating Physician
                    </td>
                    <td style="width:18%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label runat="server" ID="lblTreatPhysician"></asp:Label>
                    </td>
                    <td style="width:20%" align="left" class="lc">
                        Diagnosis
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label runat="server" ID="lblDiagnosis"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td style="width:20%" align="left" class="lc">
                        Last Office Visit Date
                    </td>
                    <td style="width:18%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label runat="server" ID="lblLastVisit"></asp:Label>
                    </td>
                    <td style="width:20%" align="left" class="lc">
                        Next Scheduled Visit
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label runat="server" ID="lblNextVisit"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td style="width:20%" align="left" class="lc">
                        Referral
                    </td>
                    <td style="width:18%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label runat="server" ID="lblReferral"></asp:Label>
                    </td>
                    <td style="width:20%" align="left" class="lc">
                        New Treating Physician
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label runat="server" ID="lblNewPhysician"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width:20%" align="left" class="lc">
                        Physical Therapy
                    </td>
                    <td style="width:18%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label runat="server" ID="lblPhyTheraphy"></asp:Label>
                    </td>
                    <td style="width:20%" align="left" class="lc">
                        Surgery
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label runat="server" ID="lblSurgery"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td style="width:20%" align="left" class="lc">
                        Off-Work
                    </td>
                    <td style="width:18%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label runat="server" ID="lblOffWork"></asp:Label>
                    </td>
                    <td style="width:20%" align="left" class="lc">
                          	Estimated RTW
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label runat="server" ID="lblRTW"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width:20%" align="left" class="lc">
                        Return to Work Full-Duty
                    </td>
                    <td style="width:18%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label runat="server" ID="lblFullDuty"></asp:Label>
                    </td>
                    <td style="width:20%" align="left" class="lc">
                        RTW Date
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label runat="server" ID="lblRTWDate">1/8/2008</asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td style="width:20%" align="left" class="lc">
                        Return to Work Restricted Duty
                    </td>
                    <td style="width:18%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic" colspan="4">
                        <asp:Label runat="server" ID="lblRestrictedDuty"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width:20%" align="left" class="lc">
                        Temporary From
                    </td>
                    <td style="width:18%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label runat="server" ID="lblTempFrom">1/10/2008</asp:Label>
                    </td>
                     <td style="width:20%" align="left" class="lc">
                        To
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label runat="server" ID="lblTempTo"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width:20%" align="left" class="lc">
                        Explain
                    </td>
                    <td style="width:18%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%;height:70px;" align="left" class="ic" colspan="4" >
                        <asp:Label runat="server" ID="lblExplain"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width:20%" align="left" class="lc">
                       Permanent
                    </td>
                    <td style="width:18%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%;height:70px;" align="left" class="ic" colspan="4" >
                        <asp:Label runat="server" ID="lblPermanent"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td style="width:20%" align="left" class="lc">
                        Estimated MMI
                    </td>
                    <td style="width:18%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label runat="server" ID="lblEstiMMI"></asp:Label>
                    </td>
                     <td style="width:20%" align="left" class="lc">
                        MMI
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label runat="server" ID="lblMMI">1/10/2008</asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td style="width:20%" align="left" class="lc">
                        Estimated Impairment
                    </td>
                    <td style="width:18%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label runat="server" ID="lblEstImpair">5</asp:Label>
                    </td>
                     <td style="width:20%" align="left" class="lc">
                        Actual Impairment
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label runat="server" ID="lblActEmpair"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width:20%" align="left" class="lc">
                       Physicians Panel Requested
                    </td>
                    <td style="width:18%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic" colspan="4">
                        <asp:Label runat="server" ID="lblPanelReq"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width:20%" align="left" class="lc">
                       New Treating Physician
                    </td>
                    <td style="width:18%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic" colspan="4">
                        <asp:Label runat="server" ID="lblNewTreatPhysician"></asp:Label>
                    </td>
                </tr>
                <tr><td colspan="6">&nbsp;</td></tr>
            </table>
            </div>
        </td>
    </tr>
    <tr>
        <td>
            <div id="divthird" style="width: 100%; display:none;">
            <table cellpadding="2" cellspacing="0" border="1" width="100%">
               <tr>
                    <td class="ghc" align="left" colspan="5">
                        Reserves and Payments
                    </td>
                </tr>
                <tr>
                    <td class="lc" align="right">&nbsp;</td>
                    <td class="lc" align="right">Indemnity</td>
                    <td class="lc" align="right">Medical</td>
                    <td class="lc" align="right">Expenses</td>
                    <td class="lc" align="right">TOTAL</td>
                </tr>
                <tr>
                    <td class="lc" align="right">Reserve</td>
                    <td class="lc" align="right"><asp:Label runat="server" ID="lblIndemReserve">100.00</asp:Label></td>
                    <td class="lc" align="right"><asp:Label runat="server" ID="lblMedicalReserve">100.00</asp:Label></td>
                    <td class="lc" align="right"><asp:Label runat="server" ID="lblExpensesReserve">100.00</asp:Label></td>
                    <td class="lc" align="right"><asp:Label runat="server" ID="lblTotalReserve">300.00</asp:Label></td>
                </tr>
                 <tr>
                    <td class="lc" align="right">Paid</td>
                    <td class="lc" align="right"><asp:Label runat="server" ID="lblIndemPaid">0.0</asp:Label></td>
                    <td class="lc" align="right"><asp:Label runat="server" ID="lblMedicalPaid">0.0</asp:Label></td>
                    <td class="lc" align="right"><asp:Label runat="server" ID="lblExpensesPaid">0.0</asp:Label></td>
                    <td class="lc" align="right"><asp:Label runat="server" ID="lblTotalPaid">0.0</asp:Label></td>
                </tr>
                 <tr>
                    <td class="lc" align="right">O/S</td>
                    <td class="lc" align="right"><asp:Label runat="server" ID="lblIndemOS">100.00</asp:Label></td>
                    <td class="lc" align="right"><asp:Label runat="server" ID="lblMedicalOS">100.00</asp:Label></td>
                    <td class="lc" align="right"><asp:Label runat="server" ID="lblExpensesOS">100.00</asp:Label></td>
                    <td class="lc" align="right"><asp:Label runat="server" ID="lblTotalOS">300.00</asp:Label></td>
                </tr>     
            </table>
            </div>
        </td>
    </tr>
    <tr>
        <td>
            <div id="divfourth" style="width: 100%; display:none;">
            <table cellpadding="2" cellspacing="0" border="0" width="100%">
               <tr>
                    <td class="ghc" align="left" colspan="6">
                        Settlement Request
                    </td>
                </tr>
                <tr>
                    <td style="width:20%" align="left" class="lc">
                       Settlement Method
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%;height:50px;" align="left" class="ic" colspan="4" >
                        <asp:Label runat="server" ID="lblSettleMethod"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td style="width:20%" align="left" class="lc">
                       Method of Settlement
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label runat="server" ID="lblMethodOfSettle"></asp:Label>
                    </td>
                    <td style="width:20%" align="left" class="lc">
                       Status Only / Action Plan
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:RadioButton ID="rbtnActionPalnYes" GroupName="ActionPlan" runat="server" Text="Yes" />
                        <asp:RadioButton ID="rbtnActionPalnNO" GroupName="ActionPlan" runat="server" Text="No" />
                    </td>
                </tr>
            </table>
            </div>
        </td>
    </tr>
    <tr>
        <td>
            <div id="divfifth" style="width: 100%; display:none;">
            <table cellpadding="2" cellspacing="0" border="0" width="100%">
               <tr>
                    <td class="ghc" align="left" colspan="6">
                        Classification
                    </td>
                </tr>
                <tr>
                    <td style="width:20%" align="left" class="lc">
                       Compensatiton Originally Denied 
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                         <asp:RadioButton Enabled="false" ID="rbtnCompensatitonYes" GroupName="Compensatiton" runat="server" Text="Yes" />
                        <asp:RadioButton Enabled="false" ID="rbtnCompensatitonNo" GroupName="Compensatiton" runat="server" Text="No" />
                    </td>
                    <td style="width:20%" align="left" class="lc">
                       L/S Reimbursement of Cost  
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                         <asp:RadioButton Enabled="false" ID="rbtnReimbursementYes" GroupName="Reimbursement" runat="server" Text="Yes" />
                        <asp:RadioButton ID="rbtnReimbursementNo" Enabled="false" GroupName="Reimbursement" runat="server" Text="No" />
                    </td>
                </tr>
                 <tr>
                    <td style="width:20%" align="left" class="lc">
                       Waive Subrogation
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:RadioButton ID="rbtnWaiveYes" GroupName="Waive" Enabled="false" runat="server" Text="Yes" />
                        <asp:RadioButton ID="rbtnWaiveNO" GroupName="Waive" runat="server" Enabled="false" Text="No" />
                    </td>
                    <td style="width:20%" align="left" class="lc">
                       Close Medicals
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:RadioButton ID="rbtnCloseMedicalYes" GroupName="CloseMedicals" runat="server" Enabled="false" Text="Yes" />
                        <asp:RadioButton ID="CloseMedicalNo" GroupName="CloseMedicals" runat="server" Enabled="false" Text="No" />
                    </td>
                </tr>                
                 <tr>
                    <td style="width:20%" align="left" class="lc">
                       Confidentiality Clause
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:RadioButton ID="rbtnConfidentYes" Enabled="false" GroupName="Confidentiality" runat="server" Text="Yes" />
                        <asp:RadioButton ID="rbtnConfidentNo" Enabled="false" GroupName="Confidentiality" runat="server" Text="No" />
                    </td>
                    <td style="width:20%" align="left" class="lc">
                       Other Medicals
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:RadioButton ID="rbtnOtherMediYes" Enabled="false" GroupName="OtherMedicals" runat="server" Text="Yes" />
                        <asp:RadioButton ID="rbtnOtherMediNO" Enabled="false" GroupName="OtherMedicals" runat="server" Text="No" />
                    </td>
                </tr>
                 <tr>
                    <td style="width:20%" align="left" class="lc">
                       Settlement of Permanent Total
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:RadioButton ID="rbtnSettlementYes" Enabled="false" GroupName="Settlement" runat="server" Text="Yes" />
                        <asp:RadioButton ID="rbtnSettlementNO" Enabled="false" GroupName="Settlement" runat="server" Text="No" />
                    </td>
                    <td style="width:20%" align="left" class="lc">
                        Resignation
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:RadioButton ID="ResignationYes" Enabled="false" GroupName="Resignation" runat="server" Text="Yes" />
                        <asp:RadioButton ID="ResignationNo" Enabled="false" GroupName="Resignation" runat="server" Text="No" />
                    </td>
                </tr>
                <tr>
                    <td style="width:20%" align="left" class="lc">
                       Other
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:RadioButton ID="rbtnOtherYes" Enabled="false" GroupName="Other" runat="server" Text="Yes" />
                        <asp:RadioButton ID="rbtnOtherNo" Enabled="false" GroupName="Other" runat="server" Text="No" />
                    </td>
                    <td style="width:20%" align="left" class="lc">
                        Resignation Date
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label runat="server" ID="lblResignationDate"></asp:Label>
                    </td>
                </tr>
                
            </table>
            </div>
        </td>
    </tr>
    <tr>
        <td>
            <div id="divsix" style="width: 100%; display:none;">
            <table cellpadding="2" cellspacing="0" border="0" width="100%">
               <tr>
                    <td class="ghc" align="left" colspan="6">
                        Legal
                    </td>
                </tr>
                <tr>
                    <td style="width:20%" align="left" class="lc">
                       Defense Council's Name
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label runat="server" ID="lblDefense"></asp:Label>
                    </td>
                     <td style="width:20%" align="left" class="lc">
                       Phone
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label runat="server" ID="lblDefensePhone"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td style="width:20%" align="left" class="lc">
                       Claimant's Attorney 
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label runat="server" ID="lblClaimant"></asp:Label>
                    </td>
                    <td style="width:20%" align="left" class="lc">
                       Phone
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label runat="server" ID="lblClaimantPhone"></asp:Label>
                    </td>
                </tr>
            </table>
            </div>
        </td>
    </tr>
       <tr>
        <td>
            <div id="divseven" style="width: 100%; display:none;">
            <table cellpadding="2" cellspacing="0" border="0" width="100%">
               <tr>
                    <td class="ghc" align="left" colspan="6">
                        Settlement Approvals
                    </td>
                </tr>
                <tr>
                    <td style="width:20%" align="left" class="lc">
                       Requested Amount
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:TextBox runat="server" ID="txtReqAmt" Enabled="false"></asp:TextBox>
                    </td>
                     <td style="width:20%" align="left" class="lc">
                       Potential Total Exposure
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:TextBox runat="server" ID="txtPotential" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td style="width:20%" align="left" class="lc">
                       Settled
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:RadioButton ID="rbtnSettledYes" Enabled="false" GroupName="Settled" runat="server" Text="Yes" />
                        <asp:RadioButton ID="rbtnSettledNo" Enabled="false" GroupName="Settled" runat="server" Text="No" />
                    </td>
                    <td style="width:20%" align="left" class="lc">
                       Amount
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:TextBox runat="server" ID="txtAmt" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="6" align="left"><b>Approvals</b></td>
                </tr>
                <tr>
                    <td style="width:20%" align="left" class="lc">
                       Location Representative
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:TextBox runat="server" ID="txtLocRepresent" Enabled="false"></asp:TextBox>
                    </td>
                     <td style="width:20%" align="left" class="lc">
                       Claims Manager
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:TextBox runat="server" ID="txtClaimManager" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width:20%" align="left" class="lc">
                       Risk Manager
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:TextBox runat="server" ID="txtRiskManager" Enabled="false"></asp:TextBox>
                    </td>
                     <td style="width:20%" align="left" class="lc">
                       Treasury
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:TextBox runat="server" ID="txtTreasury" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width:20%" align="left" class="lc">
                       CFO
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic" colspan="4">
                        <asp:TextBox runat="server" ID="txtCFO" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width:20%" align="left" class="lc">
                      Comments
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic" colspan="4">
                        <asp:TextBox runat="server" ID="txtComments" width="70%" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
            </table>
            </div>
        </td>
    </tr>
    <tr>
        <td>
            <div id="diveight" style="width: 100%; display:none;">
            <table cellpadding="2" cellspacing="0" border="0" width="100%">
               <tr>
                    <td class="ghc" align="left" colspan="6">
                        Attachment
                    </td>
                </tr>
                <tr>
                    <td style="width:20%" align="left" class="lc">
                       Attachment Type
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td align="left" class="ic" colspan="4">
                        <asp:Label runat="server" ID="lblAttachmentType"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td style="width:20%" align="left" class="lc">
                       Attachment Description 
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td align="left" class="ic" colspan="4">
                        <asp:Label runat="server" ID="lblAttachmentDesc"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td style="width:20%" align="left" class="lc">
                       Attachment Filename 
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td align="left" class="ic" colspan="4">
                        <asp:Label runat="server" ID="lblAttachFileName"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="6">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="6" class="lc" align="center">Note : All fields marked with an asterisk are required before saving.</td>
                </tr>
                <tr>
                    <td colspan="6">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="6" class="ic" align="center"> 
                        <asp:Button runat="server" ID="btnSave" EnableTheming="false" SkinID="btnGen"  Text="Save & View" OnClick="btnSave_Click" />
                    </td>
                </tr>
            </table>
            </div>
        </td>
    </tr>
    
</table>
</div>
</div>
</asp:Content>

