<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="Event_New.aspx.cs" Inherits="Event_Event_New" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Src="~/Controls/IncidentTab/IncidentTab.ascx" TagName="IncidentTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/IncidentInfo/IncidentInfo.ascx" TagName="IncidentInfo" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment_Event/AttachmentEvent.ascx" TagName="Attachment" TagPrefix="uc" %>
<%@ Register Src="~/Controls/EventInfo/EventInfo.ascx" TagName="EventInfo" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/jquery.maskedinput.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Date_Validation.js"></script>
  
    <script type="text/javascript">
        var GB_ROOT_DIR = '<%=AppConfig.SiteURL%>' + 'greybox/';
        function checkLength() 
        {
              var oObject = document.getElementById('ctl00_ContentPlaceHolder1_txtACI_Notes_txtNote') 
              if (oObject.value.length < 50)
              {
                  alert("Please enter minimum 50 Characters for Notes.");
                  return false;
              }
              else
              {
                  return true;            
              }              
        }

        function checkLengthSonic() 
        {
            if (Page_ClientValidate("vsErrorGroup"))
            {
                var oObject = document.getElementById('ctl00_ContentPlaceHolder1_txtSonic_Notes_txtNote') 
                if (oObject.value.length < 50)
                {
                    alert("Please enter minimum 50 Characters for Notes.");
                    return false;
                }
                else
                {
                    return true;            
                }        
            }
            else
                return false;
        }

        function valSaveEvent() 
        {
            if (Page_ClientValidate("vsErrorGroup"))
            {
                if (Page_ClientValidate("vsErrorEvent_Camera"))
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        function valSaveEventSonic() 
        {
            if (Page_ClientValidate("vsErrorGroup"))
            {
                if (Page_ClientValidate("vsErrorEvent_Camera_Sonic"))
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        function AciNotePopup(NoteId, type) {            
            var winHeight = 500;
            var winWidth = 500;
            var EventId = <%=ViewState["PK_Event"]%>;            
            obj = window.open("Event_Note.aspx?nid=" + NoteId + "&id=" + '<%=ViewState["PK_Event"]%>' + "&type=" + type, 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
        }

        function setscroll() {
            document.documentElement.scrollLeft = document.getElementById('<%=hndScrollX.ClientID%>').value;
            document.documentElement.scrollTop = document.getElementById('<%=hndScrollY.ClientID%>').value;
        }

        function getscroll() {
            var x = document.documentElement.scrollLeft;
            var y = document.documentElement.scrollTop;
            document.getElementById('<%=hndScrollX.ClientID%>').value = x;
            document.getElementById('<%=hndScrollY.ClientID%>').value = y;
        }

        function OpenPopupContact(ContactType) {
            ShowDialog('<%=AppConfig.SiteURL %>/Event/PopupContact.aspx?ContactType=' + ContactType, PopupWidth_Contact, PopupHeight_Contact);
        }

		function SetMenuStyle(index) {
        	var i;
			for (i = 1; i <= 5; i++) {
				var tb = document.getElementById("Menu" + i);
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



        var ActiveTabIndex = 1;
        function onNextStep() {
            if (ActiveTabIndex == 5) {
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
            ReportedEventEnableDisable();
            var Is_Sonic_Event = '<%=Is_Sonic_Event%>';
                 if (Is_Sonic_Event != null) {
                     if (Is_Sonic_Event == "True" && index == 1) {
                        index = 2;
                     }
                }

        	SetMenuStyle(index);
			ActiveTabIndex = index;
			document.getElementById("ctl00_ContentPlaceHolder1_hdnPanel").value = ActiveTabIndex;
			var op = '<%=StrOperation%>';
			if (op == "view") {
				ShowPanelView(index);
			}
			else {
				var i;
				for (i = 1; i <= 4; i++) {
					document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display = (i == index) ? "block" : "none";
				}
				document.getElementById('<%=pnlAttachment.ClientID%>').style.display = (index == 5) ? "block" : "none";
			}
//			if (index == 1) document.getElementById("ctl00_ContentPlaceHolder1_btnPreviousStep").style.display = "none";
//			else document.getElementById("ctl00_ContentPlaceHolder1_btnPreviousStep").style.display = "block";
		}



        function ShowPanelView(index) {
            SetMenuStyle(index);
            document.getElementById('ctl00_ContentPlaceHolder1_pnl' + 1 +'view').style.display = "block";
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
            obj = window.open("AuditPopup_Event_New.aspx?id=" + '<%=ViewState["PK_Event"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }

        function SetClosedDate() {
        var rdoStatus = document.getElementById('<%=rdoStatus.ClientID %>');

        for (var i = 0; i < rdoStatus.rows.length; ++i) {

                if (rdoStatus.rows[i].cells[1].firstChild.checked) {
                    var date = new Date();

                    var yyyy = date.getFullYear().toString();
                    var mm = (date.getMonth() + 1).toString();
                    var dd = date.getDate().toString();

                    var mmChars = mm.split('');
                    var ddChars = dd.split('');

                    dateString = (mmChars[1] ? mm : "0" + mmChars[0]) + '/' + (ddChars[1] ? dd : "0" + ddChars[0]) + '/' + yyyy;
                    document.getElementById('<%=txtDate_Closed.ClientID%>').value = dateString;
                }
            }
        }

        function ReportedEventEnableDisable() {
             var Is_Sonic_Event = '<%=Is_Sonic_Event%>';
                 if (Is_Sonic_Event != null) {
                     if (Is_Sonic_Event == "True") {
                         document.getElementById("<%=trACIReportedEvent.ClientID%>").style.display = "none";
                         document.getElementById("<%=trSonicReportedEvent.ClientID%>").style.display = "";
                     }
                     else {
                         document.getElementById("<%=trACIReportedEvent.ClientID%>").style.display = "";
                         document.getElementById("<%=trSonicReportedEvent.ClientID%>").style.display = "none";
                     }
                }
        }

        function OpenFRNumber(FRtype) {
            GB_showCenter('FR Number', '<%=AppConfig.SiteURL%>Event/PopupFirstReport.aspx?ftype='+FRtype, 500, 650, '');
            return false;
        }

        function setAgencyNameSonic()
        {
            var agencyname =  document.getElementById("<%=txtAgency_name.ClientID%>").value;
            var agencynameSonic = document.getElementById("<%=txtAgency_name_Sonic.ClientID%>");
            agencynameSonic.value = agencyname;
        }
        function setOfficerNameSonic()
        {
            var Officername =  document.getElementById("<%=txtOfficer_Name.ClientID%>").value;
            var OfficernameSonic = document.getElementById("<%=txtOfficer_Name_Sonic.ClientID%>");
            OfficernameSonic.value = Officername;
        }
              
        function setPhoneSonic()
        {
            var PhoneNumber =  document.getElementById("<%=txtOfficer_Phone.ClientID%>").value;
            var PhoneNumberSonic = document.getElementById("<%=txtOfficer_Phone_Sonic.ClientID%>");
            PhoneNumberSonic.value = PhoneNumber;
        }

        function setPoliceReportSonic()
        {
            var PoliceReport =  document.getElementById("<%=txtPolice_Report_Number.ClientID%>").value;
            var PoliceReportSonic = document.getElementById("<%=txtPolice_Report_Number_Sonic.ClientID%>");
            PoliceReportSonic.value = PoliceReport;
        }

        function setPolicecalledSonic()
        {
            var rdopolice = document.getElementById("<%=rdoPolice_Called.ClientID%>");
            var rdo = document.getElementById(rdopolice.id + "_0");

            var rdopoliceSonic = document.getElementById("<%=rdoPolice_Called_Sonic.ClientID%>");
            var rdoSonicYes = document.getElementById(rdopoliceSonic.id + "_0");
            var rdoSonicNo = document.getElementById(rdopoliceSonic.id + "_1");

            if (rdo.checked)
            {
                rdoSonicYes.checked = true;
            }
            else
                rdoSonicNo.checked = true;
            
        }
              

    </script>
    <link href="<%=AppConfig.SiteURL%>greybox/gb_styles.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/gb_scripts.js"></script>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" CssClass="errormessage" ValidationGroup="vsErrorGroup"
            BorderColor="DimGray" BorderWidth="1" HeaderText="Verify the following fields:"
            ShowMessageBox="true" ShowSummary="false"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsErrorCamera" runat="server" CssClass="errormessage"
            ValidationGroup="vsErrorEvent_Camera" BorderColor="DimGray" BorderWidth="1" HeaderText="Verify the following fields:"
            ShowMessageBox="true" ShowSummary="false"></asp:ValidationSummary>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="errormessage"
            ValidationGroup="vsErrorOtherVehicle" BorderColor="DimGray" BorderWidth="1" HeaderText="Verify the following fields:"
            ShowMessageBox="true" ShowSummary="false"></asp:ValidationSummary>
        <asp:ValidationSummary ID="vsErrorCameraSonic" runat="server" CssClass="errormessage"
            ValidationGroup="vsErrorEvent_Camera_Sonic" BorderColor="DimGray" BorderWidth="1"
            HeaderText="Verify the following fields:" ShowMessageBox="true" ShowSummary="false">
        </asp:ValidationSummary>
    </div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                <uc:IncidentTab ID="ucIncident" runat="server" />
                <%--<uc:ClaimTab ID="uclaimincidenttab" runat="server" Visible="false" />--%>
            </td>
        </tr>
        <tr>
            <td align="left">
                <%--<uc:IncidentInfo ID="ucIncidentInfo" runat="server" Visible="false" />--%>
                <uc:EventInfo ID="ucEventInfo" runat="server" Visible="false" />
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 10px;">
            </td>
        </tr>
        <tr>
            <td>
                <div class="bandHeaderRow">
                    <table width="100%" border="0" cellpadding="2" cellspacing="0">
                        <tr>
                            <td align="left">
                                Event
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
                        <td class="Spacer" style="height: 10px;" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td class="leftMenu" style="padding-left: 2px;">
                            <table cellpadding="5" cellspacing="0" width="100%">
                                <tr>
                                    <td style="height: 18px;" class="Spacer">
                                    </td>
                                </tr>
                                <tr runat="server" id="trACIReportedEvent">
                                    <td align="left" width="100%">
                                        <span id="Menu1" onclick="javascript:ShowPanel(1);" class="LeftMenuStatic">ACI Reported
                                            Event</span>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu2" onclick="javascript:ShowPanel(2);" class="LeftMenuStatic">Acadian Investigations</span>
                                    </td>
                                </tr>
                                <tr runat="server" id="trSonicReportedEvent">
                                    <td align="left" width="100%">
                                        <span id="Menu3" onclick="javascript:ShowPanel(3);" class="LeftMenuStatic">Sonic Reported
                                            Event</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu4" onclick="javascript:ShowPanel(4);" class="LeftMenuStatic">Insurance Type Claim</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu5" onclick="javascript:ShowPanel(5);" class="LeftMenuStatic">Attachments</span>
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
                                        <asp:HiddenField ID="hndScrollX" runat="server" />
                                        <asp:HiddenField ID="hndScrollY" runat="server" />
                                        <div id="dvEdit" runat="server" width="794px">
                                            <asp:Panel ID="pnl1" runat="server" Style="display: none;" Width="794px">
                                                <div class="bandHeaderRow">
                                                    Event Information
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td style="height: 5px" colspan="6">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Location
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:DropDownList ID="ddlLocation" runat="server" Width="175px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            ACI Event ID
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtACI_EventID" runat="server" MaxLength="30" Width="170px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <u><b>Actionable Event Type</b></u>
                                                        </td>
                                                        <td colspan="3">
                                                            <u><b>Description of Event</b></u>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <asp:Repeater ID="rptEventType" runat="server" OnItemDataBound="rptEventType_ItemDataBound">
                                                                <ItemTemplate>
                                                                    <table cellpadding="4" cellspacing="0" width="100%">
                                                                        <tr>
                                                                            <td width="50%" align="left" valign="top" colspan="2">
                                                                                <asp:CheckBox ID="chkEventType" runat="server" />
                                                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                                                                <asp:Label ID="lblEventType" Text='<%#Eval("Fld_Desc") %>' runat="server"></asp:Label>
                                                                                <asp:Label ID="lblPK_LU_Event_Type" Text='<%#Eval("PK_LU_Event_Type") %>' runat="server"
                                                                                    Style="display: none;"></asp:Label>
                                                                            </td>
                                                                            <td width="18%" align="left" valign="top">
                                                                                <asp:TextBox ID="txtEventDesciption" runat="server" MaxLength="100" Width="170px"></asp:TextBox>
                                                                            </td>
                                                                            <td width="4%" align="center" valign="top">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td width="28%" align="left" valign="top">
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Date of Event
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtCurrentDate" runat="server" Style="display: none"></asp:TextBox>
                                                            <asp:TextBox ID="txtEvent_Start_Date" runat="server" SkinID="txtDate" />
                                                            <img alt="Report Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtEvent_Start_Date', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                align="middle" runat="server" id="imgEvent_Start_Date" />
                                                            <asp:RegularExpressionValidator ID="revReport_Date" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[ACI Reported Event]/Date of Event is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtEvent_Start_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            <asp:CompareValidator ID="cmptxtEventReportDate" runat="server" ControlToCompare="txtCurrentDate"
                                                                ControlToValidate="txtEvent_Start_Date" Display="None" Text="*" ErrorMessage="[ACI Reported Event]/Date of Event should not be greater than current date."
                                                                Operator="LessThanEqual" Type="Date" ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trEvent_Camera" style="display: none;">
                                                        <td colspan="6">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        <b>Camera Grid </b>
                                                                    </td>
                                                                    <td align="center" valign="top" colspan="5">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" width="19%">
                                                                        Camera Name
                                                                    </td>
                                                                    <td align="center" valign="top" width="2%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top" style="padding-left: 5px;">
                                                                        <asp:TextBox ID="txtCamera_Name" runat="server" MaxLength="100" Width="170px"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left" valign="top" width="19%">
                                                                        Camera Number
                                                                    </td>
                                                                    <td align="center" valign="top" width="2%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top" style="padding-left: 5px;">
                                                                        <asp:TextBox ID="txtCamera_Number" runat="server" MaxLength="20" Width="170px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" width="19%">
                                                                        Event Time From
                                                                    </td>
                                                                    <td align="center" valign="top" width="2%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top" style="padding-left: 5px;">
                                                                        <asp:TextBox ID="txtEvent_Time_From" runat="server" MaxLength="5" Width="170px"></asp:TextBox>
                                                                        <cc1:MaskedEditExtender ID="mstxtClaim_Time" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99:99" MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                            AcceptAMPM="false" OnInvalidCssClass="MaskedEditError" TargetControlID="txtEvent_Time_From"
                                                                            CultureName="en-US" AutoComplete="false" ClearMaskOnLostFocus="true">
                                                                        </cc1:MaskedEditExtender>
                                                                        <asp:RegularExpressionValidator ID="revtxtClaim_Time" runat="server" ControlToValidate="txtEvent_Time_From"
                                                                            ValidationExpression="^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$"
                                                                            ErrorMessage="[ACI Reported Event]/Invalid Event Time From" Display="none" ValidationGroup="vsErrorEvent_Camera"
                                                                            SetFocusOnError="true">
                                                                        </asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td align="left" valign="top" width="19%">
                                                                        Event Time To
                                                                    </td>
                                                                    <td align="center" valign="top" width="2%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top" style="padding-left: 5px;">
                                                                        <asp:TextBox ID="txtEvent_Time_To" runat="server" MaxLength="5" Width="170px"></asp:TextBox>
                                                                        <cc1:MaskedEditExtender ID="mstxtEvent_Time_To" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99:99" MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                            AcceptAMPM="false" OnInvalidCssClass="MaskedEditError" TargetControlID="txtEvent_Time_To"
                                                                            CultureName="en-US" AutoComplete="false" ClearMaskOnLostFocus="true">
                                                                        </cc1:MaskedEditExtender>
                                                                        <asp:RegularExpressionValidator ID="revtxtEvent_Time_To" runat="server" ControlToValidate="txtEvent_Time_To"
                                                                            ValidationExpression="^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$"
                                                                            ErrorMessage="[ACI Reported Event]/Invalid Event Time To" Display="none" ValidationGroup="vsErrorEvent_Camera"
                                                                            SetFocusOnError="true">
                                                                        </asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                    </td>
                                                                    <td align="center">
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <asp:Button ID="btnEvent_CameraAdd" OnClick="btnEvent_CameraAdd_Click" runat="server"
                                                                            ValidationGroup="vsErrorEvent_Camera" OnClientClick="javascript:return valSaveEvent();"
                                                                            Text="Add" Width="70px"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
                                                                        <asp:Button ID="btnEvent_CameraCancel" OnClick="btnEvent_CameraCancel_Click" runat="server"
                                                                            Text="Cancel" Width="70px"></asp:Button>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trEvent_CameraGrid">
                                                        <td align="left" valign="top">
                                                            Camera Grid
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:GridView ID="gvEvent_Camera" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                PageSize="6" EnableViewState="true" AllowPaging="true" OnRowCommand="gvEvent_Camera_RowCommand"
                                                                OnPageIndexChanging="gvEvent_Camera_PageIndexChanging">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="1%" />
                                                                        <ItemTemplate>
                                                                            <asp:HiddenField ID="hdnPK_Event_Camera" runat="server" Value='<%# Eval("PK_Event_Camera") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Camera Name">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <%# Eval("Camera_Name")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Camera Number">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <%# Eval("Camera_Number")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Event Time From">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <%# Eval("Event_Time_From")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Event Time To">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <%# Eval("Event_Time_To")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                        <ItemStyle Width="10%" HorizontalAlign="Center" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkEdit" Text=" Edit " CommandName="EditRecord"
                                                                                CommandArgument='<%#Eval("PK_Event_Camera") %>' Visible="false">
                                                                            </asp:LinkButton>
                                                                            &nbsp;&nbsp;&nbsp;
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Delete" CommandArgument='<%#Eval("PK_Event_Camera") %>'
                                                                                CommandName="RemoveEventCamera" OnClientClick="return confirm('Are you sure to remove Event Camera record?');"
                                                                                CausesValidation="false" Visible="false" />
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
                                                            <asp:LinkButton Style="display: inline" ID="lnkAddEvent_CameraNew" OnClick="lnkAddEvent_CameraNew_Click"
                                                                runat="server" Text="Add New"></asp:LinkButton>&nbsp;&nbsp;&nbsp;
                                                            <asp:LinkButton Style="display: none" ID="lnkEvent_CameraCancel" runat="server" Text="Cancel"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <table>
                                                                <tr>
                                                                    <td align="left" width="18%" valign="top">
                                                                        Acadian Investigator Name
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">
                                                                        <asp:TextBox ID="txtInvestigator_Name" runat="server" MaxLength="60" Width="170px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="18%" valign="top">
                                                                        Acadian Investigator Email Address
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">
                                                                        <asp:TextBox ID="txtInvestigator_Email" runat="server" MaxLength="50" Width="170px"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegExpEmailID" runat="server" ControlToValidate="txtInvestigator_Email"
                                                                            Display="None" ErrorMessage="[ACI Reported Event] /Please Enter Valid Acadian Investigator Email Address"
                                                                            SetFocusOnError="True" ValidationGroup="vsErrorGroup" ToolTip="Please Enter Valid Acadian Investigator Email Address"
                                                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="18%" valign="top">
                                                                        Acadian Investigator Phone #
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">
                                                                        <asp:TextBox ID="txtInvestigator_Phone" runat="server" MaxLength="12" Width="170px"
                                                                            SkinID="txtPhone"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="revtxtInvestigator_Phone" ControlToValidate="txtInvestigator_Phone"
                                                                            runat="server" SetFocusOnError="true" ErrorMessage="[ACI Reported Event] / Please Enter Acadian Investigator Phone # in XXX-XXX-XXXX format"
                                                                            Display="none" ValidationGroup="vsErrorGroup" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Event Image
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Image ID="ImgEvent_Image" runat="server" Height="200" Width="200" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl2" runat="server" Style="display: none;" Width="794px">
                                                <div class="bandHeaderRow">
                                                    Acadian Investigations</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td style="height: 5px" colspan="6">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Police Called?
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:RadioButtonList ID="rdoPolice_Called" runat="server" onclick=" return setPolicecalledSonic();">
                                                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" width="18%" valign="top" style="padding-left: 25px;">
                                                                        If Yes:
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left" width="18%" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" style="padding-left: 60px;">
                                                                        Agency Name
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtAgency_name" runat="server" MaxLength="60" Width="170px" onblur="setAgencyNameSonic();"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" style="padding-left: 60px;">
                                                                        Officer Name
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtOfficer_Name" runat="server" MaxLength="60" Width="170px" onblur="setOfficerNameSonic();"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" style="padding-left: 60px;">
                                                                        Phone #
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtOfficer_Phone" runat="server" MaxLength="12" Width="170px" SkinID="txtPhone" onblur="setPhoneSonic();"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="revtxtOfficer_Phone" ControlToValidate="txtOfficer_Phone"
                                                                            runat="server" SetFocusOnError="true" ErrorMessage="[Acadian Investigations] / Please Enter Agency Phone # in XXX-XXX-XXXX format"
                                                                            Display="none" ValidationGroup="vsErrorGroup" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" style="padding-left: 60px;">
                                                                        Police Report #
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtPolice_Report_Number" runat="server" MaxLength="30" Width="170px" onblur="setPoliceReportSonic();"></asp:TextBox>
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
                                                                        <b>Acadian Notes Grid </b>
                                                                    </td>
                                                                    <td align="center" valign="top" colspan="5">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <%--<td align="left" valign="top" width="19%">Date
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
                                                                    </td>--%>
                                                                    <td align="left" valign="top" width="19%">
                                                                        Note
                                                                    </td>
                                                                    <td align="center" valign="top" width="2%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top" style="padding-left: 5px;">
                                                                        <uc:ctrlMultiLineTextBox ID="txtACI_Notes" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                    </td>
                                                                    <td align="center">
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <asp:Button ID="btnACINotesAdd" OnClick="btnACINotesAdd_Click" runat="server" ValidationGroup="vsErrorGroup"
                                                                            OnClientClick="javascript:return checkLength();" Text="Add" Width="70px"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
                                                                        <asp:Button ID="btnACINotesCancel" OnClick="btnACINotesCancel_Click" runat="server"
                                                                            Text="Cancel" Width="70px"></asp:Button>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trACINotesGrid">
                                                        <td align="left" valign="top">
                                                            Acadian Notes Grid
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
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
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Notes">
                                                                        <ItemStyle Width="45%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:function(){return false};" onclick="AciNotePopup('<%#Eval("PK_ACI_Event_Notes") %>','ACI');">
                                                                                <%# Eval("Note") %></a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                        <ItemStyle Width="10%" HorizontalAlign="Center" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkEdit" Text=" Edit " CommandName="EditRecord"
                                                                                CommandArgument='<%#Eval("PK_ACI_Event_Notes") %>' Visible='<%#Convert.ToBoolean(!Is_Closed_Event) %>'>
                                                                            </asp:LinkButton>
                                                                            &nbsp;&nbsp;&nbsp;
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Delete" CommandArgument='<%#Eval("PK_ACI_Event_Notes") %>'
                                                                                CommandName="RemoveACINote" OnClientClick="return confirm('Are you sure to remove Acadian Note record?');"
                                                                                CausesValidation="false" Visible='<%#Convert.ToBoolean(!Is_Closed_Event) %>' />
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
                                                            <asp:LinkButton Style="display: inline" ID="lnkAddACINotesNew" OnClick="lnkAddACINotesNew_Click"
                                                                runat="server" Text="Add New"></asp:LinkButton>&nbsp;&nbsp;&nbsp;
                                                            <asp:LinkButton Style="display: none" ID="lnkACINotesCancel" runat="server" Text="Cancel"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" class="spacer" style="height: 5px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" class="spacer" style="height: 5px">
                                                            <div class="bandHeaderRow">
                                                                Sonic Notes</div>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trSonicNotes" style="display: none;">
                                                        <td colspan="6">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        <b>Sonic Notes Grid </b>
                                                                    </td>
                                                                    <td align="center" valign="top" colspan="5">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <%--<td align="left" valign="top" width="19%">Date
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
                                                                    </td>--%>
                                                                    <td align="left" valign="top" width="19%">
                                                                        Note
                                                                    </td>
                                                                    <td align="center" valign="top" width="2%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top" style="padding-left: 5px;">
                                                                        <uc:ctrlMultiLineTextBox ID="txtSonic_Notes" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                    </td>
                                                                    <td align="center">
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <asp:Button ID="btnSonicNotesAdd" OnClick="btnSonicNotesAdd_Click" runat="server"
                                                                            ValidationGroup="vsErrorGroup" OnClientClick="javascript:return checkLengthSonic();"
                                                                            Text="Add" Width="70px"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
                                                                        <asp:Button ID="btnSonicNotesCancel" OnClick="btnSonicNotesCancel_Click" runat="server"
                                                                            Text="Cancel" Width="70px"></asp:Button>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trSonicNotesGrid">
                                                        <td align="left" valign="top">
                                                            Sonic Notes Grid
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:GridView ID="gvSonic_Notes" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                PageSize="6" EnableViewState="true" AllowPaging="true" OnRowCommand="gvSonic_Notes_RowCommand"
                                                                OnPageIndexChanging="gvSonic_Notes_PageIndexChanging">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="1%" />
                                                                        <ItemTemplate>
                                                                            <asp:HiddenField ID="hdnPK_Sonic_Event_Notes" runat="server" Value='<%# Eval("PK_Sonic_Event_Notes") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Note Date">
                                                                        <ItemStyle Width="10%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:function(){return false};" onclick="AciNotePopup('<%#Eval("PK_Sonic_Event_Notes") %>','SONIC');">
                                                                                <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Note_Date")) %></a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="User">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:function(){return false};" onclick="AciNotePopup('<%#Eval("PK_Sonic_Event_Notes") %>','SONIC');">
                                                                                <%# Eval("Updated_by_Name")%></a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Notes">
                                                                        <ItemStyle Width="45%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:function(){return false};" onclick="AciNotePopup('<%#Eval("PK_Sonic_Event_Notes") %>','SONIC');">
                                                                                <%# Eval("Note") %></a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                        <ItemStyle Width="10%" HorizontalAlign="Center" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkEdit" Text=" Edit " CommandName="EditRecord"
                                                                                CommandArgument='<%#Eval("PK_Sonic_Event_Notes") %>' Visible='<%#Convert.ToBoolean(!Is_Closed_Event) %>' >
                                                                            </asp:LinkButton>
                                                                            &nbsp;&nbsp;&nbsp;
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Delete" CommandArgument='<%#Eval("PK_Sonic_Event_Notes") %>'
                                                                                CommandName="RemoveACINote" OnClientClick="return confirm('Are you sure to remove Sonic Note record?');"
                                                                                CausesValidation="false" Visible='<%#Convert.ToBoolean(!Is_Closed_Event) %>' />
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
                                                            <asp:LinkButton Style="display: inline" ID="lnkAddSonicNotesNew" OnClick="lnkAddSonicNotesNew_Click"
                                                                runat="server" Text="Add New"></asp:LinkButton>&nbsp;&nbsp;&nbsp;
                                                            <asp:LinkButton Style="display: none" ID="lnkSonicNotesCancel" runat="server" Text="Cancel"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            <b>Images of Event : </b>
                                                        </td>
                                                        <td align="center" valign="top" colspan="5">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trInvest_Images">
                                                        <td colspan="6" align="center">
                                                            <div style="width: 95%; border: 3px solid;">
                                                                <asp:Repeater ID="rptInvest_Images" runat="server" OnItemDataBound="rptInvestImages_ItemDataBound">
                                                                    <ItemTemplate>
                                                                         <table cellpadding="0" cellspacing="0" width="95%">
                                                                            <tr>
                                                                                <td valign="top">
                                                                                    <asp:Image ID="imgInvest_Images1" runat="server" ImageUrl='<%#Eval("InvestigationImgCol1") %>' BorderWidth="1px" BorderStyle="Solid" BorderColor="Black"
                                                                                        Height="80px" Width="350px" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>

                                                                                <td valign="top">
                                                                                    <asp:Image ID="imgInvest_Images2" runat="server" ImageUrl='<%#Eval("InvestigationImgCol2") %>' BorderWidth="1px" BorderStyle="Solid" BorderColor="Black"
                                                                                        Height="80px" Width="350px" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                </asp:Repeater>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trStatus">
                                                        <td align="left" width="18%" valign="top">
                                                            Status
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:RadioButtonList ID="rdoStatus" runat="server" onclick="SetClosedDate();">
                                                                <asp:ListItem Text="Open" Value="O" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Text="Closed" Value="C"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            Date Closed
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtDate_Closed" runat="server" SkinID="txtDate" />
                                                            <img alt="Date Closed" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_Closed', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                align="middle" runat="server" id="imgDate_Closed" />
                                                            <asp:RegularExpressionValidator ID="revtxtDate_Closed" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[ACI Reported Event]/Date Closed is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtDate_Closed" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            <asp:CompareValidator ID="cmptxtDate_Closed" runat="server" ControlToCompare="txtCurrentDate"
                                                                ControlToValidate="txtDate_Closed" Display="None" Text="*" ErrorMessage="[ACI Reported Event]/Date Closed should not be greater than current date."
                                                                Operator="LessThanEqual" Type="Date" ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl3" runat="server" Style="display: none;" Width="794px">
                                                <div class="bandHeaderRow">
                                                    Sonic Reported Event (SRE)</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Location
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:DropDownList ID="ddlLocation_Sonic" runat="server" Width="175px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Date of Event
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtEvent_Start_Date_Sonic" runat="server" SkinID="txtDate" />
                                                            <img alt="Report Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtEvent_Start_Date_Sonic', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                align="middle" runat="server" id="imgEvent_Start_Date_Sonic" />
                                                            <asp:RegularExpressionValidator ID="revtxtEvent_Start_Date_Sonic" runat="server"
                                                                ValidationGroup="vsErrorGroup" Display="none" ErrorMessage="[Sonic Reported Event]/Date of Event is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtEvent_Start_Date_Sonic" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            <asp:CompareValidator ID="cmptxtEvent_Start_Date_Sonic" runat="server" ControlToCompare="txtCurrentDate"
                                                                ControlToValidate="txtEvent_Start_Date_Sonic" Display="None" Text="*" ErrorMessage="[Sonic Reported Event]/Date of Event should not be greater than current date."
                                                                Operator="LessThanEqual" Type="Date" ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            SRE#
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtEvent_Number_Sonic" runat="server" SkinID="txtDisabled" Width="170px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            Monitoring Hours
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:RadioButtonList ID="rdoMonitoring_Hours_Sonic" runat="server">
                                                                <asp:ListItem Text="Yes" Value="Y" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Source of Information
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="txtSource_Of_Information" runat="server" MaxLength="100" />
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trEvent_Camera_Sonic" style="display: none;">
                                                        <td colspan="6">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        <b>Camera Grid </b>
                                                                    </td>
                                                                    <td align="center" valign="top" colspan="5">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" width="19%">
                                                                        Camera Name
                                                                    </td>
                                                                    <td align="center" valign="top" width="2%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top" style="padding-left: 5px;">
                                                                        <asp:TextBox ID="txtCamera_Name_Sonic" runat="server" MaxLength="100" Width="170px"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left" valign="top" width="19%">
                                                                        Camera Number
                                                                    </td>
                                                                    <td align="center" valign="top" width="2%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top" style="padding-left: 5px;">
                                                                        <asp:TextBox ID="txtCamera_Number_Sonic" runat="server" MaxLength="20" Width="170px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" width="19%">
                                                                        Event Time From
                                                                    </td>
                                                                    <td align="center" valign="top" width="2%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top" style="padding-left: 5px;">
                                                                        <asp:TextBox ID="txtEvent_Time_From_Sonic" runat="server" MaxLength="5" Width="170px"></asp:TextBox>
                                                                        <cc1:MaskedEditExtender ID="mstxtEvent_Time_From_Sonic" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99:99" MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                            AcceptAMPM="false" OnInvalidCssClass="MaskedEditError" TargetControlID="txtEvent_Time_From_Sonic"
                                                                            CultureName="en-US" AutoComplete="false" ClearMaskOnLostFocus="true">
                                                                        </cc1:MaskedEditExtender>
                                                                        <asp:RegularExpressionValidator ID="revtxtEvent_Time_From_Sonic" runat="server" ControlToValidate="txtEvent_Time_From_Sonic"
                                                                            ValidationExpression="^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$"
                                                                            ErrorMessage="[Sonic Reported Event]/Invalid Event Time From" Display="none"
                                                                            ValidationGroup="vsErrorEvent_Camera_Sonic" SetFocusOnError="true">
                                                                        </asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td align="left" valign="top" width="19%">
                                                                        Event Time To
                                                                    </td>
                                                                    <td align="center" valign="top" width="2%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top" style="padding-left: 5px;">
                                                                        <asp:TextBox ID="txtEvent_Time_To_Sonic" runat="server" MaxLength="5" Width="170px"></asp:TextBox>
                                                                        <cc1:MaskedEditExtender ID="mstxtEvent_Time_To_Sonic" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99:99" MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                            AcceptAMPM="false" OnInvalidCssClass="MaskedEditError" TargetControlID="txtEvent_Time_To_Sonic"
                                                                            CultureName="en-US" AutoComplete="false" ClearMaskOnLostFocus="true">
                                                                        </cc1:MaskedEditExtender>
                                                                        <asp:RegularExpressionValidator ID="revtxtEvent_Time_To_Sonic" runat="server" ControlToValidate="txtEvent_Time_To_Sonic"
                                                                            ValidationExpression="^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$"
                                                                            ErrorMessage="[Sonic Reported Event]/Invalid Event Time To" Display="none" ValidationGroup="vsErrorEvent_Camera_Sonic"
                                                                            SetFocusOnError="true">
                                                                        </asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                    </td>
                                                                    <td align="center">
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <asp:Button ID="btnEvent_CameraAdd_Sonic" OnClick="btnEvent_CameraAdd_Sonic_Click"
                                                                            runat="server" ValidationGroup="vsErrorEvent_Camera_Sonic" OnClientClick="javascript:return valSaveEventSonic();"
                                                                            Text="Add" Width="70px"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
                                                                        <asp:Button ID="btnEvent_CameraSonicCancel" OnClick="btnEvent_CameraSonicCancel_Click"
                                                                            runat="server" Text="Cancel" Width="70px"></asp:Button>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trEvent_CameraGrid_Sonic">
                                                        <td align="left" valign="top">
                                                            Camera Grid
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:GridView ID="gvEvent_Camera_Sonic" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                PageSize="6" EnableViewState="true" AllowPaging="true" OnRowCommand="gvEvent_Camera_Sonic_RowCommand"
                                                                OnPageIndexChanging="gvEvent_Camera_Sonic_PageIndexChanging">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="1%" />
                                                                        <ItemTemplate>
                                                                            <asp:HiddenField ID="hdnPK_Event_CameraSonic" runat="server" Value='<%# Eval("PK_Event_Camera") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Camera Name">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <%# Eval("Camera_Name")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Camera Number">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <%# Eval("Camera_Number")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Event Time From">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <%# Eval("Event_Time_From")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Event Time To">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <%# Eval("Event_Time_To")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                        <ItemStyle Width="10%" HorizontalAlign="Center" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lnkEdit" Text=" Edit " CommandName="EditRecord"
                                                                                CommandArgument='<%#Eval("PK_Event_Camera") %>' Visible='<%#Convert.ToBoolean(!Is_Closed_Event) %>'>
                                                                            </asp:LinkButton>
                                                                            &nbsp;&nbsp;&nbsp;
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Delete" CommandArgument='<%#Eval("PK_Event_Camera") %>'
                                                                                CommandName="RemoveEventCamera" OnClientClick="return confirm('Are you sure to remove Event Camera record?');"
                                                                                CausesValidation="false" Visible='<%#Convert.ToBoolean(!Is_Closed_Event) %>' />
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
                                                            <asp:LinkButton Style="display: inline" ID="lnkAddEvent_CameraNew_Sonic" OnClick="lnkAddEvent_CameraNew_Sonic_Click"
                                                                runat="server" Text="Add New"></asp:LinkButton>&nbsp;&nbsp;&nbsp;
                                                            <asp:LinkButton Style="display: none" ID="lnkEvent_CameraSonicCancel" runat="server"
                                                                Text="Cancel"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <u><b>Actionable Event Type</b></u>
                                                        </td>
                                                        <td colspan="3">
                                                            <u><b>Description of Event</b></u>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trrptEventTypeSonic">
                                                        <td align="left" valign="top" colspan="6">
                                                            <asp:Repeater ID="rptEventTypeSonic" runat="server" OnItemDataBound="rptEventTypeSonic_ItemDataBound">
                                                                <ItemTemplate>
                                                                    <table cellpadding="4" cellspacing="0" width="100%">
                                                                        <tr>
                                                                            <td width="50%" align="left" valign="top" colspan="2">
                                                                                <asp:CheckBox ID="chkEventTypeSonic" runat="server" />
                                                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                                                                <asp:Label ID="lblEventTypeSonic" Text='<%#Eval("Fld_Desc") %>' runat="server"></asp:Label>
                                                                                <asp:Label ID="lblPK_LU_Event_TypeSonic" Text='<%#Eval("PK_LU_Event_Type") %>' runat="server"
                                                                                    Style="display: none;"></asp:Label>
                                                                            </td>
                                                                            <td width="18%" align="left" valign="top">
                                                                                <asp:TextBox ID="txtEventDesciptionSonic" runat="server" MaxLength="100" Width="170px"></asp:TextBox>
                                                                            </td>
                                                                            <td width="4%" align="center" valign="top">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td width="28%" align="left" valign="top">
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Police Called?
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:RadioButtonList ID="rdoPolice_Called_Sonic" runat="server">
                                                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" width="18%" valign="top" style="padding-left: 25px;">
                                                                        If Yes:
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left" width="18%" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" style="padding-left: 60px;">
                                                                        Agency Name
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtAgency_name_Sonic" runat="server" MaxLength="60" Width="170px"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Phone #
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtOfficer_Phone_Sonic" runat="server" MaxLength="12" Width="170px"
                                                                            SkinID="txtPhone"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="revtxtOfficer_Phone_Sonic" ControlToValidate="txtOfficer_Phone_Sonic"
                                                                            runat="server" SetFocusOnError="true" ErrorMessage="[Sonic Reported Event] / Please Enter Agency Phone # in XXX-XXX-XXXX format"
                                                                            Display="none" ValidationGroup="vsErrorGroup" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" style="padding-left: 60px;">
                                                                        Officer Name
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtOfficer_Name_Sonic" runat="server" MaxLength="60" Width="170px"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Police Report #
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtPolice_Report_Number_Sonic" runat="server" MaxLength="30" Width="170px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" style="padding-left: 60px;">
                                                                        Budge #
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtBadge_Number_Sonic" runat="server" MaxLength="20" Width="170px"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" width="18%" valign="top">
                                                                        Sonic Contact Information :
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left" width="18%" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" width="4%" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left" width="28%" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" style="padding-left: 60px;">
                                                                        Name
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtSonic_Contact_Name" runat="server" MaxLength="60" Width="170px"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        Phone #
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtSonic_Contact_Phone" runat="server" MaxLength="12" Width="170px"
                                                                            SkinID="txtPhone"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="revtxtSonic_Contact_Phone" ControlToValidate="txtSonic_Contact_Phone"
                                                                            runat="server" SetFocusOnError="true" ErrorMessage="[Sonic Reported Event] / Please Enter Sonic Contact Phone # in XXX-XXX-XXXX format"
                                                                            Display="none" ValidationGroup="vsErrorGroup" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" style="padding-left: 60px;">
                                                                        Email Address
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:TextBox ID="txtSonic_Contact_Email" runat="server" MaxLength="60" Width="170px"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="revSonic_Contact_Email" runat="server" ControlToValidate="txtSonic_Contact_Email"
                                                                            Display="None" ErrorMessage="[Sonic Reported Event] /Please Enter Valid Sonic Contact Email Address"
                                                                            SetFocusOnError="True" ValidationGroup="vsErrorGroup" ToolTip="Please Enter Valid Sonic Contact Email Address"
                                                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    
                                                    <%--<tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Status
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:RadioButtonList ID="rdoStatus_Sonic" runat="server" onclick="SetACIStatus();">
                                                                <asp:ListItem Text="Open" Value="O" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Text="Closed" Value="C"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td colspan="6" class="spacer" style="height: 5px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl4" runat="server" Style="display: none;" Width="794px">
                                                <div class="bandHeaderRow">
                                                    Insurance Type Claim</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Claim Type - Select :
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Auto Liability - FROI #
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top" colspan="4">
                                                            <asp:TextBox ID="txtFK_AL_FR" runat="server" Width="170px" Enabled="false"></asp:TextBox>&nbsp;&nbsp;
                                                            <asp:LinkButton Style="display: inline" ID="lnkAddFK_AL_FR" runat="server" Text="Add" OnClientClick="return OpenFRNumber('AL');"></asp:LinkButton>
                                                            <asp:HiddenField ID="hdnFK_AL_FR" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            DPD - FROI #
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                             <asp:TextBox ID="txtFK_DPD_FR" runat="server" Width="170px" Enabled="false"></asp:TextBox>&nbsp;&nbsp;
                                                            <asp:LinkButton Style="display: inline" ID="lnkAddFK_DPD_FR" runat="server" Text="Add" OnClientClick="return OpenFRNumber('DPD');"></asp:LinkButton>
                                                            <asp:HiddenField ID="hdnFK_DPD_FR" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Premises Liability - FROI #
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                             <asp:TextBox ID="txtFK_PL_FR" runat="server" Width="170px" Enabled="false"></asp:TextBox>&nbsp;&nbsp;
                                                            <asp:LinkButton Style="display: inline" ID="lnkAddFK_PL_FR" runat="server" Text="Add" OnClientClick="return OpenFRNumber('PL');"></asp:LinkButton>
                                                            <asp:HiddenField ID="hdnFK_PL_FR" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Property Damage - FROI #
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                             <asp:TextBox ID="txtFK_Property_FR" runat="server" Width="170px" Enabled="false"></asp:TextBox>&nbsp;&nbsp;
                                                            <asp:LinkButton Style="display: inline" ID="lnkAddFK_Property_FR" runat="server" Text="Add" OnClientClick="return OpenFRNumber('Property');"></asp:LinkButton>
                                                            <asp:HiddenField ID="hdnFK_Property_FR" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            What is the Event's root cause?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID ="txtEvent_Root_Cause" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            How can the event be prevented from happening again?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID ="txtHow_Event_Prevented" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Financial Loss
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            $<asp:TextBox ID="txtFinancial_Loss" runat="server" Width="160px" onpaste="return false"
                                                                onkeypress="return FormatNumber(event,this.id,11,false);" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" class="spacer" style="height: 5px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </div>
                                        <asp:Panel ID="pnlAttachment" runat="server" Style="display: none;" Width="794px">
                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                <tr>
                                                    <td align="left" valign="top" width="100%" style="height: 200px;">
                                                        <uc:Attachment ID="ucAttachment" runat="server" Attachment_Table="Event" />
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
