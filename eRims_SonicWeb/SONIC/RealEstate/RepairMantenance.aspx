<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="RepairMantenance.aspx.cs"
    Inherits="SONIC_RealEstate_RepairMantenance" Title="Real Estate : Repair / Maintenance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposuresTab/ExposuresTab.ascx" TagName="CtlTab" TagPrefix="uc" %>
<%@ Register Src="../../Controls/RealEstateInfo/RealEstateInfo.ascx" TagName="RealEstateInfo"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery.maskedinput.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Date_Validation.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery.maskedinput.js"></script>
    <script language="javascript" type="text/javascript">

        function getVariance() {
            var txtActual = document.getElementById('<%=txtActual_Amount.ClientID%>').value;
            var txtProposed = document.getElementById('<%=txtProposal_Amount.ClientID%>').value;

            if (txtActual != '' && txtProposed != '') {
                var Variance = parseFloat(RemoveCommas(txtActual)) - parseFloat(RemoveCommas(txtProposed));
                document.getElementById('<%=txtVariance.ClientID%>').value = CurrencyFormatted(Variance);
            }

            return false;
        }
        function AuditPopUp() {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;

            obj = window.open("AuditPopup_RE_Repair_Maint.aspx?id=" + '<%=ViewState["PK_RE_Repair_Maintenance"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
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

        jQuery(function ($) {
            $("#<%=txtDate_PCA_Ordered.ClientID%>").mask("99/99/9999");
            $("#<%=txtDate_PCA_Conducted.ClientID%>").mask("99/99/9999");
            $("#<%=txtEstaimted_Start_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtActual_Start_Date.ClientID%>").mask("99/99/9999");
            $("#<%=txtEnd_Date.ClientID%>").mask("99/99/9999");
        });       
    </script>

    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <uc:CtlTab runat="server" ID="Tab"></uc:CtlTab>
            </td>
        </tr>
        <tr>
            <td style="height: 15px" class="Spacer" colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <uc2:RealEstateInfo ID="RealEstate_Info" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="height: 20px" class="Spacer" colspan="2">
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="leftMenu">
                            <table cellpadding="5" cellspacing="0" width="100%">
                                <tr>
                                    <td style="height: 10px;" class="Spacer">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu1" class="LeftMenuSelected">Repair/Maintenance</span>&nbsp;<span id="MenuAsterisk1" runat="server" style="color: Red;display:none">*</span>
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
                                            <asp:Panel ID="pnl1" runat="server">
                                                <div class="bandHeaderRow">
                                                    Real Estate : Repair/Maintenance</div>
                                                <table cellpadding="5" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td style="height: 5px;" colspan="6" class="Spacer">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Type of Repair&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:DropDownList ID="drpFK_LU_Repair_Type" Width="170px" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" width="28%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Date PCA Ordered&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtDate_PCA_Ordered" runat="server" Width="170px" />
                                                            <img alt="Date PCA Ordered" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_PCA_Ordered', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" /><br />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtDate_PCA_Ordered"
                                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                ErrorMessage="Date PCA Ordered Is Not Valid." Display="none" ValidationGroup="vsErrorGroup">
                                                            </asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Date PCA Conducted&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtDate_PCA_Conducted" runat="server" Width="170px" />
                                                            <img alt="Date PCA Conducted" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_PCA_Conducted', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" /><br />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtDate_PCA_Conducted"
                                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                ErrorMessage="Date PCA Conducted  Is Not Valid." Display="none" ValidationGroup="vsErrorGroup">
                                                            </asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            PCA Conducted By&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtPCA_Conducted_By" runat="server" Width="170px" MaxLength="75" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Scope of Work&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="drpFK_LU_Work_Scope" Width="170px" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            General Repair/Damage Description&nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="center" valign="top">
                                                            <asp:TextBox ID="txtRepairDesc" runat="server" Width="170px" MaxLength="50" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Detailed Description of Repair/Damage&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtDetailed_Description" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Contractor&nbsp;<span id="Span8" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:DropDownList ID="drpFK_RE_Contractor" Width="400px" runat="server" AutoPostBack="True"
                                                                OnSelectedIndexChanged="drpFK_RE_Contractor_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Contact Name
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblContactName" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Address 1
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblAddress1" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Address 2
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblAddress2" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            City
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCity" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            State
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblState" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Zip Code (XXXXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblZipCode" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Telephone (XXX-XXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTelephone" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Facsimile (XXX-XXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFacsimile" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Email
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Estimate Amount&nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            $&nbsp;
                                                            <asp:TextBox ID="txtEstimate_Amount" runat="server" Width="170px" onpaste="return false"
                                                                onkeypress="return currencyFormat(this,',','.',event);" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Proposal Amount&nbsp;<span id="Span10" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            $&nbsp;
                                                            <asp:TextBox ID="txtProposal_Amount" runat="server" Width="170px" onpaste="return false"
                                                                onkeypress="return currencyFormat(this,',','.',event);" onchange="javascript:return getVariance();"
                                                                onblur="javascript:return getVariance();" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Actual Amount&nbsp;<span id="Span11" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            $&nbsp;
                                                            <asp:TextBox ID="txtActual_Amount" runat="server" Width="170px" onpaste="return false"
                                                                onkeypress="return currencyFormat(this,',','.',event);" onchange="javascript:return getVariance();"
                                                                onblur="javascript:return getVariance();" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Variance&nbsp;<span id="Span12" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            $&nbsp;
                                                            <asp:TextBox ID="txtVariance" runat="server" ReadOnly="true"  Width="170px" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Estimated Start Date&nbsp;<span id="Span13" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtEstaimted_Start_Date" runat="server" Width="170px" />
                                                            <img alt="Estimated Start Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtEstaimted_Start_Date', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" /><br />
                                                            <asp:RegularExpressionValidator ID="revtxtLCDateTo" runat="server" ControlToValidate="txtEstaimted_Start_Date"
                                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                ErrorMessage="Estimated Start Date Is Not Valid." Display="none" ValidationGroup="vsErrorGroup">
                                                            </asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Actual Start Date&nbsp;<span id="Span14" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtActual_Start_Date" runat="server" Width="170px" onblur="javascript:return GetDaysDiff('ctl00_ContentPlaceHolder1_txtActual_Start_Date,ctl00_ContentPlaceHolder1_txtEnd_Date,ctl00_ContentPlaceHolder1_txtNumberofDay');" />
                                                            <img alt="Actual Start Date" onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtActual_Start_Date', 'mm/dd/y',GetDaysDiff,'ctl00_ContentPlaceHolder1_txtActual_Start_Date,ctl00_ContentPlaceHolder1_txtEnd_Date,ctl00_ContentPlaceHolder1_txtNumberofDay');" /><br />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtActual_Start_Date"
                                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                ErrorMessage="Actual Start Date Is Not Valid." Display="none" ValidationGroup="vsErrorGroup">
                                                            </asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            End Date&nbsp;<span id="Span15" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtEnd_Date" runat="server" Width="170px" onblur="javascript:return GetDaysDiff('ctl00_ContentPlaceHolder1_txtActual_Start_Date,ctl00_ContentPlaceHolder1_txtEnd_Date,ctl00_ContentPlaceHolder1_txtNumberofDay');" />
                                                            <img alt="End Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtEnd_Date', 'mm/dd/y',GetDaysDiff,'ctl00_ContentPlaceHolder1_txtActual_Start_Date,ctl00_ContentPlaceHolder1_txtEnd_Date,ctl00_ContentPlaceHolder1_txtNumberofDay');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" /><br />
                                                            <asp:CompareValidator ID="cfvToDate" runat="server" ControlToCompare="txtActual_Start_Date"
                                                                ValidationGroup="vsErrorGroup" Display="None" Type="Date" Operator="GreaterThanEqual"
                                                                ControlToValidate="txtEnd_Date" ErrorMessage="End Date Should Be Greater Than Actual Start Date."></asp:CompareValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEnd_Date"
                                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                ErrorMessage="End Date Is Not Valid." Display="none" ValidationGroup="vsErrorGroup">
                                                            </asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Number of Day&nbsp;<span id="Span16" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtNumberofDay" runat="server" ReadOnly="true" Width="170px" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </div>
                                        <div id="dvView" runat="server" width="794px">
                                            <asp:Panel ID="pnl1View" runat="server">
                                                <div class="bandHeaderRow">
                                                    Real Estate : Repair/Maintenance</div>
                                                <table cellpadding="5" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Type of Repair
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblFK_LU_Repair_Type" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" width="28%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Date PCA Ordered
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblDate_PCA_Ordered" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Date PCA Conducted
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblDate_PCA_Conducted" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            PCA Conducted By
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblPCA_Conducted_By" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Scope of Work
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_LU_Work_Scope" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            General Repair/Damage Description
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            <asp:Label ID="lblRepairDamageDesc" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Detailed Description of Repair/Damage
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblDetailed_Description" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Contractor
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_RE_Contractor" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Contact Name
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lblContractor_Contact" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Address 1
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblContractor_Address1" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Address 2
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblContractor_Address2" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            City
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblContractor_City" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            State
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_State_Contractor" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Zip Code (XXXXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblContractor_Zip_Code" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Telephone (XXX-XXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblContractor_Telephone" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Facsimile (XXX-XXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblContractor_Facsimile" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Email
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblContractor_Email" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Estimate Amount
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            $&nbsp;<asp:Label ID="lblEstimate_Amount" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Proposal Amount
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            $&nbsp;<asp:Label ID="lblProposal_Amount" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Actual Amount
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            $&nbsp;
                                                            <asp:Label ID="lblActual_Amount" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Variance
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            $&nbsp;<asp:Label ID="lblVarianceview" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Estimated Start Date
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblEstaimted_Start_Date" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Actual Start Date
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblActual_Start_Date" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            End Date
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblEnd_Date" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Number of Day
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblNumberofDayView" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="5px" class="Spacer" colspan="6">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="center">
                                                            <asp:Button ID="btnBack" runat="server" Text=" Back " CausesValidation="false" ValidationGroup="vsErrorGroup"
                                                                OnClick="btnBack_Click" />&nbsp;
                                                            <asp:Button ID="btnViewAudit2" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <%--<td>
                            &nbsp;
                        </td>--%>
                        <td align="center" colspan="2">
                            <div id="dvSave" runat="server">
                                <table cellpadding="10" cellspacing="0" border="0" width="100%">
                                    <tr>
                                        <td align="center">
                                            <asp:Button ID="btnSave" runat="server" Text="Save & View" OnClick="btnSave_Click"
                                                CausesValidation="true" ValidationGroup="vsErrorGroup" />
                                            &nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btnRevert" runat="server" Text="Revert & Return" CausesValidation="false"
                                                ValidationGroup="vsErrorGroup" OnClick="btnBack_Click" />&nbsp;
                                            <asp:Button ID="btnViewAudit" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();" />
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
