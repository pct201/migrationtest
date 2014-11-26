<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Manufacturer.aspx.cs"
    Inherits="Administrator_Manufacturer" Title="eRIMS Sonic :: Manufacturer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
function AddNewGroup()
{
    
    document.getElementById('<%=trManufacturerAdd.ClientID %>').style.display="block";
   
    document.getElementById('<%=lnkCancel.ClientID %>').style.display="inline";
}
function CheckValidation()
{    
    if(Page_ClientValidate("vsError"))
    {
       }
}
    </script>

    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields :" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsError" CssClass="errormessage"></asp:ValidationSummary>
    </div>
   <%-- <asp:UpdatePanel runat="server" ID="updManufacturer">
        <ContentTemplate>--%>
            <table cellspacing="0" cellpadding="0" width="100%">
                <tbody>
                    <tr>
                        <td colspan="4">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="bandHeaderRow" align="left" colspan="4">
                            Administrator :: Manufacturer
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 20%">
                            &nbsp;</td>
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
                                            <asp:GridView ID="gvManufacturer" runat="server" Width="100%" AutoGenerateColumns="false"
                                                PageSize="10" EnableViewState="true" AllowPaging="true" OnRowCommand="gvManufacturer_RowCommand"
                                                OnRowCreated="gvManufacturer_RowCreated" OnRowEditing="gvManufacturer_RowEditing"
                                                OnPageIndexChanging="gvManufacturer_PageIndexChanging">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Manufacturer Name">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lbldesc" Text='<%#Eval("Fld_Desc") %>'></asp:Label>
                                                            <%--<asp:LinkButton runat="server" ID="lnkView" Text='<%#Eval("Fld_Desc") %>'></asp:LinkButton>--%>
                                                            <asp:HiddenField runat="Server" ID="hdnManufacturerID" Value='<%#Eval("PK_LU_Manufacturer") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:LinkButton runat="server" ID="lnkEdit" Text="Edit" CommandName="Edit"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--<asp:TemplateField HeaderText="Remove">
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="lnkRemove" Text="Remove" CommandName="Remove" OnClientClick="return confirm('Are you sure to delete?');"></asp:LinkButton>
                </ItemTemplate>
                </asp:TemplateField>   --%>
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
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 20%">
                            &nbsp;</td>
                        <td colspan="2">
                            <asp:LinkButton Style="display: inline" ID="lnkAddNew" OnClick="lnkAddNew_Click"
                                runat="server" Text="Add New"></asp:LinkButton>&nbsp;&nbsp;&nbsp;<asp:LinkButton
                                    Style="display: none" ID="lnkCancel" OnClick="lnkCancel_Click" runat="server"
                                    Text="Cancel"></asp:LinkButton>
                        </td>
                        <td style="width: 20%">
                            &nbsp;</td>
                    </tr>
                    <tr style="display: none" id="trManufacturerAdd" runat="server">
                        <td style="width: 20%">
                            &nbsp;</td>
                        <td colspan="2">
                            <table cellspacing="1" cellpadding="3" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td style="width: 25%" align="left">
                                            Manufacturer Name <span style="color: Red;">*</span></td>
                                        <td style="width: 4%" align="center">
                                            :</td>
                                        <td align="left" colspan="4">
                                            <asp:TextBox ID="txtManufacturer" runat="server" MaxLength="50"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvManufacturer" runat="server" ValidationGroup="vsError"
                                                ErrorMessage="Please Enter Manufacturer Name" Display="none" ControlToValidate="txtManufacturer"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">
                                            <asp:Label ID="lblError" runat="server" SkinID="lblError" EnableViewState="false"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 25%" align="left">
                                        </td>
                                        <td style="width: 4%" align="center">
                                        </td>
                                        <td align="left">
                                            <asp:Button ID="btnAdd" OnClick="btnAdd_Click" runat="server" ValidationGroup="vsError"
                                                Text="Add" CausesValidation="false" OnClientClick="return CheckValidation();"></asp:Button>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                        <td style="width: 20%">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            &nbsp;</td>
                    </tr>
                </tbody>
            </table>
       <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
