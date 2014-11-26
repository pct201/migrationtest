<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Worksheet_Template_Export.aspx.cs" Inherits="Reports_Worksheet_Template_Export" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="ghc" colspan="2">
                <b> Worksheet Template Export </b>
            </td>
        </tr>
        <tr>
            <td style="height: 50px;" colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td width="10%">
                &nbsp;
            </td>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td width="18%" align="right">
                            Worksheet Template Export
                        </td>
                        <td width="4%" align="center">
                            :
                        </td>
                        <td align="left">
                            <asp:Button ID="btnExport" runat="server" Text="Export" OnClick="btnExport_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 50px;" colspan="2">
                &nbsp;
            </td>
        </tr>
    </table>

</asp:Content>

