<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="RentProjectionORS.aspx.cs"
    Inherits="SONIC_RealEstate_RentProjectionORS" Title="Real Estate : Rent Projection Option Rent Schedule" %>

<%@ Register Src="~/Controls/ExposuresTab/ExposuresTab.ascx" TagName="CtlTab" TagPrefix="uc" %>
<%@ Register Src="../../Controls/RealEstateInfo/RealEstateInfo.ascx" TagName="RealEstateInfo"
    TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Date_Validation.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery.maskedinput.js"></script>
   
    <script language="javascript" type="text/javascript">
        jQuery(function ($) {
            $("#<%=txtFromDate.ClientID%>").mask("99/99/9999");
            $("#<%=txtToDate.ClientID%>").mask("99/99/9999");
        });
        function GetMonthDiff(inttype) {
            var txtTemsinMonth = document.getElementById('<%=txtNumberOfMonth.ClientID%>');
            var txtsDate = document.getElementById('<%=txtFromDate.ClientID%>');
            var txtEDate = document.getElementById('<%=txtToDate.ClientID%>');

            if (txtEDate.value != null && txtEDate.value.trim() != '' && txtsDate.value != null && txtsDate.value.trim() != '') {
                if (isDate(txtEDate.value) && isDate(txtsDate.value)) {
                    var user_date = Date.parse(txtEDate.value);
                    var today_date = Date.parse(txtsDate.value);
                    var diff_date = user_date - today_date;
                    var num_month = diff_date / 2628000000;
                    // var num_month = diff_date/86400000 - for a day;                               
                    var strterms = num_month.toString();
                    var strsub = strterms.indexOf('.');
                    var intmonth = 0;
                    var intdays = 0;
                    if (parseInt(strsub) > -1) {
                        intmonth = strterms.substring(0, parseInt(strsub));
                        intdays = strterms.substring(parseInt(strsub) + 1, parseInt(strsub) + 3);
                        strterms = intmonth + '.' + intdays;
                    }
                    if (parseFloat(strterms) < 0) {
                        txtTemsinMonth.value = "0";
                        alert("End Date Should Be Greater Then Start Date");
                    }
                    else {
                        txtTemsinMonth.value = strterms;
                    }
                }
            }
            if (inttype == 0) {
                var txtsDate = document.getElementById('<%=txtFromDate.ClientID%>');
                var LedDate = '<%=DtLeaseCommenceDate%>'
                if (isDate(txtsDate.value) && isDate(LedDate)) {
                    var user_date = Date.parse(LedDate);
                    var today_date = Date.parse(txtsDate.value);
                    var diff_date = user_date - today_date;
                    var num_month = diff_date / 2628000000;
                    // var num_month = diff_date/86400000 - for a day;                               
                    var strterms = num_month.toString();
                    if (parseFloat(strterms) >= 0) {
                        document.getElementById('<%=lblMonthalyRent.ClientID%>').value = "0";
                        alert("From Date Should Be Greater Then Lease Commencement Date.");
                        return false;
                    }
                    onFromDateChange();
                }
            }

            return false;
        }

        function onFromDateChange() {
            __doPostBack('GetMonthlyRent', "GetMonthlyRent");
        }
        function AuditPopUp() {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;

            obj = window.open("AuditPopup_RE_RentProjections_ORS.aspx?id=" + '<%=ViewState["PK_RE_Rent_Projection_ORS"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
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
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <table width="100%" cellpadding="0" cellspacing="0">
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
            <td class="Spacer" width="100%" style="height: 15px;" colspan="2">
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
            <td class="leftMenu" width="18%">
                <table cellpadding="0" cellspacing="0" width="203px">
                    <tr>
                        <td style="height: 10px;" class="Spacer">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="5" cellspacing="0" width="100%">
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="SubtenantTRS" class="LeftMenuSelected">Option Rent Schedule</span>
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
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td width="5px">
                            &nbsp;
                        </td>
                        <td class="dvContainer" align="center">
                            <div id="dvEdit" runat="server">
                                <div class="bandHeaderRow">
                                    Rent Projections - Option Rent Schedule</div>
                                <table width="98%" cellpadding="5" cellspacing="1" border="0" align="center">
                                    <tr>
                                        <td style="height: 8px;" colspan="6" class="Spacer">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="16%" align="left" nowrap="nowrap" valign="top">
                                            Option Period
                                        </td>
                                        <td width="4%" align="center" valign="top">
                                            :
                                        </td>
                                        <td width="30%" align="left" valign="top">
                                            <asp:Label ID="lblOptionPeriod" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td colspan="3">
                                        </td>
                                    </tr>
                                    <tr runat="server" id="trEditDate">
                                        <td width="16%" align="left" nowrap="nowrap" valign="top">
                                            From Date&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                        </td>
                                        <td width="4%" align="center" valign="top">
                                            :
                                        </td>
                                        <td width="30%" align="left" valign="top">
                                            <asp:TextBox ID="txtFromDate" runat="server" MaxLength="10" SkinID="txtDate" onblur="javascript:return GetMonthDiff(0);"
                                                onchange="javascript:return GetMonthDiff(0);"></asp:TextBox>
                                            <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtFromDate', 'mm/dd/y',setTermsInManthEndDate,'ctl00_ContentPlaceHolder1_txtFromDate,ctl00_ContentPlaceHolder1_txtToDate,ctl00_ContentPlaceHolder1_txtNumberOfMonth,3');"
                                                alt="From Date" src="../../Images/iconPicDate.gif" align="middle" />
                                            <asp:RegularExpressionValidator ID="rvFromDate" runat="server" ControlToValidate="txtFromDate"
                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                ErrorMessage="From Date Is Not Valid." Display="none" ValidationGroup="vsErrorGroup">
                                            </asp:RegularExpressionValidator>
                                        </td>
                                        <td width="16%" align="left" nowrap="nowrap" valign="top">
                                            To Date&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                        </td>
                                        <td width="4%" align="center" valign="top">
                                            :
                                        </td>
                                        <td width="30%" align="left" valign="top">
                                            <asp:TextBox ID="txtToDate" runat="server" MaxLength="10" SkinID="txtDate" onblur="javascript:return GetMonthDiff(1);"
                                                onchange="javascript:return GetMonthDiff();"></asp:TextBox>
                                            <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtToDate', 'mm/dd/y',setTermsInManthEndDate,'ctl00_ContentPlaceHolder1_txtFromDate,ctl00_ContentPlaceHolder1_txtToDate,ctl00_ContentPlaceHolder1_txtNumberOfMonth,3');"
                                                alt="Lease Commence Date From" src="../../Images/iconPicDate.gif" align="middle" />
                                            <asp:RegularExpressionValidator ID="revtxtLCDateTo" runat="server" ControlToValidate="txtToDate"
                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                ErrorMessage="To Date Is Not Valid." Display="none" ValidationGroup="vsErrorGroup">
                                            </asp:RegularExpressionValidator>
                                            <asp:CompareValidator ID="cfvToDate" runat="server" ControlToCompare="txtFromDate"
                                                ValidationGroup="vsErrorGroup" Display="None" Type="Date" Operator="GreaterThanEqual"
                                                ControlToValidate="txtToDate" ErrorMessage="From Date Must Be Less Than Or Equal To Date."></asp:CompareValidator>
                                        </td>
                                    </tr>
                                    <tr runat="server" id="trViewDate" visible="false">
                                        <td width="16%" align="left" nowrap="nowrap" valign="top">
                                            From Date
                                        </td>
                                        <td width="4%" align="center" valign="top">
                                            :
                                        </td>
                                        <td width="30%" align="left" valign="top">
                                            <asp:Label ID="lblFromdate" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td width="16%" align="left" nowrap="nowrap" valign="top">
                                            To Date
                                        </td>
                                        <td width="4%" align="center" valign="top">
                                            :
                                        </td>
                                        <td width="30%" align="left" valign="top">
                                            <asp:Label ID="lblToDate" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="16%" align="left" nowrap="nowrap" valign="top">
                                            Number of Months&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                        </td>
                                        <td width="4%" align="center" valign="top">
                                            :
                                        </td>
                                        <td width="30%" align="left" valign="top">
                                            <asp:TextBox ID="txtNumberOfMonth" runat="server" MaxLength="6" onpaste="return false"
                                                onkeypress="return FormatNumber(event,this.id,6,false);"></asp:TextBox>
                                            <asp:Label ID="lblNumberofMonth" runat="server" Text="" Visible="false"></asp:Label>
                                        </td>
                                        <td colspan="3">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="16%" align="left" nowrap="nowrap" valign="top">
                                            Monthly Rent
                                        </td>
                                        <td width="4%" align="center" valign="top">
                                            :
                                        </td>
                                        <td width="30%" align="left" valign="top">
                                            $&nbsp;<asp:Label ID="lblMonthalyRent" runat="server" Text="0.0"></asp:Label>
                                        </td>
                                        <td width="16%" align="left" nowrap="nowrap" valign="top">
                                        </td>
                                        <td width="4%" align="center" valign="top">
                                        </td>
                                        <td width="30%" align="left" valign="top">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6">
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
        <tr>
            <%--<td>
                &nbsp;
            </td>--%>
            <td align="center" colspan="2">
                <table cellpadding="5" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td width="50%" align="right">
                            <asp:Button ID="btnSave" runat="server" Text="Save & View" ValidationGroup="vsErrorGroup"
                                CausesValidation="true" OnClick="btnSave_Click" />
                        </td>
                        <td align="left">
                            <asp:Button ID="btnRevertandReturn" runat="server" Text="Revert & Return" CausesValidation="false"
                                OnClick="btnRevertandReturn_Click" />&nbsp;
                            <asp:Button ID="btnViewAudit" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 10px;" colspan="2">
            </td>
        </tr>
    </table>
    <asp:CustomValidator ID="CustomValidator" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
        Display="None" ValidationGroup="vsErrorGroup" />
    <input id="hdnControlIDs" runat="server" type="hidden" />
    <input id="hdnErrorMsgs" runat="server" type="hidden" />
</asp:Content>
