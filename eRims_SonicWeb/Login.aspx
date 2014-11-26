<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login"
    Title="Erims2 Login" MasterPageFile="~/Login.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr style="height: 450px;">
            <td valign="middle" align="center">
                <table width="27%" cellpadding="3" cellspacing="0" style="border: 1pt; border-color: #7f7f7f;
                    border-style: solid; text-align: center; height: 70px;">
                    <div>
                        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
                            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
                            EnableClientScript="true" ValidationGroup="vsErrorGroup" CssClass="errormessage">
                        </asp:ValidationSummary>
                        <asp:CustomValidator ID="cvErrorMsg" runat="server" ErrorMessage="" EnableClientScript="true"
                            ValidationGroup="vsErrorGroup" Display="None"></asp:CustomValidator>
                        <asp:Label ID="lblMessage" runat="server" SkinID="lblError"></asp:Label>
                    </div>
                    <tr>
                        <td colspan="3" class="ghc">
                            Login
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top:9px;">
                            <table width="95%">
                                <tr>
                                    <td class="lc" style="width: 50%; " align="left" >
                                        <%--<asp:Label ID="lblUserName" runat="server" Text="User Id">
                                        </asp:Label>--%>
                                        User Id
                                    </td>
                                    <td class="lc">
                                        :</td>
                                    <td class="ic" style="width: 50%;" align="left">
                                        <asp:TextBox ID="txtUserId" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvUserId" runat="Server" InitialValue="" ValidationGroup="vsErrorGroup"
                                            ErrorMessage="Please Enter User Id." Display="none" ControlToValidate="txtUserId">
        
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lc" style="width: 50%;" align="left">
                                        <%--<asp:Label ID="lblPwd" runat="server" Text="Password">
                                        </asp:Label>--%>
                                        Password
                                    </td>
                                    <td class="lc">
                                        :</td>
                                    <td class="ic" style="width: 50%;" align="left">
                                        <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" Width="150px" ></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvPwd" runat="Server" InitialValue="" ValidationGroup="vsErrorGroup"
                                            ErrorMessage="Please Enter Password." Display="none" ControlToValidate="txtPwd">
        
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td colspan="2" align="left" style="padding-left: 12px; padding-top: 5px; padding-bottom: 9px;">
                                        <asp:Button ID="btnLogin" runat="server" Text="Login" ValidationGroup="vsErrorGroup"
                                            OnClick="btnLogin_Click" />
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
