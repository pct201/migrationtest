<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdjusterNotes.ascx.cs"
    Inherits="Controls_SonicClaimNotes_AdjusterNotes" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<script type="text/javascript">

    function CheckSelectedAdjNotes(buttonType, bFromGrid) {
        var ctrls = document.getElementsByTagName('input');
        var i, chkID;
        var cnt = 0;
        chkID = (bFromGrid == true ? "chkAdjSelect" : "chkRptNotesSelect");
        for (i = 0; i < ctrls.length; i++) {
            if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf(chkID) > 0) {
                if (ctrls[i].checked)
                    cnt++;
            }
        }

        if (cnt == 0) {
            if (buttonType == "View")
                alert("Please select Note(s) to View");
            else if (buttonType == "Mail")
                alert("Please select Note(s) to Mail");
            else
                alert("Please select Note(s) to Print");

            return false;
        }
        else {
            return true;
        }
    }

    function SelectDeselectAllAdjNotes(bChecked, bFromGrid) {
        var ctrls = document.getElementsByTagName('input');
        var i, chkID;
        var cnt = 0;
        chkID = (bFromGrid == true ? "chkAdjSelect" : "chkRptNotesSelect");
        for (i = 0; i < ctrls.length; i++) {
            if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf(chkID) > 0) {
                ctrls[i].checked = bChecked;
            }
        }
    }

    function SelectDeselectHeader(bFromGrid) {
        var ctrls = document.getElementsByTagName('input');
        var i, chkID;
        var cnt = 0;
        chkID = (bFromGrid == true ? "chkAdjSelect" : "chkRptNotesSelect");
        for (i = 0; i < ctrls.length; i++) {
            if (ctrls[i].type == "checkbox" && ctrls[i].id.indexOf(chkID) > 0) {
                if (ctrls[i].checked)
                    cnt++;
            }
        }

        var rowCnt = 0;
        if (bFromGrid)
            rowCnt = document.getElementById('<%=gvNotesList.ClientID %>').rows.length - 1;
        else
            rowCnt = document.getElementById('<%=hdnRptRows.ClientID %>').value;

        var headerChkID = bFromGrid ? 'chkMultiSelectAdjNotes' : 'chkRptMultiSelectAdjNotes';

        if (cnt == rowCnt)
            document.getElementById(headerChkID).checked = true;
        else
            document.getElementById(headerChkID).checked = false;
    }

    function OpenMailPopUp(tab, strPKs, FK_Table_Name, FK_Claim) {
        var oWnd = window.open('<%=AppConfig.SiteURL%>SONIC/Exposures/Asset_Protection_SendMail.aspx?Tab=' + tab +'&PK_Fields=' + strPKs + '&Table_Name=' + FK_Table_Name+ '&Claim_ID=' + FK_Claim, "Erims", "location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=600,height=300");
        oWnd.moveTo(450, 300);
        return false;
    }

