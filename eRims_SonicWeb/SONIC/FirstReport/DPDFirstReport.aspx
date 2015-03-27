<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="DPDFirstReport.aspx.cs"
    Inherits="SONIC_DPDFirstReport" Title="First Report :: Dealer Physical Damage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachments/Attachment_DPD.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/AttachmentDetails/AttachmentDetails.ascx" TagName="ctrlAttachmentDetails"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/SONICtab/SonicTab.ascx" TagName="CtlSonicTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/SONICInfo/SonicInfo.ascx" TagName="CtlSonicInfo" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .DisplayNone {
            display: none;
        }
    </style>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery.maskedinput.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Date_Validation.js"></script>

    <script language="javascript" type="text/javascript">


        //var changeHandler =
        function ShowVehicleDetails(a) {
            var selectedValues = [];
            $("#" + '<%= lstCauseOfLoss.ClientID%>' + ":selected").each(function () {
                selectedValues.push($(this).val());
            });
            alert(a);
            $("#tdVehicleDetails").css("display", "");
            SetLossSaveButton();
            var selectedValues = [];
            $("#" + '<%= lstCauseOfLoss.ClientID%>' + ":selected").each(function () {
                selectedValues.push($(this).val());
            });
            alert(selectedValues);
            return true;
        }

        //$('#<%= lstCauseOfLoss.ClientID %>').change(changeHandler).keypress(changeHandler);

        function CheckNumericVal(Ctl) {
            if (Ctl.value == "" || isNaN(Number(Ctl.value.replace(/,/g, '')) * 1) == true)
                Ctl.innerText = "";
        }

        function AuditPopUpForDPDPassenger(id) {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;

            obj = window.open("AuditPopup_DPD_Passenger.aspx?id=" + id, 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }
        function AuditPopUpForDPDVeh(id) {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;

            obj = window.open("AuditPopup_DPD_FR_Vehicle.aspx?id=" + id, 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }
        //Open Audit Popup
        function AuditPopUp() {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;

            obj = window.open("AuditPopup_DPDFirstReport.aspx?id=" + '<%=ViewState["DPD_FR_ID"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }
        //Open Witness Popup
        function AuditWitnessPopUp(id) {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;

            obj = window.open("AuditPopup_DPD_Witness.aspx?id=" + id, 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }
        //check Date Validation
        function CheckDate(sender, args) {
            args.IsValid = (ValidateDate(args.Value));
            return args.IsValid;
        }
        //used to check all validation Group.
        function CheckAllValidation() {
            //check Validation of Page
            if (CheckValidationLossInfo() == true && CheckValidationContactsInfo() == true && CheckValidationComments() == true) {
                return true;
            }
            else
                return false;

            //    if(Page_ClientValidate("vsLossInfoGroup") && Page_ClientValidate("vsContactInfoGroup"))
            //    { 
            //        return true;
            //    }
            //    else
            //        return false;
        }
        //used to check validation fro Loss information Panel
        function CheckValidationLossInfo() {
            //Validate Page for Passed Validation Group
            
            if (Page_ClientValidate("vsLossInfoGroup")) {
                return true;
            }
            else {
                Page_BlockSubmit = false;
                return false;
            }
        }

        //Validate Witness
        function ValidWitness() {
            //check value if it is "___-___-___" than convert this value to ""
            if (document.getElementById('<%=txtWitness_Phone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtWitness_Phone.ClientID%>').value = "";

            //Validate Page for Passed Validation Group
            if (Page_ClientValidate("vsWitnessGroup")) {
                
                return true;
            }
            else {
                return false;
                
            }
        }
        function CheckValidationComments() {
            //Validate Page for Passed Validation Group
            if (Page_ClientValidate("vsCommentsGroup")) {
                
                return true;
            }
            else {
                
                return false;
            }
        }
        //Used to check validation for Contact Information Panel
        function CheckValidationContactsInfo() {
            
            //check value if it is "___-___-___" than convert this value to ""
            if (document.getElementById('<%=txtEmployee_Fax.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtEmployee_Fax.ClientID%>').value = "";
            //if time is "__:__" than set it to ""
            if (document.getElementById('<%=txtTime_of_Loss.ClientID%>').value == "__:__")
                document.getElementById('<%=txtTime_of_Loss.ClientID%>').value = "";
            //if time is "__:__" than set it to ""
            if (document.getElementById('<%=txtContact_Best_Time.ClientID%>').value == "__:__")
                document.getElementById('<%=txtContact_Best_Time.ClientID%>').value = "";
            //if time is containing "a" or "p" or "A" or "P" work than prompt the alert message and blank time value
            if (document.getElementById('<%=txtTime_of_Loss.ClientID%>').value.indexOf("a") > 0 || document.getElementById('<%=txtTime_of_Loss.ClientID%>').value.indexOf("A") > 0
    || document.getElementById('<%=txtTime_of_Loss.ClientID%>').value.indexOf("p") > 0 || document.getElementById('<%=txtTime_of_Loss.ClientID%>').value.indexOf("P") > 0) {
                alert('Invalid Time of Incident.');
                document.getElementById('<%=txtTime_of_Loss.ClientID%>').value = "";
                return false;
            }
            //if time is containing "a" or "p" or "A" or "P" work than prompt the alert message and blank time value
            if (document.getElementById('<%=txtContact_Best_Time.ClientID%>').value.indexOf("a") > 0 || document.getElementById('<%=txtContact_Best_Time.ClientID%>').value.indexOf("A") > 0
    || document.getElementById('<%=txtContact_Best_Time.ClientID%>').value.indexOf("p") > 0 || document.getElementById('<%=txtContact_Best_Time.ClientID%>').value.indexOf("P") > 0) {
                alert('Invalid When to Contact Time.');
                document.getElementById('<%=txtContact_Best_Time.ClientID%>').value = "";
                document.getElementById('<%=txtContact_Best_Time.ClientID%>').focus();
                return false;
            }
            //validate page for Passed Validation Group
            if (Page_ClientValidate("vsContactInfoGroup")) {
                
                return true;
            }
            else {
                
                return false;
            }
        }



        //Used to set Menu Style
        function SetMenuStyle(index) {
            var i;
            for (i = 1; i <= 4; i++) {
                var tb = document.getElementById("DPDMenu" + i);
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
        //Show panel
        function ShowPanel(index) {
            SetMenuStyle(index);
            var op = '<%=strPageOpeMode%>';
            if (op == "view") {
                document.getElementById("<%=dvEdit.ClientID %>").style.display = "none";
                document.getElementById("<%=dvView.ClientID%>").style.display = "";
                ShowPanelView(index);
            }
            else {
                document.getElementById("<%=dvView.ClientID%>").style.display = "none";
                //check if index is 1 than display Location Section.
                if (index == 1) {
                    document.getElementById("<%=pnlLocation.ClientID%>").style.display = "";
                    document.getElementById("<%=pnlLossInformation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlWitnesses.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlComments.ClientID%>").style.display = "none";
                }
                //check if index is 2 than display Loss Information Section.
                if (index == 2) {
                    document.getElementById("<%=pnlLocation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlLossInformation.ClientID%>").style.display = "";
                    document.getElementById("<%=pnlWitnesses.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlComments.ClientID%>").style.display = "none";
                }
                //check if index is 3 than display Comments and Attachments Section.
                if (index == 3) {
                    document.getElementById("<%=pnlLocation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlLossInformation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlWitnesses.ClientID%>").style.display = "";
                    document.getElementById("<%=pnlComments.ClientID%>").style.display = "none";
                }
                //check if index is 4 than display Comments and Attachments Section.
                if (index == 4) {
                    document.getElementById("<%=pnlLocation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlLossInformation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlWitnesses.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlComments.ClientID%>").style.display = "";
                }

            }
            document.getElementById("<%=hdnCureentPanel.ClientID%>").value = index;
        }
        //shown panel for View Mode
        function ShowPanelView(index) {

            SetMenuStyle(index);
            //check if index is 1 than display Location Section.
            if (index == 1) {
                document.getElementById("<%=pnlViewLocation.ClientID%>").style.display = "";
                document.getElementById("<%=pnlViewLossInformation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewWitnesses.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewComments.ClientID%>").style.display = "none";
            }
            //check if index is 2 than display Loss Information Section.
            if (index == 2) {
                document.getElementById("<%=pnlViewLocation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewLossInformation.ClientID%>").style.display = "";
                document.getElementById("<%=pnlViewWitnesses.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewComments.ClientID%>").style.display = "none";
            }
            //check if index is 3 than display Witness Section.
            if (index == 3) {
                document.getElementById("<%=pnlViewLocation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewLossInformation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewWitnesses.ClientID%>").style.display = "";
                document.getElementById("<%=pnlViewComments.ClientID%>").style.display = "none";
            }
            //check if index is 4 than display comments and Attchment Section.
            if (index == 4) {
                document.getElementById("<%=pnlViewLocation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewLossInformation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewWitnesses.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewComments.ClientID%>").style.display = "";
            }
        }

        jQuery(function ($) {
            $("#<%=txtDate_Of_Loss.ClientID%>").mask("99/99/9999");
            $("#<%=txtDate_Reported_To_Sonic.ClientID%>").mask("99/99/9999");
            $("#<%=txtLossDate_Of_Loss.ClientID%>").mask("99/99/9999");
            $("#<%=txtEmployee_Fax.ClientID%>").mask("999-999-9999");
            $("#<%=txtWitness_Phone.ClientID%>").mask("999-999-9999");
            $("#<%=txtTime_of_Loss.ClientID%>").mask("99:99");
            $("#<%=txtContact_Best_Time.ClientID%>").mask("99:99");
        });

        var bAddedVehicle;

        function EnableDisableLossSavebutton(chkChecked) {
            var lossSave = document.getElementById('<%=btnLossSave.ClientID %>');

            var bValid = true;

            if (bAddedVehicle == false) {
                bValid = false;
            }

            if (!chkChecked && !bValid) lossSave.disabled = true;
            else if (chkChecked && !bValid) lossSave.disabled = true;
            else if (!chkChecked && bValid) lossSave.disabled = false;
            else if (chkChecked && bValid) lossSave.disabled = false;
        }

        function SetLossSaveButton() {
            var lossSave = document.getElementById('<%=btnLossSave.ClientID %>');
            var lst = document.getElementById('<%=lstCauseOfLoss.ClientID %>');
            //lossSave.disabled = false;

            //var gv1, gv2, gv3, gv4, gv5, gv6, gv7, gv8, gv9, gv10;
            //var cnt1 = 0, cnt2 = 0, cnt3 = 0, cnt4 = 0, cnt5 = 0, cnt6 = 0, cnt7 = 0, cnt8 = 0, cnt9 = 0, cnt10 = 0;

            var gv1;
            var cnt1 = 0;
            gv1 = document.getElementById('<%=gvVehicleDetails.ClientID %>');

                if (gv1 != null) cnt1 = gv1.rows.length;
            //if (gv2 != null) cnt2 = gv2.rows.length; if (gv3 != null) cnt3 = gv3.rows.length;
            //if (gv4 != null) cnt4 = gv4.rows.length; if (gv5 != null) cnt5 = gv5.rows.length; if (gv6 != null) cnt6 = gv6.rows.length;
            //if (gv7 != null) cnt7 = gv7.rows.length; if (gv8 != null) cnt8 = gv8.rows.length; if (gv9 != null) cnt9 = gv9.rows.length;
            //if (gv10 != null) cnt9 = gv10.rows.length;

                if (cnt1 <= 1) lossSave.disabled = true;
            //if (lst.options[0].selected && cnt1 <= 1) lossSave.disabled = true;
            //if (lst.options[1].selected && cnt2 <= 1) lossSave.disabled = true;
            //if (lst.options[2].selected && cnt3 <= 1) lossSave.disabled = true;
            //if (lst.options[3].selected && cnt4 <= 1) lossSave.disabled = true;
            //if (lst.options[4].selected && cnt5 <= 1) lossSave.disabled = true;
            //if (lst.options[5].selected && cnt6 <= 1) lossSave.disabled = true;
            //if (lst.options[6].selected && cnt7 <= 1) lossSave.disabled = true;
            //if (lst.options[7].selected && cnt8 <= 1) lossSave.disabled = true;
            //if (lst.options[8].selected && cnt9 <= 1) lossSave.disabled = true;
            //if (lst.options[9].selected && cnt10 <= 1) lossSave.disabled = true;
            }

            ///This Function used to display/Hide Question in Thift Section according to Radio button value
            function checkTheftVehicleRecorved() {
                var ValidTakePossession = document.getElementById('<%=rfv_Dealership_Wish_To_Take_Possession.ClientID %>');
            var ctl = document.getElementById('<%=rdo_Vehicle_Recovered.ClientID %>');
            rdo = document.getElementById(ctl.id + "_0");
            if (rdo.checked == true) {
                document.getElementById('<%=td_VehicleRecovred.ClientID %>').style.display = "";
                ValidTakePossession.enabled = true;
            }
            else {
                document.getElementById('<%=td_VehicleRecovred.ClientID %>').style.display = "none";
                ValidTakePossession.enabled = false;
            }
        }
        function TheftCheck(bChecked) {
            var ValidYear = document.getElementById('<%=revTheft_Year.ClientID %>');
            if (bChecked == true) {

                ValidYear.enabled = true;
                if (bAddedVehicle != true) bAddedVehicle = false;
            }
            else {

                ValidYear.enabled = false;
                bAddedVehicle = true;
            }
            EnableDisableLossSavebutton(bChecked);
        }

        ///This Function used to display/Hide Question in Thift Section according to Radio button value
        function checkTheftVehicleInStorage() {
            var ctl = document.getElementById('<%=rdoVehicle_In_Storage.ClientID %>');
            rdo = document.getElementById(ctl.id + "_0");

            if (rdo.checked == true) {
                document.getElementById('<%=tdVehicle_In_Storage.ClientID %>').style.display = "";
            }
            else {
                document.getElementById('<%=tdVehicle_In_Storage.ClientID %>').style.display = "none";
            }
        }
        function checkPoliceNotified() {
            var ctl = document.getElementById('<%=rdoPoliceNotified.ClientID %>');
            rdo = document.getElementById(ctl.id + "_0");
            if (rdo.checked == true) {
                document.getElementById('<%=trPoliceNotified.ClientID %>').style.display = "";
            }
            else {
                document.getElementById('<%=trPoliceNotified.ClientID %>').style.display = "none";
            }
        }
        // used to display/Hide Question in MVA-Multi section according radiobutton value
        function CheckMVAMultiDrivenByCA() {
            var ValidVehicle_Driven_By_Customer = document.getElementById('<%=rfvMVA_MultiVehicle_Driven_By_Customer.ClientID %>');
            var ValidAssociate_Cited = document.getElementById('<%=rfvMVA_MultiAssociate_Cited.ClientID %>');
            var ValidAssociate_injured = document.getElementById('<%=rfvMVA_MultiAssociate_injured.ClientID %>');
            var ValidDrug_test_performed = document.getElementById('<%=rfvMVA_MultiDrug_test_performed.ClientID %>');
            var ctl = document.getElementById('<%=rdoMVA_MultiDriven_By_Associate.ClientID %>');
            rdo = document.getElementById(ctl.id + "_0");
            if (rdo.checked == false) {
                document.getElementById('<%=trMVAMulti_DrivenByCA_No.ClientID %>').style.display = "";
                document.getElementById('<%=trMVAMulti_DrivenByCA_Yes.ClientID %>').style.display = "none";
                ValidAssociate_Cited.enabled = false;
                ValidAssociate_injured.enabled = false;
                ValidDrug_test_performed.enabled = false;
                ValidVehicle_Driven_By_Customer.enabled = true;
            }
            else {
                document.getElementById('<%=trMVAMulti_DrivenByCA_No.ClientID %>').style.display = "none";
                document.getElementById('<%=trMVAMulti_DrivenByCA_Yes.ClientID %>').style.display = "";
                ValidAssociate_Cited.enabled = true;
                ValidAssociate_injured.enabled = true;
                ValidDrug_test_performed.enabled = true;
                ValidVehicle_Driven_By_Customer.enabled = false;
            }
        }

        // used to display/Hide Question in MVA-Multi section according radiobutton value
        function CheckMultiSeeking_subrogation() {
            var ValidNotice_only_claim = document.getElementById('<%=rfvMVA_MultiNotice_only_claim.ClientID %>');
            var ctl = document.getElementById('<%=rdoMVA_MultiSeeking_subrogation.ClientID %>');
            rdo = document.getElementById(ctl.id + "_0");
            if (rdo.checked == true) {
                ValidNotice_only_claim.enabled = false;
                document.getElementById('<%=trMVA_MultiSeeking_subrogation_Yes.ClientID %>').style.display = "";
                document.getElementById('<%=trMVA_MultiSeeking_subrogation_No.ClientID %>').style.display = "none";
            }
            else {
                ValidNotice_only_claim.enabled = true;
                document.getElementById('<%=trMVA_MultiSeeking_subrogation_Yes.ClientID %>').style.display = "none";
                document.getElementById('<%=trMVA_MultiSeeking_subrogation_No.ClientID %>').style.display = "";
            }
        }
        // used to display/Hide Question in MVA-Multi section according radiobutton value
        function CheckMultiAdditional_passengers() {
            var ctl = document.getElementById('<%=rdoMVA_MultiAdditional_passengers.ClientID %>');
            rdo = document.getElementById(ctl.id + "_0");
            if (rdo.checked == true) {
                document.getElementById('<%=trMVA_MultiAdditional_passengers_Yes.ClientID %>').style.display = "";
            }
            else {
                document.getElementById('<%=trMVA_MultiAdditional_passengers_Yes.ClientID %>').style.display = "none";
            }
        }
        function CheckMultiCitation(ValidDesc) {
            var ctl = document.getElementById('<%=rdoMVA_MultiAssociate_Cited.ClientID %>');
            rdo = document.getElementById(ctl.id + "_0");
            if (rdo.checked == true) {
                document.getElementById('<%=trMVA_MultiCitation_Yes.ClientID %>').style.display = "";
                ValidDesc.enabled = true;
            }
            else {
                document.getElementById('<%=trMVA_MultiCitation_Yes.ClientID %>').style.display = "none";
                ValidDesc.enabled = false;
            }
        }
        // used to display/Hide Question in MVA-Multi section according radiobutton value
        function CheckMultiDrugTest(ValidDrugYes, ValidDrugNo) {
            var ctl = document.getElementById('<%=rdoMVA_MultiDrug_test_performed.ClientID %>');
            rdo = document.getElementById(ctl.id + "_0");
            if (rdo.checked == true) {
                document.getElementById('<%=trMVA_MultiDrugYes.ClientID %>').style.display = "";
                document.getElementById('<%=trMVA_MultiDrugNo.ClientID %>').style.display = "none";
                ValidDrugYes.enabled = true;
                ValidDrugNo.enabled = false;
            }
            else {
                document.getElementById('<%=trMVA_MultiDrugYes.ClientID %>').style.display = "none";
                document.getElementById('<%=trMVA_MultiDrugNo.ClientID %>').style.display = "";
                ValidDrugYes.enabled = false;
                ValidDrugNo.enabled = true;
            }
        }
        // used to display/Hide Question in MVA-Multi section according radiobutton value
        function CheckMultiDrivenByCust(ValidNotCustExplain) {
            var Validcustomer_injured = document.getElementById('<%=rfvMVA_Multicustomer_injured.ClientID %>');
            var ctl = document.getElementById('<%=rdoMVA_MultiVehicle_Driven_By_Customer.ClientID %>');
            rdo = document.getElementById(ctl.id + "_0");
            if (rdo.checked == true) {
                document.getElementById('<%=trMVA_MultiCust_Injured.ClientID %>').style.display = "";
                document.getElementById('<%=trMVA_MultiCust_Not_Injured.ClientID %>').style.display = "none";
                Validcustomer_injured.enabled = true;
                ValidNotCustExplain.enabled = false;
            }
            else {
                document.getElementById('<%=trMVA_MultiCust_Injured.ClientID %>').style.display = "none";
                document.getElementById('<%=trMVA_MultiCust_Not_Injured.ClientID %>').style.display = "";
                Validcustomer_injured.enabled = false;
                ValidNotCustExplain.enabled = true;
            }
        }
    </script>

    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Location/Contact Panel:" BorderWidth="1"
            BorderColor="DimGray" ValidationGroup="vsContactInfoGroup" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsLossInfo" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Loss Information Panel:" BorderWidth="1"
            BorderColor="DimGray" ValidationGroup="vsLossInfoGroup" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsLossError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in MVA – Damage to Inventory (Single Vehicle):" BorderWidth="1"
            BorderColor="DimGray" ValidationGroup="vsSingleVehicleGroup" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsAttchments" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Comments/Attachment Panel:" BorderWidth="1"
            BorderColor="DimGray" ValidationGroup="AddAttachment" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsMVAMulti" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in MVA – Damage to Inventory (Multiple Vehicles):" BorderWidth="1"
            BorderColor="DimGray" ValidationGroup="vsMVAMultiGroup" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsFraud" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Fraud Section:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsFraudGroup" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsVehicle" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Theft Section:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsVehicleGroup" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsPartialTheft" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Partial Theft Section:" BorderWidth="1"
            BorderColor="DimGray" ValidationGroup="vsPartialTheftGroup" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsVandalism" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Vandalism Section:" BorderWidth="1"
            BorderColor="DimGray" ValidationGroup="vsVandalismGroup" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsHail" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Hail Section:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsHailGroup" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsFlood" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Flood Section:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsFloodGroup" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsFire" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Fire Section:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsFireGroup" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsWind" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Wind Section:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsWindGroup" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsWitness" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Witness Section:" BorderWidth="1"
            BorderColor="DimGray" ValidationGroup="vsWitnessGroup" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsSinglePass" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Passenger Section of MVA – Damage to Inventory (Single Vehicle):"
            BorderWidth="1" BorderColor="DimGray" ValidationGroup="vsSinglePassGroup" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsMultiPass" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Passenger Section of MVA – Damage to Inventory (Multiple Vehicles):"
            BorderWidth="1" BorderColor="DimGray" ValidationGroup="vsMultiPassGroup" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsCommentsGroup" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Comments Section:"
            BorderWidth="1" BorderColor="DimGray" ValidationGroup="vsCommentsGroup" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <div style="display: none;">
        <asp:TextBox ID="txtCompare" runat="server" Height="0px" Width="0px" Text="0.00"></asp:TextBox>
    </div>
    <asp:HiddenField ID="hdnCureentPanel" runat="server" />
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100%" style="height: 50px;" valign="bottom" colspan="2">
                <uc:CtlSonicTab runat="server" ID="SonicTab"></uc:CtlSonicTab>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td class="Spacer" style="height: 15px;" colspan="2"></td>
                    </tr>
                    <tr>
                        <td width="100%" colspan="2">
                            <asp:UpdatePanel runat="Server" ID="updSonic" UpdateMode="Always">
                                <ContentTemplate>
                                    <uc:CtlSonicInfo runat="server" ID="SonicInfo" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" style="height: 15px;" colspan="2"></td>
                    </tr>
                    <tr>
                        <td class="leftMenu">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="height: 18px;" class="Spacer"></td>
                                </tr>
                                <tr>
                                    <td width="100%">
                                        <asp:Menu ID="mnuDPD" runat="server" DataSourceID="dsDPDMenu" StaticEnableDefaultPopOutImage="false">
                                            <StaticItemTemplate>
                                                <table cellpadding="5" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="100%">
                                                            <span id="DPDMenu<%#Container.ItemIndex+1%>" onclick="javascript:ShowPanel(<%#Container.ItemIndex+1%>);"
                                                                class="LeftMenuStatic">
                                                                <%#Eval("Text")%>&nbsp;
                                                                <asp:Label ID="MenuAsterisk" runat="server" Text="*" Style="color: Red; display: none"></asp:Label>
                                                            </span>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </StaticItemTemplate>
                                        </asp:Menu>
                                        <asp:SiteMapDataSource ID="dsDPDMenu" runat="server" SiteMapProvider="DPDMenuProvider"
                                            ShowStartingNode="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 5px;" class="Spacer"></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblSubmitMessage" SkinID="lblError"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:UpdateProgress runat="server" ID="upProgress" DisplayAfter="100">
                                            <ProgressTemplate>
                                                <div class="UpdatePanelloading" id="divProgress" style="width: 100%;">
                                                    <table id="ProgressTable" cellpadding="0" cellspacing="0" border="0" style="width: 100%; height: 100%;">
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
                            </table>
                        </td>
                        <td valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td style="width: 5px">&nbsp;
                                    </td>
                                    <td style="width: 794px" valign="top" class="dvContainer">
                                        <div id="dvEdit" runat="server" style="display: block;">
                                            <asp:Panel ID="pnlLocation" runat="server" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Location Information
                                                </div>
                                                <asp:UpdatePanel runat="server" ID="updLocation">
                                                    <ContentTemplate>
                                                        <asp:HiddenField runat="server" ID="hdnLocation" />
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" width="18%">Location Number
                                                                </td>
                                                                <td align="center" width="4%">:
                                                                </td>
                                                                <td align="left" width="26%">
                                                                    <asp:DropDownList runat="server" ID="ddlLocationNumber" SkinID="ddlSONIC">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left" width="18%">Location d/b/a
                                                                </td>
                                                                <td align="center" width="2%">:
                                                                </td>
                                                                <td align="left" width="30%">
                                                                    <asp:DropDownList runat="server" ID="ddlLocationdba" SkinID="default" Width="90%">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Legal Entity
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList runat="server" ID="ddlLegalEntity" SkinID="ddlSONIC">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left">Location f/k/a
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddlLocationfka" SkinID="ddlSONIC" runat="server">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Address 1
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox ID="txtLocationAddress1" Width="170px" runat="server" MaxLength="50">
                                                                    </asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Address 2
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox ID="txtLocationAddress2" Width="170px" runat="server" MaxLength="50">
                                                                    </asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">City
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox ID="txtLocationCity" runat="server" Width="170px" MaxLength="30"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">State
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtLocationState" Width="170px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Zip Code
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox ID="txtLocationZipCode" runat="server" Width="170px" MaxLength="10"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <div class="bandHeaderRow">
                                                            Loss Location if Different
                                                        </div>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" style="width: 18%">Address 1&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">:
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtLoss_Address_1" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left" style="width: 18%">Did the accident occur on company property?
                                                                </td>
                                                                <td align="center" style="width: 4%">:
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:RadioButtonList runat="server" ID="rdoOn_Company_Property" SkinID="YesNoType">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Address 2&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtLoss_Address_2" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left">Date of Loss&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtDate_Of_Loss" runat="server"></asp:TextBox>
                                                                    <asp:TextBox ID="txtCurrentDate" runat="server" Style="display: none"></asp:TextBox>
                                                                    <img alt="Date of Loss" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Of_Loss', 'mm/dd/y',CompareDateLessThanToday,'ctl00_ContentPlaceHolder1_txtDate_Of_Loss');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" /><br />
                                                                    <asp:CustomValidator ID="cvDateofLoss" runat="server" ControlToValidate="txtDate_Of_Loss"
                                                                        ValidationGroup="vsContactInfoGroup" ClientValidationFunction="CheckDate" ErrorMessage="Loss Date is not valid."
                                                                        Display="None">
                                                                    </asp:CustomValidator>
                                                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtDate_Of_Loss"
                                                                        ValidationGroup="vsContactInfoGroup" ErrorMessage="Date of Loss Should Not Be Future Date."
                                                                        Type="Date" Operator="LessThanEqual" ControlToCompare="txtCurrentDate" Display="none">
                                                                    </asp:CompareValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">City&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtLoss_City" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left">Time of Loss (HH:MM)&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtTime_of_Loss" Width="170px"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revtxtTime_of_Loss" runat="server" ControlToValidate="txtTime_of_Loss"
                                                                        ValidationExpression="^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$"
                                                                        ErrorMessage="Time of Loss is invalid." Display="none" ValidationGroup="vsContactInfoGroup"
                                                                        SetFocusOnError="true" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">State&nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList runat="server" ID="ddlLoss_State" SkinID="ddlSONIC">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left">&nbsp;
                                                                </td>
                                                                <td align="center">&nbsp;
                                                                </td>
                                                                <td align="left">&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Zip Code&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtLoss_ZipCode" Width="170px" MaxLength="10"></asp:TextBox>
                                                                </td>
                                                                <td align="left">&nbsp;
                                                                </td>
                                                                <td align="center">&nbsp;
                                                                </td>
                                                                <td align="left">&nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <div class="bandHeaderRow">
                                                            Contact Information
                                                        </div>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" width="18%">Dealership/Collision Center
                                                                </td>
                                                                <td align="center" width="4%">:
                                                                </td>
                                                                <td width="28%" align="left">
                                                                    <asp:TextBox runat="server" ID="txtdba" Width="170px"></asp:TextBox>
                                                                </td>
                                                                <td align="left" width="18%">&nbsp;
                                                                </td>
                                                                <td align="left" width="4%">&nbsp;
                                                                </td>
                                                                <td align="left" width="28%">&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Contact Name
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtContactName" Width="170px"></asp:TextBox>
                                                                </td>
                                                                <td align="left">Address 1
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtAddress_1" Width="170px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">When to Contact&nbsp;<span id="Span8" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtContact_Best_Time" Width="170px"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revtxtContact_Best_Time" runat="server" ControlToValidate="txtContact_Best_Time"
                                                                        ValidationExpression="^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$"
                                                                        ErrorMessage="Time of When to Contact is invalid." Display="none" ValidationGroup="vsContactInfoGroup"
                                                                        SetFocusOnError="true" />
                                                                </td>
                                                                <td align="left">Address 2
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtAddress_2" Width="170px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Telephone Number 1<br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtWork_Phone" Width="170px"></asp:TextBox>
                                                                </td>
                                                                <td align="left">City
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtCity" Width="170px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Telephone Number 2<br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtEmployee_Cell_Phone" Width="170px"></asp:TextBox>
                                                                </td>
                                                                <td align="left">State
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtState" Width="170px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Fax Number<br />
                                                                    (xxx-xxx-xxxx)&nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtEmployee_Fax" Width="170px" runat="server" MaxLength="50">
                                                                    </asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revContactFaxNumber" ControlToValidate="txtEmployee_Fax"
                                                                        runat="server" ValidationGroup="vsContactInfoGroup" ErrorMessage="Please Enter Fax Number in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left">Zip
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtZip_Code" Width="170px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Email Address
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox ID="txtEmail" runat="server" Width="170px" MaxLength="30"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Date Reported to Sonic&nbsp;<span id="Span10" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox ID="txtDate_Reported_To_Sonic" runat="server"></asp:TextBox>
                                                                    <img alt="Date Reported to SONIC" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Reported_To_Sonic', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" /><br />
                                                                    <asp:CustomValidator ID="cvDate_Reported_To_Sonic" runat="server" ControlToValidate="txtDate_Reported_To_Sonic"
                                                                        ValidationGroup="vsContactInfoGroup" ClientValidationFunction="CheckDate" ErrorMessage="Date Reported to Sonic is not valid."
                                                                        Display="None">
                                                                    </asp:CustomValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" align="center">
                                                                    <asp:Button runat="server" ID="btnLocationSave" Text="Save & Continue" OnClick="btnLocationSave_Click"
                                                                        CausesValidation="true" ValidationGroup="vsContactInfoGroup" OnClientClick="return CheckValidationContactsInfo();" />
                                                                    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
                                                                        Display="None" ValidationGroup="vsContactInfoGroup" />
                                                                    <input id="hdnControlIDs1" runat="server" type="hidden" />
                                                                    <input id="hdnErrorMsgs1" runat="server" type="hidden" />
                                                                    <asp:Button runat="server" ID="btnLocationAudit" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();"
                                                                        ToolTip="View Audit Trail" CausesValidation="false" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlLossInformation" Width="100%" runat="server">
                                                <asp:UpdatePanel ID="updateLoss" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <div class="bandHeaderRow">
                                                            Loss Information
                                                        </div>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">

                                                            <tr>
                                                                <td align="left" style="width: 18%">Date of Loss&nbsp;<span id="Span11" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 5%">:
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtLossDate_Of_Loss" Width="170px" Enabled="true"></asp:TextBox>
                                                                    <img alt="Date of Loss" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtLossDate_Of_Loss', 'mm/dd/y',CompareDateLessThanToday,'ctl00_ContentPlaceHolder1_txtLossDate_Of_Loss');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" /><br />
                                                                    <asp:CustomValidator ID="cvLossDate_Of_Loss" runat="server" ControlToValidate="txtLossDate_Of_Loss"
                                                                        ValidationGroup="vsLossInfoGroup" ClientValidationFunction="CheckDate" ErrorMessage="Loss Date is not valid."
                                                                        Display="None">
                                                                    </asp:CustomValidator>
                                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtLossDate_Of_Loss"
                                                                        ValidationGroup="vsLossInfoGroup" ErrorMessage="Date of Loss Should Not Be Future Date."
                                                                        Type="Date" Operator="LessThanEqual" ControlToCompare="txtCurrentDate" Display="none">
                                                                    </asp:CompareValidator>


                                                                </td>
                                                                <td align="left" style="width: 18%">&nbsp;
                                                                </td>
                                                                <td align="center" style="width: 4%">&nbsp;
                                                                </td>
                                                                <td align="left" style="width: 28%">&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" align="left">Cause of Loss to Sonic Inventory&nbsp;<span id="lblAsteriskCause" runat="server" style="color: red; display: none;">*</span><br />
                                                                    Please provide the additional information for EACH Cause of Loss to Sonic Inventory selected.
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="100%" colspan="6">
                                                                    <%-- --%>
                                                                    <asp:ListBox ID="lstCauseOfLoss" runat="server" Width="250px" SelectionMode="Multiple" AutoPostBack="true" OnSelectedIndexChanged="lstCauseOfLoss_SelectedIndexChanged" Rows="10">
                                                                        <asp:ListItem Text="Fire" Value="8" />
                                                                        <asp:ListItem Text="Flood" Value="7" />
                                                                        <asp:ListItem Text="Fraud" Value="10" />
                                                                        <asp:ListItem Text="Hail" Value="6" />
                                                                        <asp:ListItem Text="MVA – Damage (Multiple Vehicle)" Value="5" />
                                                                        <asp:ListItem Text="MVA – Damage (Single Vehicle)" Value="4" />
                                                                        <asp:ListItem Text="Partial Theft" Value="2" />
                                                                        <asp:ListItem Text="Theft" Value="1" />
                                                                        <asp:ListItem Text="Vandalism" Value="3" />
                                                                        <asp:ListItem Text="Wind" Value="9" />
                                                                    </asp:ListBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6">
                                                                    <asp:GridView ID="gvVehicleDetails" runat="server" DataKeyNames="PK_DPD_FR_Vehicle_ID"
                                                                        AutoGenerateColumns="false" Width="100%" AllowSorting="false" OnRowDataBound="gvVehicleDetails_RowDataBound"
                                                                        OnRowCreated="gvVehicleDetails_RowCreated" OnRowCommand="gvVehicleDetails_RowCommand"
                                                                        OnRowEditing="gvVehicleDetails_RowEditing">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Cause Of Loss">
                                                                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                <ItemTemplate>
                                                                                    <%#Eval("Cause_Of_Loss")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Cause Of Loss" ItemStyle-CssClass="DisplayNone" HeaderStyle-CssClass="DisplayNone">
                                                                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblIncident_Type" Text='<%#Eval("Incident_Type")%>' runat="server"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="VIN">
                                                                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                <ItemTemplate>
                                                                                    <%--<asp:LinkButton runat="server" ID="lnkEdit" CommandName="Edit" Text='<%#Eval("VIN")%>'></asp:LinkButton>--%>
                                                                                    <%#Eval("VIN")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Vehicle Make">
                                                                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                <ItemTemplate>
                                                                                    <%#Eval("Make") %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Model">
                                                                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                <ItemTemplate>
                                                                                    <%#Eval("Model") %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Year">
                                                                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                <ItemTemplate>
                                                                                    <%#Eval("Year") %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Invoice Value">
                                                                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                <ItemTemplate>
                                                                                    $
                                                                                                <%# clsGeneral.GetStringValue(Eval("Invoice_Value"))%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Remove">
                                                                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton runat="server" ID="lnkRemove" CommandName="Remove" Text="Remove"
                                                                                        OnClientClick="return confirm('Sure to delete?');"></asp:LinkButton>
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
                                                            <tr>
                                                                <td colspan="6">
                                                                    <asp:Button ID="btnEditVehicles" runat="server" Text="Add/Edit Cause Of Loss" OnClick="btnEditVehicles_Click" Visible="false" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6">
                                                                    <table cellpadding="3" cellspacing="1" border="0" style="width: 100%; display: none;" id="tdVehicleDetails" runat="server">
                                                                        <tr>
                                                                            <td colspan="6">
                                                                                <b><i>
                                                                                    <asp:Label ID="lblBase" runat="server" Text="Base Information"></asp:Label></i></b>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">VIN#&nbsp;<span id="Span12" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left" colspan="4">
                                                                                <asp:TextBox runat="server" ID="txt_VIN" Width="170px" MaxLength="30"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" style="width: 18%">Make&nbsp;<span id="Span13" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center" style="width: 4%">:
                                                                            </td>
                                                                            <td align="left" colspan="4">
                                                                                <asp:TextBox runat="server" ID="txt_Make" Width="170px" MaxLength="20"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">Model&nbsp;<span id="Span14" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left" colspan="4">
                                                                                <asp:TextBox runat="server" ID="txt_Model" Width="170px" MaxLength="20"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">Year&nbsp;<span id="Span15" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left" colspan="4">
                                                                                <asp:TextBox runat="server" ID="txt_Year" Width="170px" MaxLength="4" SkinID="txtYearWithRange"
                                                                                    onblur="javascript:return YearRange(this,'1920','2018');"></asp:TextBox>
                                                                                <asp:RegularExpressionValidator ID="revTheft_Year" runat="server" ControlToValidate="txt_Year"
                                                                                    Display="none" SetFocusOnError="false" ErrorMessage="Year is Invalid."
                                                                                    ValidationExpression="[\d]{4}" ValidationGroup="vsVehicleGroup" Enabled="false"></asp:RegularExpressionValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">Type of Vehicle&nbsp;<span id="Span16" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left" colspan="4">
                                                                                <asp:DropDownList runat="server" ID="ddl_TypeOfVehicle" SkinID="ddlSONIC">
                                                                                    <asp:ListItem Value="0" Text="-- Select --"></asp:ListItem>
                                                                                    <asp:ListItem Value="New Inventory" Text="New Inventory"></asp:ListItem>
                                                                                    <asp:ListItem Value="Used Inventory" Text="Used Inventory"></asp:ListItem>
                                                                                    <asp:ListItem Value="Demo" Text="Demo"></asp:ListItem>
                                                                                    <asp:ListItem Value="Shop Loaner" Text="Shop Loaner"></asp:ListItem>
                                                                                    <asp:ListItem Value="Daily Rental" Text="Daily Rental"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">Location of Vehicle&nbsp;<span id="Span17" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left" colspan="4">
                                                                                <asp:TextBox runat="server" ID="txt_Present_Location" Width="170px" MaxLength="50"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">Location Address&nbsp;<span id="Span18" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left" colspan="4">
                                                                                <asp:TextBox runat="server" ID="txt_Present_Address" Width="170px" MaxLength="50"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">Location State&nbsp;<span id="Span19" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left" colspan="4">
                                                                                <asp:DropDownList runat="server" ID="ddl_Present_State" SkinID="ddlSONIC">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">Location Zip&nbsp;<span id="Span20" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left" colspan="4">
                                                                                <asp:TextBox runat="server" ID="txt_Present_Zip" Width="170px" MaxLength="10"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">Invoice Value&nbsp;<span id="Span21" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left" colspan="4">$<asp:TextBox runat="server" ID="txt_Invoice_Value" Width="170px" MaxLength="10"
                                                                                onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);" onblur="javascript:CheckNumericVal(this);return ValueRange(this,'1000','1000000');"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" valign="top">In Detail, Explain What Happened&nbsp;<span id="Span22" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center" valign="top">:
                                                                            </td>
                                                                            <td align="left" colspan="4">
                                                                                <uc:ctrlMultiLineTextBox runat="server" ID="txt_Loss_Description" ControlType="TextBox"
                                                                                    IsRequired="false" RequiredFieldMessage="Please Enter In Detail, Explain What Happened." ValidationGroup="vsVehicleGroup"
                                                                                    SetFocusOnError="true" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="6">
                                                                                <b>
                                                                                    <asp:Label ID="lblName5" runat="server"></asp:Label>
                                                                                </b>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trSecurityVideo" style="display: none" runat="server">
                                                                            <td>
                                                                                Is There a Security Video Surveillance System?<span id="Span204" style="color: Red;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center" valign="top">
                                                                                :
                                                                            </td>
                                                                            <td align="left" colspan="4">
                                                                                <asp:RadioButtonList runat="server" ID="rdoTheft_Security_Video_Surveillance" SkinID="YesNoTypeNullSelection"
                                                                                    onClick="checkTheftVehicleRecorved();TheftCheck(true);">
                                                                                </asp:RadioButtonList>
                                                                                <asp:RequiredFieldValidator ID="rfvTheft_Security_Video_Surveillance" InitialValue="" ControlToValidate="rdoTheft_Security_Video_Surveillance"
                                                                                    runat="server" ValidationGroup="vsVehicleGroup" ErrorMessage="Please answer Is There a Security Video Surveillance System?"
                                                                                    SetFocusOnError="true" Display="None" Enabled="false">
                                                                                </asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="6">
                                                                                <b>
                                                                                    <asp:Label ID="lblName2" runat="server"></asp:Label>
                                                                                </b>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trVehicleRecovered" style="display: none" runat="server">
                                                                            <td align="left">Was the Vehicle Recovered?
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left" colspan="4">
                                                                                <asp:RadioButtonList runat="server" ID="rdo_Vehicle_Recovered" SkinID="YesNoTypeNullSelection"
                                                                                    onClick="checkTheftVehicleRecorved();TheftCheck(true);">
                                                                                </asp:RadioButtonList>
                                                                                <asp:RequiredFieldValidator ID="rfv_Vehicle_Recovered" InitialValue="" ControlToValidate="rdo_Vehicle_Recovered"
                                                                                    runat="server" ValidationGroup="vsVehicleGroup" ErrorMessage="Please answer was the Vehicle Recovered?"
                                                                                    SetFocusOnError="true" Display="None" Enabled="true">
                                                                                </asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="6" align="left" runat="server" id="td_VehicleRecovred" style="display: none">
                                                                                <table cellpadding="3" cellspacing="1" border="0">
                                                                                    <tr>
                                                                                        <td align="left">If Yes, damage amount&nbsp;<span id="Span122" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td align="left">$<asp:TextBox runat="server" ID="txt_Damage_estimate" Width="170px" MaxLength="10" onchange="TheftCheck(true);"
                                                                                            onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);" onblur="CheckNumericVal(this);"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="rfvTheft_Damage_estimate" InitialValue="" ControlToValidate="txtTheft_Damage_estimate"
                                                                                                runat="server" ValidationGroup="vsTheftGroup" ErrorMessage="Please Enter Damage Amount."
                                                                                                SetFocusOnError="true" Display="None" Enabled="false">
                                                                                            </asp:RequiredFieldValidator>--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">If Yes, does the dealership wish to take possession?
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:RadioButtonList runat="server" ID="rdo_Dealership_Wish_To_Take_Possession"
                                                                                                SkinID="YesNoTypeNullSelection" onclick="TheftCheck(true);">
                                                                                            </asp:RadioButtonList>
                                                                                            <asp:RequiredFieldValidator ID="rfv_Dealership_Wish_To_Take_Possession" InitialValue=""
                                                                                                ControlToValidate="rdo_Dealership_Wish_To_Take_Possession" runat="server"
                                                                                                ValidationGroup="vsVehicleGroup" ErrorMessage="Please answer does the dealership wish to take possession?"
                                                                                                SetFocusOnError="true" Display="None" Enabled="false">
                                                                                            </asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trVehicleInStorage" style="display: none" runat="server">

                                                                            <td align="left" style="width: 18%">Is the Vehicle in storage?
                                                                            </td>
                                                                            <td align="center" style="width: 4%">:
                                                                            </td>
                                                                            <td align="left" colspan="4">
                                                                                <asp:RadioButtonList runat="server" ID="rdoVehicle_In_Storage" SkinID="YesNoTypeNullSelection"
                                                                                    onClick="checkTheftVehicleInStorage();TheftCheck(true);">
                                                                                </asp:RadioButtonList>
                                                                                <asp:RequiredFieldValidator ID="rfvVehicle_In_Storage" InitialValue="" ControlToValidate="rdoVehicle_In_Storage"
                                                                                    runat="server" ValidationGroup="vsVehicleGroup" ErrorMessage="Please answer Is the Vehicle in storage?"
                                                                                    SetFocusOnError="true" Display="None" Enabled="true">
                                                                                </asp:RequiredFieldValidator>
                                                                            </td>

                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="6" align="left">
                                                                                <table cellpadding="7" cellspacing="1" border="0" width="100%" runat="server" id="tdVehicle_In_Storage" style="display: none">
                                                                                    <tr>
                                                                                        <td align="left" style="width: 22%">Address 1&nbsp;<span id="Span123" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" style="width: 4%">:
                                                                                        </td>
                                                                                        <td align="left" style="width: 24%">
                                                                                            <asp:TextBox runat="server" ID="txt_Storage_Address_1" Width="170px" MaxLength="50" onchange="TheftCheck(true);"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="rfvTheft_Storage_Address_1" InitialValue="" ControlToValidate="txtTheft_Storage_Address_1"
                                                                                                runat="server" ValidationGroup="vsTheftGroup" ErrorMessage="Please Enter Address 1 in storage section."
                                                                                                SetFocusOnError="true" Display="None" Enabled="false">
                                                                                            </asp:RequiredFieldValidator>--%>
                                                                                        </td>
                                                                                        <td align="left" style="width: 22%">Contact Name&nbsp;<span id="Span124" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" style="width: 4%">:
                                                                                        </td>
                                                                                        <td align="left" style="width: 24%">
                                                                                            <asp:TextBox runat="server" ID="txt_Storage_Contact" Width="170px" MaxLength="50" onchange="TheftCheck(true);"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="rfvTheft_Storage_Contact" InitialValue="" ControlToValidate="txtTheft_Storage_Contact"
                                                                                                runat="server" ValidationGroup="vsTheftGroup" ErrorMessage="Please Enter Contact Name in storage section."
                                                                                                SetFocusOnError="true" Display="None" Enabled="false">
                                                                                            </asp:RequiredFieldValidator>--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">Address 2&nbsp;<span id="Span125" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:TextBox runat="server" ID="txt_Storage_Address_2" Width="170px" MaxLength="50" onchange="TheftCheck(true);"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="rfvTheft_Storage_Address_2" InitialValue="" ControlToValidate="txtTheft_Storage_Address_2"
                                                                                                runat="server" ValidationGroup="vsTheftGroup" ErrorMessage="Please Enter Address 2 in storage section."
                                                                                                SetFocusOnError="true" Display="None" Enabled="false">
                                                                                            </asp:RequiredFieldValidator>--%>
                                                                                        </td>
                                                                                        <td align="left">Storage Phone&nbsp;<span id="Span126" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:TextBox runat="server" ID="txt_Storage_phone" Width="170px" MaxLength="20" onchange="TheftCheck(true);"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="rfvTheft_Storage_phone" InitialValue="" ControlToValidate="txtTheft_Storage_phone"
                                                                                                runat="server" ValidationGroup="vsTheftGroup" ErrorMessage="Please Enter Phone in storage section."
                                                                                                SetFocusOnError="true" Display="None" Enabled="false">
                                                                                            </asp:RequiredFieldValidator>--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">City&nbsp;<span id="Span127" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:TextBox runat="server" ID="txt_Storage_City" Width="170px" MaxLength="50" onchange="TheftCheck(true);"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="rfvTheft_Storage_City" InitialValue="" ControlToValidate="txtTheft_Storage_City"
                                                                                                runat="server" ValidationGroup="vsTheftGroup" ErrorMessage="Please Enter City in storage section."
                                                                                                SetFocusOnError="true" Display="None" Enabled="false">
                                                                                            </asp:RequiredFieldValidator>--%>
                                                                                        </td>
                                                                                        <td align="left">Cost of Storage&nbsp;<span id="Span128" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:TextBox runat="server" ID="txt_Storage_cost" Width="170px" onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"
                                                                                                onblur="CheckNumericVal(this);" onchange="TheftCheck(true);"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="rfvTheft_Storage_cost" InitialValue="" ControlToValidate="txtTheft_Storage_cost"
                                                                                                runat="server" ValidationGroup="vsTheftGroup" ErrorMessage="Please Enter Cost of Strorate in storage section."
                                                                                                SetFocusOnError="true" Display="None" Enabled="false">
                                                                                            </asp:RequiredFieldValidator>--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">Storage State&nbsp;<span id="Span129" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:DropDownList runat="server" ID="ddl_Storage_State" SkinID="ddlSONIC" onchange="TheftCheck(true);">
                                                                                            </asp:DropDownList>
                                                                                            <%--<asp:RequiredFieldValidator ID="rfvTheft_Storage_State" InitialValue="0" ControlToValidate="ddlTheft_Storage_State"
                                                                                                runat="server" ValidationGroup="vsTheftGroup" ErrorMessage="Please select state in storage section."
                                                                                                SetFocusOnError="true" Display="None" Enabled="false">
                                                                                            </asp:RequiredFieldValidator>--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">Storage Zip&nbsp;<span id="Span130" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:TextBox runat="server" ID="txt_storage_Zip_Code" Width="170px" MaxLength="10" onchange="TheftCheck(true);"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="rfvTheft_storage_Zip_Code" InitialValue="" ControlToValidate="txtTheft_storage_Zip_Code"
                                                                                                runat="server" ValidationGroup="vsTheftGroup" ErrorMessage="Please Enter zip code in storage section."
                                                                                                SetFocusOnError="true" Display="None" Enabled="false">
                                                                                            </asp:RequiredFieldValidator>--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="6">
                                                                                <b>
                                                                                    <asp:Label ID="lblName4" runat="server"></asp:Label>
                                                                                </b>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trWerePolicyNotified" style="display: none" runat="server">
                                                                            <td align="left">Were Police Notified?
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left" colspan="4">
                                                                                <asp:RadioButtonList runat="server" ID="rdoPoliceNotified" SkinID="YesNoTypeNullSelection"
                                                                                    onClick="checkPoliceNotified();TheftCheck(true);">
                                                                                </asp:RadioButtonList>
                                                                                <asp:RequiredFieldValidator ID="rfvPoliceNotified" InitialValue="" ControlToValidate="rdoPoliceNotified"
                                                                                    runat="server" ValidationGroup="vsVehicleGroup" ErrorMessage="Please answer Were Police Notified?"
                                                                                    SetFocusOnError="true" Display="None" Enabled="true">
                                                                                </asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="6">
                                                                                <table id="trPoliceNotified" style="display: none;" runat="server" width="100%">
                                                                                    <tr>
                                                                                        <td align="left" width="18%">Police Report Number&nbsp;<span id="Span140" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" width="2%">:
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:TextBox runat="Server" ID="txtFraudReportNumber" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="rfvFraudReportNumber" InitialValue="" ControlToValidate="txtFraudReportNumber"
                                                                                    runat="server" ValidationGroup="vsFraudGroup" ErrorMessage="Please Enter Report Number."
                                                                                    SetFocusOnError="true" Display="None" Enabled="false">
                                                                                </asp:RequiredFieldValidator>--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="6">
                                                                                <b>
                                                                                    <asp:Label ID="lblName1" runat="server"></asp:Label>
                                                                                </b>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trVehicleOwner1" style="display: none" runat="server">
                                                                            <td align="left">Vehicle Owner if not SONIC&nbsp;<span id="Span169" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left" colspan="4">
                                                                                <asp:TextBox runat="server" ID="txtMVA_MultiVehicle_Owner_Sonic" Width="170px" MaxLength="20" onchange="TheftCheck(true);"></asp:TextBox>
                                                                                <%--<asp:RequiredFieldValidator ID="rfvMVA_MultiVehicle_Owner_Sonic" InitialValue=""
                                                                                    ControlToValidate="txtMVA_MultiVehicle_Owner_Sonic" runat="server" ValidationGroup="vsMVAMultiGroup"
                                                                                    ErrorMessage="Please Enter Vehicle Owner Name." SetFocusOnError="true" Display="None"
                                                                                    Enabled="true">
                                                                                </asp:RequiredFieldValidator>--%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trVehicleOwner2" style="display: none" runat="server">
                                                                            <td align="left">Vehicle Owner Address&nbsp;<span id="Span170" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left" colspan="4">
                                                                                <asp:TextBox runat="server" ID="txtMVA_MultiVehicle_Owner_Address" Width="170px" onchange="TheftCheck(true);"
                                                                                    MaxLength="50"></asp:TextBox>
                                                                                <%--<asp:RequiredFieldValidator ID="rfvMVA_MultiVehicle_Owner_Address" InitialValue=""
                                                                                    ControlToValidate="txtMVA_MultiVehicle_Owner_Address" runat="server" ValidationGroup="vsMVAMultiGroup"
                                                                                    ErrorMessage="Please Enter Vehicle Owner Address." SetFocusOnError="true" Display="None"
                                                                                    Enabled="true">
                                                                                </asp:RequiredFieldValidator>--%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trVehicleOwner3" style="display: none" runat="server">
                                                                            <td align="left">Vehicle Owner Phone&nbsp;<span id="Span171" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left" colspan="4">
                                                                                <asp:TextBox runat="server" ID="txtMVA_MultiVehicle_Owner_Phone" Width="170px" MaxLength="20" onchange="TheftCheck(true);"></asp:TextBox>
                                                                                <%--<asp:RequiredFieldValidator ID="rfvMVA_MultiVehicle_Owner_Phone" InitialValue=""
                                                                                    ControlToValidate="txtMVA_MultiVehicle_Owner_Phone" runat="server" ValidationGroup="vsMVAMultiGroup"
                                                                                    ErrorMessage="Please Enter Vehicle Owner Phone." SetFocusOnError="true" Display="None"
                                                                                    Enabled="true">
                                                                                </asp:RequiredFieldValidator>--%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="6">
                                                                                <b>
                                                                                    <asp:Label ID="lblName3" runat="server"></asp:Label>
                                                                                </b>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trDamageEstimate" style="display: none" runat="server">
                                                                            <td align="left" style="width: 18%">Damage Estimate&nbsp;<span id="Span172" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center" style="width: 4%">:
                                                                            </td>
                                                                            <td align="left" colspan="4">$<asp:TextBox runat="server" ID="txtMVA_MultiDamage_Estimate" Width="170px" MaxLength="10" onchange="TheftCheck(true);"
                                                                                onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);" onblur="CheckNumericVal(this);"></asp:TextBox>
                                                                                <%--<asp:RequiredFieldValidator ID="rfvMVA_MultiDamage_Estimate" InitialValue="" ControlToValidate="txtMVA_MultiDamage_Estimate"
                                                                                    runat="server" ValidationGroup="vsMVAMultiGroup" ErrorMessage="Please Enter Damage Amount."
                                                                                    SetFocusOnError="true" Display="None" Enabled="true">
                                                                                </asp:RequiredFieldValidator>--%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trVehicleDrivenByCompanyAssoc" style="display: none" runat="server">
                                                                            <td align="left" style="width: 18%">Was vehicle being driven by company associate?
                                                                            </td>
                                                                            <td align="center" style="width: 4%">:
                                                                            </td>
                                                                            <td align="left" colspan="4">
                                                                                <asp:RadioButtonList runat="server" ID="rdoMVA_MultiDriven_By_Associate" SkinID="YesNoTypeNullSelection"
                                                                                    onClick="CheckMVAMultiDrivenByCA(); TheftCheck(true);">
                                                                                </asp:RadioButtonList>
                                                                                <asp:RequiredFieldValidator ID="rfvMVA_MultiDriven_By_Associate" InitialValue=""
                                                                                    ControlToValidate="rdoMVA_MultiDriven_By_Associate" runat="server" ValidationGroup="vsVehicleGroup"
                                                                                    ErrorMessage="Please answer Was vehicle being driven by company associate?" SetFocusOnError="true"
                                                                                    Display="None" Enabled="true">
                                                                                </asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trMVAMulti_DrivenByCA_Yes" style="display: none" runat="Server">
                                                                            <td colspan="6" align="left">
                                                                                <table cellpadding="3" cellspacing="0" border="0" width="100%">
                                                                                    <tr>
                                                                                        <td align="left" style="width: 18%; padding-left: 30px;">If Yes, Name&nbsp;<span id="Span173" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" style="width: 4%">:
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:TextBox runat="server" ID="txtMVA_MultiName_Yes" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="rfvMVA_MultiName_Yes" InitialValue="" ControlToValidate="txtMVA_MultiName_Yes"
                                                                                                runat="server" ValidationGroup="vsMVAMultiGroup" ErrorMessage="Please Enter Name."
                                                                                                SetFocusOnError="true" Display="None" Enabled="false">
                                                                                            </asp:RequiredFieldValidator>--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" style="width: 18%; padding-left: 30px;">If Yes, Address&nbsp;<span id="Span174" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" style="width: 4%">:
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:TextBox runat="server" ID="txtMVA_MultiAddress_Yes" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="rfvMVA_MultiAddress_Yes" InitialValue="" ControlToValidate="txtMVA_MultiAddress_Yes"
                                                                                                runat="server" ValidationGroup="vsMVAMultiGroup" ErrorMessage="Please Enter Address"
                                                                                                SetFocusOnError="true" Display="None" Enabled="false">
                                                                                            </asp:RequiredFieldValidator>--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" style="width: 18%; padding-left: 30px;">If Yes, Phone&nbsp;<span id="Span175" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" style="width: 4%">:
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:TextBox runat="server" ID="txtMVA_MultiPhone_Yes" Width="170px" MaxLength="20"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="rfvMVA_MultiPhone_Yes" InitialValue="" ControlToValidate="txtMVA_MultiPhone_Yes"
                                                                                                runat="server" ValidationGroup="vsMVAMultiGroup" ErrorMessage="Please Enter Phone"
                                                                                                SetFocusOnError="true" Display="None" Enabled="false">
                                                                                            </asp:RequiredFieldValidator>--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" style="width: 18%; padding-left: 30px;">If Yes, was associate cited for a violation?
                                                                                        </td>
                                                                                        <td align="center" style="width: 4%">:
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:RadioButtonList runat="server" ID="rdoMVA_MultiAssociate_Cited" SkinID="YesNoTypeNullSelection">
                                                                                            </asp:RadioButtonList>
                                                                                            <asp:RequiredFieldValidator ID="rfvMVA_MultiAssociate_Cited" InitialValue="" ControlToValidate="rdoMVA_MultiAssociate_Cited"
                                                                                                runat="server" ValidationGroup="vsVehicleGroup" ErrorMessage="Please answer was associate cited for a violation?"
                                                                                                SetFocusOnError="true" Display="None" Enabled="false">
                                                                                            </asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr id="trMVA_MultiCitation_Yes" runat="server" style="display: none;">
                                                                                        <td align="left" valign="top" style="padding-left: 45px;">If Yes, Description of citation&nbsp;<span id="Span176" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <uc:ctrlMultiLineTextBox runat="server" ID="txtMVA_MultiDescription_Of_Citation"
                                                                                                ControlType="textbox" IsRequired="false" ValidationGroup="vsVehicleGroup" RequiredFieldMessage="Please Enter Description of citation" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top" style="padding-left: 30px;">If Yes, was the associate injured?
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:RadioButtonList runat="server" ID="rdoMVA_MultiAssociate_injured" SkinID="YesNoTypeNullSelection">
                                                                                            </asp:RadioButtonList>
                                                                                            <asp:RequiredFieldValidator ID="rfvMVA_MultiAssociate_injured" InitialValue="" ControlToValidate="rdoMVA_MultiAssociate_injured"
                                                                                                runat="server" ValidationGroup="vsVehicleGroup" ErrorMessage="Please answer was the associcate injured?"
                                                                                                SetFocusOnError="true" Display="None" Enabled="false">
                                                                                            </asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top" style="padding-left: 30px;">If Yes, was a post-accident drug test performed?
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:RadioButtonList runat="server" ID="rdoMVA_MultiDrug_test_performed" SkinID="YesNoTypeNullSelection">
                                                                                            </asp:RadioButtonList>
                                                                                            <asp:RequiredFieldValidator ID="rfvMVA_MultiDrug_test_performed" InitialValue=""
                                                                                                ControlToValidate="rdoMVA_MultiDrug_test_performed" runat="server" ValidationGroup="vsVehicleGroup"
                                                                                                ErrorMessage="Please answer was a post-accident drug test performed?" SetFocusOnError="true"
                                                                                                Display="None" Enabled="false">
                                                                                            </asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr runat="server" id="trMVA_MultiDrugYes" style="display: none;">
                                                                                        <td align="left" valign="top" style="padding-left: 30px;">If Yes, Results&nbsp;<span id="Span177" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <uc:ctrlMultiLineTextBox runat="server" ID="txtMVA_MultiDrug_test_results" ControlType="textbox"
                                                                                                IsRequired="false" ValidationGroup="vsVehicleGroup" RequiredFieldMessage="Please Enter Drug Test Results." />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr runat="server" id="trMVA_MultiDrugNo" style="display: none;">
                                                                                        <td align="left" valign="top" style="padding-left: 30px;">If No, Explain&nbsp;<span id="Span178" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <uc:ctrlMultiLineTextBox runat="server" ID="txtMVA_MultiDrug_test_explanation" ControlType="textbox"
                                                                                                IsRequired="false" ValidationGroup="vsVehicleGroup" RequiredFieldMessage="Please Enter Drug Test Explaination." />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trMVAMulti_DrivenByCA_No" style="display: none" runat="Server">
                                                                            <td colspan="6" align="left">
                                                                                <table cellpadding="3" cellspacing="0" border="0" width="100%">
                                                                                    <tr>
                                                                                        <td align="left" style="width: 18%; padding-left: 30px;">If No, was vehicle being driven by customer?
                                                                                        </td>
                                                                                        <td align="center" style="width: 4%">:
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:RadioButtonList runat="server" ID="rdoMVA_MultiVehicle_Driven_By_Customer" SkinID="YesNoTypeNullSelection">
                                                                                            </asp:RadioButtonList>
                                                                                            <asp:RequiredFieldValidator ID="rfvMVA_MultiVehicle_Driven_By_Customer" InitialValue=""
                                                                                                ControlToValidate="rdoMVA_MultiVehicle_Driven_By_Customer" runat="server" ValidationGroup="vsVehicleGroup"
                                                                                                ErrorMessage="Please answer was vehicle being driven by customer?" SetFocusOnError="true"
                                                                                                Display="None" Enabled="false">
                                                                                            </asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr runat="server" id="trMVA_MultiCust_Injured" style="display: none;">
                                                                                        <td align="left" valign="top" style="padding-left: 45px;" colspan="6">
                                                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                                <tr>
                                                                                                    <td align="left" style="width: 18%;">If Yes, Name&nbsp;<span id="Span179" style="color: Red; display: none;" runat="server">*</span>
                                                                                                    </td>
                                                                                                    <td align="center" style="width: 4%">:
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <asp:TextBox runat="server" ID="txtMVA_MultiName_No" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                                        <%--<asp:RequiredFieldValidator ID="rfvMVA_MultiName_No" InitialValue="" ControlToValidate="txtMVA_MultiName_No"
                                                                                                            runat="server" ValidationGroup="vsMVAMultiGroup" ErrorMessage="Please Enter Name."
                                                                                                            SetFocusOnError="true" Display="None" Enabled="false">
                                                                                                        </asp:RequiredFieldValidator>--%>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">If Yes, Address&nbsp;<span id="Span180" style="color: Red; display: none;" runat="server">*</span>
                                                                                                    </td>
                                                                                                    <td align="center">:
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <asp:TextBox runat="server" ID="txtMVA_MultiAddress_No" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                                        <%--<asp:RequiredFieldValidator ID="rfvMVA_MultiAddress_No" InitialValue="" ControlToValidate="txtMVA_MultiAddress_No"
                                                                                                            runat="server" ValidationGroup="vsMVAMultiGroup" ErrorMessage="Please Enter Address"
                                                                                                            SetFocusOnError="true" Display="None" Enabled="false">
                                                                                                        </asp:RequiredFieldValidator>--%>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">If Yes, Phone&nbsp;<span id="Span181" style="color: Red; display: none;" runat="server">*</span>
                                                                                                    </td>
                                                                                                    <td align="center">:
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <asp:TextBox runat="server" ID="txtMVA_MultiPhone_No" Width="170px" MaxLength="20"></asp:TextBox>
                                                                                                        <%--<asp:RequiredFieldValidator ID="rfvMVA_MultiPhone_No" InitialValue="" ControlToValidate="txtMVA_MultiPhone_No"
                                                                                                            runat="server" ValidationGroup="vsMVAMultiGroup" ErrorMessage="Please Enter Phone"
                                                                                                            SetFocusOnError="true" Display="None" Enabled="false">
                                                                                                        </asp:RequiredFieldValidator>--%>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left" valign="top">If Yes, was the customer injured?
                                                                                                    </td>
                                                                                                    <td align="center" valign="top">:
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <asp:RadioButtonList runat="server" ID="rdoMVA_Multicustomer_injured" SkinID="YesNoTypeNullSelection">
                                                                                                        </asp:RadioButtonList>
                                                                                                        <asp:RequiredFieldValidator ID="rfvMVA_Multicustomer_injured" InitialValue="" ControlToValidate="rdoMVA_Multicustomer_injured"
                                                                                                            runat="server" ValidationGroup="vsVehicleGroup" ErrorMessage="Please answer was the customer injured?"
                                                                                                            SetFocusOnError="true" Display="None" Enabled="false">
                                                                                                        </asp:RequiredFieldValidator>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr id="trMVA_MultiCust_Not_Injured" runat="server" style="display: none">
                                                                                        <td align="left" valign="top" style="padding-left: 45px;">If No, Explain&nbsp;<span id="Span182" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <uc:ctrlMultiLineTextBox runat="Server" ID="txtMVA_MultiNot_Driven_By_Customer_Explain"
                                                                                                ControlType="TextBox" IsRequired="false" ValidationGroup="vsMVAMultiGroup" RequiredFieldMessage="Please Enter Explaination."
                                                                                                SetFocusOnError="true" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trOtherPassengers" style="display: none" runat="server">
                                                                            <td align="left" style="width: 18%">Were other passengers in the vehicle besides the Associate and the Customer?
                                                                            </td>
                                                                            <td align="center" style="width: 4%">:
                                                                            </td>
                                                                            <td align="left" colspan="4">
                                                                                <asp:RadioButtonList runat="server" ID="rdoMVA_MultiAdditional_passengers" SkinID="YesNoTypeNullSelection"
                                                                                    onClick="CheckMultiAdditional_passengers();TheftCheck(true);">
                                                                                </asp:RadioButtonList>
                                                                                <asp:RequiredFieldValidator ID="rfvMVA_MultiAdditional_passengers" InitialValue=""
                                                                                    ControlToValidate="rdoMVA_MultiAdditional_passengers" runat="server" ValidationGroup="vsVehicleGroup"
                                                                                    ErrorMessage="Please answer Were other passengers in the vehicle besides the Associate and the Customer?"
                                                                                    SetFocusOnError="true" Display="None" Enabled="true">
                                                                                </asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr runat="server" id="trMVA_MultiAdditional_passengers_Yes" style="display: none;">
                                                                            <td colspan="6" align="left" style="padding-left: 30px;">
                                                                                <%--<asp:UpdatePanel runat="server" ID="pnlMVA_MultiAdditionalPass" UpdateMode="Conditional">
                                                                                    <ContentTemplate>--%>
                                                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                    <tr>
                                                                                        <td colspan="6">
                                                                                            <asp:GridView ID="gvMVAMulti_Passenger" runat="server" DataKeyNames="PK_DPD_FR_Injured_Passenger_id"
                                                                                                AutoGenerateColumns="false" Width="100%" AllowSorting="false" OnRowDataBound="gvMVAMulti_Passenger_RowDataBound"
                                                                                                OnRowCreated="gvMVAMulti_Passenger_RowCreated" OnRowCommand="gvMVAMulti_Passenger_RowCommand"
                                                                                                OnRowEditing="gvMVAMulti_Passenger_RowEditing">
                                                                                                <Columns>
                                                                                                    <asp:TemplateField HeaderText="Name">
                                                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                                        <ItemTemplate>
                                                                                                            <asp:LinkButton runat="server" ID="lnkEdit" CommandName="Edit" Text='<%#Eval("name")%>'></asp:LinkButton>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Address 1">
                                                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                                        <ItemTemplate>
                                                                                                            <%#Eval("Address_1")%>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="City">
                                                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                                        <ItemTemplate>
                                                                                                            <%#Eval("City")%>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="State">
                                                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                                        <ItemTemplate>
                                                                                                            <%# new ERIMS.DAL.State(!string.IsNullOrEmpty(Convert.ToString(Eval("State"))) ? Convert.ToDecimal(Eval("State")) : 0).FLD_state%>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Zip">
                                                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                                        <ItemTemplate>
                                                                                                            <%#Eval("Zip_Code")%>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Remove">
                                                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                                        <ItemTemplate>
                                                                                                            <asp:LinkButton runat="server" ID="lnkRemove" CommandName="Remove" Text="Remove"
                                                                                                                OnClientClick="return confirm('Sure to delete?');"></asp:LinkButton>
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
                                                                                    <tr>
                                                                                        <td style="width: 18%" align="left">Contact Name&nbsp;<span id="Span183" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td style="width: 4%" align="center">:
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:TextBox runat="server" ID="txtMVA_MultiPass_Name" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="rfvMVA_MultiPass_Name" InitialValue="" ControlToValidate="txtMVA_MultiPass_Name"
                                                                                                        runat="server" ValidationGroup="vsMultiPassGroup" ErrorMessage="Please Enter Contact Name."
                                                                                                        SetFocusOnError="true" Display="None" Enabled="true">
                                                                                                    </asp:RequiredFieldValidator>--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">Address 1&nbsp;<span id="Span184" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:TextBox runat="server" ID="txtMVA_MultiPass_Address_1" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="rfvMVA_MultiPass_Address_1" InitialValue="" ControlToValidate="txtMVA_MultiPass_Address_1"
                                                                                                        runat="server" ValidationGroup="vsMultiPassGroup" ErrorMessage="Please Enter Address 1."
                                                                                                        SetFocusOnError="true" Display="None" Enabled="true">
                                                                                                    </asp:RequiredFieldValidator>--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">Address 2&nbsp;<span id="Span185" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:TextBox runat="server" ID="txtMVA_MultiPass_Address_2" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="rfvMVA_MultiPass_Address_2" InitialValue="" ControlToValidate="txtMVA_MultiPass_Address_2"
                                                                                                        runat="server" ValidationGroup="vsMultiPassGroup" ErrorMessage="Please Enter Address 2."
                                                                                                        SetFocusOnError="true" Display="None" Enabled="true">
                                                                                                    </asp:RequiredFieldValidator>--%>
                                                                                        </td>
                                                                                        <td align="left">Phone&nbsp;<span id="Span186" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:TextBox runat="server" ID="txtMVA_MultiPass_Phone" Width="170px" MaxLength="20"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="rfvMVA_MultiPass_Phone" InitialValue="" ControlToValidate="txtMVA_MultiPass_Phone"
                                                                                                        runat="server" ValidationGroup="vsMultiPassGroup" ErrorMessage="Please Enter Phone."
                                                                                                        SetFocusOnError="true" Display="None" Enabled="true">
                                                                                                    </asp:RequiredFieldValidator>--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">City&nbsp;<span id="Span187" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:TextBox runat="server" ID="txtMVA_MultiPass_City" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="rfvMVA_MultiPass_City" InitialValue="" ControlToValidate="txtMVA_MultiPass_City"
                                                                                                        runat="server" ValidationGroup="vsMultiPassGroup" ErrorMessage="Please Enter City."
                                                                                                        SetFocusOnError="true" Display="None" Enabled="true">
                                                                                                    </asp:RequiredFieldValidator>--%>
                                                                                        </td>
                                                                                        <td align="left">Injured?
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:RadioButtonList runat="server" ID="rdoMVA_MultiPass_Injured" SkinID="YesNoTypeNullSelection">
                                                                                            </asp:RadioButtonList>
                                                                                            <asp:RequiredFieldValidator ID="rfvMVA_MultiPass_Injured" InitialValue="" ControlToValidate="rdoMVA_MultiPass_Injured"
                                                                                                runat="server" ValidationGroup="vsMultiPassGroup" ErrorMessage="Please answer Injured?"
                                                                                                SetFocusOnError="true" Display="None" Enabled="true">
                                                                                            </asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">State&nbsp;<span id="Span188" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:DropDownList runat="server" ID="ddlMVA_MultiPass_State" SkinID="ddlSONIC">
                                                                                            </asp:DropDownList>
                                                                                            <%--<asp:RequiredFieldValidator ID="rfvMVA_MultiPass_State" InitialValue="0" ControlToValidate="ddlMVA_MultiPass_State"
                                                                                                        runat="server" ValidationGroup="vsMultiPassGroup" ErrorMessage="Please select State."
                                                                                                        SetFocusOnError="true" Display="None" Enabled="true">
                                                                                                    </asp:RequiredFieldValidator>--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">Zip&nbsp;<span id="Span189" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:TextBox runat="server" ID="txtMVA_MultiPass_Zip" Width="170px" MaxLength="10"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="rfvMVA_MultiPass_Zip" InitialValue="" ControlToValidate="txtMVA_MultiPass_Zip"
                                                                                                        runat="server" ValidationGroup="vsMultiPassGroup" ErrorMessage="Please Enter Zip Code."
                                                                                                        SetFocusOnError="true" Display="None" Enabled="true">
                                                                                                    </asp:RequiredFieldValidator>--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="6" align="left">
                                                                                            <asp:Button runat="server" ID="btnMVA_Multi_Passenger" Text="Add" OnClick="btnMVAMulti_Passenger_Click"
                                                                                                CausesValidation="true" ValidationGroup="vsMultiPassGroup" />
                                                                                            <asp:CustomValidator ID="CustomValidator14" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
                                                                                                Display="None" ValidationGroup="vsMultiPassGroup" />
                                                                                            <input id="hdnControlIDs14" runat="server" type="hidden" />
                                                                                            <input id="hdnErrorMsgs14" runat="server" type="hidden" />
                                                                                            <asp:Button runat="server" ID="btnViewAudit_MVA_Multi_Passenger" Text="View Audit Trail"
                                                                                                CausesValidation="false" Visible="false" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <%--</ContentTemplate>
                                                                                    <Triggers>
                                                                                        <asp:AsyncPostBackTrigger ControlID="btnMVA_Multi_Passenger" EventName="Click" />
                                                                                    </Triggers>
                                                                                </asp:UpdatePanel>--%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trDealership" style="display: none" runat="server">
                                                                            <td align="left">Is the dealership seeking subrogation from a third party?
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left" colspan="4">
                                                                                <asp:RadioButtonList runat="server" ID="rdoMVA_MultiSeeking_subrogation" SkinID="YesNoTypeNullSelection"
                                                                                    onClick="CheckMultiSeeking_subrogation();TheftCheck(true);">
                                                                                </asp:RadioButtonList>
                                                                                <asp:RequiredFieldValidator ID="rfvMVA_MultiSeeking_subrogation" InitialValue=""
                                                                                    ControlToValidate="rdoMVA_MultiSeeking_subrogation" runat="server" ValidationGroup="vsVehicleGroup"
                                                                                    ErrorMessage="Please answer Is the dealership seeking subrogation from a third party?"
                                                                                    SetFocusOnError="true" Display="None" Enabled="true">
                                                                                </asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr runat="Server" id="trMVA_MultiSeeking_subrogation_Yes" style="display: none;">
                                                                            <td colspan="6" style="padding-left: 30px;">
                                                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                    <tr align="left">
                                                                                        <td colspan="6">If Yes, provide Third Party Insurer Information
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" style="width: 18%;">Carrier Name&nbsp;<span id="Span190" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" style="width: 4%;">:
                                                                                        </td>
                                                                                        <td align="left" style="width: 28%;">
                                                                                            <asp:TextBox runat="server" ID="txtMVA_MultiTPI_Carrier_name" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="rfvMVA_MultiTPI_Carrier_name" InitialValue="" ControlToValidate="txtMVA_MultiTPI_Carrier_name"
                                                                                                runat="server" ValidationGroup="vsMVAMultiGroup" ErrorMessage="Please Enter Carrier Name"
                                                                                                SetFocusOnError="true" Display="None" Enabled="false">
                                                                                            </asp:RequiredFieldValidator>--%>
                                                                                        </td>
                                                                                        <td align="left" style="width: 18%;">Contact Name&nbsp;<span id="Span191" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center" style="width: 4%;">:
                                                                                        </td>
                                                                                        <td align="left" style="width: 28%;">
                                                                                            <asp:TextBox runat="server" ID="txtMVA_Multitpi_contact" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="rfvMVA_Multitpi_contact" InitialValue="" ControlToValidate="txtMVA_Multitpi_contact"
                                                                                                runat="server" ValidationGroup="vsMVAMultiGroup" ErrorMessage="Please Enter Contact Name"
                                                                                                SetFocusOnError="true" Display="None" Enabled="false">
                                                                                            </asp:RequiredFieldValidator>--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">Policy Number&nbsp;<span id="Span192" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:TextBox runat="server" ID="txtMVA_MultiTPI_Policy_number" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="rfvMVA_MultiTPI_Policy_number" InitialValue="" ControlToValidate="txtMVA_MultiTPI_Policy_number"
                                                                                                runat="server" ValidationGroup="vsMVAMultiGroup" ErrorMessage="Please Enter Policy Number."
                                                                                                SetFocusOnError="true" Display="None" Enabled="false">
                                                                                            </asp:RequiredFieldValidator>--%>
                                                                                        </td>
                                                                                        <td align="left">Phone&nbsp;<span id="Span193" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:TextBox runat="server" ID="txtMVA_Multitpi_phone" Width="170px" MaxLength="20"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="rfvMVA_Multitpi_phone" InitialValue="" ControlToValidate="txtMVA_Multitpi_phone"
                                                                                                runat="server" ValidationGroup="vsMVAMultiGroup" ErrorMessage="Please Enter Phone."
                                                                                                SetFocusOnError="true" Display="None" Enabled="false">
                                                                                            </asp:RequiredFieldValidator>--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">Address 1&nbsp;<span id="Span194" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:TextBox runat="server" ID="txtMVA_Multitpi_address_1" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="rfvMVA_Multitpi_address_1" InitialValue="" ControlToValidate="txtMVA_Multitpi_address_1"
                                                                                                runat="server" ValidationGroup="vsMVAMultiGroup" ErrorMessage="Please Enter Address 1."
                                                                                                SetFocusOnError="true" Display="None" Enabled="false">
                                                                                            </asp:RequiredFieldValidator>--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">Address 2&nbsp;<span id="Span195" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:TextBox runat="server" ID="txtMVA_Multitpi_address_2" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="rfvMVA_Multitpi_address_2" InitialValue="" ControlToValidate="txtMVA_Multitpi_address_2"
                                                                                                runat="server" ValidationGroup="vsMVAMultiGroup" ErrorMessage="Please Enter Address 2."
                                                                                                SetFocusOnError="true" Display="None" Enabled="false">
                                                                                            </asp:RequiredFieldValidator>--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">City&nbsp;<span id="Span196" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:TextBox runat="server" ID="txtMVA_Multitpi_City" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="rfvMVA_Multitpi_City" InitialValue="" ControlToValidate="txtMVA_Multitpi_City"
                                                                                                runat="server" ValidationGroup="vsMVAMultiGroup" ErrorMessage="Please Enter City."
                                                                                                SetFocusOnError="true" Display="None" Enabled="false">
                                                                                            </asp:RequiredFieldValidator>--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">State&nbsp;<span id="Span197" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:DropDownList runat="server" ID="ddlMVA_Multitpi_State" SkinID="ddlSONIC">
                                                                                            </asp:DropDownList>
                                                                                            <%--<asp:RequiredFieldValidator ID="rfvMVA_Multitpi_State" InitialValue="0" ControlToValidate="ddlMVA_Multitpi_State"
                                                                                                runat="server" ValidationGroup="vsMVAMultiGroup" ErrorMessage="Please select state."
                                                                                                SetFocusOnError="true" Display="None" Enabled="false">
                                                                                            </asp:RequiredFieldValidator>--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">Zip&nbsp;<span id="Span198" style="color: Red; display: none;" runat="server">*</span>
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:TextBox runat="server" ID="txtMVA_Multitpi_Zip_Code" Width="170px" MaxLength="10"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="rfvMVA_Multitpi_Zip_Code" InitialValue="" ControlToValidate="txtMVA_Multitpi_Zip_Code"
                                                                                                runat="server" ValidationGroup="vsMVAMultiGroup" ErrorMessage="Please Enter Zip Code."
                                                                                                SetFocusOnError="true" Display="None" Enabled="false">
                                                                                            </asp:RequiredFieldValidator>--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr runat="server" id="trMVA_MultiSeeking_subrogation_No" style="display: none;">
                                                                            <td align="left" style="padding-left: 30px;">If No, is this a notice-only Claim?
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left" colspan="4">
                                                                                <asp:RadioButtonList runat="server" ID="rdoMVA_MultiNotice_only_claim" SkinID="YesNoTypeNullSelection">
                                                                                </asp:RadioButtonList>
                                                                                <asp:RequiredFieldValidator ID="rfvMVA_MultiNotice_only_claim" InitialValue="" ControlToValidate="rdoMVA_MultiNotice_only_claim"
                                                                                    runat="server" ValidationGroup="vsMVAMultiGroup" ErrorMessage="Please answer is this a notice-only Claim?"
                                                                                    SetFocusOnError="true" Display="None" Enabled="false">
                                                                                </asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trRecoveredAmount" style="display: none" runat="server">
                                                                            <td align="left">Recovered Amount&nbsp;<span id="Span199" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left" colspan="4">$<asp:TextBox runat="server" ID="txtMVA_MultiRecovered_Amount" Width="170px" MaxLength="10" onchange="TheftCheck(true);"
                                                                                onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);" onblur="CheckNumericVal(this);"></asp:TextBox>
                                                                                <%--<asp:RequiredFieldValidator ID="rfvMVA_MultiRecovered_Amount" InitialValue="" ControlToValidate="txtMVA_MultiRecovered_Amount"
                                                                                    runat="server" ValidationGroup="vsMVAMultiGroup" ErrorMessage="Please Enter Recovered Amount"
                                                                                    SetFocusOnError="true" Display="None" Enabled="true">
                                                                                </asp:RequiredFieldValidator>--%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center" colspan="6">
                                                                                <asp:Button runat="server" ID="btnAddVehicle" Text="Add" OnClick="btnAddVehicle_Click"
                                                                                    CausesValidation="true" ValidationGroup="vsVehicleGroup" />
                                                                                <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
                                                                                    Display="None" ValidationGroup="vsVehicleGroup" />
                                                                                <input id="hdnControlIDs2" runat="server" type="hidden" />
                                                                                <input id="hdnErrorMsgs2" runat="server" type="hidden" />
                                                                                <asp:Button runat="server" ID="btnResetVehicle" Text="Return" OnClick="btnResetVehicle_Click" CausesValidation="false" />
                                                                                <asp:Button runat="server" ID="btnViewAuditVehicle" Text="View Audit Trail" CausesValidation="false"
                                                                                    Visible="false" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="6" align="left">
                                                                                <b><i>Attach Copy of Title for the above reported Vehicle and any/all other Vehicles to be included in the incident report</i></b>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td align="center" colspan="6">
                                                                    <asp:HiddenField runat="server" ID="hdnLoss" />
                                                                    <asp:Button ID="btnLossSave" runat="server" OnClick="btnLossSave_Click" OnClientClick="return CheckValidationLossInfo();" Text="Save &amp; Continue" ValidationGroup="vsLossInfoGroup" />
                                                                    <asp:CustomValidator ID="CustomValidator12" runat="server" ClientValidationFunction="ValidateFields" Display="None" ErrorMessage="" ValidationGroup="vsLossInfoGroup" />
                                                                    <input id="hdnControlIDs12" runat="server" type="hidden" />
                                                                    <input id="hdnErrorMsgs12" runat="server" type="hidden" />
                                                                    <asp:Button ID="btnLossAudit" runat="server" CausesValidation="false" OnClientClick="javascript:return AuditPopUp();" Text="View Audit Trail" ToolTip="View Audit Trail" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="lstCauseOfLoss" EventName="SelectedIndexChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlWitnesses" runat="server" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Witnesses
                                                </div>
                                                <asp:UpdatePanel runat="Server" ID="updWitness">
                                                    <ContentTemplate>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td colspan="6">
                                                                    <asp:GridView ID="gvWitnesses" runat="server" DataKeyNames="PK_DPD_Witness_ID" AutoGenerateColumns="false"
                                                                        Width="100%" AllowSorting="false" OnRowDataBound="gvWitnesses_RowDataBound" OnRowCreated="gvWitnesses_RowCreated"
                                                                        OnRowCommand="gvWitnesses_RowCommand" OnRowEditing="gvWitnesses_RowEditing">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Name">
                                                                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton runat="server" ID="lnkEdit" CommandName="Edit" Text='<%#Eval("Name")%>'></asp:LinkButton>
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
                                                                            <asp:TemplateField HeaderText="Remove">
                                                                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton runat="server" ID="lnkRemove" CommandName="Remove" Text="Remove"
                                                                                        OnClientClick="return confirm('Sure to delete?');"></asp:LinkButton>
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
                                                            <tr>
                                                                <td align="left">Name&nbsp;<span id="Span200" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtWitness_Name" Width="170px" MaxLength="50"></asp:TextBox>
                                                                    <%--<asp:RequiredFieldValidator ID="rfvWitness_Name" InitialValue="" ControlToValidate="txtWitness_Name"
                                                                        runat="server" ValidationGroup="vsWitnessGroup" ErrorMessage="Please Enter name."
                                                                        SetFocusOnError="true" Display="None" Enabled="true">
                                                                    </asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">Address&nbsp;<span id="Span201" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">:
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtWitness_Address" Width="170px" MaxLength="50"></asp:TextBox>
                                                                    <%--<asp:RequiredFieldValidator ID="rfvWitness_Address" InitialValue="" ControlToValidate="txtWitness_Address"
                                                                        runat="server" ValidationGroup="vsWitnessGroup" ErrorMessage="Please Enter Address."
                                                                        SetFocusOnError="true" Display="None" Enabled="true">
                                                                    </asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Phone&nbsp;<span id="Span202" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtWitness_Phone" Width="170px" MaxLength="20"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revWitness_Phone" ControlToValidate="txtWitness_Phone"
                                                                        runat="server" ValidationGroup="vsWitnessGroup" ErrorMessage="Please Enter Phone Number in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" align="left">
                                                                    <asp:Button runat="server" ID="btnWitnessSave" Text="Add" OnClick="btnWitnessSave_Click"
                                                                        CausesValidation="false" ValidationGroup="vsWitnessGroup" OnClientClick="javascript:return ValidWitness();" />
                                                                    <asp:CustomValidator ID="CustomValidator15" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
                                                                        Display="None" ValidationGroup="vsWitnessGroup" />
                                                                    <input id="hdnControlIDs15" runat="server" type="hidden" />
                                                                    <input id="hdnErrorMsgs15" runat="server" type="hidden" />
                                                                    <asp:Button runat="server" ID="btnViewAuditWitness" Text="View Audit Trail" Visible="false"
                                                                        ToolTip="View Audit Trail" CausesValidation="false" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" align="center">
                                                                    <asp:Button runat="server" ID="btnWitnessContinue" Text="Continue" OnClick="btnWitnessContinue_Click" />
                                                                    <asp:Button runat="server" ID="btnWitnessAudit" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();"
                                                                        ToolTip="View Audit Trail" CausesValidation="false" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlComments" runat="server" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Comments and Attachments
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" style="width: 18%" valign="top">Comments&nbsp;<span id="Span203" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" style="width: 4%" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="txtComments" runat="server" MaxLength="4000" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" style="height: 10px;"></td>
                                                    </tr>
                                                    <tr class="bandHeaderRow">
                                                        <td colspan="6">Attachments
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Attachments
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <uc:ctrlAttachmentDetails ID="CtrlAttachDetails" runat="Server" ShowAttachmentType="true" ModeofPage="editmode" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <uc:ctrlAttachment ID="CtrlAttachment" runat="Server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <asp:Label runat="server" ID="lblNote" SkinID="lblError" Text="Note : All fields marked with an asterisk are required before saving."></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="center">
                                                            <asp:Button runat="server" ID="btnSubmit" Text="Submit Report" OnClick="btnSubmit_Click"
                                                                OnClientClick="return CheckAllValidation();" />
                                                            <asp:CustomValidator ID="CustomValidator16" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
                                                                Display="None" ValidationGroup="vsCommentsGroup" />
                                                            <input id="hdnControlIDs16" runat="server" type="hidden" />
                                                            <input id="hdnErrorMsgs16" runat="server" type="hidden" />
                                                            <asp:Button runat="server" ID="btnSubmitAudit" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();"
                                                                ToolTip="View Audit Trail" CausesValidation="false" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </div>
                                        <div id="dvView" runat="server" style="display: block;">
                                            <asp:Panel ID="pnlViewLocation" runat="server" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Location Information
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%">Location Number
                                                        </td>
                                                        <td align="center" width="4%">:
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label runat="server" ID="lblLocationNumber"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%">Location d/b/a
                                                        </td>
                                                        <td align="center" width="4%">:
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label runat="server" ID="lblLocationdba"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Legal Entity
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblLegalEntity"></asp:Label>
                                                        </td>
                                                        <td align="left">Location f/k/a
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblLocationfka" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Address 1
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label ID="lblLocationAddress1" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Address 2
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label ID="lblLocationAddress2" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">City
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label ID="lblLocationCity" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">State
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label runat="server" ID="lblLocationState"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Zip Code
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label ID="lblLocationZipCode" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div class="bandHeaderRow">
                                                    Loss Location if Different
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" style="width: 18%">Address 1
                                                        </td>
                                                        <td align="center" style="width: 4%">:
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblLoss_Address_1"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">Did the accident occur on company property?
                                                        </td>
                                                        <td align="center" style="width: 4%">:
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOn_Company_Property"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Address 2
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblLoss_Address_2"></asp:Label>
                                                        </td>
                                                        <td align="left">Date of Loss
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblDate_Of_Loss" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">City
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblLoss_City"></asp:Label>
                                                        </td>
                                                        <td align="left">Time of Loss (HH:MM)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblTime_of_Loss"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">State
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblLoss_State"></asp:Label>
                                                        </td>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                        <td align="center">&nbsp;
                                                        </td>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Zip Code
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblLoss_ZipCode"></asp:Label>
                                                        </td>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                        <td align="center">&nbsp;
                                                        </td>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div class="bandHeaderRow">
                                                    Contact Information
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%">Dealership/Collision Center
                                                        </td>
                                                        <td align="center" width="4%">:
                                                        </td>
                                                        <td width="28%" align="left">
                                                            <asp:Label runat="server" ID="lbldba"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%">&nbsp;
                                                        </td>
                                                        <td align="left" width="4%">&nbsp;
                                                        </td>
                                                        <td align="left" width="28%">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Contact Name
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblContactName"></asp:Label>
                                                        </td>
                                                        <td align="left">Address 1
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblAddress_1"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">When to Contact
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblContact_Best_Time"></asp:Label>
                                                        </td>
                                                        <td align="left">Address 2
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblAddress_2"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Telephone Number 1<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblWork_Phone"></asp:Label>
                                                        </td>
                                                        <td align="left">City
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblCity"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Telephone Number 2<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblEmployee_Cell_Phone"></asp:Label>
                                                        </td>
                                                        <td align="left">State
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblState"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Fax Number<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblEmployee_Fax" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                        <td align="left">Zip
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblZip_Code"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Email Address
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label ID="lblEmail" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Date Reported to Sonic
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label ID="lblDate_Reported_To_Sonic" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlViewLossInformation" Width="100%" runat="server">
                                                <div class="bandHeaderRow">
                                                    Loss Information</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Date of Loss
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblLossDate_Of_Loss"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="left">
                                                            Cause of Loss
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="left">
                                                            <asp:CheckBox runat="server" ID="chkViewtheft" Text="Theft" Enabled="false" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" >
                                                            <asp:UpdatePanel runat="server" ID="updViewTheft">
                                                                <ContentTemplate>
                                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%" style="width: 100%; display: none;" id="tdViewTheft" runat="server">
                                                                        <tr>
                                                                            <td colspan="6">
                                                                                <asp:GridView ID="gvViewTheft" runat="server" DataKeyNames="PK_DPD_FR_Vehicle_ID"
                                                                                    AutoGenerateColumns="false" Width="100%" AllowSorting="false" OnRowCreated="gvViewTheft_RowCreated"
                                                                                    OnRowCommand="gvViewTheft_RowCommand">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="VIN">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("VIN")%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Vehicle Make">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("Make") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Model">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("Model") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Year">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("Year") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Invoice Value">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                $
                                                                                                <%# clsGeneral.GetStringValue(Eval("Invoice_Value"))%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="View">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton runat="server" ID="lnkViewTheft" CommandName="View" Text="View" CausesValidation="false"></asp:LinkButton>
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
                                                                        <tr>
                                                                            <td align="left" runat="server" id="tdViewTheftData" style="display: none;">
                                                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            VIN#
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewTheft_VIN"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" style="width: 18%">
                                                                                            Make
                                                                                        </td>
                                                                                        <td align="center" style="width: 4%">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewTheft_Make"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Model
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewTheft_Model"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Year
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewTheft_Year"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Type of Vehicle
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblTheft_TypeOfVehicle">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location of Vehicle
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblTheft_Present_Location"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location Address
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblTheft_Present_Address"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location State
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblTheft_Present_State">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location Zip
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblTheft_Present_Zip"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Invoice Value
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewTheft_Invoice_Value"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">
                                                                                            In Detail, Explain What Happened
                                                                                        </td>
                                                                                        <td align="center" valign="top">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <uc:ctrlMultiLineTextBox runat="server" ID="lblViewTheft_Loss_Description" ControlType="Label" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Is There a Security Video Surveillance System?
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblTheft_Security_Video_Surveillance"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Was the Vehicle Recovered?
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewTheft_Vehicle_Recovered">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="3" align="left" runat="server" id="tdViewTheft_VehicleRecovred" style="display: none">
                                                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        If Yes, damage amount
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        $<asp:Label runat="server" ID="lblViewTheft_Damage_estimate"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        If Yes, does the dealership wish to take possession?
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <asp:Label runat="server" ID="lblViewTheft_Dealership_Wish_To_Take_Possession">
                                                                                                        </asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Is the Vehicle in storage?
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewTheftVehicle_In_Storage">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="6" align="left" runat="server" id="tdViewTheftVehicle_In_Storage" style="display: none">
                                                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                                <tr>
                                                                                                    <td align="left" style="width: 18%">
                                                                                                        Address 1
                                                                                                    </td>
                                                                                                    <td align="center" style="width: 4%">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" style="width: 28%">
                                                                                                        <asp:Label runat="server" ID="lblViewTheft_Storage_Address_1"></asp:Label>
                                                                                                    </td>
                                                                                                    <td align="left" style="width: 18%">
                                                                                                        Contact Name
                                                                                                    </td>
                                                                                                    <td align="center" style="width: 4%">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" style="width: 28%">
                                                                                                        <asp:Label runat="server" ID="lblViewTheft_Storage_Contact"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        Address 2
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:Label runat="server" ID="lblViewTheft_Storage_Address_2"></asp:Label>
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        Storage Phone
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:Label runat="server" ID="lblViewTheft_Storage_phone"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        City
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:Label runat="server" ID="lblViewTheft_Storage_City"></asp:Label>
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        Cost of Strorate
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:Label runat="server" ID="lblViewTheft_Storage_cost"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        Storage State
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <asp:Label runat="server" ID="lblViewTheft_Storage_State">
                                                                                                        </asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        Storage Zip
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <asp:Label runat="server" ID="lblViewTheft_storage_Zip_Code"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="6" align="left">
                                                                                            <asp:Button runat="server" ID="btnViewAuditTheft_View" Text="View Audit Trail" CausesValidation="false"
                                                                                                Visible="false" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="left">
                                                            <asp:CheckBox runat="server" ID="chkViewPartialTheft" Text="Partial Theft" Enabled="false" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" >
                                                            <asp:UpdatePanel runat="server" ID="UpdViewPartialTheft">
                                                                <ContentTemplate>
                                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%" style="width: 100%; display: none;" id="tdViewPartialTheft" runat="Server">
                                                                        <tr>
                                                                            <td style="width: 100%;">
                                                                                <asp:GridView ID="gvViewPartialTheft" runat="server" DataKeyNames="PK_DPD_FR_Vehicle_ID"
                                                                                    AutoGenerateColumns="false" Width="100%" AllowSorting="false" OnRowCreated="gvViewPartialTheft_RowCreated"
                                                                                    OnRowCommand="gvViewPartialTheft_RowCommand">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="VIN">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("VIN")%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Vehicle Make">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("Make") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Model">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("Model") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Year">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("Year") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Invoice Value">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                $
                                                                                                <%# clsGeneral.GetStringValue(Eval("Invoice_Value"))%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="View">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton runat="server" ID="lnkViewPartialTheft" CommandName="View" Text="View" CausesValidation="false"></asp:LinkButton>
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
                                                                        <tr>
                                                                            <td align="left" runat="server" id="tdViewPartilTheftData" style="display: none;">
                                                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                    <tr>
                                                                                        <td align="left" style="width: 18%">
                                                                                            VIN#
                                                                                        </td>
                                                                                        <td align="center" style="width: 4%">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewPartialTheft_VIN"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Make
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewPartialTheft_Make"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Model
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewPartialTheft_Model"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Year
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewPartialTheft_Year"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Type of Vehicle
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblPartialTheft_TypeOfVehicle">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location of Vehicle
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblPartialTheft_Present_Location"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location Address
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblPartialTheft_Present_Address"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location State
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblPartialTheft_Present_State">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location Zip
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblPartialTheft_Present_Zip"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Invoice Value
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewPartialTheft_Invoice_Value"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">
                                                                                            In Detail, Explain What Happened
                                                                                        </td>
                                                                                        <td align="center" valign="top">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <uc:ctrlMultiLineTextBox runat="server" ID="lblViewPartialTheft_Loss_Description"
                                                                                                ControlType="Label" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Is There a Security Video Surveillance System?
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblPartialTheft_Security_Video_Surveillance"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="6" align="left">
                                                                                            <asp:Button runat="server" ID="btnViewAuditPartialTheft_View" Text="View Audit Trail"
                                                                                                CausesValidation="false" Visible="false" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="left">
                                                            <asp:CheckBox runat="server" ID="chkViewVandalism" Text="Vandalism" Enabled="false" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" >
                                                            <asp:UpdatePanel runat="server" ID="UpdViewVandalism">
                                                                <ContentTemplate>
                                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%" style="width: 100%; display: none;" id="tdViewVandalism" runat="Server">
                                                                        <tr>
                                                                            <td style="width: 100%;">
                                                                                <asp:GridView ID="gvViewVandalism" runat="server" DataKeyNames="PK_DPD_FR_Vehicle_ID"
                                                                                    AutoGenerateColumns="false" Width="100%" AllowSorting="false" OnRowCreated="gvViewVandalism_RowCreated"
                                                                                    OnRowCommand="gvViewVandalism_RowCommand">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="VIN">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("VIN")%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Vehicle Make">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("Make") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Model">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("Model") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Year">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("Year") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Invoice Value">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                $
                                                                                                <%# clsGeneral.GetStringValue(Eval("Invoice_Value"))%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="View">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton runat="server" ID="lnkViewVandalism" CommandName="View" Text="View" CausesValidation="false"></asp:LinkButton>
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
                                                                        <tr>
                                                                            <td align="left" runat="server" id="tdViewVandalismData" style="display: none;">
                                                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                    <tr>
                                                                                        <td align="left" style="width: 18%">
                                                                                            VIN#
                                                                                        </td>
                                                                                        <td align="center" style="width: 4%">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewVandalism_VIN"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Make
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewVandalism_Make"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Model
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewVandalism_Model"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Year
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewVandalism_Year"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Type of Vehicle
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblVandalism_TypeOfVehicle">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location of Vehicle
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblVandalism_Present_Location"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location Address
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblVandalism_Present_Address"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location State
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblVandalism_Present_State">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location Zip
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblVandalism_Present_Zip"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Invoice Value
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewVandalism_Invoice_Value"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">
                                                                                            In Detail, Explain What Happened
                                                                                        </td>
                                                                                        <td align="center" valign="top">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <uc:ctrlMultiLineTextBox runat="server" ID="lblViewVandalism_Loss_Description" ControlType="Label" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Is There a Security Video Surveillance System?
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblVandalism_Security_Video_Surveillance"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="6" align="left">
                                                                                            <asp:Button runat="server" ID="btnViewAuditVandalism_View" Text="View Audit Trail"
                                                                                                CausesValidation="false" Visible="false" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="left">
                                                            <asp:CheckBox runat="server" ID="chkViewMVA_Single_Damage" Text="MVA – Damage (Single Vehicle)"
                                                                Enabled="false" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" >
                                                            <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                                                                <ContentTemplate>
                                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%" style="display: none; width: 100%" runat="Server" id="tdViewMVA_Single_Damage">
                                                                        <tr>
                                                                            <td colspan="6">
                                                                                <asp:GridView ID="gvViewSingleVehDamage" runat="server" DataKeyNames="PK_DPD_FR_Vehicle_ID"
                                                                                    AutoGenerateColumns="false" Width="100%" AllowSorting="false" OnRowCommand="gvViewSingleVehDamage_RowCommand"
                                                                                    OnRowCreated="gvViewSingleVehDamage_RowCreated">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="VIN">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("VIN")%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Vehicle Make">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("Make") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Model">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("Model") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Year">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("Year") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Invoice Value">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                $
                                                                                                <%#clsGeneral.GetStringValue(Eval("Invoice_Value"))%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="View">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton runat="server" ID="lnkViewSingleVeh" CommandName="View" Text="View" CausesValidation="false"></asp:LinkButton>
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
                                                                        <tr>
                                                                            <td colspan="6" align="left" runat="server" id="tdViewSinglevehicleData" style="display: none;">
                                                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                    <tr>
                                                                                        <td align="left" style="width: 18%">
                                                                                            VIN#
                                                                                        </td>
                                                                                        <td align="center" style="width: 4%">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewMVA_SingleVIN"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" style="width: 18%">
                                                                                            Make
                                                                                        </td>
                                                                                        <td align="center" style="width: 4%">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewMVA_SingleMake"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" style="width: 18%">
                                                                                            Model
                                                                                        </td>
                                                                                        <td align="center" style="width: 4%">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewMVA_SingleModel"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" style="width: 18%">
                                                                                            Year
                                                                                        </td>
                                                                                        <td align="center" style="width: 4%">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewMVA_SingleYear"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Type of Vehicle
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblMVA_Single_TypeOfVehicle">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location of Vehicle
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblMVA_Single_Present_Location"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location Address
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblMVA_Single_Present_Address"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location State
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblMVA_Single_Present_State">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location Zip
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblMVA_Single_Present_Zip"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Invoice Value
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            $<asp:Label runat="server" ID="lblViewMVA_SingleInvoice_Value"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">
                                                                                            In Detail, Explain What Happened
                                                                                        </td>
                                                                                        <td align="center" valign="top">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <uc:ctrlMultiLineTextBox runat="server" ID="lblViewMVASingleLoss_description" ControlType="Label" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" style="width: 18%">
                                                                                            Damage Estimate
                                                                                        </td>
                                                                                        <td align="center" style="width: 4%">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewMVA_SingleDamage_Estimate"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" style="width: 18%">
                                                                                            Was vehicle being driven by company associate?
                                                                                        </td>
                                                                                        <td align="center" style="width: 4%">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewMVA_SingleDriven_By_Associate">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr >
                                                                                        <td colspan="6" align="left">
                                                                                            <table cellpadding="3" cellspacing="0" border="0" width="100%" id="trViewMVASingle_DrivenByCA_Yes" style="display: none" runat="Server">
                                                                                                <tr>
                                                                                                    <td align="left" style="width: 18%; padding-left: 30px;">
                                                                                                        If Yes, Name
                                                                                                    </td>
                                                                                                    <td align="center" style="width: 4%">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" >
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_SingleName_Yes"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left" style="padding-left: 30px;">
                                                                                                        If Yes, Address
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" >
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_SingleAddress_Yes"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left" style="padding-left: 30px;">
                                                                                                        If Yes, Phone
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_SinglePhone_Yes"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left" style="padding-left: 30px;">
                                                                                                        If Yes, was associate cited for a violation?
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" >
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_SingleAssociate_Cited">
                                                                                                        </asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr id="trViewMVA_SingleCitation_Yes" runat="server" style="display: none;">
                                                                                                    <td align="left" valign="top" style="padding-left: 45px;">
                                                                                                        If Yes, Description of citation
                                                                                                    </td>
                                                                                                    <td align="center" valign="top">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" >
                                                                                                        <uc:ctrlMultiLineTextBox runat="server" ID="lblViewMVA_SingleDescription_Of_Citation"
                                                                                                            ControlType="Label" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left" valign="top" style="padding-left: 30px;">
                                                                                                        If Yes, was the associcate injured?
                                                                                                    </td>
                                                                                                    <td align="center" valign="top">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" >
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_SingleAssociate_injured">
                                                                                                        </asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left" valign="top" style="padding-left: 30px;">
                                                                                                        If Yes, was a post-accident drug test performed?
                                                                                                    </td>
                                                                                                    <td align="center" valign="top">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" >
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_SingleDrug_test_performed">
                                                                                                        </asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr runat="server" id="trViewMVA_SingleDrugYes" style="display: none;">
                                                                                                    <td align="left" valign="top" style="padding-left: 45px;">
                                                                                                        If Yes, Results
                                                                                                    </td>
                                                                                                    <td align="center" valign="top">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" >
                                                                                                        <uc:ctrlMultiLineTextBox runat="server" ID="lblViewMVA_SingleDrug_test_results" ControlType="Label" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr runat="server" id="trViewMVA_SingleDrugNo" style="display: none;">
                                                                                                    <td align="left" valign="top" style="padding-left: 30px;">
                                                                                                        If No, Explain
                                                                                                    </td>
                                                                                                    <td align="center" valign="top">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" >
                                                                                                        <uc:ctrlMultiLineTextBox runat="server" ID="lblViewMVA_SingleDrug_test_explanation"
                                                                                                            ControlType="Label" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr >
                                                                                        <td colspan="6" align="left">
                                                                                            <table cellpadding="3" cellspacing="0" border="0" width="100%" id="trViewMVASingle_DrivenByCA_No" style="display: none" runat="Server">
                                                                                                <tr>
                                                                                                    <td align="left" style="width: 18%; padding-left: 30px;">
                                                                                                        If No, was vehicle being driven by customer?
                                                                                                    </td>
                                                                                                    <td align="center" style="width: 4%">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_SingleVehicle_Driven_By_Customer">
                                                                                                        </asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr runat="server" id="trViewMVA_SingleCust_Injured" style="display: none;">
                                                                                                    <td align="left" valign="top" style="padding-left: 45px;" colspan="6">
                                                                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                                            <tr>
                                                                                                                <td align="left" style="width: 18%;">
                                                                                                                    If Yes, Name
                                                                                                                </td>
                                                                                                                <td align="center" style="width: 4%">
                                                                                                                    :
                                                                                                                </td>
                                                                                                                <td align="left" colspan="4">
                                                                                                                    <asp:Label runat="server" ID="lblViewMVA_SingleName_No"></asp:Label>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td align="left">
                                                                                                                    If Yes, Address
                                                                                                                </td>
                                                                                                                <td align="center">
                                                                                                                    :
                                                                                                                </td>
                                                                                                                <td align="left" colspan="4">
                                                                                                                    <asp:Label runat="server" ID="lblViewMVA_SingleAddress_No"></asp:Label>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td align="left">
                                                                                                                    If Yes, Phone
                                                                                                                </td>
                                                                                                                <td align="center">
                                                                                                                    :
                                                                                                                </td>
                                                                                                                <td align="left" colspan="4">
                                                                                                                    <asp:Label runat="server" ID="lblViewMVA_SinglePhone_No"></asp:Label>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    If Yes, was the customer injured?
                                                                                                                </td>
                                                                                                                <td align="center" valign="top">
                                                                                                                    :
                                                                                                                </td>
                                                                                                                <td align="left" colspan="4">
                                                                                                                    <asp:Label runat="server" ID="lblViewMVA_Singlecustomer_injured">
                                                                                                                    </asp:Label>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr id="trViewMVA_SingleCust_Not_Injured" runat="server" style="display: none">
                                                                                                    <td align="left" valign="top" style="padding-left: 45px;">
                                                                                                        If No, Explain
                                                                                                    </td>
                                                                                                    <td align="center" valign="top">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <uc:ctrlMultiLineTextBox runat="Server" ID="lblViewMVA_SingleNot_Driven_By_Customer_Explain"
                                                                                                            ControlType="Label" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" style="width: 18%">
                                                                                            Were other passengers in the vehicle besides the Associate and the Customer?
                                                                                        </td>
                                                                                        <td align="center" style="width: 4%">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewMVA_SingleAdditional_passengers">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr runat="server" id="trViewMVA_SingleAdditional_passengers_Yes" style="display: none;">
                                                                                        <td colspan="6" align="left" style="padding-left: 30px;">
                                                                                            <asp:GridView ID="gvViewMVASingle_Passenger" runat="server" DataKeyNames="PK_DPD_FR_Injured_Passenger_id"
                                                                                                AutoGenerateColumns="false" Width="100%" AllowSorting="false" OnRowCreated="gvViewMVASingle_Passenger_RowCreated"
                                                                                                OnRowCommand="gvViewMVASingle_Passenger_RowCommand">
                                                                                                <Columns>
                                                                                                    <asp:TemplateField HeaderText="Name">
                                                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                                        <ItemTemplate>
                                                                                                            <%#Eval("name")%>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Address 1">
                                                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                                        <ItemTemplate>
                                                                                                            <%#Eval("Address_1")%>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="City">
                                                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                                        <ItemTemplate>
                                                                                                            <%#Eval("City")%>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="State">
                                                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                                        <ItemTemplate>
                                                                                                            <%# new ERIMS.DAL.State(!string.IsNullOrEmpty(Convert.ToString(Eval("State"))) ? Convert.ToDecimal(Eval("State")) : 0).FLD_state%>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Zip">
                                                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                                        <ItemTemplate>
                                                                                                            <%#Eval("Zip_Code")%>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="View">
                                                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                                        <ItemTemplate>
                                                                                                            <asp:LinkButton runat="server" ID="lnkViewSinglePassenger" CommandName="View" Text="View" CausesValidation="false"></asp:LinkButton>
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
                                                                                    <tr >
                                                                                        <td colspan="6" align="left" style="padding-left: 30px;">
                                                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%" runat="server" id="trMVA_Single_Passenger" style="display: none;">
                                                                                                <tr>
                                                                                                    <td style="width: 18%" align="left">
                                                                                                        Contact Name
                                                                                                    </td>
                                                                                                    <td style="width: 4%" align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_Single_Pass_Name"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        Address 1
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_Single_Pass_Address_1"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left" style="width: 18%">
                                                                                                        Address 2
                                                                                                    </td>
                                                                                                    <td align="center" style="width: 4%">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" style="width: 28%">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_Single_Pass_Address_2"></asp:Label>
                                                                                                    </td>
                                                                                                    <td align="left" style="width: 18%">
                                                                                                        Phone
                                                                                                    </td>
                                                                                                    <td align="center" style="width: 4%">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" style="width: 28%">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_Single_Pass_Phone"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        City
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_Single_Pass_City"></asp:Label>
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        Injured?
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_Single_Pass_Injured">
                                                                                                        </asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        State
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_Single_Pass_State">
                                                                                                        </asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        Zip
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_Single_Pass_Zip"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left" colspan="6">
                                                                                                        <asp:Button runat="server" ID="btnViewAudit_MVASingle_Passenger_View" Text="View Audit Trail"
                                                                                                            CausesValidation="false" Visible="false" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Is the dealership seeking subrogation from a third party?
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewMVA_SingleSeeking_subrogation">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr >
                                                                                        <td colspan="6" style="padding-left: 30px;">
                                                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%" runat="Server" id="trViewMVA_SingleSeeking_subrogation_Yes" style="display: none;">
                                                                                                <tr align="left">
                                                                                                    <td colspan="6">
                                                                                                        If Yes, provide Third Party Insurer Information
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left" style="width: 18%;">
                                                                                                        Carrier Name
                                                                                                    </td>
                                                                                                    <td align="center" style="width: 4%;">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" style="width: 28%;">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_SingleTPI_Carrier_name"></asp:Label>
                                                                                                    </td>
                                                                                                    <td align="left" style="width: 18%;">
                                                                                                        Contact Name
                                                                                                    </td>
                                                                                                    <td align="center" style="width: 4%;">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" style="width: 28%;">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_Singletpi_contact"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        Policy Number
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_SingleTPI_Policy_number"></asp:Label>
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        Phone
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_Singletpi_phone"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        Address 1
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_Singletpi_address_1"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        Address 2
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_Singletpi_address_2"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        City
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_Singletpi_City"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        State
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_Singletpi_State">
                                                                                                        </asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        Zip
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_Singletpi_Zip_Code"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr >
                                                                                        <td colspan="6" style="padding-left: 30px;">
                                                                                            <table runat="server" id="trViewMVA_SingleSeeking_subrogation_No" style="display: none;">
                                                                                                <tr>
                                                                                                    <td align="left" style="padding-left: 30px;">
                                                                                                        If No, is this a notice-only Claim?
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_SingleNotice_only_claim">
                                                                                                        </asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                        
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Recovered Amount
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewMVA_SingleRecovered_Amount"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="6">
                                                                                            <asp:Button runat="server" ID="btnViewAuditSingle_View" Text="View Audit Trail" CausesValidation="false"
                                                                                                Visible="false" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="left">
                                                            <asp:CheckBox runat="server" ID="chkViewMVA_Multi_Damage" Text="MVA – Damage (Multiple Vehicle)"
                                                                Enabled="false" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" >
                                                            <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                                                                <ContentTemplate>
                                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%" style="display: none; width: 100%" runat="Server" id="tdViewMVA_Multi_Damage">
                                                                        <tr>
                                                                            <td colspan="6">
                                                                                <asp:GridView ID="gvViewMultiVehDamage" runat="server" DataKeyNames="PK_DPD_FR_Vehicle_ID"
                                                                                    AutoGenerateColumns="false" Width="100%" AllowSorting="false" OnRowCommand="gvViewMultiVehDamage_RowCommand"
                                                                                    OnRowCreated="gvViewMultiVehDamage_RowCreated">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="VIN">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("VIN")%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Vehicle Make">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("Make") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Model">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("Model") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Year">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("Year") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Invoice Value">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                $
                                                                                                <%#clsGeneral.GetStringValue(Eval("Invoice_Value"))%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="View">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton runat="server" ID="lnkViewMultiVeh" CommandName="View" Text="View" CausesValidation="false"></asp:LinkButton>
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
                                                                        <tr>
                                                                            <td colspan="6" align="left" runat="server" id="tdViewMultivehicleData" style="display: none;">
                                                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                    <tr>
                                                                                        <td align="left" style="width: 18%">
                                                                                            VIN#
                                                                                        </td>
                                                                                        <td align="center" style="width: 4%">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewMVA_MultiVIN"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" style="width: 18%">
                                                                                            Make
                                                                                        </td>
                                                                                        <td align="center" style="width: 4%">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewMVA_MultiMake"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" style="width: 18%">
                                                                                            Model
                                                                                        </td>
                                                                                        <td align="center" style="width: 4%">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewMVA_MultiModel"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" style="width: 18%">
                                                                                            Year
                                                                                        </td>
                                                                                        <td align="center" style="width: 4%">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewMVA_MultiYear"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Vehicle Owner if not SONIC
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewMVA_MultiVehicle_Owner_Sonic"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Vehicle Owner Address
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewMVA_MultiVehicle_Owner_Address"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Vehicle Owner Phone
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewMVA_MultiVehicle_Owner_Phone"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Type of Vehicle
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblMVA_Multi_TypeOfVehicle">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location of Vehicle
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblMVA_Multi_Present_Location"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location Address
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblMVA_Multi_Present_Address"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location State
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblMVA_Multi_Present_State">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location Zip
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblMVA_Multi_Present_Zip"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Invoice Value
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            $<asp:Label runat="server" ID="lblViewMVA_MultiInvoice_Value"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">
                                                                                            In Detail, Explain What Happened
                                                                                        </td>
                                                                                        <td align="center" valign="top">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <uc:ctrlMultiLineTextBox runat="server" ID="lblViewMVAMultiLoss_description" ControlType="Label" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" style="width: 18%">
                                                                                            Damage Estimate
                                                                                        </td>
                                                                                        <td align="center" style="width: 4%">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewMVA_MultiDamage_Estimate"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" style="width: 18%">
                                                                                            Was vehicle being driven by company associate?
                                                                                        </td>
                                                                                        <td align="center" style="width: 4%">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewMVA_MultiDriven_By_Associate">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr id="trViewMVAMulti_DrivenByCA_Yes" style="display: none" runat="Server">
                                                                                        <td colspan="6" align="left">
                                                                                            <table cellpadding="3" cellspacing="0" border="0" width="100%">
                                                                                                <tr>
                                                                                                    <td align="left" style="width: 18%; padding-left: 30px;">
                                                                                                        If Yes, Name
                                                                                                    </td>
                                                                                                    <td align="center" style="width: 4%">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_MultiName_Yes"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left" style="padding-left: 30px;">
                                                                                                        If Yes, Address
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_MultiAddress_Yes"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left" style="padding-left: 30px;">
                                                                                                        If Yes, Phone
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_MultiPhone_Yes"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left" style="padding-left: 30px;">
                                                                                                        If Yes, was associate cited for a violation?
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_MultiAssociate_Cited">
                                                                                                        </asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr id="trViewMVA_MultiCitation_Yes" runat="server" style="display: none;">
                                                                                                    <td align="left" valign="top" style="padding-left: 45px;">
                                                                                                        If Yes, Description of citation
                                                                                                    </td>
                                                                                                    <td align="center" valign="top">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <uc:ctrlMultiLineTextBox runat="server" ID="lblViewMVA_MultiDescription_Of_Citation"
                                                                                                            ControlType="Label" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left" valign="top" style="padding-left: 30px;">
                                                                                                        If Yes, was the associcate injured?
                                                                                                    </td>
                                                                                                    <td align="center" valign="top">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_MultiAssociate_injured">
                                                                                                        </asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left" valign="top" style="padding-left: 30px;">
                                                                                                        If Yes, was a post-accident drug test performed?
                                                                                                    </td>
                                                                                                    <td align="center" valign="top">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_MultiDrug_test_performed">
                                                                                                        </asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr runat="server" id="trViewMVA_MultiDrugYes" style="display: none;">
                                                                                                    <td align="left" valign="top" style="padding-left: 45px;">
                                                                                                        If Yes, Results
                                                                                                    </td>
                                                                                                    <td align="center" valign="top">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <uc:ctrlMultiLineTextBox runat="server" ID="lblViewMVA_MultiDrug_test_results" ControlType="Label" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr runat="server" id="trViewMVA_MultiDrugNo" style="display: none;">
                                                                                                    <td align="left" valign="top" style="padding-left: 45px;">
                                                                                                        If No, Explain
                                                                                                    </td>
                                                                                                    <td align="center" valign="top">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <uc:ctrlMultiLineTextBox runat="server" ID="lblViewMVA_MultiDrug_test_explanation"
                                                                                                            ControlType="Label" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr id="trViewMVAMulti_DrivenByCA_No" style="display: none" runat="Server">
                                                                                        <td colspan="6" align="left">
                                                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                                <tr>
                                                                                                    <td align="left" style="width: 18%; padding-left: 30px;">
                                                                                                        If No, was vehicle being driven by customer?
                                                                                                    </td>
                                                                                                    <td align="center" style="width: 4%">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_MultiVehicle_Driven_By_Customer">
                                                                                                        </asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr runat="server" id="trViewMVA_MultiCust_Injured" style="display: none;">
                                                                                                    <td align="left" valign="top" style="padding-left: 45px;" colspan="6">
                                                                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                                            <tr>
                                                                                                                <td align="left" style="width: 18%;">
                                                                                                                    If Yes, Name
                                                                                                                </td>
                                                                                                                <td align="center" style="width: 4%">
                                                                                                                    :
                                                                                                                </td>
                                                                                                                <td align="left" colspan="4">
                                                                                                                    <asp:Label runat="server" ID="lblViewMVA_MultiName_No"></asp:Label>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td align="left">
                                                                                                                    If Yes, Address
                                                                                                                </td>
                                                                                                                <td align="center">
                                                                                                                    :
                                                                                                                </td>
                                                                                                                <td align="left" colspan="4">
                                                                                                                    <asp:Label runat="server" ID="lblViewMVA_MultiAddress_No"></asp:Label>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td align="left">
                                                                                                                    If Yes, Phone
                                                                                                                </td>
                                                                                                                <td align="center">
                                                                                                                    :
                                                                                                                </td>
                                                                                                                <td align="left" colspan="4">
                                                                                                                    <asp:Label runat="server" ID="lblViewMVA_MultiPhone_No"></asp:Label>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td align="left" valign="top">
                                                                                                                    If Yes, was the customer injured?
                                                                                                                </td>
                                                                                                                <td align="center" valign="top">
                                                                                                                    :
                                                                                                                </td>
                                                                                                                <td align="left" colspan="4">
                                                                                                                    <asp:Label runat="server" ID="lblViewMVA_Multicustomer_injured">
                                                                                                                    </asp:Label>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr id="trViewMVA_MultiCust_Not_Injured" runat="server" style="display: none">
                                                                                                    <td align="left" valign="top" style="padding-left: 45px;">
                                                                                                        If No, Explain
                                                                                                    </td>
                                                                                                    <td align="center" valign="top">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <uc:ctrlMultiLineTextBox runat="Server" ID="lblViewMVA_MultiNot_Driven_By_Customer_Explain"
                                                                                                            ControlType="Label" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" style="width: 18%">
                                                                                            Were other passengers in the vehicle besides the Associate and the Customer?
                                                                                        </td>
                                                                                        <td align="center" style="width: 4%">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewMVA_MultiAdditional_passengers">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr runat="server" id="trViewMVA_MultiAdditional_passengers_Yes" style="display: none;">
                                                                                        <td colspan="6" align="left" style="padding-left: 30px;">
                                                                                            <asp:GridView ID="gvViewMVAMulti_Passenger" runat="server" DataKeyNames="PK_DPD_FR_Injured_Passenger_id"
                                                                                                AutoGenerateColumns="false" Width="100%" AllowSorting="false" OnRowCreated="gvViewMVAMulti_Passenger_RowCreated"
                                                                                                OnRowCommand="gvViewMVAMulti_Passenger_RowCommand">
                                                                                                <Columns>
                                                                                                    <asp:TemplateField HeaderText="Name">
                                                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                                        <ItemTemplate>
                                                                                                            <%#Eval("name")%>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Address 1">
                                                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                                        <ItemTemplate>
                                                                                                            <%#Eval("Address_1")%>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="City">
                                                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                                        <ItemTemplate>
                                                                                                            <%#Eval("City")%>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="State">
                                                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                                        <ItemTemplate>
                                                                                                            <%# new ERIMS.DAL.State(!string.IsNullOrEmpty(Convert.ToString(Eval("State"))) ? Convert.ToDecimal(Eval("State")) : 0).FLD_state%>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Zip">
                                                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                                        <ItemTemplate>
                                                                                                            <%#Eval("Zip_Code")%>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="View">
                                                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                                        <ItemTemplate>
                                                                                                            <asp:LinkButton runat="server" ID="lnkViewMultiPassenger" CommandName="View" Text="View" CausesValidation="false"></asp:LinkButton>
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
                                                                                    <tr runat="server" id="trMVA_Multi_Passenger" style="display: none;">
                                                                                        <td colspan="6" align="left" style="padding-left: 30px;">
                                                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                                <tr>
                                                                                                    <td style="width: 18%" align="left">
                                                                                                        Contact Name
                                                                                                    </td>
                                                                                                    <td style="width: 4%" align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_Multi_Pass_Name"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        Address 1
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_Multi_Pass_Address_1"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left" style="width: 18%">
                                                                                                        Address 2
                                                                                                    </td>
                                                                                                    <td align="center" style="width: 4%">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" style="width: 28%">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_Multi_Pass_Address_2"></asp:Label>
                                                                                                    </td>
                                                                                                    <td align="left" style="width: 18%">
                                                                                                        Phone
                                                                                                    </td>
                                                                                                    <td align="center" style="width: 4%">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" style="width: 28%">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_Multi_Pass_Phone"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        City
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_Multi_Pass_City"></asp:Label>
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        Injured?
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_Multi_Pass_Injured">
                                                                                                        </asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        State
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_Multi_Pass_State">
                                                                                                        </asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        Zip
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_Multi_Pass_Zip"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="6" align="left">
                                                                                                        <asp:Button runat="server" ID="btnViewAudit_MVA_Multi_Passenger_View" Text="View Audit Trail"
                                                                                                            CausesValidation="false" Visible="false" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Is the dealership seeking subrogation from a third party?
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewMVA_MultiSeeking_subrogation">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr runat="Server" id="trViewMVA_MultiSeeking_subrogation_Yes" style="display: none;">
                                                                                        <td colspan="6" style="padding-left: 30px;">
                                                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                                <tr align="left">
                                                                                                    <td colspan="6">
                                                                                                        If Yes, provide Third Party Insurer Information
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left" style="width: 18%;">
                                                                                                        Carrier Name
                                                                                                    </td>
                                                                                                    <td align="center" style="width: 4%;">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" style="width: 28%;">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_MultiTPI_Carrier_name"></asp:Label>
                                                                                                    </td>
                                                                                                    <td align="left" style="width: 18%;">
                                                                                                        Contact Name
                                                                                                    </td>
                                                                                                    <td align="center" style="width: 4%;">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" style="width: 28%;">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_Multitpi_contact"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        Policy Number
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_MultiTPI_Policy_number"></asp:Label>
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        Phone
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_Multitpi_phone"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        Address 1
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_Multitpi_address_1"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        Address 2
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_Multitpi_address_2"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        City
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_Multitpi_City"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        State
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_Multitpi_State">
                                                                                                        </asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        Zip
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <asp:Label runat="server" ID="lblViewMVA_Multitpi_Zip_Code"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr runat="server" id="trViewMVA_MultiSeeking_subrogation_No" style="display: none;">
                                                                                        <td align="left" style="padding-left: 30px;">
                                                                                            If No, is this a notice-only Claim?
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewMVA_MultiNotice_only_claim">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Recovered Amount
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewMVA_MultiRecovered_Amount"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="6">
                                                                                            <asp:Button runat="server" ID="btnViewAuditMulti_View" Text="View Audit Trail" CausesValidation="false"
                                                                                                Visible="false" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="left">
                                                            <asp:CheckBox runat="server" ID="chkViewHail" Text="Hail" Enabled="false" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <asp:UpdatePanel runat="server" ID="UpdViewHail">
                                                                <ContentTemplate>
                                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%"  style="width: 100%; display: none;" id="tdViewHail" runat="Server">
                                                                        <tr>
                                                                            <td style="width: 100%;">
                                                                                <asp:GridView ID="gvViewHail" runat="server" DataKeyNames="PK_DPD_FR_Vehicle_ID"
                                                                                    AutoGenerateColumns="false" Width="100%" AllowSorting="false" OnRowCreated="gvViewHail_RowCreated"
                                                                                    OnRowCommand="gvViewHail_RowCommand">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="VIN">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("VIN")%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Vehicle Make">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("Make") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Model">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("Model") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Year">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("Year") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Invoice Value">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                $
                                                                                                <%# clsGeneral.GetStringValue(Eval("Invoice_Value"))%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="View">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton runat="server" ID="lnkViewHail" CommandName="View" Text="View" CausesValidation="false"></asp:LinkButton>
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
                                                                        <tr>
                                                                            <td align="left" runat="server" id="tdViewHailData" style="display: none;">
                                                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                    <tr>
                                                                                        <td align="left" style="width: 18%">
                                                                                            VIN#
                                                                                        </td>
                                                                                        <td align="center" style="width: 4%">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewHail_VIN"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Make
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewHail_Make"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Model
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewHail_Model"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Year
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewHail_Year"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Type of Vehicle
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblHail_TypeOfVehicle">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location of Vehicle
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblHail_Present_Location"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location Address
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblHail_Present_Address"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location State
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblHail_Present_State">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location Zip
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblHail_Present_Zip"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Invoice Value
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewHail_Invoice_Value"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">
                                                                                            In Detail, Explain What Happened
                                                                                        </td>
                                                                                        <td align="center" valign="top">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <uc:ctrlMultiLineTextBox runat="server" ID="lblViewHail_Loss_Description" ControlType="Label" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="6" align="left">
                                                                                            <asp:Button runat="server" ID="btnViewAuditHail_View" Text="View Audit Trail" CausesValidation="false"
                                                                                                Visible="false" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="left">
                                                            <asp:CheckBox runat="server" ID="chkViewFlood" Text="Flood" Enabled="false" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" >
                                                            <asp:UpdatePanel runat="server" ID="UpdViewFlood">
                                                                <ContentTemplate>
                                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%" style="width: 100%; display: none;" id="tdViewFlood" runat="Server">
                                                                        <tr>
                                                                            <td style="width: 100%;">
                                                                                <asp:GridView ID="gvViewFlood" runat="server" DataKeyNames="PK_DPD_FR_Vehicle_ID"
                                                                                    AutoGenerateColumns="false" Width="100%" AllowSorting="false" OnRowCreated="gvViewFlood_RowCreated"
                                                                                    OnRowCommand="gvViewFlood_RowCommand">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="VIN">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("VIN")%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Vehicle Make">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("Make") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Model">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("Model") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Year">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("Year") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Invoice Value">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                $
                                                                                                <%# clsGeneral.GetStringValue(Eval("Invoice_Value"))%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="View">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton runat="server" ID="lnkViewFlood" CommandName="View" Text="View" CausesValidation="false"></asp:LinkButton>
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
                                                                        <tr>
                                                                            <td align="left" runat="server" id="tdViewFloodData" style="display: none;">
                                                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                    <tr>
                                                                                        <td align="left" style="width: 18%">
                                                                                            VIN#
                                                                                        </td>
                                                                                        <td align="center" style="width: 4%">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewFlood_VIN"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Make
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewFlood_Make"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Model
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewFlood_Model"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Year
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewFlood_Year"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Type of Vehicle
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblFlood_TypeOfVehicle">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location of Vehicle
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblFlood_Present_Location"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location Address
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblFlood_Present_Address"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location State
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblFlood_Present_State">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location Zip
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblFlood_Present_Zip"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Invoice Value
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewFlood_Invoice_Value"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">
                                                                                            In Detail, Explain What Happened
                                                                                        </td>
                                                                                        <td align="center" valign="top">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <uc:ctrlMultiLineTextBox runat="server" ID="lblViewFlood_Loss_Description" ControlType="Label" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="6" align="left">
                                                                                            <asp:Button runat="server" ID="btnViewAuditFlood_View" Text="View Audit Trail" CausesValidation="false"
                                                                                                Visible="false" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="left">
                                                            <asp:CheckBox runat="server" ID="chkViewFire" Text="Fire" Enabled="false" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" >
                                                            <asp:UpdatePanel runat="server" ID="UpdViewFire">
                                                                <ContentTemplate>
                                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%" style="width: 100%; display: none;" id="tdViewFire" runat="Server">
                                                                        <tr>
                                                                            <td style="width: 100%;">
                                                                                <asp:GridView ID="gvViewFire" runat="server" DataKeyNames="PK_DPD_FR_Vehicle_ID"
                                                                                    AutoGenerateColumns="false" Width="100%" AllowSorting="false" OnRowCreated="gvViewFire_RowCreated"
                                                                                    OnRowCommand="gvViewFire_RowCommand">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="VIN">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("VIN")%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Vehicle Make">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("Make") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Model">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("Model") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Year">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("Year") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Invoice Value">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                $
                                                                                                <%# clsGeneral.GetStringValue(Eval("Invoice_Value"))%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="View">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton runat="server" ID="lnkViewFire" CommandName="View" Text="View" CausesValidation="false"></asp:LinkButton>
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
                                                                        <tr>
                                                                            <td align="left" runat="server" id="tdViewFireData" style="display: none;">
                                                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                    <tr>
                                                                                        <td align="left" style="width: 18%">
                                                                                            VIN#
                                                                                        </td>
                                                                                        <td align="center" style="width: 4%">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewFire_VIN"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Make
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewFire_Make"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Model
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewFire_Model"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Year
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewFire_Year"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Type of Vehicle
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblFire_TypeOfVehicle">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location of Vehicle
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblFire_Present_Location"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location Address
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblFire_Present_Address"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location State
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblFire_Present_State">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location Zip
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblFire_Present_Zip"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Invoice Value
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewFire_Invoice_Value"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">
                                                                                            In Detail, Explain What Happened
                                                                                        </td>
                                                                                        <td align="center" valign="top">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <uc:ctrlMultiLineTextBox runat="server" ID="lblViewFire_Loss_Description" ControlType="Label" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="6" align="left">
                                                                                            <asp:Button runat="server" ID="btnViewAuditFire_View" Text="View Audit Trail" CausesValidation="false"
                                                                                                Visible="false" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="left">
                                                            <asp:CheckBox runat="server" ID="chkViewWind" Text="Wind" Enabled="false" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" >
                                                            <asp:UpdatePanel runat="server" ID="UpdViewWind">
                                                                <ContentTemplate>
                                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%" style="width: 100%; display: none;" id="tdViewWind" runat="Server">
                                                                        <tr>
                                                                            <td style="width: 100%;">
                                                                                <asp:GridView ID="gvViewWind" runat="server" DataKeyNames="PK_DPD_FR_Vehicle_ID"
                                                                                    AutoGenerateColumns="false" Width="100%" AllowSorting="false" OnRowCreated="gvViewWind_RowCreated"
                                                                                    OnRowCommand="gvViewWind_RowCommand">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="VIN">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("VIN")%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Vehicle Make">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("Make") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Model">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("Model") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Year">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("Year") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Invoice Value">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                $
                                                                                                <%# clsGeneral.GetStringValue(Eval("Invoice_Value"))%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="View">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton runat="server" ID="lnkViewWind" CommandName="View" Text="View" CausesValidation="false"></asp:LinkButton>
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
                                                                        <tr>
                                                                            <td align="left" runat="server" id="tdViewWindData" style="display: none;">
                                                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                    <tr>
                                                                                        <td align="left" style="width: 18%">
                                                                                            VIN#
                                                                                        </td>
                                                                                        <td align="center" style="width: 4%">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewWind_VIN"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Make
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewWind_Make"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Model
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewWind_Model"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Year
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewWind_Year"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Type of Vehicle
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblWind_TypeOfVehicle">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location of Vehicle
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblWind_Present_Location"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location Address
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblWind_Present_Address"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location State
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblWind_Present_State">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location Zip
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblWind_Present_Zip"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Invoice Value
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewWind_Invoice_Value"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">
                                                                                            In Detail, Explain What Happened
                                                                                        </td>
                                                                                        <td align="center" valign="top">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <uc:ctrlMultiLineTextBox runat="server" ID="lblViewWind_Loss_Description" ControlType="Label" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="6" align="left">
                                                                                            <asp:Button runat="server" ID="btnViewAuditWind_View" Text="View Audit Trail" CausesValidation="false"
                                                                                                Visible="false" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="left">
                                                            <asp:CheckBox runat="server" ID="chkViewFraud" Text="Fraud" Enabled="false" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" >
                                                            <asp:UpdatePanel runat="server" ID="updViewFraud">
                                                                <ContentTemplate>
                                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%" style="width: 100%; display: none;" id="tdViewFraud" runat="server">
                                                                        <tr>
                                                                            <td colspan="6">
                                                                                <asp:GridView ID="gvViewFraud" runat="server" DataKeyNames="PK_DPD_FR_Vehicle_ID"
                                                                                    AutoGenerateColumns="false" Width="100%" AllowSorting="false" OnRowCreated="gvViewFraud_RowCreated"
                                                                                    OnRowCommand="gvViewFraud_RowCommand">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="VIN">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("VIN")%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Vehicle Make">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("Make") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Model">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("Model") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Year">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("Year") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Invoice Value">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                $
                                                                                                <%# clsGeneral.GetStringValue(Eval("Invoice_Value"))%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="View">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton runat="server" ID="lnkViewFraud" CommandName="View" Text="View" CausesValidation="false"></asp:LinkButton>
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
                                                                        <tr>
                                                                            <td align="left" runat="server" id="tdViewFraudData" style="display: none;">
                                                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            VIN#
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewFraud_VIN"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" style="width: 18%">
                                                                                            Make
                                                                                        </td>
                                                                                        <td align="center" style="width: 4%">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewFraud_Make"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Model
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewFraud_Model"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Year
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewFraud_Year"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Type of Vehicle
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblFraud_TypeOfVehicle">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location of Vehicle
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblFraud_Present_Location"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location Address
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblFraud_Present_Address"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location State
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblFraud_Present_State">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location Zip
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblFraud_Present_Zip"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Invoice Value
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            $<asp:Label runat="server" ID="lblViewFraud_Invoice_Value"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">
                                                                                            In Detail, Explain What Happened
                                                                                        </td>
                                                                                        <td align="center" valign="top">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <uc:ctrlMultiLineTextBox runat="server" ID="lblViewFraud_Loss_Description" ControlType="Label" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Was the Vehicle Recovered?
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewFraud_Vehicle_Recovered">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="3" align="left" runat="server" id="tdViewFraud_VehicleRecovred" style="display: none">
                                                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        If Yes, damage amount
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        $<asp:Label runat="server" ID="lblViewFraud_Damage_estimate"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        If Yes, does the dealership wish to take possession?
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <asp:Label runat="server" ID="lblViewFraud_Dealership_Wish_To_Take_Possession">
                                                                                                        </asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Is the Vehicle in storage?
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblViewFraudVehicle_In_Storage">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="6" align="left" runat="server" id="tdViewFraudVehicle_In_Storage" style="display: none">
                                                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                                <tr>
                                                                                                    <td align="left" style="width: 18%">
                                                                                                        Address 1
                                                                                                    </td>
                                                                                                    <td align="center" style="width: 4%">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" style="width: 28%">
                                                                                                        <asp:Label runat="server" ID="lblViewFraud_Storage_Address_1"></asp:Label>
                                                                                                    </td>
                                                                                                    <td align="left" style="width: 18%">
                                                                                                        Contact Name
                                                                                                    </td>
                                                                                                    <td align="center" style="width: 4%">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" style="width: 28%">
                                                                                                        <asp:Label runat="server" ID="lblViewFraud_Storage_Contact"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        Address 2
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:Label runat="server" ID="lblViewFraud_Storage_Address_2"></asp:Label>
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        Storage Phone
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:Label runat="server" ID="lblViewFraud_Storage_phone"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        City
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:Label runat="server" ID="lblViewFraud_Storage_City"></asp:Label>
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        Cost of Strorate
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:Label runat="server" ID="lblViewFraud_Storage_cost"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        Storage State
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <asp:Label runat="server" ID="lblViewFraud_Storage_State">
                                                                                                        </asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        Storage Zip
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <asp:Label runat="server" ID="lblViewFraud_storage_Zip_Code"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Were Police Notified?
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="server" ID="lblFraudPoliceNotified">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr runat="server" id="trViewPoliceNotified" style="display: none;">
                                                                                        <td align="left">
                                                                                            Police Report Number
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            :
                                                                                        </td>
                                                                                        <td align="left" colspan="4">
                                                                                            <asp:Label runat="Server" ID="lblFraudReportNumber"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="6" align="left">
                                                                                            <asp:Button runat="server" ID="btnViewAuditFraud_View" Text="View Audit Trail" CausesValidation="false"
                                                                                                Visible="false" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlViewWitnesses" runat="server" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Witnesses
                                                </div>
                                                <asp:UpdatePanel runat="Server" ID="UpdatePanel4">
                                                    <ContentTemplate>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td colspan="6">
                                                                    <asp:GridView ID="gvWitnessesView" runat="server" DataKeyNames="PK_DPD_Witness_ID"
                                                                        AutoGenerateColumns="false" Width="100%" AllowSorting="false" OnRowCreated="gvWitnessesView_RowCreated"
                                                                        OnRowCommand="gvWitnessesView_RowCommand">
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
                                                                            <asp:TemplateField HeaderText="View">
                                                                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton runat="server" ID="lnkViewWitness" CommandName="View" Text="View" CausesValidation="false"></asp:LinkButton>
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
                                                            <tr>
                                                                <td colspan="6">
                                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%" style="display: none;" runat="server" id="trWitness">
                                                                        <tr>
                                                                            <td align="left">Name
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left" colspan="4">
                                                                                <asp:Label runat="server" ID="lblWitness_Name"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" style="width: 18%">Address
                                                                            </td>
                                                                            <td align="center" style="width: 4%">:
                                                                            </td>
                                                                            <td align="left" colspan="4">
                                                                                <asp:Label runat="server" ID="lblWitness_Address"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">Phone
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left" colspan="4">
                                                                                <asp:Label runat="server" ID="lblWitness_Phone"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="6" align="left">
                                                                                <asp:Button runat="server" ID="btnViewAuditWitness_View" Text="View Audit Trail"
                                                                                    ToolTip="View Audit Trail" CausesValidation="false" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlViewComments" runat="server" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Comments and Attachments
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" style="width: 18%" valign="top">Comments
                                                        </td>
                                                        <td align="center" style="width: 4%" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="lblComments" runat="server" MaxLength="4000" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Attachments
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <uc:ctrlAttachmentDetails ID="CtrlViewAttachDetails" runat="Server" ShowAttachmentType="true" ModeofPage="viewmode" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <div align="center" style="width: 100%;">
                                                <asp:Button runat="server" ID="btnAuditView" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();"
                                                    ToolTip="View Audit Trail" CausesValidation="false" />
                                                &nbsp;&nbsp;
                                                <asp:Button runat="server" ID="btnSendMail" Text="Resend First Report" ToolTip="Resend First Report"
                                                    CausesValidation="false" OnClick="btnSendMail_Click" Width="160px" OnClientClick="" />
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    <script language="javascript" type="text/javascript">
        //used to get height of scrollbar and add to total screen height +  scollbar height
        function getScrollHeight() {
            var h = window.pageYOffset ||
                    document.body.scrollTop ||
                    document.documentElement.scrollTop;
            document.getElementById('divProgress').style.height = screen.height + h;
            document.getElementById('ProgressTable').style.height = screen.height + h;
        }
    </script>

    <script language="javascript" type="text/javascript">
        window.onscroll = getScrollHeight;
    </script>

    <script type="text/javascript">
        function ValidateFields(sender, args) {
            var msg = '';
            var index;
            index = sender.id.replace('ctl00_ContentPlaceHolder1_CustomValidator', '').trim();
            var ctrlIDs = document.getElementById('ctl00_ContentPlaceHolder1_hdnControlIDs' + index).value.split(',');
            var Messages = document.getElementById('ctl00_ContentPlaceHolder1_hdnErrorMsgs' + index).value.split(',');

            if (index == 12) {
                if (document.getElementById('<%=lblAsteriskCause.ClientID %>').style.display == "inline-block") {
                    var lstCause = document.getElementById('<%=lstCauseOfLoss.ClientID%>');
                    var cnt = 0;
                    for (var i = 0; i < lstCause.options.length; i++) {
                        if (lstCause.options[i].selected) cnt++;
                    }
                    if (cnt == 0)
                        msg = (msg.length > 0 ? "- " : "") + "Please select [Loss Information]/Cause of Loss to Sonic Inventory" + "\n";
                }
            }
            //MVA – Damage (Multiple Vehicle) 
            if (document.getElementById('ctl00_ContentPlaceHolder1_hdnControlIDs' + index).value != "") {
                if (index == 6) {
                    var i = 0;
                    for (i = 0; i < ctrlIDs.length; i++) {
                        var bEmpty = false;
                        var ctrl = document.getElementById(ctrlIDs[i]);
                        if (ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txtMVA_MultiDamage_Estimate' || ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txtMVA_MultiRecovered_Amount') {
                            switch (ctrl.type) {
                                case "text": if (ctrl.value == '') bEmpty = true; break;
                            }
                            if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                        }
                        else if (ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txtMVA_MultiName_Yes' || ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txtMVA_MultiAddress_Yes' ||
                            ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txtMVA_MultiPhone_Yes') {
                            var ctl5_1 = document.getElementById('<%=rdoMVA_MultiDriven_By_Associate.ClientID %>');
                            rdo = document.getElementById(ctl5_1.id + "_0");
                            if (rdo.checked == true) {
                                switch (ctrl.type) {
                                    case "text": if (ctrl.value == '') bEmpty = true; break;
                                }
                                if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                            }
                        }
                        else if (ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txtMVA_MultiDescription_Of_Citation_txtNote') {
                            var ctl5_2 = document.getElementById('<%=rdoMVA_MultiAssociate_Cited.ClientID %>');
                            rdo = document.getElementById(ctl5_2.id + "_0");
                            if (rdo.checked == true) {
                                switch (ctrl.type) {
                                    case "textarea": if (ctrl.value == '') bEmpty = true; break;
                                }
                                if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                            }
                        }
                        else if (ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txtMVA_MultiDrug_test_results_txtNote' || ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txtMVA_MultiDrug_test_explanation_txtNote') {
                            var ctl5_3 = document.getElementById('<%=rdoMVA_MultiDrug_test_performed.ClientID %>');
                        rdo = document.getElementById(ctl5_3.id + "_0");
                        rdo1 = document.getElementById(ctl5_3.id + "_1");
                        if (rdo.checked == true && ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txtMVA_MultiDrug_test_results_txtNote') {
                            switch (ctrl.type) {
                                case "textarea": if (ctrl.value == '') bEmpty = true; break;
                            }
                            if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                        }
                        else if (rdo1.checked == true && ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txtMVA_MultiDrug_test_explanation_txtNote') {
                            switch (ctrl.type) {
                                case "textarea": if (ctrl.value == '') bEmpty = true; break;
                            }
                            if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                        }
                    }
                    else if (ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txtMVA_MultiName_No' || ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txtMVA_MultiAddress_No' ||
                        ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txtMVA_MultiPhone_No') {
                        var ctl5_4 = document.getElementById('<%=rdoMVA_MultiVehicle_Driven_By_Customer.ClientID %>');
                        rdo = document.getElementById(ctl5_4.id + "_0");
                        if (rdo.checked == true) {
                            switch (ctrl.type) {
                                case "text": if (ctrl.value == '') bEmpty = true; break;
                            }
                            if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                        }
                    }
                    else if (ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txtMVA_MultiNot_Driven_By_Customer_Explain_txtNote') {
                        var ctl5_5 = document.getElementById('<%=rdoMVA_MultiVehicle_Driven_By_Customer.ClientID %>');
                        rdo = document.getElementById(ctl5_5.id + "_1");
                        if (rdo.checked == true) {
                            switch (ctrl.type) {
                                case "textarea": if (ctrl.value == '') bEmpty = true; break;
                            }
                            if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                        }
                    }
                    else if (ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txtMVA_MultiPass_Name' || ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txtMVA_MultiPass_Address_1' ||
                        ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txtMVA_MultiPass_Address_2' || ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txtMVA_MultiPass_Phone' ||
                        ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txtMVA_MultiPass_City' || ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_ddlMVA_MultiPass_State' ||
                        ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txtMVA_MultiPass_Zip') {
                        var ctl5_6 = document.getElementById('<%=rdoMVA_MultiAdditional_passengers.ClientID %>');
            rdo = document.getElementById(ctl5_6.id + "_0");
            if (rdo.checked == true) {
                switch (ctrl.type) {
                    case "textarea":
                    case "text": if (ctrl.value == '') bEmpty = true; break;
                    case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                }
                if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
            }
        }
        else if (ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txtMVA_MultiTPI_Carrier_name' || ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txtMVA_Multitpi_contact' ||
            ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txtMVA_MultiTPI_Policy_number' || ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txtMVA_Multitpi_phone' ||
            ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txtMVA_Multitpi_address_1' || ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txtMVA_Multitpi_address_2' ||
            ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txtMVA_Multitpi_City' || ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_ddlMVA_Multitpi_State' ||
            ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txtMVA_Multitpi_Zip_Code') {
            var ctl5_7 = document.getElementById('<%=rdoMVA_MultiSeeking_subrogation.ClientID %>');
                                rdo = document.getElementById(ctl5_7.id + "_0");
                                if (rdo.checked == true) {
                                    switch (ctrl.type) {
                                        case "textarea":
                                        case "text": if (ctrl.value == '') bEmpty = true; break;
                                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                                    }
                                    if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                                }
                            }
                            else {
                                switch (ctrl.type) {
                                    case "textarea":
                                    case "text": if (ctrl.value == '') bEmpty = true; break;
                                    case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                                    case "select-multiple": if (ctrl.selectedIndex == -1) bEmpty = true; break;
                                }
                                if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                            }
}
}
else {
    var i = 0;
    for (i = 0; i < ctrlIDs.length; i++) {
        var bEmpty = false;
        var ctrl = document.getElementById(ctrlIDs[i]);
        if (ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txtTheft_Damage_estimate') {
            var ctl1 = document.getElementById('<%=rdo_Vehicle_Recovered.ClientID %>');
            rdo = document.getElementById(ctl1.id + "_0");
            if (rdo.checked == true) {
                switch (ctrl.type) {
                    case "textarea":
                    case "text": if (ctrl.value == '') bEmpty = true; break;
                    case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                    case "select-multiple": if (ctrl.selectedIndex == -1) bEmpty = true; break;
                }
                if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
            }
        }
        else if (ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txtFraud_Damage_estimate') {
            var ctl2 = document.getElementById('<%=rdo_Vehicle_Recovered.ClientID %>');
            rdo = document.getElementById(ctl2.id + "_0");
            if (rdo.checked == true) {
                switch (ctrl.type) {
                    case "textarea":
                    case "text": if (ctrl.value == '') bEmpty = true; break;
                    case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                    case "select-multiple": if (ctrl.selectedIndex == -1) bEmpty = true; break;
                }
                if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
            }
        }
        else if (ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txt_Storage_Address_1' || ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txt_Storage_Contact' ||
      ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txt_Storage_Address_2' || ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txt_Storage_phone' || ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txt_Storage_City' ||
      ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txt_Storage_cost' || ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_ddl_Storage_State' || ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txt_storage_Zip_Code') {
            var ctl3 = document.getElementById('<%=rdoVehicle_In_Storage.ClientID %>');
            rdo = document.getElementById(ctl3.id + "_0");
            if (rdo.checked == true) {
                switch (ctrl.type) {
                    case "textarea":
                    case "text": if (ctrl.value == '') bEmpty = true; break;
                    case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                    case "select-multiple": if (ctrl.selectedIndex == -1) bEmpty = true; break;
                }
                if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
            }
        }
        else if (ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txtReportNumber') {
            var ctl5 = document.getElementById('<%=rdoPoliceNotified.ClientID %>');
                rdo = document.getElementById(ctl5.id + "_0");
                if (rdo.checked == true) {
                    switch (ctrl.type) {
                        case "textarea":
                        case "text": if (ctrl.value == '') bEmpty = true; break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                        case "select-multiple": if (ctrl.selectedIndex == -1) bEmpty = true; break;
                    }
                    if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                }
            }
            else {
                switch (ctrl.type) {
                    case "textarea":
                    case "text": if (ctrl.value == '') bEmpty = true; break;
                    case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                    case "select-multiple": if (ctrl.selectedIndex == -1) bEmpty = true; break;
                }
                if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
            }
}
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

    if (msg.length > 0) {
        sender.errormessage = msg;
        args.IsValid = false;
    }
    else
        args.IsValid = true;
}
    </script>

</asp:Content>
