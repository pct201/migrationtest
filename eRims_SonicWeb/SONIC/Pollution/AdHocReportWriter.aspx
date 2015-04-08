<%@ Page Title="EHS : Ad-Hoc Report Writer" Language="C#" MasterPageFile="~/Default.master"
    AutoEventWireup="true" CodeFile="AdHocReportWriter.aspx.cs" Inherits="Pollution_AdHocReportWriter" %>

<%@ Register Src="~/Controls/RelativeDate/RelativeDate.ascx" TagPrefix="uc" TagName="CtrlRelativeDates" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src='<%=AppConfig.SiteURL %>JavaScript/JFunctions.js'></script>
    <script type="text/javascript" language="javascript" src='<%=AppConfig.SiteURL %>JavaScript/Calendar_new.js'></script>
    <script type="text/javascript" language="javascript" src='<%=AppConfig.SiteURL %>JavaScript/calendar-en.js'></script>
    <script type="text/javascript" language="javascript" src='<%=AppConfig.SiteURL %>JavaScript/Calendar.js'></script>
    <link href="<%=AppConfig.SiteURL%>greybox/gb_styles.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        var GB_ROOT_DIR = '<%=AppConfig.SiteURL%>' + 'greybox/';

        function OPenSchedulePopup() {

            document.getElementById('<%=rfvEmpID.ClientID %>').enabled = false;

            if (Page_ClientValidate('vsErrorGroup'))
                GB_showCenter('Schedule Ad Hoc Report Writer', '<%=AppConfig.SiteURL%>SchedulerptAdHocWriter.aspx', 300, 500, '');
            else {
                Page_ClientValidate('dummy'); return false;
            }
        }
        function ConfirmDelete() {
            if (confirm("Are you sure that you want to delete the selected information and all of its subordinate data (if exists)?")) {
                SaveScrollPositions();
                return true;
            }
            else return false;
        }

        function FireAllValidation() {
            document.getElementById('<%=rfvEmpID.ClientID %>').enabled = false;
            if (Page_ClientValidate('vsErrorGroup'))
                return true;
            else {
                Page_ClientValidate('dummy'); return false;
            }
        }
        function FireAllValidation2() {
            document.getElementById('<%=rfvEmpID.ClientID %>').enabled = true;
            if (Page_ClientValidate('vsErrorGroup'))
                return true;
            else {
                Page_ClientValidate('dummy');
                return false;
            }
        }

        function formatCurrencyOnBlur(ctrl) {
            if (ctrl.value != '') {
                var val = ctrl.value.replace(",", "").replace(",", "");
                ctrl.value = formatCurrency(val).replace("$", "");
            }
        }

        function CheckListItemOutput() {
            var lstOutPut = document.getElementById('<%=lstOutputFields.ClientID %>');

            if (lstOutPut.length <= 0) {
                alert('No record!');
                return false;
            }

            if (lstOutPut.selectedIndex < 0) {
                alert('Select at least one Output Field');
                return false;
            }
        }
        function CheckListItemOutputAll() {
            var lstOutPut = document.getElementById('<%=lstOutputFields.ClientID %>');
            if (lstOutPut.length <= 0) {
                alert('No record!');
                return false;
            }
        }
        function CheckListItemSelected() {
            var lstSelected = document.getElementById('<%=lstSelectedFields.ClientID %>');
            if (lstSelected.length <= 0) {
                alert('No record!');
                return false;
            }
            if (lstSelected.selectedIndex < 0) {
                alert('Select at least one Output Field');
                return false;
            }
        }
        function CheckListItemSelectedAll() {
            var lstSelected = document.getElementById('<%=lstSelectedFields.ClientID %>');
            if (lstSelected.length <= 0)
            { alert('No record!'); return false; }
        }
        function CheckOutPutField(source, arguments) {
            var lstSelected = document.getElementById('<%=lstSelectedFields.ClientID %>');
            if (lstSelected.length <= 0) {
                arguments.IsValid = false;
                return arguments.IsValid;
            }
            else {
                arguments.IsValid = true;
                return arguments.IsValid;
            }
        }
        function CheckGroupBySortBy(source, arguments) {

            arguments.IsValid = CheckTwoDrp('<%=drpGroupByFirst.ClientID %>', '<%=drpSortingFirst.ClientID %>');
            if (arguments.IsValid) arguments.IsValid = CheckTwoDrp('<%=drpGroupByFirst.ClientID %>', '<%=drpSortingSecond.ClientID %>');
            if (arguments.IsValid) arguments.IsValid = CheckTwoDrp('<%=drpGroupByFirst.ClientID %>', '<%=drpSortingThird.ClientID %>');
            if (arguments.IsValid) arguments.IsValid = CheckTwoDrp('<%=drpGroupBySecond.ClientID %>', '<%=drpSortingFirst.ClientID %>');
            if (arguments.IsValid) arguments.IsValid = CheckTwoDrp('<%=drpGroupBySecond.ClientID %>', '<%=drpSortingSecond.ClientID %>');
            if (arguments.IsValid) arguments.IsValid = CheckTwoDrp('<%=drpGroupBySecond.ClientID %>', '<%=drpSortingThird.ClientID %>');

            return arguments.IsValid;
        }
        function CheckTwoDrp(drp1, drp2) {
            var drpFirst = document.getElementById(drp1);
            var drpSecond = document.getElementById(drp2);

            if (drpFirst.selectedIndex > 0 && drpSecond.selectedIndex > 0) {
                if (drpFirst.options[drpFirst.selectedIndex].value == drpSecond.options[drpSecond.selectedIndex].value)
                    return false;
                else return true;
            }
            else
                return true;
        }

        function SaveScrollPositions() {
            document.getElementById('__SCROLLPOSITIONX').value = (navigator.appName == 'Netscape') ? document.pageYOffset : document.body.scrollTop;
            document.getElementById('__SCROLLPOSITIONY').value = (navigator.appName == 'Netscape') ? document.pageXOffset : document.body.scrollLeft;
        }
        function CheckRecipientList() {
            var ddl = document.getElementById("<%= ddlRecipientList.ClientID %>");
            if (ddl.value == '0') {
                alert("Please Select Recipient List.");
                return false;
            }
            return FireAllValidation();
        }
    </script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/gb_scripts.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL %>JavaScript/Validator.js"
        language="javascript"></script>
    <asp:ValidationSummary ID="vsError" runat="server" ValidationGroup="vsErrorGroup"
        BorderColor="DimGray" BorderWidth="1" HeaderText="Verify the following fields:"
        ShowMessageBox="true" ShowSummary="false"></asp:ValidationSummary>
    <div>
        &nbsp;</div>
    <div class="bandHeaderRow">
        EHS : Ad Hoc Report Writer</div>
    <asp:Panel ID="pnl_Container" runat="server">
        <asp:UpdateProgress runat="server" ID="upProgress" DisplayAfter="100">
            <ProgressTemplate>
                <div class="UpdatePanelloading" id="divProgress" style="width: 100%;position:fixed">
                    <table id="ProgressTable" cellpadding="0" cellspacing="0" border="0" style="width: 100%;
                        height: 100%;">
                        <tr align="center" valign="middle">
                            <td class="LoadingText" align="center" valign="middle">
                                <img src="../../Images/indicator.gif" alt="Loading" />&nbsp;&nbsp;&nbsp;Please Wait..
                            </td>
                        </tr>
                    </table>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="upOutput" runat="server" RenderMode="Inline" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%" cellpadding="4" cellspacing="2">
                    <tr>
                        <td colspan="2">
                            <b>Output Fields : </b>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 8%">
                            &nbsp;
                        </td>
                        <td>
                            <table width="100%" cellpadding="2" cellspacing="2">
                                <tr valign="top">
                                    <td style="width: 16%">
                                        Select Output Fields
                                    </td>
                                    <td style="width: 2%;" align="center">
                                        :
                                    </td>
                                    <td style="width: 72%">
                                        <table width="100%">
                                            <tr>
                                                <td align="left" style="width: 250px">
                                                    <asp:ListBox ID="lstOutputFields" runat="server" Rows="10" SelectionMode="Multiple"
                                                        Width="250px"></asp:ListBox>
                                                </td>
                                                <td valign="middle" align="center" style="width: 125px">
                                                    <table width="100%">
                                                        <tr>
                                                            <td align="center">
                                                                <asp:Button ID="btnSelectFields" runat="server" Text=">" Width="50px" OnClick="btnSelectFields_Click"
                                                                    Enabled="false" OnClientClick="javascript:return CheckListItemOutput();" ValidationGroup="vsErrorAvailFieldss" />
                                                                <br />
                                                                <br />
                                                                <asp:Button ID="btnSelectAllFields" runat="server" Text=">>" Width="50px" Enabled="false"
                                                                    OnClick="btnSelectAllFields_Click" />
                                                                <%--OnClientClick="javascript:return CheckListItemOutputAll();"--%>
                                                                <br />
                                                                <br />
                                                                <asp:Button ID="btnDeselectFields" runat="server" Text="<" Width="50px" OnClick="btnDeselectFields_Click"
                                                                    Enabled="false" OnClientClick="javascript:return CheckListItemSelected();" ValidationGroup="vsErrorSelectFieldss" />
                                                                <br />
                                                                <br />
                                                                <asp:Button ID="btnDeselectAllFields" runat="server" Text="<<" Width="50px" OnClientClick="javascript:return CheckListItemSelectedAll();"
                                                                    Enabled="false" OnClick="btnDeselectAllFields_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td align="left">
                                                    <asp:ListBox ID="lstSelectedFields" runat="server" Rows="10" SelectionMode="Multiple"
                                                        Width="250px"></asp:ListBox>
                                                    <asp:ImageButton ID="imgUp" ImageUrl="~/Images/up-arrow.gif" runat="server" ImageAlign="top"
                                                        OnClientClick="javascript:return CheckListItemSelected();" OnClick="imgUp_Click" />
                                                    <%--OnClientClick="return MoveItemUp();"--%>
                                                    <asp:ImageButton ID="imgDown" ImageUrl="~/Images/down-arrow.gif" runat="server" ImageAlign="top"
                                                        OnClientClick="javascript:return CheckListItemSelected();" OnClick="imgDown_Click" />
                                                    <%--OnClientClick="return MoveItemDown();"--%>
                                                    <asp:CustomValidator ID="cstvlCompany" runat="server" ErrorMessage="Please Select at least one Output field"
                                                        Display="None" ValidationGroup="vsErrorGroup" ClientValidationFunction="CheckOutPutField"></asp:CustomValidator>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td style="width: 16%">
                                        First Level Group By
                                    </td>
                                    <td style="width: 2%;" align="center">
                                        :
                                    </td>
                                    <td width="32%">
                                        <asp:DropDownList ID="drpGroupByFirst" runat="server" EnableTheming="false" Width="250px">
                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left" valign="top">
                                        <asp:RadioButtonList ID="rdblGroupSortByFirst" runat="server" RepeatDirection="Horizontal"
                                            CellPadding="0" CellSpacing="0">
                                            <asp:ListItem Selected="True" Text="Ascending  " Value="ASC"></asp:ListItem>
                                            <asp:ListItem Text="Descending" Value="DESC"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Second Level Group By
                                    </td>
                                    <td align="center">
                                        :
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpGroupBySecond" runat="server" Width="250px" EnableTheming="false">
                                            <asp:ListItem Text="--Select--" Value="-1"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:CompareValidator ID="cmGroup" runat="server" ControlToValidate="drpGroupBySecond"
                                            ControlToCompare="drpGroupByFirst" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                            InitialValue="0" ErrorMessage="First Level and second Level group by must be different."
                                            Type="String" Display="None" Operator="NotEqual"></asp:CompareValidator>
                                    </td>
                                    <td valign="top">
                                        <asp:RadioButtonList ID="rdblGroupSortBySecond" runat="server" RepeatDirection="Horizontal"
                                            CellPadding="0" CellSpacing="0">
                                            <asp:ListItem Selected="True" Text="Ascending  " Value="ASC"></asp:ListItem>
                                            <asp:ListItem Text="Descending" Value="DESC"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <b>Sort By :</b>
                        </td>
                    </tr>
                    <tr align="left">
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <table width="100%" cellpadding="2" cellspacing="2">
                                <tr>
                                    <td style="width: 16%">
                                        First Level Sorting
                                    </td>
                                    <td style="width: 2%;" align="center">
                                        :
                                    </td>
                                    <td width="32%">
                                        <asp:DropDownList ID="drpSortingFirst" runat="server" EnableTheming="false" Width="250px">
                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left" valign="top" style="width: 50%">
                                        <asp:RadioButtonList ID="rdbSort1" runat="server" RepeatDirection="Horizontal" CellPadding="0"
                                            CellSpacing="0">
                                            <asp:ListItem Selected="True" Text="Ascending  " Value="ASC"></asp:ListItem>
                                            <asp:ListItem Text="Descending" Value="DESC"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Second Level Sorting
                                    </td>
                                    <td align="center">
                                        :
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpSortingSecond" runat="server" Width="250px" EnableTheming="false">
                                            <asp:ListItem Text="--Select--" Value="-1"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td valign="top">
                                        <asp:RadioButtonList ID="rdbSort2" runat="server" RepeatDirection="Horizontal" CellPadding="0"
                                            CellSpacing="0">
                                            <asp:ListItem Selected="True" Text="Ascending  " Value="ASC"></asp:ListItem>
                                            <asp:ListItem Text="Descending" Value="DESC"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Third Level Sorting
                                    </td>
                                    <td align="center">
                                        :
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpSortingThird" runat="server" Width="250px" EnableTheming="false">
                                            <asp:ListItem Text="--Select--" Value="-2"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:CompareValidator ID="cmGroup1" runat="server" ControlToValidate="drpSortingSecond"
                                            ControlToCompare="drpSortingFirst" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                            InitialValue="0" ErrorMessage="First and second Level Sorting must be different."
                                            Type="String" Display="None" Operator="NotEqual"></asp:CompareValidator>
                                        <asp:CompareValidator ID="cmGroup2" runat="server" ControlToValidate="drpSortingThird"
                                            ControlToCompare="drpSortingSecond" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                            InitialValue="0" ErrorMessage="Second and Third Level Sorting must be different."
                                            Type="String" Display="None" Operator="NotEqual"></asp:CompareValidator>
                                        <asp:CompareValidator ID="cmdGroup3" runat="server" ControlToValidate="drpSortingFirst"
                                            ControlToCompare="drpSortingThird" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                            InitialValue="0" ErrorMessage="First and Third Level Sorting must be different."
                                            Type="String" Display="None" Operator="NotEqual"></asp:CompareValidator>
                                        <asp:CustomValidator ID="csvGroupBySortBy" runat="server" ErrorMessage="Group By and Sort by selection must be different"
                                            Display="None" ValidationGroup="vsErrorGroup" ClientValidationFunction="CheckGroupBySortBy"></asp:CustomValidator>
                                    </td>
                                    <td valign="top">
                                        <asp:RadioButtonList ID="rdbSort3" runat="server" RepeatDirection="Horizontal" CellPadding="0"
                                            CellSpacing="0">
                                            <asp:ListItem Selected="True" Text="Ascending  " Value="ASC"></asp:ListItem>
                                            <asp:ListItem Text="Descending" Value="DESC"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSelectFields" EventName="Click"></asp:AsyncPostBackTrigger>
                <asp:AsyncPostBackTrigger ControlID="btnSelectAllFields" EventName="click"></asp:AsyncPostBackTrigger>
                <asp:AsyncPostBackTrigger ControlID="btnDeselectAllFields"></asp:AsyncPostBackTrigger>
                <asp:AsyncPostBackTrigger ControlID="btnDeselectFields" EventName="Click"></asp:AsyncPostBackTrigger>
                <asp:AsyncPostBackTrigger ControlID="imgDown" EventName="Click"></asp:AsyncPostBackTrigger>
                <asp:AsyncPostBackTrigger ControlID="imgUp" EventName="Click"></asp:AsyncPostBackTrigger>
            </Triggers>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="upFilter" runat="server" RenderMode="Inline" UpdateMode="Always">
            <ContentTemplate>
                <table width="100%" cellpadding="4" cellspacing="2">
                    <tr>
                        <td colspan="2" class="bandHeaderRow">
                            Filter Criteria
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="Spacer" style="height: 5px;">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" width="8%">
                            &nbsp;<b>Filter 1 :</b>
                        </td>
                        <td>
                            <table cellpadding="2" cellspacing="1" width="100%" align="center">
                                <tr>
                                    <td style="width: 25%;" valign="top">
                                        <asp:DropDownList ID="drpFilter1" runat="server" EnableTheming="false" AutoPostBack="True"
                                            Width="230px" OnSelectedIndexChanged="drpFilter_SelectedIndexChanged" onchange="Page_ClientValidate('dummy')">
                                        </asp:DropDownList>
                                    </td>
                                    <td width="75%" valign="top">
                                        <asp:Panel ID="pnlDate_F1" runat="server">
                                            <table width="100%" cellpadding="2">
                                                <tr>
                                                    <td valign="top">
                                                        <asp:DropDownList Width="106px" ID="lstDate1" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="rdbLstDate_SelectedIndexChanged">
                                                            <asp:ListItem Text="On" Value="O" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                            <asp:ListItem Text="Before" Value="BF"></asp:ListItem>
                                                            <asp:ListItem Text="After" Value="A"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="11%" valign="top">
                                                        <asp:Label ID="lblDateFrom1" runat="server" Text="On Date : "></asp:Label>
                                                    </td>
                                                    <td width="30%" valign="top">
                                                        <asp:TextBox ID="txtDate_From1" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                                        <img alt="" id="imgDate_Opened_From1" onclick="return showCalendar('<%=txtDate_From1.ClientID%>', 'mm/dd/y','','');"
                                                            runat="server" onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL %>/iconPicDate.gif'
                                                            align="middle" />
                                                        <asp:RegularExpressionValidator ID="revtxtDate_From1" runat="server" ValidationGroup="vsErrorGroup"
                                                            Display="none" ErrorMessage="Filter Criteria  1 - On Date is not a valid date"
                                                            SetFocusOnError="true" ControlToValidate="txtDate_From1" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        <uc:CtrlRelativeDates ID="ucRelativeDatesFrom_1" runat="server" strDateClientID="ctl00_ContentPlaceHolder1_txtDate_From1"
                                                            OnSetDate="RaltiveDatesSaveClick" />
                                                    </td>
                                                    <td style="width: 11%;" valign="top">
                                                        <asp:Label ID="lblDateTo1" runat="server" Text="Start Date :"></asp:Label>
                                                    </td>
                                                    <td style="width: 30%;" valign="top">
                                                        <asp:TextBox ID="txtDate_To1" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                                        <img alt="" id="imgDate_To1" runat="server" onclick="return showCalendar('<%=txtDate_To1.ClientID%>', 'mm/dd/y','','');"
                                                            onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL %>/iconPicDate.gif'
                                                            align="middle" />
                                                        <asp:RegularExpressionValidator ID="revtxtDate_To1" runat="server" ValidationGroup="vsErrorGroup"
                                                            Display="none" ErrorMessage="Filter Criteria  1 - End Date is not a valid date"
                                                            SetFocusOnError="true" ControlToValidate="txtDate_To1" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        <asp:CompareValidator ID="CompareValidatorDate_To1" runat="server" ControlToCompare="txtDate_From1"
                                                            ControlToValidate="txtDate_To1" Type="Date" Operator="GreaterThanEqual" Display="None"
                                                            SetFocusOnError="true" ErrorMessage="Filter Criteria  1 - End Date should be greater than or equal to Start Date"
                                                            ValidationGroup="vsErrorGroup" />
                                                        <uc:CtrlRelativeDates ID="ucRelativeDatesTo_1" runat="server" strDateClientID="ctl00_ContentPlaceHolder1_txtDate_To1"
                                                            Visible="false" OnSetDate="RaltiveDatesSaveClick" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:ListBox ID="lst_F1" runat="server" Rows="5" Width="400px" SelectionMode="Multiple">
                                        </asp:ListBox>
                                        <asp:Panel ID="pnlAmount_F1" runat="server">
                                            <table cellpadding="1">
                                                <tr>
                                                    <td width="45%">
                                                        <asp:DropDownList ID="drpAmount_F1" Width="106px" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="drpAmount_F_SelectedIndexChanged">
                                                            <asp:ListItem Text="Equal" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Greater Than" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Less Than" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td nowrap="nowrap" valign="top">
                                                        <asp:Label ID="lblAmountText1_F1" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtAmount1_F1" runat="server" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this);" MaxLength="15"></asp:TextBox>
                                                        <asp:Label ID="lblAmountText2_F1" Visible="false" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtAmount2_F1" runat="server" Visible="false" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this);" MaxLength="15"></asp:TextBox>
                                                        <asp:CompareValidator ID="cvAmount1" runat="server" ErrorMessage="Filter Criteria  1 - To Amount must be Greater Than or Equal To From Amount"
                                                            ControlToCompare="txtAmount1_F1" ControlToValidate="txtAmount2_F1" Operator="GreaterThanEqual"
                                                            Type="Currency" Display="None" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlText_F1" runat="server">
                                            <table cellpadding="1">
                                                <tr>
                                                    <td width="35%">
                                                        <asp:DropDownList ID="drpText_F1" Width="106px" runat="server">
                                                            <asp:ListItem Text="Contains" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Start With" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="End With" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFilter1" runat="server" Width="216px" MaxLength="50"></asp:TextBox>
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
                        <td valign="top">
                            &nbsp;<b>Filter 2 :</b>
                        </td>
                        <td>
                            <table cellpadding="2" cellspacing="1" width="100%" align="center">
                                <tr>
                                    <td style="width: 25%;" valign="top">
                                        <asp:DropDownList ID="drpFilter2" runat="server" AutoPostBack="True" Width="230px"
                                            EnableTheming="false" OnSelectedIndexChanged="drpFilter_SelectedIndexChanged"
                                            onchange="Page_ClientValidate('dummy')">
                                        </asp:DropDownList>
                                    </td>
                                    <td width="75%">
                                        <asp:Panel ID="pnlDate_F2" runat="server">
                                            <table width="100%" cellpadding="2">
                                                <tr>
                                                    <td valign="top">
                                                        <asp:DropDownList ID="lstDate2" Width="106px" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="rdbLstDate_SelectedIndexChanged">
                                                            <asp:ListItem Text="On" Value="O" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                            <asp:ListItem Text="Before" Value="BF"></asp:ListItem>
                                                            <asp:ListItem Text="After" Value="A"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="11%" valign="top">
                                                        <asp:Label ID="lblDateFrom2" runat="server" Text="On Date : "></asp:Label>
                                                    </td>
                                                    <td width="30%" valign="top">
                                                        <asp:TextBox ID="txtDate_From2" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                                        <img alt="" id="imgDate_Opened_From2" onclick="return showCalendar('<%=txtDate_From2.ClientID%>', 'mm/dd/y','','');"
                                                            runat="server" onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL %>/iconPicDate.gif'
                                                            align="middle" />
                                                        <asp:RegularExpressionValidator ID="revtxtDate_From2" runat="server" ValidationGroup="vsErrorGroup"
                                                            Display="none" ErrorMessage="Filter Criteria  2 - On Date is not a valid date"
                                                            SetFocusOnError="true" ControlToValidate="txtDate_From2" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        <uc:CtrlRelativeDates ID="ucRelativeDatesFrom_2" runat="server" strDateClientID="ctl00_ContentPlaceHolder1_txtDate_From2"
                                                            OnSetDate="RaltiveDatesSaveClick" />
                                                    </td>
                                                    <td style="width: 11%;" valign="top">
                                                        <asp:Label ID="lblDateTo2" runat="server" Text="Start Date :"></asp:Label>
                                                    </td>
                                                    <td style="width: 30%;" valign="top">
                                                        <asp:TextBox ID="txtDateTo2" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                                        <img alt="" id="imgDate_To2" runat="server" onclick="return showCalendar('<%=txtDateTo2.ClientID%>', 'mm/dd/y','','');"
                                                            onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL %>/iconPicDate.gif'
                                                            align="middle" />
                                                        <asp:RegularExpressionValidator ID="revtxtDate_To2" runat="server" ValidationGroup="vsErrorGroup"
                                                            Display="none" ErrorMessage="Filter Criteria  2 - End Date is not a valid date"
                                                            SetFocusOnError="true" ControlToValidate="txtDateTo2" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        <asp:CompareValidator ID="CompareValidatorDate_To" runat="server" ControlToCompare="txtDate_From2"
                                                            ControlToValidate="txtDateTo2" Type="Date" Operator="GreaterThanEqual" Display="None"
                                                            SetFocusOnError="true" ErrorMessage="Filter 2 - End Date should be greater than or equal to Start Date"
                                                            ValidationGroup="vsErrorGroup" />
                                                        <uc:CtrlRelativeDates ID="ucRelativeDatesTo_2" runat="server" strDateClientID="ctl00_ContentPlaceHolder1_txtDateTo2"
                                                            Visible="false" OnSetDate="RaltiveDatesSaveClick" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:ListBox ID="lst_F2" runat="server" Rows="5" Width="400px" SelectionMode="Multiple">
                                        </asp:ListBox>
                                        <asp:Panel ID="pnlAmount_F2" runat="server">
                                            <table cellpadding="1">
                                                <tr>
                                                    <td width="45%">
                                                        <asp:DropDownList ID="drpAmount_F2" Width="106px" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="drpAmount_F_SelectedIndexChanged">
                                                            <asp:ListItem Text="Equal" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Greater Than" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Less Than" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td nowrap="nowrap" valign="top">
                                                        <asp:Label ID="lblAmountText1_F2" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtAmount1_F2" runat="server" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this);" MaxLength="15"></asp:TextBox>
                                                        <asp:Label ID="lblAmountText2_F2" Visible="false" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtAmount2_F2" runat="server" Visible="false" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this);" MaxLength="15"></asp:TextBox>
                                                        <asp:CompareValidator ID="cvAmount2" runat="server" ErrorMessage="Filter Criteria  2 - To Amount must be Greater Than or Equal To From Amount"
                                                            ControlToCompare="txtAmount1_F2" ControlToValidate="txtAmount2_F2" Operator="GreaterThanEqual"
                                                            Type="Currency" Display="None" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlText_F2" runat="server">
                                            <table cellpadding="1">
                                                <tr>
                                                    <td width="35%">
                                                        <asp:DropDownList ID="drpText_F2" Width="106px" runat="server">
                                                            <asp:ListItem Text="Contains" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Start With" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="End With" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFilter2" runat="server" Width="216px" MaxLength="50"></asp:TextBox>
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
                        <td valign="top">
                            &nbsp;<b>Filter 3 :</b>
                        </td>
                        <td>
                            <table cellpadding="2" cellspacing="1" width="100%" align="center">
                                <tr>
                                    <td style="width: 25%;" valign="top">
                                        <asp:DropDownList ID="drpFilter3" runat="server" AutoPostBack="True" Width="230px"
                                            EnableTheming="false" OnSelectedIndexChanged="drpFilter_SelectedIndexChanged"
                                            onchange="Page_ClientValidate('dummy')">
                                        </asp:DropDownList>
                                    </td>
                                    <td width="75%">
                                        <asp:Panel ID="pnlDate_F3" runat="server">
                                            <table width="100%" cellpadding="2">
                                                <tr>
                                                    <td valign="top">
                                                        <asp:DropDownList ID="lstDate3" Width="106px" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="rdbLstDate_SelectedIndexChanged">
                                                            <asp:ListItem Text="On" Value="O" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                            <asp:ListItem Text="Before" Value="BF"></asp:ListItem>
                                                            <asp:ListItem Text="After" Value="A"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="11%" valign="top">
                                                        <asp:Label ID="lblDateFrom3" runat="server" Text="On Date : "></asp:Label>
                                                    </td>
                                                    <td width="30%" valign="top">
                                                        <asp:TextBox ID="txtDate_From3" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                                        <img alt="" id="imgDate_Opened_From3" onclick="return showCalendar('<%=txtDate_From3.ClientID%>', 'mm/dd/y','','');"
                                                            runat="server" onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL %>/iconPicDate.gif'
                                                            align="middle" />
                                                        <asp:RegularExpressionValidator ID="revtxtDate_From3" runat="server" ValidationGroup="vsErrorGroup"
                                                            Display="none" ErrorMessage="Filter Criteria  3 - On Date is not a valid date"
                                                            SetFocusOnError="true" ControlToValidate="txtDate_From3" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        <uc:CtrlRelativeDates ID="ucRelativeDatesFrom_3" runat="server" strDateClientID="ctl00_ContentPlaceHolder1_txtDate_From3"
                                                            OnSetDate="RaltiveDatesSaveClick" />
                                                    </td>
                                                    <td style="width: 11%;" valign="top">
                                                        <asp:Label ID="lblDateTo3" runat="server" Text="Start Date :"></asp:Label>
                                                    </td>
                                                    <td style="width: 30%;" valign="top">
                                                        <asp:TextBox ID="txtDate_To3" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                                        <img alt="" id="imgDate_To3" runat="server" onclick="return showCalendar('<%=txtDate_To3.ClientID%>', 'mm/dd/y','','');"
                                                            onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL %>/iconPicDate.gif'
                                                            align="middle" />
                                                        <asp:RegularExpressionValidator ID="revtxtDate_To3" runat="server" ValidationGroup="vsErrorGroup"
                                                            Display="none" ErrorMessage="Filter Criteria  3 - End Date is not a valid date"
                                                            SetFocusOnError="true" ControlToValidate="txtDate_To3" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToCompare="txtDate_From3"
                                                            ControlToValidate="txtDate_To3" Type="Date" Operator="GreaterThanEqual" Display="None"
                                                            SetFocusOnError="true" ErrorMessage="Filter Criteria  3 - End Date should be greater than or equal to Start Date"
                                                            ValidationGroup="vsErrorGroup" />
                                                        <uc:CtrlRelativeDates ID="ucRelativeDatesTo_3" runat="server" strDateClientID="ctl00_ContentPlaceHolder1_txtDate_To3"
                                                            Visible="false" OnSetDate="RaltiveDatesSaveClick" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:ListBox ID="lst_F3" runat="server" Rows="5" Width="400px" SelectionMode="Multiple">
                                        </asp:ListBox>
                                        <asp:Panel ID="pnlAmount_F3" runat="server">
                                            <table cellpadding="1">
                                                <tr>
                                                    <td width="45%">
                                                        <asp:DropDownList ID="drpAmount_F3" Width="106px" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="drpAmount_F_SelectedIndexChanged">
                                                            <asp:ListItem Text="Equal" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Greater Than" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Less Than" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td nowrap="nowrap" valign="top">
                                                        <asp:Label ID="lblAmountText1_F3" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtAmount1_F3" runat="server" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this);" MaxLength="15"></asp:TextBox>
                                                        <asp:Label ID="lblAmountText2_F3" Visible="false" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtAmount2_F3" runat="server" Visible="false" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this);" MaxLength="15"></asp:TextBox>
                                                        <asp:CompareValidator ID="cvAmount3" runat="server" ErrorMessage="Filter Criteria  3 - To Amount must be Greater Than or Equal To From Amount"
                                                            ControlToCompare="txtAmount1_F3" ControlToValidate="txtAmount2_F3" Operator="GreaterThanEqual"
                                                            Type="Currency" Display="None" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlText_F3" runat="server">
                                            <table cellpadding="1">
                                                <tr>
                                                    <td width="35%">
                                                        <asp:DropDownList ID="drpText_F3" Width="106px" runat="server">
                                                            <asp:ListItem Text="Contains" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Start With" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="End With" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFilter3" runat="server" Width="216px" MaxLength="50"></asp:TextBox>
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
                        <td valign="top">
                            &nbsp;<b>Filter 4 :</b>
                        </td>
                        <td>
                            <table cellpadding="2" cellspacing="1" width="100%" align="center">
                                <tr>
                                    <td style="width: 25%;" valign="top">
                                        <asp:DropDownList ID="drpFilter4" runat="server" AutoPostBack="True" Width="230px"
                                            EnableTheming="false" OnSelectedIndexChanged="drpFilter_SelectedIndexChanged"
                                            onchange="Page_ClientValidate('dummy')">
                                        </asp:DropDownList>
                                    </td>
                                    <td width="75%">
                                        <asp:Panel ID="pnlDate_F4" runat="server">
                                            <table cellpadding="2" width="100%">
                                                <tr>
                                                    <td valign="top">
                                                        <asp:DropDownList ID="lstDate4" Width="106px" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="rdbLstDate_SelectedIndexChanged">
                                                            <asp:ListItem Text="On" Value="O" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                            <asp:ListItem Text="Before" Value="BF"></asp:ListItem>
                                                            <asp:ListItem Text="After" Value="A"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="11%" valign="top">
                                                        <asp:Label ID="lblDateFrom4" runat="server" Text="On Date : "></asp:Label>
                                                    </td>
                                                    <td width="30%" valign="top">
                                                        <asp:TextBox ID="txtDate_From4" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                                        <img alt="" id="imgDate_Opened_From4" onclick="return showCalendar('<%=txtDate_From4.ClientID%>', 'mm/dd/y','','');"
                                                            runat="server" onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL %>/iconPicDate.gif'
                                                            align="middle" />
                                                        <asp:RegularExpressionValidator ID="revtxtDate_From4" runat="server" ValidationGroup="vsErrorGroup"
                                                            Display="none" ErrorMessage="Filter Criteria  4 - On Date is not a valid date"
                                                            SetFocusOnError="true" ControlToValidate="txtDate_From4" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        <uc:CtrlRelativeDates ID="ucRelativeDatesFrom_4" runat="server" strDateClientID="ctl00_ContentPlaceHolder1_txtDate_From4"
                                                            OnSetDate="RaltiveDatesSaveClick" />
                                                    </td>
                                                    <td style="width: 11%;" valign="top">
                                                        <asp:Label ID="lblDateTo4" runat="server" Text="Start Date :"></asp:Label>
                                                    </td>
                                                    <td style="width: 30%;" valign="top">
                                                        <asp:TextBox ID="txtDate_To4" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                                        <img alt="" id="imgDate_To4" runat="server" onclick="return showCalendar('<%=txtDate_To4.ClientID%>', 'mm/dd/y','','');"
                                                            onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL %>/iconPicDate.gif'
                                                            align="middle" />
                                                        <asp:RegularExpressionValidator ID="revtxtDate_To4" runat="server" ValidationGroup="vsErrorGroup"
                                                            Display="none" ErrorMessage="Filter Criteria  4 - End Date is not a valid date"
                                                            SetFocusOnError="true" ControlToValidate="txtDate_To4" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToCompare="txtDate_From4"
                                                            ControlToValidate="txtDate_To4" Type="Date" Operator="GreaterThanEqual" Display="None"
                                                            SetFocusOnError="true" ErrorMessage="Filter Criteria  4 - End Date should be greater than or equal to Start Date"
                                                            ValidationGroup="vsErrorGroup" />
                                                        <uc:CtrlRelativeDates ID="ucRelativeDatesTo_4" runat="server" strDateClientID="ctl00_ContentPlaceHolder1_txtDate_To4"
                                                            Visible="false" OnSetDate="RaltiveDatesSaveClick" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:ListBox ID="lst_F4" runat="server" Rows="5" Width="400px" SelectionMode="Multiple">
                                        </asp:ListBox>
                                        <asp:Panel ID="pnlAmount_F4" runat="server">
                                            <table cellpadding="1">
                                                <tr>
                                                    <td width="45%">
                                                        <asp:DropDownList ID="drpAmount_F4" Width="106px" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="drpAmount_F_SelectedIndexChanged">
                                                            <asp:ListItem Text="Equal" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Greater Than" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Less Than" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td nowrap="nowrap" valign="top">
                                                        <asp:Label ID="lblAmountText1_F4" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtAmount1_F4" runat="server" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this);" MaxLength="15"></asp:TextBox>
                                                        <asp:Label ID="lblAmountText2_F4" Visible="false" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtAmount2_F4" runat="server" Visible="false" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this);" MaxLength="15"></asp:TextBox>
                                                        <asp:CompareValidator ID="cvAmount4" runat="server" ErrorMessage="Filter Criteria  4 - To Amount must be Greater Than or Equal To From Amount"
                                                            ControlToCompare="txtAmount1_F4" ControlToValidate="txtAmount2_F4" Operator="GreaterThanEqual"
                                                            Type="Currency" Display="None" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlText_F4" runat="server">
                                            <table cellpadding="5">
                                                <tr>
                                                    <td width="35%">
                                                        <asp:DropDownList ID="drpText_F4" Width="106px" runat="server">
                                                            <asp:ListItem Text="Contains" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Start With" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="End With" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFilter4" runat="server" Width="216px" MaxLength="50"></asp:TextBox>
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
                        <td valign="top">
                            &nbsp;<b>Filter 5 :</b>
                        </td>
                        <td>
                            <table cellpadding="2" cellspacing="1" width="100%" align="center">
                                <tr>
                                    <td style="width: 25%;" valign="top">
                                        <asp:DropDownList ID="drpFilter5" runat="server" AutoPostBack="True" Width="230px"
                                            EnableTheming="false" OnSelectedIndexChanged="drpFilter_SelectedIndexChanged"
                                            onchange="Page_ClientValidate('dummy')">
                                        </asp:DropDownList>
                                    </td>
                                    <td width="75%">
                                        <asp:Panel ID="pnlDate_F5" runat="server">
                                            <table width="100%" cellpadding="2">
                                                <tr>
                                                    <td valign="top">
                                                        <asp:DropDownList ID="lstDate5" Width="106px" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="rdbLstDate_SelectedIndexChanged">
                                                            <asp:ListItem Text="On" Value="O" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                            <asp:ListItem Text="Before" Value="BF"></asp:ListItem>
                                                            <asp:ListItem Text="After" Value="A"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="11%" valign="top">
                                                        <asp:Label ID="lblDateFrom5" runat="server" Text="On Date : "></asp:Label>
                                                    </td>
                                                    <td width="30%" valign="top">
                                                        <asp:TextBox ID="txtDate_From5" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                                        <img alt="" id="imgDate_Opened_From5" onclick="return showCalendar('<%=txtDate_From5.ClientID%>', 'mm/dd/y','','');"
                                                            runat="server" onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL %>/iconPicDate.gif'
                                                            align="middle" />
                                                        <asp:RegularExpressionValidator ID="revtxtDate_From5" runat="server" ValidationGroup="vsErrorGroup"
                                                            Display="none" ErrorMessage="Filter Criteria  5 - On Date is not a valid date"
                                                            SetFocusOnError="true" ControlToValidate="txtDate_From5" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        <uc:CtrlRelativeDates ID="ucRelativeDatesFrom_5" runat="server" strDateClientID="ctl00_ContentPlaceHolder1_txtDate_From5"
                                                            OnSetDate="RaltiveDatesSaveClick" />
                                                    </td>
                                                    <td style="width: 11%;" valign="top">
                                                        <asp:Label ID="lblDateTo5" runat="server" Text="Start Date :"></asp:Label>
                                                    </td>
                                                    <td style="width: 30%;" valign="top">
                                                        <asp:TextBox ID="txtDate_To5" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                                        <img alt="" id="imgDate_To5" runat="server" onclick="return showCalendar('<%=txtDate_To5.ClientID%>', 'mm/dd/y','','');"
                                                            onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL %>/iconPicDate.gif'
                                                            align="middle" />
                                                        <asp:RegularExpressionValidator ID="revtxtDate_To5" runat="server" ValidationGroup="vsErrorGroup"
                                                            Display="none" ErrorMessage="Filter Criteria  5 - End Date is not a valid date"
                                                            SetFocusOnError="true" ControlToValidate="txtDate_To5" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToCompare="txtDate_From5"
                                                            ControlToValidate="txtDate_To5" Type="Date" Operator="GreaterThanEqual" Display="None"
                                                            SetFocusOnError="true" ErrorMessage="Filter Criteria  5 - End Date should be greater than or equal to Start Date"
                                                            ValidationGroup="vsErrorGroup" />
                                                        <uc:CtrlRelativeDates ID="ucRelativeDatesTo_5" runat="server" strDateClientID="ctl00_ContentPlaceHolder1_txtDate_To5"
                                                            Visible="false" OnSetDate="RaltiveDatesSaveClick" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:ListBox ID="lst_F5" runat="server" Rows="5" Width="400px" SelectionMode="Multiple">
                                        </asp:ListBox>
                                        <asp:Panel ID="pnlAmount_F5" runat="server">
                                            <table cellpadding="1">
                                                <tr>
                                                    <td width="45%">
                                                        <asp:DropDownList ID="drpAmount_F5" Width="106px" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="drpAmount_F_SelectedIndexChanged">
                                                            <asp:ListItem Text="Equal" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Greater Than" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Less Than" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td nowrap="nowrap" valign="top">
                                                        <asp:Label ID="lblAmountText1_F5" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtAmount1_F5" runat="server" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this);" MaxLength="15"></asp:TextBox>
                                                        <asp:Label ID="lblAmountText2_F5" Visible="false" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtAmount2_F5" runat="server" Visible="false" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this);" MaxLength="15"></asp:TextBox>
                                                        <asp:CompareValidator ID="cvAmount5" runat="server" ErrorMessage="Filter Criteria  5 - To Amount must be Greater Than or Equal To From Amount"
                                                            ControlToCompare="txtAmount1_F5" ControlToValidate="txtAmount2_F5" Operator="GreaterThanEqual"
                                                            Type="Currency" Display="None" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlText_F5" runat="server">
                                            <table cellpadding="1">
                                                <tr>
                                                    <td width="35%">
                                                        <asp:DropDownList ID="drpText_F5" Width="106px" runat="server">
                                                            <asp:ListItem Text="Contains" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Start With" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="End With" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFilter5" runat="server" Width="216px" MaxLength="50"></asp:TextBox>
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
                        <td valign="top">
                            &nbsp;<b>Filter 6 :</b>
                        </td>
                        <td>
                            <table cellpadding="2" cellspacing="1" width="100%" align="center">
                                <tr>
                                    <td style="width: 25%;" valign="top">
                                        <asp:DropDownList ID="drpFilter6" runat="server" AutoPostBack="True" Width="230px"
                                            EnableTheming="false" OnSelectedIndexChanged="drpFilter_SelectedIndexChanged"
                                            onchange="Page_ClientValidate('dummy')">
                                        </asp:DropDownList>
                                    </td>
                                    <td width="75%">
                                        <asp:Panel ID="pnlDate_F6" runat="server">
                                            <table width="100%" cellpadding="2">
                                                <tr>
                                                    <td valign="top">
                                                        <asp:DropDownList ID="lstDate6" Width="106px" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="rdbLstDate_SelectedIndexChanged">
                                                            <asp:ListItem Text="On" Value="O" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                            <asp:ListItem Text="Before" Value="BF"></asp:ListItem>
                                                            <asp:ListItem Text="After" Value="A"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="11%" valign="top">
                                                        <asp:Label ID="lblDateFrom6" runat="server" Text="On Date: "></asp:Label>
                                                    </td>
                                                    <td width="30%" valign="top">
                                                        <asp:TextBox ID="txtDate_From6" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                                        <img alt="" id="imgDate_Opened_From6" onclick="return showCalendar('<%=txtDate_From6.ClientID%>', 'mm/dd/y','','');"
                                                            runat="server" onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL%>/iconPicDate.gif'
                                                            align="middle" />
                                                        <asp:RegularExpressionValidator ID="revtxtDate_From6" runat="server" ValidationGroup="vsErrorGroup"
                                                            Display="none" ErrorMessage="Filter Criteria  6 - On Date is not a valid date"
                                                            SetFocusOnError="true" ControlToValidate="txtDate_From6" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        <uc:CtrlRelativeDates ID="ucRelativeDatesFrom_6" runat="server" strDateClientID="ctl00_ContentPlaceHolder1_txtDate_From6"
                                                            OnSetDate="RaltiveDatesSaveClick" />
                                                    </td>
                                                    <td style="width: 11%;" valign="top">
                                                        <asp:Label ID="lblDateTo6" runat="server" Text="Start Date :"></asp:Label>
                                                    </td>
                                                    <td style="width: 30%;" valign="top">
                                                        <asp:TextBox ID="txtDate_To6" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                                        <img alt="" id="imgDate_To6" runat="server" onclick="return showCalendar('<%=txtDate_To6.ClientID%>', 'mm/dd/y','','');"
                                                            onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL %>/iconPicDate.gif'
                                                            align="middle" />
                                                        <asp:RegularExpressionValidator ID="revtxtDate_To6" runat="server" ValidationGroup="vsErrorGroup"
                                                            Display="none" ErrorMessage="Filter Criteria  6 - End Date is not a valid date"
                                                            SetFocusOnError="true" ControlToValidate="txtDate_To6" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        <asp:CompareValidator ID="CompareValidator6" runat="server" ControlToCompare="txtDate_From6"
                                                            ControlToValidate="txtDate_To6" Type="Date" Operator="GreaterThanEqual" Display="None"
                                                            SetFocusOnError="true" ErrorMessage="Filter Criteria  6 - End Date should be greater than or equal to Start Date"
                                                            ValidationGroup="vsErrorGroup" />
                                                        <uc:CtrlRelativeDates ID="ucRelativeDatesTo_6" runat="server" strDateClientID="ctl00_ContentPlaceHolder1_txtDate_To6"
                                                            Visible="false" OnSetDate="RaltiveDatesSaveClick" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:ListBox ID="lst_F6" runat="server" Rows="5" Width="400px" SelectionMode="Multiple">
                                        </asp:ListBox>
                                        <asp:Panel ID="pnlAmount_F6" runat="server">
                                            <table cellpadding="1">
                                                <tr>
                                                    <td width="45%">
                                                        <asp:DropDownList ID="drpAmount_F6" Width="106px" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="drpAmount_F_SelectedIndexChanged">
                                                            <asp:ListItem Text="Equal" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Greater Than" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Less Than" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td nowrap="nowrap" valign="top">
                                                        <asp:Label ID="lblAmountText1_F6" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtAmount1_F6" runat="server" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this);" MaxLength="15"></asp:TextBox>
                                                        <asp:Label ID="lblAmountText2_F6" Visible="false" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtAmount2_F6" runat="server" Visible="false" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this);" MaxLength="15"></asp:TextBox>
                                                        <asp:CompareValidator ID="cvAmount6" runat="server" ErrorMessage="Filter Criteria  6 - To Amount must be Greater Than or Equal To From Amount"
                                                            ControlToCompare="txtAmount1_F6" ControlToValidate="txtAmount2_F6" Operator="GreaterThanEqual"
                                                            Type="Currency" Display="None" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlText_F6" runat="server">
                                            <table cellpadding="1">
                                                <tr>
                                                    <td width="35%">
                                                        <asp:DropDownList ID="drpText_F6" Width="106px" runat="server">
                                                            <asp:ListItem Text="Contains" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Start With" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="End With" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFilter6" runat="server" Width="216px" MaxLength="50"></asp:TextBox>
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
                        <td valign="top">
                            &nbsp;<b>Filter 7 :</b>
                        </td>
                        <td>
                            <table cellpadding="2" cellspacing="1" width="100%" align="center">
                                <tr>
                                    <td style="width: 25%;" valign="top">
                                        <asp:DropDownList ID="drpFilter7" runat="server" AutoPostBack="True" Width="230px"
                                            EnableTheming="false" OnSelectedIndexChanged="drpFilter_SelectedIndexChanged"
                                            onchange="Page_ClientValidate('dummy')">
                                        </asp:DropDownList>
                                    </td>
                                    <td width="75%">
                                        <asp:Panel ID="pnlDate_F7" runat="server">
                                            <table cellpadding="2" width="100%">
                                                <tr>
                                                    <td valign="top">
                                                        <asp:DropDownList ID="lstDate7" Width="106px" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="rdbLstDate_SelectedIndexChanged">
                                                            <asp:ListItem Text="On" Value="O" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                            <asp:ListItem Text="Before" Value="BF"></asp:ListItem>
                                                            <asp:ListItem Text="After" Value="A"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="11%" valign="top">
                                                        <asp:Label ID="lblDateFrom7" runat="server" Text="On Date : "></asp:Label>
                                                    </td>
                                                    <td width="30%" valign="top">
                                                        <asp:TextBox ID="txtDate_From7" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                                        <img alt="" id="imgDate_Opened_From7" onclick="return showCalendar('<%=txtDate_From7.ClientID%>', 'mm/dd/y','','');"
                                                            runat="server" onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL%>/iconPicDate.gif'
                                                            align="middle" />
                                                        <asp:RegularExpressionValidator ID="revtxtDate_From7" runat="server" ValidationGroup="vsErrorGroup"
                                                            Display="none" ErrorMessage="Filter Criteria  7 - On Date is not a valid date"
                                                            SetFocusOnError="true" ControlToValidate="txtDate_From7" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        <uc:CtrlRelativeDates ID="ucRelativeDatesFrom_7" runat="server" strDateClientID="ctl00_ContentPlaceHolder1_txtDate_From7"
                                                            OnSetDate="RaltiveDatesSaveClick" />
                                                    </td>
                                                    <td style="width: 11%;" valign="top">
                                                        <asp:Label ID="lblDateTo7" runat="server" Text="Start Date :"></asp:Label>
                                                    </td>
                                                    <td style="width: 30%;" valign="top">
                                                        <asp:TextBox ID="txtDate_To7" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                                        <img alt="" id="imgDate_To7" runat="server" onclick="return showCalendar('<%=txtDate_To7.ClientID%>', 'mm/dd/y','','');"
                                                            onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL %>/iconPicDate.gif'
                                                            align="middle" />
                                                        <asp:RegularExpressionValidator ID="revtxtDate_To7" runat="server" ValidationGroup="vsErrorGroup"
                                                            Display="none" ErrorMessage="Filter Criteria  7 - End Date is not a valid date"
                                                            SetFocusOnError="true" ControlToValidate="txtDate_To7" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        <asp:CompareValidator ID="CompareValidator7" runat="server" ControlToCompare="txtDate_From7"
                                                            ControlToValidate="txtDate_To7" Type="Date" Operator="GreaterThanEqual" Display="None"
                                                            SetFocusOnError="true" ErrorMessage="Filter Criteria  7 - End Date should be greater than or equal to Start Date"
                                                            ValidationGroup="vsErrorGroup" />
                                                        <uc:CtrlRelativeDates ID="ucRelativeDatesTo_7" runat="server" strDateClientID="ctl00_ContentPlaceHolder1_txtDate_To7"
                                                            Visible="false" OnSetDate="RaltiveDatesSaveClick" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:ListBox ID="lst_F7" runat="server" Rows="5" Width="400px" SelectionMode="Multiple">
                                        </asp:ListBox>
                                        <asp:Panel ID="pnlAmount_F7" runat="server">
                                            <table cellpadding="1">
                                                <tr>
                                                    <td width="45%">
                                                        <asp:DropDownList ID="drpAmount_F7" Width="106px" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="drpAmount_F_SelectedIndexChanged">
                                                            <asp:ListItem Text="Equal" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Greater Than" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Less Than" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td nowrap="nowrap" valign="top">
                                                        <asp:Label ID="lblAmountText1_F7" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtAmount1_F7" runat="server" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this);" MaxLength="15"></asp:TextBox>
                                                        <asp:Label ID="lblAmountText2_F7" Visible="false" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtAmount2_F7" runat="server" Visible="false" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this);" MaxLength="15"></asp:TextBox>
                                                        <asp:CompareValidator ID="cvAmount7" runat="server" ErrorMessage="Filter Criteria  7 - To Amount must be Greater Than or Equal To From Amount"
                                                            ControlToCompare="txtAmount1_F7" ControlToValidate="txtAmount2_F7" Operator="GreaterThanEqual"
                                                            Type="Currency" Display="None" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlText_F7" runat="server">
                                            <table cellpadding="1">
                                                <tr>
                                                    <td width="35%">
                                                        <asp:DropDownList ID="drpText_F7" Width="106px" runat="server">
                                                            <asp:ListItem Text="Contains" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Start With" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="End With" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFilter7" runat="server" Width="216px" MaxLength="50"></asp:TextBox>
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
                        <td valign="top">
                            &nbsp;<b>Filter 8 :</b>
                        </td>
                        <td>
                            <table cellpadding="2" cellspacing="1" width="100%" align="center">
                                <tr>
                                    <td style="width: 25%;" valign="top">
                                        <asp:DropDownList ID="drpFilter8" runat="server" AutoPostBack="True" Width="230px"
                                            EnableTheming="false" OnSelectedIndexChanged="drpFilter_SelectedIndexChanged"
                                            onchange="Page_ClientValidate('dummy')">
                                        </asp:DropDownList>
                                    </td>
                                    <td width="75%">
                                        <asp:Panel ID="pnlDate_F8" runat="server">
                                            <table cellpadding="2" width="100%">
                                                <tr>
                                                    <td valign="top">
                                                        <asp:DropDownList ID="lstDate8" Width="106px" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="rdbLstDate_SelectedIndexChanged">
                                                            <asp:ListItem Text="On" Value="O" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                            <asp:ListItem Text="Before" Value="BF"></asp:ListItem>
                                                            <asp:ListItem Text="After" Value="A"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="11%" valign="top">
                                                        <asp:Label ID="lblDateFrom8" runat="server" Text="On Date : "></asp:Label>
                                                    </td>
                                                    <td width="30%" valign="top">
                                                        <asp:TextBox ID="txtDate_From8" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                                        <img alt="" id="imgDate_Opened_From8" onclick="return showCalendar('<%=txtDate_From8.ClientID%>', 'mm/dd/y','','');"
                                                            runat="server" onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL%>/iconPicDate.gif'
                                                            align="middle" />
                                                        <asp:RegularExpressionValidator ID="revtxtDate_From8" runat="server" ValidationGroup="vsErrorGroup"
                                                            Display="none" ErrorMessage="Filter Criteria  8 - On Date is not a valid date"
                                                            SetFocusOnError="true" ControlToValidate="txtDate_From8" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        <uc:CtrlRelativeDates ID="ucRelativeDatesFrom_8" runat="server" strDateClientID="ctl00_ContentPlaceHolder1_txtDate_From8"
                                                            OnSetDate="RaltiveDatesSaveClick" />
                                                    </td>
                                                    <td style="width: 11%;" valign="top">
                                                        <asp:Label ID="lblDateTo8" runat="server" Text="Start Date :"></asp:Label>
                                                    </td>
                                                    <td style="width: 30%;" valign="top">
                                                        <asp:TextBox ID="txtDate_To8" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                                        <img alt="" id="imgDate_To8" runat="server" onclick="return showCalendar('<%=txtDate_To8.ClientID%>', 'mm/dd/y','','');"
                                                            onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL %>/iconPicDate.gif'
                                                            align="middle" />
                                                        <asp:RegularExpressionValidator ID="revtxtDate_To8" runat="server" ValidationGroup="vsErrorGroup"
                                                            Display="none" ErrorMessage="Filter Criteria  8 - End Date is not a valid date"
                                                            SetFocusOnError="true" ControlToValidate="txtDate_To8" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        <asp:CompareValidator ID="CompareValidator8" runat="server" ControlToCompare="txtDate_From8"
                                                            ControlToValidate="txtDate_To8" Type="Date" Operator="GreaterThanEqual" Display="None"
                                                            SetFocusOnError="true" ErrorMessage="Filter Criteria  8 - End Date should be greater than or equal to Start Date"
                                                            ValidationGroup="vsErrorGroup" />
                                                        <uc:CtrlRelativeDates ID="ucRelativeDatesTo_8" runat="server" strDateClientID="ctl00_ContentPlaceHolder1_txtDate_To8"
                                                            Visible="false" OnSetDate="RaltiveDatesSaveClick" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:ListBox ID="lst_F8" runat="server" Rows="5" Width="400px" SelectionMode="Multiple">
                                        </asp:ListBox>
                                        <asp:Panel ID="pnlAmount_F8" runat="server">
                                            <table cellpadding="1">
                                                <tr>
                                                    <td width="45%">
                                                        <asp:DropDownList ID="drpAmount_F8" Width="106px" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="drpAmount_F_SelectedIndexChanged">
                                                            <asp:ListItem Text="Equal" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Greater Than" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Less Than" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td nowrap="nowrap" valign="top">
                                                        <asp:Label ID="lblAmountText1_F8" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtAmount1_F8" runat="server" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this);" MaxLength="15"></asp:TextBox>
                                                        <asp:Label ID="lblAmountText2_F8" Visible="false" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtAmount2_F8" runat="server" Visible="false" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this);" MaxLength="15"></asp:TextBox>
                                                        <asp:CompareValidator ID="cvAmount8" runat="server" ErrorMessage="Filter Criteria  8 - To Amount must be Greater Than or Equal To From Amount"
                                                            ControlToCompare="txtAmount1_F8" ControlToValidate="txtAmount2_F8" Operator="GreaterThanEqual"
                                                            Type="Currency" Display="None" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlText_F8" runat="server">
                                            <table cellpadding="1">
                                                <tr>
                                                    <td width="35%">
                                                        <asp:DropDownList ID="drpText_F8" Width="106px" runat="server">
                                                            <asp:ListItem Text="Contains" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Start With" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="End With" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFilter8" runat="server" Width="216px" MaxLength="50"></asp:TextBox>
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
                        <td valign="top">
                            &nbsp;<b>Filter 9 :</b>
                        </td>
                        <td>
                            <table cellpadding="2" cellspacing="1" width="100%" align="center">
                                <tr>
                                    <td style="width: 25%;" valign="top">
                                        <asp:DropDownList ID="drpFilter9" runat="server" AutoPostBack="True" Width="230px"
                                            EnableTheming="false" OnSelectedIndexChanged="drpFilter_SelectedIndexChanged"
                                            onchange="Page_ClientValidate('dummy')">
                                        </asp:DropDownList>
                                    </td>
                                    <td width="75%">
                                        <asp:Panel ID="pnlDate_F9" runat="server">
                                            <table cellpadding="2" width="100%">
                                                <tr>
                                                    <td valign="top">
                                                        <asp:DropDownList ID="lstDate9" Width="106px" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="rdbLstDate_SelectedIndexChanged">
                                                            <asp:ListItem Text="On" Value="O" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                            <asp:ListItem Text="Before" Value="BF"></asp:ListItem>
                                                            <asp:ListItem Text="After" Value="A"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="11%" valign="top">
                                                        <asp:Label ID="lblDateFrom9" runat="server" Text="On Date : "></asp:Label>
                                                    </td>
                                                    <td width="30%" valign="top">
                                                        <asp:TextBox ID="txtDate_From9" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                                        <img alt="" id="imgDate_Opened_From9" onclick="return showCalendar('<%=txtDate_From9.ClientID%>','mm/dd/y','','');"
                                                            runat="server" onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL %>/iconPicDate.gif'
                                                            align="middle" />
                                                        <asp:RegularExpressionValidator ID="revtxtDate_From9" runat="server" ValidationGroup="vsErrorGroup"
                                                            Display="none" ErrorMessage="Filter Criteria  9 - On Date is not a valid date"
                                                            SetFocusOnError="true" ControlToValidate="txtDate_From9" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        <uc:CtrlRelativeDates ID="ucRelativeDatesFrom_9" runat="server" strDateClientID="ctl00_ContentPlaceHolder1_txtDate_From9"
                                                            OnSetDate="RaltiveDatesSaveClick" />
                                                    </td>
                                                    <td style="width: 11%;" valign="top">
                                                        <asp:Label ID="lblDateTo9" runat="server" Text="Start Date :"></asp:Label>
                                                    </td>
                                                    <td style="width: 30%;" valign="top">
                                                        <asp:TextBox ID="txtDate_To9" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                                        <img alt="" id="imgDate_To9" runat="server" onclick="return showCalendar('<%=txtDate_To9.ClientID%>', 'mm/dd/y','','');"
                                                            onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL %>/iconPicDate.gif'
                                                            align="middle" />
                                                        <asp:RegularExpressionValidator ID="revtxtDate_To9" runat="server" ValidationGroup="vsErrorGroup"
                                                            Display="none" ErrorMessage="Filter Criteria  9 - End Date is not a valid date"
                                                            SetFocusOnError="true" ControlToValidate="txtDate_To9" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        <asp:CompareValidator ID="CompareValidator9" runat="server" ControlToCompare="txtDate_From9"
                                                            ControlToValidate="txtDate_To9" Type="Date" Operator="GreaterThanEqual" Display="None"
                                                            SetFocusOnError="true" ErrorMessage="Filter Criteria  9 - End Date should be greater than or equal to Start Date"
                                                            ValidationGroup="vsErrorGroup" />
                                                        <uc:CtrlRelativeDates ID="ucRelativeDatesTo_9" runat="server" strDateClientID="ctl00_ContentPlaceHolder1_txtDate_To9"
                                                            Visible="false" OnSetDate="RaltiveDatesSaveClick" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:ListBox ID="lst_F9" runat="server" Rows="5" Width="400px" SelectionMode="Multiple">
                                        </asp:ListBox>
                                        <asp:Panel ID="pnlAmount_F9" runat="server">
                                            <table cellpadding="1">
                                                <tr>
                                                    <td width="45%">
                                                        <asp:DropDownList ID="drpAmount_F9" Width="106px" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="drpAmount_F_SelectedIndexChanged">
                                                            <asp:ListItem Text="Equal" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Greater Than" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Less Than" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td nowrap="nowrap" valign="top">
                                                        <asp:Label ID="lblAmountText1_F9" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtAmount1_F9" runat="server" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this);" MaxLength="15"></asp:TextBox>
                                                        <asp:Label ID="lblAmountText2_F9" Visible="false" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtAmount2_F9" runat="server" Visible="false" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this);" MaxLength="15"></asp:TextBox>
                                                        <asp:CompareValidator ID="cvAmount9" runat="server" ErrorMessage="Filter Criteria  9 - To Amount must be Greater Than or Equal To From Amount"
                                                            ControlToCompare="txtAmount1_F9" ControlToValidate="txtAmount2_F9" Operator="GreaterThanEqual"
                                                            Type="Currency" Display="None" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlText_F9" runat="server">
                                            <table cellpadding="1">
                                                <tr>
                                                    <td width="35%">
                                                        <asp:DropDownList ID="drpText_F9" Width="106px" runat="server">
                                                            <asp:ListItem Text="Contains" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Start With" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="End With" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFilter9" runat="server" Width="216px" MaxLength="50"></asp:TextBox>
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
                        <td valign="top">
                            &nbsp;<b>Filter 10 :</b>
                        </td>
                        <td>
                            <table cellpadding="2" cellspacing="1" width="100%" align="center">
                                <tr>
                                    <td style="width: 25%;" valign="top">
                                        <asp:DropDownList ID="drpFilter10" runat="server" AutoPostBack="True" Width="230px"
                                            EnableTheming="false" OnSelectedIndexChanged="drpFilter_SelectedIndexChanged"
                                            onchange="Page_ClientValidate('dummy')">
                                        </asp:DropDownList>
                                    </td>
                                    <td width="75%">
                                        <asp:Panel ID="pnlDate_F10" runat="server">
                                            <table cellpadding="2" width="100%">
                                                <tr>
                                                    <td valign="top">
                                                        <asp:DropDownList ID="lstDate10" Width="106px" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="rdbLstDate_SelectedIndexChanged">
                                                            <asp:ListItem Text="On" Value="O" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                            <asp:ListItem Text="Before" Value="BF"></asp:ListItem>
                                                            <asp:ListItem Text="After" Value="A"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="11%" valign="top">
                                                        <asp:Label ID="lblDateFrom10" runat="server" Text="On Date : "></asp:Label>
                                                    </td>
                                                    <td width="30%" valign="top">
                                                        <asp:TextBox ID="txtDate_From10" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                                        <img alt="" id="imgDate_Opened_From10" onclick="return showCalendar('<%=txtDate_From10.ClientID%>',    'mm/dd/y','','');"
                                                            runat="server" onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL%>/iconPicDate.gif'
                                                            align="middle" />
                                                        <asp:RegularExpressionValidator ID="revtxtDate_From10" runat="server" ValidationGroup="vsErrorGroup"
                                                            Display="none" ErrorMessage="Filter Criteria  10 - On Date is not a valid date"
                                                            SetFocusOnError="true" ControlToValidate="txtDate_From10" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        <uc:CtrlRelativeDates ID="ucRelativeDatesFrom_10" runat="server" strDateClientID="ctl00_ContentPlaceHolder1_txtDate_From10"
                                                            OnSetDate="RaltiveDatesSaveClick" />
                                                    </td>
                                                    <td style="width: 11%;" valign="top">
                                                        <asp:Label ID="lblDateTo10" runat="server" Text="Start Date :"></asp:Label>
                                                    </td>
                                                    <td style="width: 30%;" valign="top">
                                                        <asp:TextBox ID="txtDate_To10" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                                        <img alt="" id="imgDate_To10" runat="server" onclick="return showCalendar('<%=txtDate_To10.ClientID%>', 'mm/dd/y','','');"
                                                            onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL %>/iconPicDate.gif'
                                                            align="middle" />
                                                        <asp:RegularExpressionValidator ID="revtxtDate_To10" runat="server" ValidationGroup="vsErrorGroup"
                                                            Display="none" ErrorMessage="Filter Criteria  10 - End Date is not a valid date"
                                                            SetFocusOnError="true" ControlToValidate="txtDate_To10" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        <asp:CompareValidator ID="CompareValidator10" runat="server" ControlToCompare="txtDate_From10"
                                                            ControlToValidate="txtDate_To10" Type="Date" Operator="GreaterThanEqual" Display="None"
                                                            SetFocusOnError="true" ErrorMessage="Filter Criteria  10 - End Date should be greater than or equal to Start Date"
                                                            ValidationGroup="vsErrorGroup" />
                                                        <uc:CtrlRelativeDates ID="ucRelativeDatesTo_10" runat="server" strDateClientID="ctl00_ContentPlaceHolder1_txtDate_To10"
                                                            Visible="false" OnSetDate="RaltiveDatesSaveClick" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:ListBox ID="lst_F10" runat="server" Rows="5" Width="400px" SelectionMode="Multiple">
                                        </asp:ListBox>
                                        <asp:Panel ID="pnlAmount_F10" runat="server">
                                            <table cellpadding="1">
                                                <tr>
                                                    <td width="45%">
                                                        <asp:DropDownList ID="drpAmount_F10" Width="106px" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="drpAmount_F_SelectedIndexChanged">
                                                            <asp:ListItem Text="Equal" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Greater Than" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Less Than" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td nowrap="nowrap" valign="top">
                                                        <asp:Label ID="lblAmountText1_F10" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtAmount1_F10" runat="server" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this);" MaxLength="15"></asp:TextBox>
                                                        <asp:Label ID="lblAmountText2_F10" Visible="false" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtAmount2_F10" runat="server" Visible="false" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this);" MaxLength="15"></asp:TextBox>
                                                        <asp:CompareValidator ID="cvAmount10" runat="server" ErrorMessage="Filter Criteria  10 - To Amount must be Greater Than or Equal To From Amount"
                                                            ControlToCompare="txtAmount1_F10" ControlToValidate="txtAmount2_F10" Operator="GreaterThanEqual"
                                                            Type="Currency" Display="None" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlText_F10" runat="server">
                                            <table cellpadding="1">
                                                <tr>
                                                    <td width="35%">
                                                        <asp:DropDownList ID="drpText_F10" Width="106px" runat="server">
                                                            <asp:ListItem Text="Contains" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Start With" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="End With" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFilter10" runat="server" Width="216px" MaxLength="50"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <table width="100%" cellpadding="4" cellspacing="2">
            <tr>
                <td class="bandHeaderRow">
                    Saved Reports
                </td>
            </tr>
            <tr>
                <td>
                    <table cellspacing="1" cellpadding="2" style="width: 100%">
                        <tr>
                            <td align="left" style="width: 12%;">
                                Report Name
                            </td>
                            <td align="center" style="width: 4%;">
                                :
                            </td>
                            <td align="left" colspan="4" style="width: 84%;">
                                <asp:TextBox ID="txtReportName" runat="server" ValidationGroup="vsErrorGroup" MaxLength="200"
                                    Width="260px"></asp:TextBox><span class="mf">*</span>
                                <asp:HiddenField ID="hdnReportId" runat="Server" />
                                <asp:RequiredFieldValidator ID="rfvEmpID" ControlToValidate="txtReportName" runat="server"
                                    SetFocusOnError="true" ValidationGroup="vsErrorGroup" EnableClientScript="true"
                                    ErrorMessage="Please Enter Report Name" Display="none"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 12%;">
                                Select Report
                            </td>
                            <td align="center" style="width: 4%;">
                                :
                            </td>
                            <td align="left" style="width: 34%;">
                                <asp:DropDownList ID="ddlReports" runat="server" AutoPostBack="True" AppendDataBoundItems="true"
                                    OnSelectedIndexChanged="ddlReports_SelectedIndexChanged" Width="245px" onchange="SaveScrollPositions();Page_ClientValidate('dummy')">
                                    <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="left" style="width: 12%;">
                                &nbsp;Select Recipients
                            </td>
                            <td align="center" style="width: 4%;">
                                :
                            </td>
                            <td align="left" style="width: 34%;">
                                <asp:DropDownList ID="ddlRecipientList" runat="server" EnableTheming="false" AutoPostBack="false"
                                    AppendDataBoundItems="true" Width="230px">
                                </asp:DropDownList>
                                &nbsp;&nbsp;
                                <asp:LinkButton ID="lnkSendEmail" runat="server" Text="Send Email" OnClientClick="return CheckRecipientList();"
                                    OnClick="lnkSendEmail_Click" ValidationGroup="vsErrorGroup"></asp:LinkButton>
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
                <td align="center">
                    <asp:Button ID="btnExportExcel" runat="Server" CssClass="btn" Text="Output to Excel"
                        ValidationGroup="vsErrorGroup" OnClientClick="javascript:return FireAllValidation();"
                        OnClick="btnExportExcel_Click" ToolTip="Output to Excel" />
                    <asp:Button ID="btnSubmit" runat="Server" Text="Save Report" ValidationGroup="vsErrorGroup"
                        OnClientClick="javascript:return FireAllValidation2();SaveScrollPositions();"
                        OnClick="btnSubmit_Click" ToolTip="Save Report" />
                    <asp:Button ID="btnClear" runat="Server" Text="Clear" OnClick="btnClear_Click" ToolTip="Clear" />
                    <asp:Button ID="btnDeleteReport" runat="server" Text="Delete Report" OnClick="btnDeleteReport_Click"
                        ToolTip="Delete Report" OnClientClick="return ConfirmDelete();" Enabled="false" />
                    <asp:Button ID="btnSchedule" runat="Server" CssClass="btn" Text="Schedule" ValidationGroup="vsErrorGroup"
                        OnClientClick="javascript:OPenSchedulePopup();return false;" ToolTip="Schedule Report"
                        Visible="false" />
                    <asp:HiddenField ID="hdnScheduleID" runat="server" Value="0" />
                    <asp:Button ID="btnHdnScheduling" runat="server" OnClick="btnHdnScheduling_Click" />
                </td>
            </tr>
            <tr>
                <td class="Spacer" style="height: 10px;">
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
