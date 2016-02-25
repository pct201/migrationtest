<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="Project_Management_Add.aspx.cs" Inherits="SONIC_Exposures_Project_Management_Add" %>

<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="3" cellspacing="1" width="100%">
        <tr>
            <td style="height: 18px;" class="Spacer" colspan="2">
            </td>
        </tr>
        <tr>
            <td width="100%" colspan="2">
                <table style="background-color: black" cellspacing="1" cellpadding="3" width="100%"
                    border="0">
                    <tbody>
                        <tr class="PropertyInfoBG">
                            <td style="width: 15%" align="left">
                                <asp:Label ID="lblHeaderLocationNumber" runat="server" Text="Location Number"></asp:Label>
                            </td>
                            <td style="width: 25%" align="left">
                                <asp:Label ID="lblHeaderLocationdba" runat="server" Text="SONIC Location d/b/a"></asp:Label>
                            </td>
                            <td style="width: 25%" align="left" runat="server">
                                <asp:Label ID="lblHeaderAddress" runat="server" Text="Address"></asp:Label>
                            </td>
                            <td style="width: 13%" align="left">
                                <asp:Label ID="lblHeaderCity" runat="server" Text="City"></asp:Label>
                            </td>
                            <td style="width: 12%" align="left">
                                <asp:Label ID="lblHeaderState" runat="server" Text="State"></asp:Label>
                            </td>
                            <td style="width: 10%" align="left">
                                <asp:Label ID="lblHeaderZip" runat="server" Text="Zip"></asp:Label>
                            </td>
                        </tr>
                        <tr style="background-color: white">
                            <td align="left">
                                <asp:Label ID="lblLocation_Number" runat="server">&nbsp;</asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblLocationdba" runat="server"></asp:Label>
                            </td>
                            <td align="left" runat="Server">
                                <asp:Label ID="lblAddress" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblCity" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblState" runat="server" />
                            </td>
                            <td align="left">
                                <asp:Label ID="lblZip" runat="server" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 10px;" class="Spacer" colspan="2">
            </td>
        </tr>
        <tr>
            <td align="left" valign="top" colspan="2">
                <div class="bandHeaderRow">
                    <table width="100%" border="0" cellpadding="2" cellspacing="0">
                        <tr>
                            <td align="left">
                                Project Management Module
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td width="45%">
                        </td>
                        <td valign="top" align="right">
                            <uc:ctrlPaging ID="ctrlPageProjects" runat="server" OnGetPage="GetPage" />
                        </td>
                    </tr>
                </table>
                </br>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top" width="15%">
                Project Management Grid
                <br />
                <asp:LinkButton ID="lnkAdd" Text="Add" runat="server" OnClick="lnkAdd_OnClick" />
            </td>
            <td align="left" valign="top">
                <div style="overflow-x: scroll; overflow-y: none; text-align: left; width: 850px;"
                    id="dvSearchResult" runat="server">
                    <asp:GridView ID="gvProjectManagement" runat="server" Width="900px" AllowSorting="True"
                        AutoGenerateColumns="False" OnRowCommand="gvProjectManagement_OnRowCommand" OnSorting="gvProjectManagement_Sorting"
                        OnRowCreated="gvProjectManagement_RowCreated">
                        <Columns>
                            <asp:TemplateField HeaderText="Project Number" SortExpression="Project_Number">
                                <ItemStyle Width="15%" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkProject_Number" runat="server" CommandName="ViewProjectManagement"
                                        CommandArgument='<%# Eval("PK_EPM_Identification") %>' Text='<%# Eval("Project_Number") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Building(s)" SortExpression="Buildings">
                                <ItemStyle Width="10%" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkBuilding" runat="server" CommandName="ViewProjectManagement"
                                        CommandArgument='<%# Eval("PK_EPM_Identification") %>' Text='<%# Eval("Buildings")%>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Building Description" SortExpression="BuildingDetails">
                                <ItemStyle Width="20%" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkBuildingDetails" runat="server" CommandName="ViewProjectManagement"
                                        CommandArgument='<%# Eval("PK_EPM_Identification") %>' Text='<%# Eval("BuildingDetails")%>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Project Type" SortExpression="Project_Type">
                                <ItemStyle Width="15%" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkProject_Type" runat="server" CommandName="ViewProjectManagement"
                                        CommandArgument='<%# Eval("PK_EPM_Identification") %>' Text='<%# Eval("Project_Type") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                           <%-- <asp:TemplateField HeaderText="Target Department" SortExpression="Target_Dept">
                                <ItemStyle Width="150px" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkTarget_Department" runat="server" CommandName="ViewProjectManagement"
                                        CommandArgument='<%# Eval("PK_EPM_Identification") %>' Text='<%# Eval("Target_Dept") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <%--<asp:TemplateField HeaderText="Estimated Start Date" SortExpression="Estimated_Project_Start_Date">
                                <ItemStyle Width="150px" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEstimated_StartDate" runat="server" CommandName="ViewProjectManagement"
                                        CommandArgument='<%# Eval("PK_EPM_Identification") %>' Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Estimated_Project_Start_Date")) %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Estimated Completion Date" SortExpression="Estimated_Project_Completion_Date">
                                <ItemStyle Width="250px" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEstimated_CompletionDate" runat="server" CommandName="ViewProjectManagement"
                                        CommandArgument='<%# Eval("PK_EPM_Identification") %>' Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Estimated_Project_Completion_Date")) %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Status" SortExpression="Project_Status">
                                <ItemStyle Width="10%" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkStatus" runat="server" CommandName="ViewProjectManagement"
                                        CommandArgument='<%# Eval("PK_EPM_Identification") %>' Text='<%# string.Format("{0:C2}",Eval("Project_Status")) %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="Estimated Cost($)" SortExpression="Estimated_Cost">
                                <ItemStyle Width="150px" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEstimatedCost" runat="server" CommandName="ViewProjectManagement"
                                        CommandArgument='<%# Eval("PK_EPM_Identification") %>' Text='<%# string.Format("{0:C2}",Eval("Estimated_Cost")) %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Actual Cost($)" SortExpression="Actual_Cost">
                                <ItemStyle Width="150px" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkActualCost" runat="server" CommandName="ViewProjectManagement"
                                        CommandArgument='<%# Eval("PK_EPM_Identification") %>' Text='<%# string.Format("{0:C2}",Eval("Actual_Cost")) %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField>
                                <ItemStyle Width="10%" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkRemove" runat="server" CommandName="RemoveProjectManagement"
                                        CommandArgument='<%# Eval("PK_EPM_Identification") %>' Text="Remove" OnClientClick="return confirm('Are you Sure to delete this record?');"></asp:LinkButton>
                                </ItemTemplate>
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
                </div>
            </td>
        </tr>
        <tr>
            <td align="left">&nbsp;</td>
            <td align="center"><asp:Button runat="server" ID="btnBack" Text="Return To EHS Module" Visible="false" OnClick="btnBack_Click"/></td>
        </tr>
    </table>
</asp:Content>
