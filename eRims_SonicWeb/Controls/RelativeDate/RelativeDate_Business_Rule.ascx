<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RelativeDate_Business_Rule.ascx.cs"
    Inherits="Controls_RelativeDate_RelativeDate_Business_Rule" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:ValidationSummary ID="valSummayRelativeDate" runat="server" ValidationGroup="vsErrorGroupRelativeDate"
    ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following field(s):" />
&nbsp;<asp:ImageButton ID="lnkRelativeDate" runat="server" ToolTip="Select Relative Date"
    ImageAlign="AbsMiddle" ImageUrl="~/Images/DateRelative.bmp" OnClick="lnkRelativeDate_Click" />
&nbsp;
<asp:ImageButton ID="lbtn_Cancel" runat="server" ImageUrl="~/Images/DateRelative - Cancel.bmp"
    ImageAlign="AbsMiddle" ToolTip="Remove Relative Date" Visible="false" OnClientClick="return confirm('Are you sure you want to remove Relative date criteria ?');"
    OnClick="lbtn_Cancel_Click" />
<asp:HiddenField ID="hnd1" runat="server" />
<cc1:ModalPopupExtender ID="mpeRelativeDate" runat="server" TargetControlID="hnd1"
    BackgroundCssClass="modalBackground" PopupControlID="pnlSaveReport" CancelControlID="btnCancel">
</cc1:ModalPopupExtender>
<asp:Panel ID="pnlSaveReport" runat="server" Style="display: none" Width="375px" Height="300px"
    BackColor="#ffffff" BorderStyle="Solid" BorderWidth="1">
    <table cellpadding="3" cellspacing="1" width="100%">
        <tr>
            <td class="bandHeaderRow" align="left">
                Relative Date
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="4" cellspacing="4">
                    <tr>
                        <td align="left">
                            <asp:RadioButtonList ID="dblRelativeDates" runat="server" RepeatDirection="Horizontal"
                                CellPadding="4" CellSpacing="6" RepeatColumns="2">
                                <asp:ListItem Selected="True" Text="First Day of Previous Month" Value="FirstDayPrevMonth"></asp:ListItem>
                                <asp:ListItem Text="Last Day of Previous Month" Value="LastDayPrevMonth"></asp:ListItem>
                                <asp:ListItem Text="First Day of Current Month" Value="FirstDayCurrMonth"></asp:ListItem>
                                <asp:ListItem Text="Last Day of Current Mohth" Value="LastDayCurrMonth"></asp:ListItem>
                                <asp:ListItem Text="First Day of Previous Year" Value="FirstDayPrevYear"></asp:ListItem>
                                <asp:ListItem Text="Last Day of Previous Year" Value="LastDayPrevYear"></asp:ListItem>
                                <asp:ListItem Text="First Day of Current Year" Value="FirstDayCurrYear"></asp:ListItem>
                                <asp:ListItem Text="Last Day of Current Year" Value="LastDayCurrYear"></asp:ListItem>
                                <asp:ListItem Text="Current Date" Value="CurrentDate"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btnSave" runat="server" Text="Select" OnClick="btnSave_Click" CausesValidation="true"
                    ToolTip="Select" ValidationGroup="vsErrorGroupRelativeDate" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" ToolTip="Cancel" />
                <input type="hidden" id="hdntxtID" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>

    <script type="text/javascript">
        function SetDateValue(obj, valueDate) {
            document.getElementById(obj).value = valueDate;
            /////    SetEnable();
        }
        function SetEnable() {
            document.getElementById('ctl00_ContentPlaceHolder1_btnSetRelDate').click();
        }

        function ClearControls() {
            document.getElementById('<%=dblRelativeDates.ClientID%>').selectedIndex = 0;

        }
    </script>

</asp:Panel>
