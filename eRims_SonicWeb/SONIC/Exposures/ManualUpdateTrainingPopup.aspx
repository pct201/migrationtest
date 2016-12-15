<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="ManualUpdateTrainingPopup.aspx.cs" Inherits="SONIC_Exposures_ManualUpdateTrainingPopup" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Risk Insurance Management System</title>
</head>
<script type="text/javascript">

    function closepopup() {

        window.opener.document.getElementById('ctl00_ContentPlaceHolder1_btnhdnReload').click();
        window.close();
    }
</script>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
                HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
                ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
        </div>
        <table cellspacing="0" width="100%">
            <tr style="height: 20px;" align="left">
                <td class="PropertyInfoBG" colspan="6">Manually Update Training Data
                </td>
            </tr>
            <tr>
                <td colspan="6">&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="6">&nbsp;
                </td>
            </tr>
            <tr>
                <td align="left" class="lc" width="10%">Associate<span id="Span2" style="color: Red;" runat="server">*</span>
                </td>
                <td align="center" class="lc" valign="top" width="4%">:
                </td>
                <td align="left" class="lc" width="36%">
                    <asp:DropDownList ID="ddlAssociate" runat="server" Width="180px" SkinID="ddlSONIC">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvYear" Display="none" runat="server" ControlToValidate="ddlAssociate"
                        ErrorMessage="Please Select Associate." Text="*" ValidationGroup="vsErrorGroup" InitialValue="0">
                    </asp:RequiredFieldValidator>
                </td>
                <td align="left" class="lc" width="10%">Class <span id="Span1" style="color: Red;" runat="server">*</span>
                </td>
                <td align="center" class="lc" valign="top" width="4%">:
                </td>
                <td align="left" class="lc" width="36%">
                    <asp:DropDownList ID="ddlClass" runat="server" Width="180px" SkinID="ddlSONIC">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvClass" Display="none" runat="server" ControlToValidate="ddlClass"
                        ErrorMessage="Please Select Class." Text="*" ValidationGroup="vsErrorGroup" InitialValue="0">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <table align="center">
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="6">
                    <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vsErrorGroup" CausesValidation="true" OnClick="btnSave_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClientClick="closepopup();" OnClick="btnCancel_Click" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
        </table>

    </form>
</body>
</html>
