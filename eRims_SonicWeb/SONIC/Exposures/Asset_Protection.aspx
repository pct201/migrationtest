<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="Asset_Protection.aspx.cs" Inherits="SONIC_Exposures_AssetProtection" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/ExposuresTab/ExposuresTab.ascx" TagName="CtlTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/NotesWithSpellCheck/Notes.ascx" TagName="ctrlMultiLineTextBox"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<%--<%@ Register Src="~/Controls/Attachment_AssetProtection/Attachment.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>--%>
<%@ Register Src="~/Controls/Attachment_AssetProtection/Attachment_Folder.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%--<%@ Register Src="~/Controls/Attachment_AssetProtection/Attachment_Detail.ascx" TagName="ctrlAttachmentDetail"
    TagPrefix="uc" %>--%>
<%@ Register Src="~/Controls/SonicClaimNotes/SonicNotes.ascx" TagName="ctrlSonicNotes"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/SonicClaimNotes/AdjusterNotes.ascx" TagName="CtrlAdjusterNotes"
    TagPrefix="uc" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="Content1" runat="server">
    <script type="text/javascript" src="../../JavaScript/JFunctions.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript">
        var CheckChangeVal = false;
        var ActiveTabIndex = 1;

        function formatCurrencyOnBlur(ctrl) {
            if (ctrl.value != '') {
                var val = ctrl.value.replace(",", "").replace(",", "");
                ctrl.value = formatCurrency(val).replace("$", "");
            }
        }

        
        function onNextStep() {
            if (ActiveTabIndex == 6) {
                return ValSave();
            }
            else {
                ActiveTabIndex = ActiveTabIndex + 1;
                ShowPanel(ActiveTabIndex);
                return false;
            }
        }

        function onPreviousStep() {
            ActiveTabIndex = ActiveTabIndex - 1;
            document.getElementById("ctl00_ContentPlaceHolder1_hdnPanel").value = ActiveTabIndex;
            ShowPanel(ActiveTabIndex);
            return false;
        }

        function SetMenuStyle(index) {
            var i;
            for (i = 1; i <= 6; i++) {
                var tb = document.getElementById("Menu" + i);
                if (i == index) {
                    tb.className = "LeftMenuSelected";
                    tb.onmouseover = function () { this.className = 'LeftMenuSelected'; }
                    tb.onmouseout = function () { this.className = 'LeftMenuSelected'; }
                }
                else {
                    tb.className = "LeftMenuStatic";
                    tb.onmouseover = function () { this.className = 'LeftMenuHover'; }
                    tb.onmouseout = function () { this.className = 'LeftMenuStatic'; }
                }
            }
        }


        function FormatInteger(e) {
            if (e.keyCode >= 48 && e.keyCode <= 57) {
                return true;
            }
            else {
                return false;
            }
        }

        function ShowPanel(index) {
            SetMenuStyle(index);
            ActiveTabIndex = index;
            document.getElementById('<%= hdnPanel.ClientID %>').value = ActiveTabIndex;
            SetHeaderLabel(ActiveTabIndex);
            var op = '<%=StrOperation%>';
            if (op == "view") {
                document.getElementById('<%= dvEdit.ClientID %>').style.display = "none";
                document.getElementById('<%= dvView.ClientID %>').style.display = "";
                ShowPanelView(index);
            }
            else {
                var i;
                for (i = 1; i <= 5; i++) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display = (i == index) ? "block" : "none";
                    TextChange();
                }
                if (index == 1) {
                    document.getElementById('<%=dvProperty_SecuritySave.ClientID%>').style.display = ""; document.getElementById('<%=btnPrevoius.ClientID%>').style.display = "none";
                }
                else { document.getElementById('<%=dvProperty_SecuritySave.ClientID%>').style.display = "none"; document.getElementById('<%=btnPrevoius.ClientID%>').style.display = ""; }
                if (index == 2) { document.getElementById('<%= dvDPD_Save.ClientID %>').style.display = ""; }
                else { document.getElementById('<%= dvDPD_Save.ClientID %>').style.display = "none"; }
                if (index == 3) { document.getElementById('<%= dvAL_Save.ClientID %>').style.display = ""; }
                else { document.getElementById('<%= dvAL_Save.ClientID %>').style.display = "none"; }
                if (index == 4) { document.getElementById('<%=dvCal_Grid.ClientID%>').style.display = ""; document.getElementById('<%=dvCalAtlanticSave.ClientID%>').style.display = ""; }
                else { document.getElementById('<%=dvCal_Grid.ClientID%>').style.display = "none"; document.getElementById('<%=dvCalAtlanticSave.ClientID%>').style.display = "none"; }
                if (index == 5) document.getElementById('<%=dvFraudEventSave.ClientID%>').style.display = "";
                else document.getElementById('<%=dvFraudEventSave.ClientID%>').style.display = "none";
                if (index == 6) {
                    document.getElementById('<%=btnNext.ClientID%>').style.display = "none";
                    
                    document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "block";
                    document.getElementById("<%=btnGenerate_Abstract.ClientID%>").style.display = "none";
                }
                else {
                    document.getElementById('<%=btnNext.ClientID%>').style.display = "";
                    
                    document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "none";
                    document.getElementById("<%=btnGenerate_Abstract.ClientID%>").style.display = "";

                    if ('<%=ViewState["PK_AP_Property_Security"]%>' == "0")
                        document.getElementById("<%=btnGenerate_Abstract.ClientID%>").style.display = "none";
                    else
                        document.getElementById("<%=btnGenerate_Abstract.ClientID%>").style.display = "";
                }
            }


        }

        function ShowPanelView(index) {
            SetMenuStyle(index);
            document.getElementById('<%=dvView.ClientID%>').style.display = "block";
            var i;
            for (i = 1; i <= 5; i++) {
                document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i + "View").style.display = (i == index) ? "block" : "none";
            }

            if (index == 1) { document.getElementById('<%=btnPrevoius.ClientID%>').style.display = "none"; }
            else { document.getElementById('<%=btnPrevoius.ClientID%>').style.display = ""; }
            if (index == 6) {
                document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "block";
                document.getElementById("<%=btnNext.ClientID%>").style.display = "none";
                document.getElementById("<%=btnGenerate_Abstract.ClientID%>").style.display = "none";
            }
            else {
                document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "none";
                document.getElementById("<%=btnNext.ClientID%>").style.display = "";
                document.getElementById("<%=btnGenerate_Abstract.ClientID%>").style.display = "";

                if ('<%=ViewState["PK_AP_Property_Security"]%>' == "0")
                    document.getElementById("<%=btnGenerate_Abstract.ClientID%>").style.display = "none";
                else
                    document.getElementById("<%=btnGenerate_Abstract.ClientID%>").style.display = "";
            }
        }
        function TextChange() {
            var arrElements = document.getElementsByTagName('input');
            for (i = 0; i < arrElements.length; i++) {
                if (arrElements[i].type == 'text' && arrElements[i].id.indexOf('txtPageNumber') <= -1 && arrElements[i].id != 'ctl00_ContentPlaceHolder1_txtCap_Index_Crime_Score')
                    arrElements[i].onchange = OnChangeFunction;
                if (arrElements[i].type == 'textarea')
                    arrElements[i].onchange = OnChangeFunction;
                if (arrElements[i].type == 'radio')
                    arrElements[i].onchange = OnChangeFunction;
            }
            var arrElements_Select = document.getElementsByTagName('select');
            for (i = 0; i < arrElements_Select.length; i++) {
                if (arrElements_Select[i].type == 'select-one' && arrElements_Select[i].id.indexOf('drpRecords') <= -1)
                    arrElements_Select[i].onchange = OnChangeFunction;
            }
        }

        function OnChangeFunction() {
            if (CheckChangeVal == false)
                CheckChangeVal = true;
        }
        function SetHeaderLabel(Panelid) {
            if (Panelid == 1) {
                document.getElementById('<%= lblPanelDesc.ClientID %>').innerHTML = 'Asset Protection – Property Security';
            }
            else if (Panelid == 2) {
                document.getElementById('<%= lblPanelDesc.ClientID %>').innerHTML = 'Asset Management – Dealer Physical Damage FROIs';
            }
            else if (Panelid == 3) {
                document.getElementById('<%= lblPanelDesc.ClientID %>').innerHTML = 'Asset Management – Auto Liability FROIs';
            }
            else if (Panelid == 4) {
                document.getElementById('<%= lblPanelDesc.ClientID %>').innerHTML = 'Asset Management – ACI';<%--Change Header text from Cal Atlantic to ACI as per client's request Bug ID = 2552--%>
            }
            else if (Panelid == 5) {
                document.getElementById('<%= lblPanelDesc.ClientID %>').innerHTML = 'Asset Management – Fraud Events';
            }
            else if (Panelid == 6) {
                document.getElementById('<%= lblPanelDesc.ClientID %>').innerHTML = 'Asset Management – Attachments';
            }
}

function CheckValueChange(Panelid, IndexVal) {
    SetHeaderLabel(Panelid);
    if (CheckChangeVal == true) {
        if (confirm('Do you want to save your changes before leaving this screen?')) {
            CheckChangeVal = false;
            if (SetValidationGroup() == true) {
                __doPostBack("SaveBeforePanelChange", Panelid.toString());
                return false;
            }
        }
        else {
            CheckChangeVal = false;
            if (Panelid != null)
                ShowPanel(Panelid);
            if (IndexVal != null)
                ShowPrevNext(IndexVal);
        }
    }
    else {
        if (Panelid != null)
            ShowPanel(Panelid);
        if (IndexVal != null)
            ShowPrevNext(IndexVal);
    }
}

