﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="EPM_Project_Cost_Invoice.aspx.cs" Inherits="SONIC_Exposures_EPM_Project_Cost_Invoice" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/NotesWithSpellCheck/Notes.ascx" TagName="ctrlMultiLineTextBox"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposuresTab/ExposuresTab.ascx" TagName="CtlTab" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="../../JavaScript/JFunctions.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <div>
            <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
                HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
                ValidationGroup="vsError" CssClass="errormessage"></asp:ValidationSummary>
        </div>
        <tr>
            <td width="100%" style="height: 50px;" valign="bottom" colspan="2">
                <uc:CtlTab runat="server" ID="Tab"></uc:CtlTab>
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 10px;" colspan="2"></td>
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
                            <td align="left">
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
            <td class="leftMenu" width="18%">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="height: 10px;" class="Spacer"></td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="5" cellspacing="0" width="100%">
                                <tr>
                                    <td align="left" width="100%">
                                        <span id="EPMProject_Cost" class="LeftMenuSelected">Project Cost - Invoice</span>&nbsp;<span
                                            id="MenuAsterisk1" runat="server" style="color: Red; display: none">*</span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px;" class="Spacer"></td>
                    </tr>
                </table>
            </td>
            <td valign="top" width="82%">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td width="5px">&nbsp;
                        </td>
                        <td class="dvContainer" align="center">
                            <div id="dvEdit" runat="server">
                                <div class="bandHeaderRow">
                                    Project Cost - Invoice
                                </div>
                                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                    <tr>
                                        <td align="left" valign="top" width="20%">Invoice Number&nbsp;<span id="spnInvoiceNumber" style="color: Red; display: none;" runat="server">*</span>
                                        </td>
                                        <td align="center" valign="top" width="4%">:
                                        </td>
                                        <td align="left" valign="top" width="26%">
                                            <asp:TextBox ID="txtInvoiceNumber" runat="server" MaxLength="20" width="146px">
                                            </asp:TextBox>
                                        </td>
                                        <td align="left" valign="top" width="20%">Invoice Date&nbsp;<span id="spnInvoiceDate" style="color: Red; display: none;" runat="server">*</span>
                                        </td>
                                        <td align="center" valign="top" width="4%">:
                                        </td>
                                        <td align="left" valign="top" width="26%">
                                            <asp:TextBox ID="txtInvoiceDate" runat="server" skinid="txtDate">
                                            </asp:TextBox>
                                            <img alt="Date of Invoice" onclick="return showCalendar('<%= txtInvoiceDate.ClientID %>', 'mm/dd/y');"
                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                align="middle" id="imgtxtInvoiceDate" />
                                            <asp:RegularExpressionValidator ID="rvtxtInvoiceDate" runat="server" ControlToValidate="txtInvoiceDate" ValidationGroup="vsError"
                                                ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                                ErrorMessage="[Project Cost - Invoice]/Date of Invoice is Not Valid Date." Display="none" SetFocusOnError="true">
                                            </asp:RegularExpressionValidator>
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" AcceptNegative="Left"
                                                DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtInvoiceDate"
                                                CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964" >
                                            </cc1:MaskedEditExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" width="20%">Invoice Amount&nbsp;<span id="spnInvoiceAmount" style="color: Red; display: none;" runat="server">*</span>
                                        </td>
                                        <td align="center" valign="top" width="4%">:
                                        </td>
                                        <td align="left" valign="top" width="26%">$&nbsp;<asp:TextBox ID="txtInvoiceAmount" runat="server" SkinID="txtCurrency15" Width="146px" onkeypress="return FormatNumber(event,this.id,13,false);"
                                            onpaste="return false" />
                                        </td>
                                        <td colspan="3"></td>
                                    </tr>
                                    <tr>
                                        <td colspan="6"></td>
                                    </tr>
                                    <tr>
                                        <td colspan="6"><b>Invoice Charges Breakout</b></td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">Risk Management&nbsp;<span id="spnRiskManagement" style="color: Red; display: none;" runat="server">*</span>
                                        </td>
                                        <td align="center" valign="top">:
                                        </td>
                                        <td align="left" valign="top">$&nbsp;<asp:TextBox ID="txtRiskManagement" runat="server" SkinID="txtCurrency15" Width="170px"
                                            onkeypress="return FormatNumber(event,this.id,13,false);" onpaste="return false" />
                                        </td>
                                        <td align="left" valign="top">Corporate Development/Real Estate&nbsp;<span id="spnCorporateDevelopment" style="color: Red; display: none;" runat="server">*</span>
                                        </td>
                                        <td align="center" valign="top">:
                                        </td>
                                        <td align="left" valign="top">$&nbsp;<asp:TextBox ID="txtCorporateDevelopment" runat="server" SkinID="txtCurrency15" Width="170px"
                                            onkeypress="return FormatNumber(event,this.id,13,false);" onpaste="return false" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">Store&nbsp;<span id="spnStore" style="color: Red; display: none;"
                                            runat="server">*</span>
                                        </td>
                                        <td align="center" valign="top">:
                                        </td>
                                        <td align="left" valign="top">$&nbsp;<asp:TextBox ID="txtStore" runat="server" SkinID="txtCurrency15" Width="170px" onkeypress="return FormatNumber(event,this.id,13,false);" onpaste="return false" />
                                        </td>
                                        <td colspan="3">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td colspan="6"><b>Vendor</b></td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" width="20%">Vendor&nbsp;<span id="spnVendor" style="color: Red; display: none;" runat="server">*</span>
                                        </td>
                                        <td align="center" valign="top" width="4%">:
                                        </td>
                                        <td align="left" valign="top" width="26%">&nbsp;<asp:TextBox ID="txtVendor" runat="server" MaxLength="75" Width="146px" />
                                        </td> 
                                        <td align="left" valign="top" width="20%">Vendor Address&nbsp;<span id="spnVendorAddress" style="color: Red; display: none;" runat="server">*</span>
                                        </td>
                                        <td align="center" valign="top" width="4%">:
                                        </td>
                                        <td align="left" valign="top" width="26%">&nbsp;<asp:TextBox ID="txtVendorAddress" runat="server" MaxLength="50" Width="146px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">Vendor City&nbsp;<span id="spnVendorCity" style="color: Red; display: none;" runat="server">*</span>
                                        </td>
                                        <td align="center" valign="top">:
                                        </td>
                                        <td align="left" valign="top">&nbsp;<asp:TextBox ID="txtVendorCity" runat="server" Width="146px" MaxLength="50" />
                                        </td>
                                        <td align="left" valign="top">Vendor State&nbsp;<span id="spnVendorState" style="color: Red; display: none;" runat="server">*</span>
                                        </td>
                                        <td align="center" valign="top">:
                                        </td>
                                        <td align="left" valign="top">&nbsp;<asp:DropDownList ID="ddlVendorState" runat="server"  Width="146px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top"  width="20%">Vendor Zip (XXXXX-XXXX)&nbsp;<span id="spnVendorZip" style="color: Red; display: none;" runat="server">*</span>
                                        </td>
                                        <td align="center" valign="top"  width="4%">:
                                        </td>
                                        <td align="left" valign="top"  width="26%">&nbsp;<asp:TextBox ID="txtVendorZip" runat="server" Width="146px" MaxLength="10" SkinID="txtZipCode" onKeyPress="javascript:return FormatZipCode(event,this.id);" />
                                            <asp:RegularExpressionValidator ID="revtxtVendorZip" runat="server" ErrorMessage="[Project Cost Invoice]/Vendor Zip is not valid"
                                                SetFocusOnError="true" ControlToValidate="txtVendorZip" ValidationExpression="\b[0-9]{5}-[0-9]{4}\b|\b[0-9]{5}\b"
                                                ValidationGroup="vsError" Display="none" />
                                        </td>
                                        <td align="left" valign="top"  width="20%">Vendor Contact Name&nbsp;<span id="spnVendorContactName" style="color: Red; display: none;" runat="server">*</span>
                                        </td>
                                        <td align="center" valign="top"  width="4%">:
                                        </td>
                                        <td align="left" valign="top"  width="26%">&nbsp;<asp:TextBox ID="txtVendorContactName" runat="server" MaxLength="76" Width="146px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top"  width="20%">Vendor Telephone (XXX-XXX-XXXX)&nbsp;<span id="spnVendorTelephone" style="color: Red; display: none;" runat="server">*</span>
                                        </td>
                                        <td align="center" valign="top"  width="4%">:
                                        </td>
                                        <td align="left" valign="top"  width="26%">&nbsp;<asp:TextBox ID="txtVendorTelephone" runat="server" Width="146px"
                                                MaxLength="12" onKeyPress="javascript:return FormatPhone(event,this.id);" />
                                            <asp:RegularExpressionValidator ID="revtxtVendorTelephone" ControlToValidate="txtVendorTelephone"
                                                runat="server" ErrorMessage="[Project Cost Invoice]/Vendor Contact Telephone in not valid."
                                                ValidationGroup="vsError" Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                        </td>
                                        <td align="left" valign="top"  width="20%">Vendor E-Mail&nbsp;<span id="spnVendorEmail" style="color: Red; display: none;" runat="server">*</span>
                                        </td>
                                        <td align="center" valign="top"  width="4%">:
                                        </td>
                                        <td align="left" valign="top"  width="26%">&nbsp;<asp:TextBox ID="txtVendorEmail" runat="server" Width="146px" MaxLength="255" />
                                            <asp:RegularExpressionValidator ID="RegtxtVendorEmail" runat="server"
                                                ControlToValidate="txtVendorEmail" Display="None" ErrorMessage="Please Enter Valid [Project Cost - Invoice]/ E-Mail Address"
                                                SetFocusOnError="True" ValidationGroup="vsError" ToolTip="Please Enter Valid [Project Cost]/ E-Mail Address"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="divView" runat="server" style="display: none;">
                                <div class="bandHeaderRow">
                                    Project Cost - Invoice
                                </div>
                                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                                    <tr>
                                        <td align="left" valign="top" width="20%">Invoice Number&nbsp;
                                        </td>
                                        <td align="center" valign="top" width="4%">:
                                        </td>
                                        <td align="left" valign="top" width="26%">
                                            <asp:Label ID="lblInvoiceNumber" runat="server" >
                                            </asp:Label>
                                        </td>
                                        <td align="left" valign="top" width="20%">Invoice Date&nbsp;
                                        </td>
                                        <td align="center" valign="top" width="4%">:
                                        </td>
                                        <td align="left" valign="top" width="26%">
                                            <asp:Label ID="lblInvoiceDate" runat="server">
                                            </asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" width="20%">Invoice Amount&nbsp;
                                        </td>
                                        <td align="center" valign="top" width="4%">:
                                        </td>
                                        <td align="left" valign="top" width="26%">$&nbsp;<asp:Label ID="lblInvoiceAmount" runat="server" />
                                        </td>
                                        <td colspan="3"></td>
                                    </tr>
                                    <tr>
                                        <td colspan="6"></td>
                                    </tr>
                                    <tr>
                                        <td colspan="6"><b>Invoice Charges Breakout</b></td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" width="20%">Risk Management&nbsp;
                                        </td>
                                        <td align="center" valign="top" width="4%">:
                                        </td>
                                        <td align="left" valign="top" width="26%">$&nbsp;<asp:Label ID="lblRiskManagement" runat="server" style="word-wrap:normal;word-break:break-all" />
                                        </td>
                                        <td align="left" valign="top" width="20%">Corporate Development/Real Estate&nbsp;
                                        </td>
                                        <td align="center" valign="top" width="4%">:
                                        </td> 
                                        <td align="left" valign="top" width="26%">$&nbsp;<asp:Label ID="lblCorporateDevelopment" runat="server" style="word-wrap:normal;word-break:break-all" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" width="20%">Store&nbsp;
                                        </td>
                                        <td align="center" valign="top" width="4%">:
                                        </td>
                                        <td align="left" valign="top" colspan="4">$&nbsp;<asp:Label ID="lblStore" runat="server" style="word-wrap:normal;word-break:break-all" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td colspan="6"><b>Vendor</b></td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" width="20%">Vendor&nbsp;
                                        </td>
                                        <td align="center" valign="top" width="4%">:
                                        </td>
                                        <td align="left" valign="top">&nbsp;<asp:Label ID="lblVendor" style="word-wrap:normal;word-break:break-all" runat="server" width="26%" />
                                        </td>
                                        <td align="left" valign="top" width="20%">Vendor Address&nbsp;
                                        </td>
                                        <td align="center" valign="top" width="4%">:
                                        </td>
                                        <td align="left" valign="top">&nbsp;<asp:Label ID="lblVendorAddress" width="26%" style="word-wrap:normal;word-break:break-all" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" width="20%">Vendor City&nbsp;
                                        </td>
                                        <td align="center" valign="top" width="4%">:
                                        </td>
                                        <td align="left" valign="top" width="26%">&nbsp;<asp:Label ID="lblVendorCity" runat="server"  style="word-wrap:normal;word-break:break-all"/>
                                        </td>
                                        <td align="left" valign="top" width="20%">Vendor State&nbsp;
                                        </td>
                                        <td align="center" valign="top" width="4%">:
                                        </td>
                                        <td align="left" valign="top" width="26%">&nbsp;<asp:Label ID="lblVendorState" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" width="20%">Vendor Zip (XXXXX-XXXX)&nbsp;
                                        </td>
                                        <td align="center" valign="top" width="4%">:
                                        </td>
                                        <td align="left" valign="top" width="26%">&nbsp;<asp:Label ID="lblVendorZip" runat="server" />
                                        </td>
                                        <td align="left" valign="top" width="20%">Vendor Contact Name&nbsp;
                                        </td>
                                        <td align="center" valign="top" width="4%">:
                                        </td>
                                        <td align="left" valign="top" width="26%">&nbsp;<asp:Label ID="lblVendorContactNumber" style="word-wrap:normal;word-break:break-all" runat="server" Width="170px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" width="20%">Vendor Telephone (XXX-XXX-XXXX)&nbsp;
                                        </td>
                                        <td align="center" valign="top" width="4%">:
                                        </td>
                                        <td align="left" valign="top" width="26%">&nbsp;<asp:Label ID="lblVendorTelephone" runat="server" />
                                        </td>
                                        <td align="left" valign="top" width="20%">Vendor E-Mail&nbsp;
                                        </td>
                                        <td align="center" valign="top" width="4%">:
                                        </td>
                                        <td align="left" valign="top" width="26%">&nbsp;<asp:Label ID="lblVendorEmail" style="word-wrap:normal;word-break:break-all" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top" colspan="2">
                <table border="0" cellpadding="3" cellspacing="1" width="100%">
                    <tr>
                        <td>
                            <asp:Button ID="btnSaveProject_Cost" Text="Save" runat="server" OnClick="btnSaveProject_Cost_OnClick"
                                CausesValidation="true" ValidationGroup="vsError" />&nbsp;
                            <asp:Button ID="btnCancel" Text="Cancel" runat="server" OnClick="btnCancel_OnClick" />&nbsp;
                            <asp:Button ID="btnProjectCost_Audit" Text="View Audit Trail" runat="server" OnClientClick="return AuditProjectCost()"
                                CausesValidation="false" Visible="false" />&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:CustomValidator ID="CustomValidatorProjectCost" runat="server" ErrorMessage=""
        ClientValidationFunction="ValidateFields" Display="None" ValidationGroup="vsError" />
    <input id="hdnControlIDsProjectCost" runat="server" type="hidden" />
    <input id="hdnErrorMsgsProjectCost" runat="server" type="hidden" />
    <script type="text/javascript">

        function ValidateFields(sender, args) {
            var msg = "", ctrlIDs = "", Messages = "", hdnID = "";

            ctrlIDs = document.getElementById('<%=hdnControlIDsProjectCost.ClientID%>').value.split(',');
            hdnID = '<%=hdnControlIDsProjectCost.ClientID%>';
            Messages = document.getElementById('<%=hdnErrorMsgsProjectCost.ClientID%>').value.split(',');

            var focusCtrlID = "";

            if (hdnID != "") {
                if (document.getElementById(hdnID).value != "") {
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
                else
                    args.IsValid = true;
            }
        }

        function AuditProjectCost() {
            var winHeight = window.screen.availHeight - 400;
            var winWidth = window.screen.availWidth - 300;

            obj = window.open("AuditPopup_EPM_Project_Cost_Invoice.aspx?id=" + '<%=ViewState["PK_EPM_Project_Cost_Invoice"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }

        function formatCurrencyOnBlur(ctrl) {
            if (ctrl.value != '') {
                var val = ctrl.value.replace(",", "").replace(",", "");
                ctrl.value = formatCurrency(val).replace("$", "");
            }
        }
    </script>
</asp:Content>

