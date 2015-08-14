<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="LU_Incident_Type.aspx.cs" Inherits="Administrator_LU_Incident_Type" %>

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
    <asp:UpdatePanel runat="server" ID="updStatus">
        <ContentTemplate>
            <table cellspacing="0" cellpadding="0" width="100%">
                <tbody>
                    <tr>
                        <td colspan="4">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="bandHeaderRow" align="left" colspan="4">Administrator :: Event Type
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
                                            <asp:GridView ID="gvIncidentType" runat="server" Width="100%" AutoGenerateColumns="false"
                                                PageSize="10" EnableViewState="true" AllowPaging="true" OnRowCommand="gvIncidentType_RowCommand"
                                                OnPageIndexChanging="gvIncidentType_PageIndexChanging">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Description">
                                                        <ItemStyle Width="20%" />
                                                        <ItemTemplate>
                                                            <%#Eval("Fld_Desc")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Code">
                                                        <ItemStyle Width="5%" />
                                                        <ItemTemplate>
                                                            <%#Eval("Fld_Code")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Event Level">
                                                        <ItemStyle Width="20%" />
                                                        <ItemTemplate>
                                                            <%#Eval("EventLevel_Fld_Desc")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Event Outcome">
                                                        <ItemStyle Width="15%" />
                                                        <ItemTemplate>
                                                            <%#Eval("Event_Outcome")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Is Actionable">
                                                        <ItemStyle Width="15%" />
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblIs_Actionable" Text='<%#(Convert.ToString(Eval("Is_Actionable"))  == "N" ? "No" : "Yes") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Status">
                                                        <ItemStyle Width="10%" />
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblActive" Text='<%#(Convert.ToString(Eval("Active"))  == "N" ? "In Active" : "Active") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="&nbsp;&nbsp;&nbsp;&nbsp;Edit">
                                                        <ItemStyle Width="10%" />
                                                        <ItemTemplate>
                                                            <asp:Button runat="server" ID="lnkEdit" Text=" Edit " CommandName="EditRecord" CommandArgument='<%#Eval("PK_LU_Event_Type") %>'></asp:Button>
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
                        <td colspan="2" style="padding-bottom: 5px;">
                            <asp:LinkButton Style="display: inline" ID="lnkAddNew" OnClick="lnkAddNew_Click"
                                runat="server" Text="Add New"></asp:LinkButton>&nbsp;&nbsp;&nbsp;<asp:LinkButton
                                    Style="display: none" ID="lnkCancel" OnClick="lnkCancel_Click" runat="server"
                                    Text="Cancel"></asp:LinkButton>
                        </td>
                        <td style="width: 20%">&nbsp;
                        </td>
                    </tr>
                    <tr style="display: none" id="trStatusAdd" runat="server">
                        <td style="width: 20%">&nbsp;
                        </td>
                        <td colspan="2" style="padding-left: 50px;">
                            <table cellspacing="1" cellpadding="3" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td style="width: 18%" align="left">Description<span class="mf">*</span>
                                        </td>
                                        <td style="width: 4%" align="center">:
                                        </td>
                                        <td align="left" colspan="4">
                                            <asp:TextBox ID="txtDescription" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvStatus" runat="server" ValidationGroup="vsError"
                                                SetFocusOnError="true" ErrorMessage="Please Enter Description" Display="none"
                                                ControlToValidate="txtDescription"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 18%" align="left">Code<span class="mf">*</span>
                                        </td>
                                        <td style="width: 4%" align="center">:
                                        </td>
                                        <td align="left" colspan="4">
                                            <asp:TextBox ID="txtCode" runat="server" Width="170px" MaxLength="5"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="vsError"
                                                SetFocusOnError="true" ErrorMessage="Please Enter Code" Display="none" ControlToValidate="txtCode"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 18%" align="left">Event Outcome<%--<span class="mf">*</span>--%></td>
                                        <td style="width: 4%" align="center">:
                                        </td>
                                        <td align="left" colspan="4">
                                            <asp:TextBox ID="txtEvent_Outcome" runat="server" Width="170px" MaxLength="5"
                                                onKeyPress="return FormatInteger(event);" autocomplete="off" onpaste="return false;"></asp:TextBox>
                                            <%--<asp:RequiredFieldValidator ID="rfvEventOutcome" runat="server" ValidationGroup="vsError"
                                                SetFocusOnError="true" ErrorMessage="Please Enter Event OutCome" Display="none" ControlToValidate="txtEvvent_Outcome"></asp:RequiredFieldValidator>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 18%" align="left">
                                            Event Level<span class="mf"></span>
                                        </td>
                                        <td style="width: 4%" align="center">
                                            :
                                        </td>
                                        <td align="left" colspan="4">
                                            <asp:DropDownList ID="ddlEventLevel" runat="server" Width="175px" SkinID="dropGen"></asp:DropDownList>
                                            <%--<asp:RequiredFieldValidator ID="rfvddlEventLevel" runat="server" ValidationGroup="vsError" InitialValue="0"
                                                SetFocusOnError="true" ErrorMessage="Please Select Event Level" Display="none" ControlToValidate="ddlEventLevel"></asp:RequiredFieldValidator>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">Is Actionable
                                        </td>
                                        <td align="center">:
                                        </td>
                                        <td align="left" colspan="4">
                                            <asp:RadioButtonList ID="rdblIs_Actionable" runat="server">
                                                <asp:ListItem Text="Yes" Value="Y" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">Active
                                        </td>
                                        <td align="center">:
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
                                        <td align="left"></td>
                                        <td align="center"></td>
                                        <td align="left">
                                            <asp:Button ID="btnAdd" OnClick="btnAdd_Click" runat="server" ValidationGroup="vsError"
                                                Text="Add" Width="70px" Action_StatussValidation="false" OnClientClick="return CheckValidation();"></asp:Button>
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
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
