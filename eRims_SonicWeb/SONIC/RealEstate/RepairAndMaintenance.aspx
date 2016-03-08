<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="RepairAndMaintenance.aspx.cs" Inherits="SONIC_RealEstate_RepairAndMaintenance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/NotesWithSpellCheck/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposuresTab/ExposuresTab.ascx" TagName="CtlTab" TagPrefix="uc" %>
<%@ Register Src="../../Controls/RealEstateInfo/RealEstateInfo.ascx" TagName="RealEstateInfo"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" src="../../JavaScript/JFunctions.js"></script>
    <script language="javascript" type="text/javascript">

        function AuditPopUp() {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;

            obj = window.open("AuditPopup_RE_Repair_And_Maint.aspx?id=" + '<%=ViewState["PK_RE_Repair_Maintenance"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
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
                    if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
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

    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <uc:CtlTab runat="server" ID="Tab"></uc:CtlTab>
            </td>
        </tr>
        <tr>
            <td style="height: 15px" class="Spacer" colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <uc2:RealEstateInfo ID="RealEstate_Info" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="height: 20px" class="Spacer" colspan="2">
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="leftMenu">
                            <table cellpadding="5" cellspacing="0" width="100%">
                                <tr>
                                    <td style="height: 10px;" class="Spacer">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Menu1" class="LeftMenuSelected">Repair/Maintenance</span>&nbsp;<span id="MenuAsterisk1" runat="server" style="color: Red;display:none">*</span>
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
                                            <asp:Panel ID="pnl1" runat="server">
                                                <div class="bandHeaderRow">
                                                    Real Estate : Repair/Maintenance</div>
                                                <table cellpadding="5" cellspacing="1" border="0" width="100%">
                                                     <tr>
                                                        <td colspan="6" style="font-weight:bold;">
                                                            Responsible Parties
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            HVAC Repairs&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:DropDownList ID="drpFK_LU_Responsibilie_Party_HVAC_Repairs" Width="170px" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                           HVAC Capital &nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                           :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:DropDownList ID="drpFK_LU_Responsibilie_Party_HVAC_Capital" Width="170px" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Roof Repairs&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                           <asp:DropDownList ID="drpFK_LU_Responsibilie_Party_Roof_Repairs" Width="170px" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left" valign="top">
                                                           Roof Capital&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                           <asp:DropDownList ID="drpFK_LU_Responsibilie_Party_Roof_Capital" Width="170px" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                           Other Repairs&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="drpFK_LU_Responsibilie_Party_Other_Repairs" Width="170px" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" style="font-style:italic;">
                                                            Please add conditions for asterisk selections in Maintenance Notes, below.
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                          &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Maintenance Notes&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtMaintenance_Notes" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </div>
                                        <div id="dvView" runat="server" width="794px">
                                            <asp:Panel ID="pnl1View" runat="server">
                                                <div class="bandHeaderRow">
                                                    Real Estate : Repair/Maintenance</div>
                                                <table cellpadding="5" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td colspan="6" style="font-weight:bold;">
                                                            Responsible Parties
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                           HVAC Repairs
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblFK_LU_Responsibilie_Party_HVAC_Repairs" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            HVAC Capital
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblFK_LU_Responsibilie_Party_HVAC_Capital" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                           Roof Repairs
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblFK_LU_Responsibilie_Party_Roof_Repairs" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Roof Capital
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_LU_Responsibilie_Party_Roof_Capital" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                           Other Repairs
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_LU_Responsibilie_Party_Other_Repairs" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" valign="top">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                   <tr>
                                                        <td colspan="6" style="font-style:italic;">
                                                            Please add conditions for asterisk selections in Maintenance Notes, below.
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                          &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Maintenance Notes
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblMaintenance_Notes" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="5px" class="Spacer" colspan="6">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="center">
                                                            <asp:Button ID="btnBack" runat="server" Text=" Back " CausesValidation="false" ValidationGroup="vsErrorGroup"
                                                                OnClick="btnBack_Click" />&nbsp;
                                                            <asp:Button ID="btnViewAudit2" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <div id="dvSave" runat="server">
                                <table cellpadding="10" cellspacing="0" border="0" width="100%">
                                    <tr>
                                        <td align="center">
                                            <asp:Button ID="btnSave" runat="server" Text="Save & View" OnClick="btnSave_Click"
                                                CausesValidation="true" ValidationGroup="vsErrorGroup" />
                                            &nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btnRevert" runat="server" Text="Revert & Return" CausesValidation="false"
                                                ValidationGroup="vsErrorGroup" OnClick="btnBack_Click" />&nbsp;
                                            <asp:Button ID="btnViewAudit" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();" />
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

