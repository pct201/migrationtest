<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Event_Note.aspx.cs" Inherits="Event_Event_Note" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Event Note</title>
</head>
<body>
    <form id="form1" runat="server">
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td width="5px" class="Spacer">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="">
                <div class="bandHeaderRow">
                    <asp:Label runat="server" ID="lblNoteType"></asp:Label></div>
                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                    <tr>
                        <td style="height: 5px" colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="18%" valign="top">
                            Event Number
                        </td>
                        <td align="center" width="4%" valign="top">
                            :
                        </td>
                        <td align="left" width="78%" valign="top">
                            <asp:Label runat="server" ID="lblEventNo"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="18%" valign="top">
                            Date
                        </td>
                        <td align="center" width="4%" valign="top">
                            :
                        </td>
                        <td align="left" width="78%" valign="top">
                            <asp:Label runat="server" ID="lblNoteDate"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="18%" valign="top">
                            Note
                        </td>
                        <td align="center" width="4%" valign="top">
                            :
                        </td>
                        <td align="left" width="78%" valign="top">
                            <asp:Label runat="server" ID="lblNote" Style="word-wrap: normal; word-break: break-all;" ></asp:Label>
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
      
    </table>
    </form>
</body>
</html>
