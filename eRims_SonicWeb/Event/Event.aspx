<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Event.aspx.cs" Inherits="Event_Event" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/IncidentTab/IncidentTab.ascx" TagName="IncidentTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/IncidentInfo/IncidentInfo.ascx" TagName="IncidentInfo" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Date_Validation.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/jquery.maskedinput.js"></script>
    <script type="text/javascript">

        function checkLength() 
        {
            var oObject = document.getElementById('<%=txtSonic_Notes.ClientID%>') 
            if (oObject.value.length < 50)
            {
                alert("Please enter minimum 50 Characters for Notes.");
                return false;
            }
            else
            {
                return true;            
            }
            //else {
            //    var keyID = (window.event) ? event.keyCode : e.keyCode;
            //    if ((keyID>= 37 && keyID <= 40) || (keyID == 8) || (keyID == 46)) {
            //        if (window.event)
            //            e.returnValue = true;
            //    }
            //    else {
            //        if (window.event)
            //            e.returnValue = false;
            //        else
            //            e.preventDefault();
            //    }
            //}
        }

        function CheckDummyVal() {
            Page_ClientValidate('11');
            return true;
        }

        function AciNotePopup(NoteId, type)
        {            
            var winHeight = 500;
            var winWidth = 500;
            var EventId = <%=ViewState["PK_Event"]%>;
            obj = window.open("Event_Note.aspx?nid=" + NoteId + "&id=" + '<%=ViewState["PK_Event"]%>' + "&type=" + type, 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
        }

        function setscroll() 
        {
            document.documentElement.scrollLeft = document.getElementById('<%=hndScrollX.ClientID%>').value;
            document.documentElement.scrollTop = document.getElementById('<%=hndScrollY.ClientID%>').value;
        }

        function getscroll() 
        {
            var x = document.documentElement.scrollLeft;
            var y = document.documentElement.scrollTop;
            document.getElementById('<%=hndScrollX.ClientID%>').value = x;
            document.getElementById('<%=hndScrollY.ClientID%>').value = y;
        }

        function OpenPopupContact(ContactType) 
        {
            ShowDialog('<%=AppConfig.SiteURL %>/Event/PopupContact.aspx?ContactType=' + ContactType, PopupWidth_Contact, PopupHeight_Contact);
        }

        jQuery(function ($) 
        {
            $("#<%=txtDate_Sent.ClientID%>").mask("99/99/9999");
            $("#<%=txtInvestigationReportDate.ClientID%>").mask("99/99/9999");
            $("#<%=txtEventReportDate.ClientID%>").mask("99/99/9999");
            $("#<%=txtEventOccuranceDate.ClientID%>").mask("99/99/9999");
            $("#<%=txtACI_Notes_Date.ClientID%>").mask("99/99/9999");
        });

        function SetMenuStyle(index) {
            //            var i;
            //            for (i = 1; i <= 4; i++) {
            //                var tb = document.getElementById("Menu" + i);
            //                if (i == index) {
            //                    tb.className = "LeftMenuSelected";
            //                    tb.onmouseover = function () { this.className = 'LeftMenuSelected'; }
            //                    tb.onmouseout = function () { this.className = 'LeftMenuSelected'; }
            //                }
            //                else {
            //                    tb.className = "LeftMenuStatic";
            //                    tb.onmouseover = function () { this.className = 'LeftMenuHover'; }
            //                    tb.onmouseout = function () { this.className = 'LeftMenuStatic'; }
            //                }
            //            }

            var tb = document.getElementById("Menu" + 1);

            tb.className = "LeftMenuSelected";
            tb.onmouseover = function () { this.className = 'LeftMenuSelected'; }
            tb.onmouseout = function () { this.className = 'LeftMenuSelected'; }
        }

        var ActiveTabIndex = 1;
        function onNextStep() {
            if (ActiveTabIndex == 4) {
                return ValSave();
            }
            else {
                ActiveTabIndex = ActiveTabIndex + 1;
                //ShowPanel(ActiveTabIndex);
                return false;
            }
        }

        function onPreviousStep() {
            if (ActiveTabIndex == 1) {
                return true;
            }
            else {
                ActiveTabIndex = ActiveTabIndex - 1;
                document.getElementById('<%= hdnPanel.ClientID %>').value = ActiveTabIndex;
                // ShowPanel(ActiveTabIndex);
                return false;
            }
        }


        function ValSave() {
            var op = '<%=StrOperation%>';
            if (op.toLocaleLowerCase() == "view") {
                return true;
            }
            else {
                if (Page_ClientValidate("vsErrorGroup"))
                    return true;
                else
                    return false;
            }
        }

        function ShowPanel(index) {

            SetMenuStyle(index);
            ActiveTabIndex = index;
            document.getElementById('<%= hdnPanel.ClientID %>').value = ActiveTabIndex;
            var op = '<%=StrOperation%>';

            if (op.toLocaleLowerCase() == "view") {

                ShowPanelView(index);
            }
            else {
                //                var i;
                //                for (i = 1; i <= 4; i++) {
                //                    document.getElementById('ctl00_ContentPlaceHolder1_pnl' + i).style.display = (i == index) ? "block" : "none";
                //                }
                document.getElementById('ctl00_ContentPlaceHolder1_pnl' + 1).style.display = "block";
                SetFocusOnFirstControl(index);
            }


        }



        function ShowPanelView(index) {
            SetMenuStyle(index);
            document.getElementById('<%=dvView.ClientID%>').style.display = "block";
            var i = 1;
            // for (i = 1; i <= 4; i++) {
            document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i + "view").style.display = (i == index) ? "block" : "none";
            // }
        }

        function SetFocusOnFirstControl(index) {
            document.getElementById('<%=ddlLocation.ClientID %>').focus();

        }

        function YearValidate(obj, args) {
            if (trim(args.Value) != '') {
                var y = args.Value;
                if ((y.length < 4 && y.length > 0) || !IsNumericNoAlert(y) || y >= 9999 || y <= 1753) {
                    args.IsValid = false;
                }
                else {
                    args.IsValid = true;
                }
            }
            return args.IsValid;
        }

        function ValidateTime(obj, args) {
            //var RegularExpression = new RegExp("(([0-1]?[0-9])|([2][0-2])):([0-5]?[0-9])(:([0-5]?[0-9]))?$");
            var t = /^((1[012])|(0[1-9])):([0-5][0-9])?$/
            var strTime;
            strTime = args.value;
            if (t.test(strTime)) {
                args.IsValid = true;
            }
            else {
                args.IsValid = false;
            }
            return args.IsValid;
        }

        function CheckBeforeSave() {
            var op = '<%=StrOperation%>';

            if(document.getElementById("ctl00_ContentPlaceHolder1_txtTelephoneNumber1").value=="___-___-____")
                document.getElementById("ctl00_ContentPlaceHolder1_txtTelephoneNumber1").value="";
            if(document.getElementById("ctl00_ContentPlaceHolder1_txtTelephoneNumber2").value=="___-___-____")
                document.getElementById("ctl00_ContentPlaceHolder1_txtTelephoneNumber2").value="";

            if (op.toLocaleLowerCase() == "view") {
                return true;
            }
            else {
                var bValid = false;
                if (Page_ClientValidate("vsErrorGroup")) {
                    bValid = true;

                }
                if (bValid)
                    CallSave();
            }
        }



        function CallSave() {
            __doPostBack('ctl00$ContentPlaceHolder1$btnSave', '');
        }


        function AuditPopUp() {
            var winHeight = window.screen.availHeight - 300;
            if (window.screen.availHeight == 728) {
                winHeight = winHeight + 20;
            }
            var winWidth = window.screen.availWidth - 200; 
            obj = window.open("AuditPopup_Event.aspx?id=" + '<%=ViewState["PK_Event"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }

        jQuery(function ($) {
            $("#<%=txtEvent_Start_Time.ClientID%>").mask("99:99");
            $("#<%=txtEvent_End_Time.ClientID%>").mask("99:99");
        });

    </script>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" CssClass="errormessage" ValidationGroup="vsErrorGroup"
            BorderColor="DimGray" BorderWidth="1" HeaderText="Verify the following fields:"
            ShowMessageBox="true" ShowSummary="false"></asp:ValidationSummary>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="errormessage"
            ValidationGroup="vsErrorOtherVehicle" BorderColor="DimGray" BorderWidth="1" HeaderText="Verify the following fields:"
            ShowMessageBox="true" ShowSummary="false"></asp:ValidationSummary>
    </div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                <uc:IncidentTab ID="ucIncident" runat="server" />
                <%--<uc:claimtab ID="uclaimincidenttab" runat="server" Visible="false" /> --%>
            </td>
        </tr>
        <%--<tr>
            <td align="left">
                <uc:IncidentInfo ID="ucIncidentInfo" runat="server" Visible="false" />
            </td>
        </tr>--%>
        <tr>
            <td class="Spacer" style="height: 10px;"></td>
        </tr>
        <tr>
            <td>
                <div class="bandHeaderRow">
                    <table width="100%" border="0" cellpadding="2" cellspacing="0">
                        <tr>
                            <td align="left">Event
                            </td>
                            <td align="right">
                                <asp:Label ID="lblLastModifiedDateTime" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="Spacer" style="height: 10px;" colspan="2"></td>
                    </tr>
                    <tr>
                        <td class="leftMenu" style="padding-left: 2px;">
                            <table cellpadding="5" cellspacing="0" width="100%">
                                <tr>
                                    <td style="height: 18px;" class="Spacer"></td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu1" onclick="javascript:ShowPanel(1);" class="LeftMenuStatic">Event</span>
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td align="left" width="100%">
                                        <span id="Menu2" onclick="javascript:ShowPanel(2);" class="LeftMenuStatic">Company Information</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu3" onclick="javascript:ShowPanel(3);" class="LeftMenuStatic">Vehicle Information</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu4" onclick="javascript:ShowPanel(4);" class="LeftMenuStatic">Police Information</span>
                                    </td>
                                </tr>--%>
                            </table>
                        </td>
                        <td valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td width="5px" class="Spacer">&nbsp;
                                    </td>
                                    <td class="dvContainer">
                                        <asp:HiddenField ID="hndScrollX" runat="server" />
                                        <asp:HiddenField ID="hndScrollY" runat="server" />
                                        <div id="dvEdit" runat="server" width="794px">
                                            <asp:Panel ID="pnl1" runat="server" Style="display: none;" Width="794px">
                                                <div class="bandHeaderRow">
                                                    Event Information
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td style="height: 5px" colspan="6"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Event Number
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtEventNumber" autocomplete="off" runat="server" SkinID="txtDisabled" Width="170px"></asp:TextBox>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Location
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:DropDownList ID="ddlLocation" runat="server" Width="175px" OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged" AutoPostBack="true">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Event Type
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <%--<asp:DropDownList ID="ddlEventType" runat="server" Width="175px">
                                                            </asp:DropDownList>--%>
                                                            <asp:ListBox runat="server" ID="lstEventType" SelectionMode="Multiple" Width="175px"></asp:ListBox>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Event Description
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <%-- <asp:TextBox ID="txtEvent_Desc" runat="server" SkinID="" MaxLength="100" Width="170px"></asp:TextBox>
                                                            <asp:DropDownList ID="ddlFK_LU_Event_Description" runat="server" Width="175px">
                                                            </asp:DropDownList>--%>
                                                            <asp:ListBox runat="server" ID="lstEventDescription" SelectionMode="Multiple" Width="175px"></asp:ListBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Other Type
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox runat="server" ID="txtOther_Event_Type" MaxLength="50" Width="170px"></asp:TextBox>
                                                        </td>
                                                        <td align="left" valign="top">Other Description
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtOther_Event_Desc" runat="server" MaxLength="50" Width="170px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Camera Name
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox runat="server" ID="txtCameraName" Width="170px" MaxLength="50"></asp:TextBox>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Camera Number
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox runat="server" ID="txtCameraNumber" Width="170px" MaxLength="50"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Sonic Event
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlFK_LU_Sonic_Event" runat="server" Width="175px" SkinID="drpYesNoString" AutoPostBack="true" OnSelectedIndexChanged="ddlFK_LU_Sonic_Event_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Date Sent to Sonic
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtDate_Sent" runat="server" SkinID="txtDate" />
                                                            <img alt="Report Date" onclick="return showCalendar('<%= txtDate_Sent.ClientID %>', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revtxtDate_Sent" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[Event]/Date Sent to Sonic is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtDate_Sent" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            <asp:CompareValidator ID="cmptxtDateSentToClient" runat="server" ControlToCompare="txtCurrentDate"
                                                                ControlToValidate="txtDate_Sent" Display="None" Text="*" ErrorMessage="[Event]/Date Sent to Sonic should not be greater than current date."
                                                                Operator="LessThanEqual" Type="Date" ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <%--<td align="left" width="18%" valign="top">
                                                            Date Opened
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtDate_Opened" runat="server" SkinID="txtDate" Enabled="false"
                                                                Width="170px" />
                                                        </td>--%>
                                                        <td align="left" valign="top">Investigation Report Date
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtInvestigationReportDate" runat="server" SkinID="txtDate" />
                                                            <img alt="Report Date" onclick="return showCalendar('<%= txtInvestigationReportDate.ClientID %>', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revtxtInvestigationReportDate" runat="server"
                                                                ValidationGroup="vsErrorGroup" Display="none" ErrorMessage="[Event]/Investigation Report Date is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtInvestigationReportDate" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" valign="top">Event Report Date
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtCurrentDate" runat="server" Style="display: none"></asp:TextBox>
                                                            <asp:TextBox ID="txtEventReportDate" runat="server" SkinID="txtDate" />
                                                            <img alt="Report Date" onclick="return showCalendar('<%= txtEventReportDate.ClientID %>', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revReport_Date" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[Event]/Event Report Date is not a valid date" SetFocusOnError="true"
                                                                ControlToValidate="txtEventReportDate" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            <asp:CompareValidator ID="cmptxtEventReportDate" runat="server" ControlToCompare="txtCurrentDate"
                                                                ControlToValidate="txtEventReportDate" Display="None" Text="*" ErrorMessage="[Event]/Event Report Date should not be greater than current date."
                                                                Operator="LessThanEqual" Type="Date" ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Event Occurrence Date
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtEventOccuranceDate" runat="server" SkinID="txtDate" />
                                                            <img alt="Report Date" onclick="return showCalendar('<%= txtEventOccuranceDate.ClientID %>', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revtxtEventOccuranceDate" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[Event]/Event Occurance Date is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtEventOccuranceDate" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Event Start Time
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtEvent_Start_Time" runat="server" SkinID="txtDisabled" />
                                                        </td>
                                                        <td align="left" valign="top">Event End Time
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtEvent_End_Time" runat="server" SkinID="txtDisabled" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trACINotesGrid">
                                                        <td align="left" valign="top">ACI Notes Grid
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td>
                                                                        <asp:GridView ID="gvACI_Notes" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                            PageSize="6" EnableViewState="true" AllowPaging="true" OnRowCommand="gvACI_Notes_RowCommand"
                                                                            OnPageIndexChanging="gvACI_Notes_PageIndexChanging">
                                                                            <Columns>
                                                                                <asp:TemplateField>
                                                                                    <ItemStyle Width="5%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:HiddenField ID="hdnPK_ACI_Event_Notes" runat="server" Value='<%# Eval("PK_ACI_Event_Notes") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Note Date">
                                                                                    <ItemStyle Width="20%" />
                                                                                    <ItemTemplate>
                                                                                        <a href="javascript:function(){return false};" onclick="AciNotePopup('<%#Eval("PK_ACI_Event_Notes") %>','ACI');">
                                                                                            <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Note_Date")) %></a>
                                                                                        <%--<asp:LinkButton ID="lblNote_Date" runat="server" CommandName="ViewNote" CausesValidation="false"
                                                                                Text='' CommandArgument=></asp:LinkButton>--%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Notes">
                                                                                    <ItemStyle Width="45%" />
                                                                                    <ItemTemplate>
                                                                                        <a href="javascript:function(){return false};" onclick="AciNotePopup('<%#Eval("PK_ACI_Event_Notes") %>','ACI');">
                                                                                            <%# Eval("Note") %></a>
                                                                                        <%--<asp:LinkButton ID="lblNotes" runat="server" Text='<%#Eval("Note") %>' CommandName="ViewNote"
                                                                                CausesValidation="false" CommandArgument='<%#Eval("PK_ACI_Event_Notes") %>'></asp:LinkButton>--%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton runat="server" ID="lnkEdit" Text=" Edit " CommandName="EditRecord" Visible="false" CommandArgument='<%#Eval("PK_ACI_Event_Notes") %>'>
                                                                                        </asp:LinkButton>
                                                                                        &nbsp;&nbsp;&nbsp;
                                                                                        <asp:LinkButton ID="lnkRemove" runat="server" Text="Delete" CommandArgument='<%#Eval("PK_ACI_Event_Notes") %>' Visible="false"
                                                                                            CommandName="RemoveACINote" OnClientClick="return confirm('Are you sure to remove ACI Note record?');" CausesValidation="false" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <EmptyDataTemplate>
                                                                                <table cellpadding="4" cellspacing="0" width="100%">
                                                                                    <tr>
                                                                                        <td width="100%" align="center" style="border: 1px solid #cccccc;">
                                                                                            <asp:Label ID="lblEmptyHeaderGridMessage" runat="server" Text="No Record Found"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </EmptyDataTemplate>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding-bottom: 5px;">
                                                                        <asp:LinkButton Style="display: inline" ID="lnkAddACINotesNew" OnClick="lnkAddACINotesNew_Click" Visible="false"
                                                                            runat="server" Text="Add New"></asp:LinkButton>&nbsp;&nbsp;&nbsp;
                                                                    <asp:LinkButton Style="display: none" ID="lnkACINotesCancel"
                                                                        runat="server" Text="Cancel"></asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trACINotes" style="display: none;">
                                                        <td colspan="6">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        <b>ACI Notes Grid </b>
                                                                    </td>
                                                                    <td align="center" valign="top" colspan="5">&nbsp;
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td align="left" valign="top" width="19%">Date
                                                                    </td>
                                                                    <td align="center" valign="top" width="2%">:
                                                                    </td>
                                                                    <td align="left" valign="top" style="padding-left: 5px;">
                                                                        <asp:TextBox ID="txtACI_Notes_Date" runat="server" SkinID="txtDate" MaxLength="12" autocomplete="off"
                                                                            onpaste="return false"></asp:TextBox>
                                                                        <img alt="Report Date" onclick="return showCalendar('<%= txtACI_Notes_Date.ClientID %>', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                            align="middle" />
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="vsErrorGroup"
                                                                            Display="none" ErrorMessage="[ACI Notes Grid]/Date Sonic is not a valid date"
                                                                            SetFocusOnError="true" ControlToValidate="txtDate_Sent" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtCurrentDate"
                                                                            ControlToValidate="txtACI_Notes_Date" Display="None" Text="*" ErrorMessage="[ACI Notes Grid]/Date should not be greater than current date."
                                                                            Operator="LessThanEqual" Type="Date" ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                                                                    </td>
                                                                    <td align="left" valign="top" width="19%">Note
                                                                    </td>
                                                                    <td align="center" valign="top" width="2%">:
                                                                    </td>
                                                                    <td align="left" valign="top" style="padding-left: 5px;">
                                                                        <asp:TextBox ID="txtACI_Notes" runat="server" Width="160px" MaxLength="100"></asp:TextBox>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left"></td>
                                                                    <td align="center"></td>
                                                                    <td align="left" colspan="4">
                                                                        <asp:Button ID="btnACINotesAdd" OnClick="btnACINotesAdd_Click" runat="server" ValidationGroup="vsErrorGroup"
                                                                            Text="Add" Width="70px"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
                                                                        <asp:Button ID="btnACINotesCancel" OnClick="btnACINotesCancel_Click" runat="server" Text="Cancel" Width="70px"></asp:Button>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trSONICNotesGrid">
                                                        <td align="left" valign="top">Sonic Notes Grid
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td>
                                                                        <asp:GridView ID="gvSonic_Notes" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                            PageSize="6" EnableViewState="true" AllowPaging="true" OnRowCommand="gvSonic_Notes_RowCommand"
                                                                            OnPageIndexChanging="gvSonic_Notes_PageIndexChanging">
                                                                            <Columns>
                                                                                <asp:TemplateField>
                                                                                    <ItemStyle Width="5%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:HiddenField ID="hdnPK_ACI_Event_Notes" runat="server" Value='<%# Eval("PK_Sonic_Event_Notes") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Note Date">
                                                                                    <ItemStyle Width="20%" />
                                                                                    <ItemTemplate>
                                                                                        <a href="javascript:function(){return false};" onclick="AciNotePopup('<%#Eval("PK_Sonic_Event_Notes") %>','SONIC');">
                                                                                            <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Note_Date")) %></a>
                                                                                        <%--<asp:LinkButton ID="lblNote_Date" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Note_Date")) %>'
                                                                                                    CommandArgument='<%#Eval("PK_Sonic_Event_Notes") %>' CommandName="ViewSonicNote"
                                                                                                CausesValidation="false"></asp:LinkButton>--%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Notes">
                                                                                    <ItemStyle Width="45%" />
                                                                                    <ItemTemplate>
                                                                                        <a href="javascript:function(){return false};" onclick="AciNotePopup('<%#Eval("PK_Sonic_Event_Notes") %>','SONIC');">
                                                                                            <%#Eval("Note") %>
                                                                                        </a>
                                                                                        <%--<asp:LinkButton ID="lblNotes" runat="server" Text='<%#Eval("Note") %>' CommandArgument='<%#Eval("PK_Sonic_Event_Notes") %>'
                                                                                                CommandName="ViewSonicNote" CausesValidation="false"></asp:LinkButton>--%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton runat="server" ID="lnkEdit" Text=" Edit " CommandName="EditRecord" CommandArgument='<%#Eval("PK_Sonic_Event_Notes") %>'>
                                                                                        </asp:LinkButton>
                                                                                        &nbsp;&nbsp;&nbsp;
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Delete" CommandArgument='<%#Eval("PK_Sonic_Event_Notes") %>'
                                                                                CommandName="RemoveSonicNote" OnClientClick="return confirm('Are you sure to remove ACI Note record?');"
                                                                                CausesValidation="false" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <EmptyDataTemplate>
                                                                                <table cellpadding="4" cellspacing="0" width="100%">
                                                                                    <tr>
                                                                                        <td width="100%" align="center" style="border: 1px solid #cccccc;">
                                                                                            <asp:Label ID="lblEmptyHeaderGridMessage" runat="server" Text="No Record Found"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </EmptyDataTemplate>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding-bottom: 5px;">
                                                                        <asp:LinkButton Style="display: inline" ID="lnkAddSONICNoteNew" OnClick="lnkAddSONICNotesNew_Click"
                                                                            runat="server" Text="Add New"></asp:LinkButton>&nbsp;&nbsp;&nbsp;
                                                                    <asp:LinkButton Style="display: none" ID="lnkSONICNotesCancel"
                                                                        runat="server" Text="Cancel"></asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trSONICNotes" style="display: none;">
                                                        <td colspan="6">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        <b>Sonic Notes Grid </b>
                                                                    </td>
                                                                    <td align="center" valign="top" colspan="5">&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <%--<td align="left" valign="top" width="19%">Date
                                                                        </td>
                                                                        <td align="center" valign="top" width="2%">:
                                                                        </td>
                                                                        <td align="left" valign="top"  style="padding-left:5px;" >
                                                                            <asp:TextBox ID="txtSONIC_Notes_Date" runat="server"   SkinID="txtDate" MaxLength="12" autocomplete="off"
                                                                                onpaste="return false"></asp:TextBox>
                                                                           <img alt="Report Date" onclick="return showCalendar('<%= txtSONIC_Notes_Date.ClientID %>', 'mm/dd/y');"
                                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                                align="middle" />
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="vsErrorGroup"
                                                                                Display="none" ErrorMessage="[SONIC Notes Grid]/Date Sonic is not a valid date"
                                                                                SetFocusOnError="true" ControlToValidate="txtDate_Sent" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtCurrentDate"
                                                                                ControlToValidate="txtSONIC_Notes_Date" Display="None" Text="*" ErrorMessage="[SONIC Notes Grid]/Date should not be greater than current date."
                                                                                Operator="LessThanEqual" Type="Date" ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                                                                        </td>--%>
                                                                    <td align="left" valign="top" width="19%">Note
                                                                    </td>
                                                                    <td align="center" valign="top" width="2%">:
                                                                    </td>
                                                                    <td align="left" valign="top" colspan="4" style="padding-left: 5px;">
                                                                        <uc:ctrlMultiLineTextBox ID="txtSonic_Notes" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left"></td>
                                                                    <td align="center"></td>
                                                                    <td align="left" colspan="4">
                                                                        <asp:Button ID="btnSONICNotesAdd" OnClick="btnSONICNotesAdd_Click" runat="server" ValidationGroup="vsErrorGroup" OnClientClick="javascript:return checkLength();"
                                                                            Text="Add" Width="70px"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
                                                                        <asp:Button ID="btnSONICNotesCancel" OnClick="btnSONICNotesCancel_Click" runat="server" Text="Cancel" Width="70px"></asp:Button>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Event Image
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:FileUpload Width="200px" ID="fpFile1" runat="server" />
                                                            <asp:Image ID="ImgEvent_Image" runat="server" Height="200" Width="200" />
                                                            <asp:HiddenField ID="hdnImageName" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <div class="bandHeaderRow">
                                                                Contact Information
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Spacer" colspan="6">

                                                            <asp:UpdatePanel runat="server" ID="updStep2">
                                                                <ContentTemplate>
                                                                    <table cellpadding="3" cellspacing="1" width="100%" border="0">
                                                                        <tr runat="server" id="trContactNamedrp">
                                                                            <td align="left" style="width: 88px">Name
                                                                            </td>
                                                                            <td align="center" width="4%">:
                                                                            </td>
                                                                            <td align="left" width="28%">
                                                                                <asp:DropDownList runat="server" ID="ddlName" SkinID="ddlSONIC" OnSelectedIndexChanged="ddlName_SelectedIndexChanged"
                                                                                    AutoPostBack="True" onchange="CheckDummyVal();">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td align="left" width="18%">&nbsp;
                                                                            </td>
                                                                            <td align="center" width="4%">&nbsp;
                                                                            </td>
                                                                            <td align="left" width="28%">&nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr runat="server" id="trContactNametxt">
                                                                            <td align="left" style="width: 88px">Name(First,Middle,Last)
                                                                            </td>
                                                                            <td align="center" width="4%">:
                                                                            </td>
                                                                            <td align="left" width="28%">
                                                                                <asp:TextBox ID="txtFirstNameContact" runat="server" Width="170px"></asp:TextBox>
                                                                            </td>
                                                                            <td align="left" width="18%">&nbsp;<asp:TextBox ID="txtMiddleNameContact" runat="server" Width="170px"></asp:TextBox>
                                                                            </td>
                                                                            <td align="center" width="4%">&nbsp;
                                                                            </td>
                                                                            <td align="left" width="28%">&nbsp;<asp:TextBox ID="txtLastNameContact" runat="server" Width="170px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" style="width: 88px">Title
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left" colspan="3">
                                                                                <asp:TextBox runat="server" ID="txtTitle" Width="170px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" style="width: 88px">Telephone Number 1<br />
                                                                                (xxx-xxx-xxxx)
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left" colspan="3">
                                                                                <asp:TextBox runat="server" ID="txtTelephoneNumber1" Width="170px" Enabled="true"
                                                                                    MaxLength="12"></asp:TextBox>
                                                                                <cc1:MaskedEditExtender ID="mskPhone" runat="server" TargetControlID="txtTelephoneNumber1"
                                                                                    Mask="999-999-9999" MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false">
                                                                                </cc1:MaskedEditExtender>
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtTelephoneNumber1"
                                                                                    runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Telephone Number 1 in xxx-xxx-xxxx format."
                                                                                    Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" style="width: 88px">Telephone Number 2<br />
                                                                                (xxx-xxx-xxxx)
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left" colspan="3">
                                                                                <asp:TextBox runat="server" ID="txtTelephoneNumber2" Width="170px" Enabled="true"
                                                                                    MaxLength="12"></asp:TextBox>
                                                                                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtTelephoneNumber2"
                                                                                    Mask="999-999-9999" MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false">
                                                                                </cc1:MaskedEditExtender>
                                                                                <asp:RegularExpressionValidator ID="revtxtTelephoneNumber2" ControlToValidate="txtTelephoneNumber2"
                                                                                    runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Telephone Number 2 in xxx-xxx-xxxx format."
                                                                                    Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" style="width: 88px">Email Address
                                                                            </td>
                                                                            <td align="center">:
                                                                            </td>
                                                                            <td align="left" colspan="3">
                                                                                <asp:TextBox runat="server" ID="txtEmailAddress" Width="170px" Enabled="true" MaxLength="100"></asp:TextBox>
                                                                                <asp:RegularExpressionValidator ID="revEmail" runat="server" Display="None" ControlToValidate="txtEmailAddress"
                                                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="vsErrorGroup"
                                                                                    ErrorMessage="Email Address is not valid.">
                                                                                </asp:RegularExpressionValidator></td>
                                                                        </tr>
                                                                    </table>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="ddlLocation" EventName="SelectedIndexChanged" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <%--<tr>
                                                        <td align="left" valign="top">
                                                            Date Sent to Client
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                           <asp:TextBox ID="txtDateSentToClient" runat="server" SkinID="txtDate" />
                                                            <img alt="Report Date" onclick="return showCalendar('<%= txtDateSentToClient.ClientID %>', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revtxtDateSentToClient" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[Event]/Date Sent to Client is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtDateSentToClient" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            <asp:CompareValidator ID="cmptxtDateSentToClient" runat="server" ControlToCompare="txtCurrentDate"
                                                                ControlToValidate="txtDateSentToClient" Display="None" Text="*" ErrorMessage="[Event]/Date Sent to Client should not be greater than current date."
                                                                Operator="LessThanEqual" Type="Date" ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            Sonic Event
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:DropDownList ID="ddlSonicEvent" runat="server" Width="175px">
                                                                <asp:ListItem Selected="True" Text="-- Select --" Value=""></asp:ListItem>
                                                                <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td colspan="6" class="spacer" style="height: 30px"></td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <%--<asp:Panel ID="pnl2" runat="server" Style="display: none;" Width="794px">
                                                <div class="bandHeaderRow">
                                                    Company Information</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td style="height: 5px" colspan="6">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Company
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtCompany" runat="server" SkinID="" MaxLength="60" Width="170px"></asp:TextBox>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            Location
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:DropDownList ID="ddlCompanyLocation" runat="server" Width="175px">
                                                            </asp:DropDownList>
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
                                                            <asp:TextBox ID="txtCompanyAddress1" runat="server" MaxLength="100" SkinID="" Width="170px"></asp:TextBox>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Address 2
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtCompanyAddress2" runat="server" MaxLength="100" SkinID="" Width="170px"></asp:TextBox>
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
                                                            <asp:TextBox ID="txtCompanyCity" runat="server" SkinID="" MaxLength="60" Width="170px"></asp:TextBox>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            State
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="ddlCompanyState" runat="server" Width="170">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Zipcode
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtCompanyZipcode" runat="server" MaxLength="10" SkinID="txtZipCode"
                                                                Width="170px" onKeyPress="javascript:return FormatZipCode(event,this.id);"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="revtxtCompanyZipcode" runat="server" ErrorMessage="[Company Information] Zipcode is not valid"
                                                                SetFocusOnError="true" ControlToValidate="txtCompanyZipcode" ValidationExpression="\b[0-9]{5}-[0-9]{4}\b|\b[0-9]{5}\b"
                                                                ValidationGroup="vsErrorGroup" Display="none" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Country
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="ddlCompanyCountry" runat="server" Width="175px">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <b>Company Contact</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Name(First, Middle, Last)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtCompanyContactFirstName" runat="server" SkinID="txtDisabled"
                                                                Width="170px"></asp:TextBox>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            <asp:TextBox ID="txtCompanyContactMiddleName" runat="server" SkinID="txtDisabled"
                                                                Width="170px"></asp:TextBox>
                                                        </td>
                                                        <td align="center" valign="top">
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtCompanyContactLastName" runat="server" SkinID="txtDisabled" Width="170px"></asp:TextBox>
                                                            <asp:Button ID="btnAdjuster" runat="server" Text="V" OnClientClick="javascript:OpenPopupContact('Company Contact');return false;" />
                                                            <asp:HiddenField ID="hdnCompanyContact" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Phone
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtCompanyPhone" runat="server" MaxLength="12" SkinID="txtPhone"
                                                                Width="170px"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="revtxtCompanyPhone" ControlToValidate="txtCompanyPhone"
                                                                runat="server" ErrorMessage="Please Enter Company Phone in XXX-XXX-XXXX format."
                                                                ValidationGroup="vsErrorGroup" Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Email
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtEmail" runat="server" SkinID="" MaxLength="30" Width="170px"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegtxtEmail" runat="server" ControlToValidate="txtEmail"
                                                                Display="None" ErrorMessage="Please Enter Valid [Company Information]/Email Address"
                                                                SetFocusOnError="True" ValidationGroup="vsErrorGroup" ToolTip="Please Enter Valid [Company Information]/Email Address"
                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Facsimile
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtCompanyfax" runat="server" SkinID="txtPhone" MaxLength="12" Width="170px"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="regtxtCompanyfax" ControlToValidate="txtCompanyfax"
                                                                ValidationGroup="vsErrorGroup" runat="server" ErrorMessage="Please Enter Company Facsimile in XXX-XXX-XXXX format."
                                                                Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" class="spacer" style="height: 5px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl3" runat="server" Style="display: none;" Width="794px">
                                                <div class="bandHeaderRow">
                                                    Vehicle Information</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td style="height: 5px" colspan="6">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Vehicle Number
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtVehicleNo" runat="server" SkinID="" MaxLength="20" Width="170px"></asp:TextBox>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            VIN
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtVIN" runat="server" SkinID="" MaxLength="30" Width="170px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Make
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtMake" runat="server" MaxLength="30" SkinID="" Width="170px"></asp:TextBox>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Model
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtModel" runat="server" SkinID="" MaxLength="30" Width="170px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Year
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtYear" runat="server" SkinID="" MaxLength="4" Width="170px" onblur="javascript:return YearRange(this,'1920','2020')"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="revtxtYear" runat="server" ControlToValidate="txtYear"
                                                                Display="none" SetFocusOnError="false" ErrorMessage="[Vehicle Information ]/ Year is Invalid."
                                                                ValidationGroup="vsErrorGroup" ValidationExpression="[\d]{4}"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Company Tiled
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtVehicleCompanyTiled" runat="server" MaxLength="20" SkinID=""
                                                                Width="170px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            License Tag
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtLicenseTag" runat="server" SkinID="" MaxLength="20" Width="170px"></asp:TextBox>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            State Registered
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="ddlStateRegistered" runat="server" Width="170px">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" class="spacer" style="height: 5px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl4" runat="server" Style="display: none;" Width="794px">
                                                <div class="bandHeaderRow">
                                                    Police Information</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td style="height: 5px" colspan="6">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Police Dept. Name
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtPoliceDeptName" runat="server" SkinID="" MaxLength="60" Width="170px"></asp:TextBox>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            Phone
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtPolicePhone" runat="server" SkinID="txtPhone" MaxLength="12"
                                                                Width="170px"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="revtxtPolicePhone" ControlToValidate="txtPolicePhone"
                                                                ValidationGroup="vsErrorGroup" runat="server" ErrorMessage="Please Enter [Police Information]/ Phone in XXX-XXX-XXXX format."
                                                                Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Office Name(First, Middle, Last)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtOfficeFirstName" runat="server" SkinID="" MaxLength="30" Width="170px"></asp:TextBox>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            <asp:TextBox ID="txtOfficerMiddleName" runat="server" SkinID="" MaxLength="30" Width="170px"></asp:TextBox>
                                                        </td>
                                                        <td align="center" valign="top">
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtOfficerLastName" runat="server" SkinID="" MaxLength="30" Width="170px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Badge Number
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtBadgeNo" runat="server" SkinID="" MaxLength="20" Width="170px"></asp:TextBox>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Fax
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtPoliceFax" runat="server" SkinID="txtPhone" MaxLength="12" Width="170px"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="revtxtPoliceFax" ControlToValidate="txtPoliceFax"
                                                                runat="server" ErrorMessage="Please Enter [Police Information]/ Fax in XXX-XXX-XXXX format."
                                                                ValidationGroup="vsErrorGroup" Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Cell Phone
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtPoliceCellNo" runat="server" SkinID="txtPhone" MaxLength="12"
                                                                Width="170px"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="revtxtPoliceCellNo" ControlToValidate="txtPoliceCellNo"
                                                                runat="server" ErrorMessage="Please Enter [Police Information]/ Cell Phone in XXX-XXX-XXXX format."
                                                                ValidationGroup="vsErrorGroup" Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            City
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtPoliceCity" runat="server" SkinID="" MaxLength="60" Width="170px"></asp:TextBox>
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
                                                            <asp:TextBox ID="txtPoliceAddress1" runat="server" SkinID="" MaxLength="100" Width="170px"></asp:TextBox>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            State
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="ddlPoliceState" runat="server" Width="170px">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Address 2
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtPoliceAddress2" runat="server" MaxLength="100" SkinID="" Width="170px"></asp:TextBox>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            ZIP
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtPoliceZip" runat="server" MaxLength="10" SkinID="txtZipCode"
                                                                Width="170px" onKeyPress="javascript:return FormatZipCode(event,this.id);"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="revtxtPoliceZip" runat="server" ErrorMessage="[Police Information]/ Zip is not valid"
                                                                SetFocusOnError="true" ControlToValidate="txtPoliceZip" ValidationExpression="\b[0-9]{5}-[0-9]{4}\b|\b[0-9]{5}\b"
                                                                ValidationGroup="vsErrorGroup" Display="none" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Jurisdiction
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtJurisdiction" runat="server" SkinID="" MaxLength="60" Width="170px"></asp:TextBox>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Report Number
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtPoliceReportNo" runat="server" SkinID="" MaxLength="20" Width="170px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Case Number
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtCaseNo" runat="server" SkinID="" MaxLength="20" Width="170px"></asp:TextBox>
                                                        </td>
                                                        <td align="left" valign="top">
                                                        </td>
                                                        <td align="center" valign="top">
                                                        </td>
                                                        <td align="left" valign="top">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Date Report Ordered
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtPoliceReportOrderDate" runat="server" SkinID="txtDate" />
                                                            <img alt="Report Date" onclick="return showCalendar('<%= txtPoliceReportOrderDate.ClientID %>', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revtxtPoliceReportOrderDate" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[Police Information]/Date Report Ordered is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtPoliceReportOrderDate" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            <asp:CompareValidator ID="cmptxtPoliceReportOrderDate" runat="server" ControlToCompare="txtCurrentDate"
                                                                ControlToValidate="txtPoliceReportOrderDate" Display="None" Text="*" ErrorMessage="[Police Information]/Date Report Ordered should not be greater than current date."
                                                                Operator="LessThanEqual" Type="Date" ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Date Report Received
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtPoliceReportReceivedDate" runat="server" SkinID="txtDate" />
                                                            <img alt="Report Date" onclick="return showCalendar('<%= txtPoliceReportReceivedDate.ClientID %>', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revtxtPoliceReportReceivedDate" runat="server"
                                                                ValidationGroup="vsErrorGroup" Display="none" ErrorMessage="[Police Information]/Date Report Received is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtPoliceReportReceivedDate" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            <asp:CompareValidator ID="cmptxtPoliceReportReceivedDate" runat="server" ControlToCompare="txtCurrentDate"
                                                                ControlToValidate="txtPoliceReportReceivedDate" Display="None" Text="*" ErrorMessage="[Police Information]/Date Report Received should not be greater than current date."
                                                                Operator="LessThanEqual" Type="Date" ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" class="spacer" style="height: 5px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>--%>
                                        </div>
                                        <div id="dvView" runat="server" width="794px">
                                            <asp:Panel ID="pnl1view" runat="server" Style="display: none;" Width="794px">
                                                <div class="bandHeaderRow">
                                                    Event
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td style="height: 5px" colspan="6"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Event Number
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblEventNumber" runat="server" />
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Location
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblLocation" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Event Type
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblEventType" runat="server" />
                                                            <asp:ListBox runat="server" ID="lbllstEventType" SelectionMode="Multiple" Width="170px" Visible="false"></asp:ListBox>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Event Description
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblEvent_Desc" runat="server" />
                                                            <%--<asp:Label ID="lblFK_LU_Event_Description" runat="server" />--%>
                                                            <asp:ListBox runat="server" ID="lbllstEventDescription" SelectionMode="Multiple" Width="175px" Visible="false"></asp:ListBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Other Type
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label runat="server" ID="lblOther_Event_Type" MaxLength="50" Width="170px" Style="word-wrap: normal; word-break: break-all;"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Other Description
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblOther_Event_Desc" runat="server" MaxLength="50" Width="170px" Style="word-wrap: normal; word-break: break-all;"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Camera Name
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblCameraName" runat="server" Style="word-wrap: normal; word-break: break-all;" />
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Camera Number
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <%--<asp:Label ID="lblEvent_Desc" runat="server" />--%>
                                                            <asp:Label ID="lblCameraNumber" runat="server" Style="word-wrap: normal; word-break: break-all;" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Sonic Event
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblFK_LU_Sonic_Event" runat="server" />
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Date Sent to Sonic
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblDate_Sent" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <%-- <td align="left" width="18%" valign="top">
                                                            Date Opened
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblDate_Opened" runat="server" />
                                                        </td>--%>
                                                        <td align="left" valign="top">Investigation Report Date
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblInvestigationDate" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">Event Report Date
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblEventReportDate" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Event Occurrence Date
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblEventOccuranceDate" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                        <td align="center" valign="top">&nbsp;
                                                        </td>
                                                        <td align="left" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Event Start Time
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblEvent_Start_Time" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">Event End Time
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblEvent_End_Time" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">ACI Notes Grid
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">


                                                            <asp:GridView ID="gvACI_NotesView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                PageSize="6" EnableViewState="true" AllowPaging="true" OnPageIndexChanging="gvACI_Notes_PageIndexChanging"
                                                                OnRowCommand="gvACI_Notes_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="5%" />
                                                                        <ItemTemplate>
                                                                            <asp:HiddenField ID="hdnPK_ACI_Event_Notes" runat="server" Value='<%# Eval("PK_ACI_Event_Notes") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Note Date">
                                                                        <ItemStyle Width="25%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:function(){return false};" onclick="AciNotePopup('<%#Eval("PK_ACI_Event_Notes") %>','ACI');">
                                                                                <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Note_Date")) %></a>
                                                                            <%--<asp:LinkButton ID="lblNote_Date" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Note_Date")) %>'
                                                                                CommandArgument='<%#Eval("PK_ACI_Event_Notes") %>' CommandName="ViewNote" CausesValidation="false"></asp:LinkButton>--%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Notes">
                                                                        <ItemStyle Width="55%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:function(){return false};" onclick="AciNotePopup('<%#Eval("PK_ACI_Event_Notes") %>','ACI');">
                                                                                <%#Eval("Note") %>
                                                                            </a>
                                                                            <%--<asp:LinkButton ID="lblNotes" runat="server" Text='' CommandArgument='<%#Eval("PK_ACI_Event_Notes") %>'
                                                                                CommandName="ViewNote" CausesValidation="false"></asp:LinkButton>--%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <table cellpadding="4" cellspacing="0" width="100%">
                                                                        <tr>
                                                                            <td width="100%" align="center" style="border: 1px solid #cccccc;">
                                                                                <asp:Label ID="lblEmptyHeaderGridMessage" runat="server" Text="No Record Found"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                    </tr>

                                                    <tr>
                                                        <td colspan="6">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Sonic Notes Grid
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:GridView ID="gvSonic_NotesView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                PageSize="6" EnableViewState="true" AllowPaging="true" OnPageIndexChanging="gvSonic_Notes_PageIndexChanging"
                                                                OnRowCommand="gvSonic_Notes_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="5%" />
                                                                        <ItemTemplate>
                                                                            <asp:HiddenField ID="hdnPK_ACI_Event_Notes" runat="server" Value='<%# Eval("PK_Sonic_Event_Notes") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Note Date">
                                                                        <ItemStyle Width="20%" />
                                                                        <ItemTemplate>
                                                                            <%--<asp:LinkButton ID="lnkNoteDate" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Note_Date")) %>'
                                                                                CommandArgument='<%#Eval("PK_Sonic_Event_Notes") %>' CommandName="ViewSonicNote"
                                                                                CausesValidation="false"></asp:LinkButton>--%>
                                                                            <a href="javascript:function(){return false};" onclick="AciNotePopup('<%#Eval("PK_Sonic_Event_Notes") %>','SONIC');">
                                                                                <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Note_Date")) %>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Notes">
                                                                        <ItemStyle Width="45%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:function(){return false};" onclick="AciNotePopup('<%#Eval("PK_Sonic_Event_Notes") %>','SONIC');">
                                                                                <%#Eval("Note") %>
                                                                            </a>
                                                                            <%--<asp:LinkButton ID="lnkNote" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Note")) %>'
                                                                                CommandArgument='<%#Eval("PK_Sonic_Event_Notes") %>' CommandName="ViewSonicNote"
                                                                                CausesValidation="false"></asp:LinkButton>--%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <table cellpadding="4" cellspacing="0" width="100%">
                                                                        <tr>
                                                                            <td width="100%" align="center" style="border: 1px solid #cccccc;">
                                                                                <asp:Label ID="lblEmptyHeaderGridMessage" runat="server" Text="No Record Found"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Event Image
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Image ID="lblImgEvent_Image" runat="server" Height="200" Width="200" />
                                                        </td>
                                                    </tr>
                                                    <%--<tr>
                                                        <td align="left" valign="top">
                                                            Date Sent to Client
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblDateSendToClient" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Sonic Event
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblSonicEvent" runat="server" />
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td colspan="6" class="spacer" style="height: 5px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <div class="bandHeaderRow">
                                                                Contact Information
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Spacer" colspan="6">
                                                            <table cellpadding="3" cellspacing="1" width="100%" border="0">

                                                                <tr>
                                                                    <td align="left" style="width: 88px">Name(First,Middle,Last)
                                                                    </td>
                                                                    <td align="center" width="4%">:
                                                                    </td>
                                                                    <td align="left" width="28%">
                                                                        <asp:Label ID="lblFirstName" runat="server"></asp:Label>&nbsp;
                                                                        <asp:Label ID="lblMiddleName" runat="server"></asp:Label>&nbsp;
                                                                        <asp:Label ID="lblLastName" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" width="18%">&nbsp;
                                                                    </td>
                                                                    <td align="center" width="4%">&nbsp;
                                                                    </td>
                                                                    <td align="left" width="28%">&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="width: 88px">Title
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left" colspan="3">
                                                                        <asp:Label runat="server" ID="lblTitle"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="width: 88px">Telephone Number 1<br />
                                                                        (xxx-xxx-xxxx)
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left" colspan="3">
                                                                        <asp:Label runat="server" ID="lblTelephone1"></asp:Label>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="width: 88px">Telephone Number 2<br />
                                                                        (xxx-xxx-xxxx)
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left" colspan="3">
                                                                        <asp:Label runat="server" ID="lblTelephone2"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="width: 88px">Email Address
                                                                    </td>
                                                                    <td align="center">:
                                                                    </td>
                                                                    <td align="left" colspan="3">
                                                                        <asp:Label runat="server" ID="lblEmail"></asp:Label>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <%--   <asp:Panel ID="pnl2view" runat="server" Style="display: none;" Width="794px">
                                                <div class="bandHeaderRow">
                                                    Company Information</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td style="height: 5px" colspan="6">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Company
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblCompanyName" runat="server" />
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            Location
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblCompanyLocation" runat="server" />
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
                                                            <asp:Label ID="lblCompanyAddress1" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Address 2
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCompanyAddress2" runat="server" />
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
                                                            <asp:Label ID="lblCompanyCity" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            State
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCompanyState" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Zipcode
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCompanyZipCode" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Country
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCompanyCountry" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <b>Company Contact</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Name(First, Middle, Last)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCompanyContactFirstName" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCompanyContactMiddleName" runat="server" />
                                                        </td>
                                                        <td align="center" valign="top">
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCompanContactLastName" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Phone
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCompanyPhone" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Email
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblComapnyEmail" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Facsimile
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCompanyFax" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" class="spacer" style="height: 5px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl3view" runat="server" Style="display: none;" Width="794px">
                                                <div class="bandHeaderRow">
                                                    Vehicle Information</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td style="height: 5px" colspan="6">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Vehicle Numbe
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblVehicleNo" runat="server" />
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            VIN
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblVIN" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Make
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblVehicleMake" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Model
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblVehicleModel" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Year
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblVehicleYear" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Company Tiled
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCompanyTiled" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            License Tag
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLicenseTag" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            State Registered
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblVehicleStateRegistered" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" class="spacer" style="height: 5px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl4view" runat="server" Style="display: none;" Width="794px">
                                                <div class="bandHeaderRow">
                                                    Police Information</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td style="height: 5px" colspan="6">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Police Dept. Name
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblPoliceDeptName" runat="server" />
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            Phone
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblPolicePhone" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Office Name(First, Middle, Last)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblOfficeFirstName" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblOfficerMiddleName" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblOfficerLastName" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Badge Number
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblBadgeNo" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Fax
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblPoliceFax" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Cell Phone
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblPoliceCellPhone" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            City
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblPoliceCity" runat="server" />
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
                                                            <asp:Label ID="lblPoliceAddress1" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            State
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblPoliceState" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Address 2
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblPoliceAddress2" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            ZIP
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblPoliceZip" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Jurisdiction
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblJurisdiction" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Report Number
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblPoliceReportNumber" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Case Number
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblPoliceCardNo" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                        </td>
                                                        <td align="center" valign="top">
                                                        </td>
                                                        <td align="left" valign="top">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Date Report Ordered
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblPoliceReportOrderedDate" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Date Report Received
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblPoliceReportReceivedDate" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" class="spacer" style="height: 5px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>--%>
                                        </div>
                                    </td>

                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <div id="dvSave" runat="server">
                                <table cellpadding="5" cellspacing="5" border="0" width="100%">
                                    <tr>
                                        <td width="100%" align="center">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <%--<asp:Button ID="btnPreviousStep" ToolTip="Previous Step" runat="server" Text="Previous Step"
                                                            OnClick="btnPreviousStep_Click" CausesValidation="false" OnClientClick="return  onPreviousStep();" />--%>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnSave" runat="server" ToolTip="Save & Continue Editing" Text="Save & Continue Editing"
                                                            OnClick="btnSave_Click" CausesValidation="true" ValidationGroup="vsErrorGroup"
                                                            Width="170px" OnClientClick="CheckBeforeSave();return false;" />
                                                        <asp:Button ID="btnSaveHidden" runat="server" OnClick="btnSaveHidden_Click" Style="display: none" />
                                                        <asp:Button ID="btnBack" runat="server" ToolTip="Edit" Text="  Edit  " CausesValidation="false"
                                                            OnClick="btnBack_Click" />
                                                        &nbsp; &nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false"
                                OnClick="btnCancel_Click" />
                                                        &nbsp; &nbsp;
                                                        <%--<asp:Button ID="btnNextStep" runat="server" ToolTip="Next Step" Text="Next Step"
                                                            CausesValidation="true" ValidationGroup="vsErrorGroup" OnClientClick="javascript:return onNextStep();"
                                                            OnClick="btnNextStep_Click" />--%>
                                                        <asp:Button ID="btnViewAudit" runat="server" Text="View Audit Trail" CausesValidation="false"
                                                            ToolTip="View Audit Trail" OnClientClick="javascript:return AuditPopUp();" />&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
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
    <asp:HiddenField ID="pnl" runat="server" />
    <asp:HiddenField ID="hdnPanel" runat="server" Value="1" />
</asp:Content>
