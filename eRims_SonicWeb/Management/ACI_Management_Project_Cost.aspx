<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="ACI_Management_Project_Cost.aspx.cs" Inherits="SONIC_ACI_Management_Project_Cost" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/NotesWithSpellCheck/Notes.ascx" TagName="ctrlMultiLineTextBox"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposuresTab/ExposuresTab.ascx" TagName="CtlTab" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="../../JavaScript/JFunctions.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"></script>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <div>
            <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
                HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
                ValidationGroup="vsErrorProjectCost" CssClass="errormessage"></asp:ValidationSummary>
        </div>
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
                                        <span id="EPMProject_Cost" class="LeftMenuSelected">Project Cost</span>&nbsp;<span
                                            id="MenuAsterisk1" runat="server" style="color: Red; display: none">*</span>
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
                                    ACI Management - Project Cost</div>
                                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                    <tr>
                                        <td align="left" valign="top" width="20%">
                                            Project Phase&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                        </td>
                                        <td align="center" valign="top" width="4%">
                                            :
                                        </td>
                                        <td align="left" valign="top" colspan="4">
                                            <asp:DropDownList ID="drpProject_Phase" runat="server" SkinID="ddlExposure">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" width="20%">
                                            Comments/Description&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                        </td>
                                        <td align="center" valign="top" width="4%">
                                            :
                                        </td>
                                        <td align="left" valign="top" colspan="4">
                                            <uc:ctrlMultiLineTextBox ID="txtCommentsOrDesc" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" width="20%">
                                            Budget&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                        </td>
                                        <td align="center" valign="top" width="4%">
                                            :
                                        </td>
                                        <td align="left" valign="top" width="26%">
                                            $&nbsp;<asp:TextBox ID="txtBudget" runat="server" SkinID="txtAmt" Width="170px" onkeypress="return FormatNumber(event,this.id,13,false);" autocomplete="off"
                                                onpaste="return false" OnBlur="CheckNumericVal(this,13);" />
                                        </td>
                                        <td align="left" valign="top" width="20%">
                                            Date Budget Established&nbsp;<span id="Span4" style="color: Red; display: none;"
                                                runat="server">*</span>
                                        </td>
                                        <td align="center" valign="top" width="4%">
                                            :
                                        </td>
                                        <td align="left" valign="top" width="26%">
                                            <asp:TextBox ID="txtDateToday" runat="server" Style="display: none;" />
                                            <asp:TextBox ID="txtDate_Budget_Established" runat="server" MaxLength="10" SkinID="txtdate"
                                                Width="150px"></asp:TextBox>
                                            <img alt="Date Budget Established" onclick="return showCalendar('<%=txtDate_Budget_Established.ClientID %>', 'mm/dd/y');"
                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                align="middle" />
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender6" runat="server" AcceptNegative="Left"
                                                DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDate_Budget_Established"
                                                CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                            </cc1:MaskedEditExtender>
                                            <br />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ValidationGroup="vsErrorProjectCost"
                                                Display="none" ErrorMessage="[Project Cost]/Date Budget Established is not a valid date"
                                                SetFocusOnError="true" ControlToValidate="txtDate_Budget_Established" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                            <asp:CompareValidator ID="CompareValidator34" runat="server" ControlToCompare="txtDateToday"
                                                ControlToValidate="txtDate_Budget_Established" Type="Date" Display="None" ErrorMessage="[Project Cost]/Date Budget Established Should not be Future Date"
                                                Operator="LessThanEqual" ValidationGroup="vsErrorProjectCost"></asp:CompareValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            Estimated Cost&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                        </td>
                                        <td align="center" valign="top">
                                            :
                                        </td>
                                        <td align="left" valign="top">
                                            $&nbsp;<asp:TextBox ID="txtEstimated_Cost" runat="server" SkinID="txtAmt" Width="170px" autocomplete="off"
                                                onkeypress="return FormatNumber(event,this.id,13,false);" onpaste="return false" OnBlur="CheckNumericVal(this,13);" />
                                        </td>
                                        <td align="left" valign="top">
                                            Date Estimated Cost Derived&nbsp;<span id="Span6" style="color: Red; display: none;"
                                                runat="server">*</span>
                                        </td>
                                        <td align="center" valign="top">
                                            :
                                        </td>
                                        <td align="left" valign="top">
                                            <asp:TextBox ID="txtDate_Estimated_Cost_Derived" runat="server" MaxLength="10" SkinID="txtdate"
                                                Width="150px"></asp:TextBox>
                                            <img alt="Date Estimated Cost Derived" onclick="return showCalendar('<%=txtDate_Estimated_Cost_Derived.ClientID %>', 'mm/dd/y');"
                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                align="middle" />
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender7" runat="server" AcceptNegative="Left"
                                                DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDate_Estimated_Cost_Derived"
                                                CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                            </cc1:MaskedEditExtender>
                                            <br />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ValidationGroup="vsErrorProjectCost"
                                                Display="none" ErrorMessage="[Project Cost]/Date Estimated Cost Derived is not a valid date"
                                                SetFocusOnError="true" ControlToValidate="txtDate_Estimated_Cost_Derived" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtDateToday"
                                                ControlToValidate="txtDate_Estimated_Cost_Derived" Type="Date" Display="None"
                                                ErrorMessage="[Project Cost]/Date Estimated Cost Derived Should not be Future Date"
                                                Operator="LessThanEqual" ValidationGroup="vsErrorProjectCost"></asp:CompareValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            Original Estimated Cost&nbsp;<span id="Span7" style="color: Red; display: none;"
                                                runat="server">*</span>
                                        </td>
                                        <td align="center" valign="top">
                                            :
                                        </td>
                                        <td align="left" valign="top">
                                            $&nbsp;<asp:TextBox ID="txtOriginal_Estimated_Cost" runat="server" SkinID="txtAmt" autocomplete="off"
                                                Width="170px" onkeypress="return FormatNumber(event,this.id,13,false);" onpaste="return false" OnBlur="CheckNumericVal(this,13);" />
                                        </td>
                                        <td align="left" valign="top">
                                            Date Original Estimated Cost Derived&nbsp;<span id="Span8" style="color: Red; display: none;"
                                                runat="server">*</span>
                                        </td>
                                        <td align="center" valign="top">
                                            :
                                        </td>
                                        <td align="left" valign="top">
                                            <asp:TextBox ID="txtDate_Original_Estimated_Cost_Derived" runat="server" MaxLength="10"
                                                SkinID="txtdate" Width="150px"></asp:TextBox>
                                            <img alt="Date Original Estimated Cost Derived" onclick="return showCalendar('<%=txtDate_Original_Estimated_Cost_Derived.ClientID %>', 'mm/dd/y');"
                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                align="middle" />
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender8" runat="server" AcceptNegative="Left"
                                                DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDate_Original_Estimated_Cost_Derived"
                                                CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                            </cc1:MaskedEditExtender>
                                            <br />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ValidationGroup="vsErrorProjectCost"
                                                Display="none" ErrorMessage="[Project Cost]/Date Original Estimated Cost Derived is not a valid date"
                                                SetFocusOnError="true" ControlToValidate="txtDate_Original_Estimated_Cost_Derived"
                                                ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtDateToday"
                                                ControlToValidate="txtDate_Original_Estimated_Cost_Derived" Type="Date" Display="None"
                                                ErrorMessage="[Project Cost]/Date Original Estimated Cost Derived Should not be Future Date"
                                                Operator="LessThanEqual" ValidationGroup="vsErrorProjectCost"></asp:CompareValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            Actual Cost&nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                                        </td>
                                        <td align="center" valign="top">
                                            :
                                        </td>
                                        <td align="left" valign="top">
                                            $&nbsp;<asp:TextBox ID="txtActual_Cost" runat="server" SkinID="txtAmt" Width="170px" autocomplete="off"
                                                onkeypress="return FormatNumber(event,this.id,13,false);" onpaste="return false" OnBlur="CheckNumericVal(this,13);" />
                                        </td>
                                        <td align="left" valign="top">
                                            Date Actual Cost Incurred&nbsp;<span id="Span10" style="color: Red; display: none;"
                                                runat="server">*</span>
                                        </td>
                                        <td align="center" valign="top">
                                            :
                                        </td>
                                        <td align="left" valign="top">
                                            <asp:TextBox ID="txtDate_Actual_Cost_Incurred" runat="server" MaxLength="10" SkinID="txtdate"
                                                Width="150px"></asp:TextBox>
                                            <img alt="Date Actual Cost Incurred" onclick="return showCalendar('<%=txtDate_Actual_Cost_Incurred.ClientID %>', 'mm/dd/y');"
                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                align="middle" />
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender9" runat="server" AcceptNegative="Left"
                                                DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDate_Actual_Cost_Incurred"
                                                CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                            </cc1:MaskedEditExtender>
                                            <br />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ValidationGroup="vsErrorProjectCost"
                                                Display="none" ErrorMessage="[Project Cost]/Date Actual Cost Incurred is not a valid date"
                                                SetFocusOnError="true" ControlToValidate="txtDate_Actual_Cost_Incurred" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                            <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToCompare="txtDateToday"
                                                ControlToValidate="txtDate_Actual_Cost_Incurred" Type="Date" Display="None" ErrorMessage="[Project Cost]/Date Actual Cost Incurred Should not be Future Date"
                                                Operator="LessThanEqual" ValidationGroup="vsErrorProjectCost"></asp:CompareValidator>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="divView" runat="server" style="display: none;">
                                <div class="bandHeaderRow">
                                    ACI Management - Project Cost</div>
                                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                    <tr>
                                        <td align="left" valign="top" width="20%">
                                            Project Phase
                                        </td>
                                        <td align="center" valign="top" width="4%">
                                            :
                                        </td>
                                        <td align="left" valign="top" colspan="4">
                                            <asp:Label ID="lblProject_Phase" runat="server">
                                            </asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" width="20%">
                                            Comments/Description
                                        </td>
                                        <td align="center" valign="top" width="4%">
                                            :
                                        </td>
                                        <td align="left" valign="top" colspan="4">
                                            <uc:ctrlMultiLineTextBox ID="lblCommentsOrDesc" runat="server" ControlType="Label" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" width="20%">
                                            Budget
                                        </td>
                                        <td align="center" valign="top" width="4%">
                                            :
                                        </td>
                                        <td align="left" valign="top" width="26%">
                                            $&nbsp;<asp:Label ID="lblBudget" runat="server" />
                                        </td>
                                        <td align="left" valign="top" width="20%">
                                            Date Budget Established
                                        </td>
                                        <td align="center" valign="top" width="4%">
                                            :
                                        </td>
                                        <td align="left" valign="top" width="26%">
                                            <asp:Label ID="lblDate_Budget_Established" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            Estimated Cost
                                        </td>
                                        <td align="center" valign="top">
                                            :
                                        </td>
                                        <td align="left" valign="top">
                                            $&nbsp;<asp:Label ID="lblEstimated_Cost" runat="server" />
                                        </td>
                                        <td align="left" valign="top">
                                            Date Estimated Cost Derived
                                        </td>
                                        <td align="center" valign="top">
                                            :
                                        </td>
                                        <td align="left" valign="top">
                                            <asp:Label ID="lblDate_Estimated_Cost_Derived" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            Original Estimated Cost
                                        </td>
                                        <td align="center" valign="top">
                                            :
                                        </td>
                                        <td align="left" valign="top">
                                            $&nbsp;<asp:Label ID="lblOriginal_Estimated_Cost" runat="server" />
                                        </td>
                                        <td align="left" valign="top">
                                            Date Original Estimated Cost Derived
                                        </td>
                                        <td align="center" valign="top">
                                            :
                                        </td>
                                        <td align="left" valign="top">
                                            <asp:Label ID="lblDate_Original_Estimated_Cost_Derived" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            Actual Cost
                                        </td>
                                        <td align="center" valign="top">
                                            :
                                        </td>
                                        <td align="left" valign="top">
                                            $&nbsp;<asp:Label ID="lblActual_Cost" runat="server" />
                                        </td>
                                        <td align="left" valign="top">
                                            Date Actual Cost Incurred
                                        </td>
                                        <td align="center" valign="top">
                                            :
                                        </td>
                                        <td align="left" valign="top">
                                            <asp:Label ID="lblDate_Actual_Cost_Incurred" runat="server"></asp:Label>
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
                            <asp:Button ID="btnSaveProject_Cost" Text="Save" runat="server" OnClick="btnSaveProject_Cost_OnClick"
                                CausesValidation="true" ValidationGroup="vsErrorProjectCost" />&nbsp;
                            <asp:Button ID="btnCancel" Text="Cancel" runat="server" OnClick="btnCancel_OnClick" />&nbsp;
                            <asp:Button ID="btnProjectCost_Audit" Text="View Audit Trail" runat="server" OnClientClick="return AuditProjectCost()"
                                CausesValidation="false" Visible="false" />&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:CustomValidator ID="CustomValidatorProjectCost" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFields" Display="None" ValidationGroup="vsErrorProjectCost" />
    <input id="hdnControlIDsProjectCost" runat="server" type="hidden" />
    <input id="hdnErrorMsgsProjectCost" runat="server" type="hidden" />
    <script type="text/javascript">

        function ValidateFields(sender, args) {
            var msg = "", ctrlIDs = "", Messages = "", hdnID = "";

            ctrlIDs = document.getElementById('<%=hdnControlIDsProjectCost.ClientID%>').value.split(',');
            hdnID = '<%=hdnControlIDsProjectCost.ClientID%>';
            Messages = document.getElementById('<%=hdnErrorMsgsProjectCost.ClientID%>').value.split(',');

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

        function AuditProjectCost() {
            var winHeight = window.screen.availHeight - 400;
            var winWidth = window.screen.availWidth - 300;

            obj = window.open("AuditPopup-ACI-Management-ProjectCost.aspx?id=" + '<%=ViewState["PK_ACIManagement_ProjectCost"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }

        function CheckNumericVal(Ctl, length) {
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

        function formatCurrency_New(num) {
            num = num.toString().replace(/\$|\,/g, '');
            if (isNaN(num))
                num = "0";

            sign = (num == (num = Math.abs(num)));
            num = Math.floor(num * 100 + 0.50000000001);
            cents = num % 100;
            num = Math.floor(num / 100).toString();

            if (cents < 10)
                cents = "0" + cents;

            for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3) ; i++)
                num = num.substring(0, num.length - (4 * i + 3)) + ',' +

            num.substring(num.length - (4 * i + 3));

            return (((sign) ? '' : '-') + num + '.' + cents);
        }
    </script>
</asp:Content>
