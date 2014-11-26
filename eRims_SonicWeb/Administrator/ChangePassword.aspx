<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs"
    Inherits="Administrator_ChangePassword" Title="eRIMS Sonic :: Change Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="../JavaScript/JFunctions.js"></script>

    <table width="100%" cellpadding="3" cellspacing="1">
        <tr style="height: 450px;">
            <td valign="middle" align="center">
                <table width="37%" cellpadding="3" cellspacing="1" style="border: 1pt; border-color: #7f7f7f;
                    border-style: solid; text-align: center; height: 70px;">
                    <div>
                        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
                            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
                            EnableClientScript="true" ValidationGroup="vsErrorGroup" CssClass="errormessage">
                        </asp:ValidationSummary>
                        <asp:CustomValidator ID="cvErrorMsg" runat="server" ErrorMessage="" EnableClientScript="true"
                            ValidationGroup="vsErrorGroup" Display="None"></asp:CustomValidator>
                        <asp:Label ID="lblMessage" runat="server" SkinID="lblError" EnableViewState="false"></asp:Label>
                    </div>
                    <tr>
                        <td colspan="3" class="ghc">
                            Change Password
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 9px;">
                            <table width="95%" cellpadding="3" cellspacing="1">
                                <tr style="display: none;">
                                    <td class="lc" style="width: 40%;" align="left">
                                        <%--<asp:Label ID="lblUserName" runat="server" Text="User Id">
                                        </asp:Label>--%>
                                        Current Password
                                    </td>
                                    <td class="lc">
                                        :
                                    </td>
                                    <td class="ic" style="width: 60%;" align="left">
                                        <asp:TextBox ID="txtCurrentPwd" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvCurrentPwd" runat="Server" InitialValue="" ValidationGroup="vsErrorGroup"
                                            ErrorMessage="Please Enter Current Password." Display="Dynamic" Text="*" ControlToValidate="txtCurrentPwd"
                                            Enabled="false">        
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lc" align="left">
                                        <%--<asp:Label ID="lblPwd" runat="server" Text="Password">
                                        </asp:Label>--%>
                                        New Password
                                    </td>
                                    <td class="lc">
                                        :
                                    </td>
                                    <td class="ic" align="left">
                                        <asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvNewPwd" runat="Server" InitialValue="" ValidationGroup="vsErrorGroup"
                                            ErrorMessage="Please Enter New Password." Display="Dynamic" Text="*" ControlToValidate="txtNewPwd">        
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lc" align="left">
                                        <%--<asp:Label ID="lblPwd" runat="server" Text="Password">
                                        </asp:Label>--%>
                                        Confirm Password
                                    </td>
                                    <td class="lc">
                                        :
                                    </td>
                                    <td class="ic" align="left">
                                        <asp:TextBox ID="txtConfirmPwd" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="refConfirmPwd" runat="Server" InitialValue="" ValidationGroup="vsErrorGroup"
                                            ErrorMessage="Please Enter Confirm Password." Display="Dynamic" Text="*" ControlToValidate="txtConfirmPwd">        
                                        </asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="cmpPwd" runat="server" ControlToCompare="txtNewPwd" ControlToValidate="txtConfirmPwd"
                                            Display="Dynamic" Text="*" ErrorMessage="'Confirm Password does not match with New Password"
                                            Operator="Equal" Type="String" ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td colspan="2" align="left" style="padding-left: 12px; padding-top: 5px; padding-bottom: 9px;">
                                        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vsErrorGroup"
                                            OnClick="btnSave_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" class="ic" style="display: none;">
                                        <asp:TextBox runat="server" ID="txtUserName"></asp:TextBox>
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
