<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Help.aspx.cs"
    Inherits="Help" Title=" Risk Insurance Management System " %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellspacing="0" cellpadding="0" width="100%">
        <tbody>
            <tr>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="bandHeaderRow" align="left" colspan="4">
                    Help
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 15%">
                    &nbsp;
                </td>
                <td align="center" colspan="2">
                    <asp:GridView ID="gvUser_Help" runat="server" Width="100%" AutoGenerateColumns="false"
                        PageSize="10" EnableViewState="true" AllowPaging="true" OnPageIndexChanging="gvUser_Help_PageIndexChanging"
                        OnRowDataBound="gvUser_Help_RowDataBound">
                        <RowStyle HorizontalAlign="Left" />
                        <HeaderStyle HorizontalAlign="Left" />
                        <Columns>
                            <asp:TemplateField HeaderText="Help Type">
                                <ItemStyle Width="20%" />
                                <ItemTemplate>
                                    <%#Eval("Type")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <ItemStyle Width="80%" />
                                <ItemTemplate>
                                    <a target="_blank" id="aURL" runat="server">
                                        <%#Eval("Description") %></a>
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
                <td style="width: 15%">
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
</asp:Content>
