<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Learning_Program_Items_Report.aspx.cs" Inherits="SONIC_Exposures_Learning_Program_Items_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <br />
    <br />
    <asp:Panel ID="pnlSearch" runat="server">
        <div align="center" style="width: 100%">
            <table border="0" cellpadding="2" cellspacing="2" width="60%">
                <tr>
                    <td colspan="6">&nbsp;
                    </td>
                </tr>

                <tr>
                    <td align="left" class="lc" valign="top">Year<span id="Span2" style="color: Red;" runat="server">*</span>
                    </td>
                    <td align="right" class="lc" valign="top">:
                    </td>
                    <td align="left" class="lc" valign="top">
                        <asp:DropDownList ID="ddlYear" runat="server" Width="180px" SkinID="ddlSONIC">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvYear" Display="none" runat="server" ControlToValidate="ddlYear"
                            ErrorMessage="Please Select Year." Text="*" ValidationGroup="vsErrorGroup" InitialValue="0">
                        </asp:RequiredFieldValidator>
                    </td>
                    <td align="left" class="lc" valign="top">Quarter <span id="Span1" style="color: Red;" runat="server">*</span>
                    </td>
                    <td align="right" class="lc" valign="top">:
                    </td>
                    <td align="left" class="lc" valign="top">
                        <asp:DropDownList ID="ddlQuarter" runat="server" Width="180px" SkinID="ddlSONIC">
                            <asp:ListItem Value="0" Text="-- Select --">
                            </asp:ListItem>
                            <asp:ListItem Value="1" Text="1">
                            </asp:ListItem>
                            <asp:ListItem Value="2" Text="2">
                            </asp:ListItem>
                            <asp:ListItem Value="3" Text="3">
                            </asp:ListItem>
                            <asp:ListItem Value="4" Text="4">
                            </asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvMonth" Display="none" runat="server" ControlToValidate="ddlQuarter"
                            ErrorMessage="Please Select Quarter." Text="*" ValidationGroup="vsErrorGroup" InitialValue="0">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td colspan="6">&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="6">
                        <asp:Button ID="btnSubmit" runat="server" Text="Search" ValidationGroup="vsErrorGroup" CausesValidation="true" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="6">&nbsp;</td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlResult">
        <div>
            <asp:GridView ID="gvLearning_Program" runat="server" EmptyDataText="No Records Found" Width="100%">
                <Columns>
                    <asp:TemplateField HeaderText="Training Classes">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="100%" HorizontalAlign="left" />
                        <ItemTemplate>
                            <%# Eval("LearningProgramTitle") %> 
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </asp:Panel>

    <br />
    <br />

</asp:Content>

