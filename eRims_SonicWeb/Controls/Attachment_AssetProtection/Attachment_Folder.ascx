<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Attachment_Folder.ascx.cs" Inherits="Controls_Attachment_AP_Attachment" %>
<%@ Register Src="~/Controls/Attachment_AssetProtection/AM_Attach_Section.ascx"
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
<table cellpadding="2" cellspacing="1" width="100%" id="tblFolderList" runat="server">
    <tr>
        <td align="left" width="100%">
            <div class="bandHeaderRow">
                Attachment</div>
        </td>
    </tr>
    <tr>
        <td width="100%" align="left">
            <asp:GridView ID="gvFolders" runat="server" Width="100%" AutoGenerateColumns="false"
                EmptyDataText="No Attachment Folder Found">
                <Columns>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" Width="5%" />
                        <ItemStyle HorizontalAlign="Left" Width="5%" />
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkHeaderFolder" runat="server" onclick="CheckUnCheckAll('Folder',this.checked)" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkFolder" runat="server" />
                            <input type="hidden" id="hdnID" runat="server" value='<%#Eval("PK_LU_AM_Attachment_Type")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Folders">
                        <ItemTemplate>
                            <%# Eval("Folder_Name")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Document Count" HeaderStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <%# Eval("Document_Count") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <asp:Button ID="btnViewSelection" runat="server" Text="View Selections" OnClick="btnViewSelection_Click"
                Width="120px" OnClientClick="return CheckSeleted('Folder');" />&nbsp;
            <asp:Button ID="btnAddDocument" runat="server" Text="Add Document" OnClick="btnAddDocument_Click"
                Width="120px" />&nbsp;
        </td>
    </tr>
</table>
<table cellpadding="2" cellspacing="1" width="100%" id="tblFileList" runat="server"
    visible="false">
    <tr>
        <td width="100%" align="left">
            <asp:GridView ID="gvFiles" runat="server" Width="100%" AutoGenerateColumns="false"
                EmptyDataText="No Files Found For Selected Folder(s)" OnRowCommand="gvFiles_RowCommand"
                AllowSorting="true" OnSorting="gvFiles_Sorting" OnRowCreated="gvFiles_RowCreated"
                OnRowDataBound="gvFiles_RowDataBound">
                <Columns>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Left" Width="5%" />
                        <ItemStyle HorizontalAlign="Left" Width="5%" />
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkHeaderFile" runat="server" onclick="CheckUnCheckAll('File',this.checked)" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkFile" runat="server" onclick="CheckAllUnchecked('File');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Type" SortExpression="Extension">
                        <ItemStyle Width="10%" />
                        <ItemTemplate>
                            <asp:Label ID="lblType" runat="server" Text='<%# Convert.ToString(Eval("Extension")) %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="File Name" SortExpression="Attachment_Description">
                        <ItemStyle Width="30%" />
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDocName" runat="server" Text='<%# Convert.ToString(Eval("Attachment_Description")) %>' />
                            <input type="hidden" id="hdnID" runat="server" value='<%#Eval("PK_AM_Attachments")%>' />
                            <input type="hidden" id="hdnFileName" runat="server" value='<%#Eval("Attachment_Filename") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date Attached" SortExpression="Attach_Date">
                        <ItemStyle Width="15%" />
                        <ItemTemplate>
                            <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Attach_Date"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemStyle Width="13%" />
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CommandName="EditAttachment"
                                CommandArgument='<%# Eval("PK_AM_Attachments")%>' />&nbsp;
                            <asp:LinkButton ID="lnkView" runat="server" Text="View" CommandName="ViewAttachment"
                                CommandArgument='<%# Eval("PK_AM_Attachments")%>' />&nbsp;
                            <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="DeleteAttachment"
                                CommandArgument='<%# Eval("PK_AM_Attachments") + ":" + Eval("Attachment_Filename") %>'
                                OnClientClick="return confirm('Are you sure to delete the attachment?')" />&nbsp;
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <asp:Button ID="btnViewPDF" runat="server" Text="View Selections (PDFs only)" OnClick="btnViewPDF_Click"
                Width="200px" OnClientClick="return CheckSeleted('File');" />&nbsp;
            <asp:Button ID="btnCancelFile" runat="server" Text="Back" OnClick="btnCancelFile_Click" />
            <span style="padding-left: 500px">
                <asp:Button ID="btnEmail" runat="server" Text="Email Selected Attachments" Width="200px"
                    OnClick="btnEmail_Click" /></span>
        </td>
    </tr>
