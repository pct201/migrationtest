<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="RCRA_Training_Certificate.aspx.cs" Inherits="SONIC_Exposures_RCRA_Training_Certificate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  
    <script type="text/javascript" src="<%=AppConfig.SiteURL %>JavaScript/Validator.js" language="javascript"></script>

    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Please verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td width="100%" class="Spacer" style="height: 10px;"></td>
        </tr>
        <tr class="PropertyInfoBG">
            <td align="left" style="padding-left: 20px;">Safety Training Certificate
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 20px;"></td>
        </tr>
        <tr runat="server" id="trSearch">
            <td align="center">
                <table cellpadding="3" cellspacing="2" border="0" width="80%">
                    <tr>
                        <td align="left" valign="top" width="15%">RLCM
                        </td>
                        <td align="center" valign="top" width="2%">:
                        </td>
                        <td align="left" valign="top" width="33%">
                            <asp:DropDownList runat="server" ID="ddlRLCM" Width="180" OnSelectedIndexChanged="ddlRLCM_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </td>
                        <td align="left" valign="top" colspan="3">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" width="15%" class="lc">Region
                        </td>
                        <td align="center" valign="top" width="2%">:
                        </td>
                        <td align="left" valign="top" width="33%">
                            <asp:DropDownList runat="server" ID="ddlRegion" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </td>
                        <td align="left" valign="top" colspan="3">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" class="lc">Market
                        </td>
                        <td align="center" valign="top">:
                        </td>
                        <td align="left" valign="top">
                            <asp:DropDownList runat="server" ID="ddlMarket" OnSelectedIndexChanged="ddlMarket_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </td>
                        <td align="left" valign="top" colspan="3">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" class="lc">Location
                        </td>
                        <td align="center" valign="top">:
                        </td>
                        <td align="left" valign="top">
                            <asp:DropDownList runat="server" ID="ddlLocation" OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </td>
                        <td align="left" valign="top" colspan="3">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" class="lc">Associate
                        </td>
                        <td align="center" valign="top">:
                        </td>
                        <td align="left" valign="top">
                            <asp:DropDownList runat="server" ID="ddlAssociate"></asp:DropDownList>
                        </td>
                        <td align="left" valign="top" colspan="3">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" class="lc">Year <span id="spanYear" style="color: Red;" runat="server">*</span>
                        </td>
                        <td align="center" valign="top">:
                        </td>
                        <td align="left" valign="top">
                            <asp:TextBox ID="txtYear" runat="server" Width="200" MaxLength="4" SkinID="txtYearWithRange"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvYear" Display="none" runat="server" ControlToValidate="txtYear" ErrorMessage="Please Enter Year." Text="*" ValidationGroup="vsErrorGroup"> </asp:RequiredFieldValidator>
                        </td>
                        <td align="left" valign="top" class="lc">Quarter <span id="spanQuarter" style="color: Red;" runat="server">*</span>
                        </td>
                        <td align="center" valign="top">:
                        </td>
                        <td align="left" valign="top" colspan="4">
                            <asp:TextBox ID="txtQuarter" runat="server" onKeyPress="javascript:return FormatInteger(event);" MaxLength="1" autocomplete="off"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvQuarter" Display="none" runat="server" ControlToValidate="txtQuarter" ErrorMessage="Please Enter Quarter." Text="*" ValidationGroup="vsErrorGroup" > </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revQuarter" runat="server" ControlToValidate="txtQuarter" Display="none" SetFocusOnError="true" ErrorMessage="Quarter is Invalid." ValidationExpression="[1-4]{1}" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" align="center">
                            <asp:Button runat="server" ID="btnShowReport" Text="Show Report" CausesValidation="true" ValidationGroup="vsErrorGroup" OnClick="btnShowReport_Click" />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnClearCriteria" runat="server" Text="Clear Criteria" ToolTip="Clear All" CausesValidation="false" OnClick="btnClearCriteria_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

