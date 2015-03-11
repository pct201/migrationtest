<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Popup_BuildingImprovementsNotes.aspx.cs" Inherits="SONIC_Exposures_Popup_BuildingImprovementsNotes" %>

<!DOCTYPE html>
<%@ Register Src="~/Controls/NotesWithSpellCheck/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td width="5px" class="Spacer">&nbsp;
                    </td>
                    <td class="dvContainer">
                        <div id="dvEdit" runat="server">
                            <div class="bandHeaderRow">
                                Project Notes
                            </div>
                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                <tr>
                                    <td align="left" width="20%" valign="top">Date of Note&nbsp;
                                    </td>
                                    <td align="center" width="4%" valign="top">:
                                    </td>
                                    <td align="left" width="24%" valign="top">
                                        <asp:TextBox ID="txtNote_Date" runat="server" Width="170px" SkinID="txtDate" MaxLength="10" Enabled="false"></asp:TextBox>
                                         <img alt="Date of Note" src="../../Images/iconPicDate.gif" align="middle" id="img1" />                                        
                                    </td>
                                    <td align="left" width="20%" valign="top">Date Last Modified&nbsp;
                                    </td>
                                    <td align="center" width="4%" valign="top">:
                                    </td>
                                    <td align="left" width="24%" valign="top">
                                        <asp:TextBox ID="txtLast_Modified_date" runat="server" Width="170px" SkinID="txtDate" MaxLength="10" Enabled="false"></asp:TextBox>
                                        <img alt="Date Last Modified" src="../../Images/iconPicDate.gif" align="middle" id="img2" />                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="18%" valign="top">Notes&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                    </td>
                                    <td align="center" width="4%" valign="top">:
                                    </td>
                                    <td align="left" width="28%" valign="top" colspan="4">
                                        <uc:ctrlMultiLineTextBox ID="txtNotes" ControlType="TextBox" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="dvView" runat="server" style="display: none">
                            <div class="bandHeaderRow">
                                Project Notes
                            </div>
                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                <tr>
                                    <td align="left" width="20%" valign="top">Date of Note
                                    </td>
                                    <td align="center" width="4%" valign="top">:
                                    </td>
                                    <td align="left" width="24%" valign="top">
                                        <asp:Label ID="lblNote_Date" runat="server"></asp:Label>
                                    </td>
                                    <td align="left" width="20%" valign="top">Date Last Modified
                                    </td>
                                    <td align="center" width="4%" valign="top">:
                                    </td>
                                    <td align="left" width="24%" valign="top">
                                        <asp:Label ID="lblLast_Modified_Date" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="20%" valign="top">Notes
                                    </td>
                                    <td align="center" width="4%" valign="top">:
                                    </td>
                                    <td align="left" width="24%" valign="top">
                                        <uc:ctrlMultiLineTextBox ID="lblNotes" ControlType="Label" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td width="5px" class="Spacer">&nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnSave" runat="server" Text="Save" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClientClick="javascript:self.close();" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
