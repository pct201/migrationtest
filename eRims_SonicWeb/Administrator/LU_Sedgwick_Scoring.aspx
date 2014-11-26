<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="LU_Sedgwick_Scoring.aspx.cs" Inherits="Administrator_LU_Sedgwick_Scoring" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        function AddNewGroup() {
            document.getElementById('<%=trStatusAdd.ClientID %>').style.display = "block";
        document.getElementById('<%=lnkCancel.ClientID %>').style.display = "inline";
    }

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
                        <td class="bandHeaderRow" align="left" colspan="4">Administrator :: Scoring Notes
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
                                            <asp:GridView ID="gvSedgwick_Scoring" runat="server" Width="100%" AutoGenerateColumns="false"
                                                PageSize="10" EnableViewState="true" AllowPaging="true" OnRowCommand="gvSedgwick_Scoring_RowCommand"
                                                OnPageIndexChanging="gvSedgwick_Scoring_PageIndexChanging">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Management Section">
                                                        <ItemStyle Width="25%" />
                                                        <ItemTemplate>
                                                            <%#Eval("Management_Section")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Sort Order">
                                                        <ItemStyle Width="15%" />
                                                        <ItemTemplate>
                                                            <%#Eval("Sort_Order") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Scoring Note">
                                                        <ItemStyle Width="35%" />
                                                        <ItemTemplate>
                                                            <%#Eval("Scoring_Note") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Status">
                                                        <ItemStyle Width="15%" />
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblActive" Text='<%#(Eval("Active").ToString() == "Y" ? "Active" : "In Active") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemStyle Width="10%" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton runat="server" ID="lnkEdit" Text="Edit" CommandName="EditRecord"
                                                                CommandArgument='<%#Eval("PK_LU_Sedgwick_Scoring") %>'></asp:LinkButton>
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
                        <td colspan="2">
                            <table cellspacing="1" cellpadding="3" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td style="width: 25%" align="left">Management Section<span class="mf">*</span>
                                        </td>
                                        <td style="width: 4%" align="center">:
                                        </td>
                                        <td align="left" colspan="4">
                                            <asp:DropDownList ID="drpManagement_Section" Width="180px" SkinID="dropGen" runat="server">
                                                <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                <asp:ListItem Text="Investigation" Value="Investigation"></asp:ListItem>
                                                <asp:ListItem Text="Subrogation" Value="Subrogation"></asp:ListItem>
                                                <asp:ListItem Text="Medical" Value="Medical"></asp:ListItem>
                                                <asp:ListItem Text="Disability" Value="Disability"></asp:ListItem>
                                                <asp:ListItem Text="Closure Plan" Value="Closure Plan"></asp:ListItem>
                                                <asp:ListItem Text="Reserves" Value="Reserves"></asp:ListItem>
                                                <asp:ListItem Text="Leadership" Value="Leadership"></asp:ListItem>

                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvdrpManagement_Section" runat="server" ValidationGroup="vsError"
                                                SetFocusOnError="true" ErrorMessage="Please Select Management Section" Display="none"
                                                ControlToValidate="drpManagement_Section"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 25%" align="left">Sort Order<span class="mf">*</span>
                                        </td>
                                        <td style="width: 4%" align="center">:
                                        </td>
                                        <td align="left" colspan="4">
                                            <asp:TextBox ID="txtSort_Order" runat="server" MaxLength="2" Width="20px" onkeypress="return FormatNumber(event,this.id,4,false);"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvtxtSort_Order" runat="server" ValidationGroup="vsError"
                                                SetFocusOnError="true" ErrorMessage="Please Enter Sort Order" Display="none"
                                                ControlToValidate="txtSort_Order"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 25%" align="left">Scoring Note<span class="mf">*</span>
                                        </td>
                                        <td style="width: 4%" align="center">:
                                        </td>
                                        <td align="left" colspan="4">
                                            <asp:TextBox ID="txtDescription" runat="server" MaxLength="500" TextMode="MultiLine"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvSCoringNote" runat="server" ValidationGroup="vsError"
                                                SetFocusOnError="true" ErrorMessage="Please Enter Scoring Note" Display="none"
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

