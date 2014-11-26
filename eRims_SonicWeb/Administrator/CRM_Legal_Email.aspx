<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="CRM_Legal_Email.aspx.cs" Inherits="Administrator_CRM_Legal_Email" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="MultiLineTextBox" TagPrefix="uc"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
    function AddNewGroup() {
        document.getElementById('<%=trStatusAdd.ClientID %>').style.display = "block";
        document.getElementById('<%=lnkCancel.ClientID %>').style.display = "inline";
    }

    function CheckValidation() {
        if (Page_ClientValidate("vsError")) {
            var bValid = ValidateRecipientEmails();
            if (!bValid) {
                alert('One or more Email Address in Recipient List is invalid.');
                return false;
            }
            else {
                var bValid = ValidateCCRecipientEmails();
                if (!bValid) {
                    alert('One or more Email Address in CC Recipient List is invalid.');
                    return false;
                }
                else
                    return true;
            }
        }
        else
            return false;
    }

    function validate(email) {
        var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
        return reg.test(email);
    }

    function trim(str) {
        var str = str.replace(/^\s\s*/, ''),
		ws = /\s/,
		i = str.length;
        while (ws.test(str.charAt(--i)));
        return str.slice(0, i + 1);
    }

    function CheckEmailIds(objTxt) {
        var status = true;
        var i = 0;
        var emails = objTxt.value.split(",");
        for (i = 0; i < emails.length; i++) {
            if (!validate(trim(emails[i]))) {
                //alert("Incorrect format: " + emails[i]);
                status = false;
                break;
            }
        }
        return status;
    }

    function ValidateRecipientEmails() {
        var txt = document.getElementById('<%=txtRecipients.ClientID%>');
        if (txt.value != '') {
            var bValid = CheckEmailIds(txt);
            return bValid;
        }
        else
            return true;
    }

    function ValidateCCRecipientEmails() {
        var txt = document.getElementById('<%=txtCCRecipients.ClientID%>');
        if (txt.value != '') {
            var bValid = CheckEmailIds(txt);
            return bValid;
        }
        else
            return true;
    }

    </script>

    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields :" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsError" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <asp:UpdatePanel runat="server" ID="updStatus">
        <ContentTemplate>
            <table cellspacing="0" cellpadding="0" width="100%">
                <tbody>
                    <tr>
                        <td colspan="4">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="bandHeaderRow" align="left" colspan="4">
                            Administrator :: CRM Legal Email
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10%">
                            &nbsp;
                        </td>
                        <td align="center" colspan="2">
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td align="left" width="100%">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:GridView ID="gvCRMLegalEmail" runat="server" Width="100%" AutoGenerateColumns="false"
                                                PageSize="10" EnableViewState="true" AllowPaging="true" OnRowCommand="gvCRMLegalEmail_RowCommand"
                                                OnPageIndexChanging="gvCRMLegalEmail_PageIndexChanging">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Subject">
                                                        <ItemStyle Width="40%" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSubject" runat="server" Text='<%#Eval("Subject") %>' Width="300px" CssClass="TextClip" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Body">
                                                        <ItemStyle Width="40%" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblBody" runat="server" Text='<%#Eval("Body") %>' Width="300px" CssClass="TextClip" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Status">
                                                        <ItemStyle Width="10%" />
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblActive" Text='<%#(Eval("Active").ToString() == "N" ? "In Active" : "Active") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemStyle Width="10%" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton runat="server" ID="lnkEdit" Text="Edit" CommandName="EditRecord"
                                                                CommandArgument='<%#Eval("PK_LU_CRM_Legal_Email") %>'></asp:LinkButton>
                                                        </ItemTemplate>
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
                                </tbody>
                            </table>
                        </td>
                        <td style="width: 10%">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10%">
                            &nbsp;
                        </td>
                        <td colspan="2">
                            <asp:LinkButton Style="display: inline" ID="lnkAddNew" OnClick="lnkAddNew_Click"
                                runat="server" Text="Add New"></asp:LinkButton>&nbsp;&nbsp;&nbsp;<asp:LinkButton
                                    Style="display: none" ID="lnkCancel" OnClick="lnkCancel_Click" runat="server"
                                    Text="Cancel"></asp:LinkButton>
                        </td>
                        <td style="width: 10%">
                            &nbsp;
                        </td>
                    </tr>
                    <tr style="display: none" id="trStatusAdd" runat="server">
                        <td style="width: 10%">
                            &nbsp;
                        </td>
                        <td colspan="2">
                            <table cellspacing="1" cellpadding="3" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td align="left">Subject<span class="mf">*</span></td>
                                        <td align="center">:</td>
                                        <td align="left">
                                           <asp:TextBox ID="txtSubject" runat="server" MaxLength="255" Width="300px"></asp:TextBox>
                                           <asp:RequiredFieldValidator ID="rfvSubject" runat="server" ValidationGroup="vsError"
                                                SetFocusOnError="true" ErrorMessage="Please Enter Subject" Display="none"
                                                ControlToValidate="txtSubject"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 25%" align="left" valign="top">
                                            Body<span class="mf">*</span>
                                        </td>
                                        <td style="width: 4%" align="center" valign="top">
                                            :
                                        </td>
                                        <td align="left" colspan="4" valign="top">
                                            <uc:MultiLineTextBox ID="txtBody" runat="server" MaxLength="4000" IsRequired="true" ValidationGroup="vsError" RequiredFieldMessage="Please Enter Body text" SetFocusOnError="true" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 25%" align="left" valign="top">
                                            Recipients<span class="mf">*</span><br />
                                            (Comma seperated Email-IDs)
                                        </td>
                                        <td style="width: 4%" align="center" valign="top">
                                            :
                                        </td>
                                        <td align="left" colspan="4" valign="top">
                                            <uc:MultiLineTextBox ID="txtRecipients" runat="server" MaxLength="2000" IsRequired="true" ValidationGroup="vsError" RequiredFieldMessage="Please Enter Recipients Email-IDs" SetFocusOnError="true" />                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 25%" align="left" valign="top">
                                            CC Recipients<br />
                                            (Comma seperated Email-IDs)
                                        </td>
                                        <td style="width: 4%" align="center" valign="top">
                                            :
                                        </td>
                                        <td align="left" colspan="4" valign="top">
                                            <uc:MultiLineTextBox ID="txtCCRecipients" runat="server" MaxLength="2000" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 25%" align="left">
                                            Active
                                        </td>
                                        <td style="width: 4%" align="center">
                                            :
                                        </td>
                                        <td align="left" colspan="4">
                                            <asp:RadioButtonList ID="rdblActive" runat="server">
                                                <asp:ListItem Text="Yes" Value="Y" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">
                                            <asp:Label ID="lblError" runat="server" SkinID="lblError" EnableViewState="false"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 25%" align="left">
                                        </td>
                                        <td style="width: 4%" align="center">
                                        </td>
                                        <td align="left">
                                            <asp:Button ID="btnAdd" OnClick="btnAdd_Click" runat="server" ValidationGroup="vsError"
                                                Text="Add" CausesValidation="false" OnClientClick="return CheckValidation();">
                                            </asp:Button>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                        <td style="width: 10%">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            &nbsp;
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

