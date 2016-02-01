<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExecutiveRisk.aspx.cs" Inherits="PropertyLiability_ExecutiveRisk"
    MasterPageFile="~/Default.master" Title="eRIMS Sonic :: Executive Risk Claim" %>

<%@ Register Src="~/Controls/ExcecutiveRiskInfo/ExecutiveRiskInfo.ascx" TagName="ctrlExecRisk"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment-ExecutiveRisk/Attachment.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment-ExecutiveRisk/AttachmentDetails.ascx" TagName="ctrlAttachmentDetails"
    TagPrefix="uc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="cnProperty_PropertyIdentification"
    runat="server">
    <script type="text/javascript" src="../JavaScript/JFunctions.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"></script>
    <script type="text/javascript" src="../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/jquery.maskedinput.js"></script>
    <script type="text/javascript">
        var ActiveTabIndex = 1;
        function onNextStep() {
            if (ActiveTabIndex == 11) {
                var sessionView = '<%=Session["ViewAll"]%>';
                if (sessionView != null && sessionView != '')
                    return true;
                else
                    return ValSave();
            }
            else {
                ActiveTabIndex = ActiveTabIndex + 1;
                ShowPanel(ActiveTabIndex);
                return false;
            }
        }
        function SetMenuStyle(index) {
            var i;
            for (i = 1; i <= 11; i++) {
                var tb = document.getElementById("ExecutiveRiskMenu" + i);
                if (i == index) {
                    tb.className = "LeftMenuSelected";
                    tb.onmouseover = function () { this.className = 'LeftMenuSelected'; }
                    tb.onmouseout = function () { this.className = 'LeftMenuSelected'; }
                }
                else {
                    tb.className = "LeftMenuStatic";
                    tb.onmouseover = function () { this.className = 'LeftMenuHover'; }
                    tb.onmouseout = function () { this.className = 'LeftMenuStatic'; }
                }

            }
        }

        function CheckClaimType() {
            var drp = document.getElementById('<%=drpTypeOfClaim.ClientID%>');
            var rfv = document.getElementById('<%=rfvOtherClaimType.ClientID%>');
            var txt = document.getElementById('<%=txtOtherClaimType.ClientID%>');
            if (drp.options[drp.selectedIndex].text == 'Other') {
                ValidatorEnable(rfv, true);
            }
            else {
                txt.value = '';
                ValidatorEnable(rfv, false);
            }
        }

        function ValSave() {
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqAttachType').enabled = false;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqFile').enabled = false;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_cstFile').enabled = false;

            if (document.getElementById('<%=txtTelephone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtTelephone.ClientID%>').value = "";
            if (Page_ClientValidate())
                return true;
            else
                return false;
        }

        function ValAttach() {
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqAttachType').enabled = true;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_reqFile').enabled = true;
            document.getElementById('ctl00_ContentPlaceHolder1_Attachment_cstFile').enabled = true;
            if (document.getElementById('<%=txtTelephone.ClientID%>').value == "___-___-____")
                document.getElementById('<%=txtTelephone.ClientID%>').value = "";

            if (Page_ClientValidate())
                return true;
            else
                return false;
        }

        function ConfirmDelete() {
            return confirm("Are you sure you want to delete this record?");
        }

        function ShowPanel(index) {
            SetMenuStyle(index);
            ActiveTabIndex = index;
            var op = '<%=StrOperation%>';
            if (op == "view") {
                document.getElementById("<%=dvSave.ClientID %>").style.display = "none";
                document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
                ShowPanelView(index);
            }
            else {
                var i;
                if (index < 11) {
                    document.getElementById("<%=pnlClaimIdentification.ClientID%>").style.display = (index == 1) ? "block" : "none";
                    for (i = 2; i <= 10; i++) {
                        document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display = (i == index) ? "block" : "none";
                    }
                    document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "none";
                }
                else {
                    for (i = 2; i <= 10; i++) {
                        document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i).style.display = "none";
                    }
                    document.getElementById("<%=pnlClaimIdentification.ClientID%>").style.display = "none";
                    document.getElementById("<%=dvAttachment.ClientID%>").style.display = "block";
                    document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "block";
                }
            }
        }

        function ShowPanelView(index) {
            SetMenuStyle(index);
            document.getElementById('<%=dvView.ClientID%>').style.display = "block";
            var i;
            if (index < 11) {
                document.getElementById("<%=pnlClaimIdentificationView.ClientID%>").style.display = (index == 1) ? "block" : "none";
                for (i = 2; i <= 10; i++) {
                    if (i == 6)
                        document.getElementById("ctl00_ContentPlaceHolder1_pnl6").style.display = (i == index) ? "block" : "none";
                    else if (i == 7)
                        document.getElementById("ctl00_ContentPlaceHolder1_pnl7").style.display = (i == index) ? "block" : "none";
                    else
                        document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i + "view").style.display = (i == index) ? "block" : "none";
                }
                document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "none";


            }
            else {
                for (i = 2; i <= 10; i++) {
                    if (i == 6)
                        document.getElementById("ctl00_ContentPlaceHolder1_pnl6").style.display = "none";
                    else if (i == 7)
                        document.getElementById("ctl00_ContentPlaceHolder1_pnl7").style.display = "none";
                    else
                        document.getElementById("ctl00_ContentPlaceHolder1_pnl" + i + "View").style.display = "none";
                }
                document.getElementById("<%=pnlClaimIdentificationView.ClientID%>").style.display = "none";
                document.getElementById("<%=dvAttachment.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlAttachmentDetails.ClientID%>").style.display = "block";

            }
        }

        function NavigateCarrierPage(PK) {
            var FK = '<%=PK_Executive_Risk%>';
            if (FK > 0) {
                if (PK == 0)
                    window.location.href = '<%=AppConfig.SiteURL%>ExecutiveRisk/ExecutiveRiskCarrier.aspx?eid=' + FK;
                else
                    window.location.href = '<%=AppConfig.SiteURL%>ExecutiveRisk/ExecutiveRiskCarrier.aspx?eid=' + FK + '&op=<%=StrOperation%>&id=' + PK;
            }
            else
                alert("Please Enter Executive Risk Information");
        }


        function NavigateDefensePage(PK) {
            var FK = '<%=PK_Executive_Risk%>';
            if (FK > 0) {
                if (PK == 0)
                    window.location.href = '<%=AppConfig.SiteURL%>ExecutiveRisk/DefenseAttorney.aspx?eid=' + FK;
                else
                    window.location.href = '<%=AppConfig.SiteURL%>ExecutiveRisk/DefenseAttorney.aspx?eid=' + FK + '&op=<%=StrOperation%>&id=' + PK;
            }
            else
                alert("Please Enter Executive Risk Information");
        }

        function NavigatePlaintiffPage(PK) {
            var FK = '<%=PK_Executive_Risk%>';
            if (FK > 0) {
                if (PK == 0)
                    window.location.href = '<%=AppConfig.SiteURL%>ExecutiveRisk/PlaintiffAttorney.aspx?eid=' + FK;
                else
                    window.location.href = '<%=AppConfig.SiteURL%>ExecutiveRisk/PlaintiffAttorney.aspx?eid=' + FK + '&op=<%=StrOperation%>&id=' + PK;
            }
            else
                alert("Please Enter Executive Risk Information");
        }

        function NavigateExpensePage(PK) {
            var FK = '<%=PK_Executive_Risk%>';
            if (FK > 0) {
                if (PK == 0)
                    window.location.href = '<%=AppConfig.SiteURL%>ExecutiveRisk/ExecutiveRiskExpenses.aspx?eid=' + FK;
                else
                    window.location.href = '<%=AppConfig.SiteURL%>ExecutiveRisk/ExecutiveRiskExpenses.aspx?eid=' + FK + '&op=<%=StrOperation%>&id=' + PK;
            }
            else
                alert("Please Enter Executive Risk Information");
        }

        function OpenEntityPopUp() {
            var txtID;
            //window.open("<%=AppConfig.SiteURL%>/ExecutiveRisk/SearchPopup.aspx?search=1&txtID=" + txtID,"Search","location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=600,height=450");
            ShowDialog("<%=AppConfig.SiteURL%>/ExecutiveRisk/SearchPopup.aspx?search=1&txtID=" + txtID);
            return false;
        }
        function AuditPopUp() {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;

            obj = window.open("AuditPopup_ExecutiveRisk.aspx?id=" + '<%=ViewState["PK_Executive_Risk"]%>' + '&Table_Name=Executive_Risk', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }

        function ValidateFields(sender, args) {
            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnControlIDs.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnErrorMsgs.ClientID%>').value.split(',');
            if (document.getElementById('<%=hdnControlIDs.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {
                        case "textarea":
                        case "text": if (ctrl.value == '') bEmpty = true; break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                        case "select-multiple": if (ctrl.selectedIndex == -1) bEmpty = true; break;
                    }
                    if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                }
                if (msg.length > 0) {
                    sender.errormessage = msg;
                    args.IsValid = false;
                }
                else
                    args.IsValid = true;
            }
            else {
                args.IsValid = true;
            }
        }

        jQuery(function ($) {
            $("#<%=txtDateClaimOpened.ClientID%>").mask("99/99/9999");
            $("#<%=txtDateClaimClosed.ClientID%>").mask("99/99/9999");
            $("#<%=txtDateClaimReopened.ClientID%>").mask("99/99/9999");
            $("#<%=txtDateLetterReceived.ClientID%>").mask("99/99/9999");
            $("#<%=txtDateComplaintFiled.ClientID%>").mask("99/99/9999");
            $("#<%=txtDateSuitServed.ClientID%>").mask("99/99/9999");
            $("#<%=txtPrimaryPolicyEffectiveDate.ClientID%>").mask("99/99/9999");
            $("#<%=txtPrimaryPolicyExpirationDate.ClientID%>").mask("99/99/9999");
            $("#<%=txtDateAllegedWrongfulAct.ClientID%>").mask("99/99/9999");
            $("#<%=txtDateComplaintReceived.ClientID%>").mask("99/99/9999");
            $("#<%=txtDateLegalReceivedComplaint.ClientID%>").mask("99/99/9999");
            $("#<%=txtDateRiskMgmtReceivedComplaint.ClientID%>").mask("99/99/9999");
            $("#<%=txtDateCarrierNotified.ClientID%>").mask("99/99/9999");
            $("#<%=txtDateBrokerReceivedComplaint.ClientID%>").mask("99/99/9999");
            $("#<%=txtDateHRReceivedComplaint.ClientID%>").mask("99/99/9999");
            $("#<%=txtDateAcknowledgementByPrimaryCarrier.ClientID%>").mask("99/99/9999");
            $("#<%=txtDemandExposureDate.ClientID%>").mask("99/99/9999");
            $("#<%=txtEstimatedDefenseExpenseDate.ClientID%>").mask("99/99/9999");
            $("#<%=txtActualSettlementDate.ClientID%>").mask("99/99/9999");
            $("#<%=txtActualDefenseExpenseDate.ClientID%>").mask("99/99/9999");
            $("#<%=txtTelephone.ClientID%>").mask("999-999-9999");
        });
    </script>
    <script language="javascript" type="text/javascript">
        function CheckTodayDate(sender, args) {
            args.IsValid = (CompareDateLessThanTodayNoAlert(args.Value));
            return args.IsValid;
        }
    </script>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="ghc" align="left">
                Executive Risk Claim
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="Spacer" style="height: 15px;" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" colspan="2">
                            <uc:ctrlExecRisk ID="ExecutiveRiskInfo" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" style="height: 15px;" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td class="leftMenu">
                            <table cellpadding="0" cellspacing="0" width="203px">
                                <tr>
                                    <td style="height: 10px;" class="Spacer">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Menu ID="mnuExecutiveRisk" runat="server" DataSourceID="dsSiteMap" StaticEnableDefaultPopOutImage="false">
                                            <StaticItemTemplate>
                                                <table cellpadding="5" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="100%">
                                                            <span id="ExecutiveRiskMenu<%#Container.ItemIndex+1%>" onclick="javascript:ShowPanel(<%#Container.ItemIndex+1%>);"
                                                                class="LeftMenuStatic">
                                                                <%#Eval("Text")%>
                                                            </span>
                                                             <asp:Label ID="MenuAsterisk" runat="server" Text="*" style="color: Red;display:none"  ></asp:Label> 
                                                        </td>
                                                    </tr>
                                                </table>
                                            </StaticItemTemplate>
                                        </asp:Menu>
                                        <asp:SiteMapDataSource ID="dsSiteMap" runat="server" SiteMapProvider="ExecutiveRiskMenuProvider"
                                            ShowStartingNode="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 10px;" class="Spacer">
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top" width="100%">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td width="5px">
                                        &nbsp;
                                    </td>
                                    <td class="dvContainer" style="height:280px;" valign="top">
                                        <div id="dvEdit" runat="server" width="794px">
                                            <asp:Panel ID="pnlClaimIdentification" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Claim Identification</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="16%">
                                                            <asp:Label ID="lblClaimNumberHeading" runat="server" Text="Claim Number" />
                                                        </td>
                                                        <td align="center" width="3%">
                                                            <asp:Label ID="lblSeperator" runat="server" Text=":" />
                                                        </td>
                                                        <td align="left" width="30%">
                                                            <asp:Label ID="lblClaimNumber" runat="server"></asp:Label>&nbsp;
                                                            <asp:Label ID="lblTempClaimNumber" runat="server" Text="(Temp Claim No.)" Visible="false" />
                                                        </td>
                                                        <td align="left" width="15%">
                                                            Sonic Location Code&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="3%">
                                                            :
                                                        </td>
                                                        <td align="left" width="32%">
                                                            <asp:DropDownList ID="ddlRMLocationNumber" AutoPostBack="true" Width="195px" SkinID="dropGen"
                                                                runat="server" OnSelectedIndexChanged="ddlRMLocationNumber_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Type Of Claim&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="drpTypeOfClaim" Width="170px" runat="server" onchange="CheckClaimType();">
                                                            </asp:DropDownList>                                                           
                                                        </td>
                                                        <%--<td align="left">
                                                            Legal Entity&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList runat="server" ID="ddlLegalEntity" Width="195px" AutoPostBack="true"
                                                                SkinID="dropGen" OnSelectedIndexChanged="ddlLegalEntity_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>--%>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            If Other, please specify&nbsp;<span id="Span4" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtOtherClaimType" runat="server" Width="180px" MaxLength="50" />
                                                            <asp:RequiredFieldValidator ID="rfvOtherClaimType" runat="server" ControlToValidate="txtOtherClaimType"
                                                                Enabled="false" Display="none" ErrorMessage="Please Select [Claim Identification]/Other Claim Type"
                                                                SetFocusOnError="true" ValidationGroup="vsErrorGroup" />
                                                        </td>
                                                        <td align="left">
                                                            Location d/b/a&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList runat="server" ID="ddlLocationdba" Width="195px" AutoPostBack="true"
                                                                SkinID="dropGen" OnSelectedIndexChanged="ddlLocationdba_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Type of Allegation&nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <%--<asp:DropDownList ID="drpTypeOfAllegation" Width="180px" runat="server" SkinID="Default" />--%>
                                                            <asp:ListBox ID="lstFK_Type_Of_ER_Allegation"  runat="server" Rows="5" SelectionMode="Multiple"
                                                            Width="190px"></asp:ListBox>
                                                        </td>
                                                        <td align="left">
                                                            Entity&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="ddlEntity" runat="server" SkinID="dropGen" Width="195px" OnSelectedIndexChanged="ddlEntity_SelectedIndexChanged"
                                                                AutoPostBack="true">
                                                            </asp:DropDownList>                                                           
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Legal File Number&nbsp;<span id="Span8" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="3">
                                                            <asp:TextBox ID="txtLegalFileNumber" runat="server" Width="175px" MaxLength="30" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Complainant/Plaintiff&nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtComplaintant" runat="server" Width="180px" MaxLength="50"></asp:TextBox>
                                                            <%--<asp:RequiredFieldValidator ID="rfvComplaintant" runat="server" ControlToValidate="txtComplaintant"
                                                                Display="none" Text="*" ErrorMessage="Please Enter [Claim Identification]/Complainant"
                                                                SetFocusOnError="true" ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>--%>
                                                        </td>
                                                        <td align="left">
                                                            Defendant&nbsp;<span id="Span10" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtDefendant" runat="server" Width="195px" MaxLength="50"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Claim Description&nbsp;<span id="Span11" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="txtClaimDescription" runat="server" IsRequired="false"
                                                                RequiredFieldMessage="Please enter [Claim Identification]/Claim Description"
                                                                ValidationGroup="vsErrorGroup" />
                                                        </td>
                                                    </tr>                                                   
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl2" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Claim Status</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Date Claim Opened&nbsp;<span id="Span12" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:TextBox ID="txtDateClaimOpened" runat="server"></asp:TextBox>
                                                            <img alt="Date Claim Opened" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDateClaimOpened', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                align="middle" /><br />
                                                            <asp:RegularExpressionValidator ID="revDateClaimOpened" runat="server" ControlToValidate="txtDateClaimOpened"
                                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                ErrorMessage="[Claim Status]/Date Claim Opened Not Valid" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                            <asp:CustomValidator ID="csmvtxtDateClaimOpened" runat="server" ControlToValidate="txtDateClaimOpened"
                                                                ErrorMessage="[Claim Status]/Claim Opened Date must not be greater than current date"
                                                                ClientValidationFunction="CheckTodayDate" Display="none" ValidationGroup="vsErrorGroup">
                                                            </asp:CustomValidator>
                                                            <asp:CompareValidator ID="cvCompServiceDate" runat="server" ControlToValidate="txtDateClaimClosed"
                                                                ValidationGroup="vsErrorGroup" ErrorMessage="[Claim Status]/Claim Closed Date Must Be Greater Than or Equal To [Claim Status]/Claim Opened Date."
                                                                Type="Date" Operator="GreaterThanEqual" ControlToCompare="txtDateClaimOpened"
                                                                Display="none">
                                                            </asp:CompareValidator>
                                                        </td>
                                                        <td align="left" width="18%">
                                                            Date Claim Closed&nbsp;<span id="Span13" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:TextBox ID="txtDateClaimClosed" runat="server"></asp:TextBox>
                                                            <img alt="Date Claim Closed" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDateClaimClosed', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                align="middle" /><br />
                                                            <asp:RegularExpressionValidator ID="revDateClaimClosed" runat="server" ControlToValidate="txtDateClaimClosed"
                                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                ErrorMessage="[Claim Status]/Date Claim Closed Not Valid" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Date Claim Reopened&nbsp;<span id="Span14" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:TextBox ID="txtDateClaimReopened" runat="server"></asp:TextBox>
                                                            <img alt="Date Claim Reopened" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDateClaimReopened', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                align="middle" /><br />
                                                            <asp:RegularExpressionValidator ID="revDateClaimReopened" runat="server" ControlToValidate="txtDateClaimReopened"
                                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                ErrorMessage="[Claim Status]/Date Claim Reopened Not Valid" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                            <asp:CompareValidator ID="cvReopnNopen" runat="server" ControlToValidate="txtDateClaimReopened"
                                                                ValidationGroup="vsErrorGroup" ErrorMessage="[Claim Status]/Claim Reopened Date Must Be Greater Than or Equal to [Claim Status]/Claim Opened Date."
                                                                Type="Date" Operator="GreaterThanEqual" ControlToCompare="txtDateClaimOpened"
                                                                Display="none">
                                                            </asp:CompareValidator>
                                                            <asp:CompareValidator ID="cvReopnNclose" runat="server" ControlToValidate="txtDateClaimReopened"
                                                                ValidationGroup="vsErrorGroup" ErrorMessage="[Claim Status]/Claim Reopened Date Must Be Greater Than or Equal to [Claim Status]/Claim Closed Date."
                                                                Type="Date" Operator="GreaterThanEqual" ControlToCompare="txtDateClaimClosed"
                                                                Display="none">
                                                            </asp:CompareValidator>
                                                        </td>
                                                        <td align="left" width="18%">
                                                            Bordereau Report?
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:RadioButtonList ID="rdoBordereauReport" runat="server" SkinID="YesNoType">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Claim Status/Comments&nbsp;<span id="Span15" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="txtClaimStatus" runat="server" />
                                                        </td>
                                                    </tr>                                                  
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl3" runat="server" Style="display: none;height:300px;">
                                                <div class="bandHeaderRow">
                                                    Filing</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%" >
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            EEOC?
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:RadioButtonList ID="rdoEEOC" runat="server" SkinID="YesNoType">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left" width="18%">
                                                            State Employment Commission&nbsp;<span id="Span16" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:TextBox ID="txtStateEmploymentComission" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Letter of Representation Received?
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:RadioButtonList ID="rdoLetterReceived" runat="server" SkinID="YesNoType">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left" width="18%">
                                                            Date Letter of Representation Received&nbsp;<span id="Span17" style="color: Red;
                                                                display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:TextBox ID="txtDateLetterReceived" runat="server"></asp:TextBox>
                                                            <img alt="Date Letter Received" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDateLetterReceived', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                align="middle" /><br />
                                                             <asp:RegularExpressionValidator ID="revDateLetterReceived" runat="server" ControlToValidate="txtDateLetterReceived"
                                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                ErrorMessage="[Filing]/Date Letter of Representation Received Not Valid" Display="none"
                                                                ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                            <asp:CustomValidator ID="csmvtxtDateLetterReceived" runat="server" ControlToValidate="txtDateLetterReceived"
                                                                ErrorMessage="[Filing]/Date Letter of Representation Received Date must not be greater than current date"
                                                                ClientValidationFunction="CheckTodayDate" Display="none" ValidationGroup="vsErrorGroup">
                                                            </asp:CustomValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Security Litigation?
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:RadioButtonList ID="rdoSecurityLitigation" runat="server" SkinID="YesNoType">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="left" width="18%">
                                                            Other Litigation?
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:RadioButtonList ID="rdoOtherLitigation" runat="server" SkinID="YesNoType">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Jurisdiction&nbsp;<span id="Span18" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:TextBox ID="txtJuridiction" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Date Complaint/Suit Filed&nbsp;<span id="Span19" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:TextBox ID="txtDateComplaintFiled" runat="server"></asp:TextBox>
                                                            <img alt="Date Complaint Filed" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDateComplaintFiled', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                align="middle" /><br />
                                                            <asp:RegularExpressionValidator ID="revDateComplaintFiled" runat="server" ControlToValidate="txtDateComplaintFiled"
                                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                ErrorMessage="[Filing]/Date Complaint/Suit Filed Not Valid" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                            <asp:CustomValidator ID="csmvtxtDateComplaintFiled" runat="server" ControlToValidate="txtDateComplaintFiled"
                                                                ErrorMessage="[Filing]/Date Complaint/Suit Filed Date must not be greater than current date"
                                                                ClientValidationFunction="CheckTodayDate" Display="none" ValidationGroup="vsErrorGroup">
                                                            </asp:CustomValidator>
                                                        </td>
                                                        <td align="left" width="18%">
                                                            Date Suit Served&nbsp;<span id="Span20" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:TextBox ID="txtDateSuitServed" runat="server"></asp:TextBox>
                                                            <img alt="Date Suit Served" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDateSuitServed', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                align="middle" /><br />
                                                             <asp:RegularExpressionValidator ID="revDateSuitServed" runat="server" ControlToValidate="txtDateSuitServed"
                                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                ErrorMessage="[Filing]/Date Suit Served Not Valid" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                            <asp:CompareValidator ID="cvDateSuitServed" runat="server" ControlToCompare="txtDateComplaintFiled"
                                                                ControlToValidate="txtDateSuitServed" Display="None" ErrorMessage="Date Suit Served should be greater than or equal to Date Complaint/Suit Filed"
                                                                Operator="GreaterThanEqual" Type="Date" ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Case Number&nbsp;<span id="Span21" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:TextBox ID="txtCaseNumber" runat="server" Width="170px" MaxLength="30"></asp:TextBox>
                                                        </td>
                                                    </tr>                                                   
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl4" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Insurance Profile</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Primary Insurance Claim Number&nbsp;<span id="Span22" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:TextBox ID="txtPrimaryClaimNumber" runat="server" Width="170px" MaxLength="30"></asp:TextBox>
                                                        </td>
                                                        <td align="left" width="18%">
                                                            Primary Insurance Policy Number&nbsp;<span id="Span23" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:TextBox ID="txtPrimaryPolicyNumber" runat="server" Width="170px" MaxLength="30"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Primary Policy Effective Date&nbsp;<span id="Span24" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:TextBox ID="txtPrimaryPolicyEffectiveDate" runat="server"></asp:TextBox>
                                                            <img alt="Primary Policy Effective Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPrimaryPolicyEffectiveDate', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                align="middle" /><br />
                                                            <asp:RegularExpressionValidator ID="revPrimaryPolicyEffectiveDate" runat="server"
                                                                ControlToValidate="txtPrimaryPolicyEffectiveDate" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                ErrorMessage="[Insurance Profile]/Primary Policy Effective Date Not Valid" Display="none"
                                                                ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" width="18%">
                                                            Primary Policy Expiration Date&nbsp;<span id="Span25" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:TextBox ID="txtPrimaryPolicyExpirationDate" runat="server"></asp:TextBox>
                                                            <img alt="Date Suit Served" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPrimaryPolicyExpirationDate', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                align="middle" /><br />
                                                             <asp:RegularExpressionValidator ID="revPrimaryPolicyExpirationDate" runat="server"
                                                                ControlToValidate="txtPrimaryPolicyExpirationDate" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                ErrorMessage="[Insurance Profile]/Primary Policy Expiration Date Not Valid" Display="none"
                                                                ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Total Program Limit&nbsp;<span id="Span26" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:TextBox ID="txtTotalProgramLimit" runat="server" Width="170px" onpaste="return false"
                                                                onkeypress="return FormatNumber(event,this.id,13,true);"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="regTotalProgramLimit" ControlToValidate="txtTotalProgramLimit"
                                                                runat="server" ErrorMessage="Please enter [Insurance Profile]/Total Program Limit in proper format"
                                                                ValidationGroup="vsErrorGroup" Display="none" ValidationExpression="^\d{1,3}(,\d\d\d)*$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Primary Deductable&nbsp;<span id="Span27" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:TextBox ID="txtPrimaryDeductable" runat="server" Width="170px" onpaste="return false"
                                                                onkeypress="return FormatNumber(event,this.id,13,true);"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="regPrimaryDeductable" ControlToValidate="txtPrimaryDeductable"
                                                                runat="server" ErrorMessage="Please enter [Insurance Profile]/Primary Deductable in proper format"
                                                                ValidationGroup="vsErrorGroup" Display="none" ValidationExpression="^\d{1,3}(,\d\d\d)*$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" width="18%">
                                                            Allocation&nbsp;<span id="Span28" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:TextBox ID="txtAllocation" runat="server" Width="170px" onpaste="return false"
                                                                onkeypress="return FormatNumber(event,this.id,13,true);"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="regAllocation" ControlToValidate="txtAllocation"
                                                                runat="server" ErrorMessage="Please enter [Insurance Profile]/Allocation in proper format"
                                                                ValidationGroup="vsErrorGroup" Display="none" ValidationExpression="^\d{1,3}(,\d\d\d)*$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Carrier Grid
                                                            <br />
                                                            <asp:LinkButton ID="lnkCarrierAdd" runat="server" Text="--Add--" OnClick="lnkCarrierAdd_Click"
                                                                ValidationGroup="vsErrorGroup" CausesValidation="true">
                                                                <%--OnClientClick="return ValSave();"--%>
                                                            </asp:LinkButton>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <asp:GridView ID="gvCarrier" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                OnRowCommand="gvCarrier_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Carrier">
                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigateCarrierPage(<%#Eval("PK_Executive_Risk_Carrier")%>)">
                                                                                <%#Eval("Carrier")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Layer">
                                                                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigateCarrierPage(<%#Eval("PK_Executive_Risk_Carrier")%>)">
                                                                                <%# Eval("FK_Layer") != DBNull.Value ? new ERIMS.DAL.Layer(Convert.ToDecimal(Eval("FK_Layer"))).Fld_Desc : string.Empty %>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Limit - $">
                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigateCarrierPage(<%#Eval("PK_Executive_Risk_Carrier")%>)">
                                                                                <%# clsGeneral.GetStringValue(Convert.ToDecimal(Eval("Limit"))).Replace(".00","")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Contact Name">
                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigateCarrierPage(<%#Eval("PK_Executive_Risk_Carrier")%>)">
                                                                                <%#Eval("Contact_Name")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Contact Number">
                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigateCarrierPage(<%#Eval("PK_Executive_Risk_Carrier")%>)">
                                                                                <%#Eval("Contact_Number")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Claim Number">
                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigateCarrierPage(<%#Eval("PK_Executive_Risk_Carrier")%>)">
                                                                                <%#Eval("Claim_Number")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CommandName="RemoveCarrier"
                                                                                CommandArgument='<%#Eval("PK_Executive_Risk_Carrier")%>' OnClientClick="return ConfirmDelete();"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <asp:Label ID="lblEmptyEmergencyMessage" runat="server" Text="No Record Found"></asp:Label>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>                                                   
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl5" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Key Dates</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Date of Alleged Wrongful Act&nbsp;<span id="Span29" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:TextBox ID="txtDateAllegedWrongfulAct" runat="server"></asp:TextBox>
                                                            <img alt="Date Alleged Wrongful Act" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDateAllegedWrongfulAct', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                align="middle" /><br />
                                                            <asp:RegularExpressionValidator ID="revDateAllegedWrongfulAct" runat="server" ControlToValidate="txtDateAllegedWrongfulAct"
                                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                ErrorMessage="[Key Dates]/Date of Alleged Wrongful Act Not Valid" Display="none"
                                                                ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                            <asp:CompareValidator ID="cvDateAllegedWrongfulAct1" ControlToCompare="txtDateComplaintReceived"
                                                                ControlToValidate="txtDateAllegedWrongfulAct" Display="None" ErrorMessage="[Key Dates] / Date of Alleged Wrongful Act must be less than or equal to Date Of Complaint Received"
                                                                Operator="LessThanEqual" runat="server" Type="Date" ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                                                            <asp:CompareValidator ID="cvDateLegalReceivedComplaint" ControlToCompare="txtDateLegalReceivedComplaint"
                                                                ControlToValidate="txtDateAllegedWrongfulAct" Display="None" ErrorMessage="[Key Dates] / Date of Alleged Wrongful Act must be less than or equal to Date Legal Received Complaint"
                                                                Operator="LessThanEqual" runat="server" Type="Date" ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                                                            <asp:CompareValidator ID="cvDateRiskMgmtReceivedComplaint" ControlToCompare="txtDateRiskMgmtReceivedComplaint"
                                                                ControlToValidate="txtDateAllegedWrongfulAct" Display="None" ErrorMessage="[Key Dates] / Date of Alleged Wrongful Act must be less than or equal to Date Risk Management Received Complaint"
                                                                Operator="LessThanEqual" runat="server" Type="Date" ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                                                            <asp:CompareValidator ID="cvDateBrokerReceivedComplaint" ControlToCompare="txtDateBrokerReceivedComplaint"
                                                                ControlToValidate="txtDateAllegedWrongfulAct" Display="None" ErrorMessage="[Key Dates] / Date of Alleged Wrongful Act must be less than or equal to Date Broker Received Complaint"
                                                                Operator="LessThanEqual" runat="server" Type="Date" ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                                                            <asp:CompareValidator ID="cvDateCarrierNotified" ControlToCompare="txtDateCarrierNotified"
                                                                ControlToValidate="txtDateAllegedWrongfulAct" Display="None" ErrorMessage="[Key Dates] / Date of Alleged Wrongful Act must be less than or equal to Date Carrier(s) Notified"
                                                                Operator="LessThanEqual" runat="server" Type="Date" ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                                                            <asp:CompareValidator ID="cvDateAcknowledgementByPrimaryCarrier1" ControlToCompare="txtDateAcknowledgementByPrimaryCarrier"
                                                                ControlToValidate="txtDateAllegedWrongfulAct" Display="None" ErrorMessage="[Key Dates] / Date of Alleged Wrongful Act must be less than or equal to all Date Acknowledgement By Primary Carrier"
                                                                Operator="LessThanEqual" runat="server" Type="Date" ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                                                        </td>
                                                        <td align="left" width="18%">
                                                            Date Complaint Received&nbsp;<span id="Span30" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:TextBox ID="txtDateComplaintReceived" runat="server"></asp:TextBox>
                                                            <img alt="Date Complaint Received" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDateComplaintReceived', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                align="middle" /><br />
                                                            <asp:RegularExpressionValidator ID="revDateComplaintReceived" runat="server" ControlToValidate="txtDateComplaintReceived"
                                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                ErrorMessage="[Key Dates]/Date Complaint Received Not Valid" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                            <asp:CompareValidator ID="CompareValidator1" ControlToCompare="txtDateAllegedWrongfulAct"
                                                                ControlToValidate="txtDateComplaintReceived" Display="None" ErrorMessage="[Key Dates] / Date Complaint Received must be greater than or equal to Data of Alleged Wrongful Act"
                                                                Operator="GreaterThanEqual" runat="server" Type="Date" ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                                                            <asp:CompareValidator ID="CompareValidator2" ControlToCompare="txtDateLegalReceivedComplaint"
                                                                ControlToValidate="txtDateComplaintReceived" Display="None" ErrorMessage="[Key Dates] / Date Complaint Received must be less than or equal to Date Legal Received Complaint"
                                                                Operator="LessThanEqual" runat="server" Type="Date" ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                                                            <asp:CompareValidator ID="CompareValidator3" ControlToCompare="txtDateRiskMgmtReceivedComplaint"
                                                                ControlToValidate="txtDateComplaintReceived" Display="None" ErrorMessage="[Key Dates] / Date Complaint Received must be less than or equal to Date Risk Management Received Complaint"
                                                                Operator="LessThanEqual" runat="server" Type="Date" ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                                                            <asp:CompareValidator ID="CompareValidator4" ControlToCompare="txtDateBrokerReceivedComplaint"
                                                                ControlToValidate="txtDateComplaintReceived" Display="None" ErrorMessage="[Key Dates] / Date Complaint Received must be less than or equal to Date Broker Received Complaint"
                                                                Operator="LessThanEqual" runat="server" Type="Date" ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                                                            <asp:CompareValidator ID="CompareValidator5" ControlToCompare="txtDateCarrierNotified"
                                                                ControlToValidate="txtDateComplaintReceived" Display="None" ErrorMessage="[Key Dates] / Date Complaint Received must be less than or equal to Date Carrier(s) Notified"
                                                                Operator="LessThanEqual" runat="server" Type="Date" ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                                                            <asp:CompareValidator ID="CompareValidator6" ControlToCompare="txtDateAcknowledgementByPrimaryCarrier"
                                                                ControlToValidate="txtDateAllegedWrongfulAct" Display="None" ErrorMessage="[Key Dates] / Date Complaint Received must be less than or equal to Date Acknowledgement By Primary Carrier"
                                                                Operator="LessThanEqual" runat="server" Type="Date" ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Date Legal Received Complaint&nbsp;<span id="Span31" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:TextBox ID="txtDateLegalReceivedComplaint" runat="server"></asp:TextBox>
                                                            <img alt="Date Legal Received Complaint" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDateLegalReceivedComplaint', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                align="middle" /><br />
                                                            <asp:RegularExpressionValidator ID="revDateLegalReceivedComplaint" runat="server"
                                                                ControlToValidate="txtDateLegalReceivedComplaint" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                ErrorMessage="[Key Dates]/Date Legal Received Complaint Not Valid" Display="none"
                                                                ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" width="18%">
                                                            Date Risk Management Received Complaint&nbsp;<span id="Span32" style="color: Red;
                                                                display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:TextBox ID="txtDateRiskMgmtReceivedComplaint" runat="server"></asp:TextBox>
                                                            <img alt="Date Risk Management Received Complaint" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDateRiskMgmtReceivedComplaint', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                align="middle" /><br />
                                                            <asp:RegularExpressionValidator ID="revDateRiskMgmtReceivedComplaint" runat="server"
                                                                ControlToValidate="txtDateRiskMgmtReceivedComplaint" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                ErrorMessage="[Key Dates]/Date Risk Management Received Complaint Not Valid"
                                                                Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Person Who Received Complaint in Legal&nbsp;<span id="Span33" style="color: Red;
                                                                display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtLegalComplaintRecipient" runat="server" MaxLength="50" />
                                                        </td>
                                                        <td align="left" width="18%">
                                                            Date Carrier(s) Notified&nbsp;<span id="Span34" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:TextBox ID="txtDateCarrierNotified" runat="server"></asp:TextBox>
                                                            <img alt="Date Carrier(s) Notified" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDateCarrierNotified', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                align="middle" /><br />
                                                            <asp:RegularExpressionValidator ID="revDateCarrierNotified" runat="server" ControlToValidate="txtDateCarrierNotified"
                                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                ErrorMessage="[Key Dates]/Date Carrier(s) Notified Not Valid" Display="none"
                                                                ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Date Broker Received Complaint&nbsp;<span id="Span35" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:TextBox ID="txtDateBrokerReceivedComplaint" runat="server"></asp:TextBox>
                                                            <img alt="Date Broker Received Complaint" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDateBrokerReceivedComplaint', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                align="middle" /><br />
                                                            <asp:RegularExpressionValidator ID="revDateBrokerReceivedComplaint" runat="server"
                                                                ControlToValidate="txtDateBrokerReceivedComplaint" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                ErrorMessage="[Key Dates]/Date Broker Received Complaint Not Valid" Display="none"
                                                                ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left">
                                                            Date HR Received Complaint&nbsp;<span id="Span36" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtDateHRReceivedComplaint" runat="server"></asp:TextBox>
                                                            <img alt="Date HR Received Complaint" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDateHRReceivedComplaint', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                align="middle" /><br />
                                                            <asp:RegularExpressionValidator ID="revDateHRReceivedComplaint" runat="server" ControlToValidate="txtDateHRReceivedComplaint"
                                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                ErrorMessage="[Key Dates]/Date HR Received Complaint Not Valid" Display="none"
                                                                ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Date Acknowledgement By Primary Carrier&nbsp;<span id="Span37" style="color: Red;
                                                                display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:TextBox ID="txtDateAcknowledgementByPrimaryCarrier" runat="server"></asp:TextBox>
                                                            <img alt="Date Acknowledgement By Primary Carrier" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDateAcknowledgementByPrimaryCarrier', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                align="middle" /><br />
                                                            <asp:RegularExpressionValidator ID="revDateAcknowledgementByPrimaryCarrier" runat="server"
                                                                ControlToValidate="txtDateAcknowledgementByPrimaryCarrier" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                ErrorMessage="[Key Dates]/Date Acknowledgement By Primary Carrier Not Valid"
                                                                Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                            <asp:CompareValidator ID="cvDateAcknowledgementByPrimaryCarrier" runat="server" ControlToCompare="txtDateCarrierNotified"
                                                                ControlToValidate="txtDateAcknowledgementByPrimaryCarrier" Display="None" ErrorMessage="[Key Dates] / Date Acknowledgement By Primary Carrier must be greater than or equal to Date Carrier(s) Notified"
                                                                Operator="GreaterThanEqual" Type="Date" SetFocusOnError="true" ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                                                        </td>
                                                        <td align="left">
                                                            Person Who Received Compliant in HR&nbsp;<span id="Span38" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtHRComplaintRecipient" runat="server" MaxLength="50" />
                                                        </td>
                                                    </tr>
                                                   
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl8" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Legal</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Internal Counsel&nbsp;<span id="Span39" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:TextBox ID="txtInternalCounsel" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                                                        </td>
                                                        <td align="left" width="18%">
                                                            Telephone (XXX-XXX-XXXX)&nbsp;<span id="Span40" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:TextBox ID="txtTelephone" runat="server" Width="170px" MaxLength="12"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="revTelephone" ControlToValidate="txtTelephone"
                                                                runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please enter [Legal]/Telephone Number in xxx-xxx-xxxx format."
                                                                Display="none" ValidationExpression="\d{3}(-\d{3})(-\d{4})"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Panel Counsel Required?
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:RadioButtonList ID="rdoPanelCounselRequired" runat="server" SkinID="YesNoType">
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Primary Defense File Number&nbsp;<span id="Span41" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:TextBox ID="txtPrimaryDefenseFileNumber" runat="server" Width="170px" MaxLength="30"></asp:TextBox>
                                                        </td>
                                                        <td align="left" width="18%">
                                                            Secondary Defense File Number&nbsp;<span id="Span42" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:TextBox ID="txtSecondaryDefenseFileNumber" runat="server" Width="170px" MaxLength="30"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Defense Attorney Grid
                                                            <br />
                                                            <asp:LinkButton ID="lnkDefenseAttorneyAdd" runat="server" Text="--Add--" OnClick="lnkDefenseAttorneyAdd_Click"
                                                                ValidationGroup="vsErrorGroup" CausesValidation="true"></asp:LinkButton>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <asp:GridView ID="gvDefenseAttorney" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                OnRowCommand="gvDefenseAttorney_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Firm">
                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigateDefensePage(<%#Eval("PK_Defense_Attorney")%>);">
                                                                                <%#Eval("Firm")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Name">
                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigateDefensePage(<%#Eval("PK_Defense_Attorney")%>);">
                                                                                <%#Eval("Name")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Address">
                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigateDefensePage(<%#Eval("PK_Defense_Attorney")%>);">
                                                                                <%#Eval("Address_1") + " " + Eval("Address_2")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Telephone">
                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigateDefensePage(<%#Eval("PK_Defense_Attorney")%>);">
                                                                                <%#Eval("Telephone")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="E-Mail">
                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigateDefensePage(<%#Eval("PK_Defense_Attorney")%>);">
                                                                                <%#Eval("E_Mail")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Panel">
                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigateDefensePage(<%#Eval("PK_Defense_Attorney")%>);">
                                                                                <%#Eval("Panel")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" Text="Remove" runat="server" CommandName="RemoveAttorney"
                                                                                CommandArgument='<%#Eval("PK_Defense_Attorney")%>' OnClientClick="return ConfirmDelete();"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <asp:Label ID="lblEmptyEmergencyMessage" runat="server" Text="No Record Found"></asp:Label>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Plaintiff Attorney Grid
                                                            <br />
                                                            <asp:LinkButton ID="lnkPlaintiffAttorneyAdd" runat="server" Text="--Add--" OnClick="lnkPlaintiffAttorneyAdd_Click"
                                                                ValidationGroup="vsErrorGroup" CausesValidation="true"></asp:LinkButton>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <asp:GridView ID="gvPlaintiffAttorney" runat="server" AutoGenerateColumns="false"
                                                                Width="100%" OnRowCommand="gvPlaintiffAttorney_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Firm">
                                                                        <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigatePlaintiffPage(<%#Eval("PK_Plaintiff_Attorney")%>);">
                                                                                <%#Eval("Firm")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Name">
                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigatePlaintiffPage(<%#Eval("PK_Plaintiff_Attorney")%>);">
                                                                                <%#Eval("Name")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Address">
                                                                        <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigatePlaintiffPage(<%#Eval("PK_Plaintiff_Attorney")%>);">
                                                                                <%#Eval("Address_1") + " " + Eval("Address_2")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Telephone">
                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigatePlaintiffPage(<%#Eval("PK_Plaintiff_Attorney")%>);">
                                                                                <%#Eval("Telephone")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="E-Mail">
                                                                        <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigatePlaintiffPage(<%#Eval("PK_Plaintiff_Attorney")%>);">
                                                                                <%#Eval("E_Mail")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CommandName="RemoveAttorney"
                                                                                CommandArgument='<%#Eval("PK_Plaintiff_Attorney")%>' OnClientClick="return ConfirmDelete();"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <asp:Label ID="lblEmptyEmergencyMessage" runat="server" Text="No Record Found"></asp:Label>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Court&nbsp;<span id="Span43" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:TextBox ID="txtCourt" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                                                        </td>
                                                        <td align="left" width="18%">
                                                            Judge/Arbitrator&nbsp;<span id="Span44" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:TextBox ID="txtJudge" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Legal Status&nbsp;<span id="Span45" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="txtLegalStatus" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl9" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Exposure Analysis</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Estimated Demand Exposure&nbsp;<span id="Span46" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            $ &nbsp;<asp:TextBox ID="txtEstimatedDemandExposure" runat="server" Width="155px"
                                                                onpaste="return false" onkeypress="return FormatNumber(event,this.id,13,true);"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="revEstimatedDemandExposure" ControlToValidate="txtEstimatedDemandExposure"
                                                                runat="server" ErrorMessage="Please enter [Exposure Analysis]/Estimated Demand Exposure in proper format"
                                                                ValidationGroup="vsErrorGroup" Display="none" ValidationExpression="^\d{1,3}(,\d\d\d)*$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" width="18%">
                                                            Demand Exposure Date&nbsp;<span id="Span47" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:TextBox ID="txtDemandExposureDate" runat="server"></asp:TextBox>
                                                            <img alt="Demand Exposure Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDemandExposureDate', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                align="middle" /><br />
                                                            <asp:RegularExpressionValidator ID="revDemandExposureDate" runat="server" ControlToValidate="txtDemandExposureDate"
                                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                ErrorMessage="[Exposure Analysis]/Demand Exposure Date Not Valid" Display="none"
                                                                ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Estimated Defense Expense&nbsp;<span id="Span48" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            $ &nbsp;<asp:TextBox ID="txtEstimatedDefenseExpense" runat="server" Width="155px"
                                                                onpaste="return false" onkeypress="return FormatNumber(event,this.id,13,true);"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="regEstimatedDefenseExpense" ControlToValidate="txtEstimatedDefenseExpense"
                                                                runat="server" ErrorMessage="Please enter [Exposure Analysis]/Estimated Defense Expense in proper format"
                                                                ValidationGroup="vsErrorGroup" Display="none" ValidationExpression="^\d{1,3}(,\d\d\d)*$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" width="18%">
                                                            Estimated Defense Expense Date&nbsp;<span id="Span49" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:TextBox ID="txtEstimatedDefenseExpenseDate" runat="server"></asp:TextBox>
                                                            <img alt="Estimated Defense Expense Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtEstimatedDefenseExpenseDate', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                align="middle" /><br />
                                                            <asp:RegularExpressionValidator ID="revEstimatedDefenseExpenseDate" runat="server"
                                                                ControlToValidate="txtEstimatedDefenseExpenseDate" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                ErrorMessage="[Exposure Analysis]/Estimated Defense Expense Date Not Valid" Display="none"
                                                                ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Actual Settlement&nbsp;<span id="Span50" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            $ &nbsp;<asp:TextBox ID="txtActualSettlement" runat="server" Width="155px" onKeyPress="return(currencyFormat(this,',','.',event));"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="regActualSettlement" ControlToValidate="txtActualSettlement"
                                                                runat="server" ErrorMessage="Please enter [Exposure Analysis]/Actual Settlement in proper format"
                                                                ValidationGroup="vsErrorGroup" Display="none" ValidationExpression="^\d{1,3}(,\d\d\d)*\.\d\d$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" width="18%">
                                                            Actual Settlement Date&nbsp;<span id="Span51" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:TextBox ID="txtActualSettlementDate" runat="server"></asp:TextBox>
                                                            <img alt="Actual Settlement Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtActualSettlementDate', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                align="middle" /><br />
                                                            <asp:RegularExpressionValidator ID="revActualSettlementDate" runat="server" ControlToValidate="txtActualSettlementDate"
                                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                ErrorMessage="[Exposure Analysis]/Actual Settlement Date Not Valid" Display="none"
                                                                ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Actual Defense Expense&nbsp;<span id="Span52" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            $ &nbsp;<asp:TextBox ID="txtActualDefenseExpense" runat="server" Width="155px" onKeyPress="return(currencyFormat(this,',','.',event));"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="regActualDefenseExpense" ControlToValidate="txtActualDefenseExpense"
                                                                runat="server" ErrorMessage="Please enter [Exposure Analysis]/Actual Defense Expense in proper format"
                                                                ValidationGroup="vsErrorGroup" Display="none" ValidationExpression="^\d{1,3}(,\d\d\d)*\.\d\d$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="left" width="18%">
                                                            Actual Defense Expense Date&nbsp;<span id="Span53" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:TextBox ID="txtActualDefenseExpenseDate" runat="server"></asp:TextBox>
                                                            <img alt="Actual Defense Expense Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtActualDefenseExpenseDate', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                align="middle" /><br />
                                                            <asp:RegularExpressionValidator ID="revActualDefenseExpenseDate" runat="server" ControlToValidate="txtActualDefenseExpenseDate"
                                                                ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                                                ErrorMessage="[Exposure Analysis]/Actual Defense Expense Date Not Valid" Display="none"
                                                                ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Comments&nbsp;<span id="Span54" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="txtComments" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl10" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Expense Grid</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Expense Grid
                                                            <br />
                                                            <asp:LinkButton ID="lnkExpenseAdd" runat="server" Text="--Add--" OnClick="lnkExpenseAdd_Click"
                                                                ValidationGroup="vsErrorGroup" CausesValidation="true"></asp:LinkButton>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:GridView ID="gvExpense" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                OnRowCommand="gvExpense_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Company">
                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigateExpensePage(<%#Eval("PK_Executive_Risk_Expenses")%>);">
                                                                                <%#Eval("Company")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Invoice">
                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigateExpensePage(<%#Eval("PK_Executive_Risk_Expenses")%>);">
                                                                                <%#Eval("Invoice")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Amount - $">
                                                                        <ItemStyle HorizontalAlign="Left" Width="25%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigateExpensePage(<%#Eval("PK_Executive_Risk_Expenses")%>);">
                                                                                <%# clsGeneral.GetStringValue(Convert.ToDecimal(Eval("Amount")))%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Date">
                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigateExpensePage(<%#Eval("PK_Executive_Risk_Expenses")%>);">
                                                                                <%#Eval("Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date"))) : string.Empty%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" CommandName="RemoveExpense"
                                                                                CommandArgument='<%#Eval("PK_Executive_Risk_Expenses")%>' OnClientClick="return ConfirmDelete();"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <asp:Label ID="lblEmptyEmergencyMessage" runat="server" Text="No Record Found"></asp:Label>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>                                                   
                                                </table>
                                            </asp:Panel>
                                            <div id="dvAttachment" runat="server" style="display: none;">
                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="100%">
                                                            <uc:ctrlAttachment ID="Attachment" EnableValidationSummary="true" runat="Server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Spacer" style="height: 20px;">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Spacer" style="height: 20px;" colspan="2">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                        <div id="dvView" runat="server">
                                            <asp:Panel ID="pnlClaimIdentificationView" runat="server">
                                                <div class="bandHeaderRow">
                                                    Claim Identification</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Claim Number
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblClaimNumberView" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%">
                                                            Sonic Location Code
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblSonicLocationCode" Width="170px" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Type Of Claim
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblTypeOfClaim" Width="170px" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                        <%--<td align="left">
                                                            Legal Entity
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblLegalEntity" Width="170px" runat="server">
                                                            </asp:Label>
                                                        </td>--%>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            If Other, Please Specify
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblOtherClaimType" runat="server" Width="170px" />
                                                        </td>
                                                        <td align="left">
                                                            Location d/b/a
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblLocationDBA" Width="170px" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Type of Allegation
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <%--<asp:Label ID="lblTypeOfAllegation" runat="server" Width="170px" />--%>
                                                            <asp:ListBox ID="lstFK_Type_Of_ER_AllegationView"  runat="server" Rows="5" SelectionMode="Multiple"
                                                            Width="190px"></asp:ListBox>
                                                        </td>
                                                        <td align="left" width="18%">
                                                            Entity
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblEntity" Width="170px" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Legal File Number
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblLegalFileNumber" runat="server" Width="170px" />
                                                        </td>
                                                        <td colspan="3">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Complainant/Plaintiff
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblComplaintant" runat="server" Width="170px"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            Defendant
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblDefendant" runat="server" Width="170px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Claim Description
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="lblClaimDescription" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>                                                   
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl2View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Claim Status</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Date Claim Opened
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblDateClaimOpened" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%">
                                                            Date Claim Closed
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblDateClaimClosed" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Date Claim Reopened
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblDateClaimReopened" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%">
                                                            Bordereau Report?
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblBordereauReport" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Claim Status/Comments
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="lblClaimStatus" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>                                                   
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl3View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Filing</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            EEOC?
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblEEOC" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                        <td align="left" width="18%">
                                                            State Employment Commission
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblStateEmploymentComission" runat="server" Width="170px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Letter of Representation Received?
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblLetterReceived" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                        <td align="left" width="18%">
                                                            Date Letter of Representation Received
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblDateLetterReceived" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Security Litigation?
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblSecurityLitigation" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                        <td align="left" width="18%">
                                                            Other Litigation?
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblOtherLitigation" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Jurisdiction
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblJuridiction" runat="server" Width="170px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Date Complaint/Suit Filed
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblDateComplaintFiled" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%">
                                                            Date Suite Served
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblDateSuitServed" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Case Number
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblCaseNumber" runat="server" Width="170px"></asp:Label>
                                                        </td>
                                                    </tr>                                                   
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl4View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Insurance Profile</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Primary Insurance Claim Number
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblPrimaryClaimNumber" runat="server" Width="170px"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%">
                                                            Primary Insurance Policy Number
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblPrimaryPolicyNumber" runat="server" Width="170px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Primary Policy Effective Date
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblPrimaryPolicyEffectiveDate" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%">
                                                            Primary Policy Expiration Date
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblPrimaryPolicyExpirationDate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Total Program Limit
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblTotalProgramLimit" runat="server" Width="170px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Primary Deductible
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblPrimaryDeductable" runat="server" Width="170px"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%">
                                                            Allocation
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblAllocation" runat="server" Width="170px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Carrier Grid<br />
                                                            <a href="javascript:NavigateCarrierPage(0)" style="display: <%= Module_Access_Mode == AccessType.Administrative_Access ? "none" : "block"%>">
                                                                --Add--</a>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <asp:GridView ID="gvCarrierView" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                Width="100%">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Carrier">
                                                                        <ItemStyle HorizontalAlign="Left" Width="17%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigateCarrierPage(<%#Eval("PK_Executive_Risk_Carrier")%>)">
                                                                                <%#Eval("Carrier")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Layer">
                                                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigateCarrierPage(<%#Eval("PK_Executive_Risk_Carrier")%>)">
                                                                                <%# Eval("FK_Layer") != DBNull.Value ? new ERIMS.DAL.Layer(Convert.ToDecimal(Eval("FK_Layer"))).Fld_Desc : string.Empty %>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Limit - $">
                                                                        <ItemStyle HorizontalAlign="Left" Width="17%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigateCarrierPage(<%#Eval("PK_Executive_Risk_Carrier")%>)">
                                                                                <%# clsGeneral.GetStringValue(Convert.ToDecimal(Eval("Limit"))).Replace(".00", "")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Contact Name">
                                                                        <ItemStyle HorizontalAlign="Left" Width="17%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigateCarrierPage(<%#Eval("PK_Executive_Risk_Carrier")%>)">
                                                                                <%#Eval("Contact_Name")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Contact Number">
                                                                        <ItemStyle HorizontalAlign="Left" Width="17%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigateCarrierPage(<%#Eval("PK_Executive_Risk_Carrier")%>)">
                                                                                <%#Eval("Contact_Number")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Claim Number">
                                                                        <ItemStyle HorizontalAlign="Left" Width="17%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigateCarrierPage(<%#Eval("PK_Executive_Risk_Carrier")%>)">
                                                                                <%#Eval("Claim_Number")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <asp:Label ID="lblEmptyEmergencyMessage" runat="server" Text="No Record Found"></asp:Label>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                   
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl5View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Key Dates</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Date of Alleged Wrongful Act
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblDateAllegedWrongfulAct" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%">
                                                            Date Complaint Received
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblDateComplaintReceived" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Date Legal Received Complaint
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblDateLegalReceivedComplaint" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%">
                                                            Date Risk Management Received Complaint
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblDateRiskMgmtReceivedComplaint" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Person Who Received Complaint in Legal
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblLegalComplaintRecipient" runat="server" />
                                                        </td>
                                                        <td align="left" width="18%">
                                                            Date Carrier(s) Notified
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblDateCarrierNotified" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Date Broker Received Complaint
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblDateBrokerReceivedComplaint" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            Date HR Received Complaint
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblDateHRReceivedComplaint" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Date Acknowledgement By Primary Carrier
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblDateAcknowledgementByPrimaryCarrier" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            Person Who Received Compliant in HR
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblHRComplaintRecipient" runat="server" />
                                                        </td>
                                                    </tr>
                                                    
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl8View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Legal</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Internal Counsel
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblInternalCounsel" runat="server" Width="170px"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%">
                                                            Telephone (XXX-XXX-XXXX)
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblTelephone" runat="server" Width="170px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Panel Counsel Required?
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblPanelCounselRequired" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Primary Defense File Number
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblPrimaryDefenseFileNumber" runat="server" Width="170px"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%">
                                                            Secondary Defense File Number
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblSecondaryDefenseFileNumber" runat="server" Width="170px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Defense Attorney Grid<br />
                                                            <a href="javascript:NavigateDefensePage(0);" style="display: <%= Module_Access_Mode == AccessType.Administrative_Access ? "none" : "block"%>">
                                                                --Add--</a>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <asp:GridView ID="gvDefenseAttorneyView" runat="server" Width="100%" AutoGenerateColumns="false">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Firm">
                                                                        <ItemStyle HorizontalAlign="Left" Width="17%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigateDefensePage(<%#Eval("PK_Defense_Attorney")%>);">
                                                                                <%#Eval("Firm")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Name">
                                                                        <ItemStyle HorizontalAlign="Left" Width="17%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigateDefensePage(<%#Eval("PK_Defense_Attorney")%>);">
                                                                                <%#Eval("Name")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Address">
                                                                        <ItemStyle HorizontalAlign="Left" Width="18%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigateDefensePage(<%#Eval("PK_Defense_Attorney")%>);">
                                                                                <%#Eval("Address_1") + " " + Eval("Address_2")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Telephone">
                                                                        <ItemStyle HorizontalAlign="Left" Width="16%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigateDefensePage(<%#Eval("PK_Defense_Attorney")%>);">
                                                                                <%#Eval("Telephone")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="E-Mail">
                                                                        <ItemStyle HorizontalAlign="Left" Width="16%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigateDefensePage(<%#Eval("PK_Defense_Attorney")%>);">
                                                                                <%#Eval("E_Mail")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Panel">
                                                                        <ItemStyle HorizontalAlign="Left" Width="16%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigateDefensePage(<%#Eval("PK_Defense_Attorney")%>);">
                                                                                <%#Eval("Panel")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <asp:Label ID="lblEmptyEmergencyMessage" runat="server" Text="No Record Found"></asp:Label>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Plaintiff Attorney Grid<br />
                                                            <a href="javascript:NavigatePlaintiffPage(0);" style="display: <%=Module_Access_Mode == AccessType.Administrative_Access ? "none" : "block"%>">
                                                                --Add--</a>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <asp:GridView ID="gvPlaintiffAttorneyView" runat="server" AutoGenerateColumns="false"
                                                                Width="100%">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Firm">
                                                                        <ItemStyle HorizontalAlign="Left" Width="22%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigatePlaintiffPage(<%#Eval("PK_Plaintiff_Attorney")%>);">
                                                                                <%#Eval("Firm")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Name">
                                                                        <ItemStyle HorizontalAlign="Left" Width="17%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigatePlaintiffPage(<%#Eval("PK_Plaintiff_Attorney")%>);">
                                                                                <%#Eval("Name")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Address">
                                                                        <ItemStyle HorizontalAlign="Left" Width="22%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigatePlaintiffPage(<%#Eval("PK_Plaintiff_Attorney")%>);">
                                                                                <%#Eval("Address_1") + " " + Eval("Address_2")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Telephone">
                                                                        <ItemStyle HorizontalAlign="Left" Width="17%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigatePlaintiffPage(<%#Eval("PK_Plaintiff_Attorney")%>);">
                                                                                <%#Eval("Telephone")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="E-Mail">
                                                                        <ItemStyle HorizontalAlign="Left" Width="22%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigatePlaintiffPage(<%#Eval("PK_Plaintiff_Attorney")%>);">
                                                                                <%#Eval("E_Mail")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <asp:Label ID="lblEmptyEmergencyMessage" runat="server" Text="No Record Found"></asp:Label>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Court
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblCourt" runat="server" Width="170px"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%">
                                                            Judge/Arbitrator
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblJudge" runat="server" Width="170px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Legal Status
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="lblLegalStatus" runat="server" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl9View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Exposure Analysis</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Estimated Demand Exposure
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            $ &nbsp;<asp:Label ID="lblEstimatedDemandExposure" runat="server" Width="155px"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%">
                                                            Demand Exposure Date
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblDemandExposureDate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Estimated Defense Expense
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            $ &nbsp;<asp:Label ID="lblEstimatedDefenseExpense" runat="server" Width="155px"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%">
                                                            Estimated Defense Expense Date
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblEstimatedDefenseExpenseDate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Actual Settlement
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            $ &nbsp;<asp:Label ID="lblActualSettlement" runat="server" Width="155px"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%">
                                                            Actual Settlement Date
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblActualSettlementDate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Actual Defense Expense
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            $ &nbsp;<asp:Label ID="lblActualDefenseExpense" runat="server" Width="155px"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%">
                                                            Actual Defense Expense Date
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="28%">
                                                            <asp:Label ID="lblActualDefenseExpenseDate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Comments
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <uc:ctrlMultiLineTextBox ID="lblComments" runat="server" ControlType="label" />
                                                        </td>
                                                    </tr>                                                   
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pnl10View" runat="server" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Expense Grid</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">
                                                            Expense Grid<br />
                                                            <a href="javascript:NavigateExpensePage(0);" style="display: <%=Module_Access_Mode == AccessType.Administrative_Access ? "none" : "block"%>">
                                                                --Add--</a>
                                                        </td>
                                                        <td align="center" width="4%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:GridView ID="gvExpenseView" runat="server" Width="100%" AutoGenerateColumns="false">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Company">
                                                                        <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigateExpensePage(<%#Eval("PK_Executive_Risk_Expenses")%>);">
                                                                                <%#Eval("Company")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Invoice">
                                                                        <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigateExpensePage(<%#Eval("PK_Executive_Risk_Expenses")%>);">
                                                                                <%#Eval("Invoice")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Amount - $">
                                                                        <ItemStyle HorizontalAlign="Left" Width="25%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigateExpensePage(<%#Eval("PK_Executive_Risk_Expenses")%>);">
                                                                                <%# clsGeneral.GetStringValue(Convert.ToDecimal(Eval("Amount")))%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Date">
                                                                        <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:NavigateExpensePage(<%#Eval("PK_Executive_Risk_Expenses")%>);">
                                                                                <%#Eval("Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date"))) : string.Empty%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <asp:Label ID="lblEmptyEmergencyMessage" runat="server" Text="No Record Found"></asp:Label>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>                                                   
                                                </table>
                                            </asp:Panel>
                                        </div>
                                        <asp:Panel ID="pnlAttachmentDetails" runat="server" Style="display: none;">
                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td width="100%">
                                                        <uc:ctrlAttachmentDetails ID="AttachDetails" runat="Server" />
                                                    </td>
                                                </tr>                                               
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="pnl6" runat="server" Style="display: none;">
                                            <div class="bandHeaderRow">
                                                Contact Information</div>
                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                <tr>
                                                    <td align="left" width="18%" valign="top">
                                                        Contacts Grid<br />
                                                        <asp:LinkButton ID="lnkContactAdd" runat="server" Text="--Add--" OnClick="lnkContactAdd_Click"
                                                            ValidationGroup="vsErrorGroup" CausesValidation="true">
                                                        </asp:LinkButton>
                                                    </td>
                                                    <td align="center" width="4%" valign="top">
                                                        :
                                                    </td>
                                                    <td colspan="4" valign="top">
                                                        <asp:GridView ID="gvContactInfo" runat="server" Width="100%" AutoGenerateColumns="false"
                                                            OnRowCommand="gvContactInfo_RowCommand" EmptyDataText="No Contact Exists.">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Contact Type">
                                                                    <ItemStyle Width="15%" HorizontalAlign="left" />
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkType" runat="server" Text='<%# Eval("Contact_Type") %>' CommandName="ViewContact"
                                                                            CommandArgument='<%#Eval("PK_Executive_Risk_Contacts")%>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Contact Name">
                                                                    <ItemStyle Width="22%" HorizontalAlign="left" />
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkNamee" runat="server" Text='<%# Eval("Contact_Name") %>' CommandName="ViewContact"
                                                                            CommandArgument='<%#Eval("PK_Executive_Risk_Contacts")%>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Contact Telephone Number">
                                                                    <ItemStyle Width="20%" HorizontalAlign="left" />
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkTelNum" runat="server" Text='<%# Eval("Tel_Number") %>' CommandName="ViewContact"
                                                                            CommandArgument='<%#Eval("PK_Executive_Risk_Contacts")%>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Remove">
                                                                    <ItemStyle Width="10%" HorizontalAlign="left" />
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkRemove" runat="server" CommandArgument='<%#Eval("PK_Executive_Risk_Contacts")%>'
                                                                            CommandName="RemoveContact" Text="Remove" OnClientClick="return confirm('Are you sure to delete?');" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="pnl7" runat="server" Style="display: none;">
                                            <div class="bandHeaderRow">
                                                Investigator Notes</div>
                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                <tr>
                                                    <td align="left" width="18%" valign="top">
                                                        Investigator Notes Grid<br />
                                                        <asp:LinkButton ID="lnkInvestigatorNotesAdd" runat="server" Text="--Add--" OnClick="lnkInvestigatorNotesAdd_Click"
                                                            ValidationGroup="vsErrorGroup" CausesValidation="true">
                                                        </asp:LinkButton>
                                                    </td>
                                                    <td align="center" width="4%" valign="top">
                                                        :
                                                    </td>
                                                    <td colspan="4" valign="top">
                                                        <asp:GridView ID="gvInvestigatorNotes" runat="server" Width="100%" AutoGenerateColumns="false"
                                                            OnRowCommand="gvExecutiveNotes_RowCommand" EmptyDataText="No Investigator Note Exists.">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Note Subject">
                                                                    <ItemStyle Width="22%" HorizontalAlign="left" />
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkSubject" runat="server" Text='<%# Eval("Note_Subject") %>'
                                                                            CommandName="ViewNote" CommandArgument='<%#Eval("PK_Investigator_Notes")%>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Investigator Name">
                                                                    <ItemStyle Width="15%" HorizontalAlign="left" />
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkName" runat="server" Text='<%# Eval("Investigator_Name") %>'
                                                                            CommandName="ViewNote" CommandArgument='<%#Eval("PK_Investigator_Notes")%>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Date of Notes(s)">
                                                                    <ItemStyle Width="20%" HorizontalAlign="left" />
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkDate" runat="server" Text='<%# Convert.ToDateTime(Eval("Date_Of_Note")).ToString("MMMM dd, yyyy")%>'
                                                                            CommandName="ViewNote" CommandArgument='<%#Eval("PK_Investigator_Notes")%>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Remove">
                                                                    <ItemStyle Width="10%" HorizontalAlign="left" />
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkRemove" runat="server" CommandArgument='<%#Eval("PK_Investigator_Notes")%>'
                                                                            CommandName="RemoveNote" Text="Remove" OnClientClick="return confirm('Are you sure to delete?');" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" width="100%" class="Spacer" style="height: 10px;">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td align="center">
                            <div id="dvSave" runat="server">
                                <table cellpadding="5" cellspacing="0" border="0" width="100%">
                                    <tr>
                                        <td width="34%" align="right">
                                            <asp:Button ID="btnSave" runat="server" Text="Save & View" OnClick="btnSaveAndView_Click"
                                                ValidationGroup="vsErrorGroup" CausesValidation="true" />
                                        </td>
                                        <td width="12%" align="left">
                                            <asp:Button ID="btnNextStep" runat="server" Text="Next Step" CausesValidation="true"
                                                ValidationGroup="vsErrorGroup" OnClientClick="return onNextStep();" OnClick="btnNextStep_Click" />
                                        </td>
                                        <td style="width: 54%;" align="left">
                                            <asp:Button ID="btnViewAudit" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();" />&nbsp;
                                            <asp:Button ID="btnBackSearch" runat="server" Text=" Back " OnClick="btnBackToSearch_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" width="100%" align="center">
                            <table border="0" width="100%" runat="server" id="tblViewAll">
                                <tr>
                                    <td align="right" style="width: 50%;">
                                        <asp:Button ID="btnBack" runat="server" Text=" Edit " OnClick="btnBack_Click" Visible="false" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnNextStepView" runat="server" Text="Next Step" CausesValidation="false"
                                            Visible="false" OnClientClick="return onNextStep();" />
                                    </td>
                                    <td align="left" style="width: 50%;">
                                        <asp:Button ID="btnAuditView" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();"
                                            Visible="false" />
                                        <asp:Button ID="btnBackToSearch" Text=" Back " runat="server" OnClick="btnBackToSearch_Click"
                                            Visible="false" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" width="100%" class="Spacer" style="height: 10px;">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:CustomValidator ID="CustomValidator" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
        Display="None" ValidationGroup="vsErrorGroup" />
    <input id="hdnControlIDs" runat="server" type="hidden" />
    <input id="hdnErrorMsgs" runat="server" type="hidden" />
</asp:Content>
