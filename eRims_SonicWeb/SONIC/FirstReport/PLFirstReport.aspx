<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="PLFirstReport.aspx.cs"
    Inherits="SONIC_PLFirstReport" Title="eRIMS Sonic :: First Report :: Premises Liability" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachments/Attachment.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/AttachmentDetails/AttachmentDetails.ascx" TagName="ctrlAttachmentDetails"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/SONICtab/SonicTab.ascx" TagName="CtlSonicTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/SONICInfo/SonicInfo.ascx" TagName="CtlSonicInfo" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Date_Validation.js"></script>
      <script type="text/javascript" language="javascript" src="../../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery.maskedinput.js"></script>
    <script language="javascript" type="text/javascript">

        function ConfirmDelete() {
            return confirm("Are you sure that you want to remove the data that was selected for deletion?");
        }
        //OPen Audit Popup
        function AuditPopUp() {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;

            obj = window.open("AuditPopup_PLFirstReport.aspx?id=" + '<%=ViewState["PK_PL_FR_ID"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }
        //check Date Validation
        function CheckDate(sender, args) {
            args.IsValid = (ValidateDate(args.Value));
            return args.IsValid;
        }
        ///used to fire all the function that are used to dispply/hide associate panels.
        function FireAll() {
            CheckPoliceNotified();
            checkInjured_AdmittedHospital();
        }
        //Check all Validation
        function CheckAllValidation() {

            //Check all Validation
            if (CheckLossInformation() == true &&
            CheckValidationContactsInfo() == true &&
            CheckPropertyInformation() == true && CheckProductInformation() == true &&
            CheckWitnessInformation() == true && CheckInjuryInformation() == true
            && Page_ClientValidate("vsCommentGroup")) {
                return true;
            }
            else
                return false;
        }

        function CheckInjuryInformation() {

            if (document.getElementById('<%=txtInjured_Work_Phone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtInjured_Work_Phone.ClientID%>').value = "";

            if (document.getElementById('<%=txtInjured_Home_Phone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtInjured_Home_Phone.ClientID%>').value = "";

            if (document.getElementById('<%=txtInjured_Alternate_Telephone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtInjured_Alternate_Telephone.ClientID%>').value = "";

            var rdbInjury = document.getElementById('ctl00_ContentPlaceHolder1_rdoPersonal_Bodily_Injury_0');
            if (rdbInjury.checked) {
                //used to check validate page for passd Validation Group
                if (Page_ClientValidate("vsInjuryInfoGroup")) {
                    return true;
                }
                else
                    return false;
            }
            else
                return true;
        }

        function CheckProductInformation() {

            var rdbProduct = document.getElementById('ctl00_ContentPlaceHolder1_rdoProduct_Involved_0');
            if (rdbProduct.checked) {
                //used to check validate page for passd Validation Group
                if (Page_ClientValidate("vsProductGroup")) {
                    return true;
                }
                else
                    return false;
            }
            else
                return true;
        }

        //check validation for Witness Information Panel
        function CheckWitnessInformation() {
            //check value if it is "___-___-____" than convert it to ""
            if (document.getElementById('<%=txtWitness_Home_Phone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtWitness_Home_Phone.ClientID%>').value = "";
            //check value if it is "___-___-____" than convert it to ""
            if (document.getElementById('<%=txtWitness_Work_Phone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtWitness_Work_Phone.ClientID%>').value = "";
            //check value if it is "___-___-____" than convert it to ""
            if (document.getElementById('<%=txtWitness_Alternate_Phone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtWitness_Alternate_Phone.ClientID%>').value = "";

            var rdbWitness = document.getElementById('ctl00_ContentPlaceHolder1_rdoWitnesses_0');
            if (rdbWitness.checked) {
                //used to check validate page for passd Validation Group
                if (Page_ClientValidate("vsWitnessInfoGroup")) {
                    return true;
                }
                else
                    return false;
            }
            else
                return true;
        }
        //Used to check validation for Property Information Panel
        function CheckPropertyInformation() {
            //check value if it is "___-___-____" than convert it to ""
            if (document.getElementById('<%=txtOwner_Work_Telephone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtOwner_Work_Telephone.ClientID%>').value = "";
            //check value if it is "___-___-____" than convert it to ""
            if (document.getElementById('<%=txtOwner_Home_Telephone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtOwner_Home_Telephone.ClientID%>').value = "";
            //check value if it is "___-___-____" than convert it to ""
            if (document.getElementById('<%=txtOwner_Alternate_Telephone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtOwner_Alternate_Telephone.ClientID%>').value = "";
            //check value if it is "___-___-____" than convert it to ""
            if (document.getElementById('<%=txtEstimator_Phone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtEstimator_Phone.ClientID%>').value = "";

            var rdbProperty = document.getElementById('ctl00_ContentPlaceHolder1_rdoProperty_Damage_0');
            if (rdbProperty.checked) {
                //used to check validate page for passd Validation Group
                if (Page_ClientValidate("vsPropertyInfoGroup")) {
                    return true;
                }
                else
                    return false;
            }
            else
                return true;

        }

        //used to check validation for Loss Information Panel
        function CheckLossInformation() {
            //check value if it is "___-___-____" than convert it to ""
            if (document.getElementById('<%=txtPolice_telephone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtPolice_telephone.ClientID%>').value = "";
            //if time is "__:__" than set it to ""
            if (document.getElementById('<%=txtTime_Of_Loss.ClientID%>').value == "__:__")
                document.getElementById('<%=txtTime_Of_Loss.ClientID%>').value = "";
            //if time is containing "a" or "p" or "A" or "P" work than prompt the alert message and blank time value
            if (document.getElementById('<%=txtTime_Of_Loss.ClientID%>').value.indexOf("a") > 0 || document.getElementById('<%=txtTime_Of_Loss.ClientID%>').value.indexOf("A") > 0
            || document.getElementById('<%=txtTime_Of_Loss.ClientID%>').value.indexOf("p") > 0 || document.getElementById('<%=txtTime_Of_Loss.ClientID%>').value.indexOf("P") > 0) {
                alert('Invalid Time of Incident.');
                document.getElementById('<%=txtTime_Of_Loss.ClientID%>').value = "";
                return false;
            }
            //used to check validate page for passd Validation Group
            if (Page_ClientValidate("vsLossInfoGroup")) {
                return true;
            }
            else
                return false;
        }
        //used to check Validation for COntact Information Panel
        function CheckValidationContactsInfo() {
            //check value if it is "___-___-____" than convert it to ""
            if (document.getElementById('<%=txtContactFaxNumber.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtContactFaxNumber.ClientID%>').value = "";
            //if time is "__:__" than set it to ""
            if (document.getElementById('<%=txtContact_Best_Time.ClientID%>').value == "__:__")
                document.getElementById('<%=txtContact_Best_Time.ClientID%>').value = "";
            //if time is containing "a" or "p" or "A" or "P" work than prompt the alert message and blank time value
            if (document.getElementById('<%=txtContact_Best_Time.ClientID%>').value.indexOf("a") > 0 || document.getElementById('<%=txtContact_Best_Time.ClientID%>').value.indexOf("A") > 0
            || document.getElementById('<%=txtContact_Best_Time.ClientID%>').value.indexOf("p") > 0 || document.getElementById('<%=txtContact_Best_Time.ClientID%>').value.indexOf("P") > 0) {
                alert('Invalid When to Contact Time.');
                document.getElementById('<%=txtContact_Best_Time.ClientID%>').value = "";
                document.getElementById('<%=txtContact_Best_Time.ClientID%>').focus();
                return false;
            }
            //used to check validate page for passd Validation Group
            if (Page_ClientValidate("vsContactInfoGroup")) {
                return true;
            }
            else
                return false;
        }
        //check Injured_AdmittedHospiatl radio button is selected true or not.as per answer,display/Hide Informaiton.
        function checkInjured_AdmittedHospital() {
            ctl = document.getElementById('<%=rdoInjured_Admitted_to_Hospital.ClientID %>');
            rdo = document.getElementById(ctl.id + "_0");
            if (rdo.checked == true) {
                document.getElementById('<%=tdInjury_DateAdmitted.ClientID %>').style.display = "";
                document.getElementById('<%=tdInjury_StillHospital.ClientID %>').style.display = "";
            }
            else {
                document.getElementById('<%=tdInjury_DateAdmitted.ClientID %>').style.display = "none";
                document.getElementById('<%=tdInjury_StillHospital.ClientID %>').style.display = "none";
                var Val = document.getElementById('<%=hdnInjury.ClientID%>').value;
                //check value of variable if it is 1 than blank related fields else remain as it is.
                if (Val != '1') {
                    document.getElementById('<%=txtInjured_Date_Admitted_to_Hospital.ClientID %>').value = "";
                    //document.getElementById('<%=rdoInjured_Still_in_Hospital.ClientID %>').options[document.getElementById("<%=rdoInjured_Still_in_Hospital.ClientID %>").selectedIndex].value="-1";
                }
            }
        }
        //check Police Notification  radio button is selected true or not.as per answer,display/Hide Informaiton.
        function CheckPoliceNotified() {
            ctl = document.getElementById('<%=rdoWere_Police_Notified.ClientID %>');
            rdo = document.getElementById(ctl.id + "_0");
            if (rdo.checked == true) {
                document.getElementById('<%=trLossPoliceNotified.ClientID %>').style.display = "";
            }
            else {
                var Val = document.getElementById('<%=hdnPoliceNotify.ClientID%>').value;
                if (Val != '1') {
                    document.getElementById('<%=txtPolice_Organization.ClientID %>').value = "";
                    document.getElementById('<%=txtCase_Number.ClientID %>').value = "";
                    document.getElementById('<%=txtPolice_telephone.ClientID %>').value = "";
                }
                document.getElementById('<%=trLossPoliceNotified.ClientID %>').style.display = "none";
            }
        }
        //used to display the menu as per passed values
        //Ctl = Control id
        // i = Menu number
        
        function CheckMenu(ctl, i) {
            var rdo = document.getElementById(ctl.id + "_0");
            var tb = document.getElementById("PLMenu" + i);
           
            //check radio button is check or not.if yes than that menu is displayed else remains hidden.
            if (rdo.checked == true) {
                tb.style.display = "";
            }
            else {
                tb.style.display = "none";
            }
        }
        //Used to Set Menu Style
        function SetMenuStyle(index) {
            var i;
            for (i = 1; i <= 7; i++) {
                var tb = document.getElementById("PLMenu" + i);
                //if passed Index value equal to i than set this menu to active and change display style of active menu
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
        //Used to shown panel as per passed index number.
        function ShowPanel(index) {

            SetMenuStyle(index);
            var op = '<%=strPageOpeMode%>';
            //used to checl opertion mode of Page. if it is View than display Page in view mode. else in Edit MOde
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
                    document.getElementById("<%=pnlProductLiability.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlInjury.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlProperty.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlWitnesses.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlComments.ClientID%>").style.display = "none";
                }
                //check if index is 2 than display Loss Section.
                if (index == 2) {
                    document.getElementById("<%=pnlLocation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlLossInformation.ClientID%>").style.display = "";
                    document.getElementById("<%=pnlProductLiability.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlInjury.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlProperty.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlWitnesses.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlComments.ClientID%>").style.display = "none";
                }
                //check if index is 3 than display Product Liability Section.
                if (index == 3) {
                    document.getElementById("<%=pnlLocation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlLossInformation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlProductLiability.ClientID%>").style.display = "";
                    document.getElementById("<%=pnlInjury.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlProperty.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlWitnesses.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlComments.ClientID%>").style.display = "none";
                }
                //check if index is 4 than display Injury Section.
                if (index == 4) {
                    document.getElementById("<%=pnlLocation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlLossInformation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlProductLiability.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlInjury.ClientID%>").style.display = "";
                    document.getElementById("<%=pnlProperty.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlWitnesses.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlComments.ClientID%>").style.display = "none";
                }
                //check if index is 5 than display Property Section.
                if (index == 5) {
                    document.getElementById("<%=pnlLocation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlLossInformation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlProductLiability.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlInjury.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlProperty.ClientID%>").style.display = "";
                    document.getElementById("<%=pnlWitnesses.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlComments.ClientID%>").style.display = "none";
                }
                //check if index is 6 than display Witness Section.
                if (index == 6) {
                    document.getElementById("<%=pnlLocation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlLossInformation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlProductLiability.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlInjury.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlProperty.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlWitnesses.ClientID%>").style.display = "";
                    document.getElementById("<%=pnlComments.ClientID%>").style.display = "none";
                }
                //check if index is 7 than display Comments and attachment Section.
                if (index == 7) {
                    document.getElementById("<%=pnlLocation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlLossInformation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlProductLiability.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlInjury.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlProperty.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlWitnesses.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlComments.ClientID%>").style.display = "";
                }
            }

            document.getElementById("<%=hdnCureentPanel.ClientID%>").value = index;
        }
        //used this function while page mode in view Mode
        function ShowPanelView(index) {
            //set Menu style
            SetMenuStyle(index);
            //check if Index is 1 than display Location section in View Mode.
            if (index == 1) {
                document.getElementById("<%=pnlViewLocation.ClientID%>").style.display = "";
                document.getElementById("<%=pnlViewLossInformation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewProductLiability.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewInjury.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewProperty.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewWitnesses.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewComments.ClientID%>").style.display = "none";
            }
            //check if Index is 2 than display Loss section in View Mode.
            if (index == 2) {
                document.getElementById("<%=pnlViewLocation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewLossInformation.ClientID%>").style.display = "";
                document.getElementById("<%=pnlViewProductLiability.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewInjury.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewProperty.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewWitnesses.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewComments.ClientID%>").style.display = "none";
            }
            //check if Index is 3 than display Product Liability section in View Mode.
            if (index == 3) {
                document.getElementById("<%=pnlViewLocation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewLossInformation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewProductLiability.ClientID%>").style.display = "";
                document.getElementById("<%=pnlViewInjury.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewProperty.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewWitnesses.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewComments.ClientID%>").style.display = "none";
            }
            //check if Index is 4 than display Injury section in View Mode.
            if (index == 4) {
                document.getElementById("<%=pnlViewLocation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewLossInformation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewProductLiability.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewInjury.ClientID%>").style.display = "";
                document.getElementById("<%=pnlViewProperty.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewWitnesses.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewComments.ClientID%>").style.display = "none";
            }
            //check if Index is 5 than display Property section in View Mode.
            if (index == 5) {
                document.getElementById("<%=pnlViewLocation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewLossInformation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewProductLiability.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewInjury.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewProperty.ClientID%>").style.display = "";
                document.getElementById("<%=pnlViewWitnesses.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewComments.ClientID%>").style.display = "none";
            }
            //check if Index is 6 than display Witness section in View Mode.
            if (index == 6) {
                document.getElementById("<%=pnlViewLocation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewLossInformation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewProductLiability.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewInjury.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewProperty.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewWitnesses.ClientID%>").style.display = "";
                document.getElementById("<%=pnlViewComments.ClientID%>").style.display = "none";
            }
            //check if Index is 7 than display Comments section in View Mode.
            if (index == 7) {
                document.getElementById("<%=pnlViewLocation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewLossInformation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewProductLiability.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewInjury.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewProperty.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewWitnesses.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewComments.ClientID%>").style.display = "";
            }
        }

        function ValidateFieldsLocation(sender, args) {

            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnControlIDsLocation.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnErrorMsgsLocation.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnControlIDsLocation.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {
                        case "textarea":
                        case "text":
                            if (ctrl.value == '') bEmpty = true; break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                        case "select-multiple": if (ctrl.selectedIndex == -1) bEmpty = true; break;
                    }
                    if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
                    if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                }
                if (msg.length > 0) {
                    //sender.errormessage = msg;
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

        function ValidateFieldsLossInfo(sender, args) {

            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnControlIDsLossInfo.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnErrorMsgsLossInfo.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnControlIDsLossInfo.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {
                        case "textarea":
                        case "text":
                            if (ctrl.value == '') {
                                if (ctrl.id == 'ctl00_ContentPlaceHolder1_txtPolice_Organization' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtCase_Number' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtPolice_telephone') {
                                    var rdbSecCam = document.getElementById('ctl00_ContentPlaceHolder1_rdoWere_Police_Notified_0');
                                    //used to check dropdowns selected value. if it is equal to Disposed than display Disposal type control else hide.
                                    if (rdbSecCam.checked)
                                        bEmpty = true;
                                }
                                else
                                    bEmpty = true;
                            }
                            break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                        case "select-multiple": if (ctrl.selectedIndex == -1) bEmpty = true; break;
                    }
                    if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
                    if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                }
                if (msg.length > 0) {
                    //sender.errormessage = msg;
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

        function ValidateFieldsComments(sender, args) {

            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnControlIDsComments.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnErrorMsgsComments.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnControlIDsComments.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {
                        case "textarea":
                        case "text":
                            if (ctrl.value == '') bEmpty = true; break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                        case "select-multiple": if (ctrl.selectedIndex == -1) bEmpty = true; break;
                    }
                    if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
                    if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                }
                if (msg.length > 0) {
                    //sender.errormessage = msg;
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

        function ValidateFieldsInjury(sender, args) {
            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnControlIDsInjury.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnErrorMsgsInjury.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnControlIDsInjury.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {
                        case "textarea":
                        case "text":
                            if (ctrl.value == '') {
                                if (ctrl.id == 'ctl00_ContentPlaceHolder1_txtInjured_Date_Admitted_to_Hospital') {
                                    var rdbHospital = document.getElementById('ctl00_ContentPlaceHolder1_rdoInjured_Admitted_to_Hospital_0');
                                    //used to check dropdowns selected value. if it is equal to Disposed than display Disposal type control else hide.
                                    if (rdbHospital.checked)
                                        bEmpty = true;
                                }
                                else
                                    bEmpty = true;
                            } break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                        case "select-multiple": if (ctrl.selectedIndex == -1) bEmpty = true; break;
                    }
                    if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
                    if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                }
                if (msg.length > 0) {
                    //sender.errormessage = msg;
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

        function ValidateFieldsProduct(sender, args) {

            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnControlIDsProduct.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnErrorMsgsProduct.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnControlIDsProduct.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {
                        case "textarea":
                        case "text":
                            if (ctrl.value == '') bEmpty = true; break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                        case "select-multiple": if (ctrl.selectedIndex == -1) bEmpty = true; break;
                    }
                    if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
                    if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                }
                if (msg.length > 0) {
                    //sender.errormessage = msg;
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

        function ValidateFieldsProperty(sender, args) {

            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnControlIDsProperty.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnErrorMsgsProperty.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnControlIDsProperty.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {
                        case "textarea":
                        case "text":
                            if (ctrl.value == '') bEmpty = true; break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                        case "select-multiple": if (ctrl.selectedIndex == -1) bEmpty = true; break;
                    }
                    if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
                    if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                }
                if (msg.length > 0) {
                    //sender.errormessage = msg;
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

        function ValidateFieldsWitness(sender, args) {

            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnControlIDsWitness.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnErrorMsgsWitness.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnControlIDsWitness.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {
                        case "textarea":
                        case "text":
                            if (ctrl.value == '') bEmpty = true; break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                        case "select-multiple": if (ctrl.selectedIndex == -1) bEmpty = true; break;
                    }
                    if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
                    if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                }
                if (msg.length > 0) {
                    //sender.errormessage = msg;
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

         jQuery(function ($) {
                    $("#<%=txtDate_Of_Loss.ClientID%>").mask("99/99/9999");
                    $("#<%=txtContactFaxNumber.ClientID%>").mask("999-999-9999");
                    $("#<%=txtContact_Best_Time.ClientID%>").mask("99:99");
                    $("#<%=txtTime_Of_Loss.ClientID%>").mask("99:99");
                    $("#<%=txtDate_Reported_To_Sonic.ClientID%>").mask("99/99/9999");
                    $("#<%=txtPolice_telephone.ClientID%>").mask("999-999-9999");
                    $("#<%=txtInjured_Work_Phone.ClientID%>").mask("999-999-9999");
                    $("#<%=txtInjured_Home_Phone.ClientID%>").mask("999-999-9999");
                    $("#<%=txtInjured_Alternate_Telephone.ClientID%>").mask("999-999-9999");
                    $("#<%=txtInjured_Date_of_Initial_Treatment.ClientID%>").mask("99/99/9999");
                    $("#<%=txtInjured_Date_Admitted_to_Hospital.ClientID%>").mask("99/99/9999");
                    $("#<%=txtEstimator_Phone.ClientID%>").mask("999-999-9999");
                    $("#<%=txtOwner_Work_Telephone.ClientID%>").mask("999-999-9999");
                    $("#<%=txtOwner_Home_Telephone.ClientID%>").mask("999-999-9999");
                    $("#<%=txtOwner_Alternate_Telephone.ClientID%>").mask("999-999-9999");
                    $("#<%=txtWitness_Home_Phone.ClientID%>").mask("999-999-9999");
                    $("#<%=txtWitness_Alternate_Phone.ClientID%>").mask("999-999-9999");
            });
    </script>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Location/Contact Panel:" BorderWidth="1"
            BorderColor="DimGray" ValidationGroup="vsContactInfoGroup" CssClass="errormessage">
        </asp:ValidationSummary>
        <asp:ValidationSummary ID="vsLossInfo" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Loss Information Panel:" BorderWidth="1"
            BorderColor="DimGray" ValidationGroup="vsLossInfoGroup" CssClass="errormessage">
        </asp:ValidationSummary>
        <asp:ValidationSummary ID="vsInjuryInfo" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Injury Information Panel:" BorderWidth="1"
            BorderColor="DimGray" ValidationGroup="vsInjuryInfoGroup" CssClass="errormessage">
        </asp:ValidationSummary>
        <asp:ValidationSummary ID="vsPropertyInfo" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Property Information Panel:" BorderWidth="1"
            BorderColor="DimGray" ValidationGroup="vsPropertyInfoGroup" CssClass="errormessage">
        </asp:ValidationSummary>
        <asp:ValidationSummary ID="vsWitnessInfo" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Witness Information Panel:" BorderWidth="1"
            BorderColor="DimGray" ValidationGroup="vsWitnessInfoGroup" CssClass="errormessage">
        </asp:ValidationSummary>
        <asp:ValidationSummary ID="vsAttchments" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Attachment:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="AddAttachment" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsComment" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Comments/Attachment Panel:" BorderWidth="1"
            BorderColor="DimGray" ValidationGroup="vsCommentGroup" CssClass="errormessage">
        </asp:ValidationSummary>
        <asp:ValidationSummary ID="vsProduct" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Product Panel:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsProductGroup" CssClass="errormessage"></asp:ValidationSummary>
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
                        <td class="Spacer" style="height: 15px;" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" colspan="2">
                            <asp:UpdatePanel runat="server" ID="updSonicInfo" UpdateMode="Always">
                                <ContentTemplate>
                                    <uc:CtlSonicInfo runat="server" ID="SonicInfo" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" style="height: 15px;" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td class="leftMenu">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="height: 18px;" class="Spacer">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100%">
                                       
                                             <table cellpadding="5" cellspacing="0" width="100%" >
                                                 <tr id="PLMenu1" onclick="javascript:ShowPanel(1);">
                                                    <td align="left" valign="top">
                                                        <span >Location/Contact</span>&nbsp;
                                                        <span id="MenuAsterisk1" runat="server" style="color: Red;display:none">*</span>
                                                    </td>
                                                </tr>
                                                <tr id="PLMenu2" onclick="javascript:ShowPanel(2);" >
                                                    <td align="left">
                                                        <span >Loss Information
                                                        </span>&nbsp;<span id="MenuAsterisk2" runat="server" style="color: Red;display:none">*</span>
                                                    </td>
                                                </tr>
                                                <tr id="PLMenu3" onclick="javascript:ShowPanel(3);" >
                                                    <td align="left">
                                                        <span >Product
                                                        </span>&nbsp;<span id="MenuAsterisk3" runat="server" style="color: Red;display:none">*</span>
                                                    </td>
                                                </tr>
                                                <tr id="PLMenu4" onclick="javascript:ShowPanel(4);">
                                                    <td align="left">
                                                        <span  >Injury
                                                        </span>&nbsp;<span id="MenuAsterisk4" runat="server" style="color: Red;display:none">*</span>
                                                    </td>
                                                </tr>
                                                <tr id="PLMenu5" onclick="javascript:ShowPanel(5);">
                                                    <td align="left">
                                                        <span  >Property
                                                        </span>&nbsp;<span id="MenuAsterisk5" runat="server" style="color: Red;display:none">*</span>
                                                    </td>
                                                </tr>
                                                <tr id="PLMenu6" onclick="javascript:ShowPanel(6);">
                                                    <td align="left">
                                                        <span  >Witness
                                                        </span>&nbsp;<span id="MenuAsterisk6" runat="server" style="color: Red;display:none">*</span>
                                                    </td>
                                                </tr>
                                                <tr id="PLMenu7" onclick="javascript:ShowPanel(7);">
                                                    <td align="left">
                                                        <span  >Comments <br /><br /> Attachments
                                                        </span>&nbsp;<span id="MenuAsterisk7" runat="server" style="color: Red;display:none">*</span>
                                                    </td>
                                                </tr>
                                                
                                            </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 5px;" class="Spacer">
                                    </td>
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
                            </table>
                        </td>
                        <td valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td style="width: 5px">
                                        &nbsp;
                                    </td>
                                    <td style="width: 794px" valign="top" class="dvContainer">
                                        <div id="dvEdit" runat="server" style="width: 100%;">
                                            <asp:Panel ID="pnlLocation" runat="server" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Location Information</div>
                                                <asp:UpdatePanel runat="server" ID="updLocation">
                                                    <ContentTemplate>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" width="18%">
                                                                    Location Number
                                                                </td>
                                                                <td align="center" width="4%">
                                                                    :
                                                                </td>
                                                                <td align="left" width="26%">
                                                                    <asp:DropDownList runat="server" ID="ddlLocationNumber" SkinID="ddlSONIC">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left" width="18%">
                                                                    Location d/b/a
                                                                </td>
                                                                <td align="center" width="2%">
                                                                    :
                                                                </td>
                                                                <td align="left" width="30%">
                                                                    <asp:DropDownList runat="server" ID="ddlLocationdba" SkinID="default" Width="90%">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Legal Entity
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList runat="server" ID="ddlLegalEntity" SkinID="ddlSONIC">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left">
                                                                    Location f/k/a
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddlLocationfka" SkinID="ddlSONIC" runat="server">
                                                                    </asp:DropDownList>
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
                                                                    <asp:TextBox ID="txtLocationAddress1" Width="170px" runat="server" MaxLength="50">
                                                                    </asp:TextBox>
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
                                                                    <asp:TextBox ID="txtLocationAddress2" Width="170px" runat="server" MaxLength="50">
                                                                    </asp:TextBox>
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
                                                                    <asp:TextBox ID="txtLocationCity" runat="server" Width="170px" MaxLength="30"></asp:TextBox>
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
                                                                    <asp:TextBox runat="server" ID="txtLocationState" Width="170px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Zip Code
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox ID="txtLocationZipCode" runat="server" Width="170px" MaxLength="10"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <div class="bandHeaderRow">
                                                            Contact Information</div>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" width="18%">
                                                                    Dealership/Collision Center
                                                                </td>
                                                                <td align="center" width="4%">
                                                                    :
                                                                </td>
                                                                <td width="28%" align="left">
                                                                    <asp:TextBox runat="server" ID="txtCostCenterdba" Width="170px"></asp:TextBox>
                                                                </td>
                                                                <td align="left" width="18%">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left" width="4%">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left" width="28%">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Contact Name
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtContactName" Width="170px"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    Address 1
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtCostCenterAddress1" Width="170px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    When to Contact&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtContact_Best_Time" Width="170px"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revtxtContact_Best_Time" runat="server" ControlToValidate="txtContact_Best_Time"
                                                                     ValidationExpression="^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$"
                                                                     ErrorMessage="When to Contact is invalid." Display="none" ValidationGroup="vsContactInfoGroup"
                                                                     SetFocusOnError="true"></asp:RegularExpressionValidator> 
                                                                </td>
                                                                <td align="left">
                                                                    Address 2
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtCostCenterAddress2" Width="170px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Telephone Number 1<br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtContactTelephoneNumber1" Width="170px"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    City
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtCostCenterCity" Width="170px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Telephone Number 2<br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtContactTelephoneNumber2" Width="170px"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    State
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtCostCenterState" Width="170px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Fax Number&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span><br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtContactFaxNumber" Width="170px" runat="server" MaxLength="50">
                                                                    </asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revContactFaxNumber" ControlToValidate="txtContactFaxNumber"
                                                                        runat="server" ValidationGroup="vsContactInfoGroup" ErrorMessage="Please Enter Fax Number in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left">
                                                                    Zip
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtCostCenterZipCode" Width="170px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Email Address
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox ID="txtContactEmailAddress" runat="server" Width="170px" MaxLength="30"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" align="center">
                                                                    <asp:Button runat="server" ID="btnLocationSave" Text="Save & Continue" OnClick="btnLocationSave_Click"
                                                                        ValidationGroup="vsContactInfoGroup" OnClientClick="return CheckValidationContactsInfo();" />
                                                                    <asp:Button runat="server" ID="btnLocationAudit" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();"
                                                                        ToolTip="View Audit Trail" CausesValidation="false" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                            <asp:Panel runat="server" ID="pnlLossInformation" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Loss Information</div>
                                                <asp:UpdatePanel runat="server" ID="updLossInformation">
                                                    <ContentTemplate>
                                                        <asp:HiddenField runat="server" ID="hdnLoss" />
                                                        <asp:HiddenField ID="hdnPoliceNotify" runat="server" Value="0" />
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Claimant State&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:DropDownList runat="server" ID="ddlClaimant_State" SkinID="ddlSONIC">
                                                                    </asp:DropDownList>
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
                                                                <td align="left">
                                                                    Date of Loss&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtDate_Of_Loss" runat="server" ></asp:TextBox>
                                                                     <asp:TextBox ID="txtCurrentDate" runat="server" style="display:none" ></asp:TextBox>
                                                                    <img alt="Date of Loss" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Of_Loss', 'mm/dd/y',CompareDateLessThanToday,'ctl00_ContentPlaceHolder1_txtDate_Of_Loss');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" /><br />
                                                                   <asp:CustomValidator ID="cvDateofLoss" runat="server" ControlToValidate="txtDate_Of_Loss"
                                                                        ValidationGroup="vsLossInfoGroup" ClientValidationFunction="CheckDate" ErrorMessage="Loss Date is not valid."
                                                                        Display="None">
                                                                    </asp:CustomValidator>
<asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtDate_Of_Loss"
                                                                                ValidationGroup="vsErrorGroup" ErrorMessage="Date of Loss Should Not Be Future Date."
                                                                                Type="Date" Operator="LessThanEqual" ControlToCompare="txtCurrentDate" Display="none">
                                                                            </asp:CompareValidator>

                                                                </td>
                                                                <td align="left">
                                                                    Time of Incident&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                                    <br />
                                                                    (HH:MM)
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtTime_Of_Loss" Width="170px"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revtxtTime_Of_Loss" runat="server" ControlToValidate="txtTime_Of_Loss"
                                                                      ValidationExpression="^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$"
                                                                      ErrorMessage="Invalid Time of Incident." Display="none" ValidationGroup="vsLossInfoGroup"
                                                                      SetFocusOnError="true"></asp:RegularExpressionValidator> 
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Loss Location
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtDBA" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    Non-Sonic Loss Location&nbsp;<span id="Span7" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtNonSonic_Loss_Location" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    In Detail, Explain What Happened&nbsp;<span id="Span8" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <uc:ctrlMultiLineTextBox ID="txtDescription_Of_Loss" runat="server" MaxLength="4000" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Date Reported to Sonic&nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtDate_Reported_To_Sonic" runat="server" ></asp:TextBox>
                                                                   <asp:TextBox ID="txtCurrentDate1" runat="server" style="display:none" ></asp:TextBox>  
                                                                    <img alt="Date Reported to SONIC" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Reported_To_Sonic', 'mm/dd/y',CompareDateLessThanToday,'ctl00_ContentPlaceHolder1_txtDate_Reported_To_Sonic');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" /><br />
                                                                   <asp:CustomValidator ID="cvLossReportedToSONIC" runat="server" ControlToValidate="txtDate_Reported_To_Sonic"
                                                                        ValidationGroup="vsLossInfoGroup" ClientValidationFunction="CheckDate" ErrorMessage="Date of Reported to SONIC is not valid."
                                                                        Display="None">
                                                                    </asp:CustomValidator>
                                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtDate_Reported_To_Sonic"
                                                                                ValidationGroup="vsLossInfoGroup" ErrorMessage="Date Reported to Sonic Should Not Be Future Date."
                                                                                Type="Date" Operator="LessThanEqual" ControlToCompare="txtCurrentDate" Display="none">
                                                                            </asp:CompareValidator>

                                                                </td>
                                                                <td align="left">
                                                                    Weather Conditions&nbsp;<span id="Span10" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtWeather_Conditions" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    Road Conditions&nbsp;<span id="Span11" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtRoad_Conditions" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr><td align="left" valign="top">Incident Involvement Grid<br />&nbsp;&nbsp;
                                                                <asp:LinkButton ID="lnkAddInvolvements" runat="server" ValidationGroup="vsLossInfoGroup" OnClientClick="return CheckLossInformation();" OnClick="lnkAddInvolvements_Click">--Add--</asp:LinkButton> </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4" valign="top">
                                                                 <%-- <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                                                                    <ContentTemplate>--%>
                                                                        <asp:GridView ID="gvInvolvement" runat="server" Width="100%" OnRowCommand="gvInvolvement_RowCommand">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Type">
                                                                                    <ItemStyle Width="15%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                                    <ItemTemplate>                                                                                        
                                                                                          <asp:LinkButton ID="lnkType" runat="server" Text='<%#Eval("TypeName")%>' CausesValidation="false"
                                                                                             CommandName="EditRecord" CommandArgument='<%#Eval("PK_FR_PL_Involvement")%>'></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Name">
                                                                                    <ItemStyle Width="25%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                                    <ItemTemplate>                                                                                     
                                                                                        <asp:LinkButton ID="lnkName" runat="server" Text='<%#Eval("Name")%>' CausesValidation="false"
                                                                                             CommandName="EditRecord" CommandArgument='<%#Eval("PK_FR_PL_Involvement")%>'></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Address">
                                                                                    <ItemStyle Width="35%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                                    <ItemTemplate>                                                                                       
                                                                                        <asp:LinkButton ID="lnkAddress" runat="server" Text='<%#Eval("Address")%>' CausesValidation="false"
                                                                                             CommandName="EditRecord" CommandArgument='<%#Eval("PK_FR_PL_Involvement")%>'></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                 <asp:TemplateField HeaderText="Phone">
                                                                                    <ItemStyle Width="18%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                                    <ItemTemplate>                                                                                      
                                                                                        <asp:LinkButton ID="lnkHome_Telephone" runat="server" Text='<%#Eval("Home_Telephone")%>' CausesValidation="false"
                                                                                             CommandName="EditRecord" CommandArgument='<%#Eval("PK_FR_PL_Involvement")%>'></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>                                                                                
                                                                                 <asp:TemplateField HeaderText="Remove">
                                                                                    <ItemStyle Width="7%" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CausesValidation="false"
                                                                                            OnClientClick="return ConfirmDelete();" CommandName="RemoveRecord" CommandArgument='<%#Eval("PK_FR_PL_Involvement")%>'></asp:LinkButton></ItemTemplate>
                                                                                </asp:TemplateField>                                                                               
                                                                            </Columns>
                                                                            <EmptyDataTemplate>
                                                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                                                    <tr>
                                                                                        <td align="center">
                                                                                            <asp:Label ID="lblMsg" runat="server" SkinID="Message" Text="No Record(s) Found."></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </EmptyDataTemplate>
                                                                        </asp:GridView>
                                                                   <%-- </ContentTemplate>
                                                                </asp:UpdatePanel>--%>
                                                                </td>
                                                                </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Were police notified?
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:RadioButtonList ID="rdoWere_Police_Notified" SkinID="YesNoUnknownType" runat="server"
                                                                        onClick="CheckPoliceNotified();">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr id="trLossPoliceNotified" style="display: none" runat="server">
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <table cellpadding="3" cellspacing="1" border="0">
                                                                        <tr>
                                                                            <td style="width: 18%">
                                                                                Police&nbsp;<span id="Span12" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td style="width: 4%">
                                                                                :
                                                                            </td>
                                                                            <td style="width: 28%">
                                                                                <asp:TextBox runat="server" ID="txtPolice_Organization" Width="170px" MaxLength="50"></asp:TextBox>
                                                                            </td>
                                                                            <td style="width: 18%">
                                                                                Case Number&nbsp;<span id="Span13" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td style="width: 4%">
                                                                                :
                                                                            </td>
                                                                            <td style="width: 28%">
                                                                                <asp:TextBox runat="server" ID="txtCase_Number" Width="170px" MaxLength="50"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Station Phone Number&nbsp;<span id="Span14" style="color: Red; display: none;" runat="server">*</span><br />
                                                                                (xxx-xxx-xxxx)
                                                                            </td>
                                                                            <td>
                                                                                :
                                                                            </td>
                                                                            <td colspan="4">
                                                                                <asp:TextBox runat="server" ID="txtPolice_telephone" Width="170px"></asp:TextBox>
                                                                                <asp:RegularExpressionValidator ID="revPolice_Station_Phone_Number" ControlToValidate="txtPolice_telephone"
                                                                                    runat="server" ValidationGroup="vsLossInfoGroup" ErrorMessage="Please Enter Police Station Phone Number in xxx-xxx-xxxx format."
                                                                                    Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Did Loss Result in Bodily or Personal Injury?
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:RadioButtonList ID="rdoPersonal_Bodily_Injury" SkinID="YesNoUnknownType" runat="server"
                                                                        onclick="CheckMenu(this,4);">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td align="left">
                                                                    Loss Category&nbsp;<span id="Span15" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtLoss_Category" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Was there any property damage?
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:RadioButtonList ID="rdoProperty_Damage" SkinID="YesNoUnknownType" runat="server"
                                                                        onclick="CheckMenu(this,5);">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Were there any witnesses?
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:RadioButtonList ID="rdoWitnesses" SkinID="YesNoUnknownType" runat="server" onclick="CheckMenu(this,6);">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Was a product involved?
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:RadioButtonList ID="rdoProduct_Involved" SkinID="YesNoUnknownType" runat="server"
                                                                        onclick="CheckMenu(this,3);">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Is there a Security Video Surveillance System?
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:RadioButtonList ID="rdoSecurityVideoSystem" SkinID="YesNoUnknownType" runat="server">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" align="center">
                                                                    <asp:Button runat="server" ID="btnLossSave" Text="Save & Continue" OnClick="btnLossSave_Click"
                                                                        ValidationGroup="vsLossInfoGroup" OnClientClick="return CheckLossInformation();" />
                                                                    <asp:Button runat="server" ID="btnLossAudit" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();"
                                                                        ToolTip="View Audit Trail" CausesValidation="false" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                            <asp:Panel runat="server" ID="pnlProductLiability" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Product Liability</div>
                                                <asp:UpdatePanel runat="Server" ID="updProductLiability">
                                                    <ContentTemplate>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Type of Product&nbsp;<span id="Span40" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtType_of_Product" Width="170px" MaxLength="50"></asp:TextBox>
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
                                                                <td align="left">
                                                                    Manufacturer Name&nbsp;<span id="Span41" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtManufacturer_Name" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Address 1&nbsp;<span id="Span42" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtProduct_Address_1" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Address 2&nbsp;<span id="Span43" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtProduct_Address_2" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    City&nbsp;<span id="Span44" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtProduct_City" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    State&nbsp;<span id="Span45" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList runat="server" ID="ddlProduct_State" SkinID="ddlSONIC">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Zip Code&nbsp;<span id="Span46" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtProduct_Zip_Code" Width="170px" MaxLength="10"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Location where vehicle can be seen&nbsp;<span id="Span47" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtProduct_Location" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" align="center">
                                                                    <asp:Button runat="server" ID="btnProductSave" CausesValidation="true" ValidationGroup="vsProductGroup"
                                                                        Text="Save & Continue" OnClick="btnProductSave_Click" />
                                                                    <asp:Button runat="server" ID="btnProductAudit" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();"
                                                                        ToolTip="View Audit Trail" CausesValidation="false" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                            <asp:Panel runat="server" ID="pnlInjury" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Injury Information</div>
                                                <asp:UpdatePanel runat="Server" ID="updInjury">
                                                    <ContentTemplate>
                                                        <asp:HiddenField runat="server" ID="hdnInjury" Value="0" />
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Injured Name&nbsp;<span id="Span16" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtInjured_Name" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Gender&nbsp;<span id="Span17" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtInjured_Gender" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Address 1&nbsp;<span id="Span18" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtInjured_Address_1" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    Work Telephone&nbsp;<span id="Span19" style="color: Red; display: none;" runat="server">*</span><br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtInjured_Work_Phone" Width="170px" MaxLength="20"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revInjured_Work_Phone" ControlToValidate="txtInjured_Work_Phone"
                                                                        runat="server" ValidationGroup="vsInjuryInfoGroup" ErrorMessage="Please Enter Injured Work Phone Number in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Address 2&nbsp;<span id="Span20" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtInjured_Address_2" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    Home Telephone&nbsp;<span id="Span21" style="color: Red; display: none;" runat="server">*</span><br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtInjured_Home_Phone" Width="170px" MaxLength="20"></asp:TextBox>
                                                                   <asp:RegularExpressionValidator ID="revInjured_Home_Phone" ControlToValidate="txtInjured_Home_Phone"
                                                                        runat="server" ValidationGroup="vsInjuryInfoGroup" ErrorMessage="Please Enter Injured Home Phone Number in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    City&nbsp;<span id="Span22" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtInjured_City" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    Alternate Telephone&nbsp;<span id="Span23" style="color: Red; display: none;" runat="server">*</span><br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtInjured_Alternate_Telephone" Width="170px" MaxLength="20"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revInjured_Alternate_Telephone" ControlToValidate="txtInjured_Alternate_Telephone"
                                                                        runat="server" ValidationGroup="vsInjuryInfoGroup" ErrorMessage="Please Enter Injured Altenate Phone Number in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    State&nbsp;<span id="Span24" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList runat="server" ID="ddlInjured_State" SkinID="ddlSONIC">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Zip Code&nbsp;<span id="Span25" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtInjured_Zip_Code" Width="170px" MaxLength="10"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    What was the Injured person doing when the loss occurred?&nbsp;<span id="Span26"
                                                                        style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtWhat_Was_Injured_Doing" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Description of Injury&nbsp;<span id="Span27" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtInjured_Injury_Description" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Body Part Affected&nbsp;<span id="Span28" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList runat="server" ID="ddlbody_part" SkinID="ddlSONIC">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Medical Treatment Provided&nbsp;<span id="Span29" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtInjured_Medical_Treatment_Provided" Width="170px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Taken By Emergency Transportation?
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:RadioButtonList runat="server" ID="rdoInjured_Taken_By_Emergency_Transportation"
                                                                        SkinID="YesNoType">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td align="left">
                                                                    Airlifted/Medivac
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:RadioButtonList runat="server" ID="rdoInjured_Airlifted_Medivac" SkinID="YesNoUnknownType">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Medical Facility Name&nbsp;<span id="Span30" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtInjured_Medical_Facility_Name" Width="170px" MaxLength="40"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    Date of Initial Treatment&nbsp;<span id="Span31" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtInjured_Date_of_Initial_Treatment" runat="server" SkinID="txtDate"></asp:TextBox>
                                                                    <img alt="Date of Initial Treatment" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtInjured_Date_of_Initial_Treatment', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" /><br />
                                                                    <asp:CustomValidator ID="cvInjured_Date_of_Initial_Treatment" runat="server" ControlToValidate="txtInjured_Date_of_Initial_Treatment"
                                                                        ValidationGroup="vsInjuryInfoGroup" ClientValidationFunction="CheckDate" ErrorMessage="Date of Initial Treatment is not valid."
                                                                        Display="None">
                                                                    </asp:CustomValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Medical Facility Type&nbsp;<span id="Span32" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtInjured_Medical_Facility_Type" Width="170px" MaxLength="20"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    Treating Physician’s Name&nbsp;<span id="Span33" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="Server" ID="txtInjured_Physicians_Name" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Medical Facility Address 1&nbsp;<span id="Span34" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtInjured_Medical_Facility_Address_1" Width="170px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    Admitted to Hospital
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:RadioButtonList runat="server" ID="rdoInjured_Admitted_to_Hospital" SkinID="YesNoUnknownType"
                                                                        onClick="checkInjured_AdmittedHospital();">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Medical Facility Address 2&nbsp;<span id="Span35" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtInjured_Medical_Facility_Address_2" Width="170px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left" colspan="3" id="tdInjury_DateAdmitted" runat="server" style="display: none;">
                                                                    <table cellpadding="0" cellspacing="3" border="0" width="100%">
                                                                        <tr>
                                                                            <td align="left" style="width:35%">
                                                                                Date Admitted&nbsp;<span id="Span36" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center" style="width: 10%">
                                                                                :
                                                                            </td>
                                                                            <td align="left" >
                                                                                <asp:TextBox ID="txtInjured_Date_Admitted_to_Hospital" runat="server" SkinID="txtDate" ></asp:TextBox>
                                                                                <img alt="Date Admitted to Hospital" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtInjured_Date_Admitted_to_Hospital', 'mm/dd/y',CompareDateLessThanToday,'ctl00_ContentPlaceHolder1_txtInjured_Date_Admitted_to_Hospital');"
                                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                                    align="middle" /><br />
                                                                                <asp:CustomValidator ID="cvInjured_Date_Admitted_to_Hospital" runat="server" ControlToValidate="txtInjured_Date_Admitted_to_Hospital"
                                                                                    ValidationGroup="vsInjuryInfoGroup" ClientValidationFunction="CheckDate" ErrorMessage="Date Admitted to Hospital is not valid."
                                                                                    Display="None">
                                                                                </asp:CustomValidator>
                                                                                <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txtInjured_Date_Admitted_to_Hospital"
                                                                                ValidationGroup="vsInjuryInfoGroup" ErrorMessage=" Date of Admitted Should Not Be Future Date."
                                                                                Type="Date" Operator="LessThanEqual" ControlToCompare="txtCurrentDate" Display="none">
                                                                            </asp:CompareValidator>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Medical Facility City&nbsp;<span id="Span37" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtInjured_Medical_Facility_City" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left" colspan="3" id="tdInjury_StillHospital" runat="Server" style="display: none;">
                                                                    <table cellpadding="0" cellspacing="3" border="0" width="100%">
                                                                        <tr>
                                                                            <td align="left" style="width: 35%">
                                                                                Still in Hospital
                                                                            </td>
                                                                            <td align="center" style="width: 10%">
                                                                                :
                                                                            </td>
                                                                            <td align="left" >
                                                                                <asp:RadioButtonList runat="server" ID="rdoInjured_Still_in_Hospital" SkinID="YesNoUnknownType">
                                                                                </asp:RadioButtonList>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Medical Facility State&nbsp;<span id="Span38" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList runat="server" ID="ddlInjured_Medical_Facility_State" SkinID="ddlSONIC">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Medical Facility Zip Code&nbsp;<span id="Span39" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtInjured_Medical_Facility_Zip_Code" Width="170px"
                                                                        MaxLength="10"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" align="center">
                                                                    <asp:Button runat="server" ID="btnSave" Text="Save & Continue" OnClick="btnInjuredSave_Click"
                                                                        ValidationGroup="vsInjuryInfoGroup" />
                                                                    <asp:Button runat="server" ID="btnInjuredAudit" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();"
                                                                        ToolTip="View Audit Trail" CausesValidation="false" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                            <asp:Panel runat="server" ID="pnlProperty" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Property</div>
                                                <asp:UpdatePanel runat="server" ID="updProperty">
                                                    <ContentTemplate>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Property Description&nbsp;<span id="Span48" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtProperty_Description" Width="170px" MaxLength="50"></asp:TextBox>
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
                                                                <td align="left">
                                                                    Damage Description&nbsp;<span id="Span49" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtProperty_Damage_Description" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Estimate Available
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:RadioButtonList runat="server" ID="rdoEstimate_Available" SkinID="YesNoUnknownType">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td align="left">
                                                                    Estimate Amount&nbsp;<span id="Span50" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    $
                                                                    <asp:TextBox runat="server" ID="txtEstimate_Amount" Width="170px" MaxLength="10"
                                                                        onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Estimator Name&nbsp;<span id="Span51" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtProperty_Estimator_Name" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    Estimator Phone&nbsp;<span id="Span52" style="color: Red; display: none;" runat="server">*</span><br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtEstimator_Phone" Width="170px" MaxLength="50"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revEstimator_Phone" ControlToValidate="txtEstimator_Phone"
                                                                        runat="server" ValidationGroup="vsPropertyInfoGroup" ErrorMessage="Please Enter Estimator Number in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Business Name&nbsp;<span id="Span53" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtProperty_Business_Name" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    Owner Name&nbsp;<span id="Span54" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtOwner_Name" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Address 1&nbsp;<span id="Span55" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtProperty_Address_1" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    Work Telephone&nbsp;<span id="Span56" style="color: Red; display: none;" runat="server">*</span><br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtOwner_Work_Telephone" Width="170px"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revOwner_Work_Telephone" ControlToValidate="txtOwner_Work_Telephone"
                                                                        runat="server" ValidationGroup="vsPropertyInfoGroup" ErrorMessage="Please Enter Owner Work Number in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Address 2&nbsp;<span id="Span57" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtProperty_Address_2" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    Home Telephone&nbsp;<span id="Span58" style="color: Red; display: none;" runat="server">*</span><br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtOwner_Home_Telephone" Width="170px"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revOwner_Home_Telephone" ControlToValidate="txtOwner_Home_Telephone"
                                                                        runat="server" ValidationGroup="vsPropertyInfoGroup" ErrorMessage="Please Enter Owner Home Number in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    City&nbsp;<span id="Span59" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtProperty_City" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    Alternate Telephone&nbsp;<span id="Span60" style="color: Red; display: none;" runat="server">*</span><br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtOwner_Alternate_Telephone" Width="170px"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revOwner_Alternate_Telephone" ControlToValidate="txtOwner_Alternate_Telephone"
                                                                        runat="server" ValidationGroup="vsPropertyInfoGroup" ErrorMessage="Please Enter Owner Alternate Number in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    State&nbsp;<span id="Span61" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList runat="Server" ID="ddlProperty_State" SkinID="ddlSONIC">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Zip Code&nbsp;<span id="Span62" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtProperty_Zip_Code" Width="170px" MaxLength="10"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Location where property can be seen&nbsp;<span id="Span63" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtLocation_where_property_can_be_seen" Width="170px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" align="center">
                                                                    <asp:Button runat="server" ID="btnPropertySave" CausesValidation="true" Text="Save & Continue"
                                                                        OnClick="btnPropertySave_Click" ValidationGroup="vsPropertyInfoGroup" />
                                                                    <asp:Button runat="server" ID="btnPropertyAudit" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();"
                                                                        ToolTip="View Audit Trail" CausesValidation="false" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                            <asp:Panel runat="server" ID="pnlWitnesses" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Witness Information</div>
                                                <asp:UpdatePanel runat="Server" ID="updWitness">
                                                    <ContentTemplate>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%" >
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Name&nbsp;<span id="Span64" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtWitness_Name" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Address 1&nbsp;<span id="Span65" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtWitness_Address_1" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Home Telephone&nbsp;<span id="Span66" style="color: Red; display: none;" runat="server">*</span><br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtWitness_Home_Phone" Width="170px" MaxLength="20"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revWitness_Home_Phone" ControlToValidate="txtWitness_Home_Phone"
                                                                        runat="server" ValidationGroup="vsWitnessInfoGroup" ErrorMessage="Please Enter Witness Home Number in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Address 2&nbsp;<span id="Span67" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtWitness_Address_2" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Work Telephone&nbsp;<span id="Span68" style="color: Red; display: none;" runat="server">*</span><br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtWitness_Work_Phone" Width="170px" MaxLength="20"></asp:TextBox>
                                                                    <cc1:MaskedEditExtender ID="mskWitness_Work_Phone" runat="server" TargetControlID="txtWitness_Work_Phone"
                                                                        Mask="999-999-9999" MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="revWitness_Work_Phone" ControlToValidate="txtWitness_Work_Phone"
                                                                        runat="server" ValidationGroup="vsWitnessInfoGroup" ErrorMessage="Please Enter Witness Work Number in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    City&nbsp;<span id="Span69" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtWitness_City" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Alternate Telephone&nbsp;<span id="Span70" style="color: Red; display: none;" runat="server">*</span><br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtWitness_Alternate_Phone" Width="170px" MaxLength="20"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revWitness_Alternate_Phone" ControlToValidate="txtWitness_Alternate_Phone"
                                                                        runat="server" ValidationGroup="vsWitnessInfoGroup" ErrorMessage="Please Enter Witness Alternate Number in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    State&nbsp;<span id="Span71" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:DropDownList runat="server" ID="ddlWitness_State" SkinID="ddlSONIC">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Zip&nbsp;<span id="Span72" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtWitness_Zip_Code" Width="170px" MaxLength="10"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" align="center">
                                                                    <asp:Button runat="server" ID="btnWitnessSave" Text="Save & Continue" OnClick="btnWitnessSave_Click"
                                                                        ValidationGroup="vsWitnessInfoGroup" CausesValidation="true" />&nbsp;
                                                                    <asp:Button runat="server" ID="btnWitnessAudit" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();"
                                                                        ToolTip="View Audit Trail" CausesValidation="false" />
                                                                </td>
                                                            </tr>
                                                            <tr><td colspan="6">&nbsp;</td></tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlComments" runat="server" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Comments and Attachments</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" style="width: 18%" valign="top">
                                                            Comments&nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" style="width: 4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="txtComments" runat="server" MaxLength="4000" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" style="height: 10px;">
                                                        </td>
                                                    </tr>
                                                    <tr class="bandHeaderRow">
                                                        <td colspan="6">
                                                            Attachments
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Attachments
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <uc:ctrlAttachmentDetails ID="CtrlAttachDetails" runat="Server" ModeofPage="EditMode" />
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
                                                            <asp:Button runat="server" ID="btnSubmit" CausesValidation="true" ValidationGroup="vsCommentGroup"
                                                                Text="Submit Report" OnClick="btnSubmit_Click" OnClientClick="return CheckAllValidation();" />
                                                            <asp:Button runat="server" ID="btnSubmitAudit" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();"
                                                                ToolTip="View Audit Trail" CausesValidation="false" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </div>
                                        <div id="dvView" runat="server" style="width: 100%;">
                                            <asp:Panel ID="pnlViewLocation" runat="server" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Location Information</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Location Number
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label runat="server" ID="lblLocationNumber"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%">
                                                            Location d/b/a
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label runat="server" ID="lblLocationdba"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Legal Entity
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblLegalEntity"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            Location f/k/a
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblLocationfka" runat="server">
                                                            </asp:Label>
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
                                                            <asp:Label ID="lblLocationAddress1" runat="server">
                                                            </asp:Label>
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
                                                            <asp:Label ID="lblLocationAddress2" runat="server">
                                                            </asp:Label>
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
                                                            <asp:Label ID="lblLocationCity" runat="server"></asp:Label>
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
                                                            <asp:Label runat="server" ID="lblLocationState"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Zip Code
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label ID="lblLocationZipCode" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div class="bandHeaderRow">
                                                    Contact Information</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Dealership/Collision Center
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td width="28%" align="left">
                                                            <asp:Label runat="server" ID="lblCostCenterdba"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" width="4%">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" width="28%">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Contact Name
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblContactName"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            Address 1
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblCostCenterAddress1"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            When to Contact
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblContact_Best_Time"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            Address 2
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblCostCenterAddress2"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Telephone Number 1<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblContactTelephoneNumber1"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            City
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblCostCenterCity"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Telephone Number 2<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblContactTelephoneNumber2"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            State
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblCostCenterState"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Fax Number<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblContactFaxNumber" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            Zip
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblCostCenterZipCode"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Email Address
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label ID="lblContactEmailAddress" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel runat="server" ID="pnlViewLossInformation" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Loss Information</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Claimant State
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblClaimant_State"></asp:Label>
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
                                                        <td align="left">
                                                            Date of Loss
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblDate_Of_Loss" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            Time of Incident
                                                            <br />
                                                            (HH:MM)
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblTime_Of_Loss"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Loss Location
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblDBA"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            Non-Sonic Loss Location
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblNonSonic_Loss_Location"></asp:Label>
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
                                                            <uc:ctrlMultiLineTextBox ID="lblDescription_Of_Loss" runat="server" MaxLength="4000"
                                                                ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Date Reported to Sonic
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblDate_Reported_To_Sonic" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            Weather Conditions
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblWeather_Conditions"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            Road Conditions
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblRoad_Conditions"></asp:Label>
                                                        </td>
                                                    </tr>
                                                     <tr><td align="left" valign="top">Incident Involvement Grid</td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4" valign="top">
                                                                  <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                                                                    <ContentTemplate>
                                                                        <asp:GridView ID="gvInvolvementView" runat="server" Width="100%" OnRowCommand="gvInvolvement_RowCommand">
                                                                            <Columns>
                                                                                 <asp:TemplateField HeaderText="Type">
                                                                                    <ItemStyle Width="17%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                                    <ItemTemplate>                                                                                        
                                                                                          <asp:LinkButton ID="lnkType" runat="server" Text='<%#Eval("TypeName")%>' CausesValidation="false"
                                                                                             CommandName="ViewRecord" CommandArgument='<%#Eval("PK_FR_PL_Involvement")%>'></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Name">
                                                                                    <ItemStyle Width="27%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                                    <ItemTemplate>                                                                                     
                                                                                        <asp:LinkButton ID="lnkName" runat="server" Text='<%#Eval("Name")%>' CausesValidation="false"
                                                                                             CommandName="ViewRecord" CommandArgument='<%#Eval("PK_FR_PL_Involvement")%>'></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Address">
                                                                                    <ItemStyle Width="37%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                                    <ItemTemplate>                                                                                       
                                                                                        <asp:LinkButton ID="lnkAddress" runat="server" Text='<%#Eval("Address")%>' CausesValidation="false"
                                                                                             CommandName="ViewRecord" CommandArgument='<%#Eval("PK_FR_PL_Involvement")%>'></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                 <asp:TemplateField HeaderText="Phone">
                                                                                    <ItemStyle Width="20%" HorizontalAlign="left" VerticalAlign="Top" />
                                                                                    <ItemTemplate>                                                                                      
                                                                                        <asp:LinkButton ID="lnkHome_Telephone" runat="server" Text='<%#Eval("Home_Telephone")%>' CausesValidation="false"
                                                                                             CommandName="ViewRecord" CommandArgument='<%#Eval("PK_FR_PL_Involvement")%>'></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>                                                           
                                                                            </Columns>
                                                                            <EmptyDataTemplate>
                                                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                                                    <tr>
                                                                                        <td align="center">
                                                                                            <asp:Label ID="lblMsg" runat="server" SkinID="Message" Text="No Record(s) Found."></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </EmptyDataTemplate>
                                                                        </asp:GridView>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                                </td>
                                                                </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Were police notified?
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label ID="lblWere_Police_Notified" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr id="trViewLossPoliceNotified" style="display: none;" runat="server">
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td style="width: 18%">
                                                                        Police
                                                                    </td>
                                                                    <td style="width: 4%">
                                                                        :
                                                                    </td>
                                                                    <td style="width: 28%">
                                                                        <asp:Label runat="server" ID="lblPolice_Organization"></asp:Label>
                                                                    </td>
                                                                    <td style="width: 18%">
                                                                        Case Number
                                                                    </td>
                                                                    <td style="width: 4%">
                                                                        :
                                                                    </td>
                                                                    <td style="width: 28%">
                                                                        <asp:Label runat="server" ID="lblCase_Number"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        Station Phone Number<br />
                                                                        (xxx-xxx-xxxx)
                                                                    </td>
                                                                    <td>
                                                                        :
                                                                    </td>
                                                                    <td colspan="4">
                                                                        <asp:Label runat="server" ID="lblPolice_telephone"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Did Loss Result in Bodily or Personal Injury?
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblPersonal_Bodily_Injury" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            Loss Category
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblLoss_Category"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Was there any property damage?
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label ID="lblProperty_Damage" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Were there any witnesses?
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label ID="lblWitnesses" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Was a product involved?
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label ID="lblProduct_Involved" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Is there a Security Video Surveillance System?
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label ID="lblSecurityVideoSystem" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel runat="server" ID="pnlViewProductLiability" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Product Liability</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Type of Product
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblType_of_Product"></asp:Label>
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
                                                        <td align="left">
                                                            Manufacturer Name
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblManufacturer_Name"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Address 1
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblProduct_Address_1"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
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
                                                            <asp:Label runat="server" ID="lblProduct_Address_2"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
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
                                                            <asp:Label runat="server" ID="lblProduct_City"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            State
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblProduct_State"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Zip Code
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblProduct_Zip_Code"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Location where vehicle can be seen
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblProduct_Location"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel runat="server" ID="pnlViewInjury" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Injury Information</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Injured Name
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblInjured_Name"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Gender
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblInjured_Gender"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Address 1
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblInjured_Address_1"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            Work Telephone<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblInjured_Work_Phone"></asp:Label>
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
                                                            <asp:Label runat="server" ID="lblInjured_Address_2"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            Home Telephone<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblInjured_Home_Phone"></asp:Label>
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
                                                            <asp:Label runat="server" ID="lblInjured_City"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            Alternate Telephone<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblInjured_Alternate_Telephone"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            State
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblInjured_State"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Zip Code
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblInjured_Zip_Code"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            What was the Injured person doing when the loss occurred?
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblWhat_Was_Injured_Doing"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Description of Injury
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblInjured_Injury_Description"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Body Part Affected
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblbody_part"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Medical Treatment Provided
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblInjured_Medical_Treatment_Provided"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Taken By Emergency Transportation?
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblInjured_Taken_By_Emergency_Transportation"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            Airlifted/Medivac
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblInjured_Airlifted_Medivac"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Medical Facility Name
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblInjured_Medical_Facility_Name"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            Date of Initial Treatment
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblInjured_Date_of_Initial_Treatment" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Medical Facility Type
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblInjured_Medical_Facility_Type"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            Treating Physician’s Name
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="Server" ID="lblInjured_Physicians_Name"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Medical Facility Address 1
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblInjured_Medical_Facility_Address_1"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            Admitted to Hospital
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblInjured_Admitted_to_Hospital"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Medical Facility Address 2
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblInjured_Medical_Facility_Address_2"></asp:Label>
                                                        </td>
                                                        <td align="left" colspan="3" id="tdViewInjury_DateAdmitted" runat="server" style="display: none;">
                                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" style="width: 18%">
                                                                        Date Admitted
                                                                    </td>
                                                                    <td align="center" style="width: 4%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" style="width: 28%">
                                                                        <asp:Label ID="lblInjured_Date_Admitted_to_Hospital" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Medical Facility City
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblInjured_Medical_Facility_City"></asp:Label>
                                                        </td>
                                                        <td align="left" colspan="3" id="tdViewInjury_StillHospital" runat="Server" style="display: none;">
                                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" style="width: 18%">
                                                                        Still in Hospital
                                                                    </td>
                                                                    <td align="center" style="width: 4%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" style="width: 28%">
                                                                        <asp:Label runat="server" ID="lblInjured_Still_in_Hospital"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Medical Facility State
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblInjured_Medical_Facility_State"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Medical Facility Zip Code
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblInjured_Medical_Facility_Zip_Code"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel runat="server" ID="pnlViewProperty" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Property</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Property Description
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblProperty_Description"></asp:Label>
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
                                                        <td align="left">
                                                            Damage Description
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblProperty_Damage_Description"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Estimate Available
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblEstimate_Available"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            Estimate Amount
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblEstimate_Amount"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Estimator Name
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblProperty_Estimator_Name"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            Estimator Phone
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblEstimator_Phone"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Business Name
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblProperty_Business_Name"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            Owner Name
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblOwner_Name"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Address 1
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblProperty_Address_1"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            Work Telephone<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblOwner_Work_Telephone"></asp:Label>
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
                                                            <asp:Label runat="server" ID="lblProperty_Address_2"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            Home Telephone<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblOwner_Home_Telephone"></asp:Label>
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
                                                            <asp:Label runat="server" ID="lblProperty_City"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            Alternate Telephone<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblOwner_Alternate_Telephone"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            State
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="Server" ID="lblProperty_State"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Zip Code
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblProperty_Zip_Code"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Location where property can be seen
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblLocation_where_property_can_be_seen"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel runat="server" ID="pnlViewWitnesses" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Witness Information</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Name
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblWitness_Name"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Address 1
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblWitness_Address_1"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Home Telephone
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblWitness_Home_Phone"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Address 2
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblWitness_Address_2"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Work Telephone
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblWitness_Work_Phone"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            City
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblWitness_City"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Alternate Telephone
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblWitness_Alternate_Phone"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            State
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblWitness_State"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Zip
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblWitness_Zip_Code"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlViewComments" runat="server" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Comments and Attachments</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" style="width: 18%" valign="top">
                                                            Comments
                                                        </td>
                                                        <td align="center" style="width: 4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="lblComments" runat="server" MaxLength="4000" ControlType="label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Attachments
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <uc:ctrlAttachmentDetails ID="CtrlViewAttachDetails" runat="Server" ModeofPage="ViewMode" />
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
    <asp:Panel runat="server" ID="pnlPageLoadScript" Visible="false">
        <script language="javascript" type="text/javascript">
            var rdo1 = document.getElementById("ctl00_ContentPlaceHolder1_rdoPersonal_Bodily_Injury_0");
            var tb1 = document.getElementById("PLMenu4");
            if (rdo1.checked == true) {
                tb1.style.display = "";
            }
            else {
                tb1.style.display = "none";
            }

            var rdo2 = document.getElementById("ctl00_ContentPlaceHolder1_rdoProperty_Damage_0");
            var tb2 = document.getElementById("PLMenu5");
            if (rdo2.checked == true) {
                tb2.style.display = "";
            }
            else {
                tb2.style.display = "none";
            }

            var rdo3 = document.getElementById("ctl00_ContentPlaceHolder1_rdoWitnesses_0");
            var tb3 = document.getElementById("PLMenu6");
            if (rdo3.checked == true) {
                tb3.style.display = "";
            }
            else {
                tb3.style.display = "none";
            }
            var rdo4 = document.getElementById("ctl00_ContentPlaceHolder1_rdoProduct_Involved_0");
            var tb4 = document.getElementById("PLMenu3");
            if (rdo4.checked == true) {
                tb4.style.display = "";
            }
            else {
                tb4.style.display = "none";
            }
        </script>
    </asp:Panel>
    <asp:Panel ID="pnlPageRedirect" runat="server" Visible="false">
        <script language="javascript" type="text/javascript">
            function Redirect(index) {
                var bool = false;
                for (i = index; i <= 6; i++) {
                    if ((document.getElementById("PLMenu" + i).style.display) == "") {
                        ShowPanel(i);
                        bool = true;
                        break;
                    }
                }
                if (bool == false) {
                    ShowPanel(7);
                }
            }
        </script>
    </asp:Panel>
    <asp:Panel ID="pnlDisplayInjuryTab" runat="server" Visible="false">
        <script language="javascript" type="text/javascript">
            var tb1 = document.getElementById("PLMenu4");
            tb1.style.display = "";
        </script>
    </asp:Panel>
    <asp:Panel ID="pnlDisplayPropertyTab" runat="server" Visible="false">
        <script language="javascript" type="text/javascript">
            var tb1 = document.getElementById("PLMenu5");
            tb1.style.display = "";
        </script>
    </asp:Panel>
    <asp:Panel ID="pnlDisplayWitnessesTab" runat="server" Visible="false">
        <script language="javascript" type="text/javascript">
            var tb1 = document.getElementById("PLMenu6");
            tb1.style.display = "";
        </script>
    </asp:Panel>
    <asp:Panel ID="pnlDisplayProductTab" runat="server" Visible="false">
        <script language="javascript" type="text/javascript">
            var tb1 = document.getElementById("PLMenu3");
            tb1.style.display = "";
        </script>
    </asp:Panel>
    <asp:CustomValidator ID="CustomValidatorLocation" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFieldsLocation" Display="None" ValidationGroup="vsContactInfoGroup" />
    <input id="hdnControlIDsLocation" runat="server" type="hidden" />
    <input id="hdnErrorMsgsLocation" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidatorLossInfo" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFieldsLossInfo" Display="None" ValidationGroup="vsLossInfoGroup" />
    <input id="hdnControlIDsLossInfo" runat="server" type="hidden" />
    <input id="hdnErrorMsgsLossInfo" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidatorComments" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFieldsComments" Display="None" ValidationGroup="vsCommentGroup" />
    <input id="hdnControlIDsComments" runat="server" type="hidden" />
    <input id="hdnErrorMsgsComments" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidatorInjury" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFieldsInjury"
        Display="None" ValidationGroup="vsInjuryInfoGroup" />
    <input id="hdnControlIDsInjury" runat="server" type="hidden" />
    <input id="hdnErrorMsgsInjury" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidatorProduct" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFieldsProduct"
        Display="None" ValidationGroup="vsProductGroup" />
    <input id="hdnControlIDsProduct" runat="server" type="hidden" />
    <input id="hdnErrorMsgsProduct" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidatorProperty" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFieldsProperty" Display="None" ValidationGroup="vsPropertyInfoGroup" />
    <input id="hdnControlIDsProperty" runat="server" type="hidden" />
    <input id="hdnErrorMsgsProperty" runat="server" type="hidden" />

    <asp:CustomValidator ID="CustomValidatorWitness" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFieldsWitness" Display="None" ValidationGroup="vsWitnessInfoGroup" />
    <input id="hdnControlIDsWitness" runat="server" type="hidden" />
    <input id="hdnErrorMsgsWitness" runat="server" type="hidden" />
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
</asp:Content>
