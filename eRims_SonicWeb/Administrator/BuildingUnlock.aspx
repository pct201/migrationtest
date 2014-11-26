<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="BuildingUnlock.aspx.cs" Inherits="Administrator_BuildingUnlock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields :" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td colspan="4">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="bandHeaderRow" align="left" colspan="4">
                Administrator :: Environmental Building Unlock
            </td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                <table cellpadding="0" cellspacing="0" width="90%" align="center">
                    <tr>
                        <td width="18%" align="left">
                            Building Number&nbsp;<span style="color: Red">*</span>
                        </td>
                        <td width="4%" align="center">
                            :
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="drpBuilding" runat="server" Width="500px" SkinID="dropGen" />
                            <asp:RequiredFieldValidator ID="rfvBuilding" runat="server" ControlToValidate="drpBuilding" 
                                ErrorMessage="Please select building" SetFocusOnError="true" Display="None" ValidationGroup="vsErrorGroup"
                                InitialValue="0" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" align="center">
                            <asp:Button ID="btnUnlock" runat="server" Text="Unlock" OnClick="btnUnlock_Click"
                                CausesValidation="true" ValidationGroup="vsErrorGroup" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
