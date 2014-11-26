<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="RecipientList.aspx.cs"
    Inherits="Administrator_RecipientList" Title="eRIMS Sonic :: Recipient List" %>

<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ValidationSummary ID="valSummary" runat="server" ShowMessageBox="true" ShowSummary="false"
        HeaderText="Please Verify the following fields:" />
    <table width="100%" cellpadding="2" cellspacing="1">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" class="ghc">
                Recipient List</td>
        </tr>
        <tr>
            <td style="width: 100%;">
                <asp:MultiView ID="mvRecipientList" runat="server">
                    <asp:View ID="vwRecipientList" runat="server">
                        <table style="width: 100%;" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="center" style="width: 100%;">
                                    <table width="80%">
                                        <tr>
                                            <td align="right">
                                                <asp:Button ID="btnAdd" runat="server" Text="Add List" OnClick="btnAdd_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="width: 100%;">
                                    <asp:GridView ID="gvRecipientList" runat="server" AutoGenerateColumns="False" Width="80%"
                                        DataKeyNames="Pk_RecipientList_ID" OnRowEditing="gvRecipientList_RowEditing"
                                        OnRowDeleting="gvRecipientList_RowDeleting">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Recipient List Name" HeaderStyle-HorizontalAlign="Left">
                                                <ItemStyle Width="60%" HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRecipientList" runat="server" Text='<%#Eval("ListName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtRecipientList" runat="server" Text='<%#Eval("ListName") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemStyle Width="15%" />
                                                <ItemTemplate>
                                                    <asp:Button ID="bntEdit" runat="server" Text="Edit" CommandName="Edit" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemStyle Width="15%" />
                                                <ItemTemplate>
                                                    <asp:Button ID="bntDelete" runat="server" Text="Delete" CommandName="Delete" OnClientClick="return confirm('Are you sure you wnat to delete this List?');" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="vmAddRecipient" runat="server">
                        <table width="100%" align="center" border="0">
                            <tr>
                                <td>
                                    <asp:Label ID="lblListName" runat="server" Text="List Name">
                                    </asp:Label><span class="mf">*</span>
                                </td>
                                <td>
                                    :
                                </td>
                                <td valign="middle">
                                    <asp:TextBox ID="txtListName" runat="server" MaxLength="50">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="valtxtListName" runat="server" ErrorMessage="List Name must not be blank"
                                        Display="none" SetFocusOnError="true" Font-Bold="true" ControlToValidate="txtListName"></asp:RequiredFieldValidator>
                                    &nbsp;<asp:Label ID="lblMessage" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="lblRecipients" runat="server" Text="Recipients">
                                    </asp:Label>
                                </td>
                                <td valign="top">
                                    :
                                </td>
                                <td>
                                    <asp:GridView ID="gvRecipients" runat="server" AutoGenerateColumns="False" EmptyDataText="No Recipient found !"
                                        DataKeyNames="PK_Recipient_ID">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Select" ItemStyle-Wrap="true">
                                                <ItemStyle Width="5%" Wrap="true" />
                                                <ItemTemplate>
                                                    <asp:CheckBox runat="server" ID="chkSelect" Checked='<%#Convert.ToBoolean(Eval("PK_RecipientListMatrix_ID").ToString() != "") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Email" SortExpression="Email" ItemStyle-Wrap="true">
                                                <ItemStyle Width="20%" Wrap="true" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="First Name">
                                                <ItemStyle Width="20%" Wrap="true" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRecipientName" runat="server" Text='<%#Eval("FirstName")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Middle Name" SortExpression="MidleName">
                                                <ItemStyle Width="20%" Wrap="true" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMiddleName" runat="server" Text='<%# Eval("MidleName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Last Name" SortExpression="LastName">
                                                <ItemStyle Width="20%" Wrap="true" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLastName" runat="server" Text='<%# Eval("LastName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Contact No" SortExpression="Phone">
                                                <ItemStyle Width="15%" Wrap="true" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPhone" runat="server" Text='<%# Eval("Phone") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" align="center">
                                    <asp:Button ID="Save" runat="server" CausesValidation="true" Text="Save" OnClick="Save_Click" />
                                    <asp:Button ID="Cancel" runat="server" CausesValidation="false" Text="Cancel" OnClick="Cancel_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
</asp:Content>
