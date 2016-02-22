<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Attachment.ascx.cs" Inherits="Controls_Attachments_Attachment_Property_Claims" %>
<script type="text/javascript" src="<%=AppConfig.SiteURL%>/JavaScript/Validator.js"></script>
<script type="text/javascript">
    function ShowMailPageClaim(m_strAttIds) {
        var oWnd = window.open("<%=AppConfig.SiteURL%>EventAttachmentMail.aspx?ClaimIds=" + m_strAttIds, "Erims", "location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=600,height=300");
        oWnd.moveTo(460, 180);
        return false;
    }
        </script>
<asp:ValidationSummary ID="valSummayAttachment" runat="server" ValidationGroup="AddAttachmentClaim"
    ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following field(s):" />
<asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="AddTag"
    ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following field(s):" />
<input type="hidden" id="hdnBackTo" runat="server" />
<table cellpadding="2" cellspacing="1" width="100%" id="tblFolderList" runat="server">
    <tr>
        <td width="100%" align="left">
            <asp:GridView ID="gvFolders" runat="server" Width="100%" AutoGenerateColumns="false"
                EmptyDataText="No Attachment Folder Found">
                <Columns>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Left">
                        <HeaderStyle HorizontalAlign="Left" Width="5%" />
                        <ItemStyle HorizontalAlign="Left" Width="5%" />
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkHeaderFolder" runat="server" onclick="CheckUnCheckAll('Folder',this.checked)" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkFolder" runat="server" onclick="CheckAllUnchecked('Folder');" />
                            <input type="hidden" id="hdnID" runat="server" value='<%#Eval("PK_Virtual_Folder")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Folders" HeaderStyle-HorizontalAlign="Left">
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
                EmptyDataText="No Files Found For Selected Folder(s)" OnRowCommand="gvFiles_RowCommand" HeaderStyle-HorizontalAlign="Left"
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
                            <input type="hidden" id="hdnView" runat="server" value='<%# Eval("bView") %>' />
                            <input type="hidden" id="hdnAdd" runat="server" value='<%# Eval("bAdd") %>' />
                            <input type="hidden" id="hdnEdit" runat="server" value='<%# Eval("bEdit") %>' />
                            <input type="hidden" id="hdnDelete" runat="server" value='<%# Eval("bDelete") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Documents from Select Folders" SortExpression="Description">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDocName" runat="server" Text='<%# Convert.ToString(Eval("Description")) %>' />
                            <input type="hidden" id="hdnID" runat="server" value='<%#Eval("PK_Property_Claims_Attacments_ID")%>' />
                            <input type="hidden" id="hdnFileName" runat="server" value='<%#Eval("Attachment_Path") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="Pages" HeaderStyle-HorizontalAlign="Center" SortExpression="Page_Count">
                        <ItemStyle Width="10%" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <%# Eval("Page_Count") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date Attached" SortExpression="Attach_Date">
                        <ItemStyle Width="15%" />
                        <ItemTemplate>
                            <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Attach_Date")) %>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Action">
                        <ItemStyle Width="13%" />
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CommandName="EditAttachment"
                                CommandArgument='<%# Eval("PK_Property_Claims_Attacments_ID")%>' />&nbsp;
                            <asp:LinkButton ID="lnkView" runat="server" Text="View" CommandName="ViewAttachment"
                                CommandArgument='<%# Eval("PK_Property_Claims_Attacments_ID")%>' />&nbsp;
                            <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="DeleteAttachment"
                                CommandArgument='<%# Eval("PK_Property_Claims_Attacments_ID") + ":" + Eval("Attachment_Path") %>'
                                OnClientClick="return confirm('Are you sure to delete the attachment?')" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <asp:Button ID="btnViewPDF" runat="server" Text="View Selections (PDFs only)" OnClick="btnViewPDF_Click"
                Width="200px" OnClientClick="return CheckSeleted('File');" />&nbsp;
            <%--<asp:Button ID="btnRemoveAttachment" runat="server" Text="Remove" OnClick="btnRemoveAttachment_Click" OnClientClick="return DeleteConfirm('File2');" />&nbsp;--%>
            <asp:Button ID="btnCancelFile" runat="server" Text="Cancel" OnClick="btnCancelFile_Click" />
            <span style="padding-left:500px"><asp:Button ID="btnEmail" runat="server" Text="Email Selected Attachments" Width="200px"  OnClick="btnEmail_Click" /></span>

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
            <table cellpadding="3" cellspacing="1" width="100%">
                <tr>
                    <td width="18%" align="left">
                        Folder&nbsp;<span style="color: Red">*</span>
                    </td>
                    <td width="4%" align="center">
                        :
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="drpFolder" runat="server" Width="500px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvFolder" runat="server" ControlToValidate="drpFolder"
                            InitialValue="0" ValidationGroup="AddAttachmentClaim" ErrorMessage="Please select Folder"
                            SetFocusOnError="true" Display="None" />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        File to Attach&nbsp;<span style="color: Red">*</span>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td align="left">
                        <asp:FileUpload ID="fpFileClaim" runat="server" Width="500px" />
                        <asp:RequiredFieldValidator ID="rfvFileClaim" runat="server" ControlToValidate="fpFileClaim"
                            ErrorMessage="Please select File for attachment" SetFocusOnError="true" Display="None"
                            ValidationGroup="AddAttachmentClaim" />
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top">
                        <%--New File Name<br />
                        (Automatically populated by the browse button. Edit only if necessary)--%>
                    </td>
                    <td align="center" valign="top">
                       
                    </td>
                    <td align="left" valign="top">
                        <asp:TextBox ID="txtNewFileName" runat="server" Width="500px" MaxLength="255" Rows="3" Visible="false"
                            TextMode="MultiLine" onkeypress="javascript:return CheckMaxLength(event,this,255);"
                            onchange="javascript:return CheckMaxLength(event,this,255);" /><br />
                        <%--(255 characters)--%>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:Button ID="btnAddAttachment" runat="server" Text="Add Attachment" OnClick="btnAddAttachment_Click"
                            OnClientClick="return Page_ClientValidate('AddAttachmentClaim')" />&nbsp;
                        <input type="hidden" id="hdnVirtualFolderID" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <%--<tr>
                    <td align="left" valign="top">
                        Select Tag to add
                    </td>
                    <td align="center" valign="top">
                        :
                    </td>
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td width="40%" align="left" valign="top">
                                    <asp:DropDownList ID="drpTag" runat="server" Width="200px" SkinID="dropGen" />
                                    <asp:RequiredFieldValidator ID="rfvTag" runat="server" ValidationGroup="AddTag" ControlToValidate="drpTag"
                                        ErrorMessage="Please select Tag to Add" Display="None" SetFocusOnError="true"
                                        InitialValue="0" />
                                    <br />
                                    <br />
                                    <asp:Button ID="btnAddTag" runat="server" Text="Add Selected Tag" Width="130px" CausesValidation="true"
                                        ValidationGroup="AddTag" OnClick="btnAddTag_Click" />
                                </td>
                                <td width="2%" valign="top">
                                    &nbsp;
                                </td>
                                <td align="left" valign="top">
                                    <asp:GridView ID="gvTags" runat="server" Width="100%" AutoGenerateColumns="false"
                                        EmptyDataText="No Tags Added For Selected File">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemStyle HorizontalAlign="Left" Width="7%" />
                                                <HeaderStyle HorizontalAlign="Left" Width="7%" />
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkHeaderTag" runat="server" onclick="CheckUnCheckAll('Tag',this.checked)" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkTag" runat="server" onclick="CheckAllUnchecked('Tag');" />
                                                    <input type="hidden" id="hdnID" runat="server" value='<%#Eval("PK_Attachment_Tag")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tags">
                                                <ItemTemplate>
                                                    <%# Eval("Tag_Name") %>
                                                    <input type="hidden" id="hdnLU_Tag" runat="server" value='<%#Eval("FK_LU_Tag") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <br />
                                    <br />
                                    <asp:Button ID="btnDeleteTag" runat="server" Text="Delete Checked Tag(s)" Width="170px"
                                        OnClientClick="return DeleteConfirm('Tag');" OnClick="btnDeleteTag_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>--%>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:Button ID="btnCancelAttachment" runat="server" Text="Cancel" OnClick="btnCancelAttachment_Click" />
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
            else if (grid == "Tag") alert("Please select Tag(s) to delete");
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
        else gvID = '<%=gvFiles.ClientID %>';
      
        if (cnt == document.getElementById(gvID).rows.length - 1)
            document.getElementById(chkHeaderID).checked = true;
        else
            document.getElementById(chkHeaderID).checked = false;

    }

    function openWindow(strURL) {
        oWnd = window.open(strURL, "Erims", "location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=300");
        //oWnd.moveTo(260,180);
        return false;
    }

</script>

