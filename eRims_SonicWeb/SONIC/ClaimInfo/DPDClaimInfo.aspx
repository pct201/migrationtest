<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="DPDClaimInfo.aspx.cs"
    Inherits="SONIC_DPDClaimInfo" Title="Claim Information :: Dealer Physical Damage" %>

<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Assembly="System.Web.Extensions" Namespace="System.Web.UI" TagPrefix="asp" %>
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
        function ExpandNotes(bExpand, imgPlusId, imgMinusId, txtId) {
            if (bExpand) {
                document.getElementById(txtId).rows = 30;
                document.getElementById(imgMinusId).style.display = "block";
                document.getElementById(imgPlusId).style.display = "none";
            }
            else {
                document.getElementById(txtId).rows = 5;
                document.getElementById(imgMinusId).style.display = "none";
                document.getElementById(imgPlusId).style.display = "block";
            }
        }
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
                document.getElementById("<%=pnlAttachment.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlSonicNotes.ClientID%>").style.display = "none";
                document.getElementById("btnPrev").style.display = "none";
                document.getElementById("btnNext").style.display = "block";
            }
            if (index == 2) {
                document.getElementById("<%=pnlLocationContact.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlLossInformation.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlComments.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlAttachment.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlSonicNotes.ClientID%>").style.display = "none";
                document.getElementById("btnPrev").style.display = "block";
                document.getElementById("btnNext").style.display = "block";
            }
            if (index == 3) {
                document.getElementById("<%=pnlLocationContact.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlLossInformation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlComments.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlAttachment.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlSonicNotes.ClientID%>").style.display = "none";
                document.getElementById("btnPrev").style.display = "block";
                document.getElementById("btnNext").style.display = "block";
            }
            if (index == 4) {
                document.getElementById("<%=pnlLocationContact.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlLossInformation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlComments.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlSonicNotes.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlAttachment.ClientID%>").style.display = "none";

                document.getElementById("btnPrev").style.display = "block";
                document.getElementById("btnNext").style.display = "block";
            }
            if (index == 5) {
                document.getElementById("<%=pnlLocationContact.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlLossInformation.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlComments.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlAttachment.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlSonicNotes.ClientID%>").style.display = "none";
                document.getElementById("btnPrev").style.display = "block";
                document.getElementById("btnNext").style.display = "none";
            }
        }
        function SetMenuStyle(index) {
            var i;
            for (i = 1; i <= 5; i++) {
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
        BorderColor="DimGray" ValidationGroup="AddAttachment" CssClass="errormessage">
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
                                                    <asp:Label ID="lblClaimNumber" runat="server">&nbsp;</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblLocationdba" runat="server"></asp:Label>
                                                </td>
                                                <td style="display: none" id="tdName" align="left" runat="Server">
                                                    <asp:Label ID="lblName" runat="server"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblDateLoss" runat="server"></asp:Label>
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
                                                    <span id="WCMenu3" href="#" onclick="javascript:ShowPanel('3');">Comments </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span id="WCMenu4" href="#" onclick="javascript:ShowPanel('4');">Sonic Notes</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span id="WCMenu5" href="#" onclick="javascript:ShowPanel('5');">Attachment </span>
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
                                                            Date of Update
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="26%">
                                                            <asp:Label runat="server" ID="lblDateofUpdate" />
                                                        </td>
                                                        <td align="left" width="20%">
                                                            Data Source
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="26%">
                                                            <asp:Label runat="server" ID="lblDataSource" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Location RM Number
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblLocationRMNumber" />
                                                        </td>
                                                        <td align="left">
                                                            Claim Number
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblClaimNumberAgain" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <b>Loss Location if Different</b>
                                                        </td>
                                                        <td align="center">
                                                        </td>
                                                        <td align="left">
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
                                                            Address1
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblAddress1" />
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
                                                            Address 2
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblAddress2" />
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
                                                            City
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblCity" />
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
                                                            State
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblState" />
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
                                                            Zip
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblZip" />
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
                                                        </td>
                                                        <td align="center">
                                                        </td>
                                                        <td align="left">
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
                                                            Accident on Company Property Y/N
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblAccidentonCompanyProperty" />
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
                                                            Date of Loss
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblDateofLoss" />
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
                                                            Time of Loss
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblTimeofLoss" />
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
                                                            Date Reported to Sonic
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblDateReportedtoSonic" />
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
                                            <asp:Panel ID="pnlLossInformation" runat="server" Width="100%">
                                                <asp:UpdatePanel runat="server" ID="udpLoss">
                                                    <ContentTemplate>
                                                        <table cellspacing="1" cellpadding="3" width="100%" border="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td align="left" width="20%">
                                                                        <b>Theft</b>
                                                                    </td>
                                                                    <td align="center" width="4%">
                                                                    </td>
                                                                    <td align="left" width="26%">
                                                                    </td>
                                                                    <td align="left" width="20%">
                                                                        <b>Partial Theft</b>
                                                                    </td>
                                                                    <td align="center" width="4%">
                                                                    </td>
                                                                    <td align="left" width="26%">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Make
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblTheftMake" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        Number of Vehicles Damaged
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblPartialTheftNumberofVehiclesDamaged" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Model
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblTheftModel" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        Total Estimate of Damages
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblParialTheftDamageEstimate" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Year
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblTheftYear" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        <b>Vandalism</b>
                                                                    </td>
                                                                    <td align="center">
                                                                    </td>
                                                                    <td align="left">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        VIN
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblTheftVIN" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        Number of Vehicles Damaged
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblVandalismNumberofVehiclesDamaged" runat="server" __designer:wfdid="w4"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Invoice Value
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblVehicleInvoiceValue" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        Total Estimate of Damages
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblVandalismTotalEstimateofDamages" runat="server" __designer:wfdid="w5"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Vehicle Recoverd Y/N
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblVehicleRecovered" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        <b>Hail</b>
                                                                    </td>
                                                                    <td align="center">
                                                                    </td>
                                                                    <td align="left">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Damage Amount
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblTheftVehicleDamageAmount" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        Number of Vehicles Damaged
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblHailNumberOfVehiclesDamaged" runat="server" __designer:wfdid="w6"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Dealer wishes to Take possesiion Y/N
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblTheftDealershipWishToTakePossession" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        Total Estimate of Damages
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblHailDamageEstimate" runat="server" __designer:wfdid="w7"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" colspan="3">
                                                                        <asp:Label ID="lblTitleMVADamage" runat="server" Text="<b>MVA Damage (Single Vehicle)</b>"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        <b>Flood</b>
                                                                    </td>
                                                                    <td align="center">
                                                                    </td>
                                                                    <td align="left">
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
                                                                        Number of Vehicles Damaged
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblFloodNumberOfVehiclesDamaged" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblTitleMake" runat="server" Text="Make"></asp:Label>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label ID="lblMidMake" runat="server" Text=":"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblDPDClaimsVehicleMake" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        Total Estimate of Damages
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label ID="Label1" runat="server" Text=":"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblFloodDamageEstimate" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblTitleModel" runat="server" Text="Model"></asp:Label>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label ID="lblMidModel" runat="server" Text=":"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblDPDClaimsVehicleModel" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        <b>Fire</b>
                                                                    </td>
                                                                    <td align="center">
                                                                    </td>
                                                                    <td align="left">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblTitleYear" runat="server" Text="Year"></asp:Label>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label ID="lblMidYear" runat="server" Text=":"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblDPDClaimsVehicleYear" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        Number of Vehicles Damaged
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblFireNumberOfVehiclesDamaged" runat="server" __designer:wfdid="w8"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblTitleVIN" runat="server" Text="VIN"></asp:Label>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label ID="lblMidVIN" runat="server" Text=":"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblDPDClaimsVehicleVIN" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        Total Estimate of Damages
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblFireDamageEstimate" runat="server" __designer:wfdid="w9"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblTitleDamageAmount" runat="server" Text="Damage Amount"></asp:Label>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label ID="lblMidDamageAmount" runat="server" Text=":"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblDPDClaimsVehicleDamageEstimate" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        <b>Wind</b>
                                                                    </td>
                                                                    <td align="center">
                                                                    </td>
                                                                    <td align="left">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblTitleDrivenbyAssociate" runat="server" Text="Vehicle Driven by Associate Y/N"></asp:Label>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label ID="lblMidDrivenbyAssociate" runat="server" Text=":"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblDPDClaimsVehicleDrivenByAssociate" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        Number of Vehicles Damaged
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblWindNumberOfVehiclesDamaged" runat="server" __designer:wfdid="w10"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblTitleDrivenbyCustomer" runat="server" Text="Vehicle Driven by Customer Y/N"></asp:Label>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label ID="lblMidDrivenbyCustomer" runat="server" Text=":"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblDPDClaimsVehicleDrivenByCustomer" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        Total Estimate of Damages
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblWindDamageEstimate" runat="server" __designer:wfdid="w11"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Loss Description
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
                                                                        <%--  <asp:TextBox ID="txtMVASingleLossDescription" runat="server" Width="100%" ReadOnly="true"
                                                                    Rows="4" TextMode="MultiLine"></asp:TextBox>--%>
                                                                        <uc:ctrlMultiLineTextBox ID="txtMVASingleLossDescription" runat="server" MaxLength="4000"
                                                                            ControlType="Label" Width="790" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Police Were Notified Y/N
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblMVASinglePoliceNotified" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                    </td>
                                                                    <td align="center">
                                                                    </td>
                                                                    <td align="left">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Police Report Number
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblMVASinglePoliceReportNumber" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                    </td>
                                                                    <td align="center">
                                                                    </td>
                                                                    <td align="left">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6">
                                                                        <table id="tblMultipleDamage" cellspacing="0" cellpadding="0" width="100%" runat="server">
                                                                            <%--<tbody>--%>
                                                                                <tr>
                                                                                    <td align="left" colspan="3">
                                                                                        <b>MVA Damage (Multiple Vehicle)</b>
                                                                                    </td>
                                                                                    <td align="left">
                                                                                    </td>
                                                                                    <td align="center">
                                                                                    </td>
                                                                                    <td align="left">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left" colspan="3">
                                                                                        Click for detail<br />
                                                                                        <div style="overflow-y: scroll; overflow-x: hidden; width: 99%; height: 100px; border: solid 1px #000000;"
                                                                                            id="divMVADamageList">
                                                                                            <asp:GridView ID="gvWCTransList" runat="server" Width="98%" AutoGenerateColumns="False"
                                                                                                OnRowCommand="gvWCTransList_RowCommand">
                                                                                                <HeaderStyle HorizontalAlign="center" />
                                                                                                <RowStyle HorizontalAlign="center" />
                                                                                                <Columns>
                                                                                                    <asp:TemplateField HeaderText="Make">
                                                                                                        <ItemStyle Width="20%" />
                                                                                                        <ItemTemplate>
                                                                                                            <asp:LinkButton runat="server" Text='<%#Eval("Make")%>' ID="lnkWCTransListMake" CommandName="ViewWCTransList"
                                                                                                                CommandArgument='<%#Container.DataItemIndex%>' />
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Model">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label runat="server" ID="lblWCTransListModel" Text='<%#Eval("Model") %>' />
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Year">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label runat="server" ID="lblWCTransListYear" Text='<%#Eval("Year") %>' />
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="VIN">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label runat="server" ID="lblWCTransListVIN" Text='<%#Eval("VIN#") %>' />
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Damage Estimate">
                                                                                                        <ItemTemplate>
                                                                                                            $
                                                                                                            <asp:Label runat="server" ID="lblWCTransListDamageEstimate" Text='<%#Eval("Damage_Estimate","{0:N2}") %>' />
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField Visible="false">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label runat="server" ID="lblWCTransListDrivenByAssociate" Text='<%#Eval("Driven_By_Associate") %>' />
                                                                                                            <asp:Label runat="server" ID="lblWCTransListVehicleDrivenByCustomer" Text='<%#Eval("Vehicle_Driven_By_Customer") %>' />
                                                                                                            <asp:Label runat="server" ID="lblWCTransListPoliceNotified" Text='<%#Eval("Police_Notified") %>' />
                                                                                                            <asp:Label runat="server" ID="lblWCTransListPoliceReportNumber" Text='<%#Eval("Police_Report_Number") %>' />
                                                                                                            <asp:Label runat="server" ID="lblWCTransListInvoiceAmount" Text='<%#Eval("Invoice_Value") %>' />
                                                                                                            <asp:Label runat="server" ID="lblWCTransListVehicleRecovered" Text='<%#Eval("Vehicle_Recovered") %>' />
                                                                                                            <asp:Label runat="server" ID="lblWCTransListDealershipWishToTakePossession" Text='<%#Eval("Dealership_Wish_To_Take_Possession") %>' />
                                                                                                            <asp:Label runat="server" ID="lblWCTransListAssociateCited" Text='<%#Eval("Associate_Cited") %>' />
                                                                                                            <asp:Label runat="server" ID="lblWCTransListLossDescription" Text='<%#Eval("Loss_Description") %>' />
                                                                                                            <asp:Label runat="server" ID="lblWCTransListDescriptionOfCitation" Text='<%#Eval("Description_Of_Citation") %>' />
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
                                                                                        </div>
                                                                                        <asp:Panel ID="pnlMVADamageDetail" runat="server" Width="100%" Visible="false">
                                                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                                <tr>
                                                                                                    <td width="26%" align="left">
                                                                                                        Make
                                                                                                    </td>
                                                                                                    <td width="4%" align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td width="70%" align="left">
                                                                                                        <asp:Label runat="server" ID="lblWCTransMake" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        Model
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:Label runat="server" ID="lblWCTransModel" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        Year
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:Label runat="server" ID="lblWCTransYear" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        VIN
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:Label runat="server" ID="lblWCTransVIN" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        Damage Amount
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:Label runat="server" ID="lblWCTransDamageAmount" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        Vehicle Driven By Associate Y/N
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:Label runat="server" ID="lblWCTransDrivenByAssociate" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        Associate was cited for a violation Y/N
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:Label runat="server" ID="lblWCTransAssociateCited" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        Description of Citation
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:Label runat="server" ID="lblWCTransDescriptionOfCitation" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        Vehicle Driven by Customer Y/N
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:Label runat="server" ID="lblWCTransDrivenbyCustomer" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        Loss Description
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left" colspan="3">
                                                                                                        <uc:ctrlMultiLineTextBox ID="txtWCTransLossDescription" runat="server" MaxLength="4000"
                                                                                                            ControlType="Label" Width="790" />
                                                                                                        <%--<asp:TextBox TextMode="MultiLine" Width="100%" Rows="4" ID="txtWCTransLossDescription"
                                                                                                    runat="server" ReadOnly="true" />--%>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        Police Were Notified Y/N
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:Label runat="server" ID="lblWCTransPoliceNotified" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        Police Report Number
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        :
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:Label runat="server" ID="lblWCTransPoliceReportNumber" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </asp:Panel>
                                                                                    </td>
                                                                                </tr>
                                                                            <%--</tbody>--%>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" colspan="3">
                                                                        <b>Fraud</b>
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
                                                                        Click for detail<br />
                                                                        <div style="overflow-y: scroll; overflow-x: hidden; width: 99%; height: 100px; border: solid 1px #000000"
                                                                            id="divFraudList">
                                                                            <asp:GridView ID="gvFraudList" runat="server" Width="98%" AutoGenerateColumns="False"
                                                                                OnRowCommand="gvFraudList_RowCommand" OnRowDataBound="gvFraudList_RowDataBound">
                                                                                <HeaderStyle HorizontalAlign="center" />
                                                                                <RowStyle HorizontalAlign="center" />
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="Make">
                                                                                        <ItemStyle Width="20%" />
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton runat="server" Text='<%#Eval("Make")%>' ID="lnkFraudListMake" CommandName="View"
                                                                                                CommandArgument='<%#Container.DataItemIndex%>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Model">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label runat="server" ID="lblFraudListModel" Text='<%#Eval("Model") %>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Year">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label runat="server" ID="lblFraudListYear" Text='<%#Eval("Year") %>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="VIN">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label runat="server" ID="lblFraudListVIN" Text='<%#Eval("VIN#") %>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Invoice Value">
                                                                                        <ItemTemplate>
                                                                                            $
                                                                                            <asp:Label runat="server" ID="lblFraudListDamageEstimate" Text='<%#Eval("Invoice_Value","{0:N2}") %>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Recovered?">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label runat="server" ID="lblFraudListVehicleRecovered" Text='<%# Eval("Vehicle_Recovered") %>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label runat="server" ID="lblFraudListAssociateCited" Text='<%#Eval("Associate_Cited") %>' />
                                                                                            <asp:Label runat="server" ID="lblFraudListDrivenByAssociate" Text='<%#Eval("Driven_By_Associate") %>' />
                                                                                            <asp:Label runat="server" ID="lblFraudListVehicleDrivenByCustomer" Text='<%#Eval("Vehicle_Driven_By_Customer") %>' />
                                                                                            <asp:Label runat="server" ID="lblFraudListPoliceNotified" Text='<%#Eval("Police_Notified") %>' />
                                                                                            <asp:Label runat="server" ID="lblFraudListPoliceReportNumber" Text='<%#Eval("Police_Report_Number") %>' />
                                                                                            <asp:Label runat="server" ID="lblFraudListInvoiceAmount" Text='<%#Eval("Invoice_Value") %>' />
                                                                                            <asp:Label runat="server" ID="lblFraudListDealershipWishToTakePossession" Text='<%#Eval("Dealership_Wish_To_Take_Possession") %>' />
                                                                                            <asp:Label runat="server" ID="lblLossDescription" Text='<%#Eval("Loss_Description") %>' />
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
                                                                        </div>
                                                                        <asp:Panel ID="pnlFraudDetail" runat="server" Width="100%" Visible="false">
                                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                <tr>
                                                                                    <td width="26%" align="left">
                                                                                        Make
                                                                                    </td>
                                                                                    <td width="4%" align="center">
                                                                                        :
                                                                                    </td>
                                                                                    <td width="70%" align="left">
                                                                                        <asp:Label runat="server" ID="lblFraudMake" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        Model
                                                                                    </td>
                                                                                    <td align="center">
                                                                                        :
                                                                                    </td>
                                                                                    <td align="left">
                                                                                        <asp:Label runat="server" ID="lblFraudModel" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        Year
                                                                                    </td>
                                                                                    <td align="center">
                                                                                        :
                                                                                    </td>
                                                                                    <td align="left">
                                                                                        <asp:Label runat="server" ID="lblFraudYear" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        VIN
                                                                                    </td>
                                                                                    <td align="center">
                                                                                        :
                                                                                    </td>
                                                                                    <td align="left">
                                                                                        <asp:Label runat="server" ID="lblFraudVIN" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        Vehicle Invoice Amount
                                                                                    </td>
                                                                                    <td align="center">
                                                                                        :
                                                                                    </td>
                                                                                    <td align="left">
                                                                                        <asp:Label runat="server" ID="lblFraudInvoiceAmount" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        Vehicle Recovered Y/N
                                                                                    </td>
                                                                                    <td align="center">
                                                                                        :
                                                                                    </td>
                                                                                    <td align="left">
                                                                                        <asp:Label runat="server" ID="lblFraudVehicleRecovered" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        ADealership Wishes to Take Possession Y/N
                                                                                    </td>
                                                                                    <td align="center">
                                                                                        :
                                                                                    </td>
                                                                                    <td align="left">
                                                                                        <asp:Label runat="server" ID="lblFraudDealershipWishToTakePossession" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        Loss Description
                                                                                    </td>
                                                                                    <td align="center">
                                                                                        :
                                                                                    </td>
                                                                                    <td align="left">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left" colspan="3">
                                                                                        <uc:ctrlMultiLineTextBox ID="txtLossDescription" runat="server" MaxLength="4000"
                                                                                            ControlType="Label" Width="790" />
                                                                                        <%--<asp:TextBox TextMode="MultiLine" Width="100%" Rows="4" ID="txtLossDescription" runat="server"
                                                                                    ReadOnly="true" />--%>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        Police Were Notified Y/N
                                                                                    </td>
                                                                                    <td align="center">
                                                                                        :
                                                                                    </td>
                                                                                    <td align="left">
                                                                                        <asp:Label runat="server" ID="lblPoliceNotified" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        Police Report Number
                                                                                    </td>
                                                                                    <td align="center">
                                                                                        :
                                                                                    </td>
                                                                                    <td align="left">
                                                                                        <asp:Label runat="server" ID="lblPoliceReportNumber" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </asp:Panel>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlComments" runat="server" Width="100%">
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="20%">
                                                            Comments:
                                                        </td>
                                                        <td align="center" width="4%">
                                                        </td>
                                                        <td align="left" width="26%">
                                                        </td>
                                                        <td align="left" width="20%">
                                                        </td>
                                                        <td align="center" width="4%">
                                                        </td>
                                                        <td align="left" width="26%">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="6" style="height: 150px; vertical-align: top;">
                                                            <%--<asp:TextBox runat="server" Rows="4" TextMode="MultiLine" Width="100%" ID=""
                                                                ReadOnly="true" />--%>
                                                            <uc:ctrlMultiLineTextBox ID="txtComments" runat="server" MaxLength="4000" ControlType="Label"
                                                                Width="790" />
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
                                                                    <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-Width="12%">
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
                                            <asp:Panel ID="pnlAttachment" runat="server">
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td>
                                                            <uc:CtlAttachment ID="CtrlAttachment_Cliam" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <uc:CtlAttachmentDetail ID="CtlAttachDetail_Cliam" runat="server" IntAttachmentPanel="4" />
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="5" cellspacing="1" border="0" width="100%">
                                <tr>
                                    <td align="right" width="50%">
                                        <input type="button" id="btnPrev" value="Previous" style="display: none; font-weight: bold;
                                            color: #000080;" onclick="javascript:ShowPrevNext(-1);" />
                                    </td>
                                    <td align="left" width="50%">
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
