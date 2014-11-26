<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="LU_SIC.aspx.cs" Inherits="Administrator_LU_SIC" %>
<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
    function AddNewGroup() {
        document.getElementById('<%=trStatusAdd.ClientID %>').style.display = "block";
        document.getElementById('<%=lnkCancel.ClientID %>').style.display = "inline";
    }

    function CheckValidation() {
        if (Page_ClientValidate("vsError")) {
        }
    }
 
    </script>

    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields :" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsError" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <asp:UpdatePanel runat="server" ID="updStatus">
        <ContentTemplate>
            <table cellspacing="0" cellpadding="0" width="100%">
                <tbody>
                    <tr>
                        <td colspan="4">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="bandHeaderRow" align="left" colspan="4">
                            Administrator :: SIC
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5%">
                            &nbsp;
                        </td>
                        <td align="left" colspan="2">
                            <table cellpadding="3" cellspacing="0" width="100%">
                                <tr>
                                    <td width="40%">&nbsp;</td>
                                    <td valign="top" align="right">
                                        <uc:ctrlPaging ID="ucPaging" runat="server" OnGetPage="GetPage" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 5%">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5%">
                            &nbsp;
                        </td>
                        <td align="center" colspan="2">
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td align="left">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:GridView ID="gvSIC" runat="server" Width="100%" AutoGenerateColumns="false"
                                                EnableViewState="true" AllowPaging="false" OnRowCommand="gvSIC_RowCommand">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Code">
                                                        <ItemStyle Width="10%" />
                                                        <ItemTemplate>
                                                            <%#Eval("Fld_Code")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Level 1 Description">
                                                        <ItemStyle Width="27%" />
                                                        <ItemTemplate>
                                                            <%#Eval("Fld_Desc_1")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Level 2 Description">
                                                        <ItemStyle Width="27%" />
                                                        <ItemTemplate>
                                                            <%#Eval("Fld_Desc_2")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Level 3 Description">
                                                        <ItemStyle Width="27%" />
                                                        <ItemTemplate>
                                                            <%#Eval("Fld_Desc_3")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemStyle Width="9%" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton runat="server" ID="lnkEdit" Text="Edit" CommandName="EditRecord"
                                                                CommandArgument='<%#Eval("PK_LU_SIC") %>'></asp:LinkButton>&nbsp;
                                                            <asp:LinkButton runat="server" ID="lnkDelete" Text="Delete" CommandName="DeleteRecord"
                                                                CommandArgument='<%#Eval("PK_LU_SIC") %>' OnClientClick="return confirm('Are you sure to delete the record?');"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    <table cellpadding="4" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td width="100%" align="center" style="border: 1px solid #cccccc;">
                                                                <asp:Label ID="lblEmptyHeaderGridMessage" runat="server" Text="No Record Found"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                        <td style="width: 5%">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5%">
                            &nbsp;
                        </td>
                        <td colspan="2">
                            <asp:LinkButton Style="display: inline" ID="lnkAddNew" OnClick="lnkAddNew_Click"
                                runat="server" Text="Add New"></asp:LinkButton>&nbsp;&nbsp;&nbsp;<asp:LinkButton
                                    Style="display: none" ID="lnkCancel" OnClick="lnkCancel_Click" runat="server"
                                    Text="Cancel"></asp:LinkButton>
                        </td>
                        <td style="width: 5%">
                            &nbsp;
                        </td>
                    </tr>
                    <tr style="display: none" id="trStatusAdd" runat="server">
                        <td style="width: 5%">
                            &nbsp;
                        </td>
                        <td colspan="2">
                            <table cellspacing="1" cellpadding="3" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td style="width: 18%" align="left">
                                            Code<span class="mf">*</span>
                                        </td>
                                        <td style="width: 4%" align="center">
                                            :
                                        </td>
                                        <td align="left" colspan="4">
                                            <asp:TextBox ID="txtCode" runat="server" MaxLength="4"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvStatus" runat="server" ValidationGroup="vsError" 
                                                SetFocusOnError="true" ErrorMessage="Please Enter Code" Display="none"
                                                ControlToValidate="txtCode"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 18%" align="left">
                                            Level 1 Description<span class="mf">*</span>
                                        </td>
                                        <td style="width: 4%" align="center">
                                            :
                                        </td>
                                        <td align="left" colspan="4">
                                            <asp:TextBox ID="txtDesc1" runat="server" MaxLength="50" Width="250px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="vsError" 
                                                SetFocusOnError="true" ErrorMessage="Please Enter Level 1 Description" Display="none"
                                                ControlToValidate="txtDesc1"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 18%" align="left">
                                            Level 2 Description<span class="mf">*</span>
                                        </td>
                                        <td style="width: 4%" align="center">
                                            :
                                        </td>
                                        <td align="left" colspan="4">
                                            <asp:TextBox ID="txtDesc2" runat="server" MaxLength="70" Width="250px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="vsError" 
                                                SetFocusOnError="true" ErrorMessage="Please Enter Level 2 Description" Display="none"
                                                ControlToValidate="txtDesc2"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 18%" align="left">
                                            Level 3 Description<span class="mf">*</span>
                                        </td>
                                        <td style="width: 4%" align="center">
                                            :
                                        </td>
                                        <td align="left" colspan="4">
                                            <asp:TextBox ID="txtDesc3" runat="server" MaxLength="70" Width="250px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="vsError" 
                                                SetFocusOnError="true" ErrorMessage="Please Enter Level 3 Description" Display="none"
                                                ControlToValidate="txtDesc3"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">
                                            <asp:Label ID="lblError" runat="server" SkinID="lblError" EnableViewState="false"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 18%" align="left">
                                        </td>
                                        <td style="width: 4%" align="center">
                                        </td>
                                        <td align="left">
                                            <asp:Button ID="btnAdd" OnClick="btnAdd_Click" runat="server" ValidationGroup="vsError"
                                                Text="Add" CausesValidation="false" OnClientClick="return CheckValidation();">
                                            </asp:Button>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                        <td style="width: 5%">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            &nbsp;
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

