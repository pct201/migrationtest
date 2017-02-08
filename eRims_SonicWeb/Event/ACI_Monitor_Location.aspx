<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="ACI_Monitor_Location.aspx.cs" Inherits="Event_ACI_Monitor_Location" %>

<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">

        function CheckValidation() {
            if (Page_ClientValidate("vsError")) {
            }
        }

    </script>
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
                <td class="bandHeaderRow" align="left" colspan="4">Administrator :: Group ID and Location
                </td>
            </tr>
            <tr>
                <td colspan="4">&nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="pnlGrid" runat="server" Width="100%">
                        <table cellspacing="0" cellpadding="0" width="90%" border="0" align="center">
                            <tbody>
                                <tr valign="top">
                                    <td align="left" width="30%">
                                             <%--   Search by Description&nbsp;&nbsp;
                                                <asp:TextBox ID="txtSearchDesc" runat="server" Width="150px" MaxLength="50" />&nbsp;&nbsp;
                                                <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click" />--%>
                                        <br />
                                        <br />
                                        <asp:Label ID="lblNumber" runat="server" Text="0"></asp:Label>&nbsp;Record(s) Found
                                    </td>
                                    <td align="right" width="30%">
                                        <uc:ctrlPaging ID="ctrlPageProperty" runat="server" OnGetPage="GetPage" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:GridView ID="gvGroupID" runat="server" AutoGenerateColumns="false" AllowSorting="true"
                                                Width="100%" OnSorting="gvGroupID_Sorting" OnRowCreated="gvGroupID_RowCreated"
                                                OnRowCommand="gvGroupID_RowCommand">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Location" HeaderStyle-HorizontalAlign="Left"
                                                    ItemStyle-HorizontalAlign="Left" SortExpression="Location">
                                                    <ItemStyle Width="20%" />
                                                    <ItemTemplate>
                                                        <%#Eval("Location")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Building Description" HeaderStyle-HorizontalAlign="Left" 
                                                    ItemStyle-HorizontalAlign="Left" SortExpression="Building_Description">
                                                    <ItemStyle Width="25%" />
                                                    <ItemTemplate>
                                                        <%#Eval("Building_Description") %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Left" 
                                                    ItemStyle-HorizontalAlign="Left" SortExpression="Status">
                                                    <ItemStyle Width="10%" />
                                                    <ItemTemplate>
                                                        <%#Eval("Status") %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Group ID" HeaderStyle-HorizontalAlign="Left" 
                                                    ItemStyle-HorizontalAlign="Left" SortExpression="Group_ID">
                                                    <ItemStyle Width="10%" />
                                                    <ItemTemplate>
                                                        <%#Eval("Group_ID") %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Est. Live <br/> Monitoring Date" HeaderStyle-HorizontalAlign="Left" 
                                                    ItemStyle-HorizontalAlign="Left" SortExpression="Est_Live_Monitoring_Date">
                                                    <ItemStyle Width="15%" />
                                                    <ItemTemplate>
                                                        <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Est_Live_Monitoring_Date")) %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Actual Live <br/> Monitoring Date" HeaderStyle-HorizontalAlign="Left" 
                                                    ItemStyle-HorizontalAlign="Left" SortExpression="Act_Live_Monitoring_Date">
                                                    <ItemStyle Width="15%" />
                                                    <ItemTemplate>
                                                        <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Act_Live_Monitoring_Date")) %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="" HeaderStyle-HorizontalAlign="Center" 
                                                    ItemStyle-HorizontalAlign="Center">
                                                    <ItemStyle Width="5%" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" ID="lnkEdit" Text="Edit" CommandName="EditRecord"
                                                            CommandArgument='<%#Eval("PK_ACI_Link_LU_Location") %>' />&nbsp;
                                                               <%-- <asp:LinkButton runat="server" ID="lnkRemove" Text="Remove" CommandName="RemoveRecord"
                                                                    CommandArgument='<%#Eval("PK_ACI_Link_LU_Location") %>' />&nbsp;--%>
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
                                <tr>
                                    <td colspan="2">&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" width="100%" align="center">
                                        <asp:Button Style="display: inline" ID="lnkAddNew" OnClick="lnkAddNew_Click" runat="server"
                                            Text="Add New"></asp:Button>&nbsp;&nbsp;
                                               <%-- <asp:Button ID="btnExport" runat="server" Text="Export to Excel" OnClick="btnExport_Click" />--%>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="pnlDetail" runat="server" Width="100%" Visible="false">
                       <%-- <table>
                            <tr>
                                <td class="bandHeaderRow" align="left" width="100%">Administrator :: Group ID and Location
                                </td>
                            </tr>
                        </table>--%>
                        <div class="bandHeaderRow">
                            Manage Group ID
                        </div>
                        <table cellspacing="1" cellpadding="3" width="50%" border="0" align="center">
                            <tbody>
                                <tr>
                                    <td style="width: 18%" align="left">Location <span class="mf">*</span>
                                    </td>
                                    <td style="width: 4%" align="center">:
                                    </td>
                                    <td align="left">
                                       <asp:DropDownList ID="drpFK_LU_Location" runat="server" Width="175px" OnSelectedIndexChanged="drpFK_LU_Location_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvdrpFK_LU_Location" runat="server" ValidationGroup="vsError" InitialValue="0"
                                            SetFocusOnError="true" ErrorMessage="Please Select Location" Display="none" ControlToValidate="drpFK_LU_Location"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 18%" align="left">Building <span class="mf">*</span>
                                    </td>
                                    <td style="width: 4%" align="center">:
                                    </td>
                                    <td align="left">
                                       <asp:DropDownList ID="drpFK_Building_ID" runat="server" Width="175px"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvdrpFK_Building_ID" runat="server" ValidationGroup="vsError" InitialValue="0"
                                            SetFocusOnError="true" ErrorMessage="Please Select Building" Display="none" ControlToValidate="drpFK_Building_ID"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 18%" align="left">
                                        Group ID<span class="mf">*</span>
                                    </td>
                                    <td style="width: 4%" align="center">
                                        :
                                    </td>
                                    <td align="left" colspan="4">
                                        <asp:TextBox ID="txtGroup_ID" runat="server" Width="170px" MaxLength="4" autocomplete="off"
                                                onKeyPress="return FormatInteger(event);" onpaste="return false" ></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvtxtGroup_ID" runat="server" ValidationGroup="vsError"
                                            SetFocusOnError="true" ErrorMessage="Please Enter Group ID" Display="none" ControlToValidate="txtGroup_ID"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="3">
                                        <asp:Label ID="lblError" runat="server" SkinID="lblError" EnableViewState="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left"></td>
                                    <td align="center"></td>
                                    <td align="left">
                                        <asp:Button ID="btnAdd" OnClick="btnAdd_Click" runat="server" ValidationGroup="vsError"
                                            Width="70px" Text="Save" CausesValidation="false" OnClientClick="return CheckValidation();"></asp:Button>&nbsp;&nbsp;
                                        <asp:Button CausesValidation="false" ID="btnCancel" OnClick="btnCancel_Click" runat="server"
                                            Text="Cancel"></asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;
                </td>
            </tr>
        </tbody>
    </table>

</asp:Content>

