<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="OtherLiabilityPolicies.aspx.cs"
    Inherits="Administration_OtherLiabilityPolicies" Title="Maintenance :: Other Liability Type" %>

<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="Spacer" style="height: 10px;" colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="2" class="bandHeaderRow" style="height: 20px;" align="left">
                Other Policy Types
            </td>
        </tr>
        <tr>
            <td align="center">
                <div id="dvAddMode" runat="server" style="display: none;">
                    <table width="45%">
                        <tr>
                            <td>
                                Policy Name<span class="msg1">*</span>&nbsp;: </td>
                            <td align="left">
                                <asp:TextBox ID="txtPolicyName" runat="server" MaxLength="50" />
                                <asp:HiddenField ID="hdnPK" runat="server" Value="0" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPolicyName"
                                    ErrorMessage="Please enter Policy Name" Display="None" ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="Spacer" style="height: 10px;" colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btnSave" Text="Save" runat="server" OnClick="btnSave_Click" ValidationGroup="vsErrorGroup" />&nbsp;&nbsp;
                                <asp:Button ID="btnCancel" Text="Cancel" runat="server" CausesValidation="False"
                                    OnClick="btnCancel_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:HiddenField ID="hdnPKOtherPolicyTypes" Value="" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <div id="dvResult" runat="server">
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td width="100%" class="Spacer" style="height: 5px;">
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-right: 5px;">
                    <table cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td align="right" colspan="2">
                                &nbsp;<span class="pagingfont"><b>Search</b></span>&nbsp; &nbsp;
                                <asp:TextBox ID="txtSearch" runat="server" Width="70px" MaxLength="30" CssClass="pagingfields"></asp:TextBox>&nbsp;
                                <asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" Text="Search"
                                    CssClass="pagingfields" />
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" colspan="2" class="Spacer" style="height: 6px;">
                            </td>
                        </tr>
                        <tr>
                            <td width="45%">
                                &nbsp;&nbsp; <span class="heading">Other Policy Types</span><br />
                                &nbsp;&nbsp; Total Records:&nbsp;<asp:Label ID="lblNumber" runat="server" Text="5"></asp:Label>
                            </td>
                            <td valign="top" align="right">
                                <uc:ctrlPaging ID="ctrlPageSecurity" runat="server" OnGetPage="GetPage" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="Spacer" style="height: 10px;">
                </td>
            </tr>
            <tr>
                <td class="dvContent">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td class="Spacer" style="height: 10px;">
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:GridView ID="gvPolicyTypes" Width="100%" AllowPaging="false" runat="server"
                                    OnRowCommand="gvPolicyTypes_RowCommand" OnRowDataBound="gvPolicyTypes_RowDataBound"
                                    OnRowCreated="gvPolicyTypes_RowCreated" OnSorting="gvSecurity_Sorting">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Policy Name" SortExpression="Fld_Desc">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="80%" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemTemplate>
                                                <%#Eval("Fld_Desc")%>
                                                <input type="hidden" id="hdnID" runat="server" value='<%#Eval("PK_Other_Policy_Types")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Disposition">
                                            <HeaderStyle HorizontalAlign="center" />
                                            <ItemStyle HorizontalAlign="center" Width="20%" />
                                            <ItemTemplate>
                                                <asp:Button ID="btnEdit" Text="Edit" runat="server" CommandName="UpdatePT" Width="50px"
                                                    CommandArgument='<%#Eval("PK_Other_Policy_Types")%>' />
                                                &nbsp;&nbsp;&nbsp;<asp:Button ID="btnDelete" Text="Delete" OnClientClick="return confirm('Are you sure that you want to remove the data that was selected for deletion?');"
                                                    runat="server" CommandName="DeleteDT" CommandArgument='<%#Eval("PK_Other_Policy_Types")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td width="100%" class="Spacer" style="height: 20px;">
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnAddNew" runat="server" SkinID="AddNew" OnClick="btnAddPolicy_Click" />&nbsp;
                </td>
            </tr>
            <tr>
                <td width="100%" class="Spacer" style="height: 20px;">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
