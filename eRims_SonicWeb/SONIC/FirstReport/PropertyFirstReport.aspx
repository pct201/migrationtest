<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="PropertyFirstReport.aspx.cs"
    Inherits="SONIC_PropertyFirstReport" Title="First Report :: Property" %>

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
        function AuditPopUpForBuilding(id) {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;

            obj = window.open("AuditPopup_Property_FR_Building.aspx?id=" + id, 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }

        //OPen Audit Popup
        function AuditPopUpForWitness(id) {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;

            obj = window.open("AuditPopup_Property_FR_Witness.aspx?id=" + id, 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }

        //OPen Audit Popup
        function AuditPopUp() {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;

            obj = window.open("AuditPopup_PropertyFirstReport.aspx?id=" + '<%=ViewState["PK_Prop_FR_ID"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }
        //check Date Validation
        function CheckDate(sender, args) {
            args.IsValid = (ValidateDate(args.Value));
            return args.IsValid;
        }
        //Check all Validation
        function CheckAllValidation() {
            //Check all Validation
            if (CheckValidationLossInfo() == true &&
                CheckValidationContactsInfo() == true && Page_ClientValidate("vsCommentGroup")) {
                return true;
            }
            else
                return false;

            //    if(Page_ClientValidate("vsLossInfoGroup") 
            //    && Page_ClientValidate("vsContactInfoGroup"))
            //    
        }
        //used to count Totoal Estimate Amount. this funciton is call at blur event of each related TextBox.
        function CountEstTotal() {
            /*****************************Common for this Function*********************************************/
            //Here one come comment is for isNaN function.
            //javascript is support octal numeber. so when javascript get 01 or any number preceding of 0
            //than it not return the correct value i.e if 01 is passed than is not undersatnd it as 1. it convert it value to octal
            //Number. so we first multiply number with 1 so 01 becomes 1 than check is numberic for this value.
            /***************************************************************************************************/
            var TotalEst = 0;
            var Est1 = (document.getElementById('<%=txtDamage_Building_Facilities_Est_Cost.ClientID %>'));
            var Est2 = (document.getElementById('<%=txtDamage_Equipment_Est_Cost.ClientID %>'));
            var Est3 = (document.getElementById('<%=txtDamage_Product_Damage_Est_Cost.ClientID %>'));
            var Est4 = (document.getElementById('<%=txtDamage_Parts_Est_Cost.ClientID %>'));
            var Est5 = (document.getElementById('<%=txtDamage_Salvage_Cleanup_Est_Cost.ClientID %>'));
            var Est6 = (document.getElementById('<%=txtDamage_Decontamination_Est_Cost.ClientID %>'));
            var Est7 = (document.getElementById('<%=txtDamage_Electronic_Data_Est_Cost.ClientID %>'));
            var Est8 = (document.getElementById('<%=txtDamage_Service_Interruption_Est_Cost.ClientID %>'));
            var Est9 = (document.getElementById('<%=txtDamage_Payroll_Est_Cost.ClientID %>'));
            var Est10 = (document.getElementById('<%=txtDamage_Loss_of_Sales_Est_Cost.ClientID %>'));
            //used to check value of textbox not null and value is numeric
            if (Est1.value != "" && isNaN(Number(Est1.value.replace(/,/g, '')) * 1) == false)
                TotalEst = Number(TotalEst) + Number(Est1.value.replace(/,/g, '') * 1);
            else
                Est1.innerText = 0;
            //used to check value of textbox not null and value is numeric   
            if (Est2.value != "" && isNaN(Number(Est2.value.replace(/,/g, '')) * 1) == false)
                TotalEst = Number(TotalEst) + Number(Est2.value.replace(/,/g, '') * 1);
            else
                Est2.innerText = 0;
            //used to check value of textbox not null and value is numeric
            if (Est3.value != "" && isNaN(Number(Est3.value.replace(/,/g, '')) * 1) == false)
                TotalEst = Number(TotalEst) + Number(Est3.value.replace(/,/g, '') * 1);
            else
                Est3.innerText = 0;
            //used to check value of textbox not null and value is numeric
            if (Est4.value != "" && isNaN(Number(Est4.value.replace(/,/g, '')) * 1) == false)
                TotalEst = Number(TotalEst) + Number(Est4.value.replace(/,/g, '') * 1);
            else
                Est4.innerText = 0;
            //used to check value of textbox not null and value is numeric
            if (Est5.value != "" && isNaN(Number(Est5.value.replace(/,/g, '')) * 1) == false)
                TotalEst = Number(TotalEst) + Number(Est5.value.replace(/,/g, '') * 1);
            else
                Est5.innerText = 0;
            //used to check value of textbox not null and value is numeric
            if (Est6.value != "" && isNaN(Number(Est6.value.replace(/,/g, '')) * 1) == false)
                TotalEst = Number(TotalEst) + Number(Est6.value.replace(/,/g, '') * 1);
            else
                Est6.innerText = 0;
            //used to check value of textbox not null and value is numeric      
            if (Est7.value != "" && isNaN(Number(Est7.value.replace(/,/g, '')) * 1) == false)
                TotalEst = Number(TotalEst) + Number(Est7.value.replace(/,/g, '') * 1);
            else
                Est7.innerText = 0;
            //used to check value of textbox not null and value is numeric
            if (Est8.value != "" && isNaN(Number(Est8.value.replace(/,/g, '')) * 1) == false)
                TotalEst = Number(TotalEst) + Number(Est8.value.replace(/,/g, '') * 1);
            else
                Est8.innerText = 0;
            //used to check value of textbox not null and value is numeric
            if (Est9.value != "" && isNaN(Number(Est9.value.replace(/,/g, '')) * 1) == false)
                TotalEst = Number(TotalEst) + Number(Est9.value.replace(/,/g, '') * 1);
            else
                Est9.innerText = 0;
            //used to check value of textbox not null and value is numeric
            if (Est10.value != "" && isNaN(Number(Est10.value.replace(/,/g, '')) * 1) == false)
                TotalEst = Number(TotalEst) + Number(Est10.value.replace(/,/g, '') * 1);
            else
                Est10.innerText = 0;
            //set values
            document.getElementById('<%=txtEstCalculated.ClientID %>').innerText = InsertCommas(TotalEst.toFixed(2));
        }
        function CountActualTotal() {
            /*****************************Common for this Function*********************************************/
            //Here one come comment is for isNaN function.
            //javascript is support octal numeber. so when javascript get 01 or any number preceding of 0
            //than it not return the correct value i.e if 01 is passed than is not undersatnd it as 1. it convert it value to octal
            //Number. so we first multiply number with 1 so 01 becomes 1 than check is numberic for this value.
            /***************************************************************************************************/

            var TotalActual = 0;
            var Actual1 = (document.getElementById('<%=txtDamage_Building_Facilities_Actual_Cost.ClientID %>'));
            var Actual2 = (document.getElementById('<%=txtDamage_Equipment_Actual_Cost.ClientID %>'));
            var Actual3 = (document.getElementById('<%=txtDamage_Product_Damage_Actual_Cost.ClientID %>'));
            var Actual4 = (document.getElementById('<%=txtDamage_Parts_Actual_Cost.ClientID %>'));
            var Actual5 = (document.getElementById('<%=txtDamage_Salvage_Cleanup_Actual_Cost.ClientID %>'));
            var Actual6 = (document.getElementById('<%=txtDamage_Decontamination_Actual_Cost.ClientID %>'));
            var Actual7 = (document.getElementById('<%=txtDamage_Electronic_Data_Actual_Cost.ClientID %>'));
            var Actual8 = (document.getElementById('<%=txtDamage_Service_Interruption_Actual_Cost.ClientID %>'));
            var Actual9 = (document.getElementById('<%=txtDamage_Payroll_Actual_Cost.ClientID %>'));
            var Actual10 = (document.getElementById('<%=txtDamage_Loss_of_Sales_Actual_Cost.ClientID %>'));
            //used to check value of textbox not null and value is numeric
            if (Actual1.value != "" && isNaN(Number(Actual1.value.replace(/,/g, '')) * 1) == false)
                TotalActual = Number(TotalActual) + Number(Actual1.value.replace(/,/g, '') * 1);
            else
                Actual1.innerText = 0;
            //used to check value of textbox not null and value is numeric      
            if (Actual2.value != "" && isNaN(Number(Actual2.value.replace(/,/g, '')) * 1) == false)
                TotalActual = Number(TotalActual) + Number(Actual2.value.replace(/,/g, '') * 1);
            else
                Actual2.innerText = 0;
            //used to check value of textbox not null and value is numeric
            if (Actual3.value != "" && isNaN(Number(Actual3.value.replace(/,/g, '')) * 1) == false)
                TotalActual = Number(TotalActual) + Number(Actual3.value.replace(/,/g, '') * 1);
            else
                Actual3.innerText = 0;
            //used to check value of textbox not null and value is numeric
            if (Actual4.value != "" && isNaN(Number(Actual4.value.replace(/,/g, '')) * 1) == false)
                TotalActual = Number(TotalActual) + Number(Actual4.value.replace(/,/g, '') * 1);
            else
                Actual4.innerText = 0;

            //used to check value of textbox not null and value is numeric
            if (Actual5.value != "" && isNaN(Number(Actual5.value.replace(/,/g, '')) * 1) == false)
                TotalActual = Number(TotalActual) + Number(Actual5.value.replace(/,/g, '') * 1);
            else
                Actual5.innerText = 0;

            //used to check value of textbox not null and value is numeric
            if (Actual6.value != "" && isNaN(Number(Actual6.value.replace(/,/g, '')) * 1) == false)
                TotalActual = Number(TotalActual) + Number(Actual6.value.replace(/,/g, '') * 1);
            else
                Actual6.innerText = 0;

            //used to check value of textbox not null and value is numeric
            if (Actual7.value != "" && isNaN(Number(Actual7.value.replace(/,/g, '')) * 1) == false)
                TotalActual = Number(TotalActual) + Number(Actual7.value.replace(/,/g, '') * 1);
            else
                Actual7.innerText = 0;

            //used to check value of textbox not null and value is numeric
            if (Actual8.value != "" && isNaN(Number(Actual8.value.replace(/,/g, '')) * 1) == false)
                TotalActual = Number(TotalActual) + Number(Actual8.value.replace(/,/g, '') * 1);
            else
                Actual8.innerText = 0;

            //used to check value of textbox not null and value is numeric
            if (Actual9.value != "" && isNaN(Number(Actual9.value.replace(/,/g, '')) * 1) == false)
                TotalActual = Number(TotalActual) + Number(Actual9.value.replace(/,/g, '') * 1);
            else
                Actual9.innerText = 0;

            //used to check value of textbox not null and value is numeric
            if (Actual10.value != "" && isNaN(Number(Actual10.value.replace(/,/g, '')) * 1) == false)
                TotalActual = Number(TotalActual) + Number(Actual10.value.replace(/,/g, '') * 1);
            else
                Actual10.innerText = 0;

            document.getElementById('<%=txtActualCalculated.ClientID %>').innerText = InsertCommas(TotalActual.toFixed(2));
        }
        //used to check Validation for Loss Informatio panel
        function CheckValidationLossInfo() {
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
            //used to check Page Validation of passed Validation group id
            if (Page_ClientValidate("vsLossInfoGroup")) {
                return true;
            }
            else
                return false;
        }
        //used to check validation of contact Information panel
        function CheckValidationContactsInfo() {
            //check value if it is "___-___-___" than convert this value to ""
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
            //used to Validate Page for Passed Validation group id
            if (Page_ClientValidate("vsContactInfoGroup")) {
                return true;
            }
            else
                return false;
        }
        //Used to Set Menu Style
        function SetMenuStyle(index) {
            var i;
            for (i = 1; i <= 3; i++) {
                var tb = document.getElementById("PropertyMenu" + i);
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
                document.getElementById("<%=dvView.ClientID%>").style.display = "block";
                ShowPanelView(index);
            }
            else {
                document.getElementById("<%=dvView.ClientID%>").style.display = "none";
                //check if index is 1 than display Location Section.
                if (index == 1) {
                    document.getElementById("<%=pnlLocation.ClientID%>").style.display = "block";
                    document.getElementById("<%=pnlLossInformation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlComments.ClientID%>").style.display = "none";
                }
                //check if index is 2 than  display Loss information panel
                if (index == 2) {
                    document.getElementById("<%=pnlLocation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlLossInformation.ClientID%>").style.display = "block";
                    document.getElementById("<%=pnlComments.ClientID%>").style.display = "none";
                }
                //check if index is either 3 than displa Comment and Attachment Section
                if (index == 3) {
                    document.getElementById("<%=pnlLocation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlLossInformation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlComments.ClientID%>").style.display = "block";
                }

            }
        }
        //used this function while page mode in view Mode
        function ShowPanelView(index) {
            //set Menu style
            SetMenuStyle(index);
            //check if Index is 1 than display Location section in View Mode.
            if (index == 1) {
                document.getElementById("<%=pnlViewLocation.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlViewLossInformation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewComments.ClientID%>").style.display = "none";
            }
            //check if Index is 2 than display Loss Information in View Mode
            if (index == 2) {
                document.getElementById("<%=pnlViewLocation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewLossInformation.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlViewComments.ClientID%>").style.display = "none";
            }
            //check if Index is either 3 than Comment and Attachment Section in View Mode
            if (index == 3) {
                document.getElementById("<%=pnlViewLocation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewLossInformation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlViewComments.ClientID%>").style.display = "block";
            }

            document.getElementById("<%=hdnCureentPanel.ClientID%>").value = index;
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

        function ValidateFieldsLossInfoBuilding(sender, args) {

            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnControlIDsLossInfoBuilding.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnErrorMsgsLossInfoBuilding.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnControlIDsLossInfoBuilding.ClientID%>').value != "") {
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

        function ValidateFieldsLossInfoWitness(sender, args) {

            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnControlIDsLossInfoWitness.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnErrorMsgsLossInfoWitness.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnControlIDsLossInfoWitness.ClientID%>').value != "") {
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

        jQuery(function ($) {
            $("#<%=txtDate_Reported_To_Sonic.ClientID%>").mask("99/99/9999");
            $("#<%=txtContactFaxNumber.ClientID%>").mask("999-999-9999");
            $("#<%=txtContact_Best_Time.ClientID%>").mask("99:99");
            $("#<%=txtDate_Of_Loss.ClientID%>").mask("99/99/9999");
            $("#<%=txtTime_Of_Loss.ClientID%>").mask("99:99");
            $("#<%=txtDate_Cleanup_Complete.ClientID%>").mask("99/99/9999");
            $("#<%=txtDate_Repairs_Complete.ClientID%>").mask("99/99/9999");
            $("#<%=txtDate_Full_Service_Resumed.ClientID%>").mask("99/99/9999");
            $("#<%=txtDate_Fire_Protection_Services_Resumed.ClientID%>").mask("99/99/9999");
            $("#<%=txtDateReportComplate.ClientID%>").mask("99/99/9999");
            $("#<%=txtClaimClosed.ClientID%>").mask("99/99/9999");
        });
    </script>

    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Location/Contact Panel:" BorderWidth="1"
            BorderColor="DimGray" ValidationGroup="vsContactInfoGroup" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsErrorLossBuilding" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1"
            BorderColor="DimGray" ValidationGroup="vsErrorBuildingAffected" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsErrorLossWitness" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1"
            BorderColor="DimGray" ValidationGroup="vsErrorWitness" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsLossError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Loss Panel:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsLossInfoGroup" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsAttchments" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Comments/Attachment Panel:" BorderWidth="1"
            BorderColor="DimGray" ValidationGroup="AddAttachment" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsComment" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields in Comments/Attachment Panel:" BorderWidth="1"
            BorderColor="DimGray" ValidationGroup="vsCommentGroup" CssClass="errormessage"></asp:ValidationSummary>
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
                                        <asp:Menu ID="mnuProperty" runat="server" DataSourceID="dsPropertyMenu" StaticEnableDefaultPopOutImage="false">
                                            <StaticItemTemplate>
                                                <table cellpadding="5" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="100%">
                                                            <span id="PropertyMenu<%#Container.ItemIndex+1%>" onclick="javascript:ShowPanel(<%#Container.ItemIndex+1%>);"
                                                                class="LeftMenuStatic">
                                                                <%#Eval("Text")%>&nbsp;
                                                                 <asp:Label ID="MenuAsterisk" runat="server" Text="*" Style="color: Red; display: none"></asp:Label>
                                                            </span>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </StaticItemTemplate>
                                        </asp:Menu>
                                        <asp:SiteMapDataSource ID="dsPropertyMenu" runat="server" SiteMapProvider="SonicPropertyMenuProvider"
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
                                                                <%--<td align="left" valign="top">Legal Entity
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList runat="server" ID="ddlLegalEntity" SkinID="ddlSONIC">
                                                                    </asp:DropDownList>
                                                                </td>--%>
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
                                                            Contact Information
                                                        </div>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" width="18%">Dealership/Collision Center
                                                                </td>
                                                                <td align="center" width="4%">:
                                                                </td>
                                                                <td width="28%" align="left">
                                                                    <asp:TextBox runat="server" ID="txtCostCenterdba" Width="170px"></asp:TextBox>
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
                                                                    <asp:TextBox runat="server" ID="txtCostCenterAddress1" Width="170px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">When to Contact&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtContact_Best_Time" Width="170px"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revtxtContact_Best_Time" runat="server"
                                                                        ControlToValidate="txtContact_Best_Time"
                                                                        ValidationExpression="^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$"
                                                                        ErrorMessage="Invalid Time of When to Contact." Display="none" ValidationGroup="vsContactInfoGroup"
                                                                        SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left">Address 2
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtCostCenterAddress2" Width="170px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Telephone Number 1<br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtContactTelephoneNumber1" Width="170px"></asp:TextBox>
                                                                </td>
                                                                <td align="left">City
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtCostCenterCity" Width="170px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Telephone Number 2<br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtContactTelephoneNumber2" Width="170px"></asp:TextBox>
                                                                </td>
                                                                <td align="left">State
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtCostCenterState" Width="170px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Fax Number&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span><br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtContactFaxNumber" Width="170px" runat="server" MaxLength="50">
                                                                    </asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revContactFaxNumber" ControlToValidate="txtContactFaxNumber"
                                                                        runat="server" ValidationGroup="vsContactInfoGroup" ErrorMessage="Please Enter Fax Number in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left">Zip
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtCostCenterZipCode" Width="170px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Email Address
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox ID="txtContactEmailAddress" runat="server" Width="170px" MaxLength="30"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Date Reported to Sonic&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox ID="txtDate_Reported_To_Sonic" runat="server"></asp:TextBox>
                                                                    <asp:TextBox ID="txtCurrentDate" runat="server" Style="display: none"></asp:TextBox>
                                                                    <img alt="Date Reported to SONIC" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Reported_To_Sonic', 'mm/dd/y',CompareDateLessThanToday,'ctl00_ContentPlaceHolder1_txtDate_Reported_To_Sonic');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" /><br />
                                                                    <asp:CustomValidator ID="cvDate_Reported_To_Sonic" runat="server" ControlToValidate="txtDate_Reported_To_Sonic"
                                                                        ValidationGroup="vsContactInfoGroup" ClientValidationFunction="CheckDate" ErrorMessage="Date Reported to Sonic is not valid."
                                                                        Display="None">
                                                                    </asp:CustomValidator>
                                                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtDate_Reported_To_Sonic"
                                                                        ValidationGroup="vsContactInfoGroup" ErrorMessage="Date Reported to Sonic Should Not Be Future Date."
                                                                        Type="Date" Operator="LessThanEqual" ControlToCompare="txtCurrentDate" Display="none">
                                                                    </asp:CompareValidator>

                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" align="center">
                                                                    <asp:Button runat="server" ID="btnLocationSave" Text="Save & Continue" OnClick="btnLocationSave_Click"
                                                                        ValidationGroup="vsContactInfoGroup" OnClientClick="return CheckValidationContactsInfo();" />
                                                                    <asp:Button runat="server" ID="btnLocationAudit" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();"
                                                                        ToolTip="View Audit Trail" CausesValidation="false" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6">&nbsp;</td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlLossInformation" Width="100%" runat="server">
                                                <div class="bandHeaderRow">
                                                    Loss Information
                                                </div>
                                                <asp:UpdatePanel runat="server" ID="updLoss">
                                                    <ContentTemplate>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" style="width: 18%">Date of Loss&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">:
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox ID="txtDate_Of_Loss" runat="server"></asp:TextBox>
                                                                    <img alt="Date of Loss" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Of_Loss', 'mm/dd/y',CompareDateLessThanToday,'ctl00_ContentPlaceHolder1_txtDate_Of_Loss');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" /><br />
                                                                    <asp:RegularExpressionValidator ID="revtxtDate_Of_Loss" runat="server" ControlToValidate="txtDate_Of_Loss"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                        ErrorMessage="Date Reported to Sonic is not valid." Display="none" ValidationGroup="vsLossInfoGroup"></asp:RegularExpressionValidator>
                                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtDate_Of_Loss"
                                                                        ValidationGroup="vsLossInfoGroup" ErrorMessage=" Date of Loss Should Not Be Future Date."
                                                                        Type="Date" Operator="LessThanEqual" ControlToCompare="txtCurrentDate" Display="none">
                                                                    </asp:CompareValidator>
                                                                </td>
                                                                <td align="left" style="width: 18%">Time of Loss(HH:MM)&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">:
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="Server" ID="txtTime_Of_Loss" Width="170px"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                                                        ControlToValidate="txtTime_Of_Loss"
                                                                        ValidationExpression="^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$"
                                                                        ErrorMessage="Invalid Time of Loss." Display="none" ValidationGroup="vsLossInfoGroup"
                                                                        SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Building Affected
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left" colspan="4">&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6">
                                                                    <asp:UpdatePanel runat="server" ID="updBuilding">
                                                                        <ContentTemplate>
                                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                <tr>
                                                                                    <td colspan="4">
                                                                                        <asp:GridView ID="gvBUilding" runat="server" DataKeyNames="PK_Property_FR_Building_ID"
                                                                                            AutoGenerateColumns="false" Width="100%" AllowSorting="false" OnRowCreated="gvBUilding_RowCreated"
                                                                                            OnRowCommand="gvBUilding_RowCommand" OnRowEditing="gvBUilding_RowEditing">
                                                                                            <Columns>
                                                                                                <asp:TemplateField HeaderText="Occupancy">
                                                                                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                                    <ItemTemplate>
                                                                                                        <%#Eval("Occupancy")%>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Address">
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
                                                                                                        <%# new ERIMS.DAL.State((Eval("State") != null) ? Convert.ToDecimal(Eval("State")) : 0).FLD_state%>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Zip">
                                                                                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                                    <ItemTemplate>
                                                                                                        <%#Eval("Zip")%>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Edit">
                                                                                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton runat="server" ID="lnkEdit" CommandName="Edit" Text="Edit"></asp:LinkButton>
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
                                                                                    <td style="width: 25%">&nbsp;
                                                                                    </td>
                                                                                    <td style="width: 14%">Occupancy (Departments)&nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                                                                                    </td>
                                                                                    <td style="width: 7%" align="center">:
                                                                                    </td>
                                                                                    <td style="width: 54%">
                                                                                        <asp:TextBox runat="server" ID="txtB_Occupancy" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>&nbsp;
                                                                                    </td>
                                                                                    <td>Address 1&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                                                                    </td>
                                                                                    <td align="center">:
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox runat="server" ID="txtB_Address_1" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>&nbsp;
                                                                                    </td>
                                                                                    <td>Address 2&nbsp;<span id="Span8" style="color: Red; display: none;" runat="server">*</span>
                                                                                    </td>
                                                                                    <td align="center">:
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox runat="server" ID="txtB_Address_2" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>&nbsp;
                                                                                    </td>
                                                                                    <td>City&nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                                                                                    </td>
                                                                                    <td align="center">:
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox runat="server" ID="txtB_City" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>&nbsp;
                                                                                    </td>
                                                                                    <td>State&nbsp;<span id="Span10" style="color: Red; display: none;" runat="server">*</span>
                                                                                    </td>
                                                                                    <td align="center">:
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList runat="server" ID="ddlB_State" SkinID="ddlSONIC">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>&nbsp;
                                                                                    </td>
                                                                                    <td>Zip Code&nbsp;<span id="Span11" style="color: Red; display: none;" runat="server">*</span>
                                                                                    </td>
                                                                                    <td align="center">:
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox runat="server" ID="txtB_Zip" Width="170px" MaxLength="10"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="right" colspan="2">
                                                                                        <asp:Button runat="server" ID="btnAddBuilding" CausesValidation="true" ValidationGroup="vsErrorBuildingAffected" Text="Add" OnClick="btnAddBuilding_Click" />
                                                                                    </td>
                                                                                    <td align="left" colspan="2">
                                                                                        <asp:Button runat="server" ID="btnBuildingAudit" Text="View Audit Trail" Visible="false"
                                                                                            CauseValidation="false" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Witnesses
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left" colspan="4">&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6">
                                                                    <asp:UpdatePanel runat="server" ID="updWitness">
                                                                        <ContentTemplate>
                                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                <tr>
                                                                                    <td colspan="4">
                                                                                        <asp:GridView ID="gvWitness" runat="server" DataKeyNames="PK_Property_FR_Witness_ID"
                                                                                            AutoGenerateColumns="false" Width="100%" AllowSorting="false" OnRowCreated="gvWitness_RowCreated"
                                                                                            OnRowCommand="gvWitness_RowCommand" OnRowEditing="gvWitness_RowEditing">
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
                                                                                                        <%# new ERIMS.DAL.State((Eval("State") != null) ? Convert.ToDecimal(Eval("State")) : 0).FLD_state%>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Zip">
                                                                                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                                    <ItemTemplate>
                                                                                                        <%#Eval("Zip")%>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Edit">
                                                                                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton runat="server" ID="lnkEdit" CommandName="Edit" Text="Edit"></asp:LinkButton>
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
                                                                                    <td style="width: 25%">&nbsp;
                                                                                    </td>
                                                                                    <td style="width: 14%">Name&nbsp;<span id="Span12" style="color: Red; display: none;" runat="server">*</span>
                                                                                    </td>
                                                                                    <td style="width: 7%" align="center">:
                                                                                    </td>
                                                                                    <td style="width: 54%">
                                                                                        <asp:TextBox ID="txtW_Name" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>&nbsp;
                                                                                    </td>
                                                                                    <td>Address 1&nbsp;<span id="Span13" style="color: Red; display: none;" runat="server">*</span>
                                                                                    </td>
                                                                                    <td align="center">:
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox runat="server" ID="txtW_Address_1" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>&nbsp;
                                                                                    </td>
                                                                                    <td>Address 2&nbsp;<span id="Span14" style="color: Red; display: none;" runat="server">*</span>
                                                                                    </td>
                                                                                    <td align="center">:
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox runat="server" ID="txtW_Address_2" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>&nbsp;
                                                                                    </td>
                                                                                    <td>City&nbsp;<span id="Span15" style="color: Red; display: none;" runat="server">*</span>
                                                                                    </td>
                                                                                    <td align="center">:
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox runat="server" ID="txtW_City" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>&nbsp;
                                                                                    </td>
                                                                                    <td>State&nbsp;<span id="Span16" style="color: Red; display: none;" runat="server">*</span>
                                                                                    </td>
                                                                                    <td align="center">:
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList runat="server" ID="ddlW_State" SkinID="ddlSONIC">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>&nbsp;
                                                                                    </td>
                                                                                    <td>Zip Code&nbsp;<span id="Span17" style="color: Red; display: none;" runat="server">*</span>
                                                                                    </td>
                                                                                    <td align="center">:
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox runat="server" ID="txtW_Zip" Width="170px" MaxLength="10"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="right" colspan="2">
                                                                                        <asp:Button runat="server" ID="btnAddWitness" CausesValidation="true" ValidationGroup="vsErrorWitness" Text="Add" OnClick="btnAddWitness_Click" />
                                                                                    </td>
                                                                                    <td align="left" colspan="2">
                                                                                        <asp:Button runat="server" ID="btnWitnessAudit" Text="View Audit Trail" Visible="false" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Type of Loss
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left" colspan="4">Check All that apply:
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">&nbsp;
                                                                </td>
                                                                <td align="center">&nbsp;
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                        <tr>
                                                                            <td style="width: 5%">&nbsp;
                                                                            </td>
                                                                            <td style="width: 48%">
                                                                                <asp:CheckBox runat="server" ID="chkFire" Text="Fire" />
                                                                            </td>
                                                                            <td style="width: 47%">
                                                                                <asp:CheckBox runat="server" ID="chkProperty_Damage_by_Sonic_Associate" Text="Property Damage by Sonic Associate" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 5%">&nbsp;
                                                                            </td>
                                                                            <td style="width: 48%">
                                                                                <asp:CheckBox runat="server" ID="chkWind_Damage" Text="Wind Damage" />
                                                                            </td>
                                                                            <td style="width: 47%">
                                                                                <asp:CheckBox runat="server" ID="chkEnvironmental_Loss" Text="Environmental Loss" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>&nbsp;
                                                                            </td>
                                                                            <td>
                                                                                <asp:CheckBox runat="server" ID="chkHail_Damage" Text="Hail Damage" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:CheckBox runat="server" ID="chkVandalism_To_The_Property" Text="Vandalism to the Property" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>&nbsp;
                                                                            </td>
                                                                            <td>
                                                                                <asp:CheckBox runat="server" ID="chkEarth_Movement" Text="Earth Movement" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:CheckBox runat="server" ID="chkTheft_Associate_Tools" Text="Theft - Associate Tools" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>&nbsp;
                                                                            </td>
                                                                            <td>
                                                                                <asp:CheckBox runat="server" ID="chkFlood" Text="Flood" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:CheckBox runat="server" ID="chkTheft_All_Other" Text="Theft - All Other" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>&nbsp;
                                                                            </td>
                                                                            <td>
                                                                                <asp:CheckBox runat="server" ID="chkThird_Party_Property_Damage" Text="Third Party Property Damage" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:CheckBox runat="server" ID="chkOther" Text="Other" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Description of Loss&nbsp;<span id="Span18" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="txtDescription_of_Loss" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Is There a Security Video Surveillance System?
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:RadioButtonList runat="server" ID="rdo_Security_Video_Surveillance" SkinID="YesNoTypeNullSelection">
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Damages
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left" colspan="4">&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">&nbsp;
                                                                </td>
                                                                <td align="center">&nbsp;
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                        <tr>
                                                                            <td style="width: 30%">&nbsp;
                                                                            </td>
                                                                            <td style="width: 35%">Estimated Cost
                                                                            </td>
                                                                            <td style="width: 35%">Actual Cost
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>Building and Facilities&nbsp;<span id="Span19" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox runat="server" ID="txtDamage_Building_Facilities_Est_Cost" MaxLength="10"
                                                                                    Width="170px" onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"
                                                                                    OnBlur="CountEstTotal();"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox runat="server" ID="txtDamage_Building_Facilities_Actual_Cost" MaxLength="10"
                                                                                    Width="170px" onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"
                                                                                    OnBlur="CountActualTotal();"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>Equipment&nbsp;<span id="Span20" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox runat="server" ID="txtDamage_Equipment_Est_Cost" Width="170px" MaxLength="10"
                                                                                    onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"
                                                                                    onBlur="CountEstTotal();"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox runat="server" ID="txtDamage_Equipment_Actual_Cost" Width="170px" MaxLength="10"
                                                                                    onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"
                                                                                    OnBlur="CountActualTotal();"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>Product Damage&nbsp;<span id="Span21" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox runat="server" ID="txtDamage_Product_Damage_Est_Cost" Width="170px"
                                                                                    MaxLength="10" onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"
                                                                                    OnBlur="CountEstTotal();"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox runat="server" ID="txtDamage_Product_Damage_Actual_Cost" MaxLength="10"
                                                                                    Width="170px" onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"
                                                                                    OnBlur="CountActualTotal();"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>Parts&nbsp;<span id="Span22" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox runat="server" ID="txtDamage_Parts_Est_Cost" Width="170px" MaxLength="10"
                                                                                    onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"
                                                                                    OnBlur="CountEstTotal();"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox runat="server" ID="txtDamage_Parts_Actual_Cost" Width="170px" MaxLength="10"
                                                                                    onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"
                                                                                    OnBlur="CountActualTotal();"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>Salvage and Cleanup Expenses (including labor)&nbsp;<span id="Span23" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox runat="server" ID="txtDamage_Salvage_Cleanup_Est_Cost" MaxLength="10"
                                                                                    Width="170px" onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"
                                                                                    OnBlur="CountEstTotal();"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox runat="server" ID="txtDamage_Salvage_Cleanup_Actual_Cost" MaxLength="10"
                                                                                    Width="170px" onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"
                                                                                    OnBlur="CountActualTotal();"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>Decontamination Expenses&nbsp;<span id="Span24" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox runat="server" ID="txtDamage_Decontamination_Est_Cost" MaxLength="10"
                                                                                    Width="170px" onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"
                                                                                    OnBlur="CountEstTotal();"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox runat="server" ID="txtDamage_Decontamination_Actual_Cost" MaxLength="10"
                                                                                    Width="170px" onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"
                                                                                    OnBlur="CountActualTotal();"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>Electronic Data/Processing Media&nbsp;<span id="Span25" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox runat="server" ID="txtDamage_Electronic_Data_Est_Cost" MaxLength="10"
                                                                                    Width="170px" onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"
                                                                                    OnBlur="CountEstTotal();"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox runat="server" ID="txtDamage_Electronic_Data_Actual_Cost" MaxLength="10"
                                                                                    Width="170px" onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"
                                                                                    OnBlur="CountActualTotal();"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>Service Interruption&nbsp;<span id="Span26" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox runat="server" ID="txtDamage_Service_Interruption_Est_Cost" MaxLength="10"
                                                                                    Width="170px" onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"
                                                                                    OnBlur="CountEstTotal();"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox runat="server" ID="txtDamage_Service_Interruption_Actual_Cost" MaxLength="10"
                                                                                    Width="170px" onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"
                                                                                    OnBlur="CountActualTotal();"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>Ordinary Payroll&nbsp;<span id="Span27" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox runat="server" ID="txtDamage_Payroll_Est_Cost" Width="170px" MaxLength="10"
                                                                                    onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"
                                                                                    OnBlur="CountEstTotal();"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox runat="server" ID="txtDamage_Payroll_Actual_Cost" Width="170px" MaxLength="10"
                                                                                    onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"
                                                                                    OnBlur="CountActualTotal();"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>Loss of Sales&nbsp;<span id="Span28" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox runat="server" ID="txtDamage_Loss_of_Sales_Est_Cost" MaxLength="10"
                                                                                    Width="170px" onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"
                                                                                    OnBlur="CountEstTotal();"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox runat="server" ID="txtDamage_Loss_of_Sales_Actual_Cost" MaxLength="10"
                                                                                    Width="170px" onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"
                                                                                    OnBlur="CountActualTotal();"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>TOTAL&nbsp;<span id="Span29" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox runat="server" ID="txtEstCalculated" Width="170px" ReadOnly="true"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox runat="server" ID="txtActualCalculated" Width="170px" ReadOnly="true"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Date Clean-up or Salvage Operations Completed&nbsp;<span id="Span30" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox ID="txtDate_Cleanup_Complete" runat="server" Width="170px" onblur="javascript:return checkYearRange(this.id);"></asp:TextBox>
                                                                    <img alt="Clean Up Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Cleanup_Complete', 'mm/dd/y',checkYearRange,'ctl00_ContentPlaceHolder1_txtDate_Cleanup_Complete');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" /><br />
                                                                    <asp:CustomValidator ID="cvDate_Cleanup_Complete" runat="server" ControlToValidate="txtDate_Cleanup_Complete"
                                                                        ValidationGroup="vsLossInfoGroup" ClientValidationFunction="CheckDate" ErrorMessage="Clean Up Date is not valid."
                                                                        Display="None">
                                                                    </asp:CustomValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Date Equipment/Biuilding Repairs Completed&nbsp;<span id="Span31" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtDate_Repairs_Complete" Width="170px" onblur="javascript:return checkYearRange(this.id);"></asp:TextBox>
                                                                    <img alt="Repair Complete Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Repairs_Complete', 'mm/dd/y',checkYearRange,'ctl00_ContentPlaceHolder1_txtDate_Repairs_Complete');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" /><br />
                                                                    <asp:CustomValidator ID="cvDate_Repairs_Complete" runat="server" ControlToValidate="txtDate_Repairs_Complete"
                                                                        ValidationGroup="vsLossInfoGroup" ClientValidationFunction="CheckDate" ErrorMessage="Date of repairs complete is not valid."
                                                                        Display="None">
                                                                    </asp:CustomValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Date Full Services Resumed&nbsp;<span id="Span32" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtDate_Full_Service_Resumed" Width="170px" onblur="javascript:return checkYearRange(this.id);"></asp:TextBox>
                                                                    <img alt="Date when full service resume" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Full_Service_Resumed', 'mm/dd/y',checkYearRange,'ctl00_ContentPlaceHolder1_txtDate_Full_Service_Resumed');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" /><br />
                                                                    <asp:CustomValidator ID="cvDate_Full_Service_Resumed" runat="server" ControlToValidate="txtDate_Full_Service_Resumed"
                                                                        ValidationGroup="vsLossInfoGroup" ClientValidationFunction="CheckDate" ErrorMessage="Date of Full Service Resumed is not valid."
                                                                        Display="None">
                                                                    </asp:CustomValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Date Fire Protection Services Resumed&nbsp;<span id="Span33" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtDate_Fire_Protection_Services_Resumed" Width="170px"
                                                                        onblur="javascript:return checkYearRange(this.id);"></asp:TextBox>
                                                                    <img alt="Date of Fire Protection Services Resumed" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Fire_Protection_Services_Resumed', 'mm/dd/y',checkYearRange,'ctl00_ContentPlaceHolder1_txtDate_Fire_Protection_Services_Resumed');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" /><br />
                                                                    <asp:CustomValidator ID="cvDate_Fire_Protection_Services_Resumed" runat="server"
                                                                        ControlToValidate="txtDate_Fire_Protection_Services_Resumed" ValidationGroup="vsLossInfoGroup"
                                                                        ClientValidationFunction="CheckDate" ErrorMessage="Date of Fire Protection service resume is not valid."
                                                                        Display="None">
                                                                    </asp:CustomValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" align="center">
                                                                    <asp:Button runat="server" ID="btnLossSave" Text="Save & Continue" OnClick="btnLossSave_Click"
                                                                        ValidationGroup="vsLossInfoGroup" OnClientClick="return CheckValidationLossInfo();" />
                                                                    <asp:Button runat="server" ID="btnLossAudit" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();"
                                                                        ToolTip="View Audit Trail" CausesValidation="false" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6">&nbsp;</td>
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
                                                        <td align="left" style="width: 18%" valign="top">Comments/Instructions&nbsp;<span id="Span34" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" style="width: 4%" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="txtComments" runat="server" MaxLength="4000" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Date Report Completed&nbsp;<span id="Span35" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:TextBox ID="txtDateReportComplate" runat="server" Width="170px" onblur="javascript:return checkYearRange(this.id);"></asp:TextBox>
                                                            <img alt="Date of Loss" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDateReportComplate', 'mm/dd/y',checkYearRange,'ctl00_ContentPlaceHolder1_txtDateReportComplate');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" /><br />
                                                            <asp:CustomValidator ID="cvReportComplate" runat="server" ControlToValidate="txtDateReportComplate"
                                                                ValidationGroup="vsCommentGroup" ClientValidationFunction="CheckDate" ErrorMessage="Date Reported Complete is not valid."
                                                                Display="None">
                                                            </asp:CustomValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Date Claim Closed&nbsp;<span id="Span36" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:TextBox ID="txtClaimClosed" runat="server" Width="170px" onblur="javascript:return checkYearRange(this.id);"></asp:TextBox>
                                                            <img alt="Date of Loss" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtClaimClosed', 'mm/dd/y','ctl00_ContentPlaceHolder1_txtClaimClosed');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" /><br />
                                                            <asp:CustomValidator ID="cvClimClosed" runat="server" ControlToValidate="txtClaimClosed"
                                                                ValidationGroup="vsCommentGroup" ClientValidationFunction="CheckDate" ErrorMessage="Date of Claim Closed is not valid."
                                                                Display="None">
                                                            </asp:CustomValidator>
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
                                                            <asp:Button runat="server" ID="btnSubmit" CausesValidation="true" ValidationGroup="vsCommentGroup" Text="Submit Report" OnClick="btnSubmit_Click"
                                                                OnClientClick="return CheckAllValidation();" />
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
                                                        <%--<td align="left" valign="top">Legal Entity
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblLegalEntity"></asp:Label>
                                                        </td>--%>
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
                                                        <td align="left" width="18%">Dealership/Collision Center
                                                        </td>
                                                        <td align="center" width="4%">:
                                                        </td>
                                                        <td width="28%" align="left">
                                                            <asp:Label runat="server" ID="lblCostCenterdba"></asp:Label>
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
                                                            <asp:Label runat="server" ID="lblCostCenterAddress1"></asp:Label>
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
                                                            <asp:Label runat="server" ID="lblCostCenterAddress2"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Telephone Number 1<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblContactTelephoneNumber1"></asp:Label>
                                                        </td>
                                                        <td align="left">City
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblCostCenterCity"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Telephone Number 2<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblContactTelephoneNumber2"></asp:Label>
                                                        </td>
                                                        <td align="left">State
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblCostCenterState"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Fax Number<br />
                                                            (xxx-xxx-xxxx)
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblContactFaxNumber" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                        <td align="left">Zip
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblCostCenterZipCode"></asp:Label>
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
                                                    Loss Information
                                                </div>
                                                <asp:HiddenField runat="Server" ID="HiddenField1" />
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" style="width: 18%">Date of Loss
                                                        </td>
                                                        <td align="center" style="width: 4%">:
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label ID="lblDate_Of_Loss" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 18%">Time of Loss
                                                        </td>
                                                        <td align="center" style="width: 4%">:
                                                        </td>
                                                        <td align="left" style="width: 28%">
                                                            <asp:Label runat="Server" ID="lblTime_Of_Loss"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Building Affected
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <asp:UpdatePanel runat="server" ID="updViewBuilding">
                                                                <ContentTemplate>
                                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                        <tr>
                                                                            <td colspan="6">
                                                                                <asp:GridView ID="gvViewBUilding" runat="server" DataKeyNames="PK_Property_FR_Building_ID"
                                                                                    AutoGenerateColumns="false" Width="100%" AllowSorting="false" OnRowCreated="gvViewBUilding_RowCreated"
                                                                                    OnRowCommand="gvViewBUilding_RowCommand">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="Occupancy">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("Occupancy")%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Address">
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
                                                                                                <%# new ERIMS.DAL.State((Eval("State") != null) ? Convert.ToDecimal(Eval("State")) : 0).FLD_state%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Zip">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("Zip")%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="View">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton runat="server" ID="lnkViewBuilding" CommandName="View" Text="View"></asp:LinkButton>
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
                                                                            <td colspan="6" style="width: 100%; display: none;" id="tdViewBuilding" runat="server">
                                                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                    <tr>
                                                                                        <td style="width: 25%">&nbsp;
                                                                                        </td>
                                                                                        <td style="width: 14%">Occupancy (Departments)
                                                                                        </td>
                                                                                        <td style="width: 7%" align="center">:
                                                                                        </td>
                                                                                        <td style="width: 54%">
                                                                                            <asp:Label runat="server" ID="lblB_Occupancy"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>&nbsp;
                                                                                        </td>
                                                                                        <td>Address 1
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label runat="server" ID="lblB_Address_1"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>&nbsp;
                                                                                        </td>
                                                                                        <td>Address 2
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label runat="server" ID="lblB_Address_2"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>&nbsp;
                                                                                        </td>
                                                                                        <td>City
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label runat="server" ID="lblB_City"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>&nbsp;
                                                                                        </td>
                                                                                        <td>State
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label runat="server" ID="lblB_State"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>&nbsp;
                                                                                        </td>
                                                                                        <td>Zip Code
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label runat="server" ID="lblB_Zip"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="center" colspan="4">
                                                                                            <asp:Button runat="server" ID="btnViewBuildingAudit" Text="View Audit Trail" Visible="false"
                                                                                                CausesValidation="false" />
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
                                                        <td align="left" colspan="6">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Witnesses
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <asp:UpdatePanel runat="server" ID="udpViewWitness">
                                                                <ContentTemplate>
                                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                        <tr>
                                                                            <td colspan="6">
                                                                                <asp:GridView ID="gvViewWitness" runat="server" DataKeyNames="PK_Property_FR_Witness_ID"
                                                                                    AutoGenerateColumns="false" Width="100%" AllowSorting="false" OnRowCreated="gvViewWitness_RowCreated"
                                                                                    OnRowCommand="gvViewWitness_RowCommand">
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
                                                                                                <%# new ERIMS.DAL.State((Eval("State") != null) ? Convert.ToDecimal(Eval("State")) : 0).FLD_state%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Zip">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <%#Eval("Zip")%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="View">
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton runat="server" ID="lnkViewWitness" CommandName="View" Text="View"></asp:LinkButton>
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
                                                                            <td colspan="6" style="width: 100%; display: none;" runat="server" id="tdViewWitness">
                                                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                    <tr>
                                                                                        <td style="width: 25%">&nbsp;
                                                                                        </td>
                                                                                        <td style="width: 14%">Name
                                                                                        </td>
                                                                                        <td style="width: 7%" align="center">:
                                                                                        </td>
                                                                                        <td style="width: 54%">
                                                                                            <asp:Label ID="lblW_Name" runat="server"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>&nbsp;
                                                                                        </td>
                                                                                        <td>Address 1
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label runat="server" ID="lblW_Address_1"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>&nbsp;
                                                                                        </td>
                                                                                        <td>Address 2
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label runat="server" ID="lblW_Address_2"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>&nbsp;
                                                                                        </td>
                                                                                        <td>City
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label runat="server" ID="lblW_City"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>&nbsp;
                                                                                        </td>
                                                                                        <td>State
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label runat="server" ID="lblW_State"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>&nbsp;
                                                                                        </td>
                                                                                        <td>Zip Code
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label runat="server" ID="lblW_Zip"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="center" colspan="4">
                                                                                            <asp:Button runat="server" ID="btnViewWitnessAudit" Text="View Audit Trail" Visible="false"
                                                                                                CausesValidation="false" />
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
                                                        <td align="left">Type of Loss
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">Check All that apply:
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                        <td align="center">&nbsp;
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td style="width: 5%">&nbsp;
                                                                    </td>
                                                                    <td style="width: 48%">
                                                                        <asp:CheckBox runat="server" ID="chkViewFire" Text="Fire" Enabled="false" />
                                                                    </td>
                                                                    <td style="width: 47%">
                                                                        <asp:CheckBox runat="server" ID="chkViewProperty_Damage_by_Sonic_Associate" Enabled="false"
                                                                            Text="Property Damage by Sonic Associate" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 5%">&nbsp;
                                                                    </td>
                                                                    <td style="width: 48%">
                                                                        <asp:CheckBox runat="server" ID="chkViewWind_Damage" Text="Wind Damage" Enabled="false" />
                                                                    </td>
                                                                    <td style="width: 47%">
                                                                        <asp:CheckBox runat="server" ID="chkViewEnvironmental_Loss" Text="Environmental Loss"
                                                                            Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;
                                                                    </td>
                                                                    <td>
                                                                        <asp:CheckBox runat="server" ID="chkViewHail_Damage" Text="Hail Damage" Enabled="false" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:CheckBox runat="server" ID="chkViewVandalism_To_The_Property" Text="Vandalism to the Property"
                                                                            Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;
                                                                    </td>
                                                                    <td>
                                                                        <asp:CheckBox runat="server" ID="chkViewEarth_Movement" Text="Earth Movement" Enabled="false" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:CheckBox runat="server" ID="chkViewTheft_Associate_Tools" Text="Theft - Associate Tools"
                                                                            Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;
                                                                    </td>
                                                                    <td>
                                                                        <asp:CheckBox runat="server" ID="chkViewFlood" Text="Flood" Enabled="false" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:CheckBox runat="server" ID="chkViewTheft_All_Other" Text="Theft - All Other"
                                                                            Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;
                                                                    </td>
                                                                    <td>
                                                                        <asp:CheckBox runat="server" ID="chkViewThird_Party_Property_Damage" Text="Third Party Property Damage"
                                                                            Enabled="false" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:CheckBox runat="server" ID="chkViewOther" Text="Other" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Description of Loss
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <uc:ctrlMultiLineTextBox runat="server" ID="lblDescription_of_Loss" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Is There a Security Video Surveillance System?
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label runat="server" ID="lbl_Security_Video_Surveillance"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Damages
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                        <td align="center">&nbsp;
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td style="width: 30%">&nbsp;
                                                                    </td>
                                                                    <td style="width: 35%">Estimated Cost
                                                                    </td>
                                                                    <td style="width: 35%">Actual Cost
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Building and Facilities
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label runat="server" ID="lblDamage_Building_Facilities_Est_Cost"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label runat="server" ID="lblDamage_Building_Facilities_Actual_Cost"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Equipment
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label runat="server" ID="lblDamage_Equipment_Est_Cost"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label runat="server" ID="lblDamage_Equipment_Actual_Cost"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Product Damage
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label runat="server" ID="lblDamage_Product_Damage_Est_Cost"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label runat="server" ID="lblDamage_Product_Damage_Actual_Cost"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Parts
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label runat="server" ID="lblDamage_Parts_Est_Cost"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label runat="server" ID="lblDamage_Parts_Actual_Cost"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Salvage and Cleanup Expenses (including labor)
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label runat="server" ID="lblDamage_Salvage_Cleanup_Est_Cost"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label runat="server" ID="lblDamage_Salvage_Cleanup_Actual_Cost"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Decontamination Expenses
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label runat="server" ID="lblDamage_Decontamination_Est_Cost"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label runat="server" ID="lblDamage_Decontamination_Actual_Cost"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Electronic Data/Processing Media
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label runat="server" ID="lblDamage_Electronic_Data_Est_Cost"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label runat="server" ID="lblDamage_Electronic_Data_Actual_Cost"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Service Interruption
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label runat="server" ID="lblDamage_Service_Interruption_Est_Cost"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label runat="server" ID="lblDamage_Service_Interruption_Actual_Cost"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Ordinary Payroll
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label runat="server" ID="lblDamage_Payroll_Est_Cost"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label runat="server" ID="lblDamage_Payroll_Actual_Cost"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Loss of Sales
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label runat="server" ID="lblDamage_Loss_of_Sales_Est_Cost"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label runat="server" ID="lblDamage_Loss_of_Sales_Actual_Cost"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>TOTAL
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label runat="server" ID="lblEstCalculated"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label runat="server" ID="lblActualCalculated"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Date Clean-up or Salvage Operations Completed
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label ID="lblDate_Cleanup_Complete" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Date Equipment/Biuilding Repairs Completed
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label runat="server" ID="lblDate_Repairs_Complete"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Date Full Services Resumed
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label runat="server" ID="lblDate_Full_Service_Resumed"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Date Fire Protection Services Resumed
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label runat="server" ID="lblDate_Fire_Protection_Services_Resumed"></asp:Label>
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
                                                        <td align="left" style="width: 18%" valign="top">Comments/Instructions
                                                        </td>
                                                        <td align="center" style="width: 4%" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="lblComments" runat="server" MaxLength="4000" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%" valign="top">Date Report Completed
                                                        </td>
                                                        <td align="center" style="width: 4%" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label ID="lblDateReportComplate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 18%" valign="top">Date Claim Closed
                                                        </td>
                                                        <td align="center" style="width: 4%" valign="top">:
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:Label ID="lblClaimClosed" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
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

    <asp:CustomValidator ID="CustomValidatorLocation" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFieldsLocation"
        Display="None" ValidationGroup="vsContactInfoGroup" />
    <input id="hdnControlIDsLocation" runat="server" type="hidden" />
    <input id="hdnErrorMsgsLocation" runat="server" type="hidden" />

    <asp:CustomValidator ID="CustomValidatorLossInfo" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFieldsLossInfo"
        Display="None" ValidationGroup="vsLossInfoGroup" />
    <input id="hdnControlIDsLossInfo" runat="server" type="hidden" />
    <input id="hdnErrorMsgsLossInfo" runat="server" type="hidden" />

    <asp:CustomValidator ID="CustomValidatorLossInfoBuilding" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFieldsLossInfoBuilding"
        Display="None" ValidationGroup="vsErrorBuildingAffected" />
    <input id="hdnControlIDsLossInfoBuilding" runat="server" type="hidden" />
    <input id="hdnErrorMsgsLossInfoBuilding" runat="server" type="hidden" />

    <asp:CustomValidator ID="CustomValidatorLossInfoWitness" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFieldsLossInfoWitness"
        Display="None" ValidationGroup="vsErrorWitness" />
    <input id="hdnControlIDsLossInfoWitness" runat="server" type="hidden" />
    <input id="hdnErrorMsgsLossInfoWitness" runat="server" type="hidden" />

    <asp:CustomValidator ID="CustomValidatorComments" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFieldsComments"
        Display="None" ValidationGroup="vsCommentGroup" />
    <input id="hdnControlIDsComments" runat="server" type="hidden" />
    <input id="hdnErrorMsgsComments" runat="server" type="hidden" />

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
