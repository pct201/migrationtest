<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="rptPARImport.aspx.cs" Inherits="SONIC_Exposures_rptPARImport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function ValFileImport() {
            if (document.getElementById('<%=fpFile.ClientID%>').value != '')
                return true;
            else {
                alert("Please Select File To Import");
                return false;
            }
        }
    </script>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="ghc" colspan="2">
                <b>Premium Allocation Report Import</b>
            </td>
        </tr>
        <tr>
            <td style="height: 50px;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td width="10%">
                &nbsp;
            </td>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td width="24%" align="right">
                            Premium Allocation Report Spreadsheet File
                        </td>
                        <td width="4%" align="center">
                            :
                        </td>
                        <td align="left">
                            <asp:FileUpload ID="fpFile" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:Button ID="btnImport" runat="server" Text="Import" OnClick="btnImport_Click"
                                OnClientClick="return ValFileImport();" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 50px;">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
