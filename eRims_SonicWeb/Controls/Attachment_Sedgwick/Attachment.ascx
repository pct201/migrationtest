<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Attachment.ascx.cs" Inherits="Controls_Attachment_Sedgwick_Attachment" %>
<%@ Register Src="~/Controls/NotesWithSpellCheck/Notes.ascx" TagName="ctrlMultiLineTextBox"
    TagPrefix="uc" %>
<script language="javascript" type="text/javascript">

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
    function RemoveAttachment(NoOfAttachment) {
        HideAll();
        var fpFile_ID = null, fu = null;

        document.getElementById('<%=hdnAttachmentCount.ClientID %>').value = NoOfAttachment - 1;

        if (NoOfAttachment == 2) {
            document.getElementById('<%=trAttachment2.ClientID %>').style.display = 'none';
            document.getElementById('<%=trAttachment1.ClientID %>').style.display = 'block';
            document.getElementById('<%=lbtAdd1.ClientID %>').style.display = 'block';

            fpFile_ID = '<%=fpFile2.ClientID %>';
            fu = document.getElementById(fpFile_ID);

        }
        else if (NoOfAttachment == 3) {
            document.getElementById('<%=trAttachment3.ClientID %>').style.display = 'none';
            document.getElementById('<%=trAttachment2.ClientID %>').style.display = 'block';
            document.getElementById('<%=lbtAdd2.ClientID %>').style.display = 'block';
            document.getElementById('<%=lbtRemove2.ClientID %>').style.display = 'block';
            fpFile_ID = '<%=fpFile3.ClientID %>';
            fu = document.getElementById(fpFile_ID);

        }
        else if (NoOfAttachment == 4) {
            document.getElementById('<%=trAttachment4.ClientID %>').style.display = 'none';
            document.getElementById('<%=trAttachment3.ClientID %>').style.display = 'block';
            document.getElementById('<%=lbtAdd3.ClientID %>').style.display = 'block';
            document.getElementById('<%=lbtRemove3.ClientID %>').style.display = 'block';
            fpFile_ID = '<%=fpFile4.ClientID %>';
            fu = document.getElementById(fpFile_ID);
        }
        else if (NoOfAttachment == 5) {
            document.getElementById('<%=trAttachment5.ClientID %>').style.display = 'none';
            document.getElementById('<%=trAttachment4.ClientID %>').style.display = 'block';
            document.getElementById('<%=lbtAdd4.ClientID %>').style.display = 'block';
            document.getElementById('<%=lbtRemove4.ClientID %>').style.display = 'block';
            fpFile_ID = '<%=fpFile5.ClientID %>';
            fu = document.getElementById(fpFile_ID);
        }
        else if (NoOfAttachment == 6) {
            document.getElementById('<%=trAttachment6.ClientID %>').style.display = 'none';
            document.getElementById('<%=trAttachment5.ClientID %>').style.display = 'block';
            document.getElementById('<%=lbtAdd5.ClientID %>').style.display = 'block';
            document.getElementById('<%=lbtRemove5.ClientID %>').style.display = 'block';
            fpFile_ID = '<%=fpFile6.ClientID %>';
            fu = document.getElementById(fpFile_ID);
        }
        else if (NoOfAttachment == 7) {
            document.getElementById('<%=trAttachment7.ClientID %>').style.display = 'none';
            document.getElementById('<%=trAttachment6.ClientID %>').style.display = 'block';
            document.getElementById('<%=lbtAdd6.ClientID %>').style.display = 'block';
            document.getElementById('<%=lbtRemove6.ClientID %>').style.display = 'block';
            fpFile_ID = '<%=fpFile7.ClientID %>';
            fu = document.getElementById(fpFile_ID);
        }
        else if (NoOfAttachment == 8) {
            document.getElementById('<%=trAttachment8.ClientID %>').style.display = 'none';
            document.getElementById('<%=trAttachment7.ClientID %>').style.display = 'block';
            document.getElementById('<%=lbtAdd7.ClientID %>').style.display = 'block';
            document.getElementById('<%=lbtRemove7.ClientID %>').style.display = 'block';
            fpFile_ID = '<%=fpFile8.ClientID %>';
            fu = document.getElementById(fpFile_ID);
        }
        else if (NoOfAttachment == 9) {
            document.getElementById('<%=trAttachment9.ClientID %>').style.display = 'none';
            document.getElementById('<%=trAttachment8.ClientID %>').style.display = 'block';
            document.getElementById('<%=lbtAdd8.ClientID %>').style.display = 'block';
            document.getElementById('<%=lbtRemove8.ClientID %>').style.display = 'block';
            fpFile_ID = '<%=fpFile9.ClientID %>';
            fu = document.getElementById(fpFile_ID);
        }
        else if (NoOfAttachment == 10) {
            document.getElementById('<%=trAttachment10.ClientID %>').style.display = 'none';
            document.getElementById('<%=trAttachment9.ClientID %>').style.display = 'block';
            document.getElementById('<%=lbtAdd9.ClientID %>').style.display = 'block';
            document.getElementById('<%=lbtRemove9.ClientID %>').style.display = 'block';
            fpFile_ID = '<%=fpFile10.ClientID %>';
            fu = document.getElementById(fpFile_ID);
        }

    fu.outerHTML = '<INPUT id=' + fpFile_ID + ' type=file value="" name=' + fpFile_ID.replace(/_/g, "$") + '">';

    return false;
}

