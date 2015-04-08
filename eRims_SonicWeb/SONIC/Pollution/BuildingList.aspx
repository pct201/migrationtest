<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="BuildingList.aspx.cs" Inherits="SONIC_Pollution_BuildingList" %>
<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellpadding="1" cellspacing="1" width="100%" border="0">
            <tr>
                <td align="left">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="left">
                    <table cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td width="45%">
                                &nbsp;<span class="heading">EHS Module Building Grid</span><br />
                                &nbsp;<asp:Label ID="lblNumber" runat="server" Text=""></asp:Label>&nbsp;Buildings
                                Found
                            </td>
                            <td valign="top" align="right">
                                <uc:ctrlPaging ID="ctrlPageIncident" runat="server" OnGetPage="GetPage" />
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
                                <asp:GridView ID="gvBuilding" runat="server" Width="100%" OnRowCommand="gvBuilding_RowCommand"
                                    OnRowDataBound="gvBuilding_RowDataBound" AllowSorting="True" AutoGenerateColumns="False"
                                    OnRowCreated="gvBuilding_RowCreated" OnSorting="gvBuilding_Sorting">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sonic Location Code" SortExpression="Sonic_Location_Code">
                                            <ItemStyle Width="15%" HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <%#Eval("Sonic_Location_Code")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sonic Location d/b/a" SortExpression="dba">
                                            <ItemStyle Width="20%" HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <%#Eval("dba")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Building" SortExpression="Building_Occupacy">
                                            <ItemStyle Width="60%" HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <%# Eval("Building_Occupacy")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Disposition">
                                            <ItemStyle Width="5%" HorizontalAlign="Left" Wrap="false" />
                                            <ItemTemplate>                                                
                                                    <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CommandName="EditDetails"
                                                        CommandArgument='<%#Eval("PK_Building_ID") + ":" + Eval("PK_PM_Site_Information") %>'></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkAdd" runat="server" Text="Add" CommandName="AddDetails"
                                                        CommandArgument='<%#Eval("PK_Building_ID")%>'></asp:LinkButton>
                                                   &nbsp;&nbsp;<asp:LinkButton ID="lnkView" runat="server" Text="View" CommandName="ViewDetails"
                                                    CommandArgument='<%#Eval("PK_Building_ID")  + ":" + Eval("PK_PM_Site_Information")%>'></asp:LinkButton>&nbsp;&nbsp;                                                   
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
                                    <HeaderStyle VerticalAlign="Top" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td width="100%" class="Spacer" style="height: 10px;">
                </td>
            </tr>
            <tr>
                <td><table width="100%"><tr>
                <td align="center">
                    <asp:Button ID="btnReturntoPM" runat="server" Text="Return to Project Management Module" OnClick="btnReturntoPM_Click" />&nbsp;                
                    <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
                </td>
                    </tr>
                </table></td>
            </tr>
            <tr>
                <td width="100%" class="Spacer" style="height: 10px;">
                </td>
            </tr>
        </table>
</asp:Content>

