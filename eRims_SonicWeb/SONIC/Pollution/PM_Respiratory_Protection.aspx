<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="PM_Respiratory_Protection.aspx.cs" Inherits="SONIC_Pollution_Respiratory_Protection" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/NotesWithSpellCheck/Notes.ascx" TagName="ctrlMultiLineTextBox"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attchment-Occupational/Attachment.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposuresTab/ExposuresTab.ascx" TagName="CtlTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposureInfo/EnviroExposureInfo.ascx" TagName="ctrlExposureInfo"
    TagPrefix="uc" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="Content1" runat="server">
    <script type="text/javascript" src="../../JavaScript/JFunctions.js"></script>
    <script type="text/javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" src="../../JavaScript/jquery.min.js"> </script>
    <script type="text/javascript">
        function returnConfirm() {
            return confirm('Are you sure you want to remove the selected data from eRIMS2?');
        }

        function SetMenuStyle(index) {
            var i;
            for (i = 1; i <= 1; i++) {
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

        function ShowPanel(index) {
            SetMenuStyle(index);
            ActiveTabIndex = index;
            var op = '<%=StrOperation%>';
            if (op == "view") {
                ShowPanelView(index);
            }
            else {
                var i;
                if (index < 3) {
                    for (i = 1; i <= 2; i++) {
                        document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display = (i == index) ? "block" : "none";
                    }
                    if (index == 1)
                        document.getElementById('<%=txtDate.ClientID %>').focus();
                }
                else {
                    for (i = 1; i <= 2; i++) {
                        document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display = "none";
                    }
                }
            }
        }

        function ShowPanelView(index) {
            SetMenuStyle(index);
            document.getElementById('<%=dvView.ClientID%>').style.display = "block";
            var i;
            if (index < 3) {
                for (i = 1; i <= 2; i++) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i + "View").style.display = (i == index) ? "block" : "none";
                }
            }
            else {
                for (i = 1; i <= 2; i++) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i + "View").style.display = "none";
                }
            }
        }


        function ValSave() {
            //            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqAttachType').enabled = false;
            //document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqFile').enabled = false;
            //            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_cstFile').enabled = false;
            if (Page_ClientValidate('vsErrorGroup'))
                return true;
            else
                return false;
        }

        function ValAttach() {
            //            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqAttachType').enabled = true;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqFile').enabled = true;
            //            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_cstFile').enabled = true;
            if (Page_ClientValidate('vsErrorGroup'))
                return true;
            else
                return false;
        }
         
        function OpenAuditPopUp() {
            var winHeight = window.screen.availHeight - 400;
            var winWidth = window.screen.availWidth - 500;

            obj = window.open('AuditPopup_PM_Respiratory_Protection.aspx?id=<%=ViewState["PK_PM_Respiratory_Protection"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }
         
        $(document).ready(function () {
            ShowHideMedicalRow(); ShowHideTrainingRow(); ShowHideFitTestRow();
            $("#<%=rdoMedical_Evaluation.ClientID%>").change(function () {
                ShowHideMedicalRow();
            });
            $("#<%=rdoRestrictions_Applied.ClientID%>").change(function () {
                ShowHideMedicalRow();
            });
            $("#<%=rdoTraining_Completed.ClientID%>").change(function () {
                ShowHideTrainingRow();
            });
            $("#<%=rdoFit_Test.ClientID%>").change(function () {
                ShowHideFitTestRow();
            });

            $('#<%= drpVendorLookup.ClientID%>').on('change', function () {
                var selectedVal = $("#<%= drpVendorLookup.ClientID%> option:selected").val();
                if (selectedVal == -1) {
                    $('#<%= txtVendor.ClientID%>').val('');
                $('#<%= txtVendor_Representative.ClientID%>').val('');
                $('#<%= txtVendor_Address.ClientID%>').val('');
                $('#<%= txtVendor_Zip_Code.ClientID%>').val('');
                $('#<%= txtVendor_Telephone.ClientID%>').val('');
                $('#<%= txtVendor_City.ClientID%>').val('');
                $("#<%= drpFK_LU_Vendor_State.ClientID%>").val("0");
            }
            else {
                arr = selectedVal.split('|');
                //alert(arr[0] + arr[1]);
                $('#<%= txtVendor.ClientID%>').val(arr[0]);
                    $('#<%= txtVendor_Representative.ClientID%>').val(arr[1]);
                $('#<%= txtVendor_Address.ClientID%>').val(arr[2]);
                $('#<%= txtVendor_Zip_Code.ClientID%>').val(arr[3]);
                $('#<%= txtVendor_Telephone.ClientID%>').val(arr[4]);
                    if (arr[0] == "Examinetics") {
                        $('#<%= txtVendor_City.ClientID%>').val("Overland Park");
                        $("#<%= drpFK_LU_Vendor_State.ClientID%>").val("17");
                    }
                    else {
                        $('#<%= txtVendor_City.ClientID%>').val('');
                        $("#<%= drpFK_LU_Vendor_State.ClientID%>").val('0');
                    }
            }
                //$('txtVendor').val(arr[0]);
            });

        });

        function ShowHideMedicalRow() {
            var rdoMedical_Evaluation = $("#<%=rdoMedical_Evaluation.ClientID%> input[type='radio']:checked").val();
            var rdoRestrictions_Applied = $("#<%=rdoRestrictions_Applied.ClientID%> input[type='radio']:checked").val();

            if (rdoMedical_Evaluation == 'Y')
                $("#trMedical_Evaluation").show();
            else
                $("#trMedical_Evaluation").hide();

            if (rdoRestrictions_Applied == 'Y') {
                $("#trWereRestrictions1").show(); $("#trWereRestrictions2").show();
            }
            else {
                $("#trWereRestrictions1").hide(); $("#trWereRestrictions2").hide();
                $('#<%= txtReevaluation_Date.ClientID%>').val(""); $('#<%= txtRestrictionsNotes.ClientID%>').val(""); 
            }
        }

        function ShowHideTrainingRow() {
            var rdoTraining_Completed = $("#<%=rdoTraining_Completed.ClientID%> input[type='radio']:checked").val();

            if (rdoTraining_Completed == 'Y')
                $("#trTraining").show();
            else {
                $("#trTraining").hide();
                $('#<%= txtTraining_Completed_Date.ClientID%>').val("");
            }
        }

        function ShowHideFitTestRow() {
            var rdoFit_Test = $("#<%=rdoFit_Test.ClientID%> input[type='radio']:checked").val();

            if (rdoFit_Test == 'Y') {
                $("#trFitTest1").show(); $("#trFitTest2").show();
            }
            else {
                $("#trFitTest1").hide(); $("#trFitTest2").hide();
                $('#<%= txtFit_Test_Date.ClientID%>').val("");
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
                    var rdoMedical_Evalution = $("#<%=rdoMedical_Evaluation.ClientID%> input[type='radio']:checked");
                    var rdoRestrictions_Applied = $("#<%=rdoRestrictions_Applied.ClientID%> input[type='radio']:checked");
                    var rdoReevaluation_Required = $("#<%=rdoReevaluation_Required.ClientID%> input[type='radio']:checked");
                    var rdoTraining_Completed = $("#<%=rdoTraining_Completed.ClientID%> input[type='radio']:checked");
                    var rdoFit_Test = $("#<%=rdoFit_Test.ClientID%> input[type='radio']:checked");

                    if (ctrlIDs[i] == '<%=rdoMedical_Evaluation.ClientID%>' || ctrlIDs[i] == '<%=rdoRestrictions_Applied.ClientID%>'
                        || ctrlIDs[i] == '<%=rdoReevaluation_Required.ClientID%>') {
                        if (rdoMedical_Evalution.length == 0 && ctrlIDs[i].indexOf('rdoMedical_Evaluation') > 0) bEmpty = true;
                        else if (rdoMedical_Evalution.val() == 'Y') {//here 'Were Restrictions Applied?' fields validation set
                            if (rdoRestrictions_Applied.length == 0) bEmpty = true;
                        }
                        if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                    }
                    else if (!((ctrlIDs[i] == '<%=txtNotesComments.ClientID%>'))) {
                        switch (ctrl.type) {
                            case "textarea":
                            case "text":
                                if (ctrlIDs[i].indexOf('txtRestrictionsNotes_txtNote') > 0 && rdoRestrictions_Applied.length > 0 && rdoRestrictions_Applied.val() == 'Y'
                                    && rdoMedical_Evalution.length > 0 && rdoMedical_Evalution.val() == 'Y' && ctrl.value == '') bEmpty = true;//Restrictions validate only when 'Were Restrictions Applied?' = Yes
                                else if (ctrlIDs[i].indexOf('txtTraining_Completed_Date') > 0 && rdoTraining_Completed.length > 0 && rdoTraining_Completed.val() == 'Y'
                                    && ctrl.value == '') bEmpty = true;//Training Completion Date validate only when If  Training Completed? = 'Yes'
                                else if (ctrlIDs[i].indexOf('txtFit_Test_Date') > 0 && rdoFit_Test.length > 0 && rdoFit_Test.val() == 'Y'
                                    && ctrl.value == '') bEmpty = true;//Date Fit Test Completed validate only when If  Fit Test Completed? = 'Yes'
                                else if (ctrlIDs[i].indexOf('txtRestrictionsNotes_txtNote') <= 0 && ctrlIDs[i].indexOf('txtFit_Test_Date') <= 0
                                    && ctrlIDs[i].indexOf('txtTraining_Completed_Date') <= 0 && ctrl.value == '') bEmpty = true; break;
                            case "select-one":
                                if (ctrlIDs[i].indexOf('drpFK_LU_Respirator_Type') > 0 && rdoFit_Test.length > 0 && rdoFit_Test.val() == 'Y'
                                    && ctrl.selectedIndex == 0) bEmpty = true;//Type of Respirator Used validate only when If  Fit Test Completed? = 'Yes'
                                else if (ctrlIDs[i].indexOf('drpFK_LU_Respirator_Type') <= 0 && ctrl.selectedIndex == 0) bEmpty = true; break;
                        }

                        //if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
                        if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                    }
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
    <asp:ValidationSummary ID="valSummary" runat="server" ValidationGroup="vsErrorGroup"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following fields:"
        BorderWidth="1" BorderColor="DimGray" CssClass="errormessage" />
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100%" style="height: 50px;" valign="bottom">
                <uc:CtlTab runat="server" ID="Tab"></uc:CtlTab>
            </td>
        </tr>
        <tr>
            <td class="Spacer" width="100%" style="height: 15px;">
            </td>
        </tr>
        <tr>
            <td width="100%">
                <uc:ctrlExposureInfo ID="ucCtrlExposureInfo" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="ghc" align="left">
                Occupational Health and Safety Programs – Respiratory Protection
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="Spacer" style="height: 15px;" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td class="leftMenu">
                            <table cellpadding="5" cellspacing="0" width="100%">
                                <tr>
                                    <td style="height: 18px;" class="Spacer">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%" nowrap="nowrap">
                                        <span id="Menu1" onclick="javascript:ShowPanel(1);" class="LeftMenuStatic">Respiratory Protection</span>&nbsp;<span
                                           id="MenuAsterisk1" runat="server" style="color: Red;display:none">*</span>
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td align="left" width="100%">
                                        <span id="Menu2" onclick="javascript:ShowPanel(2);" class="LeftMenuStatic">Attachment</span>
                                    </td>
                                </tr>--%>
                            </table>
                        </td>
                        <td valign="top">
                               <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td width="5px" class="Spacer">
                                        &nbsp;
                                    </td>
                                    <td class="dvContainer">
                                        <div id="dvEdit" runat="server" width="794px">
                                            <asp:Panel ID="pnl1" runat="server" Style="display: inline;">
                                                <div class="bandHeaderRow">
                                                    Respiratory Protection</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Date&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" width="28%">
                                                            <asp:TextBox ID="txtDate" runat="server" Width="150px" SkinID="txtDate" autocomplete="off"/>
                                                            <img alt="Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revDate" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[Respiratory Protection]/Date is not a valid date" SetFocusOnError="true"
                                                                ControlToValidate="txtDate" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" valign="top" width="18%">
                                                           Associate&nbsp;<span id="Span13" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" width="28%">
                                                            <asp:DropDownList ID="drpFK_Employee" Width="175px" runat="server" SkinID="dropGen">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Event Type&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:DropDownList ID="drpEvent_Type" Width="350px" runat="server" SkinID="dropGen">
                                                                <asp:ListItem Text="--Select--" Value="0" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Text="Air Monitoring" Value="Air_Monitoring"></asp:ListItem>
                                                                <asp:ListItem Text="Respiratory Protection" Value="Respiratory_Protection"></asp:ListItem>
                                                            </asp:DropDownList>                                                            
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="4">
                                                            On-Line Medical Evaluation Completed (within 2 years) and Completed Evaluation Attached? 
                                                            &nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList ID="rdoMedical_Evaluation" runat="server">
                                                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr id="trMedical_Evaluation">
                                                        <td align="left" valign="top">
                                                           Were Restrictions Applied? 
                                                             &nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:RadioButtonList ID="rdoRestrictions_Applied" runat="server">
                                                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr id="trWereRestrictions1">
                                                        <td align="left" valign="top">
                                                            Restrictions&nbsp;<span id="Span19" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="txtRestrictionsNotes" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr id="trWereRestrictions2">
                                                        <td align="left" valign="top">
                                                           Re-evaluation Required? 
                                                            &nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList ID="rdoReevaluation_Required" runat="server">
                                                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                         <td align="left" valign="top">
                                                            Re-Evaluation Date&nbsp;<span id="Span14" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtReevaluation_Date" runat="server" Width="150px" SkinID="txtDate" autocomplete="off"/>
                                                            <img alt="Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtReevaluation_Date', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="rgvReevaluation_Date" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[Respiratory Protection]/Re-Evaluation Date is not a valid date" SetFocusOnError="true"
                                                                ControlToValidate="txtReevaluation_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                           Training Completed?
                                                            &nbsp;<span id="Span10" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:RadioButtonList ID="rdoTraining_Completed" runat="server">
                                                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr id="trTraining">
                                                        <td align="left" valign="top">
                                                            Training Completion Date&nbsp;<span id="Span15" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:TextBox ID="txtTraining_Completed_Date" runat="server" Width="150px" SkinID="txtDate" autocomplete="off"/>
                                                            <img alt="Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtTraining_Completed_Date', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="rgvtxtTraining_Completed" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[Respiratory Protection]/Training Completion Date is not a valid date" SetFocusOnError="true"
                                                                ControlToValidate="txtTraining_Completed_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                           Fit Test Completed?
                                                            &nbsp;<span id="Span11" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:RadioButtonList ID="rdoFit_Test" runat="server">
                                                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr id="trFitTest1">
                                                        <td align="left" valign="top">
                                                            Date Fit Test Completed&nbsp;<span id="Span16" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtFit_Test_Date" runat="server" Width="150px" SkinID="txtDate" autocomplete="off"/>
                                                            <img alt="Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtFit_Test_Date', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[Respiratory Protection]/Date Fit Test Completed is not a valid date" SetFocusOnError="true"
                                                                ControlToValidate="txtFit_Test_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" valign="top">
                                                           Pass/Fail?
                                                            &nbsp;<span id="Span24" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:RadioButtonList ID="rdoPass_Fail" runat="server">
                                                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr id="trFitTest2">
                                                        <td align="left" width="18%" valign="top">
                                                            Type of Respirator Used&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:DropDownList ID="drpFK_LU_Respirator_Type" Width="175px" runat="server" SkinID="dropGen">
                                                            </asp:DropDownList>                                                            
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Vendor Lookup&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:DropDownList ID="drpVendorLookup" Width="350px" runat="server" SkinID="dropGen">
                                                            </asp:DropDownList>                                                            
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Vendor&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">                                                            
                                                            <asp:TextBox ID="txtVendor" runat="server" Width="170px" MaxLength="75" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Vendor Representative Name&nbsp;<span id="Span12" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtVendor_Representative" runat="server" Width="170px" MaxLength="75" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                         <td align="left" valign="top">
                                                            Vendor Street Address&nbsp;<span id="Span17" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">                                                            
                                                            <asp:TextBox ID="txtVendor_Address" runat="server" Width="170px" MaxLength="75"/>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Vendor City&nbsp;<span id="Span18" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtVendor_City" runat="server" Width="170px" MaxLength="50" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Vendor State&nbsp;<span id="Span8" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="drpFK_LU_Vendor_State" Width="175px" runat="server" SkinID="dropGen">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Vendor Zip (XXXXX-XXXX)&nbsp;<span id="Span20" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtVendor_Zip_Code" runat="server" Width="146px" MaxLength="10" SkinID="txtZipCode" onKeyPress="javascript:return FormatZipCode(event,this.id);" />
                                                            <asp:RegularExpressionValidator ID="revVendor_Zip_Code" runat="server" ErrorMessage="Vendor Zip is not valid"
                                                                SetFocusOnError="true" ControlToValidate="txtVendor_Zip_Code" ValidationExpression="\b[0-9]{5}-[0-9]{4}\b|\b[0-9]{5}\b"
                                                                ValidationGroup="vsErrorGroup" Display="none" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Vendor Telephone (XXX-XXX-XXXX)&nbsp;<span id="Span21" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtVendor_Telephone" runat="server" Width="146px"
                                                                MaxLength="12" onKeyPress="javascript:return FormatPhone(event,this.id);" />
                                                                <asp:RegularExpressionValidator ID="revtxtVendor_Telephone" ControlToValidate="txtVendor_Telephone"
                                                                    runat="server" ErrorMessage="Vendor Telephone in not valid."
                                                                    ValidationGroup="vsErrorGroup" Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Vendor E-Mail&nbsp;<span id="Span22" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtVendor_EMail" runat="server" Width="146px" MaxLength="100" />
                                                            <asp:RegularExpressionValidator ID="revVendor_EMail" runat="server"
                                                                ControlToValidate="txtVendor_EMail" Display="None" ErrorMessage="Please Enter Valid E-Mail Address"
                                                                SetFocusOnError="True" ValidationGroup="vsErrorGroup" ToolTip="Please Enter Valid E-Mail Address"
                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Notes and Comments&nbsp;<span id="Span23" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="txtNotesComments" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <b>Attachments</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                             <uc:ctrlAttachment ID="Attachments" runat="server" PanelNumber="1" AttachmentTable="PM_Respiratory_Protection_Attachments"/>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl2" runat="server" Style="display: inline;">
                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="100%">
                                                            <%--<uc:ctrlAttachment ID="Attachment" runat="Server" />--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Spacer" style="height: 20px;">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div id="dvAttachment" runat="server" style="display: none;">
                                                                <%--<uc:ctrlAttachmentDetails ID="AttachDetails" runat="Server" />--%>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Spacer" style="height: 20px;">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </div>
                                        <div id="dvView" runat="server" width="794px">
                                            <asp:Panel ID="pnl1View" runat="server" Style="display: inline;">
                                                <div class="bandHeaderRow">
                                                    Respiratory Protection</div>
                                                  <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                   <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Date
                                                        </td>
                                                        <td align="center" valign="top" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" width="28%">
                                                            <asp:Label ID="lblDate" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top" width="18%">
                                                           Associate
                                                        </td>
                                                        <td align="center" valign="top" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" width="28%">
                                                           <asp:Label ID="lblFK_Employee" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Event Type
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lblEvent_Type" runat="server" /> 
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="4">
                                                            On-Line Medical Evaluation Completed (within 2 years) and Completed Evaluation Attached? 
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblMedical_Evaluation" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr id="trViewMedical_Evaluation" runat="server">
                                                        <td align="left" valign="top">
                                                           Were Restrictions Applied? 
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lblRestrictions_Applied" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr id="trViewWereRestrictions1" runat="server">
                                                        <td align="left" valign="top">
                                                            Restrictions
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="lblRestrictionsNotes" runat="server" ControlType="Label"/>
                                                        </td>
                                                    </tr>
                                                    <tr id="trViewWereRestrictions2" runat="server">
                                                        <td align="left" valign="top">
                                                           Re-evaluation Required? 
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblReevaluation_Required" runat="server" />
                                                        </td>
                                                         <td align="left" valign="top">
                                                            Re-Evaluation Date
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblReevaluation_Date" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                           Training Completed?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lblTraining_Completed" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr id="trViewTraining" runat="server">
                                                        <td align="left" valign="top">
                                                            Training Completion Date
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lblTraining_Completed_Date" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                           Fit Test Completed?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                           <asp:Label ID="lblFit_Test" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr id="trViewFitTest1" runat="server">
                                                        <td align="left" valign="top">
                                                            Date Fit Test Completed
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFit_Test_Date" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                           Pass/Fail?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                           <asp:Label ID="lblPass_Fail" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr id="trViewFitTest2" runat="server">
                                                        <td align="left" width="18%" valign="top">
                                                            Type of Respirator Used
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                           <asp:Label ID="lblFK_LU_Respirator_Type" runat="server" /> 
                                                        </td>
                                                    </tr>
                                                    <%--<tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Vendor Lookup
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                           <asp:Label ID="lblVendorLookup" runat="server" />
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Vendor
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">                                                            
                                                            <asp:Label ID="lblVendor" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Vendor Representative Name
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblVendor_Representative" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                         <td align="left" valign="top">
                                                            Vendor Street Address
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">                                                            
                                                            <asp:Label ID="lblVendor_Address" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Vendor City
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblVendor_City" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Vendor State
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_LU_Vendor_State" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Vendor Zip (XXXXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblVendor_Zip_Code" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Vendor Telephone (XXX-XXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                           <asp:Label ID="lblVendor_Telephone" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Vendor E-Mail
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblVendor_EMail" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Notes and Comments
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="lblNotesComments" runat="server" ControlType="Label"/>
                                                        </td>
                                                    </tr>
                                                      <tr>
                                                        <td colspan="6">
                                                            <b>Attachments</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                             <uc:ctrlAttachment ID="AttachmentsView" runat="server"  PanelNumber="1" AttachmentTable="PM_Respiratory_Protection_Attachments"/>
                                                        </td>
                                                    </tr>
                                                  </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl2View" runat="server" Style="display: inline;">
                                                <div id="Div1" runat="server" style="display: inline;">
                                                    <table cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td width="100%">
                                                                <%--<uc:ctrlAttachmentDetails ID="AttachDetailsView" runat="Server" />--%>
                                                            </td>
                                                        </tr>
                                                        <%--<tr>
													<td class="Spacer" style="height: 150px;"></td>
												</tr>--%>
                                                    </table>
                                                </div>
                                            </asp:Panel>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td align="center">
                            <div id="dvSave" runat="server">
                                <table cellpadding="5" cellspacing="0" border="0" width="100%">
                                    <tr>
                                        <td width="60%" align="right">
                                            <asp:Button ID="btnSave" runat="server" Text="Save & View" OnClick="btnSave_Click"
                                                CausesValidation="true" ValidationGroup="vsErrorGroup" OnClientClick="return ValSave();" />
                                            <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />
                                            <asp:Button runat="server" ID="btnAuditTrail" Text="View Audit Trail" CausesValidation="false"
                                                Visible="true" OnClientClick="javascript:return OpenAuditPopUp();" />
                                            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
                                        </td>
                                        <td align="left">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:CustomValidator ID="CustomValidator" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
                    Display="None" ValidationGroup="vsErrorGroup" />
                <input id="hdnControlIDs" runat="server" type="hidden" />
                <input id="hdnErrorMsgs" runat="server" type="hidden" />
    
</asp:Content>
