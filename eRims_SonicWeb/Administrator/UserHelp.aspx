<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="UserHelp.aspx.cs"
    Inherits="Administrator_UserHelp" Title="Risk Insurance Management System :: Docs" %>

<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        function CheckValidation() {
            if (Page_ClientValidate("vsError")) {
                return CheckForURL();
            }
            else {
                return false;
            }
        }
        function CheckForURL()
        {
            var theurl = document.getElementById('ctl00_ContentPlaceHolder1_txtUrl').value;
            var fileval =  document.getElementById("<%= fpFile.ClientID %>").value;

            if (theurl.trim() = "")
            {
                if (theurl.toLowerCase().indexOf('http://') > -1) {
                    alert('please do not use "http://" prefix for URL.');
                    document.getElementById('ctl00_ContentPlaceHolder1_txtUrl').focus();
                    return false;
                }
                theurl = 'http://' + theurl;
                var tomatch = /http:\/\/[A-Za-z0-9\.-]{3,}\.[A-Za-z]{3}/
                if (tomatch.test(theurl)) {
                    return true;
                }
                else {
                    var MSG = 'The URL that has been entered does not test as a valid URL. Do you want to change it?';
                    var rtn = confirm(MSG);
                    if (rtn == true) {
                        document.getElementById('ctl00_ContentPlaceHolder1_txtUrl').focus();
                        return false;
                    }
                    else
                        return true;
                }
            }
        }
        function ExpandNotes(bExpand, imgPlusId, imgMinusId, txtId) {
            if (bExpand) {
                document.getElementById(txtId).rows = 30;
                document.getElementById(imgMinusId).style.display = "block";
                document.getElementById(imgPlusId).style.display = "none";
            }
            else {
                document.getElementById(txtId).rows = 5;
                document.getElementById(imgMinusId).style.display = "none";
                document.getElementById(imgPlusId).style.display = "block";
            }
        }

        function AtLeastOneURL_ClientValidate(sender, args) {
            if (document.getElementById("<%= txtUrl.ClientID %>").value.trim() == "" && document.getElementById("<%= fpFile.ClientID %>").value.trim() == "") {
                sender.errormessage = "Please Enter URL or Upload Document";
                args.IsValid = false;
            }
            else if(document.getElementById("<%= txtUrl.ClientID %>").value.trim() != "" && document.getElementById("<%= fpFile.ClientID %>").value.trim() != "")
            {
                sender.errormessage = "Please Enter either URL or select Upload Document";
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }
        }
    </script>

    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields :" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsError" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <asp:UpdatePanel runat="server" ID="updGroup" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="3">&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="bandHeaderRow" colspan="3" align="left">Administrator :: Docs
                    </td>
                </tr>
                <tr>
                    <td colspan="3">&nbsp;<asp:Label runat="server" ID="lblError" SkinID="lblError" EnableViewState="false"></asp:Label>
                    </td>
                </tr>
                <tr runat="server" id="trGrid">
                    <td style="width: 5%">&nbsp;
                    </td>
                    <td align="center">
                        <table cellpadding="3" cellspacing="2" border="0" width="100%">
                            <tr>
                                <td align="left">
                                    <asp:GridView ID="gvUserHelp" runat="server" Width="100%" AutoGenerateColumns="false"
                                        OnRowCommand="gvUserHelp_RowCommand" OnRowDataBound="gvUserHelp_OnRowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Document Type">
                                                <ItemTemplate>
                                                    <%# Eval("Type")%>
                                                </ItemTemplate>
                                                <ItemStyle Width="12%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Description">
                                                <ItemTemplate>
                                                    <%# Eval("Description")%>
                                                </ItemTemplate>
                                                <ItemStyle Width="38%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="URL">
                                                <ItemTemplate>
                                                    <%# Eval("URL")%>
                                                </ItemTemplate>
                                                <ItemStyle Width="25%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText=" Active?">
                                                <ItemTemplate>
                                                    <asp:RadioButtonList ID="rdbActive" Enabled="false" runat="server" CellPadding="0"
                                                        CellSpacing="0" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </ItemTemplate>
                                                <ItemStyle Width="15%" HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Edit" ItemStyle-Width="10%">
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" ID="lnkEdit" Text=" Edit " CommandArgument='<%#Eval("PK_UserHelp")%>'
                                                        CommandName="EditItem"></asp:LinkButton>
                                                    <asp:HiddenField ID="hdnActive" runat="server" Value='<%#Eval("Active")%>' />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <table cellpadding="4" cellspacing="0" width="100%">
                                                <tr>
                                                    <td width="100%" align="center" style="border: 1px solid #cccccc;">
                                                        <asp:Label ID="lblEmptyHeaderGridMessage" runat="server" Text="No Record Found"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">&nbsp;<asp:Button runat="server" ID="btnAddNew" Text="  Add  " OnClick="btnAddNew_Click"></asp:Button>
                                </td>
                            </tr>
                            <tr>
                                <td align="center"></td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 5%">&nbsp;
                    </td>
                </tr>
                <tr runat="server" id="trEdit" visible="false">
                    <td style="width: 5%">&nbsp;
                    </td>
                    <td align="center">
                        <table width="70%" cellpadding="3" cellspacing="2" border="0">
                            <tr>
                                <td width="10%"></td>
                                <td align="left" width="20%">Document Type <span class="mf">*</span>
                                </td>
                                <td width="2%" align="center">:
                                </td>
                                <td width="68%" align="left">
                                    <asp:DropDownList ID="drpType" runat="server" SkinID="dropGen" Width="200px">
                                        <%--  <asp:ListItem Selected="True" Text="--Select--" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="User Manual" Value="User Manual"></asp:ListItem>
                                        <asp:ListItem Text="How To Video" Value="How To Video"></asp:ListItem>--%>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator runat="server" ID="rfvType" ValidationGroup="vsError"
                                        SetFocusOnError="true" ErrorMessage="Please Select Document Type" Display="none"
                                        InitialValue="0" ControlToValidate="drpType"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td align="left" valign="top">Description <span class="mf">*</span>
                                </td>
                                <td align="center" valign="top">:
                                </td>
                                <td align="left" valign="top">
                                    <uc:ctrlMultiLineTextBox ID="txtDescription" ValidationGroup="vsError" ControlType="TextBox"
                                        runat="server" MaxLength="2000" Width="400" IsRequired="true" RequiredFieldMessage="Please Enter Description" />
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td align="left">URL <span class="mf">*</span>
                                </td>
                                <td align="center">:
                                </td>
                                <td align="left" nowrap="nowrap">http://<asp:TextBox ID="txtUrl" runat="server" MaxLength="500" Width="360px"></asp:TextBox>
                                  <%--  <asp:RequiredFieldValidator runat="server" ID="rfvUrl" ValidationGroup="vsError"
                                        SetFocusOnError="true" ErrorMessage="Please Enter URL" Display="none" ControlToValidate="txtUrl"></asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td align="left">Upload Document <span class="mf">*</span>
                                </td>
                                <td align="center">:
                                </td>
                                <td align="left" nowrap="nowrap">
                                    <asp:FileUpload ID="fpFile" runat="server" Width="500px" EnableViewState="true" />
                                    <asp:CustomValidator ID="AtLeastOneURL" runat="server" ErrorMessage="Please Enter URL or Upload Document"
                                        Display="none" ClientValidationFunction="AtLeastOneURL_ClientValidate" ValidationGroup="vsError" />
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td align="left">Active
                                </td>
                                <td align="center">:
                                </td>
                                <td align="left">
                                    <asp:RadioButtonList ID="rdbActiveEdit" runat="server" CellPadding="1" CellSpacing="1"
                                        RepeatDirection="Horizontal">
                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" class="spacer" height="10px"></td>
                            </tr>
                            <tr>
                                <td colspan="3"></td>
                                <td align="left" colspan="4">
                                    <asp:Button runat="server" ID="btnSave" Text=" Save " OnClick="btnSave_Click" ValidationGroup="vsError"
                                        OnClientClick="javascript:return CheckValidation();"></asp:Button>
                                    &nbsp;&nbsp;<asp:Button runat="server" CausesValidation="false" ID="btnCancel" Text="Cancel"
                                        OnClick="btnCancel_Click"></asp:Button>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 5%">&nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="3">&nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>
