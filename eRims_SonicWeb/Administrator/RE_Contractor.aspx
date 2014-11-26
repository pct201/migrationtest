<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="RE_Contractor.aspx.cs"
    Inherits="Administrator_RE_Contractor" Title="eRIMS Sonic :: Contractor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ValidationSummary ID="valSummary" runat="server" ShowMessageBox="true" ShowSummary="false" />
    <div>
        <asp:UpdateProgress runat="server" ID="upProgress" DisplayAfter="100">
            <ProgressTemplate>
                <div class="UpdatePanelloading" id="divProgress" style="width: 100%;">
                    <table id="ProgressTable" cellpadding="0" cellspacing="0" border="0" style="width: 100%;
                        height: 100%;">
                        <tr align="center" valign="middle">
                            <td class="LoadingText" align="center" valign="middle">
                                <img src="../Images/indicator.gif" alt="Loading" />&nbsp;&nbsp;&nbsp;Please Wait..
                            </td>
                        </tr>
                    </table>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
    <table width="100%" align="center" cellpadding="2" cellspacing="3">
        <tr>
            <td class="bandHeaderRow" align="left" colspan="3">
                <asp:Label ID="lblPageHeader" runat="server" Text="Administrator :: Contractor Select"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlContractor" runat="server">
        <table width="90%" align="center" cellpadding="2" cellspacing="3" align="center">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr align="center">
                <td style="width: 13%">
                    Select a Contractor <span class="mf">*</span>
                </td>
                <td style="width: 4%" align="right">
                    :
                </td>
                <td style="width: 60%" align="left">
                    <asp:DropDownList ID="ddlContractor" runat="server" Width="200px">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvddlContractor" runat="server" ControlToValidate="ddlContractor"
                        InitialValue="0" Display="None" ErrorMessage="Please Select Contractor." SetFocusOnError="true"></asp:RequiredFieldValidator>
                </td>
                <td style="width: 16%;">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="Spacer" style="height: 10px;" colspan="4">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                </td>
                <td>
                    <asp:Button ID="btnNext" runat="server" Text="  Edit  " OnClick="btnNext_Click" CausesValidation="true" />&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnAddNew" runat="server" Text="  Add  " OnClick="btnAddNew_Click"
                        CausesValidation="false" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlAddEdit" runat="server">
        <table width="90%" align="center" cellpadding="2" cellspacing="3" align="center">
            <tr align="left">
                <td style="width: 18%">
                    Company <span class="mf">*</span>
                </td>
                <td align="right" style="width: 4%;">
                    :
                </td>
                <td style="width: 28%">
                    <asp:TextBox ID="txtCompany" runat="server" MaxLength="75"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtCompany" runat="server" ControlToValidate="txtCompany"
                        ErrorMessage="Please Enter Company." SetFocusOnError="true" Display="None"></asp:RequiredFieldValidator>
                </td>
                <td style="width: 18%">
                    Contact
                </td>
                <td align="right" style="width: 4%;">
                    :
                </td>
                <td style="width: 28%">
                    <asp:TextBox ID="txtContact" runat="server" MaxLength="75"></asp:TextBox>
                </td>
            </tr>
            <tr align="left">
                <td>
                    Address 1
                </td>
                <td align="right" style="width: 4%;">
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtAddress1" runat="server" MaxLength="50"></asp:TextBox>
                </td>
                <td>
                    Address 2
                </td>
                <td align="right" style="width: 4%;">
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtAddress2" runat="server" MaxLength="50"></asp:TextBox>
                </td>
            </tr>
            <tr align="left">
                <td>
                    City
                </td>
                <td align="right" style="width: 4%;">
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtCity" runat="server" MaxLength="50"></asp:TextBox>
                </td>
                <td>
                    State
                </td>
                <td align="right" style="width: 4%;">
                    :
                </td>
                <td>
                    <asp:DropDownList ID="ddlState" runat="server" SkinID="dropGen" Width="156px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr align="left">
                <td>
                    Zip Code (XXXXX-XXXX)
                </td>
                <td align="right" style="width: 4%;">
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtZipCode" runat="server" MaxLength="10" onKeyPress="javascript:return FormatZipCode(event,this.id);"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revtxtZipCode" runat="server" ControlToValidate="txtZipCode"
                        ErrorMessage="Please Enter Zip Code in (XXXXX-XXXX) format." SetFocusOnError="true"
                        ValidationExpression="\d{5}(-\d{4})?" Display="None"></asp:RegularExpressionValidator>
                </td>
                <td>
                    Telephone (XXX-XXX-XXXX)
                </td>
                <td align="right" style="width: 4%;">
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtTelephone" runat="server" MaxLength="12" SkinID="txtPhone"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revtxtTelephone" runat="server" ControlToValidate="txtTelephone"
                        ErrorMessage="Please Enter Telephone in (XXX-XXX-XXXX) format." SetFocusOnError="true"
                        ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" Display="None"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr align="left">
                <td>
                    Facsimile (XXX-XXX-XXXX)
                </td>
                <td align="right" style="width: 4%;">
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtFacsimile" runat="server" MaxLength="12" SkinID="txtPhone"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revtxtFacsimile" runat="server" ControlToValidate="txtFacsimile"
                        ErrorMessage="Please Enter Facsimile in (XXX-XXX-XXXX) format." SetFocusOnError="true"
                        ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" Display="None"></asp:RegularExpressionValidator>
                </td>
                <td>
                    E-Mail
                </td>
                <td align="right" style="width: 4%;">
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" MaxLength="255"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revtxtEmail" runat="server" ControlToValidate="txtEmail"
                        ErrorMessage="E-mail is not valid." SetFocusOnError="true" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        Display="None"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr align="left">
                <td>
                    Active
                </td>
                <td align="right" style="width: 4%;">
                    :
                </td>
                <td>
                    <asp:RadioButtonList ID="rdblActive" runat="server">
                        <asp:ListItem Text="Yes" Value="Y" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td colspan="8" align="center">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CausesValidation="true" OnClick="btnSave_Click" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false"
                        OnClick="btnCancel_Click" />
                </td>
            </tr>
            <tr>
                <td class="Spacer" style="height: 10px;" colspan="8">
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