</table>
<table cellpadding="1" cellspacing="1" width="100%" id="tblAddEditAttachment" runat="server"
    visible="false">
    <tr>
        <td width="100%" class="bandHeaderRow">
            <asp:Label ID="lblAttachHeader" runat="server" Text="Add Attachment"></asp:Label>
            <asp:Label ID="lblAttachHeaderView" runat="server" Text="View Attachment" Visible="false" />
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td width="100%">
            <table cellpadding="3" cellspacing="1" width="100%" visible="false" id="tblEditAttachment"
                runat="server">
                <tr>
                    <td width="18%" align="left">
                        Folder
                    </td>
                    <td width="4%" align="center">
                        :
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="drpFolder" runat="server" Width="500px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvFolder" runat="server" ControlToValidate="drpFolder"
                            InitialValue="0" ValidationGroup="AddAttachment" ErrorMessage="Please select Folder"
                            SetFocusOnError="true" Display="None" />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        File to Attach
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td align="left">
                        <asp:FileUpload ID="fpFile" runat="server" Width="500px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:Button ID="btnAddAttachment" runat="server" Text="Add Attachment" OnClick="btnAddAttachment_Click"
                            OnClientClick="return Page_ClientValidate('AddAttachment')" />&nbsp;
                        <input type="hidden" id="hdnVirtualFolderID" runat="server" />
                        <asp:Button ID="btnCancelAttachment" runat="server" Text="Cancel" OnClick="btnCancelAttachment_Click" />
                    </td>
                </tr>
            </table>
            <table id="tblAddAttachment" runat="server" visible="false" width="100%">
                <tr>
                    <td width="100%" align="left">
                        <uc:AttachmentSection ID="Attachment1" runat="server" PanelNumber="7" />
                        <br />
                        <asp:LinkButton ID="lnkAddNew1" runat="server" Text="--Add New--" OnClientClick="ShowAttachmentSection(1);return false;"
                            Font-Bold="true" />&nbsp;
                        <asp:HiddenField ID="hndCount" runat="server" Value="1" />
                        <input type="hidden" id="hndCounthtml" />
                    </td>
                </tr>
                <tr id="trSection2" style="display: none;" runat="server">
                    <td width="100%" align="left">
                        <hr />
                        <uc:AttachmentSection ID="Attachment2" runat="server" PanelNumber="7" />
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
                        <uc:AttachmentSection ID="Attachment3" runat="server" PanelNumber="7" />
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
                        <uc:AttachmentSection ID="Attachment4" runat="server" PanelNumber="7" />
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
                        <uc:AttachmentSection ID="Attachment5" runat="server" PanelNumber="7" />
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
                        <asp:Button ID="btnSaveAttachments" runat="server" Text="Save Attachments" OnClick="btnSaveAttachments_Click"
                            OnClientClick="return FinalValidate();" />&nbsp;&nbsp;<asp:Button ID="btnCancelAttachment_Add"
                                runat="server" Text="Cancel" OnClick="btnCancelAttachment_Add_Click" />
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

    function CheckUnCheckAll(grid, bChecked) {
        var ctrls = document.getElementsByTagName('input');
        var i, chkID;
        if (grid == "Folder") chkID = "chkFolder";
        else if (grid == "File") chkID = "chkFile";
        else chkID = "chkTag";
        var cnt = 0;
        for (i = 0; i < ctrls.length; i++) {
            if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf(chkID) > 0) {
                ctrls[i].checked = bChecked;
            }
        }
    }

    function CheckAllUnchecked(grid) {
        var ctrls = document.getElementsByTagName('input');
        var i, chkID, chkHeader, chkHeaderID;
        if (grid == "Folder") { chkID = "chkFolder"; chkHeader = "chkHeaderFolder"; }
        else if (grid == "File") { chkID = "chkFile"; chkHeader = "chkHeaderFile"; }
        else { chkID = "chkTag"; chkHeader = "chkHeaderTag"; }
        var cnt = 0;
        for (i = 0; i < ctrls.length; i++) {
            if (ctrls[i].type == "checkbox") {
                if (ctrls[i].id.indexOf(chkID) > 0) {
                    if (ctrls[i].checked) cnt++;
                }
                else if (ctrls[i].id.indexOf(chkHeader) > 0)
                    chkHeaderID = ctrls[i].id;
            }
        }
        var gvID;
        if (grid == "Folder") gvID = '<%=gvFolders.ClientID %>';
        else if (grid == "File") gvID = '<%=gvFiles.ClientID %>';


        if (cnt == document.getElementById(gvID).rows.length - 1)
            document.getElementById(chkHeaderID).checked = true;
        else
            document.getElementById(chkHeaderID).checked = false;

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

        document.getElementById('ctl00_ContentPlaceHolder1_ctrlAttachment_trSection' + (intSection + 1)).style.display = "";
        document.getElementById('ctl00_ContentPlaceHolder1_ctrlAttachment_lnkAddNew' + intSection).style.display = "none";
        //alert(intSection);
        $('#hndCounthtml').val(intSection + 1);

        if (intSection > 1) {
            $('#<%=hndCount.ClientID %>').val(intSection + 1);
            document.getElementById('ctl00_ContentPlaceHolder1_ctrlAttachment_lnkRemove' + intSection).style.display = "none";
        }
    }

    function HideAttachmentSection(intSection) {
        document.getElementById('ctl00_ContentPlaceHolder1_ctrlAttachment_lnkAddNew' + (intSection - 1)).style.display = "";
        document.getElementById('ctl00_ContentPlaceHolder1_ctrlAttachment_trSection' + intSection).style.display = "none";
        $('#hndCounthtml').val($('#hndCounthtml').val() - 1);

        if (intSection > 2) {

            $('#<%=hndCount.ClientID %>').val(intSection - 1);
            document.getElementById('ctl00_ContentPlaceHolder1_ctrlAttachment_lnkRemove' + (intSection - 1)).style.display = "";
        }
        $('#ctl00_ContentPlaceHolder1_ctrlAttachment_Attachment' + (intSection) + '_txtNewFileName').text('');
        $('#ctl00_ContentPlaceHolder1_ctrlAttachment_Attachment' + (intSection) + '_txtFilePath').val('');
        document.getElementById('ctl00_ContentPlaceHolder1_ctrlAttachment_Attachment' + (intSection) + '_drpFolder').selectedIndex = 0;
        // document.getElementById('ctl00_ContentPlaceHolder1_ucAttachment_Attachment' + (intSection) + '_fpFile').value = "";
        // alert(document.getElementById('ctl00_ContentPlaceHolder1_ucAttachment_Attachment' + (intSection) + '_fpFile').value);
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
                if ($('#ctl00_ContentPlaceHolder1_ctrlAttachment_Attachment' + i + '_txtNewFileName').val() != "") {
                    totalFileName = totalFileName + $('#ctl00_ContentPlaceHolder1_ctrlAttachment_Attachment' + i + '_txtNewFileName').val() + "&~&~&";
                    var FileName = document.getElementById('ctl00_ContentPlaceHolder1_ctrlAttachment_Attachment' + i + '_fpFile').value;
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

            var FolderName = document.getElementById('ctl00_ContentPlaceHolder1_ctrlAttachment_Attachment' + j + '_drpFolder').selectedIndex;
            var FileName_value = document.getElementById('ctl00_ContentPlaceHolder1_ctrlAttachment_Attachment' + j + '_fpFile').value;
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
            __doPostBack('ctl00$ContentPlaceHolder1$ctrlAttachment$btnSaveAttachments', '');
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
