<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="SabaTrainingImportExport.aspx.cs" Title="Saba Training Export/Import" Inherits="Administrator_SabaTrainingImportExport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <script language="javascript" type="text/javascript">
     function OpenPopup(totalCount,strFilePath, strFileURL)
     { 
        var w = 500, h = 300;

        var navigationurl = '<%=AppConfig.SiteURL%>Administrator/SabaTrainingFolloeUp.aspx?total=' + totalCount + "&fPath=" + strFilePath + "&fUrl=" + strFileURL;
            if (document.all || document.layers) {
                w = screen.availWidth;
                h = screen.availHeight;
            }
            var leftPos, topPos;
            var popW = 530, popH = 300;
            if (document.all)
            { leftPos = (w - popW) / 2; topPos = (h - popH) / 2; }
            else
            { leftPos = w / 2; topPos = h / 2; }

            window.open(navigationurl, "popup", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=" + popW + ",height=" + popH + ",top=" + topPos + ",left=" + leftPos);
     }
    </script>
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>    
       <table cellpadding="0" cellspacing="0" width="100%" border="0">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td class="bandHeaderRow" align="left">
                            Saba Training Import
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <span class="heading">&nbsp; </span>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table width="80%" cellpadding="5" cellspacing="1" border="0">
                                <tr>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="35%">
                                        <b>To Export Saba Training Spreadsheet File, Click Here :</b>
                                        <asp:GridView ID="gvSabaTraining" runat="server" EnableTheming="false" style="display:none" AutoGenerateColumns="true" HeaderStyle-HorizontalAlign="Left">
                                            <HeaderStyle Font-Bold="true" HorizontalAlign="Left"/>
                                        </asp:GridView>
                                    </td>
                                    <td align="left">
                                        <asp:Button ID="btnExport" runat="server" Text="Export" 
                                            onclick="btnExport_Click" CausesValidation="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">
                                        <b>Saba Training Import</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="35%">
                                        Updated Saba Training Spreadsheet File :
                                    </td>
                                    <td align="left">
                                        <asp:FileUpload ID="fldImport" runat="server" />
                                        <asp:RequiredFieldValidator ID="rfvImport" runat="server" ControlToValidate="fldImport" ErrorMessage="Please select Policy Spreadsheet File to import" Display="None" ValidationGroup="vsErrorGroup" SetFocusOnError="true"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="left">
                                        <asp:Button ID="btnImport" runat="server" Text="Import" OnClick="btnImport_Click" CausesValidation="true" ValidationGroup="vsErrorGroup" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;
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


