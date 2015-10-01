<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="CRM_Customer.aspx.cs" Inherits="SONIC_CRM_CRM_Customer" ValidateRequest="false" %>

<%@ Register Src="~/Controls/CRMTab/CRMTab.ascx" TagName="Tab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/CRMInfo/CRMInfo_Customer.ascx" TagName="Info" TagPrefix="uc" %>
<%@ Register Src="~/Controls/NotesWithSpellCheck/Notes.ascx" TagName="ctrlMultiLineTextBox"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment_CRM/Attachment.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment_CRM/AttachmentDetails.ascx" TagName="ctrlAttachmentDetails"
    TagPrefix="uc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" src="../../JavaScript/JFunctions.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript">
        function SetMenuStyle(index) {
            var i;
            for (i = 1; i <= 8; i++) {
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

        var ActiveTabIndex = 1;
        function onNextStep() {
            var op = '<%=StrOperation%>';
            if (op == "view") {
                ActiveTabIndex = ActiveTabIndex + 1;
                ShowPanelView(ActiveTabIndex);
                return false;
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

        function ShowPanel(index) {
            SetMenuStyle(index);
            ActiveTabIndex = index;
            document.getElementById("ctl00_ContentPlaceHolder1_hdnPanel").value = ActiveTabIndex;
            var op = '<%=StrOperation%>';
            if (op == "view") {
                ShowPanelView(index);
            }
            else {
                var i;
                if (index < 8) {
                    for (i = 1; i <= 7; i++) {
                        document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display = (i == index) ? "block" : "none";
                    }
                    document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "none";
                    document.getElementById("<%=btnNextStep.ClientID%>").style.display = "inline";
                }
                else {
                    for (i = 1; i <= 7; i++) {
                        document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display = "none";
                    }
                    document.getElementById("<%=dvAttachment.ClientID%>").style.display = "block";
                    document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "block";
                    document.getElementById("<%=btnNextStep.ClientID%>").style.display = "none";
                }
                SetFocusOnFirstControl(index)
            }
            if (index == 1) document.getElementById("ctl00_ContentPlaceHolder1_btnPreviousStep").style.display = "none";
            else document.getElementById("ctl00_ContentPlaceHolder1_btnPreviousStep").style.display = "block";
        }

        function ShowPanelView(index) {
            SetMenuStyle(index);
            document.getElementById('<%=dvView.ClientID%>').style.display = "block";
            var i;
            if (index < 8) {
                for (i = 1; i <= 7; i++) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i + "View").style.display = (i == index) ? "block" : "none";
                }
                document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "none";
                document.getElementById("<%=btnNextStep.ClientID%>").style.display = "inline";
            }
            else {
                for (i = 1; i <= 7; i++) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i + "View").style.display = "none";
                }
                document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "block";
                document.getElementById("<%=btnNextStep.ClientID%>").style.display = "none";
            }
            if (index == 1) document.getElementById("ctl00_ContentPlaceHolder1_btnPreviousStep").style.display = "none";
            else document.getElementById("ctl00_ContentPlaceHolder1_btnPreviousStep").style.display = "block";
        }

        function ValSave() {
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_cstFile').enabled = false;
            if (Page_ClientValidate())
                return true;
            else {
                Page_ClientValidate('Dummy');
                return false;
            }
        }

        function YearValidate(x) {
            var strErrorInval = "";
            var strErrorLess = "";
            strErrorInval = "Year is Invalid.";
            strErrorLess = "Year should be less than or equal to next year.";

            var right_now = new Date();
            var the_year = right_now.getYear();
            the_year = the_year + 1;

            var y = document.getElementById(x).value;
            if (y.length < 4 && y.length > 0) {
                alert(strErrorInval);
                document.getElementById(x).select();
            }
            if (y != the_year && y > the_year) {
                alert(strErrorLess);
                document.getElementById(x).select();
            }
        }

        function ShowHideLegalEmail(rdoID) {
            var rdoYes = document.getElementById(rdoID + '_0');
            if (rdoYes.checked) {
                document.getElementById('<%=drpFK_LU_CRM_Legal_Email.ClientID %>').disabled = false;
                document.getElementById('<%=Span34.ClientID %>').style.display = "block";
            }
            else {
                document.getElementById('<%=drpFK_LU_CRM_Legal_Email.ClientID %>').selectedIndex = 0;
                document.getElementById('<%=drpFK_LU_CRM_Legal_Email.ClientID %>').disabled = true;
                document.getElementById('<%=Span34.ClientID %>').style.display = "none";
            }
        }

        function CalculateDaysClosed(PanelNum) {
            var txtIncidentDate = document.getElementById("ctl00_ContentPlaceHolder1_txtRecord_Date").value;
            var txtCloseDate = document.getElementById("ctl00_ContentPlaceHolder1_txtClose_Date").value;
            if (txtIncidentDate != '' && txtCloseDate != '')
                __doPostBack('CalculateNumDaysClosed', PanelNum);
            else
                document.getElementById("ctl00_ContentPlaceHolder1_txtDays_To_Close").value = '';
        }
        function IfSave() {
            var values = '<%=ViewState["PK_CRM_Customer"]%>';
            if (values == '0') {
                alert('Please Save Customer Information First');
                ShowPanel(1);
                return false;
            }
            else return Page_ClientValidate('AddAttachment');
        }

        function SetFocusOnFirstControl(index) {

            switch (index) {
                case 1:
                    document.getElementById('ctl00_ContentPlaceHolder1_drpFK_LU_CRM_Source').focus(); break;
                case 2:
                    document.getElementById('ctl00_ContentPlaceHolder1_drpFK_LU_CRM_Department').focus(); break;
                case 3:
                    document.getElementById('ctl00_ContentPlaceHolder1_drpFK_LU_CRM_Contacted_Resolution_2').focus(); break;
                case 4:
                    document.getElementById('ctl00_ContentPlaceHolder1_lnkAddComplaint').focus(); break;
                case 5:
                    document.getElementById('ctl00_ContentPlaceHolder1_lnkAddFieldNote').focus(); break;
                case 6:
                    document.getElementById('ctl00_ContentPlaceHolder1_rdoComplete').focus(); break;
                case 7:
                    document.getElementById('ctl00_ContentPlaceHolder1_txtEmailDateSent').focus(); break;
                case 8:
                    document.getElementById('ctl00_ContentPlaceHolder1_Attachment_txtAttachDesc_txtNote').focus();
                default:
                    break;
            }
        }
        function ShowCustomerMailPage() {
            var pkid = '<%=Encryption.Encrypt(PK_CRM_Customer.ToString()) %>';
            var winHeight = window.screen.availHeight - 600;
            var winWidth = window.screen.availWidth - 800;
            var navigateurl = '<%=AppConfig.SiteURL%>SONIC/CRM/AbstractMail.aspx?ID=' + pkid;
            obj = window.open(navigateurl, 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }
        function OpenAuditPopUp() {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;

            obj = window.open('AuditPopup_CRM_Customer.aspx?id=<%=ViewState["PK_CRM_Customer"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }

        function BindGridEmailLog() {
            __doPostBack('UpdateEmailLogGrid', ActiveTabIndex);
        }

        function ConfirmRemove() {
            return confirm("Are you sure to remove?");
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
                        case "select-one":
                            if (ctrl.selectedIndex == 0) {
                                if (ctrl.id == 'ctl00_ContentPlaceHolder1_drpFK_LU_CRM_Legal_Email') {
                                    var rdb = document.getElementById('ctl00_ContentPlaceHolder1_rdoLegal_Attorney_General_0');
                                    //used to check dropdowns selected value. if it is equal to Disposed than display Disposal type control else hide.
                                    if (rdb.checked)
                                        bEmpty = true;
                                }
                                else
                                    bEmpty = true;
                            }
                            break;
                    }
                    //if (bEmpty && focusCtrlID == "") {
                    //    focusCtrlID = ctrlIDs[i];
                    //    document.getElementById(ctrlIDs[i]).focus();
                    //                     };
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
    <br />
    <uc:Tab ID="ucCRMTab" runat="server" />
    <br />
    <uc:Info ID="ucCRMInfo" runat="server" />
    <table cellpadding="0" cellspacing="0" width="100%">
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
                                    <td align="left" width="100%">
                                        <span id="Menu1" onclick="javascript:ShowPanel(1);" class="LeftMenuStatic">Customer
                                            Information&nbsp;<span id="MenuAsterisk1" runat="server" style="color: Red;display:none">*</span></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu2" onclick="javascript:ShowPanel(2);" class="LeftMenuStatic">Department
                                        Information&nbsp;<span id="MenuAsterisk2" runat="server" style="color: Red;display:none">*</span></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu3" onclick="javascript:ShowPanel(3);" class="LeftMenuStatic">Contacts
                                        and Dates&nbsp;<span id="MenuAsterisk3" runat="server" style="color: Red;display:none">*</span></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu4" onclick="javascript:ShowPanel(4);" class="LeftMenuStatic">Incident
                                            Grid</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu5" onclick="javascript:ShowPanel(5);" class="LeftMenuStatic">Field Notes</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu6" onclick="javascript:ShowPanel(6);" class="LeftMenuStatic">Resolution
                                        <span id="MenuAsterisk6" runat="server" style="color: Red;display:none">*</span></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu7" onclick="javascript:ShowPanel(7);" class="LeftMenuStatic">Email Log</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu8" onclick="javascript:ShowPanel(8);" class="LeftMenuStatic">Attachments</span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td width="5px" class="Spacer">
                                        &nbsp;
                                    </td>
                                    <td class="dvContainer" width="794px">
                                        <div id="dvEdit" runat="server" width="794px">
                                            <asp:Panel ID="pnl1" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Customer Information</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Complaint Number
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtComplaintNumber" runat="server" Enabled="false" Width="170px" />
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Source&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="drpFK_LU_CRM_Source" Width="175px" runat="server" SkinID="dropGen">
                                                            </asp:DropDownList>
                                                            <%--<asp:RequiredFieldValidator ID="rfvFK_LU_CRM_Source" runat="server" ControlToValidate="drpFK_LU_CRM_Source"
                                                                Display="None" ErrorMessage="Please select [Customer Information]/Source" InitialValue="0"
                                                                SetFocusOnError="true" ValidationGroup="vsErrorGroup" />--%>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            Date of Incident&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtRecord_Date" runat="server" Width="150px" SkinID="txtDate" onblur="CalculateDaysClosed(1);" />
                                                            <img alt="Date of Incident" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtRecord_Date', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                onmouseout="javascript:ctl00_ContentPlaceHolder1_txtRecord_Date.focus();" align="middle" />
                                                            <asp:RegularExpressionValidator ID="revRecord_Date" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[Customer Information]/Date of Incident is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtRecord_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            <%--<asp:RequiredFieldValidator ID="rfvRecord_Date" runat="server" ControlToValidate="txtRecord_Date"
                                                                Display="None" ErrorMessage="Please enter [Customer Information]/Date of Incident"
                                                                SetFocusOnError="true" ValidationGroup="vsErrorGroup" />--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Last Name&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtLast_Name" runat="server" Width="170px" MaxLength="50" />
                                                            <%--<asp:RequiredFieldValidator ID="rfvLast_Name" runat="server" ControlToValidate="txtLast_Name"
                                                                Display="None" ErrorMessage="Please enter [Customer Information]/Last Name" SetFocusOnError="true"
                                                                ValidationGroup="vsErrorGroup" />--%>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            First Name&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtFirst_Name" runat="server" Width="170px" MaxLength="50" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Last Name Co-Buyer or Caller&nbsp;<span id="spnLastNameCaller" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtLast_Name_Co_Buyer" runat="server" Width="170px" MaxLength="50" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            First Name Co-Buyer or Caller&nbsp;<span id="spnFirstNameCaller" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtFirst_Name_Co_Buyer" runat="server" Width="170px" MaxLength="50" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Address&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtAddress" runat="server" Width="170px" MaxLength="75" />
                                                            <%--<asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress"
                                                                Display="None" ErrorMessage="Please enter [Customer Information]/Address" SetFocusOnError="true"
                                                                ValidationGroup="vsErrorGroup" />--%>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            City&nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtCity" runat="server" Width="170px" MaxLength="30" />
                                                            <%--<asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="txtCity"
                                                                Display="None" ErrorMessage="Please enter [Customer Information]/City" SetFocusOnError="true"
                                                                ValidationGroup="vsErrorGroup" />--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            State&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="drpFK_State" Width="175px" runat="server" SkinID="dropGen">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Zip (XXXXX-XXXX)&nbsp;<span id="Span8" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtZip_Code" runat="server" Width="170px" MaxLength="10" onKeyPress="javascript:return FormatZipCode(event,this.id);" />
                                                            <asp:RegularExpressionValidator ID="revZipCode" runat="server" ErrorMessage="Please enter Valid [Customer Information]/Zip"
                                                                ControlToValidate="txtZip_Code" ValidationExpression="\b[0-9]{5}-[0-9]{4}\b|\b[0-9]{5}\b"
                                                                ValidationGroup="vsErrorGroup" SetFocusOnError="true" Display="None" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Email&nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:TextBox ID="txtEmail" runat="server" Width="565px" MaxLength="255" />
                                                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Please enter Valid [Customer Information]/Email"
                                                                ValidationGroup="vsErrorGroup" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                Display="None" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Home Telephone (XXX-XXX-XXXX)&nbsp;<span id="Span10" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtHome_Telephone" runat="server" Width="170px" MaxLength="12" SkinID="txtPhone" />
                                                            <asp:RegularExpressionValidator ID="revHomePhone" runat="server" ErrorMessage="Please enter Valid [Customer Information]/Home Telephone"
                                                                ValidationGroup="vsErrorGroup" ControlToValidate="txtHome_Telephone" ValidationExpression="\b[0-9]{3}-[0-9]{3}-[0-9]{4}\b"
                                                                Display="None" SetFocusOnError="true" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Cell Telephone (XXX-XXX-XXXX)&nbsp;<span id="Span11" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtCell_Telephone" runat="server" Width="170px" MaxLength="12" SkinID="txtPhone" />
                                                            <asp:RegularExpressionValidator ID="rfvCellPhone" runat="server" ErrorMessage="Please enter Valid [Customer Information]/Cell Telephone"
                                                                ValidationGroup="vsErrorGroup" ControlToValidate="txtCell_Telephone" ValidationExpression="\b[0-9]{3}-[0-9]{3}-[0-9]{4}\b"
                                                                Display="None" SetFocusOnError="true" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Work Telephone (XXX-XXX-XXXX)&nbsp;<span id="Span12" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtWork_Telephone" runat="server" Width="170px" MaxLength="12" SkinID="txtPhone" />
                                                            <asp:RegularExpressionValidator ID="rfvWorkPhone" runat="server" ErrorMessage="Please enter Valid [Customer Information]/Work Telephone"
                                                                ValidationGroup="vsErrorGroup" ControlToValidate="txtWork_Telephone" ValidationExpression="\b[0-9]{3}-[0-9]{3}-[0-9]{4}\b"
                                                                Display="None" SetFocusOnError="true" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Work Telephone Extension&nbsp;<span id="Span13" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtWork_Telephone_Extension" runat="server" Width="170px" MaxLength="5"
                                                                onkeypress="return CheckNum(this.id);" onpaste="return false" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Summary&nbsp;<span id="Span14" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtSummary" IsRequired="false" RequiredFieldMessage="Please enter [Customer Information]/Summary"
                                                                ValidationGroup="vsErrorGroup" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Resolution Summary&nbsp;<span id="Span15" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtResolution_Summary" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl2" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Department Information</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Department&nbsp;<span id="Span16" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:DropDownList ID="drpFK_LU_CRM_Department" Width="175px" runat="server" SkinID="dropGen">
                                                            </asp:DropDownList>
                                                            <%--<asp:RequiredFieldValidator ID="rfvFK_LU_CRM_Department" runat="server" ControlToValidate="drpFK_LU_CRM_Department"
                                                                Display="None" ErrorMessage="Please select [Department Information]/Department"
                                                                InitialValue="0" SetFocusOnError="true" ValidationGroup="vsErrorGroup" />--%>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            Department Detail&nbsp;<span id="Span17" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:DropDownList ID="drpFK_LU_CRM_Dept_Desc_Detail" Width="175px" runat="server"
                                                                SkinID="dropGen">
                                                            </asp:DropDownList>
                                                            <%--<asp:RequiredFieldValidator ID="rfvFK_LU_CRM_Dept_Desc_Detail" runat="server" ControlToValidate="drpFK_LU_CRM_Dept_Desc_Detail"
                                                                Display="None" ErrorMessage="Please select [Department Information]/Department Detail"
                                                                InitialValue="0" SetFocusOnError="true" ValidationGroup="vsErrorGroup" />--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Date of Service&nbsp;<span id="Span18" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtService_Date" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Date of Service" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtService_Date', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revService_Date" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[Department Information]/Date of Service is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtService_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            <%--<asp:RequiredFieldValidator ID="rfvService_Date" runat="server" ControlToValidate="txtService_Date"
                                                                Display="None" ErrorMessage="Please enter [Department Information]/Date of Service"
                                                                SetFocusOnError="true" ValidationGroup="vsErrorGroup" />--%>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Date of Service Estimated?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList ID="rdoService_Date_Est" runat="server" Width="40%" SkinID="YesNoType">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Dealer&nbsp;<span id="Span19" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:DropDownList ID="drpFK_LU_Location" Width="568px" runat="server" SkinID="dropGen">
                                                            </asp:DropDownList>
                                                            <%--<asp:RequiredFieldValidator ID="rfvFK_LU_Location" runat="server" ControlToValidate="drpFK_LU_Location"
                                                                Display="None" ErrorMessage="Please select [Department Information]/Dealer" InitialValue="0"
                                                                SetFocusOnError="true" ValidationGroup="vsErrorGroup" />--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Brand&nbsp;<span id="Span20" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="drpFK_LU_CRM_Brand" Width="175px" runat="server" SkinID="dropGen">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Model&nbsp;<span id="Span21" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtModel" runat="server" Width="170px" MaxLength="30" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Year&nbsp;<span id="Span22" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:TextBox ID="txtYear" runat="server" Width="170px" MaxLength="4" onkeypress="return CheckNum(this.id);"
                                                                onblur="return YearValidate(this.id);" onpaste="return false" />
                                                        </td>
                                                    </tr>
                                                    <tr height="53">
                                                        <td align="left" valign="top" colspan="6">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl3" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Contacts and Dates</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            CRM Contacted&nbsp;<span id="Span23" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:DropDownList ID="drpFK_LU_CRM_Contacted_Resolution_2" Width="175px" runat="server"
                                                                SkinID="dropGen">
                                                            </asp:DropDownList>
                                                            <%--<asp:RequiredFieldValidator ID="rfvFK_LU_CRM_Contacted_Resolution_2" runat="server"
                                                                ControlToValidate="drpFK_LU_CRM_Contacted_Resolution_2" Display="None" ErrorMessage="Please select [Contacts and Dates]/CRM Contacted"
                                                                InitialValue="0" SetFocusOnError="true" ValidationGroup="vsErrorGroup" />--%>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Resolution Manager&nbsp;<span id="Span24" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:DropDownList ID="drpFK_LU_CRM_Contacted_Resolution_1" Width="175px" runat="server"
                                                                SkinID="dropGen">
                                                            </asp:DropDownList>
                                                            <%--<asp:RequiredFieldValidator ID="rfvFK_LU_CRM_Contacted_Resolution_1" runat="server"
                                                                ControlToValidate="drpFK_LU_CRM_Contacted_Resolution_1" Display="None" ErrorMessage="Please select [Contacts and Dates]/Resolution Manager"
                                                                InitialValue="0" SetFocusOnError="true" ValidationGroup="vsErrorGroup" />--%>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Resolution Manager Name&nbsp;<span id="Span25" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtResolution_Manager" runat="server" Width="170px" MaxLength="50" />
                                                            <%--<asp:RequiredFieldValidator ID="rfvResolution_Manager" runat="server" ControlToValidate="txtResolution_Manager"
                                                                Display="None" ErrorMessage="Please enter [Contacts and Dates]/Resolution Manager Name"
                                                                SetFocusOnError="true" ValidationGroup="vsErrorGroup" />--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Resolution Manager Email&nbsp;<span id="Span26" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtResolution_Manager_Email" runat="server" Width="170px" MaxLength="255" />
                                                            <asp:RegularExpressionValidator ID="revResolutionEmail" runat="server" ErrorMessage="Please enter Valid [Contacts and Dates]/Resolution Manager Email"
                                                                ValidationGroup="vsErrorGroup" ControlToValidate="txtResolution_Manager_Email"
                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="None"
                                                                SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Customer Contacted GM?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList ID="rdoCustomer_Contacted_GM" runat="server" SkinID="YesNoType">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Date of Contact GM&nbsp;<span id="Span27" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtGM_Contact_Date" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Date of Contact GM" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtGM_Contact_Date', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revGM_Contact_Date" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[Contacts and Dates]/Date of Contact GM is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtGM_Contact_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            GM Name&nbsp;<span id="Span28" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtGM_Name" runat="server" Width="170px" MaxLength="50" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Date of Contact RVP&nbsp;<span id="Span29" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtRVP_Contact_Date" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Date of Contact RVP" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtRVP_Contact_Date', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revRVP_Contact_Date" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[Contacts and Dates]/Date of Contact RVP is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtRVP_Contact_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            RVP Name&nbsp;<span id="Span30" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="drpFK_LU_CRM_RVP" Width="175px" runat="server" SkinID="dropGen">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Date of Contact DFOD&nbsp;<span id="Span31" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtDFOD_Contact_Date" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Date of Contact DFOD" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDFOD_Contact_Date', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revDFOD_Contact_Date" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[Contacts and Dates]/Date of Contact DFOD is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtDFOD_Contact_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            DFOD&nbsp;<span id="Span32" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="drpFK_LU_CRM_DFOD" Width="175px" runat="server" SkinID="dropGen">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Other Contact Name&nbsp;<span id="Span33" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtOther_Cotnact_Name" runat="server" Width="170px" MaxLength="50" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Legal/Attorney General?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList ID="rdoLegal_Attorney_General" runat="server" SkinID="YesNoType"
                                                                onclick="ShowHideLegalEmail(this.id);">
                                                            </asp:RadioButtonList>
                                                            <input type="hidden" id="hdnLegal_Attorney_GeneralOLDVal" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Legal Email&nbsp;<span id="Span34" style="color: Red; display: none; position: absolute"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="drpFK_LU_CRM_Legal_Email" Width="175px" runat="server" SkinID="dropGen">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Demand Letter?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList ID="rdoDemand_Letter" runat="server" SkinID="YesNoType">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Date of Last Update&nbsp;<span id="Span35" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:TextBox ID="txtUpdate_Date" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Date of Last Update" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtUpdate_Date', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[Contacts and Dates]/Date of Last Update is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtUpdate_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Last Action&nbsp;<span id="Span36" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="txtLast_Action" runat="server"   />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl4" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Incident Grid</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%" height="185">
                                                    <tr valign="top" align="left">
                                                        <td align="left" width="21%" valign="top">
                                                            Incident Grid<br />
                                                            <asp:LinkButton ID="lnkAddComplaint" runat="server" Text="--Add--" OnClientClick="javascript:return ValSave();"
                                                                OnClick="lnkAddComplaint_Click" />
                                                        </td>
                                                        <td align="center" valign="top" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" width="75%">
                                                            <div id="divgvComplaint" runat="server" style="overflow-x: hidden; overflow-y: scroll;
                                                                width: 600px; height: 200px">
                                                                <asp:GridView ID="gvComplaint" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                    EmptyDataText="No Records Found" OnRowCommand="gvComplaint_RowCommand">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Date">
                                                                            <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                            <ItemTemplate>
                                                                                <a href='CRM_Customer_Complaint_Notes.aspx?id=<%#Encryption.Encrypt(Eval("PK_CRM_Notes").ToString())%>&mode=<%# (StrOperation == "" ? "edit" : StrOperation) %>&pid=<%#Encryption.Encrypt(Eval("FK_Table_Name").ToString())%>&bmode=<%# (StrOperation == "" ? "edit" : StrOperation) %>'>
                                                                                    <%#(Eval("Note_Date")) == DBNull.Value ? "" : Eval("Note_Date", "{0:MM-dd-yyyy}")%>
                                                                                </a>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Note Abstract">
                                                                            <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblNote" runat="server" Text='<%# Eval("Note")%>' Width="350px" CssClass="TextClip" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Remove" HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkRemove" runat="server" Text='Remove' CommandName="RemoveNote"
                                                                                    CommandArgument='<%# Eval("PK_CRM_Notes") %>' OnClientClick="return confirm('Are you sure to remove the record?');" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl5" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Field Notes</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%" height="185">
                                                    <tr valign="top" align="left">
                                                        <td align="left" width="21%" valign="top">
                                                            Field Notes Grid<br />
                                                            <asp:LinkButton ID="lnkAddFieldNote" runat="server" Text="--Add--" OnClientClick="javascript:return ValSave();"
                                                                OnClick="lnkAddFieldNote_Click" />
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" width="75%">
                                                            <div id="divgvFieldNotes" runat="server" style="overflow-x: hidden; overflow-y: scroll;
                                                                width: 600px; height: 200px">
                                                                <asp:GridView ID="gvFieldNotes" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                    EmptyDataText="No Records Found" OnRowCommand="gvFieldNotes_RowCommand">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Date">
                                                                            <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                            <ItemTemplate>
                                                                                <a href='CRM_Customer_Notes.aspx?id=<%#Encryption.Encrypt(Eval("PK_CRM_Notes").ToString())%>&mode=<%# (StrOperation == "" ? "edit" : StrOperation) %>&pid=<%#Encryption.Encrypt(Eval("FK_Table_Name").ToString())%>&bmode=<%# (StrOperation == "" ? "edit" : StrOperation) %>'>
                                                                                    <%#(Eval("Note_Date")) == DBNull.Value ? "" : Eval("Note_Date", "{0:MM-dd-yyyy}")%>
                                                                                </a>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Note Abstract">
                                                                            <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblNote" runat="server" Text='<%# Eval("Note")%>' Width="350px" CssClass="TextClip" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Remove" HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkRemove" runat="server" Text='Remove' CommandName="RemoveNote"
                                                                                    CommandArgument='<%# Eval("PK_CRM_Notes") %>' OnClientClick="return confirm('Are you sure to remove the record?');" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <br />
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr valign="top" align="left">
                                                        <td style="width: 35%">
                                                            Field Resolution Information
                                                            <br />
                                                            <asp:LinkButton ID="lnkResolution" runat="server" Text="--Add--" OnClick="lnkResolution_Click"></asp:LinkButton>
                                                        </td>
                                                        <td align="center" valign="top" style="width: 2%">
                                                            :
                                                        </td>
                                                        <td style="width: 63%">
                                                            <div id="divgvResolution" runat="server" style="overflow-x: hidden; overflow-y: scroll;
                                                                width: 610px; height: 200px">
                                                                <asp:GridView ID="gvResolution" runat="server" AutoGenerateColumns="false" Width="100%"
                                                                    OnRowCommand="gvResolution_RowCommand">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Date" ItemStyle-Width="12%" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <a href='CRM_Customer_Resolution_Notes.aspx?id=<%#Encryption.Encrypt(Eval("PK_CRM_Notes").ToString())%>&mode=<%# (StrOperation == "" ? "edit" : StrOperation) %>&pid=<%#Encryption.Encrypt(Eval("FK_Table_Name").ToString())%>&bmode=<%# (StrOperation == "" ? "edit" : StrOperation) %>'>
                                                                                    <%#(Eval("Note_Date")) == DBNull.Value ? "" : Eval("Note_Date", "{0:MM-dd-yyyy}")%>
                                                                                </a>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Note Abstract" ItemStyle-Width="75%" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <%#Eval("Note")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Remove" ItemStyle-Width="13%" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lblRemove" runat="server" CommandName="Remove" CommandArgument='<%#Eval("PK_CRM_Notes") %>'
                                                                                    OnClientClick="javascript:return ConfirmRemove();" Text="Remove" ToolTip="Remove"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                                    <EmptyDataTemplate>
                                                                        No Record found.
                                                                    </EmptyDataTemplate>
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl6" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Resolution</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Complete?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList ID="rdoComplete" runat="server" SkinID="YesNoType">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            Close Date&nbsp;<span id="Span37" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtClose_Date" runat="server" Width="150px" SkinID="txtDate" onblur="CalculateDaysClosed(6);" />
                                                            <img alt="Close Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtClose_Date', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                onmouseout="javascript:ctl00_ContentPlaceHolder1_txtClose_Date.focus();" align="middle" />
                                                            <asp:RegularExpressionValidator ID="revClose_Date" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[Resolution]/Close Date is not a valid date" SetFocusOnError="true"
                                                                ControlToValidate="txtClose_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            <asp:CompareValidator ID="cvCloseDate" runat="server" ControlToValidate="txtClose_Date"
                                                                ControlToCompare="txtRecord_Date" ValidationGroup="vsErrorGroup" ErrorMessage="[Resolution]/Close Date must be greater than or equal to [Customer Information]/Date of Incident"
                                                                Type="Date" Operator="GreaterThanEqual" Display="None" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Days to Close
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtDays_To_Close" runat="server" Width="170px" Enabled="false" onkeypress="return FormatNumber(event,this.id,4,true);"
                                                                onpaste="return false" />
                                                            <asp:TextBox ID="txtMaxDays" runat="server" Text="9999" Style="display: none" />
                                                            <asp:CompareValidator ID="cvDays_To_Close" runat="server" ControlToValidate="txtDays_To_Close"
                                                                ControlToCompare="txtMaxDays" Type="Integer" Operator="LessThanEqual" ErrorMessage="[Resolution]/Days to Close should be less than or equal to 9999"
                                                                Display="None" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Customer Call Back After Resolved?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList ID="rdoCustomer_Callback_After_Resolution" runat="server" SkinID="YesNoType">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Resolution Letter to Customer?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList ID="rdoResolution_Letter_To_Customer" runat="server" SkinID="YesNoType">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Date Resolution Letter Sent&nbsp;<span id="Span38" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtDate_Resolution_Letter_Sent" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Date Resolution Letter Sent" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Resolution_Letter_Sent', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revDate_Resolution_Letter_Sent" runat="server"
                                                                ValidationGroup="vsErrorGroup" Display="none" ErrorMessage="[Resolution]/Date Resolution Letter Sent is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtDate_Resolution_Letter_Sent" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Sent By&nbsp;<span id="Span39" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="drpFK_LU_CRM_Response_Method" Width="175px" runat="server"
                                                                SkinID="dropGen">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Letter N/A?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList ID="rdoLetter_NA" runat="server" SkinID="YesNoType">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Letter N/A Reason&nbsp;<span id="Span40" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="drpFK_LU_CRM_Letter_NA_Reason" Width="175px" runat="server"
                                                                SkinID="dropGen">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Letter N/A Note&nbsp;<span id="Span41" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtLetter_NA_Note" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl7" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Email Log</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" valign="top" width="100%">
                                                            <span id="spname" style="font-size: 11px;">Click Date to View Detail </span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="100%">
                                                            <div id="dvEmailLogGrid" runat="server" style="overflow-x: hidden; overflow-y: scroll;
                                                                width: 785px; height: 200px">
                                                                <asp:GridView ID="gvEmailLog" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                    EmptyDataText="No Records Found" OnRowCommand="gvEmailLog_RowCommand" OnRowEditing="gvEmailLog_RowEditing">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Date">
                                                                            <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkDate" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Date"))%>'
                                                                                    CommandName="Edit" CommandArgument='<%# Eval("PK_CRM_Email_Log") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Subject">
                                                                            <ItemStyle Width="35%" HorizontalAlign="Left" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblSubject" runat="server" Text='<%# Eval("Subject")%>' Width="300px" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Recipients">
                                                                            <ItemStyle Width="25%" HorizontalAlign="Left" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblRecipients" runat="server" Text='<%# Eval("Recipients")%>' Width="100px" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="CCs">
                                                                            <ItemStyle Width="25%" HorizontalAlign="Left" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblCCs" runat="server" Text='<%# Eval("CCs")%>' Width="100px" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Date Email Sent&nbsp;<span id="Span42" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="78%" valign="top">
                                                            <asp:TextBox ID="txtEmailDateSent" runat="server" Width="150px" SkinID="txtDate"
                                                                ReadOnly="true" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Subject&nbsp;<span id="Span43" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtSubject" runat="server" Width="565px" ReadOnly="true" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Recipient(s)&nbsp;<span id="Span44" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtRecipient" runat="server" ReadOnly="true" ShowSpellChecker="false" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            CC(s)&nbsp;<span id="Span45" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtCCs" runat="server" ReadOnly="true" ShowSpellChecker="false" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <div id="dvAttachment" runat="server" style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Add Attachment
                                                </div>
                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="100%">
                                                            <uc:ctrlAttachment ID="Attachment" runat="Server" ShowAttachmentButton="true" OnbtnHandler="Attachment_btnHandler" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Spacer" style="height: 20px;">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                        <div id="dvView" runat="server" width="794px">
                                            <asp:Panel ID="pnl1View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Customer Information</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Complaint Number
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblComplaintNumber" runat="server" />
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            Date of Incident
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblRecord_Date" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Source
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_LU_CRM_Source" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Last Name
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLast_Name" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            First Name
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFirst_Name" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Last Name Co-Buyer or Caller
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLast_Name_Co_Buyer" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            First Name Co-Buyer or Caller
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFirst_Name_Co_Buyer" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Address
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblAddress" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            City
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCity" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            State
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_State" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Zip (XXXXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblZip_Code" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Email
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblEmail" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Home Telephone (XXX-XXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblHome_Telephone" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Cell Telephone (XXX-XXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCell_Telephone" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Work Telephone (XXX-XXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblWork_Telephone" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Work Telephone Extension
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblWork_Telephone_Extension" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Summary
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblSummary" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Resolution Summary
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblResolution_Summary" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl2View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Department Information</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Department
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblFK_LU_CRM_Department" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            Department Detail
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblFK_LU_CRM_Dept_Desc_Detail" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Date of Service
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblService_Date" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Date of Service Estimated?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblService_Date_Est" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Dealer
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lblFK_LU_Location" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Brand
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_LU_CRM_Brand" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Model
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblModel" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Year
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lblYear" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr height="100">
                                                        <td align="left" valign="top" colspan="6">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl3View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Contacts and Dates</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            CRM Contacted
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblFK_LU_CRM_Contacted_Resolution_2" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Resolution Manager
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblFK_LU_CRM_Contacted_Resolution_1" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Resolution Manager Name
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblResolution_Manager" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Resolution Manager Email
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblResolution_Manager_Email" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Customer Contacted GM?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCustomer_Contacted_GM" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Date of Contact GM
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblGM_Contact_Date" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            GM Name
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblGM_Name" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Date of Contact RVP
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblRVP_Contact_Date" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            RVP Name
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_LU_CRM_RVP" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Date of Contact DFOD
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblDFOD_Contact_Date" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            DFOD
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_LU_CRM_DFOD" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Other Contact Name
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblOther_Cotnact_Name" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Legal/Attorney General?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLegal_Attorney_General" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Legal Email
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_LU_CRM_Legal_Email" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Demand Letter?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblDemand_Letter" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Date of Last Update
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lblUpdate_Date" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Last Action
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <uc:ctrlMultiLineTextBox  ID="lblLast_Action" runat="server" ControlType="Label"/>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl4View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Incident Grid</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%" height="170">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Incident Grid
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <div id="divgvComplaintView" runat="server" style="overflow-x: hidden; overflow-y: scroll;
                                                                width: 600px; height: 200px">
                                                                <asp:GridView ID="gvComplaintView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                    EmptyDataText="No Records Found" OnRowCommand="gvComplaint_RowCommand">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Date">
                                                                            <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                            <ItemTemplate>
                                                                                <a href='CRM_Customer_Complaint_Notes.aspx?id=<%#Encryption.Encrypt(Eval("PK_CRM_Notes").ToString())%>&mode=<%# (StrOperation == "" ? "edit" : StrOperation) %>&pid=<%#Encryption.Encrypt(Eval("FK_Table_Name").ToString())%>&bmode=<%# (StrOperation == "" ? "edit" : StrOperation) %>'>
                                                                                    <%#(Eval("Note_Date")) == DBNull.Value ? "" : Eval("Note_Date", "{0:MM-dd-yyyy}")%>
                                                                                </a>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Note Abstract">
                                                                            <ItemStyle Width="80%" HorizontalAlign="Left" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblNote" runat="server" Text='<%# Eval("Note")%>' Width="430px" CssClass="TextClip" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl5View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Field Notes</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%" height="170">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Field Notes Grid
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <div id="divgvFieldNotesView" runat="server" style="overflow-x: hidden; overflow-y: scroll;
                                                                width: 600px; height: 200px">
                                                                <asp:GridView ID="gvFieldNotesView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                    EmptyDataText="No Records Found" OnRowCommand="gvFieldNotes_RowCommand">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Date">
                                                                            <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                            <ItemTemplate>
                                                                                <a href='CRM_Customer_Notes.aspx?id=<%#Encryption.Encrypt(Eval("PK_CRM_Notes").ToString())%>&mode=<%# (StrOperation == "" ? "edit" : StrOperation) %>&pid=<%#Encryption.Encrypt(Eval("FK_Table_Name").ToString())%>&bmode=<%# (StrOperation == "" ? "edit" : StrOperation) %>'>
                                                                                    <%#(Eval("Note_Date")) == DBNull.Value ? "" : Eval("Note_Date", "{0:MM-dd-yyyy}")%>
                                                                                </a>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Note Abstract">
                                                                            <ItemStyle Width="80%" HorizontalAlign="Left" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblNote" runat="server" Text='<%# Eval("Note")%>' Width="430px" CssClass="TextClip" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <br />
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr valign="top" align="left">
                                                        <td style="width: 30%">
                                                            Field Resolution Information
                                                        </td>
                                                        <td align="center" valign="top" style="width: 4%">
                                                            :
                                                        </td>
                                                        <td style="width: 66%">
                                                            <div id="divgvResolutionView" runat="server" style="overflow-x: hidden; overflow-y: scroll;
                                                                width: 610px; height: 200px">
                                                                <asp:GridView ID="gvResolutionView" runat="server" AutoGenerateColumns="false" Width="100%">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Date" ItemStyle-Width="12%" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <a href='CRM_Customer_Resolution_Notes.aspx?id=<%#Encryption.Encrypt(Eval("PK_CRM_Notes").ToString())%>&mode=<%# (StrOperation == "" ? "edit" : StrOperation) %>&pid=<%#Encryption.Encrypt(Eval("FK_Table_Name").ToString())%>&bmode=<%# (StrOperation == "" ? "edit" : StrOperation) %>'>
                                                                                    <%#(Eval("Note_Date")) == DBNull.Value ? "" : Eval("Note_Date", "{0:MM-dd-yyyy}")%>
                                                                                </a>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Note Abstract" ItemStyle-Width="88%" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <%#Eval("Note")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                                    <EmptyDataTemplate>
                                                                        No Record found.
                                                                    </EmptyDataTemplate>
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl6View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Resolution</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Complete?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblComplete" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            Close Date
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblClose_Date" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Days to Close
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblDays_To_Close" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Customer Call Back After Resolved?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCustomer_Callback_After_Resolution" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Resolution Letter to Customer?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblResolution_Letter_To_Customer" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Date Resolution Letter Sent
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblDate_Resolution_Letter_Sent" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Sent By
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_LU_CRM_Response_Method" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Letter N/A?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLetter_NA" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Letter N/A Reason
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_LU_CRM_Letter_NA_Reason" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Letter N/A Note
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblLetter_NA_Note" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl7View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Email Log</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" valign="top" width="100%">
                                                            <span id="Span" style="font-size: 11px;">Click Date to View Detail </span>
                                                        </td>
                                                    </tr>
                                                    <tr valign="top">
                                                        <td align="left" valign="top" width="100%" height="170">
                                                            <div id="dvEmailLogGridView" runat="server" style="overflow-x: hidden; overflow-y: scroll;
                                                                width: 785px; height: 200px">
                                                                <asp:GridView ID="gvEmailLogView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                    EmptyDataText="No Records Found" OnRowCommand="gvEmailLogView_RowCommand" OnRowEditing="gvEmailLogView_RowEditing">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Date">
                                                                            <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkDate" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Date"))%>'
                                                                                    CommandName="View" CommandArgument='<%# Eval("PK_CRM_Email_Log") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Subject">
                                                                            <ItemStyle Width="35%" HorizontalAlign="Left" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblSubject" runat="server" Text='<%# Eval("Subject")%>' Width="300px" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Recipients">
                                                                            <ItemStyle Width="25%" HorizontalAlign="Left" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblRecipients" runat="server" Text='<%# Eval("Recipients")%>' Width="100px" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="CCs">
                                                                            <ItemStyle Width="25%" HorizontalAlign="Left" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblCCs" runat="server" Text='<%# Eval("CCs")%>' Width="100px" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Date Email Sent
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="78%" valign="top">
                                                            <asp:Label ID="lblEmailDateSent" runat="server" Width="150px" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Subject
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSubject" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Recipient(s)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblRecipient" runat="server" ControlType="Label" ShowSpellChecker="false" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            CC(s)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblCCs" runat="server" ControlType="Label" ShowSpellChecker="false" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </div>
                                        <asp:Panel ID="pnlAttachmentDetails" runat="server" Style="display: none;">
                                            <div class="bandHeaderRow">
                                                Attachment Details
                                            </div>
                                            <table cellpadding="0" cellspacing="0" width="100%" height="185">
                                                <tr>
                                                    <td width="100%" valign="top">
                                                        <uc:ctrlAttachmentDetails ID="AttachDetails" runat="Server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="Spacer" style="height: 15px;">
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr style="display: none">
                                    <td>
                                        <asp:Label ID="lblNotesHTML" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <div id="dvSave" runat="server">
                                <table cellpadding="5" cellspacing="1" width="100%">
                                    <tr>
                                        <td width="100%" align="center">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnPreviousStep" runat="server" Text="Previous Step" CausesValidation="false"
                                                            OnClientClick="return  onPreviousStep();" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnSave" runat="server" Text=" Save & View " CausesValidation="true"
                                                            OnClick="btnSave_Click" ValidationGroup="vsErrorGroup" OnClientClick="return ValSave();" />
                                                        <asp:Button ID="btnEdit" runat="server" Visible="false" Text="  Edit  " OnClick="btnEdit_Click" />
                                                        <asp:Button ID="btnEmail" runat="server" Visible="false" Text="  Email  " OnClientClick="return ShowCustomerMailPage();" />
                                                        <asp:Button ID="btnNextStep" runat="server" Text="Next Step" CausesValidation="true"
                                                            ValidationGroup="vsErrorGroup" OnClientClick="return onNextStep();" />
                                                        <asp:Button runat="server" ID="btnAuditTrail" Text="View Audit Trail" CausesValidation="false"
                                                            Visible="true" OnClientClick="javascript:return OpenAuditPopUp();" />
                                                    </td>
                                                </tr>
                                            </table>
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
    <asp:HiddenField ID="hdnPanel" runat="server" Value="1" />
    <asp:CustomValidator ID="CustomValidator" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
        Display="None" ValidationGroup="vsErrorGroup" />
    <input id="hdnControlIDs" runat="server" type="hidden" />
    <input id="hdnErrorMsgs" runat="server" type="hidden" />
</asp:Content>
