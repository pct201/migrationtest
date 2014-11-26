<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Business_Rule_Management.aspx.cs"
    Inherits="Administrator_Business_Rule_Management" MaintainScrollPositionOnPostback="true" %>

<%@ Register Src="~/Controls/Notes/Notes.ascx" TagPrefix="uc1" TagName="ctrlMultiLineTextBox" %>
<%@ Register Src="~/Controls/RelativeDate/RelativeDate_Business_Rule.ascx" TagPrefix="uc"
    TagName="CtrlRelativeDates" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src='<%=AppConfig.SiteURL %>JavaScript/JFunctions.js'></script>
    <script type="text/javascript" language="javascript" src='<%=AppConfig.SiteURL %>JavaScript/Calendar_new.js'></script>
    <script type="text/javascript" language="javascript" src='<%=AppConfig.SiteURL %>JavaScript/calendar-en.js'></script>
    <script type="text/javascript" language="javascript" src='<%=AppConfig.SiteURL %>JavaScript/Calendar.js'></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL %>JavaScript/Validator.js"></script>
    <link href="<%=AppConfig.SiteURL%>greybox/gb_styles.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        var GB_ROOT_DIR = '<%=AppConfig.SiteURL%>' + 'greybox/';
        function ConfirmDelete() {
            if (confirm("Are you sure that you want to delete the selected information and all of its subordinate data (if exists)?")) {
                SaveScrollPositions();
                return true;
            }
            else return false;
        }
        function validateRecipient(obj,arg) {
            var checkBoxList = document.getElementById('<%=chkEmailFields.ClientID %>');
            var txtRecipient = document.getElementById('<%=txtIAssignTo.ClientID %>');
            var returnVal = false;           
            if (checkBoxList != null) {
                var numCheckBoxItems = checkBoxList.cells.length;
                if (numCheckBoxItems > 0) {
                    for (i = 0; i < numCheckBoxItems; i++) {
                        //Get the checkboxlist item
                        var checkBox = document.getElementById(checkBoxList.id + '_' + [i]);
                        //Check if the checkboxlist item exists, and if it is checked
                        if (checkBox != null && checkBox.checked) { returnVal = true; }
                    }
                }
                else {
                    if (txtRecipient.value != '')
                        returnVal = true;
                }
            }
            else {
                if (txtRecipient.value != '')
                    returnVal = true;
            }
            if (!returnVal) {
                if (txtRecipient.value != '')
                    returnVal = true;
            }
            arg.IsValid = returnVal;
            return returnVal;                    
        }
        function FilterValidation() {

            if (Page_ClientValidate('vsErrorGroup')) {
                if ((document.getElementById('ctl00_ContentPlaceHolder1_drpFilter1').selectedIndex > 0) || (document.getElementById('ctl00_ContentPlaceHolder1_drpFilter2').selectedIndex > 0) || (document.getElementById('ctl00_ContentPlaceHolder1_drpFilter3').selectedIndex > 0) || (document.getElementById('ctl00_ContentPlaceHolder1_drpFilter4').selectedIndex > 0) || (document.getElementById('ctl00_ContentPlaceHolder1_drpFilter5').selectedIndex > 0)) {
                    if (document.getElementById('ctl00_ContentPlaceHolder1_drpAction_Type').value == 'Update') {
                        if (Page_ClientValidate('vsErrorGroupUpdate'))
                            return true;
                        else {
                            Page_ClientValidate('dummy');
                            return false;
                        }

                    }
                    else if (document.getElementById('ctl00_ContentPlaceHolder1_drpAction_Type').value == 'Email') {
                        if (Page_ClientValidate('vsErrorGroupEmail')) {
                            return true;
                        }
                        else {
                            Page_ClientValidate('dummy');
                            return false;
                        }
                    }
                    else if (document.getElementById('ctl00_ContentPlaceHolder1_drpAction_Type').value == 'Diary') {
                        if (Page_ClientValidate('vsErrorGroupDiary'))
                            return true;
                        else {
                            Page_ClientValidate('dummy');
                            return false;
                        }
                    }
                    else {
                        Page_ClientValidate('dummy');
                        return false;
                    }
                }
                else {
                    alert('Please select the filter criteria for at least one field.');
                    return false;
                }
            }
            else
                return false;
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
        function openPopUp() {
            oWnd = window.open("RecipientPopUp.aspx?list=" + document.getElementById('ctl00_ContentPlaceHolder1_txtIAssignToID').value, "Erims", "location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=470");
            oWnd.moveTo(260, 180);
            return false;
        }
        function openPopUpDiary() {
            oWnd = window.open("LDiaryUser.aspx", "Erims", "location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=300");
            oWnd.moveTo(260, 180);
            return false;
        }

        function CheckUncheckContacts() {
            var ctrls = document.getElementById('<%=chkContactFields.ClientID%>').getElementsByTagName("input");
            var cnt = 0;
            for (var i = 0; i < ctrls.length; i++) {
                if (ctrls[i].checked) {
                    cnt++;
                }
            }
            if (cnt > 0 && document.getElementById('<%=chkCurrentUser.ClientID%>').checked) {
                alert("Please select either Current User or Assigned Contact");
                return false;
            }
            else
                return true;
        }

        function formatCurrencyOnBlur(ctrl) {
            if (ctrl.value != '') {
                var val = ctrl.value.replace(",", "").replace(",", "");
                ctrl.value = formatCurrency(val).replace("$", "");
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
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="vsErrorGroupEmail"
        BorderColor="DimGray" BorderWidth="1" HeaderText="Verify the following fields:"
        ShowMessageBox="true" ShowSummary="false"></asp:ValidationSummary>
    <asp:ValidationSummary ID="ValidationSummary4" runat="server" ValidationGroup="vsErrorGroupEmailRecipient"
        BorderColor="DimGray" BorderWidth="1" HeaderText="Verify the following fields:"
        ShowMessageBox="true" ShowSummary="false"></asp:ValidationSummary>
    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="vsErrorGroupUpdate"
        BorderColor="DimGray" BorderWidth="1" HeaderText="Verify the following fields:"
        ShowMessageBox="true" ShowSummary="false"></asp:ValidationSummary>
    <asp:ValidationSummary ID="ValidationSummary3" runat="server" ValidationGroup="vsErrorGroupDiary"
        BorderColor="DimGray" BorderWidth="1" HeaderText="Verify the following fields:"
        ShowMessageBox="true" ShowSummary="false"></asp:ValidationSummary>
    <div class="bandHeaderRow">
        Business Rule Management</div>
    <asp:Panel ID="pnl_Container" runat="server">
        <%--<asp:UpdatePanel ID="upOutput" runat="server" RenderMode="Inline" UpdateMode="Conditional">--%>
        <%--<ContentTemplate>--%>
        <table width="100%" cellpadding="4" cellspacing="2">
            <tr>
                <td width="15%">
                    Select Module<span class="mf">*</span>
                </td>
                <td valign="top" width="4%">
                    :
                </td>
                <td>
                    <asp:DropDownList ID="drpModule" runat="server" AutoPostBack="True" Width="350px" EnableTheming="false"
                        OnSelectedIndexChanged="drpModule_SelectedIndexChanged" onchange="Page_ClientValidate('dummy');">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvModule" runat="server" InitialValue="0" ValidationGroup="vsErrorGroup"
                        ErrorMessage="Please Select Module" Display="None" ControlToValidate="drpModule"
                        SetFocusOnError="true" />
                </td>
            </tr>
            <tr>
                <td width="15%">
                    Select Screen<span class="mf">*</span>
                </td>
                <td valign="top" width="4%">
                    :
                </td>
                <td>
                    <asp:DropDownList ID="drpScreen" runat="server" AutoPostBack="True" Width="350px" EnableTheming="false"
                        OnSelectedIndexChanged="drpScreen_SelectedIndexChanged" onchange="Page_ClientValidate('dummy');">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvScreen" runat="server" InitialValue="0" ValidationGroup="vsErrorGroup"
                        ErrorMessage="Please Select Screen" Display="None" ControlToValidate="drpScreen"
                        SetFocusOnError="true" />
                </td>
            </tr>
        </table>
        <%--</ContentTemplate>
            <Triggers>
            </Triggers>--%>
        <%-- </asp:UpdatePanel>--%>
        <%--<asp:UpdatePanel ID="upFilter" runat="server" RenderMode="Inline" UpdateMode="Always">--%>
        <%--<ContentTemplate>--%>
        <table width="100%" cellpadding="4" cellspacing="2">
            <tr>
                <td colspan="3" class="bandHeaderRow">
                    Rule
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <table width="100%">
                        <tr>
                            <td valign="top" width="15%">
                                Rule Name<span class="mf">*</span> &nbsp;
                            </td>
                            <td valign="top" width="4%">
                                :
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtRuleName" MaxLength="250"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvRuleName" runat="server" ValidationGroup="vsErrorGroup"
                                    SetFocusOnError="true" ErrorMessage="Please Enter Rule Name" Display="none" ControlToValidate="txtRuleName"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                Description&nbsp;
                            </td>
                            <td valign="top" width="4%">
                                :
                            </td>
                            <td>
                                <uc1:ctrlMultiLineTextBox ID="txtDescription" Rows="5" runat="server" ValidationGroup="AddAttachment"
                                    MaxLength="2000" onkeypress="javascript:return CheckMaxLength(e,this,2000);" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="3" class="bandHeaderRow">
                    Rule Criteria
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <table width="100%">
                        <tr>
                            <td valign="top" width="5%">
                                Field 1 :
                            </td>
                            <td>
                                <table cellpadding="2" cellspacing="1" width="100%" align="center">
                                    <tr>
                                        <td style="width: 22%;" valign="top">
                                            <asp:DropDownList ID="drpFilter1" runat="server" AutoPostBack="True" Width="250px" EnableTheming="false"
                                                OnSelectedIndexChanged="drpFilter_SelectedIndexChanged" onchange="AskfForLogoff=false;Page_ClientValidate('dummy')">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 5%;" align="left" valign="top">
                                            <asp:CheckBox ID="chkNotCriteria1" runat="server" Text="Not" Visible="false" />
                                        </td>
                                        <td width="70%" align="left" valign="top">
                                            <asp:Panel ID="pnlDate_F1" runat="server">
                                                <table width="100%">
                                                    <tr>
                                                        <td valign="top">
                                                            <asp:DropDownList Width="106px" ID="lstDate1" runat="server" AutoPostBack="true" EnableTheming="false"
                                                                OnSelectedIndexChanged="rdbLstDate_SelectedIndexChanged" onchange="Page_ClientValidate('dummy');">
                                                                <asp:ListItem Text="On" Value="O" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                                <asp:ListItem Text="On or Before" Value="BF"></asp:ListItem>
                                                                <asp:ListItem Text="On or After" Value="A"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td width="11%" nowrap="nowrap" valign="top">
                                                            <asp:Label ID="lblDateFrom1" runat="server" Text="On Date : "></asp:Label>
                                                        </td>
                                                        <td width="30%" valign="top">
                                                            <asp:TextBox ID="txtDate_From1" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                                            <img alt="" id="imgDate_Opened_From1" onclick="return showCalendar('<%=txtDate_From1.ClientID%>', 'mm/dd/y','','');"
                                                                runat="server" onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL %>iconPicDate.gif'
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
                                                                onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL %>iconPicDate.gif'
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
                                                            <asp:DropDownList ID="drpAmount_F1" Width="150px" runat="server" AutoPostBack="true" EnableTheming="false"
                                                                OnSelectedIndexChanged="drpAmount_F_SelectedIndexChanged" onchange="Page_ClientValidate('dummy');">
                                                                <asp:ListItem Text="Equal" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="Greater Than" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Greater Than or Equal to" Value="4"></asp:ListItem>
                                                                <asp:ListItem Text="Between" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="Less Than" Value="3"></asp:ListItem>
                                                                <asp:ListItem Text="Less Than or Equal to" Value="5"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
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
                                            <asp:Panel ID="pnlNumber_F1" runat="server">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="drpNumber_F1" Width="150px" runat="server" AutoPostBack="true" EnableTheming="false"
                                                                OnSelectedIndexChanged="drpNumber_F_SelectedIndexChanged" onchange="Page_ClientValidate('dummy');">
                                                                <asp:ListItem Text="Equal" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="Greater Than" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Greater Than or Equal to" Value="4"></asp:ListItem>
                                                                <asp:ListItem Text="Between" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="Less Than" Value="3"></asp:ListItem>
                                                                <asp:ListItem Text="Less Than or Equal to" Value="5"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblNumberText1_F1" runat="server"></asp:Label>
                                                            <asp:TextBox ID="txtNumber1_F1" runat="server" onkeypress="return numberOnly(this);"></asp:TextBox>
                                                            <asp:Label ID="lblNumberText2_F1" Visible="false" runat="server"></asp:Label>
                                                            <asp:TextBox ID="txtNumber2_F1" runat="server" Visible="false" onkeypress="return numberOnly(this);"></asp:TextBox>
                                                            <asp:CompareValidator ID="cvNumber1" runat="server" ErrorMessage="Filter Criteria  1 - To Number must be Greater Than or Equal To From Number"
                                                                ControlToCompare="txtNumber1_F1" ControlToValidate="txtNumber2_F1" Operator="GreaterThanEqual"
                                                                Type="Currency" Display="None" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlText_F1" runat="server">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="drpText_F1" Width="106px" runat="server" EnableTheming="false">
                                                                <asp:ListItem Text="Contains" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Starts With" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="Ends With" Value="3"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtFilter1" runat="server" Width="216px" MaxLength="50"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                        <td valign="top">
                                            <span id="spnField1" runat="server" visible="false">AND</span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" width="5%">
                                Field 2 :
                            </td>
                            <td>
                                <table cellpadding="2" cellspacing="1" width="100%" align="center">
                                    <tr>
                                        <td style="width: 22%;" valign="top">
                                            <asp:DropDownList ID="drpFilter2" runat="server" AutoPostBack="True" Width="250px" EnableTheming="false"
                                                OnSelectedIndexChanged="drpFilter_SelectedIndexChanged" onchange="AskfForLogoff=false;Page_ClientValidate('dummy')">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 5%;" align="left" valign="top">
                                            <asp:CheckBox ID="chkNotCriteria2" runat="server" Text="Not" Visible="false" />
                                        </td>
                                        <td width="70%" align="left" valign="top">
                                            <asp:Panel ID="pnlDate_F2" runat="server">
                                                <table width="100%">
                                                    <tr>
                                                        <td valign="top">
                                                            <asp:DropDownList ID="lstDate2" Width="106px" runat="server" AutoPostBack="true" EnableTheming="false"
                                                                OnSelectedIndexChanged="rdbLstDate_SelectedIndexChanged" onchange="Page_ClientValidate('dummy');">
                                                                <asp:ListItem Text="On" Value="O" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                                <asp:ListItem Text="On or Before" Value="BF"></asp:ListItem>
                                                                <asp:ListItem Text="On or After" Value="A"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td width="11%" valign="top">
                                                            <asp:Label ID="lblDateFrom2" runat="server" Text="On Date : "></asp:Label>
                                                        </td>
                                                        <td width="30%" valign="top">
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
                                                        <td style="width: 11%;" valign="top">
                                                            <asp:Label ID="lblDateTo2" runat="server" Text="Start Date :"></asp:Label>
                                                        </td>
                                                        <td style="width: 30%;" valign="top">
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
                                                            <asp:DropDownList ID="drpAmount_F2" Width="150px" runat="server" AutoPostBack="true" EnableTheming="false"
                                                                OnSelectedIndexChanged="drpAmount_F_SelectedIndexChanged" onchange="Page_ClientValidate('dummy');">
                                                                <asp:ListItem Text="Equal" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="Greater Than" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Greater Than or Equal to" Value="4"></asp:ListItem>
                                                                <asp:ListItem Text="Between" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="Less Than" Value="3"></asp:ListItem>
                                                                <asp:ListItem Text="Less Than or Equal to" Value="5"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
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
                                            <asp:Panel ID="pnlNumber_F2" runat="server">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="drpNumber_F2" Width="150px" runat="server" AutoPostBack="true" EnableTheming="false"
                                                                OnSelectedIndexChanged="drpNumber_F_SelectedIndexChanged" onchange="Page_ClientValidate('dummy');">
                                                                <asp:ListItem Text="Equal" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="Greater Than" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Greater Than or Equal to" Value="4"></asp:ListItem>
                                                                <asp:ListItem Text="Between" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="Less Than" Value="3"></asp:ListItem>
                                                                <asp:ListItem Text="Less Than or Equal to" Value="5"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblNumberText1_F2" runat="server"></asp:Label>
                                                            <asp:TextBox ID="txtNumber1_F2" runat="server" onkeypress="return numberOnly(this);"></asp:TextBox>
                                                            <asp:Label ID="lblNumberText2_F2" Visible="false" runat="server"></asp:Label>
                                                            <asp:TextBox ID="txtNumber2_F2" runat="server" Visible="false" onkeypress="return numberOnly(this);"></asp:TextBox>
                                                            <asp:CompareValidator ID="cvNumber2" runat="server" ErrorMessage="Filter Criteria  2 - To Number must be Greater Than or Equal To From Number"
                                                                ControlToCompare="txtNumber1_F2" ControlToValidate="txtNumber2_F2" Operator="GreaterThanEqual"
                                                                Type="Currency" Display="None" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlText_F2" runat="server">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="drpText_F2" Width="106px" runat="server" EnableTheming="false">
                                                                <asp:ListItem Text="Contains" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Starts With" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="Ends With" Value="3"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtFilter2" runat="server" Width="216px" MaxLength="50"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                        <td valign="top">
                                            <span id="spnField2" runat="server" visible="false">AND</span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" width="5%">
                                Field 3 :
                            </td>
                            <td>
                                <table cellpadding="2" cellspacing="1" width="100%" align="center">
                                    <tr>
                                        <td style="width: 22%;" valign="top">
                                            <asp:DropDownList ID="drpFilter3" runat="server" AutoPostBack="True" Width="250px" EnableTheming="false"
                                                OnSelectedIndexChanged="drpFilter_SelectedIndexChanged" onchange="AskfForLogoff=false;Page_ClientValidate('dummy')">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 5%;" align="left" valign="top">
                                            <asp:CheckBox ID="chkNotCriteria3" runat="server" Text="Not" Visible="false" />
                                        </td>
                                        <td width="70%" align="left" valign="top">
                                            <asp:Panel ID="pnlDate_F3" runat="server">
                                                <table width="100%">
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="lstDate3" Width="106px" runat="server" AutoPostBack="true" EnableTheming="false"
                                                                OnSelectedIndexChanged="rdbLstDate_SelectedIndexChanged" onchange="Page_ClientValidate('dummy');">
                                                                <asp:ListItem Text="On" Value="O" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                                <asp:ListItem Text="On or Before" Value="BF"></asp:ListItem>
                                                                <asp:ListItem Text="On or After" Value="A"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td width="11%" valign="top">
                                                            <asp:Label ID="lblDateFrom3" runat="server" Text="On Date : "></asp:Label>
                                                        </td>
                                                        <td width="30%" valign="top">
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
                                                        <td style="width: 11%;" valign="top">
                                                            <asp:Label ID="lblDateTo3" runat="server" Text="Start Date :"></asp:Label>
                                                        </td>
                                                        <td style="width: 30%;" valign="top">
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
                                                            <asp:DropDownList ID="drpAmount_F3" Width="150px" runat="server" AutoPostBack="true" EnableTheming="false"
                                                                OnSelectedIndexChanged="drpAmount_F_SelectedIndexChanged" onchange="Page_ClientValidate('dummy');">
                                                                <asp:ListItem Text="Equal" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="Greater Than" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Greater Than or Equal to" Value="4"></asp:ListItem>
                                                                <asp:ListItem Text="Between" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="Less Than" Value="3"></asp:ListItem>
                                                                <asp:ListItem Text="Less Than or Equal to" Value="5"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
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
                                            <asp:Panel ID="pnlNumber_F3" runat="server">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="drpNumber_F3" Width="150px" runat="server" AutoPostBack="true" EnableTheming="false"
                                                                OnSelectedIndexChanged="drpNumber_F_SelectedIndexChanged" onchange="Page_ClientValidate('dummy');">
                                                                <asp:ListItem Text="Equal" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="Greater Than" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Greater Than or Equal to" Value="4"></asp:ListItem>
                                                                <asp:ListItem Text="Between" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="Less Than" Value="3"></asp:ListItem>
                                                                <asp:ListItem Text="Less Than or Equal to" Value="5"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblNumberText1_F3" runat="server"></asp:Label>
                                                            <asp:TextBox ID="txtNumber1_F3" runat="server" onkeypress="return numberOnly(this);"></asp:TextBox>
                                                            <asp:Label ID="lblNumberText2_F3" Visible="false" runat="server"></asp:Label>
                                                            <asp:TextBox ID="txtNumber2_F3" runat="server" Visible="false" onkeypress="return numberOnly(this);"></asp:TextBox>
                                                            <asp:CompareValidator ID="cvNumber3" runat="server" ErrorMessage="Filter Criteria  3 - To Number must be Greater Than or Equal To From Number"
                                                                ControlToCompare="txtNumber1_F3" ControlToValidate="txtNumber2_F3" Operator="GreaterThanEqual"
                                                                Type="Currency" Display="None" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlText_F3" runat="server">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="drpText_F3" Width="106px" runat="server" EnableTheming="false">
                                                                <asp:ListItem Text="Contains" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Starts With" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="Ends With" Value="3"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtFilter3" runat="server" Width="216px" MaxLength="50"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                        <td valign="top">
                                            <span id="spnField3" runat="server" visible="false">AND</span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" width="5%">
                                Field 4 :
                            </td>
                            <td>
                                <table cellpadding="2" cellspacing="1" width="100%" align="center">
                                    <tr>
                                        <td style="width: 22%;" valign="top">
                                            <asp:DropDownList ID="drpFilter4" runat="server" AutoPostBack="True" Width="250px" EnableTheming="false"
                                                OnSelectedIndexChanged="drpFilter_SelectedIndexChanged" onchange="AskfForLogoff=false;Page_ClientValidate('dummy')">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 5%;" align="left" valign="top">
                                            <asp:CheckBox ID="chkNotCriteria4" runat="server" Text="Not" Visible="false" />
                                        </td>
                                        <td width="70%" align="left" valign="top">
                                            <asp:Panel ID="pnlDate_F4" runat="server">
                                                <table width="100%">
                                                    <tr>
                                                        <td valign="top">
                                                            <asp:DropDownList ID="lstDate4" Width="106px" runat="server" AutoPostBack="true" EnableTheming="false"
                                                                OnSelectedIndexChanged="rdbLstDate_SelectedIndexChanged" onchange="Page_ClientValidate('dummy');">
                                                                <asp:ListItem Text="On" Value="O" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                                <asp:ListItem Text="On or Before" Value="BF"></asp:ListItem>
                                                                <asp:ListItem Text="On or After" Value="A"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td width="11%" valign="top">
                                                            <asp:Label ID="lblDateFrom4" runat="server" Text="On Date : "></asp:Label>
                                                        </td>
                                                        <td width="30%" valign="top">
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
                                                        <td style="width: 11%;" valign="top">
                                                            <asp:Label ID="lblDateTo4" runat="server" Text="Start Date :"></asp:Label>
                                                        </td>
                                                        <td style="width: 30%;" valign="top">
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
                                                            <asp:DropDownList ID="drpAmount_F4" Width="150px" runat="server" AutoPostBack="true" EnableTheming="false"
                                                                OnSelectedIndexChanged="drpAmount_F_SelectedIndexChanged" onchange="Page_ClientValidate('dummy');">
                                                                <asp:ListItem Text="Equal" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="Greater Than" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Greater Than or Equal to" Value="4"></asp:ListItem>
                                                                <asp:ListItem Text="Between" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="Less Than" Value="3"></asp:ListItem>
                                                                <asp:ListItem Text="Less Than or Equal to" Value="5"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
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
                                            <asp:Panel ID="pnlNumber_F4" runat="server">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="drpNumber_F4" Width="150px" runat="server" AutoPostBack="true" EnableTheming="false"
                                                                OnSelectedIndexChanged="drpNumber_F_SelectedIndexChanged" onchange="Page_ClientValidate('dummy');">
                                                                <asp:ListItem Text="Equal" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="Greater Than" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Greater Than or Equal to" Value="4"></asp:ListItem>
                                                                <asp:ListItem Text="Between" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="Less Than" Value="3"></asp:ListItem>
                                                                <asp:ListItem Text="Less Than or Equal to" Value="5"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblNumberText1_F4" runat="server"></asp:Label>
                                                            <asp:TextBox ID="txtNumber1_F4" runat="server" onkeypress="return numberOnly(this);"></asp:TextBox>
                                                            <asp:Label ID="lblNumberText2_F4" Visible="false" runat="server"></asp:Label>
                                                            <asp:TextBox ID="txtNumber2_F4" runat="server" Visible="false" onkeypress="return numberOnly(this);"></asp:TextBox>
                                                            <asp:CompareValidator ID="cvNumber4" runat="server" ErrorMessage="Filter Criteria  4 - To Number must be Greater Than or Equal To From Number"
                                                                ControlToCompare="txtNumber1_F4" ControlToValidate="txtNumber2_F4" Operator="GreaterThanEqual"
                                                                Type="Currency" Display="None" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlText_F4" runat="server">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="drpText_F4" Width="106px" runat="server" EnableTheming="false">
                                                                <asp:ListItem Text="Contains" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Starts With" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="Ends With" Value="3"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtFilter4" runat="server" Width="216px" MaxLength="50"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                        <td valign="top">
                                            <span id="spnField4" runat="server" visible="false">AND</span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" width="5%">
                                Field 5 :
                            </td>
                            <td>
                                <table cellpadding="2" cellspacing="1" width="100%" align="center">
                                    <tr>
                                        <td style="width: 22%;" valign="top">
                                            <asp:DropDownList ID="drpFilter5" runat="server" AutoPostBack="True" Width="250px" EnableTheming="false"
                                                OnSelectedIndexChanged="drpFilter_SelectedIndexChanged" onchange="AskfForLogoff=false;Page_ClientValidate('dummy')">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 5%;" align="left" valign="top">
                                            <asp:CheckBox ID="chkNotCriteria5" runat="server" Text="Not" Visible="false" />
                                        </td>
                                        <td width="70%" align="left" valign="top">
                                            <asp:Panel ID="pnlDate_F5" runat="server">
                                                <table width="100%">
                                                    <tr>
                                                        <td valign="top">
                                                            <asp:DropDownList ID="lstDate5" Width="106px" runat="server" AutoPostBack="true" EnableTheming="false"
                                                                OnSelectedIndexChanged="rdbLstDate_SelectedIndexChanged" onchange="Page_ClientValidate('dummy');">
                                                                <asp:ListItem Text="On" Value="O" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                                <asp:ListItem Text="On or Before" Value="BF"></asp:ListItem>
                                                                <asp:ListItem Text="On or After" Value="A"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td width="11%" valign="top">
                                                            <asp:Label ID="lblDateFrom5" runat="server" Text="On Date : "></asp:Label>
                                                        </td>
                                                        <td width="30%" valign="top">
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
                                                        <td style="width: 11%;" valign="top">
                                                            <asp:Label ID="lblDateTo5" runat="server" Text="Start Date :"></asp:Label>
                                                        </td>
                                                        <td style="width: 30%;" valign="top">
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
                                                            <asp:DropDownList ID="drpAmount_F5" Width="150px" runat="server" AutoPostBack="true" EnableTheming="false"
                                                                OnSelectedIndexChanged="drpAmount_F_SelectedIndexChanged" onchange="Page_ClientValidate('dummy');">
                                                                <asp:ListItem Text="Equal" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="Greater Than" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Greater Than or Equal to" Value="4"></asp:ListItem>
                                                                <asp:ListItem Text="Between" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="Less Than" Value="3"></asp:ListItem>
                                                                <asp:ListItem Text="Less Than or Equal to" Value="5"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
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
                                            <asp:Panel ID="pnlNumber_F5" runat="server">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="drpNumber_F5" Width="150px" runat="server" AutoPostBack="true" EnableTheming="false"
                                                                OnSelectedIndexChanged="drpNumber_F_SelectedIndexChanged" onchange="Page_ClientValidate('dummy');">
                                                                <asp:ListItem Text="Equal" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="Greater Than" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Greater Than or Equal to" Value="4"></asp:ListItem>
                                                                <asp:ListItem Text="Between" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="Less Than" Value="3"></asp:ListItem>
                                                                <asp:ListItem Text="Less Than or Equal to" Value="5"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblNumberText1_F5" runat="server"></asp:Label>
                                                            <asp:TextBox ID="txtNumber1_F5" runat="server" onkeypress="return numberOnly(this);"></asp:TextBox>
                                                            <asp:Label ID="lblNumberText2_F5" Visible="false" runat="server"></asp:Label>
                                                            <asp:TextBox ID="txtNumber2_F5" runat="server" Visible="false" onkeypress="return numberOnly(this);"></asp:TextBox>
                                                            <asp:CompareValidator ID="cvNumber5" runat="server" ErrorMessage="Filter Criteria  4 - To Number must be Greater Than or Equal To From Number"
                                                                ControlToCompare="txtNumber1_F4" ControlToValidate="txtNumber2_F4" Operator="GreaterThanEqual"
                                                                Type="Currency" Display="None" ValidationGroup="vsErrorGroup" SetFocusOnError="true"></asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlText_F5" runat="server">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="drpText_F5" Width="106px" runat="server" EnableTheming="false">
                                                                <asp:ListItem Text="Contains" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Starts With" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="Ends With" Value="3"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtFilter5" runat="server" Width="216px" MaxLength="50"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                        <td valign="top">
                                            <span id="spnField5" runat="server" visible="false">&nbsp;</span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="3" class="bandHeaderRow">
                    Action
                </td>
            </tr>
            <tr>
                <td valign="top" width="15%">
                    Action Timing<span class="mf">*</span>
                </td>
                <td valign="top" width="4%">
                    :
                </td>
                <td valign="top">
                    <asp:DropDownList runat="server" ID="rdListEvaluation" EnableTheming="false">
                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                        <asp:ListItem Text="When record is created." Value="Add Save"> </asp:ListItem>
                        <asp:ListItem Text="Every time record is edited." Value="Edit Save"> </asp:ListItem>
                        <asp:ListItem Text="When Record is created or edited." Value="Add and Edit Save"> </asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="0"
                        ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Action Timing" Display="None"
                        ControlToValidate="rdListEvaluation" SetFocusOnError="true" />
                </td>
            </tr>
            <tr>
                <td valign="top" width="15%">
                    Action Type<span class="mf">*</span>
                </td>
                <td valign="top" width="4%">
                    :
                </td>
                <td valign="top">
                    <asp:DropDownList ID="drpAction_Type" Width="106px" runat="server" OnSelectedIndexChanged="drpAction_Type_SelectedIndexChanged"
                        AutoPostBack="True" Enabled="false" onchange="Page_ClientValidate('dummy');" EnableTheming="false">
                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Update" Value="Update"></asp:ListItem>
                        <asp:ListItem Text="Email" Value="Email"></asp:ListItem>
                        <asp:ListItem Text="Diary" Value="Diary"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="0"
                        ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Action Type" Display="None"
                        ControlToValidate="drpAction_Type" SetFocusOnError="true" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <%--<asp:UpdatePanel ID="pnlAction" runat="server" UpdateMode="Conditional">--%>
                    <%--<ContentTemplate>--%>
                    <div runat="server" id="divUpdate_Action" style="display: block">
                        <table width="100%" cellspacing="0" cellpadding="0">
                            <tr>
                                <td valign="top" width="15%">
                                    Field to Update
                                </td>
                                <td valign="top" width="4%">
                                    :
                                </td>
                                <td>
                                    <table cellpadding="2" cellspacing="1" width="100%" align="center">
                                        <tr>
                                            <td style="width: 20%;" valign="top">
                                                <asp:DropDownList ID="drpFilter_Action" runat="server" AutoPostBack="True" Width="270px" EnableTheming="false"
                                                    onchange="AskfForLogoff=false;Page_ClientValidate('dummy')" OnSelectedIndexChanged="drpFilter_Action_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" InitialValue="0"
                                                    ValidationGroup="vsErrorGroupUpdate" ErrorMessage="Please Select Field to update"
                                                    Display="None" ControlToValidate="drpFilter_Action" SetFocusOnError="true" />
                                            </td>
                                            <td style="width: 80px;" align="center" valign="top">
                                                <span id="spnNewValue" runat="server" visible="false">New Value :</span>
                                            </td>
                                            <td valign="top">
                                                <asp:DropDownList ID="drpDirectDerived" runat="server" AutoPostBack="True" Width="110px" EnableTheming="false"
                                                    OnSelectedIndexChanged="drpDirectDerived_SelectedIndexChanged" Visible="false">
                                                    <asp:ListItem Text="Direct Value" Value="True" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="Derived Value" Value="False"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left" valign="top">
                                                <div runat="server" id="tdAction" style="display: block">
                                                    <asp:Panel ID="pnlDate_F_Action" runat="server">
                                                        <table cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td valign="top" width="1%" valign="top">
                                                                    <asp:DropDownList ID="lstDate_Action" Width="106px" runat="server" AutoPostBack="true" EnableTheming="false"
                                                                        OnSelectedIndexChanged="rdbLstDate_SelectedIndexChanged" Visible="false" onchange="Page_ClientValidate('dummy');">
                                                                        <asp:ListItem Text="On" Value="O" Selected="True"></asp:ListItem>
                                                                        <asp:ListItem Text="Between" Value="B"></asp:ListItem>
                                                                        <asp:ListItem Text="On or Before" Value="BF"></asp:ListItem>
                                                                        <asp:ListItem Text="On or After" Value="A"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td width="1%" valign="top">
                                                                    <asp:Label ID="lblDateFrom_Action" runat="server" Text=""></asp:Label>
                                                                </td>
                                                                <td width="30%" valign="top">
                                                                    <asp:TextBox ID="txtDate_From_Action" runat="server" SkinID="txtdate" Width="80px"
                                                                        MaxLength="10"></asp:TextBox>
                                                                    <img alt="" id="imgDate_Opened_From_Action" onclick="return showCalendar('<%=txtDate_From_Action.ClientID%>', 'mm/dd/y','','');"
                                                                        runat="server" onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL %>iconPicDate.gif'
                                                                        align="middle" />
                                                                    <asp:RegularExpressionValidator ID="revtxtDate_From_Action" runat="server" ValidationGroup="vsErrorGroupUpdate"
                                                                        Display="none" ErrorMessage="Filter Criteria Action - On Date is not a valid date"
                                                                        SetFocusOnError="true" ControlToValidate="txtDate_From_Action" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                                    <uc:CtrlRelativeDates ID="ucRelativeDatesFrom_Action" runat="server" strDateClientID="ctl00_ContentPlaceHolder1_txtDate_From_Action"
                                                                        OnSetDate="RaltiveDatesSaveClick" />
                                                                </td>
                                                                <td style="width: 11%;" valign="top">
                                                                    <asp:Label ID="lblDateTo_Action" runat="server" Text="Start Date :" Visible="false"></asp:Label>
                                                                </td>
                                                                <td style="width: 1%;" valign="top">
                                                                    <asp:TextBox ID="txtDate_To_Action" runat="server" SkinID="txtdate" Width="80px"
                                                                        MaxLength="10" Visible="false"></asp:TextBox>
                                                                    <img alt="" id="imgDate_To_Action" runat="server" onclick="return showCalendar('<%=txtDate_To_Action.ClientID%>', 'mm/dd/y','','');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src='<%=AppConfig.ImageURL %>iconPicDate.gif'
                                                                        align="middle" visible="false" />
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="vsErrorGroupUpdate"
                                                                        Visible="false" Display="none" ErrorMessage="Filter Criteria Action - End Date is not a valid date"
                                                                        SetFocusOnError="true" ControlToValidate="txtDate_To_Action" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtDate_From_Action"
                                                                        ControlToValidate="txtDate_To_Action" Type="Date" Operator="GreaterThanEqual"
                                                                        Display="None" SetFocusOnError="true" Visible="false" ErrorMessage="Filter Criteria Action - End Date should be greater than or equal to Start Date"
                                                                        ValidationGroup="vsErrorGroupUpdate" />
                                                                    <uc:CtrlRelativeDates ID="ucRelativeDatesTo_Action" runat="server" strDateClientID="ctl00_ContentPlaceHolder1_txtDate_To_Action"
                                                                        Visible="false" OnSetDate="RaltiveDatesSaveClick" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlMultiSelect_F_Action" runat="server" Style="display: block">
                                                        <table cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td valign="top">
                                                                    <asp:DropDownList ID="lst_F_Action" runat="server" Width="300px" EnableTheming="false" onchange="AskfForLogoff=false;">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlAmount_F_Action" runat="server">
                                                        <table cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td valign="top">
                                                                    <asp:Label ID="lblAmountText1_F_Action" runat="server"></asp:Label>
                                                                    <asp:TextBox valign="top" ID="txtAmount1_F_Action" runat="server" onkeypress="javascript:return FormatNumber(event,this.id,12,false,false);"
                                                                        onblur="javascript:return formatCurrencyOnBlur(this);" MaxLength="15"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlNumber_F_Action" runat="server">
                                                        <table cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td valign="top">
                                                                    <asp:Label ID="lblNumberText1_F_Action" runat="server"></asp:Label>
                                                                    <asp:TextBox valign="top" ID="txtNumber1_F_Action" runat="server" onkeypress="return numberOnly(this);"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlText_F_Action" runat="server">
                                                        <table cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td valign="top">
                                                                    <asp:TextBox valign="top" ID="txtFilter_Action" runat="server" Width="216px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </div>
                                            </td>
                                            <td valign="top">
                                                <div runat="server" id="tdDerived" style="display: block; text-align: left;">
                                                    <table style="padding-top: 0px;">
                                                        <tr>
                                                            <td valign="top">
                                                                <asp:DropDownList ID="drpFilter_Derived" runat="server" AutoPostBack="True" Width="170px" EnableTheming="false"
                                                                    Visible="false" OnSelectedIndexChanged="drpFilter_Derived_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td valign="top">
                                                                <asp:DropDownList ID="drpDerived_Add" runat="server" Visible="false" EnableTheming="false">
                                                                    <asp:ListItem Text=" + " Value="+" Selected="True"></asp:ListItem>
                                                                    <%--<asp:ListItem Text=" - " Value="-"></asp:ListItem>--%>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td valign="top">
                                                                <asp:TextBox runat="server" ID="txtNumber_Derived" Width="100px" Visible="false"
                                                                    onkeypress="return numberOnly(this);"></asp:TextBox>
                                                                <asp:TextBox runat="server" ID="txtText_Derived" Width="100px" Visible="false"></asp:TextBox>
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
                    </div>
                    <div runat="server" id="divEmail_Action" style="display: block">
                        <table width="100%">
                            <tr>
                                <td width="15%" valign="top">
                                    Recipient(s)<span class="mf">*</span>
                                </td>
                                <td valign="top" width="4%">
                                    :
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtIAssignTo" Width="50%" ReadOnly="true"></asp:TextBox>&nbsp;
                                    <asp:CustomValidator ID="cvEmailRecipient" runat="server" Text="" Display="None" SetFocusOnError="true" 
                                     ErrorMessage="Please select the recipient(s)" ValidationGroup="vsErrorGroupEmail" ClientValidationFunction="validateRecipient"></asp:CustomValidator>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="vsErrorGroupEmailRecipient"
                                        SetFocusOnError="true" ErrorMessage="Please select the recipient(s)" Display="none"
                                        ControlToValidate="txtIAssignTo"></asp:RequiredFieldValidator>--%>
                                    <asp:HiddenField runat="server" ID="txtIAssignToID" />
                                    <asp:Button ID="btnIAssignTo" Text="V" runat="server" CssClass="btn" OnClientClick="return openPopUp();" />
                                </td>
                            </tr>
                            <tr id="trRecipientFromRecord" runat="server" style="display: none">
                                <td width="15%" valign="top">
                                    Recipient(s) from record
                                </td>
                                <td valign="top" width="4%">
                                    :
                                </td>
                                <td>
                                    <div style="overflow-y: scroll; width: 760px; height: 100px; background-color: #d3d3d3;">
                                        <asp:CheckBoxList ID="chkEmailFields" runat="server" RepeatColumns="3" RepeatDirection="Vertical">
                                        </asp:CheckBoxList>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td width="15%" valign="top">
                                    Email Subject<span class="mf">*</span>
                                </td>
                                <td valign="top" width="4%">
                                    :
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtEmailSubject" Width="95%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="vsErrorGroupEmail"
                                        SetFocusOnError="true" ErrorMessage="Please enter the email subject" Display="none"
                                        ControlToValidate="txtEmailSubject"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td width="15%" valign="top">
                                    Email body<span class="mf">*</span>
                                </td>
                                <td valign="top" width="4%">
                                    :
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtEmailBody" Width="95%" Rows="3" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="vsErrorGroupEmail"
                                        SetFocusOnError="true" ErrorMessage="Please enter the email body" Display="none"
                                        ControlToValidate="txtEmailBody"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td width="15%" valign="top">
                                    Record Details to be sent
                                </td>
                                <td valign="top" width="4%">
                                    :
                                </td>
                                <td>
                                    <div style="overflow-y: scroll; width: 760px; height: 200px; background-color: #d3d3d3;">
                                        <asp:CheckBoxList ID="chkFields" runat="server" Width="720px" RepeatColumns="4" RepeatDirection="Vertical">
                                        </asp:CheckBoxList>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div runat="server" id="divDiary_Action" style="display: block">
                        <table width="100%">
                            <tr>
                                <td width="15%">
                                    Assigned To <span class="mf">*</span>
                                </td>
                                <td valign="top" width="4%">
                                    :
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtIAssignToDiary" Width="20%" ReadOnly="true"></asp:TextBox>&nbsp;
                                    <asp:Button ID="btnIAssignTODiary" Text="V" runat="server" CssClass="btn" OnClientClick="return openPopUpDiary();" />
                                    <asp:RequiredFieldValidator ID="rfvIAssignToDiary" ControlToValidate="txtIAssignToDiary"
                                        runat="server" InitialValue="" ValidationGroup="vsErrorGroupDiary" SetFocusOnError="true"
                                        ErrorMessage="Please Select Assigned To" Display="none" Text="*"></asp:RequiredFieldValidator>
                                    <asp:HiddenField runat="server" ID="txtIAssignToIDDiary" />
                                </td>
                            </tr>
                            <tr>
                                <td width="15%">
                                    Assigned From Record 
                                </td>
                                <td valign="top" width="4%">
                                    :
                                </td>
                                <td>
                                    &nbsp;<asp:CheckBox ID="chkCurrentUser" runat="server" Text="Current User" onclick="return CheckUncheckContacts();" />
                                </td>
                            </tr>
                            <tr id="trAssignedContact" runat="server">
                                <td width="15%" valign="top">
                                    Assigned From Contact
                                </td>
                                <td valign="top" width="4%">
                                    :
                                </td>
                                <td>
                                    <%--<div style="width: 760px; height: 35px; background-color: #d3d3d3;">--%>
                                        <asp:CheckBoxList ID="chkContactFields" runat="server" RepeatColumns="3" RepeatDirection="Vertical" Width="90%" onclick="return CheckUncheckContacts();">
                                        </asp:CheckBoxList>
                                    <%--</div>--%>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" width="15%">
                                    Diary Note<span class="mf">*</span>
                                </td>
                                <td valign="top" width="4%">
                                    :
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtDiaryNote" Width="95%" TextMode="MultiLine" Rows="3"></asp:TextBox>&nbsp;
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtDiaryNote"
                                        runat="server" InitialValue="" ValidationGroup="vsErrorGroupDiary" SetFocusOnError="true"
                                        ErrorMessage="Please enter the diary note" Display="none" Text="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td width="15%">
                                    Diary Date<span class="mf">*</span>
                                </td>
                                <td valign="top" width="4%">
                                    :
                                </td>
                                <td>
                                    Date of Action &nbsp;+&nbsp;
                                    <asp:TextBox runat="server" ID="txtDiaryDate" Width="145" onkeypress="return FormatNumber(event,this.id,5,true);"></asp:TextBox>&nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                    <%--</ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="drpAction_Type" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>--%>
                </td>
            </tr>
        </table>
        <%--</ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>--%>
        <table width="100%" cellpadding="4" cellspacing="2" style="display: block;">
            <tr>
                <td align="center">
                    <asp:Button ID="btnSave" runat="Server" Text="Save" ValidationGroup="vsErrorGroup"
                        OnClick="btnSave_Click" ToolTip="Save" OnClientClick="javascript:return FilterValidation();" />
                    <asp:Button ID="btnClear" runat="Server" Text="Clear" OnClick="btnClear_Click" ToolTip="Clear" />
                    <asp:Button ID="btnCancel" runat="server" Text="Search" OnClick="btnCancel_Click"
                        Visible="true" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
