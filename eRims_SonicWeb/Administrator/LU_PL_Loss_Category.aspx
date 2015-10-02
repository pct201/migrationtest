<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="LU_PL_Loss_Category.aspx.cs" Inherits="Administrator_LU_PL_Loss_Category" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="../JavaScript/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../JavaScript/jquery-1.10.1.ui.min.js"></script>

    <script language="javascript" type="text/javascript">

        var jq = $.noConflict();

        jq(function () {
            jq('.gvLossCategory').each(function () {
                jq('#' + jq(this).attr('id').concat(' tbody')).sortable({
                    cursor: 'move',
                    scroll: false,
                    stop: function (ev, ui) {
                        jq('.gvLossCategory').each(function () {
                            jq(this).find('tr').removeClass('bkodd').removeAttr('style');
                            jq(this).find('tr:even').addClass('bkodd');
                        });
                    }
                });
                jq('#' + jq(this).attr('id').concat(' tbody')).disableSelection();
            });
        });

        function getData() {
            //gets table             
            var Ids = [];
            jq('.gvLossCategory').each(function () {
                var tempIds = jq(this).find('tr > td:first-child').next().map(function () {
                    return parseInt((jq(this).find('input:hidden')).val());
                }).get().join(',');
                Ids.push(tempIds);
            });
            jq('#ctl00_ContentPlaceHolder1_hdnSortOrder').val(Ids);

            var PKId = [];
            jq('.gvLossCategory').each(function () {

                var tempIds = jq(this).find('tr > td:last-child').map(function () {
                    return parseInt((jq(this).find('input:hidden')).val());
                }).get().join(',');
                PKId.push(tempIds);
            });
            jq('#<%=hdnPKId.ClientID %>').val(PKId);

        }

        function CheckValidation() {
            if (Page_ClientValidate("vsError")) {
            }
        }
    </script>
    
    <style type="text/css">
        .bkeven {
            background-color: White;
            font-family: Tahoma;
            font-size: 8pt;
        }

        .bkodd {
            background-color: #EAEAEA !important;
            font-family: Tahoma !important;
            font-size: 8pt !important;
        }
    </style>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields :" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsError" CssClass="errormessage"></asp:ValidationSummary>
    </div>

    <table cellspacing="0" cellpadding="0" width="100%">
        <tbody>
            <tr>
                <td colspan="4">&nbsp;
                </td>
            </tr>
            <tr>
                <td class="bandHeaderRow" align="left" colspan="4">Administrator :: PL Loss Category

                </td>
            </tr>
            <tr>
                <td colspan="4">&nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 20%">&nbsp;
                </td>
                <td align="center" colspan="2">
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tbody>
                            <tr>
                                <td align="left">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <table cellspacing="0" cellpadding="4" border="0" style="color: #333333; font-family: Tahoma; font-size: 8pt; width: 100%; border-collapse: collapse;">
                                        <tr align="left" style="color: White; background-color: #7F7F7F; font-family: Tahoma; font-size: 8pt; font-weight: bold;">
                                            <th scope="col">Description</th>
                                            <th scope="col">Active</th>
                                            <th scope="col">Edit</th>
                                            <th scope="col">&nbsp;</th>
                                        </tr>
                                    </table>
                                    <asp:GridView ID="gvLossCategory" CssClass="gvLossCategory" runat="server" Width="100%" AutoGenerateColumns="false"
                                        PageSize="10" EnableViewState="true" AllowPaging="false" GridLines="None" OnRowCommand="gvLossCategory_RowCommand" ShowHeader="false" dontUseScrolls="true">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemStyle Width="50%" />
                                                <ItemTemplate>
                                                    <%#Eval("Description") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemStyle Width="25%" />
                                                <ItemTemplate>
                                                    <%#Eval("Active") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemStyle Width="21%" />
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" ID="lnkEdit" Text="Edit" CommandName="EditRecord"
                                                        CommandArgument='<%#Eval("PK_LU_PL_Loss_Category") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:HiddenField runat="server" Value='<%# Eval("PK_LU_PL_Loss_Category") %>' ID="hdnPK" />
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
                <td style="width: 20%">&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="4">&nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 20%">&nbsp;
                </td>
                <td colspan="2">
                    <asp:HiddenField ID="hdnSortOrder" runat="server" />
                    <asp:HiddenField ID="hdnPKId" runat="server" />
                    <asp:LinkButton Style="display: inline" ID="lnkAddNew" OnClick="lnkAddNew_Click"
                        runat="server" Text="Add New"></asp:LinkButton>&nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="lnkSaveReorderList" runat="server" Text="Save Order" OnClientClick="getData();" OnClick="lnkSaveReorderList_Click" />&nbsp;&nbsp;&nbsp;<asp:LinkButton
                                Style="display: none" ID="lnkCancel" OnClick="lnkCancel_Click" runat="server"
                                Text="Cancel"></asp:LinkButton>
                </td>
                <td style="width: 20%">&nbsp;
                </td>
            </tr>
            <tr style="display: none" id="trStatusAdd" runat="server">
                <td style="width: 20%">&nbsp;
                </td>
                <td colspan="2">
                    <table cellspacing="1" cellpadding="3" width="100%" border="0">
                        <tbody>
                            <tr>
                                <td style="width: 25%" align="left">Description<span class="mf">*</span>
                                </td>
                                <td style="width: 4%" align="center">:
                                </td>
                                <td align="left" colspan="4">
                                    <asp:TextBox ID="txtDescription" runat="server" MaxLength="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvStatus" runat="server" ValidationGroup="vsError"
                                        SetFocusOnError="true" ErrorMessage="Please Enter Description" Display="none"
                                        ControlToValidate="txtDescription"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25%" align="left">Active
                                </td>
                                <td style="width: 4%" align="center">:
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
                                <td style="width: 25%" align="left"></td>
                                <td style="width: 4%" align="center"></td>
                                <td align="left">
                                    <asp:Button ID="btnAdd" OnClick="btnAdd_Click" runat="server" ValidationGroup="vsError"
                                        Text="Add" CausesValidation="false" OnClientClick="return CheckValidation();"></asp:Button>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
                <td style="width: 20%">&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="4">&nbsp;
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>