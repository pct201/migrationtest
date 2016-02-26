<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Attachment.ascx.cs" Inherits="Controls_Attachment_OC_Attachment" %>
<%@ Register Src="~/Controls/Attchment-Occupational/AM_Attach_Section.ascx"
    TagName="AttachmentSection" TagPrefix="uc" %>
<input type="hidden" id="hdnBackTo" runat="server" />
<div>
    <asp:ValidationSummary ID="valSummayAttachment" runat="server" ValidationGroup="AddAttachment"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following field(s):" />
</div>
<asp:ScriptManagerProxy runat="server" ID="scMain">
    <Services>
        <asp:ServiceReference Path="~/FileUtility.asmx" />
    </Services>
</asp:ScriptManagerProxy>

<table cellpadding="2" cellspacing="1" width="100%" id="tblFileList" runat="server">
    <tr>
        <td width="100%" align="left">
            <asp:GridView ID="gvFiles" runat="server" Width="100%" AutoGenerateColumns="false"
                EmptyDataText="No Files Found." OnRowCommand="gvFiles_RowCommand" OnRowDataBound="gvFiles_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="File Name" >
                        <ItemStyle Width="70%" />
                        <HeaderStyle HorizontalAlign="Center"/>
                        <ItemTemplate  >
                            <asp:LinkButton ID="lnkDocName" runat="server" Text='<%# Convert.ToString(Eval("NewAttachment_Name")) %>' />
                            <input type="hidden" id="hdnID" runat="server" value='<%#Eval("PK_Attachments")%>' />
                            <input type="hidden" id="hdnFileName" runat="server" value='<%#Eval("File_Name") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email">
                        <ItemStyle Width="15%" />
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEmail" runat="server">
                                <img src="../../Images/Email_Attachment.jpg" alt="E-Mail" /></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemStyle Width="15%" />
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDelete" CommandArgument='<%# Eval("PK_Attachments") + ":" + Eval("File_Name") %>'
                                CommandName="DeleteAttachment" runat="server" OnClientClick="return confirm('Are you sure to delete the attachment?')">
                                <img src="../../Images/delete_Attachment.jpg" alt="delete" /></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>                 
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <asp:Button ID="btnViewPDF" runat="server" Text="View Selections (PDFs only)"
                Width="200px" OnClientClick="return CheckSeleted('File');" Visible="false" />&nbsp;
            <asp:Button ID="btnCancelFile" runat="server" Text="Back" OnClick="btnCancelFile_Click" Visible="false" />
            <span style="padding-left: 500px">
                <asp:Button ID="btnEmail" runat="server" Text="Email Selected Attachments" Width="200px"
                    OnClick="btnEmail_Click" Visible="false" /></span>
        </td>
    </tr>
