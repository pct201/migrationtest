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
<%@ Register Src="~/Controls/SonicClaimNotes/AdjusterNotes.ascx" TagName="CtrlAdjusterNotes"
    TagPrefix="uc" %>
<asp:content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">
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
                //Set Claim Information Screen Visible
                SetPanelByIndex("block", "none", "none", "none", "none", "none", "block");
            }
            if (index == 2) {
                //Set Addresses Screen Visible
                SetPanelByIndex("none", "block", "none", "none", "none", "block", "block");

            }
            if (index == 3) {
                //Set Incidents Screen Visible
                SetPanelByIndex("none", "none", "block", "none", "none", "block", "block");

            }
            if (index == 4) {
                //Set Details Screen Visible
                SetPanelByIndex("none", "none", "none", "block", "none", "block", "block");

            }
            if (index == 5) {
                //Set Notes Screen Visible
                SetPanelByIndex("none", "none", "none", "none", "block", "block", "none");

            }
        }

        //Enable-Disable zx Screen and Previous/Next Button as per Click
        function SetPanelByIndex(ClaimInfo, Addresses, Incidents, Details, Notes, btnPrev, btnNext) {

            document.getElementById("<%=pnlClaimInformation.ClientID%>").style.display = ClaimInfo;
            document.getElementById("<%=pnlAddresses.ClientID%>").style.display = Addresses;
            document.getElementById("<%=pnlIncidents.ClientID%>").style.display = Incidents;
            document.getElementById("<%=pnlDetails.ClientID%>").style.display = Details;
            document.getElementById("<%=pnlNotes.ClientID%>").style.display = Notes;

            document.getElementById("btnPrev").style.display = btnPrev;
            document.getElementById("btnNext").style.display = btnNext;
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
                                                    <span id="WCMenu1" href="#" onclick="javascript:ShowPanel('1');">Claim Information</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span id="WCMenu2" href="#" onclick="javascript:ShowPanel('2');">Addresses</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span id="WCMenu3" href="#" onclick="javascript:ShowPanel('3');">Incidents </span>
                                                </td>
                                            </tr>                                            
                                            <tr>
                                                <td>
                                                    <span id="WCMenu4" href="#" onclick="javascript:ShowPanel('4');">Details </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span id="WCMenu5" href="#" onclick="javascript:ShowPanel('5');">Notes</span>
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
                                            <asp:Panel ID="pnlClaimInformation" runat="server" Width="100%">
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td height="12px"></td>                                               
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="20%">
                                                            Date of Loss
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="26%">
                                                            <asp:Label runat="server" ID="lblDateofLoss" />
                                                        </td>
                                                        <td align="left" width="20%">
                                                            Time of Loss
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="26%">
                                                            <asp:Label runat="server" ID="lblTimeofLoss" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Description of Loss
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblDescriptionofLoss" />
                                                        </td>
                                                        <td align="left">
                                                            Line Type
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblLineType" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Claim Type
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblClaimType" />
                                                        </td>
                                                        <td align="left">
                                                            Claim Sub-Type
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblClaimSubType" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Claim Status
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblClaimStatus" />
                                                        </td>
                                                        <td align="left">
                                                            Claim Sub-Status
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblClaimSubStatus" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="12px"></td>                                               
                                                    </tr> 
                                                    <tr>
                                                        <td align="left">
                                                            Date Reported To Sonic
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblDateReportedtoSonic" />
                                                        </td>
                                                        <%--<td align="left">
                                                            Date Closed
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="Label4" />
                                                        </td>--%>
                                                    </tr>                                                   
                                                    <tr>
                                                        <td align="left">
                                                            Date Opened
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblDateOpened" />
                                                        </td>
                                                        <td align="left">
                                                            Date Closed
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblDateClosed" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Date ReOpened
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblDateReOpened" />
                                                        </td>
                                                       <%-- <td align="left">
                                                            Address1
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblEmployeeAddress1" />
                                                        </td>--%>
                                                    </tr>
                                                    <tr>
                                                        <td height="12px"></td>                                               
                                                    </tr>                                              
                                                    <tr>
                                                        <td align="left">
                                                            State of Accident
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblState" />
                                                        </td>
                                                        <%--<td align="left">
                                                            Loss Location Address
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblLossLocationAddress" />
                                                        </td>--%>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Loss Location Address
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblLossLocationAddress" />
                                                        </td>                                                        
                                                        <td align="left">
                                                            Loss Location City
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblCity" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Loss Location Zip Code
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblZip" />
                                                        </td>
                                                        <%--<td align="left">
                                                            State
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblEmployeeState" />
                                                        </td>--%>
                                                    </tr>
                                                    <tr>
                                                        <td height="12px"></td>                                               
                                                    </tr>     
                                                    <tr>
                                                        <td align="left">
                                                            VIN
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblVIN" />
                                                        </td>
                                                        <td align="left">
                                                            Vehicle Make
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblVehicleMake" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Vehicle Model
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblVehicleModel" />
                                                        </td>
                                                        <td align="left">
                                                            Vehicle Year
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblVehicleYear" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="12px"></td>                                               
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Driver Name
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblDriverName" />
                                                        </td>
                                                        <td align="left">
                                                            Claimant Telephone Number
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblClaimantTelephoneNumber" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="12px"></td>                                               
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Claimant First Name
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblClaimantFirstName" />
                                                        </td>
                                                        <td align="left">
                                                            Claimant Last Name
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblClaimantLastName" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="12px"></td>                                               
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Employee Name
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblEmployeeName" />
                                                        </td>
                                                        <td align="left">
                                                            Employee Address
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblEmployeeAddress" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Employee City
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblEmployeeCity" />
                                                        </td>
                                                        <td align="left">
                                                            Employee State
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
                                                            Employee Zip Code
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblEmployeeZip" />
                                                        </td>
                                                        <td align="left">
                                                            Employee Gender
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblEmployeeGender" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Employee SSN
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblEmployeeSSN" />
                                                        </td>
                                                        <td align="left">
                                                            Employee Marital Status
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblEmployeeMaritalStatus" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Employee Date of Birth
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblEmployeeDOB" />
                                                        </td>
                                                        <%--<td align="left">
                                                            Claimant Last Name
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="Label11" />
                                                        </td>--%>
                                                    </tr>
                                                    <tr>
                                                        <td height="12px"></td>                                               
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            State of Accident
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblStateofAccident" />
                                                        </td>
                                                        <td align="left">
                                                            State of Jurisdiction
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblStateofJurisdiction" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="12px"></td>                                               
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Date Reported to Insurer
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblDateReportedtoInsurer" />
                                                        </td>
                                                        <td align="left">
                                                            Date Entered
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblDateEntered" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="12px"></td>                                               
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Coverage Code
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblCoverageCode" />
                                                        </td>
                                                        <td align="left">
                                                            Line of Coverage
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblLineofCoverage" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="12px"></td>                                               
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Date Suit Filed
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblDateSuitFiled" />
                                                        </td>
                                                        <td align="left">
                                                            Litigation Y/N
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblLitigationYN" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="12px"></td>                                               
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            SRS Policy Number
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblSRSPolicyNumber" />
                                                        </td>
                                                        <%--<td align="left">
                                                            Policy Effective Date
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblPolicyEffectiveDate" />
                                                        </td>--%>
                                                    </tr>
                                                    <tr>

                                                        <td align="left">
                                                            Policy Effective Date
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblPolicyEffectiveDate" />
                                                        </td>
                                                        <td align="left">
                                                            Policy Expiration Date
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblPolicyExpirationDate" />
                                                        </td>                                                        
                                                    </tr>
                                                    <tr>
                                                        <td height="12px"></td>                                               
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Loss Gross Paid
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblLossGrossPaid" />
                                                        </td>
                                                        <td align="left">
                                                            Loss Net Recovered
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblLossNetRecovered" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Loss Incurred
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblLossIncurred" />
                                                        </td>
                                                        <td align="left">
                                                            Loss Outstanding
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblLossOutstanding" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Expense Gross Paid
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblExpenseGrossPaid" />
                                                        </td>
                                                        <td align="left">
                                                            Expense Net Recovered
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblExpenseNetRecovered" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Expense Incurred
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblExpenseIncurred" />
                                                        </td>
                                                        <td align="left">
                                                            Expense Outstanding
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblExpenseOutstanding" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Medical Gross Paid
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblMedicalGrossPaid" />
                                                        </td>
                                                        <td align="left">
                                                        </td>
                                                        <td align="center">                                                            
                                                        </td>
                                                        <td align="left">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="12px"></td>                                               
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Accident City/Town
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblAccidentCityTown" />
                                                        </td>
                                                        <td align="left">
                                                        </td>
                                                        <td align="center">
                                                        </td>
                                                        <td align="left">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="12px"></td>                                               
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Claims Made Indicator
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblClaimsMadeIndicator" />
                                                        </td>
                                                        <td align="left">
                                                            Claims Made Date
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblClaimsMadeDate" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Retroactive Date
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblRetroactiveDate" />
                                                        </td>
                                                        <td align="left">
                                                        </td>
                                                        <td align="center">
                                                        </td>
                                                        <td align="left">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="12px"></td>                                               
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Cause of Injury Code
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblCauseofInjuryCode" />
                                                        </td>
                                                        <td align="left">
                                                        </td>
                                                        <td align="center">
                                                        </td>
                                                        <td align="left">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="12px"></td>                                               
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Driver Age
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblDriverAge" />
                                                        </td>
                                                        <td align="left">
                                                            Driver Gender
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblDriverGender" />
                                                        </td>
                                                    </tr>
                                                   <tr>
                                                        <td height="12px"></td>                                               
                                                    </tr>
                                                     <tr>
                                                        <td align="left">
                                                            Adjustor Code
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblAdjustorCode" />
                                                        </td>
                                                        <td align="left">
                                                            Date Updated
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblDateUpdated" />
                                                        </td>
                                                    </tr>
                                                    
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlAddresses" runat="server" Width="100%" >
                                              <asp:Panel id="pnlAddressesGrid" runat="server"  >
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td valign="top" style="width: 15%">
                                                            DPD Address Grid                                                           
                                                        </td>
                                                        <td align="center" valign="top" style="width: 3%">
                                                            :
                                                        </td>
                                                        <td style="margin-left: 40px" style="width: 650px">
                                                            <asp:GridView ID="gvAddress" runat="server" AutoGenerateColumns="false" Width="100%" OnRowCommand="gvAddress_RowCommand" OnRowDataBound="gvAddress_RowDataBound">
                                                                <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                                <EmptyDataTemplate>
                                                                    <asp:Label ID="lblEmptyEmergencyMessage" runat="server" Text="No Record Found"></asp:Label>
                                                                </EmptyDataTemplate>
                                                                <Columns>                                                                   
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top" 
                                                                        HeaderText="Last Name">
                                                                        <ItemStyle Width="20%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lblLastName" runat="server" Text='<%# Eval("Last_Name") %>'
                                                                                CommandName="EditRecord" CommandArgument='<%#Eval("PK_DPD_Claims_Addresses") %>' ></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                   <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top" 
                                                                        HeaderText="First Name">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lblFirstName" runat="server" Text='<%# Eval("First_Name") %>'
                                                                                CommandName="EditRecord" CommandArgument='<%#Eval("PK_DPD_Claims_Addresses") %>' ></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top" 
                                                                        HeaderText="Address">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lblAddress" runat="server" Text='<%# Eval("Address_1") %>' 
                                                                                CommandName="EditRecord" CommandArgument='<%#Eval("PK_DPD_Claims_Addresses") %>'></asp:LinkButton>                                                                                                                                                                
                                                                            <%--<asp:LinkButton ID="lblAddress2" runat="server" Text='<%# Eval("Address_2") %>' 
                                                                                CommandName="EditRecord" CommandArgument='<%#Eval("PK_DPD_Claims_Addresses") %>'></asp:LinkButton> 
                                                                            <asp:LinkButton ID="lblCity" runat="server" Text='<%# Eval("City") %>'
                                                                                CommandName="EditRecord" CommandArgument='<%#Eval("PK_DPD_Claims_Addresses") %>'></asp:LinkButton>--%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top" 
                                                                        HeaderText="Phone">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lblPhone" runat="server" Text='<%# Eval("Phone_Number") %>'
                                                                                CommandName="EditRecord" CommandArgument='<%#Eval("PK_DPD_Claims_Addresses") %>' ></asp:LinkButton>
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
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                               </asp:Panel>
                                                 <asp:Panel id="pnlAddressesView" runat="server" Visible="false" Width="100%">
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td height="12px">
                                                        </td>
                                                    </tr>                                                                                               
                                                    <tr>
                                                        <td align="left" width="20%">
                                                            Address Number
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="26%">
                                                            <asp:Label runat="server" ID="lblAddressNumber" />
                                                        </td>          
                                                        <td align="left" width="20%">&nbsp;</td>   
                                                        <td align="center" width="4%">&nbsp;</td>   
                                                        <td align="left" width="26%">&nbsp;</td>   
                                                       
                                                    <tr>
                                                        <td height="12px" colspan="6"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            First Name
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblAddressFirstName" />
                                                        </td>
                                                        <td align="left">
                                                            Last Name
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblAddressLastName" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Address
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblAddress1" />
                                                        </td>
                                                        <td align="left">
                                                            Address 2
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblAddress2" />
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
                                                            <asp:Label runat="server" ID="lblAddressCity" />
                                                        </td>
                                                        <td align="left">
                                                            Phone Number
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblAddressPhoneNumber" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Fax Number
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblFaxNumber" />
                                                        </td>
                                                        <td align="left">
                                                            E-Mail Address
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblEmailAddress" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" align="center" style="padding-right:150px;">
                                                            <asp:button runat="server" id ="btnBackToGrid" Text="Back" OnClick="btnBackToGrid_Click" />
                                                        </td>

                                                    </tr>
                                                     <tr>
                                                        <td colspan="5"></td>
                                                    </tr>
                                                </table>

                                            </asp:Panel>
                                             </asp:Panel>
                                               
                                            <asp:Panel ID="pnlIncidents" runat="server" Width="100%">
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td valign="top" style="width: 15%">
                                                            DPD Incidents Grid                                                           
                                                        </td>
                                                        <td align="center" valign="top" style="width: 3%">
                                                            :
                                                        </td>
                                                        <td style="margin-left: 40px" style="width: 650px">
                                                            <asp:GridView ID="gvDPDIncidentsGrid" runat="server" AutoGenerateColumns="false" Width="100%">
                                                                <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                                <EmptyDataTemplate>
                                                                    <asp:Label ID="Label1" runat="server" Text="No Record Found"></asp:Label>
                                                                </EmptyDataTemplate>
                                                                <Columns>                                                                   
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top" 
                                                                        HeaderText="Field Number">
                                                                        <ItemTemplate >
                                                                            <asp:Label ID="lblFieldNumber" runat="server" Text='<%# Eval("field_Number") %>'
                                                                                 Width="80px"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                   <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                        HeaderText="Incident Category">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDPDIncidentCategory" runat="server" Text='<%# Eval("Incident_Category") %>'
                                                                                 Width="160px"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                        HeaderText="Incident Data">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblIncidentCategory" runat="server" Text='<%# Eval("Incident_Data") %>'
                                                                                 Width=""></asp:Label>
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
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlNotes" runat="server" Style="display: none;">
                                                <table border="0" cellpadding="1" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="100%" align="left">
                                                            <uc:CtrlAdjusterNotes ID="ucAdjusterNotes" runat="server" CurrentClaimType="DPD" />
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
                                                                                CommandArgument='<%#Eval("PK_Claim_Notes") %>' Width="312px" CssClass="TextClip"></asp:LinkButton>
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
                                            <asp:Panel ID="pnlDetails" runat="server">
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td height="12px"></td>                                               
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="20%">
                                                            Contact Name
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="26%">
                                                            <asp:Label runat="server" ID="lblContactName" />
                                                        </td>
                                                        <td align="left" width="20%">
                                                            Contact Home Phone
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="26%">
                                                            <asp:Label runat="server" ID="lblContactHomePhone" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Report Number
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblReportNumber" />
                                                        </td>
                                                        <td align="left">
                                                            Loss Damage Estimate
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblLossDamageEstimate" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="12px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Owner/Manufacturer Name
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblOwnerManufacturerName" />
                                                        </td>
                                                        <td align="left">
                                                            Owner/Manufacturer Home Phone
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblOwnerManufacturerHomePhone" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Owner/Manufacturer Address
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblOwnerManufacturerAddress" />
                                                        </td>
                                                        <td align="left">
                                                            Owner/Manufacturer Address 2
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblOwnerManufacturerAddress2" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="12px"></td>                                               
                                                    </tr>                                                    
                                                    <tr>
                                                        <td align="left">
                                                            Owner/Manufacturer City
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblOwnerManufacturerCity" />
                                                        </td>
                                                        <td align="left">
                                                            Owner/Manufacturer State
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblOwnerManufacturerState" />
                                                        </td>
                                                    </tr>                                                   
                                                    <tr>
                                                        <td align="left">
                                                            Owner/Manufacturer Zip Code
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblOwnerManufacturerZipCode" />
                                                        </td>
                                                        <%--<td align="left">
                                                            Owner/Manufacturer State
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="Label3" />
                                                        </td>--%>
                                                    </tr>
                                                    <tr>
                                                        <td height="12px"></td>                                               
                                                    </tr>
                                                     <tr>
                                                        <td align="left">
                                                            Vehicle Damage Description
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblVehicleDamageDescription" />
                                                        </td>
                                                       <%-- <td align="left">
                                                            Address1
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblEmployeeAddress1" />
                                                        </td>--%>
                                                    </tr>
                                                    <tr>
                                                        <td height="12px"></td>                                               
                                                    </tr>                                              
                                                    <tr>
                                                        <td align="left">
                                                            Other Vehicle Damage Estimate
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblOtherVehicleDamageEstimate" />
                                                        </td>
                                                        <%--<td align="left">
                                                            Loss Location Address
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblLossLocationAddress" />
                                                        </td>--%>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Other Vehicle Owner Name
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblOtherVehicleOwnerName" />
                                                        </td>                                                        
                                                        <td align="left">
                                                            Other Vehicle Owner Address
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblOtherVehicleOwnerAddress" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Other Vehicle Driver Address
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblOtherVehicleDriverAddress" />
                                                        </td>
                                                        <td align="left">
                                                            Other Vehicle Driver Address 2
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblOtherVehicleDriverAddress2" />
                                                        </td>
                                                    </tr>                                                        
                                                    <tr>
                                                        <td align="left">
                                                            Other Vehicle Driver Phone Number
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblOtherVehicleDriverPhoneNumber" />
                                                        </td>
                                                        <td align="left">
                                                            Other Vehicle Driver Work Phone
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblOtherVehicleDriverWorkPhone" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Other Vehicle Driver’s License Number
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblOtherVehicleDriverLicenseNumber" />
                                                        </td>
                                                        <%--<td align="left">
                                                            Vehicle Year
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="Label20" />
                                                        </td>--%>
                                                    </tr>
                                                    <tr>
                                                        <td height="12px"></td>                                               
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            First Party Vehicle Type
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblFirstPartyVehicleType" />
                                                        </td>
                                                        <td align="left">
                                                            First Party Vehicle Drivable
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblFirstPartyVehicleDrivable" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            First Party Vehicle Address
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblFirstPartyVehicleAddress" />
                                                        </td>
                                                        <td align="left">
                                                            First Party Vehicle Address 2
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblFirstPartyVehicleAddress2" />
                                                        </td>
                                                    </tr>                                                    
                                                    <tr>
                                                        <td align="left">
                                                            First Party Vehicle City
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblFirstPartyVehicleCity" />
                                                        </td>
                                                        <td align="left">
                                                            First Party Vehicle State
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblFirstPartyVehicleState" />
                                                        </td>
                                                    </tr>                                                   
                                                    <tr>
                                                        <td align="left">
                                                            Frist Party Vehicle Zip Code
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblFristPartyVehicleZipCode" />
                                                        </td>
                                                        <%--<td align="left">
                                                            Employee Address
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="Label26" />
                                                        </td>--%>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            First Party Citations Issued
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblFirstPartyCitationsIssued" />
                                                        </td>
                                                        <td align="left">
                                                            First Party Citations Issued By
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblFirstPartyCitationsIssuedBy" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            First Party Citation Number
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblFirstPartyCitationNumber" />
                                                        </td>
                                                        <%--<td align="left">
                                                            Employee Gender
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="Label30" />
                                                        </td>--%>
                                                    </tr>
                                                    <tr>
                                                        <td height="12px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Description of Property Damage
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblDescriptionofPropertyDamage" />
                                                        </td>
                                                        <%--<td align="left">
                                                            Employee Marital Status
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="Label32" />
                                                        </td>--%>
                                                    </tr>
                                                     <tr>
                                                        <td height="12px"></td>                                               
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Any Vehicles Towed
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblAnyVehiclesTowed" />
                                                        </td>
                                                        <td align="left">
                                                            When to Contact
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblWhentoContact" />
                                                        </td>
                                                    </tr>                                                    
                                                    <tr>
                                                        <td align="left">
                                                            Reported By
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblReportedBy" />
                                                        </td>
                                                        <td align="left">
                                                            Insured Vehicle Location
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblInsuredVehicleLocation" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="12px"></td>                                               
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Third Party Insurance Company
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblThirdPartyInsuranceCompany" />
                                                        </td>
                                                        <td align="left">
                                                           Third Party Insurance Policy Number
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblThirdPartyInsurancePolicyNumber" />
                                                        </td>
                                                    </tr>                                                    
                                                    <tr>
                                                        <td align="left">
                                                            Third Party Claim Number
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblThirdPartyClaimNumber" />
                                                        </td>
                                                        <%--<td align="left">
                                                            Line of Coverage
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="Label39" />
                                                        </td>--%>
                                                    </tr>                                                    
                                                    <tr>
                                                        <td align="left">
                                                            Third Party Driver’s Name
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblThirdPartyDriverName" />
                                                        </td>
                                                        <%--<td align="left">
                                                            Litigation Y/N
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="Label41" />
                                                        </td>--%>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Third Party Driver Address
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblThirdPartyDriverAddress" />
                                                        </td>
                                                        <td align="left">
                                                            Third Party Driver Address 2
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblThirdPartyDriverAddress2" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Third Party Driver City
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblThirdPartyDriverCity" />
                                                        </td>
                                                        <td align="left">
                                                            Third Party Driver State
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblThirdPartyDriverState" />
                                                        </td>                                                        
                                                    </tr>                                                    
                                                    <tr>
                                                        <td align="left">
                                                            Third Party Postal Code
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblThirdPartyPostalCode" />
                                                        </td>
                                                        <%--<td align="left">
                                                            Loss Net Recovered
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="Label46" />
                                                        </td>--%>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Third Party Driver Home Phone
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblThirdPartyDriverHomePhone" />
                                                        </td>
                                                        <td align="left">
                                                            Third Party Driver Work Phone
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblThirdPartyDriverWorkPhone" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Third Party Driver’s License Number
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblThirdPartyDriverLicenseNumber" />
                                                        </td>
                                                        <%--<td align="left">
                                                            Expense Net Recovered
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="Label50" />
                                                        </td>--%>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Third Party Vehicle Year
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblThirdPartyVehicleYear" />
                                                        </td>
                                                      <td align="left">
                                                            Third Party Vehicle Make
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblThirdPartyVehicleMake" />
                                                        </td>
                                                    </tr>
                                                    
                                                    <tr>
                                                        <td align="left">
                                                            Third Party Vehicle Model
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblThirdPartyVehicleModel" />
                                                        </td>
                                                        <td align="left">Third Party Vehicle License Plate Number
                                                        </td>
                                                        <td align="center">
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblThirdPartyVehicleLicensePlateNumber" />
                                                        </td>
                                                    </tr>
                                                    
                                                    <tr>
                                                        <td align="left">
                                                            Third Party Vehicle VIN
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblThirdPartyVehicleVIN" />
                                                        </td>
                                                        <td align="left">
                                                            Third Party Vehicle Damage Description
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblThirdPartyVehicleDamageDescription" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Third Party Vehicle Citation Issued
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblThirdPartyVehicleCitationIssued" />
                                                        </td>
                                                        <td align="left">Third Party Vehicle Citation Number
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblThirdPartyVehicleCitationNumber" />
                                                        </td>
                                                    </tr>                                                    
                                                    <tr>
                                                        <td align="left">
                                                            Third Party Vehicle Driver Wearing Seatbelt
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblThirdPartyVehicleDriverWearingSeatbelt" />
                                                        </td>
                                                        <td align="left">Third Party Driver Injury Description
                                                        </td>
                                                        <td align="center">
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblThirdPartyDriverInjuryDescription" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="12px"></td>                                               
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Third Party Vehicle Driver Owns Vehicle
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblThirdPartyVehicleDriverOwnsVehicle" />
                                                        </td>
                                                        <td align="left">
                                                           Third Party Vehicle Did Passenger Seek Medical Attention
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblThirdPartyVehicleDidPassengerSeekMedicalAttention" />
                                                        </td>
                                                    </tr>
                                                   <tr>
                                                        <td height="12px"></td>                                               
                                                    </tr>
                                                     <tr>
                                                        <td align="left">
                                                            Authority Contacted
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label runat="server" ID="lblAuthorityContacted" />
                                                        </td>                                                        
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
                        <td></td>
                        <td>
                            <table cellpadding="5" cellspacing="1" border="0" width="100%">
                                <tr>
                                    <td align="right" width="50%">
                                        <input type="button" id="btnPrev" value="Previous" style="display: none; font-weight: bold;
                                            color: #000080;" onclick="javascript: ShowPrevNext(-1);" />
                                    </td>
                                    <td align="left" width="50%">
                                        <input type="button" id="btnNext" style="font-weight: bold; color: #000080;" value="Next"
                                            onclick="javascript: ShowPrevNext(1);" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:content>
