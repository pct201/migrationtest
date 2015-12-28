<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="ConstructionProjectManagement.aspx.cs" Inherits="SONIC_Exposures_ConstructionProjectManagement" %>

<%@ Register Src="~/Controls/ExposuresTab/ExposuresTab.ascx" TagName="CtlTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposureInfo/ExposureInfo.ascx" TagName="ctrlExposureInfo"
    TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                        <td class="Spacer" style="height: 15px;" colspan="3"></td>
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
                        <td class="Spacer" style="height: 15px;" colspan="3"></td>
                    </tr>
                    <tr>
                        <td class="ghc" align="left" colspan="4">Construction Project Management
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" style="height: 15px;" colspan="3"></td>
                    </tr>
                    <tr>
                        <td class="leftMenu">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="height: 18px;" class="Spacer"></td>
                                </tr>
                                <tr>
                                    <td width="100%">&nbsp;&nbsp;<span id="FrenchiseGrid" class="LeftMenuSelected">Projects Grid</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100%">&nbsp;&nbsp;<a id="aAddProject" runat="server" href="#" visible="false" style="text-decoration:underline">Add</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 10px;" class="Spacer"></td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 5px">&nbsp;
                        </td>
                        <td valign="top" class="dvContainer">
                            <table cellpadding="3" cellspacing="1" border="0" width="800px" id="tblPropertyCope"
                                runat="server">
                                <tr>
                                    <td align="left" valign="top" colspan="4" width="88%">
                                        <asp:GridView ID="gvProjectList" runat="server" Width="100%" EmptyDataText="No Record Found" AllowSorting="true" OnSorting="gvProjectList_Sorting"
                                            AllowPaging="true" PageSize="50" OnPageIndexChanging="gvProjectList_PageIndexChanging" OnRowCommand="gvProjectList_RowCommand"
                                            HeaderStyle-VerticalAlign="Top">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Project Number" SortExpression="Project_Number">
                                                    <ItemStyle Width="15%" />
                                                    <ItemTemplate>
                                                        <a style="word-break:break-all; word-wrap:normal; display:inline-block;" href='ConstructionProjectsView.aspx?loc=<%# Encryption.Encrypt(Eval("FK_Location").ToString()) %>&prjId=<%# Encryption.Encrypt(Eval("PK_Facility_construction_Project").ToString()) %>'><%# Eval("Project_Number") %></a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Title" SortExpression="Title">
                                                    <ItemStyle Width="15%"  />
                                                    <ItemTemplate>
                                                        <a style="word-break:break-all; word-wrap:normal; display:inline-block;" href='ConstructionProjectsView.aspx?loc=<%# Encryption.Encrypt(Eval("FK_Location").ToString()) %>&prjId=<%# Encryption.Encrypt(Eval("PK_Facility_construction_Project").ToString()) %>'><%# Eval("Title") %></a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Building" SortExpression="Building_Number">
                                                    <ItemStyle Width="15%"  />
                                                    <ItemTemplate>
                                                        <a style="word-break:break-all; word-wrap:normal; display:inline-block;" href='ConstructionProjectsView.aspx?loc=<%# Encryption.Encrypt(Eval("FK_Location").ToString()) %>&prjId=<%# Encryption.Encrypt(Eval("PK_Facility_construction_Project").ToString()) %>'><%# DBNull.Value.Equals(Eval("Building_Number")) ? "" : Convert.ToString(Eval("Building_Number")).Trim(',') %></a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Project Type" SortExpression="Type_Description">
                                                    <ItemStyle Width="15%" />
                                                    <ItemTemplate>
                                                        <a style="word-break:break-all; word-wrap:normal; display:inline-block;" href='ConstructionProjectsView.aspx?loc=<%# Encryption.Encrypt(Eval("FK_Location").ToString()) %>&prjId=<%# Encryption.Encrypt(Eval("PK_Facility_construction_Project").ToString()) %>'><%# Eval("Type_Description") %></a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Estimated Start Date" SortExpression="Estimated_Start_Date">
                                                    <ItemStyle Width="20%" />
                                                    <ItemTemplate>
                                                        <a href='ConstructionProjectsView.aspx?loc=<%# Encryption.Encrypt(Eval("FK_Location").ToString()) %>&prjId=<%# Encryption.Encrypt(Eval("PK_Facility_construction_Project").ToString()) %>'><%# DBNull.Value.Equals(Eval("Estimated_Start_Date")) ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Estimated_Start_Date"))) %></a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Estimated Complete Date" SortExpression="Estimated_Completion_Date">
                                                    <ItemStyle Width="20%" />
                                                    <ItemTemplate>
                                                        <a href='ConstructionProjectsView.aspx?loc=<%# Encryption.Encrypt(Eval("FK_Location").ToString()) %>&prjId=<%# Encryption.Encrypt(Eval("PK_Facility_construction_Project").ToString()) %>'><%# DBNull.Value.Equals(Eval("Estimated_Completion_Date")) ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Estimated_Completion_Date")))%></a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Remove">
                                                    <ItemStyle Width="10%" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbtnRemove" TeID="lnkRemove" OnClientClick="return ConfirmRemove();" CausesValidation="false"
                                                            runat="server" CommandName="RemoveProject" CommandArgument='<%#Eval("PK_Facility_construction_Project")%>'
                                                            Text="Remove"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="height: 35px;" valign="middle" width="100%" colspan="4">
                            <asp:Button ID="btnEdit" runat="server" Text=" Edit " OnClick="btnEdit_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text=" Return to View Mode" OnClick="btnCancel_Click" Visible="false" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 15px;" class="Spacer" colspan="2"></td>
        </tr>
    </table>
    <script type="text/javascript">
        function ConfirmRemove() {
            return confirm("Are you sure you want to remove the record?");
        }
    </script>
</asp:Content>
