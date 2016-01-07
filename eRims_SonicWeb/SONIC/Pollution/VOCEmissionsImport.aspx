<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="VOCEmissionsImport.aspx.cs" Inherits="SONIC_Exposures_VOCEmissionsImport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>

    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td width="100%" class="ghc" colspan="2">VOC Emissions .CSV Import
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
        <tr>
            <td>
                <table cellspacing="0" cellpadding="0" width="100%">
                    <tr>
                        <td width="10%"></td>
                        <td align="left" width="10%">Location&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                        </td>
                        <td width="4%" align="center">:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlLocation" width="175px" runat="server" skinid="dropGen"> </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td width="10%"></td>
                        <td align="left" width="10%">Month&nbsp;<span id="Span2" style="color: Red;" runat="server">*</span>
                        </td>
                        <td width="4%" align="center">:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMonth" width="175px" runat="server" SkinID="dropGen"> </asp:DropDownList>
                             <asp:RequiredFieldValidator ControlToValidate="ddlMonth" ID="rfvMonth" Display="None"
                                ValidationGroup="vsErrorGroup" ErrorMessage="Please select Month" InitialValue="0" runat="server">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td width="10%"></td>
                        <td align="left" width="10%">Year&nbsp;<span id="Span3" style="color: Red;" runat="server">*</span>
                        </td>
                        <td width="4%" align="center">:
                        </td>
                        <td>
                            <asp:dropdownlist id="ddlYear" width="175px" runat="server" skinid="dropGen"> </asp:dropdownlist>
                             <asp:RequiredFieldValidator ControlToValidate="ddlYear" ID="rfvYear" Display="None"
                                ValidationGroup="vsErrorGroup" ErrorMessage="Please select Year" InitialValue="0" runat="server"> </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td width="10%"></td>
                        <td width="10%" align="left">File to Import&nbsp;<span id="Span4" style="color: Red;" runat="server">*</span>
                        </td>
                        <td width="4%" align="center">:
                        </td>
                        <td>
                            <asp:fileupload id="fpFile" runat="server" />
                               <asp:RequiredFieldValidator ControlToValidate="fpFile" ID="rfvFPFile" Display="None"
                                ValidationGroup="vsErrorGroup" ErrorMessage="Please select File to Import" runat="server"> </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="padding-left:250px;">
                <asp:Button ID="btnSubmit" runat="server" CausesValidation="true" ValidationGroup="vsErrorGroup" Text="Submit" OnClick="btnSubmit_Click"/>&nbsp;&nbsp;
                 <asp:Button ID="btnCancel" runat="server"  Text="Cancel" OnClick="btnCancel_Click"/>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>

