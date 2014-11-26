<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="LU_Executive_Risk_Defense_Attorney.aspx.cs" Inherits="Administrator_LU_Executive_Risk_Defense_Attorney" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/jquery.maskedinput.js"></script>
    <script type="text/javascript">
        function ValSave() {
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqAttachType').enabled = false;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqFile').enabled = false;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_cstFile').enabled = false;

            if (document.getElementById('<%=txtZipcode.ClientID%>').value == "_____-____")
                document.getElementById('<%=txtZipcode.ClientID%>').value = "";

            if (document.getElementById('<%=txtTelephone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtTelephone.ClientID%>').value = "";

            if (Page_ClientValidate())
                return true;
            else
                return false;
        }


        jQuery(function ($) {
            $("#<%=txtTelephone.ClientID%>").mask("999-999-9999");

        });
    </script>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <div runat="Server" id="divViewAttorneyList">
        <table width="100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td class="bandHeaderRow" colspan="4" align="left">
                    Defense Attorney
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 5px">
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <table cellpadding="0" cellspacing="0" border="0" style="text-align: right; width: 100%;">
                        <tr>
                            <td>
                                <asp:Button ID="btnAddNew" runat="server" Text="Add New" ToolTip="Add new Defense Attorney Details"
                                    OnClick="btnAddNew_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 5px;">
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;">
                                <asp:GridView ID="gvDefenseAttorney" runat="server" AutoGenerateColumns="false" DataKeyNames="PK_LU_Executive_Risk_Defense_Attorney"
                                    Width="100%" OnRowCommand="gvDefenseAttorney_RowCommand" OnRowDataBound="gvDefenseAttorney_RowDataBound"
                                    AllowPaging="true"  OnPageIndexChanging="gvDefenseAttorney_PageIndexChanging" PageSize="20">
                                    <Columns>
                                         <asp:TemplateField HeaderText="Name">
                                            <ItemStyle Width="20%" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Firm">
                                            <ItemStyle Width="20%" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblFirm" runat="server" Text='<%# Eval("Firm")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Address 1">
                                            <ItemStyle Width="15%" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblAddress_1" runat="server" Text='<%# Eval("Address_1")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Address 2">
                                            <ItemStyle Width="15%" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblAddress_2" runat="server" Text='<%# Eval("Address_2")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="City">
                                            <ItemStyle Width="15%" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblCity" runat="server" Text='<%# Eval("City")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Panel?">
                                            <ItemStyle Width="5%" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblPanel" runat="server" Text='<%#(Eval("Panel").ToString() == "N" ? "No" : "Yes") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status">
                                            <ItemStyle Width="5%" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblActive" runat="server" Text='<%#(Eval("Active").ToString() == "N" ? "In Active" : "Active") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemStyle Width="5%" />
                                            <ItemTemplate>
                                                <asp:Button ID="btnEdit" CommandName="EditItem" CommandArgument='<%#Eval("PK_LU_Executive_Risk_Defense_Attorney")%>'
                                                    runat="server" Text="Edit" ToolTip="Edit the Security Details" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="center" Width="60px" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="center" />
                                    <EmptyDataTemplate>
                                        No Record found.
                                    </EmptyDataTemplate>
                                    <PagerSettings Visible="False" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div id="divModifyAttorney" runat="server">
            <div class="bandHeaderRow">
                Defense Attorney</div>
            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                <tr>
                    <td align="left" width="18%">
                        Firm&nbsp;<span id="Span1" style="color: Red;">*</span>
                    </td>
                    <td align="center" width="4%">
                        :
                    </td>
                    <td align="left" width="28%">
                        <asp:TextBox ID="txtFirm" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFirm" runat="server" ControlToValidate="txtFirm"
                            Display="none" Text="*" ErrorMessage="Please Enter Firm" SetFocusOnError="true"
                            ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                    </td>
                    <td align="left" width="18%">
                        Name
                    </td>
                    <td align="center" width="4%">
                        :
                    </td>
                    <td align="left" width="28%">
                        <asp:TextBox ID="txtName" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        Address 1
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtAddress1" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                    </td>
                    <td align="left">
                        Address 2
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtAddress2" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        City
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtCity" runat="server" Width="170px" MaxLength="20"></asp:TextBox>
                    </td>
                    <td align="left">
                        State
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="drpState" Width="180px" runat="server" SkinID="dropGen">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        Zip Code (XXXXX-XXXX)&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtZipcode" runat="server" Width="170px" MaxLength="10" onKeyPress="javascript:return FormatZipCode(event,this.id);"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revZipCode" ControlToValidate="txtZipCode" runat="server"
                            ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Zip Code in xxxxx-xxxx format."
                            Display="none" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator>
                    </td>
                    <td align="left">
                        Telephone (XXX-XXX-XXXX)&nbsp;<span id="Span8" style="color: Red; display: none;"
                            runat="server">*</span>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtTelephone" runat="server" Width="170px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revTelephone" ControlToValidate="txtTelephone"
                            runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Telephone Number in xxx-xxx-xxxx format."
                            Display="none" ValidationExpression="\d{3}(-\d{3})(-\d{4})"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        E-Mail&nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtEmail" runat="server" Width="170px" MaxLength="255"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                            ValidationGroup="vsErrorGroup" Display="None" ErrorMessage="Email Address Is Invalid"
                            SetFocusOnError="True" ToolTip="Email Address Is Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                    </td>
                    <td align="left">
                        Panel?
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td align="left">
                        <asp:RadioButtonList ID="rdoPanel" runat="server" SkinID="YesNoType">
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        Active?
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td align="left">
                        <asp:RadioButtonList ID="rdoActive" runat="server" SkinID="YesNoType">
                        </asp:RadioButtonList>
                    </td>
                
                </tr>
                <tr>
                    <td align="left" valign="top">
                        Notes&nbsp;<span id="Span10" style="color: Red; display: none;" runat="server">*</span>
                    </td>
                    <td align="center" valign="top">
                        :
                    </td>
                    <td align="left" colspan="4">
                        <uc:ctrlMultiLineTextBox ID="txtNotes" runat="server" />
                    </td>
                </tr>
            </table>
             <br />
                <table width="100%" cellpadding="3" cellspacing="1" border="0">
            <tr>
                <td align="center">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td align="center">
                                &nbsp;<asp:Label runat="server" ID="lblError" CssClass="error" EnableViewState="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnSave" runat="server" Text=" Save " CausesValidation="true" ValidationGroup="vsErrorGroup"
                                    OnClick="btnSave_Click" />&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false"
                                    OnClick="btnCancel_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
