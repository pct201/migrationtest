<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="AttachmentFolders.aspx.cs" Inherits="Administrator_AttachmentFolders" %>

<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields :" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errorMessage"></asp:ValidationSummary>
    <br />
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100%" class="bandHeaderRow">
                Administrator :: Document Folder Maintenance
            </td>
        </tr>
        <tr>
            <td width="100%">
                <asp:Panel ID="pnlGrid" runat="server" Width="100%">
                    <table cellpadding="5" cellspacing="1" width="100%">
                        <tr>
                            <td width="100%" align="right">
                                <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" class="Spacer" style="height: 5px;">
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td width="100%" colspan="2" class="Spacer" style="height: 6px;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="45%">
                                            &nbsp;Total Records:&nbsp;<asp:Label ID="lblNumber" runat="server" Text="5"></asp:Label>
                                        </td>
                                        <td valign="top" align="right">
                                            <uc:ctrlPaging ID="ctrlPageSecurity" runat="server" OnGetPage="GetPage" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" class="Spacer" style="height: 10px;">
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:GridView ID="gvFolders" runat="server" AutoGenerateColumns="false" Width="100%"
                                    OnRowCommand="gvFolders_RowCommand" HeaderStyle-HorizontalAlign="Left" EmptyDataText="No Record Found" AllowPaging="false">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Module">
                                            <ItemStyle Width="20%" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblMajorCoverage" runat="server" Text='<%# Eval("Major_Coverage") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Folder">
                                            <ItemStyle Width="60%" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblFolder" runat="server" Text='<%# Eval("Folder_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemStyle Width="20%" HorizontalAlign="Right" />
                                            <ItemTemplate>
                                                <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="EditDetails" CommandArgument='<%# Eval("PK_Attachment_Folder") %>' />&nbsp;
                                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="DeleteDetails"
                                                    CommandArgument='<%# Eval("PK_Virtual_Folder") %>' OnClientClick="return confirm('Are you sure that you want to delete selected record(s)?');" />&nbsp;
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlAddEdit" runat="server" Width="100%" Visible="false">
                    <br />
                    <table cellpadding="3" cellspacing="1" width="80%" align="center">
                        <tr>
                            <td colspan="2">
                            </td>
                            <td align="left">
                                &nbsp;<asp:Label ID="lblError" runat="server" SkinID="lblError" EnableViewState="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="18%" align="left">
                                Folder Name&nbsp;<span style="color: Red">*</span>
                            </td>
                            <td width="4%" align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtFolderName" runat="server" Width="95%" MaxLength="255" />
                                <asp:RequiredFieldValidator ID="rfvFolderName" runat="server" ControlToValidate="txtFolderName"
                                    ErrorMessage="Please enter Folder Name" ValidationGroup="vsErrorGroup" Display="None" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                Module&nbsp;<span style="color: Red">*</span>
                            </td>
                            <td align="center" valign="top">
                                :
                            </td>
                            <td align="left" valign="top">
                                <asp:CheckBoxList ID="chkMajorCoverage" runat="server">
                                    <asp:ListItem Text="Event" Value="18" />
                                </asp:CheckBoxList>
                                <asp:CustomValidator ID="cvMajorCoverage" runat="server" ErrorMessage="Please select Module(s)"
                                    ClientValidationFunction="CheckMajCov" ValidationGroup="vsErrorGroup" Display="None" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center">
                                <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vsErrorGroup"
                                    OnClick="btnSave_Click" />&nbsp;
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        function CheckMajCov(object, args) {
            var ctrls = document.getElementsByTagName('input');
            var i, cnt = 0;
            for (i = 0; i < ctrls.length; i++) {
                if (ctrls[i].type == "checkbox") {
                    if (ctrls[i].checked) {
                        cnt++;
                    }
                }
            }

            if (cnt > 0)
                args.IsValid = true;
            else
                args.IsValid = false;

        }
    </script>
</asp:Content>
