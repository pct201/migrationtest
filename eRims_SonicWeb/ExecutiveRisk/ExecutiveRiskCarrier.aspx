<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExecutiveRiskCarrier.aspx.cs"
    Inherits="PropertyLiability_ExecutiveRiskCarrier" MasterPageFile="~/Default.master" %>

<%@ Register Src="~/Controls/ExcecutiveRiskInfo/ExecutiveRiskInfo.ascx" TagName="ctrlExecRisk"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment-ExecutiveRisk/Attachment.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment-ExecutiveRisk/AttachmentDetails.ascx" TagName="ctrlAttachmentDetails"
    TagPrefix="uc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="cnProperty_PropertyIdentification"
    runat="server">
    <script type="text/javascript" src="../JavaScript/JFunctions.js"></script>
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
                    document.getElementById("<%=pnlCarrier.ClientID%>").style.display = "block";
                    document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "none";
                }
                else if (index == 2) {
                    document.getElementById("<%=pnlCarrier.ClientID%>").style.display = "none";
                    document.getElementById("<%=dvAttachment.ClientID%>").style.display = "block";
                    document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "block";
                }
            }
        }

        function ShowPanelView(index) {
            SetMenuStyle(index);
            document.getElementById('<%=dvView.ClientID%>').style.display = "block";
            if (index == 1) {
                document.getElementById("<%=pnlCarrierView.ClientID%>").style.display = "block";
                document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "none";
            }
            else if (index == 2) {
                document.getElementById("<%=pnlCarrierView.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "block";
                document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
            }
        }

        function ValSave() {
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqAttachType').enabled = false;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqFile').enabled = false;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_cstFile').enabled = false;

            if (document.getElementById('<%=txtContactNumber.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtContactNumber.ClientID%>').value = "";
            if (Page_ClientValidate())
                return true;
            else
                return false;
        }

        function ValAttach() {
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqAttachType').enabled = true;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqFile').enabled = true;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_cstFile').enabled = true;
            if (document.getElementById('<%=txtContactNumber.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtContactNumber.ClientID%>').value = "";
            if (Page_ClientValidate())
                return true;
            else
                return false;
        }
        function AuditPopUp() {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;

            obj = window.open("AuditPopUp_ExecutiveRiskCarrier.aspx?id=" + '<%=ViewState["PK_Executive_Risk_Carrier"]%>' + '&Table_Name=Carrier', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
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
            $("#<%=txtContactNumber.ClientID%>").mask("999-999-9999");
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
                            <span id="Menu1" onclick="javascript:ShowPanel(1);" class="LeftMenuStatic">Executive
                                Risk Carrier</span>&nbsp;<span id="MenuAsterisk1" runat="server" style="color: Red;display:none">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="100%">
                            <span id="Menu2" onclick="javascript:ShowPanel(2);" class="LeftMenuStatic">Attachment</span>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top" align="left">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td width="5px">
                            &nbsp;
                        </td>
                        <td valign="top" width="794px" class="dvContainer">
                            <div id="dvEdit" runat="server">
                                <asp:Panel ID="pnlCarrier" runat="server" Style="display: none;">
                                    <div class="bandHeaderRow">
                                        Executive Risk Carrier</div>
                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                        <tr>
                                            <td align="left" width="18%">
                                                Carrier&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td align="center" width="4%">
                                                :
                                            </td>
                                            <td align="left" width="28%">
                                                <asp:TextBox ID="txtCarrier" runat="server" Width="170px" MaxLength="50"></asp:TextBox>                                               
                                            </td>
                                            <td align="left" width="18%">
                                                &nbsp;
                                            </td>
                                            <td align="center" width="4%">
                                                &nbsp;
                                            </td>
                                            <td align="right" width="28%">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Layer&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="drpLayer" Width="170px" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left">
                                                Limit&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                $ &nbsp;<asp:TextBox ID="txtLimit" runat="server" Width="155px" onpaste="return false"
                                                    onkeypress="return FormatNumber(event,this.id,13,true);"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="regLimit" ControlToValidate="txtLimit" runat="server"
                                                    ErrorMessage="Please enter [Executive Risk Carrier]/Limit in proper format" ValidationGroup="vsErrorGroup"
                                                    Display="none" ValidationExpression="^\d{1,3}(,\d\d\d)*$"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Contact Name&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtContactName" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                                            </td>
                                            <td align="left">
                                                Contact Number&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtContactNumber" runat="server" Width="170px"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="revTelephone" ControlToValidate="txtContactNumber"
                                                    runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter [Executive Risk Carrier]/Contact Number in xxx-xxx-xxxx format."
                                                    Display="none" ValidationExpression="\d{3}(-\d{3})(-\d{4})"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Claim Number&nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtClaimNumber" runat="server" Width="170px" MaxLength="30"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">
                                                Notes&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td align="center" valign="top">
                                                :
                                            </td>
                                            <td align="left" colspan="4">
                                                <uc:ctrlMultiLineTextBox ID="txtNotes" runat="server" />
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
                            <div id="dvView" runat="server">
                                <asp:Panel ID="pnlCarrierView" runat="server" Style="display: none;">
                                    <div class="bandHeaderRow">
                                        Executive Risk Carrier</div>
                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                        <tr>
                                            <td align="left" width="18%">
                                                Carrier&nbsp;<span style="color: Red;">*</span>
                                            </td>
                                            <td align="center" width="4%">
                                                :
                                            </td>
                                            <td align="left" width="28%">
                                                <asp:Label ID="lblCarrier" runat="server"></asp:Label>
                                            </td>
                                            <td align="left" width="18%">
                                                &nbsp;
                                            </td>
                                            <td align="center" width="4%">
                                                &nbsp;
                                            </td>
                                            <td align="right" width="28%">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Layer
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblLayer" runat="server">
                                                </asp:Label>
                                            </td>
                                            <td align="left">
                                                Limit
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                $ &nbsp;<asp:Label ID="lblLimit" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Contact Name
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblContactName" runat="server"></asp:Label>
                                            </td>
                                            <td align="left">
                                                Contact Number
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblContactNumber" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Claim Number
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblClaimNumber" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">
                                                Notes
                                            </td>
                                            <td align="center" valign="top">
                                                :
                                            </td>
                                            <td align="left" colspan="4">
                                                <uc:ctrlMultiLineTextBox ID="lblNotes" runat="server" ControlType="Label" />
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
            <td colspan="2" width="100%" class="Spacer" style="height:10px;">
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
            <td colspan="2" width="100%" class="Spacer" style="height:10px;">
            </td>
        </tr>
        
    </table>
    <asp:CustomValidator ID="CustomValidator" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
        Display="None" ValidationGroup="vsErrorGroup" />
    <input id="hdnControlIDs" runat="server" type="hidden" />
    <input id="hdnErrorMsgs" runat="server" type="hidden" />
</asp:Content>