function OpenClaimNotes(Pk_Claim_Notes, FK_Claim) {
    var winHeight = window.screen.availHeight - 200;
    var winWidth = window.screen.availWidth - 400;

    obj = window.open("SONIC/ClaimInfo/ClaimNotes.aspx?id=" + Pk_Claim_Notes + "&FK_Claim=" + FK_Claim + "&tbl=DPDClaim", 'PopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
    obj.focus();
    return false;
}

function OpenClaimNotesView(Pk_Claim_Notes, FK_Claim) {
    var winHeight = window.screen.availHeight - 200;
    var winWidth = window.screen.availWidth - 400;

    obj = window.open("SONIC/ClaimInfo/ClaimNotes.aspx?id=" + Pk_Claim_Notes + "&FK_Claim=" + FK_Claim + "&op=view", 'PopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
    obj.focus();
    return false;
}

function openAP_Propert_SecurtyPopup() {
    var winHeight = window.screen.availHeight - 300;
    var winWidth = window.screen.availWidth - 315;


    obj = window.open("AuditPopup_AP_Property_Security.aspx?id=" + '<%=ViewState["PK_AP_Property_Security"]%>', 'PopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
    obj.focus();
    return false;
}

function openAP_Propert_Securty_FinancialPopup() {
    var winHeight = window.screen.availHeight - 300;
    var winWidth = window.screen.availWidth - 500;


    obj = window.open("AuditPopup_AP_Property_Security_Financials.aspx?id=" + '<%=ViewState["PK_AP_Property_Security"]%>', 'PopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
    obj.focus();
    return false;
}

function openAuditPopup() {
    var winHeight = window.screen.availHeight - 300;
    var winWidth = window.screen.availWidth - 315;

    obj = window.open("Audit_Popup_AP_DPD_FROIs.aspx?id=" + '<%=ViewState["PK_AP_DPD_FROIs"]%>', 'PopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }

        function openAP_FE_Notes_AuditPopup() {
            var oWnd = window.open("AuditPopup_AP_FE_Notes.aspx?id=" + '<%=ViewState["PK_AP_FE_Notes"]%>', "Erims", "location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=807,height=400");
    oWnd.moveTo(350, 200);
    return false;
}

function openAP_FE_PA_Notes_AuditPopup() {
    var oWnd = window.open("AuditPopup_AP_FE_PA_Notes.aspx?id=" + '<%=ViewState["PK_AP_FE_PA_Notes"]%>', "Erims", "location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=807,height=400");
            oWnd.moveTo(350, 200);
            return false;
        }

        function openAP_Cal_Atlantic_AuditPopup() {
            var winHeight = window.screen.availHeight - 370;
            var winWidth = window.screen.availWidth - 315;

            obj = window.open("AuditPopup_AP_Cal_Atlantic.aspx?id=" + '<%=ViewState["PK_AP_Cal_Atlantic"]%>', 'PopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
    obj.focus();
    return false;
}

function openFraud_Event_AuditPopup() {
    var winHeight = window.screen.availHeight - 300;
    var winWidth = window.screen.availWidth - 315;

    obj = window.open("AuditPopup_AP_Fraud_Events.aspx?id=" + '<%=ViewState["PK_AP_Fraud_Events"]%>', 'PopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=2,menubar=0');
    obj.focus();
    return false;
}

function openAP_FE_Transaction_AuditPopup() {
    var oWnd = window.open("AuditPopup_AP_FE_Transactions.aspx?id=" + '<%=ViewState["PK_AP_FE_Transactions"]%>', "Erims", "location=0,status=0,scrollbars=0,menubar=0,resizable=0,toolbar=0,width=1145,height=450");
    oWnd.moveTo(200, 200);
    return false;
}

function AuditPopUp() {
    var winHeight = window.screen.availHeight - 300;
    if (window.screen.availHeight == 728) {
        winHeight = winHeight + 20;
    }
    var winWidth = window.screen.availWidth - 200;
    obj = window.open("AuditPopup_AP_AL_FROIs.aspx?id=" + '<%=ViewState["PK_AP_AL_FROIs"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
    obj.focus();
    return false;
}

function OpenClaimNotes(PK_Auto_Loss_Claims_ID) {
    var winHeight = window.screen.availHeight - 200;
    var winWidth = window.screen.availWidth - 400;
    obj = window.open("<%=AppConfig.SiteURL%>SONIC/ClaimInfo/ALClaimInfo.aspx?id=" + PK_Auto_Loss_Claims_ID + "&pnl=4", 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
    obj.focus();

    return false;
}

function openGenereteAbstract() {

    var winHeight = window.screen.availHeight - 600;
    var winWidth = window.screen.availWidth - 1000;
    var PKID = 0;
    var VehicleId = 0;
    if (document.getElementById('<%= hdnPanel.ClientID %>').value == 1) {
                PKID = '<%=ViewState["PK_AP_Property_Security"]%>';
            }
            if (document.getElementById('<%= hdnPanel.ClientID %>').value == 2) {
                PKID = '<%=ViewState["FK_DPD_FR_ID"]%>';
                VehicleId = '<%=ViewState["FK_DPD_FR_Vehicle_ID"]%>';
            }
            else if (document.getElementById('<%= hdnPanel.ClientID %>').value == 3) {
                PKID = '<%=ViewState["FK_AL_FR_ID"]%>';
            }
            else if (document.getElementById('<%= hdnPanel.ClientID %>').value == 4) {
                PKID = '<%=ViewState["PK_AP_Cal_Atlantic"]%>';
            }
            else if (document.getElementById('<%= hdnPanel.ClientID %>').value == 5) {
                PKID = '<%=ViewState["PK_AP_Fraud_Events"]%>';
            }

    obj = window.open("Asset_Protection_Generate_Abstract.aspx?id=" + '<%=ViewState["LocationID"]  %>' + "&ps_id=" + '<%= ViewState["PK_AP_Property_Security"] %>' + "&panel=" + document.getElementById('<%= hdnPanel.ClientID %>').value + "&PKID=" + PKID + "&VID=" + VehicleId, 'PopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }

        function IsValidMonitorTime() {
            Page_ClientValidate("vsAddPSMonitor");
            if (Page_IsValid) {
                var endDay = $("#<%= ddlDayMonitoringEnds.ClientID %> :selected").val();
                var startDay = $("#<%= ddlDayMonitoringBegins.ClientID %> :selected").val();

                if (endDay < startDay) {
                    endDay = (parseInt(endDay, 10) + 7);
                }
                var CompareEndDay = (endDay - startDay + 1);
                var MonitoringEndTime = $("#<%= txtTimeMonitoringEnds.ClientID %>").val();
                var MonitoringBeginTime = $("#<%= txtTimeMonitoringBegins.ClientID %>").val();
                var startdate1 = new Date("January 01, 1999 " + MonitoringBeginTime + ":00");
                var enddate1 = new Date("January 0" + CompareEndDay + ", 1999 " + MonitoringEndTime + ":00");
                var diff = enddate1 - startdate1;
                var seconds = Math.floor(diff / 1000); //ignore any left over units smaller than a second
                var minutes = Math.floor(seconds / 60);
                seconds = seconds % 60;
                var hours = Math.floor(minutes / 60);
                minutes = minutes % 60;
                if (hours == "NaN") {
                    alert('Enter valid values');
                    return false;
                }
                if (hours < 0) {
                    alert('End Time should greater than start time');
                    return false;
                }
                if (hours < 10) {
                    hours = "0" + hours;
                }
                if (minutes < 10) {
                    minutes = "0" + minutes;
                }
                if (hours > 23) {
                    var r = confirm("The entered monitoring time period is " + hours + ":" + minutes + " hours, is this the desired entry?");
                    if (r == true) {
                        document.getElementById('<%= txtMonitoringPeriodHours.ClientID %>').value = hours + ":" + minutes;
                    }
                    else {
                        return false;
                    }
                }
                else {
                    document.getElementById('<%= txtMonitoringPeriodHours.ClientID %>').value = hours + ":" + minutes;
                }
            }
            else {
                return false;
            }
        }

        function SetRiskCategory() {
            var Cap_Index_Crime_Score = (document.getElementById('<%=txtCap_Index_Crime_Score.ClientID %>'));
            var Cap_Index_Risk_Category = (document.getElementById('<%=ddlCap_Index_Risk_Category.ClientID %>'));

            if (Cap_Index_Crime_Score.value != "") {
                if (Cap_Index_Crime_Score.value >= 0 && Cap_Index_Crime_Score.value <= 99) {
                    Cap_Index_Risk_Category.selectedIndex = 5;
                }
                else if (Cap_Index_Crime_Score.value >= 100 && Cap_Index_Crime_Score.value <= 199) {
                    Cap_Index_Risk_Category.selectedIndex = 4;
                }
                else if (Cap_Index_Crime_Score.value >= 200 && Cap_Index_Crime_Score.value <= 399) {
                    Cap_Index_Risk_Category.selectedIndex = 3;
                }
                else if (Cap_Index_Crime_Score.value >= 400 && Cap_Index_Crime_Score.value <= 799) {
                    Cap_Index_Risk_Category.selectedIndex = 2;
                }
                else if (Cap_Index_Crime_Score.value >= 800 && Cap_Index_Crime_Score.value <= 2000) {
                    Cap_Index_Risk_Category.selectedIndex = 1;
                }
                else {
                    Cap_Index_Crime_Score.value = 0;
                    Cap_Index_Risk_Category.selectedIndex = 0;
                    alert('range must be between 0 to 2000');
                }
            }
        }
       
    </script>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorProperty_Security" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="false"
            ShowMessageBox="true" HeaderText="Verify the following fields:" BorderWidth="1"
            BorderColor="DimGray" ValidationGroup="vsErrorDPD_FROIs" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowSummary="false"
            ShowMessageBox="true" HeaderText="Verify the following fields:" BorderWidth="1"
            BorderColor="DimGray" ValidationGroup="vsErrorAL_FROIs" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowSummary="false"
            ShowMessageBox="true" HeaderText="Verify the following fields:" BorderWidth="1"
            BorderColor="DimGray" ValidationGroup="vsErrorCalAtlantic" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="ValidationSummary4" runat="server" ShowSummary="false"
            ShowMessageBox="true" HeaderText="Verify the following fields:" BorderWidth="1"
            BorderColor="DimGray" ValidationGroup="vsErrorFraudEvents" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="ValidationSummary5" runat="server" ShowSummary="false"
            ShowMessageBox="true" HeaderText="Verify the following fields:" BorderWidth="1"
            BorderColor="DimGray" ValidationGroup="vsErrorFraudEventsNotes" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="ValidationSummary6" runat="server" ShowSummary="false"
            ShowMessageBox="true" HeaderText="Verify the following fields:" BorderWidth="1"
            BorderColor="DimGray" ValidationGroup="vsErrorFraudEventsTransaction" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="ValidationSummary7" runat="server" ShowSummary="false"
            ShowMessageBox="true" HeaderText="Verify the following fields:" BorderWidth="1"
            BorderColor="DimGray" ValidationGroup="vsAddPSMonitor" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100%" style="height: 50px;" valign="bottom" colspan="2">
                <uc:CtlTab runat="server" ID="Tab"></uc:CtlTab>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="Spacer" style="height: 15px;" colspan="2"></td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" colspan="2">
                            <table style="background-color: black" cellspacing="1" cellpadding="3" width="100%"
                                border="0">
                                <tbody>
                                    <tr class="PropertyInfoBG">
                                        <td style="width: 19%" align="left">
                                            <asp:Label ID="lblHeaderLocationNumber" runat="server" Text="Location Number"></asp:Label>
                                        </td>
                                        <td style="width: 23%" align="left">
                                            <asp:Label ID="lblHeaderLocationdba" runat="server" Text="SONIC Location d/b/a"></asp:Label>
                                        </td>
                                        <td style="width: 16%" align="left">
                                            <asp:Label ID="lblHeaderAddress" runat="server" Text="Address"></asp:Label>
                                        </td>
                                        <td style="width: 16%" align="left">
                                            <asp:Label ID="lblHeaderCity" runat="server" Text="City"></asp:Label>
                                        </td>
                                        <td style="width: 16%" align="left">
                                            <asp:Label ID="lblHeaderState" runat="server" Text="State"></asp:Label>
                                        </td>
                                        <td style="width: 10%" align="left">
                                            <asp:Label ID="lblHeaderZip" runat="server" Text="Zip"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="background-color: white">
                                        <td align="left">
                                            <asp:Label ID="lblLocation_Number" runat="server">&nbsp;</asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblLocationdba" runat="server"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblAddress" runat="server"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblCity" runat="server"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblState" runat="server" />
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblZip" runat="server" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" style="height: 10px;" colspan="2"></td>
                    </tr>
                    <tr>
                        <td class="ghc" align="left" colspan="2">
                            <asp:Label ID="lblPanelDesc" runat="server" Text="Asset Protection – Property Security" />
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" style="height: 10px;" colspan="2"></td>
                    </tr>
                    <tr>
                        <td class="leftMenu">
                            <table cellpadding="5" cellspacing="0" width="100%">
                                <tr>
                                    <td style="height: 18px;" class="Spacer"></td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu1" onclick="javascript:CheckValueChange(1,null);" class="LeftMenuStatic">Property Security&nbsp;<span id="MenuAsterisk1" runat="server" style="color: Red; display: none">*</span></span>
                                    </td>
                                    <tr>
                                        <td align="left" width="100%">
                                            <span id="Menu2" onclick="javascript:CheckValueChange(2,null);" class="LeftMenuStatic">DPD FROIs&nbsp;<span id="MenuAsterisk2" runat="server" style="color: Red; display: none">*</span></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" width="100%">
                                            <span id="Menu3" onclick="javascript:CheckValueChange(3,null);" class="LeftMenuStatic">AL FROIs&nbsp;<span id="MenuAsterisk3" runat="server" style="color: Red; display: none">*</span></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" width="100%">
                                            <span id="Menu4" onclick="javascript:CheckValueChange(4,null);" class="LeftMenuStatic">ACI&nbsp;<span id="MenuAsterisk4" runat="server" style="color: Red; display: none">*</span></span>
                                            <%--Change Header text from Cal Atlantic to ACI as per client's request Bug ID = 2552--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" width="100%">
                                            <span id="Menu5" onclick="javascript:CheckValueChange(5,null);" class="LeftMenuStatic">Fraud Events&nbsp;<span id="MenuAsterisk5" runat="server" style="color: Red; display: none">*</span></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" width="100%">
                                            <span id="Menu6" onclick="javascript:CheckValueChange(6,null);" class="LeftMenuStatic">Attachments</span>
                                        </td>
                                    </tr>
                                </tr>
                            </table>
                        </td>
                        <td valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td width="5px" class="Spacer">&nbsp;
                                    </td>
                                    <td class="dvContainer">
                                        <div id="dvEdit" runat="server" width="794px">
                                            <asp:Panel ID="pnl1" runat="server" Style="display: none;" Width="794px">
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%" id="tblMainPropertySecurity"
                                                    runat="server">
                                                    <tr>
                                                        <td colspan="6">
                                                            <strong>CCTV Alarm Systems</strong>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">CCTV Company Name&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:TextBox ID="txtCCTV_Company_Name" runat="server" Width="563px" MaxLength="150" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">CCTV Company Address 1&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtCCTV_Company_Address_1" runat="server" Width="170px" MaxLength="100" />
                                                        </td>
                                                        <td align="left" valign="top" width="18%">CCTV Company Address 2&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="28%">
                                                            <asp:TextBox ID="txtCCTV_Company_Address_2" runat="server" Width="170px" MaxLength="100" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">CCTV Company City&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtCCTV_Company_City" runat="server" Width="170px" MaxLength="50" />
                                                        </td>
                                                        <td align="left" valign="top">CCTV Company State&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="drpFK_CCTV_Company_State" Width="175px" runat="server" SkinID="dropGen">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">CCTV Company Zip&nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                                                            <br />
                                                            (99999-9999)
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtCCTV_Company_Zip" runat="server" Width="170px" MaxLength="10"
                                                                SkinID="txtZipCode" onKeyPress="javascript:return FormatZipCode(event,this.id);" />
                                                            <asp:RegularExpressionValidator ID="revtxtCCTV_Company_Zip" runat="server" ErrorMessage="[Property Security]/CCTV Company Zip is not valid"
                                                                SetFocusOnError="true" ControlToValidate="txtCCTV_Company_Zip" ValidationExpression="\b[0-9]{5}-[0-9]{4}\b|\b[0-9]{5}\b"
                                                                ValidationGroup="vsErrorProperty_Security" Display="none" />
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">CCTV Company Contact Name&nbsp;<span id="Span7" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtCCTV_Company_Contact_Name" runat="server" Width="170px" MaxLength="50" />
                                                        </td>
                                                        <td align="left" valign="top">CCTV Company Contact Telephone&nbsp;<span id="Span8" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                            <br />
                                                            (999-999-9999)
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtCCTV_Comapny_Contact_Telephone" runat="server" Width="170px"
                                                                MaxLength="12" onKeyPress="javascript:return FormatPhone(event,this.id);" />
                                                            <asp:RegularExpressionValidator ID="revtxtCCTV_Comapny_Contact_Telephone" ControlToValidate="txtCCTV_Comapny_Contact_Telephone"
                                                                runat="server" ErrorMessage="Please Enter [Property Security]/CCTV Company Contact Telephone in XXX-XXX-XXXX format."
                                                                ValidationGroup="vsErrorProperty_Security" Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">CCTV Company Contact E-Mail&nbsp;<span id="Span9" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" width="78%" valign="top" colspan="4">
                                                            <asp:TextBox ID="txtCCTV_Company_Contact_EMail" runat="server" Width="563px" MaxLength="255" />
                                                            <asp:RegularExpressionValidator ID="RegtxtCCTV_Company_Contact_EMail" runat="server"
                                                                ControlToValidate="txtCCTV_Company_Contact_EMail" Display="None" ErrorMessage="Please Enter Valid [Property Security]/CCTV Company Contact E-Mail Address"
                                                                SetFocusOnError="True" ValidationGroup="vsErrorProperty_Security" ToolTip="Please Enter Valid [Property Security]/CCTV Company Contact E-Mail Address"
                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">ACI System <%--Change Header text from Cal Atlantic to ACI as per client's request Bug ID = 2552--%>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList ID="rdoCal_Atlantic_System" runat="server" SkinID="YesNoType">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Live Monitoring
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList ID="rdoLive_Monitoring" runat="server" SkinID="YesNoType">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">CCTV Hours Monitoring Grid<br />
                                                            <asp:LinkButton ID="lnkbtnAddCCTVHoursMonitoringGrid" runat="server" Text="--Add--"
                                                                OnClick="lnkbtnAddCCTVHoursMonitoringGrid_Click" CausesValidation="true" ValidationGroup="vsErrorProperty_Security"></asp:LinkButton>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:GridView ID="gvCCTVHoursMonitoringGrid" runat="server" GridLines="None" CellPadding="4"
                                                                CellSpacing="0" AutoGenerateColumns="false" Width="100%" EnableTheming="false"
                                                                OnRowCommand="gvMonitoingGrid_RowCommand">
                                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <RowStyle BackColor="#EAEAEA" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <EditRowStyle BackColor="#2461BF" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <PagerStyle BackColor="#7f7f7f" ForeColor="White" HorizontalAlign="Center" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <HeaderStyle BackColor="#7f7f7f" Font-Bold="True" ForeColor="White" Font-Names="Tahoma"
                                                                    Font-Size="8pt" VerticalAlign="Bottom" />
                                                                <AlternatingRowStyle BackColor="White" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <EmptyDataRowStyle CssClass="emptyrow" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Day Monitoring Begins" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnDayMonitoringBegins" runat="server" CommandName="gvEdit"
                                                                                CommandArgument='<%# Eval("PK_AP_Property_Security_Monitor_Grids") %>'> 
                                                                            <%# Eval("Start_Day")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Time Monitoring Begins" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnTimeMonitoringBegins" runat="server" CommandName="gvEdit"
                                                                                CommandArgument='<%# Eval("PK_AP_Property_Security_Monitor_Grids") %>'> 
                                                                                <%# Eval("Start_Time")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Day Monitoring Ends" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnDayMonitoringEnds" runat="server" CommandName="gvEdit"
                                                                                CommandArgument='<%# Eval("PK_AP_Property_Security_Monitor_Grids") %>'> 
                                                                                <%# Eval("End_Day")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Time Monitoring Ends" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnTimeMonitoringEnds" runat="server" CommandName="gvEdit"
                                                                                CommandArgument='<%# Eval("PK_AP_Property_Security_Monitor_Grids") %>'> 
                                                                                <%# Eval("End_Time")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Hours" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnHours" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_AP_Property_Security_Monitor_Grids") %>'> 
                                                                                <%# Eval("Hours")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnRemove" runat="server" Text="Remove" OnClientClick="return confirm('Are you Sure to delete this record?');"
                                                                                CommandName="Remove" CommandArgument='<%# Eval("PK_AP_Property_Security_Monitor_Grids") %>'> 
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                                <EmptyDataTemplate>
                                                                    <b>No Record found</b>
                                                                </EmptyDataTemplate>
                                                                <PagerSettings Visible="False" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Exterior Camera Coverage
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkEccBack" runat="server" Text="Back" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkEccCarwash" runat="server" Text="Car Wash" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkEccFront" runat="server" Text="Front" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkEccsatelliteParking" runat="server" Text="Satellite Parking" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkEccSide" runat="server" Text="Side" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkEccZerodotLine" runat="server" Text="Zero Lot Line (Showroom)" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkEccOther" runat="server" Text="Other" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <table>
                                                                            <tr>
                                                                                <td align="left" valign="top">Number of External Cameras&nbsp;<span id="Span143" style="color: Red; display: none;" runat="server">*</span>  
                                                                                </td>
                                                                                <td align="center" valign="top">:&nbsp;&nbsp;&nbsp;
                                                                                </td>
                                                                                <td align="left" valign="top"> 
                                                                                    <asp:TextBox ID="txtNumberOfExternalCameras" runat="server" Width="150px" SkinID="txtAmt" onpaste="return false" Maxlength="9"
                                                                                        onkeypress="return FormatNumber(event,this.id,11,false,true);"  />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Exterior Camera Coverage – Other Description&nbsp;<span id="Span12" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtExterior_Camera_Coverage_Other_Description" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Interior Camera Coverage
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkIccBodyShop" runat="server" Text="Body Shop" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkIccCashier" runat="server" Text="Cashier" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkIccComputerRoom" runat="server" Text="Computer Room" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkIccDetailBays" runat="server" Text="Detail Bays" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkIccKeyBoxArea" runat="server" Text="Key Box Area" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkIccPartsReceivingArea" runat="server" Text="Part Receiving Area" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkIccServiceDepartment" runat="server" Text="Service Department" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkIccServiceLane" runat="server" Text="Service Lane" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkIccShowRoom" runat="server" Text="Showroom" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkIccSmartSafeOffice" runat="server" Text="Smart Safe Office" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkIccOther" runat="server" Text="Other" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <table>
                                                                            <tr>
                                                                                <td align="left" valign="top">Number of Internal Cameras&nbsp;<span id="Span144" style="color: Red; display: none;" runat="server">*</span>      
                                                                                </td>
                                                                                <td align="center" valign="top">:&nbsp;&nbsp;&nbsp;
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:TextBox ID="txtNumberofInternalCameras" runat="server" Width="150px" onpaste="return false" MaxLength="9" onkeypress="return FormatNumber(event,this.id,11,false,true);"   />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Interior Camera Coverage – Other Description&nbsp;<span id="Span13" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtInterior_Camera_Coverage_Other_Description" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="5px" class="Spacer">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <strong>Burglar Alarm Coverage</strong>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Burglar Alarm System
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList ID="rdoBuglar_Alarm_System" runat="server" SkinID="YesNoType">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left" valign="top">Is System Active and Functioning Properly?
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList ID="rdoIs_System_Active_and_Function_Properly" runat="server"
                                                                SkinID="YesNoType">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Burglar Alarm Company Name&nbsp;<span id="Span14" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:TextBox ID="txtBurglar_Alarm_Company_Name" runat="server" Width="563px" MaxLength="150" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Burglar Alarm Company Address 1&nbsp;<span id="Span15" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtBurglar_Alarm_Company_Address_1" runat="server" Width="170px"
                                                                MaxLength="100" />
                                                        </td>
                                                        <td align="left" valign="top">Burglar Alarm Company Address 2&nbsp;<span id="Span16" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtBurglar_Alarm_Company_Address_2" runat="server" Width="170px"
                                                                MaxLength="100" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Burglar Alarm Company City&nbsp;<span id="Span17" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtBurglar_Alarm_Company_City" runat="server" Width="170px" MaxLength="50" />
                                                        </td>
                                                        <td align="left" valign="top">Burglar Alarm Company State&nbsp;<span id="Span18" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="drpFK_Burglar_Alarm_Company_State" Width="175px" runat="server"
                                                                SkinID="dropGen">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Burglar Alarm Company Zip&nbsp;<span id="Span19" style="color: Red; display: none;"
                                                            runat="server">*</span><br />
                                                            (99999-9999)
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtBurglar_Alarm_Company_Zip" runat="server" Width="170px" SkinID="txtZipCode"
                                                                MaxLength="10" onKeyPress="javascript:return FormatZipCode(event,this.id);" />
                                                            <asp:RegularExpressionValidator ID="revtxtBurglar_Alarm_Company_Zip" runat="server"
                                                                ErrorMessage="[Property Security]/Burglar Alarm Company Zip is not valid" SetFocusOnError="true"
                                                                ControlToValidate="txtBurglar_Alarm_Company_Zip" ValidationExpression="\b[0-9]{5}-[0-9]{4}\b|\b[0-9]{5}\b"
                                                                ValidationGroup="vsErrorProperty_Security" Display="none" />
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Burglar Alarm Company Contact Name&nbsp;<span id="Span20" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtBurglar_Alarm_Company_Contact_Name" runat="server" Width="170px"
                                                                MaxLength="50" />
                                                        </td>
                                                        <td align="left" valign="top">Burglar Alarm Company Contact Telephone&nbsp;<span id="Span21" style="color: Red; display: none;"
                                                            runat="server">*</span><br />
                                                            (999-999-9999)
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtBurglar_Alarm_Comapny_Contact_Telephone" runat="server" SkinID="txtPhone"
                                                                Width="170px" MaxLength="12" onKeyPress="javascript:return FormatPhone(event,this.id);" />
                                                            <asp:RegularExpressionValidator ID="revtxtBurglar_Alarm_Comapny_Contact_Telephone"
                                                                ControlToValidate="txtBurglar_Alarm_Comapny_Contact_Telephone" runat="server"
                                                                ErrorMessage="Please Enter [Property Security]/Burglar Alarm Company Contact Telephone in XXX-XXX-XXXX format."
                                                                ValidationGroup="vsErrorProperty_Security" Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Burglar Alarm Company Contact E-Mail&nbsp;<span id="Span22" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:TextBox ID="txtBurglar_Alarm_Company_Contact_EMail" runat="server" Width="563px"
                                                                MaxLength="255" />
                                                            <asp:RegularExpressionValidator ID="revtxtBurglar_Alarm_Company_Contact_EMail" runat="server"
                                                                ControlToValidate="txtBurglar_Alarm_Company_Contact_EMail" Display="None" ErrorMessage="Please Enter Valid [Property Security]/Burglar Alarm Company Contact E-Mail"
                                                                SetFocusOnError="True" ValidationGroup="vsErrorProperty_Security" ToolTip="Please Enter Valid [Property Security]/Burglar Alarm Company Contact E-Mail"
                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Zone/Doors
                                                        </td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkZDCollisionCenter" runat="server" Text="Collision Center" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkZDOffice" runat="server" Text="Office" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkZDParts" runat="server" Text="Parts" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkZDSalesShowroom" runat="server" Text="Sales Showroom" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkZDService" runat="server" Text="Service" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkZDOther" runat="server" Text="Other" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Burglar Alarm Coverage – Other Description&nbsp;<span id="Span23" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtBurglar_Alarm_Coverage_Other_Description" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Burglar Alarm Coverage Comments&nbsp;<span id="Span24" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtBurglar_Alarm_Coverage_Comments" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="5px" class="Spacer">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <strong>Guard Services</strong>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Guard Company Name&nbsp;<span id="Span25" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:TextBox ID="txtGuard_Company_Name" runat="server" Width="563px" MaxLength="150" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Guard Company Address 1&nbsp;<span id="Span26" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtGuard_Company_Address_1" runat="server" Width="170px" MaxLength="100" />
                                                        </td>
                                                        <td align="left" valign="top">Guard Company Address 2&nbsp;<span id="Span27" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtGuard_Company_Address_2" runat="server" Width="170px" MaxLength="100" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Guard Company City&nbsp;<span id="Span28" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtGuard_Company_City" runat="server" Width="170px" MaxLength="50" />
                                                        </td>
                                                        <td align="left" valign="top">Guard Company State&nbsp;<span id="Span29" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="drpFK_Guard_Company_State" Width="175px" runat="server" SkinID="dropGen">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Guard Company Zip&nbsp;<span id="Span30" style="color: Red; display: none;" runat="server">*</span><br />
                                                            (99999-9999)
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtGuard_Company_Zip" runat="server" Width="170px" MaxLength="10"
                                                                SkinID="txtZipCode" onKeyPress="javascript:return FormatZipCode(event,this.id);" />
                                                            <asp:RegularExpressionValidator ID="retxtGuard_Company_Zip" runat="server" ErrorMessage="[Property Security]/Guard Company Zip is not valid"
                                                                SetFocusOnError="true" ControlToValidate="txtGuard_Company_Zip" ValidationExpression="\b[0-9]{5}-[0-9]{4}\b|\b[0-9]{5}\b"
                                                                ValidationGroup="vsErrorProperty_Security" Display="none" />
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Guard Company Contact Name&nbsp;<span id="Span31" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtGuard_Company_Contact_Name" runat="server" Width="170px" MaxLength="50" />
                                                        </td>
                                                        <td align="left" valign="top">Guard Company Contact Telephone&nbsp;<span id="Span32" style="color: Red; display: none;"
                                                            runat="server">*</span><br />
                                                            (999-999-9999)
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtGuard_Comapny_Contact_Telephone" runat="server" Width="170px"
                                                                SkinID="txtPhone" MaxLength="12" onKeyPress="javascript:return FormatPhone(event,this.id);" />
                                                            <asp:RegularExpressionValidator ID="retxtGuard_Comapny_Contact_Telephone" ControlToValidate="txtGuard_Comapny_Contact_Telephone"
                                                                runat="server" ErrorMessage="Please Enter [Property Security]/Guard Company Contact Telephone in XXX-XXX-XXXX format."
                                                                ValidationGroup="vsErrorProperty_Security" Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Guard Company Contact E-Mail&nbsp;<span id="Span33" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:TextBox ID="txtGuard_Company_Contact_EMail" runat="server" Width="563px" MaxLength="255" />
                                                            <asp:RegularExpressionValidator ID="retxtGuard_Company_Contact_EMail" runat="server"
                                                                ControlToValidate="txtGuard_Company_Contact_EMail" Display="None" ErrorMessage="Please Enter Valid [Property Security]/Guard Company Contact E-Mail"
                                                                SetFocusOnError="True" ValidationGroup="vsErrorProperty_Security" ToolTip="Please Enter Valid [Property Security]/Guard Company Contact E-Mail"
                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Guard Hours Monitored Grid
                                                            <br />
                                                            <asp:LinkButton ID="lnkbtnAddGaurdHoursMonitoredGrid" runat="server" Text="--Add--"
                                                                OnClick="lnkbtnAddGaurdHoursMonitoredGrid_Click" CausesValidation="true" ValidationGroup="vsErrorProperty_Security"></asp:LinkButton>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:GridView ID="gvGuardHoursMonitorGrid" runat="server" GridLines="None" CellPadding="4"
                                                                CellSpacing="0" AutoGenerateColumns="false" Width="100%" EnableTheming="false"
                                                                OnRowCommand="gvMonitoingGrid_RowCommand">
                                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <RowStyle BackColor="#EAEAEA" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <EditRowStyle BackColor="#2461BF" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <PagerStyle BackColor="#7f7f7f" ForeColor="White" HorizontalAlign="Center" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <HeaderStyle BackColor="#7f7f7f" Font-Bold="True" ForeColor="White" Font-Names="Tahoma"
                                                                    Font-Size="8pt" VerticalAlign="Bottom" />
                                                                <AlternatingRowStyle BackColor="White" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <EmptyDataRowStyle CssClass="emptyrow" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Day Monitoring Begins" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnDayMonitoringBegins" runat="server" CommandName="gvEdit"
                                                                                CommandArgument='<%# Eval("PK_AP_Property_Security_Monitor_Grids") %>'> 
                                                                            <%# Eval("Start_Day")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Time Monitoring Begins" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnTimeMonitoringBegins" runat="server" CommandName="gvEdit"
                                                                                CommandArgument='<%# Eval("PK_AP_Property_Security_Monitor_Grids") %>'> 
                                                                                <%# Eval("Start_Time")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Day Monitoring Ends" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnDayMonitoringEnds" runat="server" CommandName="gvEdit"
                                                                                CommandArgument='<%# Eval("PK_AP_Property_Security_Monitor_Grids") %>'> 
                                                                                <%# Eval("End_Day")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Time Monitoring Ends" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnTimeMonitoringEnds" runat="server" CommandName="gvEdit"
                                                                                CommandArgument='<%# Eval("PK_AP_Property_Security_Monitor_Grids") %>'> 
                                                                                <%# Eval("End_Time")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Hours" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnHours" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_AP_Property_Security_Monitor_Grids") %>'> 
                                                                                <%# Eval("Hours")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnRemove" runat="server" Text="Remove" OnClientClick="return confirm('Are you Sure to delete this record?');"
                                                                                CommandName="Remove" CommandArgument='<%# Eval("PK_AP_Property_Security_Monitor_Grids") %>'> 
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                                <EmptyDataTemplate>
                                                                    <b>No Record found</b>
                                                                </EmptyDataTemplate>
                                                                <PagerSettings Visible="False" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Off-Duty Officer Name&nbsp;<span id="Span36" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtOffDuty_Officer_Name" runat="server" Width="170px" MaxLength="50" />
                                                        </td>
                                                        <td align="left" valign="top">Off-Duty Officer Telephone&nbsp;<span id="Span37" style="color: Red; display: none;"
                                                            runat="server">*</span><br />
                                                            (999-999-9999)
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtOffDuty_Officer_Telephone" runat="server" Width="170px" MaxLength="12"
                                                                onKeyPress="javascript:return FormatPhone(event,this.id);" />
                                                            <asp:RegularExpressionValidator ID="retxtOffDuty_Officer_Telephone" ControlToValidate="txtOffDuty_Officer_Telephone"
                                                                runat="server" ErrorMessage="Please Enter [Property Security]/Off-Duty Officer Telephone in XXX-XXX-XXXX format."
                                                                ValidationGroup="vsErrorProperty_Security" Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Off-Duty Officer Hours Monitored Grid<br />
                                                            <asp:LinkButton ID="lnkbtnAddOffdutyOfficerHoursMonitoredGrid" runat="server" Text="--Add--"
                                                                OnClick="lnkbtnAddOffdutyOfficerHoursMonitoredGrid_Click" CausesValidation="true"
                                                                ValidationGroup="vsErrorProperty_Security"></asp:LinkButton>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:GridView ID="gvOffDutyOfficerHoursMonitoredGrid" runat="server" GridLines="None"
                                                                CellPadding="4" CellSpacing="0" AutoGenerateColumns="false" Width="100%" EnableTheming="false"
                                                                OnRowCommand="gvMonitoingGrid_RowCommand">
                                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <RowStyle BackColor="#EAEAEA" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <EditRowStyle BackColor="#2461BF" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <PagerStyle BackColor="#7f7f7f" ForeColor="White" HorizontalAlign="Center" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <HeaderStyle BackColor="#7f7f7f" Font-Bold="True" ForeColor="White" Font-Names="Tahoma"
                                                                    Font-Size="8pt" VerticalAlign="Bottom" />
                                                                <AlternatingRowStyle BackColor="White" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <EmptyDataRowStyle CssClass="emptyrow" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Day Monitoring Begins" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnDayMonitoringBegins" runat="server" CommandName="gvEdit"
                                                                                CommandArgument='<%# Eval("PK_AP_Property_Security_Monitor_Grids") %>'> 
                                                                            <%# Eval("Start_Day")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Time Monitoring Begins" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnTimeMonitoringBegins" runat="server" CommandName="gvEdit"
                                                                                CommandArgument='<%# Eval("PK_AP_Property_Security_Monitor_Grids") %>'> 
                                                                                <%# Eval("Start_Time")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Day Monitoring Ends" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnDayMonitoringEnds" runat="server" CommandName="gvEdit"
                                                                                CommandArgument='<%# Eval("PK_AP_Property_Security_Monitor_Grids") %>'> 
                                                                                <%# Eval("End_Day")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Time Monitoring Ends" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnTimeMonitoringEnds" runat="server" CommandName="gvEdit"
                                                                                CommandArgument='<%# Eval("PK_AP_Property_Security_Monitor_Grids") %>'> 
                                                                                <%# Eval("End_Time")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Hours" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnHours" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_AP_Property_Security_Monitor_Grids") %>'> 
                                                                                <%# Eval("Hours")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnRemove" runat="server" Text="Remove" OnClientClick="return confirm('Are you Sure to delete this record?');"
                                                                                CommandName="Remove" CommandArgument='<%# Eval("PK_AP_Property_Security_Monitor_Grids") %>'> 
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                                <EmptyDataTemplate>
                                                                    <b>No Record found</b>
                                                                </EmptyDataTemplate>
                                                                <PagerSettings Visible="False" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="5px" class="Spacer">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <strong>Access Control - Systems</strong>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkACFirstFloorOnly" runat="server" Text="1st Floor Only" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="25%">
                                                                        <asp:CheckBox ID="chkACBusinessArea" runat="server" Text="Business Area" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="25%">
                                                                        <asp:CheckBox ID="chkKeyFobs" runat="server" Text="Key Fobs" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkACCashier" runat="server" Text="Cashier" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="25%">
                                                                        <asp:CheckBox ID="chkACControlRoom" runat="server" Text="Computer Room" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="25%">
                                                                        <asp:CheckBox ID="chkDoorRestrictions" runat="server" Text="Door Restrictions" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkACControllerOffice" runat="server" Text="Controller Office" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkACEnterExitBuilding" runat="server" Text="Enter/Exit Building" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkACFandIOffice" runat="server" Text="F&I Office" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkACGMOffice" runat="server" Text="GM Office" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkACMulipleFloors" runat="server" Text="Multiple Floors" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkACParts" runat="server" Text="Parts" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkACSmartSafeOffice" runat="server" Text="Smart Safe Office" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkACOther" runat="server" Text="Other" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Access Control – Other Description&nbsp;<span id="Span40" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtAccess_Control_Other_Description" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            <strong>Fencing/Gates Protection</strong>
                                                        </td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkFGEnterenceExitAlarms" runat="server" Text="Entrance/Exit Arms" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkFGEnterenceExitGate" runat="server" Text="Entrance/Exit Gate" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top">
                                                            <span style="font-weight: bold; text-decoration: underline">Fencing</span>
                                                        </td>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkFBack" runat="server" Text="Back" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkFEntierPerimeter" runat="server" Text="Entire Perimeter" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkFFront" runat="server" Text="Front" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkFSatelliteParkingLot" runat="server" Text="Satellite Parking Lot" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkFSide" runat="server" Text="Side" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top">
                                                            <span style="font-weight: bold; text-decoration: underline">Post Bollards</span>
                                                        </td>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkPBack" runat="server" Text="Back" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkPEntirePerimeter" runat="server" Text="Entire Perimeter" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkPFront" runat="server" Text="Front" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkPSatelliteParkingLot" runat="server" Text="Satellite Parking Lot" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkPSide" runat="server" Text="Side" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            <strong>Key Tracking System </strong>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkSITSAutoTracks" runat="server" Text="KEYper" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkSITSKeyTracks" runat="server" Text="KeyTrak" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkSITSOther" runat="server" Text="Other" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Other Security Inventory Tracking System&nbsp;<span id="Span41" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtSecurity_Inventory_Tracking_System_Other_Description"
                                                                runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Cap Index Crime Score<span id="Span141" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtCap_Index_Crime_Score" runat="server" Width="170px" AutoPostBack="true"
                                                                onblur="return true" CausesValidation="false" OnTextChanged="txtCap_Index_Crime_Score_TextChanged"
                                                                MaxLength="5" onKeyPress="return FormatInteger(event);" onpaste="return false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Cap Index Risk Category<span id="Span142" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="ddlCap_Index_Risk_Category" runat="server" Width="175px">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Financial Grid<br />
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="90%" runat="server" id="tblFinancialGrid">
                                                                <tr>
                                                                    <td width="40%" align="left" class="assetheader">Category</td>
                                                                    <td width="30%" align="left" class="assetheader">Total Capex $</td>
                                                                    <td width="30%" align="left" class="assetheader">Total Monthly Charge $</td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="40%" align="left" class="asset">
                                                                        <asp:Label ID="lblCCTVOnly" runat="server" Text="CCTV Only"></asp:Label></td>
                                                                    <td width="30%" align="left" class="asset">
                                                                        <asp:TextBox ID="txtCCTVOnlyTC" runat="server" SkinID="txtCurrency15"  /></td>
                                                                    <td width="30%" align="left" class="asset">
                                                                        <asp:TextBox ID="txtCCTVOnlyTM" runat="server" SkinID="txtCurrency15" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="40%" align="left" class="asset2">
                                                                        <asp:Label ID="lblBurglarAlarms" runat="server" Text="Burglar Alarms"></asp:Label></td>
                                                                    <td width="30%" align="left" class="asset2">
                                                                        <asp:TextBox ID="txtBurglarAlarmsTC" runat="server" SkinID="txtCurrency15" /></td>
                                                                    <td width="30%" align="left" class="asset2">
                                                                        <asp:TextBox ID="txtBurglarAlarmsTM" runat="server" SkinID="txtCurrency15" /></td>
                                                                </tr>                                                               
                                                                <tr>
                                                                    <td width="40%" align="left" class="asset">
                                                                        <asp:Label ID="lblGuardServices" runat="server" Text="Guard Services"></asp:Label></td>
                                                                    <td width="30%" align="left" class="asset">
                                                                        <asp:TextBox ID="txtGuardServicesTC" runat="server" SkinID="txtCurrency15" /></td>
                                                                    <td width="30%" align="left" class="asset">
                                                                        <asp:TextBox ID="txtGuardServicesTM" runat="server" SkinID="txtCurrency15" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="40%" align="left" class="asset2">
                                                                        <asp:Label ID="lblAccessControl" runat="server" Text="Access Control"></asp:Label></td>
                                                                    <td width="30%" align="left" class="asset2">
                                                                        <asp:TextBox ID="txtAccessControlTC" runat="server" SkinID="txtCurrency15" /></td>
                                                                    <td width="30%" align="left" class="asset2">
                                                                        <asp:TextBox ID="txtAccessControlTM" runat="server" SkinID="txtCurrency15" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="40%" align="left" class="asset">
                                                                        <asp:Label ID="lblSecurityInventoryTrackingSystems" runat="server" Text="Security Inventory Tracking Systems"></asp:Label></td>
                                                                    <td width="30%" align="left" class="asset">
                                                                        <asp:TextBox ID="txtSecurityInventoryTrackingSystemsTC" runat="server" SkinID="txtCurrency15" /></td>
                                                                    <td width="30%" align="left" class="asset">
                                                                        <asp:TextBox ID="txtSecurityInventoryTrackingSystemsTM" runat="server" SkinID="txtCurrency15" /></td>
                                                                </tr>
                                                                 <tr>
                                                                    <td width="40%" align="left" class="asset2">
                                                                        <asp:Label ID="lblCategory" runat="server" Text="CCTV and Live Monitoring Services"></asp:Label></td>
                                                                    <td width="30%" align="left" class="asset2">
                                                                        <asp:TextBox ID="txtCategoryTC" runat="server" SkinID="txtCurrency15" /></td>
                                                                    <td width="30%" align="left" class="asset2">
                                                                        <asp:TextBox ID="txtCategoryTM" runat="server" SkinID="txtCurrency15" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="3">&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="3" align="center">
                                                                        <asp:Button ID="btnSaveFinancialGrid" runat="server" Text="Save" OnClick="btnSaveFinancialGrid_Click" />
                                                                        &nbsp;
                                                                        <asp:Button ID="btnCancelFinancialGrid" runat="server" Text="Cancel" OnClick="btnCancelFinancialGrid_Click" />
                                                                        &nbsp;
                                                                        <asp:Button ID="btnViewAuditFinancialGrid" runat="server" Text="View Audit Trail" OnClientClick="javascript:return openAP_Propert_Securty_FinancialPopup();" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <hr>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <asp:Panel ID="pnlAddPropertySecurityMonitorGrid" runat="server" Width="100%" Style="display: none;">
                                                    <div class="bandHeaderRow">
                                                        Property Security Monitor Grid
                                                    </div>
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <td align="left" width="21%" valign="top">Day Monitoring Begins&nbsp;<span id="Span10" style="color: Red" runat="server">*</span>
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top" width="75%" colspan="4">
                                                                <asp:DropDownList ID="ddlDayMonitoringBegins" runat="server" SkinID="ddlExposure">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="rfvddlDayMonitoringBegins" runat="server" ControlToValidate="ddlDayMonitoringBegins"
                                                                    ErrorMessage="Select Day Monitoring Begins" Display="None" ValidationGroup="vsAddPSMonitor"
                                                                    SetFocusOnError="true" InitialValue="0"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="21%" valign="top">Time Monitoring Begins&nbsp;<span id="Span11" style="color: Red" runat="server">*</span>
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top" width="75%" colspan="4">
                                                                <asp:TextBox ID="txtTimeMonitoringBegins" runat="server" Width="170px" MaxLength="5" />
                                                                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AutoComplete="true"
                                                                    MaskType="Time" Mask="99:99" TargetControlID="txtTimeMonitoringBegins" AcceptNegative="Left"
                                                                    DisplayMoney="Left" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                    OnInvalidCssClass="MaskedEditError" CultureName="en-US">
                                                                </cc1:MaskedEditExtender>
                                                                <asp:RegularExpressionValidator ID="revtxtTimeMonitoringBegins" runat="server" ControlToValidate="txtTimeMonitoringBegins"
                                                                    ValidationExpression="^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$"
                                                                    ErrorMessage="Time Monitoring Begins should be valid time" Display="none" ValidationGroup="vsAddPSMonitor"
                                                                    SetFocusOnError="true">
                                                                </asp:RegularExpressionValidator>
                                                                <asp:RequiredFieldValidator ID="rfvtxtTimeMonitoringBegins" runat="server" ControlToValidate="txtTimeMonitoringBegins"
                                                                    Display="None" ErrorMessage="Enter Time Monitoring Begins." ValidationGroup="vsAddPSMonitor"
                                                                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="21%" valign="top">Day Monitoring Ends&nbsp;<span id="Span38" style="color: Red" runat="server">*</span>
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top" width="75%" colspan="4">
                                                                <asp:DropDownList ID="ddlDayMonitoringEnds" runat="server" SkinID="ddlExposure">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="rfvddlDayMonitoringEnds" runat="server" ControlToValidate="ddlDayMonitoringEnds"
                                                                    ErrorMessage="Select Day Monitoring Ends" Display="None" ValidationGroup="vsAddPSMonitor"
                                                                    SetFocusOnError="true" InitialValue="0"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="21%" valign="top">Time Monitoring Ends&nbsp;<span id="Span39" style="color: Red" runat="server">*</span>
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top" width="75%" colspan="4">
                                                                <asp:TextBox ID="txtTimeMonitoringEnds" runat="server" Width="170px" MaxLength="5" />
                                                                <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" AutoComplete="true"
                                                                    MaskType="Time" Mask="99:99" TargetControlID="txtTimeMonitoringEnds" AcceptNegative="Left"
                                                                    DisplayMoney="Left" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                    OnInvalidCssClass="MaskedEditError" CultureName="en-US">
                                                                </cc1:MaskedEditExtender>
                                                                <asp:RegularExpressionValidator ID="revtxtTimeMonitoringEnds" runat="server" ControlToValidate="txtTimeMonitoringEnds"
                                                                    ValidationExpression="^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$"
                                                                    ErrorMessage="Time Monitoring Ends should be valid time" Display="none" ValidationGroup="vsAddPSMonitor"
                                                                    SetFocusOnError="true">
                                                                </asp:RegularExpressionValidator>
                                                                <asp:RequiredFieldValidator ID="rfvtxtTimeMonitoringEnds" runat="server" ControlToValidate="txtTimeMonitoringEnds"
                                                                    Display="None" ErrorMessage="Enter Time Monitoring Ends." ValidationGroup="vsAddPSMonitor"
                                                                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="21%" valign="top">Hours&nbsp;<span id="Span134" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top" width="75%" colspan="4">
                                                                <asp:TextBox ID="txtMonitoringPeriodHours" runat="server" SkinID="txtDisabled"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" align="left" valign="top">
                                                                <table border="0" align="center" cellpadding="0" cellspacing="5">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Button ID="btnAddPSMonitorGird" runat="server" Text="Save" OnClientClick="javascript:return IsValidMonitorTime();"
                                                                                OnClick="btnAddPSMonitorGird_Click" CausesValidation="true" ValidationGroup="vsAddPSMonitor" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="btnBackPropertySecurity" runat="server" Text="Back" OnClick="btnShowPropertySecurityFromMonitor_Click"
                                                                                CausesValidation="false" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </asp:Panel>
                                            <div id="dvProperty_SecuritySave" runat="server" style="display: none;">
                                                <table cellpadding="5" cellspacing="0" border="0" width="100%">
                                                    <tr>
                                                        <td width="50%" align="right">
                                                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CausesValidation="true"
                                                                ValidationGroup="vsErrorProperty_Security" />
                                                        </td>
                                                        <td align="left">
                                                            <asp:Button ID="btnProperty_SecurityAudit" runat="server" Text="View Audit Trail"
                                                                CausesValidation="false" ToolTip="View Audit Trail" OnClientClick="javascript:return openAP_Propert_SecurtyPopup();"
                                                                Visible="false" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <asp:Panel ID="pnl2" runat="server" Style="display: none;" Width="794px">
                                                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td>
                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td width="45%"></td>
                                                                    <td valign="top" align="right">
                                                                        <uc:ctrlPaging ID="CtrlPagingDPD_FROIs" runat="server" OnGetPage="GetPageDPD_FROIs" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            <asp:GridView ID="gvAP_DPD_FROIs" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                AllowSorting="true" OnRowCommand="gvAP_DPD_FROIs_OnRowCommand" OnSorting="gvAP_DPD_FROIs_Sorting"
                                                                OnRowCreated="gvAP_DPD_FROIs_OnRowCreated">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="DPD First Report Number" SortExpression="DPD_FR_Number">
                                                                        <ItemStyle Width="25%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkDPD_First_Report_Number" runat="server" Text='<%# Eval("DPD_FR_Number") %>'
                                                                                CssClass="TextClip" CommandName="Edit_DPD_FROIs" CommandArgument='<%# Eval("PK_DPD_FR_ID") +";" + Eval("PK_AP_DPD_FROIs") + ";" +  Eval("FK_First_Report_Wizard_ID") +";"+ Eval("PK_DPD_FR_Vehicle_ID") +";"+ Eval("PK_DPD_Claims_ID") %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Date of Loss" SortExpression="Date_Of_Loss">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkDate_Of_Loss" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Date_Of_Loss")) %>'
                                                                                CssClass="TextClip" CommandName="Edit_DPD_FROIs" CommandArgument='<%# Eval("PK_DPD_FR_ID") +";" + Eval("PK_AP_DPD_FROIs") + ";" +  Eval("FK_First_Report_Wizard_ID") +";"+ Eval("PK_DPD_FR_Vehicle_ID")+";"+ Eval("PK_DPD_Claims_ID") %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Cause of Loss" SortExpression="Cause_Of_Loss">
                                                                        <ItemStyle Width="18%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkCause_of_Loss" runat="server" Text='<%# Eval("Cause_Of_Loss") %>'
                                                                                CssClass="TextClip" CommandName="Edit_DPD_FROIs" CommandArgument='<%# Eval("PK_DPD_FR_ID") +";" + Eval("PK_AP_DPD_FROIs") + ";" +  Eval("FK_First_Report_Wizard_ID") +";"+ Eval("PK_DPD_FR_Vehicle_ID")+";"+ Eval("PK_DPD_Claims_ID") %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Make" SortExpression="Make">
                                                                        <ItemStyle Width="16%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkMake" runat="server" Text='<%# Eval("Make") %>' CommandName="Edit_DPD_FROIs"
                                                                                CssClass="TextClip" CommandArgument='<%# Eval("PK_DPD_FR_ID") +";" + Eval("PK_AP_DPD_FROIs") + ";" +  Eval("FK_First_Report_Wizard_ID") +";"+ Eval("PK_DPD_FR_Vehicle_ID")+";"+ Eval("PK_DPD_Claims_ID") %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Model" SortExpression="Model">
                                                                        <ItemStyle Width="16%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkModel" runat="server" Text='<%# Eval("Model") %>' CommandName="Edit_DPD_FROIs"
                                                                                CssClass="TextClip" CommandArgument='<%# Eval("PK_DPD_FR_ID") +";" + Eval("PK_AP_DPD_FROIs") + ";" +  Eval("FK_First_Report_Wizard_ID") +";"+ Eval("PK_DPD_FR_Vehicle_ID")+";"+ Eval("PK_DPD_Claims_ID") %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Status" SortExpression="Item_Status">
                                                                        <ItemStyle Width="10%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Item_Status") %>'></asp:Label>
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
                                                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">FROIs To be Included in Grid
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:RadioButtonList ID="rdoFROIs" runat="server" RepeatDirection="Horizontal" RepeatColumns="3"
                                                                OnSelectedIndexChanged="rdoDPD_FROIs_OnSelectedIndexChanged" AutoPostBack="true">
                                                                <asp:ListItem Text="Open" Value="O"></asp:ListItem>
                                                                <asp:ListItem Text="Closed" Value="C"></asp:ListItem>
                                                                <asp:ListItem Text="All" Value="A" Selected="True"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div class="bandHeaderRow">
                                                    Incident Information
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Incident Number
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top" colspan="4">
                                                            <a href="../FirstReport/DPDFirstReport.aspx?id=<%= Encryption.Encrypt(FK_DPD_FR_ID.ToString()) %>"
                                                                target="_blank">
                                                                <asp:Label ID="lblIncident_Number" runat="server" />
                                                            </a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Date of Loss
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtDate_Of_Loss" runat="server" Width="170px" SkinID="txtDisabled" />
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Time of Loss
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtTime_of_Loss" runat="server" Width="170px" MaxLength="50" SkinID="txtDisabled" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Cause of Loss
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtCause_of_Loss" Width="170px" runat="server" SkinID="txtDisabled" />
                                                        </td>
                                                        <td align="left" valign="top">VIN#
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtVIN" runat="server" Width="170px" MaxLength="30" SkinID="txtDisabled" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Make
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtMake" runat="server" Width="170px" MaxLength="20" SkinID="txtDisabled" />
                                                        </td>
                                                        <td align="left" valign="top">Model
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtModel" runat="server" Width="170px" MaxLength="20" SkinID="txtDisabled" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Year
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtYear" runat="server" Width="170px" onkeypress="return currencyFormat(this,',','.',event);"
                                                                onpaste="return false" SkinID="txtDisabled" />
                                                        </td>
                                                        <td align="left" valign="top">Type of Vehicle
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtTypeOfVehicle" runat="server" Width="170px" MaxLength="20" SkinID="txtDisabled" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Vehicle Color&nbsp;<span id="Span145" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:TextBox ID="txtVehicleColor" runat="server" Width="170px" MaxLength="50"/>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Location of Vehicle
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtPresent_Location" runat="server" Width="170px" MaxLength="50"
                                                                SkinID="txtDisabled" />
                                                        </td>
                                                        <td align="left" valign="top">Location Address
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtPresent_Address" runat="server" Width="170px" MaxLength="50"
                                                                SkinID="txtDisabled" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Location State
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtPresent_State" runat="server" Width="170px" MaxLength="50" SkinID="txtDisabled" />
                                                        </td>
                                                        <td align="left" valign="top">Location Zip
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtPresent_Zip" runat="server" Width="170px" MaxLength="10" SkinID="txtDisabled" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Invoice Value
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtInvoice_Value" runat="server" Width="170px" onkeypress="return currencyFormat(this,',','.',event);"
                                                                onpaste="return false" SkinID="txtDisabled" />
                                                        </td>
                                                        <td align="left" valign="top">Police Case Number&nbsp;<span id="Span146" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtPoliceCaseNumber" runat="server" Width="170px" MaxLength="50" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" valign="top" width="22%">Investigating Police Department&nbsp;<span id="Span147" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtInvestigatingPoliceDepartment" runat="server" Width="170px" MaxLength="100"/>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Loss Description
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtLoss_Description" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Witnesses
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="center" width="78%" valign="top">
                                                            <asp:GridView ID="gvDPD_Witnesses" runat="server" AutoGenerateColumns="false" Width="100%"
                                                                AllowSorting="false">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Name">
                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                        <ItemTemplate>
                                                                            <%#Eval("Name")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Address">
                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                        <ItemTemplate>
                                                                            <%#Eval("Address")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Phone">
                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                        <ItemTemplate>
                                                                            <%#Eval("Phone")%>
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
                                                <table cellpadding="3" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td align="left" valign="top" width="18%">Associated Claim Number
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td width="78%" align="left">
                                                            <asp:Label ID="lblDPDClaim_Number" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="3"></td>
                                                    </tr>
                                                </table>
                                                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td></td>
                                                    </tr>
                                                </table>
                                                <table border="0" cellpadding="1" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="100%" align="left">
                                                            <uc:ctrlSonicNotes ID="ctrlSonicNotes" runat="server" IsAddVisible="false" StrOperation="edit" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                    <div class="bandHeaderRow">
                                                        <caption>
                                                            Investigation</caption>
                                                    </div>
                                                    <tr>
                                                        <td align="left" width="22%" colspan="2"></td>
                                                        <td align="left" width="78%" colspan="4">
                                                            <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chk3rd_Party_Vendor_Related_Theft" Text="3rd Party Vendor Related Theft"
                                                                            runat="server" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAccess_Control_Failures" Text="Access Control Failures" runat="server" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkBreaking_and_Entering" Text="Breaking and Entering" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkBurglar_Alarm_Failure" Text="Burglar Alarm Failure" runat="server" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkCamera_Dead_Spot" Text="Camera Dead Spot" runat="server" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkCCTV_Monitoring_Failure" Text="CCTV Monitoring Failure (Equipment)"
                                                                            runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkCCTV_Monitoring_Failure_byOperator" Text="CCTV Monitoring Failure by Operator"
                                                                            runat="server" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkDesign_weakness_Property_Protection" Text="Design weakness – Property Protection"
                                                                            runat="server" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkEnvironmental_Obstruction_ConditionCamera" Text="Environmental Obstruction/Condition – Camera"
                                                                            runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkFailure_to_ReportLate_Report" Text="Failure to Report/Late Report"
                                                                            runat="server" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkKey_Swap" Text="Key Swap" runat="server" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkLighting_Deficiencies" Text="Lighting Deficiencies" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkLockBox_Not_Properly_Secured" Text="Lock Box Not Properly Secured"
                                                                            runat="server" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkNegligence_Lackof_Key_Control_Program_Unattended_Keys" Text="Negligence Lack of Key Control Program – Unattended Keys"
                                                                            runat="server" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkNonPermissible_User_of_TakingVehicle" Text="Non-Permissible User of Taking Vehicle"
                                                                            runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkPower_Outage" Text="Power Outage" runat="server" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkSecurity_Guard_Failure" Text="Security Guard Failure" runat="server" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkStolen_Id" Text="Stolen Id" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkTheft_by_Deception" Text="Theft by Deception" runat="server" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkUnauthorized_Building_Entry_Forcible" Text="Unauthorized Building Entry (Forcible)"
                                                                            runat="server" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkUnauthorized_Building_Entry_Unlocked" Text="Unauthorized Building Entry (Unlocked)"
                                                                            runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkUnauthorized_Vehicle_Entry_Forcible" Text="Unauthorized Vehicle Entry (Forcible)"
                                                                            runat="server" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkUnauthorized_Vehicle_Entry_Unlocked" Text="Unauthorized Vehicle Entry (Unlocked)"
                                                                            runat="server" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkVehicle_Takenby_Tow_Truck" Text="Vehicle Taken by Tow Truck"
                                                                            runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkWeather_Related_DamageLoss" Text="Weather Related Damage/Loss"
                                                                            runat="server" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkVandalism" Text="Vandalism" runat="server" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkOther_Describe" Text="Other - Describe" runat="server" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Investigation Finding – Other Description&nbsp;<span id="Span42" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtInvestigation_Finding_Other_Description" runat="server"
                                                                ControlType="TextBox" />
                                                            <!--
                                                                MaxLength="1000" ControlType="TextBox" />
-->
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div class="bandHeaderRow">
                                                    FROI Review
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">What is the incident’s root cause?&nbsp;<span id="Span43" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtRoot_Cause" runat="server" ControlType="TextBox" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">How can the incident be prevented from happening again?&nbsp;<span id="Span44" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtIncident_Prevention" runat="server" ControlType="TextBox" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Who has been tasked with implementing practices/procedures to prevent re-occurrence?&nbsp;<span
                                                            id="Span45" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtPerson_Tasked" runat="server" Width="170px" MaxLength="50" />
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Target Date of Completion&nbsp;<span id="Span46" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtTarget_Date_of_Completion" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Target Date of Completion" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtTarget_Date_of_Completion', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revTarget_Date_of_Completion" runat="server"
                                                                ValidationGroup="vsErrorDPD_FROIs" Display="none" ErrorMessage="[DPD FROIs]/Target Date of Completion is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtTarget_Date_of_Completion" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" valign="top">Status Due On&nbsp;<span id="Span47" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtStatus_Due_On" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Status Due On" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtStatus_Due_On', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revStatus_Due_On" runat="server" ValidationGroup="vsErrorDPD_FROIs"
                                                                Display="none" ErrorMessage="[DPD FROIs]/Status Due On is not a valid date" SetFocusOnError="true"
                                                                ControlToValidate="txtStatus_Due_On" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Comments&nbsp;<span id="Span48" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtComments" runat="server" ControlType="TextBox" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Financial Loss&nbsp;<span id="Span49" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">$&nbsp;<asp:TextBox ID="txtFinancial_Loss" runat="server" Width="170px" onkeypress="return currencyFormat(this,',','.',event);"
                                                            onpaste="return false" />
                                                        </td>
                                                        <td align="left" valign="top">Recovery&nbsp;<span id="Span50" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">$&nbsp;<asp:TextBox ID="txtRecovery" runat="server" Width="170px" onkeypress="return currencyFormat(this,',','.',event);"
                                                            onpaste="return false" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Item Status&nbsp;<span id="Span51" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="drpItem_Status" runat="server" Width="150px">
                                                                <asp:ListItem Text="--Select--" Value="0" />
                                                                <asp:ListItem Text="Open" Value="1" />
                                                                <asp:ListItem Text="Close" Value="2" />
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <div id="dvDPD_Save" runat="server" width="794px">
                                                <table cellpadding="5" cellspacing="0" border="0" width="100%">
                                                    <tr>
                                                        <td width="50%" align="right">
                                                            <asp:Button ID="btnDPD_FROIsSave" runat="server" Text="Save" OnClick="btnDPD_FROIsSave_Click"
                                                                CausesValidation="true" ValidationGroup="vsErrorDPD_FROIs" />
                                                        </td>
                                                        <td width="50%" align="left">
                                                            <asp:Button ID="btnDPD_FROIsAudit_Trail" Text="View Audit Trail" runat="server" OnClientClick="return openAuditPopup();"
                                                                CausesValidation="false" Visible="false" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <asp:Panel ID="pnl3" runat="server" Style="display: none;" Width="794px">
                                                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td>
                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td width="45%"></td>
                                                                    <td valign="top" align="right">
                                                                        <uc:ctrlPaging ID="CtrlPagingAL_FROIs" runat="server" OnGetPage="GetPageFROIs_AL" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            <asp:GridView ID="gvAP_AL_FROIs" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                AllowSorting="true" OnRowCommand="gvAP_AL_FROIs_OnRowCommand" OnSorting="gvAP_AL_FROIs_Sorting"
                                                                OnRowCreated="gvAP_AL_FROIs_OnRowCreated">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="AL First Report Number" SortExpression="AL_FR_Number">
                                                                        <ItemStyle Width="30%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkAL_First_Report_Number" runat="server" Text='<%# Eval("AL_FR_Number") %>'
                                                                                Width="150px" CssClass="TextClip" CommandName="Edit_AL_FROIs" CommandArgument='<%# Eval("PK_AL_FR_ID") + ";" + Eval("PK_AP_AL_FROIs") + ";" +  Eval("FK_First_Report_Wizard_ID")  + ";" + Eval("PK_Auto_Loss_Claims_ID") + ";" +  Eval("Origin_Claim_Number") %>'></asp:LinkButton>
                                                                            <%--CommandArgument='<%# Eval("PK_AL_FR_ID") + ";" + Eval("PK_AP_AL_FROIs") + ";" +  Eval("FK_First_Report_Wizard_ID") %>'></asp:LinkButton>--%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Date of Loss" SortExpression="Date_Of_Loss">
                                                                        <ItemStyle Width="16%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkDate_Of_Loss" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Date_Of_Loss")) %>'
                                                                                Width="100px" CssClass="TextClip" CommandName="Edit_AL_FROIs" CommandArgument='<%# Eval("PK_AL_FR_ID") +";" + Eval("PK_AP_AL_FROIs") + ";" +  Eval("FK_First_Report_Wizard_ID") + ";" + Eval("PK_Auto_Loss_Claims_ID") + ";" +  Eval("Origin_Claim_Number") %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Make" SortExpression="Make">
                                                                        <ItemStyle Width="20%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkMake" runat="server" Text='<%# Eval("Make") %>' CommandName="Edit_AL_FROIs"
                                                                                Width="150px" CssClass="TextClip" CommandArgument='<%# Eval("PK_AL_FR_ID") +";" + Eval("PK_AP_AL_FROIs") + ";" +  Eval("FK_First_Report_Wizard_ID") + ";" + Eval("PK_Auto_Loss_Claims_ID") + ";" +  Eval("Origin_Claim_Number") %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Model" SortExpression="Model">
                                                                        <ItemStyle Width="16%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkModel" runat="server" Text='<%# Eval("Model") %>' CommandName="Edit_AL_FROIs"
                                                                                Width="150px" CommandArgument='<%# Eval("PK_AL_FR_ID") +";" + Eval("PK_AP_AL_FROIs") + ";" +  Eval("FK_First_Report_Wizard_ID") + ";" + Eval("PK_Auto_Loss_Claims_ID") + ";" +  Eval("Origin_Claim_Number") %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Status" SortExpression="Item_Status">
                                                                        <ItemStyle Width="10%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Item_Status") %>' Width="80px"></asp:Label>
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
                                                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">FROIs To be Included in Grid
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:RadioButtonList ID="rdoAL_FROIs" runat="server" RepeatDirection="Horizontal"
                                                                RepeatColumns="3" AutoPostBack="true" OnSelectedIndexChanged="rdoAL_FROIs_OnSelectedIndexChanged">
                                                                <asp:ListItem Text="Open" Value="O"></asp:ListItem>
                                                                <asp:ListItem Text="Closed" Value="C"></asp:ListItem>
                                                                <asp:ListItem Text="All" Value="A" Selected="True"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div class="bandHeaderRow">
                                                    Incident Information
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Incident Number
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top" colspan="4">
                                                            <a href="../FirstReport/ALFirstReport.aspx?id=<%= Encryption.Encrypt(FK_AL_FR_ID.ToString()) %>"
                                                                target="_blank">
                                                                <asp:Label ID="lblAL_Incident_Number" runat="server" /></a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Date of Loss
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtAL_Date_Of_Loss" runat="server" Width="170px" SkinID="txtDisabled"
                                                                Enabled="false" />
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Time of Loss
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtAL_Time_of_Loss" runat="server" Width="170px" MaxLength="50"
                                                                SkinID="txtDisabled" Enabled="false" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Description of Loss
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtAL_Description_Of_Loss" runat="server" Enabled="false" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Incident Occurred
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:RadioButton runat="server" Text="Onsite" ID="rdbAL_Onsite" Enabled="false" Style="margin-top: -5px;" />
                                                            <asp:RadioButton runat="server" Text="Offsite" ID="rdbAL_Offsite" Enabled="false"
                                                                Style="margin-top: -5px;" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Were Police Notified?
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList ID="rdbAL_WerePoliceNotified" runat="server" RepeatDirection="Horizontal"
                                                                RepeatColumns="3" AutoPostBack="true" Enabled="false" SkinID="YNTypeNullSelection">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left" valign="top">Were Pedestrians Involved?
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList ID="rdbAL_WerePedestriansInvolved" runat="server" RepeatDirection="Horizontal"
                                                                RepeatColumns="3" AutoPostBack="true" Enabled="false" SkinID="YNTypeNullSelection">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Was there any property damage?
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList ID="rdbAL_propertydamage" runat="server" RepeatDirection="Horizontal"
                                                                RepeatColumns="3" AutoPostBack="true" Enabled="false" SkinID="YNTypeNullSelection">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left" valign="top">Were there any witnesses?
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList ID="rdbAL_Witnesses" runat="server" RepeatDirection="Horizontal"
                                                                RepeatColumns="3" AutoPostBack="true" Enabled="false" SkinID="YNTypeNullSelection">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Is there a Security Video Surveillance System?
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:RadioButtonList ID="rdbAL_SecurityVideo" runat="server" RepeatDirection="Horizontal"
                                                                RepeatColumns="3" AutoPostBack="true" Enabled="false" SkinID="YNTypeNullSelection">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Weather Conditions
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtAL_WeatherConditions" runat="server" Width="170px" SkinID="txtDisabled"
                                                                Enabled="false" />
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Road Conditions
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtAL_RoadConditions" runat="server" Width="170px" MaxLength="50"
                                                                SkinID="txtDisabled" Enabled="false" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Witnesses
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="center" width="78%" valign="top">
                                                            <asp:GridView ID="gvAL_Witnesses" runat="server" AutoGenerateColumns="false" Width="100%"
                                                                AllowSorting="false">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Name">
                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                        <ItemTemplate>
                                                                            <%#Eval("Witness_Name")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Address">
                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                        <ItemTemplate>
                                                                            <%#Eval("Witness_Address_1")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Phone">
                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                        <ItemTemplate>
                                                                            <%#Eval("Witness_Work_Phone")%>
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
                                                <table cellpadding="3" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td align="left" valign="top" width="18%">Associated Claim Number
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" width="78%">
                                                            <asp:Label ID="lblALClaim_Number" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="3"></td>
                                                    </tr>
                                                </table>
                                                <table cellpadding="1" cellspacing="0" width="100%">
                                                    <div class="bandHeaderRow">
                                                        <caption>
                                                            Claim Notes
                                                        </caption>
                                                    </div>
                                                    <tr>
                                                        <td width="100%" align="left">
                                                            <uc:CtrlAdjusterNotes ID="ucAdjusterNotes" runat="server" CurrentClaimType="AL" IsMailVisible="true" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table border="0" cellpadding="1" cellspacing="0" width="100%" style="margin-top: -10px;">
                                                    <tr>
                                                        <td width="100%" align="left">
                                                            <uc:ctrlSonicNotes ID="ctrlSonicNotes_AL" runat="server" IsAddVisible="false" StrOperation="edit" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div class="bandHeaderRow">
                                                    Investigation
                                                </div>
                                                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td align="left" width="22%" colspan="2"></td>
                                                        <td align="left" width="78%">
                                                            <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_3rd_Party_Vendor_Related_Theft" Text="3rd Party Vendor Related Theft"
                                                                            runat="server" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_Access_Control_Failures" Text="Access Control Failures" runat="server" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_Breaking_and_Entering" Text="Breaking and Entering" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_Burglar_Alarm_Failure" Text="Burglar Alarm Failure" runat="server" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_Camera_Dead_Spot" Text="Camera Dead Spot" runat="server" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_CCTV_Monitoring_Failure" Text="CCTV Monitoring Failure (Equipment)"
                                                                            runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_CCTV_Monitoring_Failure_byOperator" Text="CCTV Monitoring Failure by Operator"
                                                                            runat="server" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_Design_weakness_Property_Protection" Text="Design weakness – Property Protection"
                                                                            runat="server" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_Environmental_Obstruction_ConditionCamera" Text="Environmental Obstruction/Condition – Camera"
                                                                            runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_Failure_to_ReportLate_Report" Text="Failure to Report/Late Report"
                                                                            runat="server" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_Key_Swap" Text="Key Swap" runat="server" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_Lighting_Deficiencies" Text="Lighting Deficiencies" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_LockBox_Not_Properly_Secured" Text="Lock Box Not Properly Secured"
                                                                            runat="server" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_Negligence_Lackof_Key_Control_Program_Unattended_Keys" Text="Negligence Lack of Key Control Program – Unattended Keys"
                                                                            runat="server" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_NonPermissible_User_of_TakingVehicle" Text="Non-Permissible User of Taking Vehicle"
                                                                            runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_Power_Outage" Text="Power Outage" runat="server" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_Security_Guard_Failure" Text="Security Guard Failure" runat="server" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_Stolen_Id" Text="Stolen Id" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_Theft_by_Deception" Text="Theft by Deception" runat="server" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_Unauthorized_Building_Entry_Forcible" Text="Unauthorized Building Entry (Forcible)"
                                                                            runat="server" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_Unauthorized_Building_Entry_Unlocked" Text="Unauthorized Building Entry (Unlocked)"
                                                                            runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_Unauthorized_Vehicle_Entry_Forcible" Text="Unauthorized Vehicle Entry (Forcible)"
                                                                            runat="server" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_Unauthorized_Vehicle_Entry_Unlocked" Text="Unauthorized Vehicle Entry (Unlocked)"
                                                                            runat="server" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_Vehicle_Takenby_Tow_Truck" Text="Vehicle Taken by Tow Truck"
                                                                            runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_Weather_Related_DamageLoss" Text="Weather Related Damage/Loss"
                                                                            runat="server" />
                                                                    </td>
                                                                    <td colspan="2" valign="top">
                                                                        <asp:CheckBox ID="chkAL_Other_Describe" Text="Other - Describe" runat="server" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Investigation Finding – Other Description&nbsp;<span id="Span52" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtAL_Investigation_Finding" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div class="bandHeaderRow">
                                                    FROI Review
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">What is the incident’s root cause?&nbsp;<span id="Span53" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtAL_Root_Cause" runat="server" ControlType="TextBox" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">How can the incident be prevented from happening again?&nbsp;<span id="Span54" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtAL_Incident_Prevention" runat="server" ControlType="TextBox" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Who has been tasked with implementing practices/procedures to prevent re-occurrence?&nbsp;<span
                                                            id="Span55" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtAL_Person_Tasked" runat="server" Width="170px" MaxLength="50" />
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Target Date of Completion&nbsp;<span id="Span56" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtAL_Target_Date_of_Completion" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Target Date of Completion" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtAL_Target_Date_of_Completion', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="<%=AppConfig.SiteURL%>Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revAL_Target_Date_of_Completion" runat="server"
                                                                ValidationGroup="vsErrorAL_FROIs" Display="none" ErrorMessage="[AL FROIs]/Target Date of Completion is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtAL_Target_Date_of_Completion" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" valign="top">Status Due On&nbsp;<span id="Span57" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtAL_Status_Due_On" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Status Due On" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtAL_Status_Due_On', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="<%=AppConfig.SiteURL%>Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revAL_Status_Due_On" runat="server" ValidationGroup="vsErrorAL_FROIs"
                                                                Display="none" ErrorMessage="[AL FROIs]/Status Due On is not a valid date" SetFocusOnError="true"
                                                                ControlToValidate="txtAL_Status_Due_On" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Comments&nbsp;<span id="Span58" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtAL_Comments" runat="server" ControlType="TextBox" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Financial Loss&nbsp;<span id="Span59" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">$&nbsp;<asp:TextBox ID="txtAL_Financial_Loss" runat="server" Width="170px" onkeypress="return currencyFormat(this,',','.',event);"
                                                            onpaste="return false" />
                                                        </td>
                                                        <td align="left" valign="top">Recovery&nbsp;<span id="Span60" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">$&nbsp;<asp:TextBox ID="txtAL_Recovery" runat="server" Width="170px" onkeypress="return currencyFormat(this,',','.',event);"
                                                            onpaste="return false" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Item Status&nbsp;<span id="Span61" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="drpAL_Item_Status" runat="server" Width="150px">
                                                                <asp:ListItem Text="--Select--" Value="0" />
                                                                <asp:ListItem Text="Open" Value="1" />
                                                                <asp:ListItem Text="Close" Value="2" />
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <div id="dvAL_Save" runat="server" width="794px">
                                                <table cellpadding="5" cellspacing="0" border="0" width="100%">
                                                    <tr>
                                                        <td width="50%" align="right">
                                                            <asp:Button ID="btnAL_Save" runat="server" Text="Save" CausesValidation="true" ValidationGroup="vsErrorAL_FROIs"
                                                                OnClick="btnAL_Save_Click" />
                                                        </td>
                                                        <td align="left">
                                                            <asp:Button ID="btnAL_ViewAuditTrail" runat="server" Text="View Audit Trail" CausesValidation="false"
                                                                ToolTip="View Audit Trail" OnClientClick="javascript:return AuditPopUp();" Visible="false" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div id="dvCal_Grid" runat="server" style="display: none;">
                                                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td>
                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td width="45%"></td>
                                                                    <td valign="top" align="right">
                                                                        <uc:ctrlPaging ID="CtrlPagingAP_Calatlantic" runat="server" OnGetPage="GetPageAP_Calatlantic" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" colspan="6">
                                                                        <asp:GridView ID="gvEvent" runat="server" GridLines="None" CellPadding="4" CellSpacing="0"
                                                                            AllowSorting="true" AutoGenerateColumns="false" Width="100%" EnableTheming="false"
                                                                            OnRowCommand="gvEvent_RowCommand" OnRowCreated="gvEvent_OnRowCreated" OnSorting="gvEvent_Sorting">
                                                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Names="Tahoma"
                                                                                Font-Size="8pt" />
                                                                            <RowStyle BackColor="#EAEAEA" Font-Names="Tahoma" Font-Size="8pt" />
                                                                            <EditRowStyle BackColor="#2461BF" Font-Names="Tahoma" Font-Size="8pt" />
                                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" Font-Names="Tahoma"
                                                                                Font-Size="8pt" />
                                                                            <PagerStyle BackColor="#7f7f7f" ForeColor="White" HorizontalAlign="Center" Font-Names="Tahoma"
                                                                                Font-Size="8pt" />
                                                                            <HeaderStyle BackColor="#7f7f7f" Font-Bold="True" ForeColor="White" Font-Names="Tahoma"
                                                                                Font-Size="8pt" VerticalAlign="Bottom" />
                                                                            <AlternatingRowStyle BackColor="White" Font-Names="Tahoma" Font-Size="8pt" />
                                                                            <EmptyDataRowStyle CssClass="emptyrow" />
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Event Number" HeaderStyle-HorizontalAlign="Left" SortExpression="Event_Number">
                                                                                    <ItemStyle Width="100px" HorizontalAlign="Left" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkbtnEventNumber" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_Event")%>'> <%# Eval("Event_Number")%></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Date of Event" HeaderStyle-HorizontalAlign="Left"
                                                                                    SortExpression="Event_Occurence_Date">
                                                                                    <ItemStyle Width="100px" HorizontalAlign="Left" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkbtnEventDate" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_Event")%>'>
                                                                             
                                                                             <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Event_Occurence_Date"))%>  
                                                                                        </asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Time of Event" HeaderStyle-HorizontalAlign="Left"
                                                                                    ItemStyle-HorizontalAlign="Left" SortExpression="Event_Report_Date">
                                                                                    <ItemStyle Width="" />
                                                                                    <ItemTemplate>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Type" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                                    SortExpression="Event_Type">
                                                                                    <ItemStyle Width="" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkbtnEventType" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_Event")%>'>
                                                                        <%# Eval("Event_Type")%>
                                                                                        </asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="FROI" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                                    SortExpression="Associated_FROI_Number">
                                                                                    <ItemStyle Width="" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkbtnFROI" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_Event")%>'>
                                                                            <%# Eval("Associated_FROI_Number")%>
                                                                                        </asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                                    SortExpression="STATUS">
                                                                                    <ItemStyle Width="" />
                                                                                    <ItemTemplate>
                                                                                        <%# Eval("STATUS")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                                            <EmptyDataTemplate>
                                                                                <b>No Record found</b>
                                                                            </EmptyDataTemplate>
                                                                            <PagerSettings Visible="False" />
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <table border="0" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td align="left">Event To be Included in Grid
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:RadioButtonList ID="rbtnlEvent" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rbtnlEvent_SelectedIndexChanged">
                                                                            <asp:ListItem Selected="True" Text="Open" Value="O"></asp:ListItem>
                                                                            <asp:ListItem Text="Closed" Value="C"></asp:ListItem>
                                                                            <asp:ListItem Text="All" Value="A"></asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <asp:Panel ID="pnl4" runat="server" Style="display: none;" Width="794px">
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <div class="bandHeaderRow">
                                                                Event Information
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="18%">Date of Event
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="28%">
                                                            <asp:TextBox ID="txtDateOfEvent" runat="server" Width="170px" SkinID="txtDisabled"></asp:TextBox>
                                                        </td>
                                                        <td align="left" valign="top" width="18%">Time of Event
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="28%">
                                                            <asp:TextBox ID="txtTimeofEvent" runat="server" Width="170px" MaxLength="5" SkinID="txtDisabled"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Type of Event
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtTypeofEvent" runat="server" Width="170px" SkinID="txtDisabled"></asp:TextBox>
                                                        </td>
                                                        <td align="left" valign="top">Event Report Date
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtEventReportDate" runat="server" Width="170px" SkinID="txtDisabled"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Investigation Report Date
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtInvestigationReportDate" runat="server" Width="170px" SkinID="txtDisabled"></asp:TextBox>
                                                        </td>
                                                        <td align="left" valign="top">Date Sent to Client
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtDateSendToClient" runat="server" Width="170px" SkinID="txtDisabled"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Event Description
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtFK_LU_Event_Description" runat="server" Width="170px" SkinID="txtDisabled"></asp:TextBox>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Date Opened
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtDate_Opened" runat="server" Width="170px" SkinID="txtDisabled"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Event Occurance Date
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtEventOccuranceDate" runat="server" Width="170px" SkinID="txtDisabled"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            <asp:LinkButton ID="lnkbtnViewCalatlanticData" runat="server" Text="View ACI Data"
                                                                Enabled="false" OnClick="lnkbtnViewCalatlanticData_Click"></asp:LinkButton>
                                                            <%--Change Header text from Cal Atlantic to ACI as per client's request Bug ID = 2552--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <div class="bandHeaderRow">
                                                                Event Review
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            <span style="text-decoration: underline">Report/Event</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Potential Risk&nbsp;<span id="Span62" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtPotential_Risk" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            <span style="text-decoration: underline">Event</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Action Taken&nbsp;<span id="Span63" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtAction_Taken" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            <span style="text-decoration: underline">Case</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Was Law Enforcement Notified?
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList ID="rdoWas_Law_Enforcement_Notified" runat="server" SkinID="YesNoType">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Officer Name&nbsp;<span id="Span64" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtOfficer_Name" runat="server" Width="170px" MaxLength="50" />
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Phone Number&nbsp;<span id="Span65" style="color: Red; display: none;" runat="server">*</span><br />
                                                            (XXX-XXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtPhone_Number" runat="server" Width="170px" SkinID="txtPhone"
                                                                MaxLength="12" />
                                                            <asp:RegularExpressionValidator ID="revtxtPhone_Number" ControlToValidate="txtPhone_Number"
                                                                runat="server" ErrorMessage="Please Enter Phone Number in XXX-XXX-XXXX format."
                                                                ValidationGroup="vsErrorCalAtlantic" Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" valign="top">E-Mail&nbsp;<span id="Span66" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtEMail" runat="server" Width="170px" MaxLength="255" />
                                                            <asp:RegularExpressionValidator ID="regtxtEMail" runat="server" ControlToValidate="txtEMail"
                                                                Display="None" ErrorMessage="Please Enter Valid E-Mail Address" SetFocusOnError="True"
                                                                ValidationGroup="vsErrorCalAtlantic" ToolTip="Please Enter Valid E-Mail Address"
                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Law Enforcement Agency&nbsp;<span id="Span67" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtLaw_Enforcement_Agency" runat="server" Width="170px" MaxLength="100" />
                                                        </td>
                                                        <td align="left" valign="top">Location&nbsp;<span id="Span68" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtLocation" runat="server" Width="170px" MaxLength="75" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Police Report Number&nbsp;<span id="Span69" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtPolice_Report_Number" runat="server" Width="170px" MaxLength="25" />
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Notes&nbsp;<span id="Span70" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtNotes" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            <span style="text-decoration: underline">Insurance Claim Type</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:RadioButtonList ID="rblInsuranceClaimType" runat="server" RepeatColumns="2"
                                                                AutoPostBack="true" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblInsuranceClaimType_SelectedIndexChanged">
                                                                <asp:ListItem Text="Auto Liability" Value="Auto Liability"></asp:ListItem>
                                                                <asp:ListItem Text="DPD" Value="DPD"></asp:ListItem>
                                                                <asp:ListItem Text="Premises Liability" Value="Premises Liability"></asp:ListItem>
                                                                <asp:ListItem Text="Property Damage" Value="Property Damage"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Associated FROI Number&nbsp;<span id="Span71" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="ddlAssociateFROINo" runat="server" Width="170px">
                                                                <asp:ListItem Text="--Select--" Value="0" />
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left" valign="top">Associated Claim Number&nbsp;<span id="Span72" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <asp:DropDownList ID="ddlAssociatedClaimNo" runat="server" Width="170px">
                                                                <asp:ListItem Text="--Select--" Value="0" />
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">What is the event’s root cause?&nbsp;<span id="Span73" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtCalRoot_Cause" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">How can the event be prevented from happening again?&nbsp;<span id="Span74" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtevent_Prevention" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Who has been tasked with implementing practices/procedures to prevent re-occurrence?&nbsp;<span
                                                            id="Span75" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtCalPerson_Tasked" runat="server" Width="170px" MaxLength="50" />
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Target Date of Completion&nbsp;<span id="Span76" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtCalTarget_Date_of_Completion" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Target Date of Completion" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtCalTarget_Date_of_Completion', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="vsErrorCalAtlantic"
                                                                Display="none" ErrorMessage="[ACI]/Target Date of Completion is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtCalTarget_Date_of_Completion" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            <%--Change Header text from Cal Atlantic to ACI as per client's request Bug ID = 2552--%>
                                                        </td>
                                                        <td align="left" valign="top">Status Due On&nbsp;<span id="Span77" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtCalStatus_Due_On" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Status Due On" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtCalStatus_Due_On', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="vsErrorCalAtlantic"
                                                                Display="none" ErrorMessage="[ACI]/Status Due On is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtCalStatus_Due_On" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            <%--Change Header text from Cal Atlantic to ACI as per client's request Bug ID = 2552--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Comments&nbsp;<span id="Span78" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtCalComments" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Financial Loss&nbsp;<span id="Span79" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">$&nbsp;<asp:TextBox ID="txtCalFinancial_Loss" runat="server" Width="170px" onkeypress="return currencyFormat(this,',','.',event);"
                                                            onpaste="return false" />
                                                        </td>
                                                        <td align="left" valign="top">Recovery&nbsp;<span id="Span80" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">$&nbsp;
                                                            <asp:TextBox ID="txtCalRecovery" runat="server" Width="170px" onkeypress="return currencyFormat(this,',','.',event);"
                                                                onpaste="return false" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Item Status&nbsp;<span id="Span81" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="ddlCalAtlantic_Item_Status" runat="server">
                                                                <asp:ListItem Text="--Select--" Value="0" />
                                                                <asp:ListItem Text="Open" Value="O" />
                                                                <asp:ListItem Text="Close" Value="C" />
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <div id="dvCalAtlanticSave" runat="server" style="display: none;">
                                                <table cellpadding="5" cellspacing="0" border="0" width="100%">
                                                    <tr>
                                                        <td width="50%" align="right">
                                                            <asp:Button ID="btnCalAtlanicSave" runat="server" Text="Save" OnClick="btnCalAtlanicSave_Click"
                                                                CausesValidation="true" ValidationGroup="vsErrorCalAtlantic" />
                                                        </td>
                                                        <td align="left">
                                                            <asp:Button ID="btnCal_AtlanticAudit_Trail" Text="View Audit Trail" runat="server"
                                                                OnClientClick="return openAP_Cal_Atlantic_AuditPopup();" CausesValidation="false"
                                                                Visible="false" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <asp:Panel ID="pnl5" runat="server" Style="display: none;" Width="794px">
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%" id="tblMainFraudEvent"
                                                    runat="server">
                                                    <tr>
                                                        <td valign="top" align="right" colspan="6">
                                                            <table>
                                                                <tr>
                                                                    <td width="30%"></td>
                                                                    <td>
                                                                        <uc:ctrlPaging ID="CtrlPaging_Fraud" runat="server" OnGetPage="GetPageFROIs_Fraud" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <asp:GridView ID="gvFraudEvent" runat="server" GridLines="None" CellPadding="4" CellSpacing="0"
                                                                AllowSorting="true" AutoGenerateColumns="false" Width="100%" EnableTheming="false"
                                                                OnRowCommand="gvFraudEvent_RowCommand" OnSorting="gvFraudEvent_Sorting" OnRowCreated="gvFraudEvent_OnRowCreated">
                                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <RowStyle BackColor="#EAEAEA" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <EditRowStyle BackColor="#2461BF" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <PagerStyle BackColor="#7f7f7f" ForeColor="White" HorizontalAlign="Center" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <HeaderStyle BackColor="#7f7f7f" Font-Bold="True" ForeColor="White" Font-Names="Tahoma"
                                                                    Font-Size="8pt" VerticalAlign="Bottom" />
                                                                <AlternatingRowStyle BackColor="White" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <EmptyDataRowStyle CssClass="emptyrow" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Fraud Number" HeaderStyle-HorizontalAlign="Left" SortExpression="Fraud_Number">
                                                                        <ItemStyle Width="13%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnFraudNumber" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_AP_Fraud_Events")%>'> 
                                                                            <%# Eval("Fraud_Number")%></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Exposure Period Begin Date" HeaderStyle-HorizontalAlign="Left"
                                                                        SortExpression="Exposure_Period_Begin_Date">
                                                                        <ItemStyle Width="23%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnBeginDate" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_AP_Fraud_Events")%>'> 
                                                                            <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Exposure_Period_Begin_Date"))%>
                                                                            
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Exposure Period End Date" HeaderStyle-HorizontalAlign="Left"
                                                                        ItemStyle-HorizontalAlign="Left" SortExpression="Exposure_Period_End_Date">
                                                                        <ItemStyle Width="21%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnEndDate" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_AP_Fraud_Events")%>'>
                                                                            <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Exposure_Period_End_Date"))%>
                                                                        
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Reported To" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                        SortExpression="Reported_To">
                                                                        <ItemStyle Width="" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnReportedTo" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_AP_Fraud_Events")%>'>
                                                                        <%# Eval("Reported_To")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Reported Date" HeaderStyle-HorizontalAlign="Left"
                                                                        ItemStyle-HorizontalAlign="Left" SortExpression="Reported_Date">
                                                                        <ItemStyle Width="14%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnReportedDate" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_AP_Fraud_Events")%>'>
                                                                            <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Reported_Date"))%>
                                                                            
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                        SortExpression="Close_File">
                                                                        <ItemStyle Width="7%" />
                                                                        <ItemTemplate>
                                                                            <%# Eval("STATUS")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemStyle Width="7%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnRemoveFruadEvent" runat="server" Text="Remove" OnClientClick="return confirm('Are you Sure to delete this record?');"
                                                                                CommandName="gvRemove" CommandArgument='<%# Eval("PK_AP_Fraud_Events")%>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                                <EmptyDataTemplate>
                                                                    <b>No Record found</b>
                                                                </EmptyDataTemplate>
                                                                <PagerSettings Visible="False" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">&nbsp;&nbsp;<asp:LinkButton ID="lnkbtnFraudEventAdd" runat="server" Text="--Add New--"
                                                            OnClick="lnkbtnFraudEventAdd_Click"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="5px" class="Spacer">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Event To be Included in Grid
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:RadioButtonList ID="rdoFraud_EventTo_Include" runat="server" OnSelectedIndexChanged="rdoFraud_EventTo_Include_OnSelectedIndexChanged"
                                                                AutoPostBack="true">
                                                                <asp:ListItem Selected="True" Text="Open" Value="O"></asp:ListItem>
                                                                <asp:ListItem Text="Closed" Value="C"></asp:ListItem>
                                                                <asp:ListItem Text="All" Value="A"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <div class="bandHeaderRow">
                                                                Event Claim
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="18%">Fraud Number
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="28%">
                                                            <asp:TextBox ID="txtFraudNumber" runat="server" Width="170px" SkinID="txtDisabled"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="18%">Exposure Period Begin Date&nbsp;<span id="Span82" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="28%">
                                                            <asp:TextBox ID="txtExpPeriodBeginDate" runat="server" Width="170px" SkinID="txtDate"></asp:TextBox>
                                                            <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtExpPeriodBeginDate', 'mm/dd/y','','');"
                                                                onmouseover="javascript:this.style.cursor='hand';" alt="" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revtxtExpPeriodBeginDate" runat="server" ValidationGroup="vsErrorFraudEvents"
                                                                Display="none" ErrorMessage="[Fraud-Events]/Exposure Period Begin Date" SetFocusOnError="true"
                                                                ControlToValidate="txtExpPeriodBeginDate" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" valign="top" width="18%">Exposure Period End Date&nbsp;<span id="Span83" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="28%">
                                                            <asp:TextBox ID="txtExpoPeriodEndDate" runat="server" Width="170px" SkinID="txtDate"></asp:TextBox>
                                                            <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtExpoPeriodEndDate', 'mm/dd/y','','');"
                                                                onmouseover="javascript:this.style.cursor='hand';" alt="" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revtxtExpoPeriodEndDate" runat="server" ValidationGroup="vsErrorFraudEvents"
                                                                Display="none" ErrorMessage="[Fraud-Events]/Exposure Period End Date" SetFocusOnError="true"
                                                                ControlToValidate="txtExpoPeriodEndDate" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            <asp:CompareValidator ID="cvCompDate" runat="server" ControlToValidate="txtExpoPeriodEndDate"
                                                                ValidationGroup="vsErrorFraudEvents" ErrorMessage="Exposure Period End Date Must Be Greater Than Exposure Period Begin Date"
                                                                Type="Date" Operator="GreaterThanEqual" ControlToCompare="txtExpPeriodBeginDate"
                                                                Display="none">
                                                            </asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="18%">Reported To&nbsp;<span id="Span84" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="28%">
                                                            <asp:TextBox ID="txtReportedTo" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                                                        </td>
                                                        <td align="left" valign="top" width="18%">Reported Date&nbsp;<span id="Span85" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="28%">
                                                            <asp:TextBox ID="txtReportedDate" runat="server" Width="170px" SkinID="txtDate"></asp:TextBox>
                                                            <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtReportedDate', 'mm/dd/y','','');"
                                                                onmouseover="javascript:this.style.cursor='hand';" alt="" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revtxtReportedDate" runat="server" ValidationGroup="vsErrorFraudEvents"
                                                                Display="none" ErrorMessage="[Fraud-Events]/Reported Date" SetFocusOnError="true"
                                                                ControlToValidate="txtReportedDate" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Description of Event&nbsp;<span id="Span86" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtDesciptionofEvent" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <div class="bandHeaderRow">
                                                                Notification
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkCustomerRelationsHotLine" runat="server" Text="Customer Relations Hot Line" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkDiscoveredFraudthroughAudits" runat="server" Text="Discovered Fraud through Audits" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkIntrnlAditCntrlLeadToFraudEvent" runat="server" Text="Internal Audit Control Breakdown leading to Fraud Event" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkRetailLending" runat="server" Text="Retail Lending" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkSonicAssociate1800HotLine" runat="server" Text="Sonic Associate 1-800 Hot Line" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkStoreRedFlags" runat="server" Text="Store Red Flags" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkOther" runat="server" Text="Other" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Other Notification Description&nbsp;<span id="Span87" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtOther_Notification_Description" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <div class="bandHeaderRow">
                                                                Initial Review
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Initial Claim Review Purification Notes&nbsp;<span id="Span88" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtInternal_Review_Purification_Notes" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Fraud Date&nbsp;<span id="Span89" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtFraud_Date" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Fraud Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtFraud_Date', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revFraud_Date" runat="server" ValidationGroup="vsErrorFraudEvents"
                                                                Display="none" ErrorMessage="[Fraud Events]/Fraud Date is not a valid date" SetFocusOnError="true"
                                                                ControlToValidate="txtFraud_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <div class="bandHeaderRow">
                                                                Partnership Assignments
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">HR Assignment&nbsp;<span id="Span90" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtHR_Assignment" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">HR Associate Contacted&nbsp;<span id="Span91" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtHR_Associate_Contacted" runat="server" Width="170px" MaxLength="50" />
                                                        </td>
                                                        <td align="left" valign="top">Date HR Assigned&nbsp;<span id="Span92" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtDate_HR_Assigned" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Date HR Assigned" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_HR_Assigned', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revDate_HR_Assigned" runat="server" ValidationGroup="vsErrorFraudEvents"
                                                                Display="none" ErrorMessage="[Fraud Events]/Date HR Assigned is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtDate_HR_Assigned" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Internal Audit Assignment&nbsp;<span id="Span93" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtInternal_Audit_Assignment" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Internal Audit Associate Contacted&nbsp;<span id="Span94" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtInternal_Audit_Associate_Contacted" runat="server" Width="170px"
                                                                MaxLength="50" />
                                                        </td>
                                                        <td align="left" valign="top">Date Internal Audit Assigned&nbsp;<span id="Span95" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtDate_Internal_Audit_Assigned" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Date Internal Audit Assigned" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Internal_Audit_Assigned', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revDate_Internal_Audit_Assigned" runat="server"
                                                                ValidationGroup="vsErrorFraudEvents" Display="none" ErrorMessage="[Fraud Events]/Date Internal Audit Assigned is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtDate_Internal_Audit_Assigned" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Store Controller Assignment&nbsp;<span id="Span96" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtStore_Controller_Assignment" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Store Controller Associate Contacted&nbsp;<span id="Span97" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtStore_Controller_Associate_Contacted" runat="server" Width="170px"
                                                                MaxLength="50" />
                                                        </td>
                                                        <td align="left" valign="top">Date Store Controller Assigned&nbsp;<span id="Span98" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtDate_Store_Controller_Assigned" runat="server" Width="150px"
                                                                SkinID="txtDate" />
                                                            <img alt="Date Store Controller Assigned" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Store_Controller_Assigned', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revDate_Store_Controller_Assigned" runat="server"
                                                                ValidationGroup="vsErrorFraudEvents" Display="none" ErrorMessage="[Fraud Events]/Date Store Controller Assigned is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtDate_Store_Controller_Assigned"
                                                                ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Regional Controller Assignment&nbsp;<span id="Span99" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtRegional_Controller_Assignment" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Regional Controller Associate Contacted&nbsp;<span id="Span100" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtRegional_Controller_Associate_Contacted" runat="server" Width="170px"
                                                                MaxLength="50" />
                                                        </td>
                                                        <td align="left" valign="top">Date Regional Controller Assigned&nbsp;<span id="Span101" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtDate_Regional_Controller_Assigned" runat="server" Width="150px"
                                                                SkinID="txtDate" />
                                                            <img alt="Date Regional Controller Assigned" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Regional_Controller_Assigned', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revDate_Regional_Controller_Assigned" runat="server"
                                                                ValidationGroup="vsErrorFraudEvents" Display="none" ErrorMessage="[Fraud Events]/Date Regional Controller Assigned is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtDate_Regional_Controller_Assigned"
                                                                ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Legal Department Assignment&nbsp;<span id="Span102" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtLegal_Department_Assignment" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Legal Department Associate Contacted&nbsp;<span id="Span103" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtLegal_Department_Associate_Contacted" runat="server" Width="170px"
                                                                MaxLength="50" />
                                                        </td>
                                                        <td align="left" valign="top">Date Legal Department Assigned&nbsp;<span id="Span104" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtDate_Legal_Department_Assigned" runat="server" Width="150px"
                                                                SkinID="txtDate" />
                                                            <img alt="Date Legal Department Assigned" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Legal_Department_Assigned', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revDate_Legal_Department_Assigned" runat="server"
                                                                ValidationGroup="vsErrorFraudEvents" Display="none" ErrorMessage="[Fraud Events]/Date Legal Department Assigned is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtDate_Legal_Department_Assigned"
                                                                ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Outside Legal Assignment&nbsp;<span id="Span105" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtOutside_Legal_Assignment" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Outside Legal Person Contacted&nbsp;<span id="Span106" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtOutside_Legal_Associate_Contacted" runat="server" Width="170px"
                                                                MaxLength="50" />
                                                        </td>
                                                        <td align="left" valign="top">Date Outside Legal Assigned&nbsp;<span id="Span107" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtDate_Outside_Legal_Assigned" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Date Outside Legal Assigned" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Outside_Legal_Assigned', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revDate_Outside_Legal_Assigned" runat="server"
                                                                ValidationGroup="vsErrorFraudEvents" Display="none" ErrorMessage="[Fraud Events]/Date Outside Legal Assigned is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtDate_Outside_Legal_Assigned" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Operations Assignment&nbsp;<span id="Span108" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtOperations_Assignment" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Operations Associate Contacted&nbsp;<span id="Span109" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtOperations_Associate_Contacted" runat="server" Width="170px"
                                                                MaxLength="50" />
                                                        </td>
                                                        <td align="left" valign="top">Date Operations Assigned&nbsp;<span id="Span110" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtDate_Operations_Assigned" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Date Operations Assigned" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Operations_Assigned', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revDate_Operations_Assigned" runat="server" ValidationGroup="vsErrorFraudEvents"
                                                                Display="none" ErrorMessage="[Fraud Events]/Date Operations Assigned is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtDate_Operations_Assigned" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Retail Lending Assignment&nbsp;<span id="Span111" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtRetail_Lending_Assignment" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Retail Lending Associate Contacted&nbsp;<span id="Span112" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtRetail_Lending_Associate_Contacted" runat="server" Width="170px"
                                                                MaxLength="50" />
                                                        </td>
                                                        <td align="left" valign="top">Date Retail Lending Assigned&nbsp;<span id="Span113" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtDate_Retail_Lending_Assigned" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Date Retail Lending Assigned" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Retail_Lending_Assigned', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revDate_Retail_Lending_Assigned" runat="server"
                                                                ValidationGroup="vsErrorFraudEvents" Display="none" ErrorMessage="[Fraud Events]/Date Retail Lending Assigned is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtDate_Retail_Lending_Assigned" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">BT Security Assignment&nbsp;<span id="Span135" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtBT_Security_Assignment" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">BT Security Associate Contacted&nbsp;<span id="Span136" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtBT_Security_Associate_Contacted" runat="server" Width="170px"
                                                                MaxLength="50" />
                                                        </td>
                                                        <td align="left" valign="top">Date BT Security Assigned&nbsp;<span id="Span137" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtDate_BT_Security_Assigned" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Date BT Security Assigned" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_BT_Security_Assigned', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revtxtDate_BT_Security_Assigned" runat="server"
                                                                ValidationGroup="vsErrorFraudEvents" Display="none" ErrorMessage="[Fraud Events]/Date BT Security Assigned is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtDate_BT_Security_Assigned" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Other Assignment&nbsp;<span id="Span138" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtOther_Assignment" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Other/Person Contacted&nbsp;<span id="Span139" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtAssociated_Contacted" runat="server" Width="170px" MaxLength="50" />
                                                        </td>
                                                        <td align="left" valign="top">Date Assigned&nbsp;<span id="Span140" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtDate_Assigned" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Date Assigned" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Assigned', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revtxtDate_Assigned" runat="server" ValidationGroup="vsErrorFraudEvents"
                                                                Display="none" ErrorMessage="[Fraud Events]/Date Assigned is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtDate_Assigned" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Notes Grid
                                                            <br />
                                                            <asp:LinkButton ID="lnkAddFraudNotesGrid" runat="server" Text="--Add--" OnClick="lnkAddFraudNotesGrid_Click"
                                                                ValidationGroup="vsErrorFraudEvents" CausesValidation="true"></asp:LinkButton>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:GridView ID="gvFraudEventsNote" runat="server" GridLines="None" CellPadding="4" CellSpacing="0" OnSorting="gvFraudEventsNote_Sorting"
                                                                AutoGenerateColumns="false" Width="100%" EnableTheming="false" OnRowCommand="gvFraudEventsNote_RowCommand" AllowSorting="true">
                                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <RowStyle BackColor="#EAEAEA" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <EditRowStyle BackColor="#2461BF" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <PagerStyle BackColor="#7f7f7f" ForeColor="White" HorizontalAlign="Center" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <HeaderStyle BackColor="#7f7f7f" Font-Bold="True" ForeColor="White" Font-Names="Tahoma"
                                                                    Font-Size="8pt" VerticalAlign="Bottom" />
                                                                <AlternatingRowStyle BackColor="White" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <EmptyDataRowStyle CssClass="emptyrow" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Date" HeaderStyle-HorizontalAlign="Left" SortExpression="Note_Date">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnNoteDate" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_AP_FE_PA_Notes") %>'> 
                                                                            <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Note_Date"))%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Note Text" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemStyle Width="" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lblNotes" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_AP_FE_PA_Notes") %>' CssClass="TextClip" Width="410px">
                                                                                <%# Eval("Note")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                        <ItemStyle Width="10%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnRemove" runat="server" Text="Remove" OnClientClick="return confirm('Are you Sure to delete this record?');"
                                                                                CommandName="Remove" CommandArgument='<%# Eval("PK_AP_FE_PA_Notes") %>'>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                                <EmptyDataTemplate>
                                                                    <b>No Record found</b>
                                                                </EmptyDataTemplate>
                                                                <PagerSettings Visible="False" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>



                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <div class="bandHeaderRow">
                                                                NAPM Investigation
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">On-Site Findings&nbsp;<span id="Span114" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtOnSite_Findings" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">TLO Findings&nbsp;<span id="Span115" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtTLO_Findings" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Statements Obtained&nbsp;<span id="Span116" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtStatements_Obtained" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Fact Finding/Due-Diligence&nbsp;<span id="Span117" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtFact_Finding_andor_Due_Diligence" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Law Enforcement Involvement&nbsp;<span id="Span118" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtLaw_Enforcement_Involvement" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <div class="bandHeaderRow">
                                                                Disposition Game Plan
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkCivilAction" runat="server" Text="Civil Action" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkCriminalAction" runat="server" Text="Criminal Action" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkFurtherInvestigation" runat="server" Text="Further Investigation" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top">
                                                            <span style="text-decoration: underline">Associate Corrective Action</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkSuspension" runat="server" Text="Suspension" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkTermination" runat="server" Text="Termination" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkWritten" runat="server" Text="Written" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkVerbal" runat="server" Text="Verbal" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkCommunicationStrategy" runat="server" Text="Communication Strategy (Internal and External)" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkGamePlanOther" runat="server" Text="Other" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Detailed Disposition Game Plan Description&nbsp;<span id="Span119" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtDetailed_Deisposition_Game_Plan_Description" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top">
                                                            <asp:CheckBox ID="chkAccountingGapsandControl" runat="server" Text="Accounting Gaps and Controls" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top">
                                                            <span style="text-decoration: underline">Red Flags Missed</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkMFRIncentives" runat="server" Text="Aging – MFR Incentives" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkAgingWarranties" runat="server" Text="Aging – Warranties" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkAccountPayableSchemes" runat="server" Text="Account Payable Schemes" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkAssociateCollusion" runat="server" Text="Associate(s) Collusion" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkBillingSchemes" runat="server" Text="Billing Schemes" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkExternalScam" runat="server" Text="External Scam" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkImproperDisclosuretoCustomerFandIProductPurchase" runat="server"
                                                                            Text="Improper Disclosure to Customer F&I Product Purchase" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkImproperDisclosuretoCustomerVehiclePurchase" runat="server"
                                                                            Text="Improper Disclosure to Customer Vehicle Purchase" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkInventorySchemes" runat="server" Text="Inventory Schemes" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkOperasionsNoAdherencetoSonicPolicyandPlaybook" runat="server"
                                                                            Text="Operations – No Adherence to Sonic Policy and Playbook" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkVendorCollusion" runat="server" Text="Vendor Collusion" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkVendorSchemes" runat="server" Text="Vendor Schemes" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkMonthlyARControlReview" runat="server" Text="Monthly A/R Control Review" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkDispositionGameplanOther" runat="server" Text="Other" /></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Detail Description of Root Cause&nbsp;<span id="Span120" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtDetail_Description_of_Root_Cause" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <div class="bandHeaderRow">
                                                                Corrective Action/Recommendation
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkchangeaControl" runat="server" Text="Change a Control" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkCurrentSystemEnhancement" runat="server" Text="Current System Enhancement" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkImplementPolicy" runat="server" Text="Implement Policy" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkNewSystemChange" runat="server" Text="New System Change" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkResultOfDespositionPlan" runat="server" Text="Results of Disposition Plan" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkRetraining" runat="server" Text="Re-Training" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkTraining" runat="server" Text="Training" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkCorrectiveActionRecommendationOther" runat="server" Text="Other" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Detailed Description of Corrective Action/Recommendation&nbsp;<span id="Span121"
                                                            style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtDetail_Description_of_Corrective_Action_andor_Recommendation"
                                                                runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <div class="bandHeaderRow">
                                                                Asset Protection Committee
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Notes Grid
                                                            <br />
                                                            <asp:LinkButton ID="lnkbtnAddNotesGrid" runat="server" Text="--Add--" OnClick="lnkbtnAddNotesGrid_Click"
                                                                ValidationGroup="vsErrorFraudEvents" CausesValidation="true"></asp:LinkButton>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:GridView ID="gvNotesGrid" runat="server" GridLines="None" CellPadding="4" CellSpacing="0"
                                                                AutoGenerateColumns="false" Width="100%" EnableTheming="false" OnRowCommand="gvNotesGrid_RowCommand">
                                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <RowStyle BackColor="#EAEAEA" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <EditRowStyle BackColor="#2461BF" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <PagerStyle BackColor="#7f7f7f" ForeColor="White" HorizontalAlign="Center" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <HeaderStyle BackColor="#7f7f7f" Font-Bold="True" ForeColor="White" Font-Names="Tahoma"
                                                                    Font-Size="8pt" VerticalAlign="Bottom" />
                                                                <AlternatingRowStyle BackColor="White" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <EmptyDataRowStyle CssClass="emptyrow" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Date" HeaderStyle-HorizontalAlign="Left" SortExpression="Note_Date">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnNoteDate" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_AP_FE_Notes") %>'> 
                                                                            <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Note_Date"))%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Note Text" HeaderStyle-HorizontalAlign="Left" SortExpression="Note">
                                                                        <ItemStyle Width="" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblNotes" runat="server" CssClass="TextClip" Width="410px">
                                                                                <%# Eval("Note")%>
                                                                            </asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                        <ItemStyle Width="10%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnRemove" runat="server" Text="Remove" OnClientClick="return confirm('Are you Sure to delete this record?');"
                                                                                CommandName="Remove" CommandArgument='<%# Eval("PK_AP_FE_Notes") %>'>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                                <EmptyDataTemplate>
                                                                    <b>No Record found</b>
                                                                </EmptyDataTemplate>
                                                                <PagerSettings Visible="False" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <div class="bandHeaderRow">
                                                                Event Claim Status
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Close File
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList ID="rdoClose_File" runat="server" SkinID="YesNoType">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left" valign="top">Close Date&nbsp;<span id="Span122" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtClose_Date" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Close Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtClose_Date', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revClose_Date" runat="server" ValidationGroup="vsErrorFraudEvents"
                                                                Display="none" ErrorMessage="[Fraud Events]/Close Date is not a valid date" SetFocusOnError="true"
                                                                ControlToValidate="txtClose_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Reopen File
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList ID="rdoReopen_File" runat="server" SkinID="YesNoType">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left" valign="top">Reopen Date&nbsp;<span id="Span123" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtReopen_Date" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Reopen Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtReopen_Date', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revReopen_Date" runat="server" ValidationGroup="vsErrorFraudEvents"
                                                                Display="none" ErrorMessage="[Fraud Events]/Reopen Date is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtReopen_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Comments&nbsp;<span id="Span124" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtFraudEvent_Comments" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <div class="bandHeaderRow">
                                                                Financial Risk Exposure Grid
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Financial Reserve Grid
                                                            <br />
                                                            <asp:LinkButton ID="lnkbtnAddFinancialGrid" runat="server" Text="--Add--" OnClick="lnkbtnAddFinancialGrid_Click"
                                                                ValidationGroup="vsErrorFraudEvents" CausesValidation="true"></asp:LinkButton>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:GridView ID="gvFinancialReserveTransaction" runat="server" GridLines="None"
                                                                CellPadding="4" CellSpacing="0" AutoGenerateColumns="false" Width="100%" EnableTheming="false"
                                                                OnRowCommand="gvFinancialReserveTransaction_RowCommand">
                                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <RowStyle BackColor="#EAEAEA" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <EditRowStyle BackColor="#2461BF" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <PagerStyle BackColor="#7f7f7f" ForeColor="White" HorizontalAlign="Center" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <HeaderStyle BackColor="#7f7f7f" Font-Bold="True" ForeColor="White" Font-Names="Tahoma"
                                                                    Font-Size="8pt" VerticalAlign="Bottom" />
                                                                <AlternatingRowStyle BackColor="White" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <EmptyDataRowStyle CssClass="emptyrow" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Type" HeaderStyle-HorizontalAlign="Left" SortExpression="Type">
                                                                        <ItemStyle Width="" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnNoteDate" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_AP_FE_Transactions") %>'> <%# Eval("Type")%>&nbsp;<%# Eval("Category")%></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Date" HeaderStyle-HorizontalAlign="Left" SortExpression="Transaction_Date">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnTransactionDate" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_AP_FE_Transactions") %>'>
                                                                            <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Transaction_Date")) %>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Amount" HeaderStyle-HorizontalAlign="Left" SortExpression="Transaction_Amount">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Right" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnTransactionAmount" runat="server" CommandName="gvEdit"
                                                                                CommandArgument='<%# Eval("PK_AP_FE_Transactions") %>'>
                                                                            <%# string.Format("{0:C2}",Eval("Transaction_Amount"))%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnRemove" runat="server" Text="Remove" OnClientClick="return confirm('Are you Sure to delete this record?');"
                                                                                CommandName="Remove" CommandArgument='<%# Eval("PK_AP_FE_Transactions") %>'>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                                <EmptyDataTemplate>
                                                                    <b>No Record found</b>
                                                                </EmptyDataTemplate>
                                                                <PagerSettings Visible="False" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Financial Matrix
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%" cellspacing="0px" cellpadding="5px">
                                                                <tr class="bandHeaderRow">
                                                                    <td align="left" valign="top" width="25%"></td>
                                                                    <td align="right" valign="top" width="25%">Potential Loss Exposure
                                                                    </td>
                                                                    <td align="right" valign="top" width="25%">Expense
                                                                    </td>
                                                                    <td align="right" valign="top" width="25%">Total
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" width="25%" class="bandHeaderRow">Reserve
                                                                    </td>
                                                                    <td align="right" valign="top" width="25%">
                                                                        <asp:Label ID="lblFMReservePotentialLoss" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="right" valign="top" width="25%">
                                                                        <asp:Label ID="lblFMReserveExpense" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="right" valign="top" width="25%">
                                                                        <asp:Label ID="lblFMReserveTotal" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" width="25%" class="bandHeaderRow">Paid
                                                                    </td>
                                                                    <td align="right" valign="top" width="25%">
                                                                        <asp:Label ID="lblFMPaidPotentialLoss" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="right" valign="top" width="25%">
                                                                        <asp:Label ID="lblFMPaidExpense" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="right" valign="top" width="25%">
                                                                        <asp:Label ID="lblFMPaidTotal" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" width="25%" class="bandHeaderRow">Recovery
                                                                    </td>
                                                                    <td align="right" valign="top" width="25%">
                                                                        <asp:Label ID="lblFMRecoveryPotentialLoss" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="right" valign="top" width="25%">
                                                                        <asp:Label ID="lblFMRecoveryExpense" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="right" valign="top" width="25%">
                                                                        <asp:Label ID="lblFMRecoveryTotal" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" width="25%" class="bandHeaderRow">Outstanding
                                                                    </td>
                                                                    <td align="right" valign="top" width="25%">
                                                                        <asp:Label ID="lblFMOutstandingPotentialLoss" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="right" valign="top" width="25%">
                                                                        <asp:Label ID="lblFMOutstandingExpense" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="right" valign="top" width="25%">
                                                                        <asp:Label ID="lblFMOutstandingTotal" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <asp:Panel ID="pnlNoteGridAdd" runat="server" Width="100%" Style="display: none;">
                                                    <div class="bandHeaderRow">
                                                        Notes Grid
                                                    </div>
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <td align="left" width="21%" valign="top">Date&nbsp;<span id="Span130" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtNotesDate" runat="server" Width="170px" SkinID="txtDate"></asp:TextBox>
                                                                <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtNotesDate', 'mm/dd/y','','');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" alt="" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RegularExpressionValidator ID="revtxtNotesDate" runat="server" ValidationGroup="vsErrorFraudEventsNotes"
                                                                    Display="none" ErrorMessage="Date is not a valid" SetFocusOnError="true" ControlToValidate="txtNotesDate"
                                                                    ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                                <%--<asp:RangeValidator ID="regtxtNotesDate" ControlToValidate="txtNotesDate"
                                                                            MinimumValue="01/01/1753" MaximumValue="12/31/2010" Type="Date" ErrorMessage="Date must be valid."
                                                                            runat="server" SetFocusOnError="true" ValidationGroup="vsErrorNotesAdd" Display="none" />--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Note Text&nbsp;<span id="Span125" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="txtNotesAdd" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3" align="left" valign="top">
                                                                <table border="0" align="center" cellpadding="0" cellspacing="5">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Button ID="btnNotesGridAdd" runat="server" Text="Save" CausesValidation="true" Visible="false"
                                                                                OnClick="btnNotesGridAdd_Click" ValidationGroup="vsErrorFraudEventsNotes" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="btnViewAuditNotesGrid" runat="server" Text="View Audit Trail" OnClientClick="return openAP_FE_Notes_AuditPopup();"
                                                                                CausesValidation="false" Visible="false" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="btnFraudNotesGridAdd" runat="server" Text="Save" CausesValidation="true" Visible="false"
                                                                                OnClick="btnFraudNotesGridAdd_Click" ValidationGroup="vsErrorFraudEventsNotes" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="btnViewFraudAuditNotesGrid" runat="server" Text="View Audit Trail" OnClientClick="return openAP_FE_PA_Notes_AuditPopup();"
                                                                                CausesValidation="false" Visible="false" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="btnBackFraudEvent" runat="server" Text="Back" OnClick="btnBackFraudEventFromTransaction_Click" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlTransactionGridAdd" runat="server" Width="100%" Style="display: none;">
                                                    <div class="bandHeaderRow">
                                                        Transaction Grid
                                                    </div>
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <td align="left" width="21%" valign="top">Transaction Type&nbsp;<span id="Span126" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top" width="75%" colspan="4">
                                                                <asp:DropDownList ID="ddlTransactionType" runat="server" SkinID="ddlExposure">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="21%" valign="top">Transaction Catagory&nbsp;<span id="Span127" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top" width="75%" colspan="4">
                                                                <asp:DropDownList ID="ddlTransactionCatagory" runat="server" SkinID="ddlExposure">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="21%" valign="top">Transaction Date&nbsp;<span id="Span128" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top" colspan="4">
                                                                <asp:TextBox ID="txtTransactionDate" runat="server" Width="170px" SkinID="txtDate"></asp:TextBox>
                                                                <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtTransactionDate', 'mm/dd/y','');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" alt="" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RegularExpressionValidator ID="revtxtTransactionDate" runat="server" ValidationGroup="vsErrorFraudEventsTransaction"
                                                                    Display="none" ErrorMessage="Transaction Date is not a valid Date" SetFocusOnError="true"
                                                                    ControlToValidate="txtTransactionDate" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top" width="21%">Transaction Amount&nbsp;<span id="Span129" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top" colspan="4">$<asp:TextBox ID="txtTransactionAmount" runat="server" Width="170px" onkeypress="return FormatNumber(event,this.id,13,false);"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" align="left" valign="top">
                                                                <table border="0" align="center" cellpadding="0" cellspacing="5">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Button ID="btnTransactionGridAdd" runat="server" Text="Save" CausesValidation="true"
                                                                                ValidationGroup="vsErrorFraudEventsTransaction" OnClick="btnTransactionGridAdd_Click" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="btnViewAuditTransactionGrid" runat="server" Text="View Audit Trail"
                                                                                OnClientClick="return openAP_FE_Transaction_AuditPopup();" CausesValidation="false"
                                                                                Visible="false" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="btnBackFraudEventFromTransaction" runat="server" Text="Back" OnClick="btnBackFraudEventFromTransaction_Click" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </asp:Panel>
                                            <div id="dvFraudEventSave" runat="server" style="display: none;">
                                                <table cellpadding="5" cellspacing="0" border="0" width="100%">
                                                    <tr>
                                                        <td width="50%" align="right">
                                                            <asp:Button ID="btnFraudEventSave" runat="server" Text="Save" OnClick="btnFraudEventSave_Click"
                                                                CausesValidation="true" ValidationGroup="vsErrorFraudEvents" />
                                                        </td>
                                                        <td align="left">
                                                            <asp:Button ID="btnFruad_EventAudit_Trail" Text="View Audit Trail" runat="server"
                                                                OnClientClick="return openFraud_Event_AuditPopup();" CausesValidation="false"
                                                                Visible="false" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                           <%-- <div id="dvAttachment" runat="server" style="display: none;">
                                                <table cellpadding="0" cellspacing="0" width="100%" style="height: 230px;">
                                                    <tr>
                                                        <td width="100%">
                                                            <uc:ctrlAttachment ID="Attachments" runat="Server" OnbtnHandler="btnAddAttachment_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Spacer" style="height: 20px;"></td>
                                                    </tr>
                                                </table>
                                            </div>--%>
                                        </div>
                                        <div id="dvView" runat="server" width="794px">
                                            <asp:Panel ID="pnl1View" runat="server" Style="display: none;" Width="794px">
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%" id="tblMainPropertySecurityView"
                                                    runat="server">
                                                    <tr>
                                                        <td colspan="6">
                                                            <strong>CCTV Alarm Systems</strong>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">CCTV Company Name
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lblCCTV_Company_Name" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">CCTV Company Address 1
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblCCTV_Company_Address_1" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top" width="18%">CCTV Company Address 2
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="28%">
                                                            <asp:Label ID="lblCCTV_Company_Address_2" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">CCTV Company City
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCCTV_Company_City" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">CCTV Company State
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_CCTV_Company_State" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">CCTV Company Zip
                                                            <br />
                                                            (99999-9999)
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCCTV_Company_Zip" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">CCTV Company Contact Name
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCCTV_Company_Contact_Name" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">CCTV Company Contact Telephone
                                                            <br />
                                                            (999-999-9999)
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCCTV_Comapny_Contact_Telephone" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">CCTV Company Contact E-Mail
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lblCCTV_Company_Contact_EMail" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">ACI System <%--Change Header text from Cal Atlantic to ACI as per client's request Bug ID = 2552--%>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCal_Atlantic_System" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Live Monitoring
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLive_Monitoring" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">CCTV Hours Monitoring Grid
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:GridView ID="gvCCTVHoursMonitoringGridView" runat="server" GridLines="None"
                                                                CellPadding="4" CellSpacing="0" AutoGenerateColumns="false" Width="100%" EnableTheming="false"
                                                                OnRowCommand="gvMonitoingGrid_RowCommand">
                                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <RowStyle BackColor="#EAEAEA" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <EditRowStyle BackColor="#2461BF" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <PagerStyle BackColor="#7f7f7f" ForeColor="White" HorizontalAlign="Center" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <HeaderStyle BackColor="#7f7f7f" Font-Bold="True" ForeColor="White" Font-Names="Tahoma"
                                                                    Font-Size="8pt" VerticalAlign="Bottom" />
                                                                <AlternatingRowStyle BackColor="White" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <EmptyDataRowStyle CssClass="emptyrow" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Day Monitoring Begins" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnDayMonitoringBegins" runat="server" CommandName="gvEdit"
                                                                                CommandArgument='<%# Eval("PK_AP_Property_Security_Monitor_Grids") %>'> 
                                                                            <%# Eval("Start_Day")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Time Monitoring Begins" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnTimeMonitoringBegins" runat="server" CommandName="gvEdit"
                                                                                CommandArgument='<%# Eval("PK_AP_Property_Security_Monitor_Grids") %>'> 
                                                                                <%# Eval("Start_Time")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Day Monitoring Ends" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnDayMonitoringEnds" runat="server" CommandName="gvEdit"
                                                                                CommandArgument='<%# Eval("PK_AP_Property_Security_Monitor_Grids") %>'> 
                                                                                <%# Eval("End_Day")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Time Monitoring Ends" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnTimeMonitoringEnds" runat="server" CommandName="gvEdit"
                                                                                CommandArgument='<%# Eval("PK_AP_Property_Security_Monitor_Grids") %>'> 
                                                                                <%# Eval("End_Time")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Hours" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnHours" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_AP_Property_Security_Monitor_Grids") %>'> 
                                                                                <%# Eval("Hours")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                                <EmptyDataTemplate>
                                                                    <b>No Record found</b>
                                                                </EmptyDataTemplate>
                                                                <PagerSettings Visible="False" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Exterior Camera Coverage
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkEccBackView" runat="server" Text="Back" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkEccCarwashView" runat="server" Text="Car Wash" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkEccFrontView" runat="server" Text="Front" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkEccsatelliteParkingView" runat="server" Text="Satellite Parking"
                                                                            Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkEccSideView" runat="server" Text="Side" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkEccZerodotLineView" runat="server" Text="Zero Lot Line (Showroom)"
                                                                            Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkEccOtherView" runat="server" Text="Other" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <table>
                                                                            <tr>
                                                                                <td align="left" valign="top">Number of External Cameras&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;    
                                                                                </td>
                                                                                <td align="center" valign="top">:&nbsp;&nbsp;&nbsp;
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label ID="lblNumberofExternalCameras" runat="server" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Exterior Camera Coverage – Other Description
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblExterior_Camera_Coverage_Other_Description" runat="server"
                                                                ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Interior Camera Coverage
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkIccBodyShopView" runat="server" Text="Body Shop" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkIccCashierView" runat="server" Text="Cashier" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkIccComputerRoomView" runat="server" Text="Computer Room" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkIccDetailBaysView" runat="server" Text="Detail Bays" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkIccKeyBoxAreaView" runat="server" Text="Key Box Area" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkIccPartsReceivingAreaView" runat="server" Text="Part Receiving Area"
                                                                            Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkIccServiceDepartmentView" runat="server" Text="Service Department"
                                                                            Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkIccServiceLaneView" runat="server" Text="Service Lane" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkIccShowRoomView" runat="server" Text="Showroom" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkIccSmartSafeOfficeView" runat="server" Text="Smart Safe Office"
                                                                            Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkIccOtherView" runat="server" Text="Other" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <table>
                                                                            <tr>
                                                                                <td align="left" valign="top">Number of Internal Cameras&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;    
                                                                                </td>
                                                                                <td align="center" valign="top">:&nbsp;&nbsp;&nbsp;
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label ID="lblNumberofInternalCameras" runat="server" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Interior Camera Coverage – Other Description
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblInterior_Camera_Coverage_Other_Description" runat="server"
                                                                ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="5px" class="Spacer">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <strong>Burglar Alarm Coverage</strong>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Burglar Alarm System
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblBuglar_Alarm_System" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Is System Active and Functioning Properly?
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblIs_System_Active_and_Function_Properly" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Burglar Alarm Company Name
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lblBurglar_Alarm_Company_Name" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Burglar Alarm Company Address 1
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblBurglar_Alarm_Company_Address_1" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Burglar Alarm Company Address 2
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblBurglar_Alarm_Company_Address_2" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Burglar Alarm Company City
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblBurglar_Alarm_Company_City" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Burglar Alarm Company State
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_Burglar_Alarm_Company_State" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Burglar Alarm Company Zip
                                                            <br />
                                                            (99999-9999)
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblBurglar_Alarm_Company_Zip" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Burglar Alarm Company Contact Name
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblBurglar_Alarm_Company_Contact_Name" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Burglar Alarm Company Contact Telephone<br />
                                                            (999-999-9999)
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblBurglar_Alarm_Comapny_Contact_Telephone" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Burglar Alarm Company Contact E-Mail
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lblBurglar_Alarm_Company_Contact_EMail" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Zone/Doors
                                                        </td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkZDCollisionCenterView" runat="server" Text="Collision Center"
                                                                            Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkZDOfficeView" runat="server" Text="Office" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkZDPartsView" runat="server" Text="Parts" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkZDSalesShowroomView" runat="server" Text="Sales Showroom" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkZDServiceView" runat="server" Text="Service" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkZDOtherView" runat="server" Text="Other" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Burglar Alarm Coverage – Other Description
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblBurglar_Alarm_Coverage_Other_Description" runat="server"
                                                                ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Burglar Alarm Coverage Comments
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblBurglar_Alarm_Coverage_Comments" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="5px" class="Spacer">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <strong>Guard Services</strong>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Guard Company Name
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lblGuard_Company_Name" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Guard Company Address 1
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblGuard_Company_Address_1" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Guard Company Address 2
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblGuard_Company_Address_2" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Guard Company City
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblGuard_Company_City" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Guard Company State
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_Guard_Company_State" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Guard Company Zip
                                                            <br />
                                                            (99999-9999)
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblGuard_Company_Zip" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Guard Company Contact Name
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblGuard_Company_Contact_Name" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Guard Company Contact Telephone
                                                            <br />
                                                            (999-999-9999)
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblGuard_Comapny_Contact_Telephone" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Guard Company Contact E-Mail
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lblGuard_Company_Contact_E_Mail" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Guard Hours Monitored Grid
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:GridView ID="gvGuardHoursMonitorGridView" runat="server" GridLines="None" CellPadding="4"
                                                                CellSpacing="0" AutoGenerateColumns="false" Width="100%" EnableTheming="false"
                                                                OnRowCommand="gvMonitoingGrid_RowCommand">
                                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <RowStyle BackColor="#EAEAEA" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <EditRowStyle BackColor="#2461BF" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <PagerStyle BackColor="#7f7f7f" ForeColor="White" HorizontalAlign="Center" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <HeaderStyle BackColor="#7f7f7f" Font-Bold="True" ForeColor="White" Font-Names="Tahoma"
                                                                    Font-Size="8pt" VerticalAlign="Bottom" />
                                                                <AlternatingRowStyle BackColor="White" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <EmptyDataRowStyle CssClass="emptyrow" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Day Monitoring Begins" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnDayMonitoringBegins" runat="server" CommandName="gvEdit"
                                                                                CommandArgument='<%# Eval("PK_AP_Property_Security_Monitor_Grids") %>'> 
                                                                            <%# Eval("Start_Day")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Time Monitoring Begins" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnTimeMonitoringBegins" runat="server" CommandName="gvEdit"
                                                                                CommandArgument='<%# Eval("PK_AP_Property_Security_Monitor_Grids") %>'> 
                                                                                <%# Eval("Start_Time")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Day Monitoring Ends" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnDayMonitoringEnds" runat="server" CommandName="gvEdit"
                                                                                CommandArgument='<%# Eval("PK_AP_Property_Security_Monitor_Grids") %>'> 
                                                                                <%# Eval("End_Day")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Time Monitoring Ends" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnTimeMonitoringEnds" runat="server" CommandName="gvEdit"
                                                                                CommandArgument='<%# Eval("PK_AP_Property_Security_Monitor_Grids") %>'> 
                                                                                <%# Eval("End_Time")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Hours" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnHours" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_AP_Property_Security_Monitor_Grids") %>'> 
                                                                                <%# Eval("Hours")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                                <EmptyDataTemplate>
                                                                    <b>No Record found</b>
                                                                </EmptyDataTemplate>
                                                                <PagerSettings Visible="False" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Off-Duty Officer Name
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblOffDuty_Officer_Name" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Off-Duty Officer Telephone
                                                            <br />
                                                            (999-999-9999)
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblOffDuty_Officer_Telephone" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Off-Duty Officer Hours Monitored Grid
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:GridView ID="gvOffDutyOfficerHoursMonitoredGridView" runat="server" GridLines="None"
                                                                CellPadding="4" CellSpacing="0" AutoGenerateColumns="false" Width="100%" EnableTheming="false"
                                                                OnRowCommand="gvMonitoingGrid_RowCommand">
                                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <RowStyle BackColor="#EAEAEA" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <EditRowStyle BackColor="#2461BF" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <PagerStyle BackColor="#7f7f7f" ForeColor="White" HorizontalAlign="Center" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <HeaderStyle BackColor="#7f7f7f" Font-Bold="True" ForeColor="White" Font-Names="Tahoma"
                                                                    Font-Size="8pt" VerticalAlign="Bottom" />
                                                                <AlternatingRowStyle BackColor="White" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <EmptyDataRowStyle CssClass="emptyrow" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Day Monitoring Begins" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnDayMonitoringBegins" runat="server" CommandName="gvEdit"
                                                                                CommandArgument='<%# Eval("PK_AP_Property_Security_Monitor_Grids") %>'> 
                                                                            <%# Eval("Start_Day")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Time Monitoring Begins" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnTimeMonitoringBegins" runat="server" CommandName="gvEdit"
                                                                                CommandArgument='<%# Eval("PK_AP_Property_Security_Monitor_Grids") %>'> 
                                                                                <%# Eval("Start_Time")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Day Monitoring Ends" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnDayMonitoringEnds" runat="server" CommandName="gvEdit"
                                                                                CommandArgument='<%# Eval("PK_AP_Property_Security_Monitor_Grids") %>'> 
                                                                                <%# Eval("End_Day")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Time Monitoring Ends" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnTimeMonitoringEnds" runat="server" CommandName="gvEdit"
                                                                                CommandArgument='<%# Eval("PK_AP_Property_Security_Monitor_Grids") %>'> 
                                                                                <%# Eval("End_Time")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Hours" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnHours" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_AP_Property_Security_Monitor_Grids") %>'> 
                                                                                <%# Eval("Hours")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                                <EmptyDataTemplate>
                                                                    <b>No Record found</b>
                                                                </EmptyDataTemplate>
                                                                <PagerSettings Visible="False" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="5px" class="Spacer">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <strong>Access Control - Systems</strong>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkACFirstFloorOnlyView" runat="server" Text="1st Floor Only" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="25%">
                                                                        <asp:CheckBox ID="chkACBusinessAreaView" runat="server" Text="Business Area" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="25%">
                                                                        <asp:CheckBox ID="chkKeyFobsView" runat="server" Text="Key Fobs" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkACCashierView" runat="server" Text="Cashier" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="25%">
                                                                        <asp:CheckBox ID="chkACControlRoomView" runat="server" Text="Computer Room" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="25%">
                                                                        <asp:CheckBox ID="chkDoorRestrictionsView" runat="server" Text="Door Restrictions" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkACControllerOfficeView" runat="server" Text="Controller Office"
                                                                            Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkACEnterExitBuildingView" runat="server" Text="Enter/Exit Building"
                                                                            Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkACFandIOfficeView" runat="server" Text="F&I Office" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkACGMOfficeView" runat="server" Text="GM Office" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkACMulipleFloorsView" runat="server" Text="Multiple Floors" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkACPartsView" runat="server" Text="Parts" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkACSmartSafeOfficeView" runat="server" Text="Smart Safe Office"
                                                                            Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkACOtherView" runat="server" Text="Other" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Access Control – Other Description
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblAccess_Control_Other_Description" runat="server"
                                                                ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            <strong>Fencing/Gates Protection</strong>
                                                        </td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkFGEnterenceExitAlarmsView" runat="server" Text="Entrance/Exit Arms"
                                                                            Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkFGEnterenceExitGateView" runat="server" Text="Entrance/Exit Gate"
                                                                            Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top">
                                                            <span style="font-weight: bold; text-decoration: underline">Fencing</span>
                                                        </td>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkFBackView" runat="server" Text="Back" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkFEntierPerimeterView" runat="server" Text="Entire Perimeter"
                                                                            Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkFFrontView" runat="server" Text="Front" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkFSatelliteParkingLotView" runat="server" Text="Satellite Parking Lot"
                                                                            Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkFSideView" runat="server" Text="Side" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top">
                                                            <span style="font-weight: bold; text-decoration: underline">Post Bollards</span>
                                                        </td>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkPBackView" runat="server" Text="Back" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkPEntirePerimeterView" runat="server" Text="Entire Perimeter"
                                                                            Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkPFrontView" runat="server" Text="Front" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkPSatelliteParkingLotView" runat="server" Text="Satellite Parking Lot"
                                                                            Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkPSideView" runat="server" Text="Side" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            <strong>Key Tracking System </strong>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkSITSAutoTracksView" runat="server" Text="KEYper" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkSITSKeyTracksView" runat="server" Text="KeyTrak" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkSITSOtherView" runat="server" Text="Other" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Other Security Inventory Tracking System
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblSecurity_Inventory_Tracking_System_Other_Description"
                                                                runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Cap Index Crime Score
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCap_Index_Crime_Score" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Cap Index Risk Category
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCap_Index_Risk_Category" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="left" valign="top">Financial Grid<br />
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="90%" runat="server" id="Table1">
                                                                <tr>
                                                                    <td width="40%" align="left" class="assetheader">Category</td>
                                                                    <td width="30%" align="left" class="assetheader">Total Capex $</td>
                                                                    <td width="30%" align="left" class="assetheader">Total Monthly Charge $</td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="40%" align="left" class="asset">
                                                                        <asp:Label ID="Label1" runat="server" Text="CCTV Only"></asp:Label></td>
                                                                    <td width="30%" align="left" class="asset">
                                                                        <asp:Label ID="lblCCTVOnlyTC" runat="server"  onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this);" /></td>
                                                                    <td width="30%" align="left" class="asset">
                                                                        <asp:Label ID="lblCCTVOnlyTM" runat="server" SkinID="txtCurrency15" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="40%" align="left" class="asset2">
                                                                        <asp:Label ID="Label2" runat="server" Text="Burglar Alarms"></asp:Label></td>
                                                                    <td width="30%" align="left" class="asset2">
                                                                        <asp:Label ID="lblBurglarAlarmsTC" runat="server" SkinID="txtCurrency" /></td>
                                                                    <td width="30%" align="left" class="asset2">
                                                                        <asp:Label ID="lblBurglarAlarmsTM" runat="server" SkinID="txtCurrency" /></td>
                                                                </tr>                                                                
                                                                <tr>
                                                                    <td width="40%" align="left" class="asset">
                                                                        <asp:Label ID="Label4" runat="server" Text="Guard Services"></asp:Label></td>
                                                                    <td width="30%" align="left" class="asset">
                                                                        <asp:Label ID="lblGuardServicesTC" runat="server" SkinID="txtCurrency" /></td>
                                                                    <td width="30%" align="left" class="asset">
                                                                        <asp:Label ID="lblGuardServicesTM" runat="server" SkinID="txtCurrency" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="40%" align="left" class="asset2">
                                                                        <asp:Label ID="Label5" runat="server" Text="Access Control"></asp:Label></td>
                                                                    <td width="30%" align="left" class="asset2">
                                                                        <asp:Label ID="lblAccessControlTC" runat="server" SkinID="txtCurrency" /></td>
                                                                    <td width="30%" align="left" class="asset2">
                                                                        <asp:Label ID="lblAccessControlTM" runat="server" SkinID="txtCurrency" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="40%" align="left" class="asset">
                                                                        <asp:Label ID="Label6" runat="server" Text="Security Inventory Tracking Systems"></asp:Label></td>
                                                                    <td width="30%" align="left" class="asset">
                                                                        <asp:Label ID="lblSecurityInventoryTrackingSystemsTC" runat="server" SkinID="txtCurrency" /></td>
                                                                    <td width="30%" align="left" class="asset">
                                                                        <asp:Label ID="lblSecurityInventoryTrackingSystemsTM" runat="server" SkinID="txtCurrency" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="40%" align="left" class="asset2">
                                                                        <asp:Label ID="Label3" runat="server" Text="CCTV and Live Monitoring Services"></asp:Label></td>
                                                                    <td width="30%" align="left" class="asset2">
                                                                        <asp:Label ID="lblCategoryTC" runat="server" SkinID="txtCurrency" /></td>
                                                                    <td width="30%" align="left" class="asset2">
                                                                        <asp:Label ID="lblCategoryTM" runat="server" SkinID="txtCurrency"/></td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="3">&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="3" align="center">
                                                                        <asp:Button ID="Button3" runat="server" Text="View Audit Trail" OnClientClick="javascript:return openAP_Propert_Securty_FinancialPopup();" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <hr />
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="left" valign="top" width="100%" colspan="6">
                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td width="40%" align="left" valign="top"></td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Button ID="btnProperty_SecurityAuditView" runat="server" Text="View Audit Trail"
                                                                            CausesValidation="false" ToolTip="View Audit Trail" OnClientClick="javascript:return openAP_Propert_SecurtyPopup();"
                                                                            Visible="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <asp:Panel ID="pnlAddPropertySecurityMonitorGridView" runat="server" Width="100%"
                                                    Style="display: none;">
                                                    <div class="bandHeaderRow">
                                                        Property Security Monitor Grid
                                                    </div>
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <td align="left" width="21%" valign="top">Day Monitoring Begins&nbsp;<span id="Span34" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top" width="75%" colspan="4">
                                                                <asp:Label ID="lblDayMonitoringBegin" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="21%" valign="top">Time Monitoring Begins&nbsp;<span id="Span35" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top" width="75%" colspan="4">
                                                                <asp:Label ID="lblTimeMonitoringBegins" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="21%" valign="top">Day Monitoring Ends&nbsp;<span id="Span131" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top" width="75%" colspan="4">
                                                                <asp:Label ID="lblDayMonitoringEnds" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="21%" valign="top">Time Monitoring Ends&nbsp;<span id="Span132" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top" width="75%" colspan="4">
                                                                <asp:Label ID="lblTimeMonitoringEnds" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="21%" valign="top">Hours&nbsp;<span id="Span133" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top" width="75%" colspan="4">
                                                                <asp:Label ID="lblMonitoringPeriodHours" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" align="left" valign="top">
                                                                <table border="0" align="center" cellpadding="0" cellspacing="5">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Button ID="btnBackPropertySecurityView" runat="server" Text="Back" OnClick="btnShowPropertySecurityFromMonitor_Click" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl2View" runat="server" Style="display: none;" Width="794px">
                                                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td>
                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td width="45%"></td>
                                                                    <td valign="top" align="right">
                                                                        <uc:ctrlPaging ID="CtrlPagingDPD_FROIsView" runat="server" OnGetPage="GetPageDPD_FROIs" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            <asp:GridView ID="gvAP_DPD_FROIsView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                AllowSorting="true" OnRowCommand="gvAP_DPD_FROIs_OnRowCommand" OnSorting="gvAP_DPD_FROIs_Sorting"
                                                                OnRowCreated="gvAP_DPD_FROIs_OnRowCreated">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="DPD First Report Number" SortExpression="DPD_FR_Number">
                                                                        <ItemStyle Width="25%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkDPD_First_Report_Number" runat="server" Text='<%# Eval("DPD_FR_Number") %>'
                                                                                CommandName="Edit_DPD_FROIs" CommandArgument='<%# Eval("PK_DPD_FR_ID") +";" + Eval("PK_AP_DPD_FROIs") + ";" +  Eval("FK_First_Report_Wizard_ID") +";"+ Eval("PK_DPD_FR_Vehicle_ID") +";"+ Eval("PK_DPD_Claims_ID") %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Date of Loss" SortExpression="Date_Of_Loss">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkDate_Of_Loss" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Date_Of_Loss")) %>'
                                                                                CommandName="Edit_DPD_FROIs" CommandArgument='<%# Eval("PK_DPD_FR_ID") +";" + Eval("PK_AP_DPD_FROIs") + ";" +  Eval("FK_First_Report_Wizard_ID") +";"+ Eval("PK_DPD_FR_Vehicle_ID")+";"+ Eval("PK_DPD_Claims_ID") %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Cause of Loss" SortExpression="Cause_Of_Loss">
                                                                        <ItemStyle Width="18%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkCause_of_Loss" runat="server" Text='<%# Eval("Cause_Of_Loss") %>'
                                                                                CommandName="Edit_DPD_FROIs" CommandArgument='<%# Eval("PK_DPD_FR_ID") +";" + Eval("PK_AP_DPD_FROIs") + ";" +  Eval("FK_First_Report_Wizard_ID") +";"+ Eval("PK_DPD_FR_Vehicle_ID")+";"+ Eval("PK_DPD_Claims_ID") %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Make" SortExpression="Make">
                                                                        <ItemStyle Width="16%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkMake" runat="server" Text='<%# Eval("Make") %>' CommandName="Edit_DPD_FROIs"
                                                                                CommandArgument='<%# Eval("PK_DPD_FR_ID") +";" + Eval("PK_AP_DPD_FROIs") + ";" +  Eval("FK_First_Report_Wizard_ID") +";"+ Eval("PK_DPD_FR_Vehicle_ID")+";"+ Eval("PK_DPD_Claims_ID") %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Model" SortExpression="Model">
                                                                        <ItemStyle Width="16%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkModel" runat="server" Text='<%# Eval("Model") %>' CommandName="Edit_DPD_FROIs"
                                                                                CommandArgument='<%# Eval("PK_DPD_FR_ID") +";" + Eval("PK_AP_DPD_FROIs") + ";" +  Eval("FK_First_Report_Wizard_ID") +";"+ Eval("PK_DPD_FR_Vehicle_ID")+";"+ Eval("PK_DPD_Claims_ID") %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Status" SortExpression="Item_Status">
                                                                        <ItemStyle Width="10%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Item_Status") %>'></asp:Label>
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
                                                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">FROIs To be Included in Grid
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:RadioButtonList ID="rdoDPD_FROIsView" runat="server" RepeatDirection="Horizontal"
                                                                RepeatColumns="3" OnSelectedIndexChanged="rdoDPD_FROIs_OnSelectedIndexChanged"
                                                                AutoPostBack="true">
                                                                <asp:ListItem Text="Open" Value="O"></asp:ListItem>
                                                                <asp:ListItem Text="Closed" Value="C"></asp:ListItem>
                                                                <asp:ListItem Text="All" Value="A" Selected="True"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div class="bandHeaderRow">
                                                    Incident Information
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Incident Number
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top" colspan="4">
                                                            <a href="../FirstReport/DPDFirstReport.aspx?id=<%= Encryption.Encrypt(FK_DPD_FR_ID.ToString()) %>"
                                                                target="_blank">
                                                                <asp:Label ID="lblIncident_NumberView" runat="server" />
                                                            </a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Date of Loss
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblDate_Of_Loss" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Time of Loss
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblTime_of_Loss" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Cause of Loss
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCause_of_Loss" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">VIN#
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblVIN" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Make
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblMake" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Model
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblModel" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Year
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblYear" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Type of Vehicle
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTypeOfVehicle" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Vehicle Color
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblVehicleColor" runat="server" style="word-wrap:normal; word-break:break-all"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Location of Vehicle
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblPresent_Location" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Location Address
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblPresent_Address" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Location State
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblPresent_State" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Location Zip
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblPresent_Zip" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Invoice Value
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblInvoice_Value" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Police Case Number
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblPoliceCaseNumber" runat="server" style="word-wrap:normal; word-break:break-all"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top"></td>
                                                        <td align="left" valign="top" width="22%">Investigating Police Department
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblInvestigatingPoliceDepartment" runat="server" style="word-wrap:normal; word-break:break-all"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Loss Description
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblLoss_Description" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Witnesses
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="center" width="78%" valign="top">
                                                            <asp:GridView ID="gvDPD_WitnessesView" runat="server" AutoGenerateColumns="false"
                                                                Width="100%" AllowSorting="false">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Name">
                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                        <ItemTemplate>
                                                                            <%#Eval("Name")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Address">
                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                        <ItemTemplate>
                                                                            <%#Eval("Address")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Phone">
                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                        <ItemTemplate>
                                                                            <%#Eval("Phone")%>
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
                                                <table cellpadding="1" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td align="left" valign="top" width="18%">Associated Claim Number
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td width="78%" align="left">
                                                            <asp:Label ID="lblDPDClaim_NumberView" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="3"></td>
                                                    </tr>
                                                </table>
                                                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td></td>
                                                    </tr>
                                                </table>
                                                <table border="0" cellpadding="1" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="100%" align="left">
                                                            <uc:ctrlSonicNotes ID="ctrlSonicNotesView" runat="server" IsAddVisible="false" StrOperation="view" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div class="bandHeaderRow">
                                                    Investigation
                                                </div>
                                                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td align="left" width="22%" colspan="2"></td>
                                                        <td align="left" width="78%" colspan="4">
                                                            <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chk3rd_Party_Vendor_Related_TheftView" Text="3rd Party Vendor Related Theft"
                                                                            runat="server" Enabled="false" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAccess_Control_FailuresView" Text="Access Control Failures"
                                                                            runat="server" Enabled="false" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkBreaking_and_EnteringView" Text="Breaking and Entering" runat="server"
                                                                            Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkBurglar_Alarm_FailureView" Text="Burglar Alarm Failure" runat="server"
                                                                            Enabled="false" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkCamera_Dead_SpotView" Text="Camera Dead Spot" runat="server"
                                                                            Enabled="false" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkCCTV_Monitoring_FailureView" Text="CCTV Monitoring Failure (Equipment)"
                                                                            runat="server" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkCCTV_Monitoring_Failure_byOperatorView" Text="CCTV Monitoring Failure by Operator"
                                                                            runat="server" Enabled="false" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkDesign_weakness_Property_ProtectionView" Text="Design weakness – Property Protection"
                                                                            runat="server" Enabled="false" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkEnvironmental_Obstruction_ConditionCameraView" Text="Environmental Obstruction/Condition – Camera"
                                                                            runat="server" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkFailure_to_ReportLate_ReportView" Text="Failure to Report/Late Report"
                                                                            runat="server" Enabled="false" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkKey_SwapView" Text="Key Swap" runat="server" Enabled="false" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkLighting_DeficienciesView" Text="Lighting Deficiencies" runat="server"
                                                                            Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkLockBox_Not_Properly_SecuredView" Text="Lock Box Not Properly Secured"
                                                                            runat="server" Enabled="false" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkNegligence_Lackof_Key_Control_Program_Unattended_KeysView" Text="Negligence Lack of Key Control Program – Unattended Keys"
                                                                            runat="server" Enabled="false" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkNonPermissible_User_of_TakingVehicleView" Text="Non-Permissible User of Taking Vehicle"
                                                                            runat="server" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkPower_OutageView" Text="Power Outage" runat="server" Enabled="false" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkSecurity_Guard_FailureView" Text="Security Guard Failure" runat="server"
                                                                            Enabled="false" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkStolen_IdView" Text="Stolen Id" runat="server" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkTheft_by_DeceptionView" Text="Theft by Deception" runat="server"
                                                                            Enabled="false" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkUnauthorized_Building_Entry_ForcibleView" Text="Unauthorized Building Entry (Forcible)"
                                                                            runat="server" Enabled="false" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkUnauthorized_Building_Entry_UnlockedView" Text="Unauthorized Building Entry (Unlocked)"
                                                                            runat="server" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkUnauthorized_Vehicle_Entry_ForcibleView" Text="Unauthorized Vehicle Entry (Forcible)"
                                                                            runat="server" Enabled="false" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkUnauthorized_Vehicle_Entry_UnlockedView" Text="Unauthorized Vehicle Entry (Unlocked)"
                                                                            runat="server" Enabled="false" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkVehicle_Takenby_Tow_TruckView" Text="Vehicle Taken by Tow Truck"
                                                                            runat="server" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkWeather_Related_DamageLossView" Text="Weather Related Damage/Loss"
                                                                            runat="server" Enabled="false" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkVandalismView" Text="Vandalism" runat="server" Enabled="false" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkOther_DescribeView" Text="Other - Describe" runat="server" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Investigation Finding – Other Description
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblInvestigation_Finding_Other_Description" runat="server"
                                                                ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div class="bandHeaderRow">
                                                    DPD FROIs
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">What is the incident’s root cause?
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblRoot_Cause" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">How can the incident be prevented from happening again?
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblIncident_Prevention" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Who has been tasked with implementing practices/procedures to prevent re-occurrence?
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblPerson_Tasked" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" width="4%" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" width="28%" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Target Date of Completion
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTarget_Date_of_Completion" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Status Due On
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblStatus_Due_On" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Comments
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblComments" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Financial Loss
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">$&nbsp;<asp:Label ID="lblFinancial_Loss" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Recovery
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">$&nbsp;<asp:Label ID="lblRecovery" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Item Status
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblItem_Status" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" valign="top" align="left">
                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="40%"></td>
                                                                    <td>
                                                                        <asp:Button ID="btnDPD_FROIsAudit_TrailView" Text="View Audit Trail" runat="server"
                                                                            OnClientClick="return openAuditPopup();" CausesValidation="false" Visible="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl3View" runat="server" Style="display: none;" Width="794px">
                                                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td>
                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td width="45%"></td>
                                                                    <td valign="top" align="right">
                                                                        <uc:ctrlPaging ID="CtrlPagingAL_FROIsView" runat="server" OnGetPage="GetPageFROIs_AL" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            <asp:GridView ID="gvAP_AL_FROIsView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                AllowSorting="true" OnRowCommand="gvAP_AL_FROIs_OnRowCommand" OnSorting="gvAP_AL_FROIs_Sorting"
                                                                OnRowCreated="gvAP_AL_FROIs_OnRowCreated">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="AL First Report Number" SortExpression="AL_FR_Number">
                                                                        <ItemStyle Width="30%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkAL_First_Report_Number" runat="server" Text='<%# Eval("AL_FR_Number") %>'
                                                                                Width="100px" CssClass="TextClip" CommandName="Edit_AL_FROIs" CommandArgument='<%# Eval("PK_AL_FR_ID") + ";" + Eval("PK_AP_AL_FROIs") + ";" +  Eval("FK_First_Report_Wizard_ID")  + ";" + Eval("PK_Auto_Loss_Claims_ID") + ";" +  Eval("Origin_Claim_Number") %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Date of Loss" SortExpression="Date_Of_Loss">
                                                                        <ItemStyle Width="16%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkDate_Of_Loss" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Date_Of_Loss")) %>'
                                                                                Width="100px" CssClass="TextClip" CommandName="Edit_AL_FROIs" CommandArgument='<%# Eval("PK_AL_FR_ID") +";" + Eval("PK_AP_AL_FROIs") + ";" +  Eval("FK_First_Report_Wizard_ID") + ";" + Eval("PK_Auto_Loss_Claims_ID") + ";" +  Eval("Origin_Claim_Number") %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Make" SortExpression="Make">
                                                                        <ItemStyle Width="20%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkMake" runat="server" Text='<%# Eval("Make") %>' CommandName="Edit_AL_FROIs"
                                                                                Width="150px" CssClass="TextClip" CommandArgument='<%# Eval("PK_AL_FR_ID") +";" + Eval("PK_AP_AL_FROIs") + ";" +  Eval("FK_First_Report_Wizard_ID") + ";" + Eval("PK_Auto_Loss_Claims_ID") + ";" +  Eval("Origin_Claim_Number") %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Model" SortExpression="Model">
                                                                        <ItemStyle Width="16%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkModel" runat="server" Text='<%# Eval("Model") %>' CommandName="Edit_AL_FROIs"
                                                                                Width="150px" CssClass="TextClip" CommandArgument='<%# Eval("PK_AL_FR_ID") +";" + Eval("PK_AP_AL_FROIs") + ";" +  Eval("FK_First_Report_Wizard_ID") + ";" + Eval("PK_Auto_Loss_Claims_ID") + ";" +  Eval("Origin_Claim_Number") %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Status" SortExpression="Item_Status">
                                                                        <ItemStyle Width="10%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Item_Status") %>' Width="80px"></asp:Label>
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
                                                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">FROIs To be Included in Grid
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:RadioButtonList ID="rdoAL_FROIsView" runat="server" RepeatDirection="Horizontal"
                                                                RepeatColumns="3" AutoPostBack="true" OnSelectedIndexChanged="rdoAL_FROIs_OnSelectedIndexChanged">
                                                                <asp:ListItem Text="Open" Value="O"></asp:ListItem>
                                                                <asp:ListItem Text="Closed" Value="C"></asp:ListItem>
                                                                <asp:ListItem Text="All" Value="A" Selected="True"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div class="bandHeaderRow">
                                                    Incident Information
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Incident Number
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top" colspan="4">
                                                            <a href="../FirstReport/ALFirstReport.aspx?id=<%= Encryption.Encrypt(FK_AL_FR_ID.ToString()) %>"
                                                                target="_blank">
                                                                <asp:Label ID="lblAL_Incident_NumberView" runat="server" /></a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Date of Loss
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblAL_Date_of_Loss" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Time of Loss
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblAL_Time_of_Loss" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Description of Loss
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblDescription_Of_Loss" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Incident Occurred
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:RadioButton runat="server" Text="Onsite" ID="rdbAL_OnsiteView" Enabled="false"
                                                                Style="margin-top: -5px;" />
                                                            <asp:RadioButton runat="server" Text="Offsite" ID="rdbAL_OffsiteView" Enabled="false"
                                                                Style="margin-top: -5px;" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Were Police Notified?
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList ID="rdbAL_WerePoliceNotifiedView" runat="server" RepeatDirection="Horizontal"
                                                                RepeatColumns="3" AutoPostBack="true" Enabled="false" Style="margin-top: -5px;">
                                                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left" valign="top">Were Pedestrians Involved?
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList ID="rdbAL_WerePedestriansInvolvedView" runat="server" RepeatDirection="Horizontal"
                                                                RepeatColumns="3" AutoPostBack="true" Enabled="false" Style="margin-top: -5px;">
                                                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Was there any property damage?
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList ID="rdbAL_propertydamageView" runat="server" RepeatDirection="Horizontal"
                                                                RepeatColumns="3" AutoPostBack="true" Enabled="false" Style="margin-top: -5px;">
                                                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left" valign="top">Were there any witnesses?
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList ID="rdbAL_WitnessesView" runat="server" RepeatDirection="Horizontal"
                                                                RepeatColumns="3" AutoPostBack="true" Enabled="false" Style="margin-top: -5px;">
                                                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Is there a Security Video Surveillance System?
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:RadioButtonList ID="rdbAL_SecurityVideoView" runat="server" RepeatDirection="Horizontal"
                                                                RepeatColumns="3" AutoPostBack="true" Enabled="false" Style="margin-top: -5px;">
                                                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Weather Conditions
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label runat="server" ID="lblWeatherConditions"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Road Conditions
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label runat="server" ID="lblRoadConditions"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Witnesses
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="center" width="78%" valign="top">
                                                            <asp:GridView ID="gvAL_WitnessesView" runat="server" AutoGenerateColumns="false"
                                                                Width="100%" AllowSorting="false">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Name">
                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                        <ItemTemplate>
                                                                            <%#Eval("Witness_Name")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Address">
                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                        <ItemTemplate>
                                                                            <%#Eval("Witness_Address_1")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Phone">
                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                        <ItemTemplate>
                                                                            <%#Eval("Witness_Work_Phone")%>
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
                                                <table cellpadding="3" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td align="left" valign="top" width="18%">Associated Claim Number
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" width="78%">
                                                            <asp:Label ID="lblALClaim_NumberView" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="3"></td>
                                                    </tr>
                                                </table>
                                                <table cellpadding="1" cellspacing="0" width="100%">
                                                    <div class="bandHeaderRow">
                                                        <caption>
                                                            Claim Notes
                                                        </caption>
                                                    </div>
                                                    <tr>
                                                        <td width="100%" align="left">
                                                            <uc:CtrlAdjusterNotes ID="ucAdjusterNotesView" runat="server" CurrentClaimType="AL"
                                                                IsMailVisible="true" />
                                                        </td>
                                                    </tr>
                                                </table>

                                                <table border="0" cellpadding="1" cellspacing="0" width="100%" style="margin-top: -10px;">
                                                    <tr>
                                                        <td width="100%" align="left">
                                                            <uc:ctrlSonicNotes ID="ctrlSonicNotes_ALView" runat="server" IsAddVisible="false" StrOperation="view" />
                                                        </td>
                                                    </tr>
                                                </table>

                                                <div class="bandHeaderRow">
                                                    Investigation
                                                </div>
                                                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td align="left" width="22%" colspan="2"></td>
                                                        <td align="left" width="78%">
                                                            <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_3rd_Party_Vendor_Related_TheftView" Text="3rd Party Vendor Related Theft"
                                                                            runat="server" Enabled="false" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_Access_Control_FailuresView" Text="Access Control Failures"
                                                                            runat="server" Enabled="false" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_Breaking_and_EnteringView" Text="Breaking and Entering" runat="server"
                                                                            Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_Burglar_Alarm_FailureView" Text="Burglar Alarm Failure" runat="server"
                                                                            Enabled="false" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_Camera_Dead_SpotView" Text="Camera Dead Spot" runat="server"
                                                                            Enabled="false" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_CCTV_Monitoring_FailureView" Text="CCTV Monitoring Failure (Equipment)"
                                                                            runat="server" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_CCTV_Monitoring_Failure_byOperatorView" Text="CCTV Monitoring Failure by Operator"
                                                                            runat="server" Enabled="false" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_Design_weakness_Property_ProtectionView" Text="Design weakness – Property Protection"
                                                                            runat="server" Enabled="false" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_Environmental_Obstruction_ConditionCameraView" Text="Environmental Obstruction/Condition – Camera"
                                                                            runat="server" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_Failure_to_ReportLate_ReportView" Text="Failure to Report/Late Report"
                                                                            runat="server" Enabled="false" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_Key_SwapView" Text="Key Swap" runat="server" Enabled="false" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_Lighting_DeficienciesView" Text="Lighting Deficiencies" runat="server"
                                                                            Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_LockBox_Not_Properly_SecuredView" Text="Lock Box Not Properly Secured"
                                                                            runat="server" Enabled="false" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_Negligence_Lackof_Key_Control_Program_Unattended_KeysView"
                                                                            Text="Negligence Lack of Key Control Program – Unattended Keys" runat="server"
                                                                            Enabled="false" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_NonPermissible_User_of_TakingVehicleView" Text="Non-Permissible User of Taking Vehicle"
                                                                            runat="server" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_Power_OutageView" Text="Power Outage" runat="server" Enabled="false" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_Security_Guard_FailureView" Text="Security Guard Failure"
                                                                            runat="server" Enabled="false" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_Stolen_IdView" Text="Stolen Id" runat="server" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_Theft_by_DeceptionView" Text="Theft by Deception" runat="server"
                                                                            Enabled="false" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_Unauthorized_Building_Entry_ForcibleView" Text="Unauthorized Building Entry (Forcible)"
                                                                            runat="server" Enabled="false" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_Unauthorized_Building_Entry_UnlockedView" Text="Unauthorized Building Entry (Unlocked)"
                                                                            runat="server" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_Unauthorized_Vehicle_Entry_ForcibleView" Text="Unauthorized Vehicle Entry (Forcible)"
                                                                            runat="server" Enabled="false" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_Unauthorized_Vehicle_Entry_UnlockedView" Text="Unauthorized Vehicle Entry (Unlocked)"
                                                                            runat="server" Enabled="false" />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_Vehicle_Takenby_Tow_TruckView" Text="Vehicle Taken by Tow Truck"
                                                                            runat="server" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:CheckBox ID="chkAL_Weather_Related_DamageLossView" Text="Weather Related Damage/Loss"
                                                                            runat="server" Enabled="false" />
                                                                    </td>
                                                                    <td colspan="2" valign="top">
                                                                        <asp:CheckBox ID="chkAL_Other_DescribeView" Text="Other - Describe" runat="server"
                                                                            Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Investigation Finding – Other Description
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblAL_Investigation_Finding" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div class="bandHeaderRow">
                                                    FROI Review
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">What is the incident’s root cause?
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblAL_Root_Cause" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">How can the incident be prevented from happening again?
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblAL_Incident_Prevention" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Who has been tasked with implementing practices/procedures to prevent re-occurrence?
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblAL_Person_Tasked" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" width="4%" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" width="28%" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Target Date of Completion
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblAL_Target_Date_of_Completion" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Status Due On
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblAL_Status_Due_On" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Comments
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblAL_Comments" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Financial Loss
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">$&nbsp;<asp:Label ID="lblAL_Financial_Loss" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Recovery
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">$&nbsp;<asp:Label ID="lblAL_Recovery" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Item Status
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblAL_Item_Status" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="left" valign="top" width="100%">
                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td width="40%" align="left" valign="top"></td>
                                                                    <td valign="top" align="left">
                                                                        <asp:Button ID="btnAL_ViewAuditTrailView" runat="server" Text="View Audit Trail"
                                                                            CausesValidation="false" ToolTip="View Audit Trail" OnClientClick="javascript:return AuditPopUp();"
                                                                            Visible="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl4View" runat="server" Style="display: none;" Width="794px">
                                                <div class="bandHeaderRow">
                                                    ACI
                                                </div>
                                                <%--Change Header text from Cal Atlantic to ACI as per client's request Bug ID = 2552--%>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td colspan="6" width="100%" valign="top" align="left">
                                                            <table>
                                                                <tr>
                                                                    <td width="45%"></td>
                                                                    <td valign="top" align="right">
                                                                        <uc:ctrlPaging ID="CtrlPagingAP_CalatlanticView" runat="server" OnGetPage="GetPageAP_Calatlantic" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <asp:GridView ID="gvEventView" runat="server" GridLines="None" CellPadding="4" CellSpacing="0"
                                                                AllowSorting="true" AutoGenerateColumns="false" Width="100%" EnableTheming="false"
                                                                OnRowCommand="gvEvent_RowCommand" OnRowCreated="gvEvent_OnRowCreated" OnSorting="gvEvent_Sorting">
                                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <RowStyle BackColor="#EAEAEA" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <EditRowStyle BackColor="#2461BF" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <PagerStyle BackColor="#7f7f7f" ForeColor="White" HorizontalAlign="Center" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <HeaderStyle BackColor="#7f7f7f" Font-Bold="True" ForeColor="White" Font-Names="Tahoma"
                                                                    Font-Size="8pt" VerticalAlign="Bottom" />
                                                                <AlternatingRowStyle BackColor="White" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <EmptyDataRowStyle CssClass="emptyrow" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Event Number" HeaderStyle-HorizontalAlign="Left" SortExpression="Event_Number">
                                                                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnEventNumber" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_Event")%>'> <%# Eval("Event_Number")%></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Date of Event" HeaderStyle-HorizontalAlign="Left"
                                                                        SortExpression="Event_Occurence_Date">
                                                                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnEventDate" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_Event")%>'>
                                                                             
                                                                             <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Event_Occurence_Date"))%>  
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Time of Event" HeaderStyle-HorizontalAlign="Left"
                                                                        ItemStyle-HorizontalAlign="Left" SortExpression="Event_Report_Date">
                                                                        <ItemStyle Width="" />
                                                                        <ItemTemplate>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Type" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                        SortExpression="Event_Type">
                                                                        <ItemStyle Width="" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnEventType" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_Event")%>'>
                                                                        <%# Eval("Event_Type")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="FROI" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                        SortExpression="Associated_FROI_Number">
                                                                        <ItemStyle Width="" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnFROI" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_Event")%>'>
                                                                            <%# Eval("Associated_FROI_Number")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                        SortExpression="STATUS">
                                                                        <ItemStyle Width="" />
                                                                        <ItemTemplate>
                                                                            <%# Eval("STATUS")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                                <EmptyDataTemplate>
                                                                    <b>No Record found</b>
                                                                </EmptyDataTemplate>
                                                                <PagerSettings Visible="False" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Event To be Included in Grid
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:RadioButtonList ID="rbtnlEventView" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rbtnlEvent_SelectedIndexChanged">
                                                                <asp:ListItem Selected="True" Text="Open" Value="O"></asp:ListItem>
                                                                <asp:ListItem Text="Closed" Value="C"></asp:ListItem>
                                                                <asp:ListItem Text="All" Value="A"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <div class="bandHeaderRow">
                                                                Event Information
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="18%">Date of Event
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="28%">
                                                            <asp:Label ID="lblDateOfEvent" runat="server" Width="170px"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top" width="18%">Time of Event
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="28%">
                                                            <asp:Label ID="lblTimeOfEvent" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Type of Event
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTypeOfEvent" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Event Report Date
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblEventReportDate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Investigation Report Date
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblInvestigationReportDate" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Date Sent to Client
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblDateSendToClient" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Event Description
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <%--<asp:Label ID="lblEvent_Desc" runat="server" />--%>
                                                            <asp:Label ID="lblFK_LU_Event_Description" runat="server" />
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Date Opened
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblDate_Opened" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Event Occurance Date
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblEventOccuranceDate" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            <asp:LinkButton ID="lnkbtnViewCalatlanticDataView" runat="server" Text="View ACI Data"
                                                                Enabled="false" OnClick="lnkbtnViewCalatlanticData_Click"></asp:LinkButton>
                                                            <%--Change Header text from Cal Atlantic to ACI as per client's request Bug ID = 2552--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <div class="bandHeaderRow">
                                                                Event Review
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            <span style="text-decoration: underline">Report/Event</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Potential Risk
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblPotential_Risk" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            <span style="text-decoration: underline">Event</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Action Taken
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblAction_Taken" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            <span style="text-decoration: underline">Case</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Was Law Enforcement Notified?
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblWas_Law_Enforcement_Notified" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Officer Name
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblOfficer_Name" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Phone Number (XXX-XXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblPhone_Number" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">E-Mail
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblEMail" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Law Enforcement Agency
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLaw_Enforcement_Agency" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Location
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLocation" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Police Report Number
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblPolice_Report_Number" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Notes
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblNotes" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            <span style="text-decoration: underline">Insurance Claim Type</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <%--<asp:CheckBox ID="chkAuto_LiabilityView" runat="server" Text="Auto Liability" Enabled="false" />--%>
                                                            <asp:RadioButtonList ID="rblInsuranceClaimTypeView" runat="server" RepeatColumns="2"
                                                                Enabled="false" RepeatDirection="Horizontal">
                                                                <asp:ListItem Text="Auto Liability" Value="Auto Liability"></asp:ListItem>
                                                                <asp:ListItem Text="DPD" Value="DPD"></asp:ListItem>
                                                                <asp:ListItem Text="Premises Liability" Value="Premises Liability"></asp:ListItem>
                                                                <asp:ListItem Text="Property Damage" Value="Property Damage"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Associated FROI Number
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblAssociatedFROINo" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Associated Claim Number
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <asp:Label ID="lblAssocaitedClaimNo" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">What is the event’s root cause?
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblCalRoot_Cause" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">How can the event be prevented from happening again?
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblEvent_Prevention" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Who has been tasked with implementing practices/procedures to prevent re-occurrence?
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTask_Prevent_Reoccurance" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Target Date of Completion
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCal_Target_Date_of_Completion" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Status Due On
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCal_Status_Due_On" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Financial Loss
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">$&nbsp;<asp:Label ID="lblCal_Financial_Loss" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Recovery
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">$&nbsp;<asp:Label ID="lblCal_Recovery" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Item Status
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCal_Item_Status" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="left" valign="top" width="100%">
                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td width="40%" align="left" valign="top"></td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Button ID="btnCal_AtlanticAudit_TrailView" Text="View Audit Trail" runat="server"
                                                                            OnClientClick="return openAP_Cal_Atlantic_AuditPopup();" CausesValidation="false"
                                                                            Visible="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl5View" runat="server" Style="display: none;" Width="794px">
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%" id="tblMainFraudEventView"
                                                    runat="server">
                                                    <tr>
                                                        <td align="right" colspan="6" valign="top">
                                                            <table>
                                                                <tr>
                                                                    <td width="30%"></td>
                                                                    <td>
                                                                        <uc:ctrlPaging ID="CtrlPaging_FraudView" runat="server" OnGetPage="GetPageFROIs_Fraud" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="6" valign="top">
                                                            <asp:GridView ID="gvFraudEventView" runat="server" AutoGenerateColumns="false" CellPadding="4"
                                                                AllowSorting="true" CellSpacing="0" EnableTheming="false" GridLines="None" Width="100%"
                                                                OnRowCommand="gvFraudEventView_RowCommand" OnSorting="gvFraudEventView_Sorting"
                                                                OnRowCreated="gvFraudEventView_OnRowCreated">
                                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                                                                    ForeColor="White" />
                                                                <RowStyle BackColor="#EAEAEA" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <EditRowStyle BackColor="#2461BF" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                                                                    ForeColor="#333333" />
                                                                <PagerStyle BackColor="#7f7f7f" Font-Names="Tahoma" Font-Size="8pt" ForeColor="White"
                                                                    HorizontalAlign="Center" />
                                                                <HeaderStyle BackColor="#7f7f7f" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                                                                    ForeColor="White" VerticalAlign="Bottom" />
                                                                <AlternatingRowStyle BackColor="White" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <EmptyDataRowStyle CssClass="emptyrow" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Fraud Number" SortExpression="Fraud_Number">
                                                                        <ItemStyle HorizontalAlign="Left" Width="13%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnFraudNumberView" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_AP_Fraud_Events")%>'> 
                                                                            <%# Eval("Fraud_Number")%></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Exposure Period Begin Date"
                                                                        SortExpression="Exposure_Period_Begin_Date">
                                                                        <ItemStyle HorizontalAlign="Left" Width="23%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnBeginDateView" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_AP_Fraud_Events")%>'> 
                                                                            <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Exposure_Period_Begin_Date"))%>
                                                                            
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Exposure Period End Date"
                                                                        ItemStyle-HorizontalAlign="Left" SortExpression="Exposure_Period_End_Date">
                                                                        <ItemStyle Width="22%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnEndDate" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_AP_Fraud_Events")%>'>
                                                                            <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Exposure_Period_End_Date"))%>
                                                                        
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Reported To" ItemStyle-HorizontalAlign="Left"
                                                                        SortExpression="Reported_To">
                                                                        <ItemStyle Width="" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnReportedTo" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_AP_Fraud_Events")%>'>
                                                                        <%# Eval("Reported_To")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Reported Date"
                                                                        ItemStyle-HorizontalAlign="Left" SortExpression="Reported_Date">
                                                                        <ItemStyle Width="17%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnReportedDate" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_AP_Fraud_Events")%>'>
                                                                            <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Reported_Date"))%>
                                                                            
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Status" ItemStyle-HorizontalAlign="Left"
                                                                        SortExpression="Close_File">
                                                                        <ItemStyle Width="11%" />
                                                                        <ItemTemplate>
                                                                            <%# Eval("STATUS")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                                <EmptyDataTemplate>
                                                                    <b>No Record found</b>
                                                                </EmptyDataTemplate>
                                                                <PagerSettings Visible="False" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Event To be Included in Grid
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:RadioButtonList ID="rbtnlFraudEventView" runat="server" OnSelectedIndexChanged="rdoFraud_EventTo_Include_OnSelectedIndexChanged"
                                                                AutoPostBack="true">
                                                                <asp:ListItem Selected="True" Text="Open" Value="O"></asp:ListItem>
                                                                <asp:ListItem Text="Closed" Value="C"></asp:ListItem>
                                                                <asp:ListItem Text="All" Value="A"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <div class="bandHeaderRow">
                                                                Event Claim
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="18%">Fraud Number
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="28%">
                                                            <asp:Label ID="lblFraudNumber" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="18%">Exposure Period Begin Date
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="28%">
                                                            <asp:Label ID="lblExposurePeriodBeginDate" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top" width="18%">Exposure Period End Date
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="28%">
                                                            <asp:Label ID="lblExposurePeriodEndDate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="18%">Reported To
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="28%">
                                                            <asp:Label ID="lblReportedTo" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top" width="18%">Reported Date
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="28%">
                                                            <asp:Label ID="lblReportedDate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Description of Event
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblDesciptionOfEvent" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <div class="bandHeaderRow">
                                                                Notification
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkCustomerRelationsHotLineView" runat="server" Text="Customer Relations Hot Line"
                                                                            Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkDiscoveredFraudthroughAuditsView" runat="server" Text="Discovered Fraud through Audits"
                                                                            Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkIntrnlAditCntrlLeadToFraudEventView" runat="server" Text="Internal Audit Control Breakdown leading to Fraud Event"
                                                                            Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkRetailLendingView" runat="server" Text="Retail Lending" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkSonicAssociate1800HotLineView" runat="server" Text="Sonic Associate 1-800 Hot Line"
                                                                            Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkStoreRedFlagsView" runat="server" Text="Store Red Flags" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkOtherView" runat="server" Text="Other" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Other Notification Description
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblOther_Notification_Description" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <div class="bandHeaderRow">
                                                                Initial Review
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Initial Claim Review Purification Notes
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblInternal_Review_Purification_Notes" runat="server"
                                                                ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Fraud Date
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFraud_Date" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <div class="bandHeaderRow">
                                                                Partnership Assignments
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">HR Assignment
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblHR_Assignment" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">HR Associate Contacted
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblHR_Associate_Contacted" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Date HR Assigned
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblDate_HR_Assigned" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Internal Audit Assignment
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblInternal_Audit_Assignment" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Internal Audit Associate Contacted
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblInternal_Audit_Associate_Contacted" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Date Internal Audit Assigned
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblDate_Internal_Audit_Assigned" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Store Controller Assignment
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblStore_Controller_Assignment" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Store Controller Associate Contacted
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblStore_Controller_Associate_Contacted" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Date Store Controller Assigned
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblDate_Store_Controller_Assigned" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Regional Controller Assignment
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblRegional_Controller_Assignment" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Regional Controller Associate Contacted
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblRegional_Controller_Associate_Contacted" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Date Regional Controller Assigned
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblDate_Regional_Controller_Assigned" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Legal Department Assignment
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblLegal_Department_Assignment" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Legal Department Associate Contacted
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLegal_Department_Associate_Contacted" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Date Legal Department Assigned
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblDate_Legal_Department_Assigned" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Outside Legal Assignment
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblOutside_Legal_Assignment" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Outside Legal Person Contacted
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblOutside_Legal_Associate_Contacted" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Date Outside Legal Assigned
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblDate_Outside_Legal_Assigned" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Operations Assignment
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblOperations_Assignment" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Operations Associate Contacted
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblOperations_Associate_Contacted" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Date Operations Assigned
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblDate_Operations_Assigned" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Retail Lending Assignment
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblRetail_Lending_Assignment" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Retail Lending Associate Contacted
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblRetail_Lending_Associate_Contacted" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Date Retail Lending Assigned
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblDate_Retail_Lending_Assigned" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">BT Security Assignment
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblBT_Security_Assignment" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">BT Security Associate Contacted
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblBT_Security_Associate_Contacted" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Date BT Security Assigned
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblDate_BT_Security_Assigned" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Other Assignment
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblOther_Assignment" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Other/Person Contacted
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblAssociated_Contacted" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Date Assigned
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblDate_Assigned" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Notes Grid
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:GridView ID="gvNotesGridFraudView" runat="server" GridLines="None" CellPadding="4" OnSorting="gvNotesGridFraudView_Sorting"
                                                                CellSpacing="0" AutoGenerateColumns="false" Width="100%" EnableTheming="false" AllowSorting="true"
                                                                OnRowCommand="gvNotesGridFraudView_RowCommand">
                                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <RowStyle BackColor="#EAEAEA" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <EditRowStyle BackColor="#2461BF" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <PagerStyle BackColor="#7f7f7f" ForeColor="White" HorizontalAlign="Center" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <HeaderStyle BackColor="#7f7f7f" Font-Bold="True" ForeColor="White" Font-Names="Tahoma"
                                                                    Font-Size="8pt" VerticalAlign="Bottom" />
                                                                <AlternatingRowStyle BackColor="White" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <EmptyDataRowStyle CssClass="emptyrow" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Date" HeaderStyle-HorizontalAlign="Left" SortExpression="Note_Date">
                                                                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnNoteDateView" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_AP_FE_PA_Notes") %>'> 
                                                                             <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Note_Date"))%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Note Text" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lblNotesView" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_AP_FE_PA_Notes") %>' Width="410px" CssClass="TextClip">
                                                                            <%# Eval("Note")%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                                <EmptyDataTemplate>
                                                                    <b>No Record found</b>
                                                                </EmptyDataTemplate>
                                                                <PagerSettings Visible="False" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <div class="bandHeaderRow">
                                                                NAPM Investigation
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">On-Site Findings:
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblOnSite_Findings" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">TLO Findings
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblTLO_Findings" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Statements Obtained
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblStatements_Obtained" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Fact Finding/Due-Diligence
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblFact_Finding_andor_Due_Diligence" runat="server"
                                                                ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Law Enforcement Involvement
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblLaw_Enforcement_Involvement" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <div class="bandHeaderRow">
                                                                Disposition Game Plan
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkCivilActionView" runat="server" Text="Civil Action" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkCriminalActionView" runat="server" Text="Criminal Action" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkFurtherInvestigationView" runat="server" Text="Further Investigation"
                                                                            Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top">
                                                            <span style="text-decoration: underline">Associate Corrective Action</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkSuspensionView" runat="server" Text="Suspension" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkTerminationView" runat="server" Text="Termination" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkWrittenView" runat="server" Text="Written" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkVerbalView" runat="server" Text="Verbal" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkCommunicationStrategyView" runat="server" Text="Communication Strategy (Internal and External)"
                                                                            Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkGamePlanOtherView" runat="server" Text="Other" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Detailed Disposition Game Plan Description
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblDetailed_Deisposition_Game_Plan_Description" runat="server"
                                                                ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top">
                                                            <asp:CheckBox ID="chkAccountingGapsandControlView" runat="server" Text="Accounting Gaps and Controls"
                                                                Enabled="false" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top">
                                                            <span style="text-decoration: underline">Red Flags Missed</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkMFRIncentivesView" runat="server" Text="Aging – MFR Incentives"
                                                                            Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkAgingWarrantiesView" runat="server" Text="Aging – Warranties"
                                                                            Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkAccountPayableSchemesView" runat="server" Text="Account Payable Schemes"
                                                                            Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkAssociateCollusionView" runat="server" Text="Associate(s) Collusion"
                                                                            Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkBillingSchemesView" runat="server" Text="Billing Schemes" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkExternalScamView" runat="server" Text="External Scam" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkImproperDisclosuretoCustomerFandIProductPurchaseView" runat="server"
                                                                            Text="Improper Disclosure to Customer F&I Product Purchase" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkImproperDisclosuretoCustomerVehiclePurchaseView" runat="server"
                                                                            Text="Improper Disclosure to Customer Vehicle Purchase" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkInventorySchemesView" runat="server" Text="Inventory Schemes"
                                                                            Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkOperasionsNoAdherencetoSonicPolicyandPlaybookView" runat="server"
                                                                            Text="Operations – No Adherence to Sonic Policy and Playbook" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkVendorCollusionView" runat="server" Text="Vendor Collusion"
                                                                            Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkVendorSchemesView" runat="server" Text="Vendor Schemes" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkMonthlyARControlReviewView" runat="server" Text="Monthly A/R Control Review" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkDispositionGameplanOtherView" runat="server" Text="Other" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Detail Description of Root Cause
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblDetail_Description_of_Root_Cause" runat="server"
                                                                ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <div class="bandHeaderRow">
                                                                Corrective Action/Recommendation
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkchangeaControlView" runat="server" Text="Change a Control" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkCurrentSystemEnhancementView" runat="server" Text="Current System Enhancement"
                                                                            Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkImplementPolicyView" runat="server" Text="Implement Policy"
                                                                            Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkNewSystemChangeView" runat="server" Text="New System Change"
                                                                            Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkResultOfDespositionPlanView" runat="server" Text="Results of Disposition Plan"
                                                                            Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkRetrainingView" runat="server" Text="Re-Training" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top"></td>
                                                        <td align="center" valign="top"></td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="27%">
                                                                        <asp:CheckBox ID="chkTrainingView" runat="server" Text="Training" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" valign="top" width="50%">
                                                                        <asp:CheckBox ID="chkCorrectiveActionRecommendationOtherView" runat="server" Text="Other"
                                                                            Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Detailed Description of Corrective Action/Recommendation
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblDetail_Description_of_Corrective_Action_andor_Recommendation"
                                                                runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <div class="bandHeaderRow">
                                                                Asset Protection Committee
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Notes Grid
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:GridView ID="gvNotesGridView" runat="server" GridLines="None" CellPadding="4"
                                                                CellSpacing="0" AutoGenerateColumns="false" Width="100%" EnableTheming="false"
                                                                OnRowCommand="gvNotesGridView_RowCommand">
                                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <RowStyle BackColor="#EAEAEA" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <EditRowStyle BackColor="#2461BF" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <PagerStyle BackColor="#7f7f7f" ForeColor="White" HorizontalAlign="Center" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <HeaderStyle BackColor="#7f7f7f" Font-Bold="True" ForeColor="White" Font-Names="Tahoma"
                                                                    Font-Size="8pt" VerticalAlign="Bottom" />
                                                                <AlternatingRowStyle BackColor="White" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <EmptyDataRowStyle CssClass="emptyrow" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Date" HeaderStyle-HorizontalAlign="Left" SortExpression="Note_Date">
                                                                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnNoteDateView" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_AP_FE_Notes") %>'> 
                                                                             <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Note_Date"))%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Note Text" HeaderStyle-HorizontalAlign="Left" SortExpression="Note">
                                                                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblNotesView" runat="server" Width="410px" CssClass="TextClip" >
                                                                            <%# Eval("Note")%>
                                                                            </asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                                <EmptyDataTemplate>
                                                                    <b>No Record found</b>
                                                                </EmptyDataTemplate>
                                                                <PagerSettings Visible="False" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <div class="bandHeaderRow">
                                                                Event Claim Status
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Close File
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblClose_File" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Close Date
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblClose_Date" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Reopen File
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblReopen_File" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Reopen Date
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblReopen_Date" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Comments
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblEventComments" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <div class="bandHeaderRow">
                                                                Financial Risk Exposure Grid
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Financial Reserve Grid
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:GridView ID="gvFinancialReserveTransactionView" runat="server" GridLines="None"
                                                                CellPadding="4" CellSpacing="0" AutoGenerateColumns="false" Width="100%" EnableTheming="false"
                                                                OnRowCommand="gvFinancialReserveTransactionView_RowCommand">
                                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <RowStyle BackColor="#EAEAEA" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <EditRowStyle BackColor="#2461BF" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <PagerStyle BackColor="#7f7f7f" ForeColor="White" HorizontalAlign="Center" Font-Names="Tahoma"
                                                                    Font-Size="8pt" />
                                                                <HeaderStyle BackColor="#7f7f7f" Font-Bold="True" ForeColor="White" Font-Names="Tahoma"
                                                                    Font-Size="8pt" VerticalAlign="Bottom" />
                                                                <AlternatingRowStyle BackColor="White" Font-Names="Tahoma" Font-Size="8pt" />
                                                                <EmptyDataRowStyle CssClass="emptyrow" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Type" HeaderStyle-HorizontalAlign="Left" SortExpression="Transaction_Type">
                                                                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnNoteDateView" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_AP_FE_Transactions") %>'> <%# Eval("Type")%>&nbsp;<%# Eval("Category")%></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Date" HeaderStyle-HorizontalAlign="Left" SortExpression="Transaction_Date">
                                                                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnTransactionDate" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_AP_FE_Transactions") %>'>
                                                                            <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Transaction_Date")) %>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Amount" HeaderStyle-HorizontalAlign="Left" SortExpression="Transaction_Amount">
                                                                        <ItemStyle Width="100px" HorizontalAlign="Right" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnTransactionAmount" runat="server" CommandName="gvEdit"
                                                                                CommandArgument='<%# Eval("PK_AP_FE_Transactions") %>'>
                                                                            <%# string.Format("{0:C2}",Eval("Transaction_Amount"))%>
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                                <EmptyDataTemplate>
                                                                    <b>No Record found</b>
                                                                </EmptyDataTemplate>
                                                                <PagerSettings Visible="False" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Financial Matrix
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%" cellspacing="0px" cellpadding="5px">
                                                                <tr class="bandHeaderRow">
                                                                    <td align="left" valign="top" width="25%"></td>
                                                                    <td align="right" valign="top" width="25%">Potential Loss Exposure
                                                                    </td>
                                                                    <td align="right" valign="top" width="25%">Expense
                                                                    </td>
                                                                    <td align="right" valign="top" width="25%">Total
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" width="25%" class="bandHeaderRow">Reserve
                                                                    </td>
                                                                    <td align="right" valign="top" width="25%">
                                                                        <asp:Label ID="lblFMReservePotentialLossView" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="right" valign="top" width="25%">
                                                                        <asp:Label ID="lblFMReserveExpenseView" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="right" valign="top" width="25%">
                                                                        <asp:Label ID="lblFMReserveTotalView" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" width="25%" class="bandHeaderRow">Paid
                                                                    </td>
                                                                    <td align="right" valign="top" width="25%">
                                                                        <asp:Label ID="lblFMPaidPotentialLossView" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="right" valign="top" width="25%">
                                                                        <asp:Label ID="lblFMPaidExpenseView" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="right" valign="top" width="25%">
                                                                        <asp:Label ID="lblFMPaidTotalView" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" width="25%" class="bandHeaderRow">Recovery
                                                                    </td>
                                                                    <td align="right" valign="top" width="25%">
                                                                        <asp:Label ID="lblFMRecoveryPotentialLossView" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="right" valign="top" width="25%">
                                                                        <asp:Label ID="lblFMRecoveryExpenseView" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="right" valign="top" width="25%">
                                                                        <asp:Label ID="lblFMRecoveryTotalView" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" width="25%" class="bandHeaderRow">Outstanding
                                                                    </td>
                                                                    <td align="right" valign="top" width="25%">
                                                                        <asp:Label ID="lblFMOutstandingPotentialLossView" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="right" valign="top" width="25%">
                                                                        <asp:Label ID="lblFMOutstandingExpenseView" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="right" valign="top" width="25%">
                                                                        <asp:Label ID="lblFMOutstandingTotalView" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" width="100%" valign="top" align="left">
                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td valign="top" align="left" width="40%"></td>
                                                                    <td>
                                                                        <asp:Button ID="btnFruad_EventAudit_TrailView" Text="View Audit Trail" runat="server"
                                                                            OnClientClick="return openFraud_Event_AuditPopup();" CausesValidation="false"
                                                                            Visible="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <asp:Panel ID="pnlNoteGridAddView" runat="server" Width="100%" Style="display: none;">
                                                    <div class="bandHeaderRow">
                                                        Notes Grid
                                                    </div>
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <td align="left" width="21%" valign="top">Date
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblNotesDate" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Note Text
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <uc:ctrlMultiLineTextBox ID="txtNotesAddView" runat="server" ControlType="Label"
                                                                    ValidationGroup="vsErrorNotesAdd" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3" align="left" valign="top">
                                                                <table border="0" align="center" cellpadding="0" cellspacing="5">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Button ID="btnViewAuditNotesGridView" runat="server" Text="View Audit Trail"
                                                                                OnClientClick="return openAP_FE_Notes_AuditPopup();" CausesValidation="false"
                                                                                Visible="false" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="btnViewAuditNotesFraudGridView" runat="server" Text="View Audit Trail"
                                                                                OnClientClick="return openAP_FE_PA_Notes_AuditPopup();" CausesValidation="false"
                                                                                Visible="false" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="btnBackFraudEventView" runat="server" Text="Back" OnClick="btnBackFraudEventFromTransaction_Click" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlTransactionGridAddView" runat="server" Width="100%" Style="display: none;">
                                                    <div class="bandHeaderRow">
                                                        Transaction Grid
                                                    </div>
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <td align="left" width="21%" valign="top">Transaction Type
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top" width="75%" colspan="4">
                                                                <%--  <asp:DropDownList ID="ddlTransactionType11" runat="server" SkinID="ddlExposure">
                                                                </asp:DropDownList>--%>
                                                                <asp:Label ID="lblTransactionType" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="21%" valign="top">Transaction Catagory
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top" colspan="4">
                                                                <%--<asp:DropDownList ID="ddlTransactionCatagory11" runat="server" SkinID="ddlExposure">
                                                                </asp:DropDownList>--%>
                                                                <asp:Label ID="lblTransactionCatagory" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="21%" valign="top">Transaction Date
                                                            </td>
                                                            <td align="center" width="4%" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top" colspan="4">
                                                                <%--<asp:TextBox ID="txtTransactionDate11" runat="server" Width="170px" SkinID="txtDate"></asp:TextBox>--%>
                                                                <asp:Label ID="lblTransactionDate" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">Transaction Amount
                                                            </td>
                                                            <td align="center" valign="top">:
                                                            </td>
                                                            <td align="left" valign="top" colspan="4">$
                                                                <asp:Label ID="lblTransactionAmount" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" align="left" valign="top">
                                                                <table border="0" align="center" cellpadding="0" cellspacing="5">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Button ID="btnViewAuditTransactionGridView" runat="server" Text="View Audit Trail"
                                                                                OnClientClick="return openAP_FE_Transaction_AuditPopup();" CausesValidation="false"
                                                                                Visible="false" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="btnBackFraudEventFromTransactionView" runat="server" Text="Back"
                                                                                OnClick="btnBackFraudEventFromTransaction_Click" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </asp:Panel>
                                        </div>
                                        <asp:Panel ID="pnlAttachmentDetails" runat="server" Style="display: none;" Width="794px">
                                            <table cellpadding="0" cellspacing="0" width="100%" style="height: 250px;">
                                                <tr>
                                                    <td width="100%" valign="top">
                                                        <%--<uc:ctrlAttachmentDetail ID="AttachDetails" runat="Server" />--%>
                                                        <uc:ctrlAttachment ID="Attachments" runat="server" PanelNumber="6" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                        <td align="center">
                            <table border="0" cellpadding="5" cellspacing="1" width="100%">
                                <tr>
                                    <td>
                                        <asp:Button ID="btnPrevoius" Text="Previous" runat="server" OnClientClick="return onPreviousStep();" />&nbsp;&nbsp;
                                        <asp:Button ID="btnBack" runat="server" Text="Edit" OnClick="btnBack_Click" CausesValidation="false" />&nbsp;&nbsp;
                                        <asp:Button ID="btnReturnto_View_Mode" Text="Return to View Mode" runat="server"
                                            OnClick="btnReturnto_View_Mode_OnClick" Visible="false" CausesValidation="false"
                                            Width="150px" />&nbsp;&nbsp;
                                        <asp:Button ID="btnGenerate_Abstract" runat="server" Text="Generate Abstract" OnClientClick="return openGenereteAbstract();"
                                            Style="display: none;" CausesValidation="false" />&nbsp;&nbsp;
                                        <asp:Button ID="btnNext" Text="Next" runat="server" OnClientClick="return onNextStep();" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hdnPanel" runat="server" Value="1" />
    <asp:CustomValidator ID="CustomValidatorProperty_Security" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFieldsProperty_Security" Display="None" ValidationGroup="vsErrorProperty_Security" />
    <input id="hdnControlIDsProperty_Security" runat="server" type="hidden" />
    <input id="hdnErrorMsgsProperty_Security" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidatorDPD_FROIs" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFieldsDPD_FROIs" Display="None" ValidationGroup="vsErrorDPD_FROIs" />
    <input id="hdnControlIDsDPD_FROIs" runat="server" type="hidden" />
    <input id="hdnErrorMsgsDPD_FROIs" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidatorAl_FROIs" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFieldsAL_FROIs" Display="None" ValidationGroup="vsErrorAL_FROIs" />
    <input id="hdnControlIDsAL_FROIs" runat="server" type="hidden" />
    <input id="hdnErrorMsgsAL_FROIs" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidatorCalAtlantic" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFieldsCalAtlantic" Display="None" ValidationGroup="vsErrorCalAtlantic" />
    <input id="hdnControlIDsCalAtlantic" runat="server" type="hidden" />
    <input id="hdnErrorMsgsCalAtlantic" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidatorFraudEvents" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFieldsFraudEvents" Display="None" ValidationGroup="vsErrorFraudEvents" />
    <input id="hdnControlIDsFraudEvents" runat="server" type="hidden" />
    <input id="hdnErrorMsgsFraudEvents" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidatorFraudEventsNote" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFieldsFraudEventsNotes" Display="None" ValidationGroup="vsErrorFraudEventsNotes" />
    <input id="hdnControlIDsNotes" runat="server" type="hidden" />
    <input id="hdnErrorMsgsNotes" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidatorFraudEventsTransaction" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFieldsFraudEventsTransaction" Display="None"
        ValidationGroup="vsErrorFraudEventsTransaction" />
    <input id="hdnControlIDsTransaction" runat="server" type="hidden" />
    <input id="hdnErrorMsgsTransaction" runat="server" type="hidden" />
    <script type="text/javascript">
        function ValidateFieldsProperty_Security(sender, args) {
            var msg = "", ctrlIDs = "", Messages = "", hdnID = "";

            ctrlIDs = document.getElementById('<%=hdnControlIDsProperty_Security.ClientID%>').value.split(',');
            hdnID = '<%=hdnControlIDsProperty_Security.ClientID%>';
            Messages = document.getElementById('<%=hdnErrorMsgsProperty_Security.ClientID%>').value.split(',');
            var focusCtrlID = "";

            if (hdnID != "") {
                if (document.getElementById(hdnID).value != "") {
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
                else
                    args.IsValid = true;
            }
        }

        function ValidateFieldsDPD_FROIs(sender, args) {
            var Pk_DPD_FROI_ID = '<%=ViewState["FK_DPD_FR_ID"]%>';
            if (Pk_DPD_FROI_ID == '' || Pk_DPD_FROI_ID == '0') {
                sender.errormessage = 'Please select DPD First Report record first';
                args.IsValid = false;
            }
            else {
                var msg = "", ctrlIDs = "", Messages = "", hdnID = "";

                ctrlIDs = document.getElementById('<%=hdnControlIDsDPD_FROIs.ClientID%>').value.split(',');
                hdnID = '<%=hdnControlIDsDPD_FROIs.ClientID%>';
                Messages = document.getElementById('<%=hdnErrorMsgsDPD_FROIs.ClientID%>').value.split(',');
                var focusCtrlID = "";

                if (hdnID != "") {
                    if (document.getElementById(hdnID).value != "") {
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
                    else
                        args.IsValid = true;
                }
            }
        }

        function ValidateFieldsAL_FROIs(sender, args) {
            var Pk_AL_FROI_ID = '<%=ViewState["FK_AL_FR_ID"]%>';
            if (Pk_AL_FROI_ID == '' || Pk_AL_FROI_ID == '0') {
                sender.errormessage = 'Please select AL First Report record first';
                args.IsValid = false;
            }
            else {
                var msg = "", ctrlIDs = "", Messages = "", hdnID = "";
                ctrlIDs = document.getElementById('<%=hdnControlIDsAL_FROIs.ClientID%>').value.split(',');
                hdnID = '<%=hdnControlIDsAL_FROIs.ClientID%>';
                Messages = document.getElementById('<%=hdnErrorMsgsAL_FROIs.ClientID%>').value.split(',');
                var focusCtrlID = "";

                if (hdnID != "") {
                    if (document.getElementById(hdnID).value != "") {
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
                    else
                        args.IsValid = true;
                }
            }
        }

        function ValidateFieldsCalAtlantic(sender, args) {
            var PK_AP_Cal_Atlantic = '<%=ViewState["PK_AP_Cal_Atlantic"]%>';
            if (PK_AP_Cal_Atlantic == '' || PK_AP_Cal_Atlantic == '0') {
                sender.errormessage = 'Please select Event record first';
                args.IsValid = false;
            }
            else {
                var msg = "", ctrlIDs = "", Messages = "", hdnID = "";
                ctrlIDs = document.getElementById('<%=hdnControlIDsCalAtlantic.ClientID%>').value.split(',');
                hdnID = '<%=hdnControlIDsCalAtlantic.ClientID%>';
                Messages = document.getElementById('<%=hdnErrorMsgsCalAtlantic.ClientID%>').value.split(',');
                var focusCtrlID = "";

                if (hdnID != "") {
                    if (document.getElementById(hdnID).value != "") {
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
                    else
                        args.IsValid = true;
                }
            }
        }

        function ValidateFieldsFraudEvents(sender, args) {
            var msg = "", ctrlIDs = "", Messages = "", hdnID = "";
            ctrlIDs = document.getElementById('<%=hdnControlIDsFraudEvents.ClientID%>').value.split(',');
            hdnID = '<%=hdnControlIDsFraudEvents.ClientID%>';
            Messages = document.getElementById('<%=hdnErrorMsgsFraudEvents.ClientID%>').value.split(',');
            var focusCtrlID = "";

            if (hdnID != "") {
                if (document.getElementById(hdnID).value != "") {
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
                else
                    args.IsValid = true;
            }
        }

        function ValidateFieldsFraudEventsNotes(sender, args) {
            var msg = "", ctrlIDs = "", Messages = "", hdnID = "";
            ctrlIDs = document.getElementById('<%=hdnControlIDsNotes.ClientID%>').value.split(',');
            hdnID = '<%=hdnControlIDsNotes.ClientID%>';
            Messages = document.getElementById('<%=hdnErrorMsgsNotes.ClientID%>').value.split(',');
            var focusCtrlID = "";

            if (hdnID != "") {
                if (document.getElementById(hdnID).value != "") {
                    var i = 0;
                    for (i = 0; i < ctrlIDs.length; i++) {
                        var bEmpty = false;
                        var ctrl = document.getElementById(ctrlIDs[i]);
                        switch (ctrl.type) {
                            case "textarea":
                            case "text": if (ctrl.value == '') bEmpty = true; break;
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
                else
                    args.IsValid = true;
            }
        }


        function ValidateFieldsFraudEventsTransaction(sender, args) {
            var msg = "", ctrlIDs = "", Messages = "", hdnID = "";
            ctrlIDs = document.getElementById('<%=hdnControlIDsTransaction.ClientID%>').value.split(',');
            hdnID = '<%=hdnControlIDsTransaction.ClientID%>';
            Messages = document.getElementById('<%=hdnErrorMsgsTransaction.ClientID%>').value.split(',');
            var focusCtrlID = "";

            if (hdnID != "") {
                if (document.getElementById(hdnID).value != "") {
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
                else
                    args.IsValid = true;
            }
        }


        function SetValidationGroup() {
            var Index = document.getElementById('<%= hdnPanel.ClientID%>').value;
            var ValidationGroups;

            if (Index == 1) {
                ValidationGroups = "vsErrorProperty_Security";
            }
            else if (Index == 2) {
                ValidationGroups = "vsErrorDPD_FROIs";
            }
            else if (Index == 3) {
                ValidationGroups = "vsErrorAL_FROIs";
            }
            else if (Index == 4) {
                ValidationGroups = "vsErrorCalAtlantic";
            }
            else if (Index == 5) {
                ValidationGroups = "vsErrorFraudEvents";
            }
            if (ValidationGroups != "") {
                if (Page_ClientValidate(ValidationGroups)) {
                    return true;
                }
                else {
                    Page_ClientValidate('dummy');
                    return false;
                }
            }
            return true;
        }
    </script>
</asp:Content>
