<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExecutiveRiskExpenses.aspx.cs"
    Inherits="PropertyLiability_ExecutiveRiskExpenses" MasterPageFile="~/Default.master" %>

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
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"></script>
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
                    document.getElementById("<%=pnlAttorney.ClientID%>").style.display = "block";
                    document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "none";
                }
                else if (index == 2) {
                    document.getElementById("<%=pnlAttorney.ClientID%>").style.display = "none";
                    document.getElementById("<%=dvAttachment.ClientID%>").style.display = "block";
                    document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "block";
                }
            }
        }

        function ShowPanelView(index) {
            SetMenuStyle(index);
            document.getElementById('<%=dvView.ClientID%>').style.display = "block";
            if (index == 1) {
                document.getElementById("<%=pnlAttorneyView.ClientID%>").style.display = "block";
                document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "none";
            }
            else if (index == 2) {
                document.getElementById("<%=pnlAttorneyView.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "block";
                document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
            }
        }

        function ValSave() {
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqAttachType').enabled = false;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqFile').enabled = false;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_cstFile').enabled = false;
            if (Page_ClientValidate())
                return true;
            else
                return false;
        }

        function ValAttach() {
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqAttachType').enabled = true;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqFile').enabled = true;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_cstFile').enabled = true;
            if (Page_ClientValidate())
                return true;
            else
                return false;
        }
        function AuditPopUp() {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;

            obj = window.open("AuditPopup_ExecutiveRiskExpenses.aspx?id=" + '<%=ViewState["PK_Executive_Risk_Expenses"]%>' + '&Table_Name=Executive_Risk_Expenses', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
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
            $("#<%=txtDate.ClientID%>").mask("99/99/9999");
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
                                Risk Expenses</span>&nbsp;<span id="MenuAsterisk1" runat="server" style="color: Red;display:none">*</span>
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
                                <asp:Panel ID="pnlAttorney" runat="server" Style="display: none;">
                                    <div class="bandHeaderRow">
                                        Executive Risk Expenses</div>
                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                        <tr>
                                            <td align="left" width="18%">
                                                Company&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td align="center" width="4%">
                                                :
                                            </td>
                                            <td align="left" width="28%">
                                                <asp:TextBox ID="txtCompany" runat="server" Width="170px" MaxLength="50"></asp:TextBox>                                              
                                            </td>
                                            <td align="left" width="18%">
                                                Invoice&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td align="center" width="4%">
                                                :
                                            </td>
                                            <td align="left" width="28%">
                                                <asp:TextBox ID="txtInvoice" runat="server" Width="170px" MaxLength="30"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Amount&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                $ &nbsp;<asp:TextBox ID="txtAmount" runat="server" Width="155px" onKeyPress="return(currencyFormat(this,',','.',event));"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="regAmount" ControlToValidate="txtAmount" runat="server"
                                                    ErrorMessage="Please enter [Executive Risk Expenses]/Amount in proper format"
                                                    ValidationGroup="vsErrorGroup" Display="none" ValidationExpression="^\d{1,3}(,\d\d\d)*\.\d\d$"></asp:RegularExpressionValidator>
                                            </td>
                                            <td align="left">
                                                Date&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                                                <img alt="Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate', 'mm/dd/y');"
                                                    onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                    align="middle" /><br />
                                                <asp:RegularExpressionValidator ID="revDate" runat="server" ControlToValidate="txtDate"
                                                    ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                    ErrorMessage="[Executive Risk Expenses]/Date Not Valid" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">
                                                Notes&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
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
                                <asp:Panel ID="pnlAttorneyView" runat="server" Style="display: none;">
                                    <div class="bandHeaderRow">
                                        Executive Risk Expenses</div>
                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                        <tr>
                                            <td align="left" width="18%">
                                                Company
                                            </td>
                                            <td align="center" width="4%">
                                                :
                                            </td>
                                            <td align="left" width="28%">
                                                <asp:Label ID="lblCompany" runat="server"></asp:Label>
                                            </td>
                                            <td align="left" width="18%">
                                                Invoice
                                            </td>
                                            <td align="center" width="4%">
                                                :
                                            </td>
                                            <td align="left" width="28%">
                                                <asp:Label ID="lblInvoice" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Amount
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                $ &nbsp;<asp:Label ID="lblAmount" runat="server" Width="155px"></asp:Label>
                                            </td>
                                            <td align="left">
                                                Date
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblDate" runat="server"></asp:Label>
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
            <td class="Spacer" style="height: 10px;" colspan="2">
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
                                <asp:Button ID="btnBack1" runat="server" Text=" Back " OnClick="btnBack_Click" CausesValidation="false" />&nbsp;
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
                <asp:Button ID="btnBack" runat="server" Text=" Back " OnClick="btnBack_Click" Visible="false"
                    CausesValidation="false" />&nbsp;
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
