<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmailAttachment.aspx.cs"
    Inherits="SONIC_EmailAttachment" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Erims Mail</title>
    <link href="~/App_Themes/Default/Default.css" type="text/css" />

    <script type="text/javascript">
    function Close()
    {
        self.close();
    }
    function test(lst)
    {
        //alert(lst.options[lst.selectedIndex].value);
        var obj=document.getElementById(lst.id);
        var strEmails = '';
        for(i=0;i<obj.length; i++)
        {
            if(obj.options[i].selected == true)
                strEmails = strEmails + obj.options[i].text + ', ';
        }
        document.getElementById('divSelectedEmails').innerHTML = strEmails;
        document.getElementById('lblEMails').value=strEmails;
    }
    
    </script>

</head>
<body style="background-color: White;">
    <form id="form1" runat="server">
        <div>
            <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
                HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
                ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
            <asp:CustomValidator ID="cvErrorMsg" runat="server" ErrorMessage="" EnableClientScript="false"
                ValidationGroup="vsErrorGroup" Display="None"></asp:CustomValidator>
        </div>
        <div style="display: none;">
            <asp:Label ID="lblScript" runat="server"></asp:Label>
        </div>
        <div>
            <table width="100%" style="border: 1pt; border-color: #7f7f7f; border-style: solid;">
                <tr>
                    <td class="ghc" style="font-family: Tahoma; font-size: 11pt; font-weight: bold;"
                        align="left">
                        Mail<asp:Label runat="server" ID="lblEMails" style="display:none" EnableViewState="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <table width="100%">
                            <tr valign="top">
                                <td class="lc" align="left" style="width: 15%;">
                                    To Email Address</td>
                                <td class="lc" style="width: 5%">
                                    :</td>
                                <td class="ic" align="left" style="width: 20%">
                                    <asp:ListBox runat="server" ID="lstEmailTo" SelectionMode="multiple" onchange="test(this);"></asp:ListBox>
                                    <asp:RequiredFieldValidator runat="server" ID="rfvEmailTo" ControlToValidate="lstEmailTo" Display="none" 
                                    ErrorMessage="Please Select Email Address"
                                       ValidationGroup="vsErrorGroup" InitialValue=""></asp:RequiredFieldValidator>
                                </td>
                                <td class="lc" style="width: 60%">
                                    <div id="divSelectedEmails" style="height:75px;overflow-y:scroll;"></div>
                                    </td>
                            </tr>
                            <tr>
                                <td class="lc" align="left">
                                    E-Mail From</td>
                                <td class="lc">
                                    :</td>
                                <td class="ic" align="left" colspan="2">
                                   <asp:Label runat="server" ID="lblEmailFrom"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="lc" align="left" valign="top">
                                    E-Mail Message</td>
                                <td class="lc" valign="top">
                                    :</td>
                                <td class="ic" align="left" colspan="2">
                                    <uc:ctrlMultiLineTextBox runat="server" ID="txtBody" ControlType="textbox" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="ic" colspan="4" align="center">
                                    <asp:Button ID="btnSend" Text="Send" runat="server" OnClick="btnSend_Click" ValidationGroup="vsErrorGroup">
                                    </asp:Button>&nbsp;<asp:Button runat="server" ID="btnClose" Text="Cancel" OnClientClick="javascript:parent.parent.GB_hide();" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <script language="javascript" type="text/javascript">
        
        </script>
    </form>
</body>
</html>
