<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Settlement_View.aspx.cs" Inherits="WorkerCompensation_Settlement_View" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%--Menu DIV--%>
        <%--<div id="Div1" runat="server" style="width: 100%">
            <asp:Menu ID="mnuWorkComp" runat="server" DataSourceID="smdWorkComp" Orientation="Horizontal"
                StaticDisplayLevels="2" StaticSubMenuIndent=""  SkinID="mnuTab">
            </asp:Menu>
            <asp:SiteMapDataSource ID="smdWorkComp" runat="server" />
        </div>--%>
<div id="contmain" runat="server" style="width: 100%;">
<br />
        <div id="Div1" runat="server" style="width: 100%; text-align: center;  border: solid 1px">           
    <table border="0" cellpadding="1" cellspacing="0" width="99%">
        <tr>
            <td align="center" style="background-image: url('../images/normal_btn.jpg')" class="normal_tab"
                valign="middle">
                <a class="main_menu" href="Workers_ Compensation.aspx">Worker Compensation</a></td>
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
<table cellpadding="5" cellspacing="0" border="0" width="100%">
    <tr>
        <td>        
            <table cellpadding="2" cellspacing="0" border="0" width="100%">
                <tr>
                    <td class="lc" align="left" colspan="3">SETTLEMENT</td>
                    <td class="lc" align="right" colspan="3">
                       
                    </td>
                </tr>
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
        </td>
    </tr>
    <tr>
        <td>        
            <table cellpadding="2" cellspacing="0" border="0" width="100%">
                <tr>
                    <td colspan="6" class="ghc">
                        Status</td>
                </tr>
                <tr>
                    <td style="width:20%" align="left" class="lc">
                        Treating Physician
                    </td>
                    <td style="width:5%" align="Center" class="lc">
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
                    <td style="width:5%" align="Center" class="lc">
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
                    <td style="width:5%" align="Center" class="lc">
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
                    <td style="width:5%" align="Center" class="lc">
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
                    <td style="width:5%" align="Center" class="lc">
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
                    <td style="width:5%" align="Center" class="lc">
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
                    <td style="width:5%" align="Center" class="lc">
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
                    <td style="width:5%" align="Center" class="lc">
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
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%;height:70px;" align="left" class="ic" colspan="4">
                        <asp:Label runat="server" ID="lblExplain"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width:20%" align="left" class="lc">
                       Permanent
                    </td>
                    <td style="width:5%" align="Center" class="lc">
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
                    <td style="width:5%" align="Center" class="lc">
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
                    <td style="width:5%" align="Center" class="lc">
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
                    <td style="width:5%" align="Center" class="lc">
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
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic" colspan="4">
                        <asp:Label runat="server" ID="lblNewTreatPhysician"></asp:Label>
                    </td>
                </tr>
                <tr><td colspan="6">&nbsp;</td></tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
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
        </td>
    </tr>
    <tr>
        <td>
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
                    <td style="width:25%;height:50px;" align="left" class="ic" colspan="4">
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
                        <asp:RadioButton ID="rbtnActionPalnYes" Enabled="false" GroupName="ActionPlan" runat="server" Text="Yes" />
                        <asp:RadioButton ID="rbtnActionPalnNO" Enabled="false" GroupName="ActionPlan" runat="server" Text="No" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
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
                        <asp:Label runat="server" ID="lblCompensatiton"></asp:Label>
                    </td>
                    <td style="width:20%" align="left" class="lc">
                       L/S Reimbursement of Cost  
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label runat="server" ID="lblReimbursement"></asp:Label>
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
                        <asp:Label runat="server" ID="lblWaive"></asp:Label>
                    </td>
                    <td style="width:20%" align="left" class="lc">
                       Close Medicals
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label runat="server" ID="lblCloseMedical"></asp:Label>
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
                        <asp:Label runat="server" ID="lblConfident"></asp:Label>
                    </td>
                    <td style="width:20%" align="left" class="lc">
                       Other Medicals
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                       <asp:Label runat="server" ID="lblOtherMedi"></asp:Label>
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
                        <asp:Label runat="server" ID="lblSettleTotal"></asp:Label>
                    </td>
                    <td style="width:20%" align="left" class="lc">
                        Resignation
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label runat="server" ID="lblResignation"></asp:Label>
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
                        <asp:Label runat="server" ID="lblOther"></asp:Label>
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
        </td>
    </tr>
    <tr>
        <td>
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
        </td>
    </tr>
       <tr>
        <td>
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
                        <asp:Label ID="lblReqAmt" runat="server"></asp:Label>
                    </td>
                     <td style="width:20%" align="left" class="lc">
                       Potential Total Exposure
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label ID="lblPotential" runat="server"></asp:Label>
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
                        <asp:Label ID="lblSettle" runat="server"></asp:Label>
                    </td>
                    <td style="width:20%" align="left" class="lc">
                       Amount
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label ID="lblAmt" runat="server"></asp:Label>
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
                        <asp:Label ID="lblLocRepresent" runat="server"></asp:Label>
                    </td>
                     <td style="width:20%" align="left" class="lc">
                       Claims Manager
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label ID="lblClaimManager" runat="server"></asp:Label>
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
                        <asp:Label ID="lblRiskManager" runat="server"></asp:Label>
                    </td>
                     <td style="width:20%" align="left" class="lc">
                       Treasury
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%" align="left" class="ic">
                        <asp:Label ID="lblTreasury" runat="server"></asp:Label>
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
                        <asp:Label ID="lblCFO" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width:20%" align="left" class="lc">
                      Comments
                    </td>
                    <td style="width:5%" align="Center" class="lc">
                        :
                    </td>
                    <td style="width:25%;height:60px;" align="left" class="ic" colspan="4">
                        <asp:Label ID="lblComment" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <table cellpadding="2" cellspacing="0" border="0" width="100%">
               <tr>
                    <td class="ghc" align="left" colspan="6">
                        Attachment Details
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
            </table>
        </td>
    </tr>
    <tr>
        <td colspan="6">&nbsp;</td>
    </tr>
    <tr>
        <td colspan="6">&nbsp;</td>
    </tr>    
    <tr>
        <td colspan="6">&nbsp;</td>
    </tr>
    <tr>
        <td colspan="6" class="ic" align="center"> 
            <asp:Button runat="server" ID="btnBack" EnableTheming="false" SkinID="btnGen" Text="Back" OnClick="btnBack_Click" />
        </td>
    </tr>
</table>
</div>
</asp:Content>

