<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Default.master" CodeFile="LetterHistory.aspx.cs"
    Inherits="Admin_LetterHistory" %>

<%@ Register Src="~/Controls/Attachment_COI/Attachment_COI.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment_COI/AttachmentDetails_COI.ascx" TagName="ctrlAttachmentDetails"
    TagPrefix="uc" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
 

    <script type="text/javascript">
        var currIndex = 1;

        function ShowPrevNext(index) {
            ShowPanel(parseInt(currIndex, 10) + parseInt(index, 10));
        }

        function SetMenuStyle(index) {
            var i;

            for (i = 1; i <= 8; i++) {
                var tb = document.getElementById("Menu" + i);
                if (i == index) {
                    tb.className = "LeftMenuSelected";
                    tb.onmouseover = function() { this.className = 'LeftMenuSelected'; }
                    tb.onmouseout = function() { this.className = 'LeftMenuSelected'; }
                }
                else {
                    tb.className = "LeftMenuStatic";
                    tb.onmouseover = function() { this.className = 'LeftMenuHover'; }
                    tb.onmouseout = function() { this.className = 'LeftMenuStatic'; }
                }
            }
            var prev = document.getElementById('<%=btnPrev.ClientID%>');
            var next = document.getElementById('<%=btnNext.ClientID%>');
            if (index == 1) {
                prev.disabled = true;
                next.disabled = false;
            }
            else if (index == 8) {
                prev.disabled = false;
                next.disabled = true;
            }
            else {
                prev.disabled = false;
                next.disabled = false;
            }

        }
        function ValSave() {
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqAttachType').enabled = false;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqFile').enabled = false;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_cstFile').enabled = false;


        }

        function ValAttach() {
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqAttachType').enabled = true;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqFile').enabled = true;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_cstFile').enabled = true;


        }

        function ConfirmDelete() {
            return confirm("Are you sure that you want to remove the data that was selected for deletion?");
        }

        function ShowPanel(index) {
            currIndex = index;
            SetMenuStyle(index);
            var i;

            if (index < 8) {
                for (i = 1; i < 8; i++) {

                    document.getElementById("ctl00_ContentPlaceHolder1_Panel" + i).style.display = "none";
                }

                document.getElementById("ctl00_ContentPlaceHolder1_Panel" + index).style.display = "block";
                //document.getElementById("ctl00_ContentPlaceHolder1_Div1").style.display="none";
                document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";

            }
            else {

                for (i = 1; i < 8; i++) {
                    document.getElementById("ctl00_ContentPlaceHolder1_Panel" + i).style.display = "none";
                }
                //document.getElementById("ctl00_ContentPlaceHolder1_Div1").style.display="block";
                document.getElementById("<%=dvAttachment.ClientID%>").style.display = "block";

            }

        }
    
        
    
    </script>

    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <div style="width: 100%" id="contmain">
        <table cellpadding="0" cellspacing="0" width="100%" align="left">
            <tr>
                <td style="width: 10px;" class="Spacer">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="leftMenu" valign="top" style="padding-left: 10px; padding-bottom: 10px">
                    <table cellpadding="3" cellspacing="0" width="203px">
                        <tr>
                            <td style="height: 10px;" class="Spacer">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="100%">
                                <span id="Menu1" onclick="javascript:ShowPanel(1);" class="LeftMenuStatic">Identification</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="100%">
                                <span id="Menu2" onclick="javascript:ShowPanel(2);" class="LeftMenuStatic">Disposition</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="100%">
                                <span id="Menu3" onclick="javascript:ShowPanel(3);" class="LeftMenuStatic">Coverage
                                    Status</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="100%">
                                <span id="Menu4" onclick="javascript:ShowPanel(4);" class="LeftMenuStatic">COI</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="100%">
                                <span id="Menu5" onclick="javascript:ShowPanel(5);" class="LeftMenuStatic">Insurance
                                    Companies</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="100%">
                                <span id="Menu6" onclick="javascript:ShowPanel(6);" class="LeftMenuStatic">Locations</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="100%">
                                <span id="Menu7" onclick="javascript:ShowPanel(7);" class="LeftMenuStatic">Specific
                                    Text</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="100%">
                                <span id="Menu8" onclick="javascript:ShowPanel(8);" class="LeftMenuStatic">Attachment</span>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 5px;" class="Spacer">
                    &nbsp;
                </td>
                <td class="dvContainer" valign="top" width="100%">
                    <table cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td class="tblGrid" align="left">
                                <asp:Panel ID="Panel1" runat="server" Style="display: block; height: 100%">
                                    <div class="bandHeaderRow">
                                        Identification</div>
                                    <table cellpadding="3" cellspacing="1" width="100%">
                                        <tr>
                                            <td width="20%" align="left" valign="top">
                                                Insured
                                            </td>
                                            <td width="2%" align="center" valign="top">
                                                :
                                            </td>
                                            <td width="26%" align="left" valign="top">
                                                <asp:Label ID="lblInsured" runat="server"></asp:Label>
                                            </td>
                                            <td width="2%">
                                                &nbsp;
                                            </td>
                                            <td width="20%" align="left">
                                                Issue Date
                                            </td>
                                            <td width="2%" align="center">
                                                :
                                            </td>
                                            <td width="26%" align="left">
                                                <asp:Label ID="lblIssueDate" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="Panel2" runat="server" Style="display: none; height: 100%">
                                    <div class="bandHeaderRow">
                                        Disposition</div>
                                    <table cellpadding="3" cellspacing="1" width="100%">
                                        <tr>
                                            <td width="20%" align="left">
                                                Date Letter Sent
                                            </td>
                                            <td width="2%" align="center">
                                                :
                                            </td>
                                            <td width="26%" align="left">
                                                <asp:Label ID="lblDateLetterSent" runat="server"></asp:Label>
                                            </td>
                                            <td width="2%">
                                                &nbsp;
                                            </td>
                                            <td width="20%" align="left">
                                                Sent by E-Mail
                                            </td>
                                            <td width="2%" align="center">
                                                :
                                            </td>
                                            <td width="26%" align="left">
                                                <asp:Label ID="lblSendByEmail" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Noncompliance Level
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left" colspan="5">
                                                <asp:Label ID="lblNoncomplianceLevel" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="Panel3" runat="server" Style="display: none; height: 100%">
                                    <div class="bandHeaderRow">
                                        Coverage Status</div>
                                    <table cellpadding="3" cellspacing="1" width="100%">
                                        <tr>
                                            <td width="20%" align="left">
                                                General
                                            </td>
                                            <td width="2%" align="center">
                                                :
                                            </td>
                                            <td width="26%" align="left">
                                                <asp:Label ID="lblGeneral" runat="server"></asp:Label>
                                            </td>
                                            <td width="2%">
                                                &nbsp;
                                            </td>
                                            <td width="20%" align="left" valign="top">
                                                Workers Compensation/Employer’s Liability
                                            </td>
                                            <td width="2%" align="center" valign="top">
                                                :
                                            </td>
                                            <td width="26%" align="left" valign="top">
                                                <asp:Label ID="lblWCLiability" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Automobile
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblAutomobile" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="left">
                                                Property
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblProperty" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Excess
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblExcess" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="left">
                                                Professional
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblProfessional" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="Panel4" runat="server" Style="display: none; height: 100%">
                                    <div class="bandHeaderRow">
                                        COI</div>
                                    <table cellpadding="3" cellspacing="1" width="100%">
                                        <tr>
                                            <td width="20%" align="left" valign="top">
                                                Original or Signed Certificate Received
                                            </td>
                                            <td width="2%" align="center" valign="top">
                                                :
                                            </td>
                                            <td width="26%" align="left" valign="top">
                                                <asp:Label ID="lblSignedCertificate" runat="server"></asp:Label>
                                            </td>
                                            <td width="2%">
                                                &nbsp;
                                            </td>
                                            <td width="20%" align="left" valign="top">
                                                Cancellation Notice Under 30 Days
                                            </td>
                                            <td width="2%" align="center" valign="top">
                                                :
                                            </td>
                                            <td width="26%" align="left" valign="top">
                                                <asp:Label ID="lblCancellationNotice" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <%--<tr>
                                                <td align="left" valign="top">Insurance is Primary and Non-Contributory with any Other Insurance – Wording Provided</td>
                                                <td align="center" valign="top">:</td>
                                                <td align="left" valign="top"><asp:Label ID="lblPrimaryProvided" runat="server"></asp:Label></td>
                                                <td>&nbsp;</td>
                                                <td align="left" valign="top">All Locations are listed on the Certificate</td>
                                                <td align="center" valign="top">:</td>
                                                <td align="left" valign="top"><asp:Label ID="lblAllLocation" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">Insured Name on Policies and Certificates same as Franchise Entity Business Name</td>
                                                <td align="center" valign="top">:</td>
                                                <td align="left" colspan="5" valign="top"><asp:Label ID="lblInsuredNameSame" runat="server"></asp:Label></td>                                                
                                            </tr>--%>
                                        <tr>
                                            <td colspan="7">
                                                <asp:DataList ID="dlComplianceView" runat="server" Width="100%" RepeatColumns="2"
                                                    RepeatDirection="Horizontal" EnableViewState="true" Visible="true" OnItemDataBound="dlComplianceTextView_ItemDataBound">
                                                    <ItemTemplate>
                                                        <table width="100%">
                                                            <tr>
                                                                <td width="17%" align="left" valign="top">
                                                                    <asp:Label ID="lblComplianceText" runat="server" Text='<%#Eval("Compliance_Text") %>'></asp:Label>
                                                                    <asp:HiddenField ID="hdnPK" runat="server" Value='<%#Eval("PK_Compliance") %>' />
                                                                </td>
                                                                <td width="2%" align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td width="25%" align="left" valign="top">
                                                                    <asp:Label ID="lblIsTurnedOn" runat="server"></asp:Label>
                                                                </td>
                                                                <td width="2%">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="Panel5" runat="server" Style="display: none; height: 100%">
                                    <div class="bandHeaderRow">
                                        Insurance Companies</div>
                                    <table cellpadding="3" cellspacing="1" width="100%">
                                        <tr>
                                            <td width="20%" align="left">
                                                No AM Best Rating
                                            </td>
                                            <td width="2%" align="center">
                                                :
                                            </td>
                                            <td width="26%" align="left">
                                                <asp:Label ID="lblAMBestRating" runat="server"></asp:Label>
                                            </td>
                                            <td width="2%">
                                                &nbsp;
                                            </td>
                                            <td width="20%" align="left">
                                                &nbsp;
                                            </td>
                                            <td width="2%" align="center">
                                                &nbsp;
                                            </td>
                                            <td width="26%" align="left">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="Panel6" runat="server" Style="display: none; height: 100%">
                                    <div class="bandHeaderRow">
                                        Locations</div>
                                    <table cellpadding="3" cellspacing="1" width="100%">
                                        <tr>
                                            <td width="20%" align="left">
                                                Ordinance or Law
                                            </td>
                                            <td width="2%" align="center">
                                                :
                                            </td>
                                            <td width="26%" align="left">
                                                <asp:Label ID="lblOrdinanceOrLaw" runat="server"></asp:Label>
                                            </td>
                                            <td width="2%">
                                                &nbsp;
                                            </td>
                                            <td width="20%" align="left">
                                                Waiver of Subrogation
                                            </td>
                                            <td width="2%" align="center">
                                                :
                                            </td>
                                            <td width="26%" align="left">
                                                <asp:Label ID="lblSubrogation" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Insured Perils – Special Form
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblInsuredPerils" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="left">
                                                100% Replacement Cost Values
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblReplacementCost" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">
                                                Evidence of Property on Acord 24, 27 or 28
                                            </td>
                                            <td align="center" valign="top">
                                                :
                                            </td>
                                            <td align="left" colspan="5" valign="top">
                                                <asp:Label ID="lblEvidence" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="Panel7" runat="server" Style="display: none; height: 100%">
                                    <div class="bandHeaderRow">
                                        Specific Text</div>
                                    <table cellpadding="3" cellspacing="1" width="100%">
                                        <tr>
                                            <td width="20%" align="left" valign="top">
                                                Level 1 Text
                                            </td>
                                            <td width="2%" align="center" valign="top">
                                                :
                                            </td>
                                            <td align="left" valign="top" colspan="5">
                                                <asp:Label ID="lblLevel1Text" runat="server" Width="97%" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">
                                                Level 2 Text
                                            </td>
                                            <td align="center" valign="top">
                                                :
                                            </td>
                                            <td align="left" valign="top" colspan="5">
                                                <asp:Label ID="lblLevel2Text" runat="server" Width="97%" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">
                                                Level 3 Text
                                            </td>
                                            <td align="center" valign="top">
                                                :
                                            </td>
                                            <td align="left" valign="top" colspan="5">
                                                <asp:Label ID="lblLevel3Text" runat="server" Width="97%" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">
                                                Level 4 Text
                                            </td>
                                            <td align="center" valign="top">
                                                :
                                            </td>
                                            <td align="left" valign="top" colspan="5">
                                                <asp:Label ID="lblLevel4Text" runat="server" Width="97%" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                    </table>
                    <div id="Div1" runat="server" style="display: none;">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td width="100%">
                                    <uc:ctrlAttachment ID="Attachment" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="Spacer" style="height: 10px;">
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btnAddAttachment" runat="server" SkinID="AddAttachment" CausesValidation="true"
                                        OnClick="btnAddAttachment_Click" ValidationGroup="AddAttachment" OnClientClick="Page_ClientValidate()" />&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="Spacer" style="height: 60px;">
                                </td>
                            </tr>
                        </table>
                    </div>
                    <asp:Panel ID="dvAttachment" runat="server" Style="display: none;">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td width="100%">
                                    <uc:ctrlAttachmentDetails ID="AttachDetails" runat="Server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="Spacer" style="height: 100px;">
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td class="Spacer" style="height: 20px;">
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td colspan="2" align="center">
                 <input id="btnPrev" runat="server" onclick="javascript:ShowPrevNext(-1);" type="button"
                                        value="Previous" style="background-position: left top; height: 22px; background-repeat: no-repeat;
                                        border-style: outset; color: Navy; font-weight: bold; cursor: pointer;" />&nbsp;
                    <asp:Button ID="btnBack" runat="server" SkinID="Back" CausesValidation="false" OnClick="btnBack_Click" />                   
                    <input id="btnNext" runat="server" onclick="javascript:ShowPrevNext(1);" style="background-position: left top;
                                        height: 22px; background-repeat: no-repeat; border-style: outset; color: Navy;
                                        font-weight: bold; cursor: pointer;" type="button" value=" Next " />                    
                </td>
            </tr>
            <tr>
                <td class="Spacer" style="height: 20px;">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
