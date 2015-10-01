<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="CRMSearch.aspx.cs" Inherits="SONIC_CRM_CRMSearch" ValidateRequest="false" %>

<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Date_Validation.js"></script>
    <script language="javascript" type="text/javascript">
        function onIncidentTypeChange() {
            var drpIncident = document.getElementById('ctl00_ContentPlaceHolder1_drpIncidentType');

            if (drpIncident.options[drpIncident.selectedIndex].text == 'Customer') {
                document.getElementById('ctl00_ContentPlaceHolder1_pnlSearch').style.display = "block";
                document.getElementById('ctl00_ContentPlaceHolder1_pnlnonCustomer').style.display = "none";
                trCustomer.style.display = "";
                trNonCustomer.style.display = "none";
                trIncidentType.style.display = "none";
                document.getElementById('ctl00_ContentPlaceHolder1_txtComplaintNumber_Cust').focus();
            }
            else if (drpIncident.options[drpIncident.selectedIndex].text == 'Non-Customer') {
                document.getElementById('ctl00_ContentPlaceHolder1_pnlSearch').style.display = "none";
                document.getElementById('ctl00_ContentPlaceHolder1_pnlnonCustomer').style.display = "block";
                trCustomer.style.display = "none";
                trNonCustomer.style.display = "";
                trIncidentType.style.display = "none";
                document.getElementById('ctl00_ContentPlaceHolder1_txtContactNumber_NonCust').focus();
            }
            else {
                document.getElementById('ctl00_ContentPlaceHolder1_pnlSearch').style.display = "none";
                document.getElementById('ctl00_ContentPlaceHolder1_pnlnonCustomer').style.display = "none";
                trCustomer.style.display = "none";

                trNonCustomer.style.display = "none";
                trIncidentType.style.display = "";
                drpIncident.focus();
            }
            drpIncident.selectedIndex = 0;
            ClearScreen();
        }
        function onCancelSearch() {
            var drpIncident = document.getElementById('ctl00_ContentPlaceHolder1_drpIncidentType');
            drpIncident.selectedIndex = 0;
            trCustomer.style.display = "none";
            trNonCustomer.style.display = "none";
            document.getElementById('ctl00_ContentPlaceHolder1_pnlSearch').style.display = "none";
            document.getElementById('ctl00_ContentPlaceHolder1_pnlnonCustomer').style.display = "none";
            trIncidentType.style.display = "block";
            drpIncident.focus();

            return false;
        }

        function ClearScreen() {
            document.getElementById('ctl00_ContentPlaceHolder1_txtComplaintNumber_Cust').value = '';
            document.getElementById('ctl00_ContentPlaceHolder1_txtIncidentDateFrom_Cust').value = '';
            document.getElementById('ctl00_ContentPlaceHolder1_txtIncidentDateTo_Cust').value = '';
            document.getElementById('ctl00_ContentPlaceHolder1_drpSource_Cust').selectedIndex = 0;
            document.getElementById('ctl00_ContentPlaceHolder1_txtLastName_Cust').value = '';
            document.getElementById('ctl00_ContentPlaceHolder1_txtFirstName_Cust').value = '';
            document.getElementById('ctl00_ContentPlaceHolder1_txtLastNameCoBuyer_Cust').value = '';
            document.getElementById('ctl00_ContentPlaceHolder1_txtFirstNameCoBuyer_Cust').value = '';
            document.getElementById('ctl00_ContentPlaceHolder1_drpDepartment_Cust').selectedIndex = 0;
            document.getElementById('ctl00_ContentPlaceHolder1_drpLocationDBA_Cust').selectedIndex = 0;
            document.getElementById('ctl00_ContentPlaceHolder1_txtLastUpdateFrom_Cust').value = '';
            document.getElementById('ctl00_ContentPlaceHolder1_txtLastUpdateTo_Cust').value = '';
            document.getElementById('ctl00_ContentPlaceHolder1_txtLastAction_Cust').value = '';
            document.getElementById('ctl00_ContentPlaceHolder1_txtCloseDateTo_Cust').value = '';
            document.getElementById('ctl00_ContentPlaceHolder1_txtCloseDateFrom_Cust').value = '';
            document.getElementById('ctl00_ContentPlaceHolder1_txtDateResolutionLetterFrom_Cust').value = '';
            document.getElementById('ctl00_ContentPlaceHolder1_txtDateResolutionLetterTo_Cust').value = '';
            document.getElementById('ctl00_ContentPlaceHolder1_txtCompany_name').value = '';
            var rdbLetterNA_Cust = document.getElementById('ctl00_ContentPlaceHolder1_rdbLetterNA_Cust');
            var rdbLetterNA_CustArray = rdbLetterNA_Cust.getElementsByTagName('input');
            for (var i = 0; i < rdbLetterNA_CustArray.length; i++) {
                var inputElement = rdbLetterNA_CustArray[i];

                inputElement.checked = false;
            }

            var rdbComplete_Cust = document.getElementById('ctl00_ContentPlaceHolder1_rdbComplete_Cust');
            var rdbComplete_CustArray = rdbComplete_Cust.getElementsByTagName('input');
            for (var i = 0; i < rdbComplete_CustArray.length; i++) {
                var inputElement = rdbComplete_CustArray[i];

                inputElement.checked = false;
            }

            var rdbResolutionLetter_Cust = document.getElementById('ctl00_ContentPlaceHolder1_rdbResolutionLetter_Cust');
            var rdbResolutionLetter_CustArray = rdbResolutionLetter_Cust.getElementsByTagName('input');
            for (var i = 0; i < rdbResolutionLetter_CustArray.length; i++) {
                var inputElement = rdbResolutionLetter_CustArray[i];

                inputElement.checked = false;
            }

            document.getElementById('ctl00_ContentPlaceHolder1_txtContactNumber_NonCust').value = '';
            document.getElementById('ctl00_ContentPlaceHolder1_txtContactDateFrom_NonCust').value = '';
            document.getElementById('ctl00_ContentPlaceHolder1_txtContactDateTo_NonCust').value = '';
            document.getElementById('ctl00_ContentPlaceHolder1_drpLocationDBA_NonCust').selectedIndex = 0;
            document.getElementById('ctl00_ContentPlaceHolder1_drpCategory_NonCust').selectedIndex = 0;
            document.getElementById('ctl00_ContentPlaceHolder1_txtResponseDateFrom_NonCust').value = '';
            document.getElementById('ctl00_ContentPlaceHolder1_txtResponseDateTo_NonCust').value = '';
            document.getElementById('ctl00_ContentPlaceHolder1_txtLastName_NonCust').value = '';
            document.getElementById('ctl00_ContentPlaceHolder1_txtFirstName_NonCust').value = '';
            document.getElementById('ctl00_ContentPlaceHolder1_drpSoruce_NonCust').selectedIndex = 0;

            var rdbReponseNA_NonCust = document.getElementById('ctl00_ContentPlaceHolder1_rdbReponseNA_NonCust');
            var rdbReponseNA_NonCustArray = rdbReponseNA_NonCust.getElementsByTagName('input');
            for (var i = 0; i < rdbReponseNA_NonCustArray.length; i++) {
                var inputElement = rdbReponseNA_NonCustArray[i];

                inputElement.checked = false;
            }

            var rdbReponseSent_NonCust = document.getElementById('ctl00_ContentPlaceHolder1_rdbReponseSent_NonCust');
            var rdbReponseSent_NonCustArray = rdbReponseSent_NonCust.getElementsByTagName('input');
            for (var i = 0; i < rdbReponseSent_NonCustArray.length; i++) {
                var inputElement = rdbReponseSent_NonCustArray[i];

                inputElement.checked = false;
            }
        }
        function ConfirmRemove() {
            return confirm("Are you sure to delete?");
        }
        function FireDefaultButton(event, target)         
        {
            if (event.keyCode == 13) 
            {
                var element = event.target || event.srcElement;

                if (element == document.getElementById('ctl00_ContentPlaceHolder1_txtComplaintNumber_Cust') || element == document.getElementById('ctl00_ContentPlaceHolder1_txtContactNumber_NonCust') || element == document.getElementById('ctl00_ContentPlaceHolder1_txtLastName_Cust') || element == document.getElementById('ctl00_ContentPlaceHolder1_txtLastName_NonCust')
                || element == document.getElementById('ctl00_ContentPlaceHolder1_txtCompany_name')) {
                    var defaultButton;
                    defaultButton = document.getElementById(target);
                    if (defaultButton && "undefined" != typeof defaultButton.click) {
                        defaultButton.click();
                        event.cancelBubble = true;
                        if (event.stopPropagation)
                            event.stopPropagation();
                        return false;
                    }
                }
                else
                    return false;             
            }
            return true;
        }

    </script>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsCustomerGroup" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="false"
            ShowMessageBox="true" HeaderText="Verify the following fields:" BorderWidth="1"
            BorderColor="DimGray" ValidationGroup="vsNonCustomerGroup" CssClass="errormessage">
        </asp:ValidationSummary>
    </div>
    <div style="width: 100%" id="dvSearch" runat="server">
        <table width="100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td align="left" colspan="3">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="left" class="bandHeaderRow" colspan="3">
                    CRM Search
                </td>
            </tr>
            <tr>
                <td align="left" colspan="3" style="height: 20px;">
                    &nbsp;
                </td>
            </tr>
            <tr style="height: 150px; vertical-align: middle;" id="trIncidentType">
                <td align="right" width="30%">
                    Incident Type
                </td>
                <td align="center" width="10%">
                    :
                </td>
                <td align="left">
                    <asp:DropDownList ID="drpIncidentType" runat="server" AutoPostBack="false" Width="200px"
                        SkinID="dropGen" onchange="javascript:onIncidentTypeChange();">
                        <asp:ListItem Text="--Select--" Value="" Selected="True" />
                        <asp:ListItem Text="Customer" Value="Customer" />
                        <asp:ListItem Text="Non-Customer" Value="Non-Customer" />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <div id="pnlSearch" runat="server" onkeypress="return FireDefaultButton(event, 'ctl00_ContentPlaceHolder1_btnSearch_cust')">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr id="trCustomer" style="display: none;">
                                <td width="15%">
                                    &nbsp;
                                </td>
                                <td align="left" colspan="2">
                                    <table cellpadding="3" cellspacing="1" width="90%" border="0">
                                        <tr>
                                            <td align="left" width="25%">
                                                Incident Type
                                            </td>
                                            <td width="2%" align="center">
                                                :
                                            </td>
                                            <td align="left" width="33%">
                                                Customer
                                            </td>
                                            <td align="left" width="10%">
                                            </td>
                                            <td width="2%" align="center">
                                            </td>
                                            <td align="left" width="30%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Complaint Number
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left" colspan="4">
                                                <asp:TextBox ID="txtComplaintNumber_Cust" Width="190px" runat="server" SkinID="txtYearWithRange"
                                                    MaxLength="20"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Date of Incident From
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtIncidentDateFrom_Cust" runat="server" Width="175px" SkinID="txtdate"
                                                    MaxLength="10">
                                                </asp:TextBox>
                                                <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtIncidentDateFrom_Cust.ClientID%>', 'mm/dd/y');"
                                                    alt="Date of Incident From" src="../../Images/iconPicDate.gif" align="middle" />
                                                <%-- <asp:RegularExpressionValidator ID="rvIncidentDateFrom" runat="server" ControlToValidate="txtIncidentDateFrom_Cust"
                                    ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                    ErrorMessage="Date of Incident From Is Not Valid" Display="none" ValidationGroup="vsCustomerGroup"></asp:RegularExpressionValidator>--%>
                                                <asp:RegularExpressionValidator ID="rvIncidentDateFrom" runat="server" ValidationGroup="vsCustomerGroup"
                                                    Display="none" ErrorMessage="Date of Incident From Is Not Valid" SetFocusOnError="true"
                                                    ControlToValidate="txtIncidentDateFrom_Cust" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                            </td>
                                            <td align="left">
                                                To
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtIncidentDateTo_Cust" runat="server" SkinID="txtdate" MaxLength="10">
                                                </asp:TextBox>
                                                <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtIncidentDateTo_Cust.ClientID%>', 'mm/dd/y');"
                                                    alt="Date of Incident To" src="../../Images/iconPicDate.gif" align="middle" />
                                                <asp:CompareValidator ID="cbDate" runat="server" ErrorMessage="Date of Incident From  Must Be Less Than Date of Incident To"
                                                    ControlToCompare="txtIncidentDateFrom_Cust" Type="Date" ValidationGroup="vsCustomerGroup"
                                                    Operator="GreaterThanEqual" ControlToValidate="txtIncidentDateTo_Cust" Display="none">
                                                </asp:CompareValidator>
                                                <asp:RegularExpressionValidator ID="rvIncidentDateTo" runat="server" ControlToValidate="txtIncidentDateTo_Cust"
                                                    ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                                    ErrorMessage="Date of Incident To Is Not Valid" Display="none" ValidationGroup="vsCustomerGroup">
                                                </asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Source
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left" colspan="4">
                                                <asp:DropDownList ID="drpSource_Cust" runat="server" AutoPostBack="false" Width="200px"
                                                    SkinID="dropGen">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Last Name
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left" colspan="4">
                                                <asp:TextBox ID="txtLastName_Cust" Width="190px" runat="server" MaxLength="50"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                First Name
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left" colspan="4">
                                                <asp:TextBox ID="txtFirstName_Cust" Width="190px" runat="server" MaxLength="50"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Last Name Co-Buyer or Caller
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left" colspan="4">
                                                <asp:TextBox ID="txtLastNameCoBuyer_Cust" Width="190px" runat="server" MaxLength="75"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                First Name Co-Buyer or Caller                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left" colspan="4">
                                                <asp:TextBox ID="txtFirstNameCoBuyer_Cust" Width="190px" runat="server" MaxLength="75"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Department
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left" colspan="4">
                                                <asp:DropDownList ID="drpDepartment_Cust" runat="server" AutoPostBack="false" Width="200px"
                                                    SkinID="dropGen">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Location D/B/A
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left" colspan="4">
                                                <asp:DropDownList ID="drpLocationDBA_Cust" runat="server" AutoPostBack="false" Width="200px"
                                                    SkinID="dropGen">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Date of Last Update From
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtLastUpdateFrom_Cust" runat="server" Width="175px" SkinID="txtdate"
                                                    MaxLength="10">
                                                </asp:TextBox>
                                                <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtLastUpdateFrom_Cust.ClientID%>', 'mm/dd/y');"
                                                    alt="Date of Last Update From" src="../../Images/iconPicDate.gif" align="middle" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtLastUpdateFrom_Cust"
                                                    ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                                    ErrorMessage="Date of Last Update From Is Not Valid" Display="none" ValidationGroup="vsCustomerGroup">
                                                </asp:RegularExpressionValidator>
                                            </td>
                                            <td align="left">
                                                To
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtLastUpdateTo_Cust" runat="server" SkinID="txtdate" MaxLength="10">
                                                </asp:TextBox>
                                                <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtLastUpdateTo_Cust.ClientID%>', 'mm/dd/y');"
                                                    alt="Date of Last Update To" src="../../Images/iconPicDate.gif" align="middle" />
                                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Date of Last Update From Must Be Less Than Date of Last Update To"
                                                    ControlToCompare="txtLastUpdateFrom_Cust" Type="Date" ValidationGroup="vsCustomerGroup"
                                                    Operator="GreaterThanEqual" ControlToValidate="txtLastUpdateTo_Cust" Display="none">
                                                </asp:CompareValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtLastUpdateTo_Cust"
                                                    ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                                    ErrorMessage="Date of Last Update To Is Not Valid" Display="none" ValidationGroup="vsCustomerGroup">
                                                </asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Last Action
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left" colspan="4">
                                                <asp:TextBox ID="txtLastAction_Cust" Width="190px" runat="server" MaxLength="75"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Complete?
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left" colspan="4">
                                                <asp:RadioButtonList ID="rdbComplete_Cust" runat="server" RepeatDirection="Horizontal"
                                                    SkinID="YNTypeNullSelection">
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Close Date From
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtCloseDateFrom_Cust" runat="server" Width="175px" SkinID="txtdate"
                                                    MaxLength="10">
                                                </asp:TextBox>
                                                <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtCloseDateFrom_Cust.ClientID%>', 'mm/dd/y');"
                                                    alt="Close Date From" src="../../Images/iconPicDate.gif" align="middle" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtCloseDateFrom_Cust"
                                                    ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                                    ErrorMessage="Close Date From Is Not Valid" Display="none" ValidationGroup="vsCustomerGroup">
                                                </asp:RegularExpressionValidator>
                                            </td>
                                            <td align="left">
                                                To
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtCloseDateTo_Cust" runat="server" SkinID="txtdate" MaxLength="10">
                                                </asp:TextBox>
                                                <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtCloseDateTo_Cust.ClientID%>', 'mm/dd/y');"
                                                    alt="Close Date To" src="../../Images/iconPicDate.gif" align="middle" />
                                                <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Close Date From Must Be Less Than Close Date To"
                                                    ControlToCompare="txtCloseDateFrom_Cust" Type="Date" ValidationGroup="vsCustomerGroup"
                                                    Operator="GreaterThanEqual" ControlToValidate="txtCloseDateTo_Cust" Display="none">
                                                </asp:CompareValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtCloseDateTo_Cust"
                                                    ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                                    ErrorMessage="Close Date To Is Not Valid" Display="none" ValidationGroup="vsCustomerGroup">
                                                </asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Resolution Letter to Customer?
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left" colspan="4">
                                                <asp:RadioButtonList ID="rdbResolutionLetter_Cust" runat="server" RepeatDirection="Horizontal"
                                                    SkinID="YNTypeNullSelection">
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Date Resolution Letter Sent From
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtDateResolutionLetterFrom_Cust" runat="server" Width="175px" SkinID="txtdate"
                                                    MaxLength="10">
                                                </asp:TextBox>
                                                <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtDateResolutionLetterFrom_Cust.ClientID%>', 'mm/dd/y');"
                                                    alt="Date Resolution Letter Sent From" src="../../Images/iconPicDate.gif" align="middle" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtDateResolutionLetterFrom_Cust"
                                                    ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                                    ErrorMessage="Date Resolution Letter Sent From Is Not Valid" Display="none" ValidationGroup="vsCustomerGroup">
                                                </asp:RegularExpressionValidator>
                                            </td>
                                            <td align="left">
                                                To
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtDateResolutionLetterTo_Cust" runat="server" SkinID="txtdate"
                                                    MaxLength="10">
                                                </asp:TextBox>
                                                <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtDateResolutionLetterTo_Cust.ClientID%>', 'mm/dd/y');"
                                                    alt="Date Resolution Letter Sent To" src="../../Images/iconPicDate.gif" align="middle" />
                                                <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="Date Resolution Letter Sent From Must Be Less Than Date Resolution Letter Sent To"
                                                    ControlToCompare="txtDateResolutionLetterFrom_Cust" Type="Date" ValidationGroup="vsCustomerGroup"
                                                    Operator="GreaterThanEqual" ControlToValidate="txtDateResolutionLetterTo_Cust"
                                                    Display="none">
                                                </asp:CompareValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtDateResolutionLetterTo_Cust"
                                                    ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                                    ErrorMessage="Date Resolution Letter Sent To Is Not Valid" Display="none" ValidationGroup="vsCustomerGroup">
                                                </asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Letter N/A?
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left" colspan="4">
                                                <asp:RadioButtonList ID="rdbLetterNA_Cust" runat="server" RepeatDirection="Horizontal"
                                                    SkinID="YNTypeNullSelection">
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" align="center">
                                                <asp:Button ID="btnSearch_cust" runat="server" Text="Search" CausesValidation="true"
                                                    OnClick="btnSearch_Cust_Click" ValidationGroup="vsCustomerGroup" />
                                                <%--&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false"
                                    OnClientClick="javascript:return onCancelSearch();" />--%>
                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnAdd_Cust" runat="server" Text="  Add  " OnClick="btnAdd_Cust_Click"
                                                    CausesValidation="false" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <div id="pnlnonCustomer" runat="server" onkeypress="return FireDefaultButton(event, 'ctl00_ContentPlaceHolder1_btnSearch_NonCust.ClientID')">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr id="trNonCustomer" style="display: none;">
                                <td width="15%">
                                    &nbsp;
                                </td>
                                <td align="left" colspan="2">
                                    <table cellpadding="3" cellspacing="1" width="90%" border="0">
                                        <tr>
                                            <td align="left" width="25%">
                                                Incident Type
                                            </td>
                                            <td width="2%" align="center">
                                                :
                                            </td>
                                            <td align="left" width="33%">
                                                Non-Customer
                                            </td>
                                            <td align="left" width="10%">
                                            </td>
                                            <td width="2%" align="center">
                                            </td>
                                            <td align="left" width="30%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Contact Number
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left" colspan="4">
                                                <asp:TextBox ID="txtContactNumber_NonCust" Width="190px" runat="server" SkinID="txtYearWithRange"
                                                    MaxLength="20"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Date of Contact From
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtContactDateFrom_NonCust" runat="server" Width="175px" SkinID="txtdate"
                                                    MaxLength="10">
                                                </asp:TextBox>
                                                <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtContactDateFrom_NonCust.ClientID%>', 'mm/dd/y');"
                                                    alt="Date of Contact From" src="../../Images/iconPicDate.gif" align="middle" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtContactDateFrom_NonCust"
                                                    ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                                    ErrorMessage="Date of Contact From Is Not Valid" Display="none" ValidationGroup="vsNonCustomerGroup">
                                                </asp:RegularExpressionValidator>
                                            </td>
                                            <td align="left">
                                                To
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtContactDateTo_NonCust" runat="server" SkinID="txtdate" MaxLength="10">
                                                </asp:TextBox>
                                                <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtContactDateTo_NonCust.ClientID%>', 'mm/dd/y');"
                                                    alt="Date of Contact To" src="../../Images/iconPicDate.gif" align="middle" />
                                                <asp:CompareValidator ID="CompareValidator4" runat="server" ErrorMessage="Date of Contact From  Must Be Less Than Date of Contact To"
                                                    ControlToCompare="txtContactDateFrom_NonCust" Type="Date" ValidationGroup="vsNonCustomerGroup"
                                                    Operator="GreaterThanEqual" ControlToValidate="txtContactDateTo_NonCust" Display="none">
                                                </asp:CompareValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtContactDateTo_NonCust"
                                                    ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                                    ErrorMessage="Date of Contact To Is Not Valid" Display="none" ValidationGroup="vsNonCustomerGroup">
                                                </asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Source
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left" colspan="4">
                                                <asp:DropDownList ID="drpSoruce_NonCust" runat="server" AutoPostBack="false" Width="200px"
                                                    SkinID="dropGen">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Company Name
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left" colspan="4">
                                                <asp:TextBox ID="txtCompany_name" runat="server" Width="190px" MaxLength="50"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Last Name
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left" colspan="4">
                                                <asp:TextBox ID="txtLastName_NonCust" Width="190px" runat="server" MaxLength="50"></asp:TextBox>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td align="left">
                                                First Name
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left" colspan="4">
                                                <asp:TextBox ID="txtFirstName_NonCust" Width="190px" runat="server" MaxLength="50"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Location D/B/A
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left" colspan="4">
                                                <asp:DropDownList ID="drpLocationDBA_NonCust" runat="server" AutoPostBack="false"
                                                    Width="200px" SkinID="dropGen">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Category
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left" colspan="4">
                                                <asp:DropDownList ID="drpCategory_NonCust" runat="server" AutoPostBack="false" Width="200px"
                                                    SkinID="dropGen">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Response Sent?
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left" colspan="4">
                                                <asp:RadioButtonList ID="rdbReponseSent_NonCust" runat="server" RepeatDirection="Horizontal"
                                                    SkinID="YNTypeNullSelection">
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Date of Response From
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtResponseDateFrom_NonCust" runat="server" Width="175px" SkinID="txtdate"
                                                    MaxLength="10">
                                                </asp:TextBox>
                                                <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtResponseDateFrom_NonCust.ClientID%>', 'mm/dd/y');"
                                                    alt="Date of Response From" src="../../Images/iconPicDate.gif" align="middle" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"
                                                    ControlToValidate="txtResponseDateFrom_NonCust" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                                    ErrorMessage="Date of Response From Is Not Valid" Display="none" ValidationGroup="vsNonCustomerGroup">
                                                </asp:RegularExpressionValidator>
                                            </td>
                                            <td align="left">
                                                To
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtResponseDateTo_NonCust" runat="server" SkinID="txtdate" MaxLength="10">
                                                </asp:TextBox>
                                                <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtResponseDateTo_NonCust.ClientID%>', 'mm/dd/y');"
                                                    alt="Date of Response To" src="../../Images/iconPicDate.gif" align="middle" />
                                                <asp:CompareValidator ID="CompareValidator6" runat="server" ErrorMessage="Date of Response From Must Be Less Than Date of Response To"
                                                    ControlToCompare="txtResponseDateFrom_NonCust" Type="Date" ValidationGroup="vsNonCustomerGroup"
                                                    Operator="GreaterThanEqual" ControlToValidate="txtResponseDateTo_NonCust" Display="none">
                                                </asp:CompareValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                                                    ControlToValidate="txtResponseDateTo_NonCust" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                                    ErrorMessage="Date of Response To Is Not Valid" Display="none" ValidationGroup="vsNonCustomerGroup">
                                                </asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Response N/A?
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left" colspan="4">
                                                <asp:RadioButtonList ID="rdbReponseNA_NonCust" runat="server" RepeatDirection="Horizontal"
                                                    SkinID="YNTypeNullSelection">
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" align="center">
                                                <asp:Button ID="btnSearch_NonCust" runat="server" Text="Search" CausesValidation="true"
                                                    OnClick="btnSearch_NonCust_Click" ValidationGroup="vsNonCustomerGroup" />
                                                <%--&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnCancel_NonCust" runat="server" Text="Cancel" CausesValidation="false"
                                    OnClientClick="javascript:return onCancelSearch();" />--%>
                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnAdd_NonCust" runat="server" Text="  Add  " OnClick="btnAdd_NonCust_Click"
                                                    CausesValidation="false" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="3" style="height: 20px;">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div style="width: 100%" id="dvSearchResult" runat="server" visible="false">
        <table cellpadding="1" cellspacing="1" width="100%" border="0">
            <tr>
                <td align="left">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="left">
                    <table cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td width="45%">
                                &nbsp;<span class="heading">CRM Search Results</span><br />
                                &nbsp;<asp:Label ID="lblNumber" runat="server" Text=""></asp:Label>&nbsp;Incidents
                                Found
                            </td>
                            <td valign="top" align="right">
                                <uc:ctrlPaging ID="ctrlPageIncident" runat="server" OnGetPage="GetPage" />
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="Spacer" style="height: 5px;">
                </td>
            </tr>
            <tr>
                <td class="dvContent" valign="top">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td align="left">
                                <asp:GridView ID="gvIncident" runat="server" Width="100%" OnRowCommand="gvIncident_RowCommand"
                                    OnRowDataBound="gvIncident_RowDataBound" AllowSorting="True" AutoGenerateColumns="False"
                                    OnRowCreated="gvIncident_RowCreated" OnSorting="gvIncident_Sorting">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Incident Type" SortExpression="Incident_Type">
                                            <ItemStyle Width="13%" HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <%#Eval("Incident_Type")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Complaint/Contact Number" SortExpression="PK_CRM_Customer">
                                            <ItemStyle Width="13%" HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <%#Eval("PK_CRM_Customer")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Location D/B/A" SortExpression="LocationDBA">
                                            <ItemStyle Width="13%" HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <%#Eval("LocationDBA")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date of Incident/Contact" SortExpression="Record_Date">
                                            <ItemStyle Width="13%" HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Record_Date"))%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date of Last Update" SortExpression="Update_Date">
                                            <ItemStyle Width="12%" HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Update_Date"))%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Last Name" SortExpression="Last_Name">
                                            <ItemStyle Width="13%" HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <%#Eval("Last_Name")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="First Name" SortExpression="First_Name">
                                            <ItemStyle Width="13%" HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <%#Eval("First_Name")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Disposition">
                                            <ItemStyle Width="10%" HorizontalAlign="Right" Wrap="false" />
                                            <ItemTemplate>
                                                <asp:Button ID="lnkView" runat="server" Text="View" Width="50px" CommandName="ViewIncident"
                                                    CommandArgument='<%#Eval("PK_CRM_Customer")%>'></asp:Button>&nbsp;&nbsp;<asp:Button
                                                        ID="lnkEdit" runat="server" Text="Edit" Width="50px" CommandName="EditIncident"
                                                        CommandArgument='<%#Eval("PK_CRM_Customer")%>'></asp:Button>&nbsp;&nbsp;<asp:Button
                                                            ID="lnkDelete" runat="server" Text="Delete" Width="70px" OnClientClick="javascript:return ConfirmRemove();"
                                                            CommandName="DeleteIncident" CommandArgument='<%#Eval("PK_CRM_Customer")%>'>
                                                </asp:Button>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <table width="100%">
                                            <tr>
                                                <td align="center">
                                                    <asp:Label ID="lblMsg" runat="server" SkinID="Message" Text="No records found."></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>
                                    <HeaderStyle VerticalAlign="Top" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td width="100%" class="Spacer" style="height: 10px;">
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnSearchAgain" runat="server" SkinID="Search" OnClick="btnSearchAgain_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnAddNew" runat="server" Text="  Add  " OnClick="btnAddNew_Click" />
                </td>
            </tr>
            <tr>
                <td width="100%" class="Spacer" style="height: 10px;">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
