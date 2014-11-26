<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Default.master" CodeFile="WCPolicyAddEdit.aspx.cs"
    Inherits="Admin_WCPolicyAddEdit" %>

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
                window.location.href = PageName + '&Page=WC&prop=<%=Encryption.Encrypt(PK_COI_WC_Policies.ToString())%>&coi=<%=Encryption.Encrypt(FK_COI.ToString())%>&op=<%=Request.QueryString["op"]%>';
            else
                window.location.href = PageName + '?Page=WC&prop=<%=Encryption.Encrypt(PK_COI_WC_Policies.ToString())%>&coi=<%=Encryption.Encrypt(FK_COI.ToString())%>';

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

        function ConfirmDelete() {
            return confirm("Are you sure that you want to remove the data that was selected for deletion?");
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
            document.getElementById('<%=lblNote.ClientID%>').style.display = "none";

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
                <td class="leftMenu" valign="top" style="padding-left: 5px;">
                    <table cellpadding="5" cellspacing="0" width="100%">
                        <tr>
                            <td style="height: 10px;" class="Spacer">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="100%">
                                <span id="Menu1" onclick="javascript:ShowPanel(1);" class="LeftMenuStatic">Worker’s
                                    Compensation/Employer’s Liability Policies Risk Expenses</span>&nbsp;<span id="MenuAsterisk1"
                                        runat="server" style="color: Red; display: none;">*</span>
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
                                                        Worker’s Compensation/Employer’s Liability Policies</div>
                                                    <table cellpadding="3" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td colspan="7">
                                                                <a href="javascript:ShowDialogCOI('Search.aspx?coi=<%=Encryption.Encrypt(FK_COI.ToString())%>&tbl=<%=(int)clsGeneral.Tables.WC_Policies%>');">
                                                                    Find</a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="15%" align="left">
                                                                Insurance Company&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td width="2%" align="center">
                                                                :
                                                            </td>
                                                            <td width="26%" align="left">
                                                                <asp:DropDownList ID="drpCompany" runat="server" Width="205px" SkinID="Default" TabIndex="1">
                                                                </asp:DropDownList>
                                                                <%--<asp:RequiredFieldValidator ID="rfvCompany" runat="server" InitialValue="--Select--"
                                                                    Display="none" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Insurance Company"
                                                                    ControlToValidate="drpCompany" SetFocusOnError="true" />--%>
                                                            </td>
                                                            <td width="2%">
                                                                &nbsp;
                                                            </td>
                                                            <td width="15%" align="left">
                                                                Policy Number&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td width="2%" align="center">
                                                                :
                                                            </td>
                                                            <td width="26%" align="left">
                                                                <asp:TextBox ID="txtPolicyNumber" runat="server" Width="200px" MaxLength="35" TabIndex="9"></asp:TextBox>
                                                                <%--<asp:RequiredFieldValidator ID="rfvPolicyNumber" runat="server" ValidationGroup="vsErrorGroup"
                                                                    ErrorMessage="Please Enter Policy Number" ControlToValidate="txtPolicyNumber"
                                                                    Display="none" SetFocusOnError="true" />--%>
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
                                                                    ErrorMessage="Please enter [Worker’s Compensation Policies]/Issue Date" RegularExpressionMessage="Please enter Valid [Worker’s Compensation Policies]/Issue Date"
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
                                                                    ErrorMessage="Please enter [Worker’s Compensation Policies]/Effective Date" RegularExpressionMessage="Please enter Valid [Worker’s Compensation Policies]/Effective Date"
                                                                    TabIndex="10" />
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
                                                                    ErrorMessage="Please enter [Worker’s Compensation Policies]/Expiration Date"
                                                                    RegularExpressionMessage="Please enter Valid [Worker’s Compensation Policies]/Expiration Date"
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
                                                                <uc:ctrlCalendar ID="txtCancellationDate" runat="server" RegularExpressionMessage="Please enter Valid [Worker’s Compensation Policies]/Cancellation Date"
                                                                    TabIndex="11" IsRequiredField="false" ErrorMessage="Please enter [Worker’s Compensation Policies]/Cancellation Date" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                WC State Limits
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:RadioButtonList ID="rdoStateLimits" runat="server" SkinID="YesNoType" TabIndex="4" />
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                Other
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:RadioButtonList ID="rdoOther" runat="server" SkinID="YesNoType" TabIndex="12" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Proprietor/Partners/Executive Officers are included
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:RadioButtonList ID="rdoManagement" runat="server" SkinID="YesNoType" TabIndex="5" />
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                Each Accident&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                $&nbsp;<asp:TextBox ID="txtAccident" Width="190px" runat="server" SkinID="DollarFieldBox"
                                                                    onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="13"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Leased Employees included
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:RadioButtonList ID="rdoLeasedEmployees" runat="server" SkinID="YesNoType" TabIndex="6" />
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                Disease - Each Employee&nbsp;<span id="Span8" style="color: Red; display: none;"
                                                                    runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                $&nbsp;<asp:TextBox ID="txtDiseaseEach" Width="190px" runat="server" SkinID="DollarFieldBox"
                                                                    onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="14"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                State Funded
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:RadioButtonList ID="rdoStateFunded" runat="server" SkinID="YesNoType" TabIndex="7" />
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                Disease – Policy Limit&nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                $&nbsp;<asp:TextBox ID="txtDiseaseLimit" Width="190px" runat="server" SkinID="DollarFieldBox"
                                                                    onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="15"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                Notes&nbsp;<span id="Span10" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" colspan="5" valign="top">
                                                                <uc:ctrlNotes ID="txtNotes" runat="server" TabIndex="8" Width="600" />
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
                                                        Worker’s Compensation/Employer’s Liability Policies</div>
                                                    <table cellpadding="5" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td width="20%" align="left" valign="top">
                                                                Insurance Company&nbsp;<span class="msg1">*</span>
                                                            </td>
                                                            <td width="2%" align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td width="26%" align="left" valign="top">
                                                                <asp:Label ID="lblCompany" runat="server"></asp:Label>
                                                            </td>
                                                            <td width="2%" valign="top">
                                                                &nbsp;
                                                            </td>
                                                            <td width="20%" align="left" valign="top">
                                                                Policy Number&nbsp;<span class="msg1">*</span>
                                                            </td>
                                                            <td width="2%" align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td width="26%" align="left" valign="top">
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
                                                                WC State Limits
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblStateLimits" runat="server" Width="35%" />
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                Other
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblOther" runat="server" Width="35%" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Proprietor/Partners/Executive Officers are included
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblManagement" runat="server" Width="35%" />
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                Each Accident
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                $&nbsp;<asp:Label ID="lblAccident" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Leased Employees included
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblLeasedEmployees" runat="server" Width="35%" />
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                Disease - Each Employee
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                $&nbsp;<asp:Label ID="lblDiseaseEach" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                State Funded
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblStateFunded" runat="server" Width="35%" />
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                Disease – Policy Limit
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                $&nbsp;<asp:Label ID="lblDiseaseLimit" runat="server"></asp:Label>
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
                                                <asp:Panel ID="Panel4" runat="server" Style="display: block; height: 100%">
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
                                                                <asp:GridView ID="gvAI" runat="server" Width="95%" OnRowCommand="gvAI_RowCommand">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Name">
                                                                            <ItemStyle Width="40%" HorizontalAlign="left" />
                                                                            <ItemTemplate>
                                                                                <a href="javascript:Navigate_URL('AdditionalInsured.aspx?id=<%#Encryption.Encrypt(Eval("PK_COI_AI").ToString())%>');">
                                                                                    <%# clsGeneral.FormatName(Eval("First_Name"), Eval("Last_Name"))%>
                                                                                </a>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Address">
                                                                            <ItemStyle Width="40%" HorizontalAlign="left" />
                                                                            <ItemTemplate>
                                                                                <%# clsGeneral.FormatAddress(Convert.ToString(Eval("Address_1")), Convert.ToString(Eval("Address_2")), Convert.ToString(Eval("City")), (Eval("FK_State")!= DBNull.Value)? new ERIMS.DAL.State(Convert.ToDecimal(Eval("FK_State"))).FLD_abbreviation : string.Empty, Convert.ToString(Eval("Zip_Code")))%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Remove">
                                                                            <ItemStyle Width="20%" HorizontalAlign="Left" />
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
                                                            <td class="Spacer" style="height: 95px;">
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
                                                <uc:ctrlAttachmentDetails ID="AttachDetails" runat="Server" ShowReplaceColumn="false" />
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
                        ValidationGroup="vsErrorGroup" OnClick="btnSave_Click" />&nbsp;
                    <asp:Button ID="btnReturn" runat="server" SkinID="Revert&Return" CausesValidation="false"
                        OnClick="btnReturn_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
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
