<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="ManageContacts.aspx.cs" Inherits="SONIC_Purchasing_ManageContacts" %>

<%@ Register Src="../../Controls/SONIC_Purchasing/Purchasing_Search.ascx" TagName="Purchasing_Search"
    TagPrefix="uc1" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        function ConfirmDelete() {
            return confirm("Are you sure you want to delete this record?");
        }
        function ValidateFields(sender, args) {
            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnControlIDs.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnErrorMsgs.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnControlIDs.ClientID%>').value != "") {
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
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    <div id="dvManageSearch" runat="server">
        <table cellpadding="0" cellspacing="0" width="100%" align="center">
            <tr>
                <td width="100%" class="Spacer" style="height: 3px;">
                </td>
            </tr>
            <tr>
                <td class="ghc" align="left">
                    Manage Contacts Search Information
                </td>
            </tr>
            <tr>
                <td width="100%" class="Spacer" style="height: 10px;">
                </td>
            </tr>
            <tr>
                <td class="dvContent">
                    <table cellpadding="3" cellspacing="1" border="0" width="33%" align="center">
                        <tr>
                            <td width="28%" align="left" valign="top">
                                Contact Type
                            </td>
                            <td width="2%" align="center" valign="top">
                                :
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="drpManageContactType" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                Contact Name
                            </td>
                            <td align="center" valign="top">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtContactName" runat="server" Width="170px" MaxLength="50" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                Title
                            </td>
                            <td align="center" valign="top">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtTitle" runat="server" Width="170px" MaxLength="50" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                Address 1
                            </td>
                            <td align="center" valign="top">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtAddress1" runat="server" Width="170px" MaxLength="50" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                City
                            </td>
                            <td align="center" valign="top">
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
                                <asp:ListBox ID="lstState" runat="server" SelectionMode="Multiple" Width="170px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="Spacer" colspan="3" style="height: 10px;">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                            <td align="left">
                                <asp:Button ID="btnSearch" runat="server" CausesValidation="false" Text="Search" OnClick="btnSearch_Click"
                                     ToolTip="Search" />&nbsp;
                                <asp:Button ID="btnClear" runat="server" Text="Clear" ToolTip="Clear" CausesValidation="false"
                                    OnClick="btnClear_Click" />&nbsp;
                                <asp:Button ID="btnManageConactAdd" runat="server" Text="Add New" ToolTip="Add New"
                                    CausesValidation="false" OnClick="btnAdd_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" class="Spacer" style="height: 15px;">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div id="dvSearchResult" runat="server" style="width: 100%;" visible="false">
        <table width="100%" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <table style="width: 100%;">
                        <tr>
                            <td align="left">
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td colspan="2">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="45%">
                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                <tr>
                                                    <td align="left">
                                                        &nbsp;<asp:Label ID="lblSearchHeader" runat="server" Text="" CssClass="heading"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        &nbsp;
                                                        <asp:Label ID="lblNumber" runat="server" Text="0"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td valign="top" align="right">
                                            <uc:ctrlPaging ID="ctrlPurchasingSearch" runat="server" OnGetPage="GetPage" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <div style="overflow: auto; text-align: left;">
                                    <asp:GridView ID="gvContact" runat="server" AutoGenerateColumns="false" Width="100%"
                                        EmptyDataText="No Record Found" AllowSorting="true" DataKeyNames="PK_Purchasing_Contacts"
                                        AllowPaging="false" OnSorting="gvContact_Sorting" OnRowCreated="gvContact_RowCreated"
                                        OnRowCommand="gvContact_RowCommand" OnRowDataBound="gvContact_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Contact Type" SortExpression="Contact_Type" HeaderStyle-HorizontalAlign="Left">
                                                <ItemStyle Width="10%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lnkContactType" runat="server" Text='<% #Eval("Contact_Type") %>'
                                                        CssClass="acher"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Contact Name" SortExpression="Contact_Name" HeaderStyle-HorizontalAlign="Left">
                                                <ItemStyle Width="11%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lnkContactName" runat="server" Text='<% #Eval("Contact_Name") %>'
                                                        CssClass="acher"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Title" SortExpression="Title" HeaderStyle-HorizontalAlign="Left">
                                                <ItemStyle Width="11%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lnkTitle" runat="server" Text='<% #Eval("Title") %>' CssClass="acher"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Address" SortExpression="Address_1" HeaderStyle-HorizontalAlign="Left">
                                                <ItemStyle Width="15%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lnkAddress" runat="server" Text='<% #Eval("Address_1") %>' CssClass="acher"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Work Telephone" SortExpression="Work_Telephone" HeaderStyle-HorizontalAlign="Left">
                                                <ItemStyle Width="11%" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkWork_Telephone" runat="server" Text='<% #Eval("Work_Telephone") %>'
                                                        CommandName="edititem" CssClass="acher"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Cell Telephone" SortExpression="Cell_Telephone" HeaderStyle-HorizontalAlign="Left">
                                                <ItemStyle Width="10%" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkCell_Telephone" runat="server" Text='<% #Eval("Cell_Telephone") %>'
                                                        CommandName="edititem" CssClass="acher"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Facsimile" SortExpression="Facsimile" HeaderStyle-HorizontalAlign="Left">
                                                <ItemStyle Width="10%" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkFacsimile" runat="server" Text='<% #Eval("Facsimile") %>'
                                                        CommandName="edititem" CssClass="acher"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Email" SortExpression="Email" HeaderStyle-HorizontalAlign="Left">
                                                <ItemStyle Width="11%" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkEmail" runat="server" Text='<% #Eval("Email") %>' CommandName="edititem"
                                                        CssClass="acher"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Disposition" HeaderStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Center" Width="11%"></ItemStyle>
                                                <ItemTemplate>
                                                    <asp:Button ID="lnkEdit" CommandName="EditItem" CommandArgument='<%#Eval("PK_Purchasing_Contacts")%>'
                                                        ToolTip="Edit Manage Contacts" runat="server" Text="Edit"></asp:Button>&nbsp;
                                                    <asp:Button ID="lnkView" CommandName="ViewItem" CommandArgument='<%#Eval("PK_Purchasing_Contacts")%>'
                                                        ToolTip="View Manage Contacts" runat="server" Text="View"></asp:Button>&nbsp;
                                                    <asp:Button ID="lnkDelete" CommandName="DeleteItem" ToolTip="Delete Manage Contacts"
                                                        runat="server" OnClientClick="return ConfirmDelete();" CommandArgument='<%#Eval("PK_Purchasing_Contacts")%>'
                                                        Text="Delete"></asp:Button>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnSearchAgain" runat="server" Text="Search Again" ToolTip="Search Again"
                                    CausesValidation="false" OnClick="btnSearchAgain_Click" />&nbsp;
                                <asp:Button ID="btnAdd" runat="server" Text="Add New" ToolTip="Add New" CausesValidation="false"
                                    OnClick="btnAdd_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div id="dvAddContact" runat="server" visible="false">
        <table cellpadding="3" cellspacing="1" border="0" width="100%">
            <tr>
                <td colspan="9" class="ghc" align="left">
                    Manage Contacts Information
                </td>
            </tr>
            <tr>
                <td colspan="9">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td align="left">
                    Contact Type&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                </td>
                <td align="center">
                    :
                </td>
                <td align="left">
                    <asp:DropDownList ID="drpContactType" runat="server">
                    </asp:DropDownList>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpContactType"
                        InitialValue="0" Display="none" ErrorMessage="Please Select Contact Type" SetFocusOnError="true"
                        ValidationGroup="vsErrorGroup" />--%>
                </td>
                <td colspan="5">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td width="3%">
                    &nbsp;
                </td>
                <td align="left" width="18%">
                    Contact Name&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                </td>
                <td align="center" width="4%">
                    :
                </td>
                <td align="left" width="22%">
                    <asp:TextBox ID="txtAddContactName" runat="server" Width="170" MaxLength="75"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAddContactName"
                        Display="none" ErrorMessage="Please Enter Contact Name" SetFocusOnError="true"
                        ValidationGroup="vsErrorGroup" />--%>
                </td>
                <td width="6%">
                    &nbsp;
                </td>
                <td align="left" width="18%">
                    Title&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                </td>
                <td align="center" width="4%">
                    :
                </td>
                <td align="left" width="22%">
                    <asp:TextBox ID="txtAddTitle" runat="server" Width="170" MaxLength="50"></asp:TextBox>
                </td>
                <td align="left" width="3%">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td align="left">
                    Address1&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                </td>
                <td align="center">
                    :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtAddAddress1" runat="server" Width="170px" MaxLength="50" />
                </td>
                <td>
                    &nbsp;
                </td>
                <td align="left">
                    Address2&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                </td>
                <td align="center">
                    :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtAddAddress2" runat="server" Width="170px" MaxLength="50" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td align="left">
                    City&nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                </td>
                <td align="center">
                    :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtAddCity" runat="server" Width="170px" MaxLength="30" />
                </td>
                <td>
                    &nbsp;
                </td>
                <td align="left">
                    State&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                </td>
                <td align="center">
                    :
                </td>
                <td align="left">
                    <asp:DropDownList ID="drpState" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td align="left" nowrap="nowrap">
                    Zip Code (XXXXX-XXXX)&nbsp;<span id="Span8" style="color: Red; display: none;" runat="server">*</span>
                </td>
                <td align="center">
                    :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtZipCode" runat="server" Width="170px" MaxLength="10" onKeyPress="javascript:return FormatZipCode(event,this.id);"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revZipCode" runat="server" ErrorMessage="Zip Code is not valid"
                        ValidationGroup="vsErrorGroup" SetFocusOnError="true" ControlToValidate="txtZipCode"
                        ValidationExpression="\b[0-9]{5}-[0-9]{4}\b|\b[0-9]{5}\b" Display="none" />
                </td>
                <td>
                    &nbsp;
                </td>
                <td align="left">
                </td>
                <td align="center">
                </td>
                <td align="left">
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td align="left" nowrap="nowrap">
                    Work Telephone (XXX-XXX-XXXX)&nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                </td>
                <td align="center">
                    :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtWorkPhone" runat="server" Width="170px" MaxLength="12" onKeyPress="javascript:return FormatPhone(event,this.id);" />
                    <asp:RegularExpressionValidator ID="revWorkTel" runat="server" ControlToValidate="txtWorkPhone"
                        ValidationExpression="\b[0-9]{3}-[0-9]{3}-[0-9]{4}\b" ErrorMessage="Please Enter Work Telephone in xxx-xxx-xxxx format."
                        SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none"></asp:RegularExpressionValidator>
                </td>
                <td>
                    &nbsp;
                </td>
                <td align="left" nowrap="nowrap">
                    Cell Telephone (XXX-XXX-XXXX)&nbsp;<span id="Span10" style="color: Red; display: none;" runat="server">*</span>
                </td>
                <td align="center">
                    :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtCellPhone" runat="server" Width="170px" MaxLength="12" onKeyPress="javascript:return FormatPhone(event,this.id);" />
                    <asp:RegularExpressionValidator ID="revCellPhone" runat="server" ControlToValidate="txtCellPhone"
                        ValidationExpression="\b[0-9]{3}-[0-9]{3}-[0-9]{4}\b" ErrorMessage="Please Enter Cell Telephone in xxx-xxx-xxxx format."
                        SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none"></asp:RegularExpressionValidator>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td align="left">
                    Facsimile (XXX-XXX-XXXX)&nbsp;<span id="Span11" style="color: Red; display: none;" runat="server">*</span>
                </td>
                <td align="center">
                    :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtFacsimile" runat="server" Width="170px" MaxLength="12" onKeyPress="javascript:return FormatPhone(event,this.id);" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtFacsimile"
                        ValidationExpression="\b[0-9]{3}-[0-9]{3}-[0-9]{4}\b" ErrorMessage="Please Enter Facsimile in xxx-xxx-xxxx format."
                        SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none"></asp:RegularExpressionValidator>
                </td>
                <td>
                    &nbsp;
                </td>
                <td align="left">
                    E-Mail&nbsp;<span id="Span12" style="color: Red; display: none;" runat="server">*</span>
                </td>
                <td align="center">
                    :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtEmail" runat="server" Width="170px" MaxLength="255" />
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                        ValidationGroup="vsErrorGroup" Display="None" ErrorMessage="Email Address Is Invalid."
                        SetFocusOnError="True" ToolTip="Email Address Is Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td align="left" valign="top">
                    Notes&nbsp;<span id="Span13" style="color: Red; display: none;" runat="server">*</span>
                </td>
                <td align="center" valign="top">
                    :
                </td>
                <td align="left" colspan="6">
                    <uc:ctrlMultiLineTextBox ID="txtSupplierNotes" runat="server" IsRequired="false" />
                </td>
            </tr>
        </table>
    </div>
    <div id="dvAddButton" runat="server" visible="false">
        <table cellpadding="3" cellspacing="1" border="0" width="100%">
            <tr>
                <td align="center">
                    <asp:Button ID="btnSave" runat="server" Text="Save & View" OnClick="btnSave_Click"
                        ValidationGroup="vsErrorGroup" ToolTip="Save & View" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                        ToolTip="Cancel" />
                </td>
            </tr>
        </table>
    </div>
    <div id="dvAddContactView" runat="server" visible="false">
        <table cellpadding="3" cellspacing="1" border="0" width="100%">
            <tr>
                <td colspan="9" class="ghc" align="left">
                    Manage Contacts Information
                </td>
            </tr>
            <tr>
                <td colspan="9">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td align="left">
                    Contact Type
                </td>
                <td align="center">
                    :
                </td>
                <td align="left">
                    <asp:Label ID="lblContactType" runat="server">
                    </asp:Label>
                </td>
                <td colspan="5">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="left" width="3%">
                    &nbsp;
                </td>
                <td align="left" width="18%">
                    Contact Name
                </td>
                <td align="center" width="4%">
                    :
                </td>
                <td align="left" width="22%">
                    <asp:Label ID="lblAddContactName" runat="server"></asp:Label>
                </td>
                <td width="6%">
                    &nbsp;
                </td>
                <td align="left" width="18%">
                    Title
                </td>
                <td align="center" width="4%">
                    :
                </td>
                <td align="left" width="22%">
                    <asp:Label ID="lblAddTitle" runat="server"></asp:Label>
                </td>
                <td align="left" width="3%">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td align="left">
                    Address1
                </td>
                <td align="center">
                    :
                </td>
                <td align="left">
                    <asp:Label ID="lblAddAddress1" runat="server" />
                </td>
                <td>
                    &nbsp;
                </td>
                <td align="left">
                    Address2
                </td>
                <td align="center">
                    :
                </td>
                <td align="left">
                    <asp:Label ID="lblAddAddress2" runat="server" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td align="left">
                    City
                </td>
                <td align="center">
                    :
                </td>
                <td align="left">
                    <asp:Label ID="lblAddCity" runat="server" />
                </td>
                <td>
                    &nbsp;
                </td>
                <td align="left">
                    State
                </td>
                <td align="center">
                    :
                </td>
                <td align="left">
                    <asp:Label ID="lblState" runat="server">
                    </asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td align="left" nowrap="nowrap">
                    Zip Code (XXXXX-XXXX)
                </td>
                <td align="center">
                    :
                </td>
                <td align="left">
                    <asp:Label ID="lblZipCode" runat="server"></asp:Label>
                </td>
                <td align="left">
                </td>
                <td align="center">
                </td>
                <td align="left">
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td align="left" nowrap="nowrap">
                    Work Telephone (XXX-XXX-XXXX)
                </td>
                <td align="center">
                    :
                </td>
                <td align="left">
                    <asp:Label ID="lblWorkPhone" runat="server" />
                </td>
                <td>
                    &nbsp;
                </td>
                <td align="left" nowrap="nowrap">
                    Cell Telephone (XXX-XXX-XXXX)
                </td>
                <td align="center">
                    :
                </td>
                <td align="left">
                    <asp:Label ID="lblCellPhone" runat="server" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td align="left">
                    Facsimile (XXX-XXX-XXXX)
                </td>
                <td align="center">
                    :
                </td>
                <td align="left">
                    <asp:Label ID="lblFacsimile" runat="server" />
                </td>
                <td>
                    &nbsp;
                </td>
                <td align="left">
                    E-Mail
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
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td align="left" valign="top">
                    Notes
                </td>
                <td align="center" valign="top">
                    :
                </td>
                <td align="left" colspan="6">
                    <uc:ctrlMultiLineTextBox ID="lblSupplierNotes" runat="server" IsRequired="false"
                        ControlType="Label" />
                </td>
            </tr>
        </table>
    </div>
    <div id="dvButtonView" runat="server" visible="false">
        <table cellpadding="3" cellspacing="1" border="0" width="100%">
            <tr>
                <td align="center">
                    <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" ToolTip="Edit" />
                    <asp:Button ID="btnCancelView" runat="server" Text="Return to Search Results" OnClick="btnCancel_Click"
                        ToolTip="Return to Search Results" Width="190px" />
                </td>
            </tr>
        </table>
    </div>
    <asp:CustomValidator ID="CustomValidator" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
        Display="None" ValidationGroup="vsErrorGroup" />
    <input id="hdnControlIDs" runat="server" type="hidden" />
    <input id="hdnErrorMsgs" runat="server" type="hidden" />
</asp:Content>
