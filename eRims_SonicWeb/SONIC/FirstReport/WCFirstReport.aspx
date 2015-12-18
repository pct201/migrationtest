<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="WCFirstReport.aspx.cs"
    Inherits="SONIC_WCFirstReport" Title="eRIMS Sonic :: First Report :: Worker's Compensation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachments/Attachment.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/AttachmentDetails/AttachmentDetails.ascx" TagName="ctrlAttachmentDetails"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/SONICtab/SonicTab.ascx" TagName="CtlSonicTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/SONICInfo/SonicInfo.ascx" TagName="CtlSonicInfo" TagPrefix="uc" %>
<%@ Register Src="~/Controls/AttachmentDetails/AttachmentDetails.ascx" TagName="Test"
    TagPrefix="ucTest" %>
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

            obj = window.open("AuditPopup_WCFirstReport.aspx?id=" + '<%=ViewState["WC_FR_ID"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }
        //check Date Validation
        function CheckDate(sender, args) {
            args.IsValid = (ValidateDate(args.Value));
            return args.IsValid;
        }
        //For Testing
        function Test() {
            document.getElementById('<%=btnHdnTest.ClientID %>').click();
        }
        ///used to fire all the function that are used to dispply/hide associate panels.
        function FireAll() {
            CheckInjuryOccured();
            CheckReferringPhysician();
            checkWorkStatus();
        }
        //used to check radio buttons for work status. and according to selection of radiobutton an image of calender is displayed.
        function checkWorkStatus() {
            var rdo1 = document.getElementById('<%=rdoStatus_Out_Of_Work.ClientID %>');
            var rdo2 = document.getElementById('<%=rdoStatus_Return_To_Work_Unrestricted.ClientID %>');
            var rdo3 = document.getElementById('<%=rdoStatus_Return_Tp_Work_Restricted.ClientID %>');
            var rdo4 = document.getElementById('<%=rdoStatus_Unknown.ClientID %>');
            var img1 = document.getElementById('imgStatus_Out_Of_Work');
            var img2 = document.getElementById('imgStatus_Return_To_Work_Unrestricted');
            var img3 = document.getElementById('imgStatus_Return_Tp_Work_Restricted');
            var Span1 = document.getElementById('<%=Span45.ClientID %>');
            var Span2 = document.getElementById('<%=Span46.ClientID %>');
            var Span3 = document.getElementById('<%=Span47.ClientID %>');
            var chk = false;
            //used to check all calender image are available or not.
            if (img1 != null && img2 != null && img3 != null) {
                //used to check a variable value. if it is false than only check a radiobutton value
                if (chk == false) {
                    //check radio button's checked value if it is true than display a calender control. and also disable all other calender control 
                    if (rdo1.checked == true) {
                        img1.style.display = "inline";
                        img2.style.display = "none";
                        img3.style.display = "none";
                        document.getElementById('<%=txtStatus_Out_Of_Work_date.ClientID %>').disabled = false;
                        document.getElementById('<%=txtStatus_Return_To_Work_Unrestricted_date.ClientID %>').value = '';
                        document.getElementById('<%=txtStatus_Return_To_Work_Unrestricted_date.ClientID %>').disabled = true;
                        document.getElementById('<%=txtStatus_Return_Tp_Work_Restricted_date.ClientID %>').value = '';
                        document.getElementById('<%=txtStatus_Return_Tp_Work_Restricted_date.ClientID %>').disabled = true;
                        Span1.style.display = "inline";
                        Span2.style.display = "none";
                        Span3.style.display = "none";
                        chk = true;
                    }
                }
                //used to check a variable value. if it is false than only check a radiobutton value
                if (chk == false) {
                    //check radio button's checked value if it is true than display a calender control. and also disable all other calender control 
                    if (rdo2.checked == true) {
                        img1.style.display = "none";
                        img2.style.display = "inline";
                        img3.style.display = "none";
                        document.getElementById('<%=txtStatus_Return_To_Work_Unrestricted_date.ClientID %>').disabled = false;
                        document.getElementById('<%=txtStatus_Out_Of_Work_date.ClientID %>').value = '';
                        document.getElementById('<%=txtStatus_Out_Of_Work_date.ClientID %>').disabled = true;
                        document.getElementById('<%=txtStatus_Return_Tp_Work_Restricted_date.ClientID %>').value = '';
                        document.getElementById('<%=txtStatus_Return_Tp_Work_Restricted_date.ClientID %>').disabled = true;
                        Span2.style.display = "inline";
                        Span1.style.display = "none";
                        Span3.style.display = "none";
                        chk = true;
                    }
                }
                //used to check a variable value. if it is false than only check a radiobutton value
                if (chk == false) {
                    //check radio button's checked value if it is true than display a calender control. and also disable all other calender control 
                    if (rdo3.checked == true) {
                        img1.style.display = "none";
                        img2.style.display = "none";
                        img3.style.display = "inline";
                        document.getElementById('<%=txtStatus_Return_Tp_Work_Restricted_date.ClientID %>').disabled = false;
                        document.getElementById('<%=txtStatus_Out_Of_Work_date.ClientID %>').value = '';
                        document.getElementById('<%=txtStatus_Out_Of_Work_date.ClientID %>').disabled = true;
                        document.getElementById('<%=txtStatus_Return_To_Work_Unrestricted_date.ClientID %>').value = '';
                        document.getElementById('<%=txtStatus_Return_To_Work_Unrestricted_date.ClientID %>').disabled = true;
                        Span3.style.display = "inline";
                        Span1.style.display = "none";
                        Span2.style.display = "none";
                        chk = true;
                    }
                }
                //used to check a variable value. if it is false than only check a radiobutton value
                if (chk == false) {
                    //check radio button's checked value if it is true than display a calender control. and also disable all other calender control 
                    if (rdo4.checked == true) {
                        img1.style.display = "none";
                        img2.style.display = "none";
                        img3.style.display = "none";
                        document.getElementById('<%=txtStatus_Out_Of_Work_date.ClientID %>').value = '';
                        document.getElementById('<%=txtStatus_Out_Of_Work_date.ClientID %>').disabled = true;
                        document.getElementById('<%=txtStatus_Return_Tp_Work_Restricted_date.ClientID %>').value = '';
                        document.getElementById('<%=txtStatus_Return_Tp_Work_Restricted_date.ClientID %>').disabled = true;
                        document.getElementById('<%=txtStatus_Return_To_Work_Unrestricted_date.ClientID %>').value = '';
                        document.getElementById('<%=txtStatus_Return_To_Work_Unrestricted_date.ClientID %>').disabled = true;
                        Span1.style.display = "none";
                        Span2.style.display = "none";
                        Span3.style.display = "none";
                        chk = true;
                    }
                }
            }
        }

        //Check all Validation when user click on Submit button
        function CheckAllValidation() {
            if (CheckValidationLocationInfo() == true && CheckAssociateValues() == true && CheckValidationIncidentInfo() == true &&
                CheckValidationMedicalInfo() == true && CheckValidationContactsInfo() == true && CheckComments() == true) {
                return true;
            }
            else
                return false;
        }

        //check validation for Location Information
        function CheckValidationLocationInfo() {
            //if number is "___-___-____" than set it to ""
            if (document.getElementById('<%=txtContactFaxNumber.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtContactFaxNumber.ClientID%>').value = "";

            //validate page for passed validation group.
            if (Page_ClientValidate("vsLocationGroup"))
                return true;
            else
                return false;
        }

        //check validation for Contact Information
        function CheckValidationContactsInfo() {
            //if number have value "___-___-____" than set it to ""
            if (document.getElementById('<%=txtContactTelephone1.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtContactTelephone1.ClientID%>').value = "";
            if (document.getElementById('<%=txtContactTelephone2.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtContactTelephone2.ClientID%>').value = "";
            if (document.getElementById('<%=txtContactDetailFaxNumber.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtContactDetailFaxNumber.ClientID%>').value = "";
            if (document.getElementById('<%=txtContactRLCMTelephone1.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtContactRLCMTelephone1.ClientID%>').value = "";
            if (document.getElementById('<%=txtContactRLCMTelephone2.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtContactRLCMTelephone2.ClientID%>').value = "";

            //Validate page for passed validation group id
            if (Page_ClientValidate("vsContactsGroup"))
                return true;
            else
                return false;
        }

        //make validation for Medicle Information Panel
        function CheckValidationMedicalInfo() {
            //if number is "___-___-____" than set it to ""
            if (document.getElementById('<%=txtDate_of_Initial_Medical_Treatment.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtDate_of_Initial_Medical_Treatment.ClientID%>').value = "";
            if (document.getElementById('<%=txtMedical_Facility_Phone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtMedical_Facility_Phone.ClientID%>').value = "";
            if (document.getElementById('<%=txtStatus_Out_Of_Work_date.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtStatus_Out_Of_Work_date.ClientID%>').value = "";
            if (document.getElementById('<%=txtStatus_Return_To_Work_Unrestricted_date.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtStatus_Return_To_Work_Unrestricted_date.ClientID%>').value = "";
            if (document.getElementById('<%=txtStatus_Return_Tp_Work_Restricted_date.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtStatus_Return_Tp_Work_Restricted_date.ClientID%>').value = "";
            if (document.getElementById('<%=txtNext_Doctor_Visit.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtNext_Doctor_Visit.ClientID%>').value = "";
            if (document.getElementById('<%=txtPhysician_Phone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtPhysician_Phone.ClientID%>').value = "";

            // validate page by passed validaiton group id.
            if (Page_ClientValidate("vsMedicalGroup"))
                return true;
            else
                return false;

        }

        // Make Validation fro Incident INformation Panel
        function CheckValidationIncidentInfo() {
            //if number is "___-___-____" than set it to ""
            if (document.getElementById('<%=txtWitness_1_Phone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtWitness_1_Phone.ClientID%>').value = "";
            if (document.getElementById('<%=txtWitness_2_Phone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtWitness_2_Phone.ClientID%>').value = "";
            if (document.getElementById('<%=txtWitness_3_Phone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtWitness_3_Phone.ClientID%>').value = "";
          <%--  if (document.getElementById('<%=txtFacility_Zip_Code.ClientID%>').value == "_____-____")
                document.getElementById('<%=txtFacility_Zip_Code.ClientID%>').value = "";--%>
            //if time is "__:__" than set it to ""
            if (document.getElementById('<%=txtTime_Of_Incident.ClientID%>').value == "__:__")
                document.getElementById('<%=txtTime_Of_Incident.ClientID%>').value = "";
            if (document.getElementById('<%=txtTime_Began_Work.ClientID%>').value == "__:__")
                document.getElementById('<%=txtTime_Began_Work.ClientID%>').value = "";
            //if time is containing "a" or "p" or "A" or "P" work than prompt the alert message and blank time value
            if (document.getElementById('<%=txtTime_Of_Incident.ClientID%>').value.indexOf("a") > 0 || document.getElementById('<%=txtTime_Of_Incident.ClientID%>').value.indexOf("A") > 0
            || document.getElementById('<%=txtTime_Of_Incident.ClientID%>').value.indexOf("p") > 0 || document.getElementById('<%=txtTime_Of_Incident.ClientID%>').value.indexOf("P") > 0) {
                alert('Invalid Time of Incident.');
                document.getElementById('<%=txtTime_Of_Incident.ClientID%>').value = "";
                return false;
            }
            //Validate Page by passed Validation Group ID
            if (Page_ClientValidate("vsIncidentInfoGroup")) {
                return true;
            }
            else
                return false;
        }
        //make validation for Locaiton information Panel
        function CheckValidationLocation() {
            //if number is "___-___-____" than set it to ""
            if (document.getElementById('<%=txtContactTelephoneNumber1.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtContactTelephoneNumber1.ClientID%>').value = "";
            if (document.getElementById('<%=txtContactTelephoneNumber2.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtContactTelephoneNumber2.ClientID%>').value = "";
            if (document.getElementById('<%=txtContactFaxNumber.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtContactFaxNumber.ClientID%>').value = "";
            //Validate Page by passed Validation Group ID
            if (Page_ClientValidate("vsLocationGroup")) {
                return true;
            }
            else
                return false;
        }
        //Make Validation for Associated Information Panel
        function CheckAssociateValues() {
            //if number is "___-___-____" than set it to ""
            if (document.getElementById('<%=txtAlternate_Phone_2.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtAlternate_Phone_2.ClientID%>').value = "";
            if (document.getElementById('<%=txtSupervisor_Telephone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtSupervisor_Telephone.ClientID%>').value = "";
            //Validate Page by passed Validation Group ID   
            if (Page_ClientValidate("vsAssociateGroup")) {
                return true;
            }
            else
                return false;
        }

        function CheckComments() {
            //Validate Page by passed Validation Group ID
            if (Page_ClientValidate("vsCommentsGroup"))
                return true;
            else
                return false;
        }

        //check radiobutton list value. if it is true than related fields are displayed else remains Hidden
        function CheckReferringPhysician() {
            ctl = document.getElementById('<%=rdoReferring_Physician.ClientID %>')
            rdo = document.getElementById(ctl.id + "_0");
            validator = document.getElementById('<%=revPhysician_Phone.ClientID %>')
            //check radio button value
            if (rdo.checked == true) {
                document.getElementById('<%=tdReferringPhysican.ClientID %>').style.display = "block";
                validator.enabled = true;
            }
            else {
                var Val = document.getElementById('<%=hdnMedicalPhysician.ClientID%>').value;
                if (Val != '1') {
                    document.getElementById('<%=txtPhysician_Name.ClientID %>').value = "";
                    document.getElementById('<%=txtPhysician_Address1.ClientID %>').value = "";
                    document.getElementById('<%=txtPhysician_Address2.ClientID %>').value = "";
                    document.getElementById('<%=txtPhysician_City.ClientID %>').value = "";
                    document.getElementById('<%=ddlPhysician_State.ClientID %>').selectedIndex = 0;
                    document.getElementById('<%=txtPhysician_Zip.ClientID %>').value = "";
                    document.getElementById('<%=txtPhysician_Phone.ClientID %>').value = "";
                }
                document.getElementById('<%=tdReferringPhysican.ClientID %>').style.display = "none";
                validator.enabled = false;
            }
        }
        //check radiobutton list value. if it is true than related fields are displayed else remains Hidden
        function CheckInjuryOccured() {
            ctl = document.getElementById('<%=rdoInjuryOccurredOffsite.ClientID %>');
            rdo = document.getElementById(ctl.id + "_0");

            //check radio button checked value
            if (rdo.checked == true) {
                document.getElementById('<%=trIncidentInjuryOccured.ClientID %>').style.display = "none";

            }
            else {
                document.getElementById('<%=trIncidentInjuryOccured.ClientID %>').style.display = "";
                var Val = document.getElementById('<%=hdnOnsiteOffsite.ClientID%>').value;
                if (Val != '1') {
                    document.getElementById('<%=txtOffsite_Address1.ClientID %>').value = "";
                    document.getElementById('<%=txtOffsite_Address2.ClientID %>').value = "";
                    document.getElementById('<%=txtOffsite_City.ClientID %>').value = "";
                    document.getElementById('<%=txtOffsite_zip.ClientID %>').value = "";
                    document.getElementById('<%=ddlOffsite_State.ClientID %>').selectedIndex = 0;
                }
            }
        }
        //set Menu style. accoring to the passed value in Index parameter.
        //passed index menu is selected and set the classname property.
        function SetMenuStyle(index) {
            var i;
            for (i = 1; i <= 6; i++) {
                var tb = document.getElementById("WCMenu" + i);
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
        //used to display panel as per passed index number.
        function ShowPanel(index) {
            SetMenuStyle(index);
            var op = '<%=strPageOpeMode%>';
            //check page mode. if Mode is View than page open in View mode else open in edit mode
            if (op == "view") {
                document.getElementById("<%=dvEdit.ClientID %>").style.display = "none";
                document.getElementById("<%=dvView.ClientID%>").style.display = "block";
                ShowPanelView(index);
            }
            else {
                document.getElementById("<%=dvView.ClientID%>").style.display = "none";
                if (index == 1) {
                    document.getElementById("<%=pnlLocation.ClientID%>").style.display = "block";
                    document.getElementById("<%=pnlAssociate.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlIncident.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlMedical.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlContacts.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlComments.ClientID%>").style.display = "none";
                }
                if (index == 2) {
                    document.getElementById("<%=pnlLocation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlAssociate.ClientID%>").style.display = "block";
                    document.getElementById("<%=pnlIncident.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlMedical.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlContacts.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlComments.ClientID%>").style.display = "none";
                }
                if (index == 3) {
                    document.getElementById("<%=pnlLocation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlAssociate.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlIncident.ClientID%>").style.display = "block";
                    document.getElementById("<%=pnlMedical.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlContacts.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlComments.ClientID%>").style.display = "none";
                }
                if (index == 4) {
                    document.getElementById("<%=pnlLocation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlAssociate.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlIncident.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlMedical.ClientID%>").style.display = "block";
                    document.getElementById("<%=pnlContacts.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlComments.ClientID%>").style.display = "none";
                }
                if (index == 5) {
                    document.getElementById("<%=pnlLocation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlAssociate.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlIncident.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlMedical.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlContacts.ClientID%>").style.display = "block";
                    document.getElementById("<%=pnlComments.ClientID%>").style.display = "none";
                }
                if (index == 6) {
                    document.getElementById("<%=pnlLocation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlAssociate.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlIncident.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlMedical.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlContacts.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlComments.ClientID%>").style.display = "block";
                }
            }

            document.getElementById("<%=hdnCureentPanel.ClientID%>").value = index;
        }
        ///Used to open page in View mode.
        function ShowPanelView(index) {
            SetMenuStyle(index);
            //used to check index value. and accorind to answer Panel is displayed.
            if (index == 1) {
                document.getElementById("<%=pnlViewLocation.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlViewAssociate.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewIncident.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewMedical.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewContacts.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewComments.ClientID%>").style.display = "none";
            }
            if (index == 2) {
                document.getElementById("<%=pnlViewLocation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewAssociate.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlViewIncident.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewMedical.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewContacts.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewComments.ClientID%>").style.display = "none";
            }
            if (index == 3) {
                document.getElementById("<%=pnlViewLocation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewAssociate.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewIncident.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlViewMedical.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewContacts.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewComments.ClientID%>").style.display = "none";
            }
            if (index == 4) {
                document.getElementById("<%=pnlViewLocation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewAssociate.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewIncident.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewMedical.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlViewContacts.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewComments.ClientID%>").style.display = "none";
            }
            if (index == 5) {
                document.getElementById("<%=pnlViewLocation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewAssociate.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewIncident.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewMedical.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewContacts.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlViewComments.ClientID%>").style.display = "none";
            }
            if (index == 6) {
                document.getElementById("<%=pnlViewLocation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewAssociate.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewIncident.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewMedical.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewContacts.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewComments.ClientID%>").style.display = "block";
            }
        }

        function ValidateFieldsAssociate(sender, args) {
            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnAssociateID.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnAssociateErrorMsgs.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnAssociateID.ClientID%>').value != "") {
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

        function ValidateFieldsIncident(sender, args) {
            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnIncidentID.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnIncidentErrorMsgs.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnIncidentID.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {

                        case "textarea": if (ctrl.value == '') bEmpty = true; break;
                        case "text":
                            if (ctrl.value == '') {
                                if (ctrl.id == 'ctl00_ContentPlaceHolder1_txtOffsite_Address1' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtOffsite_Address2' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtOffsite_City' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtOffsite_zip') {
                                    var rdb = document.getElementById('ctl00_ContentPlaceHolder1_rdoInjuryOccurredOffsite_1');
                                    //used to check dropdowns selected value. if it is equal to Disposed than display Disposal type control else hide.
                                    if (rdb.checked)
                                        bEmpty = true;
                                }
                                else
                                    bEmpty = true;
                            } break;

                        case "select-one":
                            if (ctrl.selectedIndex == 0) {
                                if (ctrl.id == 'ctl00_ContentPlaceHolder1_ddlOffsite_State') {
                                    var rdb = document.getElementById('ctl00_ContentPlaceHolder1_rdoInjuryOccurredOffsite_1');
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

        function ValidateFieldsMedical(sender, args) {
            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnMedicalID.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnMedicalErrorMsgs.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnMedicalID.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {

                        case "textarea":
                        case "text":
                            if (ctrl.value == '') {
                                if (ctrl.id == 'ctl00_ContentPlaceHolder1_txtStatus_Out_Of_Work_date') {
                                    var rdb = document.getElementById('ctl00_ContentPlaceHolder1_rdoStatus_Out_Of_Work');
                                    if (rdb.checked)
                                        bEmpty = true;
                                }
                                else if (ctrl.id == 'ctl00_ContentPlaceHolder1_txtStatus_Return_To_Work_Unrestricted_date') {
                                    var rdb = document.getElementById('ctl00_ContentPlaceHolder1_rdoStatus_Return_To_Work_Unrestricted');
                                    if (rdb.checked)
                                        bEmpty = true;
                                }
                                else if (ctrl.id == 'ctl00_ContentPlaceHolder1_txtStatus_Return_Tp_Work_Restricted_date') {
                                    var rdb = document.getElementById('ctl00_ContentPlaceHolder1_rdoStatus_Return_Tp_Work_Restricted');
                                    if (rdb.checked)
                                        bEmpty = true;
                                }
                                else if (ctrl.id == 'ctl00_ContentPlaceHolder1_txtPhysician_Name' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtPhysician_Address1' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtPhysician_Address2'
                                         || ctrl.id == 'ctl00_ContentPlaceHolder1_txtPhysician_City' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtPhysician_Zip' || ctrl.id == 'ctl00_ContentPlaceHolder1_txtPhysician_Phone') {
                                    var rdb = document.getElementById('ctl00_ContentPlaceHolder1_rdoReferring_Physician_0');
                                    if (rdb.checked)
                                        bEmpty = true;
                                }
                                else
                                    bEmpty = true;
                            } break;
                        case "select-one":
                            if (ctrl.selectedIndex == 0) {
                                if (ctrl.id == 'ctl00_ContentPlaceHolder1_ddlPhysician_State') {
                                    var rdbSecCam = document.getElementById('ctl00_ContentPlaceHolder1_rdoReferring_Physician_0');
                                    if (rdbSecCam.checked)
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

        jQuery(function ($) {
            $("#<%=txtDate_Of_Incident.ClientID%>").mask("99/99/9999");
            $("#<%=txtDate_Reported_To_Sonic.ClientID%>").mask("99/99/9999");
            $("#<%=txtDate_of_Initial_Medical_Treatment.ClientID%>").mask("99/99/9999");
            $("#<%=txtStatus_Out_Of_Work_date.ClientID%>").mask("99/99/9999");
            $("#<%=txtStatus_Return_To_Work_Unrestricted_date.ClientID%>").mask("99/99/9999");
            $("#<%=txtStatus_Return_Tp_Work_Restricted_date.ClientID%>").mask("99/99/9999");
            $("#<%=txtNext_Doctor_Visit.ClientID%>").mask("99/99/9999");
            $("#<%=txtAlternate_Phone_2.ClientID%>").mask("999-999-9999");
            $("#<%=txtContactFaxNumber.ClientID%>").mask("999-999-9999");
            $("#<%=txtSupervisor_Telephone.ClientID%>").mask("999-999-9999");
            $("#<%=txtWitness_1_Phone.ClientID%>").mask("999-999-9999");
            $("#<%=txtWitness_2_Phone.ClientID%>").mask("999-999-9999");
            $("#<%=txtWitness_3_Phone.ClientID%>").mask("999-999-9999");
            $("#<%=txtMedical_Facility_Phone.ClientID%>").mask("999-999-9999");
            $("#<%=txtPhysician_Phone.ClientID%>").mask("999-999-9999");
            $("#<%=txtContactTelephone2.ClientID%>").mask("999-999-9999");
            $("#<%=txtContactTelephone1.ClientID%>").mask("999-999-9999");
            $("#<%=txtContactDetailFaxNumber.ClientID%>").mask("999-999-9999");
            $("#<%=txtContactRLCMTelephone1.ClientID%>").mask("999-999-9999");
            $("#<%=txtContactRLCMTelephone2.ClientID%>").mask("999-999-9999");
            <%--$("#<%=txtFacility_Zip_Code.ClientID%>").mask("99999-9999");--%>
            $("#<%=txtTime_Of_Incident.ClientID%>").mask("99:99");
            $("#<%=txtContactBestTime.ClientID%>").mask("99:99");
            $("#<%=txtTime_Began_Work.ClientID%>").mask("99:99");
        });

        function EnableDisable(elementRef) {
            var inputArray = elementRef.getElementsByTagName('input');
            var labelArray2 = elementRef.getElementsByTagName('Label');
            var rdoCon = document.getElementById('<%=rdoSupervisor_Involved_In_Consultation.ClientID %>');
            for (var i = 0; i < inputArray.length; i++) {
                if (inputArray[i].checked) {
                    if (inputArray[i].value == 'Y') {
                        rdoCon.disabled = false;
                    }
                    else {
                        rdoCon.disabled = true;
                    }
                }
            }
        }
    </script>

    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Location/Contact Panel:" BorderWidth="1"
            BorderColor="DimGray" ValidationGroup="vsLocationGroup" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsAssociateInfo" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Associate Information Panel:" BorderWidth="1"
            BorderColor="DimGray" ValidationGroup="vsAssociateGroup" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsIncidentInfo" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Incident Information Panel:" BorderWidth="1"
            BorderColor="DimGray" ValidationGroup="vsIncidentInfoGroup" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsMedical" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Medical Panel:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsMedicalGroup" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsContacts" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Contacts Panel:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsContactsGroup" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsAttchments" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Attachment:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="AddAttachment" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsComments" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Comments Panel:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsCommentsGroup" CssClass="errormessage"></asp:ValidationSummary>
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
                            <uc:CtlSonicInfo runat="server" ID="SonicInfo" />
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
                                        <asp:Menu ID="mnuWC" runat="server" DataSourceID="dsWCMenu" StaticEnableDefaultPopOutImage="false">
                                            <StaticItemTemplate>
                                                <table cellpadding="5" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="100%">
                                                            <span id="WCMenu<%#Container.ItemIndex+1%>" onclick="javascript:ShowPanel(<%#Container.ItemIndex+1%>);"
                                                                class="LeftMenuStatic">
                                                                <%#Eval("Text")%>&nbsp;
                                                                <asp:Label ID="MenuAsterisk" runat="server" Text="*" Style="color: Red; display: none;"></asp:Label>
                                                            </span>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </StaticItemTemplate>
                                        </asp:Menu>
                                        <asp:SiteMapDataSource ID="dsWCMenu" runat="server" SiteMapProvider="WCMenuProvider"
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
                                    <td width="5px">&nbsp;
                                    </td>
                                    <td width="794px" valign="top" class="dvContainer">
                                        <div id="dvEdit" runat="server" style="width: 100%;">
                                            <asp:Panel ID="pnlLocation" runat="server" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Location Information
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%">Location Number
                                                        </td>
                                                        <td align="center" width="4%">:
                                                        </td>
                                                        <td align="left" width="22%">
                                                            <asp:TextBox runat="server" ID="txtLocationNumberEdit" Width="170px" Enabled="false"> </asp:TextBox>
                                                        </td>
                                                        <td align="left" width="10%">Location d/b/a
                                                        </td>
                                                        <td align="center" width="4%">:
                                                        </td>
                                                        <td align="left" width="30%">
                                                            <asp:TextBox runat="server" ID="txtLocationdbaEdit" Width="170px" Enabled="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Legal Entity
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox runat="server" ID="txtLegalEntityEdit" Width="170px" Enabled="false"></asp:TextBox>
                                                        </td>
                                                        <td align="left">Location f/k/a
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox runat="server" ID="txtLocationfkaEdit" Width="170px" Enabled="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Address 1
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:TextBox ID="txtLocationAddress1" Width="170px" runat="server" MaxLength="50"
                                                                Enabled="false">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Address 2
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:TextBox ID="txtLocationAddress2" Width="170px" runat="server" MaxLength="50"
                                                                Enabled="false">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">City
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:TextBox ID="txtLocationCity" runat="server" Width="170px" Enabled="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">State
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:TextBox runat="server" ID="txtLocationState" Width="170px" Enabled="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Zip Code
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:TextBox ID="txtLocationZipCode" runat="server" Width="170px" MaxLength="10"
                                                                Enabled="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div class="bandHeaderRow">
                                                    Contact Information
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%">Name
                                                        </td>
                                                        <td align="center" width="4%">:
                                                        </td>
                                                        <td align="left" width="22%">
                                                            <asp:TextBox runat="server" ID="txtContactNameEdit" Width="170px" Enabled="false"></asp:TextBox>
                                                        </td>
                                                        <td width="10%">&nbsp;
                                                        </td>
                                                        <td width="4%">&nbsp;
                                                        </td>
                                                        <td width="30%">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Title
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:TextBox runat="server" ID="txtContactTitle" Width="170px" Enabled="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Telephone Number 1<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:TextBox runat="server" ID="txtContactTelephoneNumber1" Width="170px" Enabled="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Telephone Number 2<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:TextBox runat="server" ID="txtContactTelephoneNumber2" Width="170px" Enabled="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Fax Number&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span><br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:TextBox ID="txtContactFaxNumber" Width="170px" runat="server" MaxLength="50">
                                                            </asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="revContactFaxNumber" ControlToValidate="txtContactFaxNumber"
                                                                runat="server" ValidationGroup="vsLocationGroup" ErrorMessage="Please Enter Fax Number in xxx-xxx-xxxx format."
                                                                Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Email Address
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:TextBox ID="txtContactEmailAddress" runat="server" Width="170px" MaxLength="30"
                                                                Enabled="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="center">
                                                            <asp:Button runat="server" ID="btnLocationSave" Text="Save & Continue" OnClick="btnLocationSave_Click"
                                                                ValidationGroup="vsLocationGroup" OnClientClick="return CheckValidationLocationInfo();"
                                                                ToolTip="Save & Continue" />
                                                            <asp:Button runat="server" ID="btnLocationAudit" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();"
                                                                ToolTip="View Audit Trail" CausesValidation="false" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <%--</ContentTemplate>
                            </asp:UpdatePanel>--%>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlAssociate" runat="server" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Associate Information
                                                </div>
                                                <asp:HiddenField runat="server" ID="hdnAssociate" />
                                                <asp:Button runat="server" ID="btnHdnTest" OnClick="btnHdnTest_Click" Style="display: none;" />
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%">Name&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">:
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:DropDownList runat="server" ID="ddlAssociateName" SkinID="ddlSONIC" onChange="Test();">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left" width="18%">Date of Birth
                                                        </td>
                                                        <td align="center" width="4%">:
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:TextBox ID="txtDate_Of_Birth" runat="server" Width="170px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Gender
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox runat="server" ID="txtGender" Width="170px"></asp:TextBox>
                                                        </td>
                                                        <td align="left">Age
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox runat="server" ID="txtCountdate_of_birth" Width="170px" Enabled="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Address 1&nbsp;
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox runat="server" ID="txtAddress_1" Width="170px"></asp:TextBox>
                                                        </td>
                                                        <td align="left">Social Security Number
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox runat="server" ID="txtSocial_Security_Number" Width="170px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Address 2
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtAddress_2" Width="170px" runat="server">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td align="left">Date of Hire
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtDate_of_Hire" runat="server" Width="170px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">City
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtCity" runat="server" Width="170px"></asp:TextBox>
                                                        </td>
                                                        <td align="left">Job Title
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtJob_Title" runat="server" Width="170px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">State
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox runat="server" ID="txtStateEdit" Width="170px" Enabled="false"></asp:TextBox>
                                                        </td>
                                                        <td align="left">Job Classification
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtDescription" runat="server" Width="170px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Zip Code
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtZip_code" runat="server" Width="170px"></asp:TextBox>
                                                        </td>
                                                        <td align="left">Job Description
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtOccupation_description" runat="server" Width="170px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Home Telephone<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtHome_Phone" runat="server" Width="170px"></asp:TextBox>
                                                        </td>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                        <td align="center">&nbsp;
                                                        </td>
                                                        <td align="left">
                                                            <%--<asp:DropDownList  runat="server" id="ddlDepartment" SkinID="ddlSONIC"></asp:DropDownList>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Alternate Phone 1
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtCell_phone" runat="server" Width="170px"></asp:TextBox>
                                                        </td>
                                                        <td align="left">Salary
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtSalary" runat="server" Width="170px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Alternate Phone 2&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtAlternate_Phone_2" runat="server" Width="170px"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="revAlternate_Phone_2" ControlToValidate="txtAlternate_Phone_2"
                                                                runat="server" ValidationGroup="vsAssociateGroup" ErrorMessage="Please Enter Alternate Phone Number in xxx-xxx-xxxx format."
                                                                Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left">Salary Frequency
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtSalary_Frequency" runat="server" Width="170px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">State of Hire&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="ddlState_of_hire" runat="server" Width="170px" SkinID="ddlSONIC">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left">Hours worked Per week&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtEmployee_hrs_per_week" runat="server" Width="170px" MaxLength="2"
                                                                onKeyPress="return FormatInteger(event);"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="revEmployee_hrs_per_week" runat="server" ControlToValidate="txtEmployee_hrs_per_week"
                                                                Display="none" SetFocusOnError="true" ErrorMessage="Employee Hours per week must be numeric"
                                                                ValidationExpression="^\d+$" ValidationGroup="vsAssociateGroup"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                        <td align="center">&nbsp;
                                                        </td>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                        <td align="left">Days worked Per week&nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtEmployee_Days_per_week" runat="server" Width="170px" MaxLength="2"
                                                                onKeyPress="return FormatInteger(event);"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="REVEmployee_Days_per_week" runat="server" ControlToValidate="txtEmployee_Days_per_week"
                                                                Display="none" SetFocusOnError="true" ErrorMessage="Employee Days per week must be numeric"
                                                                ValidationExpression="^\d+$" ValidationGroup="vsAssociateGroup"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Supervisor Name
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtSupervisor_Name" runat="server" Width="170px"></asp:TextBox>
                                                        </td>
                                                        <td align="left">Time Shift Begins&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtEmployee_Time_Shift_Begins" runat="server" Width="170px" MaxLength="40"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Supervisor Telephone&nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                                                            <br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtSupervisor_Telephone" runat="server" Width="170px"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="revSupervisor_Telephone" ControlToValidate="txtSupervisor_Telephone"
                                                                runat="server" ValidationGroup="vsAssociateGroup" ErrorMessage="Please Enter Supervisor Telephone in xxx-xxx-xxxx format."
                                                                Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left">Time Shift Ends&nbsp;<span id="Span8" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtEmployee_Time_Shift_Ends" runat="server" Width="170px" MaxLength="40"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Involved in Motor Vehicle Accident?
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:RadioButtonList runat="server" ID="rdoMotor_Vehicle_Accident" SkinID="YesNoType">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Driver's License State
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox runat="server" ID="txtDriver_License_stateEdit" Width="170px" Enabled="false"></asp:TextBox>
                                                        </td>
                                                        <td align="left">Driver's License Number
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtDriver_License_Number" runat="server" Width="170px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Employment Status
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox runat="server" ID="txtActive_Inactive_Leave" Width="170px"></asp:TextBox>
                                                        </td>
                                                        <td align="left">Email Address
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtemail" runat="server" Width="170px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Marital Status
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox runat="server" ID="txtMarital_StatusEdit" Width="170px" Enabled="false"></asp:TextBox>
                                                        </td>
                                                        <td align="left">Associate ID Number
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtSonic_Employee_ID" runat="server" Width="170px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Number of Departments
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:TextBox ID="txtNumber_of_Dependents" runat="server" Width="170px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="center">
                                                            <asp:Button runat="server" ID="btnAssociateSave" Text="Save & Continue" OnClick="btnAssociateSave_Click"
                                                                ValidationGroup="vsAssociateGroup" OnClientClick="return CheckAssociateValues();"
                                                                ToolTip="Save & Continue" />
                                                            <asp:Button runat="server" ID="btnAssociateAudit" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();"
                                                                ToolTip="View Audit Trail" CausesValidation="false" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <%--</ContentTemplate>
                            </asp:UpdatePanel>--%>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlIncident" runat="server" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Incident Information
                                                </div>
                                                <asp:HiddenField runat="server" ID="hdnIncident" />
                                                <asp:HiddenField runat="Server" ID="hdnOnsiteOffsite" Value="0" />
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" style="width: 18%">Date of Incident&nbsp;<span id="Span10" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" style="width: 4%">:
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:TextBox ID="txtDate_Of_Incident" runat="server"></asp:TextBox>
                                                            <asp:TextBox ID="txtCurrentDate" runat="server" Style="display: none"></asp:TextBox>
                                                            <img alt="Date of Incident" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Of_Incident', 'mm/dd/y',CompareDateLessThanToday,'ctl00_ContentPlaceHolder1_txtDate_Of_Incident');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" /><br />
                                                            <asp:CustomValidator ID="cvDate_Of_Incident" runat="server" ControlToValidate="txtDate_Of_Incident"
                                                                ValidationGroup="vsIncidentInfoGroup" ClientValidationFunction="CheckDate" ErrorMessage="Date of Incident is not valid."
                                                                Display="None">
                                                            </asp:CustomValidator>
                                                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtDate_Of_Incident"
                                                                ValidationGroup="vsIncidentInfoGroup" ErrorMessage="Date of Incident Should Not Be Future Date."
                                                                Type="Date" Operator="LessThanEqual" ControlToCompare="txtCurrentDate" Display="none">
                                                            </asp:CompareValidator>
                                                        </td>
                                                        <td align="left" style="width: 18%">Time of Incident(HH:MM)&nbsp;<span id="Span11" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" style="width: 4%">:
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:TextBox ID="txtTime_Of_Incident" runat="server" Width="170px"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="revtxtTime_Of_Incident" runat="server" ControlToValidate="txtTime_Of_Incident"
                                                                ValidationExpression="^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$"
                                                                ErrorMessage="Invalid Time of Incident." Display="none" ValidationGroup="vsIncidentInfoGroup"
                                                                SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Filing State&nbsp;<span id="Span12" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList runat="server" ID="ddlFiling_State" SkinID="ddlSONIC">
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
                                                        <td align="left">Injury Occurred
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:RadioButtonList runat="server" ID="rdoInjuryOccurredOffsite" onClick="CheckInjuryOccured();">
                                                                <asp:ListItem Value="N">Onsite</asp:ListItem>
                                                                <asp:ListItem Value="Y">Offsite</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr id="trIncidentInjuryOccured" runat="server" style="display: none">
                                                        <td align="left">&nbsp;
                                                        </td>
                                                        <td align="center">&nbsp;
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td style="width: 18%">Address 1&nbsp;<span id="Span40" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td style="width: 4%">:
                                                                    </td>
                                                                    <td style="width: 28%">
                                                                        <asp:TextBox runat="server" ID="txtOffsite_Address1" Width="170px" MaxLength="50"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Address 2&nbsp;<span id="Span41" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td>:
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox runat="server" ID="txtOffsite_Address2" Width="170px" MaxLength="50"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>City&nbsp;<span id="Span42" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td>:
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox runat="server" ID="txtOffsite_City" Width="170px" MaxLength="50"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>State&nbsp;<span id="Span43" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td>:
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList runat="server" ID="ddlOffsite_State" SkinID="ddlSONIC" MaxLength="50">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Zip code&nbsp;<span id="Span44" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td>:
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox runat="server" ID="txtOffsite_zip" Width="170px" MaxLength="50"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Description of Incident&nbsp;<span id="Span13" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="txtDescription_Of_Incident" runat="server" MaxLength="4000"
                                                                ValidationGroup="vsIncidentInfoGroup" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Associate Injured in Regular Job
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:RadioButtonList runat="server" ID="rdoAssociate_Injured_Regular_Job" SkinID="YesNoUnknownType">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Nature of Injury&nbsp;<span id="Span14" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList runat="server" ID="ddlFK_Nature_Of_Injury" SkinID="ddlSONIC">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left">Department Where Injury Occurred&nbsp;<span id="Span15" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">&nbsp;
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList runat="server" ID="ddlFK_Department_Where_Occurred" SkinID="ddlSONIC">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Body Part Affected&nbsp;<span id="Span16" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:DropDownList runat="server" ID="ddlFK_Body_Parts_Affected" SkinID="ddlSONIC">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Were Safeguards or Safety Equipment Provided?
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:RadioButtonList runat="server" ID="rdoSafeguards_Provided" SkinID="YesNoUnknownType">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left">Were Safeguards or Safety Equipment Used?
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:RadioButtonList ID="rdoSafeguards_Used" runat="server" SkinID="YesNoUnknownType">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Was Machine Part Involved?
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:RadioButtonList runat="server" ID="rdoMachine_Part_Involved" SkinID="YesNoUnknownType">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left">Was Machine Part Defective?
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:RadioButtonList ID="rdoMachine_Part_Defective" runat="server" SkinID="YesNoUnknownType">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Was the claim Questionable?&nbsp;<span id="Span26" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:RadioButtonList runat="server" ID="rdoClaim_Questionable" SkinID="YesNoTypeNullSelection">
                                                            </asp:RadioButtonList>

                                                        </td>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                        <td align="center">&nbsp;
                                                        </td>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">If Yes, Why?&nbsp;<span id="Span17" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="txtClaim_Questionable_Description" runat="server" MaxLength="4000" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Date Reported to Sonic&nbsp;<span id="Span18" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtDate_Reported_To_Sonic" runat="server"></asp:TextBox>
                                                            <img alt="Date Reported to SONIC" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Reported_To_Sonic', 'mm/dd/y',CompareDateLessThanToday,'ctl00_ContentPlaceHolder1_txtDate_Reported_To_Sonic');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" /><br />
                                                            <asp:CustomValidator ID="cvDate_Reported_To_Sonic" runat="server" ControlToValidate="txtDate_Reported_To_Sonic"
                                                                ValidationGroup="vsIncidentInfoGroup" ClientValidationFunction="CheckDate" ErrorMessage="Reported Date to Sonic is not valid."
                                                                Display="None">
                                                            </asp:CustomValidator>
                                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtDate_Reported_To_Sonic"
                                                                ValidationGroup="vsIncidentInfoGroup" ErrorMessage="Reported Date to Sonic Should Not Be Future Date."
                                                                Type="Date" Operator="LessThanEqual" ControlToCompare="txtCurrentDate" Display="none">
                                                            </asp:CompareValidator>
                                                        </td>
                                                        <td align="left">To Whom at Sonic was Incident Reported to?&nbsp;<span id="Span19" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox runat="server" ID="txtperson_reported_to" Width="170px" MaxLength="50"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Witnesses?
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:RadioButtonList runat="server" ID="rdoWitnesses" SkinID="YesNoTypeNullSelection">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Witness 1&nbsp;<span id="Span20" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox runat="server" ID="txtWitness_1" Width="170px" MaxLength="50"></asp:TextBox>
                                                        </td>
                                                        <td align="left">Witness 1 Telephone&nbsp;<span id="Span23" style="color: Red; display: none;" runat="server">*</span><br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox runat="server" ID="txtWitness_1_Phone" Width="170px" MaxLength="50"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="revWitness_1_Phone" ControlToValidate="txtWitness_1_Phone"
                                                                runat="server" ValidationGroup="vsIncidentInfoGroup" ErrorMessage="Please Enter Witness phone 1 in xxx-xxx-xxxx format."
                                                                Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Witness 2&nbsp;<span id="Span21" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox runat="server" ID="txtWitness_2" Width="170px" MaxLength="50"></asp:TextBox>
                                                        </td>
                                                        <td align="left">Witness 2 Telephone&nbsp;<span id="Span24" style="color: Red; display: none;" runat="server">*</span><br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox runat="server" ID="txtWitness_2_Phone" Width="170px" MaxLength="50"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="revWitness_2_Phone" ControlToValidate="txtWitness_2_Phone"
                                                                runat="server" ValidationGroup="vsIncidentInfoGroup" ErrorMessage="Please Enter Witness phone 2 in xxx-xxx-xxxx format."
                                                                Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Witness 3&nbsp;<span id="Span22" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox runat="server" ID="txtWitness_3" Width="170px" MaxLength="50"></asp:TextBox>
                                                        </td>
                                                        <td align="left">Witness 3 Telephone&nbsp;<span id="Span25" style="color: Red; display: none;" runat="server">*</span><br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox runat="server" ID="txtWitness_3_Phone" Width="170px" MaxLength="50"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="revWitness_3_Phone" ControlToValidate="txtWitness_3_Phone"
                                                                runat="server" ValidationGroup="vsIncidentInfoGroup" ErrorMessage="Please Enter Witness phone 3 in xxx-xxx-xxxx format."
                                                                Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                        <td align="center">&nbsp;
                                                        </td>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                        <td align="left">Fatality
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:RadioButtonList runat="server" ID="rdoFatality" SkinID="YesNoTypeNullSelection">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <div class="bandHeaderRow">
                                                                OSHA Fields
                                                            </div>
                                                        </td>
                                                    </tr>
                                                  <%--  <tr>
                                                        <td align="left">Name of Physician or Other Health Care Professional
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox runat="server" ID="txtPhysician_Other_Professional" Width="170px" MaxLength="75"></asp:TextBox>
                                                        </td>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                        <td align="center">&nbsp;
                                                        </td>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">If Treatment is Given Away from the Worksite, Facility Where it Was Given
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox runat="server" ID="txtFacility" Width="170px" MaxLength="75"></asp:TextBox>
                                                        </td>
                                                        <td align="left">Treatment Facility Address
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtFacility_Address" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Treatment Facility City
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox runat="server" ID="txtFacility_City" Width="170px" MaxLength="50"></asp:TextBox>
                                                        </td>
                                                        <td align="left">Treatment Facility State
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="ddlFK_State_Facility" runat="server" SkinID="ddlSONIC"></asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Treatment Facility Zip Code (XXXXX-XXXX)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox runat="server" ID="txtFacility_Zip_Code" Width="170px" MaxLength="10"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtFacility_Zip_Code"
                                                                runat="server" ValidationGroup="vsIncidentInfoGroup" ErrorMessage="Please Enter txtFacility_Zip_Code in XXXXX-XXXX format."
                                                                Display="none" ValidationExpression="((\(\d{2}\) ?)|(\d{5}-))?\d{4}$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                        <td align="center">&nbsp;
                                                        </td>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="left">Was Associate Treated in an Emergency Room?
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:RadioButtonList ID="rblEmergency_Room" runat="server" SkinID="YesNoType">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left">Time Associate Began Work (HH:MM)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtTime_Began_Work" runat="server" Width="170px"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtTime_Began_Work"
                                                                ValidationExpression="^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$"
                                                                ErrorMessage="Invalid Time Associate Began Work." Display="none" ValidationGroup="vsIncidentInfoGroup"
                                                                SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">What was the associate doing just before the incident occurred?
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="txtActivity_Before_Incident" runat="server" MaxLength="1000"
                                                                ValidationGroup="vsIncidentInfoGroup" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Describe any object or substance that directly harmed the associate
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="txtObject_Substance_Involved" runat="server" MaxLength="1000"
                                                                ValidationGroup="vsIncidentInfoGroup" />
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td colspan="6" align="center">
                                                            <asp:Button runat="server" ID="btnIncidentSave" Text="Save & Continue" ToolTip="Save & Continue"
                                                                OnClick="btnIncidentSave_Click" ValidationGroup="vsIncidentInfoGroup" OnClientClick="return CheckValidationIncidentInfo();" />
                                                            <asp:Button runat="server" ID="btnIncidentAudit" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();"
                                                                ToolTip="View Audit Trail" CausesValidation="false" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <%--</ContentTemplate>
                                
                            </asp:UpdatePanel>--%>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlMedical" runat="server" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Medical
                                                </div>
                                                <asp:HiddenField runat="server" ID="hdnMedicalPhysician" Value="0" />
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" valign="top">Was Telephone Nurse Consultation Used? <span style="color: Red">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList ID="rdoTelephone_Nurse_Consultation" runat="server" SkinID="YesNoType"
                                                                AutoPostBack="true" OnSelectedIndexChanged="rdoTelephone_Nurse_Consultation_SelectedIndexChanged">
                                                            </asp:RadioButtonList>
                                                            <%--<asp:RequiredFieldValidator ID="reqtel" runat="server" ValidationGroup="vsMedicalGroup"
                                                                ControlToValidate="rdoTelephone_Nurse_Consultation" ErrorMessage="[Medical]/Please select Was Telephone Nurse Consultation Used?"
                                                                InitialValue="" Display="None" SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                                                        </td>
                                                        <td align="left" valign="top">Was the Associate’s Direct Supervisor Involved in the Telephone Nurse Consultation Phone Call? <span style="color: Red">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList ID="rdoSupervisor_Involved_In_Consultation" runat="server" SkinID="YesNoType">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%" valign="top">Describe Initial Treatment&nbsp;<span id="Span27" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" style="width: 4%" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="txtInitial_Medical_Treatment" runat="server" MaxLength="4000" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Date of Initial Treatment&nbsp;<span id="Span28" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:TextBox ID="txtDate_of_Initial_Medical_Treatment" runat="server"></asp:TextBox>
                                                            <img alt="Date of Initial Medical Treatment" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_of_Initial_Medical_Treatment', 'mm/dd/y',CompareDateLessThanToday,'ctl00_ContentPlaceHolder1_txtDate_of_Initial_Medical_Treatment');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" /><br />
                                                            <asp:CustomValidator ID="cvDate_of_Initial_Medical_Treatment" runat="server" ControlToValidate="txtDate_of_Initial_Medical_Treatment"
                                                                ValidationGroup="vsMedicalGroup" ClientValidationFunction="CheckDate" ErrorMessage="Initial Date of Treatment is not valid."
                                                                Display="None">
                                                            </asp:CustomValidator>
                                                            <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txtDate_of_Initial_Medical_Treatment"
                                                                ValidationGroup="vsMedicalGroup" ErrorMessage="Initial Date of Treatment Should Not Be Future Date."
                                                                Type="Date" Operator="LessThanEqual" ControlToCompare="txtCurrentDate" Display="none">
                                                            </asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Taken by Emergency Transportation?
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:RadioButtonList runat="server" ID="rdoTaken_By_Emergency_Transportation" SkinID="YesNoTypeNullSelection">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">Medical Facility Name&nbsp;<span id="Span29" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" style="width: 4%">:
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:TextBox runat="server" ID="txtMedical_Facility_Name" Width="170px" MaxLength="40"></asp:TextBox>
                                                        </td>
                                                        <td align="left" style="width: 18%">Treating Physician's Name&nbsp;<span id="Span30" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" style="width: 4%">:
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:TextBox runat="server" ID="txtTreating_Physician_Name" Width="170px" MaxLength="40"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Medical Facility Address 1&nbsp;<span id="Span31" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox runat="server" ID="txtMedical_Facility_Address1" Width="170px" MaxLength="50"></asp:TextBox>
                                                        </td>
                                                        <td align="left">Admitted to Hospital
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:RadioButtonList runat="server" ID="rdoAdmitted_to_Hospital" SkinID="YesNoUnknownType">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Medical Facility Address 2&nbsp;<span id="Span32" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox runat="server" ID="txtMedical_Facility_Address2" Width="170px" MaxLength="50"></asp:TextBox>
                                                        </td>
                                                        <td align="left">Still in Hospital
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:RadioButtonList runat="server" ID="rdoStill_In_Hospital" SkinID="YesNoUnknownType">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Medical Facility City&nbsp;<span id="Span33" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:TextBox runat="server" ID="txtMedical_Facility_City" Width="170px" MaxLength="50"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Medical Facility State&nbsp;<span id="Span34" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:DropDownList runat="server" ID="ddlMedical_Facility_State" SkinID="ddlSONIC">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Medical Facility Zip Code&nbsp;<span id="Span35" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:TextBox runat="server" ID="txtMedical_Facility_Zip" Width="170px" MaxLength="10"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="reMedical_Facility_Zip" ControlToValidate="txtMedical_Facility_Zip"
                                                                runat="server" ValidationGroup="vsMedicalGroup" ErrorMessage="Please Enter Medical Facility Zip Code in XXXXX-XXXX format."
                                                                Display="none" ValidationExpression="((\(\d{2}\) ?)|(\d{5}-))?\d{4}$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Medical Facility Telephone&nbsp;<span id="Span36" style="color: Red; display: none;" runat="server">*</span><br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:TextBox runat="server" ID="txtMedical_Facility_Phone" Width="170px" MaxLength="50"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="revMedical_Facility_Phone" ControlToValidate="txtMedical_Facility_Phone"
                                                                runat="server" ValidationGroup="vsMedicalGroup" ErrorMessage="Please Enter Medical Facility Number in xxx-xxx-xxxx format."
                                                                Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Work Status
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:RadioButton runat="server" ID="rdoStatus_Out_Of_Work" Text="Out of Work" GroupName="WorkStatus"
                                                                onClick="checkWorkStatus();" />
                                                        </td>
                                                        <td align="left">As Of&nbsp;<span id="Span45" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtStatus_Out_Of_Work_date" runat="server"></asp:TextBox>
                                                            <img alt="Date of Out of Work" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtStatus_Out_Of_Work_date', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" id="imgStatus_Out_Of_Work" style="display: none" /><br />
                                                            <asp:CustomValidator ID="cvStatus_Out_Of_Work_date" runat="server" ControlToValidate="txtStatus_Out_Of_Work_date"
                                                                ValidationGroup="vsMedicalGroup" ClientValidationFunction="CheckDate" ErrorMessage="Date of Out of work is not valid."
                                                                Display="None">
                                                            </asp:CustomValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:RadioButton runat="server" ID="rdoStatus_Return_To_Work_Unrestricted" Text="Returned to Regular Job with no Restrictions"
                                                                GroupName="WorkStatus" onClick="checkWorkStatus();" />
                                                        </td>
                                                        <td align="left">As Of&nbsp;<span id="Span46" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtStatus_Return_To_Work_Unrestricted_date" runat="server"></asp:TextBox>
                                                            <img alt="Date of unrestricted return" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtStatus_Return_To_Work_Unrestricted_date', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" id="imgStatus_Return_To_Work_Unrestricted" style="display: none" /><br />
                                                            <asp:CustomValidator ID="cvStatus_Return_To_Work_Unrestricted_date" runat="server"
                                                                ControlToValidate="txtStatus_Return_To_Work_Unrestricted_date" ValidationGroup="vsMedicalGroup"
                                                                ClientValidationFunction="CheckDate" ErrorMessage="Date of Returned to Regular Job with no Restrictions is not valid."
                                                                Display="None">
                                                            </asp:CustomValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:RadioButton runat="server" ID="rdoStatus_Return_Tp_Work_Restricted" Text="Returned to Work with Restrictions"
                                                                GroupName="WorkStatus" onClick="checkWorkStatus();" />
                                                        </td>
                                                        <td align="left">As Of&nbsp;<span id="Span47" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtStatus_Return_Tp_Work_Restricted_date" runat="server"></asp:TextBox>
                                                            <img alt="restricted date of Return to work" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtStatus_Return_Tp_Work_Restricted_date', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" id="imgStatus_Return_Tp_Work_Restricted" style="display: none;" /><br />
                                                            <asp:CustomValidator ID="cvStatus_Return_Tp_Work_Restricted_date" runat="server"
                                                                ControlToValidate="txtStatus_Return_Tp_Work_Restricted_date" ValidationGroup="vsMedicalGroup"
                                                                ClientValidationFunction="CheckDate" ErrorMessage="Date of Returned to Work with Restrictions is not valid."
                                                                Display="None">
                                                            </asp:CustomValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:RadioButton runat="server" ID="rdoStatus_Unknown" Text="Unknown" GroupName="WorkStatus"
                                                                onClick="checkWorkStatus();" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Next Doctor’s Office Visit&nbsp;<span id="Span37" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:TextBox ID="txtNext_Doctor_Visit" runat="server" SkinID="txtDateGreaterThanToday"></asp:TextBox>
                                                            <img alt="Next Doctor vist Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtNext_Doctor_Visit', 'mm/dd/y',CompareDateGreaterThanToday,'ctl00_ContentPlaceHolder1_txtNext_Doctor_Visit');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" /><br />
                                                            <asp:CustomValidator ID="cvNext_Doctor_Visit" runat="server" ControlToValidate="txtNext_Doctor_Visit"
                                                                ValidationGroup="vsMedicalGroup" ClientValidationFunction="CheckDate" ErrorMessage="Next Doctor's visit date is not valid."
                                                                Display="None">
                                                            </asp:CustomValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Referring Physician?
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList runat="server" ID="rdoReferring_Physician" SkinID="YesNoType"
                                                                onClick="CheckReferringPhysician();">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left" colspan="4" runat="server" id="tdReferringPhysican" style="display: none;">
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" style="width: 18%">Physician’s Name&nbsp;<span id="Span48" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" style="width: 4%">:
                                                                    </td>
                                                                    <td align="left" style="width: 28%">
                                                                        <asp:TextBox runat="server" ID="txtPhysician_Name" Width="170px" MaxLength="40"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">Physician’s Address 1&nbsp;<span id="Span49" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox runat="server" ID="txtPhysician_Address1" Width="170px" MaxLength="50"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">Physician’s Address 2&nbsp;<span id="Span50" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox runat="server" ID="txtPhysician_Address2" Width="170px" MaxLength="50"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">Physician’s City&nbsp;<span id="Span51" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox runat="server" ID="txtPhysician_City" Width="170px" MaxLength="50"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">Physician’s State&nbsp;<span id="Span52" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:DropDownList runat="server" ID="ddlPhysician_State" SkinID="ddlSONIC">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">Physician’s Zip Code&nbsp;<span id="Span53" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox runat="server" ID="txtPhysician_Zip" Width="170px" MaxLength="10"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">Physician’s Telephone&nbsp;<span id="Span54" style="color: Red; display: none;" runat="server">*</span><br />
                                                                        (xxx-xxx-xxxx)
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox runat="server" ID="txtPhysician_Phone" Width="170px" MaxLength="13"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="revPhysician_Phone" ControlToValidate="txtPhysician_Phone"
                                                                            runat="server" ValidationGroup="vsMedicalGroup" ErrorMessage="Please Enter Physician Number in xxx-xxx-xxxx format."
                                                                            Display="none" Enabled="false" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="center">
                                                            <asp:Button runat="server" ID="btnMedicalSave" Text="Save & Continue" ToolTip="Save & Continue"
                                                                OnClick="btnMedicalSave_Click" ValidationGroup="vsMedicalGroup" OnClientClick="return CheckValidationMedicalInfo();" />
                                                            <asp:Button runat="server" ID="btnMedicalAudit" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();"
                                                                ToolTip="View Audit Trail" CausesValidation="false" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <%--</ContentTemplate>
                            </asp:UpdatePanel>--%>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlContacts" runat="server" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Contacts
                                                </div>
                                                <%--<asp:UpdatePanel runat="server" ID="updContact">
                            <ContentTemplate>--%>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" style="width: 18%" valign="top">Dealership/Collision Center
                                                        </td>
                                                        <td align="center" style="width: 4%" valign="top">:
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:TextBox ID="txtdba" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                                                        </td>
                                                        <td align="left" style="width: 18%">&nbsp;
                                                        </td>
                                                        <td align="center" style="width: 4%">&nbsp;
                                                        </td>
                                                        <td align="left" style="width: 28%">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Contact Name
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtContactDetailContactName" runat="server" Width="170px"></asp:TextBox>
                                                        </td>
                                                        <td align="left">Address 1
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtContactDetailAddress_1" runat="server" Width="170px" ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">When to Contact
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtContactBestTime" runat="server" Width="170px"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="revtxtContactBestTime" runat="server" ControlToValidate="txtContactBestTime"
                                                                ValidationExpression="^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$"
                                                                ErrorMessage="Invalid When to Contact Time." Display="none" ValidationGroup="vsContactsGroup"
                                                                SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left">Address 2
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtContactAddress2" runat="server" Width="170px" ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Telephone Number 1<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtContactTelephone1" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="revContactTelephone1" ControlToValidate="txtContactTelephone1"
                                                                runat="server" ValidationGroup="vsContactsGroup" ErrorMessage="Please Enter the Phone Number 1 in xxx-xxx-xxxx format."
                                                                Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left">City
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtContactDetailCity" runat="server" Width="170px" ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Telephone Number 2<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtContactTelephone2" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="revContactTelephone2" ControlToValidate="txtContactTelephone2"
                                                                runat="server" ValidationGroup="vsContactsGroup" ErrorMessage="Please Enter Telephone Number 2 in xxx-xxx-xxxx format."
                                                                Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left">State
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtContactDetailState" runat="server" Width="170px" ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Fax Number<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtContactDetailFaxNumber" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="revContactDetailFaxNumber" ControlToValidate="txtContactDetailFaxNumber"
                                                                runat="server" ValidationGroup="vsContactsGroup" ErrorMessage="Please Enter the Fax Number in xxx-xxx-xxxx format."
                                                                Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left">Zip
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtContactDetailZipCode" runat="server" Width="170px" ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Email Address
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtContactDetailEmailAddress" runat="server" Width="170px" MaxLength="60"></asp:TextBox>
                                                            <asp:RegularExpressionValidator runat="Server" ID="revContactDetailEmailAddress"
                                                                ControlToValidate="txtContactDetailEmailAddress" Display="None" ErrorMessage="Please Enter Valid Email ID"
                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="vsContactsGroup"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                        <td align="center">&nbsp;
                                                        </td>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Regional Loss Control Manager
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtContactRegionalManager" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                                                        </td>
                                                        <td align="left">RLCM Telephone Number 1<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtContactRLCMTelephone1" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="revContactRLCMTelephone1" ControlToValidate="txtContactRLCMTelephone1"
                                                                runat="server" ValidationGroup="vsContactsGroup" ErrorMessage="Please Enter RLCM phone 1 in xxx-xxx-xxxx format."
                                                                Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">RLCM Email Address
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtContactRLCMEmailAddress" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                                                            <asp:RegularExpressionValidator runat="Server" ID="revRLCMEmail" ControlToValidate="txtContactRLCMEmailAddress"
                                                                Display="None" ValidationGroup="vsContactsGroup" ErrorMessage="Please Enter Valid RLCM Email ID"
                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left">RLCM Telephone Number 2<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtContactRLCMTelephone2" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="revContactRLCMTelephone2" ControlToValidate="txtContactRLCMTelephone2"
                                                                runat="server" ValidationGroup="vsContactsGroup" ErrorMessage="Please Enter RLCM Phone Number 2 in xxx-xxx-xxxx format."
                                                                Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="center">
                                                            <asp:Button runat="server" ID="btnContactsSave" Text="Save & Continue" ToolTip="Save & Continue"
                                                                OnClick="btnContactsSave_Click" ValidationGroup="vsContactsGroup" OnClientClick="return CheckValidationContactsInfo();" />
                                                            <asp:Button runat="server" ID="btnContactAudit" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();"
                                                                ToolTip="View Audit Trail" CausesValidation="false" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <%--</ContentTemplate>
                            </asp:UpdatePanel>--%>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlComments" runat="server" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Comments
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" valign="top">Initial Claim Classification&nbsp;<span id="Span38" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:</td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <asp:ListBox SelectionMode="Multiple" runat="server" ID="lstInitialClaim"></asp:ListBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%" valign="top">Comments/Special Instructor to Adjuster&nbsp;<span id="Span39" style="color: Red; display: none;" runat="server">*</span>
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
                                                            <asp:Button runat="server" ID="btnSubmit" Text="Submit Report" ToolTip="Submit Report"
                                                                OnClick="btnSubmit_Click" OnClientClick="return CheckAllValidation();" />
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
                                                    Location Information
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" style="width: 18%;">Date Reported to SRS
                                                        </td>
                                                        <td align="center" style="width: 4%;">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label runat="server" ID="lblDate_Reported_to_SRS"></asp:Label>
                                                        </td>
                                                    </tr>
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
                                                    Contact Information
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%">Name
                                                        </td>
                                                        <td align="center" width="4%">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label runat="server" ID="lblContactName"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Title
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label runat="server" ID="lblContactTitle"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Telephone Number 1<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label runat="server" ID="lblContactTelephoneNumber1"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Telephone Number 2<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label runat="server" ID="lblContactTelephoneNumber2"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Fax Number<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label ID="lblContactFaxNumber" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Email Address
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label ID="lblContactEmailAddress" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlViewAssociate" runat="server" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Associate Information
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%">Name
                                                        </td>
                                                        <td align="center" width="4%">:
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label runat="server" ID="lblAssociateName"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%">Date of Birth
                                                        </td>
                                                        <td align="center" width="4%">:
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label runat="server" ID="lblDate_Of_Birth"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Gender
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label runat="server" ID="lblGender"></asp:Label>
                                                        </td>
                                                        <td align="left">Age
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblCountdate_of_birth"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Address 1
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblAddress_1"></asp:Label>
                                                        </td>
                                                        <td align="left">Social Security Number
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblSocial_Security_Number"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Address 2
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblAddress_2" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                        <td align="left">Date of Hire
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblDate_of_Hire" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">City
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblCity" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">Job Title
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblJob_Title" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">State
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblState"></asp:Label>
                                                        </td>
                                                        <td align="left">Job Classification
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblDescription" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Zip Code
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblZip_code" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">Job Description
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblOccupation_description" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Home Telephone<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblHome_Phone" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                        <td align="center">&nbsp;
                                                        </td>
                                                        <td align="left">
                                                            <%--<asp:Label runat="server" id="lblDepartment"></asp:Label>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Alternate Phone 1
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblCell_phone" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">Salary
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblSalary" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Alternate Phone 2
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblAlternate_Phone_2" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">Salary Frequency
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblSalary_Frequency" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">State of Hire
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblState_of_hire" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">Hours Worked Per Week
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblEmployee_hrs_per_week" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                        <td align="center">&nbsp;
                                                        </td>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                        <td align="left">Days Worked Per Week
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblEmployee_Days_per_week" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Supervisor Name
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblSupervisor_Name" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">Time Shift Begins
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblEmployee_Time_Shift_Begins" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Supervisor Telephone
                                                            <br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblSupervisor_Telephone" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">Time Shift Ends
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblEmployee_Time_Shift_Ends" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Involved in Motor Vehicle Accident?
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label runat="server" ID="lblMotor_Vehicle_Accident"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Driver's License State
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblDriver_License_state"></asp:Label>
                                                        </td>
                                                        <td align="left">Driver's License Number
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblDriver_License_Number" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Employment Status
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblActive_Inactive_Leave"></asp:Label>
                                                        </td>
                                                        <td align="left">Email Address
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblemail" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Marital Status
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblMarital_Status"></asp:Label>
                                                        </td>
                                                        <td align="left">Associate ID Number
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblSonic_Employee_ID" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Number of Departments
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label ID="lblNumber_of_Dependents" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlViewIncident" runat="server" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Incident Information
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" style="width: 18%">Date of Incident
                                                        </td>
                                                        <td align="center" style="width: 4%">:
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label ID="lblDate_Of_Incident" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">Time of Incident(HH:MM)
                                                        </td>
                                                        <td align="center" style="width: 4%">:
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label ID="lblTime_Of_Incident" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Filing State
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblFiling_State"></asp:Label>
                                                        </td>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                        <td align="center">&nbsp;
                                                        </td>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Injury Occurred
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label runat="server" ID="lblInjuryOccurredOffsite">
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr id="trViewIncidentInjuryOccured" runat="Server" style="display: none">
                                                        <td align="left">&nbsp;
                                                        </td>
                                                        <td align="center">&nbsp;
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td style="width: 18%">Address 1
                                                                    </td>
                                                                    <td style="width: 4%">:
                                                                    </td>
                                                                    <td style="width: 28%">
                                                                        <asp:Label runat="server" ID="lblOffsite_Address1"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Address 2
                                                                    </td>
                                                                    <td>:
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label runat="server" ID="lblOffsite_Address2"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>City
                                                                    </td>
                                                                    <td>:
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label runat="server" ID="lblOffsite_City"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>State
                                                                    </td>
                                                                    <td>:
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label runat="server" ID="lblOffsite_State"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Zip code
                                                                    </td>
                                                                    <td>:
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label runat="server" ID="lblOffsite_zip"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Description of Incident
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="lblDescription_Of_Incident" runat="server" MaxLength="4000"
                                                                ControlType="label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Associate Injured in Regular Job
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label runat="server" ID="lblAssociate_Injured_Regular_Job"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Nature of Injury
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblFK_Nature_Of_Injury"></asp:Label>
                                                        </td>
                                                        <td align="left">Department Where Injured Occurred
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblFK_Department_Where_Occurred"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Body Part Affected
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label runat="server" ID="lblFK_Body_Parts_Affected"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Were Safeguards or Safety Equipment Provided?
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblSafeguards_Provided"></asp:Label>
                                                        </td>
                                                        <td align="left">Were Safeguards or Safety Equipment Used?
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblSafeguards_Used" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Was Machine Part Involved?
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblMachine_Part_Involved"></asp:Label>
                                                        </td>
                                                        <td align="left">Was Machine Part Defective?
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblMachine_Part_Defective" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Was the Claim Questionable?
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblClaim_Questionable"></asp:Label>
                                                        </td>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                        <td align="center">&nbsp;
                                                        </td>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">If Yes, Why?
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="lblClaim_Questionable_Description" runat="server" MaxLength="4000"
                                                                ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Date Reported to Sonic
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblDate_Reported_To_Sonic" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">To Whom at Sonic was Incident Reported to?
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblperson_reported_to"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Witnesses?
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label runat="server" ID="lblWitnesses"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Witness 1
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblWitness_1"></asp:Label>
                                                        </td>
                                                        <td align="left">Witness 1 Telephone<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblWitness_1_Phone"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Witness 2
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblWitness_2"></asp:Label>
                                                        </td>
                                                        <td align="left">Witness 2 Telephone<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblWitness_2_Phone"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Witness 3
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblWitness_3"></asp:Label>
                                                        </td>
                                                        <td align="left">Witness 3 Telephone<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblWitness_3_Phone"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                        <td align="center">&nbsp;
                                                        </td>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                        <td align="left">Fatality
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblFatality"></asp:Label>
                                                        </td>
                                                    </tr>


                                                    <tr>
                                                        <td colspan="6">
                                                            <div class="bandHeaderRow">
                                                                OSHA Fields
                                                            </div>
                                                        </td>
                                                    </tr>
                                                   <%-- <tr>
                                                        <td align="left">Name of Physician or Other Health Care Professional
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblPhysician_Other_Professional"></asp:Label>
                                                        </td>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                        <td align="center">&nbsp;
                                                        </td>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">If Treatment is Given Away from the Worksite, Facility Where it Was Given
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblFacility"></asp:Label>
                                                        </td>
                                                        <td align="left">Treatment Facility Address
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblFacility_Address"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Treatment Facility City
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblFacility_City"></asp:Label>
                                                        </td>
                                                        <td align="left">Treatment Facility State
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblFK_State_Facility"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Treatment Facility Zip Code (XXXXX-XXXX)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblFacility_Zip_Code"></asp:Label>
                                                        </td>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                        <td align="center">&nbsp;
                                                        </td>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="left">Was Associate Treated in an Emergency Room?
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblEmergency_Room"></asp:Label>
                                                        </td>
                                                        <td align="left">Time Associate Began Work (HH:MM)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblTime_Began_Work"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">What was the associate doing just before the incident occurred?
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="lblActivity_Before_Incident" runat="server" MaxLength="1000"
                                                                ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Describe any object or substance that directly harmed the associate
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="lblObject_Substance_Involved" runat="server" MaxLength="1000"
                                                                ControlType="Label" />
                                                        </td>
                                                    </tr>



                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlViewMedical" runat="server" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Medical
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" valign="top">Was Telephone Nurse Consultation Used? <span style="color: Red">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTelephone_Nurse_Consultation" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Was the Associate’s Direct Supervisor Involved in the Telephone Nurse Consultation Phone Call? <span style="color: Red">*</span>
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSupervisor_Involved_In_Consultation" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%" valign="top">Describe Initial Treatment
                                                        </td>
                                                        <td align="center" style="width: 4%" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="lblInitial_Medical_Treatment" runat="server" MaxLength="4000"
                                                                ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Date of Initial Treatment
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label ID="lblDate_of_Initial_Medical_Treatment" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Taken by Emergency Transportation?
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label runat="server" ID="lblTaken_By_Emergency_Transportation"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%">Medical Facility Name
                                                        </td>
                                                        <td align="center" style="width: 4%">:
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblMedical_Facility_Name"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">Treating Physician's Name
                                                        </td>
                                                        <td align="center" style="width: 4%">:
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="server" ID="lblTreating_Physician_Name"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Medical Facility Address 1
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblMedical_Facility_Address1"></asp:Label>
                                                        </td>
                                                        <td align="left">Admitted to Hospital
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblAdmitted_to_Hospital"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Medical Facility Address 2
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblMedical_Facility_Address2"></asp:Label>
                                                        </td>
                                                        <td align="left">Still in Hospital
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblStill_In_Hospital"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Medical Facility City
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label runat="server" ID="lblMedical_Facility_City"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Medical Facility State
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label runat="server" ID="lblMedical_Facility_State"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Medical Facility Zip Code
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label runat="server" ID="lblMedical_Facility_Zip"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Medical Facility Telephone<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label runat="server" ID="lblMedical_Facility_Phone"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Work Status
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">Out of Work :
                                                            <asp:Label runat="server" ID="lblStatus_Out_Of_Work" />
                                                        </td>
                                                        <td align="left">As Of
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblStatus_Out_Of_Work_date" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">Returned to Regular Job with No Restrictions :
                                                            <asp:Label runat="server" ID="lblStatus_Return_To_Work_Unrestricted" />
                                                        </td>
                                                        <td align="left">As Of
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblStatus_Return_To_Work_Unrestricted_date" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">Returned to Work with Restrictions :
                                                            <asp:Label runat="server" ID="lblStatus_Return_Tp_Work_Restricted" />
                                                        </td>
                                                        <td align="left">As Of
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblStatus_Return_Tp_Work_Restricted_date" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">Unknown :
                                                            <asp:Label runat="server" ID="lblStatus_Unknown" Text="Unknown" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Next Doctor’s Office Visit
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label ID="lblNext_Doctor_Visit" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Referring Physician?
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label runat="server" ID="lblReferring_Physician"></asp:Label>
                                                        </td>
                                                        <td align="left" colspan="4" runat="server" id="tdViewReferringPhysican" style="display: none;">
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" style="width: 18%">Physician’s Name
                                                                    </td>
                                                                    <td align="center" style="width: 4%">:
                                                                    </td>
                                                                    <td align="left" style="width: 28%">
                                                                        <asp:Label runat="server" ID="lblPhysician_Name"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">Physician’s Address 1
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label runat="server" ID="lblPhysician_Address1"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">Physician’s Address 2
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label runat="server" ID="lblPhysician_Address2"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">Physician’s City
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label runat="server" ID="lblPhysician_City"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">Physician’s State
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label runat="server" ID="lblPhysician_State"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">Physician’s Zip Code
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label runat="server" ID="lblPhysician_Zip"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">Physician’s Telephone<br />
                                                                        (xxx-xxx-xxxx)
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label runat="server" ID="lblPhysician_Phone"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlViewContacts" runat="server" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Contacts
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" style="width: 18%" valign="top">Dealership/Collision Center
                                                        </td>
                                                        <td align="center" style="width: 4%" valign="top">:
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label ID="lbldba" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">&nbsp;
                                                        </td>
                                                        <td align="center" style="width: 4%">&nbsp;
                                                        </td>
                                                        <td align="left" style="width: 28%">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Contact Name
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblContactDetailContactName" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">Address 1
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblContactDetailAddress_1" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">When to Contact
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblContactBestTime" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">Address 2
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblContactAddress2" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Telephone Number 1<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblContactTelephone1" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">City
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblContactDetailCity" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Telephone Number 2<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblContactTelephone2" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">State
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblContactDetailState" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Fax Number<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblContactDetailFaxNumber" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">Zip
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblContactDetailZipCode" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Email Address
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblContactDetailEmailAddress" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                        <td align="center">&nbsp;
                                                        </td>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Regional Loss Control Manager
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblContactRegionalManager" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">RLCM Telephone Number 1<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblContactRLCMTelephone1" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">RLCM Email Address
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblContactRLCMEmailAddress" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">RLCM Telephone Number 2<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblContactRLCMTelephone2" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlViewComments" runat="server" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Comments and Attachments
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" valign="top">Initial Claim Classification
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label ID="lblInitial_Claim_Classification" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%" valign="top">Comments/Special Instructor to Adjuster
                                                        </td>
                                                        <td align="center" style="width: 4%" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="lblComments" runat="server" MaxLength="4000" ControlType="label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Attachments
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <uc:ctrlAttachmentDetails ID="CtrlAttachmentDetailsView" runat="Server" ModeofPage="viewmode" />
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
                                                <asp:Button ID="btnClaimReview" runat="server" Text="Return to Claim Review Worksheet" OnClientClick="history.go(-1);return false;" />
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
    <asp:Panel runat="Server" ID="pnlUnrestricted" Visible="false">

        <script language="javascript" type="text/javascript">
            document.getElementById('imgStatus_Return_To_Work_Unrestricted').style.display = 'inline';
            document.getElementById('<%=txtStatus_Out_Of_Work_date.ClientID %>').disabled = true;
            document.getElementById('<%=txtStatus_Return_To_Work_Unrestricted_date.ClientID %>').disabled = false;
            document.getElementById('<%=txtStatus_Return_Tp_Work_Restricted_date.ClientID %>').disabled = true;
        </script>

    </asp:Panel>
    <asp:Panel runat="Server" ID="pnlOutOFWord" Visible="false">

        <script language="javascript" type="text/javascript">
            document.getElementById('imgStatus_Out_Of_Work').style.display = 'inline';
            document.getElementById('<%=txtStatus_Out_Of_Work_date.ClientID %>').disabled = false;
            document.getElementById('<%=txtStatus_Return_To_Work_Unrestricted_date.ClientID %>').disabled = true;
            document.getElementById('<%=txtStatus_Return_Tp_Work_Restricted_date.ClientID %>').disabled = true;
        </script>

    </asp:Panel>
    <asp:Panel runat="Server" ID="pnlrestricted" Visible="false">

        <script language="javascript" type="text/javascript">
            document.getElementById('imgStatus_Return_Tp_Work_Restricted').style.display = 'inline';
            document.getElementById('<%=txtStatus_Out_Of_Work_date.ClientID %>').disabled = true;
            document.getElementById('<%=txtStatus_Return_To_Work_Unrestricted_date.ClientID %>').disabled = true;
            document.getElementById('<%=txtStatus_Return_Tp_Work_Restricted_date.ClientID %>').disabled = false;
        </script>

    </asp:Panel>

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
    <asp:CustomValidator ID="CustomValidator" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
        Display="None" ValidationGroup="vsLocationGroup" />
    <input id="hdnControlIDs" runat="server" type="hidden" />
    <input id="hdnErrorMsgs" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFieldsAssociate"
        Display="None" ValidationGroup="vsAssociateGroup" />
    <input id="hdnAssociateID" runat="server" type="hidden" />
    <input id="hdnAssociateErrorMsgs" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFieldsIncident"
        Display="None" ValidationGroup="vsIncidentInfoGroup" />
    <input id="hdnIncidentID" runat="server" type="hidden" />
    <input id="hdnIncidentErrorMsgs" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFieldsMedical"
        Display="None" ValidationGroup="vsMedicalGroup" />
    <input id="hdnMedicalID" runat="server" type="hidden" />
    <input id="hdnMedicalErrorMsgs" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidator4" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFieldsComments"
        Display="None" ValidationGroup="vsCommentsGroup" />
    <input id="hdnCommentsID" runat="server" type="hidden" />
    <input id="hdnCommentsErrorMsgs" runat="server" type="hidden" />

</asp:Content>
