<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InspectionsEmail.aspx.cs"
    Inherits="SONIC_Exposures_InspectionsEmail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>

    <script language="javascript" type="text/javascript" src="../../JavaScript/Validator.js"></script>

</head>

<script language="javascript" type="text/javascript">
    function CheckAddress(sender, args)
    {        
        if(document.getElementById('<%=drpRecipientList.ClientID%>').selectedIndex == -1 && trim(args.Value) == '')
            args.IsValid = false;
        else
            args.IsValid = true;
            
        return args.IsValid;
    }
    function SetDate() {
        alert('Mail sent successfully!');
        //parent.parent.CheckForDate();
        parent.parent.GB_hide();      
        return false;
    }
</script>

<body>
    <form id="form1" runat="server">
        <asp:ValidationSummary ID="valInspection" runat="server" ValidationGroup="vsInspection"
            ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following fields"
            BorderWidth="1" BorderColor="DimGray" CssClass="errormessage" />
        <asp:ScriptManager ID="scManager1" runat="server" EnablePartialRendering="true">
        </asp:ScriptManager>
        <div>
            <br />
            <br />
            <br />
            <asp:UpdatePanel ID="upDatePnl" runat="server">
                <ContentTemplate>
                    <table cellpadding="3" cellspacing="1" width="95%" align="center">
                        <tr>
                            <td align="left" width="20%">
                                &nbsp;
                            </td>
                            <td width="4%" align="center">
                                &nbsp;
                            </td>
                            <td align="left">
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td width="155" align="left">
                                            &nbsp;
                                        </td>
                                        <td align="left">
                                            Additional Email IDs<br />
                                            (Comma Separated)
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="20%">
                                Recipient List<span class="mf">*</span>
                            </td>
                            <td width="4%" align="center">
                                :
                            </td>
                            <td align="left">
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td width="155" align="left">
                                            <asp:ListBox ID="drpRecipientList" runat="server" EnableTheming="True" Width="150px"
                                                SelectionMode="Multiple" />
                                        </td>
                                        <td align="left" valign="top">
                                            <asp:TextBox ID="txtAdditionalAddresses" runat="server" Width="155px" />
                                            <asp:CustomValidator ID="csmvEmailAddress" runat="server" ErrorMessage="Please Select email Recipiet or Enter Email ID."
                                                ClientValidationFunction="CheckAddress" Display="None" ControlToValidate="txtAdditionalAddresses"
                                                ValidateEmptyText="true" ValidationGroup="vsInspection"></asp:CustomValidator>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Subject
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtSubject" runat="server" MaxLength="200" Width="250px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                Text
                            </td>
                            <td align="center" valign="top">
                                :
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtText" runat="server" MaxLength="4000" TextMode="multiline" Rows="5"
                                    Width="300px" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center">
                                <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" CausesValidation="true"
                                    ValidationGroup="vsInspection" />&nbsp;
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false"
                                    OnClientClick="parent.parent.GB_hide();" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <br />
        <br />
        <asp:UpdateProgress ID="upProgress1" runat="server" DisplayAfter="100">
            <ProgressTemplate>
                <span style="color: Green;"><b>Mail sending process is going on.Please wait....</b>
                </span>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </form>
</body>
</html>
