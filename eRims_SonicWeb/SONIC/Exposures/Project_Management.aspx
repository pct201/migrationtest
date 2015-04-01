<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="Project_Management.aspx.cs" Inherits="SONIC_Exposures_Project_Management" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/ExposuresTab/ExposuresTab.ascx" TagName="CtlTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/NotesWithSpellCheck/Notes.ascx" TagName="ctrlMultiLineTextBox"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment-ProjectManagement/Attachment.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="../../JavaScript/JFunctions.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript">
        var CheckChangeVal = false;
        var ActiveTabIndex = 1;
        function onNextStep() {
            if (ActiveTabIndex == 6) {
                return ValSave();
            }
            else {
                ActiveTabIndex = ActiveTabIndex + 1;
                ShowPanel(ActiveTabIndex);
                return false;
            }
        }

        function onPreviousStep() {
            ActiveTabIndex = ActiveTabIndex - 1;
            document.getElementById("ctl00_ContentPlaceHolder1_hdnPanel").value = ActiveTabIndex;
            ShowPanel(ActiveTabIndex);
            return false;
        }

        function SetMenuStyle(index) {
            var i;
            for (i = 1; i <= 6; i++) {
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

            document.getElementById('<%= hdnPanel.ClientID %>').value = ActiveTabIndex;

                      
            var op = '<%= ViewState["strOperation"] %>';
            if (op == "view") {
                document.getElementById('<%= dvEdit.ClientID %>').style.display = "none";
                document.getElementById('<%= dvView.ClientID %>').style.display = "";
                ShowPanelView(index);
            }
            else {
                var i;
                for (i = 1; i <= 5; i++) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display = (i == index) ? "block" : "none";

                    TextChange();
                }
                document.getElementById('<%=pnlAttachment.ClientID%>').style.display = (index == 6) ? "block" : "none";
                if (index == 1) document.getElementById('<%=btnPrevoius.ClientID%>').style.display = "none";
                else document.getElementById('<%=btnPrevoius.ClientID%>').style.display = "";
                if (index == 6) document.getElementById('<%=btnNext.ClientID%>').style.display = "none";
                else document.getElementById('<%=btnNext.ClientID%>').style.display = "";
                if (index == 2) document.getElementById("ctl00_ContentPlaceHolder1_Div2").style.display = "block";
                else document.getElementById("ctl00_ContentPlaceHolder1_Div2").style.display = "none";
                if (index == 3) document.getElementById("ctl00_ContentPlaceHolder1_Div4").style.display = "block";
                else document.getElementById("ctl00_ContentPlaceHolder1_Div4").style.display = "none";
                if (index == 5) document.getElementById("ctl00_ContentPlaceHolder1_Div3").style.display = "block";
                else document.getElementById("ctl00_ContentPlaceHolder1_Div3").style.display = "none";

                if (index == 3 || index == 4 || index == 6) { document.getElementById('<%=btnSave.ClientID%>').style.display = "none"; document.getElementById('<%=btnAuditTrail.ClientID%>').style.display = "none"; }
                else { document.getElementById('<%=btnSave.ClientID%>').style.display = ""; document.getElementById('<%=btnAuditTrail.ClientID%>').style.display = ""; }
                if (op == "add") {
                    document.getElementById('<%=btnAuditTrail.ClientID%>').style.display = "none";
                }
            }
        }

        function ShowPanelView(index) {
            var i;
            if (index < 6) {
                for (i = 1; i <= 5; i++) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i + "view").style.display = (i == index) ? "block" : "none";
                    if (index == 2) document.getElementById("ctl00_ContentPlaceHolder1_Div2").style.display = "block";
                    else document.getElementById("ctl00_ContentPlaceHolder1_Div2").style.display = "none";
                    if (index == 5) document.getElementById("ctl00_ContentPlaceHolder1_Div3").style.display = "block";
                    else document.getElementById("ctl00_ContentPlaceHolder1_Div3").style.display = "none";
                    if (index == 3) document.getElementById("ctl00_ContentPlaceHolder1_Div4").style.display = "block";
                    else document.getElementById("ctl00_ContentPlaceHolder1_Div4").style.display = "none";
                }
            }
            else {
                for (i = 1; i <= 5; i++) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i + "view").style.display = "none";
                }
            }
            document.getElementById('<%=pnlAttachment.ClientID%>').style.display = (index == 6) ? "block" : "none";
            if (index == 1) document.getElementById('<%=btnPrevoius.ClientID%>').style.display = "none";
            if (index == 1) document.getElementById('<%=btnPrevoius.ClientID%>').style.display = "none";
            else document.getElementById('<%=btnPrevoius.ClientID%>').style.display = "";
            if (index == 6) document.getElementById('<%=btnNext.ClientID%>').style.display = "none";
            else document.getElementById('<%=btnNext.ClientID%>').style.display = "";
            if (index == 3 || index == 4 || index == 6) { document.getElementById('<%=btnAuditTrail.ClientID%>').style.display = "none"; }
            else { document.getElementById('<%=btnAuditTrail.ClientID%>').style.display = ""; }
        }

        function SetRequestingEntityOther() {
            var drpRequesting_Entity = document.getElementById('<%= drpRequesting_Entity.ClientID %>');
            var drpRequesting_Entity_Text = drpRequesting_Entity.options[drpRequesting_Entity.selectedIndex].innerHTML;
            if (drpRequesting_Entity_Text == "Other - Describe") {
                document.getElementById('<%= txtOther_Requesting_Entity_Desc.ClientID %>').disabled = false;
            }
            else {
                document.getElementById('<%= txtOther_Requesting_Entity_Desc.ClientID %>').disabled = true;
                document.getElementById('<%= txtOther_Requesting_Entity_Desc.ClientID %>').value = "";
            }
        }

        function SetTargetAreaOther() {
            document.getElementById('<%= txtOther_Target_Area_Desc.ClientID %>').disabled = true;
            var lstTargetArea = document.getElementById('<%= lstTargetArea.ClientID %>');
            var listLength = lstTargetArea.options.length;
            for (var i = 0; i < listLength; i++) {
                var lstTargetArea_Text = lstTargetArea.options[i].innerHTML;
                if (lstTargetArea.options[i].selected && lstTargetArea_Text == "Other – Describe") {
                    document.getElementById('<%= txtOther_Target_Area_Desc.ClientID %>').disabled = false;
                }
                else {
                    document.getElementById('<%= txtOther_Target_Area_Desc.ClientID %>').value = "";
                }
            }
        }

        function SetPurposeofProject() {
            document.getElementById('<%= txtPurpose_of_Project_Other_Description.ClientID %>').disabled = true;
            var lstPurpose_Of_Project = document.getElementById('<%= lstPurpose_Of_Project.ClientID %>');
            var listLength = lstPurpose_Of_Project.options.length;
            for (var i = 0; i < listLength; i++) {
                var lstPurpose_Of_Project_Text = lstPurpose_Of_Project.options[i].innerHTML;
                if (lstPurpose_Of_Project.options[i].selected && lstPurpose_Of_Project_Text == "Other") {
                    document.getElementById('<%= txtPurpose_of_Project_Other_Description.ClientID %>').disabled = false;
                }
                else {
                    document.getElementById('<%= txtPurpose_of_Project_Other_Description.ClientID %>').value = "";
                }
            }
        }

        function SetReqActivityDesc() {
            var drpRequired_Activity = document.getElementById('<%= drpRequired_Activity.ClientID %>');
            var drpRequired_Activity_Text = drpRequired_Activity.options[drpRequired_Activity.selectedIndex].innerHTML;
            if (drpRequired_Activity_Text == "Remediation - Describe") {
                document.getElementById('<%= txtRequired_Activity_Description.ClientID %>').disabled = false;
            }
            else {
                document.getElementById('<%= txtRequired_Activity_Description.ClientID %>').disabled = true;
                document.getElementById('<%= txtRequired_Activity_Description.ClientID %>').value = "";
            }
        }

        function TextChange() {
            var arrElements = document.getElementsByTagName('input');
            for (i = 0; i < arrElements.length; i++) {
                if (arrElements[i].type == 'text' && arrElements[i].id.indexOf('txtPageNumber') <= -1)
                    arrElements[i].onchange = OnChangeFunction;
                if (arrElements[i].type == 'textarea')
                    arrElements[i].onchange = OnChangeFunction;
                if (arrElements[i].type == 'radio')
                    arrElements[i].onchange = OnChangeFunction;
            }

            var arrElements_Select = document.getElementsByTagName('select');
            for (i = 0; i < arrElements_Select.length; i++) {
                if (arrElements_Select[i].type == 'select-one') {
                    if (arrElements_Select[i].id.indexOf('<%= drpRequesting_Entity.ClientID%>') > -1 && arrElements_Select[i].id.indexOf('drpRecords') <= -1)
                        arrElements_Select[i].onchange = OnchangeRequestingEntityOther;
                    else if (arrElements_Select[i].id.indexOf('<%= drpRequired_Activity.ClientID%>') > -1 && arrElements_Select[i].id.indexOf('drpRecords') <= -1)
                        arrElements_Select[i].onchange = onChangeSetReqActivityDesc;
                    else
                        if (arrElements_Select[i].id.indexOf('drpRecords') <= -1)
                            arrElements_Select[i].onchange = OnChangeFunction;
                }

                if (arrElements_Select[i].type == 'select - multiple') {
                    if (arrElements_Select[i].id.indexOf('<%= lstTargetArea.ClientID%>') > -1 && arrElements_Select[i].id.indexOf('drpRecords') <= -1)
                        arrElements_Select[i].onchange = OnChangeTargetAreaOther;
                    else if (arrElements_Select[i].id.indexOf('<%= lstPurpose_Of_Project.ClientID%>') > -1 && arrElements_Select[i].id.indexOf('drpRecords') <= -1)
                        arrElements_Select[i].onchange = OnChangePurposeofProject;
                    else
                        arrElements_Select[i].onchange = OnChangeFunction;
                }
            }
        }

        function OnchangeRequestingEntityOther() {
            SetRequestingEntityOther();
            OnChangeFunction();
        }

        function OnChangeTargetAreaOther() {
            SetTargetAreaOther();
            OnChangeFunction();
        }

        function OnChangePurposeofProject() {
            SetPurposeofProject();
            OnChangeFunction();
        }

        function onChangeSetReqActivityDesc() {
            SetReqActivityDesc();
            OnChangeFunction();
        }

        function OnChangeFunction() {
            if (CheckChangeVal == false)
                CheckChangeVal = true;
        }

        function CheckValueChange(Panelid, IndexVal) {
            if (CheckChangeVal == true) {
                if (confirm('Do you want to save your changes before leaving this screen?')) {
                    CheckChangeVal = false;
                    if (SetValidationGroup() == true) {
                        __doPostBack("<%=btnSave.ClientID %>", Panelid.toString());
                        return false;
                    }
                }
                else {
                    CheckChangeVal = false;
                    if (Panelid != null)
                        ShowPanel(Panelid);
                    if (IndexVal != null)
                        ShowPrevNext(IndexVal);
                }
            }
            else {
                if (Panelid != null)
                    ShowPanel(Panelid);
                if (IndexVal != null)
                    ShowPrevNext(IndexVal);
            }
        }

        //For Consultant Notes Validation
        function CheckSelectedSonicNotes(buttonType) {
            var ctrls = document.getElementsByTagName('input');
            var i, chkID;
            var cnt = 0;
            chkID = "chkSelectSonicNotes";
            for (i = 0; i < ctrls.length; i++) {
                if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf(chkID) > 0) {
                    if (ctrls[i].checked)
                        cnt++;
                }
            }

            if (cnt == 0) {
                if (buttonType == "View")
                    alert("Please select Note(s) to View");
                else
                    alert("Please select Note(s) to Print");

                return false;
            }
            else {
                return true;
            }
        }

        function ShowEnvironmentalRequestMailPage(PK_EPM_Identification, Location_ID) {
            ShowDialog("Popup_Environmental_Reuest_Form.aspx?id=" + PK_EPM_Identification + "&loc=" + Location_ID, 600, 450);
            return false;
        }
    </script>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="false"
            ShowMessageBox="true" HeaderText="Verify the following fields:" BorderWidth="1"
            BorderColor="DimGray" ValidationGroup="vsErrorIdentification" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowSummary="false"
            ShowMessageBox="true" HeaderText="Verify the following fields:" BorderWidth="1"
            BorderColor="DimGray" ValidationGroup="vsErrorConsultant" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="ValidationSummary4" runat="server" ShowSummary="false"
            ShowMessageBox="true" HeaderText="Verify the following fields:" BorderWidth="1"
            BorderColor="DimGray" ValidationGroup="vsErrorAction_Notes" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100%" style="height: 50px;" valign="bottom" colspan="2">
                <uc:CtlTab runat="server" ID="Tab"></uc:CtlTab>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="Spacer" style="height: 15px;" colspan="2"></td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" colspan="2">
                            <table style="background-color: black" cellspacing="1" cellpadding="3" width="100%"
                                border="0">
                                <tbody>
                                    <tr class="PropertyInfoBG">
                                        <td id="tdProjectNum" runat="server" style="width: 14%; display: none;" align="left">
                                            <asp:Label ID="lblProjectNumber" runat="server" Text="Project Number"></asp:Label>
                                        </td>
                                        <td id="tdProjectType" runat="server" style="width: 12%; display: none;" align="left">
                                            <asp:Label ID="Label1" runat="server" Text="Project Type"></asp:Label>
                                        </td>
                                        <td style="width: 13%" align="left">
                                            <asp:Label ID="lblHeaderLocationNumber" runat="server" Text="Location Number"></asp:Label>
                                        </td>
                                        <td style="width: 18%" align="left">
                                            <asp:Label ID="lblHeaderLocationdba" runat="server" Text="SONIC Location d/b/a"></asp:Label>
                                        </td>
                                        <td id="Td1" style="width: 18%" align="left" runat="server">
                                            <asp:Label ID="lblHeaderAddress" runat="server" Text="Address"></asp:Label>
                                        </td>
                                        <td style="width: 10%" align="left">
                                            <asp:Label ID="lblHeaderCity" runat="server" Text="City"></asp:Label>
                                        </td>
                                        <td style="width: 10%" align="left">
                                            <asp:Label ID="lblHeaderState" runat="server" Text="State"></asp:Label>
                                        </td>
                                        <td style="width: 5%" align="left">
                                            <asp:Label ID="lblHeaderZip" runat="server" Text="Zip"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="background-color: white">
                                        <td id="tdHeaderPro_Num" runat="server" align="left" style="display: none;">
                                            <asp:Label ID="lblHeaderProject_Number" runat="server">&nbsp;</asp:Label>
                                        </td>
                                        <td id="tdHeaderProType" runat="server" align="left" style="display: none;">
                                            <asp:Label ID="lblHeaderProject_Type" runat="server">&nbsp;</asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblLocation_Number" runat="server">&nbsp;</asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblLocationdba" runat="server"></asp:Label>
                                        </td>
                                        <td align="left" runat="Server">
                                            <asp:Label ID="lblAddress" runat="server"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblCity" runat="server"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblState" runat="server" />
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblZip" runat="server" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" style="height: 5px;" colspan="2"></td>
                    </tr>
                    <tr>
                        <td class="leftMenu">
                            <table cellpadding="5" cellspacing="0" width="100%">
                                <tr>
                                    <td style="height: 18px;" class="Spacer"></td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu1" onclick="javascript:CheckValueChange(1,null);" class="LeftMenuStatic">Identification&nbsp;<span id="MenuAsterisk1" runat="server" style="color: Red; display: none">*</span></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu2" onclick="javascript:CheckValueChange(2,null);" class="LeftMenuStatic">Consultant and Schedule&nbsp;<span id="MenuAsterisk2" runat="server" style="color: Red; display: none">*</span></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu3" onclick="javascript:CheckValueChange(3,null);" class="LeftMenuStatic">Project Cost&nbsp;<span id="MenuAsterisk3" runat="server" style="color: Red; display: none">*</span></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu4" onclick="javascript:CheckValueChange(4,null);" class="LeftMenuStatic">Project Milestone &nbsp;<span id="MenuAsterisk4" runat="server" style="color: Red; display: none">*</span></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu5" onclick="javascript:CheckValueChange(5,null);" class="LeftMenuStatic">Action and Notes&nbsp;<span id="MenuAsterisk5" runat="server" style="color: Red; display: none">*</span></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu6" onclick="javascript:CheckValueChange(6,null);" class="LeftMenuStatic">Attachments</span>
                                    </td>
                                </tr>                            
                            </table>
                        </td>
                        <td valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td width="5px" class="Spacer">&nbsp;
                                    </td>
                                    <td class="dvContainer">
                                        <div id="dvEdit" runat="server" width="794px">
                                            <asp:Panel ID="pnl1" runat="server" Style="display: none;" Width="794px">
                                                <div class="bandHeaderRow">
                                                    Identification
                                                </div>
                                                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <b>Project Number</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Companion to Project&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:DropDownList ID="drpCompanion_to_Project" runat="server" Width="150px">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Project Number&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:TextBox ID="txtProject_Number" runat="server" SkinID="txtDisabled" Width="300px" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Building(s)&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:CheckBoxList ID="chkBuilding" runat="server" RepeatDirection="Vertical" RepeatLayout="Flow"
                                                                RepeatColumns="1" OnSelectedIndexChanged="chkBuilding_OnSelectedIndexChanged"
                                                                AutoPostBack="true">
                                                            </asp:CheckBoxList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Equipment&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:ListBox ID="lstEquipment" runat="server" Width="200px" SelectionMode="Multiple" />
                                                        </td>
                                                        <td width="100%" colspan="3">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="20%">
                                                                        <b>Site Contact at Property</b>
                                                                    </td>
                                                                    <td align="center" valign="top" width="4%"></td>
                                                                    <td align="left" valign="top" width="26%"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" width="20%">Name<span id="spnName" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top" width="4%">:</td>
                                                                    <td align="left" valign="top" width="26%">
                                                                        <asp:TextBox ID="txtName" runat="server" MaxLength="75">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" width="20%">Telephone (XXX-XXX-XXXX)<span id="spnTelephone" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top" width="4%">:</td>
                                                                    <td align="left" valign="top" width="26%">
                                                                        <asp:TextBox ID="txtTelephone" runat="server" MaxLength="12"
                                                                            onKeyPress="javascript:return FormatPhone(event,this.id);"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="txtTelephone"
                                                                            SetFocusOnError="true" runat="server" ValidationGroup="vsErrorIdentification" ErrorMessage="[Site Contact at Property]/Please Enter Telephone Number in xxx-xxx-xxxx format."
                                                                            Display="none" Enabled="true" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" width="20%">Email<span id="spnEmail" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top" width="4%">:</td>
                                                                    <td align="left" valign="top" width="26%">
                                                                        <asp:TextBox ID="txtEmail" runat="server" MaxLength="220">
                                                                        </asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtEmail"
                                                                            ValidationGroup="vsErrorIdentification" Display="None" ErrorMessage="[Site Contact at Property]/E-Mail Is Invalid"
                                                                            SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Project Type&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:DropDownList ID="drpProject_Type" runat="server" SkinID="ddlExposure" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Project Description&nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="txtProject_Description" runat="server" ControlType="TextBox" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Requesting Entity&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:DropDownList ID="drpRequesting_Entity" runat="server" SkinID="ddlExposure" onchange="OnchangeRequestingEntityOther();" />
                                                        </td>
                                                        <td align="left" valign="top" width="20%">Other Requesting Entity Description
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:TextBox ID="txtOther_Requesting_Entity_Desc" Enabled="false" runat="server"
                                                                MaxLength="50" Width="170px" />
                                                            <asp:CustomValidator ID="csmvtxtContributingFactor_Other" runat="server" ErrorMessage="Please enter [Identification]/Other Requesting Entity Description"
                                                                ControlToValidate="txtOther_Requesting_Entity_Desc" Display="None" SetFocusOnError="true"
                                                                ClientValidationFunction="CheckOtherRequestingEntity" ValidationGroup="vsErrorIdentification"
                                                                ValidateEmptyText="true" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Person Requesting Work&nbsp;<span id="Span45" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtPerson_Requesting_Work" runat="server" Width="170px" MaxLength="100" />
                                                        </td>
                                                        <td align="left" valign="top" width="20%">Title of Person Requesting Work&nbsp;<span id="Span46" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtTitle_of_Person_RequestingWork" runat="server" Width="170px"
                                                                MaxLength="50" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Target Area&nbsp;<span id="Span8" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:ListBox ID="lstTargetArea" runat="server" SelectionMode="Multiple" Height="250px"
                                                                Width="210px" onchange="OnChangeTargetAreaOther();" />
                                                        </td>
                                                        <td align="left" valign="top" width="20%">Other Target Area Description
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:TextBox ID="txtOther_Target_Area_Desc" Enabled="false" runat="server" MaxLength="50"
                                                                Width="170px" />
                                                            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Please enter [Identification]/Other Target Area Description"
                                                                ControlToValidate="txtOther_Target_Area_Desc" Display="None" SetFocusOnError="true"
                                                                ClientValidationFunction="CheckOtherTargetArea" ValidationGroup="vsErrorIdentification"
                                                                ValidateEmptyText="true" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Purpose of Project&nbsp;<span id="Span43" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:ListBox ID="lstPurpose_Of_Project" runat="server" SelectionMode="Multiple" Height="110px"
                                                                Width="210px" onchange="OnChangePurposeofProject();" />
                                                        </td>
                                                        <td align="left" valign="top" width="20%">Purpose of Project Other Description
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:TextBox ID="txtPurpose_of_Project_Other_Description" Enabled="false" runat="server"
                                                                MaxLength="50" Width="170px" />
                                                            <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="Please enter [Identification]/Purpose of Project Other Description"
                                                                ControlToValidate="txtPurpose_of_Project_Other_Description" Display="None" SetFocusOnError="true"
                                                                ClientValidationFunction="CheckOtherPurposeofProject" ValidationGroup="vsErrorIdentification"
                                                                ValidateEmptyText="true" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Existing Documents&nbsp;<span id="Span44" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%" colspan="4">
                                                            <asp:ListBox ID="lstExistingDocuments" runat="server" SelectionMode="Multiple" Height="100px"
                                                                Width="210px" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl2" runat="server" Style="display: none;" Width="794px">
                                                <div class="bandHeaderRow">
                                                    Consultant
                                                </div>
                                                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Hart & Hickman&nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:RadioButton ID="rdoHartNHickMan" GroupName="grpHartnHickman" runat="server"
                                                                AutoPostBack="true" OnCheckedChanged="rdoHartNHickMan_OnCheckedChanged" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Other Consultant&nbsp;<span id="Span10" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:RadioButton ID="rdoOther" GroupName="grpHartnHickman" runat="server" AutoPostBack="true"
                                                                OnCheckedChanged="rdoOther_OnCheckedChanged" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Consultant Company&nbsp;<span id="Span11" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:TextBox ID="txtConsultant_Company" runat="server" Width="170px" MaxLength="100" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Consultant Address 1&nbsp;<span id="Span12" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:TextBox ID="txtConsultant_Address1" runat="server" Width="170px" MaxLength="50" />
                                                        </td>
                                                        <td align="left" valign="top" width="20%">Consultant Address 2&nbsp;<span id="Span13" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:TextBox ID="txtConsultant_Address2" runat="server" Width="170px" MaxLength="50" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Consultant City&nbsp;<span id="Span14" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:TextBox ID="txtConsultant_City" runat="server" Width="170px" MaxLength="30" />
                                                        </td>
                                                        <td align="left" valign="top" width="20%">Consultant State&nbsp;<span id="Span15" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:DropDownList ID="drpConsultant_State" runat="server" SkinID="ddlExposure" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Consultant Zip Code&nbsp;<span id="Span16" style="color: Red; display: none;" runat="server">*</span>
                                                            <br />
                                                            (XXXXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:TextBox runat="server" ID="txtConsultant_Zip_Code" Width="170px" MaxLength="10"
                                                                onKeyPress="javascript:return FormatZipCode(event,this.id);"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="revZipCode" runat="server" ErrorMessage="[Consultant and Schedule]/Consultant Zip Code is not valid"
                                                                ValidationGroup="vsErrorConsultant" SetFocusOnError="true" ControlToValidate="txtConsultant_Zip_Code"
                                                                ValidationExpression="\b[0-9]{5}-[0-9]{4}\b|\b[0-9]{5}\b" Display="none" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Consultant Contact Name&nbsp;<span id="Span17" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:TextBox ID="txtConsultant_Contact_Name" runat="server" Width="170px" MaxLength="100" />
                                                        </td>
                                                        <td align="left" valign="top" width="20%">Consultant Contact Telephone Number&nbsp;<span id="Span18" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                            <br />
                                                            (XXX-XXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:TextBox ID="txtConsultant_Contact_Telephone" runat="server" Width="170px" MaxLength="12"
                                                                onKeyPress="javascript:return FormatPhone(event,this.id);"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="regTelephone" ControlToValidate="txtConsultant_Contact_Telephone"
                                                                SetFocusOnError="true" runat="server" ValidationGroup="vsErrorConsultant" ErrorMessage="[Consultant and Schedule]/Please Enter Consultant Contact Telephone Number in xxx-xxx-xxxx format."
                                                                Display="none" Enabled="true" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Consultant Contact E-Mail&nbsp;<span id="Span19" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:TextBox ID="txtConsultant_Contact_EMail" runat="server" Width="170px" MaxLength="255" />
                                                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtConsultant_Contact_EMail"
                                                                ValidationGroup="vsErrorConsultant" Display="None" ErrorMessage="[Consultant and Schedule]/Consultant Contact E-Mail Is Invalid"
                                                                SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="btnEmail_From" Text="E-Mail Form" runat="server" OnClick="btnEmail_From_OnClick"
                                                                CausesValidation="true" ValidationGroup="vsErrorConsultant" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div class="bandHeaderRow">
                                                    Schedule
                                                </div>
                                                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Date to Consultant&nbsp;<span id="Span20" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:TextBox ID="txtDate_to_Consultant" runat="server" MaxLength="10" SkinID="txtdate"
                                                                Width="150px"></asp:TextBox>
                                                            <img alt="Date to Consultant" onclick="return showCalendar('<%=txtDate_to_Consultant.ClientID %>', 'mm/dd/y',OnChangeFunction);"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <cc1:MaskedEditExtender ID="mskDate_to_Consultant" runat="server" AcceptNegative="Left"
                                                                DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDate_to_Consultant"
                                                                CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                            </cc1:MaskedEditExtender>
                                                            <br />
                                                            <asp:RegularExpressionValidator ID="revDate_to_Consultant" runat="server" ValidationGroup="vsErrorConsultant"
                                                                Display="none" ErrorMessage="[Consultant and Schedule]/Date to Consultant is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtDate_to_Consultant" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">RM Notification Date&nbsp;<span id="Span21" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:TextBox ID="txtRM_Notification_Date" runat="server" MaxLength="10" SkinID="txtdate"
                                                                Width="150px"></asp:TextBox>
                                                            <img alt="RM Notification Date" onclick="return showCalendar('<%=txtRM_Notification_Date.ClientID %>', 'mm/dd/y',OnChangeFunction);"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AcceptNegative="Left"
                                                                DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtRM_Notification_Date"
                                                                CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                            </cc1:MaskedEditExtender>
                                                            <br />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="vsErrorConsultant"
                                                                Display="none" ErrorMessage="[Consultant and Schedule]/RM Notification Date is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtRM_Notification_Date" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <b>Start Date</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Estimated Project Start Date&nbsp;<span id="Span22" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:TextBox ID="txtEstimated_Project_StartDate" runat="server" MaxLength="10" SkinID="txtdate"
                                                                Width="150px"></asp:TextBox>
                                                            <img alt="Estimated Project Start Date" onclick="return showCalendar('<%=txtEstimated_Project_StartDate.ClientID %>', 'mm/dd/y',OnChangeFunction);"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" AcceptNegative="Left"
                                                                DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtEstimated_Project_StartDate"
                                                                CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                            </cc1:MaskedEditExtender>
                                                            <br />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="vsErrorConsultant"
                                                                Display="none" ErrorMessage="[Consultant and Schedule]/Estimated Project Start Date is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtEstimated_Project_StartDate" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" valign="top" width="20%">Actual Project Start Date&nbsp;<span id="Span23" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:TextBox ID="txtActual_Project_StartDate" runat="server" MaxLength="10" SkinID="txtdate"
                                                                Width="150px"></asp:TextBox>
                                                            <img alt="Actual Project Start Date" onclick="return showCalendar('<%=txtActual_Project_StartDate.ClientID %>', 'mm/dd/y',OnChangeFunction);"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" AcceptNegative="Left"
                                                                DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtActual_Project_StartDate"
                                                                CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                            </cc1:MaskedEditExtender>
                                                            <br />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationGroup="vsErrorConsultant"
                                                                Display="none" ErrorMessage="[Consultant and Schedule]/Actual Project Start Date is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtActual_Project_StartDate" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <%--<tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <b>End Date</b>
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Project Due Date&nbsp;<span id="Span24" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:TextBox ID="txtEstimated_Project_CompletionDate" runat="server" MaxLength="10"
                                                                SkinID="txtdate" Width="150px"></asp:TextBox>
                                                            <img alt="Project Due Date" onclick="return showCalendar('<%=txtEstimated_Project_CompletionDate.ClientID %>', 'mm/dd/y',OnChangeFunction);"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" AcceptNegative="Left"
                                                                DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtEstimated_Project_CompletionDate"
                                                                CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                            </cc1:MaskedEditExtender>
                                                            <br />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ValidationGroup="vsErrorConsultant"
                                                                Display="none" ErrorMessage="[Consultant and Schedule]/Project Due Date is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtEstimated_Project_CompletionDate"
                                                                ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            <asp:CompareValidator ErrorMessage="[Consultant and Schedule]/Project Due Date Should be greater than Estimated Project start Date"
                                                                ControlToValidate="txtEstimated_Project_CompletionDate" ControlToCompare="txtEstimated_Project_StartDate"
                                                                Type="Date" runat="server" SetFocusOnError="true" Display="None" ValidationGroup="vsErrorConsultant"
                                                                Operator="GreaterThanEqual" />
                                                        </td>
                                                        <td align="left" valign="top" width="20%">Actual Project Completion Date&nbsp;<span id="Span25" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:TextBox ID="txtActual_Project_CompletionDate" runat="server" MaxLength="10"
                                                                SkinID="txtdate" Width="150px"></asp:TextBox>
                                                            <img alt="Actual Project Completion Date" onclick="return showCalendar('<%=txtActual_Project_CompletionDate.ClientID %>', 'mm/dd/y',OnChangeFunction);"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />
                                                            <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" AcceptNegative="Left"
                                                                DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtActual_Project_CompletionDate"
                                                                CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                            </cc1:MaskedEditExtender>
                                                            <br />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ValidationGroup="vsErrorConsultant"
                                                                Display="none" ErrorMessage="[Consultant and Schedule]/Actual Project Completion Date is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtActual_Project_CompletionDate" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                            <asp:CompareValidator ID="CompareValidator1" ErrorMessage="[Consultant and Schedule]/Actual Project Completion Date Should be greater than Actual Project start Date"
                                                                ControlToValidate="txtActual_Project_CompletionDate" ControlToCompare="txtActual_Project_StartDate"
                                                                Type="Date" runat="server" SetFocusOnError="true" Display="None" ValidationGroup="vsErrorConsultant"
                                                                Operator="GreaterThanEqual" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <asp:LinkButton ID="lnkViewSchedule" Text="--View Schedule--" runat="server" OnClick="lnkViewSchedule_OnClick" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl3" runat="server" Style="display: none;" Width="794px">
                                                <div class="bandHeaderRow">
                                                    Project Cost
                                                </div>
                                                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                    <tr runat="server">
                                                        <td align="left" valign="top" width="15%">Project Cost Grid<br />
                                                            <asp:LinkButton ID="lnkAddProjectCost" runat="server" OnClick="lnkAddProjectCost_Click"
                                                                CausesValidation="false">--Add--</asp:LinkButton>
                                                        </td>
                                                        <td align="center" valign="top" width="2%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:GridView ID="gvProjectCost" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                OnRowCommand="gvProjectCost_RowCommand" OnRowDataBound="gvProjectCost_OnRowDataBound"
                                                                ShowFooter="true">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Project Number">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkProject_Number" runat="server" CommandName="EditProjectCost"
                                                                                CommandArgument='<%# Eval("PK_EPM_Project_Cost") +";" + Eval("FK_EPM_Identification") %>'
                                                                                Text='<%# Eval("Project_Number") %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Project Type">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkProject_Type" runat="server" CommandName="EditProjectCost"
                                                                                CommandArgument='<%# Eval("PK_EPM_Project_Cost") +";" + Eval("FK_EPM_Identification") %>'
                                                                                Text='<%# Eval("Project_Type")%>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Project Phase">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkProject_Phase" runat="server" CommandName="EditProjectCost"
                                                                                CommandArgument='<%# Eval("PK_EPM_Project_Cost") +";" + Eval("FK_EPM_Identification") %>'
                                                                                Text='<%# Eval("Project_Phase") %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lblTotal" Text="Total" runat="server" Font-Bold="true" />
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Budget($)">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbudget" runat="server" CommandName="EditProjectCost" CommandArgument='<%# Eval("PK_EPM_Project_Cost") +";" + Eval("FK_EPM_Identification") %>'
                                                                                Text='<%# string.Format("{0:C2}",Eval("Budget")) %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lblBudgetSum" runat="server" />
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Estimated Cost($)">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkEstimated_Cost" runat="server" CommandName="EditProjectCost"
                                                                                CommandArgument='<%# Eval("PK_EPM_Project_Cost") + ";" + Eval("FK_EPM_Identification") %>'
                                                                                Text='<%# string.Format("{0:C2}",Eval("Estimated_Cost")) %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lblEstimatedCostSum" runat="server" />
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Actual Cost($)">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkActualCost" runat="server" CommandName="EditProjectCost" CommandArgument='<%# Eval("PK_EPM_Project_Cost") +";" + Eval("FK_EPM_Identification") %>'
                                                                                Text='<%# string.Format("{0:C2}",Eval("Actual_Cost")) %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lblActualCostSum" runat="server" />
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="10%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" CommandName="RemoveProjectCost" CommandArgument='<%# Eval("PK_EPM_Project_Cost") %>'
                                                                                Text="Remove" OnClientClick="return confirm('Are you sure to delete?');"></asp:LinkButton>
                                                                            <asp:HiddenField ID="hdnFK_EPM_Identification" runat="server" Value='<%# Eval("FK_EPM_Identification") %>' />
                                                                        </ItemTemplate>
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
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server">
                                                        <td align="left" valign="top">Include Companion Project(s) in Project Cost Grid
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td colspan="4">
                                                            <asp:CheckBox ID="chkIncludeCompProject" runat="server" AutoPostBack="true" OnCheckedChanged="chkIncludeCompProject_OnCheckedChanged" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl4" runat="server" Style="display: none;" Width="794px">
                                                <div class="bandHeaderRow">
                                                    Projects Milestones
                                                </div>
                                                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                    <tr runat="server">
                                                        <td align="left" valign="top" width="20%">Milestone Grid<br />
                                                            <asp:LinkButton ID="lnkProject_Milestone" runat="server" OnClick="lnkProject_Milestone_Click"
                                                                CausesValidation="false">--Add--</asp:LinkButton>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:GridView ID="gvProjectMilestone" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                OnRowCommand="gvProjectMilestone_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Milestone">
                                                                        <ItemStyle Width="20%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkProject_Milestone" runat="server" CommandName="EditProjectMilestone"
                                                                                CommandArgument='<%# Eval("PK_EPM_Milestone") %>' Text='<%# Eval("EPM_Milestone") %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Other Description">
                                                                        <ItemStyle Width="20%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkProject_Desc" runat="server" CommandName="EditProjectMilestone"
                                                                                CssClass="TextClip" Width="150px" CommandArgument='<%# Eval("PK_EPM_Milestone") %>'
                                                                                Text='<%# Eval("Description")%>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Date">
                                                                        <ItemStyle Width="20%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkProject_MilestoneDate" runat="server" CommandName="EditProjectMilestone"
                                                                                CommandArgument='<%# Eval("PK_EPM_Milestone") %>' Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Milestone_Date")) %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Reminder E-Mail">
                                                                        <ItemStyle Width="20%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkProject_Reminder_Mail" runat="server" CommandName="EditProjectMilestone"
                                                                                CommandArgument='<%# Eval("PK_EPM_Milestone") %>' Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Email_Reminder")) %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="10%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" CommandName="RemoveProjectMilestone"
                                                                                CommandArgument='<%# Eval("PK_EPM_Milestone") %>' Text="Remove" OnClientClick="return confirm('Are you sure to delete?');"></asp:LinkButton>
                                                                        </ItemTemplate>
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
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl5" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Action and Notes
                                                </div>
                                                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Required Activity&nbsp;<span id="Span26" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:DropDownList ID="drpRequired_Activity" runat="server" SkinID="ddlExposure" onchange="onChangeSetReqActivityDesc();" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Required Activity Description&nbsp;<span id="Span27" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="txtRequired_Activity_Description" runat="server" ControlType="TextBox" />
                                                            <asp:CustomValidator ID="cvRequired_Activity_Description" runat="server" ErrorMessage="Please enter [Action And Notes]/Required Activity Description"
                                                                Display="None" SetFocusOnError="true" ClientValidationFunction="CheckRequiredActivityDescription"
                                                                ValidationGroup="vsErrorAction_Notes" ValidateEmptyText="true" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Date Required Activity Initially Entered&nbsp;<span id="Span28" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:TextBox ID="txtDate_Required_Activity_InitiallyEntered" runat="server" MaxLength="10"
                                                                SkinID="txtDisabled" Width="170px"></asp:TextBox>
                                                        </td>
                                                        <td align="left" valign="top" width="20%">Date Required Activity Last Edited&nbsp;<span id="Span29" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:TextBox ID="txtDateRequired_Activity_LastEdited" runat="server" MaxLength="10"
                                                                SkinID="txtDisabled" Width="170px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Action&nbsp;<span id="Span30" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="txtAction" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Date Action Initially Entered&nbsp;<span id="Span31" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:TextBox ID="txtDate_Action_InitiallyEntered" runat="server" MaxLength="10" SkinID="txtDisabled"
                                                                Width="170px"></asp:TextBox>
                                                        </td>
                                                        <td align="left" valign="top" width="20%">Date Action Last Edited&nbsp;<span id="Span32" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:TextBox ID="txtDate_Action_LastEdited" runat="server" MaxLength="10" SkinID="txtDisabled"
                                                                Width="170px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Status&nbsp;<span id="Span33" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="txtStatus" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Date Status Initially Entered&nbsp;<span id="Span34" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:TextBox ID="txtDate_Status_InitiallyEntered" runat="server" MaxLength="10" SkinID="txtDisabled"
                                                                Width="170px"></asp:TextBox>
                                                        </td>
                                                        <td align="left" valign="top" width="20%">Date Status Last Edited&nbsp;<span id="Span35" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:TextBox ID="txtDate_Status_LastEdited" runat="server" MaxLength="10" SkinID="txtDisabled"
                                                                Width="170px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Issues&nbsp;<span id="Span36" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="txtIssues" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Date Issues Initially Entered&nbsp;<span id="Span37" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:TextBox ID="txtDate_Issues_InitiallyEntered" runat="server" MaxLength="10" SkinID="txtDisabled"
                                                                Width="170px"></asp:TextBox>
                                                        </td>
                                                        <td align="left" valign="top" width="20%">Date Issues Last Edited&nbsp;<span id="Span38" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:TextBox ID="txtDate_Issues_LastEdited" runat="server" MaxLength="10" SkinID="txtDisabled"
                                                                Width="170px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Outcome&nbsp;<span id="Span39" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:DropDownList ID="drpOutcome" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Comments&nbsp;<span id="Span40" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="txtComments" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Date Comments Initially Entered&nbsp;<span id="Span41" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:TextBox ID="txtDate_Comments_InitiallyEntered" runat="server" MaxLength="10"
                                                                SkinID="txtDisabled" Width="170px"></asp:TextBox>
                                                        </td>
                                                        <td align="left" valign="top" width="20%">Date Comments Last Edited&nbsp;<span id="Span42" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:TextBox ID="txtDate_Comments_LastEdited" runat="server" MaxLength="10" SkinID="txtDisabled"
                                                                Width="170px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </div>
                                        <div id="dvView" runat="server" width="794px">
                                            <asp:Panel ID="pnl1view" runat="server" Style="display: none;" Width="794px">
                                                <div class="bandHeaderRow">
                                                    Identification
                                                </div>
                                                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <b>Project Number </b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Companion to Project
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lblCompanion_to_Project" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Project Number
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lblProject_Number" runat="server" SkinID="lblDisabled" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Building(s)
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:CheckBoxList ID="chkBuildingView" runat="server" RepeatDirection="Vertical"
                                                                RepeatLayout="Flow" Enabled="false" RepeatColumns="1">
                                                            </asp:CheckBoxList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Equipment
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:ListBox ID="lstEquipmentView" runat="server" Width="200px" SelectionMode="Multiple" />
                                                        </td>
                                                        <td width="100%" colspan="3">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" valign="top" width="20%">
                                                                        <b>Site Contact at Property</b>
                                                                    </td>
                                                                    <td align="center" valign="top" width="4%"></td>
                                                                    <td align="left" valign="top" width="26%"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" width="20%">Name
                                                                    </td>
                                                                    <td align="center" valign="top" width="4%">:</td>
                                                                    <td align="left" valign="top" width="26%">
                                                                        <asp:Label ID="lblName" runat="server" Style="word-wrap: normal; word-break: break-all">
                                                                        </asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" width="20%">Telephone (XXX-XXX-XXXX)
                                                                    </td>
                                                                    <td align="center" valign="top" width="4%">:</td>
                                                                    <td align="left" valign="top" width="26%">
                                                                        <asp:Label ID="lblTelephone" runat="server">
                                                                        </asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" width="20%">Email
                                                                    </td>
                                                                    <td align="center" valign="top" width="4%">:</td>
                                                                    <td align="left" valign="top" width="26%">
                                                                        <asp:Label ID="lblEmail" runat="server" Style="word-wrap: normal; word-break: break-all">
                                                                        </asp:Label></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Project Type
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lblProject_Type" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Project Description
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="lblProject_Description" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Requesting Entity
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:Label ID="lblRequesting_Entity" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top" width="20%">Other Requesting Entity Description
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:Label ID="lblOther_Requesting_Entity_Desc" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Person Requesting Work
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblPerson_Requesting_Work" runat="server" Width="200px" CssClass="TextClip" />
                                                        </td>
                                                        <td align="left" valign="top" width="20%">Title of Person Requesting Work
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTitle_of_Person_RequestingWork" runat="server" Width="200px" CssClass="TextClip" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Target Area
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:ListBox ID="lstTargetAreaView" runat="server" Height="250px" Width="210px" SelectionMode="Multiple" />
                                                        </td>
                                                        <td align="left" valign="top" width="20%">Other Target Area Description
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:Label ID="lblOther_Target_Area_Desc" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Purpose of Project
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:ListBox ID="lstPurpose_Of_ProjectView" runat="server" Height="110px" Width="210px"
                                                                SelectionMode="Multiple" />
                                                        </td>
                                                        <td align="left" valign="top" width="20%">Purpose of Project Other Description
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:Label ID="lblPurpose_of_Project_Other_Description" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Existing Documents
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%" colspan="4">
                                                            <asp:ListBox ID="lstExistingDocumentsView" runat="server" SelectionMode="Multiple"
                                                                Height="100px" Width="210px" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl2view" runat="server" Style="display: none;" Width="794px">
                                                <div class="bandHeaderRow">
                                                    Consultant
                                                </div>
                                                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Hart & Hickman
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lblHart_N_Hickman" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Other Consultant
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lblOther_Consultant" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Consultant Company
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lblConsultant_Company" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Consultant Address 1
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:Label ID="lblConsultant_Address1" runat="server" CssClass="TextClip" Width="200px" />
                                                        </td>
                                                        <td align="left" valign="top" width="20%">Consultant Address 2
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:Label ID="lblConsultant_Address2" runat="server" CssClass="TextClip" Width="200px" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Consultant City
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:Label ID="lblConsultant_City" runat="server" />
                                                        </td>
                                                        <td align="left" valign="top" width="20%">Consultant State
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:Label ID="lblConsultant_State" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Consultant Zip Code
                                                            <br />
                                                            (XXXXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lblConsultant_Zip_Code" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Consultant Contact Name
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:Label ID="lblConsultant_Contact_Name" runat="server" CssClass="TextClip" Width="200px" />
                                                        </td>
                                                        <td align="left" valign="top" width="20%">Consultant Contact Telephone Number
                                                            <br />
                                                            (XXX-XXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:Label ID="lblConsultant_Contact_Telephone" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Consultant Contact E-Mail
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lblConsultant_Contact_EMail" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div class="bandHeaderRow">
                                                    Schedule
                                                </div>
                                                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Date to Consultant
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lblDate_to_Consultant" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">RM Notification Date
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lblRM_Notification_Date" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <b>Start Date</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Estimated Project Start Date
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:Label ID="lblEstimated_Project_StartDate" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top" width="20%">Actual Project Start Date
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:Label ID="lblActual_Project_StartDate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <%-- <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <b>End Date</b>
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Project Due Date
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:Label ID="lblEstimated_Project_CompletionDate" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top" width="20%">Actual Project Completion Date
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:Label ID="lblActual_Project_CompletionDate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" colspan="6">
                                                            <asp:LinkButton ID="lnkViewScheduleView" Text="--View Schedule--" runat="server"
                                                                OnClick="lnkViewSchedule_OnClick" />
                                                        </td>
                                                    </tr>
                                                </table>


                                            </asp:Panel>
                                            <asp:Panel ID="pnl3view" runat="server" Style="display: none;" Width="794px">
                                                <div class="bandHeaderRow">
                                                    Project Cost
                                                </div>
                                                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td align="left" valign="top" width="15%">Project Cost Grid<br />
                                                        </td>
                                                        <td align="center" valign="top" width="2%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:GridView ID="gvProjectCostView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                OnRowCommand="gvProjectCost_RowCommand" OnRowDataBound="gvProjectCost_OnRowDataBound"
                                                                ShowFooter="true">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Project Number">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkProject_Number" runat="server" CommandName="EditProjectCost"
                                                                                CommandArgument='<%# Eval("PK_EPM_Project_Cost") +";" + Eval("FK_EPM_Identification") %>'
                                                                                Text='<%# Eval("Project_Number") %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Project Type">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkProject_Type" runat="server" CommandName="EditProjectCost"
                                                                                CommandArgument='<%# Eval("PK_EPM_Project_Cost") +";" + Eval("FK_EPM_Identification") %>'
                                                                                Text='<%# Eval("Project_Type")%>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Project Phase">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkProject_Phase" runat="server" CommandName="EditProjectCost"
                                                                                CommandArgument='<%# Eval("PK_EPM_Project_Cost") +";" + Eval("FK_EPM_Identification") %>'
                                                                                Text='<%# Eval("Project_Phase") %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lblTotal" Text="Total" runat="server" Font-Bold="true" />
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Budget($)">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbudget" runat="server" CommandName="EditProjectCost" CommandArgument='<%# Eval("PK_EPM_Project_Cost") +";" + Eval("FK_EPM_Identification") %>'
                                                                                Text='<%# string.Format("{0:C2}",Eval("Budget")) %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lblBudgetSum" runat="server" />
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Estimated Cost($)">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkEstimated_Cost" runat="server" CommandName="EditProjectCost"
                                                                                CommandArgument='<%# Eval("PK_EPM_Project_Cost") +";" + Eval("FK_EPM_Identification") %>'
                                                                                Text='<%# string.Format("{0:C2}",Eval("Estimated_Cost")) %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lblEstimatedCostSum" runat="server" />
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Actual Cost($)">
                                                                        <ItemStyle Width="15%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkActualCost" runat="server" CommandName="EditProjectCost" CommandArgument='<%# Eval("PK_EPM_Project_Cost") +";" + Eval("FK_EPM_Identification") %>'
                                                                                Text='<%# string.Format("{0:C2}",Eval("Actual_Cost")) %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lblActualCostSum" runat="server" />
                                                                        </FooterTemplate>
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
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Include Companion Project(s) in Project Cost Grid
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td colspan="4">
                                                            <asp:CheckBox ID="chkIncludeCompProjectView" runat="server" AutoPostBack="true" OnCheckedChanged="chkIncludeCompProject_OnCheckedChanged" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl4view" runat="server" Style="display: none;" Width="794px">
                                                <div class="bandHeaderRow">
                                                    Projects Milestones
                                                </div>
                                                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Milestone Grid<br />
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:GridView ID="gvProjectMilestoneView" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                OnRowCommand="gvProjectMilestone_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Milestone">
                                                                        <ItemStyle Width="25%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkProject_Milestoneview" runat="server" CommandName="EditProjectMilestone"
                                                                                CommandArgument='<%# Eval("PK_EPM_Milestone") %>' Text='<%# Eval("EPM_Milestone") %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Other Description">
                                                                        <ItemStyle Width="25%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkProject_Descview" runat="server" CommandName="EditProjectMilestone"
                                                                                CssClass="TextClip" Width="150px" CommandArgument='<%# Eval("PK_EPM_Milestone") %>'
                                                                                Text='<%# Eval("Description")%>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Date">
                                                                        <ItemStyle Width="25%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkProject_MilestoneDateview" runat="server" CommandName="EditProjectMilestone"
                                                                                CommandArgument='<%# Eval("PK_EPM_Milestone") %>' Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Milestone_Date")) %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Reminder E-Mail">
                                                                        <ItemStyle Width="25%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkProject_Reminder_Mailview" runat="server" CommandName="EditProjectMilestone"
                                                                                CommandArgument='<%# Eval("PK_EPM_Milestone") %>' Text='<%# clsGeneral.FormatYesNoToDisplayForView(Eval("Email_Reminder")) %>'></asp:LinkButton>
                                                                        </ItemTemplate>
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
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl5view" runat="server" Style="display: none;" Width="794px">
                                                <div class="bandHeaderRow">
                                                    Action and Notes
                                                </div>
                                                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Required Activity
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lblRequired_Activity" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Required Activity Description
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="lblRequired_Activity_Description" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Date Required Activity Initially Entered
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:Label ID="lblDate_Required_Activity_InitiallyEntered" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top" width="20%">Date Required Activity Last Edited
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:Label ID="lblDateRequired_Activity_LastEdited" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Action
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="lblAction" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Date Action Initially Entered
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:Label ID="lblDate_Action_InitiallyEntered" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top" width="20%">Date Action Last Edited
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:Label ID="lblDate_Action_LastEdited" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Status
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="lblStatus" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Date Status Initially Entered
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:Label ID="lblDate_Status_InitiallyEntered" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top" width="20%">Date Status Last Edited
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:Label ID="lblDate_Status_LastEdited" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Issues
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="lblIssues" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Date Issues Initially Entered
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:Label ID="lblDate_Issues_InitiallyEntered" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top" width="20%">Date Issues Last Edited
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:Label ID="lblDate_Issues_LastEdited" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Outcome
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lblOutcome" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Comments
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="lblComments" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Date Comments Initially Entered
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:Label ID="lblDate_Comments_InitiallyEntered" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top" width="20%">Date Comments Last Edited
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:Label ID="lblDate_Comments_LastEdited" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </div>
                                        <div id="Div2" runat="server" style="display: none;">
                                            <div class="bandHeaderRow">
                                                Notes
                                            </div>
                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                <tr>
                                                    <td colspan="3">
                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                            <tr>
                                                                <td width="45%"></td>
                                                                <td valign="top" align="right">
                                                                    <uc:ctrlPaging ID="ctrlPageSonicNotes" runat="server" OnGetPage="ctrlPageSonicNotes_GetPage" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                <tr>
                                                    <td valign="top" style="width: 20%">Consultant Notes Grid<br />
                                                        <asp:LinkButton ID="btnNotesAdd" runat="server" ValidationGroup="vsError" Text="--Add--"
                                                            OnClick="btnNotesAdd_Click"></asp:LinkButton>
                                                    </td>
                                                    <td align="center" valign="top" style="width: 3%">:
                                                    </td>
                                                    <td style="margin-left: 40px" style="width: 650px" align="left">
                                                        <asp:GridView ID="gvNotes" runat="server" AutoGenerateColumns="false" Width="100%"
                                                            OnRowCommand="gvNotes_RowCommand">
                                                            <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                            <EmptyDataTemplate>
                                                                <asp:Label ID="lblEmptyEmergencyMessage" runat="server" Text="No Record Found"></asp:Label>
                                                            </EmptyDataTemplate>
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-Width="12%">
                                                                    <HeaderTemplate>
                                                                        <input type="checkbox" id="chkMultiSelectSonicNotes" onclick="SelectDeselectAllSonicNotes(this.checked);" />Select
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkSelectSonicNotes" runat="server" onclick="SelectDeselectNoteHeader();" />
                                                                        <input type="hidden" id="hdnPK" runat="server" value='<%#Eval("PK_EPM_Consultant_Notes") %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                    HeaderText="Note Date">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lbtNote_Date" runat="server" Text='<%# string.Format("{0:MM/dd/yyyy}", Eval("Note_Date")) %>'
                                                                            CommandName="EditRecord" CommandArgument='<%#Eval("PK_EPM_Consultant_Notes") %>' Width="80px"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                HeaderText="User">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lbtUser_Name" runat="server" Text='<%# Eval("User_Name") %>'
                                                                        CommandName="EditRecord" CommandArgument='<%#Eval("PK_EPM_Consultant_Notes") %>' Width="100px"></asp:LinkButton>
                                                                </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                    HeaderText="Notes">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lbtNotes" runat="server" Text='<%# Eval("Note") %>' CommandName="EditRecord"
                                                                            CommandArgument='<%#Eval("PK_EPM_Consultant_Notes") %>' Width="310px" CssClass="TextClip"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                    HeaderText="Remove">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lbtDelete" runat="server" Text="Remove" CommandName="Remove"
                                                                            CommandArgument='<%#Eval("PK_EPM_Consultant_Notes") %>' OnClientClick="javascript:return confirm('Are you sure you want delete selected record?');"
                                                                            Width="80px"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3" align="center">
                                                        <asp:Button ID="btnView" runat="server" Text=" View " OnClick="btnView_Click" OnClientClick="return CheckSelectedSonicNotes('View');" />&nbsp;&nbsp;
                                                            <asp:Button ID="btnPrint" runat="server" Text=" Print " OnClick="btnPrint_Click"
                                                                OnClientClick="return CheckSelectedSonicNotes('Print');" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="Div3" runat="server" style="display: none;">
                                            <div class="bandHeaderRow">
                                                Notes
                                            </div>
                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                <tr>
                                                    <td colspan="3">
                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                            <tr>
                                                                <td width="45%"></td>
                                                                <td valign="top" align="right">
                                                                    <uc:ctrlPaging ID="ctrlActionNotes" runat="server" OnGetPage="ctrlPageActionNotes_GetPage" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                <tr>
                                                    <td valign="top" style="width: 20%">Risk Management Notes Grid<br />
                                                        <asp:LinkButton ID="lnkActionNotes" runat="server" ValidationGroup="vsError" Text="--Add--"
                                                            OnClick="lnkActionNotes_Click"></asp:LinkButton>
                                                    </td>
                                                    <td align="center" valign="top" style="width: 3%">:
                                                    </td>
                                                    <td style="margin-left: 40px" style="width: 650px" align="left">
                                                        <asp:GridView ID="gvActionNotes" runat="server" AutoGenerateColumns="false" Width="100%"
                                                            OnRowCommand="gvActionNotes_RowCommand">
                                                            <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                            <EmptyDataTemplate>
                                                                <asp:Label ID="lblEmptyEmergencyMessage" runat="server" Text="No Record Found"></asp:Label>
                                                            </EmptyDataTemplate>
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-Width="12%">
                                                                    <HeaderTemplate>
                                                                        <input type="checkbox" id="chkMultiSelectSonicNotes" onclick="SelectDeselectAllSonicNotes(this.checked);" />Select
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkSelectSonicNotes" runat="server" onclick="SelectDeselectNoteHeader();" />
                                                                        <input type="hidden" id="hdnPK" runat="server" value='<%#Eval("PK_EPM_Action_Notes_RM") %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                    HeaderText="Note Date">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lbtNote_Date" runat="server" Text='<%# string.Format("{0:MM/dd/yyyy}", Eval("Note_Date")) %>'
                                                                            CommandName="EditRecord" CommandArgument='<%#Eval("PK_EPM_Action_Notes_RM") %>' Width="80px"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                    HeaderText="User">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lbtUser_Name" runat="server" Text='<%# Eval("User_Name") %>'
                                                                            CommandName="EditRecord" CommandArgument='<%#Eval("PK_EPM_Action_Notes_RM") %>' Width="100px"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                    HeaderText="Notes">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lbtNotes" runat="server" Text='<%# Eval("Note") %>' CommandName="EditRecord"
                                                                            CommandArgument='<%#Eval("PK_EPM_Action_Notes_RM") %>' Width="310px" CssClass="TextClip"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                    HeaderText="Remove">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lbtDelete" runat="server" Text="Remove" CommandName="Remove"
                                                                            CommandArgument='<%#Eval("PK_EPM_Action_Notes_RM") %>' OnClientClick="javascript:return confirm('Are you sure you want delete selected record?');"
                                                                            Width="80px"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3" align="center">
                                                        <asp:Button ID="btnActionNotesView" runat="server" Text=" View " OnClick="btnActionNotesView_Click" OnClientClick="return CheckSelectedSonicNotes('View');" />&nbsp;&nbsp;
                                                            <asp:Button ID="btnActionNotesPrint" runat="server" Text=" Print " OnClick="btnActionNotesPrint_Click"
                                                                OnClientClick="return CheckSelectedSonicNotes('Print');" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="Div4" runat="server" style="display: none;">
                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                <tr>
                                                    <td valign="top" style="width: auto">Invoice Grid<br />
                                                        <asp:LinkButton ID="lnkAddInvoice" runat="server" ValidationGroup="vsError" Text="--Add--"
                                                            OnClick="lnkAddInvoice_Click"></asp:LinkButton>
                                                    </td>
                                                    <td align="center" valign="top" style="width: 3%">&nbsp;:
                                                    </td>
                                                    <td style="margin-left: 40px" style="width: 650px" align="left">
                                                        <asp:GridView ID="gvInvoice" runat="server" AutoGenerateColumns="false" Width="100%"
                                                            OnRowCommand="gvInvoice_RowCommand">
                                                            <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                            <EmptyDataTemplate>
                                                                <asp:Label ID="lblEmptyEmergencyMessage" runat="server" Text="No Record Found"></asp:Label>
                                                            </EmptyDataTemplate>
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                    HeaderText="Invoice Number">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lblInvoiceNumber" runat="server" Text='<%# Eval("Invoice_Number") %>'
                                                                            CommandName="EditRecord" CommandArgument='<%#Eval("PK_EPM_Project_Cost_Invoice") %>' Width="80px"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                    HeaderText="Invoice Date">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lblInvoice_Date" runat="server" Text='<%# string.Format("{0:MM/dd/yyyy}", Eval("Invoice_Date")) %>'
                                                                            CommandName="EditRecord" CommandArgument='<%#Eval("PK_EPM_Project_Cost_Invoice") %>' Width="100px"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                    HeaderText="Invoice Amount($)">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lblInvoice_Amount" runat="server" Text='<%# string.Format("{0:C2}",Eval("Invoice_Amount")) %>' CommandName="EditRecord"
                                                                            CommandArgument='<%#Eval("PK_EPM_Project_Cost_Invoice") %>' Width="120px" Style="word-wrap: normal; word-break: break-all"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                    HeaderText="Vendor">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lblVendor" runat="server" Text='<%# Eval("Vendor") %>' CommandName="EditRecord"
                                                                            CommandArgument='<%#Eval("PK_EPM_Project_Cost_Invoice") %>' Width="100px" CssClass="TextClip"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                    HeaderText="Remove">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lbtDelete" runat="server" Text="Remove" CommandName="Remove"
                                                                            CommandArgument='<%#Eval("PK_EPM_Project_Cost_Invoice") %>' OnClientClick="javascript:return confirm('Are you sure you want delete selected record?');"
                                                                            Width="80px"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <asp:Panel ID="pnlAttachment" runat="server" Style="display: none;" Width="794px">
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td align="left" valign="top" width="100%" style="height: 200px;">
                                                        <uc:ctrlAttachment ID="ctrlAttachment" runat="server" PanelNumber="6" />
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
                        <td colspan="2" align="center">
                            <table border="0" cellpadding="5" cellspacing="1" width="100%">
                                <tr>
                                    <td>
                                        <asp:Button ID="btnPrevoius" Text="Previous" runat="server" OnClientClick="return onPreviousStep();" />&nbsp;&nbsp;
                                        <asp:Button ID="btnSave" Text="Save" runat="server" OnClick="btnSave_OnClick" CausesValidation="true"
                                            OnClientClick="javascript:return SetValidationGroup();" />&nbsp;&nbsp;
                                        <asp:Button ID="btnEdit" Text="Edit" runat="server" OnClick="btnEdit_OnClick" Visible="false"
                                            CausesValidation="false" />&nbsp;&nbsp;
                                        <asp:Button ID="btnReturnto_View_Mode" Text="Return to View Mode" runat="server"
                                            OnClick="btnReturnto_View_Mode_OnClick" Visible="false" CausesValidation="false"
                                            Width="150px" />&nbsp;&nbsp;
                                        <asp:Button ID="btnNext" Text="Next" runat="server" OnClientClick="return onNextStep();" />&nbsp;&nbsp;
                                        <asp:Button ID="btnAuditTrail" Text="View Audit Trail" runat="server" OnClientClick="return SetAuditTrailByPanel();"
                                            CausesValidation="false" Style="display: none;" />&nbsp;&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hdnPanel" runat="server" Value="1" />
    <asp:HiddenField ID="hdnchkBuilding" runat="server" Value="1" />
    <asp:CustomValidator ID="CustomValidatorIdentification" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFields" Display="None" ValidationGroup="vsErrorIdentification" />
    <input id="hdnControlIDsIdentification" runat="server" type="hidden" />
    <input id="hdnErrorMsgsIdentification" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidatorConsultant" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFields" Display="None" ValidationGroup="vsErrorConsultant" />
    <input id="hdnCtrlsIDsConsultant" runat="server" type="hidden" />
    <input id="hdnMessagesConsultant" runat="server" type="hidden" />
    <asp:CustomValidator ID="CustomValidatorAction_Notes" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFields" Display="None" ValidationGroup="vsErrorAction_Notes" />
    <input id="hdnCtrlsIDsAction_Notes" runat="server" type="hidden" />
    <input id="hdnMessagesAction_Notes" runat="server" type="hidden" />
    <script type="text/javascript">

        function ValidateFields(sender, args) {
            var validatorID = sender.id;
            var msg = "", ctrlIDs = "", Messages = "", hdnID = "";

            if (validatorID.indexOf('Identification') > 0) {
                ctrlIDs = document.getElementById('<%=hdnControlIDsIdentification.ClientID%>').value.split(','); hdnID = '<%=hdnControlIDsIdentification.ClientID%>'; Messages = document.getElementById('<%=hdnErrorMsgsIdentification.ClientID%>').value.split(',');
            }
            else if (validatorID.indexOf('Consultant') > 0) {
                ctrlIDs = document.getElementById('<%=hdnCtrlsIDsConsultant.ClientID%>').value.split(','); hdnID = '<%=hdnCtrlsIDsConsultant.ClientID%>'; Messages = document.getElementById('<%=hdnMessagesConsultant.ClientID%>').value.split(',');
            }
            else if (validatorID.indexOf('Action_Notes') > 0) {
                ctrlIDs = document.getElementById('<%=hdnCtrlsIDsAction_Notes.ClientID%>').value.split(','); hdnID = '<%=hdnCtrlsIDsAction_Notes.ClientID%>'; Messages = document.getElementById('<%=hdnMessagesAction_Notes.ClientID%>').value.split(',');
            }

    var focusCtrlID = "";
    args.IsValid = false;

    if (hdnID != "") {
        if (document.getElementById(hdnID).value != "") {
            var i = 0;
            for (i = 0; i < ctrlIDs.length; i++) {
                var bEmpty = false;
                var ctrl = document.getElementById(ctrlIDs[i]);
                if (ctrlIDs[i] == '<%= chkBuilding.ClientID %>') {
                    var chkListBuilding = document.getElementById('<%= chkBuilding.ClientID %>');

                    if (chkListBuilding != null) {
                        var chkListinputs = chkListBuilding.getElementsByTagName("input");
                        for (var j = 0; j < chkListinputs.length; j++) {
                            if (chkListinputs[j].checked) {
                                args.IsValid = true;
                            }
                        }
                    }
                    else {
                        args.IsValid = false;
                    }

                    if (args.IsValid != true) {

                        if (chkListBuilding != null) {
                            focusCtrlID = 'ctl00_ContentPlaceHolder1_chkBuilding';
                            msg = 'Please select [Identification]/Building(s)' + "\n";
                        }
                        else {
                            ctrl = document.getElementById('ctl00_ContentPlaceHolder1_txtProject_Number');
                            focusCtrlID = 'ctl00_ContentPlaceHolder1_txtProject_Number';
                            msg = "There is no Building(s) associated with Environmental" + "\n";
                        }
                    }
                }
                switch (ctrl.type) {
                    case "textarea":
                    case "text": if (ctrl.value == '') bEmpty = true; break;
                    case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                    case "select-multiple": if (ctrl.selectedIndex == -1) bEmpty = true; break;
                }
                if (ctrlIDs[i] != '<%= chkBuilding.ClientID %>') {
                    if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
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
        else
            args.IsValid = true;
    }
}

function SetValidationGroup() {
    var Index = document.getElementById('<%= hdnPanel.ClientID%>').value;
    var ValidationGroups;

    if (Index == 1) {
        ValidationGroups = "vsErrorIdentification";
    }
    else if (Index == 2) {
        ValidationGroups = "vsErrorConsultant";
    }
    else if (Index == 5) {
        ValidationGroups = "vsErrorAction_Notes";
    }

    if (ValidationGroups != "") {
        if (Page_ClientValidate(ValidationGroups)) {
            return true;
        }
        else {
            Page_ClientValidate('dummy');
            return false;
        }
    }
    return true;
}

function CheckOtherRequestingEntity(source, args) {
    var drpRequesting_Entity = document.getElementById('<%= drpRequesting_Entity.ClientID %>');
    var drpdrpRequesting_Entity_Text = drpRequesting_Entity.options[drpRequesting_Entity.selectedIndex].innerHTML;
    if (drpdrpRequesting_Entity_Text == "Other - Describe" && document.getElementById('<%= txtOther_Requesting_Entity_Desc.ClientID %>').value.length == 0) {
        args.IsValid = false;
        return;
    }
}

function CheckOtherTargetArea(source, args) {
    var lstTargetArea = document.getElementById('<%= lstTargetArea.ClientID %>');
    var listLength = lstTargetArea.options.length;
    for (var i = 0; i < listLength; i++) {
        var lstTargetArea_Text = lstTargetArea.options[i].innerHTML;
        if (lstTargetArea.options[i].selected && lstTargetArea_Text == "Other – Describe" && document.getElementById('<%= txtOther_Target_Area_Desc.ClientID %>').value.length == 0) {
            args.IsValid = false;
            return;
        }
    }
}

function CheckOtherPurposeofProject(source, args) {
    var lstPurpose_Of_Project = document.getElementById('<%= lstPurpose_Of_Project.ClientID %>');
    var listLength = lstPurpose_Of_Project.options.length;
    for (var i = 0; i < listLength; i++) {
        var lstPurpose_Of_Project_Text = lstPurpose_Of_Project.options[i].innerHTML;
        if (lstPurpose_Of_Project.options[i].selected && lstPurpose_Of_Project_Text == "Other" && document.getElementById('<%= txtPurpose_of_Project_Other_Description.ClientID %>').value.length == 0) {
                    args.IsValid = false;
                    return;
                }
            }
        }

        function CheckRequiredActivityDescription(source, args) {
            var drpRequired_Activity = document.getElementById('<%= drpRequired_Activity.ClientID %>');
            var drpRequired_Activity_Text = drpRequired_Activity.options[drpRequired_Activity.selectedIndex].innerHTML;
            if (drpRequired_Activity_Text == "Remediation - Describe" && document.getElementById('<%= txtRequired_Activity_Description.ClientID %>').value.length == 0) {
                args.IsValid = false;
                return;
            }
        }

        function SetAuditTrailByPanel() {
            var Index = document.getElementById('<%= hdnPanel.ClientID%>').value;
            var winHeight = window.screen.availHeight - 400;
            var winWidth = window.screen.availWidth - 300;

            if (Index == "1") {
                obj = window.open("AuditPopup_Project_Management.aspx?id=" + '<%=ViewState["PK_EPM_Identification"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            }
            if (Index == "2") {
                obj = window.open("AuditPopup_EPM-Consultant.aspx?id=" + '<%=ViewState["PK_EPM_Identification"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            }
            if (Index == "5") {
                obj = window.open("AuditPopup_EPM-ActionAndNotes.aspx?id=" + '<%=ViewState["PK_EPM_Action_Notes"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            }

            obj.focus();
            return false;

        }
    </script>
</asp:Content>
