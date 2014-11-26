<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="ImportOhioWCClaim.aspx.cs" Inherits="SONIC_ClaimInfo_ImportOhioWCClaim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="width: 100%;">
          <br />
        <div class="bandHeaderRow">
            Import Ohio WC Claim Information From SpreadSheet
        </div>
    </div>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            EnableClientScript="true" ValidationGroup="vgSubmit" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <table width="100%">
        <tr>
            <td class="Spacer" style="height:10px;"></td>
        </tr>
        <tr>
            <td align="center">
                <table width="100%" cellpadding="3" cellspacing="3">
                    <tr>
                        <td width="40%" align="right">Select File&nbsp;<span id="Span2" style="color: Red;" runat="server">*</span></td>
                        <td width="2%" align="center">:</td>
                        <td width="58%" align="left">
                            <asp:FileUpload ID="fupFile" runat="server" Width="200px" />
                            <asp:RequiredFieldValidator ID="rfvFupFile" runat="server" Display="None" ControlToValidate="fupFile" SetFocusOnError="true" ValidationGroup="vgSubmit" ErrorMessage="Please Select File"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3" align="center">
                            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" ValidationGroup="vgSubmit" Text="Submit" />&nbsp;
                            <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Text="Cancel" OnClick="btnCancel_Click"  />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

