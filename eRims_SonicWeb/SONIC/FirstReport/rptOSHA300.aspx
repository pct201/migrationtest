<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="rptOSHA300.aspx.cs" Inherits="SONIC_FirstReport_rptOSHA300" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ValidationSummary ID="valSummay" runat="server" ValidationGroup="vsErrorGroup"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following field(s):" />
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td colspan="6">&nbsp;
            </td>
        </tr>
        <tr>
            <td class="ghc" colspan="3">OSHA 300 and 300A
            </td>
        </tr>
        <tr>
            <td colspan="3">&nbsp;
            </td>
        </tr>

        <tr>
            <td width="40%" align="right">
                <b>Year of Data</b> <span id="Span1" style="color: Red;" runat="server">*</span>
            </td>
            <td width="4%" align="center">:
            </td>
            <td align="left" width="56%">
                <asp:DropDownList ID="ddlYear" runat="server" Width="100px" SkinID="dropGen">
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ID="rfvYear" ControlToValidate="ddlYear" InitialValue="0" ErrorMessage="Please select Year of Data"
                    Display="None" ValidationGroup="vsErrorGroup">  </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="3">&nbsp;
            </td>
        </tr>
        <tr>
            <td align="right">
                <b>OSHA Coordinator </b><span id="Span2" style="color: Red;" runat="server">*</span>
            </td>
            <td align="center">:
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlOSHA_Coordinator" runat="server" Width="200px" SkinID="dropGen" OnSelectedIndexChanged="ddlOSHA_Coordinator_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ID="rfvOSHA_Coordinator" ControlToValidate="ddlOSHA_Coordinator" InitialValue="0" ErrorMessage="Please select OSHA Coordinator"
                    Display="None" ValidationGroup="vsErrorGroup">  </asp:RequiredFieldValidator>
            </td>

        </tr>
        <tr>
            <td colspan="3">&nbsp;
            </td>
        </tr>
        <tr>
            <td align="right">
                <b>Location </b><span id="Span3" style="color: Red;" runat="server">*</span>
            </td>
            <td align="center">:
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlLocation" runat="server" Width="200px" SkinID="dropGen">
                    <asp:ListItem Selected="True" Text="-- Select --" Value="0"></asp:ListItem>
                </asp:DropDownList>
                 <asp:RequiredFieldValidator runat="server" ID="rfvLocation" ControlToValidate="ddlLocation" InitialValue="0" ErrorMessage="Please select Location"
                    Display="None" ValidationGroup="vsErrorGroup">  </asp:RequiredFieldValidator>
            </td>

        </tr>

        <tr>
            <td colspan="6">&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="6" align="center">
                <asp:Button ID="btnGenerate" runat="server" Text="Generate Report" ValidationGroup="vsErrorGroup" OnClick="btnGenerate_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="6">&nbsp;
            </td>
        </tr>
    </table>

</asp:Content>

