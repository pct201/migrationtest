<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="RLCM_QA_QC.aspx.cs" Inherits="SONIC_Exposures_RLCM_QA_QC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <div align="center" style="width: 100%">
        <asp:Panel ID="pnlSearch" runat="server">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr style="height: 20px;" align="left">
                    <td class="PropertyInfoBG" style="padding-left: 20px;">RLCM Monthly QA/QC - Search Filter
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
            </table>
            <table border="0" cellpadding="2" cellspacing="2" width="80%">
                <tr>
                    <td align="left" class="lc">RLCM<span id="Span3" style="color: Red;" runat="server">*</span>
                    </td>
                    <td align="right" class="lc" valign="top">:
                    </td>
                    <td align="left" class="lc">
                        <asp:DropDownList ID="ddlRLCM" runat="server" Width="180px" SkinID="ddlSONIC">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvRLCM" Display="none" runat="server" ControlToValidate="ddlRLCM"
                            ErrorMessage="Please Select RLCM." Text="*" ValidationGroup="vsErrorGroup" InitialValue="0">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="lc">Month<span id="Span1" style="color: Red;" runat="server">*</span>
                    </td>
                    <td align="right" class="lc" valign="top">:
                    </td>
                    <td align="left" class="lc">
                        <asp:DropDownList ID="ddlMonth" runat="server" Width="180px" SkinID="ddlSONIC" >
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvMonth" Display="none" runat="server" ControlToValidate="ddlMonth"
                            ErrorMessage="Please Select Month." Text="*" ValidationGroup="vsErrorGroup" InitialValue="0">
                        </asp:RequiredFieldValidator>
                    </td>
                    <td align="left" class="lc">Year<span id="Span2" style="color: Red;" runat="server">*</span>
                    </td>
                    <td align="right" class="lc" valign="top">:
                    </td>
                    <td align="left" class="lc">
                        <asp:DropDownList ID="ddlYear" runat="server" Width="180px" SkinID="ddlSONIC">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvYear" Display="none" runat="server" ControlToValidate="ddlYear"
                            ErrorMessage="Please Select Year." Text="*" ValidationGroup="vsErrorGroup" InitialValue="0">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="vsErrorGroup" CausesValidation="true" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlGrid" runat="server" Visible="false">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr style="height: 20px;">
                    <td class="PropertyInfoBG" align="left" style="padding-left: 20px;">RLCM Monthly QA/QC
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>

            </table>
            <table cellpadding="3" cellspacing="1" border="0" style="background-color: Black;" width="97%">
                <tr class="PropertyInfoBG">
                    <td align="left" style="width: 15%">
                        <asp:Label ID="lblHeaderRLCM" Text="RLCM" runat="server"></asp:Label>
                    </td>
                    <td align="left" style="width: 15%">
                        <asp:Label ID="lblHeaderMonth" Text="Month" runat="server"></asp:Label>
                    </td>
                    <td align="left" style="width: 15%">
                        <asp:Label ID="lblHeaderYear" Text="Year" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="background-color: White;">
                    <td align="left">
                        <asp:Label ID="lblRLCM" runat="server"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="lblMonth" runat="server"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="lblYear" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <asp:GridView ID="gvRLCM" runat="server" AutoGenerateColumns="false" Width="100%" EmptyDataText="No Record Found." OnRowDataBound="gvRLCM_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Module" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                        <ItemStyle Width="10%" />
                        <ItemTemplate>
                            <asp:Label ID="lblModule" runat="server" Text='<%# Eval("Module")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="System" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                        <ItemStyle Width="10%" />
                        <ItemTemplate>
                            <asp:Label ID="lblSystem" runat="server" Text='<%# Eval("System") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Task" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                        <ItemStyle Width="30%" />
                        <ItemTemplate>
                            <asp:Label ID="lblTask" runat="server" Text='<%# Eval("Task")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Category" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                        <ItemStyle Width="30%" />
                        <ItemTemplate>
                            <asp:Label ID="lblCategory" runat="server" Text='<%# Eval("Category")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Identifier &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  Status" ItemStyle-HorizontalAlign="left" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                        <ItemStyle Width="20%" />
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0" width="100%" >
                                <tr>
                                    <td>
                                        <asp:GridView ID="gvChildGrid" dontUseScrolls="true" runat="server" AutoGenerateColumns="false" GridLines="None" Width="100%" ShowHeader="False" OnRowDataBound="gvChildGrid_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Identifier" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Center" ItemStyle-BackColor="White">
                                                    <ItemStyle Width="50%" />
                                                     <ItemTemplate>
                                                        <asp:LinkButton ID="lblIdentifier_Link" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_RLCM_QA_QC") %>'
                                                            Text='<%# Eval("Number")%>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" >
                                                   <ItemStyle Width="50%" />
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkStatus" runat="server"  Text='<%# Convert.ToBoolean(Eval("Status"))%>'></asp:CheckBox>
                                                        <asp:HiddenField ID="hdnStatus" runat="server"  Value='<%# Convert.ToBoolean(Eval("Status"))%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
        </asp:Panel>
    </div>

</asp:Content>

