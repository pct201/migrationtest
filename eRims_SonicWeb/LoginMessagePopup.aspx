<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginMessagePopup.aspx.cs" Inherits="LoginMessagePopup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="padding: 30px">
    <form id="form1" runat="server">
        <div runat="server" id="divForgetUserID">
            <table>
                <tr>
                    <td align="left">
                        <asp:Label runat="server" Font-Size="Medium" ID="lblMessage" Text="This is for existing users only : If you forgot your User Id, please contact your Regional Loss Control Manager."></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Button runat="server" ID="btnForgotUserIDOK" OnClientClick="ClosePopup();" Text="OK" />
                    </td>
                </tr>
            </table>
        </div>
        <div runat="server" id="divForgetPassword">
            <table>
                <tr>
                    <td align="left">
                        <asp:Label runat="server" Font-Size="Medium" ID="Label1">
                            This is for existing users only: If you forgot your password, please have your User Id entered, return here, and then <asp:LinkButton Text="click here" ID="lnkResetPassword" runat="server" OnClick="lnkResetPassword_Click"></asp:LinkButton> to get your password.
                        </asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Button runat="server" ID="btnForgotPasswordOK" OnClientClick="ClosePopup();" Text="Cancel" />
                    </td>
                </tr>
            </table>
        </div>
        <div runat="server" id="divForgetPasswordSuccess">
            <table>
                <tr>
                    <td align="left">
                        <asp:Label runat="server" Font-Size="Medium" ID="lblSuccess">
                            
                        </asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Button runat="server" ID="btnSuccessOK" OnClientClick="ClosePopup();" Text="OK" />
                    </td>
                </tr>
            </table>
        </div>
        <div runat="server" id="divAccessRequest">
            <table>
                <tr>
                    <td align="left">
                        <asp:Label runat="server" Font-Size="Medium" ID="Label2" Text="This is used to gain eRIMS2 access if you are a NEW user only. Please fill out the user access request form for Risk Management to review before granting access to eRIMS2."></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Button runat="server" ID="btnProceed" OnClientClick="return RedirectToAccessRight();" Text="Proceed" />
                        <asp:Button runat="server" ID="btnAccessRequestCancel" OnClientClick="ClosePopup();" Text="Cancel" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
    <script type="text/javascript">
        function CheckForm() {
            if (selectedContractorSecurityID == "0") {
                alert("Select contractor security user");
                return false;
            }
        }
        function ClosePopup() {
            parent.parent.GB_hide();
        }

        function AlertMessage()
        {
            alert('The password for <" + strUserName + "> was e-mailed to <" + strEmail + ">.');
            ClosePopup();
        }

        function RedirectToAccessRight() {
            //window.location.href = "<%=AppConfig.SiteURL%>Administrator/UserAccessRequestForm.aspx?Requester=1";
            parent.parent.document.getElementById('ctl00_ContentPlaceHolder1_lnkHdnAccessRequest').click();
            return false;
        }
    </script>
</body>
</html>
