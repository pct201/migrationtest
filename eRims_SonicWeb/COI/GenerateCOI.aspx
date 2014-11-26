<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="GenerateCOI.aspx.cs" Inherits="COI_GenerateCOI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


<table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td style="height:25px;" class="Spacer">
        </td>
    </tr>
    <tr>    
        <td width="100%" height="50px" align="center">
                <asp:Label SkinID="messageOrNote" EnableViewState="false" ID="lblMessage" runat="Server"></asp:Label><br /><br />
                <asp:LinkButton ID="lnkPrint" Text="Print COI" runat="server" OnClick="lnkPrint_Click"/>            
                <asp:Literal ID="ltrPrintCOI" runat="server" Visible="false"></asp:Literal>
        </td>
    </tr>
    <tr>
        <td style="height:50px;" class="Spacer">
        </td>
    </tr>
</table>
</asp:Content>
