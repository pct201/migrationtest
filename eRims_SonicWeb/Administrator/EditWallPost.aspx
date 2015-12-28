<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="EditWallPost.aspx.cs" Inherits="Administrator_EditWallPost" %>

   
    <%@ Register Src="~/Controls/Notes/Notes.ascx"  TagName="ctrlMultiLineTextBox"
    TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        function openWindow(strURL) {
            oWnd = window.open(strURL, "Erims", "location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=300");
            oWnd.moveTo(260, 180);
            return false;
        }

        function ValidateAttachmentType(obj, args) {

            var file1 = document.getElementById('<%=fludAttschment.ClientID%>').value;
            if (file1 == '') {
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }
            return args.IsValid;

        }
    </script>
    <asp:ValidationSummary ID="valSummary" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td class="dvContainer">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="tblGrid" align="left">
                            <div class="bandHeaderRow" style="text-align: center">
                                <asp:Label ID="lblHeadingMessage" runat="server" Text="Wall Post"></asp:Label></div>
                            <table align="center" cellpadding="5" cellspacing="5" width="70%">
                                <tr>
                                    <td width="18%" align="left" valign="top">
                                        Poster
                                    </td>
                                    <td width="2%" align="center" valign="top">
                                        :
                                    </td>
                                    <td width="80%" align="left" valign="top">
                                        <asp:Label ID="lblPoster" runat="server"></asp:Label>                                       
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        Date
                                    </td>
                                    <td align="center" valign="top">
                                        :
                                    </td>
                                    <td align="left" valign="top">
                                        <asp:Label ID="lblDate" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                      <asp:Label ID="lblTopic" runat="server" Text="Topic"></asp:Label> <span class="mf" style="position:absolute">*</span>
                                    </td>
                                    <td align="center" valign="top">
                                        :
                                    </td>
                                    <td align="left" valign="top">
                                        <asp:TextBox ID="txtTopic" Width="570px" runat="server" MaxLength="250" TabIndex="3"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rvTopic" runat="server" ErrorMessage="Please Enter Topic"
                                            ControlToValidate="txtTopic" Display="None" ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        Type
                                    </td>
                                    <td align="center" valign="top">
                                        :
                                    </td>
                                    <td align="left" valign="top">
                                        <asp:Label ID="lblType" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        Message<span class="mf">*</span>
                                    </td>
                                    <td align="center" valign="top">
                                        :
                                    </td>
                                    <td align="left" valign="top">
                                         <uc:ctrlMultiLineTextBox ID="txtMessage" runat="server"  ValidationGroup="vsErrorGroup" IsRequired="true" ControlType="TextBox" RequiredFieldMessage="Please Enter Message"  />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        Attachment
                                    </td>
                                    <td align="center" valign="top">
                                        :
                                    </td>
                                    <td align="left" valign="top">
                                        <asp:FileUpload ID="fludAttschment" runat="server" Width="300px" /> 
                                        &nbsp; &nbsp;<asp:LinkButton ID="lnkFileAttached" runat="server"></asp:LinkButton>&nbsp;&nbsp;
                                        <asp:LinkButton ID="lnkDelet" runat="server" ToolTip="Remove Attachment" OnClick="lnkDelet_Click" OnClientClick="javascript:return confirm('Are you sure to remove attchment?');">Remove</asp:LinkButton>
                                        <asp:HiddenField ID="hdFileNameStored" runat="server" />
                                        <asp:CustomValidator ID="cstFile" runat="Server" ControlToValidate="fludAttschment" ErrorMessage="Invalid Attachment Type"
                                            Display="None" ValidationGroup="vsErrorGroup" ClientValidationFunction="ValidateAttachmentType"></asp:CustomValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Spacer" style="height: 10px;">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" style="height: 10px;">
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnSave" runat="server" SkinID="Save" CausesValidation="true" ValidationGroup="vsErrorGroup"
                                OnClick="btnSave_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnCancel" runat="server" CausesValidation="false" CssClass="btn"
                                Style="width: 80px;" Text="Cancel" OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" style="height: 10px;">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

