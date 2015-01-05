<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FCIPolicy.aspx.cs" MasterPageFile="~/Default.master"
    Inherits="Policy_FCIPolicy" MaintainScrollPositionOnPostback="true" Title="eRIMS Sonic :: Add New Policy" %>

<%@ Register Src="~/Controls/ClaimAttachment/Attachment.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/ClaimAttachment/AttachmentDetails.ascx" TagName="ctrlAttachmentDetails"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="../JavaScript/JFunctions.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Date_Validation.js"></script>
    <link href="../App_Themes/Default/stylecal.css" type="text/css" rel="Stylesheet" />
    <script type="text/javascript">
        function checkSelected() {
            var Check = false;
            var arrElements = document.getElementsByTagName('input');
            for (i = 0; i < arrElements.length; i++) {
                if ((arrElements[i].type == 'checkbox') && (arrElements[i].checked == true) && (arrElements[i].name.indexOf('chkItem') > -1)) {
                    Check = true;
                    break;
                }
            }
            if (Check == false) {
                alert('Please check at least one check box to Delete!');
                return false;
            }
            else {
                if (confirm('Are you sure to delete ?'))
                    return true;
                else
                    return false;
            }
        }
        function CheckNumericVal(Ctl,length) {
            if (Ctl.value == "" || isNaN(Number(Ctl.value.replace(/,/g, '')) * 1) == true)
                Ctl.innerText = "";
            else {
                var len1 = Ctl.value.split(".")[0].replace(/,/g, '').length;
                if (len1 > length - 2) {
                    alert("Length is exceeded.");
                    Ctl.innerText = "";
                }
                else
                    Ctl.innerText = formatCurrency_New(Ctl.value);
            }
        }
        //check Date Validation
        function CheckDate(sender, args) {
            args.IsValid = (ValidateDate(args.Value));
            return args.IsValid;
        }
        function CheckFSR(rdo, tr) {

            var rdo1 = document.getElementById(rdo.id + "_0");
            var tr1 = document.getElementById("ctl00_ContentPlaceHolder1_fvPolicyDetails_" + tr);
            if (rdo1.checked == true) {
                tr1.style.display = "block";
            }
            else
                tr1.style.display = "none";
        }

        function ValAttach() {

            document.getElementById("ctl00_ContentPlaceHolder1_fvPolicyDetails_rfvUpload").enabled = true;
            return true;
        }

        function ValSave() {


            return true;
        }
        function openWindow(strURL) {
            oWnd = window.open(strURL, "Erims", "location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=300");
            oWnd.moveTo(260, 180);
            return false;

        }
        function openMailWindow(strURL) {
            //oWnd=window.open("Mail.aspx?AttName="+ strURL,"Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=0,toolbar=0,width=500,height=280");
            oWnd = window.open(strURL, "Erims", "location=0,status=0,scrollbars=1,menubar=0,resizable=0,toolbar=0,width=500,height=280");
            oWnd.moveTo(260, 180);
            return false;

        }
        function MinMax(name) {
            if (name == "Description") {

                if (document.getElementById("ctl00_ContentPlaceHolder1_fvPolicyDetails_txtDescription").style.height == "200px") {
                    document.getElementById("ctl00_ContentPlaceHolder1_fvPolicyDetails_ibtnAttach").src = "../Images/minus.jpg";
                    document.getElementById("ctl00_ContentPlaceHolder1_fvPolicyDetails_txtDescription").style.height = "800px";
                    document.getElementById("pnlAttach").style.display = "block";
                }
                else if (document.getElementById("ctl00_ContentPlaceHolder1_fvPolicyDetails_txtDescription").style.height == "800px") {

                    document.getElementById("ctl00_ContentPlaceHolder1_fvPolicyDetails_ibtnAttach").src = "../Images/plus.jpg";
                    document.getElementById("ctl00_ContentPlaceHolder1_fvPolicyDetails_txtDescription").style.height = "200px";
                    //document.getElementById("pnlAttach").style.display = "none";
                }
            }
            return false;
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
                        case "text":
                            if (ctrl.value == '') {
                                if (ctrl.id == 'ctl00_ContentPlaceHolder1_fvPolicyDetails_txtSharePC' || ctrl.id == 'ctl00_ContentPlaceHolder1_fvPolicyDetails_txtShareLimit') {
                                    var rdb = document.getElementById('ctl00_ContentPlaceHolder1_fvPolicyDetails_rdbQuota_0');
                                    //used to check dropdowns selected value. if it is equal to Disposed than display Disposal type control else hide.
                                    if (rdb.checked)
                                        bEmpty = true;
                                }
                                else if (ctrl.id == 'ctl00_ContentPlaceHolder1_fvPolicyDetails_txtUnderlying') {
                                    var rdb = document.getElementById('ctl00_ContentPlaceHolder1_fvPolicyDetails_rdbLayer_0');
                                    //used to check dropdowns selected value. if it is equal to Disposed than display Disposal type control else hide.
                                    if (rdb.checked)
                                        bEmpty = true;
                                }
                                else
                                    bEmpty = true;
                            } break;

                        case "select-one":
                            if (ctrl.selectedIndex == 0) {
                                if (ctrl.id == 'ctl00_ContentPlaceHolder1_fvPolicyDetails_ddlLayerNo') {
                                    var rdb = document.getElementById('ctl00_ContentPlaceHolder1_fvPolicyDetails_rdbLayer_0');
                                    //used to check dropdowns selected value. if it is equal to Disposed than display Disposal type control else hide.
                                    if (rdb.checked)
                                        bEmpty = true;
                                }
                                else if (ctrl.id == 'ctl00_ContentPlaceHolder1_fvPolicyDetails_ddlType') {
                                    var rdb = document.getElementById('ctl00_ContentPlaceHolder1_fvPolicyDetails_rdoFinancial_Security_Required_0');
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
                    document.getElementById(focusCtrlID).focus();
                }
                else
                    args.IsValid = true;
            }
            else {
                args.IsValid = true;
            }
        }
    </script>
    <script type="text/javascript">
        function ErimsUnCheckHeader() {
            var i, flag = 0;
            var chk;
            for (i = 0; i < document.forms[0].elements.length; i++) {
                if ((document.forms[0].elements[i].type == 'checkbox')) {
                    if (document.forms[0].elements[i].name != "ctl00$ContentPlaceHolder1$gvPolicyDetails$ctl01$chkHeader") {

                        if (document.forms[0].elements[i].checked == false)
                        { flag = 1; }
                    }
                }
            }
            for (i = 0; i < document.forms[0].elements.length; i++) {
                if (flag == 1) {
                    if ((document.forms[0].elements[i].type == 'checkbox')) {
                        if (document.forms[0].elements[i].name == "ctl00$ContentPlaceHolder1$gvPolicyDetails$ctl01$chkHeader") {
                            chk = document.forms[0].elements[i];
                            chk.checked = false;
                        }
                    }
                }
                else if (flag == 0) {
                    if ((document.forms[0].elements[i].type == 'checkbox'))
                        if (document.forms[0].elements[i].name == "ctl00$ContentPlaceHolder1$gvPolicyDetails$ctl01$chkHeader")
                            document.forms[0].elements[i].checked = true;
                }
            }
        }
        function AuditPopUp() {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;

            obj = window.open("PolicyAuditPopUp.aspx?id=" + '<%=Session["PolicyId"]%>' + '&Table_Name=Settlement&RandomNo=' + Math.random(), 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=0,menubar=0');
            obj.focus();
            return false;
        }
    </script>
    <script language="javascript" type="text/javascript">

        function LayerChange() {
            var ddl = document.getElementById('ctl00_ContentPlaceHolder1_fvPolicyDetails_ddlLayerNo');
            var Layer1 = document.getElementById('ctl00_ContentPlaceHolder1_fvPolicyDetails_rdbLayer_0');
            var Layer2 = document.getElementById('ctl00_ContentPlaceHolder1_fvPolicyDetails_rdbLayer_1');
            var Limit = document.getElementById('ctl00_ContentPlaceHolder1_fvPolicyDetails_txtUnderlying');

            if (Layer1.checked)
                ddl.disabled = Limit.disabled = false;
            else if (Layer2.checked)
                ddl.disabled = Limit.disabled = true;
        }

        function QuotaChange() {
            var txtPercent = document.getElementById('ctl00_ContentPlaceHolder1_fvPolicyDetails_txtSharePC');
            var Quota1 = document.getElementById('ctl00_ContentPlaceHolder1_fvPolicyDetails_rdbQuota_0');
            var Quota2 = document.getElementById('ctl00_ContentPlaceHolder1_fvPolicyDetails_rdbQuota_1');
            var Limit = document.getElementById('ctl00_ContentPlaceHolder1_fvPolicyDetails_txtShareLimit');

            if (Quota1.checked)
                txtPercent.disabled = Limit.disabled = false;
            else if (Quota2.checked)
                txtPercent.disabled = Limit.disabled = true;
        }
    </script>
    <div style="width: 100%;">
        <div>
            <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
                HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
                EnableClientScript="true" ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
            <asp:ValidationSummary ID="vsAttchments" runat="server" ShowSummary="false" ShowMessageBox="true"
                HeaderText="Verify the following fields in Comments/Attachment Panel:" BorderWidth="1"
                BorderColor="DimGray" ValidationGroup="AddAttachment" CssClass="errormessage"></asp:ValidationSummary>
            <asp:CustomValidator ID="cvErrorMsg" runat="server" ErrorMessage="" EnableClientScript="true"
                ValidationGroup="vsErrorGroup" Display="None"></asp:CustomValidator>
        </div>
        <div style="display: none;">
            <asp:Label ID="lblPolID" runat="Server"></asp:Label>
        </div>
        <table width="100%">
            <tr>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:MultiView ID="mvPolicyDetails" runat="server">
                        <asp:View ID="vwPolDetails" runat="server">
                            <table width="100%">
                                <tr>
                                    <td align="center">
                                        <asp:FormView ID="fvPolicyDetails" runat="server" Width="100%" OnDataBound="fvPolicyDetails_DataBound"
                                            DefaultMode="Edit">
                                            <ItemTemplate>
                                                <table width="100%" style="border: 1pt; border-color: #7f7f7f; border-style: solid; text-align: left;">
                                                    <tr>
                                                        <td colspan="2">
                                                            <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White; font-weight: Bolder; font-family: Tahoma; font-size: 10pt; text-align: left;">
                                                                <tr>
                                                                    <td class="ghc">Policy
                                                                        <asp:Label ID="lblPolicyDetailsId" runat="server" Text='<%#Eval("Pk_Policy_Id")%>'
                                                                            Height="0px" Width="0px" Visible="false"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <table width="100%" style="text-align: left;">
                                                                <tr>
                                                                    <td class="lc" style="width: 23%;">Program
                                                                    </td>
                                                                    <td class="lc" style="width: 2%;">:
                                                                    </td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:Label ID="lblProgram" runat="server" Text='<%# Eval("Program") %>'></asp:Label>
                                                                    </td>
                                                                    <td class="lc" style="width: 23%;">Policy Type
                                                                    </td>
                                                                    <td class="lc" style="width: 2%;">:
                                                                    </td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:Label ID="lblPolType" runat="server" Text='<%# Eval("PolicyType") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Insurance Carrier
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:Label ID="lblCarrier" runat="server" Text='<%# Eval("Carrier") %>'></asp:Label>
                                                                    </td>
                                                                    <td class="lc">Underwriter
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:Label ID="lblUnderWriter" runat="server" Text='<%# Eval("Underwriter") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">TPA
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:Label ID="lblTPA" runat="server" Text='<%# Eval("TPA") %>'></asp:Label>
                                                                    </td>
                                                                    <td class="lc">Policy Number
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="lc">
                                                                        <asp:Label ID="lblPolNo" runat="server" Text='<%# Eval("Policy_Number") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Policy Effective Date
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:Label ID="lblDtPolBegin" runat="server" Text='<%#clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Policy_Begin_Date")))%>'></asp:Label>
                                                                    </td>
                                                                    <td class="lc">Policy Expiration Date
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:Label ID="lblDtPolExp" runat="server" Text='<%#clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Policy_Expiration_Date")))%>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Policy Year
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:Label ID="lblPolYear" runat="server" Text='<%# Eval("Policy_Year") %>'></asp:Label>
                                                                    </td>
                                                                    <td class="lc">Location
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:Label ID="lblPolEntity" runat="server" Text='<%# Eval("Location") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Annual Premium
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">$<asp:Label ID="lblAnnPremium" runat="server" Text='<%# Eval("Annual_Premium") %>'></asp:Label>
                                                                    </td>
                                                                    <td class="lc">Surplus Lines Fees
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">$<asp:Label ID="lblSLF" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Surplus_Lines_Fees")) %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Deductible ?
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:Label ID="lblDeductible" runat="server" Text='<%# (Eval("Deductible").ToString() == "N" ? "No" : Eval("Deductible").ToString() == "Y" ? "Yes" : "")%>'></asp:Label>
                                                                    </td>
                                                                    <td class="lc">Deductible Amount
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">$<asp:Label ID="lblDedAmount" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Deductible_Amount")) %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Coverage Form
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:Label ID="lblCovForm" runat="server" Text='<%# Eval("Coverage_Form").ToString() == "O" ? "Occurence" : Eval("Coverage_Form").ToString() == "C" ? "Claims Made" : "" %>'></asp:Label>
                                                                    </td>
                                                                    <td class="lc">Store Deductible
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">$<asp:Label ID="lblStore_Deductible" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Store_Deductible")) %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Per Occurrence Limit
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">$<asp:Label ID="lblPreOccLimit" runat="server" Text='<%# Eval("Per_Occurrence_Limit") %>'></asp:Label>
                                                                    </td>
                                                                    <td class="lc">Aggregate Limit
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">$<asp:Label ID="lblAggLimit" runat="server" Text='<%# Eval("Aggregate_Limit") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Layered Program?
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:Label ID="lblLayerProg" runat="server" Text='<%# (Eval("Layered_Program").ToString() == "N" ? "No" : Eval("Layered_Program").ToString() == "Y" ? "Yes" : "")%>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">If Layered, Layer Number
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:Label ID="lblLayerNo" runat="server" Text='<%# Eval("PolicyLayer") %>'></asp:Label>
                                                                    </td>
                                                                    <td class="lc">Underlying Limit
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">$<asp:Label ID="lblUnderlying" runat="server" Text='<%# Eval("Underlying_Limit") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Quota Share ?
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:Label ID="lblQuota" runat="server" Text='<%# (Eval("Quota_Share").ToString() == "N" ? "No" : Eval("Quota_Share").ToString() == "Y" ? "Yes" : "") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Share Percentage
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Share_Precentage") %>'></asp:Label>
                                                                    </td>
                                                                    <td class="lc">Share Limit
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">$<asp:Label ID="lblShareLimit" runat="server" Text='<%# Eval("Share_Limit") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Retroactive
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:Label ID="lblRetro" runat="server" Text='<%# (Eval("Retroactive").ToString() == "N" ? "No" : Eval("Retroactive").ToString() == "Y" ? "Yes" : "") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Financial Security Required?
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:Label ID="lblFinancial_Security_Required" runat="server" Text='<%# (Eval("Financial_Security_Required").ToString() == "N" ? "No" : Eval("Financial_Security_Required").ToString() == "Y" ? "Yes" : "") %>'></asp:Label>
                                                                </tr>
                                                                <tr id="trFSR" runat="server" style="display: block;">
                                                                    <td class="lc">Type
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:Label runat="server" ID="lblType" Text='<%# Eval("FK_Financial_Security_Type") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Original Amount
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">$<asp:Label ID="lblOriginal_Amount" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Original_Amount")) %>'></asp:Label>
                                                                    </td>
                                                                    <td class="lc">Original Amount Date
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:Label ID="lblOriginal_Amount_Date" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Original_Amount_Date")))%>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Change Amount 1
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">$<asp:Label ID="lblChange_Amount_1" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Change_Amount_1")) %>'></asp:Label>
                                                                    </td>
                                                                    <td class="lc">Change Amount Date 1
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:Label ID="lblChange_Amount_1_Date" runat="server" Text='<%#clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Change_Amount_1_Date")))%>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Change Amount 2
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">$<asp:Label ID="lblChange_Amount_2" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Change_Amount_2")) %>'></asp:Label>
                                                                    </td>
                                                                    <td class="lc">Change Amount Date 2
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:Label ID="lblChange_Amount_2_Date" runat="server" Text='<%#clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Change_Amount_2_Date")))%>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Change Amount 3
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">$<asp:Label ID="lblChange_Amount_3" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Change_Amount_3")) %>'></asp:Label>
                                                                    </td>
                                                                    <td class="lc">Change Amount Date 3
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:Label ID="lblChange_Amount_3_Date" runat="server" Text='<%#clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Change_Amount_3_Date")))%>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Change Amount 4
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">$<asp:Label ID="lblChange_Amount_4" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Change_Amount_4")) %>'></asp:Label>
                                                                    </td>
                                                                    <td class="lc">Change Amount Date 4
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:Label ID="lblChange_Amount_4_Date" runat="server" Text='<%#clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Change_Amount_4_Date")))%>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" valign="top">Policy Notes
                                                                    </td>
                                                                    <td class="lc" valign="top">:
                                                                    </td>
                                                                    <td class="ic" colspan="4">
                                                                        <uc:ctrlMultiLineTextBox runat="server" ID="lblPolicy_Notes" ControlType="Label"
                                                                            Text='<%# Eval("Policy_Notes") %>' />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6">
                                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White; font-weight: Bolder; font-family: Tahoma; font-size: 10pt; text-align: left;">
                                                                            <tr>
                                                                                <td class="ghc">Policy Features
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Policy Features
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="lc" colspan="4">
                                                                        <asp:GridView ID="gvFeatures" runat="server" AutoGenerateColumns="false" DataKeyNames=""
                                                                            Width="100%" AllowPaging="false" AllowSorting="True" OnSorting="gvFeatures_Sorting"
                                                                            OnRowCreated="gvFeatures_RowCreated" OnRowCommand="gvFeatures_RowCommand">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="Feature" HeaderText="Feature" SortExpression="Feature"></asp:BoundField>
                                                                                <%--<asp:BoundField DataField="Limit" HeaderText="Limit" SortExpression="Limit"></asp:BoundField>--%>
                                                                                <asp:TemplateField HeaderText="Limit" SortExpression="Limit">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label runat="server" ID="lblLimit" Text='<%# clsGeneral.GetStringValue(Eval("Limit")) %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <%--<asp:BoundField DataField="Deductible" HeaderText="Deductible" SortExpression="Deductible">
                                                                                </asp:BoundField>--%>
                                                                                <asp:TemplateField HeaderText="Deductible" SortExpression="Deductible">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label runat="server" ID="lblDeductible" Text='<%# clsGeneral.GetStringValue(Eval("Deductible")) %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:HyperLinkField DataNavigateUrlFields="PK_Policy_Features" DataNavigateUrlFormatString="PolicyFeature.aspx?PfID={0}&Mode=View"
                                                                                    Text="View" Target="_parent" HeaderText="View" />
                                                                            </Columns>
                                                                            <EmptyDataRowStyle ForeColor="red" HorizontalAlign="Center" />
                                                                            <EmptyDataTemplate>
                                                                                Currently There Is No Data.<br />
                                                                                Pls Add One Or More Policy Feature.
                                                                            </EmptyDataTemplate>
                                                                            <PagerSettings Visible="False" />
                                                                            <PagerSettings Visible="False" />
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6">
                                                                        <uc:ctrlAttachmentDetails runat="server" ID="AttachmentDetails" EnableMail="true" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="2">
                                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                                            <asp:Button ID="btnAuditView" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();"
                                                                Visible="true" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <InsertItemTemplate>
                                                <table width="100%" style="border: 1pt; border-color: #7f7f7f; border-style: solid; text-align: left;">
                                                    <tr>
                                                        <td colspan="2">
                                                            <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White; font-weight: Bolder; font-family: Tahoma; font-size: 10pt; text-align: left;">
                                                                <tr>
                                                                    <td class="ghc">Policy
                                                                        <asp:Label ID="lblPolicyDetailsId" runat="server" Text='<%#Eval("Pk_Policy_Id")%>'
                                                                            Height="0px" Width="0px" Visible="false"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <table width="100%" style="text-align: left;">
                                                                <tr>
                                                                    <td class="lc" style="width: 23%;">Program&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc" style="width: 2%;">:
                                                                    </td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:DropDownList ID="ddlProgram" runat="server" AutoPostBack="true" Width="157px"
                                                                            SkinID="dropGen" OnSelectedIndexChanged="ddlProgram_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td class="lc" style="width: 23%;">Policy Type&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc" style="width: 2%;">:
                                                                    </td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:DropDownList ID="ddlPolType" runat="server" SkinID="dropGen" Width="225px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Insurance Carrier&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:TextBox ID="txtCarrier" runat="server" MaxLength="50"></asp:TextBox>
                                                                    </td>
                                                                    <td class="lc">Underwriter&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:TextBox ID="txtUnderWriter" runat="server" MaxLength="50"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">TPA&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:TextBox runat="server" ID="txtTPA" MaxLength="75"></asp:TextBox>
                                                                    </td>
                                                                    <td class="lc">Policy Number&nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="lc">
                                                                        <asp:TextBox ID="txtPolNo" runat="server" MaxLength="30"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Policy Effective Date&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:TextBox ID="txtDtPolBegin" runat="server" SkinID="txtDate"></asp:TextBox>
                                                                        <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvPolicyDetails_txtDtPolBegin', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                            align="absmiddle" />
                                                                        <cc1:MaskedEditExtender ID="MaskedEditExtender6" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                            OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDtPolBegin"
                                                                            CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                        </cc1:MaskedEditExtender>
                                                                        <asp:CustomValidator ID="cvDtPolBegin" runat="server" ControlToValidate="txtDtPolBegin"
                                                                            ValidationGroup="vsErrorGroup" ClientValidationFunction="CheckDate" ErrorMessage="Policy Effective Date is not valid."
                                                                            Display="None" SetFocusOnError="true">
                                                                        </asp:CustomValidator>
                                                                    </td>
                                                                    <td class="lc">Policy Expiration Date&nbsp;<span id="Span8" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:TextBox ID="txtDtPolExp" runat="server" SkinID="txtDate"></asp:TextBox>
                                                                        <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvPolicyDetails_txtDtPolExp', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                            align="absmiddle" />
                                                                        <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                            OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDtPolExp"
                                                                            CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                        </cc1:MaskedEditExtender>
                                                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtDtPolExp"
                                                                            ValidationGroup="vsErrorGroup" ErrorMessage="Policy Expiry Date Must Be Greater Than or Equal to Policy Effective Date."
                                                                            Type="Date" Operator="GreaterThanEqual" ControlToCompare="txtDtPolBegin" Display="none">
                                                                        </asp:CompareValidator>
                                                                        <asp:CustomValidator ID="cvDtPolExp" runat="server" ControlToValidate="txtDtPolExp"
                                                                            ValidationGroup="vsErrorGroup" ClientValidationFunction="CheckDate" ErrorMessage="Policy Expiry Date is not valid."
                                                                            Display="None" SetFocusOnError="true">
                                                                        </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Policy Year&nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:TextBox ID="txtPolYear" runat="server" onkeypress="return numberOnly(event);"
                                                                            MaxLength="4"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="revPolYear" runat="server" ControlToValidate="txtPolYear"
                                                                            Display="none" SetFocusOnError="true" ErrorMessage="Policy Year is Invalid."
                                                                            ValidationExpression="[\d]{4}" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td class="lc">Location&nbsp;<span id="Span10" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:DropDownList ID="ddlLocation" runat="server" SkinID="dropGen" Width="225px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Annual Premium&nbsp;<span id="Span11" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">$<asp:TextBox ID="txtPolAnnPremium" SkinID="txtAmt" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                                        OnBlur="CheckNumericVal(this,10);"></asp:TextBox>
                                                                    </td>
                                                                    <td class="lc">Surplus Lines Fees&nbsp;<span id="Span12" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">$<asp:TextBox ID="txtSLF" runat="server" SkinID="txtAmt" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                                        OnBlur="CheckNumericVal(this,10);"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Deductible ?&nbsp;<span id="Span13" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:RadioButtonList ID="rblDeductible" runat="server">
                                                                            <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                            <asp:ListItem Text="No" Value="N" Selected="true"></asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                    <td class="lc">Deductible Amount&nbsp;<span id="Span14" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">$<asp:TextBox ID="txtDedAmt" runat="server" SkinID="txtAmt" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                                        OnBlur="CheckNumericVal(this,10);"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Coverage Form&nbsp;<span id="Span15" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:RadioButtonList ID="rdbCF" runat="server">
                                                                            <asp:ListItem Text="Occurence" Value="O" Selected="true"></asp:ListItem>
                                                                            <asp:ListItem Text="Claims Made" Value="C"></asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                    <td class="lc">Store Deductible&nbsp;<span id="Span16" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">$<asp:TextBox ID="txtStore_Deductible" runat="server" SkinID="txtAmt" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                                        OnBlur="CheckNumericVal(this,10);"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Per Occurrence Limit&nbsp;<span id="Span17" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">$<asp:TextBox ID="txtPreOccLimit" runat="server" SkinID="txtAmt" onKeyPress="return(currencyFormat_New(this,',','.',20,event))"
                                                                        OnBlur="CheckNumericVal(this,20);"></asp:TextBox>
                                                                    </td>
                                                                    <td class="lc">Aggregate Limit&nbsp;<span id="Span18" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">$<asp:TextBox ID="txtAggLimit" runat="server" SkinID="txtAmt" onKeyPress="return(currencyFormat_New(this,',','.',15,event))"
                                                                        OnBlur="CheckNumericVal(this,15);"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Layered Program?&nbsp;<span id="Span19" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:RadioButtonList ID="rdbLayer" runat="server" onclick="javascript:return LayerChange();">
                                                                            <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                            <asp:ListItem Text="No" Value="N" Selected="true"></asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">If Layered, Layer Number&nbsp;<span id="Span20" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:DropDownList ID="ddlLayerNo" runat="server" SkinID="dropGen" Width="157px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td class="lc">Underlying Limit&nbsp;<span id="Span21" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">$<asp:TextBox ID="txtUnderlying" runat="server" SkinID="txtAmt" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                                        OnBlur="CheckNumericVal(this,10);"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Quota Share ?&nbsp;<span id="Span22" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:RadioButtonList ID="rdbQuota" runat="server" onclick="javascript:return QuotaChange();">
                                                                            <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                            <asp:ListItem Text="No" Value="N" Selected="true"></asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Share Percentage&nbsp;<span id="Span23" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:TextBox ID="txtSharePC" runat="server" MaxLength="5" onkeypress="return numberOnly(event);"></asp:TextBox>
                                                                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtSharePC"
                                                                            ValidationGroup="vsErrorGroup" ErrorMessage="Share Percentage Must Be Less Than or Equal to 100."
                                                                            Type="Double" Operator="LessThanEqual" ControlToCompare="txtCmp" Display="none"
                                                                            SetFocusOnError="true">
                                                                        </asp:CompareValidator>
                                                                        <div style="display: none;">
                                                                            <asp:TextBox ID="txtCmp" runat="Server" Text="100"></asp:TextBox>
                                                                        </div>
                                                                    </td>
                                                                    <td class="lc">Share Limit&nbsp;<span id="Span24" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">$<asp:TextBox ID="txtShareLimit" SkinID="txtAmt" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                                        OnBlur="CheckNumericVal(this,10);"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Retroactive&nbsp;<span id="Span25" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic" colspan="4">
                                                                        <asp:RadioButtonList ID="rdbRetro" runat="server">
                                                                            <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                            <asp:ListItem Text="No" Value="N" Selected="true"></asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Financial Security Required?&nbsp;<span id="Span26" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic" colspan="4">
                                                                        <asp:RadioButtonList ID="rdoFinancial_Security_Required" runat="server">
                                                                            <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                                            <asp:ListItem Value="N" Text="No" Selected="True"></asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                </tr>
                                                                <tr id="trFSR" runat="server" style="display: none;">
                                                                    <td class="lc">Type&nbsp;<span id="Span38" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic" colspan="4">
                                                                        <asp:DropDownList runat="server" ID="ddlType" SkinID="dropGen" Width="157px">
                                                                            <asp:ListItem Text="-- Select --" Value="0"></asp:ListItem>
                                                                            <asp:ListItem Text="LOC" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="Cash" Value="2"></asp:ListItem>
                                                                            <asp:ListItem Text="Other" Value="3"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Original Amount&nbsp;<span id="Span27" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">$<asp:TextBox ID="txtOriginal_Amount" runat="server" SkinID="txtAmt" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                                        OnBlur="CheckNumericVal(this,10);"></asp:TextBox>
                                                                    </td>
                                                                    <td class="lc">Original Amount Date&nbsp;<span id="Span28" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:TextBox ID="txtOriginal_Amount_Date" runat="server" SkinID="txtDate"></asp:TextBox>
                                                                        <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvPolicyDetails_txtOriginal_Amount_Date', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                            align="absmiddle" />
                                                                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                            OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtOriginal_Amount_Date"
                                                                            CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                        </cc1:MaskedEditExtender>
                                                                        <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtOriginal_Amount_Date"
                                                                            ValidationGroup="vsErrorGroup" ClientValidationFunction="CheckDate" ErrorMessage="Original Amount Date is not valid."
                                                                            Display="None" SetFocusOnError="true">
                                                                        </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Change Amount 1&nbsp;<span id="Span29" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">$<asp:TextBox ID="txtChange_Amount_1" runat="server" SkinID="txtAmt" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                                        OnBlur="CheckNumericVal(this,10);"></asp:TextBox>
                                                                    </td>
                                                                    <td class="lc">Change Amount Date 1&nbsp;<span id="Span30" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:TextBox ID="txtChange_Amount_1_Date" runat="server" SkinID="txtDate"></asp:TextBox>
                                                                        <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvPolicyDetails_txtChange_Amount_1_Date', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                            align="absmiddle" />
                                                                        <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                            OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtChange_Amount_1_Date"
                                                                            CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                        </cc1:MaskedEditExtender>
                                                                        <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="txtChange_Amount_1_Date"
                                                                            ValidationGroup="vsErrorGroup" ClientValidationFunction="CheckDate" ErrorMessage="Change Amount 1 Date is not valid."
                                                                            Display="None" SetFocusOnError="true">
                                                                        </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Change Amount 2&nbsp;<span id="Span31" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">$<asp:TextBox ID="txtChange_Amount_2" runat="server" SkinID="txtAmt" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                                        OnBlur="CheckNumericVal(this,10);"></asp:TextBox>
                                                                    </td>
                                                                    <td class="lc">Change Amount Date 2&nbsp;<span id="Span32" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:TextBox ID="txtChange_Amount_2_Date" runat="server" SkinID="txtDate"></asp:TextBox>
                                                                        <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvPolicyDetails_txtChange_Amount_2_Date', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                            align="absmiddle" />
                                                                        <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                            OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtChange_Amount_2_Date"
                                                                            CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                        </cc1:MaskedEditExtender>
                                                                        <asp:CustomValidator ID="CustomValidator3" runat="server" ControlToValidate="txtChange_Amount_2_Date"
                                                                            ValidationGroup="vsErrorGroup" ClientValidationFunction="CheckDate" ErrorMessage="Change Amount 2 Date is not valid."
                                                                            Display="None" SetFocusOnError="true">
                                                                        </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Change Amount 3&nbsp;<span id="Span33" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">$<asp:TextBox ID="txtChange_Amount_3" runat="server" SkinID="txtAmt" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                                        OnBlur="CheckNumericVal(this,10);"></asp:TextBox>
                                                                    </td>
                                                                    <td class="lc">Change Amount Date 3&nbsp;<span id="Span34" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:TextBox ID="txtChange_Amount_3_Date" runat="server" SkinID="txtDate"></asp:TextBox>
                                                                        <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvPolicyDetails_txtChange_Amount_3_Date', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                            align="absmiddle" />
                                                                        <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                            OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtChange_Amount_3_Date"
                                                                            CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                        </cc1:MaskedEditExtender>
                                                                        <asp:CustomValidator ID="CustomValidator4" runat="server" ControlToValidate="txtChange_Amount_3_Date"
                                                                            ValidationGroup="vsErrorGroup" ClientValidationFunction="CheckDate" ErrorMessage="Change Amount 3 Date is not valid."
                                                                            Display="None" SetFocusOnError="true">
                                                                        </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Change Amount 4&nbsp;<span id="Span35" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">$<asp:TextBox ID="txtChange_Amount_4" runat="server" SkinID="txtAmt" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                                        OnBlur="CheckNumericVal(this,10);"></asp:TextBox>
                                                                    </td>
                                                                    <td class="lc">Change Amount Date 4&nbsp;<span id="Span36" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:TextBox ID="txtChange_Amount_4_Date" runat="server" SkinID="txtDate"></asp:TextBox>
                                                                        <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvPolicyDetails_txtChange_Amount_4_Date', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                            align="absmiddle" />
                                                                        <cc1:MaskedEditExtender ID="MaskedEditExtender7" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                            OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtChange_Amount_4_Date"
                                                                            CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                        </cc1:MaskedEditExtender>
                                                                        <asp:CustomValidator ID="CustomValidator5" runat="server" ControlToValidate="txtChange_Amount_4_Date"
                                                                            ValidationGroup="vsErrorGroup" ClientValidationFunction="CheckDate" ErrorMessage="Change Amount 4 Date is not valid."
                                                                            Display="None" SetFocusOnError="true">
                                                                        </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" valign="top">Policy Notes&nbsp;<span id="Span37" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc" valign="top">:
                                                                    </td>
                                                                    <td class="ic" colspan="4">
                                                                        <uc:ctrlMultiLineTextBox runat="server" ID="txtPolicy_Notes" ControlType="TextBox" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6">
                                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White; font-weight: Bolder; font-family: Tahoma; font-size: 10pt; text-align: left;">
                                                                            <tr>
                                                                                <td class="ghc">Policy Features
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Policy Features </br>
                                                                        <asp:LinkButton ID="lnkPF" runat="server" Text="--Add--" OnClick="lnkPF_Click" ValidationGroup="vsErrorGroup"></asp:LinkButton>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="lc" colspan="4">
                                                                        <asp:GridView ID="gvFeatures" runat="server" AutoGenerateColumns="false" DataKeyNames=""
                                                                            Width="100%" AllowPaging="false" AllowSorting="True" OnRowCommand="gvFeatures_RowCommand"
                                                                            OnSorting="gvFeatures_Sorting" OnRowCreated="gvFeatures_RowCreated">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="Feature" HeaderText="Feature" SortExpression="Feature"></asp:BoundField>
                                                                                <asp:TemplateField HeaderText="Limit" SortExpression="Limit">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label runat="server" ID="lblLimit" Text='<%# clsGeneral.GetStringValue(Eval("Limit")) %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Deductible" SortExpression="Deductible">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label runat="server" ID="lblDeductible" Text='<%# clsGeneral.GetStringValue(Eval("Deductible")) %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:HyperLinkField DataNavigateUrlFields="PK_Policy_Features" DataNavigateUrlFormatString="PolicyFeature.aspx?PfID={0}&Mode=Edit"
                                                                                    Text="Edit" Target="_parent" HeaderText="Edit" />
                                                                                <asp:TemplateField HeaderText="Remove">
                                                                                    <ItemStyle HorizontalAlign="left" />
                                                                                    <ItemTemplate>
                                                                                        <asp:ImageButton runat="server" ID="imgRemove" ImageUrl="~/Images/grdimg_delete.gif"
                                                                                            CommandName="Remove" CommandArgument='<%# Eval("PK_Policy_Features") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <EmptyDataRowStyle ForeColor="red" HorizontalAlign="Center" />
                                                                            <EmptyDataTemplate>
                                                                                Currently There Is No Data.<br />
                                                                                Pls Add One Or More Policy Feature.
                                                                            </EmptyDataTemplate>
                                                                            <PagerSettings Visible="False" />
                                                                            <PagerSettings Visible="False" />
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6">
                                                                        <uc:ctrlAttachment runat="server" ID="Attachment" OnbtnHandler="btnAddAttachment_Click" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6">
                                                                        <uc:ctrlAttachmentDetails runat="server" ID="AttachmentDetails" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" colspan="6">
                                                                        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vsErrorGroup"
                                                                            OnClick="btnSave_Click" />
                                                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </InsertItemTemplate>
                                            <EditItemTemplate>
                                                <table width="100%" style="border: 1pt; border-color: #7f7f7f; border-style: solid; text-align: left;">
                                                    <tr>
                                                        <td colspan="2">
                                                            <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White; font-weight: Bolder; font-family: Tahoma; font-size: 10pt; text-align: left;">
                                                                <tr>
                                                                    <td class="ghc">Policy
                                                                        <asp:Label ID="lblPolicyDetailsId" runat="server" Text='<%#Eval("Pk_Policy_Id")%>'
                                                                            Height="0px" Width="0px" Visible="false"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <table width="100%" style="text-align: left;">
                                                                <tr>
                                                                    <td class="lc" style="width: 23%;">Program&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc" style="width: 2%;">:
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        <asp:DropDownList runat="server" ID="ddlProgram" AutoPostBack="true" SkinID="dropGen"
                                                                            Width="157px" OnSelectedIndexChanged="ddlProgram_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td class="lc" style="width: 23%;">Policy Type&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc" style="width: 2%;">:
                                                                    </td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:DropDownList ID="ddlPolType" runat="server" Width="225px" SkinID="dropGen">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Insurance Carrier&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:TextBox ID="txtCarrier" runat="server" MaxLength="50" Text='<%# Eval("Carrier") %>'></asp:TextBox>
                                                                    </td>
                                                                    <td class="lc">Underwriter&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:TextBox ID="txtUnderWriter" runat="server" MaxLength="50" Text='<%# Eval("UnderWriter") %>'></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">TPA&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:TextBox runat="server" ID="txtTPA" MaxLength="75" Text='<%# Eval("TPA") %>'></asp:TextBox>
                                                                    </td>
                                                                    <td class="lc">Policy Number&nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="lc">
                                                                        <asp:TextBox ID="txtPolNo" runat="server" MaxLength="30" Text='<%# Eval("Policy_Number") %>'></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Policy Effective Date&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:TextBox ID="txtDtPolBegin" runat="server" SkinID="txtDate" Text='<%# clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Policy_Begin_Date"))) %>'></asp:TextBox>
                                                                        <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvPolicyDetails_txtDtPolBegin', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                            align="absmiddle" />
                                                                        <cc1:MaskedEditExtender ID="MaskedEditExtender6" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                            OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDtPolBegin"
                                                                            CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                        </cc1:MaskedEditExtender>
                                                                        <asp:CustomValidator ID="cvDtPolBegin" runat="server" ControlToValidate="txtDtPolBegin"
                                                                            ValidationGroup="vsErrorGroup" ClientValidationFunction="CheckDate" ErrorMessage="Policy Effective Date is not valid."
                                                                            Display="None">
                                                                        </asp:CustomValidator>
                                                                    </td>
                                                                    <td class="lc">Policy Expiration Date&nbsp;<span id="Span8" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:TextBox ID="txtDtPolExp" runat="server" SkinID="txtDate" Text='<%# clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Policy_Expiration_Date"))) %>'></asp:TextBox>
                                                                        <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvPolicyDetails_txtDtPolExp', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                            align="absmiddle" />
                                                                        <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                            OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDtPolExp"
                                                                            CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                        </cc1:MaskedEditExtender>
                                                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtDtPolExp"
                                                                            ValidationGroup="vsErrorGroup" ErrorMessage="Policy Expiry Date Must Be Greater Than or Equal to Policy Effective Date."
                                                                            Type="Date" Operator="GreaterThanEqual" ControlToCompare="txtDtPolBegin" Display="none">
                                                                        </asp:CompareValidator>
                                                                        <asp:CustomValidator ID="cvDtPolExp" runat="server" ControlToValidate="txtDtPolExp"
                                                                            ValidationGroup="vsErrorGroup" ClientValidationFunction="CheckDate" ErrorMessage="Policy Expiry Date is not valid."
                                                                            Display="None">
                                                                        </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Policy Year&nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:TextBox ID="txtPolYear" runat="server" onkeypress="return numberOnly(event);"
                                                                            MaxLength="4" Text='<%# Eval("Policy_Year") %>'></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="revPolYear" runat="server" ControlToValidate="txtPolYear"
                                                                            Display="none" SetFocusOnError="true" ErrorMessage="Policy Year is Invalid."
                                                                            ValidationExpression="[\d]{4}" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td class="lc">Location&nbsp;<span id="Span10" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:DropDownList ID="ddlLocation" runat="server" SkinID="dropGen" Width="225px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Annual Premium&nbsp;<span id="Span11" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">$<asp:TextBox ID="txtPolAnnPremium" SkinID="txtAmt" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Annual_Premium")) %>'
                                                                        onKeyPress="return(currencyFormat(this,',','.',event))" OnBlur="CheckNumericVal(this,10);"></asp:TextBox>
                                                                    </td>
                                                                    <td class="lc">Surplus Lines Fees&nbsp;<span id="Span12" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">$<asp:TextBox ID="txtSLF" runat="server" SkinID="txtAmt" Text='<%# clsGeneral.GetStringValue(Eval("Surplus_Lines_Fees")) %>'
                                                                        onKeyPress="return(currencyFormat(this,',','.',event))" OnBlur="CheckNumericVal(this,10);"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Deductible ?&nbsp;<span id="Span13" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:RadioButtonList ID="rblDeductible" runat="server">
                                                                            <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                            <asp:ListItem Text="No" Value="N" Selected="true"></asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                    <td class="lc">Deductible Amount&nbsp;<span id="Span14" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">$<asp:TextBox ID="txtDedAmt" runat="server" SkinID="txtAmt" Text='<%# clsGeneral.GetStringValue(Eval("Deductible_Amount")) %>'
                                                                        onKeyPress="return(currencyFormat(this,',','.',event))" OnBlur="CheckNumericVal(this,10);"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Coverage Form&nbsp;<span id="Span15" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:RadioButtonList ID="rdbCF" runat="server">
                                                                            <asp:ListItem Text="Occurence" Value="O" Selected="true"></asp:ListItem>
                                                                            <asp:ListItem Text="Claims Made" Value="C"></asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                    <td class="lc">Store Deductible&nbsp;<span id="Span16" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">$<asp:TextBox ID="txtStore_Deductible" runat="server" SkinID="txtAmt" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                                        OnBlur="CheckNumericVal(this,10);" Text='<%# clsGeneral.GetStringValue(Eval("Store_Deductible")) %>'></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Per Occurrence Limit&nbsp;<span id="Span17" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">$<asp:TextBox ID="txtPreOccLimit" runat="server" SkinID="txtAmt" Text='<%# clsGeneral.GetStringValue(Eval("Per_Occurrence_Limit")) %>'
                                                                        onKeyPress="return(currencyFormat_New(this,',','.',20,event))" OnBlur="CheckNumericVal(this,20);"></asp:TextBox>
                                                                    </td>
                                                                    <td class="lc">Aggregate Limit&nbsp;<span id="Span18" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">$<asp:TextBox ID="txtAggLimit" runat="server" SkinID="txtAmt" Text='<%# clsGeneral.GetStringValue(Eval("Aggregate_Limit")) %>'
                                                                        onKeyPress="return(currencyFormat_New(this,',','.',15,event))" OnBlur="CheckNumericVal(this,15);"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Layered Program?&nbsp;<span id="Span19" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:RadioButtonList ID="rdbLayer" runat="server" onclick="javascript:return LayerChange();">
                                                                            <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                            <asp:ListItem Text="No" Value="N" Selected="true"></asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">If Layered, Layer Number&nbsp;<span id="Span20" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:DropDownList ID="ddlLayerNo" runat="server" SkinID="dropGen" Width="157px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td class="lc">Underlying Limit&nbsp;<span id="Span21" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">$<asp:TextBox ID="txtUnderlying" SkinID="txtAmt" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Underlying_Limit")) %>'
                                                                        onKeyPress="return(currencyFormat(this,',','.',event))" OnBlur="CheckNumericVal(this,10);"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Quota Share ?&nbsp;<span id="Span22" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:RadioButtonList ID="rdbQuota" runat="server" onclick="javascript:return QuotaChange();">
                                                                            <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                            <asp:ListItem Text="No" Value="N" Selected="true"></asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Share Percentage&nbsp;<span id="Span23" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:TextBox ID="txtSharePC" runat="server" MaxLength="5" Text='<%# Eval("Share_Precentage") %>'
                                                                            onkeypress="return numberOnly(event);"></asp:TextBox>
                                                                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtSharePC"
                                                                            ValidationGroup="vsErrorGroup" ErrorMessage="Share Percentage Must Be Less Than or Equal to 100."
                                                                            Type="Double" Operator="LessThanEqual" ControlToCompare="txtCmp" Display="none">
                                                                        </asp:CompareValidator>
                                                                        <div style="display: none;">
                                                                            <asp:TextBox ID="txtCmp" runat="Server" Text="100"></asp:TextBox>
                                                                        </div>
                                                                    </td>
                                                                    <td class="lc">Share Limit&nbsp;<span id="Span24" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">$<asp:TextBox ID="txtShareLimit" SkinID="txtAmt" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Share_Limit")) %>'
                                                                        onKeyPress="return(currencyFormat(this,',','.',event))" OnBlur="CheckNumericVal(this,10);"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Retroactive&nbsp;<span id="Span25" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:RadioButtonList ID="rdbRetro" runat="server">
                                                                            <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                            <asp:ListItem Text="No" Value="N" Selected="true"></asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Financial Security Required?&nbsp;<span id="Span26" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic" colspan="4">
                                                                        <asp:RadioButtonList ID="rdoFinancial_Security_Required" runat="server">
                                                                            <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                                            <asp:ListItem Value="N" Text="No" Selected="True"></asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                </tr>
                                                                <tr id="trFSR" runat="server" style="display: none;">
                                                                    <td class="lc">Type&nbsp;<span id="Span38" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic" colspan="4">
                                                                        <asp:DropDownList runat="server" ID="ddlType" SkinID="dropGen" Width="157px">
                                                                            <asp:ListItem Text="-- Select --" Value="0"></asp:ListItem>
                                                                            <asp:ListItem Text="LOC" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="Cash" Value="2"></asp:ListItem>
                                                                            <asp:ListItem Text="Other" Value="3"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Original Amount&nbsp;<span id="Span27" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">$<asp:TextBox ID="txtOriginal_Amount" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Original_Amount")) %>'
                                                                        SkinID="txtAmt" onKeyPress="return(currencyFormat(this,',','.',event))" OnBlur="CheckNumericVal(this,10);"></asp:TextBox>
                                                                    </td>
                                                                    <td class="lc">Original Amount Date&nbsp;<span id="Span28" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:TextBox ID="txtOriginal_Amount_Date" runat="server" SkinID="txtDate" Text='<%# clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Original_Amount_Date"))) %>'></asp:TextBox>
                                                                        <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvPolicyDetails_txtOriginal_Amount_Date', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                            align="absmiddle" />
                                                                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                            OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtOriginal_Amount_Date"
                                                                            CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                        </cc1:MaskedEditExtender>
                                                                        <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtOriginal_Amount_Date"
                                                                            ValidationGroup="vsErrorGroup" ClientValidationFunction="CheckDate" ErrorMessage="Original Amount Date is not valid."
                                                                            Display="None" SetFocusOnError="true">
                                                                        </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Change Amount 1&nbsp;<span id="Span29" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">$<asp:TextBox ID="txtChange_Amount_1" runat="server" SkinID="txtAmt" Text='<%# clsGeneral.GetStringValue(Eval("Change_Amount_1")) %>'
                                                                        onKeyPress="return(currencyFormat(this,',','.',event))" OnBlur="CheckNumericVal(this,10);"></asp:TextBox>
                                                                    </td>
                                                                    <td class="lc">Change Amount Date 1&nbsp;<span id="Span30" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:TextBox ID="txtChange_Amount_1_Date" runat="server" SkinID="txtDate" Text='<%# clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Change_Amount_1_Date"))) %>'></asp:TextBox>
                                                                        <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvPolicyDetails_txtChange_Amount_1_Date', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                            align="absmiddle" />
                                                                        <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                            OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtChange_Amount_1_Date"
                                                                            CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                        </cc1:MaskedEditExtender>
                                                                        <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="txtChange_Amount_1_Date"
                                                                            ValidationGroup="vsErrorGroup" ClientValidationFunction="CheckDate" ErrorMessage="Change Amount 1 Date is not valid."
                                                                            Display="None" SetFocusOnError="true">
                                                                        </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Change Amount 2&nbsp;<span id="Span31" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">$<asp:TextBox ID="txtChange_Amount_2" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Change_Amount_2")) %>'
                                                                        SkinID="txtAmt" onKeyPress="return(currencyFormat(this,',','.',event))" OnBlur="CheckNumericVal(this,10);"></asp:TextBox>
                                                                    </td>
                                                                    <td class="lc">Change Amount Date 2&nbsp;<span id="Span32" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:TextBox ID="txtChange_Amount_2_Date" runat="server" SkinID="txtDate" Text='<%# clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Change_Amount_2_Date"))) %>'></asp:TextBox>
                                                                        <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvPolicyDetails_txtChange_Amount_2_Date', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                            align="absmiddle" />
                                                                        <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                            OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtChange_Amount_2_Date"
                                                                            CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                        </cc1:MaskedEditExtender>
                                                                        <asp:CustomValidator ID="CustomValidator3" runat="server" ControlToValidate="txtChange_Amount_2_Date"
                                                                            ValidationGroup="vsErrorGroup" ClientValidationFunction="CheckDate" ErrorMessage="Change Amount 2 Date is not valid."
                                                                            Display="None" SetFocusOnError="true">
                                                                        </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Change Amount 3&nbsp;<span id="Span33" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">$<asp:TextBox ID="txtChange_Amount_3" runat="server" SkinID="txtAmt" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                                        OnBlur="CheckNumericVal(this,10);" Text='<%# clsGeneral.GetStringValue(Eval("Change_Amount_3")) %>'></asp:TextBox>
                                                                    </td>
                                                                    <td class="lc">Change Amount Date 3&nbsp;<span id="Span34" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:TextBox ID="txtChange_Amount_3_Date" runat="server" SkinID="txtDate" Text='<%# clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Change_Amount_3_Date"))) %>'></asp:TextBox>
                                                                        <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvPolicyDetails_txtChange_Amount_3_Date', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                            align="absmiddle" />
                                                                        <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                            OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtChange_Amount_3_Date"
                                                                            CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                        </cc1:MaskedEditExtender>
                                                                        <asp:CustomValidator ID="CustomValidator4" runat="server" ControlToValidate="txtChange_Amount_3_Date"
                                                                            ValidationGroup="vsErrorGroup" ClientValidationFunction="CheckDate" ErrorMessage="Change Amount 3 Date is not valid."
                                                                            Display="None" SetFocusOnError="true">
                                                                        </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Change Amount 4&nbsp;<span id="Span35" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">$<asp:TextBox ID="txtChange_Amount_4" runat="server" SkinID="txtAmt" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                                        OnBlur="CheckNumericVal(this,10);" Text='<%# clsGeneral.GetStringValue(Eval("Change_Amount_4")) %>'></asp:TextBox>
                                                                    </td>
                                                                    <td class="lc">Change Amount Date 4&nbsp;<span id="Span36" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="ic">
                                                                        <asp:TextBox ID="txtChange_Amount_4_Date" runat="server" SkinID="txtDate" Text='<%# clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Change_Amount_4_Date"))) %>'></asp:TextBox>
                                                                        <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvPolicyDetails_txtChange_Amount_4_Date', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                            align="absmiddle" />
                                                                        <cc1:MaskedEditExtender ID="MaskedEditExtender7" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                            OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtChange_Amount_4_Date"
                                                                            CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                        </cc1:MaskedEditExtender>
                                                                        <asp:CustomValidator ID="CustomValidator5" runat="server" ControlToValidate="txtChange_Amount_4_Date"
                                                                            ValidationGroup="vsErrorGroup" ClientValidationFunction="CheckDate" ErrorMessage="Change Amount 4 Date is not valid."
                                                                            Display="None" SetFocusOnError="true">
                                                                        </asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" valign="top">Policy Notes&nbsp;<span id="Span37" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td class="lc" valign="top">:
                                                                    </td>
                                                                    <td class="ic" colspan="4" style="width: 75%">
                                                                        <uc:ctrlMultiLineTextBox runat="server" ID="txtPolicy_Notes" ControlType="TextBox"
                                                                            Text='<%# Eval("Policy_Notes") %>' />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6">
                                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White; font-weight: Bolder; font-family: Tahoma; font-size: 10pt; text-align: left;">
                                                                            <tr>
                                                                                <td class="ghc">Policy Features
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc">Policy Features </br>
                                                                        <asp:LinkButton ID="lnkPF" runat="server" Text="--Add--" OnClick="lnkPF_Click" ValidationGroup="vsErrorGroup"></asp:LinkButton>
                                                                    </td>
                                                                    <td class="lc">:
                                                                    </td>
                                                                    <td class="lc" colspan="4">
                                                                        <asp:GridView ID="gvFeatures" runat="server" AutoGenerateColumns="false" DataKeyNames=""
                                                                            Width="100%" AllowPaging="false" AllowSorting="True" OnRowCommand="gvFeatures_RowCommand"
                                                                            OnSorting="gvFeatures_Sorting" OnRowCreated="gvFeatures_RowCreated">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="Feature" HeaderText="Feature" SortExpression="Feature"></asp:BoundField>
                                                                                <%--<asp:BoundField DataField="Limit" HeaderText="Limit" SortExpression="Limit"></asp:BoundField>--%>
                                                                                <asp:TemplateField HeaderText="Limit" SortExpression="Limit">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label runat="server" ID="lblLimit" Text='<%# clsGeneral.GetStringValue(Eval("Limit")) %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <%--<asp:BoundField DataField="Deductible" HeaderText="Deductible" SortExpression="Deductible">
                                                                                </asp:BoundField>--%>
                                                                                <asp:TemplateField HeaderText="Deductible" SortExpression="Deductible">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label runat="server" ID="lblDeductible" Text='<%# clsGeneral.GetStringValue(Eval("Deductible")) %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:HyperLinkField DataNavigateUrlFields="PK_Policy_Features" DataNavigateUrlFormatString="PolicyFeature.aspx?PfID={0}&Mode=Edit"
                                                                                    Text="Edit" Target="_parent" HeaderText="Edit" />
                                                                                <asp:TemplateField HeaderText="Remove">
                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                    <ItemTemplate>
                                                                                        <asp:ImageButton runat="server" ID="imgRemove" ImageUrl="~/Images/grdimg_delete.gif"
                                                                                            OnClientClick="return confirm('Are you sure you want to remove the selected data from eRIMS2? Once the data are removed, eRIMS2 does not have functionality to retrieve the data.')"
                                                                                            CommandName="Remove" CommandArgument='<%# Eval("PK_Policy_Features") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <EmptyDataRowStyle ForeColor="red" HorizontalAlign="Center" />
                                                                            <EmptyDataTemplate>
                                                                                Currently There Is No Data.<br />
                                                                                Pls Add One Or More Policy Feature.
                                                                            </EmptyDataTemplate>
                                                                            <PagerSettings Visible="False" />
                                                                            <PagerSettings Visible="False" />
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <uc:ctrlAttachment runat="server" ID="Attachment" OnbtnHandler="btnAddAttachment_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <uc:ctrlAttachmentDetails runat="server" ID="AttachmentDetails" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="6">
                                                            <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vsErrorGroup"
                                                                OnClick="btnSave_Click" />
                                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                                            <asp:Button ID="btnAuditView" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();"
                                                                Visible="true" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </EditItemTemplate>
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
    <asp:CustomValidator ID="CustomValidator" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
        Display="None" ValidationGroup="vsErrorGroup" />
    <input id="hdnControlIDs" runat="server" type="hidden" />
    <input id="hdnErrorMsgs" runat="server" type="hidden" />
</asp:Content>
