<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AM_Attach_Section.ascx.cs" Inherits="Controls_Attachment_AssetProtection_AM_Attach_Section" %>
<asp:UpdatePanel ID="updatepnl1" runat="server" UpdateMode="Always">
    <ContentTemplate>
        <table cellpadding="3" cellspacing="1" width="100%">
            <tr>
                <td width="18%" align="left">
                    <asp:Label ID="lbl" runat="server">Attachment Name</asp:Label>
                </td>
                <td width="4%" align="center">:
                </td>
                <td align="left" width="27%">
                    <asp:TextBox ID="txtAttachmentNameAdd" runat="server" Width="150px">
                    </asp:TextBox>
                </td>
                 <td width="18%" align="left">
                    <asp:Label ID="Label1" runat="server">Attachment Type&nbsp;<span style="color:red;">*</span></asp:Label>
                </td>
                <td width="4%" align="center">:
                </td>
                <td align="left" width="27%">
                    <asp:RadioButtonList runat="server" ID="rblAttachmentType">
                        <asp:ListItem Text="Find It" Value="Find It" />
                         <asp:ListItem Text="Fix It" Value="Fix It" />
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td align="left" width="18%">Select File
                </td>
                <td align="center" width="4%">:
                </td>
                <td align="Right" width="27%">
                    <asp:FileUpload ID="fpFile" runat="server" Width="250px" />
                    <asp:TextBox ID="txtFilePath" runat="server" Width="450px" ReadOnly="true" Visible="false" />
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>

