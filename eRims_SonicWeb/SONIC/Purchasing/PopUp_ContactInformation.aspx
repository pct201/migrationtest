<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopUp_ContactInformation.aspx.cs"
    Inherits="SONIC_Purchasing_PopUp_ContactInformation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Risk Insurance Management System</title>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>

    <script type="text/javascript" src="../../JavaScript/JFunctions.js"></script>
    <script language="javascript" type="text/javascript">
    function ValidateFields(sender, args) {
            var msg = '';
            var ctrlIDs = document.getElementById('hdnControlIDs').value.split(',');
            var Messages = document.getElementById('hdnErrorMsgs').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('hdnControlIDs').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {
                        case "textarea":
                        case "text": if (ctrl.value == '') bEmpty = true; break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                        case "select-multiple": if (ctrl.selectedIndex == -1) bEmpty = true; break;
                    }
                    if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
                    if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                }
                if (msg.length > 0) {
                    sender.errormessage = msg;
                    args.IsValid = false;
                }
                else
                    args.IsValid = true;
            }
            else {
                args.IsValid = true;
            }
        }
        </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup"></asp:ValidationSummary>
    <asp:CustomValidator ID="CustomValidator" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
        Display="None" ValidationGroup="vsErrorGroup" />
    <input id="hdnControlIDs" runat="server" type="hidden" />
    <input id="hdnErrorMsgs" runat="server" type="hidden" />

    <div id="dvContact" runat="server">
        <table cellpadding="1" cellspacing="0" width="100%">
            <tr>
                <td colspan="2" width="100%">
                    &nbsp;
                </td>
            </tr>
            <tr id="trContact" runat="server">
                <td width="65%" align="left" valign="top">
                    &nbsp;&nbsp;<span class="NormalFontBold">Find Contact Information</span>
                </td>
                <td align="left" valign="top">
                    <table cellpadding="4" cellspacing="0" width="100%" border="0">
                        <tr>
                            <td align="left">
                                Contact Name
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtContactName" runat="server" Width="170px" MaxLength="50" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Title
                            </td>
                            <td align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtTitle" runat="server" Width="170px" MaxLength="50" />
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
                                <asp:TextBox ID="txtAddress1" runat="server" Width="170px" MaxLength="50" />
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
                                <asp:TextBox ID="txtCity" runat="server" Width="170px" MaxLength="50" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                State
                            </td>
                            <td align="center" valign="top">
                                :
                            </td>
                            <td align="left" valign="top">
                                <asp:ListBox ID="lstState" runat="server" SelectionMode="Multiple" Width="175px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="left">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                                    ValidationGroup="vsErrorGroup" />&nbsp;
                                <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />&nbsp;
                                <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;
                </td>
            </tr>
            <tr id="trGrid" runat="server">
                <td align="left" colspan="2">
                    <asp:GridView ID="gvContact" runat="server" AutoGenerateColumns="false" Width="100%"
                        EmptyDataText="No Record Found" AllowSorting="true" DataKeyNames="PK_Purchasing_Contacts"
                        AllowPaging="false" OnSorting="gvContact_Sorting" OnRowCreated="gvContact_RowCreated" OnRowDataBound="gvContact_RowDataBound"
                        OnRowCommand="gvContact_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="Contact Name" SortExpression="Contact_Name" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle Width="14%" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkContactName" runat="server" Text='<% #Eval("Contact_Name") %>'
                                        CommandName="edititem" CssClass="acher"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Title" SortExpression="Title" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle Width="14%" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkTitle" runat="server" Text='<% #Eval("Title") %>' CommandName="edititem"
                                        CssClass="acher"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Address" SortExpression="Address_1" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle Width="16%" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkAddress" runat="server" Text='<% #Eval("Address_1") %>' CommandName="edititem"
                                        CssClass="acher"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Work Telephone" SortExpression="Work_Telephone" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle Width="13%" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkWork_Telephone" runat="server" Text='<% #Eval("Work_Telephone") %>' CommandName="edititem"
                                        CssClass="acher"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cell Telephone" SortExpression="Cell_Telephone" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle Width="13%" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkCell_Telephone" runat="server" Text='<% #Eval("Cell_Telephone") %>' CommandName="edititem"
                                        CssClass="acher"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Facsimile" SortExpression="Facsimile" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle Width="13%" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkFacsimile" runat="server" Text='<% #Eval("Facsimile") %>' CommandName="edititem"
                                        CssClass="acher"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email" SortExpression="Email" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle Width="17%" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEmail" runat="server" Text='<% #Eval("Email") %>' CommandName="edititem"
                                        CssClass="acher"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                        </Columns>
                    </asp:GridView>
                    <table cellpadding="0" cellspacing="0" width="100%" id="tblPaging" runat="server"
                        style="display: none">
                        <tr>
                            <td width="100%" align="center" style="background-color: #7f7f7f; font-family: Tahoma;
                                font-size: 8pt">
                                <asp:DataList ID="dlPages" runat="server" RepeatDirection="Horizontal" CellPadding="4"
                                    CellSpacing="0">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Container.ItemIndex + 1 %>'
                                            CommandArgument='<%#Container.ItemIndex + 1 %>' OnClick="lnkPage_Click" ForeColor="White" />
                                    </ItemTemplate>
                                </asp:DataList>
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
    </div>
    <div id="divSupplier" runat="server" visible="false">
        <table cellpadding="1" cellspacing="0" width="100%">
            <tr>
                <td>
                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                        <tr>
                            <td colspan="3" align="left" valign="top">
                                <span class="NormalFontBold">Supplier Contact Information</span>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%">
                                Contact Name&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                <asp:TextBox ID="txtAddContactName" runat="server" Width="170" MaxLength="50"></asp:TextBox>                                
                            </td>
                            <td align="left" width="18%">
                                Title&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                <asp:TextBox ID="txtAddTitle" runat="server" Width="170" MaxLength="75"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%">
                                Address1&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                <asp:TextBox ID="txtAddAddress1" runat="server" Width="170px" MaxLength="50" />
                            </td>
                            <td align="left" width="18%">
                                Address2&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                <asp:TextBox ID="txtAddAddress2" runat="server" Width="170px" MaxLength="50" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%">
                                City&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                <asp:TextBox ID="txtAddCity" runat="server" Width="170px" MaxLength="30" />
                            </td>
                            <td align="left" width="18%">
                                State&nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                <asp:DropDownList ID="drpState" Width="170px" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%" nowrap="nowrap">
                                Zip Code (XXXXX-XXXX)&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                <asp:TextBox ID="txtZipCode" runat="server" Width="170px" MaxLength="10" onKeyPress="javascript:return FormatZipCode(event,this.id);"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revZipCode" runat="server" ErrorMessage="Zip Code is not valid"
                                    ValidationGroup="vsErrorGroup" SetFocusOnError="true" ControlToValidate="txtZipCode"
                                    ValidationExpression="\b[0-9]{5}-[0-9]{4}\b|\b[0-9]{5}\b" Display="none" />
                            </td>
                            <td align="left" width="18%">
                            </td>
                            <td align="center" width="4%">
                            </td>
                            <td align="left" width="28%">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%" nowrap="nowrap">
                                Work Telephone (XXX-XXX-XXXX)&nbsp;<span id="Span8" style="color: Red; display: none;" runat="server">*</span>
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                <asp:TextBox ID="txtWorkPhone" runat="server" Width="170px" MaxLength="12" onKeyPress="javascript:return FormatPhone(event,this.id);" />
                                <asp:RegularExpressionValidator ID="revWorkTel" runat="server" ControlToValidate="txtWorkPhone"
                                    ValidationExpression="\b[0-9]{3}-[0-9]{3}-[0-9]{4}\b" ErrorMessage="Please Enter Work Telephone in xxx-xxx-xxxx format."
                                    SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none"></asp:RegularExpressionValidator>
                            </td>
                            <td align="left" width="18%" nowrap="nowrap">
                                Cell Telephone (XXX-XXX-XXXX)&nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                <asp:TextBox ID="txtCellPhone" runat="server" Width="170px" MaxLength="12" onKeyPress="javascript:return FormatPhone(event,this.id);" />
                                <asp:RegularExpressionValidator ID="revCellPhone" runat="server" ControlToValidate="txtCellPhone"
                                    ValidationExpression="\b[0-9]{3}-[0-9]{3}-[0-9]{4}\b" ErrorMessage="Please Enter Cell Telephone in xxx-xxx-xxxx format."
                                    SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%">
                                Facsimile (XXX-XXX-XXXX)&nbsp;<span id="Span10" style="color: Red; display: none;" runat="server">*</span>
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                <asp:TextBox ID="txtFacsimile" runat="server" Width="170px" MaxLength="12" onKeyPress="javascript:return FormatPhone(event,this.id);" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtFacsimile"
                                    ValidationExpression="\b[0-9]{3}-[0-9]{3}-[0-9]{4}\b" ErrorMessage="Please Enter Facsimile in xxx-xxx-xxxx format."
                                    SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none"></asp:RegularExpressionValidator>
                            </td>
                            <td align="left" width="18%">
                                E-Mail&nbsp;<span id="Span11" style="color: Red; display: none;" runat="server">*</span>
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                <asp:TextBox ID="txtEmail" runat="server" Width="170px" MaxLength="255" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmail"
                                    ValidationGroup="vsErrorGroup" Display="None" ErrorMessage="Email Address Is Invalid."
                                    SetFocusOnError="True" ToolTip="Email Address Is Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                Notes&nbsp;<span id="Span12" style="color: Red; display: none;" runat="server">*</span>
                            </td>
                            <td align="center" valign="top">
                                :
                            </td>
                            <td align="left" colspan="4">
                                <uc:ctrlMultiLineTextBox ID="txtSupplierNotes" runat="server" IsRequired="false" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div id="divsonic" runat="server" visible="false">
        <table cellpadding="3" cellspacing="1" border="0" width="100%">
            <tr>
                <td colspan="3" align="left" valign="top">
                    <span class="NormalFontBold">Sonic Contact Information</span>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="left" width="18%">
                    Contact Name&nbsp;<span id="Span13" style="color: Red; display: none;" runat="server">*</span>
                </td>
                <td align="center" width="4%">
                    :
                </td>
                <td align="left" width="28%">
                    <asp:TextBox ID="txtSonicContactName" runat="server" Width="170" MaxLength="50"></asp:TextBox>                   
                </td>
                <td align="left" width="18%">
                    Title&nbsp;<span id="Span14" style="color: Red; display: none;" runat="server">*</span>
                </td>
                <td align="center" width="4%">
                    :
                </td>
                <td align="left" width="28%">
                    <asp:TextBox ID="txtSonicTitle" runat="server" Width="170" MaxLength="75"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left" width="18%">
                    Address1&nbsp;<span id="Span15" style="color: Red; display: none;" runat="server">*</span>
                </td>
                <td align="center" width="4%">
                    :
                </td>
                <td align="left" width="28%">
                    <asp:TextBox ID="txtSonicAddress1" runat="server" Width="170px" MaxLength="50" />
                </td>
                <td align="left" width="18%">
                    Address2&nbsp;<span id="Span16" style="color: Red; display: none;" runat="server">*</span>
                </td>
                <td align="center" width="4%">
                    :
                </td>
                <td align="left" width="28%">
                    <asp:TextBox ID="txtSonicAddress2" runat="server" Width="170px" MaxLength="50" />
                </td>
            </tr>
            <tr>
                <td align="left" width="18%">
                    City&nbsp;<span id="Span17" style="color: Red; display: none;" runat="server">*</span>
                </td>
                <td align="center" width="4%">
                    :
                </td>
                <td align="left" width="28%">
                    <asp:TextBox ID="txtSonicCity" runat="server" Width="170px" MaxLength="30" />
                </td>
                <td align="left" width="18%">
                    State&nbsp;<span id="Span18" style="color: Red; display: none;" runat="server">*</span>
                </td>
                <td align="center" width="4%">
                    :
                </td>
                <td align="left" width="28%">
                    <asp:DropDownList ID="drpSonicState" Width="170px" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="left" width="18%" nowrap="nowrap">
                    Zip Code (XXXXX-XXXX)&nbsp;<span id="Span19" style="color: Red; display: none;" runat="server">*</span>
                </td>
                <td align="center" width="4%">
                    :
                </td>
                <td align="left" width="28%">
                    <asp:TextBox ID="txtSonicZipCode" runat="server" Width="170px" MaxLength="10" onKeyPress="javascript:return FormatZipCode(event,this.id);"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Zip Code is not valid"
                        ValidationGroup="vsErrorGroup" SetFocusOnError="true" ControlToValidate="txtSonicZipCode"
                        ValidationExpression="\b[0-9]{5}-[0-9]{4}\b|\b[0-9]{5}\b" Display="none" />
                </td>
                <td align="left" width="18%">
                </td>
                <td align="center" width="4%">
                    :
                </td>
                <td align="left" width="28%">
                </td>
            </tr>
            <tr>
                <td align="left" width="18%" nowrap="nowrap">
                    Work Telephone (XXX-XXX-XXXX)&nbsp;<span id="Span20" style="color: Red; display: none;" runat="server">*</span>
                </td>
                <td align="center" width="4%">
                    :
                </td>
                <td align="left" width="28%">
                    <asp:TextBox ID="txtSonicWorkPhone" runat="server" Width="170px" MaxLength="12" onKeyPress="javascript:return FormatPhone(event,this.id);" />
                    <asp:RegularExpressionValidator ID="revSonicWorkPhone" runat="server" ControlToValidate="txtSonicWorkPhone"
                        ValidationExpression="\b[0-9]{3}-[0-9]{3}-[0-9]{4}\b" ErrorMessage="Please Enter Work Telephone in xxx-xxx-xxxx format."
                        SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none"></asp:RegularExpressionValidator>
                </td>
                <td align="left" width="18%" nowrap="nowrap">
                    Cell Telephone (XXX-XXX-XXXX)&nbsp;<span id="Span21" style="color: Red; display: none;" runat="server">*</span>
                </td>
                <td align="center" width="4%">
                    :
                </td>
                <td align="left" width="28%">
                    <asp:TextBox ID="txtSonicCellPhone" runat="server" Width="170px" MaxLength="12" onKeyPress="javascript:return FormatPhone(event,this.id);" />
                    <asp:RegularExpressionValidator ID="revSonicCellPhone" runat="server" ControlToValidate="txtSonicCellPhone"
                        ValidationExpression="\b[0-9]{3}-[0-9]{3}-[0-9]{4}\b" ErrorMessage="Please Enter Cell Telephone in xxx-xxx-xxxx format."
                        SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="left" width="18%">
                    Facsimile (XXX-XXX-XXXX)&nbsp;<span id="Span22" style="color: Red; display: none;" runat="server">*</span>
                </td>
                <td align="center" width="4%">
                    :
                </td>
                <td align="left" width="28%">
                    <asp:TextBox ID="txtSonicFscsimile" runat="server" Width="170px" MaxLength="12" onKeyPress="javascript:return FormatPhone(event,this.id);" />
                    <asp:RegularExpressionValidator ID="revSonicFescimile" runat="server" ControlToValidate="txtSonicFscsimile"
                        ValidationExpression="\b[0-9]{3}-[0-9]{3}-[0-9]{4}\b" ErrorMessage="Please Enter Facsimile in xxx-xxx-xxxx format."
                        SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none"></asp:RegularExpressionValidator>
                </td>
                <td align="left" width="18%">
                    E-Mail&nbsp;<span id="Span23" style="color: Red; display: none;" runat="server">*</span>
                </td>
                <td align="center" width="4%">
                    :
                </td>
                <td align="left" width="28%">
                    <asp:TextBox ID="txtSonicEmail" runat="server" Width="170px" MaxLength="255" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtSonicEmail"
                        ValidationGroup="vsErrorGroup" Display="None" ErrorMessage="Email Address Is Invalid."
                        SetFocusOnError="True" ToolTip="Email Address Is Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="left" valign="top">
                    Notes&nbsp;<span id="Span24" style="color: Red; display: none;" runat="server">*</span>
                </td>
                <td align="center" valign="top">
                    :
                </td>
                <td align="left" colspan="4">
                    <uc:ctrlMultiLineTextBox ID="txtSonicNotes" runat="server" IsRequired="false" />
                </td>
            </tr>
        </table>
    </div>
    <div id="dvAddButton" runat="server" visible="false">
        <table cellpadding="3" cellspacing="1" border="0" width="100%">
            <tr>
                <td colspan="6" align="center">
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="vsErrorGroup" />
                    <asp:Button ID="btnContactClear" runat="server" Text="Clear" OnClick="btnContactClear_Click" />
                    <asp:Button ID="btnContactSearch" runat="server" Text="Search" OnClick="btnContactSearch_Click" />
                </td>
            </tr>
        </table>
    </div>

    <script type="text/javascript">
        function SelectValue() {
            window.opener.document.getElementById("ctl00_ContentPlaceHolder1_btnPK").click();
            self.close();
        }
    </script>

    </form>
</body>
</html>
