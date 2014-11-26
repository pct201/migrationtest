<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="DeleteFirstReport.aspx.cs"
    Inherits="Administrator_DeleteFirstReport" Title="eRIMS Sonic :: Delete First Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
    function CheckConfirm()
    {
        if(Page_ClientValidate("vsErrorGroup"))
        {
            if(confirm('Are you sure you want to delete this record?'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
            return false;
        
    }
    </script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Validator.js"></script>

    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td class="bandHeaderRow" colspan="4" align="left">
                Delete First Report
            </td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <table width="100%" cellpadding="3" cellspacing="1" border="0">
                    <tr>
                        <td colspan="6" align="center">
                            <table cellpadding="3" cellspacing="1" align="center" width="100%">
                                <tr>
                                    <td colspan="5">&nbsp;<asp:Label runat="server" ID="lblError" CssClass="error" EnableViewState="false"></asp:Label>&nbsp;</td>
                                </tr>
                                
                                <tr>
                                    <td style="width: 35%">
                                        &nbsp;
                                    </td>
                                    <td style="width: 16%;" align="left">
                                        First Report Type<span style="color: Red;">*</span>
                                    </td>
                                    <td style="width: 4%;" align="Center">
                                        :
                                    </td>
                                    <td align="left" style="width: 10%;">
                                        <asp:DropDownList runat="server" ID="ddlFirstReportType" SkinID="ddlSONIC">
                                            <asp:ListItem Value="0" Text="-- Select --"></asp:ListItem>
                                            <asp:ListItem Value="WC" Text="Worker's Compensation"></asp:ListItem>
                                            <asp:ListItem Value="AL" Text="Auto Liability"></asp:ListItem>
                                            <asp:ListItem Value="DPD" Text="Dealer Physical Damage"></asp:ListItem>
                                            <asp:ListItem Value="Property" Text="Property"></asp:ListItem>
                                            <asp:ListItem Value="PL" Text="Premises Liability"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator runat="server" ID="rfvAddFR" ErrorMessage="Please select First Reoprt Type"
                                            Display="None" ValidationGroup="vsErrorGroup" InitialValue="0" ControlToValidate="ddlFirstReportType"
                                            SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </td>
                                    <td style="width: 35%">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="left">
                                        First Report Number<span style="color: Red;">*</span>
                                    </td>
                                    <td align="center">
                                        :
                                    </td>
                                    <td align="left">
                                        <asp:TextBox runat="server" ID="txtFirstReportNumber" Width="170px" onKeyPress="return FormatInteger(event);"
                                            MaxLength="12"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="REVFirstReportNumber" runat="server" ControlToValidate="txtFirstReportNumber"
                                            Display="none" SetFocusOnError="true" ErrorMessage="First Report Number must be numeric"
                                            ValidationExpression="^\d+$" ValidationGroup="vsErrorGroup" ></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator runat="server" ID="rfvFirstReportNumber" ErrorMessage="Please Enter First Report Number"
                                            Display="None" ValidationGroup="vsErrorGroup" ControlToValidate="txtFirstReportNumber" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5" align="center">
                                        <asp:Button runat="server" ID="btnDelete" Text="Delete" CausesValidation="false"
                                            ValidationGroup="vsErrorGroup" OnClick="btnDelete_Click" OnClientClick="javascript:return CheckConfirm()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