</table>
<table cellpadding="1" cellspacing="1" width="100%" id="tblAddEditAttachment" runat="server">
    <tr>
        <td width="100%" class="bandHeaderRow">
            <asp:Label ID="lblAttachHeader" runat="server" Text="Add Attachment"></asp:Label>
            <asp:Label ID="lblAttachHeaderView" runat="server" Text="View Attachment" Visible="false" />
        </td>
    </tr>
    <tr>
        <td>&nbsp;
        </td>
    </tr>
    <tr>
        <td width="100%">
            <table cellpadding="3" cellspacing="1" width="100%" id="tblEditAttachment" runat="server" visible="false">
                <tr>
                    <td width="18%" align="left">Attachment Name
                    </td>
                    <td width="4%" align="center">:
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtAttachmentNameEdit" runat="server" Width="150px">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvAttachment" runat="server" ControlToValidate="txtAttachmentName"
                            ValidationGroup="AddAttachment" ErrorMessage="Please Enter Attachment Name"
                            SetFocusOnError="true" Display="None" />
                    </td>
                </tr>
                <tr>
                    <td align="left">Select File
                    </td>
                    <td align="center">:
                    </td>
                    <td align="left">
                        <asp:FileUpload ID="fpFile" runat="server" Width="250px" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:Button ID="btnAddAttachment" runat="server" Text="Add Attachment" OnClick="btnAddAttachment_Click"
                            OnClientClick="return Page_ClientValidate('AddAttachment')" />&nbsp;
                        <input type="hidden" id="hdnVirtualFolderID" runat="server" />
                        <asp:Button ID="btnCancelAttachment" runat="server" Text="Cancel" OnClick="btnCancelAttachment_Click" Visible="false" />
                    </td>
                </tr>
            </table>
            <table id="tblAddAttachment" runat="server" width="100%">
                <tr>
                    <td width="100%" align="left">
                        <uc:AttachmentSection ID="Attachment1" runat="server" PanelNumber="1" />

                        <asp:LinkButton ID="lnkAddNew1" runat="server" Text="--Add New--" OnClientClick="ShowAttachmentSection(1);return false;"
                            Font-Bold="true" />&nbsp;
                        <asp:HiddenField ID="hndCount" runat="server" Value="1" />
                        <input type="hidden" id="hndCounthtml" />
                    </td>
                </tr>
                <tr id="trSection2" style="display: none;" runat="server">
                    <td width="100%" align="left">
                        <hr />
                        <uc:AttachmentSection ID="Attachment2" runat="server" PanelNumber="1" />
                        <br />
                        <asp:LinkButton ID="lnkAddNew2" runat="server" Text="--Add New--" OnClientClick="ShowAttachmentSection(2);return false;"
                            Font-Bold="true" />&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="lnkRemove2" runat="server" Text="--Remove--" OnClientClick="HideAttachmentSection(2);return false;"
                            Font-Bold="true" />&nbsp;
                    </td>
                </tr>
                <tr id="trSection3" style="display: none;" runat="server">
                    <td width="100%" align="left">
                        <hr />
                        <uc:AttachmentSection ID="Attachment3" runat="server" PanelNumber="1" />
                        <br />
                        <asp:LinkButton ID="lnkAddNew3" runat="server" Text="--Add New--" OnClientClick="ShowAttachmentSection(3);return false;"
                            Font-Bold="true" />&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="lnkRemove3" runat="server" Text="--Remove--" OnClientClick="HideAttachmentSection(3);return false;"
                            Font-Bold="true" />&nbsp;
                    </td>
                </tr>
                <tr id="trSection4" style="display: none;">
                    <td width="100%" align="left">
                        <hr />
                        <uc:AttachmentSection ID="Attachment4" runat="server" PanelNumber="1" />
                        <br />
                        <asp:LinkButton ID="lnkAddNew4" runat="server" Text="--Add New--" OnClientClick="ShowAttachmentSection(4);return false;"
                            Font-Bold="true" />&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="lnkRemove4" runat="server" Text="--Remove--" OnClientClick="HideAttachmentSection(4);return false;"
                            Font-Bold="true" />&nbsp;
                    </td>
                </tr>
                <tr id="trSection5" style="display: none;">
                    <td width="100%" align="left">
                        <hr />
                        <uc:AttachmentSection ID="Attachment5" runat="server" PanelNumber="1" />
                        <br />
                        <asp:LinkButton ID="lnkAddNew5" runat="server" Text="--Add New--" OnClientClick="ShowAttachmentSection(5);return false;"
                            Font-Bold="true" />&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="lnkRemove5" runat="server" Text="--Remove--" OnClientClick="HideAttachmentSection(5);return false;"
                            Font-Bold="true" />&nbsp;
                    </td>
                </tr>
                <tr id="trSection6" style="display: none;">
                    <td width="100%" align="left">
                        <hr />
                        <uc:AttachmentSection ID="Attachment6" runat="server" PanelNumber="7" />
                        <br />
                        <asp:LinkButton ID="lnkAddNew6" runat="server" Text="--Add New--" OnClientClick="ShowAttachmentSection(6);return false;"
                            Font-Bold="true" />&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="lnkRemove6" runat="server" Text="--Remove--" OnClientClick="HideAttachmentSection(6);return false;"
                            Font-Bold="true" />&nbsp;
                    </td>
                </tr>
                <tr id="trSection7" style="display: none;">
                    <td width="100%" align="left">
                        <hr />
                        <uc:AttachmentSection ID="Attachment7" runat="server" PanelNumber="7" />
                        <br />
                        <asp:LinkButton ID="lnkAddNew7" runat="server" Text="--Add New--" OnClientClick="ShowAttachmentSection(7);return false;"
                            Font-Bold="true" />&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="lnkRemove7" runat="server" Text="--Remove--" OnClientClick="HideAttachmentSection(7);return false;"
                            Font-Bold="true" />&nbsp;
                    </td>
                </tr>
                <tr id="trSection8" style="display: none;">
                    <td width="100%" align="left">
                        <hr />
                        <uc:AttachmentSection ID="Attachment8" runat="server" PanelNumber="7" />
                        <br />
                        <asp:LinkButton ID="lnkAddNew8" runat="server" Text="--Add New--" OnClientClick="ShowAttachmentSection(8);return false;"
                            Font-Bold="true" />&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="lnkRemove8" runat="server" Text="--Remove--" OnClientClick="HideAttachmentSection(8);return false;"
                            Font-Bold="true" />&nbsp;
                    </td>
                </tr>
                <tr id="trSection9" style="display: none;">
                    <td width="100%" align="left">
                        <hr />
                        <uc:AttachmentSection ID="Attachment9" runat="server" PanelNumber="7" />
                        <br />
                        <asp:LinkButton ID="lnkAddNew9" runat="server" Text="--Add New--" OnClientClick="ShowAttachmentSection(9);return false;"
                            Font-Bold="true" />&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="lnkRemove9" runat="server" Text="--Remove--" OnClientClick="HideAttachmentSection(9);return false;"
                            Font-Bold="true" />&nbsp;
                    </td>
                </tr>
                <tr id="trSection10" style="display: none;">
                    <td width="100%" align="left">
                        <hr />
                        <uc:AttachmentSection ID="Attachment10" runat="server" PanelNumber="7" />
                        <br />
                        <%--<asp:LinkButton ID="lnkAddNew10" runat="server" Text="--Add New--" OnClientClick="ShowAttachmentSection(10);return false;" Font-Bold="true"  />&nbsp;&nbsp;&nbsp;&nbsp;--%>
                        <asp:LinkButton ID="lnkRemove10" runat="server" Text="--Remove--" OnClientClick="HideAttachmentSection(10);return false;"
                            Font-Bold="true" />&nbsp;
                    </td>
                </tr>
                <tr>
                    <td width="100%" align="center">
                        <asp:Button ID="btnSaveAttachments" runat="server" Text="Save" OnClick="btnSaveAttachments_Click"
                            OnClientClick="return FinalValidate();" />
                        <%--&nbsp;&nbsp;<asp:Button ID="btnCancelAttachment_Add"
                                runat="server" Text="Cancel" OnClick="btnCancelAttachment_Add_Click" />--%>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<br />
