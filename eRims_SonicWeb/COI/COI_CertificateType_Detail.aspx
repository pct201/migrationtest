<%@ Page Language="C#" AutoEventWireup="true" CodeFile="COI_CertificateType_Detail.aspx.cs" Inherits="COI_COI_CertificateType_Detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript" src="../JavaScript/calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"></script>
    <script type="text/javascript" src="JavaScript/JFunctions.js"></script>
    <script type="text/javascript" src="../JavaScript/Validator.js"></script>
    <link href="../App_Themes/Default/Default.skin" type="text/css" rel="Skin" />
    <script language="javascript" type="text/javascript">
        function numberOnly(e) {
            var k;
            if (window.event) {
                k = event.keyCode;
            }
            else {
                k = e.which;
            }
            if (k == 8) {
                return true;
            }
            if ((k <= 47) || (k >= 58)) {
                if (window.event) {
                    window.event.returnValue = null;
                    return false;
                }
                else {
                    e.preventDefault();
                }
            }
            if (k == 8)
            { }
        }

        function ClosePopup() {
            parent.parent.document.getElementById('ctl00_ContentPlaceHolder1_btnhdnReload').click();
            parent.parent.GB_hide();
        }

        function ChangeTitle(PageTitle) {
            //window.top.document.querySelectorAll('.caption')[0].innerHTML = PageTitle;
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ValidationSummary ID="vsTheft" runat="server" ShowSummary="false" ShowMessageBox="true"
                HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
                ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>

            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="false" ShowMessageBox="true"
                HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
                ValidationGroup="vsErrorGroup4Evidance" CssClass="errormessage"></asp:ValidationSummary>

            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowSummary="false" ShowMessageBox="true"
                HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
                ValidationGroup="vsErrorGroup4certi" CssClass="errormessage"></asp:ValidationSummary>

            <asp:Panel ID="pnlChooseType" runat="server">
                <div class="bandHeaderRow" style="text-align: left">
                    Choose Certificate Type
                </div>
                <table cellpadding="0" cellspacing="0" border="0" width="100%" style="margin-left: auto; margin-right: auto; width: 290px; height: 275px;">
                    <tr>
                        <td width="100%" class="header_text">&nbsp;
                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                <tr>
                                    <td align="left" width="100%">
                                        <asp:RadioButtonList ID="rdoGeneralRequired" runat="server" Font-Size="10pt" CellPadding="1" CellSpacing="1" RepeatDirection="Vertical" RepeatColumns="1">
                                        </asp:RadioButtonList>
                                        <asp:RequiredFieldValidator ID="revIsRegionalOfficer" runat="server" ValidationGroup="vsErrorGroup"
                                            ErrorMessage="Please select one certificate type" InitialValue="" Display="none"
                                            ControlToValidate="rdoGeneralRequired"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Spacer" style="height: 10px;" width="100%"></td>
                                </tr>
                                <tr>
                                    <td align="center" width="100%">
                                        <asp:Button runat="server" ID="btnOK" Text="OK" OnClick="btnOK_Click" CausesValidation="true" ValidationGroup="vsErrorGroup" />
                                        &nbsp;
                                    <asp:Button runat="server" ID="btnCancelCertificateType" Text="Cancel" OnClick="btnCancelCertificateType_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="pnlCertOfLiabInsur" runat="server" Style="display: none;">
                <div class="bandHeaderRow" style="text-align: left">
                    Certificate of Liability Insurance
                </div>
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <%-- <tr>
                    <td  style="font-size: 12px;text-align: left;font-weight: bold;white-space: nowrap;padding:5px 20px 5px 5px; border-bottom:1px solid gray">Certificate of Liability Insurance
                    </td>
                </tr>--%>
                    <tr>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="3" cellspacing="1" border="0">
                                <tr>
                                    <td style="width: 25%" align="left">Date Issued
                                    </td>
                                    <td style="width: 2%" align="center">:
                                    </td>
                                    <td style="width: 25%" align="left">
                                        <asp:TextBox ID="txtDateIssued" runat="server" Width="120px" MaxLength="10" onkeypress="javascript:return FormatDate(event,this.id);" onpaste="return false;"></asp:TextBox>
                                        <img alt="" onclick="return showCalendar('txtDateIssued', 'mm/dd/y');"
                                            onmouseover="javascript:this.style.cursor='hand';" src="<%=AppConfig.SiteURL%>JavaScript/iconPicDate.gif"
                                            align="absmiddle" />
                                        <asp:RegularExpressionValidator ID="revDateOfProfile" runat="server" ControlToValidate="txtDateIssued"
                                            ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                            ErrorMessage="Please Enter Valid Date Issued" Display="none" SetFocusOnError="true"
                                            ValidationGroup="vsErrorGroup4certi">
                                        </asp:RegularExpressionValidator>
                                    </td>
                                    <td style="width: 20%" align="left">Signed Certificate?
                                    </td>
                                    <td style="width: 2%" align="center">:
                                    </td>
                                    <td style="width: 26%" align="left">
                                        <asp:RadioButtonList ID="rblSignedCerti" runat="server">
                                            <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                            <asp:ListItem Value="0" Text="No" Selected="True"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 25%" align="left" valign="top">Named as Additional Insured
                                    </td>
                                    <td style="width: 2%" align="center" valign="top">:
                                    </td>
                                    <td colspan="4" align="left">
                                        <asp:CheckBoxList ID="rblAdditionalInsured" runat="server" RepeatDirection="Vertical" RepeatColumns="1">
                                            <%--    <asp:ListItem Text="Sonic Automotive" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Master Landlord" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Mortgagee" Value="3"></asp:ListItem>--%>
                                        </asp:CheckBoxList>

                                        <%--  <asp:RadioButton ID="rblSonicAutomotive" runat="server" Text="Sonic Automotive" />
                                    <asp:RadioButton ID="rblMasterLandlord" runat="server" Text="Master Landlord" />
                                    <asp:RadioButton ID="rblMortgagee" runat="server" Text="Mortgagee" />--%>

                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 25%" align="left">Waver of Subrogation?
                                    </td>
                                    <td style="width: 2%" align="center">:
                                    </td>
                                    <td style="width: 25%" align="left">
                                        <asp:RadioButtonList ID="rblWaverOfSub" runat="server">
                                            <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                            <asp:ListItem Value="0" Text="No" Selected="True"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 25%" align="left">Certificate Includes Notice of Cancellation?
                                    </td>
                                    <td style="width: 2%" align="center">:
                                    </td>
                                    <td style="width: 25%" align="left">
                                        <asp:RadioButtonList ID="rblCertiIncludes" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rblCertiIncludes_SelectedIndexChanged">
                                            <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                            <asp:ListItem Value="0" Text="No" Selected="True"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td style="width: 20%" align="left">If Yes, Number of Days
                                    </td>
                                    <td style="width: 2%" align="center">:
                                    </td>
                                    <td style="width: 26%" align="left">
                                        <asp:TextBox ID="txtNoOfDays" runat="server" Width="145px" Enabled="false" onkeypress="return numberOnly(this);" MaxLength="4"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Spacer" style="height: 10px;"></td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="center">
                                        <asp:Button runat="server" ID="btnSave" Text="Save" OnClick="btnSave_Click" ValidationGroup="vsErrorGroup4certi" />
                                        <asp:Button runat="server" ID="btnCancel" Text="Cancel" OnClick="btnCancel_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="pnlEviOfCPI" runat="server" Style="display: none;">
                <div class="bandHeaderRow" style="text-align: left">
                    Evidence of Commercial Property Insurance
                </div>
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <%-- <tr>
                    <td style="font-size: 12px;text-align: left;font-weight: bold;white-space: nowrap;padding:5px 20px 5px 5px; border-bottom:1px solid gray">Evidence of Commercial Property Insurance
                    </td>
                </tr>--%>
                    <tr>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="3" cellspacing="1" border="0">
                                <tr>
                                    <td style="width: 20%" align="left">Date Issued
                                    </td>
                                    <td style="width: 2%" align="center">:
                                    </td>
                                    <td style="width: 28%" align="left">
                                        <asp:TextBox ID="txtEvi_DateIssued" runat="server" Width="120px" MaxLength="10" onkeypress="javascript:return FormatDate(event,this.id);" onpaste="return false;"></asp:TextBox>
                                        <img alt="" onclick="return showCalendar('txtEvi_DateIssued', 'mm/dd/y');"
                                            onmouseover="javascript:this.style.cursor='hand';" src="<%=AppConfig.SiteURL%>JavaScript/iconPicDate.gif"
                                            align="absmiddle" />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEvi_DateIssued"
                                            ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                            ErrorMessage="Please Enter Valid Date Issued" Display="none" SetFocusOnError="true"
                                            ValidationGroup="vsErrorGroup4Evidance">
                                        </asp:RegularExpressionValidator>
                                    </td>
                                    <td style="width: 20%" align="left">Signed Certificate?
                                    </td>
                                    <td style="width: 2%" align="center">:
                                    </td>
                                    <td style="width: 28%" align="left">
                                        <asp:RadioButtonList ID="rblEvi_SignedCerti" runat="server">
                                            <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                            <asp:ListItem Value="0" Text="No" Selected="True"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" align="left" valign="top">Additional Interest
                                    </td>
                                    <td style="width: 2%" align="center" valign="top">:
                                    </td>
                                    <td colspan="4" align="left">
                                        <asp:CheckBoxList ID="rblEvi_AddInterest" runat="server" RepeatDirection="Vertical" RepeatColumns="1">
                                            <%--  <asp:ListItem Text="Mortgagee" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="Lenders Loss Payee" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="Contract of Sale" Value="6"></asp:ListItem>
                                        <asp:ListItem Text="Master Landlord of Location" Value="7"></asp:ListItem>--%>
                                        </asp:CheckBoxList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" align="left">Mortgage Clause Not Required?
                                    </td>
                                    <td style="width: 2%" align="center">:
                                    </td>
                                    <td style="width: 28%" align="left">
                                        <asp:RadioButtonList ID="rblMasterNoReq" runat="server">
                                            <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                            <asp:ListItem Value="0" Text="No" Selected="True"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" align="left">Loss Payee Not Required?
                                    </td>
                                    <td style="width: 2%" align="center">:
                                    </td>
                                    <td style="width: 28%" align="left">
                                        <asp:RadioButtonList ID="rblLossPayee" runat="server">
                                            <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                            <asp:ListItem Value="0" Text="No" Selected="True"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Spacer" style="height: 10px;"></td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="center">
                                        <asp:Button runat="server" ID="btnEVI_Save" Text="Save" OnClick="btnEVI_Save_Click" ValidationGroup="vsErrorGroup4Evidance" />
                                        <asp:Button runat="server" ID="btnEVI_Cancel" Text="Cancel" OnClick="btnEVI_Cancel_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
