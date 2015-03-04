<%@ Control Language="C#" AutoEventWireup="true" CodeFile="APNotes.ascx.cs" Inherits="Controls_SonicClaimNotes_APNotes" %>
<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<script type="text/javascript">
    function CheckSelectedSonicNotes(buttonType) {
        var ctrls = document.getElementsByTagName('input');
        var i, chkID;
        var cnt = 0;
        chkID = "chkSelectSonicNotes";
        for (i = 0; i < ctrls.length; i++) {
            if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf(chkID) > 0) {
                if (ctrls[i].checked)
                    cnt++;
            }
        }

        if (cnt == 0) {
            if (buttonType == "View")
                alert("Please select Note(s) to View");
            else
                alert("Please select Note(s) to Print");

            return false;
        }
        else {
            return true;
        }
    }
</script>
<asp:UpdatePanel runat="server" ID="updSonicNotes" UpdateMode="Always">
    <ContentTemplate>
        <asp:Panel ID="pnlSonicNotes" runat="server">
            <div class="bandHeaderRow">
                Sonic Notes</div>
            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                <tr>
                    <td colspan="3">
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td width="45%">
                                </td>
                                <td valign="top" align="right">
                                    <uc:ctrlPaging ID="ctrlPageSonicNotes" runat="server" />
                                </td>
                            </tr>
                        </table>
                        </br>
                    </td>
                </tr>
                <tr>
                    <td valign="top" style="width: 15%">
                        Sonic Notes Grid<br />
                        <asp:LinkButton ID="btnNotesAdd" runat="server" ValidationGroup="vsError" Text="--Add--"
                            OnClick="btnNotesAdd_Click"></asp:LinkButton>
                    </td>
                    <td align="center" valign="top" style="width: 3%">
                        :
                    </td>
                    <td style="margin-left: 40px" style="width: 650px" align="left">
                        <asp:GridView ID="gvNotes" runat="server" AutoGenerateColumns="false" Width="100%"
                            OnRowCommand="gvNotes_RowCommand">
                            <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                            <EmptyDataTemplate>
                                <asp:Label ID="lblEmptyEmergencyMessage" runat="server" Text="No Record Found"></asp:Label>
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-Width="12%">
                                    <HeaderTemplate>
                                        <input type="checkbox" id="chkMultiSelectSonicNotes" onclick="SelectDeselectAllSonicNotes(this.checked);" />Select
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelectSonicNotes" runat="server" onclick="SelectDeselectNoteHeader();" />
                                        <input type="hidden" id="hdnPK" runat="server" value='<%#Eval("PK_AP_Notes") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                    HeaderText="Note Date">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtNote_Date" runat="server" Text='<%# string.Format("{0:MM/dd/yyyy}", Eval("Note_Date")) %>'
                                            CommandName="EditRecord" CommandArgument='<%#Eval("PK_AP_Notes") %>' Width="80px"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                    HeaderText="User">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtUser_Name" runat="server" Text='<%# Eval("User_Name") %>'
                                            CommandName="EditRecord" CommandArgument='<%#Eval("PK_AP_Notes") %>' Width="100px"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                    HeaderText="Notes">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtNotes" runat="server" Text='<%# Eval("Note") %>' CommandName="EditRecord"
                                            CommandArgument='<%#Eval("PK_AP_Notes") %>' Width="310px" CssClass="TextClip"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                    HeaderText="Remove">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtDelete" runat="server" Text="Remove" CommandName="Remove"
                                            CommandArgument='<%#Eval("PK_AP_Notes") %>' OnClientClick="javascript:return confirm('Are you sure you want delete selected record?');"
                                            Width="80px"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:Button ID="btnView" runat="server" Text=" View " OnClick="btnView_Click" OnClientClick="return CheckSelectedSonicNotes('View');" />&nbsp;&nbsp;
                        <asp:Button ID="btnPrint" runat="server" Text=" Print " OnClick="btnPrint_Click"
                            OnClientClick="return CheckSelectedSonicNotes('Print');" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnPrint" />
    </Triggers>
</asp:UpdatePanel>
