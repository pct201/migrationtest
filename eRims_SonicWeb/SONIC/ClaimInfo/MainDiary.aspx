<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="MainDiary.aspx.cs"
    Inherits="SONIC_ClaimInfo_MainDiary" Title="eRIMS Sonic :: Claim Information :: MainDiary" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/ClaimTab/ClaimTab.ascx" TagName="CtlClaimTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/SONICInfo/SonicInfo.ascx" TagName="CtlSonicInfo" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>JavaScript/JFunctions.js">
    </script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>JavaScript/Validator.js">
    </script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery.maskedinput.js"></script>
   
    <script type="text/javascript">
        function SetMenuStyle(index) {
        }

        function valSearch(searchCol) {
            ValidatorEnable(document.getElementById('<%=revSearchDateDiary.ClientID%>'), (searchCol == "Diary_Date"))
        }
        function MinMaxI() {
            if (document.getElementById("ctl00_ContentPlaceHolder1_fvDiaryDetails_txtINote").style.height == "") {
                document.getElementById("ctl00_ContentPlaceHolder1_fvDiaryDetails_ibtnIDisplay").src = "../Images/minus.jpg";
                document.getElementById("ctl00_ContentPlaceHolder1_fvDiaryDetails_txtINote").style.height = "100px";
                document.getElementById("pnlTemp").style.display = "block";
            }
            else if (document.getElementById("ctl00_ContentPlaceHolder1_fvDiaryDetails_txtINote").style.height == "100px") {
                document.getElementById("ctl00_ContentPlaceHolder1_fvDiaryDetails_ibtnIDisplay").src = "../Images/plus.jpg";
                document.getElementById("ctl00_ContentPlaceHolder1_fvDiaryDetails_txtINote").style.height = "";
                document.getElementById("pnlTemp").style.display = "none";
            }
            return false;
        }
        function MinMax() {
            if (document.getElementById("ctl00_ContentPlaceHolder1_fvDiaryDetails_txtNote").style.height == "") {
                document.getElementById("ctl00_ContentPlaceHolder1_fvDiaryDetails_ibtnDisplay").src = "../Images/minus.jpg";
                document.getElementById("ctl00_ContentPlaceHolder1_fvDiaryDetails_txtNote").style.height = "100px";
                document.getElementById("pnlETemp").style.display = "block";
            }
            else if (document.getElementById("ctl00_ContentPlaceHolder1_fvDiaryDetails_txtNote").style.height == "100px") {
                document.getElementById("ctl00_ContentPlaceHolder1_fvDiaryDetails_ibtnDisplay").src = "../Images/plus.jpg";
                document.getElementById("ctl00_ContentPlaceHolder1_fvDiaryDetails_txtNote").style.height = "";
                document.getElementById("pnlETemp").style.display = "none";
            }
            return false;
        }

        function displayDetail() {
            document.getElementById("ctl00_ContentPlaceHolder1_divfirst").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_divthird").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_divbtn").style.display = "none";
            return false;
        }

        function openPopUp(assignTo) {
            //debugger; 
            ShowDialog("../../ExecutiveRisk/LDiaryUser.aspx?Module=Diary");
            //        oWnd=window.open("LDiaryUser.aspx","Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=300");	
            //        oWnd.moveTo(260,180);
            return false;
        }

    </script>
    <script language="javascript" type="text/javascript">
        function CheckTodayDate(sender, args) {
            args.IsValid = (CompareDateLessThanTodayNoAlert(args.Value));
            return args.IsValid;
        }

        function ValidateFields(sender, args) {

            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnControlIDs.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnErrorMsgs.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnControlIDs.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {
                        case "textarea":
                        case "text": if (ctrl.value == '') bEmpty = true; break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                        case "select-multiple": if (ctrl.selectedIndex == -1) bEmpty = true; break;
                    }
                    if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
                    if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                }
                if (msg.length > 0) {
                    sender.errormessage = msg;
                    args.IsValid = false;
                }
                else
                    args.IsValid = true;
            }
            else {
                args.IsValid = true;
            }
        }

        function ValidateFieldsUpdate(sender, args) {

            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnControlUpdateIDs.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnUpdateErrorMsgs.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnControlUpdateIDs.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {
                        case "textarea":
                        case "text": if (ctrl.value == '') bEmpty = true; break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                        case "select-multiple": if (ctrl.selectedIndex == -1) bEmpty = true; break;
                    }
                    if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
                    if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                }
                if (msg.length > 0) {
                    sender.errormessage = msg;
                    args.IsValid = false;
                }
                else
                    args.IsValid = true;
            }
            else {
                args.IsValid = true;
            }
        }

    </script>
    <div style="width: 100%;">
        <asp:ValidationSummary ID="vsErrorInsert" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroupInsert" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsErrorEdit" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroupEdit" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsErrorSearch" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroupSearch" CssClass="errormessage"></asp:ValidationSummary>
        <asp:CustomValidator ID="cvErrorMsg" runat="server" ErrorMessage="" EnableClientScript="false"
            ValidationGroup="vsErrorGroup" Display="None"></asp:CustomValidator>
        <asp:Label runat="server" Visible="false" ID="lblScript"></asp:Label>
    </div>
    <div id="contmain" runat="server" style="width: 100%;">
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td style="height: 50px;" colspan="2" valign="bottom">
                    <uc:CtlClaimTab ID="ClaimTab" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="Spacer" style="height: 15px;" colspan="2">
                    <asp:UpdateProgress runat="server" ID="upProgress" DisplayAfter="100">
                        <ProgressTemplate>
                            <div class="UpdatePanelloading" id="divProgress" style="width: 100%;">
                                <table id="ProgressTable" cellpadding="0" cellspacing="0" border="0" style="width: 100%;
                                    height: 100%;">
                                    <tr align="center" valign="middle">
                                        <td class="LoadingText" align="center" valign="middle">
                                            <img src="../../Images/indicator.gif" alt="Loading" />&nbsp;&nbsp;&nbsp;Please Wait..
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </td>
            </tr>
            <tr runat="server" id="trWCHeader" style="display: none;">
                <td colspan="2" width="100%">
                    <asp:UpdatePanel runat="Server" ID="updSonic_WC" UpdateMode="Always">
                        <ContentTemplate>
                            <table style="background-color: black" cellspacing="1" cellpadding="3" width="100%"
                                border="0">
                                <tbody>
                                    <tr class="PropertyInfoBG">
                                        <td style="width: 15%" align="left">
                                            <asp:Label ID="lblHeaderClaimNumber_WC" runat="server" Text="Claim Number"></asp:Label>
                                        </td>
                                        <td style="width: 15%" align="left">
                                            <asp:Label ID="lblHeaderLocationdba_WC" runat="server" Text="SONIC Location d/b/a"></asp:Label>
                                        </td>
                                        <td style="width: 15%" id="tdHeaderName_WC" align="left" runat="server">
                                            <asp:Label ID="lblHeaderName_WC" runat="server" Text="Name"></asp:Label>
                                        </td>
                                        <td style="width: 15%" align="left">
                                            <asp:Label ID="lblHeaderDateIncident_WC" runat="server" Text="Date of Incident"></asp:Label>
                                        </td>
                                        <td style="width: 25%" align="left">
                                            <asp:Label ID="lblHeaderAssociatedFirstReport_WC" runat="server" Text="Associated First Report"></asp:Label>
                                        </td>
                                        <td style="width: 15%" align="left">
                                            <asp:Label ID="lblHeaderInvestigation_WC" runat="server" Text="Investigation"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="background-color: white">
                                        <td align="left">
                                            <asp:Label ID="lblClaimNumber_WC" runat="server">&nbsp;</asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblLocationdba_WC" runat="server"></asp:Label>
                                        </td>
                                        <td id="tdName_WC" align="left" runat="Server">
                                            <asp:Label ID="lblName_WC" runat="server"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblDateIncident1_WC" runat="server"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:LinkButton ID="lnkAssociatedFirstReport_WC" runat="server" OnClick="lnkAssociatedFirstReport_WC_Click"></asp:LinkButton>
                                        </td>
                                        <td align="left">
                                            <asp:LinkButton ID="lnkInvestigation_WC" runat="server" /><asp:LinkButton ID="lnkAddInvestigation_WC"
                                                runat="server" Text="Add New" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr runat="server" id="trALHeader" style="display: none;">
                <td width="100%" colspan="2">
                    <asp:UpdatePanel runat="Server" ID="updSonic_AL" UpdateMode="Always">
                        <ContentTemplate>
                            <table style="background-color: black" cellspacing="1" cellpadding="3" width="100%"
                                border="0">
                                <tbody>
                                    <tr class="PropertyInfoBG">
                                        <td style="width: 18%" align="left">
                                            <asp:Label ID="lblHeaderClaimNumber_AL" runat="server" Text="Claim Number"></asp:Label>
                                        </td>
                                        <td style="width: 18%" align="left">
                                            <asp:Label ID="lblHeaderLocationdba_AL" runat="server" Text="SONIC Location d/b/a"></asp:Label>
                                        </td>
                                        <td style="display: none; width: 18%" id="tdHeaderName_AL" align="left" runat="server">
                                            <asp:Label ID="lblHeaderName_AL" runat="server" Text="Name"></asp:Label>
                                        </td>
                                        <td style="width: 18%" align="left">
                                            <asp:Label ID="lblHeaderDateIncident_AL" runat="server" Text="Date of Incident"></asp:Label>
                                        </td>
                                        <td style="width: 28%" align="left">
                                            <asp:Label ID="lblHeaderAssociatedFirstReport_AL" runat="server" Text="Associated First Report"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="background-color: white">
                                        <td align="left">
                                            <asp:Label ID="lblClaimNumber_AL" runat="server">&nbsp; </asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblLocationdba_AL" runat="server"> </asp:Label>
                                        </td>
                                        <td style="display: none" id="tdName_AL" align="left" runat="Server">
                                            <asp:Label ID="lblName_AL" runat="server"> </asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblDateIncident_AL" runat="server"> </asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:LinkButton ID="lnkAssociatedFirstReport_AL" runat="server" OnClick="lnkAssociatedFirstReport_AL_Click"></asp:LinkButton>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr runat="server" id="trDPDHeader" style="display: none;">
                <td width="100%" colspan="2">
                    <asp:UpdatePanel runat="Server" ID="updSonic_DPD" UpdateMode="Always">
                        <ContentTemplate>
                            <table style="background-color: black" cellspacing="1" cellpadding="3" width="100%"
                                border="0">
                                <tbody>
                                    <tr class="PropertyInfoBG">
                                        <td style="width: 18%" align="left">
                                            <asp:Label ID="lblHeaderClaimNumber_DPD" runat="server" Text="Claim Number"></asp:Label>
                                        </td>
                                        <td style="width: 18%" align="left">
                                            <asp:Label ID="lblHeaderLocationdba_DPD" runat="server" Text="SONIC Location d/b/a"></asp:Label>
                                        </td>
                                        <td style="display: none; width: 18%" id="tdHeaderName_DPD" align="left" runat="server">
                                            <asp:Label ID="lblHeaderName_DPD" runat="server" Text="Name"></asp:Label>
                                        </td>
                                        <td style="width: 18%" align="left">
                                            <asp:Label ID="lblHeaderDateLoss_DPD" runat="server" Text="Date of Loss"></asp:Label>
                                        </td>
                                        <td style="width: 28%" align="left">
                                            <asp:Label ID="lblHeaderAssociatedFirstReport_DPD" runat="server" Text="Associated First Report"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="background-color: white">
                                        <td align="left">
                                            <asp:Label ID="lblClaimNumber_DPD" runat="server">&nbsp;</asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblLocationdba_DPD" runat="server"></asp:Label>
                                        </td>
                                        <td style="display: none" id="tdName_DPD" align="left" runat="Server">
                                            <asp:Label ID="lblName_DPD" runat="server"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblDateLoss_DPD" runat="server"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:LinkButton ID="lnkAssociatedFirstReport_DPD" runat="server" OnClick="lnkAssociatedFirstReport_DPD_Click"></asp:LinkButton>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr runat="server" id="trPLHeader" style="display: none;">
                <td width="100%" colspan="2">
                    <asp:UpdatePanel runat="Server" ID="updSonic_PL" UpdateMode="Always">
                        <ContentTemplate>
                            <table style="background-color: black" cellspacing="1" cellpadding="3" width="100%"
                                border="0">
                                <tbody>
                                    <tr class="PropertyInfoBG">
                                        <td style="width: 18%" align="left">
                                            <asp:Label ID="lblHeaderClaimNumber_PL" runat="server" Text="Claim Number"></asp:Label>
                                        </td>
                                        <td style="width: 18%" align="left">
                                            <asp:Label ID="lblHeaderLocationdba_PL" runat="server" Text="SONIC Location d/b/a"></asp:Label>
                                        </td>
                                        <td style="display: none; width: 18%" id="tdHeaderName_PL" align="left" runat="server">
                                            <asp:Label ID="lblHeaderName_PL" runat="server" Text="Name"></asp:Label>
                                        </td>
                                        <td style="width: 18%" align="left">
                                            <asp:Label ID="lblHeaderDateIncident_PL" runat="server" Text="Date of Incident"></asp:Label>
                                        </td>
                                        <td style="width: 28%" align="left">
                                            <asp:Label ID="lblHeaderAssociatedFirstReport_PL" runat="server" Text="Associated First Report"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="background-color: white">
                                        <td align="left">
                                            <asp:Label ID="lblClaimNumber_PL" runat="server"> &nbsp;</asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblLocationdba_PL" runat="server"> &nbsp;</asp:Label>
                                        </td>
                                        <td style="display: none" id="tdName_PL" align="left" runat="Server">
                                            <asp:Label ID="lblName_PL" runat="server"> &nbsp;</asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblDateIncident_PL" runat="server"> &nbsp;</asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:LinkButton ID="lnkAssociatedFirstReport_PL" runat="server" OnClick="lnkAssociatedFirstReport_PL_Click"> </asp:LinkButton>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr runat="server" id="trPROPHeader" style="display: none;">
                <td width="100%" colspan="2">
                    <asp:UpdatePanel runat="Server" ID="updSonic_Prop" UpdateMode="Always">
                        <ContentTemplate>
                            <table style="background-color: black" cellspacing="1" cellpadding="3" width="100%"
                                border="0">
                                <tbody>
                                    <tr class="PropertyInfoBG">
                                        <td style="width: 18%" align="left">
                                            <asp:Label ID="lblHeaderClaimNumber_Prop" runat="server" Text="Claim Number"></asp:Label>
                                        </td>
                                        <td style="width: 18%" align="left">
                                            <asp:Label ID="lblHeaderLocationdba_Prop" runat="server" Text="SONIC Location d/b/a"></asp:Label>
                                        </td>
                                        <td style="display: none; width: 18%" id="tdHeaderName_Prop" align="left" runat="server">
                                            <asp:Label ID="lblHeaderName_Prop" runat="server" Text="Name"></asp:Label>
                                        </td>
                                        <td style="width: 18%" align="left">
                                            <asp:Label ID="lblHeaderDateLoss_Prop" runat="server" Text="Date of Loss"></asp:Label>
                                        </td>
                                        <td style="width: 28%" align="left">
                                            <asp:Label ID="lblHeaderAssociatedFirstReport_Prop" runat="server" Text="Associated First Report"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="background-color: white">
                                        <td align="left">
                                            <asp:Label ID="lblClaimNumber_Prop" runat="server">&nbsp; </asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblLocationdba_Prop" runat="server"> </asp:Label>
                                        </td>
                                        <td style="display: none" id="tdName_Prop" align="left" runat="Server">
                                            <asp:Label ID="lblName_Prop" runat="server"> </asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblDateIncident_Prop" runat="server"> </asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:LinkButton ID="lnkAssociatedFirstReport_Prop" runat="server" OnClick="lnkAssociatedFirstReport_Prop_Click"></asp:LinkButton>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="Spacer" style="height: 15px;" colspan="2">
                </td>
            </tr>
            <tr>
                <td id="leftDiv" runat="server" style="width: 203px; font-family: verdana; vertical-align: top;
                    border: solid 1px black;">
                    <table border="0" cellpadding="5" cellspacing="0" width="203px">
                        <tr>
                            <td colspan="2" class="Spacer" height="10px;">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 15%">
                                &nbsp;
                            </td>
                            <td style="width: 85%" runat="server" id="temp">
                                <asp:LinkButton ID="first" runat="server" CssClass="left_menu_active" OnClick="first_Click"
                                    Text="Claim Details"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:LinkButton ID="second" runat="server" CssClass="left_menu" OnClick="second_Click"
                                    Text="Diary Data"></asp:LinkButton>&nbsp;<span id="MenuAsterisk2" runat="server"
                                        style="color: Red; display: none">*</span>
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="100%">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td width="5px">
                                &nbsp;
                            </td>
                            <td class="dvContainer">
                                <div id="mainContent" runat="server">
                                    <div id="divfirst" style="width: 100%; display: block;" runat="server">
                                        <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                            <tr>
                                                <td colspan="6" class="ghc">
                                                    Claim Details
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%;" align="left" class="lc">
                                                    <asp:Label runat="server" ID="lblMClaimNumber">Claim Number</asp:Label>
                                                </td>
                                                <td align="Center" class="lc">
                                                    :
                                                </td>
                                                <td style="width: 25%;" align="left" class="ic">
                                                    <asp:Label runat="server" ID="lblClaimNum"></asp:Label>
                                                </td>
                                                <td style="width: 25%;" align="left" class="lc">
                                                    <asp:Label runat="server" ID="lblMDOIncident">Date of Incident</asp:Label>
                                                </td>
                                                <td align="Center" class="lc">
                                                    :
                                                </td>
                                                <td style="width: 25%;" align="left" class="ic">
                                                    <asp:Label runat="server" ID="lblDateIncident"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%;" align="left" class="lc">
                                                    <asp:Label runat="server" ID="lblMLastName">Name</asp:Label>
                                                </td>
                                                <td align="Center" class="lc">
                                                    :
                                                </td>
                                                <td style="width: 25%;" align="left" class="ic">
                                                    <asp:Label runat="server" ID="lblName1"></asp:Label>
                                                </td>
                                                <td style="width: 25%;" align="left" class="lc">
                                                    <asp:Label runat="server" ID="lblMEmployee">Employee</asp:Label>
                                                </td>
                                                <td align="Center" class="lc">
                                                    :
                                                </td>
                                                <td style="width: 25%;" align="left" class="ic">
                                                    <asp:RadioButtonList ID="rbtnEmployee" runat="server" Enabled="false" RepeatDirection="Horizontal">
                                                        <asp:ListItem>Yes</asp:ListItem>
                                                        <asp:ListItem>No</asp:ListItem>
                                                    </asp:RadioButtonList>
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
                                        </table>
                                    </div>
                                    <div id="divSearch" runat="server" style="display: none;">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 80%; display: block;" align="right">
                                                    <table style="width: 60%;">
                                                        <tr>
                                                            <td class="lc">
                                                                Search
                                                            </td>
                                                            <td class="ic">
                                                                <asp:DropDownList ID="ddlSearch" runat="server" SkinID="dropGen" onchange="valSearch(this.value);">
                                                                    <asp:ListItem Text="Assign To" Value="Assigned_To"></asp:ListItem>
                                                                    <asp:ListItem Text="Diary Date" Value="Diary_Date"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td class="ic">
                                                                <asp:TextBox ID="txtSearch" runat="server" MaxLength="20"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="revSearchDateDiary" runat="server" ControlToValidate="txtSearch"
                                                                    Enabled="false" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                    ErrorMessage="Please enter proper diary date to search" Display="none" ValidationGroup="vsErrorGroupSearch"></asp:RegularExpressionValidator>
                                                            </td>
                                                            <td class="ic">
                                                                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                                                                    ValidationGroup="vsErrorGroupSearch" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 20%;" align="left" class="lc">
                                                    <asp:Label ID="lblBankDetailsTotal" runat="server"></asp:Label>
                                                </td>
                                                <td style="width: 80%;" align="right">
                                                    <table width="75%">
                                                        <tr>
                                                            <td class="lc">
                                                                No. of Records per page :
                                                                <asp:DropDownList ID="ddlPage" SkinID="dropGen" runat="server" DataSourceID="xdsPaging"
                                                                    DataTextField="Text" DataValueField="Value" AutoPostBack="True" OnSelectedIndexChanged="ddlPage_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:XmlDataSource ID="xdsPaging" runat="server" DataFile="~/App_Data/PagingTable.xml">
                                                                </asp:XmlDataSource>
                                                            </td>
                                                            <td class="ic">
                                                                <asp:Button ID="btnPrev" runat="server" OnClick="btnPrev_Click" Text=" < " SkinID="btnGen" />
                                                            </td>
                                                            <td class="lc">
                                                                <asp:Label ID="lblPageInfo" runat="server"></asp:Label>
                                                            </td>
                                                            <td class="ic">
                                                                <asp:Button ID="btnNext" runat="server" OnClick="btnNext_Click" Text=" > " SkinID="btnGen" />
                                                            </td>
                                                            <td class="lc">
                                                                Go to Page:
                                                            </td>
                                                            <td class="ic">
                                                                <asp:Panel runat="server" ID="pnl" DefaultButton="btnGo">
                                                                    <asp:TextBox ID="txtPageNo" runat="server" MaxLength="3" Width="20px" onkeypress="return numberOnly(event);"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revPageNumber" runat="server" ErrorMessage="*"
                                                                        ControlToValidate="txtPageNo" Display="dynamic" ValidationExpression="^([0-9]*|\d*\d{1}?\d*)$"
                                                                        ValidationGroup="Paging"></asp:RegularExpressionValidator>
                                                                </asp:Panel>
                                                            </td>
                                                            <td class="ic">
                                                                <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click" ValidationGroup="Paging"
                                                                    CausesValidation="true" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div id="divthird" style="width: 100%; display: none;" runat="server">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td>
                                                    <asp:MultiView runat="server" ID="mvDiaryDetails">
                                                        <asp:View runat="server" ID="vwDiaryList">
                                                            <table style="width: 100%;">
                                                                <tr>
                                                                    <td>
                                                                        <table style="text-align: right; width: 100%;">
                                                                            <tr>
                                                                                <td class="ic">
                                                                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" ToolTip="Click here to delete Diary Details"
                                                                                        OnClick="btnDelete_Click" CausesValidation="false" />
                                                                                    <asp:Button ID="btnAddNew" runat="server" Text="Add New" ToolTip="Add new Diary Details"
                                                                                        OnClick="btnAddNew_Click" CausesValidation="false" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: left;">
                                                                                    <asp:GridView ID="gvDiaryDetails" runat="server" AutoGenerateColumns="false" OnRowCommand="gvDiaryDetails_RowCommand"
                                                                                        DataKeyNames="PK_Diary_ID" Width="100%" OnRowDataBound="gvDiaryDetails_RowDataBound"
                                                                                        AllowPaging="True" AllowSorting="True" OnSorting="gvDiaryDetails_Sorting" OnRowCreated="gvDiaryDetails_RowCreated">
                                                                                        <Columns>
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <input name="chkItem" type="checkbox" value='<%# Eval("PK_Diary_ID")%>' onclick="javascript:UnCheckHeader('gvDiaryDetails')" />
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle Width="10px" />
                                                                                                <HeaderTemplate>
                                                                                                    <input type="checkbox" name="chkHeader" id="chkHeader" runat="Server" onclick="javascript:SelectAllCheckboxes(this)" />
                                                                                                </HeaderTemplate>
                                                                                                <HeaderStyle Width="10px" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Date Of Note Entry" SortExpression="DateOfNoteEntry">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "DateOfNoteEntry", "{0:MM/dd/yyyy}")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <%--<asp:BoundField DataField="DateOfNoteEntry" HeaderText="Date Of Note Entry" SortExpression="DateOfNoteEntry">
                                                                                    </asp:BoundField>--%>
                                                                                            <asp:BoundField DataField="Assigned_To" HeaderText="Assigned To" SortExpression="Assigned_To">
                                                                                            </asp:BoundField>
                                                                                            <asp:TemplateField HeaderText="Diary_Date" SortExpression="Diary_Date">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblDiary_Date" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Diary_Date", "{0:MM/dd/yyyy}")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <%-- <asp:BoundField DataField="Diary_Date" HeaderText="Diary Date" SortExpression="Diary_Date">
                                                                                    </asp:BoundField>--%>
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Button ID="btnEdit" CommandName="EditItem" CommandArgument='<%#Eval("PK_Diary_ID")%>'
                                                                                                        runat="server" Text="Edit" ToolTip="Edit the Diary Details" />
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Button ID="btnView" runat="server" Text="View" CommandName="View" CommandArgument='<%#Eval("PK_Diary_ID")%>'
                                                                                                        ToolTip="View the Diary Details" />
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                                                        <EmptyDataTemplate>
                                                                                            No Diary found for the following claim.
                                                                                        </EmptyDataTemplate>
                                                                                        <PagerSettings Visible="False" />
                                                                                    </asp:GridView>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:View>
                                                        <asp:View ID="vwDiaryDetails" runat="server">
                                                            <table style="width: 100%;">
                                                                <tr>
                                                                    <td>
                                                                        <div>
                                                                            <table cellpadding="2" cellspacing="2" style="border: 1pt; border-color: #7f7f7f;
                                                                                border-style: solid; text-align: left; width: 100%;">
                                                                                <tr>
                                                                                    <td align="left" colspan="6" class="ghc">
                                                                                        Claim Details
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 25%;" align="left" class="lc">
                                                                                        <asp:Label runat="server" ID="lblFClaimNumber">Claim Number</asp:Label>
                                                                                    </td>
                                                                                    <td align="Center" class="lc">
                                                                                        :
                                                                                    </td>
                                                                                    <td style="width: 25%;" align="left" class="ic">
                                                                                        <asp:Label runat="server" ID="lblClaimNo"></asp:Label>
                                                                                    </td>
                                                                                    <td align="left" class="lc">
                                                                                        <asp:Label runat="server" ID="lblFDOIncident">Date of Incident</asp:Label>
                                                                                    </td>
                                                                                    <td align="Center" class="lc">
                                                                                        :
                                                                                    </td>
                                                                                    <td align="left" class="ic">
                                                                                        <asp:Label runat="server" ID="lblDOIncident"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left" class="lc">
                                                                                        <asp:Label runat="server" ID="lblFLastName">Name</asp:Label>
                                                                                    </td>
                                                                                    <td align="Center" class="lc">
                                                                                        :
                                                                                    </td>
                                                                                    <td align="left" class="ic">
                                                                                        <asp:Label runat="server" ID="lblNameView"></asp:Label>
                                                                                    </td>
                                                                                    <td style="width: 25%;" align="left" class="lc">
                                                                                        <asp:Label runat="server" ID="lblFEmployee">Employee</asp:Label>
                                                                                    </td>
                                                                                    <td align="Center" class="lc">
                                                                                        :
                                                                                    </td>
                                                                                    <td style="width: 25%;" align="left" class="ic">
                                                                                        <asp:Label runat="server" ID="lblEmployee"></asp:Label>
                                                                                    </td>
                                                                                    <%--<td align="left" class="lc">
                                                                                <asp:Label runat="server" ID="lblFFirstName"> First Name</asp:Label>
                                                                            </td>
                                                                            <td align="Center" class="lc">
                                                                                :
                                                                            </td>
                                                                            <td align="left" class="ic">
                                                                                <asp:Label runat="server" ID="lblFirstName"></asp:Label>
                                                                            </td>--%>
                                                                                </tr>
                                                                                <%--<tr>
                                                                            <td align="left" class="lc">
                                                                                <asp:Label runat="server" ID="lblFMiddleName">Middle Name</asp:Label>
                                                                            </td>
                                                                            <td align="Center" class="lc">
                                                                                :
                                                                            </td>
                                                                            <td align="left" class="ic">
                                                                                <asp:Label runat="server" ID="lblMiddleName"></asp:Label>
                                                                            </td>
                                                                            
                                                                        </tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:FormView runat="server" ID="fvDiaryDetails" OnDataBound="fvDiaryDetails_DataBound"
                                                                            Width="100%">
                                                                            <InsertItemTemplate>
                                                                                <table cellpadding="2" cellspacing="2" border="0" style="width: 100%;">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <div>
                                                                                                <table cellpadding="2" cellspacing="2" style="width: 100%;">
                                                                                                    <tr>
                                                                                                        <td align="left" colspan="6" class="ghc">
                                                                                                            Diary Information
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="width: 25%;" align="left" class="lc">
                                                                                                            <asp:Label runat="server" ID="lblDONEntry">Date of Note Entry&nbsp;<span id="Span8"
                                                                                                                style="color: Red; display: none;" runat="server">*</span></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="Center" class="lc">
                                                                                                            :
                                                                                                        </td>
                                                                                                        <td style="width: 25%;" align="left" class="ic">
                                                                                                            <asp:TextBox runat="server" ID="txtIDONoteEntry" ValidationGroup="vsErrorGroupInsert"></asp:TextBox>&nbsp;
                                                                                                            <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvDiaryDetails_txtIDONoteEntry', 'mm/dd/y');"
                                                                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                                                                align="absmiddle" /><br />
                                                                                                            <asp:RegularExpressionValidator ID="revtxtIDONoteEntry" runat="server" ControlToValidate="txtIDONoteEntry"
                                                                                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                                                                ErrorMessage="Date Not Valid(Date of Note Entry)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                                                            <asp:RegularExpressionValidator ID="revIDONoteEntry" runat="server" ControlToValidate="txtIDONoteEntry"
                                                                                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                                                                ErrorMessage="[Diary Data]/Date of Note Entry is Not Valid." Display="none" ValidationGroup="vsErrorGroupInsert"></asp:RegularExpressionValidator>
                                                                                                        </td>
                                                                                                        <td style="width: 25%;" align="left" class="lc">
                                                                                                            <asp:Label runat="server" ID="lblDiaryDate">Diary Date&nbsp;<span id="Span1" style="color: Red;
                                                                                                                display: none;" runat="server">*</span></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="Center" class="lc">
                                                                                                            :
                                                                                                        </td>
                                                                                                        <td style="width: 25%;" align="left" class="ic">
                                                                                                            <asp:TextBox runat="server" ID="txtIDiaryDate" ValidationGroup="vsErrorGroupInsert"></asp:TextBox>&nbsp;
                                                                                                            <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvDiaryDetails_txtIDiaryDate', 'mm/dd/y');"
                                                                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                                                                align="absmiddle" />
                                                                                                            <asp:RegularExpressionValidator ID="revtxtIDiaryDate" runat="server" ControlToValidate="txtIDiaryDate"
                                                                                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                                                                ErrorMessage="Date Not Valid(Diary Date)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                                                            <asp:RegularExpressionValidator ID="revIDiaryDate" runat="server" ControlToValidate="txtIDiaryDate"
                                                                                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                                                                ErrorMessage="[Diary Data]/Diary Date is Not Valid." Display="none" ValidationGroup="vsErrorGroupInsert"></asp:RegularExpressionValidator>
                                                                                                            <asp:CustomValidator ID="csmvtxtIDiaryDate" runat="server" ControlToValidate="txtIDiaryDate"
                                                                                                                ErrorMessage="[Diary Data]/Diary Date must not be greater than current date"
                                                                                                                ClientValidationFunction="CheckTodayDate" Display="none" ValidationGroup="vsErrorGroupInsert"
                                                                                                                Enabled="false">
                                                                                                            </asp:CustomValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="left" class="lc" style="width: 25%;" valign="top">
                                                                                                            <asp:Label runat="server" ID="lblNote">Note&nbsp;<span id="Span2" style="color: Red;
                                                                                                                display: none;" runat="server">*</span></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="Center" class="lc" valign="top">
                                                                                                            :
                                                                                                        </td>
                                                                                                        <td align="left" class="ic" colspan="4" valign="top" style="width: 75%;">
                                                                                                            <asp:ImageButton ID="ibtnIDisplay" ImageUrl="~/Images/Minus.jpg" runat="server" OnClientClick="javascript:return MinMaxI();" />
                                                                                                            <div id="pnlTemp" style="display: block;">
                                                                                                                <asp:TextBox runat="server" ID="txtINote" MaxLength="4000" Height="100px" TextMode="MultiLine"
                                                                                                                    Width="93%"></asp:TextBox>
                                                                                                            </div>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="left" class="lc" style="width: 25%;" valign="top">
                                                                                                            <asp:Label runat="server" ID="lblClear"> Clear?</asp:Label>
                                                                                                        </td>
                                                                                                        <td align="Center" class="lc" valign="top">
                                                                                                            :
                                                                                                        </td>
                                                                                                        <td align="left" class="ic" style="width: 25%;" valign="top">
                                                                                                            <asp:RadioButton runat="server" GroupName="Clear" ID="rbIClearYes" Text="Yes" />&nbsp;
                                                                                                            <asp:RadioButton runat="server" GroupName="Clear" ID="rbIClearNo" Checked="true"
                                                                                                                Text="No" />
                                                                                                        </td>
                                                                                                        <td align="left" class="lc" style="width: 25%;" valign="top">
                                                                                                            <asp:Label runat="server" ID="lblAssignTo">Assigned To&nbsp;<span id="Span3" style="color: Red;
                                                                                                                display: none;" runat="server">*</span></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="Center" class="lc" valign="top">
                                                                                                            :
                                                                                                        </td>
                                                                                                        <td align="left" class="ic" style="width: 25%;" valign="top">
                                                                                                            <asp:TextBox runat="server" ID="txtIAssignTo" ReadOnly="true" Width="70%"></asp:TextBox>&nbsp;
                                                                                                            <asp:Button ID="btnIAssignTO" Text="V" runat="server" CssClass="btn" />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td colspan="6" style="display: none;">
                                                                                                            <asp:TextBox runat="server" ID="txtIAssignToID"></asp:TextBox>&nbsp;
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td colspan="6">
                                                                                                            &nbsp;
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td class="ic" align="center" colspan="6">
                                                                                                            <asp:Button runat="server" ID="btnISaveView" SkinID="btnGen" Text="Save & View" ValidationGroup="vsErrorGroupInsert"
                                                                                                                OnClick="btnSaveView_Click" />
                                                                                                            <asp:Button runat="server" ID="btnICancel" Text="Cancel" SkinID="btnGen" OnClick="btnCancel_Click"
                                                                                                                CausesValidation="false" />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <%--<tr>
                                                                                                <td align="center" class="lc" colspan="6">
                                                                                                     <asp:UpdateProgress runat="server">
                                                                                                        <ProgressTemplate>
                                                                                                           <span class="mf"> Mail sending process is going on, please wait...</span>
                                                                                                        </ProgressTemplate>
                                                                                                    </asp:UpdateProgress>
                                                                                                </td>
                                                                                            </tr>--%>
                                                                                                </table>
                                                                                            </div>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </InsertItemTemplate>
                                                                            <EditItemTemplate>
                                                                                <table cellpadding="3" cellspacing="0" border="0" style="width: 100%;">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <div>
                                                                                                <table cellpadding="2" cellspacing="2" style="width: 100%;">
                                                                                                    <tr>
                                                                                                        <td align="left" colspan="6" class="ghc">
                                                                                                            Diary Information
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="width: 25%;" align="left" class="lc">
                                                                                                            <asp:Label runat="server" ID="lblDONEntry">Date of Note Entry&nbsp;<span id="Span7"
                                                                                                                style="color: Red; display: none;" runat="server">*</span></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="Center" class="lc">
                                                                                                            :
                                                                                                        </td>
                                                                                                        <td style="width: 25%;" align="left" class="ic">
                                                                                                            <asp:TextBox runat="server" ID="txtDONoteEntry" ValidationGroup="vsErrorGroupEdit"></asp:TextBox>&nbsp;
                                                                                                            <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvDiaryDetails_txtDONoteEntry', 'mm/dd/y');"
                                                                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                                                                align="absmiddle" /><br />
                                                                                                            <asp:RegularExpressionValidator ID="revtxtDONoteEntry" runat="server" ControlToValidate="txtDONoteEntry"
                                                                                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                                                                ErrorMessage="Date Not Valid(Date of Note Entry)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                                                            <asp:RegularExpressionValidator ID="revDONoteEntry" runat="server" ControlToValidate="txtDONoteEntry"
                                                                                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                                                                ErrorMessage="[Diary Data]/Date of Note Entry is Not Valid." Display="none" ValidationGroup="vsErrorGroupEdit"></asp:RegularExpressionValidator>
                                                                                                        </td>
                                                                                                        <td style="width: 25%;" align="left" class="lc">
                                                                                                            <asp:Label runat="server" ID="lblDiaryDate">Diary Date&nbsp;<span id="Span4" style="color: Red;
                                                                                                                display: none;" runat="server">*</span></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="Center" class="lc">
                                                                                                            :
                                                                                                        </td>
                                                                                                        <td style="width: 25%;" align="left" class="ic">
                                                                                                            <asp:TextBox runat="server" ID="txtDiaryDate"></asp:TextBox>
                                                                                                            <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvDiaryDetails_txtDiaryDate', 'mm/dd/y');"
                                                                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                                                                align="absmiddle" />
                                                                                                            <br />
                                                                                                            <asp:RequiredFieldValidator ID="rfvDiaryDate" ControlToValidate="txtDiaryDate" Display="none"
                                                                                                                Text="*" runat="server" InitialValue="" ValidationGroup="vsErrorGroupEdit" ErrorMessage="Please Select [Diary Data]/Diary Date."></asp:RequiredFieldValidator>
                                                                                                            <asp:RegularExpressionValidator ID="revDiaryDate" runat="server" ControlToValidate="txtDiaryDate"
                                                                                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                                                                ErrorMessage="[Diary Data]/Diary Date is Not Valid." Display="none" ValidationGroup="vsErrorGroupEdit"></asp:RegularExpressionValidator>
                                                                                                            <asp:CustomValidator ID="csmvtxtDiaryDate" runat="server" ControlToValidate="txtDiaryDate"
                                                                                                                ErrorMessage="[Diary Data]/Diary Date must not be greater than current date"
                                                                                                                ClientValidationFunction="CheckTodayDate" Display="none" ValidationGroup="vsErrorGroupEdit"
                                                                                                                Enabled="false">
                                                                                                            </asp:CustomValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="left" class="lc" style="width: 25%" valign="top">
                                                                                                            <asp:Label runat="server" ID="lblNote">Note&nbsp;<span id="Span5" style="color: Red;
                                                                                                                display: none;" runat="server">*</span></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="Center" class="lc" valign="top">
                                                                                                            :
                                                                                                        </td>
                                                                                                        <td align="left" class="ic" colspan="4" style="width: 75%;" valign="top">
                                                                                                            <asp:ImageButton ID="ibtnDisplay" ImageUrl="~/Images/Minus.jpg" runat="server" OnClientClick="javascript:return MinMax();" />
                                                                                                            <div id="pnlETemp" style="display: block;">
                                                                                                                <asp:TextBox runat="server" ID="txtNote" MaxLength="4000" Height="100px" TextMode="MultiLine"
                                                                                                                    Width="93%"></asp:TextBox>
                                                                                                            </div>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="left" class="lc" style="width: 25%" valign="top">
                                                                                                            <asp:Label runat="server" ID="lblClear"> Clear?</asp:Label>
                                                                                                        </td>
                                                                                                        <td align="Center" class="lc" valign="top">
                                                                                                            :
                                                                                                        </td>
                                                                                                        <td align="left" class="ic" style="width: 25%" valign="top">
                                                                                                            <asp:RadioButton runat="server" GroupName="Clear" ID="rbClearYes" Text="Yes" />&nbsp;
                                                                                                            <asp:RadioButton runat="server" GroupName="Clear" ID="rbClearNo" Checked="true" Text="No" />
                                                                                                        </td>
                                                                                                        <td align="left" class="lc" style="width: 25%" valign="top">
                                                                                                            <asp:Label runat="server" ID="lblAssignTo">Assigned To&nbsp;<span id="Span6" style="color: Red;
                                                                                                                display: none;" runat="server">*</span></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="Center" class="lc" valign="top">
                                                                                                            :
                                                                                                        </td>
                                                                                                        <td align="left" class="ic" style="width: 25%" valign="top">
                                                                                                            <asp:TextBox runat="server" ID="txtAssignTo" SkinID="txtDisabled" Width="70%"></asp:TextBox>&nbsp;
                                                                                                            <asp:Button ID="btnAssignTO" Text="V" runat="server" CssClass="btn" />
                                                                                                            <asp:RequiredFieldValidator ID="rfvAssignTo" ControlToValidate="txtAssignTo" runat="server"
                                                                                                                InitialValue="" ValidationGroup="vsErrorGroupEdit" ErrorMessage="Please Select [Diary Data]/Assigned To."
                                                                                                                Display="none" Text="*"></asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td colspan="6" style="display: none;" valign="top">
                                                                                                            <asp:TextBox runat="server" ID="txtAssignToID"></asp:TextBox>&nbsp;
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td colspan="6">
                                                                                                            &nbsp;
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td class="ic" align="center" colspan="6">
                                                                                                            <asp:Button runat="server" ID="btnSaveView" SkinID="btnGen" Text="Save & View" ValidationGroup="vsErrorGroupEdit"
                                                                                                                OnClick="btnSaveView_Click" />
                                                                                                            <asp:Button runat="server" ID="btnCancel" Text="Cancel" SkinID="btnGen" OnClick="btnCancel_Click"
                                                                                                                CausesValidation="false" />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <%--<tr>
                                                                                                <td align="center" class="lc" colspan="6">
                                                                                                     <asp:UpdateProgress runat="server">
                                                                                                        <ProgressTemplate>
                                                                                                           <span class="mf"> Mail sending process is going on, please wait...</span>
                                                                                                        </ProgressTemplate>
                                                                                                    </asp:UpdateProgress>
                                                                                                </td>
                                                                                            </tr>--%>
                                                                                                </table>
                                                                                            </div>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <table cellpadding="4" cellspacing="0" border="0" style="width: 100%;">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <div>
                                                                                                <table cellpadding="2" cellspacing="2" style="width: 100%;">
                                                                                                    <tr>
                                                                                                        <td align="left" colspan="6" class="ghc">
                                                                                                            Diary Information
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="width: 25%;" align="left" class="lc">
                                                                                                            <asp:Label runat="server" ID="lblDONEntry"> Date of Note Entry</asp:Label>
                                                                                                        </td>
                                                                                                        <td align="Center" class="lc">
                                                                                                            :
                                                                                                        </td>
                                                                                                        <td style="width: 25%;" align="left" class="ic">
                                                                                                            <asp:Label runat="server" ID="lblDONoteEntry"></asp:Label>
                                                                                                        </td>
                                                                                                        <td style="width: 25%;" align="left" class="lc">
                                                                                                            <asp:Label runat="server" ID="lblVDiaryDate"> Diary Date</asp:Label>
                                                                                                        </td>
                                                                                                        <td align="Center" class="lc">
                                                                                                            :
                                                                                                        </td>
                                                                                                        <td style="width: 25%;" align="left" class="ic">
                                                                                                            <asp:Label runat="server" ID="lblDiaryDate"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="left" class="lc" style="width: 25%;">
                                                                                                            <asp:Label runat="server" ID="lblVNote">Note</asp:Label>
                                                                                                        </td>
                                                                                                        <td align="Center" class="lc">
                                                                                                            :
                                                                                                        </td>
                                                                                                        <td align="left" class="ic" colspan="4">
                                                                                                            <asp:Label runat="server" ID="lblNote"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="left" class="lc" style="width: 25%;">
                                                                                                            <asp:Label runat="server" ID="lblVClear"> Clear?</asp:Label>
                                                                                                        </td>
                                                                                                        <td align="Center" class="lc">
                                                                                                            :
                                                                                                        </td>
                                                                                                        <td align="left" class="ic" style="width: 25%;">
                                                                                                            <asp:Label runat="server" ID="lblClear"></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="left" class="lc" style="width: 25%;">
                                                                                                            <asp:Label runat="server" ID="lblVAssignTo">Assigned To</asp:Label>
                                                                                                        </td>
                                                                                                        <td align="Center" class="lc">
                                                                                                            :
                                                                                                        </td>
                                                                                                        <td align="left" class="ic" style="width: 25%;">
                                                                                                            <asp:Label runat="server" ID="lblAssignTo"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td colspan="6">
                                                                                                            &nbsp;
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td class="ic" align="center" colspan="6">
                                                                                                            <asp:Button runat="server" ID="btnSaveView" SkinID="btnGen" Text="Save & View" Enabled="false"
                                                                                                                OnClick="btnSaveView_Click" CausesValidation="false" />
                                                                                                            <asp:Button runat="server" ID="btnCancel" Text="Cancel" SkinID="btnGen" OnClick="btnCancel_Click"
                                                                                                                CausesValidation="false" />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </div>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:FormView>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:View>
                                                    </asp:MultiView>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div id="divbtn" runat="server">
        <table style="width: 100%;">
            <tr>
                <td align="center" class="ic" style="height: 26px">
                    <asp:Label runat="server" ID="lbl" Text="df" Visible="false"></asp:Label>
                    <asp:Button runat="server" ID="btnNextStep" Text="Next Step" OnClick="btnNextStep_Click"
                        SkinID="btnGen" />
                </td>
            </tr>
        </table>
    </div>
    <div id="divView" runat="server" style="display: none;">
        <table cellpadding="4" cellspacing="2" border="0" style="width: 100%;">
            <tr>
                <td align="left" colspan="6" class="ghc">
                    Claim Details
                </td>
            </tr>
            <tr>
                <td width="20%" align="left" class="lc">
                    <asp:Label runat="server" ID="lblDClaimNo">Claim Number</asp:Label>
                </td>
                <td width="5%" align="Center" class="lc">
                    :
                </td>
                <td width="25%" align="left" class="ic">
                    <asp:Label runat="server" ID="lblVClaimNo"></asp:Label>
                </td>
                <td align="left" class="lc">
                    <asp:Label runat="server" ID="lblDDOIncident">Date of Incident</asp:Label>
                </td>
                <td align="Center" class="lc">
                    :
                </td>
                <td align="left" class="ic">
                    <asp:Label runat="server" ID="lblVDOInci"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" class="lc">
                    <asp:Label runat="server" ID="lblDLastName">Name</asp:Label>
                </td>
                <td align="Center" class="lc">
                    :
                </td>
                <td align="left" class="ic">
                    <asp:Label runat="server" ID="lblVName"></asp:Label>
                </td>
                <td width="20%" align="left" class="lc">
                    <asp:Label runat="server" ID="lblDEmployee">Employee</asp:Label>
                </td>
                <td width="5%" align="Center" class="lc">
                    :
                </td>
                <td width="25%" align="left" class="ic">
                    <asp:Label runat="server" ID="lblVEmployee"></asp:Label>
                </td>
                <%-- <td align="left" class="lc">
                    <asp:Label runat="server" ID="lblDFirstName"> First Name</asp:Label>
                </td>
                <td align="Center" class="lc">
                    :
                </td>
                <td align="left" class="ic">
                    <asp:Label runat="server" ID="lblVFirstName"></asp:Label>
                </td>--%>
            </tr>
            <%--<tr>
                <td align="left" class="lc">
                    <asp:Label runat="server" ID="lblDMiddleName">Middle Name</asp:Label>
                </td>
                <td align="Center" class="lc">
                    :
                </td>
                <td align="left" class="ic">
                    <asp:Label runat="server" ID="lblVMiddleMName"></asp:Label>
                </td>
                
            </tr>--%>
            <tr>
                <td class="lc">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:GridView runat="server" ID="gvViewAll" AutoGenerateColumns="false" Width="100%"
                        OnRowDataBound="gvViewAll_RowDataBound">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table cellpadding="4" cellspacing="0" width="100%">
                                        <tr>
                                            <td align="left" colspan="6" class="ghc">
                                                Diary Information
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" ID="lblDiaryID" Visible="false" Text='<%#Eval("PK_Diary_ID") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 20%;" align="left" class="lc">
                                                <asp:Label runat="server" ID="lblVLDONoteEntry">Date of Note Entry</asp:Label>
                                            </td>
                                            <td width="5%" align="Center" class="lc">
                                                :
                                            </td>
                                            <td width="25%" align="left" class="ic">
                                                <asp:Label runat="server" ID="lblVDoActivity" Text='<%# DataBinder.Eval(Container.DataItem,"DateOfNoteEntry","{0:MM/dd/yyyy}") %>'></asp:Label>
                                            </td>
                                            <td width="20%" align="left" class="lc">
                                                <asp:Label runat="server" ID="lblVLDiaryDate">Diary Date</asp:Label>
                                            </td>
                                            <td width="5%" align="Center" class="lc">
                                                :
                                            </td>
                                            <td width="25%" align="left" class="ic">
                                                <asp:Label runat="server" ID="lblVDate" Text='<%# DataBinder.Eval(Container.DataItem,"Diary_Date","{0:MM/dd/yyyy}") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="lc">
                                                <asp:Label runat="server" ID="lblVLNote">Note</asp:Label>
                                            </td>
                                            <td align="Center" class="lc">
                                                :
                                            </td>
                                            <td align="left" class="ic">
                                                <asp:Label runat="server" ID="lblVAuthor" Text='<%#Eval("Note") %>'></asp:Label>
                                            </td>
                                            <td align="left" class="lc">
                                                <asp:Label runat="server" ID="lblVLClear">Clear</asp:Label>
                                            </td>
                                            <td align="Center" class="lc">
                                                :
                                            </td>
                                            <td align="left" class="ic">
                                                <asp:Label runat="server" ID="lblVNoteType" Text='<%#Eval("Clear") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="lc">
                                                <asp:Label runat="server" ID="lblVLAssignTo"> Assigned To </asp:Label>
                                            </td>
                                            <td align="Center" class="lc">
                                                :
                                            </td>
                                            <td align="left" class="ic" colspan="4">
                                                <asp:Label runat="server" ID="lblVUpdateBy" Text='<%#Eval("Assigned_To") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerSettings Visible="false" />
                        <EmptyDataRowStyle ForeColor="red" HorizontalAlign="Center" />
                        <EmptyDataTemplate>
                            Currently there is no Diary for the following claim.
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" colspan="6">
                    <asp:Button runat="server" ID="btnViewNext" OnClick="btnViewNext_Click" Text="Next Step" />
                </td>
            </tr>
        </table>
    </div>
    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
        Display="None" ValidationGroup="vsErrorGroupInsert" />
    <input id="hdnControlIDs" runat="server" type="hidden" />
    <input id="hdnErrorMsgs" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFieldsUpdate"
        Display="None" ValidationGroup="vsErrorGroupEdit" />
    <input id="hdnControlUpdateIDs" runat="server" type="hidden" />
    <input id="hdnUpdateErrorMsgs" runat="server" type="hidden" />
</asp:Content>