</script>
<asp:UpdatePanel runat="Server" ID="updNotes" UpdateMode="Always">
    <ContentTemplate>
        <asp:Panel ID="pnlGrid" runat="server" Width="100%">
            Click For Detail
            <br />
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td width="45%">
                    </td>
                    <td valign="top" align="right">
                        <uc:ctrlPaging ID="ctrlPageNotes" runat="server" OnGetPage="GetPage" />
                    </td>
                </tr>
            </table>
            </br>
            <div id="divNotesList" style="width: 765px; height: 190px; overflow-x: hidden; overflow-y: scroll;
                border: solid 1px #000000;">
                <asp:GridView ID="gvNotesList" runat="server" AutoGenerateColumns="false" Width="100%" AllowSorting="true" OnSorting="gvNotesList_Sorting"
                    OnRowCommand="gvNotesList_RowCommand" OnRowDataBound="gvNotesList_RowDataBound">
                    <HeaderStyle HorizontalAlign="Center" />
                    <Columns>
                        <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-Width="8%" HeaderStyle-HorizontalAlign="Left">
                            <HeaderTemplate>
                                <input type="checkbox" id="chkMultiSelectAdjNotes" onclick="SelectDeselectAllAdjNotes(this.checked,true);" />Select
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkAdjSelect" runat="server" onclick="SelectDeselectHeader(true);" />
                                <input type="hidden" id="hdnID" runat="server" value='<%#Eval("PK_Adjustor_Notes_RO_ID")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date" SortExpression="Data_Entry_Date">
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="lnkData_Entry_Date" CommandName="View" CommandArgument='<%#Eval("PK_Adjustor_Notes_RO_ID")%>'
                                    Text='<%#Eval("Data_Entry_Date")%>'>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Data Source" DataField="Data_Source" ItemStyle-Width="70px"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField HeaderText="Note Type" DataField="Activity_Type" ItemStyle-Width="70px"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField HeaderText="Note Text" DataField="Small_Note_Text" ItemStyle-HorizontalAlign="Left" />
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
            </div>
            <br />
            <table cellpadding="4" cellspacing="0" width="100%">
                <tr>
                    <td width="100%" align="center">
                        <asp:Button ID="btnView" runat="server" Text=" View " OnClick="btnView_Click" OnClientClick="return CheckSelectedAdjNotes('View',true);" />&nbsp;&nbsp;
                        <asp:Button ID="btnPrint" runat="server" Text=" Print " OnClick="btnPrint_Click" OnClientClick="return CheckSelectedAdjNotes('Print',true);" />                            
                        <asp:Button ID="btnShowAPEVNotes" runat="server" Text="Show Specific Notes Only" OnClick="btnShowAPEVNotes_Click" Visible="false"/>
                        <asp:Button ID="btnPrintAll" runat="server" Text=" Print All " OnClick="btnPrintAll_Click" /> 
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlNotesDetail" runat="server" Visible="false" Width="100%">
            <br />
            <br />
            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                <tr>
                    <td width="20%" align="left">
                        Data Entry Date
                    </td>
                    <td width="4%" align="center">
                        :
                    </td>
                    <td width="26%" align="left">
                        <asp:Label ID="lblDataEntryDate" runat="server"></asp:Label>
                    </td>
                    <td width="20%" align="left">
                        Data Source
                    </td>
                    <td width="4%" align="center">
                        :
                    </td>
                    <td width="26%" align="left">
                        <asp:Label ID="lblDataSource2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        Claimant Name
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td align="left">
                        <asp:Label ID="lblClaimantName" runat="server"></asp:Label>
                    </td>
                    <td align="left">
                        Unique Claim Number
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td align="left">
                        <asp:Label ID="lblSourceUniqueClaimNumber" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        Claimant SSN
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td align="left">
                        <asp:Label ID="lblClaimantSSN" runat="server"></asp:Label>
                    </td>
                    <td align="left">
                        Activity Type
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td align="left">
                        <asp:Label ID="lblActivityType" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        Accident Date
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td align="left">
                        <asp:Label ID="lblAccidentDate" runat="server"></asp:Label>
                    </td>
                    <td align="left">
                        Data Received Date
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td align="left">
                        <asp:Label ID="lblDataReceivedDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        MultiNote Indicator
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td align="left">
                        <asp:Label ID="lblMultiNoteIndicator" runat="server"></asp:Label>
                    </td>
                    <td align="left">
                        Initials
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td align="left">
                        <asp:Label ID="lblInitials" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        Note Text
                    </td>
                    <td align="center">
                        :
                    </td>
                    <td align="left">
                    </td>
                    <td align="left">
                    </td>
                    <td align="center">
                    </td>
                    <td align="left">
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="6">
                        <%--<asp:TextBox ID="lblNoteText" runat="server" Width="100%" Height="50px" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>--%>
                        <uc:ctrlMultiLineTextBox ID="lblNoteText" runat="server" MaxLength="4000" ControlType="Label"
                            Width="760" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlSelectedNotes" runat="server" Width="100%" Visible="false">
            <input type="hidden" id="hdnRptRows" runat="server" />
            <table cellpadding="1" cellspacing="1" width="100%">
                <tr>
                    <td width="100%">
                        <div style="width: 785px; height: 370px; overflow-x: hidden; overflow-y: scroll;">
                            <asp:Repeater ID="rptNotes" runat="server">
                                <ItemTemplate>
                                    <table cellpadding="1" cellspacing="1" width="100%">
                                        <tr style='display: <%# Container.ItemIndex == 0 ? "block" : "none" %>'>
                                            <td colspan="2" align="left" valign="bottom">
                                                <input type="checkbox" id="chkRptMultiSelectAdjNotes" onclick="SelectDeselectAllAdjNotes(this.checked,false);" />Select
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="5%" align="left" valign="top">
                                                <asp:CheckBox ID="chkRptNotesSelect" runat="server" onclick="SelectDeselectHeader(false);" />
                                                <input type="hidden" id="hdnID" runat="server" value='<%#Eval("PK_Adjustor_Notes_RO_ID")%>' />
                                            </td>
                                            <td align="left" valign="top">
                                                <table cellpadding="3" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td width="18%" align="left" valign="top">
                                                            Data Entry Date
                                                        </td>
                                                        <td width="4%" align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td width="28%" align="left" valign="top">
                                                            <%#clsGeneral.FormatDBNullDateToDisplay(Eval("Data_Entry_Date"))%>
                                                        </td>
                                                        <td width="18%" align="left" valign="top">
                                                            Activity Type
                                                        </td>
                                                        <td width="4%" align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td width="28%" align="left" valign="top">
                                                            <%#Eval("Activity_Type_Description")%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Note Text
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="lblNoteText" runat="server" Text='<%# Eval("Note_Text") %>'
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
                        <asp:Button ID="btnPrintSelectedNotes" runat="server" Text=" Print " OnClick="btnPrintSelectedNotes_Click"
                            OnClientClick="return CheckSelectedAdjNotes('Print',false);" />&nbsp;
                        <asp:Button ID="btnCancel" runat="server" Text=" Cancel " OnClick="btnCancel_Click" />
                        <asp:Button ID="btnMailNotes" runat="server" Text=" Mail " OnClick="btnMailNotes_Click" />
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
        <asp:PostBackTrigger ControlID="btnPrintSelectedNotes" />
        <asp:PostBackTrigger ControlID="btnPrint" />
        <asp:PostBackTrigger ControlID="btnPrintAll" />
    </Triggers>
</asp:UpdatePanel>
<br />
