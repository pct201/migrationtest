<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Default.master" CodeFile="ExcessPolicyAddEdit.aspx.cs"
    Inherits="ExcessPolicyAddEdit" %>

<%@ Register Src="~/Controls/Calender/Calender.ascx" TagName="ctrlCalendar" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment_COI/Attachment_COI.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlNotes" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment_COI/AttachmentDetails_COI.ascx" TagName="ctrlAttachmentDetails"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/COIInfo/COIInfo.ascx" TagName="ctrlCOIInfo" TagPrefix="uc" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script type="text/javascript">
        function CheckForValidation() {
            return AlertValidation('<%=Attachment.RequiredAttachTypeID%>', '<%=Attachment.RequiredAttachFileID%>');
        }
        function Navigate_URL(PageName) {
            var strOpr = '<%=Request.QueryString["op"]%>';
            if (strOpr != null && strOpr == "view") {
                RedirectToPage(PageName);
            }
            else {
                Page_ClientValidate('vsErrorGroup');
                if (Page_IsValid == false) {
                    //alert("There are invalid entries on this screen, in order to save the data, please provide a valid enty for the fields marked with '!!'");
                }
                else {
                    //__doPostBack('ctl00$ContentPlaceHolder1$btnSave', PageName);
                    document.getElementById('<%=hdnPageName.ClientID%>').value = PageName;
                    document.getElementById('<%=btnDummyForSave.ClientID%>').click();
                }
            }
        }
        function RedirectToPage(PageName) {
            if (PageName.indexOf("?") > 0)
                window.location.href = PageName + '&Page=EP&prop=<%=Encryption.Encrypt(PK_COI_Excess_Policies.ToString())%>&coi=<%=Encryption.Encrypt(FK_COI.ToString())%>&op=<%=Request.QueryString["op"]%>';
            else
                window.location.href = PageName + '?Page=EP&prop=<%=Encryption.Encrypt(PK_COI_Excess_Policies.ToString())%>&coi=<%=Encryption.Encrypt(FK_COI.ToString())%>';

        }
        function SetMenuStyle(index) {
            var i;
            for (i = 1; i <= 3; i++) {
                var tb = document.getElementById("Menu" + i);
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

        function SetFocusOnFirstControl(index) {
            switch (index) {
                case 1:
                    document.getElementById('ctl00_ContentPlaceHolder1_drpCompany').focus(); break;
                case 2:
                    document.getElementById('ctl00_ContentPlaceHolder1_lnkGeneralAdd').focus(); break;
                case 3:
                    document.getElementById('ctl00_ContentPlaceHolder1_Attachment_drpAttachType').focus();
                    break;
                default:
                    break;
            }
        }

        function ConfirmDelete() {
            return confirm("Are you sure that you want to remove the data that was selected for deletion?");
        }

        function ShowPanel(index) {
            SetMenuStyle(index);
            var i;
            var op = '<%=StrOperation%>';
            if (op == "view") {
                document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
                ShowPanelView(index);
            }
            else {
                document.getElementById('<%=dvEdit.ClientID%>').style.display = "block";
                document.getElementById('<%=btnSave.ClientID%>').style.display = "inline";
                document.getElementById('<%=btnReturn.ClientID%>').style.display = "inline";
                document.getElementById('<%=btnBack.ClientID%>').style.display = "none";
                document.getElementById('<%=lblNote.ClientID%>').style.display = "block";

                if (index == 1) {
                    document.getElementById("ctl00_ContentPlaceHolder1_Panel1").style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_Panel4").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_Div1").style.display = "none";
                    document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";

                }
                else if (index == 2) {
                    document.getElementById("ctl00_ContentPlaceHolder1_Panel1").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_Panel4").style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_Div1").style.display = "none";
                    document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";

                }
                else {

                    document.getElementById("ctl00_ContentPlaceHolder1_Panel1").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_Panel4").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_Div1").style.display = "block";

                    document.getElementById("<%=dvAttachment.ClientID%>").style.display = "block";

                }
                SetFocusOnFirstControl(index);
            }
        }

        function ShowPanelView(index) {
            SetMenuStyle(index);

            document.getElementById('<%=dvView.ClientID%>').style.display = "block";
            document.getElementById('<%=btnSave.ClientID%>').style.display = "none";
            document.getElementById('<%=btnReturn.ClientID%>').style.display = "none";
            document.getElementById('<%=btnBack.ClientID%>').style.display = "block";

            if (index == 1) {
                document.getElementById("ctl00_ContentPlaceHolder1_Panel2").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_Panel4").style.display = "none";
                document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
            }
            else if (index == 2) {
                document.getElementById("ctl00_ContentPlaceHolder1_Panel2").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_Panel4").style.display = "block";
                document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
            }
            else if (index == 3) {
                document.getElementById("ctl00_ContentPlaceHolder1_Panel2").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_Panel4").style.display = "none";
                document.getElementById("<%=dvAttachment.ClientID%>").style.display = "block";
            }
        }

        function ValidateFields(sender, args) {
            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnControlIDs.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnErrorMsgs.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnControlIDs.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {
                        case "textarea":
                        case "text": if (ctrl.value == '') bEmpty = true; break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                    }
                    if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
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
    </script>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <div style="width: 100%" id="contmain">
        <table cellpadding="0" cellspacing="0" width="100%" align="left">
            <tr>
                <td style="height: 15px;" class="Spacer">
                </td>
            </tr>
            <tr>
                <td width="100%" colspan="3">
                    <uc:ctrlCOIInfo ID="ucCtrlCOIInfo" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="Spacer" style="height: 5px;" colspan="3" width="100%">
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
                            <td align="left" width="100%">
                                <span id="Menu1" onclick="javascript:ShowPanel(1);" class="LeftMenuStatic">Excess Liability
                                    Policies</span> <span id="MenuAsterisk1" runat="server" style="color: Red; display: none;">
                                        *</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="100%">
                                <span id="Menu2" onclick="javascript:ShowPanel(2);" class="LeftMenuStatic">Additional
                                    Insured</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="100%">
                                <span id="Menu3" onclick="javascript:ShowPanel(3);" class="LeftMenuStatic">Attachment</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 10px;" class="Spacer">
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 5px;" class="Spacer">
                    &nbsp;
                </td>
                <td valign="top" width="100%">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td class="dvContainer">
                                <div id="dvEdit" runat="server">
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td class="tblGrid" align="left">
                                                <asp:Panel ID="Panel1" runat="server" Style="display: block; height: 100%">
                                                    <div class="bandHeaderRow">
                                                        Excess Liability Policies</div>
                                                    <table cellpadding="3" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td colspan="7">
                                                                <a href="javascript:ShowDialogCOI('Search.aspx?coi=<%=Encryption.Encrypt(FK_COI.ToString())%>&tbl=<%=(int)clsGeneral.Tables.Excess_Liability_Policies%>');">
                                                                    Find</a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="18%" align="left">
                                                                Insurance Company&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td width="2%" align="center">
                                                                :
                                                            </td>
                                                            <td width="28%" align="left">
                                                                <asp:DropDownList ID="drpCompany" runat="server" Width="205px" SkinID="Default" TabIndex="1">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td width="2%">
                                                                &nbsp;
                                                            </td>
                                                            <td width="18%" align="left">
                                                                Policy Number&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td width="2%" align="center">
                                                                :
                                                            </td>
                                                            <td width="30%" align="left">
                                                                <asp:TextBox ID="txtPolicyNumber" Width="200px" runat="server" MaxLength="35" TabIndex="10"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Issue Date&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <uc:ctrlCalendar ID="txtIssueDate" runat="server" IsRequiredField="false" ValidationGroup="vsErrorGroup"
                                                                    ErrorMessage="Please enter [Excess Liability Policies]/Issue Date" RegularExpressionMessage="Please enter Valid [Excess Liability Policies]/Issue Date"
                                                                    TabIndex="2" />
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                Effective Date&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <uc:ctrlCalendar ID="txtEffectiveDate" runat="server" IsRequiredField="false" ValidationGroup="vsErrorGroup"
                                                                    ErrorMessage="Please enter [Excess Liability Policies]/Effective Date" RegularExpressionMessage="Please enter Valid [Excess Liability Policies]/Effective Date"
                                                                    TabIndex="11" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Expiration Date&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <uc:ctrlCalendar ID="txtExpirationDate" runat="server" IsRequiredField="false" ValidationGroup="vsErrorGroup"
                                                                    ErrorMessage="Please enter [Excess Liability Policies]/Expiration Date" RegularExpressionMessage="Please enter Valid [Excess Liability Policies]/Expiration Date"
                                                                    TabIndex="3" />
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                Cancellation Date&nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <uc:ctrlCalendar ID="txtCancellationDate" runat="server" ValidationGroup="vsErrorGroup"
                                                                    IsRequiredField="false" ErrorMessage="Please enter [Excess Liability Policies]/Cancellation Date"
                                                                    RegularExpressionMessage="Please enter Valid [Excess Liability Policies]/Cancellation Date"
                                                                    TabIndex="12" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Occurrence Form
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:RadioButtonList ID="rdoOccurrenceForm" runat="server" SkinID="YesNoType" TabIndex="4" />
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                Each Occurrence&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                $&nbsp;<asp:TextBox ID="txtOccurrenceCoverage" Width="190px" runat="server" SkinID="DollarFieldBox"
                                                                    onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="13"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Umbrella Form
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:RadioButtonList ID="rdoUmbrellaForm" runat="server" SkinID="YesNoType" TabIndex="5" />
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                Aggregate&nbsp;<span id="Span8" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                $&nbsp;<asp:TextBox ID="txtAggregate" runat="server" Width="190px" SkinID="DollarFieldBox"
                                                                    onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="14"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Retention
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:RadioButtonList ID="rdoRetention" runat="server" SkinID="YesNoType" TabIndex="6" />
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                Retention&nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                $&nbsp;<asp:TextBox ID="txtRetention" Width="190px" runat="server" SkinID="DollarFieldBox"
                                                                    onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="15"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Accept Limits
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:RadioButtonList ID="rdoAcceptLimits" runat="server" SkinID="YesNoType" TabIndex="7" />
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                Accept Limits&nbsp;<span id="Span10" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                $&nbsp;<asp:TextBox ID="txtAcceptLimits" Width="190px" runat="server" SkinID="DollarFieldBox"
                                                                    onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="16"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Special Umbrella Limits
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:RadioButtonList ID="rdoSpecialUmbrella" runat="server" SkinID="YesNoType" TabIndex="8" />
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                Special Umbrella Limits&nbsp;<span id="Span11" style="color: Red; display: none;"
                                                                    runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                $&nbsp;<asp:TextBox ID="txtSpecialUmbrella" Width="190px" runat="server" SkinID="DollarFieldBox"
                                                                    onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="17"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                Notes&nbsp;<span id="Span12" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" colspan="5" valign="top">
                                                                <uc:ctrlNotes ID="txtNotes" runat="server" TabIndex="9" Width="600" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="Spacer" style="height: 5px;" colspan="7">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div id="Div1" runat="server" style="display: none;">
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td width="100%">
                                                <uc:ctrlAttachment ID="Attachment" runat="Server" ShowAttachmentType="true" OnbtnHandler="Attachment_btnHandler" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div id="dvView" runat="server" style="display: none;">
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td class="tblGrid" align="left">
                                                <asp:Panel ID="Panel2" runat="server" Style="display: block; height: 100%">
                                                    <div class="bandHeaderRow">
                                                        Excess Liability Policies</div>
                                                    <table cellpadding="5" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td width="18%" align="left" valign="top">
                                                                Insurance Company&nbsp;<span class="msg1">*</span>
                                                            </td>
                                                            <td width="2%" align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td width="28%" align="left" valign="top">
                                                                <asp:Label ID="lblCompany" runat="server"></asp:Label>
                                                            </td>
                                                            <td width="2%" valign="top">
                                                                &nbsp;
                                                            </td>
                                                            <td width="18%" align="left" valign="top">
                                                                Policy Number&nbsp;<span class="msg1">*</span>
                                                            </td>
                                                            <td width="2%" align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td width="30%" align="left" valign="top">
                                                                <asp:Label ID="lblPolicyNumber" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Issue Date
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblIssueDate" runat="server" />
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                Effective Date
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblEffectiveDate" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Expiration Date
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblExpirationDate" runat="server" />
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                Cancellation Date
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblCancellationDate" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Occurrence Form
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblOccurrenceForm" runat="server" Width="35%" />
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                Each Occurrence
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                $&nbsp;<asp:Label ID="lblOccurrenceCoverage" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Umbrella Form
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblUmbrellaForm" runat="server" Width="35%" />
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                Aggregate
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                $&nbsp;<asp:Label ID="lblAggregate" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Retention
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblRetention" runat="server" Width="35%" />
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                Retention
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                $&nbsp;<asp:Label ID="lblRetentionAmount" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Accept Limits
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblAcceptLimits" runat="server" Width="35%" />
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                Accept Limits
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                $&nbsp;<asp:Label ID="lblAcceptLimitsCoverage" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Special Umbrella Limits
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblSpecialUmbrella" runat="server" Width="35%" />
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                Special Umbrella Limits
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                $&nbsp;<asp:Label ID="lblSpecialUmbrellaCoverage" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                Notes
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" colspan="5" valign="top">
                                                                <uc:ctrlNotes ID="lblNotes" runat="server" ControlType="Label" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div id="dvGrid" runat="server">
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td class="tblGrid" align="left">
                                                <asp:Panel ID="Panel4" runat="server" Style="display: block; height: 100%;">
                                                    <div class="bandHeaderRow">
                                                        Additional Insured</div>
                                                    <table cellpadding="3" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td width="20%" align="left" valign="top">
                                                                Additional Insured Grid<br />
                                                                <a id="lnkGeneralAdd" runat="server" href="javascript:Navigate_URL('AdditionalInsured.aspx');">
                                                                    --Add--</a>
                                                            </td>
                                                            <td width="2%" align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:GridView ID="gvAI" runat="server" Width="100%" OnRowCommand="gvAI_RowCommand">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Name">
                                                                            <ItemStyle Width="30%" HorizontalAlign="left" />
                                                                            <ItemTemplate>
                                                                                <a href="javascript:Navigate_URL('AdditionalInsured.aspx?id=<%#Encryption.Encrypt(Eval("PK_COI_AI").ToString())%>');">
                                                                                    <%# clsGeneral.FormatName(Eval("First_Name"), Eval("Last_Name"))%>
                                                                                </a>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Address">
                                                                            <ItemStyle Width="60%" HorizontalAlign="left" />
                                                                            <ItemTemplate>
                                                                                <%# clsGeneral.FormatAddress(Convert.ToString(Eval("Address_1")), Convert.ToString(Eval("Address_2")), Convert.ToString(Eval("City")), (Eval("FK_State")!= DBNull.Value)? new ERIMS.DAL.State(Convert.ToDecimal(Eval("FK_State"))).FLD_abbreviation : string.Empty, Convert.ToString(Eval("Zip_Code")))%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Remove">
                                                                            <ItemStyle Width="10%" HorizontalAlign="Left" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkRemove" runat="server" Text="Remove" OnClientClick="return ConfirmDelete();"
                                                                                    CommandName="RemoveInsured" CommandArgument='<%#Eval("PK_COI_AI")%>'></asp:LinkButton></ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                        <table cellpadding="0" cellspacing="0" width="100%">
                                                                            <tr>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblMsg" runat="server" SkinID="Message" Text="No Record Exist."></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </EmptyDataTemplate>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="Spacer" style="height: 70px;">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <asp:Panel ID="dvAttachment" runat="server" Style="display: none;">
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td width="100%">
                                                <uc:ctrlAttachmentDetails ID="AttachDetails" runat="Server" runat="Server" ShowReplaceColumn="false" />
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
                    </table>
                </td>
            </tr>
            <tr>
                <td class="Spacer" style="height: 15px;">
                </td>
                <td style="width: 5px;" class="Spacer">
                    &nbsp;
                </td>
                <td align="center">
                    <asp:Label ID="lblNote" runat="server" SkinID="MessageOrNote"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="Spacer" style="height: 15px;">
                </td>
                <td style="width: 5px;" class="Spacer">
                    &nbsp;
                </td>
                <td class="Spacer" style="height: 15px;">
                </td>
            </tr>
            <tr>
                <td class="Spacer" style="height: 25px;">
                </td>
                <td style="width: 5px;" class="Spacer">
                    &nbsp;
                </td>
                <td align="center">
                    <asp:Button ID="btnSave" runat="server" SkinID="SaveAndView" CausesValidation="true"
                        ValidationGroup="vsErrorGroup" OnClick="btnSave_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnReturn" runat="server" SkinID="Revert&Return" CausesValidation="false"
                        OnClick="btnBack_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnBack" runat="server" SkinID="Back" CausesValidation="false" OnClick="btnBack_Click" />
                </td>
            </tr>
            <tr>
                <td class="Spacer" style="height: 15px;">
                </td>
                <td style="width: 5px;" class="Spacer">
                    &nbsp;
                </td>
                <td class="Spacer" style="height: 15px;">
                </td>
            </tr>
        </table>
    </div>
    <asp:Button ID="btnDummyForSave" runat="server" OnClick="btnDummyForSave_Click" Style="display: none"
        CausesValidation="false" />
    <input type="hidden" id="hdnPageName" runat="server" />
    <asp:CustomValidator ID="CustomValidator" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
        Display="None" ValidationGroup="vsErrorGroup" />
    <input id="hdnControlIDs" runat="server" type="hidden" />
    <input id="hdnErrorMsgs" runat="server" type="hidden" />
</asp:Content>
