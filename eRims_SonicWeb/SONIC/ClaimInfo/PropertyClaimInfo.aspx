<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="PropertyClaimInfo.aspx.cs"
    Inherits="SONIC_PropertyClaimInfo" Title="Claim Information :: Property" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Src="~/Controls/SONICtab/SonicTab.ascx" TagName="CtlSonicTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/ClaimTab/ClaimTab.ascx" TagName="CtlClaimTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/SONICInfo/SonicInfo.ascx" TagName="CtlSonicInfo" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment_Property_Claims/Attachment.ascx" TagName="Attachment" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachments/Attachment.ascx" TagName="CtlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/AttachmentDetails/AttachmentDetails.ascx" TagName="CtlAttachmentDetail"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/SonicClaimNotes/SonicNotes.ascx" TagName="ctrlSonicNotes"
    TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery.maskedinput.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Date_Validation.js"></script>
    <script type="text/javascript" language="javascript">
        var currIndex = 1;
        var mode = '<%= Mode.ToUpper() %>';

        function ShowPrevNext(index) {
            ShowPanel(parseInt(currIndex, 10) + parseInt(index, 10));
        }

        //check Date Validation
        function CheckDate(sender, args) {
            args.IsValid = (ValidateDate(args.Value));
            return args.IsValid;
        }

        function ShowPanel(index) {
            currIndex = index;
            SetMenuStyle(index);

            if (index == 1 && mode == 'VIEW') {
                document.getElementById("<%=pnlLocationContact.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlLossInformation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlComments.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlSonicNotes.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlEditLocationContact.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlEditLossInformation.ClientID%>").style.display = "none";

                showViewableControls(false);

                document.getElementById("btnPrev").style.display = "none";
                document.getElementById("btnNext").style.display = "block";
            }
            if (index == 2 && mode == 'VIEW') {
                document.getElementById("<%=pnlLocationContact.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlLossInformation.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlComments.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlSonicNotes.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlEditLocationContact.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlEditLossInformation.ClientID%>").style.display = "none";

                document.getElementById("btnPrev").style.display = "block";
                document.getElementById("btnNext").style.display = "block";
                showViewableControls(false);
            }
            if (index == 3) {
                document.getElementById("<%=pnlLocationContact.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlLossInformation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlComments.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlSonicNotes.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlEditLocationContact.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlEditLossInformation.ClientID%>").style.display = "none";

                document.getElementById("btnPrev").style.display = "block";
                document.getElementById("btnNext").style.display = "block";
                showViewableControls(false);
            }
            if (index == 4) {
                document.getElementById("<%=pnlLocationContact.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlLossInformation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlComments.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlSonicNotes.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlEditLocationContact.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlEditLossInformation.ClientID%>").style.display = "none";

                document.getElementById("btnPrev").style.display = "block";
                document.getElementById("btnNext").style.display = "none";
                if (mode == "EDIT")
                    showViewableControls(true);
                else
                    showViewableControls(false);
            }
            if (index == 1 && mode == 'EDIT') {
                document.getElementById("<%=pnlLocationContact.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlLossInformation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlComments.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlSonicNotes.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlEditLocationContact.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlEditLossInformation.ClientID%>").style.display = "none";

                document.getElementById("btnPrev").style.display = "none";
                document.getElementById("btnNext").style.display = "block";
            }

            if (index == 2 && mode == 'EDIT') {
                document.getElementById("<%=pnlLocationContact.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlLossInformation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlComments.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlSonicNotes.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlEditLocationContact.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlEditLossInformation.ClientID%>").style.display = "block";

                document.getElementById("btnPrev").style.display = "block";
                document.getElementById("btnNext").style.display = "block";
            }

        }

        function showViewableControls(isEditable) {
            if (isEditable) {
                $('#divtxtDate_Report_Completed').show();
                $('#divtxtDate_Claim_Closed').show();
                $('#divtxtCommentsEdit').show();
                $('#divtxtComments').hide();
                document.getElementById('<%= btnSaveComments.ClientID %>').style.display = "block";
                document.getElementById('<%= lblDateReportComplete.ClientID %>').style.display = "none";
                document.getElementById('<%= lblDateClaimClosed.ClientID %>').style.display = "none";
                document.getElementById('<%= txtCommentsEdit.ClientID %>').style.display = "block";
                document.getElementById('<%= txtComments.ClientID %>').style.display = "none";
            }
            else {
                $('#divtxtDate_Report_Completed').hide();
                $('#divtxtDate_Claim_Closed').hide();
                $('#divtxtCommentsEdit').hide();
                $('#divtxtComments').show();
                document.getElementById('<%= btnSaveComments.ClientID %>').style.display = "none";
                document.getElementById('<%= txtCommentsEdit.ClientID %>').style.display = "none";
                document.getElementById('<%= txtComments.ClientID %>').style.display = "block";
                document.getElementById('<%= lblDateReportComplete.ClientID %>').style.display = "block";
                document.getElementById('<%= lblDateClaimClosed.ClientID %>').style.display = "block";
            }

        }

        function SetMenuStyle(index) {
            var i;
            for (i = 1; i <= 4; i++) {
                var tb = document.getElementById("WCMenu" + i);
                if (i == index) {
                    tb.className = "C_LeftMenuSelected";
                    tb.onmouseover = function () { this.className = 'C_LeftMenuSelected'; }
                    tb.onmouseout = function () { this.className = 'C_LeftMenuSelected'; }
                }
                else {
                    tb.className = "C_LeftMenuStatic";
                    tb.onmouseover = function () { this.className = 'C_LeftMenuHover'; }
                    tb.onmouseout = function () { this.className = 'C_LeftMenuStatic'; }
                }

            }
        }

        function CheckSelectedSonicNotes(buttonType) {
            var ctrls = document.getElementsByTagName('input');
            var i, chkID;
            var cnt = 0;
            chkID = "chkSelectSonicNotes";
            for (i = 0; i < ctrls.length; i++) {
                if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf(chkID) > 0) {
                    if (ctrls[i].checked)
                        cnt++;
                }
            }

            if (cnt == 0) {
                if (buttonType == "View")
                    alert("Please select Note(s) to View");
                else
                    alert("Please select Note(s) to Print");

                return false;
            }
            else {
                return true;
            }
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
            document.getElementById('<%=txtTotalEstCost.ClientID %>').innerText = InsertCommas(TotalEst.toFixed(2));
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

            document.getElementById('<%=txtTotalActualCost.ClientID %>').innerText = InsertCommas(TotalActual.toFixed(2));
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

        jQuery(function ($) {
            $("#<%=txtDate_Reported_To_Sonic.ClientID%>").mask("99/99/9999");
            //$("#<%=txtContactFaxNumber.ClientID%>").mask("999-999-9999");
            //$("#<%=txtContact_Best_Time.ClientID%>").mask("99:99");
            $("#<%=txtDate_Of_Loss.ClientID%>").mask("99/99/9999");
            //$("#<%=txtTime_Of_Loss.ClientID%>").mask("99:99");
            $("#<%=txtDate_Cleanup_Complete.ClientID%>").mask("99/99/9999");
            $("#<%=txtDate_Repairs_Complete.ClientID%>").mask("99/99/9999");
            $("#<%=txtDate_Full_Service_Resumed.ClientID%>").mask("99/99/9999");
            $("#<%=txtDate_Fire_Protection_Services_Resumed.ClientID%>").mask("99/99/9999");
        });

        //OPen Audit Popup
        function AuditPopUpForBuilding(id) {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;

            obj = window.open("<%= AppConfig.SiteURL %>/SONIC/FirstReport/AuditPopup_Property_FR_Building.aspx?id=" + id, 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }

        //OPen Audit Popup
        function AuditPopUpForWitness(id) {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;

            obj = window.open("<%= AppConfig.SiteURL %>/SONIC/FirstReport/AuditPopup_Property_FR_Witness.aspx?id=" + id, 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }

        //OPen Audit Popup
        function AuditPopUp() {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;

            obj = window.open("<%= AppConfig.SiteURL %>/SONIC/FirstReport/AuditPopup_PropertyFirstReport.aspx?id=" + '<%=ViewState["PK_Prop_FR_ID"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }

        function setCaretPosition(elem, caretPos) {
            var range;
            elem = document.getElementById('ctl00_ContentPlaceHolder1_txtTime_Of_Loss');
            if (elem.createTextRange) {
                range = elem.createTextRange();
                range.move('character', caretPos);
                range.select();
            } else {
                elem.focus();
                if (elem.selectionStart !== undefined) {
                    elem.setSelectionRange(caretPos, caretPos);
                }
            }
        }

    </script>
    <asp:ValidationSummary ID="vsAttchments" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields in Comments/Attachment Panel:" BorderWidth="1"
        BorderColor="DimGray" ValidationGroup="AddClaimAttachment" CssClass="errormessage"></asp:ValidationSummary>

    <asp:ValidationSummary ID="vsLossError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields in Loss Panel:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsLossInfoGroup" CssClass="errormessage"></asp:ValidationSummary>

    <asp:ValidationSummary ID="vsSummaryProofOfLoss" runat="server" ShowSummary="false"
        ShowMessageBox="true" HeaderText="Verify the following fields in Attachment:"
        BorderWidth="1" BorderColor="DimGray" ValidationGroup="vsProofOfLoss" CssClass="errormessage"></asp:ValidationSummary>

    <asp:ValidationSummary ID="vsContactInfo" runat="server" ShowSummary="false"
        ShowMessageBox="true" HeaderText="Verify the following fields in Attachment:"
        BorderWidth="1" BorderColor="DimGray" ValidationGroup="vsContactInfoGroup" CssClass="errormessage"></asp:ValidationSummary>
    

    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100%" style="height: 50px;" valign="bottom" colspan="2">
                <uc:CtlClaimTab runat="server" ID="ClaimTab" />
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
                                    <table style="background-color: black" cellspacing="1" cellpadding="3" width="100%"
                                        border="0">
                                        <tbody>
                                            <tr class="PropertyInfoBG">
                                                <td style="width: 18%" align="left">
                                                    <asp:Label ID="lblHeaderClaimNumber" runat="server" Text="Claim Number"></asp:Label>
                                                </td>
                                                <td style="width: 18%" align="left">
                                                    <asp:Label ID="lblHeaderLocationdba" runat="server" Text="SONIC Location d/b/a"></asp:Label>
                                                </td>
                                                <td style="display: none; width: 18%" id="tdHeaderName" align="left" runat="server">
                                                    <asp:Label ID="lblHeaderName" runat="server" Text="Name"></asp:Label>
                                                </td>
                                                <td style="width: 18%" align="left">
                                                    <asp:Label ID="lblHeaderDateLoss" runat="server" Text="Date of Loss"></asp:Label>
                                                </td>
                                                <td style="width: 28%" align="left">
                                                    <asp:Label ID="lblHeaderAssociatedFirstReport" runat="server" Text="Associated First Report"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr style="background-color: white">
                                                <td align="left">
                                                    <asp:Label ID="lblClaimNumber" runat="server">&nbsp; </asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblLocationdba" runat="server"> </asp:Label>
                                                </td>
                                                <td style="display: none" id="tdName" align="left" runat="Server">
                                                    <asp:Label ID="lblName" runat="server"> </asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblDateIncident" runat="server"> </asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:LinkButton ID="lnkAssociatedFirstReport" runat="server" OnClick="lnkAssociatedFirstReport_Click"></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
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
                                        <table cellpadding="5" cellspacing="0" border="0" width="100%">
                                            <tr>
                                                <td>
                                                    <span id="WCMenu1" href="#" onclick="javascript:ShowPanel('1');">Location/Contact</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span id="WCMenu2" href="#" onclick="javascript:ShowPanel('2');">Loss Information</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span id="WCMenu3" href="#" onclick="javascript:ShowPanel('3');">Sonic Notes</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span id="WCMenu4" href="#" onclick="javascript:ShowPanel('4');">Comments
                                                        <br />
                                                        <br />
                                                        Attachments</span>
                                                </td>
                                            </tr>
                                        </table>
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
                                        <div id="dvView" runat="server" style="width: 100%;">
                                            <asp:Panel ID="pnlLocationContact" runat="server" Width="100%">
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="20%">Location RM Number
                                                        </td>
                                                        <td align="center" width="4%">:
                                                        </td>
                                                        <td align="left" width="26%">
                                                            <asp:Label runat="server" ID="lblLocationRMNumber" />
                                                        </td>
                                                        <td align="left" width="20%">Claim Number
                                                        </td>
                                                        <td align="center" width="4%">:
                                                        </td>
                                                        <td align="left" width="26%">
                                                            <asp:Label runat="server" ID="lblClaimNumberAgain" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Address1
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblAddress1" />
                                                        </td>
                                                        <td align="left">
                                                            <b>Contact Information</b>
                                                        </td>
                                                        <td align="center"></td>
                                                        <td align="left"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Address 2
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblAddress2" />
                                                        </td>
                                                        <td align="left">Location DBA
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblLocationDBAAgain" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">City
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblCity" />
                                                        </td>
                                                        <td align="left">Name
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblEmployeeName" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">State
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblState" />
                                                        </td>
                                                        <td align="left">Address1
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblEmployeeAddress1" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Zip
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblZip" />
                                                        </td>
                                                        <td align="left">Address 2
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblEmployeeAddress2" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Date of Loss
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblDateofLoss" />
                                                        </td>
                                                        <td align="left">City
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblEmployeeCity" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Time of Loss
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblTimeofLoss" />
                                                        </td>
                                                        <td align="left">State
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblEmployeeState" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Date Reported to Sonic
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblDateReportedtoSonic" />
                                                        </td>
                                                        <td align="left">Zip
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblEmployeeZip" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"></td>
                                                        <td align="center"></td>
                                                        <td align="left"></td>
                                                        <td align="left">Time to Contact
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblTimetoContact" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"></td>
                                                        <td align="center"></td>
                                                        <td align="left"></td>
                                                        <td align="left">Telephone Number 1
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblEmployeeWorkPhone" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"></td>
                                                        <td align="center"></td>
                                                        <td align="left"></td>
                                                        <td align="left">Telephone Number 2
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblEmployeeCellPhone" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"></td>
                                                        <td align="center"></td>
                                                        <td align="left"></td>
                                                        <td align="left">Fax
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblFax" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"></td>
                                                        <td align="center"></td>
                                                        <td align="left"></td>
                                                        <td align="left">Email address
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblEmployeeEmail" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlLossInformation" runat="server" Width="100%" Style="display: none;">
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="31%">Time of Loss
                                                        </td>
                                                        <td align="center" width="4%">:
                                                        </td>
                                                        <td align="left" width="65%">
                                                            <asp:Label runat="server" ID="lblLossInfoTimeofLoss" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <b>Building Affected</b>
                                                        </td>
                                                        <td align="center"></td>
                                                        <td align="left"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="3">
                                                            <div id="divBuildingAffected" style="width: 99%; height: 100px; overflow-y: scroll; overflow-x: hidden; border: solid 1px #000000;">
                                                                <asp:GridView ID="gvBuildingAffected" runat="server" AutoGenerateColumns="false"
                                                                    Width="98%">
                                                                    <HeaderStyle HorizontalAlign="center" />
                                                                    <Columns>
                                                                        <asp:BoundField ControlStyle-Width="20%" HeaderText="Occupancy" DataField="Occupancy" />
                                                                        <asp:TemplateField ControlStyle-Width="20%" HeaderText="Address">
                                                                            <ItemTemplate>
                                                                                <%#Eval("Address_1") %>
                                                                                &nbsp;
                                                                                <%#Eval("Address_2") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField ControlStyle-Width="20%" HeaderText="City" DataField="City" />
                                                                        <asp:TemplateField HeaderText="State">
                                                                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                                            <ItemTemplate>
                                                                                <%# new ERIMS.DAL.State((Eval("State") != null) ? Convert.ToDecimal(Eval("State")) : 0).FLD_state%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField ControlStyle-Width="20%" HeaderText="Zip" DataField="Zip" />
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
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <b>Witnesses</b>
                                                        </td>
                                                        <td align="center"></td>
                                                        <td align="left"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="3">
                                                            <div id="divWitnesses" style="width: 99%; height: 100px; overflow-y: scroll; overflow-x: hidden; border: solid 1px #000000;">
                                                                <asp:GridView ID="gvWitnesses" runat="server" AutoGenerateColumns="false" Width="98%">
                                                                    <HeaderStyle HorizontalAlign="center" />
                                                                    <Columns>
                                                                        <asp:BoundField ControlStyle-Width="20%" HeaderText="Name" DataField="Name" />
                                                                        <asp:TemplateField ControlStyle-Width="20%" HeaderText="Address">
                                                                            <ItemTemplate>
                                                                                <%#Eval("Address_1") %>
                                                                                &nbsp;
                                                                                <%#Eval("Address_2") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField ControlStyle-Width="20%" HeaderText="City" DataField="City" />
                                                                        <asp:TemplateField HeaderText="State">
                                                                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                                            <ItemTemplate>
                                                                                <%# new ERIMS.DAL.State((Eval("State") != null) ? Convert.ToDecimal(Eval("State")) : 0).FLD_state%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField ControlStyle-Width="20%" HeaderText="Zip" DataField="Zip" />
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
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <b>Type of Loss</b>
                                                        </td>
                                                        <td align="center"></td>
                                                        <td align="left"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="3">
                                                            <table cellpadding="3" cellspacing="1" border="0" width="70%">
                                                                <tr>
                                                                    <td align="left" width="50%">
                                                                        <asp:CheckBox ID="chkFire" runat="server" Text="Fire" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" width="50%">
                                                                        <asp:CheckBox ID="chkDamageBySonicAssociates" runat="server" Text="Property Damage By Sonic Associates"
                                                                            Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="50%">
                                                                        <asp:CheckBox ID="chkWindDamage" runat="server" Text="Wind Damage" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" width="50%">
                                                                        <asp:CheckBox ID="chkEnvironmetalLoss" runat="server" Text="Environmetal Loss" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="50%">
                                                                        <asp:CheckBox ID="chkHallDamage" runat="server" Text="Hall Damage" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" width="50%">
                                                                        <asp:CheckBox ID="chkVandalismtotheProperty" runat="server" Text="Vandalism to the Property"
                                                                            Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="50%">
                                                                        <asp:CheckBox ID="chkEarthMovement" runat="server" Text="Earth Movement" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" width="50%">
                                                                        <asp:CheckBox ID="chkTheftAssociateTools" runat="server" Text="Theft - Associate Tools"
                                                                            Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="50%">
                                                                        <asp:CheckBox ID="chkFlood" runat="server" Text="Flood" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" width="50%">
                                                                        <asp:CheckBox ID="chkTheftAllOther" runat="server" Text="Theft - All Other" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="50%">
                                                                        <asp:CheckBox ID="chkThirdPartyPropertyDamage" runat="server" Text="Third Party Property Damage"
                                                                            Enabled="false" />
                                                                    </td>
                                                                    <td align="left" width="50%">
                                                                        <asp:CheckBox ID="chkOther" runat="server" Text="Other" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <b>Description of Loss</b>
                                                        </td>
                                                        <td align="center"></td>
                                                        <td align="left"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="3">
                                                            <%-- <asp:TextBox ID="txtDescriptionofLoss" TextMode="MultiLine" Rows="4" runat="server"
                                                                ReadOnly="true" Width="100%" />--%>
                                                            <uc:ctrlMultiLineTextBox ID="txtDescriptionofLoss" runat="server" MaxLength="4000"
                                                                ControlType="Label" Width="790" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <b>Damages</b>
                                                        </td>
                                                        <td align="center"></td>
                                                        <td align="left"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="3">
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td width="31%"></td>
                                                                    <td align="center" width="4%"></td>
                                                                    <td align="center">
                                                                        <b>Estimated Cost</b>
                                                                    </td>
                                                                    <td align="center">
                                                                        <b>Actual Cost</b>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="31%">Buildings and Facilities
                                                                    </td>
                                                                    <td align="center" width="4%">:
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblDamageBuildingFacilitiesEstCost" />
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblDamageBuildingFacilitiesActualCost" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Equipment
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblDamageEquipmentEstCost" />
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblDamageEquipmentActualCost" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Product Damage
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblDamageProductDamageEstCost" />
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblDamageProductDamageActualCost" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Parts
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblDamagePartsEstCost" />
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblDamagePartsActualCost" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Salvage and Cleanup Expenses including labor
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblDamageSalvageCleanupEstCost" />
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblDamageSalvageCleanupActualCost" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Decontamination Expenses
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblDamageDecontaminationEstCost" />
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblDamageDecontaminationActualCost" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Electronic Data/Processing Media
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblDamageElectronicDataEstCost" />
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblDamageElectronicDataActualCost" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Service Interruption
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblDamageServiceInterruptionEstCost" />
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblDamageServiceInterruptionActualCost" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Ordinary Payroll
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblDamagePayrollEstCost" />
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblDamagePayrollActualCost" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Loss of Sales
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblDamageLossofSalesEstCost" />
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblDamageLossofSalesActualCost" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <b>TOTAL</b>
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblTotalEstimatedCost" />
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblTotalActualCoat" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <b>Proof of Loss</b>
                                                        </td>
                                                        <td align="center"></td>
                                                        <td align="left"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="3">
                                                            <div id="divProofOfLoss" style="width: 99%; border: solid 1px #000000;">
                                                                <asp:GridView ID="gvProofOfLosses" runat="server" DataKeyNames="" OnRowDataBound="gvProofOfLosses_RowDataBound"
                                                                    AutoGenerateColumns="false" Width="100%" AllowSorting="false">
                                                                    <Columns>
                                                                        <asp:TemplateField ControlStyle-Width="20%" HeaderText="Date">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblDate" runat="server"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ControlStyle-Width="20%" HeaderText="Partial or Final">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblDescription" runat="server"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ControlStyle-Width="20%" HeaderText="Amount $">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblAmount" runat="server"></asp:Label>
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
                                                            </div>
                                                        </td>
                                                    </tr>

                                                    <tr height="20px">
                                                        <td colspan="3"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Date Clean-up or Salvage Operations Completed
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblDateCleanupComplete" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Date Equipment/Building Repairs Complete
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblDateRepairsComplete" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Date Full Services Resumed
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblDateFullServiceResumed" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">Date Fire Protection Services Resumed
                                                        </td>
                                                        <td align="center">:
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblDateFireProtectionServicesResumed" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlComments" runat="server" Width="100%" Style="display: none;">

                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="31%">
                                                            <b>Comments</b>
                                                        </td>
                                                        <td align="center" width="4%"></td>
                                                        <td align="left" width="65%"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="3">
                                                            <%--<asp:TextBox TextMode="MultiLine" ID="" Rows="4" runat="server" Width="100%"
                                                                ReadOnly="true" />--%>
                                                            <div id="divtxtComments">
                                                                <uc:ctrlMultiLineTextBox ID="txtComments" runat="server" MaxLength="4000" ControlType="Label"
                                                                    Width="790" />
                                                            </div>
                                                            <div id="divtxtCommentsEdit">
                                                                <uc:ctrlMultiLineTextBox ID="txtCommentsEdit" runat="server" MaxLength="4000" ControlType="TextBox"
                                                                    Width="790" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="31%">Date Report Completed
                                                        </td>
                                                        <td align="center" width="4%">:
                                                        </td>
                                                        <td align="left" width="65%">
                                                            <asp:Label ID="lblDateReportComplete" runat="server" />
                                                            <div id="divtxtDate_Report_Completed">
                                                                <asp:TextBox ID="txtDate_Report_Completed" runat="server" SkinID="txtDate"></asp:TextBox>
                                                                <img alt="Date Report Completed" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Report_Completed', 'mm/dd/y',function(){},'ctl00_ContentPlaceHolder1_txtDate_Report_Completed');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" /><br />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtDate_Report_Completed"
                                                                    ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                    ErrorMessage="Date Reported Complete is not valid." Display="none" ValidationGroup="vsLossInfoGroup"></asp:RegularExpressionValidator>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="31%">Date Claim Closed
                                                        </td>
                                                        <td align="center" width="4%">:
                                                        </td>
                                                        <td align="left" width="65%">
                                                            <asp:Label ID="lblDateClaimClosed" runat="server" />
                                                            <div id="divtxtDate_Claim_Closed">
                                                                <asp:TextBox ID="txtDate_Claim_Closed" runat="server" SkinID="txtDate"></asp:TextBox>
                                                                <img alt="Date Report Completed" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Claim_Closed', 'mm/dd/y',function(){},'ctl00_ContentPlaceHolder1_txtDate_Claim_Closed');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" /><br />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtDate_Claim_Closed"
                                                                    ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                    ErrorMessage="Date Claim Closed is not valid." Display="none" ValidationGroup="vsLossInfoGroup"></asp:RegularExpressionValidator>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trSaveComment">
                                                        <td colspan="6" align="center">
                                                            <asp:Button runat="server" ID="btnSaveComments" Text="Save & Continue" OnClick="btnSaveComments_Click"
                                                                ValidationGroup="vsLossInfoGroup" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="31%">
                                                            <b>Attachments</b>
                                                        </td>
                                                        <td align="center" width="4%"></td>
                                                        <td align="left" width="65%"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="3">Click to view<br />
                                                            <uc:Attachment ID="ucAttachment" runat="server" Attachment_Table="Property_Claims" MajorCoverage="Property_Claims" ReadOnly="false" />
                                                            <%--<uc:CtlAttachment ID="CtrlAttachment_Cliam" runat="server" />
                                                            <uc:CtlAttachmentDetail ID="CtlAttachDetail_Cliam" runat="server" IntAttachmentPanel="3" />--%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlSonicNotes" runat="server" Style="display: none;">
                                                <table border="0" cellpadding="1" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="100%" align="left">
                                                            <uc:ctrlSonicNotes ID="ctrlSonicNotes" runat="server" IsAddVisible="true" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <%--<div class="bandHeaderRow">
                                                    Sonic Notes</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td valign="top" style="width: 15%">
                                                            Sonic Notes Grid<br />
                                                            <asp:LinkButton ID="btnNotesAdd" runat="server" ValidationGroup="vsError" Text="--Add--"
                                                                OnClick="btnNotesAdd_Click"></asp:LinkButton>
                                                        </td>
                                                        <td align="center" valign="top" style="width: 3%">
                                                            :
                                                        </td>
                                                        <td style="margin-left: 40px" style="width: 650px">
                                                            <asp:GridView ID="gvNotes" runat="server" AutoGenerateColumns="false" Width="100%"
                                                                OnRowCommand="gvNotes_RowCommand">
                                                                <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                                <EmptyDataTemplate>
                                                                    <asp:Label ID="lblEmptyEmergencyMessage" runat="server" Text="No Record Found"></asp:Label>
                                                                </EmptyDataTemplate>
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-Width="12%" HeaderStyle-VerticalAlign="Top">
                                                                        <HeaderTemplate>
                                                                            <input type="checkbox" id="chkMultiSelectSonicNotes" onclick="SelectDeselectAllSonicNotes(this.checked);" />Select
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="chkSelectSonicNotes" runat="server" onclick="SelectDeselectNoteHeader();" />
                                                                            <input type="hidden" id="hdnPK" runat="server" value='<%#Eval("PK_Claim_Notes") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                        HeaderText="Note Date">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbtNote_Date" runat="server" Text='<%# string.Format("{0:MM/dd/yyyy}", Eval("Note_Date")) %>'
                                                                                CommandName="EditRecord" CommandArgument='<%#Eval("PK_Claim_Notes") %>' Width="80px"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                        HeaderText="User">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbtUser_Name" runat="server" Text='<%# Eval("User_Name") %>'
                                                                                CommandName="EditRecord" CommandArgument='<%#Eval("PK_Claim_Notes") %>' Width="100px"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                        HeaderText="Notes">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbtNotes" runat="server" Text='<%# Eval("Note") %>' CommandName="EditRecord"
                                                                                CommandArgument='<%#Eval("PK_Claim_Notes") %>' Width="310px" CssClass="TextClip"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                        HeaderText="Remove">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbtDelete" runat="server" Text="Remove" CommandName="Remove"
                                                                                CommandArgument='<%#Eval("PK_Claim_Notes") %>' OnClientClick="javascript:return confirm('Are you sure you want delete selected record?');"
                                                                                Width="80px"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" align="center">
                                                            <asp:Button ID="btnView" runat="server" Text=" View " OnClick="btnView_Click" OnClientClick="return CheckSelectedSonicNotes('View');" />&nbsp;&nbsp;
                                                            <asp:Button ID="btnPrint" runat="server" Text=" Print " OnClick="btnPrint_Click"
                                                                OnClientClick="return CheckSelectedSonicNotes('Print');" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>--%>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlEditLocationContact" runat="server" Width="100%">
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
                                                                    <asp:DropDownList runat="server" ID="ddlLocationNumber" SkinID="ddlSONIC" Enabled="false">
                                                                    </asp:DropDownList>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td align="left">Address 1
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox ID="txtLocationAddress1" Width="170px" runat="server" MaxLength="50" Enabled="false">
                                                                    </asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Address 2
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox ID="txtLocationAddress2" Width="170px" runat="server" MaxLength="50" Enabled="false">
                                                                    </asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">City
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox ID="txtLocationCity" runat="server" Width="170px" MaxLength="30" Enabled="false"></asp:TextBox>
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
                                                                    <asp:TextBox ID="txtLocationZipCode" runat="server" Width="170px" MaxLength="10" Enabled="false"></asp:TextBox>
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
                                                                    <asp:TextBox runat="server" ID="txtCostCenterdba" Width="170px" Enabled="false"></asp:TextBox>
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
                                                                    <asp:TextBox runat="server" ID="txtContactName" Width="170px" Enabled="false"></asp:TextBox>
                                                                </td>
                                                                <td align="left">Address 1
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtCostCenterAddress1" Width="170px" Enabled="false"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">When to Contact&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtContact_Best_Time" Width="170px"></asp:TextBox>
                                                                    <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" AcceptNegative="Left"
                                                                        DisplayMoney="Left" Mask="99:99" MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                        AcceptAMPM="false" OnInvalidCssClass="MaskedEditError" TargetControlID="txtContact_Best_Time"
                                                                        CultureName="en-US" AutoComplete="false" ClearMaskOnLostFocus="true">
                                                                    </cc1:MaskedEditExtender>
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
                                                                    <asp:TextBox runat="server" ID="txtCostCenterAddress2" Width="170px" Enabled="false"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Telephone Number 1<br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtContactTelephoneNumber1" Width="170px" Enabled="false"></asp:TextBox>
                                                                </td>
                                                                <td align="left">City
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtCostCenterCity" Width="170px" Enabled="false"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Telephone Number 2<br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtContactTelephoneNumber2" Width="170px" Enabled="false"></asp:TextBox>
                                                                </td>
                                                                <td align="left">State
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtCostCenterState" Width="170px" Enabled="false"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Fax Number&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span><br />
                                                                    (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtContactFaxNumber" Width="170px" runat="server" MaxLength="12" onKeyPress="javascript:return FormatPhone(event,this.id);">
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
                                                                    <asp:TextBox runat="server" ID="txtCostCenterZipCode" Width="170px" Enabled="false"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Email Address
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox ID="txtContactEmailAddress" runat="server" Width="170px" MaxLength="30" Enabled="false"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Date Reported to Sonic&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">:
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox ID="txtDate_Reported_To_Sonic" runat="server" SkinID="txtDate"></asp:TextBox>
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
                                            <asp:Panel ID="pnlEditLossInformation" Width="100%" runat="server">
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
                                                                    <asp:TextBox ID="txtDate_Of_Loss" runat="server" SkinID="txtDate"></asp:TextBox>
                                                                    <img alt="Date of Loss" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Of_Loss', 'mm/dd/y',CompareDateLessThanToday,'ctl00_ContentPlaceHolder1_txtDate_Of_Loss');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" /><br />
                                                                    <asp:RegularExpressionValidator ID="revtxtDate_Of_Loss" runat="server" ControlToValidate="txtDate_Of_Loss"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                        ErrorMessage="Date Reported to Sonic is not valid." Display="none" ValidationGroup="vsLossInfoGroup"></asp:RegularExpressionValidator>

                                                                </td>
                                                                <td align="left" style="width: 18%">Time of Loss(HH:MM)&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" style="width: 4%">:
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:TextBox runat="Server" ID="txtTime_Of_Loss" Width="170px"></asp:TextBox>
                                                                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AcceptNegative="Left"
                                                                        DisplayMoney="Left" Mask="99:99" MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                        AcceptAMPM="false" OnInvalidCssClass="MaskedEditError" TargetControlID="txtTime_Of_Loss"
                                                                        CultureName="en-US" AutoComplete="false" ClearMaskOnLostFocus="true">
                                                                    </cc1:MaskedEditExtender>
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
                                                                                        <asp:GridView ID="gvBUilding" runat="server" DataKeyNames="PK_Property_Claims_Building_ID"
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
                                                                                        <asp:GridView ID="gvWitness" runat="server" DataKeyNames="PK_Property_Claims_Witness_ID"
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
                                                                                <asp:CheckBox runat="server" ID="chkFireEdit" Text="Fire" />
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
                                                                                <asp:CheckBox runat="server" ID="chkFloodEdit" Text="Flood" />
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
                                                                                <asp:CheckBox runat="server" ID="chkOtherEdit" Text="Other" />
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
                                                                                <asp:TextBox runat="server" ID="txtTotalEstCost" Width="170px" ReadOnly="true"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox runat="server" ID="txtTotalActualCost" Width="170px" ReadOnly="true"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Proof of Loss<br />
                                                                    <asp:LinkButton ID="lnkAddProofOfLoss" runat="server" Text="--Add--" OnClick="lnkAddProofOfLoss_Click" />
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td colspan="4" valign="top">
                                                                    <asp:UpdatePanel runat="server" ID="upProofOfLoss">
                                                                        <ContentTemplate>
                                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                <tr>
                                                                                    <td colspan="4">
                                                                                        <asp:GridView ID="gvProofOfLoss" runat="server" DataKeyNames="PK_Property_Claims_Proof_Of_Loss" AutoGenerateColumns="false" Width="100%" AllowSorting="false"
                                                                                            OnRowCommand="gvProofOfLoss_RowCommand" OnRowDataBound="gvProofOfLoss_RowDataBound" OnRowEditing="gvProofOfLoss_RowEditing">
                                                                                            <Columns>
                                                                                                <asp:TemplateField HeaderText="Date">
                                                                                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton ID="lnkDate" runat="server" CommandName="edit"></asp:LinkButton>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Partial or Final">
                                                                                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton ID="lnkDescription" runat="server" CommandName="edit"></asp:LinkButton>
                                                                                                        <asp:Label ID="lblDescription" runat="server"></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Amount $">
                                                                                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton ID="lnkAmount" runat="server" CommandName="edit"></asp:LinkButton>
                                                                                                        <asp:Label ID="lblAmount" runat="server"></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Remove">
                                                                                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton ID="lnkRemoveProofOfLoss" runat="server" Text="Remove" CommandName="remove"></asp:LinkButton>
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
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6">
                                                                    <table width="100%" runat="server" id="tblAddEditProofOfLoss" style="display: none">
                                                                        <tr>
                                                                            <td colspan="6">
                                                                                <div class="bandHeaderRow">
                                                                                    Proof Of Loss   
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>&nbsp;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="20%">Date</td>
                                                                            <td width="2%">:</td>
                                                                            <td width="25%">
                                                                                <asp:TextBox ID="txtProofOfLossDate" runat="server"></asp:TextBox>
                                                                                <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" AcceptNegative="Left"
                                                                                    DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                                    AcceptAMPM="false" OnInvalidCssClass="MaskedEditError" TargetControlID="txtProofOfLossDate"
                                                                                    CultureName="en-US" AutoComplete="false" ClearMaskOnLostFocus="true">
                                                                                </cc1:MaskedEditExtender>
                                                                                <img alt="Date of Loss" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtProofOfLossDate', 'mm/dd/y',function(){},'ctl00_ContentPlaceHolder1_txtProofOfLossDate');"
                                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                                    align="middle" /><br />
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtProofOfLossDate"
                                                                                    ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                                    ErrorMessage="Date proof of loss is not valid." Display="none" ValidationGroup="vsProofOfLoss"></asp:RegularExpressionValidator>
                                                                            </td>
                                                                            <td width="20%">Type</td>
                                                                            <td width="2%">:</td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlProofOfLossType" runat="server">
                                                                                    <asp:ListItem Text="--Select--"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>Amount</td>
                                                                            <td>:</td>
                                                                            <td>$<asp:TextBox ID="txtProofOfLossAmount" runat="server" onkeypress="return currencyFormat(this,',','.',event);"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td></td>
                                                                            <td></td>
                                                                            <td align="center">
                                                                                <asp:Button ID="btnProofOfLossSave" runat="server" Text="Save" OnClick="btnProofOfLossSave_Click" ValidationGroup="vsProofOfLoss" />
                                                                            </td>
                                                                            <td align="center">
                                                                                <asp:Button ID="btnProofOfLossCancel" runat="server" Text="Cancel" OnClick="btnProofOfLossCancel_Click" />
                                                                            </td>
                                                                            <td></td>
                                                                            <td></td>
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
                                                                    <asp:TextBox ID="txtDate_Cleanup_Complete" runat="server" Width="170px" SkinID="txtDate" onblur="javascript:return checkYearRange(this.id);"></asp:TextBox>
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
                                                                    <asp:TextBox runat="server" ID="txtDate_Repairs_Complete" Width="170px" SkinID="txtDate" onblur="javascript:return checkYearRange(this.id);"></asp:TextBox>
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
                                                                    <asp:TextBox runat="server" ID="txtDate_Full_Service_Resumed" Width="170px" SkinID="txtDate" onblur="javascript:return checkYearRange(this.id);"></asp:TextBox>
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
                                                                    <asp:TextBox runat="server" ID="txtDate_Fire_Protection_Services_Resumed" Width="170px" SkinID="txtDate"
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
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                        <td>
                            <table cellpadding="5" cellspacing="1" border="0" width="100%">
                                <tr>
                                    <td align="right" width="30%"></td>
                                    <td align="right">
                                        <asp:Button ID="btnEdit" runat="server" Style="font-weight: bold; color: #000080; float: left; margin: 0 0 0 15px;" Text="Edit" OnClick="btnEdit_Click" />
                                        <input type="button" id="btnPrev" value="Previous" style="font-weight: bold; color: #000080; float: left; margin: 0 0 0 15px;"
                                            onclick="javascript: ShowPrevNext(-1);" />
                                        <input type="button" id="btnNext" style="font-weight: bold; color: #000080; float: left; margin: 0 0 0 15px;" value="Next"
                                            onclick="javascript: ShowPrevNext(1);" />
                                    </td>
                                    <td align="left"></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