function ShowNewAttachment(NoOfAttachment) {
    document.getElementById('<%=hdnAttachmentCount.ClientID %>').value = NoOfAttachment;

        HideAll();

        if (NoOfAttachment == 1) {
            document.getElementById('<%=trAttachment1.ClientID%>').style.display = 'block';
            document.getElementById('<%=lbtAdd1.ClientID %>').style.display = 'block';
        }
        else if (NoOfAttachment == 2) {
            document.getElementById('<%=trAttachment2.ClientID%>').style.display = 'block';
            document.getElementById('<%=lbtAdd2.ClientID %>').style.display = 'block';
            document.getElementById('<%=lbtRemove2.ClientID %>').style.display = 'block';
        }
        else if (NoOfAttachment == 3) {
            document.getElementById('<%=trAttachment3.ClientID%>').style.display = 'block';
            document.getElementById('<%=lbtAdd3.ClientID %>').style.display = 'block';
            document.getElementById('<%=lbtRemove3.ClientID %>').style.display = 'block';
        }
        else if (NoOfAttachment == 4) {
            document.getElementById('<%=trAttachment4.ClientID%>').style.display = 'block';
            document.getElementById('<%=lbtAdd4.ClientID %>').style.display = 'block';
            document.getElementById('<%=lbtRemove4.ClientID %>').style.display = 'block';
        }
        else if (NoOfAttachment == 5) {
            document.getElementById('<%=trAttachment5.ClientID%>').style.display = 'block';
            document.getElementById('<%=lbtAdd5.ClientID %>').style.display = 'block';
            document.getElementById('<%=lbtRemove5.ClientID %>').style.display = 'block';
        }
        else if (NoOfAttachment == 6) {
            document.getElementById('<%=trAttachment6.ClientID%>').style.display = 'block';
            document.getElementById('<%=lbtAdd6.ClientID %>').style.display = 'block';
            document.getElementById('<%=lbtRemove6.ClientID %>').style.display = 'block';
        }
        else if (NoOfAttachment == 7) {
            document.getElementById('<%=trAttachment7.ClientID%>').style.display = 'block';
            document.getElementById('<%=lbtAdd7.ClientID %>').style.display = 'block';
            document.getElementById('<%=lbtRemove7.ClientID %>').style.display = 'block';
        }
        else if (NoOfAttachment == 8) {
            document.getElementById('<%=trAttachment8.ClientID%>').style.display = 'block';
            document.getElementById('<%=lbtAdd8.ClientID %>').style.display = 'block';
            document.getElementById('<%=lbtRemove8.ClientID %>').style.display = 'block';
        }
        else if (NoOfAttachment == 9) {
            document.getElementById('<%=trAttachment9.ClientID%>').style.display = 'block';
            document.getElementById('<%=lbtAdd9.ClientID %>').style.display = 'block';
            document.getElementById('<%=lbtRemove9.ClientID %>').style.display = 'block';
        }
        else if (NoOfAttachment == 10) {
            document.getElementById('<%=trAttachment10.ClientID%>').style.display = 'block';
            document.getElementById('<%=lbtRemove10.ClientID %>').style.display = 'block';
        }
    return false;
}

