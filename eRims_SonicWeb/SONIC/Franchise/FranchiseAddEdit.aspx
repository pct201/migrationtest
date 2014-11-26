<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="FranchiseAddEdit.aspx.cs" Inherits="SONIC_Franchise_FranchiseAddEdit" %>

<%@ Register Src="~/Controls/NotesWithSpellCheck/Notes.ascx" TagName="ctrlMultiLineTextBox"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment_Franchise/Attachment.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment_Franchise/AttachmentDetails.ascx" TagName="ctrlAttachmentDetails"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposuresTab/ExposuresTab.ascx" TagName="CtlTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposureInfo/ExposureInfo.ascx" TagName="ctrlExposureInfo"
    TagPrefix="uc" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="Content1" runat="server">
    <script type="text/javascript" src="../../JavaScript/JFunctions.js"></script>
    <script type="text/javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript">
        function SetMenuStyle(index) {
            var i;
            for (i = 1; i <= 2; i++) {
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
                if (index < 2) {
                    for (i = 1; i <= 1; i++) {
                        document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display = (i == index) ? "block" : "none";
                        if (i == 1)
                            document.getElementById('<%=drpFK_Building_Id.ClientID%>').focus();
                    }
                    document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "none";
                }
                else {
                    for (i = 1; i <= 1; i++) {
                        document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display = "none";
                    }
                    document.getElementById("<%=dvAttachment.ClientID%>").style.display = "block";
                    document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "block";
                    document.getElementById('ctl00_ContentPlaceHolder1_Attachment_txtType').focus();
                }
            }
        }

        function ShowPanelView(index) {
            SetMenuStyle(index);
            document.getElementById('<%=dvView.ClientID%>').style.display = "block";
            var i;
            if (index < 2) {
                for (i = 1; i <= 1; i++) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i + "View").style.display = (i == index) ? "block" : "none";
                }
                document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "none";
            }
            else {
                for (i = 1; i <= 1; i++) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i + "View").style.display = "none";
                }
                document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "block";
            }
        }


        function ValSave() {
            return Page_ClientValidate('vsErrorGroup');
        }

        function OpenAuditPopUp() {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;

            obj = window.open('AuditPopup_Franchise.aspx?id=<%=ViewState["PK_Franchise"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
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
    </script>
    <asp:ValidationSummary ID="valSummary" runat="server" ValidationGroup="vsErrorGroup"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following fields"
        BorderWidth="1" BorderColor="DimGray" CssClass="errormessage" />
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100%" style="height: 50px;" valign="bottom" colspan="2">
                <uc:CtlTab runat="server" ID="Tab"></uc:CtlTab>
            </td>
        </tr>
        <tr>
            <td class="Spacer" width="100%" style="height: 15px;" colspan="2">
            </td>
        </tr>
        <tr>
            <td width="100%" colspan="2">
                <uc:ctrlExposureInfo ID="ucCtrlExposureInfo" runat="server" />
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
                                    <td align="left" width="100%">
                                        <span id="Menu1" onclick="javascript:ShowPanel(1);" class="LeftMenuStatic">Franchise
                                            Information</span>&nbsp;<span id="MenuAsterisk1" runat="server" style="color: Red;display:none">*</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu2" onclick="javascript:ShowPanel(2);" class="LeftMenuStatic">Attachments</span>
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
                                    <td class="dvContainer">
                                        <div id="dvEdit" runat="server" width="794px">
                                            <asp:Panel ID="pnl1" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Franchise Information</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td colspan="6" align="left" class="BlueItalicText">
                                                            The data for the blue italicized field on this screen are derived from the Lease module for the same location and building.
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Location d/b/a
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLocationDBA" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Legal Entity Name
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLegalEntityName" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Location f/k/a
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLocationFKA" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Sonic Location Code
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSonicLocCode" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Building&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" width="28%" valign="top">
                                                            <asp:DropDownList ID="drpFK_Building_Id" Width="93%" runat="server" SkinID="dropGen" AutoPostBack="true" OnSelectedIndexChanged="drpFK_Building_Id_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Brand&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="drpFK_LU_Franchise_Brand" Width="175px" runat="server" SkinID="dropGen">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Franchise Renewal Date&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtFranchise_Renewal_Date" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Franchise Renewal Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtFranchise_Renewal_Date', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revFranchise_Renewal_Date" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[Franchise Information]/Franchise Renewal Date is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtFranchise_Renewal_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <%--  <tr>
                                                        <td align="left" valign="top">
                                                            Additional Land
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="drpFK_LU_Franchise_Additional_Land" Width="175px" runat="server"
                                                                SkinID="dropGen">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Plans Submitted for Approval&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtPlanSubmitted" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Construction Start" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPlanSubmitted', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[Franchise Information]/Plans Submitted for Approval is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtPlanSubmitted" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Permit Secured&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtPermitSecured" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Construction Start" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPermitSecured', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[Franchise Information]/Permit Secured is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtPermitSecured" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Construction Start&nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtConstruction_Start" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Construction Start" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtConstruction_Start', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revConstruction_Start" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[Franchise Information]/Construction Start is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtConstruction_Start" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Signage Ordered&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:TextBox ID="txtSignageOrdered" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Construction Start" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtSignageOrdered', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[Franchise Information]/Signage Ordered is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtSignageOrdered" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Anticipated Completion&nbsp;<span id="Span8" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtAnticipated_Completion" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Anticipated Completion" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtAnticipated_Completion', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revAnticipated_Completion" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[Franchise Information]/Anticipated Completion is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtAnticipated_Completion" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Construction Finish&nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtConstruction_Finish" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Construction Finish" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtConstruction_Finish', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revConstruction_Finish" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[Franchise Information]/Construction Finish is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtConstruction_Finish" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            <asp:CompareValidator ID="cvConsructionDates" runat="server" ControlToCompare="txtConstruction_Start"
                                                                ControlToValidate="txtConstruction_Finish" Type="Date" Display="None" SetFocusOnError="true"
                                                                Operator="GreaterThanEqual" ValidationGroup="vsErrorGroup" ErrorMessage="[Franchise Information]/Construction Finish Date must be greater than or equal to the Construction Start Date" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Proposed Improvement Costs&nbsp;<span id="Span10" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            $&nbsp;<asp:TextBox ID="txtProposedImprovementCosts" runat="server" MaxLength="20"
                                                                SkinID="txtAmt" onkeypress="return FormatNumber(event,this.id,13,false);" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" nowrap="nowrap">
                                                            Additional Land Comments&nbsp;<span id="Span11" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtAdditional_Land_Comments" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" class="BlueItalicText">
                                                            Renewal Options<%--&nbsp;<span id="Span12" style="color: Red; display: none;" runat="server">*</span>--%>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtRenewal_Options" runat="server" ReadOnly="true" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Scope of Improvements&nbsp;<span id="Span13" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtScope_of_Improvements" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Additional Notes&nbsp;<span id="Span14" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtAdditional_Notes" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <%-- <tr>
                                                        <td align="left" valign="top">
                                                            Improvement Time Line<br />
                                                            <asp:LinkButton ID="lnkAddTimeLine" runat="server" Text="--Add--" OnClick="lnkAddTimeLine_Click"
                                                                CausesValidation="true" ValidationGroup="vsErrorGroup" />
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <asp:GridView ID="gvTimeLine" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                OnRowCommand="gvTimeLine_RowCommand" EmptyDataText="No Time Line Exists!">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Improvement" ItemStyle-Width="17%" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkImprovement" runat="server" CommandName="ShowDetails" CommandArgument='<%#Eval("PK_Franchise_Improvements") %>'
                                                                                Text='<%#Eval("Improvement")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Scheduled Start" ItemStyle-Width="17%" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkScheduledStart" runat="server" CommandName="ShowDetails" CommandArgument='<%#Eval("PK_Franchise_Improvements") %>'
                                                                                Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Scheduled_Start"))%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Actual Start" ItemStyle-Width="17%" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkActualStart" runat="server" CommandName="ShowDetails" CommandArgument='<%#Eval("PK_Franchise_Improvements") %>'
                                                                                Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Actual_Start"))%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Actual Completion" ItemStyle-Width="22%" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkActualCompletion" runat="server" CommandName="ShowDetails"
                                                                                CommandArgument='<%#Eval("PK_Franchise_Improvements") %>' Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Actual_Completion"))%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Update" ItemStyle-Width="17%" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="ShowDetails" CommandArgument='<%#Eval("PK_Franchise_Improvements") %>'
                                                                                Text='<%#Eval("Updates")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" CommandName="RemoveDetails" CommandArgument='<%#Eval("PK_Franchise_Improvements") %>'
                                                                                Text='Remove' OnClientClick="return confirm('Are you sure to remove?');" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>--%>
                                                </table>
                                                <%--  <asp:CustomValidator ID="cmvCheckAllOptions" runat="server" ClientValidationFunction="CheckAllOptions"
                                                    ValidationGroup="vsErrorGroup" Display="None" SetFocusOnError="false" ErrorMessage="[Franchise Information]/Additional Tracking Field 1 through 5 must be unique">
                                                </asp:CustomValidator>--%>
                                            </asp:Panel>
                                            <div id="dvAttachment" runat="server" style="display: none;">
                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="100%">
                                                            <uc:ctrlAttachment ID="Attachment" runat="Server" OnFileSelection="AddAttachment" />
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
                                                    Franchise Information</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td colspan="6" align="left" class="BlueItalicText">
                                                            The data for the blue italicized field on this screen are derived from the Lease module for the same location and building.
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="18%">
                                                            Location d/b/a
                                                        </td>
                                                        <td align="center" valign="top" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" width="28%">
                                                            <asp:Label ID="lblLocationDBAView" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top" width="18%">
                                                            Legal Entity Name
                                                        </td>
                                                        <td align="center" valign="top" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" width="28%">
                                                            <asp:Label ID="lblLegalEntityNameView" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Location f/k/a
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLocationFKAView" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Sonic Location Code
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSonicLocCodeView" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Building
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:Label ID="lblFK_Building_Id" runat="server"></asp:Label>
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
                                                            <asp:Label ID="lblFK_LU_Franchise_Brand" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Franchise Renewal Date
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFranchise_Renewal_Date" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Plans Submitted for Approval
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_LU_Franchise_Plans_Submitted" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Permit Secured
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_LU_Franchise_Permit_Secured" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Construction Start
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblConstruction_Start" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Signage Ordered
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lblSignageOrdered" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Anticipated Completion
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblAnticipated_Completion" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Construction Finish
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblConstruction_Finish" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Proposed Improvement Costs
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            $&nbsp;<asp:Label ID="lblProposedImprovementCosts" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Additional Land Comments
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblAdditional_Land_Comments" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" class="BlueItalicText">
                                                            Renewal Options
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblRenewal_Options" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Scope of Improvements
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblScope_of_Improvements" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Additional Notes
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblAdditional_Notes" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <%-- <tr>
                                                        <td align="left" valign="top">
                                                            Improvement Time Line
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <asp:GridView ID="gvTiemLineView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                OnRowCommand="gvTimeLine_RowCommand" EmptyDataText="No Time Line Exists!">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Improvement" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkImprovement" runat="server" CommandName="ShowDetails" CommandArgument='<%#Eval("PK_Franchise_Improvements") %>'
                                                                                Text='<%#Eval("Improvement")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Scheduled Start" ItemStyle-Width="18%" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkScheduledStart" runat="server" CommandName="ShowDetails" CommandArgument='<%#Eval("PK_Franchise_Improvements") %>'
                                                                                Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Scheduled_Start"))%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Actual Start" ItemStyle-Width="18%" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkActualStart" runat="server" CommandName="ShowDetails" CommandArgument='<%#Eval("PK_Franchise_Improvements") %>'
                                                                                Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Actual_Start"))%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Actual Completion" ItemStyle-Width="22%" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkActualCompletion" runat="server" CommandName="ShowDetails"
                                                                                CommandArgument='<%#Eval("PK_Franchise_Improvements") %>' Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Actual_Completion"))%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Update" ItemStyle-Width="22%" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="ShowDetails" CommandArgument='<%#Eval("PK_Franchise_Improvements") %>'
                                                                                Text='<%#Eval("Updates")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>--%>
                                                </table>
                                            </asp:Panel>
                                        </div>
                                        <asp:Panel ID="pnlAttachmentDetails" runat="server" Style="display: none;">
                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td width="100%">
                                                        <uc:ctrlAttachmentDetails ID="AttachDetails" runat="Server" IntAttachmentPanel="2" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="Spacer" style="height: 150px;">
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <table cellpadding="5" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td width="100%" align="center">
                                        <asp:Button ID="btnSave" runat="server" Text="Save & View" OnClick="btnSave_Click"
                                            CausesValidation="true" ValidationGroup="vsErrorGroup" OnClientClick="return ValSave();" />&nbsp;
                                        <asp:Button ID="btnEdit" runat="server" Text=" Edit " OnClick="btnEdit_Click" CausesValidation="false" />&nbsp;
                                        <asp:Button ID="btnReturn" runat="server" Text="Revert & Return" OnClick="btnReturn_Click" />&nbsp;
                                        <asp:Button ID="btnAuditTrail" runat="server" Text="View Audit Trail" CausesValidation="false"
                                            OnClientClick="javascript:return OpenAuditPopUp();" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
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
