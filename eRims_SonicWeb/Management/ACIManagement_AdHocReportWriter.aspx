<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="ACIManagement_AdHocReportWriter.aspx.cs" Inherits="Management_ACIManagement_AdHocReportWriter" %>

<%--<%@ Register Src="~/Controls/DistributionFolders/AdHocDistributionFolders.ascx" TagName="AdHocDistribution"
    TagPrefix="uc" %>--%>
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
            var PK_Schedule = '<%=ViewState["PK_SID"]%>';
            var hdnPK_Adhoc = document.getElementById('ctl00_ContentPlaceHolder1_hdnReportId').value;
            if (hdnPK_Adhoc == "")
                hdnPK_Adhoc = 0;
            if (Page_ClientValidate('vsErrorGroup'))
                GB_showCenter('Schedule Ad Hoc Report Writer', '<%=AppConfig.SiteURL%>/Management/SchedulerptManagementAdHocWriter.aspx?PKID=' + PK_Schedule + "&RID=" + hdnPK_Adhoc, 300, 500, '');
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
            if (arguments.IsValid) arguments.IsValid = CheckTwoDrp('<%=drpGroupByFirst.ClientID %>', '<%=drpSortingFourth.ClientID %>');
            if (arguments.IsValid) arguments.IsValid = CheckTwoDrp('<%=drpGroupByFirst.ClientID %>', '<%=drpSortingFifth.ClientID %>');

            if (arguments.IsValid) arguments.IsValid = CheckTwoDrp('<%=drpGroupBySecond.ClientID %>', '<%=drpSortingFirst.ClientID %>');
            if (arguments.IsValid) arguments.IsValid = CheckTwoDrp('<%=drpGroupBySecond.ClientID %>', '<%=drpSortingSecond.ClientID %>');
            if (arguments.IsValid) arguments.IsValid = CheckTwoDrp('<%=drpGroupBySecond.ClientID %>', '<%=drpSortingThird.ClientID %>');
            if (arguments.IsValid) arguments.IsValid = CheckTwoDrp('<%=drpGroupBySecond.ClientID %>', '<%=drpSortingFourth.ClientID %>');
            if (arguments.IsValid) arguments.IsValid = CheckTwoDrp('<%=drpGroupBySecond.ClientID %>', '<%=drpSortingFifth.ClientID %>');

            if (arguments.IsValid) arguments.IsValid = CheckTwoDrp('<%=drpGroupByThird.ClientID %>', '<%=drpSortingFirst.ClientID %>');
            if (arguments.IsValid) arguments.IsValid = CheckTwoDrp('<%=drpGroupByThird.ClientID %>', '<%=drpSortingSecond.ClientID %>');
            if (arguments.IsValid) arguments.IsValid = CheckTwoDrp('<%=drpGroupByThird.ClientID %>', '<%=drpSortingThird.ClientID %>');
            if (arguments.IsValid) arguments.IsValid = CheckTwoDrp('<%=drpGroupByThird.ClientID %>', '<%=drpSortingFourth.ClientID %>');
            if (arguments.IsValid) arguments.IsValid = CheckTwoDrp('<%=drpGroupByThird.ClientID %>', '<%=drpSortingFifth.ClientID %>');

            if (arguments.IsValid) arguments.IsValid = CheckTwoDrp('<%=drpGroupByFourth.ClientID %>', '<%=drpSortingFirst.ClientID %>');
            if (arguments.IsValid) arguments.IsValid = CheckTwoDrp('<%=drpGroupByFourth.ClientID %>', '<%=drpSortingSecond.ClientID %>');
            if (arguments.IsValid) arguments.IsValid = CheckTwoDrp('<%=drpGroupByFourth.ClientID %>', '<%=drpSortingThird.ClientID %>');
            if (arguments.IsValid) arguments.IsValid = CheckTwoDrp('<%=drpGroupByFourth.ClientID %>', '<%=drpSortingFourth.ClientID %>');
            if (arguments.IsValid) arguments.IsValid = CheckTwoDrp('<%=drpGroupByFourth.ClientID %>', '<%=drpSortingFifth.ClientID %>');

            if (arguments.IsValid) arguments.IsValid = CheckTwoDrp('<%=drpGroupByFifth.ClientID %>', '<%=drpSortingFirst.ClientID %>');
            if (arguments.IsValid) arguments.IsValid = CheckTwoDrp('<%=drpGroupByFifth.ClientID %>', '<%=drpSortingSecond.ClientID %>');
            if (arguments.IsValid) arguments.IsValid = CheckTwoDrp('<%=drpGroupByFifth.ClientID %>', '<%=drpSortingThird.ClientID %>');
            if (arguments.IsValid) arguments.IsValid = CheckTwoDrp('<%=drpGroupByFifth.ClientID %>', '<%=drpSortingFourth.ClientID %>');
            if (arguments.IsValid) arguments.IsValid = CheckTwoDrp('<%=drpGroupByFifth.ClientID %>', '<%=drpSortingFifth.ClientID %>');

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
    <script type="text/javascript">
        function CheckValidation1(source, args) {
            var e = document.getElementById('<%=drpGroupByFirst.ClientID %>');
            var ddlFirst = e.options[e.selectedIndex].text;

            var e2 = document.getElementById('<%=drpGroupBySecond.ClientID %>');
            var ddlSecond = e2.options[e2.selectedIndex].text;
            if (ddlSecond != "--Select--") {
                if (ddlFirst == "--Select--") {
                    args.IsValid = false;
                }
                else {
                    args.IsValid = true;
                }
            }


        }
        function CheckValidation2(source, args) {
            var e = document.getElementById('<%=drpGroupByFirst.ClientID %>');
            var ddlFirst = e.options[e.selectedIndex].text;

            var e2 = document.getElementById('<%=drpGroupBySecond.ClientID %>');
            var ddlSecond = e2.options[e2.selectedIndex].text;

            var e3 = document.getElementById('<%=drpGroupByThird.ClientID %>');
            var ddlThird = e3.options[e3.selectedIndex].text;
            if (ddlThird != "--Select--") {
                if (ddlSecond == "--Select--" || ddlFirst == "--Select--") {
                    args.IsValid = false;
                }
                else {
                    args.IsValid = true;
                }
            }
        }
        function CheckValidation3(source, args) {
            var e = document.getElementById('<%=drpGroupByFirst.ClientID %>');
            var ddlFirst = e.options[e.selectedIndex].text;

            var e2 = document.getElementById('<%=drpGroupBySecond.ClientID %>');
            var ddlSecond = e2.options[e2.selectedIndex].text;

            var e3 = document.getElementById('<%=drpGroupByThird.ClientID %>');
            var ddlThird = e3.options[e3.selectedIndex].text;
            var e4 = document.getElementById('<%=drpGroupByFourth.ClientID %>');
            var ddlFourth = e4.options[e4.selectedIndex].text;
            if (ddlFourth != "--Select--") {
                if (ddlSecond == "--Select--" || ddlFirst == "--Select--" || ddlThird == "--Select--") {
                    args.IsValid = false;
                }
                else {
                    args.IsValid = true;
                }
            }
        }
        function CheckValidation4(source, args) {
            var e = document.getElementById('<%=drpGroupByFirst.ClientID %>');
            var ddlFirst = e.options[e.selectedIndex].text;

            var e2 = document.getElementById('<%=drpGroupBySecond.ClientID %>');
            var ddlSecond = e2.options[e2.selectedIndex].text;

            var e3 = document.getElementById('<%=drpGroupByThird.ClientID %>');
            var ddlThird = e3.options[e3.selectedIndex].text;
            var e4 = document.getElementById('<%=drpGroupByFourth.ClientID %>');
            var ddlFourth = e4.options[e4.selectedIndex].text;
            var e5 = document.getElementById('<%=drpGroupByFifth.ClientID %>');
            var ddlFifth = e5.options[e5.selectedIndex].text;
            if (ddlFifth != "--Select--") {
                if (ddlSecond == "--Select--" || ddlFirst == "--Select--" || ddlThird == "--Select--" || ddlFourth == "--Select--") {
                    args.IsValid = false;
                }
                else {
                    args.IsValid = true;
                }
            }
        }
    </script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/gb_scripts.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL %>JavaScript/Validator.js"
        language="javascript"></script>
    <br />
    <asp:ValidationSummary ID="vsError" runat="server" ValidationGroup="vsErrorGroup"
        BorderColor="DimGray" BorderWidth="1" HeaderText="Verify the following fields:"
        ShowMessageBox="true" ShowSummary="false"></asp:ValidationSummary>
    <div class="bandHeaderRow">
        Management: Ad Hoc Report Writer</div>
    <asp:Panel ID="pnl_Container" runat="server">
        <table width="100%" cellpadding="4" cellspacing="2">
            <tr>
                <td align="center">
                    <table cellpadding="1" cellspacing="1">
                        <tr>
                            <td align="left">
                                <%--<b>Report Type</b>--%>
                                &nbsp;
                            </td>
                            <td align="left">
                                <asp:CheckBoxList ID="rblCoverage" RepeatDirection="Horizontal" runat="server" AutoPostBack="True"
                                    Visible="false" OnSelectedIndexChanged="rblCoverage_SelectedIndexChanged" onclick="SaveScrollPositions();Page_ClientValidate('dummy')">
                                    <asp:ListItem Text="Management" Value="999" Selected="True" Enabled="false" />
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                        <%--<tr>
                            <td align="left">
                                <b>Report Type :</b>
                            </td>
                            <td align="left">
                                <asp:RadioButtonList ID="rdbEvent" runat="server">
                                    <asp:ListItem Value="1" Text="Event" Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="0" Text="Alaram"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>--%>
                    </table>
                </td>
            </tr>
        </table>
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
                                        Select Output Fields &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:
                                    </td>
                                    <%--<td style="width: 2%;" align="center">
                                       
                                    </td>--%>
                                    <td style="width: 72%" colspan="2">
                                        <table width="100%">
                                            <tr>
                                                <td align="left" style="width: 250px">
                                                    <asp:ListBox ID="lstOutputFields" runat="server" Rows="10" SelectionMode="Multiple"
                                                        Width="300px"></asp:ListBox>
                                                </td>
                                                <td valign="middle" align="center" style="width: 70px">
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
                                                        Width="300px"></asp:ListBox>
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
                                        <asp:DropDownList ID="drpGroupByFirst" runat="server" Width="250px"
                                            onchange="AskfForLogoff=false;Page_ClientValidate('dummy')">
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
                                        <asp:DropDownList ID="drpGroupBySecond" runat="server" Width="250px" onchange="AskfForLogoff=false;Page_ClientValidate('dummy')">
                                            <asp:ListItem Text="--Select--" Value="-1"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:CompareValidator ID="cmGroup" runat="server" ControlToValidate="drpGroupBySecond"
                                            ControlToCompare="drpGroupByFirst" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                            InitialValue="0" ErrorMessage="First Level and second Level group by must be different."
                                            Type="String" Display="None" Operator="NotEqual"></asp:CompareValidator>
                                        <asp:CustomValidator ID="cust1" runat="server" ControlToValidate="drpGroupBySecond"
                                            ClientValidationFunction="CheckValidation1" Display="None" ErrorMessage="Please Select First Groupby"
                                            SetFocusOnError="true" ValidationGroup="vsErrorGroup" ValidateEmptyText="true"></asp:CustomValidator>
                                    </td>
                                    <td valign="top">
                                        <asp:RadioButtonList ID="rdblGroupSortBySecond" runat="server" RepeatDirection="Horizontal"
                                            CellPadding="0" CellSpacing="0">
                                            <asp:ListItem Selected="True" Text="Ascending  " Value="ASC"></asp:ListItem>
                                            <asp:ListItem Text="Descending" Value="DESC"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Third Level Group By
                                    </td>
                                    <td align="center">
                                        :
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpGroupByThird" runat="server" Width="250px" onchange="AskfForLogoff=false;Page_ClientValidate('dummy')">
                                            <asp:ListItem Text="--Select--" Value="-2"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:CompareValidator ID="CV2" runat="server" ControlToValidate="drpGroupByThird"
                                            ControlToCompare="drpGroupByFirst" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                            InitialValue="0" ErrorMessage="First Level and Third Level group by must be different."
                                            Type="String" Display="None" Operator="NotEqual"></asp:CompareValidator>
                                        <asp:CompareValidator ID="CV1" runat="server" ControlToValidate="drpGroupByThird"
                                            ControlToCompare="drpGroupBySecond" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                            InitialValue="0" ErrorMessage="Second Level and Third Level group by must be different."
                                            Type="String" Display="None" Operator="NotEqual"></asp:CompareValidator>
                                        <%--<asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="drpGroupByThird"
                                             ClientValidationFunction="CheckValidation1"
                                            Display="None" ErrorMessage="Please Select First Groupby"   SetFocusOnError="true"
                                             ValidationGroup="vsErrorGroup"  ValidateEmptyText="true"></asp:CustomValidator>--%>
                                        <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="drpGroupByThird"
                                            ClientValidationFunction="CheckValidation2" Display="None" ErrorMessage="First and Second Group By must be selected"
                                            SetFocusOnError="true" ValidationGroup="vsErrorGroup" ValidateEmptyText="true"></asp:CustomValidator>
                                    </td>
                                    <td>
                                        <asp:RadioButtonList ID="rdblGroupSortByThird" runat="server" RepeatDirection="Horizontal"
                                            CellPadding="0" CellSpacing="0">
                                            <asp:ListItem Selected="True" Text="Ascending  " Value="ASC"></asp:ListItem>
                                            <asp:ListItem Text="Descending" Value="DESC"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Fourth Level Group By
                                    </td>
                                    <td align="center">
                                        :
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpGroupByFourth" runat="server" Width="250px" onchange="AskfForLogoff=false;Page_ClientValidate('dummy')">
                                            <asp:ListItem Text="--Select--" Value="-3"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:CompareValidator ID="CV3" runat="server" ControlToValidate="drpGroupByFourth"
                                            ControlToCompare="drpGroupByFirst" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                            InitialValue="0" ErrorMessage="First Level and Fourth Level group by must be different."
                                            Type="String" Display="None" Operator="NotEqual"></asp:CompareValidator>
                                        <asp:CompareValidator ID="CV4" runat="server" ControlToValidate="drpGroupByFourth"
                                            ControlToCompare="drpGroupBySecond" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                            InitialValue="0" ErrorMessage="Second Level and Fourth Level group by must be different."
                                            Type="String" Display="None" Operator="NotEqual"></asp:CompareValidator>
                                        <asp:CompareValidator ID="CV5" runat="server" ControlToValidate="drpGroupByFourth"
                                            ControlToCompare="drpGroupByThird" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                            InitialValue="0" ErrorMessage="Third Level and Fourth Level group by must be different."
                                            Type="String" Display="None" Operator="NotEqual"></asp:CompareValidator>
                                        <%--<asp:CustomValidator ID="CustomValidator3" runat="server" ControlToValidate="drpGroupByFourth"
                                             ClientValidationFunction="CheckValidation1"
                                            Display="None" ErrorMessage="Please Select First Groupby"   SetFocusOnError="true"
                                             ValidationGroup="vsErrorGroup"  ValidateEmptyText="true"></asp:CustomValidator>

                                             <asp:CustomValidator ID="CustomValidator4" runat="server" ControlToValidate="drpGroupByFourth"
                                             ClientValidationFunction="CheckValidation2"
                                            Display="None" ErrorMessage="Please Select Second Groupby"   SetFocusOnError="true"
                                             ValidationGroup="vsErrorGroup"  ValidateEmptyText="true"></asp:CustomValidator>--%>
                                        <asp:CustomValidator ID="CustomValidator5" runat="server" ControlToValidate="drpGroupByFourth"
                                            ClientValidationFunction="CheckValidation3" Display="None" ErrorMessage="First, Second and Third Group By must be selected"
                                            SetFocusOnError="true" ValidationGroup="vsErrorGroup" ValidateEmptyText="true"></asp:CustomValidator>
                                    </td>
                                    <td>
                                        <asp:RadioButtonList ID="rdblGroupSortByFourth" runat="server" RepeatDirection="Horizontal"
                                            CellPadding="0" CellSpacing="0">
                                            <asp:ListItem Selected="True" Text="Ascending  " Value="ASC"></asp:ListItem>
                                            <asp:ListItem Text="Descending" Value="DESC"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Fifth Level Group By
                                    </td>
                                    <td align="center">
                                        :
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpGroupByFifth" runat="server" Width="250px" onchange="AskfForLogoff=false;Page_ClientValidate('dummy')">
                                            <asp:ListItem Text="--Select--" Value="-4"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:CompareValidator ID="CV6" runat="server" ControlToValidate="drpGroupByFifth"
                                            ControlToCompare="drpGroupByFirst" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                            InitialValue="0" ErrorMessage="First Level and Fifth Level group by must be different."
                                            Type="String" Display="None" Operator="NotEqual"></asp:CompareValidator>
                                        <asp:CompareValidator ID="CV7" runat="server" ControlToValidate="drpGroupByFifth"
                                            ControlToCompare="drpGroupBySecond" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                            InitialValue="0" ErrorMessage="Second Level and Fifth Level group by must be different."
                                            Type="String" Display="None" Operator="NotEqual"></asp:CompareValidator>
                                        <asp:CompareValidator ID="CV8" runat="server" ControlToValidate="drpGroupByFifth"
                                            ControlToCompare="drpGroupByThird" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                            InitialValue="0" ErrorMessage="Third Level and Fifth Level group by must be different."
                                            Type="String" Display="None" Operator="NotEqual"></asp:CompareValidator>
                                        <asp:CompareValidator ID="CV9" runat="server" ControlToValidate="drpGroupByFifth"
                                            ControlToCompare="drpGroupByFourth" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                            InitialValue="0" ErrorMessage="Fourth Level and Fifth Level group by must be different."
                                            Type="String" Display="None" Operator="NotEqual"></asp:CompareValidator>
                                        <%-- <asp:CustomValidator ID="CustomValidator6" runat="server" ControlToValidate="drpGroupByFifth"
                                             ClientValidationFunction="CheckValidation1"
                                            Display="None" ErrorMessage="Please Select First Groupby"   SetFocusOnError="true"
                                             ValidationGroup="vsErrorGroup"  ValidateEmptyText="true"></asp:CustomValidator>

                                             <asp:CustomValidator ID="CustomValidator7" runat="server" ControlToValidate="drpGroupByFifth"
                                             ClientValidationFunction="CheckValidation2"
                                            Display="None" ErrorMessage="Please Select Second Groupby"   SetFocusOnError="true"
                                             ValidationGroup="vsErrorGroup"  ValidateEmptyText="true"></asp:CustomValidator>

                                             <asp:CustomValidator ID="CustomValidator8" runat="server" ControlToValidate="drpGroupByFifth"
                                             ClientValidationFunction="CheckValidation3"
                                            Display="None" ErrorMessage="Please Select Third Groupby"   SetFocusOnError="true"
                                             ValidationGroup="vsErrorGroup"  ValidateEmptyText="true"></asp:CustomValidator>--%>
                                        <asp:CustomValidator ID="CustomValidator9" runat="server" ControlToValidate="drpGroupByFifth"
                                            ClientValidationFunction="CheckValidation4" Display="None" ErrorMessage="First, Second, Third and Fourth Group By must be selected"
                                            SetFocusOnError="true" ValidationGroup="vsErrorGroup" ValidateEmptyText="true"></asp:CustomValidator>
                                    </td>
                                    <td>
                                        <asp:RadioButtonList ID="rdblGroupSortByFifth" runat="server" RepeatDirection="Horizontal"
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
                                        <asp:DropDownList ID="drpSortingFirst" runat="server" Width="250px"
                                            onchange="AskfForLogoff=false;Page_ClientValidate('dummy')">
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
                                        <asp:DropDownList ID="drpSortingSecond" runat="server" Width="250px" onchange="AskfForLogoff=false;Page_ClientValidate('dummy')">
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
                                        <asp:DropDownList ID="drpSortingThird" runat="server" Width="250px" onchange="AskfForLogoff=false;Page_ClientValidate('dummy')">
                                            <asp:ListItem Text="--Select--" Value="-2"></asp:ListItem>
                                        </asp:DropDownList>
                                        <%--<asp:CompareValidator ID="cmGroup1" runat="server" ControlToValidate="drpSortingSecond"
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
                                            Display="None" ValidationGroup="vsErrorGroup" ClientValidationFunction="CheckGroupBySortBy"></asp:CustomValidator>--%>
                                    </td>
                                    <td valign="top">
                                        <asp:RadioButtonList ID="rdbSort3" runat="server" RepeatDirection="Horizontal" CellPadding="0"
                                            CellSpacing="0">
                                            <asp:ListItem Selected="True" Text="Ascending  " Value="ASC"></asp:ListItem>
                                            <asp:ListItem Text="Descending" Value="DESC"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Fourth Level Sorting
                                    </td>
                                    <td align="center">
                                        :
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpSortingFourth" runat="server" Width="250px" onchange="AskfForLogoff=false;Page_ClientValidate('dummy')">
                                            <asp:ListItem Text="--Select--" Value="-3"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td valign="top">
                                        <asp:RadioButtonList ID="rdbSort4" runat="server" RepeatDirection="Horizontal" CellPadding="0"
                                            CellSpacing="0">
                                            <asp:ListItem Selected="True" Text="Ascending  " Value="ASC"></asp:ListItem>
                                            <asp:ListItem Text="Descending" Value="DESC"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Fifth Level Sorting
                                    </td>
                                    <td align="center">
                                        :
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpSortingFifth" runat="server" Width="250px" onchange="AskfForLogoff=false;Page_ClientValidate('dummy')">
                                            <asp:ListItem Text="--Select--" Value="-4"></asp:ListItem>
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
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="drpSortingFourth"
                                            ControlToCompare="drpSortingFirst" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                            InitialValue="0" ErrorMessage="First and Fourth Level Sorting must be different."
                                            Type="String" Display="None" Operator="NotEqual"></asp:CompareValidator>
                                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="drpSortingFourth"
                                            ControlToCompare="drpSortingSecond" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                            InitialValue="0" ErrorMessage="Second and Fourth Level Sorting must be different."
                                            Type="String" Display="None" Operator="NotEqual"></asp:CompareValidator>
                                        <asp:CompareValidator ID="CompareValidator11" runat="server" ControlToValidate="drpSortingFourth"
                                            ControlToCompare="drpSortingThird" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                            InitialValue="0" ErrorMessage="Third and Fourth Level Sorting must be different."
                                            Type="String" Display="None" Operator="NotEqual"></asp:CompareValidator>
                                        <asp:CompareValidator ID="CompareValidator12" runat="server" ControlToValidate="drpSortingFifth"
                                            ControlToCompare="drpSortingFirst" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                            InitialValue="0" ErrorMessage="First and Fifth Level Sorting must be different."
                                            Type="String" Display="None" Operator="NotEqual"></asp:CompareValidator>
                                        <asp:CompareValidator ID="CompareValidator13" runat="server" ControlToValidate="drpSortingFifth"
                                            ControlToCompare="drpSortingSecond" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                            InitialValue="0" ErrorMessage="Second and Fifth Level Sorting must be different."
                                            Type="String" Display="None" Operator="NotEqual"></asp:CompareValidator>
                                        <asp:CompareValidator ID="CompareValidator14" runat="server" ControlToValidate="drpSortingFifth"
                                            ControlToCompare="drpSortingThird" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                            InitialValue="0" ErrorMessage="Third and Fifth Level Sorting must be different."
                                            Type="String" Display="None" Operator="NotEqual"></asp:CompareValidator>
                                        <asp:CompareValidator ID="CompareValidator15" runat="server" ControlToValidate="drpSortingFifth"
                                            ControlToCompare="drpSortingFourth" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                            InitialValue="0" ErrorMessage="Fourth and Fifth Level Sorting must be different."
                                            Type="String" Display="None" Operator="NotEqual"></asp:CompareValidator>
                                        <asp:CustomValidator ID="csvGroupBySortBy" runat="server" ErrorMessage="Group By and Sort by selection must be different"
                                            Display="None" ValidationGroup="vsErrorGroup" ClientValidationFunction="CheckGroupBySortBy"></asp:CustomValidator>
                                    </td>
                                    <td valign="top">
                                        <asp:RadioButtonList ID="rdbSort5" runat="server" RepeatDirection="Horizontal" CellPadding="0"
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
                        <td style="width: 8%">
                            &nbsp;
                        </td>
                        <td>
                            <table width="100%" cellpadding="2" cellspacing="1">
                                <tr style="display: none">
                                    <td style="width: 16%">
                                        Prior Valuation Date
                                    </td>
                                    <td style="width: 2%;" align="center" valign="middle">
                                        :
                                    </td>
                                    <td style="width: 32%" valign="middle">
                                        <asp:TextBox ID="txtPriorDate" runat="server" SkinID="txtDate"></asp:TextBox>
                                        <img alt="" onclick="javascript:return showCalendar('ctl00_ContentPlaceHolder1_txtPriorDate', 'mm/dd/y');"
                                            onmouseover="javascript:this.style.cursor='hand';" src="~/Images/iconPicDate.gif"
                                            align="middle" id="imgPriorValuationDate" runat="server" />
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender18" runat="server" AcceptNegative="Left"
                                            DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                            OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtPriorDate"
                                            CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                        </cc1:MaskedEditExtender>
                                        <uc:CtrlRelativeDates ID="ucRelativeDates_PriorVal" runat="server" strDateClientID="ctl00_ContentPlaceHolder1_txtPriorDate"
                                            Visible="true" OnSetDate="RaltiveDatesSaveClick" />
                                        <asp:RegularExpressionValidator ID="revtxtPriorDate" runat="server" ValidationGroup="vsErrorGroup"
                                            Display="none" ErrorMessage="Prior Valuation Date is not a valid date" SetFocusOnError="true"
                                            ControlToValidate="txtPriorDate" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkGrandTotal" runat="server" Text="Include Grand Total in Report " />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <b>Filter 1 :</b>
                        </td>
                        <td>
                            <table cellpadding="2" cellspacing="1" width="100%" align="center">
                                <tr>
                                    <td style="width: 25%;" valign="top">
                                        <asp:DropDownList ID="drpFilter1" runat="server" AutoPostBack="True" Width="250px"
                                            OnSelectedIndexChanged="drpFilter_SelectedIndexChanged" onchange="AskfForLogoff=false;Page_ClientValidate('dummy')">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 5%;" align="left" valign="top">
                                        <asp:CheckBox ID="chkNotCriteria1" runat="server" Text="Not" Visible="false" />
                                    </td>
                                    <td width="70%" align="left" valign="top">
                                        <asp:Panel ID="pnlDate_F1" runat="server">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList Width="106px" ID="lstDate1" EnableTheming="false" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="rdbLstDate_SelectedIndexChanged">
                                                            <asp:ListItem Text="On" Value="O" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                            <asp:ListItem Text="On or Before" Value="BF"></asp:ListItem>
                                                            <asp:ListItem Text="On or After" Value="A"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="11%" nowrap="nowrap">
                                                        <asp:Label ID="lblDateFrom1" runat="server" Text="On Date : "></asp:Label>
                                                    </td>
                                                    <td width="30%">
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
                                                    <td style="width: 11%;">
                                                        <asp:Label ID="lblDateTo1" runat="server" Text="Start Date :"></asp:Label>
                                                    </td>
                                                    <td style="width: 30%;">
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
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="drpAmount_F1" Width="106px" EnableTheming="false" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="drpAmount_F_SelectedIndexChanged">
                                                            <asp:ListItem Text="Equal" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Greater Than" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Less Than" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblAmountText1_F1" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtAmount1_F1" runat="server" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this,12);" MaxLength="15"></asp:TextBox>
                                                        <asp:Label ID="lblAmountText2_F1" Visible="false" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtAmount2_F1" runat="server" Visible="false" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this,12);" MaxLength="15"></asp:TextBox>
                                                        <asp:CompareValidator ID="cvAmount1" runat="server" ErrorMessage="Filter Criteria  1 - To Amount must be Greater Than or Equal To From Amount"
                                                            ControlToCompare="txtAmount1_F1" ControlToValidate="txtAmount2_F1" Operator="GreaterThanEqual"
                                                            Type="Currency" Display="None" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlText_F1" runat="server">
                                            <table>
                                                <tr>
                                                    <td width="40%">
                                                        <asp:DropDownList ID="drpText_F1" Width="106px" runat="server">
                                                            <asp:ListItem Text="Contains" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Start With" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="End With" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="60%">
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
                            <b>Filter 2 :</b>
                        </td>
                        <td>
                            <table cellpadding="2" cellspacing="1" width="100%" align="center">
                                <tr>
                                    <td style="width: 25%;" valign="top">
                                        <asp:DropDownList ID="drpFilter2" runat="server" AutoPostBack="True" Width="250px"
                                            OnSelectedIndexChanged="drpFilter_SelectedIndexChanged" onchange="AskfForLogoff=false;Page_ClientValidate('dummy')">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 5%;" align="left" valign="top">
                                        <asp:CheckBox ID="chkNotCriteria2" runat="server" Text="Not" Visible="false" />
                                    </td>
                                    <td width="70%" align="left" valign="top">
                                        <asp:Panel ID="pnlDate_F2" runat="server">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="lstDate2" Width="106px"  EnableTheming="false" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="rdbLstDate_SelectedIndexChanged">
                                                            <asp:ListItem Text="On" Value="O" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                            <asp:ListItem Text="On or Before" Value="BF"></asp:ListItem>
                                                            <asp:ListItem Text="On or After" Value="A"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="11%">
                                                        <asp:Label ID="lblDateFrom2" runat="server" Text="On Date : "></asp:Label>
                                                    </td>
                                                    <td width="30%">
                                                        <asp:TextBox ID="txtDate_From2" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                                        <img alt="" id="imgDate_Opened_From2" onclick="return showCalendar('<%=txtDate_From2.ClientID%>', 'mm/dd/y','','');"
                                                            runat="server" onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL %>iconPicDate.gif'
                                                            align="middle" />
                                                        <asp:RegularExpressionValidator ID="revtxtDate_From2" runat="server" ValidationGroup="vsErrorGroup"
                                                            Display="none" ErrorMessage="Filter Criteria  2 - On Date is not a valid date"
                                                            SetFocusOnError="true" ControlToValidate="txtDate_From2" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        <uc:CtrlRelativeDates ID="ucRelativeDatesFrom_2" runat="server" strDateClientID="ctl00_ContentPlaceHolder1_txtDate_From2"
                                                            OnSetDate="RaltiveDatesSaveClick" />
                                                    </td>
                                                    <td style="width: 11%;">
                                                        <asp:Label ID="lblDateTo2" runat="server" Text="Start Date :"></asp:Label>
                                                    </td>
                                                    <td style="width: 30%;">
                                                        <asp:TextBox ID="txtDateTo2" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                                        <img alt="" id="imgDate_To2" runat="server" onclick="return showCalendar('<%=txtDateTo2.ClientID%>', 'mm/dd/y','','');"
                                                            onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL %>iconPicDate.gif'
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
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="drpAmount_F2" Width="106px" EnableTheming="false" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="drpAmount_F_SelectedIndexChanged">
                                                            <asp:ListItem Text="Equal" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Greater Than" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Less Than" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblAmountText1_F2" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtAmount1_F2" runat="server" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this,12);" MaxLength="15"></asp:TextBox>
                                                        <asp:Label ID="lblAmountText2_F2" Visible="false" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtAmount2_F2" runat="server" Visible="false" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this,12);" MaxLength="15"></asp:TextBox>
                                                        <asp:CompareValidator ID="cvAmount2" runat="server" ErrorMessage="Filter Criteria  2 - To Amount must be Greater Than or Equal To From Amount"
                                                            ControlToCompare="txtAmount1_F2" ControlToValidate="txtAmount2_F2" Operator="GreaterThanEqual"
                                                            Type="Currency" Display="None" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlText_F2" runat="server">
                                            <table>
                                                <tr>
                                                    <td width="40%">
                                                        <asp:DropDownList ID="drpText_F2" Width="106px" runat="server">
                                                            <asp:ListItem Text="Contains" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Start With" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="End With" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="60%">
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
                            <b>Filter 3 :</b>
                        </td>
                        <td>
                            <table cellpadding="2" cellspacing="1" width="100%" align="center">
                                <tr>
                                    <td style="width: 25%;" valign="top">
                                        <asp:DropDownList ID="drpFilter3" runat="server" AutoPostBack="True" Width="250px"
                                            OnSelectedIndexChanged="drpFilter_SelectedIndexChanged" onchange="AskfForLogoff=false;Page_ClientValidate('dummy')">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 5%;" align="left" valign="top">
                                        <asp:CheckBox ID="chkNotCriteria3" runat="server" Text="Not" Visible="false" />
                                    </td>
                                    <td width="70%" align="left" valign="top">
                                        <asp:Panel ID="pnlDate_F3" runat="server">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="lstDate3" Width="106px"  EnableTheming="false" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="rdbLstDate_SelectedIndexChanged">
                                                            <asp:ListItem Text="On" Value="O" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                            <asp:ListItem Text="On or Before" Value="BF"></asp:ListItem>
                                                            <asp:ListItem Text="On or After" Value="A"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="11%">
                                                        <asp:Label ID="lblDateFrom3" runat="server" Text="On Date : "></asp:Label>
                                                    </td>
                                                    <td width="30%">
                                                        <asp:TextBox ID="txtDate_From3" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                                        <img alt="" id="imgDate_Opened_From3" onclick="return showCalendar('<%=txtDate_From3.ClientID%>', 'mm/dd/y','','');"
                                                            runat="server" onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL %>iconPicDate.gif'
                                                            align="middle" />
                                                        <asp:RegularExpressionValidator ID="revtxtDate_From3" runat="server" ValidationGroup="vsErrorGroup"
                                                            Display="none" ErrorMessage="Filter Criteria  3 - On Date is not a valid date"
                                                            SetFocusOnError="true" ControlToValidate="txtDate_From3" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        <uc:CtrlRelativeDates ID="ucRelativeDatesFrom_3" runat="server" strDateClientID="ctl00_ContentPlaceHolder1_txtDate_From3"
                                                            OnSetDate="RaltiveDatesSaveClick" />
                                                    </td>
                                                    <td style="width: 11%;">
                                                        <asp:Label ID="lblDateTo3" runat="server" Text="Start Date :"></asp:Label>
                                                    </td>
                                                    <td style="width: 30%;">
                                                        <asp:TextBox ID="txtDate_To3" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                                        <img alt="" id="imgDate_To3" runat="server" onclick="return showCalendar('<%=txtDate_To3.ClientID%>', 'mm/dd/y','','');"
                                                            onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL %>iconPicDate.gif'
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
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="drpAmount_F3" Width="106px" EnableTheming="false" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="drpAmount_F_SelectedIndexChanged">
                                                            <asp:ListItem Text="Equal" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Greater Than" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Less Than" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblAmountText1_F3" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtAmount1_F3" runat="server" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this,12);" MaxLength="15"></asp:TextBox>
                                                        <asp:Label ID="lblAmountText2_F3" Visible="false" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtAmount2_F3" runat="server" Visible="false" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this,12);" MaxLength="15"></asp:TextBox>
                                                        <asp:CompareValidator ID="cvAmount3" runat="server" ErrorMessage="Filter Criteria  3 - To Amount must be Greater Than or Equal To From Amount"
                                                            ControlToCompare="txtAmount1_F3" ControlToValidate="txtAmount2_F3" Operator="GreaterThanEqual"
                                                            Type="Currency" Display="None" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlText_F3" runat="server">
                                            <table>
                                                <tr>
                                                    <td width="40%">
                                                        <asp:DropDownList ID="drpText_F3" Width="106px" runat="server">
                                                            <asp:ListItem Text="Contains" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Start With" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="End With" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="60%">
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
                            <b>Filter 4 :</b>
                        </td>
                        <td>
                            <table cellpadding="2" cellspacing="1" width="100%" align="center">
                                <tr>
                                    <td style="width: 25%;" valign="top">
                                        <asp:DropDownList ID="drpFilter4" runat="server" AutoPostBack="True" Width="250px"
                                            OnSelectedIndexChanged="drpFilter_SelectedIndexChanged" onchange="Page_ClientValidate('dummy')">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 5%;" align="left" valign="top">
                                        <asp:CheckBox ID="chkNotCriteria4" runat="server" Text="Not" Visible="false" />
                                    </td>
                                    <td width="70%" align="left" valign="top">
                                        <asp:Panel ID="pnlDate_F4" runat="server">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="lstDate4" Width="106px"  EnableTheming="false" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="rdbLstDate_SelectedIndexChanged">
                                                            <asp:ListItem Text="On" Value="O" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                            <asp:ListItem Text="On or Before" Value="BF"></asp:ListItem>
                                                            <asp:ListItem Text="On or After" Value="A"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="11%">
                                                        <asp:Label ID="lblDateFrom4" runat="server" Text="On Date : "></asp:Label>
                                                    </td>
                                                    <td width="30%">
                                                        <asp:TextBox ID="txtDate_From4" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                                        <img alt="" id="imgDate_Opened_From4" onclick="return showCalendar('<%=txtDate_From4.ClientID%>', 'mm/dd/y','','');"
                                                            runat="server" onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL %>iconPicDate.gif'
                                                            align="middle" />
                                                        <asp:RegularExpressionValidator ID="revtxtDate_From4" runat="server" ValidationGroup="vsErrorGroup"
                                                            Display="none" ErrorMessage="Filter Criteria  4 - On Date is not a valid date"
                                                            SetFocusOnError="true" ControlToValidate="txtDate_From4" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        <uc:CtrlRelativeDates ID="ucRelativeDatesFrom_4" runat="server" strDateClientID="ctl00_ContentPlaceHolder1_txtDate_From4"
                                                            OnSetDate="RaltiveDatesSaveClick" />
                                                    </td>
                                                    <td style="width: 11%;">
                                                        <asp:Label ID="lblDateTo4" runat="server" Text="Start Date :"></asp:Label>
                                                    </td>
                                                    <td style="width: 30%;">
                                                        <asp:TextBox ID="txtDate_To4" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                                        <img alt="" id="imgDate_To4" runat="server" onclick="return showCalendar('<%=txtDate_To4.ClientID%>', 'mm/dd/y','','');"
                                                            onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL %>iconPicDate.gif'
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
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="drpAmount_F4" Width="106px" EnableTheming="false" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="drpAmount_F_SelectedIndexChanged">
                                                            <asp:ListItem Text="Equal" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Greater Than" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Less Than" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblAmountText1_F4" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtAmount1_F4" runat="server" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this,12);" MaxLength="15"></asp:TextBox>
                                                        <asp:Label ID="lblAmountText2_F4" Visible="false" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtAmount2_F4" runat="server" Visible="false" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this,12);" MaxLength="15"></asp:TextBox>
                                                        <asp:CompareValidator ID="cvAmount4" runat="server" ErrorMessage="Filter Criteria  4 - To Amount must be Greater Than or Equal To From Amount"
                                                            ControlToCompare="txtAmount1_F4" ControlToValidate="txtAmount2_F4" Operator="GreaterThanEqual"
                                                            Type="Currency" Display="None" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlText_F4" runat="server">
                                            <table>
                                                <tr>
                                                    <td width="40%">
                                                        <asp:DropDownList ID="drpText_F4" Width="106px" runat="server">
                                                            <asp:ListItem Text="Contains" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Start With" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="End With" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="60%">
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
                            <b>Filter 5 :</b>
                        </td>
                        <td>
                            <table cellpadding="2" cellspacing="1" width="100%" align="center">
                                <tr>
                                    <td style="width: 25%;" valign="top">
                                        <asp:DropDownList ID="drpFilter5" runat="server" AutoPostBack="True" Width="250px"
                                            OnSelectedIndexChanged="drpFilter_SelectedIndexChanged" onchange="Page_ClientValidate('dummy')">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 5%;" align="left" valign="top">
                                        <asp:CheckBox ID="chkNotCriteria5" runat="server" Text="Not" Visible="false" />
                                    </td>
                                    <td width="70%" align="left" valign="top">
                                        <asp:Panel ID="pnlDate_F5" runat="server">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="lstDate5" Width="106px"  EnableTheming="false" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="rdbLstDate_SelectedIndexChanged">
                                                            <asp:ListItem Text="On" Value="O" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                            <asp:ListItem Text="On or Before" Value="BF"></asp:ListItem>
                                                            <asp:ListItem Text="On or After" Value="A"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="11%">
                                                        <asp:Label ID="lblDateFrom5" runat="server" Text="On Date : "></asp:Label>
                                                    </td>
                                                    <td width="30%">
                                                        <asp:TextBox ID="txtDate_From5" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                                        <img alt="" id="imgDate_Opened_From5" onclick="return showCalendar('<%=txtDate_From5.ClientID%>', 'mm/dd/y','','');"
                                                            runat="server" onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL %>iconPicDate.gif'
                                                            align="middle" />
                                                        <asp:RegularExpressionValidator ID="revtxtDate_From5" runat="server" ValidationGroup="vsErrorGroup"
                                                            Display="none" ErrorMessage="Filter Criteria  5 - On Date is not a valid date"
                                                            SetFocusOnError="true" ControlToValidate="txtDate_From5" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        <uc:CtrlRelativeDates ID="ucRelativeDatesFrom_5" runat="server" strDateClientID="ctl00_ContentPlaceHolder1_txtDate_From5"
                                                            OnSetDate="RaltiveDatesSaveClick" />
                                                    </td>
                                                    <td style="width: 11%;">
                                                        <asp:Label ID="lblDateTo5" runat="server" Text="Start Date :"></asp:Label>
                                                    </td>
                                                    <td style="width: 30%;">
                                                        <asp:TextBox ID="txtDate_To5" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                                        <img alt="" id="imgDate_To5" runat="server" onclick="return showCalendar('<%=txtDate_To5.ClientID%>', 'mm/dd/y','','');"
                                                            onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL %>iconPicDate.gif'
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
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="drpAmount_F5" Width="106px" EnableTheming="false" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="drpAmount_F_SelectedIndexChanged">
                                                            <asp:ListItem Text="Equal" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Greater Than" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Less Than" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblAmountText1_F5" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtAmount1_F5" runat="server" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this,12);" MaxLength="15"></asp:TextBox>
                                                        <asp:Label ID="lblAmountText2_F5" Visible="false" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtAmount2_F5" runat="server" Visible="false" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this,12);" MaxLength="15"></asp:TextBox>
                                                        <asp:CompareValidator ID="cvAmount5" runat="server" ErrorMessage="Filter Criteria  5 - To Amount must be Greater Than or Equal To From Amount"
                                                            ControlToCompare="txtAmount1_F5" ControlToValidate="txtAmount2_F5" Operator="GreaterThanEqual"
                                                            Type="Currency" Display="None" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlText_F5" runat="server">
                                            <table>
                                                <tr>
                                                    <td width="40%">
                                                        <asp:DropDownList ID="drpText_F5" Width="106px" runat="server">
                                                            <asp:ListItem Text="Contains" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Start With" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="End With" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="60%">
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
                            <b>Filter 6 :</b>
                        </td>
                        <td>
                            <table cellpadding="2" cellspacing="1" width="100%" align="center">
                                <tr>
                                    <td style="width: 25%;" valign="top">
                                        <asp:DropDownList ID="drpFilter6" runat="server" AutoPostBack="True" Width="250px"
                                            OnSelectedIndexChanged="drpFilter_SelectedIndexChanged" onchange="Page_ClientValidate('dummy')">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 5%;" align="left" valign="top">
                                        <asp:CheckBox ID="chkNotCriteria6" runat="server" Text="Not" Visible="false" />
                                    </td>
                                    <td width="70%" align="left" valign="top">
                                        <asp:Panel ID="pnlDate_F6" runat="server">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="lstDate6" Width="106px"  EnableTheming="false" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="rdbLstDate_SelectedIndexChanged">
                                                            <asp:ListItem Text="On" Value="O" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                            <asp:ListItem Text="On or Before" Value="BF"></asp:ListItem>
                                                            <asp:ListItem Text="On or After" Value="A"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="11%">
                                                        <asp:Label ID="lblDateFrom6" runat="server" Text="On Date: "></asp:Label>
                                                    </td>
                                                    <td width="30%">
                                                        <asp:TextBox ID="txtDate_From6" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                                        <img alt="" id="imgDate_Opened_From6" onclick="return showCalendar('<%=txtDate_From6.ClientID%>', 'mm/dd/y','','');"
                                                            runat="server" onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL%>iconPicDate.gif'
                                                            align="middle" />
                                                        <asp:RegularExpressionValidator ID="revtxtDate_From6" runat="server" ValidationGroup="vsErrorGroup"
                                                            Display="none" ErrorMessage="Filter Criteria  6 - On Date is not a valid date"
                                                            SetFocusOnError="true" ControlToValidate="txtDate_From6" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        <uc:CtrlRelativeDates ID="ucRelativeDatesFrom_6" runat="server" strDateClientID="ctl00_ContentPlaceHolder1_txtDate_From6"
                                                            OnSetDate="RaltiveDatesSaveClick" />
                                                    </td>
                                                    <td style="width: 11%;">
                                                        <asp:Label ID="lblDateTo6" runat="server" Text="Start Date :"></asp:Label>
                                                    </td>
                                                    <td style="width: 30%;">
                                                        <asp:TextBox ID="txtDate_To6" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                                        <img alt="" id="imgDate_To6" runat="server" onclick="return showCalendar('<%=txtDate_To6.ClientID%>', 'mm/dd/y','','');"
                                                            onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL %>iconPicDate.gif'
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
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="drpAmount_F6" Width="106px" EnableTheming="false" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="drpAmount_F_SelectedIndexChanged">
                                                            <asp:ListItem Text="Equal" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Greater Than" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Less Than" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblAmountText1_F6" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtAmount1_F6" runat="server" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this,12);" MaxLength="15"></asp:TextBox>
                                                        <asp:Label ID="lblAmountText2_F6" Visible="false" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtAmount2_F6" runat="server" Visible="false" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this,12);" MaxLength="15"></asp:TextBox>
                                                        <asp:CompareValidator ID="cvAmount6" runat="server" ErrorMessage="Filter Criteria  6 - To Amount must be Greater Than or Equal To From Amount"
                                                            ControlToCompare="txtAmount1_F6" ControlToValidate="txtAmount2_F6" Operator="GreaterThanEqual"
                                                            Type="Currency" Display="None" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlText_F6" runat="server">
                                            <table>
                                                <tr>
                                                    <td width="40%">
                                                        <asp:DropDownList ID="drpText_F6" Width="106px" runat="server">
                                                            <asp:ListItem Text="Contains" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Start With" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="End With" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="60%">
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
                            <b>Filter 7 :</b>
                        </td>
                        <td>
                            <table cellpadding="2" cellspacing="1" width="100%" align="center">
                                <tr>
                                    <td style="width: 25%;" valign="top">
                                        <asp:DropDownList ID="drpFilter7" runat="server" AutoPostBack="True" Width="250px"
                                            OnSelectedIndexChanged="drpFilter_SelectedIndexChanged" onchange="Page_ClientValidate('dummy')">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 5%;" align="left" valign="top">
                                        <asp:CheckBox ID="chkNotCriteria7" runat="server" Text="Not" Visible="false" />
                                    </td>
                                    <td width="70%" align="left" valign="top">
                                        <asp:Panel ID="pnlDate_F7" runat="server">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="lstDate7" Width="106px"  EnableTheming="false" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="rdbLstDate_SelectedIndexChanged">
                                                            <asp:ListItem Text="On" Value="O" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                            <asp:ListItem Text="On or Before" Value="BF"></asp:ListItem>
                                                            <asp:ListItem Text="On or After" Value="A"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="11%">
                                                        <asp:Label ID="lblDateFrom7" runat="server" Text="On Date : "></asp:Label>
                                                    </td>
                                                    <td width="30%">
                                                        <asp:TextBox ID="txtDate_From7" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                                        <img alt="" id="imgDate_Opened_From7" onclick="return showCalendar('<%=txtDate_From7.ClientID%>', 'mm/dd/y','','');"
                                                            runat="server" onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL%>iconPicDate.gif'
                                                            align="middle" />
                                                        <asp:RegularExpressionValidator ID="revtxtDate_From7" runat="server" ValidationGroup="vsErrorGroup"
                                                            Display="none" ErrorMessage="Filter Criteria  7 - On Date is not a valid date"
                                                            SetFocusOnError="true" ControlToValidate="txtDate_From7" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        <uc:CtrlRelativeDates ID="ucRelativeDatesFrom_7" runat="server" strDateClientID="ctl00_ContentPlaceHolder1_txtDate_From7"
                                                            OnSetDate="RaltiveDatesSaveClick" />
                                                    </td>
                                                    <td style="width: 11%;">
                                                        <asp:Label ID="lblDateTo7" runat="server" Text="Start Date :"></asp:Label>
                                                    </td>
                                                    <td style="width: 30%;">
                                                        <asp:TextBox ID="txtDate_To7" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                                        <img alt="" id="imgDate_To7" runat="server" onclick="return showCalendar('<%=txtDate_To7.ClientID%>', 'mm/dd/y','','');"
                                                            onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL %>iconPicDate.gif'
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
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="drpAmount_F7" Width="106px" EnableTheming="false" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="drpAmount_F_SelectedIndexChanged">
                                                            <asp:ListItem Text="Equal" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Greater Than" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Less Than" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblAmountText1_F7" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtAmount1_F7" runat="server" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this,12);" MaxLength="15"></asp:TextBox>
                                                        <asp:Label ID="lblAmountText2_F7" Visible="false" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtAmount2_F7" runat="server" Visible="false" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this,12);" MaxLength="15"></asp:TextBox>
                                                        <asp:CompareValidator ID="cvAmount7" runat="server" ErrorMessage="Filter Criteria  7 - To Amount must be Greater Than or Equal To From Amount"
                                                            ControlToCompare="txtAmount1_F7" ControlToValidate="txtAmount2_F7" Operator="GreaterThanEqual"
                                                            Type="Currency" Display="None" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlText_F7" runat="server">
                                            <table>
                                                <tr>
                                                    <td width="40%">
                                                        <asp:DropDownList ID="drpText_F7" Width="106px" runat="server">
                                                            <asp:ListItem Text="Contains" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Start With" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="End With" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="60%">
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
                            <b>Filter 8 :</b>
                        </td>
                        <td>
                            <table cellpadding="2" cellspacing="1" width="100%" align="center">
                                <tr>
                                    <td style="width: 25%;" valign="top">
                                        <asp:DropDownList ID="drpFilter8" runat="server" AutoPostBack="True" Width="250px"
                                            OnSelectedIndexChanged="drpFilter_SelectedIndexChanged" onchange="Page_ClientValidate('dummy')">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 5%;" align="left" valign="top">
                                        <asp:CheckBox ID="chkNotCriteria8" runat="server" Text="Not" Visible="false" />
                                    </td>
                                    <td width="70%" align="left" valign="top">
                                        <asp:Panel ID="pnlDate_F8" runat="server">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="lstDate8" Width="106px" EnableTheming="false" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="rdbLstDate_SelectedIndexChanged">
                                                            <asp:ListItem Text="On" Value="O" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                            <asp:ListItem Text="On or Before" Value="BF"></asp:ListItem>
                                                            <asp:ListItem Text="On or After" Value="A"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="11%">
                                                        <asp:Label ID="lblDateFrom8" runat="server" Text="On Date : "></asp:Label>
                                                    </td>
                                                    <td width="30%">
                                                        <asp:TextBox ID="txtDate_From8" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                                        <img alt="" id="imgDate_Opened_From8" onclick="return showCalendar('<%=txtDate_From8.ClientID%>', 'mm/dd/y','','');"
                                                            runat="server" onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL%>iconPicDate.gif'
                                                            align="middle" />
                                                        <asp:RegularExpressionValidator ID="revtxtDate_From8" runat="server" ValidationGroup="vsErrorGroup"
                                                            Display="none" ErrorMessage="Filter Criteria  8 - On Date is not a valid date"
                                                            SetFocusOnError="true" ControlToValidate="txtDate_From8" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        <uc:CtrlRelativeDates ID="ucRelativeDatesFrom_8" runat="server" strDateClientID="ctl00_ContentPlaceHolder1_txtDate_From8"
                                                            OnSetDate="RaltiveDatesSaveClick" />
                                                    </td>
                                                    <td style="width: 11%;">
                                                        <asp:Label ID="lblDateTo8" runat="server" Text="Start Date :"></asp:Label>
                                                    </td>
                                                    <td style="width: 30%;">
                                                        <asp:TextBox ID="txtDate_To8" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                                        <img alt="" id="imgDate_To8" runat="server" onclick="return showCalendar('<%=txtDate_To8.ClientID%>', 'mm/dd/y','','');"
                                                            onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL %>iconPicDate.gif'
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
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="drpAmount_F8" Width="106px" EnableTheming="false" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="drpAmount_F_SelectedIndexChanged">
                                                            <asp:ListItem Text="Equal" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Greater Than" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Less Than" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblAmountText1_F8" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtAmount1_F8" runat="server" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this,12);" MaxLength="15"></asp:TextBox>
                                                        <asp:Label ID="lblAmountText2_F8" Visible="false" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtAmount2_F8" runat="server" Visible="false" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this,12);" MaxLength="15"></asp:TextBox>
                                                        <asp:CompareValidator ID="cvAmount8" runat="server" ErrorMessage="Filter Criteria  8 - To Amount must be Greater Than or Equal To From Amount"
                                                            ControlToCompare="txtAmount1_F8" ControlToValidate="txtAmount2_F8" Operator="GreaterThanEqual"
                                                            Type="Currency" Display="None" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlText_F8" runat="server">
                                            <table>
                                                <tr>
                                                    <td width="40%">
                                                        <asp:DropDownList ID="drpText_F8" Width="106px" runat="server">
                                                            <asp:ListItem Text="Contains" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Start With" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="End With" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="60%">
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
                            <b>Filter 9 :</b>
                        </td>
                        <td>
                            <table cellpadding="2" cellspacing="1" width="100%" align="center">
                                <tr>
                                    <td style="width: 25%;" valign="top">
                                        <asp:DropDownList ID="drpFilter9" runat="server" AutoPostBack="True" Width="250px"
                                            OnSelectedIndexChanged="drpFilter_SelectedIndexChanged" onchange="Page_ClientValidate('dummy')">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 5%;" align="left" valign="top">
                                        <asp:CheckBox ID="chkNotCriteria9" runat="server" Text="Not" Visible="false" />
                                    </td>
                                    <td width="70%" align="left" valign="top">
                                        <asp:Panel ID="pnlDate_F9" runat="server">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="lstDate9" Width="106px"  EnableTheming="false" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="rdbLstDate_SelectedIndexChanged">
                                                            <asp:ListItem Text="On" Value="O" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                            <asp:ListItem Text="On or Before" Value="BF"></asp:ListItem>
                                                            <asp:ListItem Text="On or After" Value="A"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="11%">
                                                        <asp:Label ID="lblDateFrom9" runat="server" Text="On Date : "></asp:Label>
                                                    </td>
                                                    <td width="30%">
                                                        <asp:TextBox ID="txtDate_From9" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                                        <img alt="" id="imgDate_Opened_From9" onclick="return showCalendar('<%=txtDate_From9.ClientID%>','mm/dd/y','','');"
                                                            runat="server" onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL %>iconPicDate.gif'
                                                            align="middle" />
                                                        <asp:RegularExpressionValidator ID="revtxtDate_From9" runat="server" ValidationGroup="vsErrorGroup"
                                                            Display="none" ErrorMessage="Filter Criteria  9 - On Date is not a valid date"
                                                            SetFocusOnError="true" ControlToValidate="txtDate_From9" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        <uc:CtrlRelativeDates ID="ucRelativeDatesFrom_9" runat="server" strDateClientID="ctl00_ContentPlaceHolder1_txtDate_From9"
                                                            OnSetDate="RaltiveDatesSaveClick" />
                                                    </td>
                                                    <td style="width: 11%;">
                                                        <asp:Label ID="lblDateTo9" runat="server" Text="Start Date :"></asp:Label>
                                                    </td>
                                                    <td style="width: 30%;">
                                                        <asp:TextBox ID="txtDate_To9" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                                        <img alt="" id="imgDate_To9" runat="server" onclick="return showCalendar('<%=txtDate_To9.ClientID%>', 'mm/dd/y','','');"
                                                            onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL %>iconPicDate.gif'
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
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="drpAmount_F9" Width="106px" EnableTheming="false" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="drpAmount_F_SelectedIndexChanged">
                                                            <asp:ListItem Text="Equal" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Greater Than" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Less Than" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblAmountText1_F9" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtAmount1_F9" runat="server" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this,12);" MaxLength="15"></asp:TextBox>
                                                        <asp:Label ID="lblAmountText2_F9" Visible="false" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtAmount2_F9" runat="server" Visible="false" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this,12);" MaxLength="15"></asp:TextBox>
                                                        <asp:CompareValidator ID="cvAmount9" runat="server" ErrorMessage="Filter Criteria  9 - To Amount must be Greater Than or Equal To From Amount"
                                                            ControlToCompare="txtAmount1_F9" ControlToValidate="txtAmount2_F9" Operator="GreaterThanEqual"
                                                            Type="Currency" Display="None" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlText_F9" runat="server">
                                            <table>
                                                <tr>
                                                    <td width="40%">
                                                        <asp:DropDownList ID="drpText_F9" Width="106px" runat="server">
                                                            <asp:ListItem Text="Contains" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Start With" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="End With" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="60%">
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
                            <b>Filter 10 :</b>
                        </td>
                        <td>
                            <table cellpadding="2" cellspacing="1" width="100%" align="center">
                                <tr>
                                    <td style="width: 25%;" valign="top">
                                        <asp:DropDownList ID="drpFilter10" runat="server" AutoPostBack="True" Width="250px"
                                            OnSelectedIndexChanged="drpFilter_SelectedIndexChanged" onchange="Page_ClientValidate('dummy')">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 5%;" align="left" valign="top">
                                        <asp:CheckBox ID="chkNotCriteria10" runat="server" Text="Not" Visible="false" />
                                    </td>
                                    <td width="70%" align="left" valign="top">
                                        <asp:Panel ID="pnlDate_F10" runat="server">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="lstDate10" Width="106px"  EnableTheming="false" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="rdbLstDate_SelectedIndexChanged">
                                                            <asp:ListItem Text="On" Value="O" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                            <asp:ListItem Text="On or Before" Value="BF"></asp:ListItem>
                                                            <asp:ListItem Text="On or After" Value="A"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="11%">
                                                        <asp:Label ID="lblDateFrom10" runat="server" Text="On Date : "></asp:Label>
                                                    </td>
                                                    <td width="30%">
                                                        <asp:TextBox ID="txtDate_From10" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                                        <img alt="" id="imgDate_Opened_From10" onclick="return showCalendar('<%=txtDate_From10.ClientID%>',    'mm/dd/y','','');"
                                                            runat="server" onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL%>iconPicDate.gif'
                                                            align="middle" />
                                                        <asp:RegularExpressionValidator ID="revtxtDate_From10" runat="server" ValidationGroup="vsErrorGroup"
                                                            Display="none" ErrorMessage="Filter Criteria  10 - On Date is not a valid date"
                                                            SetFocusOnError="true" ControlToValidate="txtDate_From10" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        <uc:CtrlRelativeDates ID="ucRelativeDatesFrom_10" runat="server" strDateClientID="ctl00_ContentPlaceHolder1_txtDate_From10"
                                                            OnSetDate="RaltiveDatesSaveClick" />
                                                    </td>
                                                    <td style="width: 11%;">
                                                        <asp:Label ID="lblDateTo10" runat="server" Text="Start Date :"></asp:Label>
                                                    </td>
                                                    <td style="width: 30%;">
                                                        <asp:TextBox ID="txtDate_To10" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                                        <img alt="" id="imgDate_To10" runat="server" onclick="return showCalendar('<%=txtDate_To10.ClientID%>', 'mm/dd/y','','');"
                                                            onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL %>iconPicDate.gif'
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
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="drpAmount_F10" Width="106px" EnableTheming="false" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="drpAmount_F_SelectedIndexChanged">
                                                            <asp:ListItem Text="Equal" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Greater Than" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Less Than" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblAmountText1_F10" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtAmount1_F10" runat="server" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this,12);" MaxLength="15"></asp:TextBox>
                                                        <asp:Label ID="lblAmountText2_F10" Visible="false" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtAmount2_F10" runat="server" Visible="false" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                            onblur="javascript:return formatCurrencyOnBlur(this,12);" MaxLength="15"></asp:TextBox>
                                                        <asp:CompareValidator ID="cvAmount10" runat="server" ErrorMessage="Filter Criteria  10 - To Amount must be Greater Than or Equal To From Amount"
                                                            ControlToCompare="txtAmount1_F10" ControlToValidate="txtAmount2_F10" Operator="GreaterThanEqual"
                                                            Type="Currency" Display="None" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlText_F10" runat="server">
                                            <table>
                                                <tr>
                                                    <td width="40%">
                                                        <asp:DropDownList ID="drpText_F10" Width="106px" runat="server">
                                                            <asp:ListItem Text="Contains" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Start With" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="End With" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="60%">
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
                                    Width="245px"></asp:TextBox><span class="mf">*</span>
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
                                    OnSelectedIndexChanged="ddlReports_SelectedIndexChanged" Width="250px" onchange="SaveScrollPositions();AskfForLogoff=false;Page_ClientValidate('dummy');">
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
                <td align="center">
                    <%--<uc:AdHocDistribution ID="CtrlDistribution" runat="server" App_Access="Administrative_Access"
                        OnReportDistributionSaveClick="ReportDistributionSaveClick" />--%>
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
                        OnClientClick="javascript:OPenSchedulePopup();return false;" ToolTip="Schedule Report" />
                    <asp:HiddenField ID="hdnScheduleID" runat="server" Value="0" />
                    <asp:Button ID="btnHdnScheduling" runat="server" OnClick="btnHdnScheduling_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                        Visible="false" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
