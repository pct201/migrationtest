<%@ Page Title="Risk Insurance Management System :: Franchise Grid" Language="C#"
    MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="FranchiseGrid.aspx.cs"
    Inherits="SONIC_FirstReport_FranchiseGrid" %>

<%@ Register Src="~/Controls/ExposuresTab/ExposuresTab.ascx" TagName="CtlTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposureInfo/ExposureInfo.ascx" TagName="ctrlExposureInfo"
    TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        function ConfirmRemove() {
            return confirm("Are you sure to remove?");
        }
    </script>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100%" style="height: 50px;" valign="bottom" colspan="2">
                <uc:CtlTab runat="server" ID="Tab"></uc:CtlTab>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td class="Spacer" style="height: 15px;" colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" colspan="3">
                            <asp:UpdatePanel ID="upPanel1" runat="server" UpdateMode="Always">
                                <ContentTemplate>
                                    <uc:ctrlExposureInfo ID="ucCtrlExposureInfo" runat="server" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" style="height: 15px;" colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td class="leftMenu">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="height: 18px;" class="Spacer">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100%">
                                        &nbsp;&nbsp;<span id="FrenchiseGrid" class="LeftMenuSelected">Franchise Grid</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 10px;" class="Spacer">
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 5px">
                            &nbsp;
                        </td>
                        <td valign="top" class="dvContainer">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td style="width: 800px" valign="top">
                                        <div id="dvEdit" runat="server">
                                            <asp:Panel ID="pnlPropertyCope" runat="server" Width="100%">
                                                <div class="bandHeaderRow" id="hdrPropertyCope" runat="server">
                                                    Franchise Grid</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%" id="tblPropertyCope"
                                                    runat="server">
                                                    <tr>
                                                        <td align="left" valign="top" width="10%">
                                                            Franchise Grid<br />
                                                            <asp:LinkButton ID="lnkAddFranchise" runat="server" OnClick="lnkAddFranchise_Click"
                                                                CausesValidation="false">--Add--</asp:LinkButton>
                                                        </td>
                                                        <td align="center" valign="top" width="2%">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4" width="88%">
                                                            <asp:GridView ID="gvFranchise" runat="server" Width="100%" EmptyDataText="No Record Found"
                                                                AllowPaging="true" PageSize="50" OnPageIndexChanging="gvFranchise_PageIndexChanging"
                                                                OnRowCommand="gvFranchise_RowCommand" OnRowDataBound="gvFranchise_RowDataBound"
                                                                HeaderStyle-VerticalAlign="Top">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Building">
                                                                        <ItemStyle Width="44%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkBuilding" runat="server" Text='<%#Eval("Building_Number")%>'
                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_Franchise") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Brand">
                                                                        <ItemStyle Width="18%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkBrand" runat="server" Text='<%#Eval("Brand")%>' CommandName="ShowDetails"
                                                                                CommandArgument='<%#Eval("PK_Franchise") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Construction Start">
                                                                        <ItemStyle Width="14%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkConstruction_Start" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Construction_Start","{0:MM/dd/yyyy}")%>'
                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_Franchise") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Construction Finish">
                                                                        <ItemStyle Width="14%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkConstruction_Finish" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Construction_Finish","{0:MM/dd/yyyy}")%>'
                                                                                CommandName="ShowDetails" CommandArgument='<%#Eval("PK_Franchise") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove" HeaderStyle-HorizontalAlign="Center">
                                                                        <ItemStyle Width="10%" HorizontalAlign="Center" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CommandName="RemoveDetails"
                                                                                CommandArgument='<%#Eval("PK_Franchise") %>' OnClientClick="return ConfirmRemove();" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="height: 35px;" valign="middle">
                                        <asp:Button ID="btnEdit" runat="server" Text=" Edit " OnClick="btnEdit_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 15px;" class="Spacer" colspan="2">
            </td>
        </tr>
    </table>
</asp:Content>
