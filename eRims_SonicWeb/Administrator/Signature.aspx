<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="Signature.aspx.cs" Inherits="Administrator_Signature" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        function ConfirmRemove() {
            return confirm("Are you sure to delete?");
        }
        function ValidateAttachmentType(obj, args) {

            //check attchment type selected from dropdown        
            var arrPath = args.Value.split("\\");
            var arrExt = arrPath[arrPath.length - 1].split(".");
            //check Length of Extension
            if (arrExt.length > 0) {
                switch (arrExt[arrExt.length - 1].toLowerCase()) {
                    case 'jpg':
                    case 'gif':
                    case 'bmp':
                    case 'jpeg':
                    case 'tif':
                    case 'png':
                        args.IsValid = true;
                        break;
                    default:
                        args.IsValid = false;
                }
            }
            else {
                args.IsValid = false;
            }

        }

        function ShowPicture() {
            ShowDialog('SignaturePopup.aspx?PK=<%=PK_COI_Signature%>');
        }

        function ShowDialog(navigateurl) {
            var w = 480, h = 340;


            if (document.all || document.layers) {
                w = screen.availWidth;
                h = screen.availHeight;
            }

            var leftPos, topPos;
            var popW = 700, popH = 400;
            if (document.all)
            { leftPos = (w - popW) / 2; topPos = (h - popH) / 2; }
            else
            { leftPos = w / 2; topPos = h / 2; }

            window.open(navigateurl, "popup", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=" + popW + ",height=" + popH + ",top=" + topPos + ",left=" + leftPos);
        }
    </script>
    <asp:ValidationSummary ID="valSummary" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    <table cellpadding="2" cellspacing="1" width="100%">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left" class="bandHeaderRow">
                Administrator :: Signatures
            </td>
        </tr>
        <tr>
            <td id="tdGrid" runat="server" align="center">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="spacer" style="height: 5px">
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" align="right">
                            <asp:Button ID="btnAddNew" runat="server" Text="Add New" OnClick="btnAddNew_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:GridView ID="gvSignatures" runat="server" Width="100%" AutoGenerateColumns="false"
                                AllowPaging="true" PageSize="10" EmptyDataText="No Signature Record Exist." OnPageIndexChanging="gvSignatures_PageIndexChanging"
                                OnRowCommand="gvSignatures_RowCommand">
                                <HeaderStyle HorizontalAlign="left" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Description">
                                        <ItemStyle HorizontalAlign="left" Width="35%" />
                                        <ItemTemplate>
                                            <%#Eval("Fld_Desc")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Phone">
                                        <ItemStyle HorizontalAlign="left" Width="20%" />
                                        <ItemTemplate>
                                            <%#Eval("Phone")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email">
                                        <ItemStyle HorizontalAlign="left" Width="25%" />
                                        <ItemTemplate>
                                            <%#Eval("EMail")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="center" Width="20%" />
                                        <ItemTemplate>
                                            <asp:Button ID="btnEdit" runat="server" Text=" Edit " CommandArgument='<%#Eval("PK_COI_Signature")%>'
                                                CommandName="EditSignature" />&nbsp;
                                            <asp:Button ID="btnView" runat="server" Text="View" CommandArgument='<%#Eval("PK_COI_Signature")%>'
                                                CommandName="ViewSignature" />&nbsp;
                                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandArgument='<%#Eval("PK_COI_Signature")%>'
                                                CommandName="DeleteSignature" OnClientClick="return ConfirmRemove();" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td id="tdEdit" runat="server" align="center">
                <table cellpadding="2" cellspacing="2" width="90%">
                    <tr>
                        <td width="16%" align="left">
                            Description&nbsp;<span class="msg1">*</span>
                        </td>
                        <td width="4%" align="center">
                            :
                        </td>
                        <td width="28%" align="left">
                            <asp:TextBox ID="txtDesc" runat="server" MaxLength="23" />
                            <asp:RequiredFieldValidator ID="rfvDesc" runat="server" ControlToValidate="txtDesc"
                                SetFocusOnError="true" Display="None" ErrorMessage="Please enter Description"
                                ValidationGroup="vsErrorGroup" />
                        </td>
                        <td width="4%" align="center">
                            &nbsp;
                        </td>
                        <td width="16%" align="left">
                            Department Title
                        </td>
                        <td width="4%" align="center">
                            :
                        </td>
                        <td width="28%" align="left">
                            <asp:TextBox ID="txtDepartmentTitle" MaxLength="120" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Phone
                        </td>
                        <td align="center">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPhone" runat="server" MaxLength="12" onpaste="return false;"
                                onKeyPress="javascript:return FormatPhone(event,this.id);" />
                            <asp:RegularExpressionValidator ID="revContactPhone" runat="server" ErrorMessage="Please enter valid Phone Number"
                                ControlToValidate="txtPhone" ValidationExpression="\b[0-9]{3}-[0-9]{3}-[0-9]{4}\b"
                                Display="None" SetFocusOnError="true" ValidationGroup="vsErrorGroup" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td align="left">
                            Facsimile
                        </td>
                        <td align="center">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtFacsimile" runat="server" MaxLength="12" onpaste="return false;"
                                onKeyPress="javascript:return FormatPhone(event,this.id);" />
                            <asp:RegularExpressionValidator ID="revFacsimile" runat="server" ErrorMessage="Please enter valid Facsimile Number"
                                ControlToValidate="txtFacsimile" ValidationExpression="\b[0-9]{3}-[0-9]{3}-[0-9]{4}\b"
                                Display="None" SetFocusOnError="true" ValidationGroup="vsErrorGroup" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Email
                        </td>
                        <td align="center">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtEmail" runat="server" MaxLength="120" />
                            <asp:RegularExpressionValidator ID="regEmail" runat="server" ControlToValidate="txtEmail"
                                SetFocusOnError="true" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                Display="None" ErrorMessage="Please enter valid Email" ValidationGroup="vsErrorGroup" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td align="left">
                            Closing
                        </td>
                        <td align="center">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtClosing" runat="server" MaxLength="255" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            Image
                        </td>
                        <td align="center" valign="top">
                            :
                        </td>
                        <td align="left" valign="top">
                            <asp:FileUpload ID="fpImage" runat="server" />
                            <asp:CustomValidator ID="cstFile" runat="Server" ControlToValidate="fpImage" ErrorMessage="Invalid Attachment Type"
                                Display="None" ValidationGroup="vsErrorGroup" ClientValidationFunction="ValidateAttachmentType"></asp:CustomValidator>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td align="left">
                            <a id="lnkViewImage_Edit" style="display: none;" runat="server" href="#" onclick="ShowPicture();">
                                View Image</a> &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr style="padding-top: 15px;">
                        <td>
                            &nbsp;
                        </td>
                        <td align="center" colspan="6">
                            <asp:Label ID="lblError" runat="server" SkinID="lblError" EnableViewState="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7" align="center">
                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CausesValidation="true"
                                ValidationGroup="vsErrorGroup" />&nbsp;&nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false"
                                OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td id="tdView" runat="server" align="center">
                <table cellpadding="2" cellspacing="2" width="90%">
                    <tr>
                        <td width="16%" align="left">
                            Description
                        </td>
                        <td width="4%" align="center">
                            :
                        </td>
                        <td width="28%" align="left">
                            <asp:Label ID="lblDesc" runat="server" />
                        </td>
                        <td width="4%" align="center">
                            &nbsp;
                        </td>
                        <td width="16%" align="left">
                            Department Title
                        </td>
                        <td width="4%" align="center">
                            :
                        </td>
                        <td width="28%" align="left">
                            <asp:Label ID="lblDepartmentTitle" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Phone
                        </td>
                        <td align="center">
                            :
                        </td>
                        <td align="left">
                            <asp:Label ID="lblPhone" runat="server" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td align="left">
                            Facsimile
                        </td>
                        <td align="center">
                            :
                        </td>
                        <td align="left">
                            <asp:Label ID="lblFacsimile" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Email
                        </td>
                        <td align="center">
                            :
                        </td>
                        <td align="left">
                            <asp:Label ID="lblEmail" runat="server" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td align="left">
                            Closing
                        </td>
                        <td align="center">
                            :
                        </td>
                        <td align="left">
                            <asp:Label ID="lblClosing" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Image
                        </td>
                        <td align="center">
                            :
                        </td>
                        <td align="left" colspan="5">
                            <a id="lnkViewImage_View" style="display: none;" runat="server" href="#" onclick="ShowPicture()">
                                View Image</a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7" align="center">
                            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
