<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="ConstructionProjectsView.aspx.cs" Inherits="SONIC_Exposures_ConstructionProjectsView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/ExposuresTab/ExposuresTab.ascx" TagName="CtlTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/NotesWithSpellCheck/Notes.ascx" TagName="ctrlMultiLineTextBox"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment_Construction/Attachment.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery.min.js"></script>
    <script type="text/javascript" src="../../JavaScript/JFunctions.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>

    <script type="text/javascript">
        function ToggleScreen(panelId) {
            $('#<%= hdnPanel.ClientID %>').val(panelId);
            PanelDisplay();
        }

        $(document).ready(function () {
            PanelDisplay();
        });

        function PanelDisplay() {
            var panel = $('#<%= hdnPanel.ClientID %>').val();
            if (panel == "2") {
                $('#divIdentificationView').hide();
                $('#divIdentificationEdit').show();
                $('#divAttachment').hide();
                $('#<%= btnEdit.ClientID %>').hide();
                $('#spnAttachment').removeClass("LeftMenuSelected");
                $('#spnAttachment').addClass("LeftMenuStatic");
                $('#spnIdentification').removeClass("LeftMenuStatic");
                $('#spnIdentification').addClass("LeftMenuSelected");
            }
            else if (panel == "3") {
                $('#divIdentificationView').hide();
                $('#divIdentificationEdit').hide();
                $('#divAttachment').show();
                $('#<%= btnEdit.ClientID %>').hide();
                $('#spnIdentification').removeClass("LeftMenuSelected");
                $('#spnIdentification').addClass("LeftMenuStatic");
                $('#spnAttachment').removeClass("LeftMenuStatic");
                $('#spnAttachment').addClass("LeftMenuSelected");
            }
            else {
                if ($('#<%= hdnPanelSpaire.ClientID %>').val() == "0") {
                    $('#divIdentificationView').show();
                    $('#divIdentificationEdit').hide();
                    $('#<%= btnEdit.ClientID %>').show();
                }
                else {
                    $('#divIdentificationView').hide();
                    $('#divIdentificationEdit').show();
                    $('#<%= btnEdit.ClientID %>').hide();
                }

                $('#divAttachment').hide();
                $('#spnAttachment').removeClass("LeftMenuSelected");
                $('#spnAttachment').addClass("LeftMenuStatic");
                $('#spnIdentification').removeClass("LeftMenuStatic");
                $('#spnIdentification').addClass("LeftMenuSelected");
            }
    }
    </script>
    <div>
        <asp:ValidationSummary ID="vsConstrctionProject" runat="server" ShowSummary="false"
            ShowMessageBox="true" HeaderText="Verify the following fields:" BorderWidth="1"
            BorderColor="DimGray" ValidationGroup="vsErrorIdentification" CssClass="errormessage"></asp:ValidationSummary>
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
                                        <td id="Td2" align="left" runat="Server">
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
                                        <span id="spnIdentification" onclick="ToggleScreen(1);" class="LeftMenuSelected">Identification&nbsp;<span id="MenuAsterisk1" runat="server" style="color: Red; display: none">*</span></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="spnAttachment" onclick="ToggleScreen(3);" class="LeftMenuStatic">Attachments</span>
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
                                        <div style="width: 794px">
                                            <div id="divIdentificationView" style="display: none;">
                                                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Project Number
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lbProjectNumber" runat="server" SkinID="lblDisabled" style="word-break:break-all; word-wrap:normal;" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Project Type
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lbProjectType" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Estimated Start Date
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lbEstimatedStartDate" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Estimated End Date
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:Label ID="lbEstimatedEndDate" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Building(s)
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:CheckBoxList ID="cblBuildingListView" runat="server" RepeatDirection="Vertical"
                                                                RepeatLayout="Flow" Enabled="false" RepeatColumns="1">
                                                            </asp:CheckBoxList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Project Description
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="lbProject_Description" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div id="divIdentificationEdit" style="display: none;">
                                                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Project Number&nbsp;<span id="spnProjectNumber" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:TextBox ID="txtProjectNumber" runat="server" Width="170px" MaxLength="100" />
                                                        </td>
                                                        <td align="left" valign="top" width="20%">Estimated Start Date&nbsp;<span id="spnEstimatedStartDate" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:TextBox ID="txtEstimatedStartDate" runat="server" SkinID="txtdate"
                                                                Width="150px"></asp:TextBox>
                                                            <img alt="Date to Consultant" onclick="return showCalendar('<%=txtEstimatedStartDate.ClientID %>', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />                                                            
                                                            <asp:RegularExpressionValidator ID="revEstimatedStartDate" runat="server" ValidationGroup="vsErrorIdentification"
                                                                Display="none" ErrorMessage="[Consultant and Schedule]/Estimated Start Date is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtEstimatedStartDate" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Project Type&nbsp;<span id="spnProjectType" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:DropDownList ID="ddProjectType" runat="server" Width="170px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left" valign="top" width="20%">Estimated End Date&nbsp;<span id="spnEstimatedEndDate" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" width="26%">
                                                            <asp:TextBox ID="txtEstimatedEndDate" runat="server" MaxLength="10" SkinID="txtdate"
                                                                Width="150px"></asp:TextBox>
                                                            <img alt="Date to Consultant" onclick="return showCalendar('<%=txtEstimatedEndDate.ClientID %>', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" />                                                            
                                                            <asp:RegularExpressionValidator ID="revEstimatedEndDate" runat="server" ValidationGroup="vsErrorIdentification"
                                                                Display="none" ErrorMessage="[Consultant and Schedule]/Estimated End Date is not a valid date"
                                                                SetFocusOnError="true" ControlToValidate="txtEstimatedEndDate" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Building&nbsp;<span id="spnBuilding" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <asp:CheckBoxList ID="cblBuildingList" runat="server" RepeatDirection="Vertical"
                                                                RepeatLayout="Flow" RepeatColumns="1">
                                                            </asp:CheckBoxList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top" width="20%">Project Description&nbsp;<span id="spnProjectDescription" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top" width="4%">:
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="txtProjectDescription" runat="server" ControlType="TextBox" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" align="center" valign="middle">
                                                            <asp:Button ID="btnSave" Text="Save and View" runat="server" OnClick="btnSave_Click" CausesValidation="true" ValidationGroup="vsErrorIdentification" />&nbsp;&nbsp;
                                                            <asp:Button ID="btnReturnto_View_Mode" Text="Return to View Mode" runat="server"
                                                                OnClick="btnReturnto_View_Mode_Click" CausesValidation="false"
                                                                Width="150px" />&nbsp;&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div id="divAttachment" style="display: none;">
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td align="left" valign="top" width="100%" style="height: 200px;">
                                                            <uc:ctrlAttachment ID="ctrlAttachment" runat="server" PanelNumber="2" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <table border="0" cellpadding="5" cellspacing="1" width="100%">
                                <tr>
                                    <td align="center">
                                        <asp:Button ID="btnEdit" Text="Edit" runat="server" OnClick="btnEdit_Click"
                                            CausesValidation="false" />&nbsp;&nbsp;
                                        <asp:Button runat="server" ID="btnAuditTrail" Text="View Audit Trail" CausesValidation="false"
                                            OnClientClick="javascript:return OpenAuditPopUp();" />
                                        <asp:Button ID="btnCancel" runat="server" Text=" Cancel " OnClick="btnCancel_Click"/>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <input id="hdnControlIDsIdentification" runat="server" type="hidden" />
    <input id="hdnErrorMsgsIdentification" runat="server" type="hidden" />
    <asp:HiddenField ID="hdnPanel" runat="server" Value="1" />
    <asp:HiddenField ID="hdnPanelSpaire" runat="server" Value="0" />
    <asp:CustomValidator ID="CustomValidatorIdentification" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFields" Display="None" ValidationGroup="vsErrorIdentification" />
    <script type="text/javascript">
        function ValidateFields(sender, args) {
            var validatorID = sender.id;
            var msg = "", ctrlIDs = "", Messages = "", hdnID = "";

            if (validatorID.indexOf('Identification') > 0) {
                ctrlIDs = document.getElementById('<%=hdnControlIDsIdentification.ClientID%>').value.split(','); hdnID = '<%=hdnControlIDsIdentification.ClientID%>'; Messages = document.getElementById('<%=hdnErrorMsgsIdentification.ClientID%>').value.split(',');
            }

            var focusCtrlID = "";
            args.IsValid = false;

            if (hdnID != "") {
                if (document.getElementById(hdnID).value != "") {
                    var i = 0;
                    for (i = 0; i < ctrlIDs.length; i++) {
                        var bEmpty = false;
                        var ctrl = document.getElementById(ctrlIDs[i]);
                        if (ctrlIDs[i] == '<%= cblBuildingList.ClientID %>') {
                            var chkListBuilding = document.getElementById('<%= cblBuildingList.ClientID %>');

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
                                    focusCtrlID = 'ctl00_ContentPlaceHolder1_cblBuildingList';
                                    msg += '- Please Select Building(s)' + "\n";
                                }
                                else {
                                    ctrl = document.getElementById('ctl00_ContentPlaceHolder1_txtProjectNumber');
                                    focusCtrlID = 'ctl00_ContentPlaceHolder1_txtProjectNumber';
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
                        if (ctrlIDs[i] != '<%= cblBuildingList.ClientID %>') {
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
        function OpenAuditPopUp() {
            var winHeight = window.screen.availHeight - 550;
            var winWidth = window.screen.availWidth - 900;

            obj = window.open('AuditPopupConstruction.aspx?id=<%=ViewState["ConstructionProjectId"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }
    </script>
</asp:Content>
