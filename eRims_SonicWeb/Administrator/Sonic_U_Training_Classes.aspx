<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Sonic_U_Training_Classes.aspx.cs" Inherits="Administrator_Sonic_U_Training_Classes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <script language="javascript" type="text/javascript">

    function CheckValidation()
    {    
        if(Page_ClientValidate("vsError"))
        {
        }
    }
    </script>
    <asp:UpdatePanel runat="server" ID="updTrainingClasses">
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
                            Administrator :: Safety Training Classes
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%">
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
                                            <asp:GridView ID="gvTrainingClasses" runat="server" Width="100%" AutoGenerateColumns="false"
                                                PageSize="10" EnableViewState="true" AllowPaging="true" OnRowCommand="gvTrainingClasses_RowCommand"
                                                OnPageIndexChanging="gvTrainingClasses_PageIndexChanging">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Class Name">
                                                        <ItemStyle Width="60%" />
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lbldesc" Text='<%#Eval("Class_Name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Active">
                                                        <ItemStyle Width="20%" />
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblActive" Text='<%#(Eval("Active").ToString() == "N" ? "In Active" : "Active") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemStyle Width="20%" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton runat="server" ID="lnkEdit" Text="Edit" CommandName="EditRecord"
                                                                CommandArgument='<%#Eval("PK_Sonic_U_Training_Classes") %>'></asp:LinkButton>
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
                        <td style="width: 20%">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%">
                            &nbsp;
                        </td>
                        <td colspan="2">
                            <asp:LinkButton Style="display: inline" ID="lnkAddNew" OnClick="lnkAddNew_Click"
                                runat="server" Text="Add New"></asp:LinkButton>&nbsp;&nbsp;&nbsp;<asp:LinkButton
                                    Style="display: none" ID="lnkCancel" OnClick="lnkCancel_Click" runat="server"
                                    Text="Cancel"></asp:LinkButton>
                        </td>
                        <td style="width: 20%">
                            &nbsp;
                        </td>
                    </tr>
                    <tr style="display: none" id="trTrainingAdd" runat="server">
                        <td style="width: 20%">
                            &nbsp;
                        </td>
                        <td colspan="2">
                            <table cellspacing="1" cellpadding="3" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td style="width: 25%" align="left">
                                            Class Name<span class="mf">*</span>
                                        </td>
                                        <td style="width: 4%" align="center">
                                            :
                                        </td>
                                        <td align="left" colspan="4">
                                            <asp:TextBox ID="txtClassName" runat="server" MaxLength="50"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvClassName" runat="server" ValidationGroup="vsError"
                                                SetFocusOnError="true" ErrorMessage="Please Enter Class Name" Display="none" ControlToValidate="txtClassName"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 25%" align="left">
                                            Active
                                        </td>
                                        <td style="width: 4%" align="center">
                                            :
                                        </td>
                                        <td align="left" colspan="4">
                                            <asp:RadioButtonList ID="rdblActive" runat="server">
                                                <asp:ListItem Text="Yes" Value="Y" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">
                                            <asp:Label ID="lblError" runat="server" SkinID="lblError" EnableViewState="false"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 25%" align="left">
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
                        <td style="width: 20%">
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

