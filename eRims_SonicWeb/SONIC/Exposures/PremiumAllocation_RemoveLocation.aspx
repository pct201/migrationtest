<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="PremiumAllocation_RemoveLocation.aspx.cs" Inherits="SONIC_Exposures_PremiumAllocation_RemoveLocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Date_Validation.js"></script>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" CssClass="errormessage" ValidationGroup="vsError"
            BorderColor="DimGray" BorderWidth="1" HeaderText="Verify the following fields:"
            ShowMessageBox="true" ShowSummary="false"></asp:ValidationSummary>
    </div>
    <table cellpadding="3" cellspacing="1" width="100%">
        <tr>
            <td width="100%" colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left" class="ghc" colspan="2">
                Premium Allocation Remove Location
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 3px;" colspan="2">
            </td>
        </tr>
        <tr runat="server" id="trCriteria">
            <td>
                <asp:Panel ID="pnlEdit" runat="server">
                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                        <tr>
                            <td colspan="3">
                                <asp:Label ID="lblError" runat="server" Visible="False" Font-Bold="True" CssClass="error"></asp:Label>
                            </td>
                        </tr>
                        <tr valign="top">
                            <td align="right" valign="top" width="34%">
                                Year <span style="color: Red;">*</span>
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="62%">
                                <asp:DropDownList ID="ddlYear" runat="server" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged"
                                    AutoPostBack="true" SkinID="dropGen" Width="245px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="revddlYear" runat="server" Display="None" ErrorMessage="Please Select Year."
                                    ControlToValidate="ddlYear" InitialValue="0" SetFocusOnError="true" ValidationGroup="vsError"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top" width="28%">
                                Location <span style="color: Red;">*</span>
                            </td>
                            <td width="4%" align="center" valign="top">
                                :
                            </td>
                            <td align="left" width="68%">
                                <asp:DropDownList ID="drpLocation" runat="server" Style="width: 245px;">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="revdrpLocation" runat="server" Display="None" ErrorMessage="Please Select Location."
                                    ControlToValidate="drpLocation" InitialValue="0" SetFocusOnError="true" ValidationGroup="vsError"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top" width="28%">
                               Close Month&nbsp;<span style="color: Red">*</span>
                            </td>
                            <td width="4%" align="center" valign="top">
                                :
                            </td>
                            <td align="left" width="68%">
                                <asp:DropDownList ID="ddlMonth" runat="server" Width="245px" SkinID="dropGen">
                                    <asp:ListItem Text="--Select--" Value="0" Selected="True" />
                                    <asp:ListItem Text="January" Value="1" />
                                    <asp:ListItem Text="February" Value="2" />
                                    <asp:ListItem Text="March" Value="3" />
                                    <asp:ListItem Text="April" Value="4" />
                                    <asp:ListItem Text="May" Value="5" />
                                    <asp:ListItem Text="June" Value="6" />
                                    <asp:ListItem Text="July" Value="7" />
                                    <asp:ListItem Text="August" Value="8" />
                                    <asp:ListItem Text="September" Value="9" />
                                    <asp:ListItem Text="October" Value="10" />
                                    <asp:ListItem Text="November" Value="11" />
                                    <asp:ListItem Text="December" Value="12" />
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="revddlMonth" runat="server" Display="None" ErrorMessage="Please Select Month."
                                    ControlToValidate="ddlMonth" SetFocusOnError="true" InitialValue="0" ValidationGroup="vsError"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center">
                                <asp:Button runat="server" ID="btnRemove" Text="Remove" OnClick="btnRemove_Click"
                                    CausesValidation="true" ValidationGroup="vsError" />
                                &nbsp;&nbsp;
                                <asp:Button ID="btnClearCriteria" runat="server" Text="Clear Criteria" ToolTip="Clear All"
                                    OnClick="btnClearCriteria_Click" CausesValidation="false" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
