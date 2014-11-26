<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="rptLossStratification.aspx.cs" 
Inherits="SONIC_ClaimInfo_rptLossStratification" Title="eRIMS Sonic :: Loss Limitation Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ValidationSummary ID="valSummary" runat="server" ShowMessageBox="true" ShowSummary="false" />
    <asp:HiddenField ID="hdnInnerHtml" runat="server" />
    <table width="100%">
        <tr>
            <td>
                <asp:Label ID="lblError" runat="server" Text="" Visible="false" ForeColor="red" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="ghc">
                Loss Stratification Report
            </td>
        </tr>
        <tr>
            <td>
                <table width="40%" align="center" cellpadding="3" cellspacing="0">
                    <tr>
                        <td style="width: 30%;" valign="top">
                            &nbsp; Accident Year <span style="color: Red;">*</span>
                        </td>
                        <td align="right" style="width: 5%;" valign="top">
                            :
                        </td>
                        <td style="width: 65%;">
                            <asp:ListBox ID="lsbPolicyYear" runat="server" SelectionMode="Multiple" Rows="4"
                                ToolTip="Select Accident Year" AutoPostBack="false" Width="166px"></asp:ListBox>
                            <asp:RequiredFieldValidator ID="rfvPolicyYear" runat="server" ErrorMessage="Please Select Accident Year"
                                Font-Bold="true" Display="none" Text="*" ControlToValidate="lsbPolicyYear" SetFocusOnError="false"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            &nbsp; Claim Type <span style="color: Red;">*</span>
                        </td>
                        <td align="right" valign="top">
                            :
                        </td>
                        <td valign="top">
                            <asp:ListBox ID="lsbClaimType" runat="server" SelectionMode="Multiple" Rows="4" ToolTip="Select Claim Type"
                                AutoPostBack="false" Width="166px">
                                <asp:ListItem Value="W" Text="Workers Compensation"></asp:ListItem>
                                <asp:ListItem Value="A" Text="Auto Loss"></asp:ListItem>                                
                                <asp:ListItem Value="P" Text="Premises Loss"></asp:ListItem>
                            </asp:ListBox>
                            <asp:RequiredFieldValidator ID="rfvlsbClaimType" runat="server" ErrorMessage="Please Select Claim Type"
                                Font-Bold="true" Display="none" Text="*" ControlToValidate="lsbClaimType" SetFocusOnError="false"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td align="left">
                            <asp:Button runat="server" ID="btnShowReport" Text="Show Report" UseSubmitBehavior="true"
                                OnClick="btnShowReport_Click" />&nbsp;
                            <asp:Button ID="btnClearCriteria" runat="server" Text="Clear Criteria" ToolTip="Clear All"
                                CausesValidation="false" OnClick="btnClearCriteria_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlReport" runat="server" Visible="false">
        <table width="95%" align="center">
            <tr>
                <td align="center">
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Bold="true" Text=""></asp:Label>
                </td>
            </tr>
            <tr style="height: 30px">
                <td align="left" valign="top">
                    <table id="tblUtility" runat="server" width="100%" align="center">
                        <tr valign="middle">
                            <td align="right" width="100%">
                                <asp:LinkButton ID="lbtExportToExcel" runat="server" Text="Export To Excel" OnClick="lbtExportToExcel_Click"></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td width="100%" align="center">
                    <asp:GridView ID="gvReportYear" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvReportYear_RowDataBound"
                        Width="100%" EnableTheming="false" HorizontalAlign="Left" EmptyDataText="No Record Found" 
                        GridLines="None" ShowFooter="true" CssClass="GridClass">
                        <AlternatingRowStyle BackColor="White" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <RowStyle BackColor="White" />
                        <FooterStyle CssClass="FooterStyle" />
                        <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="20px" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderStyle HorizontalAlign="Left" />
                                <HeaderTemplate>
                                    <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>
                                                                        <table width="100%" style="font-weight: bold;" id="tblHeader" runat="server">
                                                                            <tr>
                                                                                <td align="center" style="width: 50%;" valign="middle">
                                                                                    Claim Size (in $)
                                                                                </td>
                                                                                <td align="right">
                                                                                    Number Of Claims
                                                                                </td>
                                                                                <td style="width: 12%" align="right">
                                                                                    Percent To<br />
                                                                                    Total Claim
                                                                                </td>
                                                                                <td style="width: 16%" align="right">
                                                                                    Total<br />Incurred Dollars
                                                                                </td>
                                                                                <td style="width: 10%" align="right">
                                                                                    Percent To
                                                                                    <br />
                                                                                    Total Dollar
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <table width="100%" align="left">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblPolicyYear" runat="server" Text='<%# "Year - " + Eval("AccidentYear")%>'
                                                    Font-Bold="true" ForeColor="Black">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gvReportClaimType" runat="server" AutoGenerateColumns="false" 
                                                    Width="100%" OnRowDataBound="gvReportClaimType_RowDataBound" ShowHeader="False"
                                                    HorizontalAlign="Left" EnableTheming="false" GridLines="None" ShowFooter="true"
                                                    CssClass="GridClass">
                                                    <FooterStyle Font-Bold="true" ForeColor="Black" />
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <table width="100%" align="left">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblPolicy_Type" runat="server" Text='<%#"Claim Type - " + Eval("Claim_Type") %>'
                                                                                Font-Bold="true" ForeColor="black"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:GridView ID="gvReportDetail" runat="server" AutoGenerateColumns="false" Width="100%"
                                                                                CssClass="GridClass" CellPadding="4" GridLines="None" OnRowDataBound="gvReportDetail_RowDataBound"
                                                                                ShowHeader="False" ShowFooter="true" EnableTheming="false" HorizontalAlign="Left"
                                                                                EmptyDataText="No Record Found !" EmptyDataRowStyle-HorizontalAlign="Left">
                                                                                <RowStyle CssClass="RowStyle" />
                                                                                <AlternatingRowStyle CssClass="AlterRowStyle" />
                                                                                <FooterStyle Font-Bold="true" ForeColor="Black" />
                                                                                <HeaderStyle HorizontalAlign="Right" />
                                                                                <Columns>
                                                                                    <asp:TemplateField>
                                                                                        <ItemStyle Width="50%" HorizontalAlign="left" />
                                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                                        <ItemTemplate>
                                                                                            <asp:Label runat="server" ID="lblStartlimit" Text='<%#DataBinder.Eval(Container.DataItem,"StartLimit","{0:0,0.00}") %>'></asp:Label>
                                                                                            &nbsp;&nbsp;&nbsp;<asp:Label ID="lblMsgTo" runat="server" Text="To"></asp:Label>&nbsp;&nbsp;&nbsp;
                                                                                            <asp:Label runat="server" ID="lblEndLimit" Text='<%#DataBinder.Eval(Container.DataItem,"EndLimit","{0:0,0.00}") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <FooterStyle Wrap="true" />
                                                                                        <FooterTemplate>
                                                                                            <asp:Label ID="lblClaimFooter" runat="server" Text=""></asp:Label>
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField>
                                                                                        <ItemStyle HorizontalAlign="Right" Width="12%" />
                                                                                        <ItemTemplate>
                                                                                            <asp:Label runat="server" ID="lblClaimCount" Text='<%#DataBinder.Eval(Container.DataItem,"ClaimCount","{0:N0}") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <FooterStyle HorizontalAlign="Right" />
                                                                                        <FooterTemplate>
                                                                                            <asp:Label runat="server" ID="lblClaim" Text=""></asp:Label>
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField>
                                                                                        <ItemStyle HorizontalAlign="Right" Width="12%" />
                                                                                        <FooterStyle HorizontalAlign="Right" />
                                                                                        <ItemTemplate>
                                                                                            <asp:Label runat="server" ID="lblClaimPercent" Text='<%#DataBinder.Eval(Container.DataItem,"ClaimPercent","{0:N2}") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <asp:Label ID="lblClaimPercentTotal" runat="server" Text="100.00"></asp:Label>
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField>
                                                                                        <ItemStyle HorizontalAlign="Right" Width="16%" />
                                                                                        <FooterStyle HorizontalAlign="Right" />
                                                                                        <ItemTemplate>
                                                                                            <asp:Label runat="server" ID="lblIncurred" Text='<%#DataBinder.Eval(Container.DataItem,"Incurred","{0:C2}") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <asp:Label ID="lblIncurredTotal" runat="server"></asp:Label>
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField>
                                                                                        <ItemStyle HorizontalAlign="Right" Width="10%" />
                                                                                        <FooterStyle HorizontalAlign="Right" />
                                                                                        <ItemTemplate>
                                                                                            <asp:Label runat="server" ID="lblIncurredPercent" Text='<%#DataBinder.Eval(Container.DataItem,"IncurredPercent","{0:N2}") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <asp:Label ID="lblIncurredPercentTotal" runat="server" Text="100.00"></asp:Label>
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <FooterTemplate>
                                                                <table width="100%;" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td>
                                                                            <div>
                                                                                <table width="100%;" id="tblFooter" runat="server">
                                                                                    <tr>
                                                                                        <td style="width: 50%" align="left">
                                                                                            <asp:Label ID="lblPolicy_Type" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                                        </td>
                                                                                        <td style="width: 12%" align="right">
                                                                                            <asp:Label ID="lblYearTotalClaim" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                                        </td>
                                                                                        <td style="width: 12%" align="right">
                                                                                            <asp:Label ID="lblYearClaimPercent" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                                        </td>
                                                                                        <td style="width: 16%" align="right">
                                                                                            <asp:Label ID="lblYearInCurred" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                                        </td>
                                                                                        <td style="width: 10%" align="right">
                                                                                            <asp:Label ID="lblYearIncurredPercent" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>
                                                                        <table width="100%" cellpadding="2" cellspacing="2" style="color: White; font-weight: bold;
                                                                            background-color: #507CD1;" id="tblFooter" runat="server">
                                                                            <tr>
                                                                                <td style="width: 50%; padding-left: 5px;" align="left" valign="bottom">
                                                                                    <b>Report Grand Total</b>
                                                                                </td>
                                                                                <td style="width: 12%" align="right">
                                                                                    <asp:Label ID="lblGrandTotalNoOFClaim" runat="server"></asp:Label>
                                                                                </td>
                                                                                <td style="width: 12%" align="right">
                                                                                    <asp:Label ID="lblGrandTotalClaimPercent" runat="server" Text="100.00"></asp:Label>
                                                                                </td>
                                                                                <td style="width: 16%; padding-right: 3px;" align="right">
                                                                                    <asp:Label ID="lblGrandTotalIncurred" runat="server"></asp:Label>
                                                                                </td>
                                                                                <td style="width: 10%; padding-right: 5px;" align="right">
                                                                                    <asp:Label ID="lblGrandTotalIncurredPercent" runat="server" Text="100.00"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </FooterTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <table width="100%">
        <tr>
            <td class="Spacer" style="height: 15px;">
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 50px;">
            </td>
        </tr>
    </table>
</asp:Content>

