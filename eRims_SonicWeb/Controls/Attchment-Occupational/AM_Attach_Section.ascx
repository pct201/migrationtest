<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AM_Attach_Section.ascx.cs"
    Inherits="Controls_Attachment_AssetProtection_AM_Attach_Section" %>
<asp:UpdatePanel ID="updatepnl1" runat="server" UpdateMode="Always">
    <ContentTemplate>
        <table cellpadding="3" cellspacing="1" width="100%">
            <tr>
                <td width="18%" align="left">
                    Attachment Name
                </td>
                <td width="4%" align="center">
                    :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtAttachmentNameAdd" runat="server" Width="150px">
                     </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
                    Select File
                </td>
                <td align="center">
                    :
                </td>
                <td align="left">
                    <asp:FileUpload ID="fpFile" runat="server" Width="250px" />
                    <asp:TextBox ID="txtFilePath" runat="server" Width="450px" ReadOnly="true" Visible="false" />
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