function HideAll() {
    document.getElementById('<%=lbtAdd1.ClientID %>').style.display = 'none';
        document.getElementById('<%=lbtAdd2.ClientID %>').style.display = 'none';
        document.getElementById('<%=lbtAdd3.ClientID %>').style.display = 'none';
        document.getElementById('<%=lbtAdd4.ClientID %>').style.display = 'none';
        document.getElementById('<%=lbtAdd5.ClientID %>').style.display = 'none';
        document.getElementById('<%=lbtAdd6.ClientID %>').style.display = 'none';
        document.getElementById('<%=lbtAdd7.ClientID %>').style.display = 'none';
        document.getElementById('<%=lbtAdd8.ClientID %>').style.display = 'none';
        document.getElementById('<%=lbtAdd9.ClientID %>').style.display = 'none';
        document.getElementById('<%=lbtAdd10.ClientID %>').style.display = 'none';
        document.getElementById('<%=lbtRemove1.ClientID %>').style.display = 'none';
        document.getElementById('<%=lbtRemove2.ClientID %>').style.display = 'none';
        document.getElementById('<%=lbtRemove3.ClientID %>').style.display = 'none';
        document.getElementById('<%=lbtRemove4.ClientID %>').style.display = 'none';
        document.getElementById('<%=lbtRemove5.ClientID %>').style.display = 'none';
        document.getElementById('<%=lbtRemove6.ClientID %>').style.display = 'none';
        document.getElementById('<%=lbtRemove7.ClientID %>').style.display = 'none';
        document.getElementById('<%=lbtRemove8.ClientID %>').style.display = 'none';
        document.getElementById('<%=lbtRemove9.ClientID %>').style.display = 'none';
        document.getElementById('<%=lbtRemove10.ClientID %>').style.display = 'none';
        document.getElementById('<%=fpFile2.ClientID%>').style.width = "265px";
        document.getElementById('<%=fpFile3.ClientID%>').style.width = "265px";
        document.getElementById('<%=fpFile4.ClientID%>').style.width = "265px";
        document.getElementById('<%=fpFile5.ClientID%>').style.width = "265px";
        document.getElementById('<%=fpFile6.ClientID%>').style.width = "265px";
        document.getElementById('<%=fpFile7.ClientID%>').style.width = "265px";
        document.getElementById('<%=fpFile8.ClientID%>').style.width = "265px";
        document.getElementById('<%=fpFile9.ClientID%>').style.width = "265px";
        document.getElementById('<%=fpFile10.ClientID%>').style.width = "265px";
    }

    function CheckFiles(obj, args) {
        var file1 = document.getElementById('<%=fpFile1.ClientID%>').value;
        var file2 = document.getElementById('<%=fpFile2.ClientID%>').value;
        var file3 = document.getElementById('<%=fpFile3.ClientID%>').value;
        var file4 = document.getElementById('<%=fpFile4.ClientID%>').value;
        var file5 = document.getElementById('<%=fpFile5.ClientID%>').value;
        var file6 = document.getElementById('<%=fpFile6.ClientID%>').value;
        var file7 = document.getElementById('<%=fpFile7.ClientID%>').value;
        var file8 = document.getElementById('<%=fpFile8.ClientID%>').value;
        var file9 = document.getElementById('<%=fpFile9.ClientID%>').value;
        var file10 = document.getElementById('<%=fpFile10.ClientID%>').value;
        var _IsValid = false;
        var NoOfattachment = document.getElementById('<%=hdnAttachmentCount.ClientID %>').value;
        NoOfattachment = NoOfattachment + 1;
        if (NoOfattachment >= 1 && file1 != '')
            _IsValid = true;
        if (NoOfattachment >= 2 && file2 != '')
            _IsValid = true;
        if (NoOfattachment >= 3 && file3 != '')
            _IsValid = true;
        if (NoOfattachment >= 4 && file4 != '')
            _IsValid = true;
        if (NoOfattachment >= 5 && file5 != '')
            _IsValid = true;
        if (NoOfattachment >= 6 && file6 != '')
            _IsValid = true;
        if (NoOfattachment >= 7 && file7 != '')
            _IsValid = true;
        if (NoOfattachment >= 8 && file8 != '')
            _IsValid = true;
        if (NoOfattachment >= 9 && file9 != '')
            _IsValid = true;
        if (NoOfattachment >= 10 && file10 != '')
            _IsValid = true;

        args.IsValid = _IsValid;
        return _IsValid;

    }
