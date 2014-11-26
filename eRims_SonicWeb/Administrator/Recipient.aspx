<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Recipient.aspx.cs"
    Inherits="Administrator_Recipient" Title="eRIMS Sonic :: Recipient" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/jquery.maskedinput.js"></script>
    <script language="javascript" type="text/javascript">
        function SaveContact()
        {
            var i = document.getElementById('<%=txtContactNo.ClientID %>');
        }

        jQuery(function ($) {
            $("#<%=txtContactNo.ClientID%>").mask("999-999-9999");
        });
    </script>

    <asp:ValidationSummary ID="valSummary" runat="server" HeaderText="Please Verify the following fields:"
        ShowMessageBox="true" ShowSummary="false" />
    <table width="100%" cellpadding="2" cellspacing="1">
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" class="ghc">
                Recipient List</td>
        </tr>
        <tr>
            <td>
                <asp:MultiView ID="mvRecipient" runat="server" ActiveViewIndex="0">
                    <asp:View ID="vwRecipientGrid" runat="server">
                        <table align="center" width="100%" cellpadding="2" cellspacing="2">
                            <tr>
                                <td align="right">
                                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvRecipient" runat="server" AutoGenerateColumns="False" Width="100%"
                                        DataKeyNames="PK_Recipient_ID" EmptyDataText="No Recipient Found!" OnRowDeleting="gvRecipient_RowDeleting"
                                        OnRowEditing="gvRecipient_RowEditing">
                                        <Columns>
                                            <asp:TemplateField HeaderText="First Name">
                                                <ItemStyle Width="20%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFirstName" runat="server" Text='<%#Eval("FirstName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Middle Name">
                                                <ItemStyle Width="15%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMiddleName" runat="server" Text='<%#Eval("MidleName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Last Name">
                                                <ItemStyle Width="15%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLastName" runat="server" Text='<%#Eval("LastName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Contact">
                                                <ItemStyle Width="15%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblContact" runat="server" Text='<%#Eval("Phone") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Email">
                                                <ItemStyle Width="15%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemStyle Width="10%" />
                                                <ItemTemplate>
                                                    <asp:Button ID="btnEdit" runat="server" CommandName="Edit" Text="Edit" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemStyle Width="10%" />
                                                <ItemTemplate>
                                                    <asp:Button ID="lblDelete" runat="server" CommandName="Delete" Text="Delete" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="vwAddRecipient" runat="server">
                        <table width="100%">
                            <tr>
                                <td style="width: 25%;">
                                    First Name
                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red" Text="*"></asp:Label></td>
                                <td style="width: auto;" align="right">
                                    :</td>
                                <td style="width: auto;">
                                    <asp:TextBox ID="txtRecipientFirstName" runat="server" TabIndex="1"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="valFirstName" runat="server" ControlToValidate="txtRecipientFirstName"
                                        ErrorMessage="First Name must not be Blank" SetFocusOnError="True" Display="None"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td>
                                    Middle Name
                                </td>
                                <td align="right">
                                    :</td>
                                <td>
                                    <asp:TextBox ID="txtRecipientMiddleName" runat="server" TabIndex="2"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Last Name
                                </td>
                                <td align="right">
                                    :</td>
                                <td>
                                    <asp:TextBox ID="txtRecipientLastName" runat="server" TabIndex="3"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Contact No. (xxx-xxx-xxxx)
                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Red" Text="*"></asp:Label></td>
                                <td align="right">
                                    :</td>
                                <td>
                                    <asp:TextBox ID="txtContactNo" runat="server" TabIndex="4"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="revPhone" ControlToValidate="txtContactNo" runat="server"
                                        ErrorMessage="Please Enter the Contact No in xxx-xxx-xxxx format." Display="none"
                                        ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="valContactNo" runat="server" ControlToValidate="txtContactNo"
                                        ErrorMessage="Contact no must not be blank" SetFocusOnError="True" Display="None"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td>
                                    Email Address
                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="Red" Text="*"></asp:Label></td>
                                <td align="right">
                                    :</td>
                                <td>
                                    <asp:TextBox ID="txtEmail" runat="server" TabIndex="5"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="valEmailID" runat="server" ControlToValidate="txtEmail"
                                        Display="None" ErrorMessage="Please Enter Valid Email Address" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegExpEmailID" runat="server" ControlToValidate="txtEmail"
                                        Display="None" ErrorMessage="Please Enter Valid Email Address" SetFocusOnError="True" ToolTip="Please Enter Valid Email Address"
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
                            </tr>
                            <tr>
                                <td colspan="3" align="center">
                                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" OnClientClick="javascript:SaveContact();" />
                                    <asp:Button ID="btncance" runat="server" Text="Cancel" OnClick="btncance_Click" CausesValidation="False" />
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
</asp:Content>
