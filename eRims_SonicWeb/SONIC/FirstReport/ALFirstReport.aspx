<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="ALFirstReport.aspx.cs"
    Inherits="SONIC_ALFirstReport" Title="First Report :: Auto Liability" %>

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
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery.maskedinput.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Date_Validation.js"></script>
    <script language="javascript" type="text/javascript">

        //OPen Audit Popup
        function AuditPopUp() {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;

            obj = window.open("AuditPopup_ALFirstReport.aspx?id=" + '<%=ViewState["AL_FR_ID"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
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
            CheckPedestrian_AdmittedHospital();
            checkOth_Driver_AdmittedHospital();
            CheckOth_Veh_PassAdmittedHospital();
            CheckAdmittedHospital();
            CheckInjuryOccured();
        }
        ///Used validate all the Panel at same time
        function CheckAllValidation() {
            //check validation group of all tha panel
            if (CheckValidationContactsInfo() == true &&
    CheckValidationLossInfo() == true &&
    CheckValidationInsuredVehicleInfo() == true &&
    CheckValidationInsuredVehicleDriverInfo() == true &&
    CheckValidationInsuredVehiclePassengerInfo() == true &&
    CheckValidationOtherVehicleInfo() == true &&
    CheckValidationOtherVehicleDriverInfo() == true &&
    CheckValidationOtherVehiclePassengerInfo() == true &&
    CheckValidationPedestrianInfo() == true &&
    CheckValidationWitnessInfo() == true &&
    CheckComments() == true) {
                return true;
            }
            else {
                return false;
            }
            //check validation group of all tha panel
            //    if(Page_ClientValidate("vsContactInfoGroup") && Page_ClientValidate("vsLossInfoGroup") 
            //    && Page_ClientValidate("vsInsuredVehicleInfoGroup")&& Page_ClientValidate("vsInsuredDriverInfoGroup")
            //    && Page_ClientValidate("vsInsuredPassengerInfoGroup") && Page_ClientValidate("vsOtherVehicleInfoGroup")
            //    && Page_ClientValidate("vsOtherVehicleDriverInfoGroup") && Page_ClientValidate("vsOtherVehiclePassengerInfoGroup")
            //    && Page_ClientValidate("vsPadestrianInfoGroup") && Page_ClientValidate("vsWitnessInfoGroup"))

        }
        //used to Validate Witness Panel.
        function CheckValidationWitnessInfo() {
            //if number is "___-___-____" than set it to ""
            if (document.getElementById('<%=txtWitness_Home_Phone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtWitness_Home_Phone.ClientID%>').value = "";
            if (document.getElementById('<%=txtWitness_Work_Phone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtWitness_Work_Phone.ClientID%>').value = "";
            if (document.getElementById('<%=txtWitness_Alternate_Phone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtWitness_Alternate_Phone.ClientID%>').value = "";

            //validate Page by passed Validation group id.
            if (Page_ClientValidate("vsWitnessInfoGroup")) {
                return true;
            }
            else
                return false;
        }

        //check comments validation panel
        function CheckComments() {

            //Validate Page by passed Validation Group ID
            if (Page_ClientValidate("vsCommentsGroup")) {
                return true;
            }
            else
                return false;
        }
        //used to Validate Pedestrian Panel
        function CheckValidationPedestrianInfo() {
            //if number is "___-___-____" than set it to ""
            if (document.getElementById('<%=txtPedestrian_Work_Phone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtPedestrian_Work_Phone.ClientID%>').value = "";
            if (document.getElementById('<%=txtPedestrian_Home_Phone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtPedestrian_Home_Phone.ClientID%>').value = "";
            if (document.getElementById('<%=txtPedestrian_Alternate_Phone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtPedestrian_Alternate_Phone.ClientID%>').value = "";
            //Valuidate Page by passed Validation group id
            if (Page_ClientValidate("vsPadestrianInfoGroup")) {
                return true;
            }
            else
                return false;
        }
        //used to Validate Other Vehicle Passenger Information Panel
        function CheckValidationOtherVehiclePassengerInfo() {
            //if number is "___-___-____" than set it to ""
            if (document.getElementById('<%=txtOth_Veh_Pass_Alternate_Phone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtOth_Veh_Pass_Alternate_Phone.ClientID%>').value = "";
            if (document.getElementById('<%=txtOth_Veh_Pass_Home_Phone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtOth_Veh_Pass_Home_Phone.ClientID%>').value = "";
            if (document.getElementById('<%=txtOth_Veh_Pass_Work_Phone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtOth_Veh_Pass_Work_Phone.ClientID%>').value = "";
            //validate page by passed validation group
            if (Page_ClientValidate("vsOtherVehiclePassengerInfoGroup")) {
                return true;
            }
            else
                return false;
        }
        //used to Validate Oter Vehicle Driver Information
        function CheckValidationOtherVehicleDriverInfo() {
            //if number is "___-___-____" than set it to ""
            if (document.getElementById('<%=txtOther_Driver_Home_Phone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtOther_Driver_Home_Phone.ClientID%>').value = "";
            if (document.getElementById('<%=txtOther_Driver_Work_Phone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtOther_Driver_Work_Phone.ClientID%>').value = "";

            //Validate page by passed validation Group id
            if (Page_ClientValidate("vsOtherVehicleDriverInfoGroup")) {
                return true;
            }
            else
                return false;
        }
        //used to Validate Other Vehicle Information
        function CheckValidationOtherVehicleInfo() {
            //if number is "___-___-____" than set it to ""
            if (document.getElementById('<%=txtOther_Vehicle_Owner_Alternate_Phone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtOther_Vehicle_Owner_Alternate_Phone.ClientID%>').value = "";
            if (document.getElementById('<%=txtOther_Vehicle_Owner_Home_Phone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtOther_Vehicle_Owner_Home_Phone.ClientID%>').value = "";
            if (document.getElementById('<%=txtOther_Vehicle_Owner_Work_Phone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtOther_Vehicle_Owner_Work_Phone.ClientID%>').value = "";
            if (document.getElementById('<%=txtOther_Vehicle_Location_Telephone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtOther_Vehicle_Location_Telephone.ClientID%>').value = "";
            if (document.getElementById('<%=txtOther_Vehicle_Insurance_Co_Phone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtOther_Vehicle_Insurance_Co_Phone.ClientID%>').value = "";
            //Validate Page by passed validation group id
            if (Page_ClientValidate("vsOtherVehicleInfoGroup")) {
                return true;
            }
            else
                return false;
        }
        //used to Validate Insured Vehicle Passenger Infiormaiton Panel
        function CheckValidationInsuredVehiclePassengerInfo() {
            //if number is "___-___-____" than set it to ""
            if (document.getElementById('<%=txtPassenger_Alternate_Phone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtPassenger_Alternate_Phone.ClientID%>').value = "";
            if (document.getElementById('<%=txtPassenger_Home_Phone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtPassenger_Home_Phone.ClientID%>').value = "";
            if (document.getElementById('<%=txtPassenger_Work_Phone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtPassenger_Work_Phone.ClientID%>').value = "";
            //Validate Page by passed Validation Group Id
            if (Page_ClientValidate("vsInsuredPassengerInfoGroup")) {
                return true;
            }
            else
                return false;
        }
        //used to Validate Insured Vehicle Driver INformation
        function CheckValidationInsuredVehicleDriverInfo() {
            //if number is "___-___-____" than set it to ""
            if (document.getElementById('<%=txtDriver_Altermate_Phone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtDriver_Altermate_Phone.ClientID%>').value = "";
            if (document.getElementById('<%=txtDriver_Home_Phone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtDriver_Home_Phone.ClientID%>').value = "";
            if (document.getElementById('<%=txtDriver_Work_Phone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtDriver_Work_Phone.ClientID%>').value = "";
            //Validate page by passed validation group id
            if (Page_ClientValidate("vsInsuredDriverInfoGroup")) {
                return true;
            }
            else
                return false;
        }
        //used to Validate INsured Vehicle Information
        function CheckValidationInsuredVehicleInfo() {
            //if number is "___-___-____" than set it to ""
            if (document.getElementById('<%=txtOwner_Alternate_Phone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtOwner_Alternate_Phone.ClientID%>').value = "";
            if (document.getElementById('<%=txtOwner_Alternate_Phone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtOwner_Alternate_Phone.ClientID%>').value = "";
            if (document.getElementById('<%=txtOwner_Home_Phone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtOwner_Home_Phone.ClientID%>').value = "";
            if (document.getElementById('<%=txtOwner_Work_Phone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtOwner_Work_Phone.ClientID%>').value = "";
            //Validate Page by passed validation group id
            if (Page_ClientValidate("vsInsuredVehicleInfoGroup")) {
                return true;
            }
            else
                return false;
        }
        //used to Validate Loss Informaiton Panel
        function CheckValidationLossInfo() {
            //if number is "___-___-____" than set it to ""
            if (document.getElementById('<%=txtPolice_Station_Phone_Number.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtPolice_Station_Phone_Number.ClientID%>').value = "";
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
            //Validate Page by passed validation group id.
            if (Page_ClientValidate("vsLossInfoGroup")) {
                return true;
            }
            else
                return false;
        }
        //used to Validate Contact Information
        function CheckValidationContactsInfo() {
            //if number is "___-___-____" than set it to ""
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
            //Validate page by passed Validation group id
            if (Page_ClientValidate("vsContactInfoGroup")) {
                return true;
            }
            else
                return false;
        }
        //Check Weather Ploice Notification radiobutton is selected true or not.as per answer,display/Hide Informaiton.
        function CheckPoliceNotified() {
            ctl = document.getElementById('<%=rdoWere_Police_Notified.ClientID %>');
            rdo = document.getElementById(ctl.id + "_0");
            //check radio button value
            if (rdo.checked == true) {
                document.getElementById('<%=trLossPloiceNotified.ClientID %>').style.display = "block";
            }
            else {
                var Val = document.getElementById('<%=hdnPoliceNotify.ClientID%>').value;
                if (Val != '1') {
                    document.getElementById('<%=txtPolice_Agency.ClientID %>').value = "";
                    document.getElementById('<%=txtPolice_Case_Number.ClientID %>').value = "";
                    document.getElementById('<%=txtPolice_Station_Phone_Number.ClientID %>').value = "";
                }
                document.getElementById('<%=trLossPloiceNotified.ClientID %>').style.display = "none";
            }
        }
        //check Pedestrian radiobutton is selected true or not.and as per answer,display/hide Information
        function CheckPedestrian_AdmittedHospital() {
            ctl = document.getElementById('<%=rdoPedestrian_Admitted_to_Hospital.ClientID %>');
            rdo = document.getElementById(ctl.id + "_0");
            //check radio buttonlist value
            if (rdo.checked == true) {
                document.getElementById('<%=tdPedestrian_DateAdmitted.ClientID %>').style.display = "block";
                document.getElementById('<%=tdPedestrian_StillHospital.ClientID %>').style.display = "block";
            }
            else {
                document.getElementById('<%=tdPedestrian_DateAdmitted.ClientID %>').style.display = "none";
                document.getElementById('<%=tdPedestrian_StillHospital.ClientID %>').style.display = "none";
                var Val = document.getElementById('<%=hdnPedestrian.ClientID%>').value;
                //check value of variable if it is 1 than blank related fields else remain as it is.
                if (Val != '1') {
                    document.getElementById('<%=txtPedestrian_Date_Admitted_to_Hospital.ClientID %>').value = "";
                    //document.getElementById('<%=rdoPedestrian_Still_in_Hospital.ClientID %>').options[document.getElementById("<%=rdoDriver_Still_in_Hospital.ClientID %>").selectedIndex].value="-1";
                }
            }
        }
        //Check Other Driver Admitted to hospital radio button selcted true or false. as per answer,display/Hide Informaiton
        function checkOth_Driver_AdmittedHospital() {
            ctl = document.getElementById('<%=rdoOther_Driver_Admitted_to_Hospital.ClientID %>');
            rdo = document.getElementById(ctl.id + "_0");
            //check radiobuttonList value
            if (rdo.checked == true) {
                document.getElementById('<%=tdOth_Driver_DateAdmitted.ClientID %>').style.display = "block";
                document.getElementById('<%=tdOth_Driver_StillHospital.ClientID %>').style.display = "block";
            }
            else {
                document.getElementById('<%=tdOth_Driver_DateAdmitted.ClientID %>').style.display = "none";
                document.getElementById('<%=tdOth_Driver_StillHospital.ClientID %>').style.display = "none";
                var Val = document.getElementById('<%=hdnOVDriver.ClientID%>').value;
                //check value of variable if it is 1 than blank related fields else remain as it is.
                if (Val != '1') {
                    document.getElementById('<%=txtOther_Driver_Date_Admitted_to_Hospital.ClientID %>').value = "";
                    //document.getElementById('<%=rdoOther_Driver_Still_in_Hospital.ClientID %>').options[document.getElementById("<%=rdoDriver_Still_in_Hospital.ClientID %>").selectedIndex].value="-1";
                }
            }
        }
        //Check Other Vehicle Passenger Admitted Hospital radio button selected true or false. as per answer,display/Hide Informaiton
        function CheckOth_Veh_PassAdmittedHospital() {
            ctl = document.getElementById('<%=rdoOth_Veh_Pass_Admitted_to_Hospital.ClientID %>');
            rdo = document.getElementById(ctl.id + "_0");
            //Check radiobuttonlist value
            if (rdo.checked == true) {
                document.getElementById('<%=tdOth_Ven_Pass_DateAdmitted.ClientID %>').style.display = "block";
                document.getElementById('<%=tdOth_Ven_Pass_StillHospital.ClientID %>').style.display = "block";
            }
            else {
                document.getElementById('<%=tdOth_Ven_Pass_DateAdmitted.ClientID %>').style.display = "none";
                document.getElementById('<%=tdOth_Ven_Pass_StillHospital.ClientID %>').style.display = "none";
                var Val = document.getElementById('<%=hdnOthVehPass.ClientID%>').value;
                //check value of variable if it is 1 than blank related fields else remain as it is.
                if (Val != '1') {
                    document.getElementById('<%=txtOth_Veh_Pass_Date_Admitted_to_Hospital.ClientID %>').value = "";
                    //document.getElementById('<%=rdoOth_Veh_Pass_Still_in_Hospital.ClientID %>').options[document.getElementById("<%=rdoDriver_Still_in_Hospital.ClientID %>").selectedIndex].value="-1";
                }
            }
        }
        //Chedck Driver Admitted to Hospital radiobutton selected true or false. as per answer,dispplay/Hide Informaiton
        function CheckAdmittedHospital() {
            ctl = document.getElementById('<%=rdoDriver_Admitted_to_Hospital.ClientID %>');
            rdo = document.getElementById(ctl.id + "_0");
            //Check radiobuttonlist value
            if (rdo.checked == true) {
                document.getElementById('<%=tdDateAdmitted.ClientID %>').style.display = "block";
                document.getElementById('<%=tdStillHospital.ClientID %>').style.display = "block";
            }
            else {
                document.getElementById('<%=tdDateAdmitted.ClientID %>').style.display = "none";
                document.getElementById('<%=tdStillHospital.ClientID %>').style.display = "none";
                var Val = document.getElementById('<%=hdnDriver_Admitted_to_Hospital.ClientID%>').value;
                //check value of variable if it is 1 than blank related fields else remain as it is.
                if (Val != '1') {
                    document.getElementById('<%=txtDriver_Date_Admitted_to_Hospital.ClientID %>').value = "";
                    //document.getElementById('<%=rdoDriver_Still_in_Hospital.ClientID %>').options[document.getElementById("<%=rdoDriver_Still_in_Hospital.ClientID %>").selectedIndex].value="-1";
                }
            }
        }
        //CHeck Injury Occured radio button selected true or false. as per answer,display/Hide Infromation
        function CheckInjuryOccured() {
            ctl = document.getElementById('<%=rdoLoss_offsite.ClientID %>');
            rdo = document.getElementById(ctl.id + "_0");
            //check radiobutton value. if offsite is selected than display related fileds elase remins hidden
            if (rdo.checked == true) {
                document.getElementById('<%=trLossInjuryOccured.ClientID %>').style.display = "none";
            }
            else {
                document.getElementById('<%=trLossInjuryOccured.ClientID %>').style.display = "block";
                var Val = document.getElementById('<%=hdnOnsiteOffsite.ClientID%>').value;
                //check value of variable if it is 1 than blank related fields else remain as it is.
                if (Val != '1') {
                    document.getElementById('<%=txtOffsite_Address1.ClientID %>').value = "";
                    document.getElementById('<%=txtOffsite_Address2.ClientID %>').value = "";
                    document.getElementById('<%=txtOffsite_City.ClientID %>').value = "";
                    document.getElementById('<%=txtOffsite_zip.ClientID %>').value = "";
                    document.getElementById('<%=ddlOffsite_State.ClientID %>').selectedIndex = 0;
                }
            }
        }


        //used to set Menu Style
        function SetMenuStyle(index) {
            var i;
            for (i = 1; i <= 11; i++) {
                var tb = document.getElementById("ALMenu" + i);
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
        //Used to Show Current Panel. as per Panel Number. passed panel number is displyed and other are set to hidden.
        function ShowPanel(index) {
            SetMenuStyle(index);
            var op = '<%=strPageOpeMode%>';
            //check Current Mode
            if (op == "view") {
                document.getElementById("<%=dvEdit.ClientID %>").style.display = "none";
                document.getElementById("<%=dvView.ClientID%>").style.display = "block";
                ShowPanelView(index);
            }
            else {
                document.getElementById("<%=dvView.ClientID%>").style.display = "none";
                //check if index is 1 than display Location Section.
                if (index == 1) {
                    document.getElementById("<%=pnlLocation.ClientID%>").style.display = "block";
                    document.getElementById("<%=pnlLossInformation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlInsuredVehicle.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlInsuredVehicleDriver.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlInsuredVehiclePassenger.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlOtherVehicle.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlOtherVehicleDriver.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlOtherVehiclePassenger.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlpedstrian.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlWitnesses.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlComments.ClientID%>").style.display = "none";
                }
                //check if index is 2 than display Loss Infrmation Section.
                if (index == 2) {
                    document.getElementById("<%=pnlLocation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlLossInformation.ClientID%>").style.display = "block";
                    document.getElementById("<%=pnlInsuredVehicle.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlInsuredVehicleDriver.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlInsuredVehiclePassenger.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlOtherVehicle.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlOtherVehicleDriver.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlOtherVehiclePassenger.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlpedstrian.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlWitnesses.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlComments.ClientID%>").style.display = "none";
                }
                //check if index is 3 than display Insured Vehicle Section.
                if (index == 3) {
                    document.getElementById("<%=pnlLocation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlLossInformation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlInsuredVehicle.ClientID%>").style.display = "block";
                    document.getElementById("<%=pnlInsuredVehicleDriver.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlInsuredVehiclePassenger.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlOtherVehicle.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlOtherVehicleDriver.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlOtherVehiclePassenger.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlpedstrian.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlWitnesses.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlComments.ClientID%>").style.display = "none";
                }
                //check if index is 4 than display Insured Vehicle Driver Section.
                if (index == 4) {
                    document.getElementById("<%=pnlLocation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlLossInformation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlInsuredVehicle.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlInsuredVehicleDriver.ClientID%>").style.display = "block";
                    document.getElementById("<%=pnlInsuredVehiclePassenger.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlOtherVehicle.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlOtherVehicleDriver.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlOtherVehiclePassenger.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlpedstrian.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlWitnesses.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlComments.ClientID%>").style.display = "none";
                }
                //check if index is 5 than display Insured Vehicle Passenger Section.
                if (index == 5) {
                    document.getElementById("<%=pnlLocation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlLossInformation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlInsuredVehicle.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlInsuredVehicleDriver.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlInsuredVehiclePassenger.ClientID%>").style.display = "block";
                    document.getElementById("<%=pnlOtherVehicle.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlOtherVehicleDriver.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlOtherVehiclePassenger.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlpedstrian.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlWitnesses.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlComments.ClientID%>").style.display = "none";
                }
                //check if index is 6 than display Other Vehicle Section.
                if (index == 6) {
                    document.getElementById("<%=pnlLocation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlLossInformation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlInsuredVehicle.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlInsuredVehicleDriver.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlInsuredVehiclePassenger.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlOtherVehicle.ClientID%>").style.display = "block";
                    document.getElementById("<%=pnlOtherVehicleDriver.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlOtherVehiclePassenger.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlpedstrian.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlWitnesses.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlComments.ClientID%>").style.display = "none";
                }
                //check if index is 7 than display Other Vehicle Driver Section.
                if (index == 7) {
                    document.getElementById("<%=pnlLocation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlLossInformation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlInsuredVehicle.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlInsuredVehicleDriver.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlInsuredVehiclePassenger.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlOtherVehicle.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlOtherVehicleDriver.ClientID%>").style.display = "block";
                    document.getElementById("<%=pnlOtherVehiclePassenger.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlpedstrian.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlWitnesses.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlComments.ClientID%>").style.display = "none";
                }
                //check if index is 8 than display Other Vehicle Passenger Section.
                if (index == 8) {
                    document.getElementById("<%=pnlLocation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlLossInformation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlInsuredVehicle.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlInsuredVehicleDriver.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlInsuredVehiclePassenger.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlOtherVehicle.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlOtherVehicleDriver.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlOtherVehiclePassenger.ClientID%>").style.display = "block";
                    document.getElementById("<%=pnlpedstrian.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlWitnesses.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlComments.ClientID%>").style.display = "none";
                }
                //check if index is 9 than display Pedestrian Section.
                if (index == 9) {
                    document.getElementById("<%=pnlLocation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlLossInformation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlInsuredVehicle.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlInsuredVehicleDriver.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlInsuredVehiclePassenger.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlOtherVehicle.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlOtherVehicleDriver.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlOtherVehiclePassenger.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlpedstrian.ClientID%>").style.display = "block";
                    document.getElementById("<%=pnlWitnesses.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlComments.ClientID%>").style.display = "none";
                }
                //check if index is 10 than display Witness Section.
                if (index == 10) {
                    document.getElementById("<%=pnlLocation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlLossInformation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlInsuredVehicle.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlInsuredVehicleDriver.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlInsuredVehiclePassenger.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlOtherVehicle.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlOtherVehicleDriver.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlOtherVehiclePassenger.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlpedstrian.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlWitnesses.ClientID%>").style.display = "block";
                    document.getElementById("<%=pnlComments.ClientID%>").style.display = "none";
                }
                //check if index is 11 than display Comments and Attchment Section.
                if (index == 11) {
                    document.getElementById("<%=pnlLocation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlLossInformation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlInsuredVehicle.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlInsuredVehicleDriver.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlInsuredVehiclePassenger.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlOtherVehicle.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlOtherVehicleDriver.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlOtherVehiclePassenger.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlpedstrian.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlWitnesses.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlComments.ClientID%>").style.display = "block";
                }
            }

            document.getElementById("<%=hdnCureentPanel.ClientID%>").value = index;
        }
        //use to set panel in View MOde. according to value passed the panel is displayed in View Mode
        function ShowPanelView(index) {
            //set menu style
            SetMenuStyle(index);
            if (index == 1) {
                document.getElementById("<%=pnlViewLocation.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlViewLossInformation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewInsuredVehicle.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewInsuredVehicleDriver.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewInsuredVehiclePassenger.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewOtherVehicle.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewOtherVehicleDriver.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewOtherVehiclePassenger.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewpedstrian.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewWitnesses.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewComments.ClientID%>").style.display = "none";
            }
            if (index == 2) {
                document.getElementById("<%=pnlViewLocation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewLossInformation.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlViewInsuredVehicle.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewInsuredVehicleDriver.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewInsuredVehiclePassenger.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewOtherVehicle.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewOtherVehicleDriver.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewOtherVehiclePassenger.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewpedstrian.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewWitnesses.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewComments.ClientID%>").style.display = "none";
            }
            if (index == 3) {
                document.getElementById("<%=pnlViewLocation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewLossInformation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewInsuredVehicle.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlViewInsuredVehicleDriver.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewInsuredVehiclePassenger.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewOtherVehicle.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewOtherVehicleDriver.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewOtherVehiclePassenger.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewpedstrian.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewWitnesses.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewComments.ClientID%>").style.display = "none";
            }
            if (index == 4) {
                document.getElementById("<%=pnlViewLocation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewLossInformation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewInsuredVehicle.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewInsuredVehicleDriver.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlViewInsuredVehiclePassenger.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewOtherVehicle.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewOtherVehicleDriver.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewOtherVehiclePassenger.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewpedstrian.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewWitnesses.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewComments.ClientID%>").style.display = "none";
            }
            if (index == 5) {
                document.getElementById("<%=pnlViewLocation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewLossInformation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewInsuredVehicle.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewInsuredVehicleDriver.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewInsuredVehiclePassenger.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlViewOtherVehicle.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewOtherVehicleDriver.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewOtherVehiclePassenger.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewpedstrian.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewWitnesses.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewComments.ClientID%>").style.display = "none";
            }
            if (index == 6) {
                document.getElementById("<%=pnlViewLocation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewLossInformation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewInsuredVehicle.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewInsuredVehicleDriver.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewInsuredVehiclePassenger.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewOtherVehicle.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlViewOtherVehicleDriver.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewOtherVehiclePassenger.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewpedstrian.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewWitnesses.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewComments.ClientID%>").style.display = "none";
            }
            if (index == 7) {
                document.getElementById("<%=pnlViewLocation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewLossInformation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewInsuredVehicle.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewInsuredVehicleDriver.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewInsuredVehiclePassenger.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewOtherVehicle.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewOtherVehicleDriver.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlViewOtherVehiclePassenger.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewpedstrian.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewWitnesses.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewComments.ClientID%>").style.display = "none";
            }
            if (index == 8) {
                document.getElementById("<%=pnlViewLocation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewLossInformation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewInsuredVehicle.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewInsuredVehicleDriver.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewInsuredVehiclePassenger.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewOtherVehicle.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewOtherVehicleDriver.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewOtherVehiclePassenger.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlViewpedstrian.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewWitnesses.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewComments.ClientID%>").style.display = "none";
            }
            if (index == 9) {
                document.getElementById("<%=pnlViewLocation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewLossInformation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewInsuredVehicle.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewInsuredVehicleDriver.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewInsuredVehiclePassenger.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewOtherVehicle.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewOtherVehicleDriver.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewOtherVehiclePassenger.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewpedstrian.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlViewWitnesses.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewComments.ClientID%>").style.display = "none";
            }
            if (index == 10) {
                document.getElementById("<%=pnlViewLocation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewLossInformation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewInsuredVehicle.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewInsuredVehicleDriver.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewInsuredVehiclePassenger.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewOtherVehicle.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewOtherVehicleDriver.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewOtherVehiclePassenger.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewpedstrian.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewWitnesses.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlViewComments.ClientID%>").style.display = "none";
            }
            if (index == 11) {
                document.getElementById("<%=pnlViewLocation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewLossInformation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewInsuredVehicle.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewInsuredVehicleDriver.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewInsuredVehiclePassenger.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewOtherVehicle.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewOtherVehicleDriver.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewOtherVehiclePassenger.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewpedstrian.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewWitnesses.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewComments.ClientID%>").style.display = "block";
            }
        }


        function ValidateFieldsLocationInformation(sender, args) {

            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnLocationContactIDs.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnLocationContactErrorMsgs.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnLocationContactIDs.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {

                        case "textarea":
                        case "text": if (ctrl.value == '') bEmpty = true; break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
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
        function ValidateFieldsLossInformation(sender, args) {
            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnLossInformationIDs.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnLossInformationErrorMsgs.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnLossInformationIDs.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {

                        case "textarea": if (ctrl.value == '') bEmpty = true; break;
                        case "text":
                            if (ctrl.value == '') {
                                if (ctrl.id == 'ctl00_ContentPlaceHolder1_txtOffsite_Address1' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtOffsite_Address2' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtOffsite_City' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtOffsite_zip') {
                                    var rdb = document.getElementById('ctl00_ContentPlaceHolder1_rdoLoss_offsite_1');
                                    //used to check dropdowns selected value. if it is equal to Disposed than display Disposal type control else hide.
                                    if (rdb.checked)
                                        bEmpty = true;
                                }
                                else if (ctrl.id == 'ctl00_ContentPlaceHolder1_txtPolice_Agency' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtPolice_Case_Number' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtPolice_Station_Phone_Number') {
                                    var rdbpolice = document.getElementById('ctl00_ContentPlaceHolder1_rdoWere_Police_Notified_0');
                                    //used to check dropdowns selected value. if it is equal to Disposed than display Disposal type control else hide.
                                    if (rdbpolice.checked)
                                        bEmpty = true;
                                }
                                else
                                    bEmpty = true;
                            } break;

                        case "select-one":
                            if (ctrl.selectedIndex == 0) {
                                if (ctrl.id == 'ctl00_ContentPlaceHolder1_ddlOffsite_State') {
                                    var rdb = document.getElementById('ctl00_ContentPlaceHolder1_rdoLoss_offsite_1');
                                    //used to check dropdowns selected value. if it is equal to Disposed than display Disposal type control else hide.
                                    if (rdb.checked)
                                        bEmpty = true;
                                }
                                else
                                    bEmpty = true;
                            }
                            break;

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

        function ValidateFieldsInsuredVehicle(sender, args) {

            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnInsuredVehicleIDs.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnInsuredVehicleErrorMsgs.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnInsuredVehicleIDs.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {

                        case "textarea":
                        case "text": if (ctrl.value == '') bEmpty = true; break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
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
        function ValidateFieldsInsuredVehicleDriver(sender, args) {

            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnInsuredVehicleDriverIDs.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnInsuredVehicleDriverErrorMsgs.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnInsuredVehicleDriverIDs.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {

                        case "textarea":
                        case "text":
                            if (ctrl.value == '') {
                                if (ctrl.id == 'ctl00_ContentPlaceHolder1_txtDriver_Date_Admitted_to_Hospital') {
                                    var rdb = document.getElementById('ctl00_ContentPlaceHolder1_rdoDriver_Admitted_to_Hospital_0');
                                    //used to check dropdowns selected value. if it is equal to Disposed than display Disposal type control else hide.
                                    if (rdb.checked)
                                        bEmpty = true;
                                }
                                else
                                    bEmpty = true;
                            } break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
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

        function ValidateFieldsInsuredVehiclePassenger(sender, args) {

            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnInsuredVehiclePassengerIDs.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnInsuredVehiclePassengerErrorMsgs.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnInsuredVehiclePassengerIDs.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {

                        case "textarea":
                        case "text": if (ctrl.value == '') bEmpty = true; break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
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
        function ValidateFieldsOtherVehicle(sender, args) {

            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnOtherVehicleIDs.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnOtherVehicleErrorMsgs.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnOtherVehicleIDs.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {

                        case "textarea":
                        case "text": if (ctrl.value == '') bEmpty = true; break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
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

        function ValidateFieldsOtherVehicleDriver(sender, args) {

            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnOtherVehicleDriverIDs.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnOtherVehicleDriverErrorMsgs.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnOtherVehicleDriverIDs.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {

                        case "textarea":
                        case "text":
                            if (ctrl.value == '') {
                                if (ctrl.id == 'ctl00_ContentPlaceHolder1_txtOther_Driver_Date_Admitted_to_Hospital') {
                                    var rdb = document.getElementById('ctl00_ContentPlaceHolder1_rdoOther_Driver_Admitted_to_Hospital_0');
                                    //used to check dropdowns selected value. if it is equal to Disposed than display Disposal type control else hide.
                                    if (rdb.checked)
                                        bEmpty = true;
                                }
                                else
                                    bEmpty = true;
                            } break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
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

        function ValidateFieldsOtherVehiclePassenger(sender, args) {

            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnOtherVehiclePassengerIDs.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnOtherVehiclePassengerErrorMsgs.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnOtherVehiclePassengerIDs.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {

                        case "textarea":
                        case "text":
                            if (ctrl.value == '') {
                                if (ctrl.id == 'ctl00_ContentPlaceHolder1_txtOth_Veh_Pass_Date_Admitted_to_Hospital') {
                                    var rdb = document.getElementById('ctl00_ContentPlaceHolder1_rdoOth_Veh_Pass_Admitted_to_Hospital_0');
                                    //used to check dropdowns selected value. if it is equal to Disposed than display Disposal type control else hide.
                                    if (rdb.checked)
                                        bEmpty = true;
                                }
                                else
                                    bEmpty = true;
                            } break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
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
        function ValidateFieldsPedestrian(sender, args) {

            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnPedestrianIDs.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnPedestrianErrorMsgs.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnPedestrianIDs.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {

                        case "textarea":
                        case "text":
                            if (ctrl.value == '') {
                                if (ctrl.id == 'ctl00_ContentPlaceHolder1_txtPedestrian_Date_Admitted_to_Hospital') {
                                    var rdb = document.getElementById('ctl00_ContentPlaceHolder1_rdoPedestrian_Admitted_to_Hospital_0');
                                    //used to check dropdowns selected value. if it is equal to Disposed than display Disposal type control else hide.
                                    if (rdb.checked)
                                        bEmpty = true;
                                }
                                else
                                    bEmpty = true;
                            } break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
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

        function ValidateFieldsWitness(sender, args) {
            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnWitnessIDs.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnWitnessErrorMsgs.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnWitnessIDs.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {

                        case "textarea":
                        case "text": if (ctrl.value == '') bEmpty = true; break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
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

        function ValidateFieldsComments(sender, args) {

            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnCommentsID.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnCommentsErrorMsgs.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnCommentsID.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {

                        case "textarea":
                        case "text": if (ctrl.value == '') bEmpty = true; break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
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
        function SetFocusAge() {
            document.getElementById('<%=txtDriver_Date_of_Birth.ClientID %>').focus();
        }


        function CountAgeAL(Args) {
            var arrCtrlIDs = Args.split(',');
            var ControlID = arrCtrlIDs[0];
            var TargetControlID = arrCtrlIDs[1];
            var BTextBox = document.getElementById(ControlID);
            var AgeBox = document.getElementById(TargetControlID);
            if (BTextBox != null || AgeBox != null) {

                if (BTextBox.value.trim() != '') {
                    var bDate = new Date(BTextBox.value);
                    var now = new Date();
                    bday = (bDate.getDate());
                    bmo = (bDate.getMonth());
                    byr = (bDate.getFullYear());
                    tday = now.getDate();
                    tmo = (now.getMonth());
                    tyr = (now.getFullYear());
                    if (bDate > now) {
                        alert('Birth Date must be less than current date');
                        var mn;
                        if (now.getMonth() + 1 < 9) {
                            mn = '0' + (now.getMonth() + 1);
                        }
                        else {
                            mn = now.getMonth() + 1;
                        }
                        //            BTextBox.value=mn + '/' + tday + '/' + tyr;
                        //            AgeBox.innerText = "0";
                        document.getElementById(ControlID).focus();
                        return false;
                    }
                    bmo = bmo - 1;
                    if ((tmo > bmo) || (tmo == bmo & tday >= bday))
                    { age = byr; }
                    else
                    { age = byr + 1; }
                    AgeBox.innerText = tyr - age;

                    return true;
                }
                else {
                    //                    document.getElementById('ctl00_ContentPlaceHolder1_txtPedestrianAgeCount').value = '';
                    //                    document.getElementById('ctl00_ContentPlaceHolder1_txtOth_Veh_Pass_AgeCount').value = '';
                    //                    document.getElementById('ctl00_ContentPlaceHolder1_txtOther_Driver_Date_of_Birth').value = '';
                    //                    document.getElementById('ctl00_ContentPlaceHolder1_txtPassengerAgeCount').value = '';
                    //                    document.getElementById('ctl00_ContentPlaceHolder1_txtDriverAgeCount').value = '';         
                    return true;
                }
            }
        }

        jQuery(function ($) {
            $("#<%=txtDate_Of_Loss.ClientID%>").mask("99/99/9999");
            $("#<%=txtDate_Reported_To_Sonic.ClientID%>").mask("99/99/9999");
            $("#<%=txtDriver_Date_Of_Initial_Treatment.ClientID%>").mask("99/99/9999");
            $("#<%=txtDriver_Date_Admitted_to_Hospital.ClientID%>").mask("99/99/9999");
            $("#<%=txtOther_Driver_Date_Admitted_to_Hospital.ClientID%>").mask("99/99/9999");
            $("#<%=txtOth_Veh_Pass_Date_Admitted_to_Hospital.ClientID%>").mask("99/99/9999");
            $("#<%=txtPedestrian_Date_Admitted_to_Hospital.ClientID%>").mask("99/99/9999");
            $("#<%=txtContactFaxNumber.ClientID%>").mask("999-999-9999");
            $("#<%=txtPolice_Station_Phone_Number.ClientID%>").mask("999-999-9999");
            $("#<%=txtOwner_Work_Phone.ClientID%>").mask("999-999-9999");
            $("#<%=txtOwner_Home_Phone.ClientID%>").mask("999-999-9999");
            $("#<%=txtOwner_Alternate_Phone.ClientID%>").mask("999-999-9999");
            $("#<%=txtDriver_Work_Phone.ClientID%>").mask("999-999-9999");
            $("#<%=txtDriver_Home_Phone.ClientID%>").mask("999-999-9999");
            $("#<%=txtDriver_Altermate_Phone.ClientID%>").mask("999-999-9999");
            $("#<%=txtPassenger_Work_Phone.ClientID%>").mask("999-999-9999");
            $("#<%=txtPassenger_Home_Phone.ClientID%>").mask("999-999-9999");
            $("#<%=txtPassenger_Alternate_Phone.ClientID%>").mask("999-999-9999");
            $("#<%=txtOther_Vehicle_Insurance_Co_Phone.ClientID%>").mask("999-999-9999");
            $("#<%=txtOther_Vehicle_Owner_Work_Phone.ClientID%>").mask("999-999-9999");
            $("#<%=txtOther_Vehicle_Owner_Home_Phone.ClientID%>").mask("999-999-9999");
            $("#<%=txtOther_Vehicle_Location_Telephone.ClientID%>").mask("999-999-9999");
            $("#<%=txtOther_Vehicle_Owner_Alternate_Phone.ClientID%>").mask("999-999-9999");
            $("#<%=txtOther_Driver_Work_Phone.ClientID%>").mask("999-999-9999");
            $("#<%=txtOther_Driver_Home_Phone.ClientID%>").mask("999-999-9999");
            $("#<%=txtOth_Veh_Pass_Work_Phone.ClientID%>").mask("999-999-9999");
            $("#<%=txtOth_Veh_Pass_Home_Phone.ClientID%>").mask("999-999-9999");
            $("#<%=txtOth_Veh_Pass_Alternate_Phone.ClientID%>").mask("999-999-9999");
            $("#<%=txtPedestrian_Work_Phone.ClientID%>").mask("999-999-9999");
            $("#<%=txtPedestrian_Home_Phone.ClientID%>").mask("999-999-9999");
            $("#<%=txtPedestrian_Alternate_Phone.ClientID%>").mask("999-999-9999");
            $("#<%=txtWitness_Home_Phone.ClientID%>").mask("999-999-9999");
            $("#<%=txtWitness_Work_Phone.ClientID%>").mask("999-999-9999");
            $("#<%=txtWitness_Alternate_Phone.ClientID%>").mask("999-999-9999");
            $("#<%=txtContact_Best_Time.ClientID%>").mask("99:99");
            $("#<%=txtTime_Of_Loss.ClientID%>").mask("99:99");
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
        <asp:ValidationSummary ID="vsInsuredVehicleInfo" runat="server" ShowSummary="false"
            ShowMessageBox="true" HeaderText="Verify the following fields in Insured Vehicle Information Panel:"
            BorderWidth="1" BorderColor="DimGray" ValidationGroup="vsInsuredVehicleInfoGroup"
            CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsInsuredDriverInfo" runat="server" ShowSummary="false"
            ShowMessageBox="true" HeaderText="Verify the following fields in Insured Vehicle Driver Information Panel:"
            BorderWidth="1" BorderColor="DimGray" ValidationGroup="vsInsuredDriverInfoGroup"
            CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsInsuredPassengerInfo" runat="server" ShowSummary="false"
            ShowMessageBox="true" HeaderText="Verify the following fields in Insured Vehicle Passenger Information Panel:"
            BorderWidth="1" BorderColor="DimGray" ValidationGroup="vsInsuredPassengerInfoGroup"
            CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsOtherVehicleInfo" runat="server" ShowSummary="false"
            ShowMessageBox="true" HeaderText="Verify the following fields in Other Vehicle Information Panel:"
            BorderWidth="1" BorderColor="DimGray" ValidationGroup="vsOtherVehicleInfoGroup"
            CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsOtherVehicleDriverInfo" runat="server" ShowSummary="false"
            ShowMessageBox="true" HeaderText="Verify the following fields in Other Vehicle Driver Information Panel:"
            BorderWidth="1" BorderColor="DimGray" ValidationGroup="vsOtherVehicleDriverInfoGroup"
            CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsOtherVehiclePassengerInfo" runat="server" ShowSummary="false"
            ShowMessageBox="true" HeaderText="Verify the following fields in Other Vehicle Passenger Information Panel:"
            BorderWidth="1" BorderColor="DimGray" ValidationGroup="vsOtherVehiclePassengerInfoGroup"
            CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsPadestrianInfo" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Pedestrian Information Panel:" BorderWidth="1"
            BorderColor="DimGray" ValidationGroup="vsPadestrianInfoGroup" CssClass="errormessage">
        </asp:ValidationSummary>
        <asp:ValidationSummary ID="vsWitnessInfo" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Witness Information Panel:" BorderWidth="1"
            BorderColor="DimGray" ValidationGroup="vsWitnessInfoGroup" CssClass="errormessage">
        </asp:ValidationSummary>
        <asp:ValidationSummary ID="vsAttchments" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Comments/Attachment Panel:" BorderWidth="1"
            BorderColor="DimGray" ValidationGroup="AddAttachment" CssClass="errormessage">
        </asp:ValidationSummary>
        <asp:ValidationSummary ID="vsComments" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Comments Panel:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsCommentsGroup" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <asp:HiddenField ID="hdnCureentPanel" runat="server" />
    <div style="display: none;">
        <asp:TextBox ID="txtCompare" runat="server" Height="0px" Width="0px" Text="0.00"></asp:TextBox>
    </div>
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
                            <asp:UpdatePanel runat="Server" ID="updSonic" UpdateMode="Always">
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
                                        <asp:Menu ID="mnuAL" runat="server" DataSourceID="dsALMenu" StaticEnableDefaultPopOutImage="false">
                                            <StaticItemTemplate>
                                                <table cellpadding="5" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="100%">
                                                            <span id="ALMenu<%#Container.ItemIndex+1%>" onclick="javascript:ShowPanel(<%#Container.ItemIndex+1%>);"
                                                                class="LeftMenuStatic">
                                                                <%#Eval("Text")%>&nbsp;
                                                                <asp:Label ID="MenuAsterisk" runat="server" Text="*" Style="color: Red; display: none"></asp:Label>
                                                            </span>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </StaticItemTemplate>
                                        </asp:Menu>
                                        <asp:SiteMapDataSource ID="dsALMenu" runat="server" SiteMapProvider="ALMenuProvider"
                                            ShowStartingNode="false" />
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
                                                <asp:UpdatePanel runat="server" ID="updLocationInfo">
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
                                                                    When to Contact<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtContact_Best_Time" Width="170px"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revtxtContact_Best_Time" runat="server" ControlToValidate="txtContact_Best_Time"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                        ErrorMessage="Invalid When to Contact Time." Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
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
                                                                    Fax Number<span id="Span1" style="color: Red; display: none;" runat="server">*</span><br />
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
                                                <asp:UpdatePanel runat="server" ID="updLossInfo">
                                                    <ContentTemplate>
                                                        <asp:HiddenField runat="Server" ID="hdnLoss" />
                                                        <asp:HiddenField ID="hdnOnsiteOffsite" runat="server" Value="0" />
                                                        <asp:HiddenField ID="hdnPoliceNotify" runat="server" Value="0" />
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Accident State&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:DropDownList runat="server" ID="ddlClaimant_state" SkinID="ddlSONIC">
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
                                                                    Date of Loss&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtCurrentDate" runat="server" Style="display: none"></asp:TextBox>
                                                                    <asp:TextBox ID="txtDate_Of_Loss" runat="server"></asp:TextBox>
                                                                    <img alt="Date of Loss" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Of_Loss', 'mm/dd/y',CompareDateLessThanToday,'ctl00_ContentPlaceHolder1_txtDate_Of_Loss');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" /><br />
                                                                    <asp:CompareValidator ID="cmptxtDate_Of_Loss" runat="server" ControlToCompare="txtCurrentDate"
                                                                        ControlToValidate="txtDate_Of_Loss" Display="Dynamic" Text="*" ErrorMessage="Loss Date is not Greater Than current date."
                                                                        Operator="LessThanEqual" Type="Date" ValidationGroup="vsLossInfoGroup"></asp:CompareValidator>
                                                                    <asp:CustomValidator ID="csmvtxtDate_Of_Loss" runat="server" ControlToValidate="txtDate_Of_Loss"
                                                                        ValidationGroup="vsLossInfoGroup" ClientValidationFunction="CheckDate" ErrorMessage="Loss Date is not valid."
                                                                        Display="None">
                                                                    </asp:CustomValidator>
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
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                        ErrorMessage="Invalid Time for Incident." Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Auto Liability - Type&nbsp;<span id="Span191" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList runat="server" ID="ddlAuto_Liability_Type" SkinID="ddlSONIC">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td colspan="3">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Injury Occured
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:RadioButtonList runat="server" ID="rdoLoss_offsite" onClick="CheckInjuryOccured();">
                                                                        <asp:ListItem Value="N">Onsite</asp:ListItem>
                                                                        <asp:ListItem Value="Y">Offsite</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%" id="trLossInjuryOccured"
                                                                        runat="server" style="display: none;">
                                                                        <tr>
                                                                            <td style="width: 18%">
                                                                                Address 1&nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td style="width: 4%">
                                                                                :
                                                                            </td>
                                                                            <td style="width: 28%">
                                                                                <asp:TextBox runat="server" ID="txtOffsite_Address1" Width="170px" MaxLength="50"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Address 2&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td>
                                                                                :
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox runat="server" ID="txtOffsite_Address2" Width="170px" MaxLength="50"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                City&nbsp;<span id="Span8" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td>
                                                                                :
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox runat="server" ID="txtOffsite_City" Width="170px" MaxLength="50"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                State&nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td>
                                                                                :
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList runat="server" ID="ddlOffsite_State" SkinID="ddlSONIC">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Zip code&nbsp;<span id="Span10" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td>
                                                                                :
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox runat="server" ID="txtOffsite_zip" Width="170px" MaxLength="50"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    In Detail, Explain What Happened&nbsp;<span id="Span11" style="color: Red; display: none;" runat="server">*</span>
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
                                                                    Date Reported to Sonic&nbsp;<span id="Span12" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtDate_Reported_To_Sonic" runat="server"></asp:TextBox>
                                                                    <img alt="Date Reported to Sonic" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Reported_To_Sonic', 'mm/dd/y',CompareDateLessThanToday,'ctl00_ContentPlaceHolder1_txtDate_Reported_To_Sonic');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" /><br />
                                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtCurrentDate"
                                                                        ControlToValidate="txtDate_Reported_To_Sonic" Display="Dynamic" Text="*" ErrorMessage=" Date Reported to Sonic is not Greater Than current date."
                                                                        Operator="LessThanEqual" Type="Date" ValidationGroup="vsLossInfoGroup"></asp:CompareValidator>
                                                                    <%--  <asp:RegularExpressionValidator ID="revLossReportedToSONIC" runat="server" ControlToValidate="txtDate_Reported_To_Sonic"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                        ErrorMessage="Date of Reported to SONIC is not valid." Display="none" ValidationGroup="vsLossInfoGroup"></asp:RegularExpressionValidator>--%>
                                                                    <asp:CustomValidator ID="cvDate_Reported_To_Sonic" runat="server" ControlToValidate="txtDate_Reported_To_Sonic"
                                                                        ValidationGroup="vsLossInfoGroup" ClientValidationFunction="CheckDate" ErrorMessage="Date of Reported to SONIC is not valid."
                                                                        Display="None">
                                                                    </asp:CustomValidator>
                                                                </td>
                                                                <td align="left">
                                                                    Weather Conditions&nbsp;<span id="Span13" style="color: Red; display: none;" runat="server">*</span>
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
                                                                    Road Conditions&nbsp;<span id="Span14" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtRoad_Conditions" Width="170px" MaxLength="50"></asp:TextBox>
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
                                                            <tr>
                                                                <td align="left">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%" id="trLossPloiceNotified"
                                                                        runat="server" style="display: none;">
                                                                        <tr>
                                                                            <td style="width: 18%">
                                                                                Police&nbsp;<span id="Span15" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td style="width: 4%">
                                                                                :
                                                                            </td>
                                                                            <td style="width: 28%">
                                                                                <asp:TextBox runat="server" ID="txtPolice_Agency" Width="170px" MaxLength="50"></asp:TextBox>
                                                                            </td>
                                                                            <td style="width: 18%">
                                                                                Case Number&nbsp;<span id="Span16" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td style="width: 4%">
                                                                                :
                                                                            </td>
                                                                            <td style="width: 28%">
                                                                                <asp:TextBox runat="server" ID="txtPolice_Case_Number" Width="170px" MaxLength="50"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Station Phone Number&nbsp;<span id="Span17" style="color: Red; display: none;" runat="server">*</span><br />
                                                                                (xxx-xxx-xxxx)
                                                                            </td>
                                                                            <td>
                                                                                :
                                                                            </td>
                                                                            <td colspan="4">
                                                                                <asp:TextBox runat="server" ID="txtPolice_Station_Phone_Number" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                <asp:RegularExpressionValidator ID="revPolice_Station_Phone_Number" ControlToValidate="txtPolice_Station_Phone_Number"
                                                                                    runat="server" ValidationGroup="vsLossInfoGroup" ErrorMessage="Please Enter Police Station Phone in xxx-xxx-xxxx format."
                                                                                    Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Were Pedestrians Involved?
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:RadioButtonList ID="rdoPedestrian_Involved" SkinID="YesNoUnknownType" runat="server">
                                                                    </asp:RadioButtonList>
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
                                                                    <asp:RadioButtonList ID="rdoProperty_Damage" SkinID="YesNoUnknownType" runat="server">
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
                                                                    <asp:RadioButtonList ID="rdoWitnesses" SkinID="YesNoUnknownType" runat="server">
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
                                                                        ValidationGroup="vsLossInfoGroup" OnClientClick="return CheckValidationLossInfo();" />
                                                                    <asp:Button runat="server" ID="btnLossAudit" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();"
                                                                        ToolTip="View Audit Trail" CausesValidation="false" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlInsuredVehicle" runat="server" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Insured Vehicle</div>
                                                <asp:UpdatePanel runat="server" ID="updInsuredVehicle">
                                                    <ContentTemplate>
                                                        <asp:HiddenField runat="Server" ID="hdnInsured" />
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Vehicle Sub Type&nbsp;<span id="Span18" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:DropDownList runat="server" ID="ddlVehicle_Sub_Type" SkinID="ddlSONIC">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Fleet/Vehicle Number&nbsp;<span id="Span19" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtVehicle_Fleet_number" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Year&nbsp;<span id="Span20" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtYear" Width="170px" MaxLength="4" SkinID="txtYearWithRange"
                                                                        onblur="javascript:return YearRange(this,'1920','2050');"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revYear" runat="server" ControlToValidate="txtYear"
                                                                        Display="none" SetFocusOnError="false" ErrorMessage="Insured Vehicle Year is Invalid."
                                                                        ValidationExpression="[\d]{4}" ValidationGroup="vsInsuredVehicleInfoGroup"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left">
                                                                    Make&nbsp;<span id="Span21" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtMake" Width="170px" MaxLength="40"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Model&nbsp;<span id="Span22" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtModel" Width="170px" MaxLength="40"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    VIN&nbsp;<span id="Span23" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtVIN" Width="170px" MaxLength="40"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    License Plate Number&nbsp;<span id="Span24" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtLicense_Plate_Number" Width="170px" MaxLength="20"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    License Plate State&nbsp;<span id="Span25" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList runat="server" ID="ddlLicense_Plate_State" SkinID="ddlSONIC">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Vehicle Color&nbsp;<span id="Span26" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtVehicle_Color" Width="170px" MaxLength="20"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    Permissive Use
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:RadioButtonList runat="Server" ID="rdoPermissive_Use" SkinID="YesNoUnknownType">
                                                                    </asp:RadioButtonList>
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
                                                                    Type of Use
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:RadioButtonList runat="Server" ID="rdoType_Of_Use">
                                                                        <asp:ListItem Value="Business">Business</asp:ListItem>
                                                                        <asp:ListItem Value="Personal">Personal</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Description of Damage&nbsp;<span id="Span27" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <uc:ctrlMultiLineTextBox ID="txtVehicle_Damage_Description" runat="server" MaxLength="4000" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Repairs Completed
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:RadioButtonList runat="server" ID="rdoRepairs_Completed" SkinID="YesNoTypeNullSelection">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td align="left">
                                                                    Estimated Amount&nbsp;<span id="Span28" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    $<asp:TextBox runat="server" ID="txtRepairs_Estimated_Amount" Width="170px" MaxLength="50"
                                                                        onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"></asp:TextBox>
                                                                    <asp:CompareValidator ID="cvRepairs_Estimated_Amount" runat="server" ControlToValidate="txtRepairs_Estimated_Amount"
                                                                        ValidationGroup="vsInsuredVehicleInfoGroup" ErrorMessage="Please Enter Estimated Amount Greater Than $0.00."
                                                                        Type="Currency" Operator="GreaterThan" ControlToCompare="txtCompare" Display="none">
                                                                    </asp:CompareValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Drivable
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:RadioButtonList runat="server" ID="rdoDrivable" SkinID="YesNoUnknownType">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td align="left">
                                                                    Were there any passengers?
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:RadioButtonList runat="server" ID="rdoPassengers" SkinID="YesNoUnknownType">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Is the insured driver at fault?
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:RadioButtonList runat="server" ID="rdoInsured_Driver_At_Fault" SkinID="YesNoUnknownType">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Location where vehicle can be seen&nbsp;<span id="Span29" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtVehicle_Location" Width="170px" MaxLength="40"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Address 1&nbsp;<span id="Span30" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtVehicle_Location_Driver_Address_1" Width="170px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Address 2&nbsp;<span id="Span31" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtVehicle_Location_Driver_Address_2" Width="170px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    City&nbsp;<span id="Span43" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtVehicle_Location_Driver_City" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    State&nbsp;<span id="Span32" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:DropDownList runat="server" ID="ddlVehicle_Location_Driver_State" SkinID="ddlSONIC">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Zip Code&nbsp;<span id="Span33" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtVehicle_Location_Driver_ZipCode" Width="170px"
                                                                        MaxLength="10"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Owner Name&nbsp;<span id="Span34" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtOwner_Name" Width="170px" MaxLength="40"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    Work Telephone&nbsp;<span id="Span35" style="color: Red; display: none;" runat="server">*</span><br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtOwner_Work_Phone" Width="170px" MaxLength="13"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revOwner_Work_Phone" ControlToValidate="txtOwner_Work_Phone"
                                                                        runat="server" ValidationGroup="vsInsuredVehicleInfoGroup" ErrorMessage="Please Enter Work Phone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Address 1&nbsp;<span id="Span36" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtOwner_Address_1" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    Home Telephone&nbsp;<span id="Span37" style="color: Red; display: none;" runat="server">*</span><br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtOwner_Home_Phone" Width="170px" MaxLength="13"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revOwner_Home_Phone" ControlToValidate="txtOwner_Home_Phone"
                                                                        runat="server" ValidationGroup="vsInsuredVehicleInfoGroup" ErrorMessage="Please Enter Home Phone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Address 2&nbsp;<span id="Span38" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtOwner_Address_2" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    Alternate Telephone&nbsp;<span id="Span39" style="color: Red; display: none;" runat="server">*</span><br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtOwner_Alternate_Phone" Width="170px" MaxLength="13"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revOwner_Alternate_Phone" ControlToValidate="txtOwner_Alternate_Phone"
                                                                        runat="server" ValidationGroup="vsInsuredVehicleInfoGroup" ErrorMessage="Please Enter Alternate Phone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    City&nbsp;<span id="Span40" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtOwner_City" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    State&nbsp;<span id="Span41" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:DropDownList runat="server" ID="ddlOwner_State" SkinID="ddlSONIC">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Zip Code&nbsp;<span id="Span42" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtOwner_ZipCode" Width="170px" MaxLength="10"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" align="center">
                                                                    <asp:Button runat="server" ID="btnInsuredVehicleSave" Text="Save & Continue" OnClick="btnInsuredVehicleSave_Click"
                                                                        ValidationGroup="vsInsuredVehicleInfoGroup" OnClientClick="return CheckValidationInsuredVehicleInfo();" />
                                                                    <asp:Button runat="server" ID="btnInsuredVehicleAudit" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();"
                                                                        ToolTip="View Audit Trail" CausesValidation="false" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlInsuredVehicleDriver" runat="server" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Insured Vehicle Driver Information</div>
                                                <asp:UpdatePanel runat="server" ID="updInsuredDriver">
                                                    <ContentTemplate>
                                                        <asp:HiddenField runat="server" ID="hdnDriver_Admitted_to_Hospital" Value="0" />
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Name&nbsp;<span id="Span44" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtDriver_Name" Width="170px" MaxLength="40"></asp:TextBox>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Social Security Number&nbsp;<span id="Span45" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtDriver_SSN" Width="170px" MaxLength="13"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Address 1&nbsp;<span id="Span46" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtDriver_Address1" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    Date of Birth&nbsp;<span id="Span47" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtDriver_Date_of_Birth" runat="server" SkinID="txtDate" onblur="return CountAgeAL('ctl00_ContentPlaceHolder1_txtDriver_Date_of_Birth,ctl00_ContentPlaceHolder1_txtDriverAgeCount');"></asp:TextBox>
                                                                    <img alt="Date of Birth" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDriver_Date_of_Birth', 'mm/dd/y',CountAge,'ctl00_ContentPlaceHolder1_txtDriver_Date_of_Birth,ctl00_ContentPlaceHolder1_txtDriverAgeCount');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        onmouseout="javascript:ctl00_ContentPlaceHolder1_txtDriver_Date_of_Birth.focus();"
                                                                        align="middle" /><br />
                                                                    <%-- <asp:RegularExpressionValidator ID="revDriver_Date_of_Birth" runat="server" ControlToValidate="txtDriver_Date_of_Birth"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                        ErrorMessage="Driver Birth Date is not valid." Display="none" ValidationGroup="vsInsuredDriverInfoGroup"></asp:RegularExpressionValidator>--%>
                                                                    <asp:CustomValidator ID="cvDriver_Date_of_Birth" runat="server" ControlToValidate="txtDriver_Date_of_Birth"
                                                                        ValidationGroup="vsInsuredDriverInfoGroup" ClientValidationFunction="CheckDate"
                                                                        ErrorMessage="Driver Birth Date is not valid." Display="None">
                                                                    </asp:CustomValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Address 2&nbsp;<span id="Span48" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtDriver_Address2" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    Age&nbsp;<span id="Span49" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtDriverAgeCount" Width="170px" ReadOnly="true"
                                                                        EnableViewState="true"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    City&nbsp;<span id="Span50" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtDriver_City" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    Work Telephone&nbsp;<span id="Span51" style="color: Red; display: none;" runat="server">*</span><br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtDriver_Work_Phone" Width="170px" MaxLength="13"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revDriver_Work_Phone" ControlToValidate="txtDriver_Work_Phone"
                                                                        runat="server" ValidationGroup="vsInsuredDriverInfoGroup" ErrorMessage="Please Enter Driver work Phone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    State&nbsp;<span id="Span52" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList runat="server" ID="ddlDriver_State" SkinID="ddlSONIC">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left">
                                                                    Home Telephone&nbsp;<span id="Span53" style="color: Red; display: none;" runat="server">*</span><br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtDriver_Home_Phone" Width="170px" MaxLength="13"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revDriver_Home_Phone" ControlToValidate="txtDriver_Home_Phone"
                                                                        runat="server" ValidationGroup="vsInsuredDriverInfoGroup" ErrorMessage="Please Enter Driver Home Phone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Zip Code&nbsp;<span id="Span54" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtDriver_ZipCode" Width="170px" MaxLength="10"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    Alternate Telephone&nbsp;<span id="Span55" style="color: Red; display: none;" runat="server">*</span><br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtDriver_Altermate_Phone" Width="170px" MaxLength="13"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revDriver_Altermate_Phone" ControlToValidate="txtDriver_Altermate_Phone"
                                                                        runat="server" ValidationGroup="vsInsuredDriverInfoGroup" ErrorMessage="Please Enter Driver Alternate Phone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Driver’s License State&nbsp;<span id="Span56" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList runat="server" ID="ddlDriver_Drivers_License_State" SkinID="ddlSONIC">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left">
                                                                    Driver’s License Number&nbsp;<span id="Span57" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtDriver_Drivers_License_Number" Width="170px" MaxLength="20"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Relation to Insured&nbsp;<span id="Span58" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtDriver_Relation_to_Insured" Width="170px" MaxLength="50"></asp:TextBox>
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
                                                                    Citation Issued
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:RadioButtonList runat="server" ID="rdoCitation_Issued" SkinID="YesNoUnknownType">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td align="left">
                                                                    Citation Number&nbsp;<span id="Span59" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtCitation_Number" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Driver was Injured
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:RadioButtonList runat="server" ID="rdoDriver_Was_Injured" SkinID="YesNoUnknownType">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td align="left">
                                                                    Description of Injury&nbsp;<span id="Span60" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtDriver_Injury_Description" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Driver sought medical attention
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:RadioButtonList runat="server" ID="rdoDriver_Sought_Medical_Attention" SkinID="YesNoUnknownType">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td align="left">
                                                                    Driver same as Owner
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:RadioButtonList runat="server" ID="rdoDriver_Is_Owner" SkinID="YesNoUnknownType">
                                                                    </asp:RadioButtonList>
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
                                                                    <asp:RadioButtonList runat="server" ID="rdoDriver_Taken_By_Emergency_Transportation"
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
                                                                    <asp:RadioButtonList runat="server" ID="rdoDriver_Airlifted_Medivac" SkinID="YesNoUnknownType">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Medical Facility Name&nbsp;<span id="Span61" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtDriver_Medical_Facility_Name" Width="170px" MaxLength="40"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    Date of Initial Treatment&nbsp;<span id="Span62" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtDriver_Date_Of_Initial_Treatment" runat="server"></asp:TextBox>
                                                                    <img alt="Date of Initial Treatment" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDriver_Date_Of_Initial_Treatment', 'mm/dd/y',CompareDateLessThanToday,'ctl00_ContentPlaceHolder1_txtDriver_Date_Of_Initial_Treatment');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" /><br />
                                                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtCurrentDate"
                                                                        ControlToValidate="txtDriver_Date_Of_Initial_Treatment" Display="Dynamic" Text="*"
                                                                        ErrorMessage="Date of Initial Treatment is not Greater Than current date." Operator="LessThanEqual"
                                                                        Type="Date" ValidationGroup="vsInsuredDriverInfoGroup"></asp:CompareValidator>
                                                                    <%--<asp:RegularExpressionValidator ID="revDriver_Date_Of_Initial_Treatment" runat="server"
                                                                        ControlToValidate="txtDriver_Date_Of_Initial_Treatment" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                        ErrorMessage="Driver Initial Treatment Date is not valid." Display="none" ValidationGroup="vsInsuredDriverInfoGroup"></asp:RegularExpressionValidator>--%>
                                                                    <asp:CustomValidator ID="cvDriver_Date_Of_Initial_Treatment" runat="server" ControlToValidate="txtDriver_Date_Of_Initial_Treatment"
                                                                        ValidationGroup="vsInsuredDriverInfoGroup" ClientValidationFunction="CheckDate"
                                                                        ErrorMessage="Driver Initial Treatment Date is not valid." Display="None">
                                                                    </asp:CustomValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Medical Facility Type&nbsp;<span id="Span63" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtDriver_Medical_Facility_Type" Width="170px" MaxLength="20"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    Treating Physician’s Name&nbsp;<span id="Span64" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtDriver_Treating_Physician_Name" Width="170px"
                                                                        MaxLength="20"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Medical Facility Address 1&nbsp;<span id="Span65" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtDriver_Medical_Facility_Address_1" Width="170px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    Admitted to Hospital
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:RadioButtonList runat="server" ID="rdoDriver_Admitted_to_Hospital" SkinID="YesNoUnknownType"
                                                                        onClick="CheckAdmittedHospital();">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Medical Facility Address 2&nbsp;<span id="Span66" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtDriver_Medical_Facility_Address_2" Width="170px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left" colspan="3" id="tdDateAdmitted" runat="server" style="display: none;">
                                                                    <table cellpadding="0" cellspacing="3" border="0" width="100%">
                                                                        <tr>
                                                                            <td align="left" style="width: 18%">
                                                                                Date Admitted&nbsp;<span id="Span67" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center" style="width: 4%">
                                                                                :
                                                                            </td>
                                                                            <td align="left" style="width: 28%">
                                                                                <asp:TextBox ID="txtDriver_Date_Admitted_to_Hospital" runat="server"></asp:TextBox>
                                                                                <img alt="Date of Admitted to Hospital" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDriver_Date_Admitted_to_Hospital', 'mm/dd/y',CompareDateLessThanToday,'ctl00_ContentPlaceHolder1_txtDriver_Date_Admitted_to_Hospital');"
                                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                                    align="middle" /><br />
                                                                                <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToCompare="txtCurrentDate"
                                                                                    ControlToValidate="txtDriver_Date_Admitted_to_Hospital" Display="Dynamic" Text="*"
                                                                                    ErrorMessage="Date Driver Admitted is not Greater Than current date." Operator="LessThanEqual"
                                                                                    Type="Date" ValidationGroup="vsInsuredDriverInfoGroup"></asp:CompareValidator>
                                                                                <%--<asp:RegularExpressionValidator ID="revDriver_Date_Admitted_to_Hospital" runat="server"
                                                                                    ControlToValidate="txtDriver_Date_Admitted_to_Hospital" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                                    ErrorMessage="Driver Admitted Date is not valid." Display="none" ValidationGroup="vsInsuredDriverInfoGroup"></asp:RegularExpressionValidator>--%>
                                                                                <asp:CustomValidator ID="cvDriver_Date_Admitted_to_Hospital" runat="server" ControlToValidate="txtDriver_Date_Admitted_to_Hospital"
                                                                                    ValidationGroup="vsInsuredDriverInfoGroup" ClientValidationFunction="CheckDate"
                                                                                    ErrorMessage="Driver Admitted Date is not valid." Display="None">
                                                                                </asp:CustomValidator>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Medical Facility City&nbsp;<span id="Span68" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtDriver_Medical_Facility_City" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left" id="tdStillHospital" runat="server" colspan="3" style="display: none;">
                                                                    <table cellpadding="0" cellspacing="3" border="0" width="100%">
                                                                        <tr>
                                                                            <td align="left" style="width: 18%;">
                                                                                Still in Hospital
                                                                            </td>
                                                                            <td align="center" style="width: 4%;">
                                                                                :
                                                                            </td>
                                                                            <td align="left" style="width: 28%;">
                                                                                <asp:RadioButtonList runat="server" ID="rdoDriver_Still_in_Hospital" SkinID="YesNoUnknownType">
                                                                                </asp:RadioButtonList>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Medical Facility State&nbsp;<span id="Span69" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList runat="server" ID="ddlDriver_Medical_Facility_State" SkinID="ddlSONIC">
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
                                                                    Medical Facility Zip Code&nbsp;<span id="Span70" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtDriver_Medical_Facility_Zip_Code" Width="170px"
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
                                                                    <asp:Button runat="server" ID="btnInsuredVehicleDriverSave" Text="Save & Continue"
                                                                        OnClick="btnInsuredVehicleDriverSave_Click" ValidationGroup="vsInsuredDriverInfoGroup"
                                                                        OnClientClick="return CheckValidationInsuredVehicleDriverInfo();" />
                                                                    <asp:Button runat="server" ID="btnInsuredVehicleDriverAudit" Text="View Audit Trail"
                                                                        OnClientClick="javascript:return AuditPopUp();" ToolTip="View Audit Trail" CausesValidation="false" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlInsuredVehiclePassenger" Width="100%" runat="server">
                                                <div class="bandHeaderRow">
                                                    Insured Vehicle Passenger Information</div>
                                                <asp:UpdatePanel runat="server" ID="updInsuredPassenger">
                                                    <ContentTemplate>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Name&nbsp;<span id="Span71" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtPassenger_Name" Width="170px" MaxLength="40"></asp:TextBox>
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
                                                                <td align="left" style="width: 18%">
                                                                    Address 1&nbsp;<span id="Span72" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtPassenger_Address_1" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Date of Birth&nbsp;<span id="Span73" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox ID="txtPassenger_Date_of_Birth" SkinID="txtDate" runat="server" onblur="return CountAgeAL('ctl00_ContentPlaceHolder1_txtPassenger_Date_of_Birth,ctl00_ContentPlaceHolder1_txtPassengerAgeCount');"></asp:TextBox>
                                                                    <img alt="Date of Birth" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPassenger_Date_of_Birth', 'mm/dd/y',CountAge,'ctl00_ContentPlaceHolder1_txtPassenger_Date_of_Birth,ctl00_ContentPlaceHolder1_txtPassengerAgeCount');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        onmouseout="javascript:ctl00_ContentPlaceHolder1_txtPassenger_Date_of_Birth.focus();"
                                                                        align="middle" /><br />
                                                                    <%--<asp:RegularExpressionValidator ID="revPassenger_Date_of_Birth" runat="server" ControlToValidate="txtPassenger_Date_of_Birth"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                        ErrorMessage="Passenger Birth Date is not valid." Display="none" ValidationGroup="vsInsuredPassengerInfoGroup"></asp:RegularExpressionValidator>--%>
                                                                    <asp:CustomValidator ID="cvPassenger_Date_of_Birth" runat="server" ControlToValidate="txtPassenger_Date_of_Birth"
                                                                        ValidationGroup="vsInsuredPassengerInfoGroup" ClientValidationFunction="CheckDate"
                                                                        ErrorMessage="Passenger Birth Date is not valid." Display="None">
                                                                    </asp:CustomValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Address 2&nbsp;<span id="Span74" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtPassenger_Address_2" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Age&nbsp;<span id="Span75" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtPassengerAgeCount" Width="170px" ReadOnly="true"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    City&nbsp;<span id="Span76" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtPassenger_City" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Work Telephone&nbsp;<span id="Span77" style="color: Red; display: none;" runat="server">*</span><br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtPassenger_Work_Phone" Width="170px" MaxLength="20"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revPassenger_Work_Phone" ControlToValidate="txtPassenger_Work_Phone"
                                                                        runat="server" ValidationGroup="vsInsuredPassengerInfoGroup" ErrorMessage="Please Enter Passenger work Phone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    State&nbsp;<span id="Span78" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:DropDownList runat="server" ID="ddlPassenger_State" SkinID="ddlSONIC">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Home Telephone&nbsp;<span id="Span79" style="color: Red; display: none;" runat="server">*</span><br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtPassenger_Home_Phone" Width="170px" MaxLength="20"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revPassenger_Home_Phone" ControlToValidate="txtPassenger_Home_Phone"
                                                                        runat="server" ValidationGroup="vsInsuredPassengerInfoGroup" ErrorMessage="Please Enter Passenger Home Phone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Zip Code&nbsp;<span id="Span80" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtPassenger_ZipCode" Width="170px" MaxLength="10"></asp:TextBox>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Alternate Telephone&nbsp;<span id="Span81" style="color: Red; display: none;" runat="server">*</span><br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtPassenger_Alternate_Phone" Width="170px" MaxLength="20"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revPassenger_Alternate_Phone" ControlToValidate="txtPassenger_Alternate_Phone"
                                                                        runat="server" ValidationGroup="vsInsuredPassengerInfoGroup" ErrorMessage="Please Enter Passenger Alternate Phone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Driver’s License State&nbsp;<span id="Span82" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:DropDownList runat="server" ID="ddlPassenger_Drivers_License_State" SkinID="ddlSONIC">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Driver’s License Number&nbsp;<span id="Span83" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtPassenger_Drivers_License_Number" Width="170px"
                                                                        MaxLength="20"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Relation to Insured&nbsp;<span id="Span84" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtPassenger_Relation_to_Insured" Width="170px" MaxLength="50"></asp:TextBox>
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
                                                                <td align="left" style="width: 18%">
                                                                    Passenger was Injured
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:RadioButtonList runat="server" ID="rdoPassenger_Was_Injured" SkinID="YesNoUnknownType">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Description of Injury&nbsp;<span id="Span85" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtPassenger_Description_of_Injury" Width="170px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Passenger sought medical attention
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:RadioButtonList runat="server" ID="rdoPassenger_Sought_Medical_Attention" SkinID="YesNoUnknownType">
                                                                    </asp:RadioButtonList>
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
                                                                <td colspan="6" align="center">
                                                                    <asp:Button runat="server" ID="btnIVPassengerSave" Text="Save & Continue" OnClick="btnIVPassengerSave_Click"
                                                                        ValidationGroup="vsInsuredPassengerInfoGroup" OnClientClick="return CheckValidationInsuredVehiclePassengerInfo();" />
                                                                    <asp:Button runat="server" ID="btnIVPassengerAudit" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();"
                                                                        ToolTip="View Audit Trail" CausesValidation="false" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlOtherVehicle" runat="server" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Other Vehicle</div>
                                                <asp:UpdatePanel runat="server" ID="updOthVehicle">
                                                    <ContentTemplate>
                                                        <asp:HiddenField runat="server" ID="hdnOther" />
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Year&nbsp;<span id="Span86" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtOther_Vehicle_Year" Width="170px" MaxLength="4"
                                                                        SkinID="txtYearWithRange" onblur="javascript:return YearRange(this,'1920','2020')"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revOther_Vehicle_Year" runat="server" ControlToValidate="txtOther_Vehicle_Year"
                                                                        Display="none" SetFocusOnError="false" ErrorMessage="Other Vehicle Year is Invalid."
                                                                        ValidationExpression="[\d]{4}" ValidationGroup="vsOtherVehicleInfoGroup"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Make&nbsp;<span id="Span87" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtOther_Vehicle_Make" Width="170px" MaxLength="40"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Model&nbsp;<span id="Span88" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtOther_Vehicle_Model" Width="170px" MaxLength="40"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    VIN&nbsp;<span id="Span89" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtOther_Vehicle_VIN" Width="170px" MaxLength="40"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    License Plate Number&nbsp;<span id="Span90" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtOther_Vehicle_License_Plate_Number" Width="170px"
                                                                        MaxLength="20"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    License Plate State&nbsp;<span id="Span91" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList runat="server" ID="ddlOther_Vehicle_License_Plate_State" SkinID="ddlSONIC">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Vehicle Color&nbsp;<span id="Span92" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtOther_Vehicle_Vehicle_Color" Width="170px" MaxLength="20"></asp:TextBox>
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
                                                                    Insurance Company Name&nbsp;<span id="Span93" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtOther_Vehicle_Insurance_Co_Name" Width="170px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    Insurance Company Phone&nbsp;<span id="Span94" style="color: Red; display: none;"
                                                                        runat="server">*</span><br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtOther_Vehicle_Insurance_Co_Phone" Width="170px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revOther_Vehicle_Insurance_Co_Phone" ControlToValidate="txtOther_Vehicle_Insurance_Co_Phone"
                                                                        runat="server" ValidationGroup="vsOtherVehicleInfoGroup" ErrorMessage="Please Enter Other Vehicle Insurance Company Phone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Policy Number&nbsp;<span id="Span95" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtOther_Vehicle_Insurance_Policy_Number" Width="170px"
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
                                                                <td align="left" valign="top">
                                                                    Description of Damage&nbsp;<span id="Span96" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <uc:ctrlMultiLineTextBox ID="txtOther_Vehicle_Vehicle_Damage_Description" runat="server"
                                                                        MaxLength="4000" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Repairs Completed
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:RadioButtonList runat="server" ID="rdoOther_Vehicle_Repairs_Completed" SkinID="YesNoType">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td align="left">
                                                                    Estimated Amount&nbsp;<span id="Span97" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    $<asp:TextBox runat="server" ID="txtOther_Vehicle_Repairs_Estimated_Amount" Width="170px"
                                                                        MaxLength="50" onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"></asp:TextBox>
                                                                    <asp:CompareValidator ID="cvOther_Vehicle_Repairs_Estimated_Amount" runat="server"
                                                                        ControlToValidate="txtOther_Vehicle_Repairs_Estimated_Amount" ValidationGroup="vsOtherVehicleInfoGroup"
                                                                        ErrorMessage="Please Enter Estimated Amount Greater Than $0.00." Type="Currency"
                                                                        Operator="GreaterThan" ControlToCompare="txtCompare" Display="none">
                                                                    </asp:CompareValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Drivable
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:RadioButtonList runat="server" ID="rdoOther_Vehicle_Drivable" SkinID="YesNoUnknownType">
                                                                    </asp:RadioButtonList>
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
                                                                    Location where vehicle can be seen&nbsp;<span id="Span98" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtOther_Vehicle_Location" Width="170px" MaxLength="40"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    Location Telephone&nbsp;<span id="Span99" style="color: Red; display: none;" runat="server">*</span><br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtOther_Vehicle_Location_Telephone" Width="170px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revOther_Vehicle_Location_Telephone" ControlToValidate="txtOther_Vehicle_Location_Telephone"
                                                                        runat="server" ValidationGroup="vsOtherVehicleInfoGroup" ErrorMessage="Please Enter location Phone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Address 1&nbsp;<span id="Span100" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtOther_Vehicle_Location_Driver_Address_1" Width="170px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Address 2&nbsp;<span id="Span101" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtOther_Vehicle_Location_Driver_Address_2" Width="170px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    City&nbsp;<span id="Span102" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtOther_Vehicle_Location_Driver_City" Width="170px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    State&nbsp;<span id="Span103" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:DropDownList runat="server" ID="ddlOther_Vehicle_Location_Driver_State" SkinID="ddlSONIC">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Zip Code&nbsp;<span id="Span104" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtOther_Vehicle_Location_Driver_ZipCode" Width="170px"
                                                                        MaxLength="10"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Owner Name&nbsp;<span id="Span105" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="Server" ID="txtOther_Vehicle_Owner_Name" Width="170px" MaxLength="40"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    Work Telephone&nbsp;<span id="Span106" style="color: Red; display: none;" runat="server">*</span><br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtOther_Vehicle_Owner_Work_Phone" Width="170px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revOther_Vehicle_Owner_Work_Phone" ControlToValidate="txtOther_Vehicle_Owner_Work_Phone"
                                                                        runat="server" ValidationGroup="vsOtherVehicleInfoGroup" ErrorMessage="Please Enter Other Vehicle Owner work Phone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Address 1&nbsp;<span id="Span107" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtOther_Vehicle_Owner_Address_1" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    Home Telephone&nbsp;<span id="Span108" style="color: Red; display: none;" runat="server">*</span><br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtOther_Vehicle_Owner_Home_Phone" Width="170px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revOther_Vehicle_Owner_Home_Phone" ControlToValidate="txtOther_Vehicle_Owner_Home_Phone"
                                                                        runat="server" ValidationGroup="vsOtherVehicleInfoGroup" ErrorMessage="Please Enter Other Vehicle Owner Home Phone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Address 2&nbsp;<span id="Span109" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtOther_Vehicle_Owner_Address_2" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    Alternate Telephone&nbsp;<span id="Span110" style="color: Red; display: none;" runat="server">*</span><br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtOther_Vehicle_Owner_Alternate_Phone" Width="170px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revOther_Vehicle_Owner_Alternate_Phone" ControlToValidate="txtOther_Vehicle_Owner_Alternate_Phone"
                                                                        runat="server" ValidationGroup="vsOtherVehicleInfoGroup" ErrorMessage="Please Enter Other Vehicle Owner Alternate Phone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    City&nbsp;<span id="Span111" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtOther_Vehicle_Owner_City" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    State&nbsp;<span id="Span112" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:DropDownList runat="server" ID="ddlOther_Vehicle_Owner_State" SkinID="ddlSONIC">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Zip Code&nbsp;<span id="Span113" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtOther_Vehicle_Owner_ZipCode" Width="170px" MaxLength="10"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" align="center">
                                                                    <asp:Button runat="server" ID="btnOVSave" Text="Save & Continue" OnClick="btnOVSave_Click"
                                                                        ValidationGroup="vsOtherVehicleInfoGroup" OnClientClick="return CheckValidationOtherVehicleInfo();" />
                                                                    <asp:Button runat="server" ID="btnOVAudit" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();"
                                                                        ToolTip="View Audit Trail" CausesValidation="false" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                            <asp:Panel runat="server" ID="pnlOtherVehicleDriver" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Other Vehicle Driver Information</div>
                                                <asp:UpdatePanel runat="server" ID="updOtherVehDriver">
                                                    <ContentTemplate>
                                                        <asp:HiddenField runat="server" ID="hdnOVDriver" Value="0" />
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Name&nbsp;<span id="Span114" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtOther_Driver_Name" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Social Security Number&nbsp;<span id="Span115" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtOther_Driver_SSN" Width="170px" MaxLength="9"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Address 1&nbsp;<span id="Span116" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtOther_Driver_Address_1" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Date of Birth&nbsp;<span id="Span117" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox ID="txtOther_Driver_Date_of_Birth" SkinID="txtDate" runat="server" onblur="return CountAgeAL('ctl00_ContentPlaceHolder1_txtOther_Driver_Date_of_Birth,ctl00_ContentPlaceHolder1_txtOther_Driver_AgeCount');"></asp:TextBox>
                                                                    <img alt="Date of Birth" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtOther_Driver_Date_of_Birth', 'mm/dd/y',CountAge,'ctl00_ContentPlaceHolder1_txtOther_Driver_Date_of_Birth,ctl00_ContentPlaceHolder1_txtOther_Driver_AgeCount');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        onmouseout="javascript:ctl00_ContentPlaceHolder1_txtOther_Driver_Date_of_Birth.focus();"
                                                                        align="middle" /><br />
                                                                    <%-- <asp:RegularExpressionValidator ID="revOther_Driver_Date_of_Birth" runat="server"
                                                                        ControlToValidate="txtOther_Driver_Date_of_Birth" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                        ErrorMessage="Other Driver Birth Date is not valid." Display="none" ValidationGroup="vsOtherVehicleDriverInfoGroup"></asp:RegularExpressionValidator>--%>
                                                                    <asp:CustomValidator ID="CVOther_Driver_Date_of_Birth" runat="server" ControlToValidate="txtOther_Driver_Date_of_Birth"
                                                                        ValidationGroup="vsOtherVehicleDriverInfoGroup" ClientValidationFunction="CheckDate"
                                                                        ErrorMessage="Other Driver Birth Date is not valid." Display="None">
                                                                    </asp:CustomValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Address 2&nbsp;<span id="Span118" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtOther_Driver_Address_2" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Age&nbsp;<span id="Span119" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtOther_Driver_AgeCount" Width="170px" ReadOnly="true"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    City&nbsp;<span id="Span120" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtOther_Driver_City" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Work Telephone&nbsp;<span id="Span121" style="color: Red; display: none;" runat="server">*</span><br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtOther_Driver_Work_Phone" Width="170px" MaxLength="20"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revOther_Driver_Work_Phone" ControlToValidate="txtOther_Driver_Work_Phone"
                                                                        runat="server" ValidationGroup="vsOtherVehicleDriverInfoGroup" ErrorMessage="Please Enter Other Driver Work Phone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    State&nbsp;<span id="Span122" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:DropDownList runat="server" ID="ddlOther_Driver_State" SkinID="ddlSONIC">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Home Telephone&nbsp;<span id="Span123" style="color: Red; display: none;" runat="server">*</span><br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtOther_Driver_Home_Phone" Width="170px" MaxLength="20"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revOther_Driver_Home_Phone" ControlToValidate="txtOther_Driver_Home_Phone"
                                                                        runat="server" ValidationGroup="vsOtherVehicleDriverInfoGroup" ErrorMessage="Please Enter Other Driver Home Phone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Zip Code&nbsp;<span id="Span124" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtOther_Driver_ZipCode" Width="170px" MaxLength="10"></asp:TextBox>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Driver’s License Number&nbsp;<span id="Span125" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtOther_Driver_Drivers_License_Number" Width="170px"
                                                                        MaxLength="20"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Gender&nbsp;<span id="Span126" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtOther_Driver_Gender" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Driver’s License State&nbsp;<span id="Span127" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:DropDownList runat="server" ID="ddlOther_Driver_Drivers_License_State" SkinID="ddlSONIC">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Citation Issued
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:RadioButtonList runat="server" ID="rdoOther_Driver_Citation_Issued" SkinID="YesNoUnknownType">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Citation Number&nbsp;<span id="Span128" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtOther_Driver_Citation_Number" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Driver was Injured
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:RadioButtonList runat="server" ID="rdoOther_Driver_Injured" SkinID="YesNoUnknownType">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Description of Injury&nbsp;<span id="Span129" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtOther_Driver_Injury_Description" Width="170px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Driver sought medical attention
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:RadioButtonList runat="server" ID="rdoOther_Driver_Sought_Medical_Attention"
                                                                        SkinID="YesNoUnknownType">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Taken By Emergency Transportation?
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:RadioButtonList runat="server" ID="rdoOther_Driver_Taken_By_Emergency_Transportation"
                                                                        SkinID="YesNoType">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Airlifted/Medivac
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:RadioButtonList runat="server" ID="rdoOther_Driver_Airlifted_Medivac" SkinID="YesNoUnknownType">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Medical Facility Name&nbsp;<span id="Span130" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtOther_Driver_Medical_Facility_Name" Width="170px"
                                                                        MaxLength="40"></asp:TextBox>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Admitted to Hospital
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:RadioButtonList runat="server" ID="rdoOther_Driver_Admitted_to_Hospital" SkinID="YesNoUnknownType"
                                                                        onClick="checkOth_Driver_AdmittedHospital();">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Medical Facility Address 1&nbsp;<span id="Span131" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtOther_Driver_Medical_Facility_Address_1" Width="170px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left" colspan="3" id="tdOth_Driver_DateAdmitted" runat="server" style="display: none;">
                                                                    <table cellpadding="0" cellspacing="3" border="0" width="100%">
                                                                        <tr>
                                                                            <td align="left" style="width: 18%">
                                                                                Date Admitted&nbsp;<span id="Span132" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center" style="width: 4%">
                                                                                :
                                                                            </td>
                                                                            <td align="left" style="width: 28%">
                                                                                <asp:TextBox ID="txtOther_Driver_Date_Admitted_to_Hospital" runat="server"></asp:TextBox>
                                                                                <img alt="Date Admitted to Hospital" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtOther_Driver_Date_Admitted_to_Hospital', 'mm/dd/y',CompareDateLessThanToday,'ctl00_ContentPlaceHolder1_txtOther_Driver_Date_Admitted_to_Hospital');"
                                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                                    align="middle" /><br />
                                                                                <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToCompare="txtCurrentDate"
                                                                                    ControlToValidate="txtOther_Driver_Date_Admitted_to_Hospital" Display="Dynamic"
                                                                                    Text="*" ErrorMessage="Date Other Driver Admitted is not Greater Than current date."
                                                                                    Operator="LessThanEqual" Type="Date" ValidationGroup="vsOtherVehicleDriverInfoGroup"></asp:CompareValidator>
                                                                                <asp:CustomValidator ID="cvOther_Driver_Date_Admitted_to_Hospital" runat="server"
                                                                                    ControlToValidate="txtOther_Driver_Date_Admitted_to_Hospital" ValidationGroup="vsOtherVehicleDriverInfoGroup"
                                                                                    ClientValidationFunction="CheckDate" ErrorMessage="Other Driver Admitted Date is not valid."
                                                                                    Display="None">
                                                                                </asp:CustomValidator>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Medical Facility Address 2&nbsp;<span id="Span133" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtOther_Driver_Medical_Facility_Address_2" Width="170px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left" colspan="3" id="tdOth_Driver_StillHospital" runat="server" style="display: none;">
                                                                    <table cellpadding="0" cellspacing="3" border="0" width="100%">
                                                                        <tr>
                                                                            <td align="left" style="width: 18%">
                                                                                Still in Hospital
                                                                            </td>
                                                                            <td align="center" style="width: 4%">
                                                                                :
                                                                            </td>
                                                                            <td align="left" style="width: 28%">
                                                                                <asp:RadioButtonList runat="server" ID="rdoOther_Driver_Still_in_Hospital" SkinID="YesNoUnknownType">
                                                                                </asp:RadioButtonList>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Medical Facility City&nbsp;<span id="Span134" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtOther_Driver_Medical_Facility_City" Width="170px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Physician's Name&nbsp;<span id="Span135" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtOther_Driver_Physicians_Name" Width="170px" MaxLength="20"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Medical Facility State&nbsp;<span id="Span136" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:DropDownList runat="server" ID="ddlOther_Driver_Medical_Facility_State" SkinID="ddlSONIC">
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
                                                                <td align="left" style="width: 18%">
                                                                    Medical Facility Zip Code&nbsp;<span id="Span137" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtOther_Driver_Medical_Facility_Zip_Code" Width="170px"
                                                                        MaxLength="10"></asp:TextBox>
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
                                                                <td align="left" style="width: 18%">
                                                                    Medical Facility Type&nbsp;<span id="Span138" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtOther_Driver_Medical_Facility_Type" Width="170px"
                                                                        MaxLength="20"></asp:TextBox>
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
                                                                <td colspan="6" align="center">
                                                                    <asp:Button runat="server" ID="btnOVDriverSave" Text="Save & Continue" OnClick="btnOVDriverSave_Click"
                                                                        ValidationGroup="vsOtherVehicleDriverInfoGroup" OnClientClick="return CheckValidationOtherVehicleDriverInfo();" />
                                                                    <asp:Button runat="server" ID="btnOVDriverAudit" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();"
                                                                        ToolTip="View Audit Trail" CausesValidation="false" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlOtherVehiclePassenger" Width="100%" runat="server">
                                                <div class="bandHeaderRow">
                                                    Other Vehicle Passenger Information</div>
                                                <asp:UpdatePanel runat="server" ID="updOthVehPass">
                                                    <ContentTemplate>
                                                        <asp:HiddenField runat="server" ID="hdnOthVehPass" Value="0" />
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Name&nbsp;<span id="Span139" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtOth_Veh_Pass_Name" Width="170px" MaxLength="50"></asp:TextBox>
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
                                                                <td align="left" style="width: 18%">
                                                                    Address 1&nbsp;<span id="Span140" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtOth_Veh_Pass_Address_1" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Date of Birth&nbsp;<span id="Span141" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox ID="txtOth_Veh_Pass_Date_of_Birth" SkinID="txtDate" runat="server" onblur="return CountAgeAL('ctl00_ContentPlaceHolder1_txtOth_Veh_Pass_Date_of_Birth,ctl00_ContentPlaceHolder1_txtOth_Veh_Pass_AgeCount');"></asp:TextBox>
                                                                    <img alt="Date of Birth" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtOth_Veh_Pass_Date_of_Birth', 'mm/dd/y',CountAge,'ctl00_ContentPlaceHolder1_txtOth_Veh_Pass_Date_of_Birth,ctl00_ContentPlaceHolder1_txtOth_Veh_Pass_AgeCount');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        onmouseout="javascript:ctl00_ContentPlaceHolder1_txtOth_Veh_Pass_Date_of_Birth.focus();"
                                                                        align="middle" /><br />
                                                                    <%--<asp:RegularExpressionValidator ID="revOth_Veh_Pass_Date_of_Birth" runat="server"
                                                                        ControlToValidate="txtOth_Veh_Pass_Date_of_Birth" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                        ErrorMessage="Other Passenger Birth Date is not valid." Display="none" ValidationGroup="vsOtherVehiclePassengerInfoGroup"></asp:RegularExpressionValidator>--%>
                                                                    <asp:CustomValidator ID="cvOth_Veh_Pass_Date_of_Birth" runat="server" ControlToValidate="txtOth_Veh_Pass_Date_of_Birth"
                                                                        ValidationGroup="vsOtherVehiclePassengerInfoGroup" ClientValidationFunction="CheckDate"
                                                                        ErrorMessage="Other Passenger Birth Date is not valid." Display="None">
                                                                    </asp:CustomValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Address 2&nbsp;<span id="Span142" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtOth_Veh_Pass_Address_2" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Age&nbsp;<span id="Span143" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtOth_Veh_Pass_AgeCount" Width="170px" ReadOnly="true"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    City&nbsp;<span id="Span144" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtOth_Veh_Pass_City" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Work Telephone&nbsp;<span id="Span145" style="color: Red; display: none;" runat="server">*</span><br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtOth_Veh_Pass_Work_Phone" Width="170px" MaxLength="20"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revOth_Veh_Pass_Work_Phone" ControlToValidate="txtOth_Veh_Pass_Work_Phone"
                                                                        runat="server" ValidationGroup="vsOtherVehiclePassengerInfoGroup" ErrorMessage="Please Enter Other Vehicle Passenger Work Phone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    State&nbsp;<span id="Span146" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:DropDownList runat="server" ID="ddlOth_Veh_Pass_State" SkinID="ddlSONIC">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Home Telephone&nbsp;<span id="Span147" style="color: Red; display: none;" runat="server">*</span><br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtOth_Veh_Pass_Home_Phone" Width="170px" MaxLength="20"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revOth_Veh_Pass_Home_Phone" ControlToValidate="txtOth_Veh_Pass_Home_Phone"
                                                                        runat="server" ValidationGroup="vsOtherVehiclePassengerInfoGroup" ErrorMessage="Please Enter Other Vehicle Passenger Home Phone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Zip Code&nbsp;<span id="Span148" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtOth_Veh_Pass_ZipCode" Width="170px" MaxLength="10"></asp:TextBox>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Alternate Telephone&nbsp;<span id="Span149" style="color: Red; display: none;" runat="server">*</span><br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtOth_Veh_Pass_Alternate_Phone" Width="170px" MaxLength="20"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revOth_Veh_Pass_Alternate_Phone" ControlToValidate="txtOth_Veh_Pass_Alternate_Phone"
                                                                        runat="server" ValidationGroup="vsOtherVehiclePassengerInfoGroup" ErrorMessage="Please Enter Other Vehicle Passenger Alternate Phone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Passenger was Injured
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:RadioButtonList runat="server" ID="rdoOth_Veh_Pass_Injured" SkinID="YesNoUnknownType">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Description of Injury&nbsp;<span id="Span150" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtOth_Veh_Pass_Injury_Description" Width="170px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Passenger sought medical attention
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:RadioButtonList runat="server" ID="rdoOth_Veh_Pass_Sought_Medical_Attention"
                                                                        SkinID="YesNoUnknownType">
                                                                    </asp:RadioButtonList>
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
                                                                <td align="left" style="width: 18%">
                                                                    Taken By Emergency Transportation?
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:RadioButtonList runat="server" ID="rdoOth_Veh_Pass_Taken_By_Emergency_Transportation"
                                                                        SkinID="YesNoType">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Airlifted/Medivac
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:RadioButtonList runat="server" ID="rdoOth_Veh_Pass_Airlifted_Medivac" SkinID="YesNoUnknownType">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Medical Facility Name&nbsp;<span id="Span151" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtOth_Veh_Pass_Medical_Facility_Name" Width="170px"
                                                                        MaxLength="40"></asp:TextBox>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Admitted to Hospital
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:RadioButtonList runat="server" ID="rdoOth_Veh_Pass_Admitted_to_Hospital" SkinID="YesNoUnknownType"
                                                                        onClick="CheckOth_Veh_PassAdmittedHospital();">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Medical Facility Address 1&nbsp;<span id="Span152" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtOth_Veh_Pass_Medical_Facility_Address_1" Width="170px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left" colspan="3" id="tdOth_Ven_Pass_DateAdmitted" runat="server" style="display: none;">
                                                                    <table cellpadding="0" cellspacing="3" border="0" width="100%">
                                                                        <tr>
                                                                            <td align="left" style="width: 18%">
                                                                                Date Admitted&nbsp;<span id="Span153" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center" style="width: 4%">
                                                                                :
                                                                            </td>
                                                                            <td align="left" style="width: 28%">
                                                                                <asp:TextBox ID="txtOth_Veh_Pass_Date_Admitted_to_Hospital" runat="server"></asp:TextBox>
                                                                                <img alt="Date Admitted to Hospital" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtOth_Veh_Pass_Date_Admitted_to_Hospital', 'mm/dd/y',CompareDateLessThanToday,'ctl00_ContentPlaceHolder1_txtOth_Veh_Pass_Date_Admitted_to_Hospital');"
                                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                                    align="middle" /><br />
                                                                                <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToCompare="txtCurrentDate"
                                                                                    ControlToValidate="txtOth_Veh_Pass_Date_Admitted_to_Hospital" Display="Dynamic"
                                                                                    Text="*" ErrorMessage="Date Other Passenger Admitted is not Greater Than current date."
                                                                                    Operator="LessThanEqual" Type="Date" ValidationGroup="vsOtherVehiclePassengerInfoGroup"></asp:CompareValidator>
                                                                                <asp:CustomValidator ID="cvOth_Veh_Pass_Date_Admitted_to_Hospital" runat="server"
                                                                                    ControlToValidate="txtOth_Veh_Pass_Date_Admitted_to_Hospital" ValidationGroup="vsOtherVehiclePassengerInfoGroup"
                                                                                    ClientValidationFunction="CheckDate" ErrorMessage="Other Passenger Admitted Date is not valid."
                                                                                    Display="None">
                                                                                </asp:CustomValidator>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Medical Facility Address 2&nbsp;<span id="Span154" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtOth_Veh_Pass_Medical_Facility_Address_2" Width="170px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left" colspan="3" id="tdOth_Ven_Pass_StillHospital" runat="server" style="display: none;">
                                                                    <table cellpadding="0" cellspacing="3" border="0" width="100%">
                                                                        <tr>
                                                                            <td align="left" style="width: 18%">
                                                                                Still in Hospital
                                                                            </td>
                                                                            <td align="center" style="width: 4%">
                                                                                :
                                                                            </td>
                                                                            <td align="left" style="width: 28%">
                                                                                <asp:RadioButtonList runat="server" ID="rdoOth_Veh_Pass_Still_in_Hospital" SkinID="YesNoUnknownType">
                                                                                </asp:RadioButtonList>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Medical Facility City&nbsp;<span id="Span155" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtOth_Veh_Pass_Medical_Facility_City" Width="170px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Physician's Name&nbsp;<span id="Span156" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtOth_Veh_Pass_Physicians_Name" Width="170px" MaxLength="20"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Medical Facility State&nbsp;<span id="Span157" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:DropDownList runat="server" ID="ddlOth_Veh_Pass_Medical_Facility_State" SkinID="ddlSONIC">
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
                                                                <td align="left" style="width: 18%">
                                                                    Medical Facility Zip Code&nbsp;<span id="Span158" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtOth_Veh_Pass_Medical_Facility_Zip_Code" Width="170px"
                                                                        MaxLength="10"></asp:TextBox>
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
                                                                <td align="left" style="width: 18%">
                                                                    Medical Facility Type&nbsp;<span id="Span159" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtOth_Veh_Pass_Medical_Facility_Type" Width="170px"
                                                                        MaxLength="20"></asp:TextBox>
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
                                                                <td colspan="6" align="center">
                                                                    <asp:Button runat="server" ID="btnOVPassengerSave" Text="Save & Continue" OnClick="btnOVPassengerSave_Click"
                                                                        ValidationGroup="vsOtherVehiclePassengerInfoGroup" OnClientClick="return CheckValidationOtherVehiclePassengerInfo();" />
                                                                    <asp:Button runat="server" ID="btnOVPassengerAudit" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();"
                                                                        ToolTip="View Audit Trail" CausesValidation="false" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                            <asp:Panel runat="server" ID="pnlpedstrian" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Pedestrian Information</div>
                                                <asp:UpdatePanel runat="server" ID="updPedestrian">
                                                    <ContentTemplate>
                                                        <asp:HiddenField runat="server" ID="hdnPedestrian" Value="0" />
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Name&nbsp;<span id="Span160" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtPedestrian_Name" Width="170px" MaxLength="50"></asp:TextBox>
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
                                                                <td align="left" style="width: 18%">
                                                                    Address 1&nbsp;<span id="Span161" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtPedestrian_Address_1" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Date of Birth&nbsp;<span id="Span162" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox ID="txtPedestrian_Date_of_Birth" runat="server" SkinID="txtDate" onblur="return CountAgeAL('ctl00_ContentPlaceHolder1_txtPedestrian_Date_of_Birth,ctl00_ContentPlaceHolder1_txtPedestrianAgeCount');"></asp:TextBox>
                                                                    <img alt="Date of Birth" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPedestrian_Date_of_Birth', 'mm/dd/y',CountAge,'ctl00_ContentPlaceHolder1_txtPedestrian_Date_of_Birth,ctl00_ContentPlaceHolder1_txtPedestrianAgeCount');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        onmouseout="javascript:ctl00_ContentPlaceHolder1_txtPedestrian_Date_of_Birth.focus();"
                                                                        align="middle" /><br />
                                                                    <%-- <asp:RegularExpressionValidator ID="revPedestrian_Date_of_Birth" runat="server" ControlToValidate="txtPedestrian_Date_of_Birth"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                        ErrorMessage="Pedestrian Birth Date is not valid." Display="none" ValidationGroup="vsPadestrianInfoGroup"></asp:RegularExpressionValidator>--%>
                                                                    <asp:CustomValidator ID="cvPedestrian_Date_of_Birth" runat="server" ControlToValidate="txtPedestrian_Date_of_Birth"
                                                                        ValidationGroup="vsPadestrianInfoGroup" ClientValidationFunction="CheckDate"
                                                                        ErrorMessage="Pedestrian Birth Date is not valid." Display="None">
                                                                    </asp:CustomValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Address 2&nbsp;<span id="Span163" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtPedestrian_Address_2" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Age&nbsp;<span id="Span164" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtPedestrianAgeCount" Width="170px" ReadOnly="true"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    City&nbsp;<span id="Span165" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtPedestrian_City" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Work Telephone&nbsp;<span id="Span166" style="color: Red; display: none;" runat="server">*</span><br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtPedestrian_Work_Phone" Width="170px" MaxLength="20"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revPedestrian_Work_Phone" ControlToValidate="txtPedestrian_Work_Phone"
                                                                        runat="server" ValidationGroup="vsPadestrianInfoGroup" ErrorMessage="Please Enter Pedestrian Work Phone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    State&nbsp;<span id="Span167" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:DropDownList runat="server" ID="ddlPedestrian_State" SkinID="ddlSONIC">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Home Telephone&nbsp;<span id="Span168" style="color: Red; display: none;" runat="server">*</span><br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtPedestrian_Home_Phone" Width="170px" MaxLength="20"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revPedestrian_Home_Phone" ControlToValidate="txtPedestrian_Home_Phone"
                                                                        runat="server" ValidationGroup="vsPadestrianInfoGroup" ErrorMessage="Please Enter Pedestrian Home Phone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Zip Code&nbsp;<span id="Span169" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtPedestrian_ZipCode" Width="170px" MaxLength="10"></asp:TextBox>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Alternate Telephone&nbsp;<span id="Span170" style="color: Red; display: none;" runat="server">*</span><br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtPedestrian_Alternate_Phone" Width="170px" MaxLength="20"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revPedestrian_Alternate_Phone" ControlToValidate="txtPedestrian_Alternate_Phone"
                                                                        runat="server" ValidationGroup="vsPadestrianInfoGroup" ErrorMessage="Please Enter Pedestrian Alternate Phone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Pedestrian was Injured
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:RadioButtonList runat="server" ID="rdoPedestrian_Injured" SkinID="YesNoUnknownType">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Description of Injury&nbsp;<span id="Span171" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtPedestrian_Injury_Description" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Pedestrian sought medical attention
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:RadioButtonList runat="server" ID="rdoPedestrian_Sought_Medical_Attention" SkinID="YesNoUnknownType">
                                                                    </asp:RadioButtonList>
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
                                                                <td align="left" style="width: 18%">
                                                                    Taken By Emergency Transportation?
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:RadioButtonList runat="server" ID="rdoPedestrian_Taken_By_Emergency_Transportation"
                                                                        SkinID="YesNoType">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Airlifted/Medivac
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:RadioButtonList runat="server" ID="rdoPedestrian_Airlifted_Medivac" SkinID="YesNoUnknownType">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Medical Facility Name&nbsp;<span id="Span172" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtPedestrian_Medical_Facility_Name" Width="170px"
                                                                        MaxLength="40"></asp:TextBox>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Admitted to Hospital
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:RadioButtonList runat="server" ID="rdoPedestrian_Admitted_to_Hospital" SkinID="YesNoUnknownType"
                                                                        onClick="CheckPedestrian_AdmittedHospital();">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Medical Facility Address 1&nbsp;<span id="Span173" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtPedestrian_Medical_Facility_Address_1" Width="170px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left" colspan="3" id="tdPedestrian_DateAdmitted" runat="server" style="display: none;">
                                                                    <table cellpadding="0" cellspacing="3" border="0" width="100%">
                                                                        <tr>
                                                                            <td align="left" style="width: 18%">
                                                                                Date Admitted&nbsp;<span id="Span174" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td align="center" style="width: 4%">
                                                                                :
                                                                            </td>
                                                                            <td align="left" style="width: 28%">
                                                                                <asp:TextBox ID="txtPedestrian_Date_Admitted_to_Hospital" runat="server"></asp:TextBox>
                                                                                <img alt="Date Admitted to Hospital" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPedestrian_Date_Admitted_to_Hospital', 'mm/dd/y',CompareDateLessThanToday,'ctl00_ContentPlaceHolder1_txtPedestrian_Date_Admitted_to_Hospital');"
                                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                                    align="middle" /><br />
                                                                                <asp:CompareValidator ID="CompareValidator6" runat="server" ControlToCompare="txtCurrentDate"
                                                                                    ControlToValidate="txtPedestrian_Date_Admitted_to_Hospital" Display="Dynamic"
                                                                                    Text="*" ErrorMessage="Date Pedestrian Admitted is not Greater Than current date."
                                                                                    Operator="LessThanEqual" Type="Date" ValidationGroup="vsPadestrianInfoGroup"></asp:CompareValidator>
                                                                                <asp:CustomValidator ID="cvPedestrian_Date_Admitted_to_Hospital" runat="server" ControlToValidate="txtPedestrian_Date_Admitted_to_Hospital"
                                                                                    ValidationGroup="vsPadestrianInfoGroup" ClientValidationFunction="CheckDate"
                                                                                    ErrorMessage="Pedestrian Admitted Date is not valid." Display="None">
                                                                                </asp:CustomValidator>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Medical Facility Address 2&nbsp;<span id="Span175" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtPedestrian_Medical_Facility_Address_2" Width="170px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left" colspan="3" id="tdPedestrian_StillHospital" runat="Server" style="display: none;">
                                                                    <table cellpadding="0" cellspacing="3" border="0" width="100%">
                                                                        <tr>
                                                                            <td align="left" style="width: 18%">
                                                                                Still in Hospital
                                                                            </td>
                                                                            <td align="center" style="width: 4%">
                                                                                :
                                                                            </td>
                                                                            <td align="left" style="width: 28%">
                                                                                <asp:RadioButtonList runat="server" ID="rdoPedestrian_Still_in_Hospital" SkinID="YesNoUnknownType">
                                                                                </asp:RadioButtonList>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Medical Facility City&nbsp;<span id="Span176" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtPedestrian_Medical_Facility_City" Width="170px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Physician's Name&nbsp;<span id="Span177" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtPedestrian_Physicians_Name" Width="170px" MaxLength="20"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Medical Facility State&nbsp;<span id="Span178" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:DropDownList runat="server" ID="ddlPedestrian_Medical_Facility_State" SkinID="ddlSONIC">
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
                                                                <td align="left" style="width: 18%">
                                                                    Medical Facility Zip Code&nbsp;<span id="Span179" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtPedestrian_Medical_Facility_Zip_Code" Width="170px"
                                                                        MaxLength="10"></asp:TextBox>
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
                                                                <td align="left" style="width: 18%">
                                                                    Medical Facility Type&nbsp;<span id="Span180" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtPedestrian_Medical_Facility_Type" Width="170px"
                                                                        MaxLength="20"></asp:TextBox>
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
                                                                <td colspan="6" align="center">
                                                                    <asp:Button runat="server" ID="btnSave" Text="Save & Continue" OnClick="btnPedestrianSave_Click"
                                                                        ValidationGroup="vsPadestrianInfoGroup" OnClientClick="return CheckValidationPedestrianInfo();" />
                                                                    <asp:Button runat="server" ID="btnPedestrianAudit" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();"
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
                                                <asp:UpdatePanel runat="server" ID="updWitness">
                                                    <ContentTemplate>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" style="width: 18%">
                                                                    Name&nbsp;<span id="Span181" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtWitness_Name" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Address 1&nbsp;<span id="Span182" style="color: Red; display: none;" runat="server">*</span>
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
                                                                    Home Telephone&nbsp;<span id="Span183" style="color: Red; display: none;" runat="server">*</span><br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtWitness_Home_Phone" Width="170px" MaxLength="13"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revWitness_Home_Phone" ControlToValidate="txtWitness_Home_Phone"
                                                                        runat="server" ValidationGroup="vsWitnessInfoGroup" ErrorMessage="Please Enter Witness Home Phone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    Address 2&nbsp;<span id="Span184" style="color: Red; display: none;" runat="server">*</span>
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
                                                                    Work Telephone&nbsp;<span id="Span185" style="color: Red; display: none;" runat="server">*</span><br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtWitness_Work_Phone" Width="170px" MaxLength="13"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revWitness_Work_Phone" ControlToValidate="txtWitness_Work_Phone"
                                                                        runat="server" ValidationGroup="vsWitnessInfoGroup" ErrorMessage="Please Enter Witness Work Phone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    City&nbsp;<span id="Span186" style="color: Red; display: none;" runat="server">*</span>
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
                                                                    Alternate Telephone&nbsp;<span id="Span187" style="color: Red; display: none;" runat="server">*</span><br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center" style="width: 4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="server" ID="txtWitness_Alternate_Phone" Width="170px" MaxLength="13"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revWitness_Alternate_Phone" ControlToValidate="txtWitness_Alternate_Phone"
                                                                        runat="server" ValidationGroup="vsWitnessInfoGroup" ErrorMessage="Please Enter Witness Alternate Phone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left" style="width: 18%">
                                                                    State&nbsp;<span id="Span188" style="color: Red; display: none;" runat="server">*</span>
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
                                                                    Zip&nbsp;<span id="Span189" style="color: Red; display: none;" runat="server">*</span>
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
                                                                        ValidationGroup="vsWitnessInfoGroup" OnClientClick="return CheckValidationWitnessInfo();" />
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
                                                    Comments and Attachments</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" style="width: 18%" valign="top">
                                                            Comments&nbsp;<span id="Span190" style="color: Red; display: none;" runat="server">*</span>
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
                                                            <uc:ctrlAttachmentDetails ID="CtrlAttachDetails" runat="Server" ModeofPage="editmode" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <uc:ctrlAttachment ID="CtrlAttachments" runat="Server" />
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
                                                            Accident State
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblClaimant_state"></asp:Label>
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
                                                        Auto Liability - Type
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                        <asp:Label runat="server" ID="lblAuto_Liability_Type"></asp:Label>
                                                        </td>
                                                        <td colspan="3">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Injury Occured
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label runat="server" ID="lblLoss_offsite"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%" id="trViewLossInjuryOccured"
                                                                runat="Server" style="display: none;">
                                                                <tr>
                                                                    <td style="width: 18%">
                                                                        Address 1
                                                                    </td>
                                                                    <td style="width: 4%">
                                                                        :
                                                                    </td>
                                                                    <td style="width: 28%">
                                                                        <asp:Label runat="server" ID="lblOffsite_Address1"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        Address 2
                                                                    </td>
                                                                    <td>
                                                                        :
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label runat="server" ID="lblOffsite_Address2"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        City
                                                                    </td>
                                                                    <td>
                                                                        :
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label runat="server" ID="lblOffsite_City"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        State
                                                                    </td>
                                                                    <td>
                                                                        :
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label runat="server" ID="lblOffsite_State"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        Zipcode
                                                                    </td>
                                                                    <td>
                                                                        :
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label runat="server" ID="lblOffsite_zip"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
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
                                                    <tr>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%" id="trViewLossPloiceNotified"
                                                                runat="server" style="display: none;">
                                                                <tr>
                                                                    <td style="width: 18%">
                                                                        Police
                                                                    </td>
                                                                    <td style="width: 4%">
                                                                        :
                                                                    </td>
                                                                    <td style="width: 28%">
                                                                        <asp:Label runat="server" ID="lblPolice_Agency"></asp:Label>
                                                                    </td>
                                                                    <td style="width: 18%">
                                                                        Case Number
                                                                    </td>
                                                                    <td style="width: 4%">
                                                                        :
                                                                    </td>
                                                                    <td style="width: 28%">
                                                                        <asp:Label runat="server" ID="lblPolice_Case_Number"></asp:Label>
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
                                                                        <asp:Label runat="server" ID="lblPolice_Station_Phone_Number"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Were Pedestrians Involved?
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label ID="lblPedestrian_Involved" runat="server"></asp:Label>
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
                                            <asp:Panel ID="pnlViewInsuredVehicle" runat="server" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Insured Vehicle</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Vehicle Sub Type
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblVehicle_Sub_Type"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Fleet/Vehicle Number
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblVehicle_Fleet_number"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Year
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblYear"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            Make
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblMake"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Model
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblModel"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            VIN
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblVIN"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            License Plate Number
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblLicense_Plate_Number"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            License Plate State
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblLicense_Plate_State"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Vehicle Color
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblVehicle_Color"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            Permissive Use
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="Server" ID="lblPermissive_Use"></asp:Label>
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
                                                            Type of Use
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="Server" ID="lblType_Of_Use">
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Description of Damage
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="lblVehicle_Damage_Description" runat="server" MaxLength="4000"
                                                                ControlType="label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Repairs Completed
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblRepairs_Completed"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            Estimated Amount
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblRepairs_Estimated_Amount"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Drivable
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblDrivable"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            Were there any passengers?
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblPassengers"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Is the insured driver at fault?
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label runat="server" ID="lblInsured_Driver_At_Fault"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Location where vehicle can be seen
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label runat="server" ID="lblVehicle_Location"></asp:Label>
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
                                                            <asp:Label runat="server" ID="lblVehicle_Location_Driver_Address_1"></asp:Label>
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
                                                            <asp:Label runat="server" ID="lblVehicle_Location_Driver_Address_2"></asp:Label>
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
                                                            <asp:Label runat="server" ID="lblVehicle_Location_Driver_City"></asp:Label>
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
                                                            <asp:Label runat="server" ID="lblVehicle_Location_Driver_State"></asp:Label>
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
                                                            <asp:Label runat="server" ID="lblVehicle_Location_Driver_ZipCode"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Owner Name
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblOwner_Name"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            Work Telephone<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblOwner_Work_Phone"></asp:Label>
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
                                                            <asp:Label runat="server" ID="lblOwner_Address_1"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            Home Telephone<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblOwner_Home_Phone"></asp:Label>
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
                                                            <asp:Label runat="server" ID="lblOwner_Address_2"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            Alternate Telephone<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblOwner_Alternate_Phone"></asp:Label>
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
                                                            <asp:Label runat="server" ID="lblOwner_City"></asp:Label>
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
                                                            <asp:Label runat="server" ID="lblOwner_State">
                                                            </asp:Label>
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
                                                            <asp:Label runat="server" ID="lblOwner_ZipCode"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlViewInsuredVehicleDriver" runat="server" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Insured Vehicle Driver Information</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Name
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblDriver_Name"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Social Security Number
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblDriver_SSN"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Address 1
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblDriver_Address1"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Date of Birth
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label ID="lblDriver_Date_of_Birth" runat="server"></asp:Label>
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
                                                            <asp:Label runat="server" ID="lblDriver_Address2"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Age
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblDriverAgeCount"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            City
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblDriver_City"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Work Telephone<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblDriver_Work_Phone"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            State
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblDriver_State"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Home Telephone<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblDriver_Home_Phone"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Zip Code
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblDriver_ZipCode"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Alternate Telephone<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblDriver_Altermate_Phone"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Driver’s License State
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblDriver_Drivers_License_State"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Driver’s License Number
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblDriver_Drivers_License_Number"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Relation to Insured
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblDriver_Relation_to_Insured"></asp:Label>
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
                                                        <td align="left" style="width: 18%">
                                                            Citation Issued
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblCitation_Issued"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Citation Number
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblCitation_Number"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Driver was Injured
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblDriver_Was_Injured"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Description of Injury
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblDriver_Injury_Description"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Driver sought medical attention
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblDriver_Sought_Medical_Attention"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Driver same as Owner
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblDriver_Is_Owner"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Taken By Emergency Transportation?
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblDriver_Taken_By_Emergency_Transportation"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Airlifted/Medivac
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblDriver_Airlifted_Medivac"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Medical Facility Name
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblDriver_Medical_Facility_Name"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Date of Initial Treatment
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label ID="lblDriver_Date_Of_Initial_Treatment" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Medical Facility Type
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblDriver_Medical_Facility_Type"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Treating Physician’s Name
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblDriver_Treating_Physician_Name"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Medical Facility Address 1
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblDriver_Medical_Facility_Address_1"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Admitted to Hospital
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblDriver_Admitted_to_Hospital"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Medical Facility Address 2
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblDriver_Medical_Facility_Address_2"></asp:Label>
                                                        </td>
                                                        <td align="left" colspan="3" id="tdViewDateAdmitted" runat="server" style="display: none;">
                                                            <table cellpadding="0" cellspacing="3" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" style="width: 18%">
                                                                        Date Admitted
                                                                    </td>
                                                                    <td align="center" style="width: 4%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" style="width: 28%">
                                                                        <asp:Label ID="lblDriver_Date_Admitted_to_Hospital" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Medical Facility City
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblDriver_Medical_Facility_City"></asp:Label>
                                                        </td>
                                                        <td align="left" id="tdViewStillHospital" runat="server" colspan="3" style="display: none;">
                                                            <table cellpadding="0" cellspacing="3" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" style="width: 18%">
                                                                        Still in Hospital
                                                                    </td>
                                                                    <td align="center" style="width: 4%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" style="width: 28%">
                                                                        <asp:Label runat="server" ID="lblDriver_Still_in_Hospital"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Medical Facility State
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblDriver_Medical_Facility_State"></asp:Label>
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
                                                        <td align="left" style="width: 18%">
                                                            Medical Facility Zip Code
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblDriver_Medical_Facility_Zip_Code"></asp:Label>
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
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlViewInsuredVehiclePassenger" Width="100%" runat="server">
                                                <div class="bandHeaderRow">
                                                    Insured Vehicle Passenger Information</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Name
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblPassenger_Name"></asp:Label>
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
                                                        <td align="left" style="width: 18%">
                                                            Address 1
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblPassenger_Address_1"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Date of Birth
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label ID="lblPassenger_Date_of_Birth" runat="server"></asp:Label>
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
                                                            <asp:Label runat="server" ID="lblPassenger_Address_2"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Age
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblPassengerAgeCount"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            City
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblPassenger_City"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Work Telephone<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblPassenger_Work_Phone"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            State
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblPassenger_State"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Home Telephone<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblPassenger_Home_Phone"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Zip Code
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblPassenger_ZipCode"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Alternate Telephone<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblPassenger_Alternate_Phone"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Driver’s License State
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblPassenger_Drivers_License_State"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Driver’s License Number
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblPassenger_Drivers_License_Number"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Relation to Insured
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblPassenger_Relation_to_Insured"></asp:Label>
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
                                                        <td align="left" style="width: 18%">
                                                            Passenger was Injured
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblPassenger_Was_Injured"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Description of Injury
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblPassenger_Description_of_Injury"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Passenger sought medical attention
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblPassenger_Sought_Medical_Attention"></asp:Label>
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
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlViewOtherVehicle" runat="server" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Other Vehicle</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Year
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOther_Vehicle_Year"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Make
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOther_Vehicle_Make"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Model
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblOther_Vehicle_Model"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            VIN
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblOther_Vehicle_VIN"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            License Plate Number
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblOther_Vehicle_License_Plate_Number"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            License Plate State
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblOther_Vehicle_License_Plate_State"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Vehicle Color
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblOther_Vehicle_Vehicle_Color"></asp:Label>
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
                                                            Insurance Company Name
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblOther_Vehicle_Insurance_Co_Name"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            Insurance Company Phone
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblOther_Vehicle_Insurance_Co_Phone"></asp:Label>
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
                                                            <asp:Label runat="server" ID="lblOther_Vehicle_Insurance_Policy_Number"></asp:Label>
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
                                                        <td align="left" valign="top">
                                                            Description of Damage
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblOther_Vehicle_Vehicle_Damage_Description" runat="server"
                                                                MaxLength="4000" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Repairs Completed
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblOther_Vehicle_Repairs_Completed"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            Estimated Amount
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblOther_Vehicle_Repairs_Estimated_Amount"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Drivable
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblOther_Vehicle_Drivable"></asp:Label>
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
                                                            <asp:Label runat="server" ID="lblOther_Vehicle_Location"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            Location Telephone
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblOther_Vehicle_Location_Telephone"></asp:Label>
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
                                                            <asp:Label runat="server" ID="lblOther_Vehicle_Location_Driver_Address_1"></asp:Label>
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
                                                            <asp:Label runat="server" ID="lblOther_Vehicle_Location_Driver_Address_2"></asp:Label>
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
                                                            <asp:Label runat="server" ID="lblOther_Vehicle_Location_Driver_City"></asp:Label>
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
                                                            <asp:Label runat="server" ID="lblOther_Vehicle_Location_Driver_State"></asp:Label>
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
                                                            <asp:Label runat="server" ID="lblOther_Vehicle_Location_Driver_ZipCode"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Owner Name
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblOther_Vehicle_Owner_Name"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            Work Telephone<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblOther_Vehicle_Owner_Work_Phone"></asp:Label>
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
                                                            <asp:Label runat="server" ID="lblOther_Vehicle_Owner_Address_1"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            Home Telephone<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblOther_Vehicle_Owner_Home_Phone"></asp:Label>
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
                                                            <asp:Label runat="server" ID="lblOther_Vehicle_Owner_Address_2"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            Alternate Telephone<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblOther_Vehicle_Owner_Alternate_Phone"></asp:Label>
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
                                                            <asp:Label runat="server" ID="lblOther_Vehicle_Owner_City"></asp:Label>
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
                                                            <asp:Label runat="server" ID="lblOther_Vehicle_Owner_State"></asp:Label>
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
                                                            <asp:Label runat="server" ID="lblOther_Vehicle_Owner_ZipCode"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel runat="server" ID="pnlViewOtherVehicleDriver" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Other Vehicle Driver Information</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Name
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOther_Driver_Name"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Social Security Number
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOther_Driver_SSN"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Address 1
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOther_Driver_Address_1"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Date of Birth
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label ID="lblOther_Driver_Date_of_Birth" runat="server"></asp:Label>
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
                                                            <asp:Label runat="server" ID="lblOther_Driver_Address_2"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Age
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOther_Driver_AgeCount"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            City
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOther_Driver_City"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Work Telephone<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOther_Driver_Work_Phone"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            State
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOther_Driver_State"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Home Telephone<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOther_Driver_Home_Phone"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Zip Code
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOther_Driver_ZipCode"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Driver’s License Number
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOther_Driver_Drivers_License_Number"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Gender
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOther_Driver_Gender"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Driver’s License State
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOther_Driver_Drivers_License_State"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Citation Issued
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOther_Driver_Citation_Issued"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Citation Number
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOther_Driver_Citation_Number"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Driver was Injured
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOther_Driver_Injured"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Description of Injury
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOther_Driver_Injury_Description"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Driver sought medical attention
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOther_Driver_Sought_Medical_Attention"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Taken By Emergency Transportation?
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOther_Driver_Taken_By_Emergency_Transportation"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Airlifted/Medivac
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOther_Driver_Airlifted_Medivac"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Medical Facility Name
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOther_Driver_Medical_Facility_Name"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Admitted to Hospital
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOther_Driver_Admitted_to_Hospital"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Medical Facility Address 1
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOther_Driver_Medical_Facility_Address_1"></asp:Label>
                                                        </td>
                                                        <td align="left" colspan="3" id="tdViewOth_Driver_DateAdmitted" runat="server" style="display: none;">
                                                            <table cellpadding="0" cellspacing="3" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" style="width: 18%">
                                                                        Date Admitted
                                                                    </td>
                                                                    <td align="center" style="width: 4%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" style="width: 28%">
                                                                        <asp:Label ID="lblOther_Driver_Date_Admitted_to_Hospital" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Medical Facility Address 2
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOther_Driver_Medical_Facility_Address_2"></asp:Label>
                                                        </td>
                                                        <td align="left" colspan="3" id="tdViewOth_Driver_StillHospital" runat="server" style="display: none;">
                                                            <table cellpadding="0" cellspacing="3" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" style="width: 18%">
                                                                        Still in Hospital
                                                                    </td>
                                                                    <td align="center" style="width: 4%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" style="width: 28%">
                                                                        <asp:Label runat="server" ID="lblOther_Driver_Still_in_Hospital"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Medical Facility City
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOther_Driver_Medical_Facility_City"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Physician's Name
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOther_Driver_Physicians_Name"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Medical Facility State
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOther_Driver_Medical_Facility_State"></asp:Label>
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
                                                        <td align="left" style="width: 18%">
                                                            Medical Facility Zip Code
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOther_Driver_Medical_Facility_Zip_Code"></asp:Label>
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
                                                        <td align="left" style="width: 18%">
                                                            Medical Facility Type
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOther_Driver_Medical_Facility_Type"></asp:Label>
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
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlViewOtherVehiclePassenger" Width="100%" runat="server">
                                                <div class="bandHeaderRow">
                                                    Other Vehicle Passenger Information</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Name
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOth_Veh_Pass_Name"></asp:Label>
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
                                                        <td align="left" style="width: 18%">
                                                            Address 1
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOth_Veh_Pass_Address_1"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Date of Birth
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label ID="lblOth_Veh_Pass_Date_of_Birth" runat="server"></asp:Label>
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
                                                            <asp:Label runat="server" ID="lblOth_Veh_Pass_Address_2"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Age
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOth_Veh_Pass_AgeCount"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            City
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOth_Veh_Pass_City"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Work Telephone<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOth_Veh_Pass_Work_Phone"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            State
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOth_Veh_Pass_State"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Home Telephone<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOth_Veh_Pass_Home_Phone"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Zip Code
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOth_Veh_Pass_ZipCode"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Alternate Telephone<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOth_Veh_Pass_Alternate_Phone"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Passenger was Injured
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOth_Veh_Pass_Injured"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Description of Injury
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOth_Veh_Pass_Injury_Description"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Passenger sought medical attention
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOth_Veh_Pass_Sought_Medical_Attention"></asp:Label>
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
                                                        <td align="left" style="width: 18%">
                                                            Taken By Emergency Transportation?
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOth_Veh_Pass_Taken_By_Emergency_Transportation"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Airlifted/Medivac
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOth_Veh_Pass_Airlifted_Medivac"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Medical Facility Name
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOth_Veh_Pass_Medical_Facility_Name"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Admitted to Hospital
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOth_Veh_Pass_Admitted_to_Hospital"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Medical Facility Address 1
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOth_Veh_Pass_Medical_Facility_Address_1"></asp:Label>
                                                        </td>
                                                        <td align="left" colspan="3" id="tdViewOth_Ven_Pass_DateAdmitted" runat="server"
                                                            style="display: none;">
                                                            <table cellpadding="0" cellspacing="3" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" style="width: 18%">
                                                                        Date Admitted
                                                                    </td>
                                                                    <td align="center" style="width: 4%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" style="width: 28%">
                                                                        <asp:Label ID="lblOth_Veh_Pass_Date_Admitted_to_Hospital" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Medical Facility Address 2
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOth_Veh_Pass_Medical_Facility_Address_2"></asp:Label>
                                                        </td>
                                                        <td align="left" colspan="3" id="tdViewOth_Ven_Pass_StillHospital" runat="server"
                                                            style="display: none;">
                                                            <table cellpadding="0" cellspacing="3" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" style="width: 18%">
                                                                        Still in Hospital
                                                                    </td>
                                                                    <td align="center" style="width: 4%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" style="width: 28%">
                                                                        <asp:Label runat="server" ID="lblOth_Veh_Pass_Still_in_Hospital"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Medical Facility City
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOth_Veh_Pass_Medical_Facility_City"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Physician's Name
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOth_Veh_Pass_Physicians_Name"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Medical Facility State
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOth_Veh_Pass_Medical_Facility_State"></asp:Label>
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
                                                        <td align="left" style="width: 18%">
                                                            Medical Facility Zip Code
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOth_Veh_Pass_Medical_Facility_Zip_Code"></asp:Label>
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
                                                        <td align="left" style="width: 18%">
                                                            Medical Facility Type
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblOth_Veh_Pass_Medical_Facility_Type"></asp:Label>
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
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel runat="server" ID="pnlViewpedstrian" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Pedestrian Information</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Name
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblPedestrian_Name"></asp:Label>
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
                                                        <td align="left" style="width: 18%">
                                                            Address 1
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblPedestrian_Address_1"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Date of Birth
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label ID="lblPedestrian_Date_of_Birth" runat="server"></asp:Label>
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
                                                            <asp:Label runat="server" ID="lblPedestrian_Address_2"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Age
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblPedestrianAgeCount"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            City
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblPedestrian_City"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Work Telephone<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblPedestrian_Work_Phone"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            State
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblPedestrian_State"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Home Telephone<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblPedestrian_Home_Phone"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Zip Code
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblPedestrian_ZipCode"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Alternate Telephone<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblPedestrian_Alternate_Phone"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Pedestrian was Injured
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblPedestrian_Injured"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Description of Injury
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblPedestrian_Injury_Description"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Pedestrian sought medical attention
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblPedestrian_Sought_Medical_Attention"></asp:Label>
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
                                                        <td align="left" style="width: 18%">
                                                            Taken By Emergency Transportation?
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblPedestrian_Taken_By_Emergency_Transportation"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Airlifted/Medivac
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblPedestrian_Airlifted_Medivac"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Medical Facility Name
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblPedestrian_Medical_Facility_Name"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Admitted to Hospital
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblPedestrian_Admitted_to_Hospital"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Medical Facility Address 1
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblPedestrian_Medical_Facility_Address_1"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Date Admitted
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label ID="lblPedestrian_Date_Admitted_to_Hospital" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Medical Facility Address 2
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblPedestrian_Medical_Facility_Address_2"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Still in Hospital
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblPedestrian_Still_in_Hospital"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Medical Facility City
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblPedestrian_Medical_Facility_City"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">
                                                            Physician's Name
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblPedestrian_Physicians_Name"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">
                                                            Medical Facility State
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblPedestrian_Medical_Facility_State"></asp:Label>
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
                                                        <td align="left" style="width: 18%">
                                                            Medical Facility Zip Code
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblPedestrian_Medical_Facility_Zip_Code"></asp:Label>
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
                                                        <td align="left" style="width: 18%">
                                                            Medical Facility Type
                                                        </td>
                                                        <td align="center" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblPedestrian_Medical_Facility_Type"></asp:Label>
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
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblComments" runat="server" MaxLength="4000" ControlType="Label" />
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
    <asp:CustomValidator ID="CustomValidator4" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFieldsLocationInformation"
        Display="None" ValidationGroup="vsContactInfoGroup" />
    <input id="hdnLocationContactIDs" runat="server" type="hidden" />
    <input id="hdnLocationContactErrorMsgs" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFieldsLossInformation"
        Display="None" ValidationGroup="vsLossInfoGroup" />
    <input id="hdnLossInformationIDs" runat="server" type="hidden" />
    <input id="hdnLossInformationErrorMsgs" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFieldsInsuredVehicle"
        Display="None" ValidationGroup="vsInsuredVehicleInfoGroup" />
    <input id="hdnInsuredVehicleIDs" runat="server" type="hidden" />
    <input id="hdnInsuredVehicleErrorMsgs" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFieldsInsuredVehicleDriver"
        Display="None" ValidationGroup="vsInsuredDriverInfoGroup" />
    <input id="hdnInsuredVehicleDriverIDs" runat="server" type="hidden" />
    <input id="hdnInsuredVehicleDriverErrorMsgs" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidator5" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFieldsInsuredVehiclePassenger"
        Display="None" ValidationGroup="vsInsuredPassengerInfoGroup" />
    <input id="hdnInsuredVehiclePassengerIDs" runat="server" type="hidden" />
    <input id="hdnInsuredVehiclePassengerErrorMsgs" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidator6" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFieldsOtherVehicle"
        Display="None" ValidationGroup="vsOtherVehicleInfoGroup" />
    <input id="hdnOtherVehicleIDs" runat="server" type="hidden" />
    <input id="hdnOtherVehicleErrorMsgs" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidator7" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFieldsOtherVehicleDriver"
        Display="None" ValidationGroup="vsOtherVehicleDriverInfoGroup" />
    <input id="hdnOtherVehicleDriverIDs" runat="server" type="hidden" />
    <input id="hdnOtherVehicleDriverErrorMsgs" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidator8" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFieldsOtherVehiclePassenger"
        Display="None" ValidationGroup="vsOtherVehiclePassengerInfoGroup" />
    <input id="hdnOtherVehiclePassengerIDs" runat="server" type="hidden" />
    <input id="hdnOtherVehiclePassengerErrorMsgs" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidator9" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFieldsPedestrian"
        Display="None" ValidationGroup="vsPadestrianInfoGroup" />
    <input id="hdnPedestrianIDs" runat="server" type="hidden" />
    <input id="hdnPedestrianErrorMsgs" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidator10" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFieldsWitness"
        Display="None" ValidationGroup="vsWitnessInfoGroup" />
    <input id="hdnWitnessIDs" runat="server" type="hidden" />
    <input id="hdnWitnessErrorMsgs" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidator11" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFieldsComments"
        Display="None" ValidationGroup="vsCommentsGroup" />
    <input id="hdnCommentsID" runat="server" type="hidden" />
    <input id="hdnCommentsErrorMsgs" runat="server" type="hidden" />
</asp:Content>
