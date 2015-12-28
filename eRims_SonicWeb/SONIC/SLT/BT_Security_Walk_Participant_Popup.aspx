<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BT_Security_Walk_Participant_Popup.aspx.cs" Inherits="SONIC_SLT_BT_Security_Walk_Participant_Popup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BT Security Walk Members</title>
    <script type="text/javascript">
        function Save_Record()
        {            
            window.opener.AskfForLogoff = false;
            window.opener.document.getElementById('ctl00_ContentPlaceHolder1_btnReload_BTParticipant').click();
            self.close();            
        }
    </script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="pnl1" runat="server">
        <table width="100%" cellpadding="2" cellspacing="2">
            <tr>
                <td class="ghc">BT Security Walk Members</td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gv_MeetingAttendees" runat="server" PageSize="10" Width="100%"
                        EnableViewState="true" AllowPaging="true" OnRowDataBound="gv_MeetingAttendees_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="First Name" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle Width="15%" VerticalAlign="Middle" HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFirst_Name" runat="server" Text='<%#Eval("First_Name") %>' />
                                    <asp:HiddenField ID="hdnPK_SLT_Members" runat="server" Value='<%#Eval("PK_SLT_Members") %>' />
                                    <%--<asp:HiddenField ID="hdnPK_SLT_Meeting_Attendees" runat="server" Value='<%#Eval("PK_SLT_Meeting_Attendees") %>' />--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Last Name" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle Width="15%" VerticalAlign="Middle" HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:Label ID="lblLast_Name" runat="server" Text='<%#Eval("Last_Name") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SLT Role" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle Width="15%" VerticalAlign="Middle" HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSLT_Role" runat="server" Text='<%#Eval("SLT_Role") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Participated" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle Width="15%" VerticalAlign="Middle" />
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnParticipated" runat="server" Value='<%# Convert.ToBoolean(Eval("Participated")) %>' />
                                    <asp:RadioButtonList ID="rdoParticipated" runat="server" SkinID="YesNoType">
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table cellpadding="4" cellspacing="0" width="100%">
                                <tr>
                                    <td width="100%" align="center" style="border: 1px solid #cccccc;">
                                        <asp:Label ID="lblEmptyHeaderGridMessage" runat="server" Text="No Record Found"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="6" align="center" valign="top">&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="6" align="center" valign="top">
                    <asp:Button ID="btnAttendeesSave" runat="server" Text="Save" CausesValidation="true"
                        ValidationGroup="vsErrorAttendees" OnClick="btnAttendeesSave_Click" />
                </td>
            </tr>
        </table>
            </asp:Panel>
        <asp:Panel ID="pnl1View" runat="server">
                    <table width="100%" cellpadding="2" cellspacing="2">
            <tr>
                <td class="ghc">BT Security Walk Members</td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gv_MeetingAttendeesView" runat="server" PageSize="10" Width="100%"
                        EnableViewState="true" AllowPaging="true">
                        <Columns>
                            <asp:TemplateField HeaderText="First Name">
                                <ItemStyle Width="15%" VerticalAlign="Middle" HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFirst_Name" runat="server" Text='<%#Eval("First_Name") %>' />
                                    <asp:HiddenField ID="hdnPK_SLT_Members" runat="server" Value='<%#Eval("PK_SLT_Members") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Last Name">
                                <ItemStyle Width="15%" VerticalAlign="Middle" HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:Label ID="lblLast_Name" runat="server" Text='<%#Eval("Last_Name") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SLT Role">
                                <ItemStyle Width="15%" VerticalAlign="Middle" HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSLT_Role" runat="server" Text='<%#Eval("SLT_Role") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Participated">
                                <ItemStyle Width="15%" VerticalAlign="Middle" />
                                <ItemTemplate>
                                    <%# clsGeneral.FormatYesNoToDisplayForView(Eval("Participated")) %>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table cellpadding="4" cellspacing="0" width="100%">
                                <tr>
                                    <td width="100%" align="center" style="border: 1px solid #cccccc;">
                                        <asp:Label ID="lblEmptyHeaderGridMessage" runat="server" Text="No Record Found"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="6" align="center" valign="top">&nbsp;
                </td>
            </tr>
        </table>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
