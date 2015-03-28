<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Event_Note.aspx.cs" Inherits="Event_Event_Note" %>

<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>

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
                <div id="dvView" runat="server" width="794px" style="display: none">
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
                    </div>

                <div id="dvNotesList" runat="server" width="794px" style="display: none">
                <div class="bandHeaderRow">
                    Sonic Notes</div>
                <table cellpadding="1" cellspacing="1" width="100%">
                    <tr>
                        <td width="100%">
                            <div style="width: 785px; height: 370px; overflow-x: hidden; overflow-y: scroll;">
                                <asp:Repeater ID="rptNotes" runat="server">
                                    <ItemTemplate>
                                        <table cellpadding="1" cellspacing="1" width="100%">
                                            <tr>
                                                <td align="left" valign="top">
                                                    <table cellpadding="3" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td width="18%" align="left" valign="top">
                                                                Date of Note
                                                            </td>
                                                            <td width="4%" align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <%#clsGeneral.FormatDBNullDateToDisplay(Eval("Note_Date"))%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                Notes
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top" colspan="4">
                                                                <uc:ctrlMultiLineTextBox ID="lblNoteText" runat="server" Text='<%# Eval("Note") %>'
                                                                    ControlType="Label" Width="540" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr style="height: 30px">
                                                <td colspan="2" style="vertical-align: middle;">
                                                    <hr size="1" color="Black" style="width: 758px;" />
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnPrintSelectedNotes" runat="server" Text=" Print "  OnClick="btnPrintSelectedNotes_Click"
                                CausesValidation="false" />&nbsp;
                           <%-- <asp:Button ID="btnCancel" runat="server" Text=" Return "  OnClick="btnRevert_Click"
                                CausesValidation="false" />&nbsp; --%>
                          <%--  <asp:Button ID="btnMail" runat="server" Text=" Mail " OnClientClick="return OpenMailPopUp();"
                                CausesValidation="false" />--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </div>

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