</script>
<asp:HiddenField ID="hdnAttachmentCount" runat="server" Value="1" />
<asp:ValidationSummary ID="valSummayAttachment" runat="server" ShowMessageBox="true"
    ValidationGroup="AddAttachment" ShowSummary="false" HeaderText="Verify the following field(s):" />
<table cellpadding="0" cellspacing="0" border="0" width="100%">
    <tr>
        <td>
            <table cellpadding="3" cellspacing="1" width="100%">
                <tr>
                    <td align="left" valign="top">
                        Attachment Description
                    </td>
                    <td align="center" valign="top">
                        :
                    </td>
                    <td align="left" valign="top">
                        <uc:ctrlMultiLineTextBox ID="txtAttachDesc" runat="server" MaxLength="3940" TabIndex="2" />
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top">
                        Attachment Filename
                    </td>
                    <td align="center" valign="top">
                        :
                    </td>
                    <td align="left" valign="top">
                        <table cellpadding="1" cellspacing="0" width="500px">
                            <tr id="trAttachment1" runat="server">
                                <td align="left" width="55%">
                                    <asp:FileUpload ID="fpFile1" runat="server" Width="265px" />
                                </td>
                                <td width="20%" align="left">
                                    <asp:LinkButton ID="lbtAdd1" runat="server" Text="--Add Attachment--" OnClientClick="javascript:return ShowNewAttachment(2);"></asp:LinkButton>
                                </td>
                                <td align="left">
                                    <asp:LinkButton ID="lbtRemove1" runat="server" Text="--Remove--" Style="display: none;"
                                        OnClientClick="javascript:return RemoveAttachment(1);"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr id="trAttachment2" runat="server" style="display: none;" width="265px">
                                <td align="left">
                                    <asp:FileUpload ID="fpFile2" runat="server" Width="265px" />
                                </td>
                                <td>
                                    <asp:LinkButton ID="lbtAdd2" runat="server" Text="--Add Attachment--" Style="display: none;"
                                        OnClientClick="javascript:return ShowNewAttachment(3);"></asp:LinkButton>
                                </td>
                                <td align="left">
                                    <asp:LinkButton ID="lbtRemove2" runat="server" Text="--Remove--" Style="display: none;"
                                        OnClientClick="javascript:return RemoveAttachment(2);"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr id="trAttachment3" runat="server" style="display: none;">
                                <td align="left">
                                    <asp:FileUpload ID="fpFile3" runat="server" Width="265px" />
                                </td>
                                <td>
                                    <asp:LinkButton ID="lbtAdd3" runat="server" Text="--Add Attachment--" Style="display: none;"
                                        OnClientClick="javascript:return ShowNewAttachment(4);"></asp:LinkButton>
                                </td>
                                <td align="left">
                                    <asp:LinkButton ID="lbtRemove3" runat="server" Text="--Remove--" Style="display: none;"
                                        OnClientClick="javascript:return RemoveAttachment(3);"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr id="trAttachment4" runat="server" style="display: none;">
                                <td align="left">
                                    <asp:FileUpload ID="fpFile4" runat="server" Width="265px" />
                                </td>
                                <td>
                                    <asp:LinkButton ID="lbtAdd4" runat="server" Text="--Add Attachment--" Style="display: none;"
                                        OnClientClick="javascript:return ShowNewAttachment(5);"></asp:LinkButton>
                                </td>
                                <td align="left">
                                    <asp:LinkButton ID="lbtRemove4" runat="server" Text="--Remove--" Style="display: none;"
                                        OnClientClick="javascript:return RemoveAttachment(4);"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr id="trAttachment5" runat="server" style="display: none;">
                                <td align="left">
                                    <asp:FileUpload ID="fpFile5" runat="server" Width="265px" />
                                </td>
                                <td>
                                    <asp:LinkButton ID="lbtAdd5" runat="server" Text="--Add Attachment--" Style="display: none;"
                                        OnClientClick="javascript:return ShowNewAttachment(6);"></asp:LinkButton>
                                </td>
                                <td align="left">
                                    <asp:LinkButton ID="lbtRemove5" runat="server" Text="--Remove--" Style="display: none;"
                                        OnClientClick="javascript:return RemoveAttachment(5);"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr id="trAttachment6" runat="server" style="display: none;">
                                <td align="left">
                                    <asp:FileUpload ID="fpFile6" runat="server" Width="265px" />
                                </td>
                                <td>
                                    <asp:LinkButton ID="lbtAdd6" runat="server" Text="--Add Attachment--" Style="display: none;"
                                        OnClientClick="javascript:return ShowNewAttachment(7);"></asp:LinkButton>
                                </td>
                                <td align="left">
                                    <asp:LinkButton ID="lbtRemove6" runat="server" Text="--Remove--" Style="display: none;"
                                        OnClientClick="javascript:return RemoveAttachment(6);"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr id="trAttachment7" runat="server" style="display: none;">
                                <td align="left">
                                    <asp:FileUpload ID="fpFile7" runat="server" Width="265px" />
                                </td>
                                <td>
                                    <asp:LinkButton ID="lbtAdd7" runat="server" Text="--Add Attachment--" Style="display: none;"
                                        OnClientClick="javascript:return ShowNewAttachment(8);"></asp:LinkButton>
                                </td>
                                <td align="left">
                                    <asp:LinkButton ID="lbtRemove7" runat="server" Text="--Remove--" Style="display: none;"
                                        OnClientClick="javascript:return RemoveAttachment(7);"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr id="trAttachment8" runat="server" style="display: none;">
                                <td align="left">
                                    <asp:FileUpload ID="fpFile8" runat="server" Width="265px" />
                                </td>
                                <td>
                                    <asp:LinkButton ID="lbtAdd8" runat="server" Text="--Add Attachment--" Style="display: none;"
                                        OnClientClick="javascript:return ShowNewAttachment(9);"></asp:LinkButton>
                                </td>
                                <td align="left">
                                    <asp:LinkButton ID="lbtRemove8" runat="server" Text="--Remove--" Style="display: none;"
                                        OnClientClick="javascript:return RemoveAttachment(8);"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr id="trAttachment9" runat="server" style="display: none;">
                                <td align="left">
                                    <asp:FileUpload ID="fpFile9" runat="server" Width="265px" />
                                </td>
                                <td>
                                    <asp:LinkButton ID="lbtAdd9" runat="server" Text="--Add Attachment--" Style="display: none;"
                                        OnClientClick="javascript:return ShowNewAttachment(10);"></asp:LinkButton>
                                </td>
                                <td align="left">
                                    <asp:LinkButton ID="lbtRemove9" runat="server" Text="--Remove--" Style="display: none;"
                                        OnClientClick="javascript:return RemoveAttachment(9);"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr id="trAttachment10" runat="server" style="display: none;">
                                <td align="left">
                                    <asp:FileUpload ID="fpFile10" runat="server" Width="265px" />
                                    <asp:LinkButton ID="lbtAdd10" runat="server" Text="--Add Attachment--" Style="display: none;"
                                        OnClientClick="javascript:return ShowNewAttachment(11);"></asp:LinkButton>
                                </td>
                                <td align="left" colspan="2">
                                    <asp:LinkButton ID="lbtRemove10" runat="server" Text="--Remove--" Style="display: none;"
                                        OnClientClick="javascript:return RemoveAttachment(10);"></asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                        <asp:CustomValidator ID="reqFile" runat="Server" ErrorMessage="Please select file(s) for attachment"
                            Display="None" ValidationGroup="AddAttachment" ClientValidationFunction="CheckFiles"
                            ValidateEmptyText="true" ControlToValidate="fpFile1"></asp:CustomValidator>
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
                            OnClientClick="return Page_ClientValidate('AddAttachment')" OnClick="btnAddAttachment_Click" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>