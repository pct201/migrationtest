<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="Waste_Disposal_Waste_Removal.aspx.cs" Inherits="SONIC_Pollution_Waste_Disposal_Waste_Removal" %>

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
    <script type="text/javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript">
        function returnConfirm() {
            return confirm('Are you sure you want to remove the selected data from eRIMS2?');
        }
        function SetMenuStyle(index) {
            var i;
            for (i = 1; i <= 2; i++) {
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
            SetMenuStyle(index);
            ActiveTabIndex = index;
            var op = '<%=StrOperation%>';
            if (op == "view") {
                ShowPanelView(index);
            }
            else {
                var i;
                if (index < 3) {
                    for (i = 1; i <= 2; i++) {
                        document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display = (i == index) ? "block" : "none";
                    }
                    if (index == 1)
                        document.getElementById('<%=drpFK_LU_Waste_Type.ClientID %>').focus();
                }
                else {
                    for (i = 1; i <= 2; i++) {
                        document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display = "none";
                    }
                }
            }
        }

        function ShowPanelView(index) {
            SetMenuStyle(index);
            document.getElementById('<%=dvView.ClientID%>').style.display = "block";
            var i;
            if (index < 3) {
                for (i = 1; i <= 2; i++) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i + "View").style.display = (i == index) ? "block" : "none";
                }
            }
            else {
                for (i = 1; i <= 2; i++) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i + "View").style.display = "none";
                }
            }
        }


        function ValSave() {
            //            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqAttachType').enabled = false;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqFile').enabled = false;
            //            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_cstFile').enabled = false;
            if (Page_ClientValidate('vsErrorGroup'))
                return true;
            else
                return false;
        }

        function ValAttach() {
            //            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqAttachType').enabled = true;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqFile').enabled = true;
            //            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_cstFile').enabled = true;
            if (Page_ClientValidate('vsErrorGroup'))
                return true;
            else
                return false;
        }

        function SetDischargeView() {

            var dropDown = document.getElementById('ctl00_ContentPlaceHolder1_drpFK_LU_Waste_Type');
            if (dropDown.options[dropDown.selectedIndex].text == 'Antifreeze') {
                document.getElementById("ctl00_ContentPlaceHolder1_pnlDischarge").style.display = "block";
            }
            else {
                document.getElementById("ctl00_ContentPlaceHolder1_pnlDischarge").style.display = "none";
            }
            return false;
        }

        function OpenAuditPopUp() {
            var winHeight = window.screen.availHeight - 400;
            var winWidth = window.screen.availWidth - 500;

            obj = window.open('AuditPopup_PM_Waste_Removal.aspx?id=<%=ViewState["PK_PM_Waste_Removal"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }
        function ValidateFields(sender, args) {
            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnControlIDs.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnErrorMsgs.ClientID%>').value.split(',');
            var focusCtrlID = "";
            var dropDown = document.getElementById('ctl00_ContentPlaceHolder1_drpFK_LU_Waste_Type');
            if (document.getElementById('<%=hdnControlIDs.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);

                    if (!((ctrlIDs[i] == '<%=txtDischarge_Limits.ClientID%>') || (ctrlIDs[i] == '<%=txtCalifornia_Business_Plan.ClientID%>'))) {
                        switch (ctrl.type) {
                            case "textarea":
                            case "text": if (ctrl.value == '') bEmpty = true; break;
                            case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                        }

                        //if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
                        if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                    }
                    else if (dropDown.options[dropDown.selectedIndex].text == 'Antifreeze') {
                        switch (ctrl.type) {
                            case "textarea":
                            case "text": if (ctrl.value == '') bEmpty = true; break;
                            case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                        }

                        //if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
                        if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                    }
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
    <asp:ValidationSummary ID="valSummary" runat="server" ValidationGroup="vsErrorGroup"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following fields:"
        BorderWidth="1" BorderColor="DimGray" CssClass="errormessage" />
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100%" style="height: 50px;" valign="bottom">
                <uc:CtlTab runat="server" ID="Tab"></uc:CtlTab>
            </td>
        </tr>
        <tr>
            <td class="Spacer" width="100%" style="height: 15px;">
            </td>
        </tr>
        <tr>
            <td width="100%">
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
                Waste Disposal – Hazardous Waste Generator
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
                                    <td align="left" width="100%" nowrap="nowrap">
                                        <span id="Menu1" onclick="javascript:ShowPanel(1);" class="LeftMenuStatic">Hazardous Waste Generator</span>&nbsp;<span
                                           id="MenuAsterisk1" runat="server" style="color: Red;display:none">*</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu2" onclick="javascript:ShowPanel(2);" class="LeftMenuStatic">Attachment</span>
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
                                            <asp:Panel ID="pnl1" runat="server" Style="display: inline;">
                                                <div class="bandHeaderRow">
                                                    Hazardous Waste Generator</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Waste Type&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:DropDownList ID="drpFK_LU_Waste_Type" Width="175px" runat="server" SkinID="dropGen">
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
                                                            Hazardous Waste Hauler&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:DropDownList ID="drpFK_PM_Waste_Hauler" Width="175px" runat="server" SkinID="dropGen">
                                                            </asp:DropDownList>                                                            
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Receiving TSDF&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="drpFK_Receiving_TSDF" Width="175px" runat="server" SkinID="dropGen">
                                                            </asp:DropDownList>                                                            
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Amount of Hazardous Waste Generated Per Month – in Pounds&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">                                                            
                                                            <asp:TextBox ID="txtAmount_HW_Generated_Per_Month" runat="server" Width="170px" onkeypress="return FormatNumber(event,this.id,15,false);"
                                                                onpaste="return false" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            EPA ID Number&nbsp;<span id="Span12" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtEpaIdNumber" runat="server" Width="170px" MaxLength="75" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Date&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtDate" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="revDate" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[Hazardous Waste Generator]/Date is not a valid date" SetFocusOnError="true"
                                                                ControlToValidate="txtDate" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
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
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Hazardous Waste Codes&nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="drpHWCodes" Width="175px" runat="server" SkinID="dropGen">
                                                            </asp:DropDownList>   
                                                        </td>
                                                        <td align="left" valign="top">
                                                           <%-- Removal Limits&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>--%>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left" valign="top">
                                                           <%-- <asp:TextBox ID="txtRemoval_Limits" runat="server" Width="170px" MaxLength="75" />--%>
                                                        </td>
                                                    </tr>
                                                      <tr>
                                                        <td align="left" valign="top">
                                                            Start Date of Hazardous Waste Accumulation&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtHWStartDate" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtHWStartDate', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[Hazardous Waste Generator]/Start Date of Hazardous Waste Accumulation is not a valid date" SetFocusOnError="true"
                                                                ControlToValidate="txtHWStartDate" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" valign="top">
                                                             Date of Last Hazardous Waste Removal&nbsp;<span id="Span11" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                           :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtHWlastDate" runat="server" Width="150px" SkinID="txtDate" />
                                                            <img alt="Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtHWlastDate', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="vsErrorGroup"
                                                                Display="none" ErrorMessage="[Hazardous Waste Generator]/Date of Last Hazardous Waste Removal is not a valid date" SetFocusOnError="true"
                                                                ControlToValidate="txtHWlastDate" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Hazardous Waste Profile Completed and Maintained at Location?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:RadioButtonList ID="rdoHW_Profile_Complete_And_Maintained" runat="server">
                                                                <asp:ListItem Text="Yes" Value="Y" Selected="False"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Facility Generator Status&nbsp;<span id="Span8" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="drpFK_LU_Facility_Generator_Status" Width="175px" runat="server"
                                                                SkinID="dropGen">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <asp:Panel ID="pnlDischarge" runat="server" Style="display: none;">
                                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                    <tr>
                                                                        <td align="left" valign="top" width="18%">
                                                                            Discharge Limits&nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                                                                        </td>
                                                                        <td align="center" valign="top" width="4%">
                                                                            :
                                                                        </td>
                                                                        <td align="left" valign="top" width="28%">
                                                                            <asp:TextBox ID="txtDischarge_Limits" runat="server" Width="170px" MaxLength="75" />
                                                                        </td>
                                                                        <td align="left" valign="top" width="18%">
                                                                            California Business Plan&nbsp;<span id="Span10" style="color: Red; display: none;" runat="server">*</span>
                                                                        </td>
                                                                        <td align="center" valign="top" width="4%">
                                                                            :
                                                                        </td>
                                                                        <td align="left" valign="top" width="28%">
                                                                            <asp:TextBox ID="txtCalifornia_Business_Plan" runat="server" Width="170px" MaxLength="75" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Does this Hazardous Waste Generator data apply to all buildings at this location?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:RadioButtonList ID="rdoApply_To_Location" runat="server" SkinID="YesNoType" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl2" runat="server" Style="display: inline;">
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
                                                        <td>
                                                            <div id="dvAttachment" runat="server" style="display: none;">
                                                                <uc:ctrlAttachmentDetails ID="AttachDetails" runat="Server" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Spacer" style="height: 20px;">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </div>
                                        <div id="dvView" runat="server" width="794px">
                                            <asp:Panel ID="pnl1View" runat="server" Style="display: inline;">
                                                <div class="bandHeaderRow">
                                                    Hazardous Waste Generator</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Waste Type
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblFK_LU_Waste_Type" runat="server"></asp:Label>
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
                                                            Hazardous Waste Hauler
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblFK_PM_Waste_Hauler" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Receiving TSDF
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_Receiving_TSDF" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Amount of Hazardous Waste Generated Per Month – in Pounds
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblAmount_HW_Generated_Per_Month" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            EPA ID Number
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblEpaIdNumber" runat="server" style="word-wrap:normal; word-break:break-all;"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Date
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblDate" runat="server"></asp:Label>
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
                                                    <tr>
                                                        <td align="left" valign="top">
                                                           Hazardous Waste Codes
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblHWCodes" runat="server"></asp:Label>
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
                                                     <tr>
                                                        <td align="left" valign="top">
                                                           Start Date of Hazardous Waste Accumulation
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblHWStartDate" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                           Date of Last Hazardous Waste Removal
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblHWLastDate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Hazardous Waste Profile Completed and Maintained at Location?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblHW_Profile_Complete_And_Maintained" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Facility Generator Status
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_LU_Facility_Generator_Status" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <div id="dvDischargeView" runat="server" style="display: none;">
                                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                    <tr>
                                                                        <td align="left" valign="top" width="18%">
                                                                            Discharge Limits
                                                                        </td>
                                                                        <td align="center" valign="top" width="4%">
                                                                            :
                                                                        </td>
                                                                        <td align="left" valign="top" width="28%">
                                                                            <asp:Label ID="lblDischarge_Limits" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td align="left" valign="top" width="18%">
                                                                            California Business Plan
                                                                        </td>
                                                                        <td align="center" valign="top" width="4%">
                                                                            :
                                                                        </td>
                                                                        <td align="left" valign="top" width="28%">
                                                                            <asp:Label ID="lblCalifornia_Business_Plan" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Does this Hazardous Waste Generator data apply to all buildings at this location?
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lblApply_To_Location" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl2View" runat="server" Style="display: inline;">
                                                <div id="Div1" runat="server" style="display: inline;">
                                                    <table cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td width="100%">
                                                                <uc:ctrlAttachmentDetails ID="AttachDetailsView" runat="Server" />
                                                            </td>
                                                        </tr>
                                                        <%--<tr>
													<td class="Spacer" style="height: 150px;"></td>
												</tr>--%>
                                                    </table>
                                                </div>
                                            </asp:Panel>
                                        </div>
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
                                        <td width="60%" align="right">
                                            <asp:Button ID="btnSave" runat="server" Text="Save & View" OnClick="btnSave_Click"
                                                CausesValidation="true" ValidationGroup="vsErrorGroup" OnClientClick="return ValSave();" />
                                            <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />
                                            <asp:Button runat="server" ID="btnAuditTrail" Text="View Audit Trail" CausesValidation="false"
                                                Visible="true" OnClientClick="javascript:return OpenAuditPopUp();" />
                                            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
                                        </td>
                                        <td align="left">
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
    </table>
    <asp:CustomValidator ID="CustomValidator" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
                    Display="None" ValidationGroup="vsErrorGroup" />
                <input id="hdnControlIDs" runat="server" type="hidden" />
                <input id="hdnErrorMsgs" runat="server" type="hidden" />
</asp:Content>
