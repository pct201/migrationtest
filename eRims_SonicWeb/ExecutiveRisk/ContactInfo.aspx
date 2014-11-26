<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="ContactInfo.aspx.cs"
    Inherits="ExecutiveRisk_ContactInfo" %>

<%@ Register Src="~/Controls/ExcecutiveRiskInfo/ExecutiveRiskInfo.ascx" TagName="ctrlExecRisk"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment-ExecutiveRisk/Attachment.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment-ExecutiveRisk/AttachmentDetails.ascx" TagName="ctrlAttachmentDetails"
    TagPrefix="uc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="../JavaScript/Validator.js"></script> 
    <script type="text/javascript" language="javascript" src="../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/jquery.maskedinput.js"></script>
    <script type="text/javascript">
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

            var op = '<%=Request.QueryString["op"]%>';
            if (op == "view") {
                document.getElementById("<%=dvSave.ClientID %>").style.display = "none";
                document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
                ShowPanelView(index);
            }
            else {
                if (index == 1) {
                    document.getElementById("<%=pnlContactInfo.ClientID%>").style.display = "block";
                    document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "none";
                }
                else if (index == 2) {
                    document.getElementById("<%=pnlContactInfo.ClientID%>").style.display = "none";
                    document.getElementById("<%=dvAttachment.ClientID%>").style.display = "block";
                    document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "block";
                }
            }
        }

        function ShowPanelView(index) {
            SetMenuStyle(index);
            document.getElementById('<%=dvView.ClientID%>').style.display = "block";
            if (index == 1) {
                document.getElementById("<%=pnlContactInfoView.ClientID%>").style.display = "block";
                document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "none";
            }
            else if (index == 2) {
                document.getElementById("<%=pnlContactInfoView.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "block";
                document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
            }
        }

        function ValSave() {
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqAttachType').enabled = false;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqFile').enabled = false;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_cstFile').enabled = false;

            if (document.getElementById('<%=txtZipcode.ClientID%>').value == "_____-____")
                document.getElementById('<%=txtZipcode.ClientID%>').value = "";

            if (document.getElementById('<%=txtTelNum.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtTelNum.ClientID%>').value = "";

            if (document.getElementById('<%=txtCellPhone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtCellPhone.ClientID%>').value = "";

            if (Page_ClientValidate())
                return true;
            else
                return false;
        }

        function ValAttach() {
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqAttachType').enabled = true;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqFile').enabled = true;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_cstFile').enabled = true;
            if (document.getElementById('<%=txtZipcode.ClientID%>').value == "_____-____")
                document.getElementById('<%=txtZipcode.ClientID%>').value = "";

            if (document.getElementById('<%=txtTelNum.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtTelNum.ClientID%>').value = "";

            if (document.getElementById('<%=txtCellPhone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtCellPhone.ClientID%>').value = "";


            if (Page_ClientValidate())
                return true;
            else
                return false;
        }
        function AuditPopUp() {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;

            obj = window.open("AuditPopup_ContactInfo.aspx?id=" + '<%=ViewState["PK_Executive_Risk_Contacts"]%>' + '&Table_Name=Executive_Risk_Contacts', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }

        function ValidateFields(sender, args) {
            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnControlIDs.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnErrorMsgs.ClientID%>').value.split(',');            
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

        jQuery(function ($) {
            $("#<%=txtTelNum.ClientID%>").mask("999-999-9999");
            $("#<%=txtCellPhone.ClientID%>").mask("999-999-9999");
        });

    </script>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="Spacer" style="height: 15px;" colspan="2">
            </td>
        </tr>
        <tr>
            <td width="100%" colspan="2">
                <uc:ctrlExecRisk ID="ExecutiveRiskInfo" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 15px;" colspan="2">
            </td>
        </tr>
        <tr>
            <td class="leftMenu" valign="top">
                <table cellpadding="5" cellspacing="0" width="100%">
                    <tr>
                        <td style="height: 18px;" class="Spacer">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="100%">
                            <span id="Menu1" onclick="javascript:ShowPanel(1);" class="LeftMenuStatic">Contact Information</span>&nbsp;<span id="MenuAsterisk1" runat="server" style="color: Red;display:none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="100%">
                            <span id="Menu2" onclick="javascript:ShowPanel(2);" class="LeftMenuStatic">Attachment</span>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top" align="center">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td width="5px">
                            &nbsp;
                        </td>
                        <td valign="top" width="794px" class="dvContainer">
                            <div id="dvEdit" runat="server">
                                <asp:Panel ID="pnlContactInfo" runat="server" Style="display: none;">
                                    <div class="bandHeaderRow">
                                        Contact Information</div>
                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                        <tr>
                                            <td align="left" width="18%">
                                                Contact Type&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td align="center" width="4%">
                                                :
                                            </td>
                                            <td align="left" width="28%">
                                                <asp:DropDownList ID="drpContactType" runat="server" Width="170px">
                                                    <asp:ListItem Text="--Select--" Value="0" />
                                                    <asp:ListItem Text="HR" Value="HR" />
                                                    <asp:ListItem Text="Legal" Value="Legal" />
                                                    <asp:ListItem Text="Risk Management" Value="Risk Management" />
                                                    <asp:ListItem Text="Other" Value="Other" />
                                                </asp:DropDownList>
                                                <%--<asp:RequiredFieldValidator ID="rfvContactType" runat="server" ControlToValidate="drpContactType"
                                                    Display="none" Text="*" ErrorMessage="Please Enter [Contact Information]/Contact Type"
                                                    SetFocusOnError="true" ValidationGroup="vsErrorGroup" InitialValue="0"></asp:RequiredFieldValidator>--%>
                                            </td>
                                            <td colspan="3">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="18%">
                                                Contact Name&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td align="center" width="4%">
                                                :
                                            </td>
                                            <td align="left" width="28%">
                                                <asp:TextBox ID="txtContactName" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                                                <%--<asp:RequiredFieldValidator ID="rfvContactName" runat="server" ControlToValidate="txtContactName"
                                                    Display="none" Text="*" ErrorMessage="Please Enter [Contact Information]/Contact Name"
                                                    SetFocusOnError="true" ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>--%>
                                            </td>
                                            <td align="left" width="18%">
                                                Contact Telephone Number (XXX-XXX-XXXX)&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td align="center" width="4%">
                                                :
                                            </td>
                                            <td align="left" width="28%">
                                                <asp:TextBox ID="txtTelNum" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="mskvTelNum" ControlToValidate="txtTelNum" runat="server"
                                                    ValidationGroup="vsErrorGroup" ErrorMessage="Please enter Contact Telephone Number in xxx-xxx-xxxx format."
                                                    Display="none" ValidationExpression="\d{3}(-\d{3})(-\d{4})"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Contact Address 1&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtAddress1" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                                            </td>
                                            <td align="left">
                                                Contact Address 2&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtAddress2" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Contact City&nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtCity" runat="server" Width="170px" MaxLength="20"></asp:TextBox>
                                            </td>
                                            <td align="left">
                                                Contact State&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="drpState" Width="170px" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Contact Zip Code&nbsp;<span id="Span8" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtZipcode" runat="server" Width="170px" MaxLength="10" onKeyPress="javascript:return FormatZipCode(event,this.id);"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="revZipCode" ControlToValidate="txtZipCode" runat="server"
                                                    ValidationGroup="vsErrorGroup" ErrorMessage="Please enter Contact Zip Code in xxxxx-xxxx format."
                                                    Display="none" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Contact E-Mail&nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtEmail" runat="server" Width="170px" MaxLength="255"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                                                    ValidationGroup="vsErrorGroup" Display="None" ErrorMessage="Contact E-Mail Address Is Invalid"
                                                    SetFocusOnError="True" ToolTip="Email Address Is Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                            </td>
                                            <td align="left">
                                                Contact Cell Phone (XXX-XXX-XXXX)&nbsp;<span id="Span10" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtCellPhone" runat="server" Width="170px"></asp:TextBox>
                                                 <asp:RegularExpressionValidator ID="revTelephone" ControlToValidate="txtCellPhone"
                                                    runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please enter Contact Cell Phone in xxx-xxx-xxxx format."
                                                    Display="none" ValidationExpression="\d{3}(-\d{3})(-\d{4})"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <div id="dvAttachment" runat="server">
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td width="100%">
                                                <uc:ctrlAttachment ID="Attachment" EnableValidationSummary="true" runat="Server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="Spacer" style="height: 20px;" colspan="2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="Spacer" style="height: 20px;" colspan="2">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div id="dvView" runat="server" style="display: none;">
                                <asp:Panel ID="pnlContactInfoView" runat="server" Style="display: none;">
                                    <div class="bandHeaderRow">
                                        Contact Information</div>
                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                        <tr>
                                            <td align="left" width="18%">
                                                Contact Type&nbsp;<span style="color: Red;">*</span>
                                            </td>
                                            <td align="center" width="4%">
                                                :
                                            </td>
                                            <td align="left" width="28%">
                                                <asp:Label ID="lblContactType" runat="server" />
                                            </td>
                                            <td colspan="3">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="18%">
                                                Contact Name
                                            </td>
                                            <td align="center" width="4%">
                                                :
                                            </td>
                                            <td align="left" width="28%">
                                                <asp:Label ID="lblContactName" runat="server" Width="170px"></asp:Label>
                                            </td>
                                            <td align="left" width="18%">
                                                Contact Telephone Number (XXX-XXX-XXXX)
                                            </td>
                                            <td align="center" width="4%">
                                                :
                                            </td>
                                            <td align="left" width="28%">
                                                <asp:Label ID="lblTelNum" runat="server" Width="170px"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Contact Address 1
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblAddress1" runat="server" Width="170px"></asp:Label>
                                            </td>
                                            <td align="left">
                                                Contact Address 2
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblAddress2" runat="server" Width="170px"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Contact City
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblCity" runat="server" Width="170px"></asp:Label>
                                            </td>
                                            <td align="left">
                                                Contact State
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblState" Width="170px" runat="server">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Contact Zip Code
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblZipcode" runat="server" Width="170px"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Contact E-Mail
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblEmail" runat="server" Width="170px"></asp:Label>
                                            </td>
                                            <td align="left">
                                                Contact Cell Phone (XXX-XXX-XXXX)
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblCellPhone" runat="server" Width="170px"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </div>
                            <asp:Panel ID="pnlAttachmentDetails" runat="server" Style="display: none;">
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td width="100%">
                                            <uc:ctrlAttachmentDetails ID="AttachDetails" runat="Server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Spacer" style="height: 150px;">
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
            <td colspan="2" width="100%" class="Spacer" style="height: 10px;">
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
                            <td width="40%" align="right">
                                <asp:Button ID="btnSave" runat="server" Text="Save & View" OnClick="btnSaveAndView_Click"
                                    ValidationGroup="vsErrorGroup" CausesValidation="true" />
                            </td>
                            <td align="left">
                                <asp:Button ID="btnBack1" runat="server" Text=" Back " OnClick="btnBack_Click" />&nbsp;
                                <asp:Button ID="btnViewAudit" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();" />
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
        <tr>
            <td colspan="2" width="100%" align="center">
                <asp:Button ID="btnBack" runat="server" Text=" Back " OnClick="btnBack_Click" Visible="false" />&nbsp;
                <asp:Button ID="btnAuditView" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();" />
            </td>
        </tr>
        <tr>
            <td colspan="2" width="100%" class="Spacer" style="height: 10px;">
            </td>
        </tr>       
    </table>
    <asp:CustomValidator ID="CustomValidator" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
        Display="None" ValidationGroup="vsErrorGroup" />
    <input id="hdnControlIDs" runat="server" type="hidden" />
    <input id="hdnErrorMsgs" runat="server" type="hidden" />
</asp:Content>
