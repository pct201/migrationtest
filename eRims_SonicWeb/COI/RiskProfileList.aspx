<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Default.master" CodeFile="RiskProfileList.aspx.cs"
    Inherits="Admin_RiskProfileList" %>

<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script type="text/javascript">
        function CheckCOIReference(btnID) {
            var coiCnt = document.getElementById(btnID.replace("lnkDelete", "hdnCOIs")).value;
            if (Number(coiCnt) > 0) {
                if (confirm("There are one or more COIs that reference this Risk Profile, continue?")) {
                    return confirm("Are you sure that you want to delete this Risk Profile?");
                }
                else
                    return false;
            }
            else
                return confirm("Are you sure that you want to delete this Risk Profile?");
        }
    </script>
    <table cellpadding="1" cellspacing="1" width="100%">
        <tr>
            <td width="100%" class="Spacer" style="height: 10px;">
            </td>
        </tr>
        <tr>
            <td align="left">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td width="45%">
                            &nbsp;<span class="heading">Risk Profiles</span><br />
                            &nbsp;<asp:Label ID="lblNumber" runat="server" Text="5"></asp:Label>&nbsp;Risk Profiles
                            Found
                        </td>
                        <td valign="top" align="right">
                            <uc:ctrlPaging ID="ctrlPageProfile" runat="server" OnGetPage="GetPage" />
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 5px;">
            </td>
        </tr>
        <tr>
            <td class="dvContent" valign="top">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td align="left">
                            <asp:GridView ID="gvProfiles" runat="server" Width="100%" OnRowCommand="gvProfiles_RowCommand"
                                OnRowDataBound="gvProfiles_RowDataBound" AllowSorting="True" AutoGenerateColumns="False"
                                OnRowCreated="gvProfiles_RowCreated" OnSorting="gvProfiles_Sorting">
                                <Columns>
                                    <asp:TemplateField HeaderText="Name" SortExpression="Name">
                                        <ItemStyle Width="50%" HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <%#Eval("Name")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Profile Date" SortExpression="DateOfProfile">
                                        <ItemStyle Width="25%" HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <%#Convert.ToDateTime(Eval("DateOfProfile")).ToString(AppConfig.DisplayDateFormat)%>
                                            <input type="hidden" runat="server" id="hdnCOIs" value='<%#Eval("COI_Count")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Disposition">
                                        <ItemStyle Width="25%" HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <table cellpadding="2" cellspacing="0" align="right" border="0">
                                                <tr>
                                                    <td valign="top">
                                                        <asp:Button ID="lnkView" runat="server" Text="View" Width="50px" CommandName="ViewProfile"
                                                            CommandArgument='<%#Eval("PK_COI_Risk_Profile")%>'></asp:Button>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:Button ID="lnkEdit" runat="server" Text="Edit" Width="50px" CommandName="EditProfile"
                                                           CommandArgument='<%#Eval("PK_COI_Risk_Profile")%>'></asp:Button>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:Button ID="lnkDelete" runat="server" Text="Delete" Width="70px" CommandName="DeleteProfile"
                                                        CommandArgument='<%#Eval("PK_COI_Risk_Profile")%>' OnClientClick='return CheckCOIReference(this.id);' />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <table width="100%">
                                        <tr>
                                            <td align="center">
                                                <asp:Label ID="lblMsg" runat="server" SkinID="Message" Text="No records found."></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 5px;">
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btnAddNew" runat="server" SkinID="AddNew" OnClick="btnAddNew_Click" />
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 5px;">
            </td>
        </tr>
    </table>
</asp:Content>
