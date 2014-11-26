<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="PropertyClaimInfo.aspx.cs"
    Inherits="SONIC_PropertyClaimInfo" Title="Claim Information :: Property" %>

<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Src="~/Controls/SONICtab/SonicTab.ascx" TagName="CtlSonicTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/ClaimTab/ClaimTab.ascx" TagName="CtlClaimTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/SONICInfo/SonicInfo.ascx" TagName="CtlSonicInfo" TagPrefix="uc" %>
<%@ Register Src="~/Controls/ClaimAttachment/Attachment.ascx" TagName="CtlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/ClaimAttachment/AttachmentDetails.ascx" TagName="CtlAttachmentDetail"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/SonicClaimNotes/SonicNotes.ascx" TagName="ctrlSonicNotes"
    TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript">
        var currIndex = 1;
        function ShowPrevNext(index) {
            ShowPanel(parseInt(currIndex, 10) + parseInt(index, 10));
        }

        function ShowPanel(index) {
            currIndex = index;
            SetMenuStyle(index);
            if (index == 1) {
                document.getElementById("<%=pnlLocationContact.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlLossInformation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlComments.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlSonicNotes.ClientID%>").style.display = "none";

                document.getElementById("btnPrev").style.display = "none";
                document.getElementById("btnNext").style.display = "block";
            }
            if (index == 2) {
                document.getElementById("<%=pnlLocationContact.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlLossInformation.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlComments.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlSonicNotes.ClientID%>").style.display = "none";

                document.getElementById("btnPrev").style.display = "block";
                document.getElementById("btnNext").style.display = "block";
            }
            if (index == 3) {
                document.getElementById("<%=pnlLocationContact.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlLossInformation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlComments.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlSonicNotes.ClientID%>").style.display = "block";

                document.getElementById("btnPrev").style.display = "block";
                document.getElementById("btnNext").style.display = "block";
            }
            if (index == 4) {
                document.getElementById("<%=pnlLocationContact.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlLossInformation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlComments.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlSonicNotes.ClientID%>").style.display = "none";

                document.getElementById("btnPrev").style.display = "block";
                document.getElementById("btnNext").style.display = "none";
            }

        }
        function SetMenuStyle(index) {
            var i;
            for (i = 1; i <= 4; i++) {
                var tb = document.getElementById("WCMenu" + i);
                if (i == index) {
                    tb.className = "C_LeftMenuSelected";
                    tb.onmouseover = function () { this.className = 'C_LeftMenuSelected'; }
                    tb.onmouseout = function () { this.className = 'C_LeftMenuSelected'; }
                }
                else {
                    tb.className = "C_LeftMenuStatic";
                    tb.onmouseover = function () { this.className = 'C_LeftMenuHover'; }
                    tb.onmouseout = function () { this.className = 'C_LeftMenuStatic'; }
                }

            }
        }

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
    <asp:ValidationSummary ID="vsAttchments" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields in Comments/Attachment Panel:" BorderWidth="1"
        BorderColor="DimGray" ValidationGroup="AddClaimAttachment" CssClass="errormessage">
    </asp:ValidationSummary>
    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowSummary="false"
        ShowMessageBox="true" HeaderText="Verify the following fields in Attachment:"
        BorderWidth="1" BorderColor="DimGray" ValidationGroup="AddAttachment" CssClass="errormessage">
    </asp:ValidationSummary>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100%" style="height: 50px;" valign="bottom" colspan="2">
                <uc:CtlClaimTab runat="server" ID="ClaimTab" />
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td class="Spacer" style="height: 15px;" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" colspan="2">
                            <asp:UpdatePanel runat="Server" ID="updSonic" UpdateMode="Always">
                                <ContentTemplate>
                                    <table style="background-color: black" cellspacing="1" cellpadding="3" width="100%"
                                        border="0">
                                        <tbody>
                                            <tr class="PropertyInfoBG">
                                                <td style="width: 18%" align="left">
                                                    <asp:Label ID="lblHeaderClaimNumber" runat="server" Text="Claim Number"></asp:Label>
                                                </td>
                                                <td style="width: 18%" align="left">
                                                    <asp:Label ID="lblHeaderLocationdba" runat="server" Text="SONIC Location d/b/a"></asp:Label>
                                                </td>
                                                <td style="display: none; width: 18%" id="tdHeaderName" align="left" runat="server">
                                                    <asp:Label ID="lblHeaderName" runat="server" Text="Name"></asp:Label>
                                                </td>
                                                <td style="width: 18%" align="left">
                                                    <asp:Label ID="lblHeaderDateLoss" runat="server" Text="Date of Loss"></asp:Label>
                                                </td>
                                                <td style="width: 28%" align="left">
                                                    <asp:Label ID="lblHeaderAssociatedFirstReport" runat="server" Text="Associated First Report"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr style="background-color: white">
                                                <td align="left">
                                                    <asp:Label ID="lblClaimNumber" runat="server">&nbsp; </asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblLocationdba" runat="server"> </asp:Label>
                                                </td>
                                                <td style="display: none" id="tdName" align="left" runat="Server">
                                                    <asp:Label ID="lblName" runat="server"> </asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblDateIncident" runat="server"> </asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:LinkButton ID="lnkAssociatedFirstReport" runat="server" OnClick="lnkAssociatedFirstReport_Click"></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" style="height: 15px;" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td class="leftMenu">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="height: 18px;" class="Spacer">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100%">
                                        <table cellpadding="5" cellspacing="0" border="0" width="100%">
                                            <tr>
                                                <td>
                                                    <span id="WCMenu1" href="#" onclick="javascript:ShowPanel('1');">Location/Contact</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span id="WCMenu2" href="#" onclick="javascript:ShowPanel('2');">Loss Information</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span id="WCMenu3" href="#" onclick="javascript:ShowPanel('3');">Sonic Notes</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span id="WCMenu4" href="#" onclick="javascript:ShowPanel('4');">Comments
                                                        <br />
                                                        <br />
                                                        Attachments</span>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 5px;" class="Spacer">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblSubmitMessage" SkinID="lblError"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:UpdateProgress runat="server" ID="upProgress" DisplayAfter="100">
                                            <ProgressTemplate>
                                                <div class="UpdatePanelloading" id="divProgress" style="width: 100%;">
                                                    <table id="ProgressTable" cellpadding="0" cellspacing="0" border="0" style="width: 100%;
                                                        height: 100%;">
                                                        <tr align="center" valign="middle">
                                                            <td class="LoadingText" align="center" valign="middle">
                                                                <img src="../../Images/indicator.gif" alt="Loading" />&nbsp;&nbsp;&nbsp;Please Wait..
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td width="5px">
                                        &nbsp;
                                    </td>
                                    <td width="794px" valign="top" class="dvContainer">
                                        <div id="dvView" runat="server" style="width: 100%;">
                                            <asp:Panel ID="pnlLocationContact" runat="server" Width="100%">
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="20%">
                                                            Location RM Number
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="26%">
                                                            <asp:Label runat="server" ID="lblLocationRMNumber" />
                                                        </td>
                                                        <td align="left" width="20%">
                                                            Claim Number
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="26%">
                                                            <asp:Label runat="server" ID="lblClaimNumberAgain" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Address1
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblAddress1" />
                                                        </td>
                                                        <td align="left">
                                                            <b>Contact Information</b>
                                                        </td>
                                                        <td align="center">
                                                        </td>
                                                        <td align="left">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Address 2
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblAddress2" />
                                                        </td>
                                                        <td align="left">
                                                            Location DBA
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblLocationDBAAgain" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            City
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblCity" />
                                                        </td>
                                                        <td align="left">
                                                            Name
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblEmployeeName" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            State
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblState" />
                                                        </td>
                                                        <td align="left">
                                                            Address1
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblEmployeeAddress1" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Zip
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblZip" />
                                                        </td>
                                                        <td align="left">
                                                            Address 2
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblEmployeeAddress2" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Date of Loss
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblDateofLoss" />
                                                        </td>
                                                        <td align="left">
                                                            City
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblEmployeeCity" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Time of Loss
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblTimeofLoss" />
                                                        </td>
                                                        <td align="left">
                                                            State
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblEmployeeState" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Date Reported to Sonic
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblDateReportedtoSonic" />
                                                        </td>
                                                        <td align="left">
                                                            Zip
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblEmployeeZip" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                        </td>
                                                        <td align="center">
                                                        </td>
                                                        <td align="left">
                                                        </td>
                                                        <td align="left">
                                                            Time to Contact
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblTimetoContact" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                        </td>
                                                        <td align="center">
                                                        </td>
                                                        <td align="left">
                                                        </td>
                                                        <td align="left">
                                                            Telephone Number 1
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblEmployeeWorkPhone" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                        </td>
                                                        <td align="center">
                                                        </td>
                                                        <td align="left">
                                                        </td>
                                                        <td align="left">
                                                            Telephone Number 2
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblEmployeeCellPhone" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                        </td>
                                                        <td align="center">
                                                        </td>
                                                        <td align="left">
                                                        </td>
                                                        <td align="left">
                                                            Fax
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblFax" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                        </td>
                                                        <td align="center">
                                                        </td>
                                                        <td align="left">
                                                        </td>
                                                        <td align="left">
                                                            Email address
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblEmployeeEmail" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlLossInformation" runat="server" Width="100%" Style="display: none;">
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="31%">
                                                            Time of Loss
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="65%">
                                                            <asp:Label runat="server" ID="lblLossInfoTimeofLoss" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <b>Building Affected</b>
                                                        </td>
                                                        <td align="center">
                                                        </td>
                                                        <td align="left">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="3">
                                                            <div id="divBuildingAffected" style="width: 99%; height: 100px; overflow-y: scroll;
                                                                overflow-x: hidden; border: solid 1px #000000;">
                                                                <asp:GridView ID="gvBuildingAffected" runat="server" AutoGenerateColumns="false"
                                                                    Width="98%">
                                                                    <HeaderStyle HorizontalAlign="center" />
                                                                    <RowStyle HorizontalAlign="center" />
                                                                    <Columns>
                                                                        <asp:BoundField ControlStyle-Width="20%" HeaderText="Occupancy" DataField="Occupancy" />
                                                                        <asp:TemplateField ControlStyle-Width="20%" HeaderText="Address">
                                                                            <ItemTemplate>
                                                                                <%#Eval("Address_1") %>
                                                                                &nbsp;
                                                                                <%#Eval("Address_2") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField ControlStyle-Width="20%" HeaderText="City" DataField="City" />
                                                                        <asp:BoundField ControlStyle-Width="20%" HeaderText="State" DataField="State" />
                                                                        <asp:BoundField ControlStyle-Width="20%" HeaderText="Zip" DataField="Zip" />
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
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <b>Witnesses</b>
                                                        </td>
                                                        <td align="center">
                                                        </td>
                                                        <td align="left">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="3">
                                                            <div id="divWitnesses" style="width: 99%; height: 100px; overflow-y: scroll; overflow-x: hidden;
                                                                border: solid 1px #000000;">
                                                                <asp:GridView ID="gvWitnesses" runat="server" AutoGenerateColumns="false" Width="98%">
                                                                    <HeaderStyle HorizontalAlign="center" />
                                                                    <RowStyle HorizontalAlign="center" />
                                                                    <Columns>
                                                                        <asp:BoundField ControlStyle-Width="20%" HeaderText="Name" DataField="Name" />
                                                                        <asp:TemplateField ControlStyle-Width="20%" HeaderText="Address">
                                                                            <ItemTemplate>
                                                                                <%#Eval("Address_1") %>
                                                                                &nbsp;
                                                                                <%#Eval("Address_2") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField ControlStyle-Width="20%" HeaderText="City" DataField="City" />
                                                                        <asp:BoundField ControlStyle-Width="20%" HeaderText="State" DataField="State" />
                                                                        <asp:BoundField ControlStyle-Width="20%" HeaderText="Zip" DataField="Zip" />
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
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <b>Type of Loss</b>
                                                        </td>
                                                        <td align="center">
                                                        </td>
                                                        <td align="left">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="3">
                                                            <table cellpadding="3" cellspacing="1" border="0" width="70%">
                                                                <tr>
                                                                    <td align="left" width="50%">
                                                                        <asp:CheckBox ID="chkFire" runat="server" Text="Fire" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" width="50%">
                                                                        <asp:CheckBox ID="chkDamageBySonicAssociates" runat="server" Text="Property Damage By Sonic Associates"
                                                                            Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="50%">
                                                                        <asp:CheckBox ID="chkWindDamage" runat="server" Text="Wind Damage" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" width="50%">
                                                                        <asp:CheckBox ID="chkEnvironmetalLoss" runat="server" Text="Environmetal Loss" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="50%">
                                                                        <asp:CheckBox ID="chkHallDamage" runat="server" Text="Hall Damage" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" width="50%">
                                                                        <asp:CheckBox ID="chkVandalismtotheProperty" runat="server" Text="Vandalism to the Property"
                                                                            Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="50%">
                                                                        <asp:CheckBox ID="chkEarthMovement" runat="server" Text="Earth Movement" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" width="50%">
                                                                        <asp:CheckBox ID="chkTheftAssociateTools" runat="server" Text="Theft - Associate Tools"
                                                                            Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="50%">
                                                                        <asp:CheckBox ID="chkFlood" runat="server" Text="Flood" Enabled="false" />
                                                                    </td>
                                                                    <td align="left" width="50%">
                                                                        <asp:CheckBox ID="chkTheftAllOther" runat="server" Text="Theft - All Other" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="50%">
                                                                        <asp:CheckBox ID="chkThirdPartyPropertyDamage" runat="server" Text="Third Party Property Damage"
                                                                            Enabled="false" />
                                                                    </td>
                                                                    <td align="left" width="50%">
                                                                        <asp:CheckBox ID="chkOther" runat="server" Text="Other" Enabled="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <b>Description of Loss</b>
                                                        </td>
                                                        <td align="center">
                                                        </td>
                                                        <td align="left">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="3">
                                                            <%-- <asp:TextBox ID="txtDescriptionofLoss" TextMode="MultiLine" Rows="4" runat="server"
                                                                ReadOnly="true" Width="100%" />--%>
                                                            <uc:ctrlMultiLineTextBox ID="txtDescriptionofLoss" runat="server" MaxLength="4000"
                                                                ControlType="Label" Width="790" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <b>Damages</b>
                                                        </td>
                                                        <td align="center">
                                                        </td>
                                                        <td align="left">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="3">
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td width="31%">
                                                                    </td>
                                                                    <td align="center" width="4%">
                                                                    </td>
                                                                    <td align="center">
                                                                        <b>Estimated Cost</b>
                                                                    </td>
                                                                    <td align="center">
                                                                        <b>Actual Cost</b>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="31%">
                                                                        Buildings and Facilities
                                                                    </td>
                                                                    <td align="center" width="4%">
                                                                        :
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblDamageBuildingFacilitiesEstCost" />
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblDamageBuildingFacilitiesActualCost" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        Equipment
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblDamageEquipmentEstCost" />
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblDamageEquipmentActualCost" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        Product Damage
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblDamageProductDamageEstCost" />
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblDamageProductDamageActualCost" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        Parts
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblDamagePartsEstCost" />
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblDamagePartsActualCost" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        Salvage and Cleanup Expenses including labor
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblDamageSalvageCleanupEstCost" />
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblDamageSalvageCleanupActualCost" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        Decontamination Expenses
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblDamageDecontaminationEstCost" />
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblDamageDecontaminationActualCost" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        Electronic Data/Processing Media
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblDamageElectronicDataEstCost" />
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblDamageElectronicDataActualCost" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        Service Interruption
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblDamageServiceInterruptionEstCost" />
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblDamageServiceInterruptionActualCost" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        Ordinary Payroll
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblDamagePayrollEstCost" />
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblDamagePayrollActualCost" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        Loss of Sales
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblDamageLossofSalesEstCost" />
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblDamageLossofSalesActualCost" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <b>TOTAL</b>
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblTotalEstimatedCost" />
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label runat="server" ID="lblTotalActualCoat" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr height="20px">
                                                        <td colspan="3">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Date Clean-up or Salvage Operations Completed
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblDateCleanupComplete" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Date Equipment/Building Repairs Complete
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblDateRepairsComplete" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Date Full Services Resumed
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblDateFullServiceResumed" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Date Fire Protection Services Resumed
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblDateFireProtectionServicesResumed" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlComments" runat="server" Width="100%" Style="display: none;">
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="31%">
                                                            <b>Comments</b>
                                                        </td>
                                                        <td align="center" width="4%">
                                                        </td>
                                                        <td align="left" width="65%">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="3">
                                                            <%--<asp:TextBox TextMode="MultiLine" ID="" Rows="4" runat="server" Width="100%"
                                                                ReadOnly="true" />--%>
                                                            <uc:ctrlMultiLineTextBox ID="txtComments" runat="server" MaxLength="4000" ControlType="Label"
                                                                Width="790" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="31%">
                                                            <b>Attachments</b>
                                                        </td>
                                                        <td align="center" width="4%">
                                                        </td>
                                                        <td align="left" width="65%">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="3">
                                                            Click to view<br />
                                                            <uc:CtlAttachment ID="CtrlAttachment_Cliam" runat="server" />
                                                            <uc:CtlAttachmentDetail ID="CtlAttachDetail_Cliam" runat="server" IntAttachmentPanel="3" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="31%">
                                                            Date Report Completed
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="65%">
                                                            <asp:Label ID="lblDateReportComplete" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="31%">
                                                            Date Claim Closed
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="65%">
                                                            <asp:Label ID="lblDateClaimClosed" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlSonicNotes" runat="server" Style="display: none;">
                                                <table border="0" cellpadding="1" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="100%" align="left">
                                                            <uc:ctrlSonicNotes ID="ctrlSonicNotes" runat="server" IsAddVisible="true" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <%--<div class="bandHeaderRow">
                                                    Sonic Notes</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td valign="top" style="width: 15%">
                                                            Sonic Notes Grid<br />
                                                            <asp:LinkButton ID="btnNotesAdd" runat="server" ValidationGroup="vsError" Text="--Add--"
                                                                OnClick="btnNotesAdd_Click"></asp:LinkButton>
                                                        </td>
                                                        <td align="center" valign="top" style="width: 3%">
                                                            :
                                                        </td>
                                                        <td style="margin-left: 40px" style="width: 650px">
                                                            <asp:GridView ID="gvNotes" runat="server" AutoGenerateColumns="false" Width="100%"
                                                                OnRowCommand="gvNotes_RowCommand">
                                                                <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                                <EmptyDataTemplate>
                                                                    <asp:Label ID="lblEmptyEmergencyMessage" runat="server" Text="No Record Found"></asp:Label>
                                                                </EmptyDataTemplate>
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-Width="12%" HeaderStyle-VerticalAlign="Top">
                                                                        <HeaderTemplate>
                                                                            <input type="checkbox" id="chkMultiSelectSonicNotes" onclick="SelectDeselectAllSonicNotes(this.checked);" />Select
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="chkSelectSonicNotes" runat="server" onclick="SelectDeselectNoteHeader();" />
                                                                            <input type="hidden" id="hdnPK" runat="server" value='<%#Eval("PK_Claim_Notes") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                        HeaderText="Note Date">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbtNote_Date" runat="server" Text='<%# string.Format("{0:MM/dd/yyyy}", Eval("Note_Date")) %>'
                                                                                CommandName="EditRecord" CommandArgument='<%#Eval("PK_Claim_Notes") %>' Width="80px"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                        HeaderText="User">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbtUser_Name" runat="server" Text='<%# Eval("User_Name") %>'
                                                                                CommandName="EditRecord" CommandArgument='<%#Eval("PK_Claim_Notes") %>' Width="100px"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                        HeaderText="Notes">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbtNotes" runat="server" Text='<%# Eval("Note") %>' CommandName="EditRecord"
                                                                                CommandArgument='<%#Eval("PK_Claim_Notes") %>' Width="310px" CssClass="TextClip"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                        HeaderText="Remove">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbtDelete" runat="server" Text="Remove" CommandName="Remove"
                                                                                CommandArgument='<%#Eval("PK_Claim_Notes") %>' OnClientClick="javascript:return confirm('Are you sure you want delete selected record?');"
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
                                                </table>--%>
                                            </asp:Panel>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <table cellpadding="5" cellspacing="1" border="0" width="100%">
                                <tr>
                                    <td align="right" width="50%">
                                        <input type="button" id="btnPrev" value="Previous" style="font-weight: bold; color: #000080;"
                                            onclick="javascript:ShowPrevNext(-1);" />
                                    </td>
                                    <td align="left">
                                        <input type="button" id="btnNext" style="font-weight: bold; color: #000080;" value="Next"
                                            onclick="javascript:ShowPrevNext(1);" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
