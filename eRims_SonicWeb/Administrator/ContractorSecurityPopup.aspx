<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="ContractorSecurityPopup.aspx.cs" Inherits="Administrator_ContractorSecurityPopup" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <script language="javascript" type="text/javascript">
        function ClosePopup(action) {
            if (action == "from")
                parent.parent.document.getElementById('ctl00_ContentPlaceHolder1_btnRefreshProjectGrid').click();
            parent.parent.GB_hide();
        }
    </script>
</head>
<body style="padding: 50px">
    <form id="form1" runat="server">
        <div>
            <table cellpadding="0" cellspacing="0" border="0" width="90%">
                <tr>
                    <td style="width: 200px;">
                        <asp:Label runat="server">Contractor Security User</asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList runat="server" ID="ddlContractorSecurity"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button runat="server" ID="btnCancel" Text="Cancel" OnClientClick="return ClosePopup();" />
                        <asp:Button runat="server" ID="btnSubmit" Text="Copy" OnClientClick="return CheckForm();" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
    <script type="text/javascript">
        function CheckForm() {
            var selectedContractorSecurityID =  document.getElementById('<%= ddlContractorSecurity.ClientID %>').value;
            if (selectedContractorSecurityID == "0") {
                 alert("Select contractor security user");
                 return false;
             }
         }
    </script>
</body>
</html>
