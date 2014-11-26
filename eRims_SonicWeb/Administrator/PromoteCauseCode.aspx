<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="PromoteCauseCode.aspx.cs"
    Inherits="Administrator_PromoteCauseCode" Title="eRIMS Sonic :: Promote S0 Cause Code" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
        function CheckSave()
        {
            if(Page_ClientValidate("vsInvestigation"))
            {
                return confirm('Are you sure you want to save Sonic Cause Code?');   
            }
            return false; 
        }
    </script>

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
                <b>&nbsp;Promote S0 Cause Code </b>
            </td>
        </tr>
        <tr>
            <td style="padding-left: 100px; padding-top: 10px;">
                <asp:Panel ID="pnlSearchInvestigation" runat="server">
                    <table width="40%" align="left" cellpadding="1" cellspacing="3">
                        <tr>
                            <td style="width: 36%;">
                                Region<span class="mf">*</span>
                            </td>
                            <td style="width: 4%;">
                                :
                            </td>
                            <td style="width: 70%;">
                                <asp:DropDownList ID="drpRegion" runat="server" OnSelectedIndexChanged="drpRegion_SelectedIndexChanged"
                                    AutoPostBack="true" AppendDataBoundItems="true">
                                    <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvdrpRegion" runat="server" ControlToValidate="drpRegion"
                                    InitialValue="0" Display="None" ValidationGroup="vsSearch" ErrorMessage="Please select Region"></asp:RequiredFieldValidator>
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
                                        <asp:DropDownList ID="drpFirstReportNumber" runat="server" OnSelectedIndexChanged="drpFirstReportNumber_SelectedIndexChanged"
                                            AutoPostBack="true">
                                            <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="drpRegion" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="drpRegion" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                <asp:RequiredFieldValidator ID="rfvdrpFirstReportNumber" runat="server" ControlToValidate="drpFirstReportNumber"
                                    InitialValue="0" Display="None" ValidationGroup="vsSearch" ErrorMessage="Please select First Report Number."></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Investigation ID<span class="mf">*</span>
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:UpdatePanel ID="updInvestigationNumber" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="drpInvestigation" runat="server" OnSelectedIndexChanged="drpInvestigation_SelectedIndexChanged"
                                            AutoPostBack="true">
                                            <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="drpRegion" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="drpRegion" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                <asp:RequiredFieldValidator ID="rfvdrpInvestigation" runat="server" ControlToValidate="drpInvestigation"
                                    InitialValue="0" Display="None" ValidationGroup="vsSearch" ErrorMessage="Please select Investigation ID."></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            </td>
                            <td align="left">
                                <asp:Button ID="btnEditCuase" runat="server" Text="Edit Cause" ToolTip="Edit Cause"
                                    OnClick="btnEditCuase_Click" ValidationGroup="vsSearch" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlEditInvestigation" runat="server" Visible="false">
                    <table cellpadding="3" cellspacing="5" width="72%">
                        <tr>
                            <td style="width: 42%;">
                                Region
                            </td>
                            <td style="width: 4%;">
                                :
                            </td>
                            <td style="width: 54%;">
                                <asp:Label ID="lblRegion" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                First Report Number
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:Label ID="lblFirst_Report_Number" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Investigation ID
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:Label ID="lblInvestigationID" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Sonic Cause Code<span class="mf">*</span>
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:DropDownList runat="server" ID="drpSonic_Cause_Code" SkinID="Default">
                                    <asp:ListItem Text="--SELECT--" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="S1-OVEREXERTION-LIFTLOWER, PUSH/PULL, CARRY" Value="S1-OVEREXERTION-LIFTLOWER, PUSH/PULL, CARRY"></asp:ListItem>
                                    <asp:ListItem Text="S2-FALL SAME LEVEL OR ELEVATED SURFACE" Value="S2-FALL SAME LEVEL OR ELEVATED SURFACE"></asp:ListItem>
                                    <asp:ListItem Text="S3-VEHICLE RELATED - HIGHWAY, PREMISES, GOLF CART" Value="S3-VEHICLE RELATED - HIGHWAY, PREMISES, GOLF CART"></asp:ListItem>
                                    <asp:ListItem Text="S4-STRUCK BY/AGAINST - STATIONARY OBJECT/FALLING MOVING OBJECT"
                                        Value="S4-STRUCK BY/AGAINST - STATIONARY OBJECT/FALLING MOVING OBJECT"></asp:ListItem>
                                    <asp:ListItem Text="S5-OTHER - NOT CLASSIFIED IN ABOVE CODES" Value="S5-OTHER - NOT CLASSIFIED IN ABOVE CODES"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvddlSonic_Cause_Code" runat="server" ControlToValidate="drpSonic_Cause_Code"
                                    InitialValue="0" Display="None" ValidationGroup="vsInvestigation" ErrorMessage="Please select Sonic Cause Code"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center">
                                <asp:Button ID="btnSave" runat="server" Text="Save" Width="90px" OnClick="btnSave_Click"
                                    OnClientClick="javascript:return CheckSave();" />
                                <%--OnClientClick="javascript:" />--%>
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="90px" CausesValidation="false"
                                    OnClick="btnCancel_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
