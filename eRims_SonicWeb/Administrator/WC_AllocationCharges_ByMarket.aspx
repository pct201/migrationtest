<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="WC_AllocationCharges_ByMarket.aspx.cs"
    Inherits="Administrator_WC_AllocationCharges_ByMarket" Title="eRIMS Sonic :: WC Allocation Charges" %>

<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Validator.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Date_Validation.js"></script>

    <script language="javascript" type="text/javascript">
        //check Date Validation
        function CheckDate(sender, args) {
            args.IsValid = (ValidateDate(args.Value));
            return args.IsValid;
        }

        //check Numeric Validation
        function CheckNumber(sender, args) {
            args.IsValid = IsNumericNoAlert(RemoveCommas(args.Value));
            return args.IsValid;
        }

        function AuditPopUp() {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;

            obj = window.open("AuditPopup_WC_AllocationCharges_ByMarket.aspx?id=" + '<%=PK_WC_Allocation_Charges_ByMarket%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }
    </script>

    <div>
        <asp:UpdateProgress runat="server" ID="upProgress" DisplayAfter="100">
            <ProgressTemplate>
                <div class="UpdatePanelloading" id="divProgress" style="width: 100%;">
                    <table id="ProgressTable" cellpadding="0" cellspacing="0" border="0" style="width: 100%; height: 100%;">
                        <tr align="center" valign="middle">
                            <td class="LoadingText" align="center" valign="middle">
                                <img src="../Images/indicator.gif" alt="Loading" />&nbsp;&nbsp;&nbsp;Please Wait..
                            </td>
                        </tr>
                    </table>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
    <asp:ValidationSummary ID="vsError" runat="server" ShowMessageBox="true" ShowSummary="false"
        HeaderText="Please Verify following fields." />
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td class="bandHeaderRow">
                <b>&nbsp;Adjust Past Charge By Market</b>
            </td>
        </tr>
        <tr>
            <td align="center" style="padding-left: 100px; padding-top: 10px;">
                <asp:Panel ID="pnlEditWC_Allocation" runat="server">
                    <table width="80%" cellpadding="3" cellspacing="3" style="text-align: left; vertical-align: top;">
                        <tr valign="top">
                            <td style="width: 22%;">First Report Number
                            </td>
                            <td style="width: 2%;">:
                            </td>
                            <td style="width: 26%;">
                                <asp:Label ID="lblFirstReportNumber" runat="server"></asp:Label>
                            </td>
                            <td style="width: 20%;">Charge Type <span class="mf">*</span>
                            </td>
                            <td style="width: 3%;">:
                            </td>
                            <td style="width: 27%;">
                                <asp:Label ID="lblChargeType" runat="server"></asp:Label>
                                <asp:DropDownList ID="ddlChargeType" runat="server">
                                    <asp:ListItem Text="---SELECT---" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Early Close Credit" Value="Early Close Credit"></asp:ListItem>
                                    <asp:ListItem Text="Initial Charge" Value="Initial Charge"></asp:ListItem>
                                    <asp:ListItem Text="Lag Charge" Value="Lag Charge"> </asp:ListItem>
                                    <asp:ListItem Text="Lag Credit" Value="Lag Credit"></asp:ListItem>
                                    <asp:ListItem Text="Reopen Charge" Value="Reopen Charge"></asp:ListItem>
                                    <asp:ListItem Text="Nurse Triage Credit" Value="Nurse Triage Credit"></asp:ListItem>
                                    <asp:ListItem Text="Incident Investigation Credit" Value="Incident Investigation Credit"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvChargeType" runat="server" ControlToValidate="ddlChargeType"
                                    InitialValue="0" SetFocusOnError="true" ErrorMessage="Please select Charge Type."
                                    Display="None"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr valign="top">
                            <td>Charge Date <span class="mf">*</span>
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblChargeDate" runat="server"></asp:Label>
                                <div runat="server" id="pnlChargeDate" visible="false">
                                    <asp:TextBox ID="txtChargeDate" runat="server" SkinID="txtdate" Width="80px" MaxLength="10"></asp:TextBox>
                                    <img alt="Charge Date" id="imgChargeDate" onclick="return showCalendar('<%=txtChargeDate.ClientID%>', 'mm/dd/y','','');"
                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                        align="middle" />
                                    <asp:RequiredFieldValidator ID="rfvtxtChargeDate" runat="server" ControlToValidate="txtChargeDate"
                                        ErrorMessage="Please Enter Charge Date." Display="None" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="cvtxtChargeDate" runat="server" ControlToValidate="txtChargeDate"
                                        ClientValidationFunction="CheckDate" ErrorMessage="Charge Date is not valid."
                                        SetFocusOnError="true" Display="None">
                                    </asp:CustomValidator>
                                </div>
                            </td>
                            <td>Change login
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblChange_login" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr valign="top">
                            <td>Charge<span class="mf">*</span>
                            </td>
                            <td>:
                            </td>
                            <td valign="top">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>$
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCharge" runat="server" onpaste="return false" onkeypress="return currencyFormatNegetive(this,',','.',event);"
                                                MaxLength="22"></asp:TextBox>
                                            <asp:Label ID="lblCharge" runat="server" Visible="false"></asp:Label>
                                            <asp:RequiredFieldValidator ID="rfvtxtCharge" runat="server" ControlToValidate="txtCharge"
                                                ErrorMessage="Please Enter Charge." Display="None" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            <%-- <asp:RegularExpressionValidator ID="revtxtCharge" ControlToValidate="txtCharge" runat="server"
                                                ErrorMessage="Please Enter the valid Charge." SetFocusOnError="true" Display="none"
                                                ValidationExpression="^\d{1,3}(,\d\d\d)*\.\d\d$"></asp:RegularExpressionValidator>--%>
                                            <asp:CustomValidator ID="revtxtCharge" runat="server" ControlToValidate="txtCharge"
                                                ClientValidationFunction="CheckNumber" ErrorMessage="Charge is not valid." SetFocusOnError="true"
                                                Display="None">
                                            </asp:CustomValidator>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr valign="top">
                            <td valign="top">Change Explanation<span class="mf">*</span>
                            </td>
                            <td valign="top">:
                            </td>
                            <td colspan="4" valign="top">
                                <uc:ctrlMultiLineTextBox ID="txtChange_Explanation" runat="server" ControlType="TextBox"
                                    SetFocusOnError="true" IsRequired="true" RequiredFieldMessage="Please Enter Change Explanation" />
                            </td>
                        </tr>
                        <tr valign="top">
                            <td colspan="6" align="center">
                                <asp:Button ID="btnSave" Text="Save & View" runat="server" OnClick="btnSave_Click"
                                    CausesValidation="true" />
                                <asp:Button ID="btnBack" Text="Back" runat="server" OnClick="btnBack_Click" CausesValidation="false" />
                                <asp:Button ID="btnAudit" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlViewWC_Allocation" runat="server">
                    <table width="80%" cellpadding="3" cellspacing="3" style="text-align: left;">
                        <tr>
                            <td style="width: 20%;">First Report Number
                            </td>
                            <td style="width: 3%;">:
                            </td>
                            <td style="width: 27%;">
                                <asp:Label ID="lblvFirstReportNumber" runat="server"></asp:Label>
                            </td>
                            <td style="width: 20%;">Charge Type
                            </td>
                            <td style="width: 3%;">:
                            </td>
                            <td style="width: 27%;">
                                <asp:Label ID="lblvChargeType" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Charge Date
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblvChargeDate" runat="server"></asp:Label>
                            </td>
                            <td>Change login
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblvChange_login" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Charge
                            </td>
                            <td>:
                            </td>
                            <td valign="top">
                                <asp:Label ID="lblvCharge" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">Change Explanation
                            </td>
                            <td valign="top">:
                            </td>
                            <td colspan="4" valign="top">
                                <uc:ctrlMultiLineTextBox ID="lblChange_Explanation" runat="server" ControlType="label" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center">
                                <asp:Button ID="btnEdit" Text=" Edit " runat="server" OnClick="btnEdit_Click" />
                                <asp:Button ID="btnvBack" Text="Back To Search" runat="server" OnClick="btnBackSearch_Click" />
                                <asp:Button ID="btnVBackSearchResult" Text="Back to Search Results" runat="server"
                                    OnClick="btnBack_Click" Width="187px" />
                                <asp:Button ID="btnvAudit" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
