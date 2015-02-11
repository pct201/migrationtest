<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="OhioWCClaim.aspx.cs" Inherits="SONIC_FirstReport_OhioWCClaim" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="../JavaScript/JFunctions.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Date_Validation.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>

    <link href="../../App_Themes/Default/stylecal.css" type="text/css" rel="Stylesheet" />

    <script type="text/javascript">
        function formatCurrencyOnBlur(ctrl) {
            if (ctrl.value != '') {
                var val = ctrl.value.replace(",", "").replace(",", "");
                ctrl.value = formatCurrency(val).replace("$", "");
            }
        }

        //check Date Validation
        function CheckDate(sender, args) {
            args.IsValid = (ValidateDate(args.Value));
            return args.IsValid;
        }
        function OpenPopupAssociatedFirstReport() {
            ShowDialog('PopupFirstReport.aspx');
            return false;
        }
        function onReOpenDate() {
            if (document.getElementById('ctl00_ContentPlaceHolder1_txtDateClaimClosed').value == "__/__/____")
                document.getElementById('ctl00_ContentPlaceHolder1_txtDateClaimClosed').value = "";
            if (document.getElementById('ctl00_ContentPlaceHolder1_txtDateClaimReopened').value == "__/__/____")
                document.getElementById('ctl00_ContentPlaceHolder1_txtDateClaimReopened').value = "";
            var dateClose = document.getElementById('ctl00_ContentPlaceHolder1_txtDateClaimClosed').value;
            var dateReOpen = document.getElementById('ctl00_ContentPlaceHolder1_txtDateClaimReopened').value;

            if (dateClose != '') {
                var d_dateClose = new Date(dateClose);
                var d_dateReOpen = new Date(dateReOpen);
                //if (d_dateReOpen > d_dateClose) {
                if (d_dateClose > d_dateReOpen) {
                    alert("Date Claim Reopened must be grater than Date Claim Closed.");
                    document.getElementById('ctl00_ContentPlaceHolder1_txtDateClaimReopened').value = '';
                    //document.getElementById('ctl00_ContentPlaceHolder1_txtDateClaimClosed').value = '';
                }
            }
        }
        function onCloseDate() {
            if (document.getElementById('ctl00_ContentPlaceHolder1_txtDateClaimClosed').value == "__/__/____")
                document.getElementById('ctl00_ContentPlaceHolder1_txtDateClaimClosed').value = "";
            if (document.getElementById('ctl00_ContentPlaceHolder1_txtDateClaimReopened').value == "__/__/____")
                document.getElementById('ctl00_ContentPlaceHolder1_txtDateClaimReopened').value = "";
            var dateClose = document.getElementById('ctl00_ContentPlaceHolder1_txtDateClaimClosed').value;
            var dateReOpen = document.getElementById('ctl00_ContentPlaceHolder1_txtDateClaimReopened').value;

            if (dateReOpen != '') {
                var d_dateClose = new Date(dateClose);
                var d_dateReOpen = new Date(dateReOpen);
                if (d_dateClose > d_dateReOpen) {
                    alert("Date Claim Closed must be less than Date Claim Reopened.");
                    //document.getElementById('ctl00_ContentPlaceHolder1_txtDateClaimReopened').value = '';
                    document.getElementById('ctl00_ContentPlaceHolder1_txtDateClaimClosed').value = '';
                }
            }
        }
        function AuditPopUp() {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 250;
            obj = window.open("AuditPopup_OhioWCClaim.aspx?id=" + '<%=ViewState["PK_ID"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
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
                        case "text": if (ctrl.value == '') bEmpty = true; break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                    }
                    if (bEmpty && focusCtrlID == "") {
                        focusCtrlID = ctrlIDs[i];
                        document.getElementById(ctrlIDs[i]).focus();
                    };
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
        <br />
        <div class="bandHeaderRow">
            Ohio Workers’ Compensation Claim</div>
        <div>
            <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
                HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
                EnableClientScript="true" ValidationGroup="vsErrorGroup" CssClass="errormessage">
            </asp:ValidationSummary>
        </div>
        <div style="display: none;">
            <asp:Label ID="lblPolID" runat="Server"></asp:Label>
        </div>
        <table width="100%">
             <tr><td class="Spacer" style="height:10px;"></td></tr>
            <tr width="100%">
                <td align="center" width="100%">
                    <div id="divEdit" runat="server" style="display: block;">
                        <table width="80%" cellspacing="3" cellpadding="3">
                            <tr>
                                <td align="left" width="20%" valign="top">Claim Number&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                </td>
                                <td align="center" width="2%" valign="top">:
                                </td>
                                <td align="left" width="28%" valign="top">
                                    <asp:TextBox ID="txtClaimNumber" runat="server" MaxLength="50" />
                                    <%--<asp:RequiredFieldValidator ID="rfvClaimNumber" runat="server" ControlToValidate="txtClaimNumber" ErrorMessage="Please enter Claim Number" Display="None" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                                </td>
                                <td align="left" width="20%" valign="top">Associated First Report&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                </td>
                                <td align="center" width="2%" valign="top">:
                                </td>
                                <td align="left" width="28%" valign="top">
                                    <asp:TextBox ID="txtAssociatedFirstReport" runat="server" MaxLength="20" onkeydown="return false;"
                                        SkinID="txtDisabled" EnableViewState="true" />
                                    <asp:Button ID="btnAssociatedFirstReport" runat="server" Text="V" OnClientClick="javascript:return OpenPopupAssociatedFirstReport();" />
                                    <asp:HiddenField ID="hdnid" runat="server" />
                                    <%--<asp:RequiredFieldValidator ID="rfvAssociatedFirstReport" runat="server" ControlToValidate="txtClaimNumber" ErrorMessage="Please select Associated First Report" Display="None" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">Sonic Location d/b/a&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                </td>
                                <td align="center" valign="top">:
                                </td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtSonicLocation" runat="server" onkeydown="return false;" SkinID="txtDisabled" />
                                    <%--<asp:Button ID="Button1" runat="server" Text="V" OnClientClick="javascript:return OpenPopupAssociatedFirstReport();" />--%>
                                    <asp:HiddenField ID="hdnLocationID" runat="server" />
                                </td>
                                <td align="left" valign="top">Associate Name&nbsp;<span id="Span20" style="color: Red; display: none;" runat="server">*</span>
                                </td>
                                <td align="center" valign="top">:
                                </td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtAssociateName" runat="server" onkeydown="return false;" SkinID="txtDisabled" />
                                </td>
                                <%--<td align="left" valign="top">Employee Name&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                </td>
                                <td align="center" valign="top">:
                                </td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtEmployeeName" runat="server" onkeydown="return false;" SkinID="txtDisabled" />
                                </td>--%>
                            </tr>
                            <tr>
                                <td align="left" valign="top">Date of Incident<%--&nbsp;<span id="Span20" style="color: Red;" runat="server">*</span>--%>
                                </td>
                                <td align="center" valign="top">:
                                </td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtDateofIncident" runat="server" SkinID="Date of Incident" Enabled="false"  />
                                    <%--<img alt="" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDateofIncident', 'mm/dd/y');" Enabled="false"
                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                        align="middle" /><br />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationGroup="vsErrorGroup"
                                        Display="none" ErrorMessage="Date of Incident is not a valid date" SetFocusOnError="true"
                                        ControlToValidate="txtDateofIncident" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>--%>
                                </td>
                                <td align="left" valign="top">Date Claim Opened&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                </td>
                                <td align="center" valign="top">:
                                </td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtDateClaimEntered" runat="server" SkinID="txtDate" />
                                    <img alt="" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDateClaimEntered', 'mm/dd/y');"
                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                        align="middle" /><br />
                                    <asp:RegularExpressionValidator ID="revPolicy_Date" runat="server" ValidationGroup="vsErrorGroup"
                                        Display="none" ErrorMessage="Date Claim Opened is not a valid date" SetFocusOnError="true"
                                        ControlToValidate="txtDateClaimEntered" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">Date Claim Closed&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server"></span>
                                </td>
                                <td align="center" valign="top">:
                                </td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtDateClaimClosed" runat="server" onBlur="javascript:onCloseDate();"
                                        SkinID="txtDate" />
                                    <img alt="" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDateClaimClosed', 'mm/dd/y');"
                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                        align="middle" onmouseout="javascript:ctl00_ContentPlaceHolder1_txtDateClaimClosed.focus();" /><br />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="vsErrorGroup"
                                        Display="none" ErrorMessage="Date Claim Closed is not a valid date" SetFocusOnError="true"
                                        ControlToValidate="txtDateClaimClosed" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                </td>
                                <td align="left" valign="top">Date Claim Reopened&nbsp;<span id="Span6" style="color: Red; display: none;" runat="server"></span>
                                </td>
                                <td align="center" valign="top">:
                                </td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtDateClaimReopened" runat="server" onBlur="javascript:onReOpenDate();"
                                        SkinID="txtDate" />
                                    <img alt="" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDateClaimReopened', 'mm/dd/y');"
                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                        align="middle" onmouseout="javascript:ctl00_ContentPlaceHolder1_txtDateClaimReopened.focus();" /><br />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="vsErrorGroup"
                                        Display="none" ErrorMessage="Date Claim Reopened is not a valid date" SetFocusOnError="true"
                                        ControlToValidate="txtDateClaimReopened" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>

                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">Claim Status&nbsp;<span id="Span8" style="color: Red; display: none;" runat="server">*</span>
                                </td>
                                <td align="center" valign="top">:
                                </td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="ddlStatus" runat="server" Maxlength="10">                                      
                                    </asp:TextBox>                                    
                                </td>
                               <%-- <td align="left" valign="top">Type&nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                                </td>
                                <td align="center" valign="top">:
                                </td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtType" runat="server"  MaxLength="20" Width="140px" />
                                </td>--%>
                            </tr>
<%--                            <tr>
                                <td align="left" valign="top">Total Medical&nbsp;<span id="Span10" style="color: Red; display: none;" runat="server">*</span>
                                </td>
                                <td align="center" valign="top">:
                                </td>
                                <td align="left" valign="top">
                                    $<asp:TextBox ID="txtTotalMedical" runat="server" SkinID="txtCurrency" />
                                </td>
                                <td align="left" valign="top">Total Comp&nbsp;<span id="Span11" style="color: Red; display: none;" runat="server">*</span>
                                </td>
                                <td align="center" valign="top">:
                                </td>
                                <td align="left" valign="top">
                                    $<asp:TextBox ID="txtTotalComp" runat="server" SkinID="txtCurrency" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">Total Reserve&nbsp;<span id="Span12" style="color: Red; display: none;" runat="server">*</span>
                                </td>
                                <td align="center" valign="top">:
                                </td>
                                <td align="left" valign="top">
                                    $<asp:TextBox ID="txtTotalReserve" runat="server" SkinID="txtCurrency" />
                                </td>
                                <td align="left" valign="top">
                                </td>
                                <td align="center" valign="top">
                                </td>
                                <td align="left" valign="top">                                    
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="18%" valign="top">Unlimited Cost&nbsp;<span id="Span13" style="color: Red; display: none;" runat="server">*</span>
                                </td>
                                <td align="center" width="4%" valign="top">:
                                </td>
                                <td align="left" width="28%" valign="top">
                                    $<asp:TextBox ID="txtUnlimitedCost" runat="server" SkinID="txtCurrency" />
                                </td>
                                <td align="left" width="18%" valign="top">
                                    Limited to MV&nbsp;<span id="Span14" style="color: Red; display: none;" runat="server">*</span>
                                </td>
                                <td align="center" width="4%" valign="top">:                                    
                                </td>
                                <td align="left" width="28%" valign="top">                                    
                                    $<asp:TextBox ID="txtLimitedtoMV" runat="server" SkinID="txtCurrency" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="18%" valign="top">HC Percent&nbsp;<span id="Span15" style="color: Red; display: none;" runat="server">*</span>
                                </td>
                                <td align="center" width="4%" valign="top">:
                                </td>
                                <td align="left" width="28%" valign="top">
                                    <asp:TextBox ID="txtHCPercent" runat="server" SkinID="txtPercentage" />
                                </td>
                                <td align="left" width="18%" valign="top">
                                    HC Relief&nbsp;<span id="Span16" style="color: Red; display: none;" runat="server">*</span>
                                </td>
                                <td align="center" width="4%" valign="top">:                                    
                                </td>
                                <td align="left" width="28%" valign="top">                                    
                                    $<asp:TextBox ID="txtHCRelief" runat="server" SkinID="txtCurrency" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="18%" valign="top">Subrogation Collected&nbsp;<span id="Span17" style="color: Red; display: none;" runat="server">*</span>
                                </td>
                                <td align="center" width="4%" valign="top">:
                                </td>
                                <td align="left" width="28%" valign="top">
                                    $<asp:TextBox ID="txtSubrogationCollected" runat="server" SkinID="txtCurrency" />
                                </td>
                                <td>
                                </td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td align="left" width="18%" valign="top">
                                    Claim Activity&nbsp;<span id="Span18" style="color: Red; display: none;" runat="server">*</span>
                                </td>
                                <td align="center" width="4%" valign="top">:                                    
                                </td>
                                <td align="left" width="28%" valign="top">                                    
                                    <asp:TextBox ID="txtClaimActivity" runat="server"  MaxLength="20"  Width="140px" />
                                </td>
                                <td align="left" width="18%" valign="top">Total Charged&nbsp;<span id="Span19" style="color: Red; display: none;" runat="server">*</span>
                                </td>
                                <td align="center" width="4%" valign="top">:
                                </td>
                                <td align="left" width="28%" valign="top">
                                    $<asp:TextBox ID="txtTotalCharged" runat="server" SkinID="txtCurrency" />
                                </td>                               
                            </tr>  --%>                            
                            <tr>
                                <td align="left" width="18%" valign="top">Date of First Transaction
                                </td>
                                <td align="center" width="4%" valign="top">:
                                </td>
                                <td align="left" width="28%" valign="top">
                                    <asp:TextBox ID="txtDateofFirstTransaction" runat="server" SkinID="txtDate" />
                                    <img alt="" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDateofFirstTransaction', 'mm/dd/y');"
                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                        align="middle" /><br />
                                   <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ValidationGroup="vsErrorGroup"
                                        Display="none" ErrorMessage="Date Claim Entered is not a valid date" SetFocusOnError="true"
                                        ControlToValidate="txtDateofFirstTransaction" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>--%>
                                </td>
                                <td align="left" width="18%" valign="top">
                                    Total Paid To Date
                                </td>
                                <td align="center" width="4%" valign="top">:                                    
                                </td>
                                <td align="left" width="28%" valign="top">                                    
                                    $<asp:TextBox ID="txtTotalPaid" runat="server" onpaste="return false" SkinID="txtCurrency" />
                                </td>
                            </tr>                          
                        </table>
                    </div>
                    <div id="divView" runat="server" style="display: none;">
                        <table width="80%"  cellspacing="3" cellpadding="3">
                            <tr>
                                <td align="left" width="20%" valign="top">Claim Number&nbsp;<span id="Span21" style="color: Red;display:none;" runat="server">*</span>
                                </td>
                                <td align="center" width="2%" valign="top">:
                                </td>
                                <td align="left" width="28%" valign="top">
                                    <asp:Label ID="lblClaimNumber" runat="server" />
                                </td>
                                <td align="left" width="20%" valign="top">Associated First Report&nbsp;<span id="Span22" style="color: Red; display: none;" runat="server">*</span>
                                </td>
                                <td align="center" width="2%" valign="top">:
                                </td>
                                <td align="left" width="28%" valign="top">
                                   <asp:Label ID="lblAssociatedFirstReport" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">Sonic Location d/b/a&nbsp;<span id="Span23" style="color: Red; display: none;" runat="server">*</span>
                                </td>
                                <td align="center" valign="top">:
                                </td>
                                <td align="left" valign="top">
                                    <asp:Label ID="lblSonicLocation" runat="server" />
                                </td>
                                <td align="left" valign="top">Associate Name&nbsp;<span id="Span24" style="color: Red; display: none;" runat="server">*</span>
                                </td>
                                <td align="center" valign="top">:
                                </td>
                                <td align="left" valign="top">
                                    <asp:Label ID="lblEmployeeName" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">Date of Incident&nbsp;<span id="Span25" style="color: Red; display: none;" runat="server">*</span>
                                </td>
                                <td align="center" valign="top">:
                                </td>
                                <td align="left" valign="top">
                                   <asp:Label ID="lblDateOfIncident" runat="server" />
                                </td>
                                <td align="left" valign="top">Date Claim Opened&nbsp;<span id="Span26" style="color: Red; display: none;" runat="server">*</span>
                                </td>
                                <td align="center" valign="top">:
                                </td>
                                <td align="left" valign="top">
                                    <asp:Label ID="lblDateClaimEntered" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">Date Claim Closed&nbsp;<span id="Span27" style="color: Red; display: none;" runat="server"></span>
                                </td>
                                <td align="center" valign="top">:
                                </td>
                                <td align="left" valign="top">
                                   <asp:Label ID="lblDateClaimClosed" runat="server" />
                                </td>
                                <td align="left" valign="top">Date Claim Reopened&nbsp;<span id="Span28" style="color: Red; display: none;" runat="server"></span>
                                </td>
                                <td align="center" valign="top">:
                                </td>
                                <td align="left" valign="top">
                                    <asp:Label ID="lblDateClaimReopened" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">Claim Status&nbsp;<span id="Span29" style="color: Red; display: none;" runat="server">*</span>
                                </td>
                                <td align="center" valign="top">:
                                </td>
                                <td align="left" valign="top">
                                    <asp:Label ID="lblStatus" runat="server" />                               
                                </td>
                                <%--<td align="left" valign="top">Type&nbsp;<span id="Span30" style="color: Red; display: none;" runat="server">*</span>
                                </td>
                                <td align="center" valign="top">:
                                </td>
                                <td align="left" valign="top">
                                    <asp:Label ID="lblType" runat="server" />
                                </td>--%>
                            </tr>
                            <%--<tr>
                                <td align="left" valign="top">Total Medical&nbsp;<span id="Span31" style="color: Red; display: none;" runat="server">*</span>
                                </td>
                                <td align="center" valign="top">:
                                </td>
                                <td align="left" valign="top">
                                    <asp:Label ID="lblTotalMedical" runat="server" />
                                </td>
                                <td align="left" valign="top">Total Comp&nbsp;<span id="Span32" style="color: Red; display: none;" runat="server">*</span>
                                </td>
                                <td align="center" valign="top">:
                                </td>
                                <td align="left" valign="top">
                                    <asp:Label ID="lblTotalComp" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">Total Reserve&nbsp;<span id="Span33" style="color: Red; display: none;" runat="server">*</span>
                                </td>
                                <td align="center" valign="top">:
                                </td>
                                <td align="left" valign="top">
                                    <asp:Label ID="lblTotalReserve" runat="server" />
                                </td>
                                <td align="left" valign="top">
                                </td>
                                <td align="center" valign="top">
                                </td>
                                <td align="left" valign="top">                                    
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="18%" valign="top">Unlimited Cost&nbsp;<span id="Span34" style="color: Red; display: none;" runat="server">*</span>
                                </td>
                                <td align="center" width="4%" valign="top">:
                                </td>
                                <td align="left" width="28%" valign="top">
                                    <asp:Label ID="lblUnlimitedCost" runat="server" />
                                </td>
                                <td align="left" width="18%" valign="top">
                                    Limited to MV&nbsp;<span id="Span35" style="color: Red; display: none;" runat="server">*</span>
                                </td>
                                <td align="center" width="4%" valign="top">:                                    
                                </td>
                                <td align="left" width="28%" valign="top">                                    
                                    <asp:Label ID="lblLimitedToMV" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="18%" valign="top">HC Percent&nbsp;<span id="Span36" style="color: Red; display: none;" runat="server">*</span>
                                </td>
                                <td align="center" width="4%" valign="top">:
                                </td>
                                <td align="left" width="28%" valign="top">
                                    <asp:Label ID="lblHCPercent" runat="server" />
                                </td>
                                <td align="left" width="18%" valign="top">
                                    HC Relief&nbsp;<span id="Span37" style="color: Red; display: none;" runat="server">*</span>
                                </td>
                                <td align="center" width="4%" valign="top">:                                    
                                </td>
                                <td align="left" width="28%" valign="top">                                    
                                    <asp:Label ID="lblHCRelief" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="18%" valign="top">Subrogation Collected&nbsp;<span id="Span38" style="color: Red; display: none;" runat="server">*</span>
                                </td>
                                <td align="center" width="4%" valign="top">:
                                </td>
                                <td align="left" width="28%" valign="top">
                                    <asp:Label ID="lblSubCollected" runat="server" />
                                </td>
                                <td>
                                </td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td align="left" width="18%" valign="top">
                                    Claim Activity&nbsp;<span id="Span39" style="color: Red; display: none;" runat="server">*</span>
                                </td>
                                <td align="center" width="4%" valign="top">:                                    
                                </td>
                                <td align="left" width="28%" valign="top">                                    
                                     <asp:Label ID="lblClaimActivity" runat="server" />
                                </td>
                                <td align="left" width="18%" valign="top">Total Charged&nbsp;<span id="Span40" style="color: Red; display: none;" runat="server">*</span>
                                </td>
                                <td align="center" width="4%" valign="top">:
                                </td>
                                <td align="left" width="28%" valign="top">
                                    <asp:Label ID="lblTotalCharged" runat="server" />
                                </td>                               
                            </tr> --%>          
                            <tr>
                                <td align="left" width="18%" valign="top">
                                    Date of First Transaction
                                </td>
                                <td align="center" width="4%" valign="top">:                                    
                                </td>
                                <td align="left" width="28%" valign="top">                                    
                                     <asp:Label ID="lblDateOfFirstTransaction" runat="server" />
                                </td>
                                <td align="left" width="18%" valign="top">Total Paid To Date
                                </td>
                                <td align="center" width="4%" valign="top">:
                                </td>
                                <td align="left" width="28%" valign="top">
                                    <asp:Label ID="lblTotalPaidToDate" runat="server" />
                                </td>                               
                            </tr>                    
                        </table>
                        <%--<table width="80%">
                            <tr>
                                <td align="left" width="18%" valign="top">
                                    Associated First Report
                                </td>
                                <td align="center" width="4%" valign="top">
                                    :
                                </td>
                                <td align="left" width="28%" valign="top">
                                    <asp:Label ID="lblAssociatedFirstReport" runat="server" />
                                </td>
                                <td align="left" width="18%" valign="top">
                                    Employee Name
                                </td>
                                <td align="center" width="4%" valign="top">
                                    :
                                </td>
                                <td align="left" width="28%" valign="top">
                                    <asp:Label ID="lblEmployeeName" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="18%" valign="top">
                                    Claim Number
                                </td>
                                <td align="center" width="4%" valign="top">
                                    :
                                </td>
                                <td align="left" width="28%" valign="top">
                                    <asp:Label ID="lblClaimNumber" runat="server" />
                                </td>
                                <td align="left" width="18%" valign="top">
                                    Sonic Location d/b/a
                                </td>
                                <td align="center" width="4%" valign="top">
                                    :
                                </td>
                                <td align="left" width="28%" valign="top">
                                    <asp:Label ID="lblSonicLocation" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="18%" valign="top">
                                    Date Claim Entered
                                </td>
                                <td align="center" width="4%" valign="top">
                                    :
                                </td>
                                <td align="left" width="28%" valign="top">
                                    <asp:Label ID="lblDateClaimEntered" runat="server" />
                                </td>
                                <td align="left" width="18%" valign="top">
                                    Date Claim Closed
                                </td>
                                <td align="center" width="4%" valign="top">
                                    :
                                </td>
                                <td align="left" width="28%" valign="top">
                                    <asp:Label ID="lblDateClaimClosed" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="18%" valign="top">
                                    Date Claim Reopened
                                </td>
                                <td align="center" width="4%" valign="top">
                                    :
                                </td>
                                <td align="left" valign="top" colspan="4">
                                    <asp:Label ID="lblDateClaimReopened" runat="server" />
                                </td>
                            </tr>
                        </table>--%>
                    </div>
                </td>
            </tr>
            <tr><td class="Spacer" style="height:10px;"></td></tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnSave" runat="server" Text=" Save " OnClick="btnSave_Click" ValidationGroup="vsErrorGroup" />
                    &nbsp;
                    <asp:Button ID="btnEdit" runat="server" Text=" Edit " OnClick="btnEdit_Click" />
                    &nbsp;
                    <asp:Button ID="btnBack" runat="server" Text=" Back " OnClick="btnBack_Click" />
                    &nbsp;
                    <asp:Button runat="server" ID="btnAudit" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();"
                        ToolTip="View Audit Trail" CausesValidation="false" />
                </td>
            </tr>
             <tr><td class="Spacer" style="height:10px;"></td></tr>
        </table>
    </div>
      <asp:CustomValidator ID="CustomValidator" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
        Display="None" ValidationGroup="vsErrorGroup" />
    <input id="hdnControlIDs" runat="server" type="hidden" />
    <input id="hdnErrorMsgs" runat="server" type="hidden" />
</asp:Content>
