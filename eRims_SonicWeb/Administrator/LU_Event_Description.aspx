<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="LU_Event_Description.aspx.cs" Inherits="Administrator_LU_Event_Description" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <script language="javascript" type="text/javascript">


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
                            Administrator :: Event Description
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
                                            <asp:GridView ID="gvEvent_Description" runat="server" Width="100%" AutoGenerateColumns="false"
                                                PageSize="10" EnableViewState="true" AllowPaging="true" OnRowCommand="gvEvent_Description_RowCommand"
                                                OnPageIndexChanging="gvEvent_Description_PageIndexChanging">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Description">
                                                        <ItemStyle Width="40%" />
                                                        <ItemTemplate>
                                                            <%#Eval("Fld_Desc")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Code">
                                                        <ItemStyle Width="15%" />
                                                        <ItemTemplate>
                                                            <%#Eval("Fld_code")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="&nbsp;&nbsp;&nbsp;&nbsp;Edit">
                                                        <ItemStyle Width="10%" />
                                                        <ItemTemplate>
                                                            <asp:Button runat="server" ID="lnkEdit" Text=" Edit " CommandName="EditRecord" CommandArgument='<%#Eval("PK_LU_Event_Description") %>'>
                                                            </asp:Button>
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
                        <td colspan="2" style="padding-bottom: 5px;">
                            <asp:LinkButton Style="display: inline" ID="lnkAddNew" OnClick="lnkAddNew_Click"
                                runat="server" Text="Add New"></asp:LinkButton>&nbsp;&nbsp;&nbsp;<asp:LinkButton
                                    Style="display: none" ID="lnkCancel" OnClick="lnkCancel_Click" runat="server"
                                    Text="Cancel"></asp:LinkButton>
                        </td>
                        <td style="width: 20%">
                            &nbsp;
                        </td>
                    </tr>
                    <tr style="display: none" id="trStatusAdd" runat="server">
                        <td style="width: 20%">
                            &nbsp;
                        </td>
                        <td colspan="2" style="padding-left: 50px;">
                            <table cellspacing="1" cellpadding="3" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td style="width: 18%" align="left">
                                            Description<span class="mf">*</span>
                                        </td>
                                        <td style="width: 4%" align="center">
                                            :
                                        </td>
                                        <td align="left" colspan="4">
                                            <asp:TextBox ID="txtDescription" runat="server" Width="170px" MaxLength="60"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvStatus" runat="server" ValidationGroup="vsError"
                                                SetFocusOnError="true" ErrorMessage="Please Enter Description" Display="none"
                                                ControlToValidate="txtDescription"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 18%" align="left">
                                            Code<span class="mf">*</span>
                                        </td>
                                        <td style="width: 4%" align="center">
                                            :
                                        </td>
                                        <td align="left" colspan="4">
                                            <asp:TextBox ID="txtCode" runat="server" Width="170px" MaxLength="4"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="vsError"
                                                SetFocusOnError="true" ErrorMessage="Please Enter Code" Display="none" ControlToValidate="txtCode"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">
                                            <asp:Label ID="lblError" runat="server" SkinID="lblError" EnableViewState="false"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                        </td>
                                        <td align="center">
                                        </td>
                                        <td align="left">
                                            <asp:Button ID="btnAdd" OnClick="btnAdd_Click" runat="server" ValidationGroup="vsError"
                                                Text="Add" Width="70px" Action_StatussValidation="false" OnClientClick="return CheckValidation();">
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


