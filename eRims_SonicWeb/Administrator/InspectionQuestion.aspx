<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="InspectionQuestion.aspx.cs"
    Inherits="Administrator_InspectionQuestion" Title="eRIMS Sonic :: Inspection Questions" %>

<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    <%--<asp:UpdatePanel runat="server" ID="updInspection">
<ContentTemplate>--%>
    <div id="divQuestionViewList" style="display: block;" runat="Server">
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="bandHeaderRow" colspan="4" align="left">
                    Administrator :: Inspection Questions
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
                <td colspan="2" align="center">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr align="left">
                            <td>
                                <asp:LinkButton runat="server" ID="lnkAddNew" Text="Add New" OnClick="lnkAddNew_Click"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:GridView ID="gvQuestion" AllowPaging="true" PageSize="20" runat="server" Width="100%"
                                    AutoGenerateColumns="false" OnPageIndexChanging="gvQuestion_PageIndexChanging"
                                    OnRowCreated="gvQuestion_RowCreated" OnRowEditing="gvQuestion_RowEditing" OnRowCommand="gvQuestion_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Focus Area">
                                            <ItemStyle Width="15%" />
                                            <ItemTemplate>
                                                <%# Eval("Item_Number_Focus_Area") %>
                                                <asp:HiddenField runat="Server" ID="hdnInspectionQuestionID" Value='<%# Eval("PK_Inspection_Questions_ID") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Number">
                                            <ItemStyle Width="10%" />
                                            <ItemTemplate>
                                                <%#Eval("Question_Number") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Question">
                                            <ItemStyle Width="20%" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="lnkView" Text='<%#Eval("Question_Text") %>' CommandName="View"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Guidance">
                                            <ItemStyle Width="45%" />
                                            <ItemTemplate>
                                                <%#Eval("Guidance_Text")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemStyle Width="5%" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="lnkEdit" Text="Edit" CommandName="Edit"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Remove">
                                            <ItemStyle Width="5%" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="lnkRemove" Text="Remove" CommandName="Remove"
                                                    OnClientClick="return confirm('Are you sure to delete?');"></asp:LinkButton>
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
        </table>
    </div>
    <div id="divAddNewQuestion" style="display: none;" runat="server">
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="bandHeaderRow" colspan="4" align="left">
                    Administrator :: Inspection Questions
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
            <tr runat="server" id="trGroupAdd" style="display: block;">
                <td style="width: 20%">
                    &nbsp;
                </td>
                <td colspan="2">
                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                        <tr>
                            <td style="width: 18%" align="left">
                                Focus Area<span style="color: Red;">*</span>
                            </td>
                            <td style="width: 4%" align="center">
                                :
                            </td>
                            <td colspan="4" align="left">
                                <asp:TextBox runat="server" ID="txtFocusArea" MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvFocusArea" ControlToValidate="txtFocusArea" Display="None"
                                    runat="server" InitialValue="" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Focus Area"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="left">
                                Question Number<span style="color: Red;">*</span>
                            </td>
                            <td valign="top" align="center">
                                :
                            </td>
                            <td colspan="4" align="left">
                                <asp:TextBox runat="server" ID="txtQuestionNumber"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvQuestionNumber" ControlToValidate="txtQuestionNumber"
                                    Display="None" runat="server" InitialValue="" Text="*" ValidationGroup="vsErrorGroup"
                                    ErrorMessage="Please Enter Question Number"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="left">
                                Question Text<span style="color: Red;">*</span>
                            </td>
                            <td valign="top" align="center">
                                :
                            </td>
                            <td colspan="4" align="left">
                                <uc:ctrlMultiLineTextBox runat="server" ID="txtQuestionText" ControlType="TextBox"
                                    MaxLength="500" Width="450" IsRequired="true" ValidationGroup="vsErrorGroup"
                                    RequiredFieldMessage="Please Enter Question" />
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="left">
                                Guidance Text<span style="color: Red;">*</span>
                            </td>
                            <td valign="top" align="center">
                                :
                            </td>
                            <td colspan="4" align="left">
                                <uc:ctrlMultiLineTextBox runat="server" ID="txtGuidanceText" ControlType="TextBox"
                                    MaxLength="500" Width="450" IsRequired="true" ValidationGroup="vsErrorGroup"
                                    RequiredFieldMessage="Please Enter Guidance for the Question" />
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="left">
                                Deficient Answer
                            </td>
                            <td valign="top" align="center">
                                :
                            </td>
                            <td colspan="4" align="left">
                                <asp:RadioButtonList ID="rdoDeficientAnswer" runat="server" SkinID="YesNoType" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 20%">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div id="divViewQuestion" style="display: none;" runat="server">
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="bandHeaderRow" colspan="4" align="left">
                    Administrator :: Inspection Questions
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
            <tr runat="server" id="tr1" style="display: block;">
                <td style="width: 20%">
                    &nbsp;
                </td>
                <td colspan="2">
                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                        <tr>
                            <td style="width: 18%" align="left">
                                Focus Area
                            </td>
                            <td style="width: 4%" align="center">
                                :
                            </td>
                            <td colspan="4" align="left">
                                <asp:Label runat="server" ID="lblFocusArea"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="left">
                                Question Number
                            </td>
                            <td valign="top" align="center">
                                :
                            </td>
                            <td colspan="4" align="left">
                                <asp:Label runat="server" ID="lblQuestionNumber"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="left">
                                Question Text
                            </td>
                            <td valign="top" align="center">
                                :
                            </td>
                            <td colspan="4" align="left">
                                <uc:ctrlMultiLineTextBox runat="server" ID="lblQuestionText" ControlType="Label"
                                    Width="450" />
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="left">
                                Guidance Text
                            </td>
                            <td valign="top" align="center">
                                :
                            </td>
                            <td colspan="4" align="left">
                                <uc:ctrlMultiLineTextBox runat="server" ID="lblGuidanceText" ControlType="Label"
                                    Width="450" />
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="left">
                                Deficient Answer
                            </td>
                            <td valign="top" align="center">
                                :
                            </td>
                            <td colspan="4" align="left">
                                <asp:Label ID="lblDeficientAnswer" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 20%">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <table cellpadding="5" cellspacing="5" border="0" width="100%">
        <tr>
            <td style="width: 25%">
                &nbsp;
            </td>
            <td align="right">
                <asp:Button ID="btnSave" runat="server" Text="Save" CausesValidation="true" ValidationGroup="vsErrorGroup"
                    OnClick="btnSave_Click" />
            </td>
            <td style="width: 2%">
                &nbsp;
            </td>
            <td align="left">
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false"
                    OnClick="btnCancel_Click" />
            </td>
            <td style="width: 25%">
                &nbsp;
            </td>
        </tr>
    </table>
    <%--</ContentTemplate>
</asp:UpdatePanel>--%>
</asp:Content>
