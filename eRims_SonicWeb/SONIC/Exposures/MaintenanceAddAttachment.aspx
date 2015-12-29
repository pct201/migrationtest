<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="MaintenanceAddAttachment.aspx.cs" Inherits="SONIC_Exposures_MaintenanceAddAttachment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
</head>
<body>
    <script type="text/javascript">
        function ConfirmRemove() {
            return confirm("Are you sure you want to remove attachment?");
        }

        function ClosePage() {
            if ('<%= Convert.ToString(Request.QueryString["table"])  %>' != '' && '<%= Convert.ToString(Request.QueryString["table"]) %>' == "Facility_Construction_Maintenance_Item") {
                parent.parent.document.getElementById('ctl00_ContentPlaceHolder1_btnBindAttachmentGrid').click();
            }

            parent.parent.GB_hide();
            return false;
        }
    </script>
    <form id="form1" runat="server">
        <div>
            <asp:ValidationSummary ID="valPropertyCOPE" runat="server" ValidationGroup="ValAttach" ShowMessageBox="true" ShowSummary="false"
                HeaderText="Verify the following fields" BorderWidth="1" BorderColor="DimGray" CssClass="errormessage" />

            <div id="divAttachmentView" runat="server" visible="false">
                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                    <tr>
                        <td valign="top" style="width: 20%">Attachments Grid
                        </td>
                        <td align="center" valign="top" style="width: 3%">:
                        </td>
                        <td style="margin-left: 40px" style="width: 350px" align="left">
                            <asp:GridView ID="gvAttachmentDetailsView" runat="server" Width="100%" EmptyDataText="Currently there is no attachment." OnRowCommand="gvAttachmentDetails_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="File Name" HeaderStyle-HorizontalAlign="Left">
                                        <ItemStyle Width="30%" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkAttachFileView" runat="server" Text='<%# Eval("Attachment_Description").ToString().Substring(12, (Eval("Attachment_Description").ToString().Length-1) - 11)%>' CommandArgument='<%# Eval("Attachment_Description") %>'
                                                CommandName="DownloadAttachment" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                        HeaderText="Attached By">
                                        <ItemStyle Width="15%" />
                                        <ItemTemplate>
                                            <%# Eval("AttachedBy") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remove">
                                        <ItemStyle Width="5%" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkRemoveAttachmentView" runat="server" Text="Remove" CommandArgument='<%#Eval("PK_Attachment_Id") + ":" + Eval("Attachment_Description") %>'
                                                CommandName="RemoveAttachment" OnClientClick="return ConfirmRemove();" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>

            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td width="100%" class="Spacer" style="height: 30px;" colspan="4"></td>
                </tr>
                <tr>
                    <td width="15px">&nbsp;</td>
                    <td width="30%" align="left" valign="top">Attach Maintenance Documents
                    </td>
                    <td width="4%" align="center" valign="top">:</td>
                    <td align="left" valign="top">
                        <asp:FileUpload ID="fpFile" runat="server" CssClass="txtBox" />
                        <asp:RequiredFieldValidator ID="rvFile" ControlToValidate="fpFile"
                            ErrorMessage="Please select the File" runat="server" SetFocusOnError="true" ValidationGroup="ValAttach" Display="none" />
                    </td>
                </tr>
                <tr>
                    <td width="100%" class="Spacer" style="height: 10px;" colspan="4"></td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        <asp:Button ID="btnContinue" runat="server" Text="Add Attachment" OnClick="btnContinue_Click" ValidationGroup="ValAttach" />
                    </td>
                </tr>
                <tr>
                    <td width="100%" class="Spacer" style="height: 10px;" colspan="4"></td>
                </tr>
            </table>
        </div>
    </form>


</body>
</html>

