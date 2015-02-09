<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="AdjustPastCharge_ByMarket.aspx.cs"
    Inherits="Administrator_AdjustPastCharge_ByMarket" Title="eRIMS Sonic :: Adjust past charges" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ValidationSummary ID="vsSave" runat="server" HeaderText="Please verify following fields:"
        ShowMessageBox="true" ShowSummary="false" ValidationGroup="vsInvestigation" />
    <asp:ValidationSummary ID="vsSearchInvestigation" runat="server" HeaderText="Please verify following fields:"
        ShowMessageBox="true" ShowSummary="false" ValidationGroup="vsSearch" />
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
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="bandHeaderRow">
                <b>&nbsp;Adjust Past Charge By Market</b>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlSearchWC_FR" runat="server" Style="padding-left: 100px; padding-top: 10px;">
                    <table width="40%" align="left" cellpadding="1" cellspacing="3">
                        <tr>
                            <td style="width: 36%;">
                                Market<span class="mf">*</span>
                            </td>
                            <td style="width: 4%;">
                                :
                            </td>
                            <td style="width: 70%;">
                                <asp:DropDownList ID="drpMarket" runat="server" OnSelectedIndexChanged="drpMarket_SelectedIndexChanged"
                                    AutoPostBack="true" AppendDataBoundItems="true">
                                    <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvdrpMarket" runat="server" ControlToValidate="drpMarket"
                                    InitialValue="0" Display="None" ValidationGroup="vsSearch" ErrorMessage="Please select Market"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                First Report Number<span class="mf">*</span>
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:UpdatePanel ID="updFirstReportNumber" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="drpFirstReportNumber" runat="server" AutoPostBack="true">
                                            <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="drpMarket" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="drpMarket" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                <asp:RequiredFieldValidator ID="rfvdrpFirstReportNumber" runat="server" ControlToValidate="drpFirstReportNumber"
                                    InitialValue="0" Display="None" ValidationGroup="vsSearch" ErrorMessage="Please select First Report Number."></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center">
                                <asp:Button ID="btnEditCuase" runat="server" Text="Search" ToolTip="Search First Report"
                                    OnClick="btnEditCuase_Click" ValidationGroup="vsSearch" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlEditWC_Allocation" runat="server" Visible="false">
                    <table cellpadding="3" cellspacing="5" width="100%">
                        <tr>
                            <td colspan="3">
                                <asp:GridView ID="gvWC_Allocation" runat="server" ShowHeader="true" Width="100%"
                                    AutoGenerateColumns="False" OnRowCommand="gvWC_Allocation_RowCommand" EmptyDataText="No record found!">
                                    <Columns>
                                        <asp:TemplateField HeaderText="First Report Number" SortExpression="FR_Number">
                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lnkView">
                                                <%# Eval("Prefix")%>-<%# Eval("WC_FR_Number") %>
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Charge Type" SortExpression="Charge_Type">
                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                            <ItemTemplate>
                                                <%#Eval("Charge_Type")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Charge Date" SortExpression="ChargeDate">
                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                            <ItemTemplate>
                                                <%#clsGeneral.FormatDBNullDateToDisplay(Eval("ChargeDate"))%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Change Login" SortExpression="Change_login">
                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                            <ItemTemplate>
                                                <%#Eval("Change_login")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Changed" SortExpression="Changed">
                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                            <ItemTemplate>
                                                <%# Convert.ToBoolean(Eval("Changed")) == true  ? "Yes" : "No" %>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Charges(In $)" SortExpression="Charge">
                                            <ItemStyle HorizontalAlign="Right" Width="15%" />
                                            <ItemTemplate>
                                                <%#Eval("Charge","{0:N2}")%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Operation">
                                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lblEdit" runat="server" Text="Edit" CommandName="EditRecord"
                                                    CommandArgument='<%#Eval("PK_WC_Allocation_Charges_ByMarket") %>'></asp:LinkButton>
                                                &nbsp;
                                                <asp:LinkButton ID="lblView" runat="server" Text="View" CommandName="View" CommandArgument='<%#Eval("PK_WC_Allocation_Charges_ByMarket") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center">
                                <asp:Button ID="btnCancel" runat="server" Text="Back To Search" CausesValidation="false"
                                    OnClick="btnCancel_Click" />
                                <asp:Button ID="btnAdd" runat="server" Text="Add" CausesValidation="false" OnClick="btnAdd_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
