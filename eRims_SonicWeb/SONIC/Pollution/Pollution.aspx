<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="Pollution.aspx.cs" Inherits="SONIC_Pollution_Pollution" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/NotesWithSpellCheck/Notes.ascx" TagName="ctrlMultiLineTextBox"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment_Pollution/Attachment_Pollution.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment_Pollution/AttachmentDetails_Pollution.ascx"
    TagName="ctrlAttachmentDetails" TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposuresTab/ExposuresTab.ascx" TagName="CtlTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposureInfo/EnviroExposureInfo.ascx" TagName="ctrlExposureInfo"
    TagPrefix="uc" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="Content1" runat="server">
    <script type="text/javascript" src="../../JavaScript/JFunctions.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>    
    <script type="text/javascript">
        function SetMenuStyle(index) {
            var i;
            for (i = 1; i <= 10; i++) {
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

        function ShowPanel(index) {            
            document.getElementById('<%=hdPanel.ClientID%>').value = index;
            SetMenuStyle(index);
            ActiveTabIndex = index;
            var loc = '<%=Session["ExposureLocation"]%>';
            var Building_Id = '<%=Session["EnviroBuilding"]%>';
            if (index == 9) {
                if (loc > 0)
                    loc = '<%=Encryption.Encrypt(Session["ExposureLocation"].ToString()) %>';
                window.location.href = '<%=AppConfig.SiteURL%>SONIC/Exposures/Project_Management_Add.aspx?loc=' + loc + '&Building_Id=' + Building_Id + '&pnl=' +10;
            }
            var op = '<%=StrOperation%>';
            if (op == "view") {
                ShowPanelView(index);
            }
            else {
                var i;
                if (index < 10) {
                    for (i = 1; i <= 9; i++) {
                        if(index != 9)
                        document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display = (i == index) ? "block" : "none";
                    }
                    document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "none";
                    if (index == 1)
                        document.getElementById('<%=drpFK_County.ClientID %>').focus();
                    else if (index == 3)
                        document.getElementById('<%=txtContact_Name.ClientID %>').focus();
                }
                else {
                    for (i = 1; i <= 9; i++) {
                        document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display = "none";
                    }
                    document.getElementById("<%=dvAttachment.ClientID%>").style.display = "block";
                    document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "block";
                }
            }
        }

        function ShowPanelView(index) {

            document.getElementById('<%=hdPanel.ClientID%>').value = index;
            SetMenuStyle(index);
            var loc = '<%=Session["ExposureLocation"]%>';
            var Building_Id = '<%=Session["EnviroBuilding"]%>';
            if (index == 9) {
                if (loc > 0)
                    loc = '<%=Encryption.Encrypt(Session["ExposureLocation"].ToString()) %>';
                window.location.href = '<%=AppConfig.SiteURL%>SONIC/Exposures/Project_Management_Add.aspx?loc=' + loc + '&Building_Id=' + Building_Id;
            }
            document.getElementById('<%=dvView.ClientID%>').style.display = "block";
            var i;
            if (index < 10) {
                for (i = 1; i <= 9; i++) {
                    if (index != 9)
                    document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i + "View").style.display = (i == index) ? "block" : "none";
                }
                //document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "none";
            }
            else {
                for (i = 1; i <= 9; i++) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i + "View").style.display = "none";
                }
                //document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "block";
            }
        }

        function ValSave() {
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqFile').enabled = false;
            if (document.getElementById('<%=txtLatitude.ClientID%>').value == "__:__:__")
                document.getElementById('<%=txtLatitude.ClientID%>').value = "";
            if (document.getElementById('<%=txtLongitude.ClientID%>').value == "___:__:__")
                document.getElementById('<%=txtLongitude.ClientID%>').value = "";
            if (Page_ClientValidate('vsErrorGroup'))
                return true;
            else
                return false;
        }

        function ValAttach() {
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqFile').enabled = true;
            if (Page_ClientValidate())
                return true;
            else
                return false;
        }

        function numberOnly(e) {
            var k;
            if (window.event) {
                k = event.keyCode;
            }
            else {
                k = e.which;
            }
            if (k == 8) {
                return true;
            }
            if ((k <= 47) || (k >= 58)) {
                if (window.event) {
                    window.event.returnValue = null;
                    return false;
                }
                else {
                    e.preventDefault();
                }
            }
            if (k == 8)
            { }
        }

        function OpenPopup(strPopup) {

            var strPage = (strPopup == "NAICS") ? "NAICS_PopUp.aspx" : "SIC_PopUp.aspx";
            var w = 480, h = 340;

            if (document.all || document.layers) {
                w = screen.availWidth;
                h = screen.availHeight;
            }

            var leftPos, topPos;
            var popW = 650, popH = 400;
            if (document.all)
            { leftPos = (w - popW) / 2; topPos = (h - popH) / 2; }
            else
            { leftPos = w / 2; topPos = h / 2; }

            window.open(strPage, "popup", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=" + popW + ",height=" + popH + ",top=" + topPos + ",left=" + leftPos);
            return false;
        }

        function OpenAuditPopUp() {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 315;

            obj = window.open('AuditPopup_Pollution.aspx?id=<%=ViewState["PK_PM_Site_Information"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
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
                    //if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
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
    <asp:HiddenField ID="hdPanel" runat="server" Value="1" />
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100%" style="height: 50px;" valign="bottom" colspan="2">
                <uc:CtlTab runat="server" ID="Tab"></uc:CtlTab>
            </td>
        </tr>
        <tr>
            <td class="Spacer" width="100%" style="height: 15px;" colspan="2">
            </td>
        </tr>
        <tr>
            <td width="100%" colspan="2">
                <uc:ctrlExposureInfo ID="ucCtrlExposureInfo" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="ghc" align="left">
                Site Information
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="Spacer" style="height: 15px;" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td class="leftMenu">
                            <table cellpadding="5" cellspacing="0" width="100%">
                                <tr>
                                    <td style="height: 18px;" class="Spacer">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu1" onclick="javascript:ShowPanel(1);" class="LeftMenuStatic">Site Information</span>&nbsp;<span
                                            id="MenuAsterisk1" runat="server" style="color: Red; display: none">*</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu2" onclick="javascript:ShowPanel(2);" class="LeftMenuStatic">Permits</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu3" onclick="javascript:ShowPanel(3);" class="LeftMenuStatic">Compliance
                                            Reporting&nbsp;<span id="MenuAsterisk2" runat="server" style="color: Red; display: none">*</span></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu4" onclick="javascript:ShowPanel(4);" class="LeftMenuStatic">Equipment</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu5" onclick="javascript:ShowPanel(5);" class="LeftMenuStatic">Waste Disposal&nbsp;<span
                                            id="MenuAsterisk3" runat="server" style="color: Red; display: none">*</span></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu6" onclick="javascript:ShowPanel(6);" class="LeftMenuStatic">Audit/Inspections&nbsp;<span
                                            id="MenuAsterisk4" runat="server" style="color: Red; display: none">*</span></span>
                                    </td>
                                </tr>
                                 <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu7" onclick="javascript:ShowPanel(7);" class="LeftMenuStatic">Occupational Health and Safety Programs&nbsp;<span
                                            id="Span13" runat="server" style="color: Red; display: none">*</span></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu8" onclick="javascript:ShowPanel(8);" class="LeftMenuStatic">Violations&nbsp;<span
                                            id="MenuAsterisk5" runat="server" style="color: Red; display: none">*</span></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu9" onclick="javascript:ShowPanel(9);" class="LeftMenuStatic">Project Management Link&nbsp;<span
                                            id="MenuAsterisk6" runat="server" style="color: Red; display: none">*</span></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu10" onclick="javascript:ShowPanel(10);" class="LeftMenuStatic">Attachments</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 18px;" class="Spacer">
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
                                            <asp:Panel ID="pnl1" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Site Information</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%" style="height: 220px;">
                                                    <%--<tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Building&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:DropDownList ID="drpFK_Building" Width="570px" runat="server" AutoPostBack="true"
                                                                SkinID="dropGen" OnSelectedIndexChanged="drpFK_Building_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Building
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lblFK_Building" runat="server" Width="500px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            County&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:DropDownList ID="drpFK_County" Width="175px" runat="server" SkinID="dropGen">
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
                                                        <td align="left" valign="top">
                                                            SIC Code&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtSIC" runat="server" Width="150px" ReadOnly="true" SkinID="txtDisabled" />
                                                            <asp:Button ID="btnPopupSIC" runat="server" Text="V" OnClientClick="return OpenPopup('SIC');" />
                                                            <input type="hidden" id="hdnSIC" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top" colspan="3">
                                                            <asp:Label ID="lblSIC" runat="server" />
                                                            <asp:TextBox ID="txtSICDesc" runat="server" Style="display: none" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            NAICS Code&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtNAICS" runat="server" Width="150px" ReadOnly="true" SkinID="txtDisabled" />
                                                            <asp:Button ID="btnPopupNAICS" runat="server" Text="V" OnClientClick="return OpenPopup('NAICS');" />
                                                            <input type="hidden" id="hdnNAICS" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top" colspan="3">
                                                            <asp:Label ID="lblNAICS" runat="server" />
                                                            <asp:TextBox ID="txtNAICSDesc" runat="server" Style="display: none" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Number of Associates&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtNumber_Of_Employees" runat="server" Width="170px" onkeypress="return FormatNumber(event,this.id,6,true);"
                                                                onpaste="return false" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Number of Shifts&nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtNumber_Of_Shift" runat="server" Width="170px" onkeypress="return numberOnly(event);"
                                                                MaxLength="2" onpaste="return false" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Days Per Week&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtDays_Per_Week" runat="server" Width="170px" onkeypress="return numberOnly(event);"
                                                                MaxLength="1" onpaste="return false" />
                                                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtDays_Per_Week"
                                                                Display="None" MinimumValue="1" MaximumValue="7" SetFocusOnError="true" ErrorMessage="Please enter [Site Information]/Days Per Week between 1 and 7"
                                                                ValidationGroup="vsErrorGroup" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Weeks Per Year&nbsp;<span id="Span8" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtWeeks_Per_Year" runat="server" Width="170px" onkeypress="return numberOnly(event);"
                                                                MaxLength="2" onpaste="return false" />
                                                            <asp:RangeValidator ID="rvWeeks_Per_Year" runat="server" ControlToValidate="txtWeeks_Per_Year"
                                                                Display="None" MinimumValue="1" MaximumValue="52" SetFocusOnError="true" ErrorMessage="Please enter [Site Information]/Weeks Per Year between 1 and 52"
                                                                ValidationGroup="vsErrorGroup" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Facility Construction Completion Year&nbsp;<span id="Span9" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtFacility_Construction_Completion_Year" runat="server" Width="170px"
                                                                onkeypress="return numberOnly(event);" MaxLength="4" onpaste="return false" />
                                                            <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtFacility_Construction_Completion_Year"
                                                                Display="None" MinimumValue="1753" MaximumValue="2070" SetFocusOnError="true"
                                                                ErrorMessage="Please enter [Site Information]/Facility Construction Completion Year between 1753 and 2070"
                                                                ValidationGroup="vsErrorGroup" />
                                                            <%--<asp:TextBox ID="txtFacility_Construction_Completion_Date" runat="server" Width="150px" SkinID="txtDate" />
														<img alt="Facility Construction Completion Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtFacility_Construction_Completion_Date', 'mm/dd/y');" onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif" align="middle" />
														<asp:RegularExpressionValidator ID="revFacility_Construction_Completion_Date" runat="server" ValidationGroup="vsErrorGroup" Display="none" ErrorMessage="[Site Information]/Facility Construction Completion Date is not a valid date" SetFocusOnError="true" ControlToValidate="txtFacility_Construction_Completion_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>--%>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Owner of Facility&nbsp;<span id="Span10" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtOwner_Of_Facility" runat="server" Width="170px" MaxLength="75" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Latitude (DD:MM:SS)&nbsp;<span id="Span11" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtLatitude" runat="server" Width="170px" MaxLength="8" />
                                                            <cc1:MaskedEditExtender ID="mskLatitude" runat="server" TargetControlID="txtLatitude"
                                                                Mask="99:99:99" MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false"
                                                                InputDirection="LeftToRight">
                                                            </cc1:MaskedEditExtender>
                                                            <asp:RegularExpressionValidator ID="revLatitude" ControlToValidate="txtLatitude"
                                                                runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the [Site Information]/Latitude DD:MM:SS format."
                                                                Display="none" Text="*" ValidationExpression="((\d{2}:))?\d{2}:\d{2}$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Longitude (DDD:MM:SS)&nbsp;<span id="Span12" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtLongitude" runat="server" Width="170px" MaxLength="10" onKeyPress="javascript:return FormatLongitude(event,this.id);" />
                                                            <%--<cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtLongitude"
                                                                Mask="999:99:99" MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false"
                                                                AcceptNegative="Left" InputDirection="LeftToRight">
                                                            </cc1:MaskedEditExtender>--%>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtLongitude"
                                                                runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the [Site Information]/Longitude DDD:MM:SS format."
                                                                Display="none" Text="*" ValidationExpression="(-((\d{3}:))?\d{2}:\d{2})$|((\d{3}:))?\d{2}:\d{2}$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Utility Provider Grid<br />
                                                            <asp:LinkButton ID="lnkAddUtility" runat="server" Text="--Add--" CausesValidation="true"
                                                                ValidationGroup="vsErrorGroup" OnClick="lnkAddGridRecord_Click" OnClientClick="return ValSave();" />
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvUtility" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Type">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkFK_LU_Utility_Type" runat="server" Text='<%# Eval("FLD_Desc") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_SI_Utility_Provider") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Name">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkUtility_Name" runat="server" Text='<%# Eval("Utility_Name") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_SI_Utility_Provider") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Phone">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkTelephone" runat="server" Text='<%# Eval("Telephone") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_SI_Utility_Provider") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Address">
                                                                        <ItemStyle Width="30%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkAddress_1" runat="server" Text='<%# clsGeneral.FormatAddress(Eval("Address_1"),Eval("Address_2"), Eval("City"), Eval("FK_State"), Eval("Zip_Code")) %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_SI_Utility_Provider") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CommandName="RemoveDetails"
                                                                                CommandArgument='<%# Eval("PK_PM_SI_Utility_Provider") %>' OnClientClick="return confirm('Are you sure to remove the record?');" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Facility Id Grid<br />
                                                            <asp:LinkButton ID="lnkAddFacility" runat="server" Text="--Add--" CausesValidation="true"
                                                                ValidationGroup="vsErrorGroup" OnClick="lnkAddGridRecord_Click" OnClientClick="return ValSave();" />
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvFacility" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Agency">
                                                                        <ItemStyle Width="30%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkFK_LU_Agency" runat="server" Text='<%# Eval("FK_LU_Agency") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_SI_Faciltiy_ID") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="I.D Type">
                                                                        <ItemStyle Width="30%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkFK_LU_Media" runat="server" Text='<%# Eval("FK_LU_Media") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_SI_Faciltiy_ID") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Id">
                                                                        <ItemStyle Width="30%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkIdentification_Number" runat="server" Text='<%# Eval("Identification_Number") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_SI_Faciltiy_ID") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CommandName="RemoveDetails"
                                                                                CommandArgument='<%# Eval("PK_PM_SI_Faciltiy_ID") %>' OnClientClick="return confirm('Are you sure to remove the record?');" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl2" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Permits</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%" style="height: 230px;">
                                                    <tr>
                                                        <td align="left" width="12%" valign="top">
                                                            Permits Grid<br />
                                                            <asp:LinkButton ID="lnkAddPermits" runat="server" Text="--Add--" CausesValidation="true"
                                                                ValidationGroup="vsErrorGroup" OnClick="lnkAddGridRecord_Click" OnClientClick="return ValSave();" />
                                                        </td>
                                                        <td align="center" width="2%" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvPermits" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Type">
                                                                        <ItemStyle Width="57%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkFK_Permit_Type" runat="server" Text='<%# Eval("FK_Permit_Type") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Permits") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Permit Start">
                                                                        <ItemStyle Width="18%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkPermit_Start_Date" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Permit_Start_Date")) %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Permits") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Permit End">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkPermit_End_Date" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Permit_End_Date")) %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Permits") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CommandName="RemoveDetails"
                                                                                CommandArgument='<%# Eval("PK_PM_Permits") %>' OnClientClick="return confirm('Are you sure to remove the record?');" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl3" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Compliance Reporting</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%" style="height: 230px;">
                                                    <%--<tr>
														<td align="left" width="18%" valign="top">Federal Facility Identification Number&nbsp;<span id="Span13" style="color: Red; display: none;" runat="server">*</span></td>
														<td align="center" width="4%" valign="top">:</td>
														<td align="left" width="28%" valign="top">
														<asp:TextBox ID="txtFederal_Facility_Identification_Number" runat="server" Width="170px" MaxLength="50" />
														</td>
														<td align="left" width="18%" valign="top">State Facility Identification Number&nbsp;<span id="Span14" style="color: Red; display: none;" runat="server">*</span></td>
														<td align="center" width="4%" valign="top">:</td>
														<td align="left" width="28%" valign="top">
														<asp:TextBox ID="txtState_Facility_Identification_Number" runat="server" Width="170px" MaxLength="50" />
														</td>
													</tr>--%>
                                                    <tr>
                                                        <td align="left" valign="top" width="16%">
                                                            Location Contact Name&nbsp;<span id="Span15" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="2%">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" width="28%">
                                                            <asp:TextBox ID="txtContact_Name" runat="server" Width="170px" MaxLength="100" />
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            Location Contact Telephone (XXX-XXX-XXXX)&nbsp;<span id="Span16" style="color: Red;
                                                                display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="2%">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:TextBox ID="txtContact_Telephone" runat="server" Width="170px" MaxLength="12"
                                                                SkinID="txtPhone" />
                                                            <asp:RegularExpressionValidator ID="revContactPhone" runat="server" ErrorMessage="Please Enter Valid [Compliance Reporting]/Contact Telephone"
                                                                ValidationGroup="vsErrorGroup" ControlToValidate="txtContact_Telephone" ValidationExpression="\b[0-9]{3}-[0-9]{3}-[0-9]{4}\b"
                                                                Display="None" SetFocusOnError="true" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Emergency Contact Name&nbsp;<span id="Span17" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtEmergency_Contact_Name" runat="server" Width="170px" MaxLength="100" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Emergency Contact Telephone (XXX-XXX-XXXX)&nbsp;<span id="Span18" style="color: Red;
                                                                display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtEmergency_Telephone" runat="server" Width="170px" MaxLength="12"
                                                                SkinID="txtPhone" />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Please Enter Valid [Compliance Reporting]/Emergency Contact Telephone"
                                                                ValidationGroup="vsErrorGroup" ControlToValidate="txtEmergency_Telephone" ValidationExpression="\b[0-9]{3}-[0-9]{3}-[0-9]{4}\b"
                                                                Display="None" SetFocusOnError="true" />
                                                        </td>
                                                    </tr>
                                                    <%--<tr>
                                                        <td align="left" valign="top">Chemical Inventory Grid<br />
                                                            <asp:LinkButton ID="lnkChemicalInventory" runat="server" Text="--Add--" CausesValidation="true" ValidationGroup="vsErrorGroup" OnClick="lnkAddGridRecord_Click" OnClientClick="return ValSave();"/>
                                                        </td>
                                                        <td align="center" valign="top">:</td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvChemicalInventory" runat="server" Width="100%" AutoGenerateColumns="false" EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
	                                                            <Columns>
		                                                            <asp:TemplateField HeaderText="Type">
			                                                            <ItemStyle Width="20%" HorizontalAlign="Left" />
			                                                            <ItemTemplate>
				                                                            <asp:LinkButton ID="lnkFK_LU_Chemical_Type" runat="server" Text='<%# Eval("FK_LU_Chemical_Type") %>' CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_CR_Chemical_Inventory") %>' />
			                                                            </ItemTemplate>
		                                                            </asp:TemplateField>
		                                                            <asp:TemplateField HeaderText="CAS Number">
			                                                            <ItemStyle Width="15%" HorizontalAlign="Left" />
			                                                            <ItemTemplate>
				                                                            <asp:LinkButton ID="lnkCAS_Number" runat="server" Text='<%# Eval("CAS_Number") %>' CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_CR_Chemical_Inventory") %>' />
			                                                            </ItemTemplate>
		                                                            </asp:TemplateField>
                                                                     <asp:TemplateField HeaderText="Name">
			                                                            <ItemStyle Width="15%" HorizontalAlign="Left" />
			                                                            <ItemTemplate>
				                                                            <asp:LinkButton ID="lnkChemical_Name" runat="server" Text='<%# Eval("Chemical_Name") %>' CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_CR_Chemical_Inventory") %>' />
			                                                            </ItemTemplate>
		                                                            </asp:TemplateField>
		                                                            <asp:TemplateField HeaderText="Location">
			                                                            <ItemStyle Width="15%" HorizontalAlign="Left" />
			                                                            <ItemTemplate>
				                                                            <asp:LinkButton ID="lnkFK_LU_Storage_Location" runat="server" Text='<%# Eval("FK_LU_Storage_Location") %>' CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_CR_Chemical_Inventory") %>' />
			                                                            </ItemTemplate>
		                                                            </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
			                                                            <ItemTemplate>                                                                            
				                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CommandName="RemoveDetails" CommandArgument='<%# Eval("PK_PM_CR_Chemical_Inventory") %>' OnClientClick="return confirm('Are you sure to remove the record?');" />
			                                                            </ItemTemplate>
                                                                    </asp:TemplateField>
	                                                            </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Paint Inventory Grid<br />
                                                            <asp:LinkButton ID="lnkPaintInventory" runat="server" Text="--Add--" CausesValidation="true" ValidationGroup="vsErrorGroup" OnClick="lnkAddGridRecord_Click" OnClientClick="return ValSave();"/>
                                                        </td>
                                                        <td align="center" valign="top">:</td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvPaintInventory" runat="server" Width="100%" AutoGenerateColumns="false" EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
	                                                            <Columns>
		                                                            <asp:TemplateField HeaderText="Type">
			                                                            <ItemStyle Width="20%" HorizontalAlign="Left" />
			                                                            <ItemTemplate>
				                                                            <asp:LinkButton ID="lnkFK_LU_Paint_Type" runat="server" Text='<%# Eval("FK_LU_Paint_Type") %>' CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_CR_Paint_Inventory") %>' />
			                                                            </ItemTemplate>
		                                                            </asp:TemplateField>
		                                                            <asp:TemplateField HeaderText="CAS Number">
			                                                            <ItemStyle Width="15%" HorizontalAlign="Left" />
			                                                            <ItemTemplate>
				                                                            <asp:LinkButton ID="lnkCAS_Number" runat="server" Text='<%# Eval("CAS_Number") %>' CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_CR_Paint_Inventory") %>' />
			                                                            </ItemTemplate>
		                                                            </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Color">
			                                                            <ItemStyle Width="15%" HorizontalAlign="Left" />
			                                                            <ItemTemplate>
				                                                            <asp:LinkButton ID="lnkPaint_Color" runat="server" Text='<%# Eval("Paint_Color") %>' CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_CR_Paint_Inventory") %>' />
			                                                            </ItemTemplate>
		                                                            </asp:TemplateField>
		                                                            <asp:TemplateField HeaderText="Location">
			                                                            <ItemStyle Width="15%" HorizontalAlign="Left" />
			                                                            <ItemTemplate>
				                                                            <asp:LinkButton ID="lnkFK_LU_Storage_Location" runat="server" Text='<%# Eval("FK_LU_Storage_Location") %>' CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_CR_Paint_Inventory") %>' />
			                                                            </ItemTemplate>
		                                                            </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
			                                                            <ItemTemplate>                                                                            
				                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CommandName="RemoveDetails" CommandArgument='<%# Eval("PK_PM_CR_Paint_Inventory") %>' OnClientClick="return confirm('Are you sure to remove the record?');" />
			                                                            </ItemTemplate>
                                                                    </asp:TemplateField>
	                                                            </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Tier II Reporting Grid<br />
                                                            <asp:LinkButton ID="lnkTierII" runat="server" Text="--Add--" CausesValidation="true"
                                                                ValidationGroup="vsErrorGroup" OnClick="lnkAddGridRecord_Click" OnClientClick="return ValSave();" />
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvTierII" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Report Due Date">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkReport_Due_Date" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Report_Due_Date")) %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_CR_Grids") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Report Submission Date">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkReport_Submission_Date" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Report_Submission_Date")) %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_CR_Grids") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Initial Notification Submitted">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkInitial_Notification" runat="server" Text='<%# (Eval("Initial_Notification").ToString() == "N" ? "No" : Eval("Initial_Notification").ToString() == "R"? "Not Required": "Yes") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_CR_Grids") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Compliance Verification Submitted">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkCompliance_Verification" runat="server" Text='<%# (Eval("Compliance_Verification").ToString() == "N" ? "No" : Eval("Compliance_Verification").ToString() == "R"? "Not Required": "Yes") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_CR_Grids") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Notification of Report Changes Submitted">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkReport_Changes" runat="server" Text='<%# (Eval("Report_Changes").ToString() == "N" ? "No" : Eval("Report_Changes").ToString() == "R"? "Not Required": "Yes") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_CR_Grids") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CommandName="RemoveDetails"
                                                                                CommandArgument='<%# Eval("PK_PM_CR_Grids") %>' OnClientClick="return confirm('Are you sure to remove the record?');" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Air Permit Grid<br />
                                                            <asp:LinkButton ID="lnkAir_Permit" runat="server" Text="--Add--" CausesValidation="true"
                                                                ValidationGroup="vsErrorGroup" OnClick="lnkAddGridRecord_Click" OnClientClick="return ValSave();" />
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvAir_Permit" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Report Due Date">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkReport_Due_Date" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Report_Due_Date")) %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_CR_Grids") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Report Submission Date">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkReport_Submission_Date" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Report_Submission_Date")) %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_CR_Grids") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Initial Notification Submitted">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkInitial_Notification" runat="server" Text='<%# (Eval("Initial_Notification").ToString() == "N" ? "No" : Eval("Initial_Notification").ToString() == "R"? "Not Required": "Yes") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_CR_Grids") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Compliance Verification Submitted">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkCompliance_Verification" runat="server" Text='<%# (Eval("Compliance_Verification").ToString() == "N" ? "No" : Eval("Compliance_Verification").ToString() == "R"? "Not Required": "Yes") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_CR_Grids") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Notification of Report Changes Submitted">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkReport_Changes" runat="server" Text='<%# (Eval("Report_Changes").ToString() == "N" ? "No" : Eval("Report_Changes").ToString() == "R"? "Not Required": "Yes") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_CR_Grids") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CommandName="RemoveDetails"
                                                                                CommandArgument='<%# Eval("PK_PM_CR_Grids") %>' OnClientClick="return confirm('Are you sure to remove the record?');" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            6H Grid<br />
                                                            <asp:LinkButton ID="lnkSixH" runat="server" Text="--Add--" CausesValidation="true"
                                                                ValidationGroup="vsErrorGroup" OnClick="lnkAddGridRecord_Click" OnClientClick="return ValSave();" />
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvSixH" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Report Due Date">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkReport_Due_Date" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Report_Due_Date")) %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_CR_Grids") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Report Submission Date">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkReport_Submission_Date" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Report_Submission_Date")) %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_CR_Grids") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Initial Notification Submitted">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkInitial_Notification" runat="server" Text='<%# (Eval("Initial_Notification").ToString() == "N" ? "No" : Eval("Initial_Notification").ToString() == "R"? "Not Required": "Yes") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_CR_Grids") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Compliance Verification Submitted">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkCompliance_Verification" runat="server" Text='<%# (Eval("Compliance_Verification").ToString() == "N" ? "No" : Eval("Compliance_Verification").ToString() == "R"? "Not Required": "Yes") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_CR_Grids") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Notification of Report Changes Submitted">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkReport_Changes" runat="server" Text='<%# (Eval("Report_Changes").ToString() == "N" ? "No" : Eval("Report_Changes").ToString() == "R"? "Not Required": "Yes") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_CR_Grids") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CommandName="RemoveDetails"
                                                                                CommandArgument='<%# Eval("PK_PM_CR_Grids") %>' OnClientClick="return confirm('Are you sure to remove the record?');" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            OSHA Log Grid<br />
                                                            [Main Building Only]<br />
                                                            <asp:LinkButton ID="lnkComplainceReportingOSHA" runat="server" Text="--Add--" CausesValidation="true"
                                                                ValidationGroup="vsErrorGroup" OnClick="lnkComplainceReportingOSHA_Click" OnClientClick="return ValSave();" />
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvComplainceReportingOSHA" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Exists" OnRowCommand="gvComplainceReportingOSHA_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Date Completed" HeaderStyle-HorizontalAlign="Center" >
                                                                        <ItemStyle Width="15%" HorizontalAlign="center"  />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkDate_Completed" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Date_Completed")) %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Compliance_Reporting_OSHA") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Feb 1 Log Posting" HeaderStyle-HorizontalAlign="Center">
                                                                        <ItemStyle Width="15%" HorizontalAlign="center" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkLog_Posted_Feb_1" runat="server" Text='<%# CheckStatus(Eval("Log_Posted_Feb_1")) %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Compliance_Reporting_OSHA") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Number of OSHA Recordable" HeaderStyle-HorizontalAlign="Center">
                                                                        <ItemStyle Width="15%" HorizontalAlign="center" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkOSHA_Recordable" runat="server" Text='<%# Eval("OSHA_Recordable").ToString() %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Compliance_Reporting_OSHA") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Number of Lost Work Days" HeaderStyle-HorizontalAlign="Center"> 
                                                                        <ItemStyle Width="15%" HorizontalAlign="center" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkLost_Work_Days" runat="server" Text='<%# Eval("Lost_Work_Days").ToString() %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Compliance_Reporting_OSHA") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Number of Restricted Work Days" HeaderStyle-HorizontalAlign="Center">
                                                                        <ItemStyle Width="15%" HorizontalAlign="center" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRestsricted_Work_Days" runat="server" Text='<%# Eval("Restsricted_Work_Days").ToString() %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Compliance_Reporting_OSHA") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                     <asp:TemplateField HeaderText="Total Number of Associates" HeaderStyle-HorizontalAlign="Center">
                                                                        <ItemStyle Width="15%" HorizontalAlign="center" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkTotal_Associates" runat="server" Text='<%# Eval("Total_Associates").ToString() %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Compliance_Reporting_OSHA") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove" HeaderStyle-HorizontalAlign="Center">
                                                                        <ItemStyle Width="10%" HorizontalAlign="center" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CommandName="RemoveDetails"
                                                                                CommandArgument='<%# Eval("PK_PM_Compliance_Reporting_OSHA") %>' OnClientClick="return confirm('Are you sure to remove the record?');" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl4" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Equipment</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%" style="height: 230px;">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Equipment Grid<br />
                                                            <asp:LinkButton ID="lnkAddEquipment" runat="server" Text="--Add--" CausesValidation="true"
                                                                ValidationGroup="vsErrorGroup" OnClick="lnkAddGridRecord_Click" OnClientClick="return ValSave();" />
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvEquipment" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Type">
                                                                        <ItemStyle Width="30%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkFK_LU_Equipment_Type" runat="server" Text='<%# Eval("FK_LU_Equipment_Type") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Equipment") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Description">
                                                                        <ItemStyle Width="60%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkDesciption" runat="server" Text='<%# Eval("Description") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Equipment") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CommandName="RemoveDetails"
                                                                                CommandArgument='<%# Eval("PK_PM_Equipment") %>' OnClientClick="return confirm('Are you sure to remove the record?');" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl5" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Waste Disposal</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%" style="height: 230px;">
                                                    <tr>
                                                        <td align="left" width="14%" valign="top">
                                                            Hazardous Waste Hauler Grid<br />
                                                            <asp:LinkButton ID="lnkWasteHauler" runat="server" Text="--Add--" CausesValidation="true"
                                                                ValidationGroup="vsErrorGroup" OnClick="lnkAddGridRecord_Click" OnClientClick="return ValSave();" />
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvWasteHauler" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Name">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkWaste_Hauler_Name" runat="server" Text='<%# Eval("Waste_Hauler_Name") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Waste_Hauler") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Address">
                                                                        <ItemStyle Width="25%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkAddress_1" runat="server" Text='<%# clsGeneral.FormatAddress(Eval("Address_1"), Eval("Address_2"), Eval("City"), Eval("FK_State"), Eval("Zip_Code"))%>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Waste_Hauler") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Contact">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkContact_Name" runat="server" Text='<%# Eval("Contact_Name") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Waste_Hauler") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Phone">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkContact_Telephone" runat="server" Text='<%# Eval("Contact_Telephone") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Waste_Hauler") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CommandName="RemoveDetails"
                                                                                CommandArgument='<%# Eval("PK_PM_Waste_Hauler") %>' OnClientClick="return confirm('Are you sure to remove the record?');" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="14%" valign="top">
                                                            Receiving TSDF Grid<br />
                                                            <asp:LinkButton ID="lnkAddTSDF" runat="server" Text="--Add--" CausesValidation="true"
                                                                ValidationGroup="vsErrorGroup" OnClick="lnkAddGridRecord_Click" OnClientClick="return ValSave();" />
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvTSDF" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Name">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkReceiving_TSDF_Name" runat="server" Text='<%# Eval("Receiving_TSDF_Name") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Receiving_TSDF") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Address">
                                                                        <ItemStyle Width="25%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkAddress_1" runat="server" Text='<%# clsGeneral.FormatAddress(Eval("Address_1"), Eval("Address_2"), Eval("City"), Eval("FK_State"), Eval("Zip_Code"))%>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Receiving_TSDF") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Contact">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkContact_Name" runat="server" Text='<%# Eval("Contact_Name") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Receiving_TSDF") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Phone">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkContact_Telephone" runat="server" Text='<%# Eval("Contact_Telephone") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Receiving_TSDF") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CommandName="RemoveDetails"
                                                                                CommandArgument='<%# Eval("PK_PM_Receiving_TSDF") %>' OnClientClick="return confirm('Are you sure to remove the record?');" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="14%" valign="top">
                                                            Hazardous Waste Generator Grid<br />
                                                            <asp:LinkButton ID="lnkWasteRemoval" runat="server" Text="--Add--" CausesValidation="true"
                                                                ValidationGroup="vsErrorGroup" OnClick="lnkAddGridRecord_Click" OnClientClick="return ValSave();" />
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvWasteRemoval" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Type">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkFK_LU_Waste_Type" runat="server" Text='<%# Eval("FK_LU_Waste_Type") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Waste_Removal") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Hauler">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkFK_PM_Waste_Hauler" runat="server" Text='<%# Eval("FK_PM_Waste_Hauler") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Waste_Removal") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Receiver">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkFK_Receiving_TSDF" runat="server" Text='<%# Eval("FK_Receiving_TSDF") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Waste_Removal") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Date">
                                                                        <ItemStyle Width="12%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkDate" runat="server" Text='<%# string.Format("{0:MM-dd-yyyy}",Eval("Date")) %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Waste_Removal") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Amount">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkAmount_HW_Generated_Per_Month" runat="server" Text='<%# string.Format("{0:N2}", Eval("Amount_HW_Generated_Per_Month")) + Eval("Units") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Waste_Removal") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle Width="8%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CommandName="RemoveDetails"
                                                                                CommandArgument='<%# Eval("PK_PM_Waste_Removal") %>' OnClientClick="return confirm('Are you sure to remove the record?');" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Notes&nbsp;<span id="Span19" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="txtWasteDisposalNotes" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl6" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Audit/Inspections</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%" style="height: 230px;">
                                                    <tr>
                                                        <td align="left" width="14%" valign="top">
                                                            Inspection Grid<br />
                                                            <asp:LinkButton ID="lnkFrequency" runat="server" Text="--Add--" CausesValidation="true"
                                                                ValidationGroup="vsErrorGroup" OnClick="lnkAddGridRecord_Click" OnClientClick="return ValSave();" />
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvFrequency" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Last Insp">
                                                                        <ItemStyle Width="18%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkLast_Inspection_Date" runat="server" Text='<%# string.Format("{0:MM-dd-yyyy}", Eval("Last_Inspection_Date")) %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Frequency") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Next Insp">
                                                                        <ItemStyle Width="18%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkNext_Inspection_Date" runat="server" Text='<%# string.Format("{0:MM-dd-yyyy}", Eval("Next_Inspection_Date")) %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Frequency") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Cost $">
                                                                        <ItemStyle Width="18%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkCost" runat="server" Text='<%# string.Format("{0:N2}", Eval("Cost")) %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Frequency") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Next Report">
                                                                        <ItemStyle Width="18%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkNext_Report_Due" runat="server" Text='<%# Eval("Next_Report_Due") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Frequency") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Report Due">
                                                                        <ItemStyle Width="18%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkNext_Report_Date" runat="server" Text='<%# string.Format("{0:MM-dd-yyyy}", Eval("Next_Report_Date")) %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Frequency") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CommandName="RemoveDetails"
                                                                                CommandArgument='<%# Eval("PK_PM_Frequency") %>' OnClientClick="return confirm('Are you sure to remove the record?');" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                   <%-- <tr>
                                                        <td colspan="6">
                                                            &nbsp;
                                                        </td>
                                                    </tr>--%>
                                                    <%--<tr>
                                                        <td align="left" width="14%" valign="top">
                                                            Phase I Grid<br />
                                                            <asp:LinkButton ID="lnkPhaseI" runat="server" Text="--Add--" CausesValidation="true"
                                                                ValidationGroup="vsErrorGroup" OnClick="lnkAddGridRecord_Click" OnClientClick="return ValSave();" />
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvPhaseI" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Assessor">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkAssessor" runat="server" Text='<%# Eval("Assessor") %>' CommandName="EditDetails"
                                                                                CommandArgument='<%# Eval("PK_PM_Phase_I") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Last Insp">
                                                                        <ItemStyle Width="16%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkReport_Date" runat="server" Text='<%# string.Format("{0:MM-dd-yyyy}", Eval("Report_Date")) %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Phase_I") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Next Insp">
                                                                        <ItemStyle Width="17%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkNext_Report_Date" runat="server" Text='<%# string.Format("{0:MM-dd-yyyy}", Eval("Next_Report_Date")) %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Phase_I") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Next Review">
                                                                        <ItemStyle Width="17%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkNext_Review_Date" runat="server" Text='<%# string.Format("{0:MM-dd-yyyy}", Eval("Next_Review_Date")) %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Phase_I") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Cost $">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkCost" runat="server" Text='<%# string.Format("{0:N2}", Eval("Cost")) %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Phase_I") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CommandName="RemoveDetails"
                                                                                CommandArgument='<%# Eval("PK_PM_Phase_I") %>' OnClientClick="return confirm('Are you sure to remove the record?');" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td colspan="6">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="14%" valign="top">
                                                            Regulatory Inspections Grid<br />
                                                            <asp:LinkButton ID="lnkEPAInspection" runat="server" Text="--Add--" CausesValidation="true"
                                                                ValidationGroup="vsErrorGroup" OnClick="lnkAddGridRecord_Click" OnClientClick="return ValSave();" />
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvEPAInspections" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Inspection Agency">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkAssessor" runat="server" Text='<%# Eval("Fld_Desc") %>' CommandName="EditDetails"
                                                                                CommandArgument='<%# Eval("PK_PM_EPA_Inspection") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Type">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkType" runat="server" Text='<%# Eval("Inspection_Type") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_EPA_Inspection") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Last Insp.">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkReport_Date" runat="server" Text='<%# string.Format("{0:MM-dd-yyyy}", Eval("Report_Date")) %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_EPA_Inspection") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Next Insp.">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkNext_Report_Date" runat="server" Text='<%# string.Format("{0:MM-dd-yyyy}", Eval("Next_Report_Date")) %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_EPA_Inspection") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Next Review">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkNext_Review_Date" runat="server" Text='<%# string.Format("{0:MM-dd-yyyy}", Eval("Next_Review_Date")) %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_EPA_Inspection") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Cost $">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkCost" runat="server" Text='<%# string.Format("{0:N2}", Eval("Cost")) %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_EPA_Inspection") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CommandName="RemoveDetails"
                                                                                CommandArgument='<%# Eval("PK_PM_EPA_Inspection") %>' OnClientClick="return confirm('Are you sure to remove the record?');" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Notes&nbsp;<span id="Span20" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="txtInspectionNotes" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl9" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Remediations</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%" style="height: 230px;">
                                                    <tr>
                                                        <td align="left" width="14%" valign="top">
                                                            Remediation Grid<br />
                                                            <asp:LinkButton ID="lnkRemediations" runat="server" Text="--Add--" CausesValidation="true"
                                                                ValidationGroup="vsErrorGroup" OnClick="lnkAddGridRecord_Click" OnClientClick="return ValSave();" />
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvRemediations" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Description">
                                                                        <ItemStyle Width="25%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkPhase_II" runat="server" Text='<%# Eval("Description") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Remediation_Grid") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Assessor">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkAssessor" runat="server" Text='<%# Eval("Assessor") %>' CommandName="EditDetails"
                                                                                CommandArgument='<%# Eval("PK_PM_Remediation_Grid") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Report Date">
                                                                        <ItemStyle Width="12%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkReport_Date" runat="server" Text='<%# string.Format("{0:MM-dd-yyyy}", Eval("Report_Date")) %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Remediation_Grid") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Next Report">
                                                                        <ItemStyle Width="12%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkNext_Report_Date" runat="server" Text='<%# string.Format("{0:MM-dd-yyyy}", Eval("Next_Report_Date")) %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Remediation_Grid") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Next Review">
                                                                        <ItemStyle Width="12%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkNext_Review_Date" runat="server" Text='<%# string.Format("{0:MM-dd-yyyy}", Eval("Next_Review_Date")) %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Remediation_Grid") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Cost $">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkCost" runat="server" Text='<%# string.Format("{0:N2}", Eval("Cost")) %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Remediation_Grid") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle Width="9%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CommandName="RemoveDetails"
                                                                                CommandArgument='<%# Eval("PK_PM_Remediation_Grid") %>' OnClientClick="return confirm('Are you sure to remove the record?');" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Notes&nbsp;<span id="Span21" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtRemediationNote" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl8" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Violations</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%" style="height: 230px;">
                                                    <tr>
                                                        <td align="left" width="8%" valign="top">
                                                            Violations Grid<br />
                                                            <asp:LinkButton ID="lnkViolations" runat="server" Text="--Add--" CausesValidation="true"
                                                                ValidationGroup="vsErrorGroup" OnClick="lnkAddGridRecord_Click" OnClientClick="return ValSave();" />
                                                        </td>
                                                        <td align="center" width="2%" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvViolations" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Date">
                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkDate_Of_Violation" runat="server" Text='<%# string.Format("{0:MM-dd-yyyy}", Eval("Date_Of_Violation")) %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Violation") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Regulatory/Notifying Agency">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkNotifying_Agency" runat="server" Text='<%# Eval("Regulatory_Notifying_Agency") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Violation") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Desc">
                                                                        <ItemStyle Width="18%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkDescription_Of_Violations" runat="server" Text='<%# Eval("Description_Of_Violations") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Violation") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Contact">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkContact_Name" runat="server" Text='<%# Eval("Contact_Name") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Violation") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Phone Number">
                                                                        <ItemStyle Width="12%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkContact_Telephone" runat="server" Text='<%# Eval("Contact_Telephone") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Violation") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Fine $">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkCost" runat="server" Text='<%# string.Format("{0:N2}", Eval("Cost")) %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Violation") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle Width="8%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CommandName="RemoveDetails"
                                                                                CommandArgument='<%# Eval("PK_PM_Violation") %>' OnClientClick="return confirm('Are you sure to remove the record?');" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Notes&nbsp;<span id="Span22" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtViolationsNotes" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl7" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Occupational Health and Safety Programs</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%" style="height: 230px;">
                                                    <tr>
                                                        <td align="left" width="14%" valign="top">
                                                            Hearing Conversation<br />
                                                            <asp:LinkButton ID="lnkHearingConversation" runat="server" Text="--Add--" CausesValidation="true"
                                                                ValidationGroup="vsErrorGroup" OnClick="lnkAddGridRecord_Click" OnClientClick="return ValSave();" />
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvHearingConversation" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Year">
                                                                        <ItemStyle Width="18%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkYear" runat="server" Text='<%#  Eval("YEAROFTEST") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Hearing_Conservation") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                      <asp:TemplateField HeaderText="Associate">
                                                                        <ItemStyle Width="18%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkAssociate" runat="server" Text='<%#  Eval("Associate") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Hearing_Conservation") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Test Type">
                                                                        <ItemStyle Width="18%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkNext_Inspection_Date" runat="server" Text='<%# Eval("TestType") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Hearing_Conservation") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>                                                                 
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CommandName="RemoveDetails"
                                                                                CommandArgument='<%# Eval("PK_PM_Hearing_Conservation") %>' OnClientClick="return confirm('Are you sure to remove the record?');" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>                                                  
                                                    <tr>
                                                        <td colspan="6">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="14%" valign="top">
                                                            Respiratory Protection<br />
                                                            <asp:LinkButton ID="lnkRespiratoryProtection" runat="server" Text="--Add--" CausesValidation="true"
                                                                ValidationGroup="vsErrorGroup" OnClick="lnkAddGridRecord_Click" OnClientClick="return ValSave();" />
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                           <asp:GridView ID="gvRespiratoryProtection" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Date">
                                                                        <ItemStyle Width="18%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkYear" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay( Eval("Date")) %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Respiratory_Protection") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                      <asp:TemplateField HeaderText="Associate">
                                                                        <ItemStyle Width="18%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkAssociate" runat="server" Text='<%#  Eval("Associate") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Respiratory_Protection") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Event">
                                                                        <ItemStyle Width="18%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkNext_Inspection_Date" runat="server" Text='<%# Eval("EventType") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_Respiratory_Protection") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>                                                                 
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CommandName="RemoveDetails"
                                                                                CommandArgument='<%# Eval("PK_PM_Respiratory_Protection") %>' OnClientClick="return confirm('Are you sure to remove the record?');" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>      
                                                    <tr>
                                                        <td colspan="6">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="14%" valign="top">
                                                            First Response And AED Equipment<br />
                                                            <asp:LinkButton ID="lnkAEDEquipment" runat="server" Text="--Add--" CausesValidation="true"
                                                                ValidationGroup="vsErrorGroup" OnClick="lnkAddGridRecord_Click" OnClientClick="return ValSave();" />
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvFirstResponseAEDEquipment" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="AED Locations">
                                                                        <ItemStyle Width="18%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkAEDLocation" runat="server" Text='<%#Eval("AED_Location_Desc") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_FirstRepose_AEDEquipment") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                      <asp:TemplateField HeaderText="AED Manufacturer">
                                                                        <ItemStyle Width="18%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkAEDManufacturer" runat="server" Text='<%#  Eval("AEDManufacturer") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_FirstRepose_AEDEquipment") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="AED Install Date">
                                                                        <ItemStyle Width="18%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkAEDInstallDate" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay( Eval("AEDInstallDate")) %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_FirstRepose_AEDEquipment") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>                                                                 
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CommandName="RemoveDetails"
                                                                                CommandArgument='<%# Eval("PK_PM_FirstRepose_AEDEquipment") %>' OnClientClick="return confirm('Are you sure to remove the record?');" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>    
                                                    <tr>
                                                        <td colspan="6">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="14%" valign="top">
                                                            First Response And AED Associate Training<br />
                                                            <asp:LinkButton ID="lnkAEDAssociateTraining" runat="server" Text="--Add--" CausesValidation="true"
                                                                ValidationGroup="vsErrorGroup" OnClick="lnkAddGridRecord_Click" OnClientClick="return ValSave();" />
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvFirstResponseAEDAssociateTraining" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Associate Name">
                                                                        <ItemStyle Width="18%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkAssociateName" runat="server" Text='<%#Eval("AssociateName") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_AssociateTrainingFirstRepose_AED") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                      <asp:TemplateField HeaderText="Associate Title">
                                                                        <ItemStyle Width="18%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkAssociateTitle" runat="server" Text='<%#  Eval("AssociateTitle") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_AssociateTrainingFirstRepose_AED") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Associate Training Date">
                                                                        <ItemStyle Width="18%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkAssociateTrainingDate" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay( Eval("AssociateTrainingDate")) %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_AssociateTrainingFirstRepose_AED") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>                                                                 
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CommandName="RemoveDetails"
                                                                                CommandArgument='<%# Eval("PK_PM_AssociateTrainingFirstRepose_AED") %>' OnClientClick="return confirm('Are you sure to remove the record?');" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>                                 
                                                </table>
                                            </asp:Panel>
                                            <div id="dvAttachment" runat="server" style="display: none;">
                                                <table cellpadding="0" cellspacing="0" width="100%" style="height: 230px;">
                                                    <tr>
                                                        <td width="100%">
                                                            <uc:ctrlAttachment ID="Attachment" runat="Server" OnbtnHandler="btnAddAttachment_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Spacer" style="height: 20px;">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                        <div id="dvView" runat="server" width="794px">
                                            <asp:Panel ID="pnl1View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Site Information</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%" style="height: 220px;">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Building
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lblFK_BuildingView" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            County
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblFK_County" runat="server"></asp:Label>
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
                                                        <td align="left" valign="top">
                                                            SIC Code
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td width="15%" align="left" valign="top">
                                                                        <asp:Label ID="lblFK_LU_SIC" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblSICDesc" runat="server" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            NAICS Code
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td width="15%" align="left" valign="top">
                                                                        <asp:Label ID="lblFK_LU_NAICS" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblNAICSDesc" runat="server" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Number of Associates
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblNumber_Of_Employees" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Number of Shifts
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblNumber_Of_Shift" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Days Per Week
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblDays_Per_Week" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Weeks Per Year
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblWeeks_Per_Year" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Facility Construction Completion Year
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFacility_Construction_Completion_Year" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Owner of Facility
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblOwner_Of_Facility" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Latitude (DD:MM:SS)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLatitude" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Longitude (DDD:MM:SS)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblLongitude" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Utility Provider Grid
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvUtilityView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Type">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkFK_LU_Utility_Type" runat="server" Text='<%# Eval("FLD_Desc") %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_SI_Utility_Provider") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Name">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkUtility_Name" runat="server" Text='<%# Eval("Utility_Name") %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_SI_Utility_Provider") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Phone">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkTelephone" runat="server" Text='<%# Eval("Telephone") %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_SI_Utility_Provider") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Address">
                                                                        <ItemStyle Width="30%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkAddress_1" runat="server" Text='<%# clsGeneral.FormatAddress(Eval("Address_1"),Eval("Address_2"), Eval("City"), Eval("FK_State"), Eval("Zip_Code")) %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_SI_Utility_Provider") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Facility Id Grid
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvFacilityView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Agency">
                                                                        <ItemStyle Width="30%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkFK_LU_Agency" runat="server" Text='<%# Eval("FK_LU_Agency") %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_SI_Faciltiy_ID") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="I.D.Type">
                                                                        <ItemStyle Width="30%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkFK_LU_Media" runat="server" Text='<%# Eval("FK_LU_Media") %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_SI_Faciltiy_ID") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Id">
                                                                        <ItemStyle Width="30%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkIdentification_Number" runat="server" Text='<%# Eval("Identification_Number") %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_SI_Faciltiy_ID") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl2View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Permits</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%" style="height: 230px;">
                                                    <tr>
                                                        <td align="left" width="12%" valign="top">
                                                            Permits Grid
                                                        </td>
                                                        <td align="center" width="2%" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvPermitsView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Type">
                                                                        <ItemStyle Width="57%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkFK_Permit_Type" runat="server" Text='<%# Eval("FK_Permit_Type") %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Permits") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Permit Start">
                                                                        <ItemStyle Width="18%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkPermit_Start_Date" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Permit_Start_Date")) %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Permits") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Permit End">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkPermit_End_Date" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Permit_End_Date")) %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Permits") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl3View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Compliance Reporting</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%" style="height: 230px;">
                                                    <%--<tr>
														<td align="left" width="18%" valign="top">Federal Facility Identification Number</td>
														<td align="center" width="4%" valign="top">:</td>
														<td align="left" width="28%" valign="top"><asp:Label ID="lblFederal_Facility_Identification_Number" runat="server"></asp:Label>
														</td>
														<td align="left" width="18%" valign="top">State Facility Identification Number</td>
														<td align="center" width="4%" valign="top">:</td>
														<td align="left" width="28%" valign="top"><asp:Label ID="lblState_Facility_Identification_Number" runat="server"></asp:Label>
														</td>
													</tr>--%>
                                                    <tr>
                                                        <td align="left" valign="top" width="16%">
                                                            Location Contact Name
                                                        </td>
                                                        <td align="center" valign="top" width="2%">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" width="30%">
                                                            <asp:Label ID="lblContact_Name" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top" width="18%">
                                                            Location Contact Telephone
                                                        </td>
                                                        <td align="center" valign="top" width="2%">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" width="22%">
                                                            <asp:Label ID="lblContact_Telephone" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Emergency Contact Name
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblEmergency_Contact_Name" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Emergency Contact Telephone
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblEmergency_Telephone" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <%--   <tr>
                                                        <td align="left" valign="top">Chemical Inventory Grid</td>
                                                        <td align="center" valign="top">:</td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvChemicalInventoryView" runat="server" Width="100%" AutoGenerateColumns="false" EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
	                                                            <Columns>
		                                                            <asp:TemplateField HeaderText="Type">
			                                                            <ItemStyle Width="20%" HorizontalAlign="Left" />
			                                                            <ItemTemplate>
				                                                            <asp:LinkButton ID="lnkFK_LU_Chemical_Type" runat="server" Text='<%# Eval("FK_LU_Chemical_Type") %>' CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_CR_Chemical_Inventory") %>' />
			                                                            </ItemTemplate>
		                                                            </asp:TemplateField>
		                                                            <asp:TemplateField HeaderText="CAS Number">
			                                                            <ItemStyle Width="20%" HorizontalAlign="Left" />
			                                                            <ItemTemplate>
				                                                            <asp:LinkButton ID="lnkCAS_Number" runat="server" Text='<%# Eval("CAS_Number") %>' CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_CR_Chemical_Inventory") %>' />
			                                                            </ItemTemplate>
		                                                            </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Name">
			                                                            <ItemStyle Width="15%" HorizontalAlign="Left" />
			                                                            <ItemTemplate>
				                                                            <asp:LinkButton ID="lnkChemical_Name" runat="server" Text='<%# Eval("Chemical_Name") %>' CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_CR_Chemical_Inventory") %>' />
			                                                            </ItemTemplate>
		                                                            </asp:TemplateField>
		                                                            <asp:TemplateField HeaderText="Location">
			                                                            <ItemStyle Width="20%" HorizontalAlign="Left" />
			                                                            <ItemTemplate>
				                                                            <asp:LinkButton ID="lnkFK_LU_Storage_Location" runat="server" Text='<%# Eval("FK_LU_Storage_Location") %>' CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_CR_Chemical_Inventory") %>' />
			                                                            </ItemTemplate>
		                                                            </asp:TemplateField>                                                                    
	                                                            </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Paint Inventory Grid</td>
                                                        <td align="center" valign="top">:</td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvPaintInventoryView" runat="server" Width="100%" AutoGenerateColumns="false" EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
	                                                            <Columns>
		                                                            <asp:TemplateField HeaderText="Type">
			                                                            <ItemStyle Width="20%" HorizontalAlign="Left" />
			                                                            <ItemTemplate>
				                                                            <asp:LinkButton ID="lnkFK_LU_Paint_Type" runat="server" Text='<%# Eval("FK_LU_Paint_Type") %>' CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_CR_Paint_Inventory") %>' />
			                                                            </ItemTemplate>
		                                                            </asp:TemplateField>
		                                                            <asp:TemplateField HeaderText="CAS Number">
			                                                            <ItemStyle Width="20%" HorizontalAlign="Left" />
			                                                            <ItemTemplate>
				                                                            <asp:LinkButton ID="lnkCAS_Number" runat="server" Text='<%# Eval("CAS_Number") %>' CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_CR_Paint_Inventory") %>' />
			                                                            </ItemTemplate>
		                                                            </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Color">
			                                                            <ItemStyle Width="15%" HorizontalAlign="Left" />
			                                                            <ItemTemplate>
				                                                            <asp:LinkButton ID="lnkPaint_Color" runat="server" Text='<%# Eval("Paint_Color") %>' CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_CR_Paint_Inventory") %>' />
			                                                            </ItemTemplate>
		                                                            </asp:TemplateField>
		                                                            <asp:TemplateField HeaderText="Location">
			                                                            <ItemStyle Width="20%" HorizontalAlign="Left" />
			                                                            <ItemTemplate>
				                                                            <asp:LinkButton ID="lnkFK_LU_Storage_Location" runat="server" Text='<%# Eval("FK_LU_Storage_Location") %>' CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_CR_Paint_Inventory") %>' />
			                                                            </ItemTemplate>
		                                                            </asp:TemplateField>                                                                    
	                                                            </Columns>
                                                            </asp:GridView>

                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Tier II Reporting Grid
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvTierIIView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Report Due Date">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkReport_Due_Date" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Report_Due_Date")) %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_CR_Grids") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Report Submission Date">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkReport_Submission_Date" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Report_Submission_Date")) %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_CR_Grids") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Initial Notification Submitted">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkInitial_Notification" runat="server" Text='<%# (Eval("Initial_Notification").ToString() == "N" ? "No" : Eval("Initial_Notification").ToString() == "R"? "Not Required": "Yes") %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_CR_Grids") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Compliance Verification Submitted">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkCompliance_Verification" runat="server" Text='<%# (Eval("Compliance_Verification").ToString() == "N" ? "No" : Eval("Compliance_Verification").ToString() == "R"? "Not Required": "Yes") %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_CR_Grids") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Notification of Report Changes Submitted">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkReport_Changes" runat="server" Text='<%# (Eval("Report_Changes").ToString() == "N" ? "No" : Eval("Report_Changes").ToString() == "R"? "Not Required": "Yes") %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_CR_Grids") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Air Permit Grid
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvAir_PermitView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Report Due Date">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkReport_Due_Date" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Report_Due_Date")) %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_CR_Grids") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Report Submission Date">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkReport_Submission_Date" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Report_Submission_Date")) %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_CR_Grids") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Initial Notification Submitted">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkInitial_Notification" runat="server" Text='<%# (Eval("Initial_Notification").ToString() == "N" ? "No" : Eval("Initial_Notification").ToString() == "R"? "Not Required": "Yes") %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_CR_Grids") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Compliance Verification Submitted">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkCompliance_Verification" runat="server" Text='<%# (Eval("Compliance_Verification").ToString() == "N" ? "No" : Eval("Compliance_Verification").ToString() == "R"? "Not Required": "Yes") %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_CR_Grids") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Notification of Report Changes Submitted">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkReport_Changes" runat="server" Text='<%# (Eval("Report_Changes").ToString() == "N" ? "No" : Eval("Report_Changes").ToString() == "R"? "Not Required": "Yes") %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_CR_Grids") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            6H Grid
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvSixHView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Report Due Date">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkReport_Due_Date" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Report_Due_Date")) %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_CR_Grids") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Report Submission Date">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkReport_Submission_Date" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Report_Submission_Date")) %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_CR_Grids") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Initial Notification Submitted">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkInitial_Notification" runat="server" Text='<%# (Eval("Initial_Notification").ToString() == "N" ? "No" : Eval("Initial_Notification").ToString() == "R"? "Not Required": "Yes") %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_CR_Grids") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Compliance Verification Submitted">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkCompliance_Verification" runat="server" Text='<%# (Eval("Compliance_Verification").ToString() == "N" ? "No" : Eval("Compliance_Verification").ToString() == "R"? "Not Required": "Yes") %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_CR_Grids") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Notification of Report Changes Submitted">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkReport_Changes" runat="server" Text='<%# (Eval("Report_Changes").ToString() == "N" ? "No" : Eval("Report_Changes").ToString() == "R"? "Not Required": "Yes") %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_CR_Grids") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            OSHA Log Grid<br />
                                                            [Main Building Only]<br />                                                           
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvOshaLogGridView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Exists" OnRowCommand="gvComplainceReportingOSHA_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Date Completed" HeaderStyle-HorizontalAlign="Center">
                                                                        <ItemStyle Width="15%" HorizontalAlign="center" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkDate_Completed" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Date_Completed")) %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Compliance_Reporting_OSHA") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Feb 1 Log Posting" HeaderStyle-HorizontalAlign="Center">
                                                                        <ItemStyle Width="15%" HorizontalAlign="center" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkLog_Posted_Feb_1" runat="server" Text='<%# CheckStatus(Eval("Log_Posted_Feb_1")) %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Compliance_Reporting_OSHA") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Number of OSHA Recordable" HeaderStyle-HorizontalAlign="Center">
                                                                        <ItemStyle Width="15%" HorizontalAlign="center" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkOSHA_Recordable" runat="server" Text='<%# Eval("OSHA_Recordable").ToString() %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Compliance_Reporting_OSHA") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Number of Lost Work Days" HeaderStyle-HorizontalAlign="Center">
                                                                        <ItemStyle Width="15%" HorizontalAlign="center" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkLost_Work_Days" runat="server" Text='<%# Eval("Lost_Work_Days").ToString() %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Compliance_Reporting_OSHA") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Number of Restricted Work Days" HeaderStyle-HorizontalAlign="Center">
                                                                        <ItemStyle Width="15%" HorizontalAlign="center" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRestsricted_Work_Days" runat="server" Text='<%# Eval("Restsricted_Work_Days").ToString() %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Compliance_Reporting_OSHA") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                     <asp:TemplateField HeaderText="Total Number of Associates" HeaderStyle-HorizontalAlign="Center">
                                                                        <ItemStyle Width="15%" HorizontalAlign="center" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkTotal_Associates" runat="server" Text='<%# Eval("Total_Associates").ToString() %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Compliance_Reporting_OSHA") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                   <%-- <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CommandName="RemoveDetails"
                                                                                CommandArgument='<%# Eval("PK_PM_Compliance_Reporting_OSHA") %>' OnClientClick="return confirm('Are you sure to remove the record?');" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>--%>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl4View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Equipment</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%" style="height: 230px;">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Equipment Grid
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvEquipmentView" runat="server" Width="100%" AutoGenerateColumns="false" 
                                                                EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Type">
                                                                        <ItemStyle Width="30%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkFK_LU_Equipment_Type" runat="server" Text='<%# Eval("FK_LU_Equipment_Type") %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Equipment") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Description">
                                                                        <ItemStyle Width="60%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkDesciption" runat="server" Text='<%# Eval("Description") %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Equipment") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl5View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Waste Disposal</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%" style="height: 230px;">
                                                    <tr>
                                                        <td align="left" width="14%" valign="top">
                                                            Hazardous Waste Hauler Grid
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvWasteHaulerView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Name">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkWaste_Hauler_Name" runat="server" Text='<%# Eval("Waste_Hauler_Name") %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Waste_Hauler") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Address">
                                                                        <ItemStyle Width="25%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkAddress_1" runat="server" Text='<%# clsGeneral.FormatAddress(Eval("Address_1"), Eval("Address_2"), Eval("City"), Eval("FK_State"), Eval("Zip_Code"))%>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Waste_Hauler") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Contact">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkContact_Name" runat="server" Text='<%# Eval("Contact_Name") %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Waste_Hauler") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Phone">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkContact_Telephone" runat="server" Text='<%# Eval("Contact_Telephone") %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Waste_Hauler") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="14%" valign="top">
                                                            Receiving TSDF Grid
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvTSDFView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Name">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkReceiving_TSDF_Name" runat="server" Text='<%# Eval("Receiving_TSDF_Name") %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Receiving_TSDF") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Address">
                                                                        <ItemStyle Width="25%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkAddress_1" runat="server" Text='<%# clsGeneral.FormatAddress(Eval("Address_1"), Eval("Address_2"), Eval("City"), Eval("FK_State"), Eval("Zip_Code"))%>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Receiving_TSDF") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Contact">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkContact_Name" runat="server" Text='<%# Eval("Contact_Name") %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Receiving_TSDF") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Phone">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkContact_Telephone" runat="server" Text='<%# Eval("Contact_Telephone") %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Receiving_TSDF") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="14%" valign="top">
                                                            Hazardous Waste Generator Grid
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvWasteRemovalView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Type">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkFK_LU_Waste_Type" runat="server" Text='<%# Eval("FK_LU_Waste_Type") %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Waste_Removal") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Hauler">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkFK_PM_Waste_Hauler" runat="server" Text='<%# Eval("FK_PM_Waste_Hauler") %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Waste_Removal") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Receiver">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkFK_Receiving_TSDF" runat="server" Text='<%# Eval("FK_Receiving_TSDF") %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Waste_Removal") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Date">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkDate" runat="server" Text='<%# string.Format("{0:MM-dd-yyyy}", Eval("Date")) %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Waste_Removal") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Amount">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkAmount_HW_Generated_Per_Month" runat="server" Text='<%# string.Format("{0:N2}", Eval("Amount_HW_Generated_Per_Month")) + Eval("Units") %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Waste_Removal") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Notes
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="lblWasteDisposalNotes" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl6View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Audit/Inspections</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%" style="height: 230px;">
                                                    <tr>
                                                        <td align="left" width="14%" valign="top">
                                                            Inspection Grid
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvFrequencyView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Last Insp">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkLast_Inspection_Date" runat="server" Text='<%# string.Format("{0:MM-dd-yyyy}", Eval("Last_Inspection_Date")) %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Frequency") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Next Insp">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkNext_Inspection_Date" runat="server" Text='<%# string.Format("{0:MM-dd-yyyy}", Eval("Next_Inspection_Date")) %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Frequency") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Cost $">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkCost" runat="server" Text='<%# string.Format("{0:N2}", Eval("Cost")) %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Frequency") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Next Report">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkNext_Report_Due" runat="server" Text='<%# Eval("Next_Report_Due") %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Frequency") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Report Due">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkNext_Report_Date" runat="server" Text='<%# string.Format("{0:MM-dd-yyyy}", Eval("Next_Report_Date")) %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Frequency") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <%--<tr>
                                                        <td align="left" width="14%" valign="top">
                                                            Phase I Grid
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvPhaseIView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Assessor">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkAssessor" runat="server" Text='<%# Eval("Assessor") %>' CommandName="ViewDetails"
                                                                                CommandArgument='<%# Eval("PK_PM_Phase_I") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Last Insp">
                                                                        <ItemStyle Width="16%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkReport_Date" runat="server" Text='<%# string.Format("{0:MM-dd-yyyy}", Eval("Report_Date")) %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Phase_I") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Next Insp">
                                                                        <ItemStyle Width="17%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkNext_Report_Date" runat="server" Text='<%# string.Format("{0:MM-dd-yyyy}", Eval("Next_Report_Date")) %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Phase_I") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Next Review">
                                                                        <ItemStyle Width="17%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkNext_Review_Date" runat="server" Text='<%# string.Format("{0:MM-dd-yyyy}", Eval("Next_Review_Date")) %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Phase_I") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Cost $">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkCost" runat="server" Text='<%# string.Format("{0:N2}", Eval("Cost")) %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Phase_I") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>--%>
                                                  <%--  <tr>
                                                        <td colspan="6">
                                                            &nbsp;
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="left" width="14%" valign="top">
                                                            Regulatory Inspections Grid
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvEPAInspectionsView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Inspection Agency">
                                                                        <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkAssessor" runat="server" Text='<%# Eval("Fld_Desc") %>' CommandName="ViewDetails"
                                                                                CommandArgument='<%# Eval("PK_PM_EPA_Inspection") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Type">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkType" runat="server" Text='<%# Eval("Inspection_Type") %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_EPA_Inspection") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Last Insp.">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkReport_Date" runat="server" Text='<%# string.Format("{0:MM-dd-yyyy}", Eval("Report_Date")) %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_EPA_Inspection") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Next Insp.">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkNext_Report_Date" runat="server" Text='<%# string.Format("{0:MM-dd-yyyy}", Eval("Next_Report_Date")) %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_EPA_Inspection") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Next Review">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkNext_Review_Date" runat="server" Text='<%# string.Format("{0:MM-dd-yyyy}", Eval("Next_Review_Date")) %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_EPA_Inspection") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Cost $">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkCost" runat="server" Text='<%# string.Format("{0:N2}", Eval("Cost")) %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_EPA_Inspection") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Notes
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="lblInspectionNotes" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl7View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Occupational Health and Safety Programs</div>                                                          
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%" style="height: 230px;">
                                                    <tr>
                                                        <td align="left" width="14%" valign="top">
                                                            Hearing Conversation<br />
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvHearingConversationView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Year">
                                                                        <ItemStyle Width="18%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkYear" runat="server" Text='<%#  Eval("YEAROFTEST") %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Hearing_Conservation") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                      <asp:TemplateField HeaderText="Associate">
                                                                        <ItemStyle Width="18%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkAssociate" runat="server" Text='<%#  Eval("Associate") %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Hearing_Conservation") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Test Type">
                                                                        <ItemStyle Width="18%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkNext_Inspection_Date" runat="server" Text='<%# Eval("TestType") %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Hearing_Conservation") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>                                                                                                                                    
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>                                                  
                                                    <tr>
                                                        <td colspan="6">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="14%" valign="top">
                                                            Respiratory Protection<br />                                                                                                                            
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                           <asp:GridView ID="gvRespiratoryProtectionView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
                                                                <Columns>
                                                                  <asp:TemplateField HeaderText="Date">
                                                                        <ItemStyle Width="18%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkYear" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay( Eval("Date")) %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Respiratory_Protection") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                      <asp:TemplateField HeaderText="Associate">
                                                                        <ItemStyle Width="18%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkAssociate" runat="server" Text='<%#  Eval("Associate") %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Respiratory_Protection") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Event">
                                                                        <ItemStyle Width="18%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkNext_Inspection_Date" runat="server" Text='<%# Eval("EventType") %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Respiratory_Protection") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>                                                                                                                                    
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="14%" valign="top">
                                                            First Response And AED Equipment<br /> 
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvFirstResponseAEDEquipmentView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="AED Locations">
                                                                        <ItemStyle Width="18%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkAEDLocation" runat="server" Text='<%#Eval("AED_Location_Desc") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_FirstRepose_AEDEquipment") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                      <asp:TemplateField HeaderText="AED Manufacturer">
                                                                        <ItemStyle Width="18%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkAEDManufacturer" runat="server" Text='<%#  Eval("AEDManufacturer") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_FirstRepose_AEDEquipment") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="AED Install Date">
                                                                        <ItemStyle Width="18%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkAEDInstallDate" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay( Eval("AEDInstallDate")) %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_FirstRepose_AEDEquipment") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>                                                                 
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="14%" valign="top">
                                                            First Response And AED Associate Training
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvFirstResponseAEDAssociateTrainingView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Associate Name">
                                                                        <ItemStyle Width="18%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkAssociateName" runat="server" Text='<%#Eval("AssociateName") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_AssociateTrainingFirstRepose_AED") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                      <asp:TemplateField HeaderText="Associate Title">
                                                                        <ItemStyle Width="18%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkAssociateTitle" runat="server" Text='<%#  Eval("AssociateTitle") %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_AssociateTrainingFirstRepose_AED") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Associate Training Date">
                                                                        <ItemStyle Width="18%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkAssociateTrainingDate" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay( Eval("AssociateTrainingDate")) %>'
                                                                                CommandName="EditDetails" CommandArgument='<%# Eval("PK_PM_AssociateTrainingFirstRepose_AED") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>                                                                 
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>                                                                 
                                                </table>                                      
                                            </asp:Panel>
                                            <asp:Panel ID="pnl9View" runat="server" Style="display: none;">                                                 
                                                <div class="bandHeaderRow">
                                                    Remediations
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%" style="height: 230px;">
                                                    <tr>
                                                        <td align="left" width="14%" valign="top">
                                                            Remediation Grid
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvRemediationsView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Description">
                                                                        <ItemStyle Width="25%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkPhase_II" runat="server" Text='<%# Eval("Description") %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Remediation_Grid") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Assessor">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkAssessor" runat="server" Text='<%# Eval("Assessor") %>' CommandName="ViewDetails"
                                                                                CommandArgument='<%# Eval("PK_PM_Remediation_Grid") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Report Date">
                                                                        <ItemStyle Width="12%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkReport_Date" runat="server" Text='<%# string.Format("{0:MM-dd-yyyy}", Eval("Report_Date")) %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Remediation_Grid") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Next Report">
                                                                        <ItemStyle Width="12%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkNext_Report_Date" runat="server" Text='<%# string.Format("{0:MM-dd-yyyy}", Eval("Next_Report_Date")) %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Remediation_Grid") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Next Review">
                                                                        <ItemStyle Width="12%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkNext_Review_Date" runat="server" Text='<%# string.Format("{0:MM-dd-yyyy}", Eval("Next_Review_Date")) %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Remediation_Grid") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Cost $">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkCost" runat="server" Text='<%# string.Format("{0:N2}", Eval("Cost")) %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Remediation_Grid") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Notes
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblRemediationNotes" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl8View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Violations</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%" style="height: 230px;">
                                                    <tr>
                                                        <td align="left" width="10%" valign="top">
                                                            Violations Grid
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <asp:GridView ID="gvViolationsView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                EmptyDataText="No Record Exists" OnRowCommand="GridView_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Date">
                                                                        <ItemStyle Width="12%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkDate_Of_Violation" runat="server" Text='<%# string.Format("{0:MM-dd-yyyy}", Eval("Date_Of_Violation")) %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Violation") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Regulatory/Notifying Agency">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkNotifying_Agency" runat="server" Text='<%# Eval("Regulatory_Notifying_Agency") %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Violation") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Desc">
                                                                        <ItemStyle Width="18%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkDescription_Of_Violations" runat="server" Text='<%# Eval("Description_Of_Violations") %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Violation") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Contact">
                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkContact_Name" runat="server" Text='<%# Eval("Contact_Name") %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Violation") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Phone Number">
                                                                        <ItemStyle Width="12%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkContact_Telephone" runat="server" Text='<%# Eval("Contact_Telephone") %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Violation") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Fine $">
                                                                        <ItemStyle Width="18%" HorizontalAlign="Left" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkCost" runat="server" Text='<%# string.Format("{0:N2}", Eval("Cost")) %>'
                                                                                CommandName="ViewDetails" CommandArgument='<%# Eval("PK_PM_Violation") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Notes
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td colspan="4" align="left" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblViolationsNotes" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </div>
                                        <asp:Panel ID="pnlAttachmentDetails" runat="server" Style="display: none;">
                                            <table cellpadding="0" cellspacing="0" width="100%" style="height: 250px;">
                                                <tr>
                                                    <td width="100%" valign="top">
                                                        <uc:ctrlAttachmentDetails ID="AttachDetails" runat="Server" />
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
                            <table cellpadding="5" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td width="60%" align="right">
                                        <asp:Button ID="btnSave" runat="server" Text="Save & View" OnClick="btnSave_Click"
                                            CausesValidation="true" ValidationGroup="vsErrorGroup" OnClientClick="return ValSave();" />
                                        <asp:Button ID="btnEdit" runat="server" Text=" Edit " OnClick="btnEdit_Click" CausesValidation="false" />
                                        <asp:Button runat="server" ID="btnAuditTrail" Text="View Audit Trail" CausesValidation="false"
                                            Visible="true" OnClientClick="javascript:return OpenAuditPopUp();" />
                                    </td>
                                    <td align="left">
                                        &nbsp;
                                        <asp:Button ID="btnChangeBuilding" runat="server" Text="Change Building" OnClick="btnChangeBuilding_Click"
                                            Visible="false" />
                                    </td>
                                </tr>
                            </table>
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
