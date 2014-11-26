<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="FirstReportTypeAdd.aspx.cs" 
Inherits="SONIC_FirstReportTypeAdd" Title="eRIMS Sonic :: First Report :: First Report Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ValidationSummary ID="vsSonicHeader" runat="server" ShowSummary="false" ShowMessageBox="true"
    HeaderText="Verify the following fields :" BorderWidth="1" BorderColor="DimGray"
    ValidationGroup="AddFirstReport" CssClass="errormessage"></asp:ValidationSummary> 
<table cellpadding="0" cellspacing="0" width="100%">
<tr>
        <td class="groupHeaderBar" align="left">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="Spacer" style="height: 20px;">
        </td>
    </tr>
    <tr>
        <td>
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td style="width: 200px;" colspan="6" class="bandHeaderRow">
                        Add First Report Wizard
                    </td>
                </tr>
                <tr>
                    <td colspan="6"> &nbsp;</td>
                </tr>
                <tr>
                    <td align="left" style="width:18%">&nbsp;&nbsp;Specify First Report Type to add:</td>
                    <td align="center" style="width:4%">:</td>
                    <td align="left" style="width:28%">
                        <asp:DropDownList runat="server" ID="ddlFirstReportType" SkinID="ddlSONIC">
                        <asp:ListItem Value="0" Text="-- Select --"></asp:ListItem>
                        <asp:ListItem Value="WC" Text="Worker's Compensation"></asp:ListItem>
                        <asp:ListItem Value="AL" Text="Auto Liability"></asp:ListItem>
                        <asp:ListItem Value="DPD" Text="Dealer Physical Damage"></asp:ListItem>
                        <asp:ListItem Value="Property" Text="Property"></asp:ListItem>
                        <asp:ListItem Value="PL" Text="Premises Liability"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ID="rfvAddFR" ErrorMessage="Please select First Reoprt Type" Display="None"
                        ValidationGroup="AddFirstReport" InitialValue="0" ControlToValidate="ddlFirstReportType"></asp:RequiredFieldValidator>
                     </td>
                     <td  style="width:18%">&nbsp;</td>
                     <td  style="width:4%">&nbsp;</td>
                     <td  style="width:28%">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="6" align="center">
                        <asp:Button runat="server" ID="btnContinue" Text="Continue" OnClick="btnContinue_Click" CausesValidation="true" ValidationGroup="AddFirstReport" />
                    </td>
                </tr>
                <tr>
                    <td colspan="6"> &nbsp;</td>
                </tr>
          </table>
        </td>
    </tr>
</table>
</asp:Content>

