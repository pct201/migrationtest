<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="IncidentInvolvement.aspx.cs" Inherits="SONIC_FirstReport_IncidentInvolvement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="Content1" runat="server">
    <script type="text/javascript" src="../../JavaScript/JFunctions.js"></script>
     <script type="text/javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript">
        function SetMenuStyle(index) {
            var i;
            for (i = 1; i <= 1; i++) {
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
                for (i = 1; i <= 1; i++) {
                    document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display = (i == index) ? "block" : "none";
                }
            }
        }

        function ShowPanelView(index) {
            SetMenuStyle(index);
            document.getElementById('<%=dvView.ClientID%>').style.display = "block";
            var i;
            for (i = 1; i <= 1; i++) {
                document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i + "view").style.display = (i == index) ? "block" : "none";
            }
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

        function OpenAuditPopUp() {
            var winHeight = window.screen.availHeight - 400;
            var winWidth = window.screen.availWidth - 500;

            obj = window.open('AuditPopup_IncidentInvolvement.aspx?id=<%=ViewState["PK_FR_PL_Involvement"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }
    </script>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="ghc" align="left">
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
                                        <span id="Menu1" onclick="javascript:ShowPanel(1);" class="LeftMenuStatic">Incident
                                            Involvement Grid</span> <span id="MenuAsterisk1" runat="server" style="color: Red;
                                                display: none">*</span>
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
                                                    Incident Involvement Grid</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Type&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:DropDownList ID="drpFK_LU_PL_Involvement" Width="175px" runat="server" SkinID="dropGen">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            Name&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:TextBox ID="txtName" runat="server" Width="170px" MaxLength="75" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Address 1&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtAddress_1" runat="server" Width="170px" MaxLength="50" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Address 2&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtAddress_2" runat="server" Width="170px" MaxLength="50" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            City&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtCity" runat="server" Width="170px" MaxLength="30" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            State&nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:DropDownList ID="drpFK_State" Width="175px" runat="server" SkinID="dropGen">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Zip Code (XXXXX-XXXX)&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtZip_Code" runat="server" Width="170px" MaxLength="10" onKeyPress="javascript:return FormatZipCode(event,this.id);"/>
                                                             <asp:RegularExpressionValidator ID="revZipCode" runat="server" ErrorMessage="Please enter valid Zip Code"
                                                                    Display="none" ControlToValidate="txtZip_Code" ValidationExpression="\b[0-9]{5}-[0-9]{4}\b|\b[0-9]{5}\b"
                                                                    ValidationGroup="vsErrorGroup" SetFocusOnError="true" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Home Telephone (XXX-XXX-XXXX)&nbsp;<span id="Span8" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtHome_Telephone" runat="server" Width="170px" MaxLength="12"  onKeyPress="javascript:return FormatPhone(event,this.id);"/>
                                                            <asp:RegularExpressionValidator ID="revContactPhone" runat="server" ErrorMessage="Please enter valid Home Telephone"
                                                                ControlToValidate="txtHome_Telephone" ValidationExpression="\b[0-9]{3}-[0-9]{3}-[0-9]{4}\b"
                                                                Display="none" ValidationGroup="vsErrorGroup" SetFocusOnError="true" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Work Telephone (XXX-XXX-XXXX)&nbsp;<span id="Span9" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtWork_Telephone" runat="server" Width="170px" MaxLength="12" onKeyPress="javascript:return FormatPhone(event,this.id);"/>
                                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please enter valid Work Telephone"
                                                                ControlToValidate="txtWork_Telephone" ValidationExpression="\b[0-9]{3}-[0-9]{3}-[0-9]{4}\b"
                                                                Display="none" ValidationGroup="vsErrorGroup" SetFocusOnError="true" />
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Cell Telephone (XXX-XXX-XXXX)&nbsp;<span id="Span10" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtCell_Telephone" runat="server" Width="170px" MaxLength="12"  onKeyPress="javascript:return FormatPhone(event,this.id);"/>
                                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Please enter valid Cell Telephone"
                                                                ControlToValidate="txtCell_Telephone" ValidationExpression="\b[0-9]{3}-[0-9]{3}-[0-9]{4}\b"
                                                                Display="none" ValidationGroup="vsErrorGroup" SetFocusOnError="true" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            E-Mail Address&nbsp;<span id="Span11" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:TextBox ID="txtEmail" runat="server" Width="170px" MaxLength="255" />
                                                             <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Please enter valid E-Mail Address"
                                                        ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                        Display="None" SetFocusOnError="true" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </div>
                                        <div id="dvView" runat="server" width="794px">
                                            <asp:Panel ID="pnl1View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Incident Involvement Grid</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Type
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblFK_LU_PL_Involvement" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">
                                                            Name
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblName" runat="server"></asp:Label>
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
                                                            <asp:Label ID="lblAddress_1" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Address 2
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblAddress_2" runat="server"></asp:Label>
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
                                                            <asp:Label ID="lblCity" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            State
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFK_State" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Zip Code (XXXXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblZip_Code" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Home Telephone (XXX-XXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblHome_Telephone" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Work Telephone (XXX-XXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblWork_Telephone" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">
                                                            Cell Telephone (XXX-XXX-XXXX)
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblCell_Telephone" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            E-Mail Address
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblEmail" runat="server"></asp:Label>
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
                                <table cellpadding="5" cellspacing="5" border="0" width="100%">
                                    <tr>
                                        <td align="center">
                                            <asp:Button ID="btnSave" runat="server" Text=" Save " OnClick="btnSave_Click"
                                                CausesValidation="true" ValidationGroup="vsErrorGroup" />&nbsp;&nbsp;
                                            <asp:Button ID="btnReturn" runat="server" Text=" Return " OnClick="btnReturn_Click" />&nbsp;&nbsp;
                                            <asp:Button ID="btnRevert" runat="server" Text=" Revert " OnClick="btnRevert_Click" />&nbsp;&nbsp;
                                            <asp:Button ID="btnAuditTrail" runat="server" Text=" Audit Trail " OnClientClick="javascript:return OpenAuditPopUp();"/>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="dvViewbutton" runat="server">
                                <table cellpadding="5" cellspacing="5" border="0" width="100%">
                                    <tr>
                                        <td align="center">
                                            <asp:Button ID="btnEdit" runat="server" Text=" Edit " OnClick="btnEdit_Click" />&nbsp;&nbsp;
                                            <asp:Button ID="btnReturnView" runat="server" Text=" Return " OnClick="btnReturn_Click" />&nbsp;&nbsp;
                                            <asp:Button ID="btnAuditTrailView" runat="server" Text=" Audit Trail " OnClientClick="javascript:return OpenAuditPopUp();"/>
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
