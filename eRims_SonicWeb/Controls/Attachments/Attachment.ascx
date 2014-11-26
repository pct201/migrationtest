<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Attachment.ascx.cs" Inherits="Sonic_Attachment" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagPrefix="uc" TagName="ctrlMultiLineTextBox" %>

<script language="javascript" type="text/javascript">
    //used to Upload file. from this funciton click event of btnHdn is fired.
    function CheckFiles(obj, args) {
        var file1 = document.getElementById('<%=fpFile1.ClientID%>').value;
        var file2 = document.getElementById('<%=fpFile2.ClientID%>').value;
        var file3 = document.getElementById('<%=fpFile3.ClientID%>').value;
        var file4 = document.getElementById('<%=fpFile4.ClientID%>').value;
        var file5 = document.getElementById('<%=fpFile5.ClientID%>').value;

        if (file1 == '' && file2 == '' && file3 == '' && file4 == '' && file5 == '') {
            args.IsValid = false;
        }
        else {
            args.IsValid = true;
        }
        return args.IsValid;
    }

    //used to Expand Attchement Description Textbox
    function ExpandAttachDesc(bExpand) {
        if (bExpand) {
            document.getElementById('<%=txtAttachDesc.ClientID%>').style.display = "block";
            document.getElementById('imgMinus').style.display = "block";
            document.getElementById('imgPlus').style.display = "none";
        }
        else {
            document.getElementById('<%=txtAttachDesc.ClientID%>').style.display = "none";
            document.getElementById('imgMinus').style.display = "none";
            document.getElementById('imgPlus').style.display = "block";
        }
    }
</script>

<table cellpadding="0" cellspacing="0" border="0" width="100%">
    <asp:ValidationSummary ID="valSummayAttachment" runat="server" ShowMessageBox="true"
        ValidationGroup="AddAttachment" ShowSummary="false" Enabled="false" />
    <tr>
        <td class="Spacer" style="height: 20px;">
            <asp:Button runat="server" ID="btnHdn" Visible="false" OnClick="btnHdn_Click" />
        </td>
    </tr>
    <tr>
        <td>
            <table cellpadding="3" cellspacing="1" width="100%">
                <tr id="trAttachmentType" runat="server" style="display: none">
                    <td width="18%" align="left">
                        Attachment Type
                    </td>
                    <td width="4%" align="center">
                        :
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="drpAttachType" SkinID="Attachment" Width="170px" runat="server">
                        </asp:DropDownList>
                        &nbsp;<asp:RequiredFieldValidator ID="reqAttachType" runat="server" Enabled="false"
                            ControlToValidate="drpAttachType" Display="None" ErrorMessage="Please select the attachment type"
                            InitialValue="0"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td width="18%" align="left" valign="top">
                        Attachment Description
                    </td>
                    <td width="4%" align="center" valign="top">
                        :
                    </td>
                    <td align="left" valign="top">
                        <uc:ctrlMultiLineTextBox ID="txtAttachDesc" runat="server" MaxLength="4000" />
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top">
                        Attachment File Name(s)
                    </td>
                    <td align="center" valign="top">
                        :
                    </td>
                    <td align="left" valign="top">
                        <table cellpadding="1" cellspacing="0" width="100%">
                            <tr>
                                <td width="100%" align="left">
                                    <asp:FileUpload ID="fpFile1" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:FileUpload ID="fpFile2" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:FileUpload ID="fpFile3" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:FileUpload ID="fpFile4" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:FileUpload ID="fpFile5" runat="server" />
                                </td>
                            </tr>
                        </table>
                        <asp:RequiredFieldValidator ID="reqFile" runat="server" ControlToValidate="fpFile1"
                            Enabled="false" Display="None" ErrorMessage="Please select the file"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="cstFile" runat="Server" ErrorMessage="Please select file(s) for attachment"
                            EnableClientScript="true" Display="None" ClientValidationFunction="CheckFiles"
                            ValidationGroup="AddAttachment"></asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:Button ID="btnAddAttachment" runat="server" Text="Add Attachment" CausesValidation="true"
                            ValidationGroup="AddAttachment" OnClick="btnAddAttachment_Click" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
