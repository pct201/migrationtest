<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true"
    CodeFile="ServiceContract.aspx.cs" Inherits="SONIC_Purchasing_ServiceContract"
    Title="eRIMS Sonic :: Add Service Contract" %>

<%@ Register Src="../../Controls/SONIC_Purchasing/Purchasing.ascx" TagName="Purchasing"
    TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment-ExecutiveRisk/Attachment.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment-ExecutiveRisk/AttachmentDetails.ascx" TagName="ctrlAttachmentDetails"
    TagPrefix="uc" %>
<%@ Register Src="../../Controls/SONIC_Purchasing/Purchasing_Search.ascx" TagName="Purchasing_Search"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Date_Validation.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery.maskedinput.js"></script>
    <script language="javascript" type="text/javascript">

        function ContactInformationPopUp(ContactType, intPkID) {
            var values = '<%=ViewState["PK_Purchasing_Service_Contract"]%>';
            if (values == '0') {
                alert('Please Save Service Contract Information First');
                ShowPanel(1);
                return false;
            }
            else {
                var winHeight = window.screen.availHeight - 300;
                var winWidth = window.screen.availWidth - 500;

                obj = window.open("PopUp_ContactInformation.aspx?Type=" + ContactType + "&id=" + '<%=ViewState["PK_Purchasing_Service_Contract"]%>' + "&PkID=" + intPkID + "&TN=SC", 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
                obj.focus();
                return false;
            }
        }
        //OPen Audit Popup
        function AuditPopUp() {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;

            obj = window.open("AuditPopup_ServiceContract.aspx?id=" + '<%=ViewState["PK_Purchasing_Service_Contract"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }
        function ReportPopUp() {
            var winHeight = window.screen.availHeight - 500;
            var winWidth = window.screen.availWidth - 800;

            window.open("RptServiceContractAbstract.aspx?id=" + '<%=ViewState["PK_Purchasing_Service_Contract"]%>', '', 'width=' + 200 + ',height=' + 200 + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            //

            return false;
        }
        //check Date Validation
        function CheckDate(sender, args) {
            args.IsValid = (ValidateDate(args.Value));
            return args.IsValid;
        }
        var ActiveTabIndex = 1;
        function onNextStep() {
            if (ActiveTabIndex == 4) {
                var op = '<%=StrOperation%>';
                document.getElementById("ctl00_ContentPlaceHolder1_btnNextStep").style.display = "block";
                if (op == "view") {
                    ActiveTabIndex = 1;
                    ShowPanel(ActiveTabIndex);
                    return false;
                }
                else {
                    return ValSave();
                }
            }
            else {
                ActiveTabIndex = ActiveTabIndex + 1;
                ShowPanel(ActiveTabIndex);
                if (ActiveTabIndex == 4) {
                    document.getElementById("ctl00_ContentPlaceHolder1_btnNextStep").style.display = "none";
                }
                else {
                    document.getElementById("ctl00_ContentPlaceHolder1_btnNextStep").style.display = "block";
                }
                return false;
            }
        }

        function onDrpAutoRenueChange() {
            var drp = document.getElementById("ctl00_ContentPlaceHolder1_drpAutoRenueOptions");
            var txt = document.getElementById("ctl00_ContentPlaceHolder1_txtAutorenueOther");

            if (drp != null) {
                if (drp.options[drp.selectedIndex].text.trim().toLowerCase() == "other") {
                    txt.disabled = '';
                }
                else {
                    txt.disabled = 'disabled';
                }
            }
        }

        function ShowPanel(index) {
            SetMenuStyle(index);
            ActiveTabIndex = index;
            var op = '<%=StrOperation%>';
            if (op == "view") {
                document.getElementById("<%=dvSave.ClientID %>").style.display = "none";
                ShowPanelView(index);
            }
            else {
                var i;
                if (index < 4) {
                    document.getElementById("<%=pnlServiceContract.ClientID%>").style.display = (index == 1) ? "block" : "none";
                    for (i = 2; i <= 4; i++) {
                        document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display = (i == index) ? "block" : "none";
                    }
                    document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_btnNextStep").style.display = "block";
                }
                else {
                    for (i = 2; i <= 4; i++) {
                        document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display = "none";
                    }
                    document.getElementById("ctl00_ContentPlaceHolder1_pnl4").style.display = "block";
                    document.getElementById("<%=pnlServiceContract.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_btnNextStep").style.display = "none";
                }
            }

        }
        function SetMenuStyle(index) {
            var i;
            for (i = 1; i <= 4; i++) {
                var tb = document.getElementById("SonicPurchasing" + i);
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

        function ConfirmDelete() {
            return confirm("Are you sure you want to delete this record?");
        }

        function ConfirmDeleteSubRecord(intCount) {
            if (intCount > 0) {
                return confirm("One or more Assets exist that are linked to the entity that you are trying to remove. Do you want to remove the entity and its associated Assets?");
            }
            else {
                return confirm("Are you sure you want to delete this record?");
            }
            return false;
        }

        function ShowPanelView(index) {
            SetMenuStyle(index);
            document.getElementById('<%=dvView.ClientID%>').style.display = "block";
            var i;
            if (index < 4) {
                document.getElementById("<%=pnlServiceContractView.ClientID%>").style.display = (index == 1) ? "block" : "none";
                for (i = 2; i <= 4; i++) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i + "view").style.display = (i == index) ? "block" : "none";
                }
                document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "none";
            }
            else {
                for (i = 2; i <= 4; i++) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i + "view").style.display = "none";
                }
                document.getElementById("<%=pnlServiceContractView.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "block";
            }
        }

        function ValAttach() {
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqAttachType').enabled = true;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqFile').enabled = true;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_cstFile').enabled = true;

            if (Page_ClientValidate())
                return true;
            else
                return false;
        }

        function ValSave() {
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqAttachType').enabled = false;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqFile').enabled = false;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_cstFile').enabled = false;

            var rtn = ClearDefaultValues(1);
            if (rtn == false) {
                return false;
            }

            var grdDepart = document.getElementById('ctl00_ContentPlaceHolder1_gvDealeshipDepartment');
            if (grdDepart.rows.length <= 1) {
                alert("Please Enter Dealership Department Entry.");
                return false;
            }
            var grdDealer = document.getElementById('ctl00_ContentPlaceHolder1_gvDealershipGrid');
            if (grdDealer.rows.length <= 1) {
                alert("Please Enter Dealership Grid Entry.");
                return false;
            }

            if (Page_ClientValidate()) {
                return true;
            }
            else
                return false;
        }

        function ClearDefaultValues(intStatus) {
            return true;
        }


        function onMonthlyCostchange() {
            var months = document.getElementById('<%=txtMonthlyCost.ClientID%>').value;
            if (months == '') {
                months = 0;
                document.getElementById('<%=txtMonthlyCost.ClientID%>').value = "0";
            }
            var i = 12;
            var TotalCommitted = 0;
            var Annualcost = parseFloat(months.replace(",", "")) * parseFloat(i);
            var Temsmonths = document.getElementById('<%=txtTermInMonths.ClientID%>').value;
            if (Temsmonths != '') {
                TotalCommitted = parseFloat(Annualcost) * (parseFloat(Temsmonths) / parseFloat(12));
            }
            if (CurrencyFormatted(Annualcost) == document.getElementById('<%=txtAnnualCost.ClientID%>').value.trim()) {
                return false;
            }
            if (document.getElementById('<%=txtAnnualCost.ClientID%>').value.trim() != '') {
                var result = confirm("Do you want to recalculate the Annual Cost value?");
                if (result == false)
                    return false;
            }
            document.getElementById('<%=txtAnnualCost.ClientID%>').value = formatCurrency(Annualcost).replace("$", "");

            if (CurrencyFormatted(TotalCommitted) == document.getElementById('<%=txtTotalCommitted.ClientID%>').value.trim()) {
                return false;
            }
            if (document.getElementById('<%=txtTotalCommitted.ClientID%>').value.trim() != '') {
                var result = confirm("Do you want to recalculate the Total Committed Cost value?");
                if (result == false)
                    return false;
            }
            document.getElementById('<%=txtTotalCommitted.ClientID%>').value = formatCurrency(TotalCommitted).replace("$", "");

            return false;
        }

        function onAnnualCostchange() {
            var Temsmonths = document.getElementById('<%=txtTermInMonths.ClientID%>').value;
            var Annualcost = document.getElementById('<%=txtAnnualCost.ClientID%>').value;
            if (Annualcost == '') {
                Annualcost = 0;
                document.getElementById('<%=txtAnnualCost.ClientID%>').value = "0";
            }
            var TotalCommitted = 0;
            if (Temsmonths != '') {
                TotalCommitted = parseFloat(Annualcost.replace(",", "")) * (parseFloat(Temsmonths) / parseFloat(12));
            }
            if (CurrencyFormatted(TotalCommitted) == document.getElementById('<%=txtTotalCommitted.ClientID%>').value.trim()) {
                return false;
            }
            if (document.getElementById('<%=txtTotalCommitted.ClientID%>').value.trim() != '') {
                var result = confirm("Do you want to recalculate the Total Committed Cost value?");
                if (result == false)
                    return false;
            }

            document.getElementById('<%=txtTotalCommitted.ClientID%>').value = formatCurrency(TotalCommitted).replace("$", "");
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
            else {
                args.IsValid = true;
            }
        }

        jQuery(function ($) {
            $("#<%=txtStartDate.ClientID%>").mask("99/99/9999");
            $("#<%=txtEndDate.ClientID%>").mask("99/99/9999");
            $("#<%=txtNotificationDate.ClientID%>").mask("99/99/9999");
        });
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
                <uc1:Purchasing_Search ID="Purchasing_SearchTAB" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <uc1:Purchasing ID="PurchasingTab" runat="server"></uc1:Purchasing>
            </td>
        </tr>
        <tr>
            <td style="height: 20px" class="Spacer" colspan="2">
            </td>
        </tr>
        <tr>
            <td class="leftMenu">
                <table cellpadding="0" cellspacing="0" width="203px">
                    <tr>
                        <td style="height: 10px;" class="Spacer">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Menu ID="mnuServiceContract" runat="server" DataSourceID="dsSiteMap" StaticEnableDefaultPopOutImage="false">
                                <StaticItemTemplate>
                                    <table cellpadding="5" cellspacing="0" width="100%">
                                        <tr>
                                            <td align="left" width="100%">
                                                <span id="SonicPurchasing<%#Container.ItemIndex+1%>" onclick="javascript:ShowPanel(<%#Container.ItemIndex+1%>);"
                                                    class="LeftMenuStatic">
                                                    <%#Eval("Text")%>&nbsp;
                                                     <asp:Label ID="MenuAsterisk" runat="server" Text="*" style="color: Red;display:none"  ></asp:Label> 
                                                </span>
                                            </td>
                                        </tr>
                                    </table>
                                </StaticItemTemplate>
                            </asp:Menu>
                            <asp:SiteMapDataSource ID="dsSiteMap" runat="server" SiteMapProvider="PurchasingServiceContractMenuProvider"
                                ShowStartingNode="false" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px;" class="Spacer">
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top" width="100%">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td width="5px">
                            &nbsp;
                        </td>
                        <td class="dvContainer">
                            <div id="dvEdit" runat="server" width="794px">
                                <asp:Panel ID="pnlServiceContract" runat="server" Style="display: none;">
                                    <div class="bandHeaderRow">
                                        Service Contract</div>
                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                        <tr>
                                            <td align="left" width="18%">
                                                Supplier&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td align="center" width="4%">
                                                :
                                            </td>
                                            <td align="left" width="28%">
                                                <asp:TextBox ID="txtSupplier" runat="server" Width="170px" MaxLength="75" />
                                                <%--<asp:RequiredFieldValidator ID="rfvSupplier" runat="server" ControlToValidate="txtSupplier"
                                                    Display="none" ErrorMessage="Please Enter [Service Contract]/Supplier" SetFocusOnError="true"
                                                    ValidationGroup="vsErrorGroup" />--%>
                                            </td>
                                            <td align="left" width="18%">
                                                Service Type&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td align="center" width="4%">
                                                :
                                            </td>
                                            <td align="left" width="28%">
                                                <asp:TextBox ID="txtServiceType" runat="server" Width="170px" MaxLength="75" />
                                                <%--<asp:RequiredFieldValidator ID="rfvServicetype" runat="server" ControlToValidate="txtServiceType"
                                                    Display="none" ErrorMessage="Please Enter [Service Contract]/Service Type" SetFocusOnError="true"
                                                    ValidationGroup="vsErrorGroup" />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="18%">
                                                Start Date&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td align="center" width="4%">
                                                :
                                            </td>
                                            <td align="left" width="28%">
                                                <asp:TextBox ID="txtStartDate" runat="server" onchange="javascript:setTermsInManthEndDate('ctl00_ContentPlaceHolder1_txtStartDate,ctl00_ContentPlaceHolder1_txtEndDate,ctl00_ContentPlaceHolder1_txtTermInMonths,2');"></asp:TextBox>
                                                <img alt="Service Contract Start Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtStartDate', 'mm/dd/y',setTermsInManthEndDate,'ctl00_ContentPlaceHolder1_txtStartDate,ctl00_ContentPlaceHolder1_txtEndDate,ctl00_ContentPlaceHolder1_txtTermInMonths,2');"
                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                    align="middle" /><br />
                                               <asp:RegularExpressionValidator ID="revDateClaimClosed" runat="server" ControlToValidate="txtStartDate"
                                                    ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                    ErrorMessage="[Service Contract]/Start Date Not Valid" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                            </td>
                                            <td align="left" width="18%">
                                                End Date&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td align="center" width="4%">
                                                :
                                            </td>
                                            <td align="left" width="28%">
                                                <asp:TextBox ID="txtEndDate" runat="server" onchange="javascript:setTermsInManthEndDate('ctl00_ContentPlaceHolder1_txtStartDate,ctl00_ContentPlaceHolder1_txtEndDate,ctl00_ContentPlaceHolder1_txtTermInMonths,1');"></asp:TextBox>
                                                <img alt="Service Contract End Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtEndDate', 'mm/dd/y',setTermsInManthEndDate,'ctl00_ContentPlaceHolder1_txtStartDate,ctl00_ContentPlaceHolder1_txtEndDate,ctl00_ContentPlaceHolder1_txtTermInMonths,1');"
                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                    align="middle" /><br />
                                                <asp:RegularExpressionValidator ID="revEndDate" runat="server" ControlToValidate="txtEndDate"
                                                    ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                    ErrorMessage="[Service Contract]/End Date Not Valid" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                <asp:CompareValidator ID="cbDate" runat="server" ErrorMessage="Start Date Must Be Less Than End Date."
                                                    ControlToCompare="txtStartDate" Type="Date" ValidationGroup="vsErrorGroup" Operator="GreaterThan"
                                                    ControlToValidate="txtEndDate" Display="none"></asp:CompareValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="18%">
                                                Term in Months&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td align="center" width="4%">
                                                :
                                            </td>
                                            <td align="left" width="28%">
                                                <asp:TextBox ID="txtTermInMonths" onpaste="return false" onkeypress="return FormatNumber(event,this.id,6,false);"
                                                    runat="server" Width="170px" MaxLength="6" onblur="javascript:setTermsInManthEndDate('ctl00_ContentPlaceHolder1_txtStartDate,ctl00_ContentPlaceHolder1_txtEndDate,ctl00_ContentPlaceHolder1_txtTermInMonths,0');" />
                                            </td>
                                            <td align="left" width="18%">
                                                Service Frequency&nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td align="center" width="4%">
                                                :
                                            </td>
                                            <td align="left" width="28%">
                                                <asp:TextBox ID="txtServiceFrequency" runat="server" Width="170px" MaxLength="75" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="18%">
                                                Monthly Cost&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td align="center" width="4%">
                                                :
                                            </td>
                                            <td align="left" width="28%">
                                                <asp:TextBox ID="txtMonthlyCost" onKeyPress="return(currencyFormat(this,',','.',event));"
                                                    runat="server" Width="160px" MaxLength="13" onblur="javascript:return onMonthlyCostchange();"
                                                    onpaste="return false;" />
                                            </td>
                                            <td align="left" width="18%">
                                                Annual Cost&nbsp;<span id="Span8" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td align="center" width="4%">
                                                :
                                            </td>
                                            <td align="left" width="28%">
                                                $&nbsp;
                                                <asp:TextBox ID="txtAnnualCost" onKeyPress="return(currencyFormat(this,',','.',event));"
                                                    runat="server" Width="160px" MaxLength="15" onblur="javascript:return onAnnualCostchange();"
                                                    onpaste="return false;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="18%">
                                                Contract Level&nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td align="center" width="4%">
                                                :
                                            </td>
                                            <td align="left" width="28%">
                                                <asp:DropDownList ID="drpContractLevel" Width="170px" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left" width="18%">
                                                Total Committed $&nbsp;<span id="Span10" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td align="center" width="4%">
                                                :
                                            </td>
                                            <td align="left" width="28%">
                                                $&nbsp;
                                                <asp:TextBox ID="txtTotalCommitted" onKeyPress="return(currencyFormat(this,',','.',event));"
                                                    runat="server" Width="160px" MaxLength="15" onpaste="return false;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="18%">
                                                Legal Confidential?
                                            </td>
                                            <td align="center" width="4%">
                                                :
                                            </td>
                                            <td align="left" width="28%">
                                                <asp:RadioButtonList ID="rdoLegalConfidential" runat="server" SkinID="YesNoType">
                                                </asp:RadioButtonList>
                                            </td>
                                            <td align="left" width="18%">
                                                Customer/Contract Number&nbsp;<span id="Span11" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td align="center" width="4%">
                                                :
                                            </td>
                                            <td align="left" width="28%">
                                                <asp:TextBox ID="txtCustomerContractNumber" runat="server" Width="170px" MaxLength="50" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="18%">
                                                Auto Renew Options&nbsp;<span id="Span12" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td align="center" width="4%">
                                                :
                                            </td>
                                            <td align="left" width="28%">
                                                <asp:DropDownList ID="drpAutoRenueOptions" Width="170px" runat="server" onchange="javascript:onDrpAutoRenueChange();">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left" width="18%">
                                                Auto Renew Other&nbsp;<span id="Span13" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td align="center" width="4%">
                                                :
                                            </td>
                                            <td align="left" width="28%">
                                                <asp:TextBox ID="txtAutorenueOther" runat="server" Enabled="false" Width="170px"
                                                    MaxLength="75" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="18%">
                                                Notification Method&nbsp;<span id="Span14" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td align="center" width="4%">
                                                :
                                            </td>
                                            <td align="left" width="28%">
                                                <asp:DropDownList ID="drpNotificationMethod" Width="170px" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left" width="18%">
                                                Notification Date&nbsp;<span id="Span15" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td align="center" width="4%">
                                                :
                                            </td>
                                            <td align="left" width="28%">
                                                <asp:TextBox ID="txtNotificationDate" runat="server"></asp:TextBox>
                                                <img alt="Notification Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtNotificationDate', 'mm/dd/y');"
                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                    align="middle" /><br />
                                                <asp:RegularExpressionValidator ID="revNotification" runat="server" ControlToValidate="txtNotificationDate"
                                                    ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                    ErrorMessage="[Service Contract]/Notification Date Not Valid" Display="none"
                                                    ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">
                                                Status&nbsp;<span id="Span16" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td align="center" valign="top">
                                                :
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:DropDownList ID="ddlStatus" runat="server" Width="170px">
                                                    <asp:ListItem Value="" Text="--Select--"></asp:ListItem>
                                                    <asp:ListItem Value="Active" Text="Active"></asp:ListItem>
                                                    <asp:ListItem Value="InActive" Text="InActive"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left">
                                                Is COI Needed?
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:RadioButtonList ID="rdbCOINeed" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">
                                                Contract Notes&nbsp;<span id="Span17" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td align="center" valign="top">
                                                :
                                            </td>
                                            <td align="left" colspan="4">
                                                <uc:ctrlMultiLineTextBox ID="txtContractNotes" runat="server" IsRequired="false" />
                                            </td>
                                        </tr>
                                        <%-- <tr>
                                            <td align="left" valign="top">
                                                Applicable Dealers
                                            </td>
                                            <td align="center" valign="top">
                                                :
                                            </td>
                                            <td align="left" colspan="4">
                                                <uc:ctrlMultiLineTextBox ID="txtApplicableDealers" runat="server" IsRequired="false" />
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td align="left" width="18%" valign="top" nowrap="nowrap">
                                                Dealership Department Grid&nbsp;<span style="color: Red;">*</span>
                                                <br />
                                                <asp:LinkButton ID="lnkDealshipDepartment" runat="server" Text="--Add--" OnClientClick="javascript:return ClearDefaultValues(0);"
                                                    OnClick="lnkDealshipDepartment_Click" ValidationGroup="vsErrorGroup" CausesValidation="true">
                                                </asp:LinkButton>
                                            </td>
                                            <td align="center" width="4%" valign="top">
                                                :
                                            </td>
                                            <td align="left" colspan="4" valign="top">
                                                <asp:GridView ID="gvDealeshipDepartment" runat="server" Width="100%" AutoGenerateColumns="false"
                                                    OnRowCommand="gvDealeshipDepartment_RowCommand" CellPadding="3" OnRowDataBound="gvDealeshipDepartment_DataRowBound">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Department">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkedit" CommandArgument='<%#Eval("PK_Purchasing_SC_Department")%>'
                                                                    CommandName="edititem" CausesValidation="true" ValidationGroup="vsErrorGroup"
                                                                    runat="server"><%#Eval("Fld_Desc")%></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="20%" HeaderStyle-HorizontalAlign="right" ItemStyle-HorizontalAlign="right"
                                                            HeaderText="Remove">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="hdCount" runat="server" Value='<%#Eval("AssetCount")%>' />
                                                                <asp:LinkButton ID="lnkRemove" CommandArgument='<%#Eval("PK_Purchasing_SC_Department")%>'
                                                                    CommandName="remove" runat="server">Remove</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        <asp:Label ID="lblEmptyEmergencyMessage" runat="server" Text="No Record Found"></asp:Label>
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="18%" valign="top" nowrap="nowrap">
                                                Dealership Grid&nbsp;<span style="color: Red;">*</span>
                                                <br />
                                                <asp:LinkButton ID="lnkDealershipGrid" runat="server" Text="--Add--" OnClick="lnkDealershipGrid_Click"
                                                    ValidationGroup="vsErrorGroup" CausesValidation="true" OnClientClick="javascript:return ClearDefaultValues(0);">
                                                </asp:LinkButton>
                                            </td>
                                            <td align="center" width="4%" valign="top">
                                                :
                                            </td>
                                            <td align="left" colspan="4" valign="top">
                                                <asp:GridView ID="gvDealershipGrid" runat="server" Width="100%" AutoGenerateColumns="false"
                                                    OnRowCommand="gvDealershipGrid_RowCommand" CellPadding="3" OnRowDataBound="gvDealershipGrid_DataRowBound">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Dealer Name">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkLegalEntity" CommandArgument='<%#Eval("PK_Purchasing_SC_Dealer")%>'
                                                                    CommandName="edititem" CausesValidation="true" ValidationGroup="vsErrorGroup"
                                                                    runat="server"><%#Eval("dba")%></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Address">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkaddress" CommandArgument='<%#Eval("PK_Purchasing_SC_Dealer")%>'
                                                                    CommandName="edititem" CausesValidation="true" ValidationGroup="vsErrorGroup"
                                                                    runat="server"><%#Eval("Address_1")%></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="20%" HeaderStyle-HorizontalAlign="right" ItemStyle-HorizontalAlign="right"
                                                            HeaderText="Remove">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="hdCount" runat="server" Value='<%#Eval("AssetCount")%>' />
                                                                <asp:LinkButton ID="lnkRemove" CommandArgument='<%#Eval("PK_Purchasing_SC_Dealer")%>'
                                                                    CommandName="remove" runat="server">Remove</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        <asp:Label ID="lblEmptyEmergencyMessage" runat="server" Text="No Record Found"></asp:Label>
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="18%" valign="top" nowrap="nowrap">
                                                Applicable Assets Grid
                                                <br />
                                                <asp:LinkButton ID="lnkApplicableAssets" runat="server" Text="--Add--" OnClick="lnkApplicableAssets_Click"
                                                    ValidationGroup="vsErrorGroup" CausesValidation="true" OnClientClick="javascript:return ClearDefaultValues(0);">
                                                </asp:LinkButton>
                                            </td>
                                            <td align="center" width="4%" valign="top">
                                                :
                                            </td>
                                            <td align="left" colspan="4" valign="top">
                                                <asp:GridView ID="gvApplicableAssets" runat="server" Width="100%" AutoGenerateColumns="false"
                                                    OnRowCommand="gvApplicableAssets_RowCommand" CellPadding="3">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Asset Type">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkType" CommandArgument='<%#Eval("PK_Purchasing_SC_Asset")%>'
                                                                    CommandName="edititem" CausesValidation="true" ValidationGroup="vsErrorGroup"
                                                                    runat="server"><%#Eval("Type")%></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Manufacturer">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkManu" CommandArgument='<%#Eval("PK_Purchasing_SC_Asset")%>'
                                                                    CommandName="edititem" CausesValidation="true" ValidationGroup="vsErrorGroup"
                                                                    runat="server"><%#Eval("Fld_Desc")%></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Supplier">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkSupplier" CommandArgument='<%#Eval("PK_Purchasing_SC_Asset")%>'
                                                                    CommandName="edititem" CausesValidation="true" ValidationGroup="vsErrorGroup"
                                                                    runat="server"><%#Eval("Supplier")%></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="20%" HeaderStyle-HorizontalAlign="right" ItemStyle-HorizontalAlign="right"
                                                            HeaderText="Remove">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkRemove" CommandArgument='<%#Eval("PK_Purchasing_SC_Asset")%>'
                                                                    CommandName="remove" runat="server">Remove</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        <asp:Label ID="lblEmptyEmergencyMessage" runat="server" Text="No Record Found"></asp:Label>
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnl2" runat="server" Style="display: none;">
                                    <div class="bandHeaderRow">
                                        Service Contract - Contact Information</div>
                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                        <tr>
                                            <td align="left" width="11%" valign="top" nowrap="nowrap">
                                                Supplier Contact Grid
                                                <br />
                                                <asp:LinkButton ID="lnkSuppilerAdd" runat="server" Text="--Add--" ValidationGroup="vsErrorGroup"
                                                    CausesValidation="true" OnClientClick="javascript:return ContactInformationPopUp(2,0);">
                                                </asp:LinkButton>
                                                <div style="display: none;">
                                                    <asp:Button ID="btnPK" runat="server" OnClick="btnPK_Click" /></div>
                                            </td>
                                            <td align="center" width="4%" valign="top">
                                                :
                                            </td>
                                            <td align="left" width="85%" valign="top">
                                                <asp:GridView ID="gvSuppiler" runat="server" Width="100%" AutoGenerateColumns="false"
                                                    OnRowCommand="gvSuppiler_RowCommand" OnRowDataBound="gvSuppiler_DataRowBound"
                                                    CellPadding="3">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Supplier" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Left"
                                                            HeaderStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <%#Eval("Supplier")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Contact Date" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Left"
                                                            HeaderStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <%# String.Format("{0:MMM-dd-yyyy}",Eval("ContactDate"))%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Contact Name" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Left"
                                                            HeaderStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <%#Eval("ContactName")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Address" ItemStyle-Width="25%" ItemStyle-HorizontalAlign="Left"
                                                            HeaderStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAddress1" runat="server"></asp:Label>
                                                                <asp:Label ID="lblAddress2" runat="server"></asp:Label>
                                                                <asp:Label ID="lblContactDeatail" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Work Telephone" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Left"
                                                            HeaderStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <%#Eval("Work_Telephone")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="right" ItemStyle-HorizontalAlign="right"
                                                            HeaderText="Remove">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkRemoveSupplier" CommandArgument='<%#Eval("PK_Purchasing_Contacts_Link")%>'
                                                                    CommandName="remove" runat="server" OnClientClick="return confirm('Are you sure you want to delete this record?');">Remove</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        <asp:Label ID="lblEmptyEmergencyMessage" runat="server" Text="No Record Found"></asp:Label>
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="11%" valign="top" nowrap="nowrap">
                                                Sonic Contact Grid
                                                <br />
                                                <asp:LinkButton ID="lnkSonicAdd" runat="server" Text="--Add--" OnClick="lnkApplicableAssets_Click"
                                                    ValidationGroup="vsErrorGroup" CausesValidation="true" OnClientClick="javascript:return ContactInformationPopUp(1,0);">
                                                </asp:LinkButton>
                                            </td>
                                            <td align="center" width="4%" valign="top">
                                                :
                                            </td>
                                            <td align="left" width="85%" valign="top">
                                                <asp:GridView ID="gvSonic" runat="server" Width="100%" AutoGenerateColumns="false"
                                                    OnRowCommand="gvSonic_RowCommand" OnRowDataBound="gvSonic_DataRowBound" CellPadding="3">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Supplier" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Left"
                                                            HeaderStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <%#Eval("Supplier")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Contact Date" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Left"
                                                            HeaderStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <%# String.Format("{0:MMM-dd-yyyy}",Eval("ContactDate"))%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Contact Name" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Left"
                                                            HeaderStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <%#Eval("ContactName")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Address" ItemStyle-Width="25%" ItemStyle-HorizontalAlign="Left"
                                                            HeaderStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAddress1" runat="server"></asp:Label>
                                                                <asp:Label ID="lblAddress2" runat="server"></asp:Label>
                                                                <asp:Label ID="lblSonicContactDeatail" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Work Telephone" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Left"
                                                            HeaderStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <%#Eval("Work_Telephone")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="right" ItemStyle-HorizontalAlign="right"
                                                            HeaderText="Remove">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkSonicRemoveSupplier" CommandArgument='<%#Eval("PK_Purchasing_Contacts_Link")%>'
                                                                    CommandName="remove" runat="server" OnClientClick="return confirm('Are you sure you want to delete this record?');">Remove</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        <asp:Label ID="lblEmptyEmergencyMessage" runat="server" Text="No Record Found"></asp:Label>
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnl3" runat="server" Style="display: none;">
                                    <div class="bandHeaderRow">
                                        Service Contract - Note Grid</div>
                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                        <tr>
                                            <td align="left" width="18%" valign="top">
                                                Notes Grid
                                                <br />
                                                <asp:LinkButton ID="lblAddNotes" runat="server" Text="--Add--" OnClick="lblAddNotes_Click"
                                                    ValidationGroup="vsErrorGroup" CausesValidation="true" OnClientClick="javascript:return ClearDefaultValues(1);">
                                                </asp:LinkButton>
                                            </td>
                                            <td align="center" width="4%" valign="top">
                                                :
                                            </td>
                                            <td width="78%" align="left" valign="top">
                                                <asp:GridView ID="gvNotesGrid" runat="server" Width="100%" AutoGenerateColumns="false"
                                                    OnRowCommand="gvNotesGrid_RowCommand">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Note Date">
                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                            <ItemTemplate>
                                                                <a href='ServiceContractNote.aspx?id=<%#Encryption.Encrypt(Eval("PK_Purchasing_SC_Notes").ToString())%>'>
                                                                    <%#Eval("Note_Date","{0:MMM-dd-yyyy}")%>
                                                                </a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Note Text Snippet">
                                                            <ItemStyle HorizontalAlign="Left" Width="60%" />
                                                            <ItemTemplate>
                                                                <a href='ServiceContractNote.aspx?id=<%#Encryption.Encrypt(Eval("PK_Purchasing_SC_Notes").ToString())%>'>
                                                                    <asp:Label ID="Label1" CssClass="TextClip" Width="430px" runat="server" Text='<%#Eval("Note")%>'></asp:Label>
                                                                </a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Remove">
                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CommandName="remove"
                                                                    CommandArgument='<%#Eval("PK_Purchasing_SC_Notes")%>' OnClientClick="return ConfirmDelete();"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        <asp:Label ID="lblEmptyEmergencyMessage" runat="server" Text="No Record Found"></asp:Label>
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnl4" runat="server" Style="display: none;">
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td width="100%">
                                                <uc:ctrlAttachment ID="Attachment" runat="Server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="Spacer" style="height: 20px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="Spacer" style="height: 20px;" colspan="2">
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </div>
                            <div id="dvView" runat="server">
                                <asp:Panel ID="pnlServiceContractView" runat="server" Style="display: none;">
                                    <div class="bandHeaderRow">
                                        Service Contract</div>
                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                        <tr>
                                            <td align="left" width="18%" valign="top">
                                                Supplier&nbsp;<span style="color: Red;">*</span>
                                            </td>
                                            <td align="center" width="4%" valign="top">
                                                :
                                            </td>
                                            <td align="left" width="28%" valign="top">
                                                <asp:Label ID="lblSupplier" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td align="left" width="18%" valign="top">
                                                Service Type&nbsp;<span style="color: Red;">*</span>
                                            </td>
                                            <td align="center" width="4%" valign="top">
                                                :
                                            </td>
                                            <td align="left" width="28%" valign="top">
                                                <asp:Label ID="lblServiceType" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="18%" valign="top">
                                                Start Date
                                            </td>
                                            <td align="center" width="4%" valign="top">
                                                :
                                            </td>
                                            <td align="left" width="28%" valign="top">
                                                <asp:Label ID="lblStartDate" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td align="left" width="18%" valign="top">
                                                End Date
                                            </td>
                                            <td align="center" width="4%" valign="top">
                                                :
                                            </td>
                                            <td align="left" width="28%" valign="top">
                                                <asp:Label ID="lblEndDate" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="18%" valign="top">
                                                Term in Months
                                            </td>
                                            <td align="center" width="4%" valign="top">
                                                :
                                            </td>
                                            <td align="left" width="28%" valign="top">
                                                <asp:Label ID="lblTermInMonth" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td align="left" width="18%" valign="top">
                                                Service Frequency
                                            </td>
                                            <td align="center" width="4%" valign="top">
                                                :
                                            </td>
                                            <td align="left" width="28%" valign="top">
                                                <asp:Label ID="lblServiceFrequency" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="18%" valign="top">
                                                Monthly Cost
                                            </td>
                                            <td align="center" width="4%" valign="top">
                                                :
                                            </td>
                                            <td align="left" width="28%" valign="top">
                                                <asp:Label ID="lblMonthlyCost" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td align="left" width="18%" valign="top">
                                                Annual Cost
                                            </td>
                                            <td align="center" width="4%" valign="top">
                                                :
                                            </td>
                                            <td align="left" width="28%" valign="top">
                                                <asp:Label ID="lblAnnualCost" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="18%" valign="top">
                                                Contract Level
                                            </td>
                                            <td align="center" width="4%" valign="top">
                                                :
                                            </td>
                                            <td align="left" width="28%" valign="top">
                                                <asp:Label ID="lblControlLevel" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td align="left" width="18%" valign="top">
                                                Total Committed $
                                            </td>
                                            <td align="center" width="4%" valign="top">
                                                :
                                            </td>
                                            <td align="left" width="28%" valign="top">
                                                <asp:Label ID="lblTotalCommitted" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="18%" valign="top">
                                                Legal Confidential?
                                            </td>
                                            <td align="center" width="4%" valign="top">
                                                :
                                            </td>
                                            <td align="left" width="28%" valign="top">
                                                <asp:Label ID="lblLegalConfidential" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td align="left" width="18%">
                                                Customer/Contract Number
                                            </td>
                                            <td align="center" width="4%">
                                                :
                                            </td>
                                            <td align="left" width="28%">
                                                <asp:Label ID="lblCustomerContractorNumber" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="18%" valign="top">
                                                Auto Renew Options
                                            </td>
                                            <td align="center" width="4%" valign="top">
                                                :
                                            </td>
                                            <td align="left" width="28%" valign="top">
                                                <asp:Label ID="lblAutoRenew" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td align="left" width="18%" valign="top">
                                                Auto Renew Other
                                            </td>
                                            <td align="center" width="4%" valign="top">
                                                :
                                            </td>
                                            <td align="left" width="28%" valign="top">
                                                <asp:Label ID="lblAutorenueOther" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="18%" valign="top">
                                                Notification Method
                                            </td>
                                            <td align="center" width="4%" valign="top">
                                                :
                                            </td>
                                            <td align="left" width="28%" valign="top">
                                                <asp:Label ID="lblNotificationMethod" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td align="left" width="18%" valign="top">
                                                Notification Date
                                            </td>
                                            <td align="center" width="4%" valign="top">
                                                :
                                            </td>
                                            <td align="left" width="28%" valign="top">
                                                <asp:Label ID="lblNotificationDate" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">
                                                Status
                                            </td>
                                            <td align="center" valign="top">
                                                :
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td align="left" valign="top">
                                                Is COI Needed?
                                            </td>
                                            <td align="center" valign="top">
                                                :
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:Label ID="lblCOINeeded" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">
                                                Contract Notes
                                            </td>
                                            <td align="center" valign="top">
                                                :
                                            </td>
                                            <td align="left" colspan="4" valign="top">
                                                <uc:ctrlMultiLineTextBox ID="lblContractNote" runat="server" ControlType="Label" />
                                            </td>
                                        </tr>
                                        <%--   <tr>
                                            <td align="left" valign="top">
                                                Applicable Dealers
                                            </td>
                                            <td align="center" valign="top">
                                                :
                                            </td>
                                            <td align="left" colspan="4">
                                                <uc:ctrlMultiLineTextBox ID="lblApplicableDealers" runat="server" ControlType="Label" />
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td align="left" width="18%" valign="top" nowrap="nowrap">
                                                Dealership Department Grid
                                            </td>
                                            <td align="center" width="4%" valign="top">
                                                :
                                            </td>
                                            <td align="left" colspan="4" valign="top">
                                                <asp:GridView ID="gvDealeshipDepartmentView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                    CellPadding="3">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Department">
                                                            <ItemTemplate>
                                                                <%#Eval("Fld_Desc")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        <asp:Label ID="lblEmptyEmergencyMessage" runat="server" Text="No Record Found"></asp:Label>
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="18%" valign="top" nowrap="nowrap">
                                                Dealership Grid
                                            </td>
                                            <td align="center" width="4%" valign="top">
                                                :
                                            </td>
                                            <td align="left" colspan="4" valign="top">
                                                <asp:GridView ID="gvDealershipGridView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                    CellPadding="3">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Dealer Name">
                                                            <ItemTemplate>
                                                                <%#Eval("dba")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Address">
                                                            <ItemTemplate>
                                                                <%#Eval("Address_1")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        <asp:Label ID="lblEmptyEmergencyMessage" runat="server" Text="No Record Found"></asp:Label>
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="18%" valign="top" nowrap="nowrap">
                                                Applicable Assets Grid
                                            </td>
                                            <td align="center" width="4%" valign="top">
                                                :
                                            </td>
                                            <td align="left" colspan="4" valign="top">
                                                <asp:GridView ID="gvApplicableAssetsView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                    CellPadding="3">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Asset Type">
                                                            <ItemTemplate>
                                                                <%#Eval("Type")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Manufacturer">
                                                            <ItemTemplate>
                                                                <%#Eval("Fld_Desc")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Supplier">
                                                            <ItemTemplate>
                                                                <%#Eval("Supplier")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        <asp:Label ID="lblEmptyEmergencyMessage" runat="server" Text="No Record Found"></asp:Label>
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnl2view" runat="server" Style="display: none;">
                                    <div class="bandHeaderRow">
                                        Service Contract - Contact Information</div>
                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                        <tr>
                                            <td align="left" width="18%" valign="top" nowrap="nowrap">
                                                Supplier Contact Grid
                                            </td>
                                            <td align="center" width="4%" valign="top">
                                                :
                                            </td>
                                            <td align="left" colspan="4" valign="top">
                                                <asp:GridView ID="gvSupplierView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                    OnRowDataBound="gvSupplierView_DataRowBound" CellPadding="3">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Supplier" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Left"
                                                            HeaderStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <%#Eval("Supplier")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Contact Date" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Left"
                                                            HeaderStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <%# String.Format("{0:MMM-dd-yyyy}",Eval("ContactDate"))%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ContactName" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Left"
                                                            HeaderStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <%#Eval("ContactName")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Address" ItemStyle-Width="25%" ItemStyle-HorizontalAlign="Left"
                                                            HeaderStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAddress1View" runat="server"></asp:Label>
                                                                <asp:Label ID="lblAddress2View" runat="server"></asp:Label>
                                                                <asp:Label ID="lblSupplierContactDeatailView" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Work Telephone" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Left"
                                                            HeaderStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <%#Eval("Work_Telephone")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        <asp:Label ID="lblEmptyEmergencyMessage" runat="server" Text="No Record Found"></asp:Label>
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="18%" valign="top" nowrap="nowrap">
                                                Sonic Contact Grid
                                            </td>
                                            <td align="center" width="4%" valign="top">
                                                :
                                            </td>
                                            <td align="left" colspan="4" valign="top">
                                                <asp:GridView ID="gvSonicView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                    OnRowDataBound="gvSonicView_DataRowBound" CellPadding="3">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Supplier" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Left"
                                                            HeaderStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <%#Eval("Supplier")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Contact Date" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Left"
                                                            HeaderStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <%# String.Format("{0:MMM-dd-yyyy}",Eval("ContactDate"))%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ContactName" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Left"
                                                            HeaderStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <%#Eval("ContactName")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Address" ItemStyle-Width="25%" ItemStyle-HorizontalAlign="Left"
                                                            HeaderStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSonicAddress1View" runat="server"></asp:Label>
                                                                <asp:Label ID="lblSonicAddress2View" runat="server"></asp:Label>
                                                                <asp:Label ID="lblSonicContactDeatailView" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Work Telephone" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Left"
                                                            HeaderStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <%#Eval("Work_Telephone")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        <asp:Label ID="lblEmptyEmergencyMessage" runat="server" Text="No Record Found"></asp:Label>
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnl3view" runat="server" Style="display: none;">
                                    <div class="bandHeaderRow">
                                        Service Contract - Note Grid</div>
                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                        <tr>
                                            <td width="100%" align="left" valign="top">
                                                <asp:GridView ID="gvNotesGridView" runat="server" Width="100%" AutoGenerateColumns="false">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Note Date">
                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                            <ItemTemplate>
                                                                <a href='ServiceContractNote.aspx?id=<%#Encryption.Encrypt(Eval("PK_Purchasing_SC_Notes").ToString())%>'>
                                                                    <%#Eval("Note_Date","{0:MMM-dd-yyyy}")%>
                                                                </a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Note Text Snippet">
                                                            <ItemStyle HorizontalAlign="Left" Width="85%" />
                                                            <ItemTemplate>
                                                                <a href='ServiceContractNote.aspx?id=<%#Encryption.Encrypt(Eval("PK_Purchasing_SC_Notes").ToString())%>'>
                                                                    <asp:Label ID="Label1" CssClass="TextClip" Width="650px" runat="server" Text='<%#Eval("Note")%>'></asp:Label>
                                                                </a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        <asp:Label ID="lblEmptyEmergencyMessage" runat="server" Text="No Record Found"></asp:Label>
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnl4view" runat="server" Style="display: none;">
                                </asp:Panel>
                            </div>
                            <asp:Panel ID="pnlAttachmentDetails" runat="server" Style="display: none;">
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td width="100%">
                                            <uc:ctrlAttachmentDetails ID="AttachDetails" runat="Server" />
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
            <td align="center">
                <div id="dvSave" runat="server">
                    <table cellpadding="5" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td colspan="4" width="100%" class="Spacer" style="height: 15px;">
                            </td>
                        </tr>
                        <tr>
                            <td width="50%" align="right">
                                <asp:Button ID="btnSave" runat="server" Text="Save & View" OnClick="btnSaveAndView_Click"
                                    ValidationGroup="vsErrorGroup" OnClientClick="return ValSave();" CausesValidation="true" />
                                &nbsp;
                            </td>
                            <td id="tdAuditTrial" runat="server" visible="false">
                                <asp:Button runat="server" ID="btnLAAudit" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();"
                                    ToolTip="View Audit Trail" CausesValidation="false" />
                            </td>
                            <td id="tdAbstractReport" runat="server" visible="false">
                                <asp:Button ID="btnReportView" runat="server" Text="Generate Abstract Report" OnClientClick="javascript:return ReportPopUp();" />
                            </td>
                            <td align="left" width="50%">
                                <asp:Button ID="btnNextStep" runat="server" Text="Next Step" CausesValidation="true"
                                    ValidationGroup="vsErrorGroup" OnClientClick="return onNextStep();" OnClick="btnNextStep_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" width="100%" class="Spacer" style="height: 15px;">
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2" width="100%" align="center" valign="middle">
                <asp:Button ID="btnBack" runat="server" Text="Back & Edit" OnClick="btnBack_Click"
                    Visible="false" />&nbsp;<asp:Button runat="server" ID="btnLAAudit_View" Text="View Audit Trail"
                        OnClientClick="javascript:return AuditPopUp();" ToolTip="View Audit Trail" CausesValidation="false" />&nbsp;
                <asp:Button ID="btnVAbstractReport" runat="server" Text="Generate Abstract Report"
                    OnClientClick="javascript:return ReportPopUp();" Width="185px" Visible="false" />&nbsp;
                <asp:Button ID="btnNextStepView" runat="server" Text="Next Step" CausesValidation="false"
                    Visible="false" OnClientClick="return onNextStep();" OnClick="btnNextStepView_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="4" width="100%" class="Spacer" style="height: 15px;">
            </td>
        </tr>
    </table>
    <asp:CustomValidator ID="CustomValidator" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
        Display="None" ValidationGroup="vsErrorGroup" />
    <input id="hdnControlIDs" runat="server" type="hidden" />
    <input id="hdnErrorMsgs" runat="server" type="hidden" />
</asp:Content>