<script type="text/javascript">

    function DeleteConfirm(grid) {

        if (CheckSeleted(grid)) {
            if (grid == 'File2')
                return confirm('Are you sure to delete the selected Attachment(s)?');
            else
                return confirm('Are you sure to delete the selected Tag(s)?');
        }
        else
            return false;
    }

    function CheckSeleted(grid) {
        var ctrls = document.getElementsByTagName('input');
        var i, chkID;

        if (grid == "Folder") chkID = "chkFolder";
        else if (grid == "File" || grid == "File2") chkID = "chkFile";
        else chkID = "chkTag";
        //cnt is used to count number of row are selected
        var cnt = 0;
        for (i = 0; i < ctrls.length; i++) {
            if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf(chkID) > 0) {
                if (ctrls[i].checked)
                    cnt++;
            }
        }
        //used if 0 rows are selected than give alert to user else go forward.
        if (cnt == 0) {
            if (grid == "Folder") alert("Please select Folder(s) to view");
            else if (grid == "File") alert("Please select PDF File(s) to view");
            else if (grid == "File2") alert("Please select Attachment(s) to remove");
            return false;
        }
        else
            return true;
    }



    function openWindow(strURL) {
        var w = 480, h = 340;
        if (document.all || document.layers) {
            w = screen.availWidth;
            h = screen.availHeight;
        }

        var leftPos, topPos;
        var popW = 200, popH = 200;
        if (document.all)
        { leftPos = (w - popW) / 2; topPos = (h - popH) / 2; }
        else
        { leftPos = w / 2; topPos = h / 2; }
        window.open(strURL, "popup", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=" + popW + ",height=" + popH + ",top=" + topPos + ",left=" + leftPos);
        return false;
    }

    function ShowMailPage(Attach_IDs) {
        ShowDialog("<%=AppConfig.SiteURL%>SONIC/Exposures/AM_Attachment_Mail.aspx?Attch_Ids=" + Attach_IDs, 600, 450);
        return false;
    }

    function ShowAttachmentSection(intSection) {

        document.getElementById('ctl00_ContentPlaceHolder1_Attachments_trSection' + (intSection + 1)).style.display = "";
        document.getElementById('ctl00_ContentPlaceHolder1_Attachments_lnkAddNew' + intSection).style.display = "none";
        //alert(intSection);
        $('#hndCounthtml').val(intSection + 1);

        if (intSection > 1) {
            $('#<%=hndCount.ClientID %>').val(intSection + 1);
            document.getElementById('ctl00_ContentPlaceHolder1_Attachments_lnkRemove' + intSection).style.display = "none";
        }
    }

    function HideAttachmentSection(intSection) {
        document.getElementById('ctl00_ContentPlaceHolder1_Attachments_lnkAddNew' + (intSection - 1)).style.display = "";
        document.getElementById('ctl00_ContentPlaceHolder1_Attachments_trSection' + intSection).style.display = "none";
        $('#hndCounthtml').val($('#hndCounthtml').val() - 1);

        if (intSection > 2) {

            $('#<%=hndCount.ClientID %>').val(intSection - 1);
            document.getElementById('ctl00_ContentPlaceHolder1_Attachments_lnkRemove' + (intSection - 1)).style.display = "";
        }
        $('#ctl00_ContentPlaceHolder1_Attachments_Attachment' + (intSection) + '_txtNewFileName').text('');
        $('#ctl00_ContentPlaceHolder1_Attachments_Attachment' + (intSection) + '_txtFilePath').val('');
        document.getElementById('ctl00_ContentPlaceHolder1_Attachments_Attachment' + (intSection) + '_txtAttachmentNameAdd').value = "";        
    }

    function FinalValidate() {

        var hndCount = $('#hndCounthtml').val();
        if (hndCount == '') {
            hndCount = 1;
        }
        var length = hndCount;
        var totalFileName = '';
        var totalFileUploadvalue = '';
        var IsFileSelected = 'false';
        var IsFolderSelected = 'false';

        if (parseInt(length) > 0) {
            for (i = 1; i <= length; i++) {
                if ($('#ctl00_ContentPlaceHolder1_Attachments_Attachment' + i + '_txtNewFileName').val() != "") {
                    totalFileName = totalFileName + $('#ctl00_ContentPlaceHolder1_Attachments_Attachment' + i + '_txtNewFileName').val() + "&~&~&";
                    var FileName = document.getElementById('ctl00_ContentPlaceHolder1_Attachments_Attachment' + i + '_fpFile').value;
                    var ext = FileName.lastIndexOf(".");
                    if (ext > 0) {
                        totalFileUploadvalue = totalFileUploadvalue + FileName.substring(FileName.lastIndexOf(".")) + "&~&~&";
                    }
                    else {
                        totalFileUploadvalue = totalFileUploadvalue + "&~&";
                    }
                    IsFileSelected = 'true';
                }
            }
            totalFileName = totalFileName + "&~&~&;" + totalFileUploadvalue;
        }

        for (j = 1; j <= hndCount; j++) {

            var FolderName = document.getElementById('ctl00_ContentPlaceHolder1_Attachments_Attachment' + j + '_txtAttachmentNameAdd').value;
            var FileName_value = document.getElementById('ctl00_ContentPlaceHolder1_Attachments_Attachment' + j + '_fpFile').value;
            if (parseInt(FolderName) != 0 && FileName_value != "") {
                IsFolderSelected = "true";
            }
        }
        if (IsFolderSelected == "false") {
            alert('Please select Folder and File both for an attachment');
            return false;
        }
        if (IsFileSelected == "false") {
            return true;
        }
        else {
            FileUtility.CheckInvalidFileName(totalFileName, OnUpdateTreeComlete, OnTimeOut, onerror);
        }

        return false;
    }

    function OnUpdateTreeComlete(result) {

        if (result == "") {
            __doPostBack('ctl00$ContentPlaceHolder1$Attachments$btnSaveAttachments', '');
        }
        else {
            alert(result);
        }
    }


    function SetFilePath(fpID, CtrlID) {
        document.getElementById(CtrlID).value = document.getElementById(fpID).value;
    }

    function OnTimeOut(args) {
        alert("Time-out occured. Please contact us if this error persist.");
    }
    function OnError(args) {
        alert("Error calling web service. Please contact us if this error persist.");
    }
</script>
