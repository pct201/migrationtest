<%@ Page Title="eRIMS Sonic :: Change Password" Language="C#" MasterPageFile="~/Logins.master" AutoEventWireup="true" 
    CodeFile="ChangeExpiredPassword.aspx.cs" Inherits="ChangeExpiredPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script type="text/javascript" src="../JavaScript/JFunctions.js"></script>

    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr style="height: 450px;" align="center" valign="middle">
            <td valign="middle" align="center">
                <table width="37%" cellpadding="3" cellspacing="0" style="border: 1pt; border-color: #7f7f7f;
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
                        <td style="padding-top:9px;">
                            <table width="95%" cellpadding="3" cellspacing="1">
                                <tr style="display:block;">
                                    <td style="width: 40%; " align="left" >
                                        Current Password
                                    </td>
                                    <td>
                                        :</td>
                                    <td style="width: 60%;" align="left">
                                        <asp:TextBox ID="txtCurrentPwd" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvCurrentPwd" runat="Server" InitialValue="" ValidationGroup="vsErrorGroup"
                                            ErrorMessage="Please Enter Current Password." Display="Dynamic" Text="*" ControlToValidate="txtCurrentPwd" >        
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        New Password
                                    </td>
                                    <td>
                                        :</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password" Width="150px" ></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvNewPwd" runat="Server" InitialValue="" ValidationGroup="vsErrorGroup"
                                            ErrorMessage="Please Enter New Password." Display="Dynamic" Text="*" ControlToValidate="txtNewPwd">        
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        Confirm Password
                                    </td>
                                    <td>
                                        :</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtConfirmPwd" runat="server" TextMode="Password" Width="150px" ></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="refConfirmPwd" runat="Server" InitialValue="" ValidationGroup="vsErrorGroup"
                                            ErrorMessage="Please Enter Confirm Password." Display="Dynamic" Text="*" ControlToValidate="txtConfirmPwd">        
                                        </asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="cmpPwd" runat="server" ControlToCompare="txtNewPwd" ControlToValidate="txtConfirmPwd"
                                         Display="Dynamic" Text="*" ErrorMessage="New Passwod and Confirm Password should be match." Operator="Equal" 
                                         Type="String" ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td colspan="2" align="left" style="padding-left: 12px; padding-top: 5px; padding-bottom: 9px;">
                                        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vsErrorGroup"
                                            OnClick="btnSave_Click" />
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

