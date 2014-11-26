<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="WCAllocation.aspx.cs"
    Inherits="Administrator_WCAllocation" Title="eRIMS Sonic :: WC Allocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript" src="../JavaScript/Validator.js"></script>

    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td class="bandHeaderRow" colspan="4" align="left">
                WC Allocation
            </td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;
            </td>
        </tr>
        <tr runat="server" id="divViewWCList">
            <td colspan="4">
                <table cellpadding="0" cellspacing="0" border="0" style="text-align: right; width: 100%;">
                    <tr>
                        <td>
                            <asp:Button ID="btnAddNew" runat="server" Text="Add New" ToolTip="Add new Charges"
                                OnClick="btnAddNew_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px;">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left;">
                            <asp:GridView ID="gvworkers_comp_charges" runat="server" AutoGenerateColumns="false" AllowSorting="true"
                                Width="100%" DataKeyNames="Worker_Comp_id" OnRowDataBound="gvworkers_comp_charges_RowDataBound"
                                OnRowCommand="gvworkers_comp_charges_RowCommand" OnRowCreated="gvworkers_comp_charges_RowCreated"
                                OnRowEditing="gvworkers_comp_charges_RowEditing" OnRowDeleting="gvworkers_comp_charges_RowDeleting"
                                OnSorting="gvworkers_comp_charges_Sorting">
                                <Columns>
                                    <asp:TemplateField HeaderText="Year" SortExpression="Year">
                                        <ItemStyle Width="25%" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblYear" runat="server" Text='<%# Eval("Year")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Region" SortExpression="Region">
                                        <ItemStyle Width="30%" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblRegion" runat="server" Text='<%# Eval("Region")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cause" SortExpression="Cause">
                                        <ItemStyle Width="25%" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblCause" runat="server" Text='<%# Eval("Cause")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Charge" SortExpression="Charge">
                                        <ItemStyle Width="25%" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblCharge" runat="server" Text='<%# Eval("Charge")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle Width="10%" />
                                        <ItemTemplate>
                                            <asp:Button runat="server" ID="lnkEdit" CommandName="Edit" CausesValidation="false"
                                                Text="Edit"></asp:Button>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle Width="10%" />
                                        <ItemTemplate>
                                            <asp:Button runat="server" ID="lnkView" CommandName="View" CausesValidation="false"
                                                Text="View"></asp:Button>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle Width="10%" />
                                        <ItemTemplate>
                                            <asp:Button runat="server" ID="lnkDelete" CommandName="Delete" CausesValidation="false"
                                                Text="Delete" OnClientClick="javascript:return confirm('are you sure to delete?');">
                                            </asp:Button>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                <EmptyDataTemplate>
                                    Currently there is No Data found.
                                </EmptyDataTemplate>
                                <PagerSettings Visible="False" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="divModifyWC" runat="server" style="display: none;">
            <td colspan="4" align="center">
                <div runat="server" id="DivEditWC" style="width: 100%">
                    <table width="100%" cellpadding="3" cellspacing="1" border="0">
                        <tr>
                            <td colspan="6" align="center">
                                <table cellpadding="3" cellspacing="1" align="center" width="100%">
                                    <tr>
                                        <td style="width: 39%">
                                            &nbsp;
                                        </td>
                                        <td style="width: 8%;" align="left">
                                            Year<span style="color: Red;">*</span>
                                        </td>
                                        <td style="width: 4%;" align="Center">
                                            :
                                        </td>
                                        <td align="left" style="width: 10%;">
                                            <asp:TextBox runat="server" ID="txtYear" MaxLength="4" ValidationGroup="vsErrorGroup"
                                                Width="170px"></asp:TextBox>&nbsp;
                                            <asp:RequiredFieldValidator ID="rfvYear" ControlToValidate="txtYear" Display="None"
                                                runat="server" InitialValue="" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Year."></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="revYear" runat="server" ControlToValidate="txtYear"
                                                Display="none" SetFocusOnError="true" ErrorMessage="Year is Invalid." ValidationExpression="[\d]{4}"
                                                ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                        </td>
                                        <td style="width: 39%">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 39%">
                                            &nbsp;
                                        </td>
                                        <td align="left">
                                            Region<span style="color: Red;">*</span>
                                        </td>
                                        <td align="Center">
                                            :
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList runat="server" ID="ddlRegion" SkinID="ddlSONIC" ValidationGroup="vsErrorGroup">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvRegion" ControlToValidate="ddlRegion" Display="None"
                                                runat="server" InitialValue="0" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please select Region."></asp:RequiredFieldValidator>
                                        </td>
                                        <td style="width: 39%">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 39%">
                                            &nbsp;
                                        </td>
                                        <td align="left">
                                            Cause<span style="color: Red;">*</span>
                                        </td>
                                        <td align="Center">
                                            :
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList runat="server" ID="ddlCause" ValidationGroup="vsErrorGroup" SkinID="ddlSONIC">
                                                <asp:ListItem Value="0" Text="-- Select --"></asp:ListItem>
                                                <asp:ListItem Value="S1" Text="S1"></asp:ListItem>
                                                <asp:ListItem Value="S2" Text="S2"></asp:ListItem>
                                                <asp:ListItem Value="S3" Text="S3"></asp:ListItem>
                                                <asp:ListItem Value="S4" Text="S4"></asp:ListItem>
                                                <asp:ListItem Value="S5" Text="S5"></asp:ListItem>
                                            </asp:DropDownList>
                                            &nbsp;
                                            <asp:RequiredFieldValidator ID="rfvCause" ControlToValidate="ddlCause" Display="None"
                                                runat="server" InitialValue="0" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please select Cause."></asp:RequiredFieldValidator>
                                        </td>
                                        <td style="width: 39%">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 39%">
                                            &nbsp;
                                        </td>
                                        <td align="left" style="height: 30px">
                                            Charge<span style="color: Red;">*</span>
                                        </td>
                                        <td align="Center" style="height: 30px">
                                            :
                                        </td>
                                        <td align="left" style="height: 30px">
                                            <asp:TextBox runat="server" ID="txtCharge" Width="170px" MaxLength="10" onpaste="return false"
                                                onkeypress="return currencyFormat(this,',','.',event);"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="REVCharge" runat="server" ControlToValidate="txtCharge"
                                                Display="none" SetFocusOnError="true" ErrorMessage="Charge must be numeric" ValidationExpression="^\d{1,3}(,\d\d\d)*\.\d\d$"
                                                ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="rfvCharge" ControlToValidate="txtCharge" Display="None"
                                                runat="server" InitialValue="" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Charge."></asp:RequiredFieldValidator>
                                        </td>
                                        <td style="width: 39%">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div runat="server" id="DivViewWC" style="width: 100%">
                    <table width="100%" cellpadding="3" cellspacing="1" border="0">
                        <tr>
                            <td colspan="6" align="center">
                                <table cellpadding="3" cellspacing="1" align="center" width="100%">
                                    <tr>
                                        <td style="width: 39%">
                                            &nbsp;
                                        </td>
                                        <td style="width: 8%;" align="left">
                                            Year<span style="color: Red;">*</span>
                                        </td>
                                        <td style="width: 4%;" align="Center">
                                            :
                                        </td>
                                        <td align="left" style="width: 10%">
                                            <asp:Label runat="server" ID="lblYear" Width="170px"></asp:Label>
                                        </td>
                                        <td style="width: 39%">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 39%">
                                            &nbsp;
                                        </td>
                                        <td align="left">
                                            Region<span style="color: Red;">*</span>
                                        </td>
                                        <td align="Center">
                                            :
                                        </td>
                                        <td align="left">
                                            <asp:Label runat="server" ID="lblRegion" Width="170px"></asp:Label>
                                        </td>
                                        <td style="width: 39%">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 39%">
                                            &nbsp;
                                        </td>
                                        <td align="left">
                                            Cause<span style="color: Red;">*</span>
                                        </td>
                                        <td align="Center">
                                            :
                                        </td>
                                        <td align="left">
                                            <asp:Label runat="server" ID="lblCause" Width="170px"></asp:Label>
                                        </td>
                                        <td style="width: 39%">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 39%">
                                            &nbsp;
                                        </td>
                                        <td align="left">
                                            Charge<span style="color: Red;">*</span>
                                        </td>
                                        <td align="Center">
                                            :
                                        </td>
                                        <td align="left">
                                            <asp:Label runat="server" ID="lblCharge" Width="170px"></asp:Label>
                                        </td>
                                        <td style="width: 39%">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <table width="100%" cellpadding="3" cellspacing="1" border="0">
                    <tr>
                        <td align="center">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td colspan="5">
                                        &nbsp;<asp:Label runat="server" ID="lblError" CssClass="error" EnableViewState="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 25%">
                                        &nbsp;
                                    </td>
                                    <td align="right" style="width: 24%">
                                        <asp:Button ID="btnSave" runat="server" Text="Save" CausesValidation="true" ValidationGroup="vsErrorGroup"
                                            OnClick="btnSave_Click" />
                                    </td>
                                    <td style="width: 2%">
                                        &nbsp;
                                    </td>
                                    <td style="width: 24%" align="left">
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false"
                                            OnClick="btnCancel_Click" />
                                    </td>
                                    <td style="width: 25%">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
