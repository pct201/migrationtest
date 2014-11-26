<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Rights.aspx.cs"
    Inherits="SONIC_Exposures_Administrator_Rights" Title="eERIMS Sonic :: Rights" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
function AddNewRight()
{
    document.getElementById('<%=trRightAdd.ClientID %>').style.display="block";
    document.getElementById('<%=lnkCancel.ClientID %>').style.display="inline";
    document.getElementById('<%=trRightView.ClientID %>').style.display="none";
}
    </script>

    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields :" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsError" CssClass="errormessage"></asp:ValidationSummary>
    </div>
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
    <asp:UpdatePanel runat="server" ID="updRight">
        <ContentTemplate>
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="4">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="bandHeaderRow" colspan="4" align="left">
                        Administrator :: Rights
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        &nbsp;<asp:Label ID="lblError" runat="server" EnableViewState="false" SkinID="lblError"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%">
                        &nbsp;
                    </td>
                    <td colspan="2" align="center">
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td align="left">
                                    <asp:Label runat="server" Text="Click To View Details" ID="lblmsg"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:GridView ID="gvRights" runat="server" Width="100%" DataKeyNames="PK_Right_ID"
                                        AutoGenerateColumns="false" OnRowCommand="gvRights_RowCommand" OnRowCreated="gvRights_RowCreated">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Right">
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" ID="lnkView" Text='<%# Eval("Right_Name") %>' CommandName="View"></asp:LinkButton>
                                                    <%--&nbsp;<asp:Label runat="server" ID="lblRights" Text='<%# Eval("Right_Name") %>'></asp:Label>--%>
                                                </ItemTemplate>
                                                <ItemStyle Width="65%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Remove" HeaderStyle-HorizontalAlign="center">
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" ID="lnkRemove" Text="Remove" CommandName="Remove"
                                                        OnClientClick="javascript:return confirm('are you sure to delete?');"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle Width="35%" HorizontalAlign="Center" />
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
                    <td style="width: 20%">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%">
                        &nbsp;
                    </td>
                    <td colspan="2">
                        <a href="#" onclick="AddNewRight();">Add New</a>&nbsp;&nbsp;&nbsp;<asp:LinkButton
                            runat="server" ID="lnkCancel" Text="Cancel" Style="display: none;" OnClick="lnkCancel_Click"></asp:LinkButton>
                    </td>
                    <td style="width: 20%">
                        &nbsp;
                    </td>
                </tr>
                <tr runat="server" id="trRightAdd" style="display: none;">
                    <td style="width: 20%">
                        &nbsp;
                    </td>
                    <td colspan="2">
                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                            <tr>
                                <td style="width: 18%">
                                    Right Name
                                </td>
                                <td style="width: 4%">
                                    :
                                </td>
                                <td colspan="4">
                                    <asp:TextBox runat="server" ID="txtRightName" Width="170px"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="rfvRightName" ValidationGroup="vsError"
                                        ErrorMessage="Please Enter Right Name" Display="none" ControlToValidate="txtRightName"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 18%">
                                    Module Name
                                </td>
                                <td style="width: 4%">
                                    :
                                </td>
                                <td colspan="4">
                                    <asp:DropDownList runat="server" ID="ddlModuleName" AutoPostBack="true" SkinID="ddlExposure"
                                        OnSelectedIndexChanged="ddlModuleName_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator runat="server" ID="rfvModuleName" ValidationGroup="vsError"
                                        ErrorMessage="Please select Module Name" Display="none" ControlToValidate="ddlModuleName"
                                        InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 18%">
                                    Right Type
                                </td>
                                <td style="width: 4%">
                                    :
                                </td>
                                <td colspan="4">
                                    <asp:DropDownList runat="server" ID="ddlRightType" SkinID="ddlExposure">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator runat="server" ID="rfvRightType" ValidationGroup="vsError"
                                        ErrorMessage="Please select Right Type" Display="none" ControlToValidate="ddlRightType"
                                        InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <asp:Button runat="server" ID="btnAdd" Text="Add" OnClick="btnAdd_Click" CausesValidation="true"
                                        ValidationGroup="vsError" />
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
                <tr runat="server" id="trRightView" style="display: none;">
                    <td style="width: 20%">
                        &nbsp;
                    </td>
                    <td colspan="2">
                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                            <tr>
                                <td style="width: 18%">
                                    Right Name
                                </td>
                                <td style="width: 4%">
                                    :
                                </td>
                                <td colspan="4">
                                    <asp:Label runat="server" ID="lblRightName" Width="170px"></asp:Label>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ValidationGroup="vsError"
                                        ErrorMessage="Please Enter Right Name" Display="none" ControlToValidate="txtRightName"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 18%">
                                    Module Name
                                </td>
                                <td style="width: 4%">
                                    :
                                </td>
                                <td colspan="4">
                                    <asp:Label runat="server" ID="lblModuleName"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 18%">
                                    Right Type
                                </td>
                                <td style="width: 4%">
                                    :
                                </td>
                                <td colspan="4">
                                    <asp:Label runat="server" ID="lblRightType"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 20%">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
