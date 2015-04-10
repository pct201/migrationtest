<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EPM_Attach_Section.ascx.cs" Inherits="Controls_Attachment_Construction_EPM_Attach_Section" %>
<asp:UpdatePanel ID="updatepnl1" runat="server" UpdateMode="Always">
    <ContentTemplate>
        <table cellpadding="3" cellspacing="1" width="100%">
            <tr>
                <td width="18%" align="left">
                    Folder
                </td>
                <td width="4%" align="center">
                    :
                </td>
                <td align="left">
                    <asp:DropDownList ID="drpFolder" runat="server" Width="500px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="left">
                    File to Attach
                </td>
                <td align="center">
                    :
                </td>
                <td align="left">
                    <asp:FileUpload ID="fpFile" runat="server" Width="500px" />
                    <asp:TextBox ID="txtFilePath" runat="server" Width="450px" ReadOnly="true" Visible="false" />
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>