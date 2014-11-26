<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="EPM_Project_Milestone.aspx.cs" Inherits="SONIC_Exposures_EPM_Project_Milestone" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/NotesWithSpellCheck/Notes.ascx" TagName="ctrlMultiLineTextBox"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposuresTab/ExposuresTab.ascx" TagName="CtlTab" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="../../JavaScript/JFunctions.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript">
        function OpenManageRecipientspopup() {
            var w = 480, h = 340;
            if (document.all || document.layers) {
                w = screen.availWidth;
                h = screen.availHeight;
            }

            var leftPos, topPos;
            var popW = 600, popH = 300;
            if (document.all)
            { leftPos = (w - popW) / 2; topPos = (h - popH) / 2; }
            else
            { leftPos = w / 2; topPos = h / 2; }
            window.open('EPM_Milestone_Manage_Mail_Recipients.aspx', "popup", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=" + popW + ",height=" + popH + ",top=" + topPos + ",left=" + leftPos);
            return false;
        }
    </script>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <div>
            <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
                HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
                ValidationGroup="vsErrorProjectMilestone" CssClass="errormessage"></asp:ValidationSummary>
            <asp:HiddenField ID="hdnProjectDescription" runat="server" />
        </div>
        <tr>
            <td width="100%" style="height: 50px;" valign="bottom" colspan="2">
                <uc:CtlTab runat="server" ID="Tab"></uc:CtlTab>
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 10px;" colspan="2">
            </td>
        </tr>
        <tr>
            <td align="left" valign="top" colspan="2">
                <table style="background-color: black" cellspacing="1" cellpadding="3" width="100%"
                    border="0">
                    <tbody>
                        <tr class="PropertyInfoBG">
                            <td id="tdProjectNum" runat="server" style="width: 14%; display: none;" align="left">
                                <asp:Label ID="lblProjectNumber" runat="server" Text="Project Number"></asp:Label>
                            </td>
                            <td id="tdProjectType" runat="server" style="width: 12%; display: none;" align="left">
                                <asp:Label ID="Label1" runat="server" Text="Project Type"></asp:Label>
                            </td>
                            <td style="width: 13%" align="left">
                                <asp:Label ID="lblHeaderLocationNumber" runat="server" Text="Location Number"></asp:Label>
                            </td>
                            <td style="width: 18%" align="left">
                                <asp:Label ID="lblHeaderLocationdba" runat="server" Text="SONIC Location d/b/a"></asp:Label>
                            </td>
                            <td id="Td1" style="width: 18%" align="left" runat="server">
                                <asp:Label ID="lblHeaderAddress" runat="server" Text="Address"></asp:Label>
                            </td>
                            <td style="width: 10%" align="left">
                                <asp:Label ID="lblHeaderCity" runat="server" Text="City"></asp:Label>
                            </td>
                            <td style="width: 10%" align="left">
                                <asp:Label ID="lblHeaderState" runat="server" Text="State"></asp:Label>
                            </td>
                            <td style="width: 5%" align="left">
                                <asp:Label ID="lblHeaderZip" runat="server" Text="Zip"></asp:Label>
                            </td>
                        </tr>
                        <tr style="background-color: white">
                            <td id="tdHeaderPro_Num" runat="server" align="left" style="display: none;">
                                <asp:Label ID="lblHeaderProject_Number" runat="server">&nbsp;</asp:Label>
                            </td>
                            <td id="tdHeaderProType" runat="server" align="left" style="display: none;">
                                <asp:Label ID="lblHeaderProject_Type" runat="server">&nbsp;</asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblLocation_Number" runat="server">&nbsp;</asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblLocationdba" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblAddress" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblCity" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblState" runat="server" />
                            </td>
                            <td align="left">
                                <asp:Label ID="lblZip" runat="server" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 5px;" colspan="2">
            </td>
        </tr>
        <tr>
            <td class="leftMenu" width="18%">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="height: 10px;" class="Spacer">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="5" cellspacing="0" width="100%">
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="EPMProject_Milestone" class="LeftMenuSelected">Project Milestone</span>&nbsp;<span
                                            id="MenuAsterisk1" runat="server" style="color: Red; display: none">*</span></span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px;" class="Spacer">
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top" width="82%">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td width="5px">
                            &nbsp;
                        </td>
                        <td class="dvContainer" align="center">
                            <div id="dvEdit" runat="server">
                                <div class="bandHeaderRow">
                                    Project Management - Project Milestone</div>
                                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                    <tr>
                                        <td>
                                            <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                <tr>
                                                    <td align="left" valign="top" width="20%">
                                                        Milestone&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                    </td>
                                                    <td align="center" valign="top" width="4%">
                                                        :
                                                    </td>
                                                    <td align="left" valign="top" colspan="4">
                                                        <asp:DropDownList ID="drpMilestone" runat="server" SkinID="ddlExposure" OnSelectedIndexChanged="drpMilestone_SelectedIndexChanged"
                                                            AutoPostBack="true">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="20%">
                                                        Milestone Other Description&nbsp;<span id="Span2" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                    </td>
                                                    <td align="center" valign="top" width="4%">
                                                        :
                                                    </td>
                                                    <td align="left" valign="top" colspan="4">
                                                        <asp:TextBox ID="txtMilestone_Description" runat="server" Width="300px" MaxLength="255" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="20%">
                                                        Milestone Date&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                    </td>
                                                    <td align="center" valign="top" width="4%">
                                                        :
                                                    </td>
                                                    <td align="left" valign="top" colspan="4">
                                                        <asp:TextBox ID="txtDateToday" runat="server" Style="display: none;" />
                                                        <asp:TextBox ID="txtMilestone_Date" runat="server" MaxLength="10" SkinID="txtdate"
                                                            Width="150px"></asp:TextBox>
                                                        <img alt="Milestone Date" onclick="return showCalendar('<%=txtMilestone_Date.ClientID %>', 'mm/dd/y');"
                                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                            align="middle" />
                                                        <cc1:MaskedEditExtender ID="MaskedEditExtender6" runat="server" AcceptNegative="Left"
                                                            DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                            OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtMilestone_Date"
                                                            CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                        </cc1:MaskedEditExtender>
                                                        <br />
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ValidationGroup="vsErrorProjectMilestone"
                                                            Display="none" ErrorMessage="[Project Milestone]/Milestone Date is not a valid date"
                                                            SetFocusOnError="true" ControlToValidate="txtMilestone_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        <asp:CompareValidator ID="CompareValidator34" runat="server" ControlToCompare="txtDateToday"
                                                            ControlToValidate="txtMilestone_Date" Type="Date" Display="None" ErrorMessage="[Project Milestone]/Milestone Date Should be Future Date"
                                                            Operator="GreaterThanEqual" ValidationGroup="vsErrorProjectMilestone"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="20%">
                                                        E-Mail Reminder&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                                    </td>
                                                    <td align="center" valign="top" width="4%">
                                                        :
                                                    </td>
                                                    <td align="left" valign="top" width="26%">
                                                        <asp:RadioButtonList ID="rdoMailReminder" runat="server" SkinID="YesNoType">
                                                        </asp:RadioButtonList>
                                                    </td>
                                                    <td align="left" valign="top" width="20%">
                                                        Use E-Mail List from Milestone&nbsp;<span id="Span5" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                    </td>
                                                    <td align="center" valign="top" width="4%">
                                                        :
                                                    </td>
                                                    <td align="left" valign="top" width="26%">
                                                        <asp:DropDownList ID="drpMail_List_from_Milestone" runat="server" SkinID="ddlExposure"
                                                            AutoPostBack="true" OnSelectedIndexChanged="drpMail_List_from_Milestone_OnSelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="20%">
                                                        E-Mail Recipients&nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                                                    </td>
                                                    <td align="center" valign="top" width="4%">
                                                        :
                                                    </td>
                                                    <td align="left" valign="top" colspan="4">
                                                        <asp:ListBox ID="lstMail_Milestone" runat="server" SelectionMode="Multiple" Width="250px"
                                                            OnSelectedIndexChanged="lstMail_Milestone_OnSelectedIndexChanged" AutoPostBack="true">
                                                        </asp:ListBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" width="20%">
                                                        Additional Recipients&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                                    </td>
                                                    <td align="center" valign="top" width="4%">
                                                        :
                                                    </td>
                                                    <td align="left" valign="top" colspan="4">
                                                        <uc:ctrlMultiLineTextBox ID="txtAdditional_Recipients" runat="server" ControlType="TextBox" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" colspan="6">
                                                        <asp:LinkButton ID="lnkManage_Mail_Recipients" Text="Manage E-Mail Recipients" runat="server"
                                                            OnClientClick="OpenManageRecipientspopup();" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="divView" runat="server" style="display: none;">
                                <div class="bandHeaderRow">
                                    Project Management - Project Milestone</div>
                                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                    <tr>
                                        <td align="left" valign="top" width="20%">
                                            Milestone
                                        </td>
                                        <td align="center" valign="top" width="4%">
                                            :
                                        </td>
                                        <td align="left" valign="top" colspan="4">
                                            <asp:Label ID="lblMilestone" runat="server">
                                            </asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" width="20%">
                                            Milestone Other Description
                                        </td>
                                        <td align="center" valign="top" width="4%">
                                            :
                                        </td>
                                        <td align="left" valign="top" colspan="4">
                                            <asp:Label ID="lblMilestone_Description" runat="server" CssClass="TextClip" Width="250px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" width="20%">
                                            Milestone Date
                                        </td>
                                        <td align="center" valign="top" width="4%">
                                            :
                                        </td>
                                        <td align="left" valign="top" colspan="4">
                                            <asp:Label ID="lblMilestone_Date" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" width="20%">
                                            E-Mail Reminder
                                        </td>
                                        <td align="center" valign="top" width="4%">
                                            :
                                        </td>
                                        <td align="left" valign="top" width="26%">
                                            <asp:Label ID="lblMailReminder" runat="server">
                                            </asp:Label>
                                        </td>
                                        <td align="left" valign="top" width="20%">
                                            Use E-Mail List from Milestone
                                        </td>
                                        <td align="center" valign="top" width="4%">
                                            :
                                        </td>
                                        <td align="left" valign="top" width="26%">
                                            <asp:Label ID="lblMail_List_from_Milestone" runat="server">
                                            </asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" width="20%">
                                            E-Mail Recipients
                                        </td>
                                        <td align="center" valign="top" width="4%">
                                            :
                                        </td>
                                        <td align="left" valign="top" colspan="4">
                                            <asp:ListBox ID="lstMail_MilestoneView" runat="server" SelectionMode="Multiple" Width="250px">
                                            </asp:ListBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" width="20%">
                                            Additional Recipients
                                        </td>
                                        <td align="center" valign="top" width="4%">
                                            :
                                        </td>
                                        <td align="left" valign="top" colspan="4">
                                            <uc:ctrlMultiLineTextBox ID="lblAdditional_Recipients" runat="server" ControlType="Label" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top" colspan="2">
                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                    <tr>
                        <td>
                            <asp:Button ID="btnSaveMilestone" Text="Save" runat="server" OnClick="btnSaveMilestone_OnClick"
                                CausesValidation="true" ValidationGroup="vsErrorProjectMilestone" />&nbsp;
                            <asp:Button ID="btnCancelMilestone" Text="Cancel" runat="server" OnClick="btnCancelMilestone_OnClick" />&nbsp;
                            <asp:Button ID="btnViewAuditMilestone" Text="View Audit Trail" runat="server" OnClientClick="return AuditProjectMilestone();"
                                CausesValidation="false" Visible="false" />
                            <asp:Button ID="btnhdnBindMailList" runat="server" OnClick="btnhdnBindMailList_OnClick"
                                CausesValidation="false" Style="display: none" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:CustomValidator ID="CustomValidatorProjectMilestone" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFields" Display="None" ValidationGroup="vsErrorProjectMilestone" />
    <input id="hdnControlIDsProjectMilestone" runat="server" type="hidden" />
    <input id="hdnErrorMsgsProjectMilestone" runat="server" type="hidden" />
    <script type="text/javascript">

        function ValidateFields(sender, args) {
            var msg = "", ctrlIDs = "", Messages = "", hdnID = "";

            ctrlIDs = document.getElementById('<%=hdnControlIDsProjectMilestone.ClientID%>').value.split(',');
            hdnID = '<%=hdnControlIDsProjectMilestone.ClientID%>';
            Messages = document.getElementById('<%=hdnErrorMsgsProjectMilestone.ClientID%>').value.split(',');

            var focusCtrlID = "";

            if (hdnID != "") {
                if (document.getElementById(hdnID).value != "") {
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
                else
                    args.IsValid = true;
            }
        }

        function AuditProjectMilestone() {
            var winHeight = window.screen.availHeight - 400;
            var winWidth = window.screen.availWidth - 300;

            obj = window.open("AuditPopup_EPM-ProjectMilestone.aspx?id=" + '<%=ViewState["PK_EPM_Milestone"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }
    </script>
</asp:Content>
