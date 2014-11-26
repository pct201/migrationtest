<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="LR_Asset.aspx.cs"
    Inherits="SONIC_Purchasing_LR_Asset" Title="Risk Insurance Management System :: Add Lease Rental Agreement Asset" %>

<%@ Register Src="../../Controls/SONIC_Purchasing/LR_Argreement.ascx" TagName="LR_Argreement"
    TagPrefix="uc1" %>
<%@ Register Src="../../Controls/SONIC_Purchasing/Purchasing_Search.ascx" TagName="Purchasing_Search"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
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
                        case "select-multiple": if (ctrl.selectedIndex == -1) bEmpty = true; break;
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
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <uc1:Purchasing_Search ID="Purchasing_SearchTAB" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <uc1:LR_Argreement ID="LR_ArgreementTAB" runat="server" />
            </td>
        </tr>
        <%--<tr>
            <td class="Spacer" style="height: 15px;" colspan="2">
            </td>
        </tr>
        <tr>
            <td class="groupHeaderBar" align="left" colspan="2">
                <asp:Label ID="lblTitle" runat="server" Text="Lease/Rental Agreement" CssClass="heading"></asp:Label>
            </td>
        </tr>--%>
        <tr>
            <td style="height: 20px" class="Spacer" colspan="2">
            </td>
        </tr>
        <tr>
            <td class="leftMenu">
                <table cellpadding="0" cellspacing="0" width="203px">
                    <tr>
                        <td style="height: 10px;" class="Spacer">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="5" cellspacing="0" width="100%">
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="Asset" class="LeftMenuSelected">Asset &nbsp;<span id="MenuAsterisk1" runat="server" style="color: Red;display:none">*</span></span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px;" class="Spacer">
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top" width="100%">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td width="5px">
                            &nbsp;
                        </td>
                        <td class="dvContainer">
                            <div id="dvEdit" runat="server" width="794px">
                                <asp:Panel ID="pnlLRAgreement" runat="server" Style="display: block;">
                                    <div class="bandHeaderRow">
                                        Lease/Rental Agreement - Asset</div>
                                    <table width="100%" cellpadding="3" cellspacing="1" border="0">
                                        <tr>
                                            <td colspan="3">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="26%" align="left" nowrap="nowrap">
                                                Asset&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td width="4%" align="center">
                                                :
                                            </td>
                                            <td width="70%" align="left">
                                                <asp:DropDownList ID="drpAsset" runat="server" Width="170px">
                                                </asp:DropDownList>
                                                <%--<asp:RequiredFieldValidator ID="rfvDepartment" runat="server" ErrorMessage="Please Select Asset"
                                                    ControlToValidate="drpAsset" Display="None" InitialValue="0" ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                &nbsp;
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
            <td>
                &nbsp;
            </td>
            <td align="center">
                <div id="dvSave" runat="server">
                    <table cellpadding="5" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="40%" align="right">
                                <asp:Button ID="btnSave" runat="server" Text="Save & View" OnClick="btnSaveAndView_Click"
                                    ValidationGroup="vsErrorGroup" CausesValidation="true" />
                            </td>
                            <td align="left">
                                <asp:Button ID="btnRevertandReturn" runat="server" Text="Revert & Return" CausesValidation="false"
                                    OnClick="btnRevertandReturn_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 10px;" colspan="2">
            </td>
        </tr>
    </table>
    <asp:CustomValidator ID="CustomValidator" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
        Display="None" ValidationGroup="vsErrorGroup" />
    <input id="hdnControlIDs" runat="server" type="hidden" />
    <input id="hdnErrorMsgs" runat="server" type="hidden" />
</asp:Content>
