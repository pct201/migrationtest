<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Signin.aspx.cs" Inherits="Signin"
    MasterPageFile="~/Logins.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
   
       function CheckUserID()
       {     
          var txtuserid=document.getElementById("ctl00_ContentPlaceHolder1_txtUserId").value;  
          
          if(jTrim(txtuserid) !='')
          {
              return true;
          }
          else 
          {
             alert("To retrieve your password, please enter your valid user id in the login box, then click the 'Forgot Password?' link."); 
             return false; 
          }
       }
   
    </script>

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
                        <asp:Label ID="lblMessage" runat="server" SkinID="lblError" EnableViewState="false"></asp:Label>
                        <input type="hidden" id="hdntext" name="hdntext" value="" />
                        <asp:Button runat="server" ID="btnHdnSearchPage" Style="display: none;" OnClick="btnHdnSearchPage_Click" />
                        <asp:Button runat="server" ID="btnHdnStatusPage" Style="display: none;" OnClick="btnHdnStatusPage_Click" />
                    </div>
                    <tr>
                        <td colspan="3" class="ghc">
                            Login
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 9px;">
                            <table width="95%">
                                <tr>
                                    <td class="lc" style="width: 50%;" align="left">
                                        User Id
                                    </td>
                                    <td class="lc">
                                        :
                                    </td>
                                    <td class="ic" style="width: 50%;" align="left">
                                        <asp:TextBox ID="txtUserId" runat="server" Width="140px" MaxLength="65"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvUserId" runat="Server" InitialValue="" ValidationGroup="vsErrorGroup"
                                            ErrorMessage="Please Enter User Id." Display="none" ControlToValidate="txtUserId">
        
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lc" style="width: 50%;" align="left">
                                        Password
                                    </td>
                                    <td class="lc">
                                        :
                                    </td>
                                    <td class="ic" style="width: 50%;" align="left">
                                        <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" Width="140px" MaxLength="15"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvPwd" runat="Server" InitialValue="" ValidationGroup="vsErrorGroup"
                                            ErrorMessage="Please Enter Password." Display="none" ControlToValidate="txtPwd">        
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td colspan="2" align="left" style="padding-left: 12px; padding-top: 5px; padding-bottom: 9px;">
                                        <asp:Button ID="btnLogin" runat="server" Text="Login" ValidationGroup="vsErrorGroup"
                                            OnClick="btnLogin_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td colspan="2" align="left" style="padding-left: 12px; padding-top: 5px; padding-bottom: 9px;">
                                        <asp:LinkButton ID="lnkForgotPassword" runat="server" OnClick="lnkForgotPassword_Click"
                                            OnClientClick="javascript:return CheckUserID();">Forgot Password?</asp:LinkButton>
                                    </td>
                                </tr>
                                 <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td colspan="2" align="left" style="padding-left: 12px; padding-top: 5px; padding-bottom: 9px;">
                                        <asp:LinkButton ID="lnkAccessRequest" runat="server" OnClick="lnkAccessRequest_Click">Access Request</asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
   <%-- <asp:Panel runat="server" ID="pnlPopup" Visible="false">

        <script language="javascript" type="text/javascript">
            owin=window.open('Administrator/ChangePassword_Popup.aspx?UserName=' + document.getElementById('<%=txtUserId.ClientID %>').value + '&id=1&UID=<%=clsSession.UserID %>' ,'','location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=200');
            owin.moveTo(260,180);            
        </script>

    </asp:Panel>--%>
</asp:Content>
