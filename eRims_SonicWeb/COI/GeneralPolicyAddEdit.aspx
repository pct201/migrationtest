<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Default.master" CodeFile="GeneralPolicyAddEdit.aspx.cs"
    Inherits="Admin_GeneralPolicyAddEdit" %>

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
                    document.getElementById('<%=hdnPageName.ClientID%>').value = PageName;
                    document.getElementById('<%=btnDummyForSave.ClientID%>').click();
                }
            }
        }
        function RedirectToPage(PageName) {
            if (PageName.indexOf("?") > 0)
                window.location.href = PageName + '&Page=GL&prop=<%=Encryption.Encrypt(PK_COI_General_Policies.ToString())%>&coi=<%=Encryption.Encrypt(FK_COI.ToString())%>&op=<%=Request.QueryString["op"]%>';
            else
                window.location.href = PageName + '?Page=GL&prop=<%=Encryption.Encrypt(PK_COI_General_Policies.ToString())%>&coi=<%=Encryption.Encrypt(FK_COI.ToString())%>';
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
                    <uc:ctrlCOIInfo id="ucCtrlCOIInfo" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="Spacer" style="height: 5px;" colspan="3" width="100%">
                </td>
            </tr>
            <tr>
                <td class="leftMenu">
                    <table cellpadding="5" cellspacing="0" width="203px">
                        <tr>
                            <td style="height: 10px;" class="Spacer">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="100%">
                                <span id="Menu1" onclick="javascript:ShowPanel(1);" class="LeftMenuStatic">General Liability Policies</span>
                                <span id="MenuAsterisk1" runat="server" style="color:Red;display:none;">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="100%">
                                <span id="Menu2" onclick="javascript:ShowPanel(2);" class="LeftMenuStatic">Additional Insured</span>                                
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="100%">
                                <span id="Menu3" onclick="javascript:ShowPanel(3);" class="LeftMenuStatic">Attachment</span>                                
                            </td>
                        </tr>
                        <%--<tr>
                            <td style="padding-left: 5px;">
                                <asp:Menu ID="mnuRiskProfile" runat="server" Width="100%" DataSourceID="dsPropertyMenu"
                                    StaticEnableDefaultPopOutImage="false">
                                    <StaticItemTemplate>
                                        <table cellpadding="5" cellspacing="0" width="100%">
                                            <tr>
                                                <td align="left" width="100%">
                                                    <span id="mnuRiskProfile<%#Container.ItemIndex+1%>" onclick="javascript:ShowPanel(<%#Container.ItemIndex+1%>);"
                                                        class="LeftMenuStatic">
                                                        <%#Eval("Text")%>
                                                    </span>
                                                </td>
                                            </tr>
                                        </table>
                                    </StaticItemTemplate>
                                </asp:Menu>
                                <asp:SiteMapDataSource ID="dsPropertyMenu" runat="server" SiteMapProvider="COIGeneralPolicyProvider"
                                    ShowStartingNode="false" />
                            </td>
                        </tr>--%>
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
                                                        General Liability Policies</div>
                                                    <table cellpadding="3" cellspacing="1" width="100%" border="0">
                                                        <tr>
                                                            <td colspan="7">
                                                                <a href="javascript:ShowDialogCOI('Search.aspx?coi=<%=Encryption.Encrypt(FK_COI.ToString())%>&tbl=<%=(int)clsGeneral.Tables.General_Liability_Policies%>');">
                                                                    Find</a>
                                                            </td>
                                                        </tr>
                                                        <tr valign="top">
                                                            <td width="20%" align="left" valign="top">
                                                                Insurance Company&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td width="2%" align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td width="26%" align="left" valign="top">
                                                                <asp:DropDownList ID="drpCompany" runat="server" Width="205px" SkinID="Default" TabIndex="1">
                                                                </asp:DropDownList>
                                                                <%--<asp:RequiredFieldValidator ID="rfvCompany" runat="server" InitialValue="--Select--"
                                                                    ValidationGroup="vsErrorGroup" ErrorMessage="Please Select [General Liability Policies]/Insurance Company"
                                                                    ControlToValidate="drpCompany" Display="none" SetFocusOnError="true" />--%>
                                                            </td>
                                                            <td width="4%">
                                                                &nbsp;
                                                            </td>
                                                            <td width="18%" align="left" valign="top">
                                                                Policy Number&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td width="2%" align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td width="28%" align="left" valign="top">
                                                                <asp:TextBox ID="txtPolicyNumber" runat="server" Width="200px" MaxLength="35" TabIndex="13"></asp:TextBox>
                                                                <%--<asp:RequiredFieldValidator ID="rfvPolicyNumber" runat="server" ValidationGroup="vsErrorGroup"
                                                                    ErrorMessage="Please Enter [General Liability Policies]/Policy Number" ControlToValidate="txtPolicyNumber"
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
                                                                    ErrorMessage="Please enter [General Liability Policies]/Issue Date" RegularExpressionMessage="Please enter Valid [General Liability Policies]/Issue Date"
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
                                                                    ErrorMessage="Please enter [General Liability Policies]/Effective Date" RegularExpressionMessage="Please enter Valid [General Liability Policies]/Effective Date"
                                                                    TabIndex="14" />
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
                                                                    ErrorMessage="Please enter [General Liability Policies]/Expiration Date" RegularExpressionMessage="Please enter Valid [General Liability Policies]/Expiration Date"
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
                                                                <uc:ctrlCalendar ID="txtCancellationDate" runat="server" RegularExpressionMessage="Please enter Valid [General Liability Policies]/Cancellation Date"
                                                                    TabIndex="15" IsRequiredField="false" ErrorMessage="Please enter [General Liability Policies]/Cancellation Date" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Commercial General Liability&nbsp;<span id="Span7" style="color: Red; display: none;"
                                                                    runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:RadioButtonList ID="rdoCommercialLiability" runat="server" SkinID="YesNoType"
                                                                    TabIndex="4" />
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                Each Occurrence&nbsp;<span id="Span8" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                $&nbsp;<asp:TextBox ID="txtOccuranceCoverage" Width="190px" runat="server" SkinID="DollarFieldBox"
                                                                    onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="16"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Product Liability&nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:RadioButtonList ID="rdoProductLiability" runat="server" SkinID="YesNoType" TabIndex="5" />
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                Fire Damage&nbsp;<span id="Span10" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                $&nbsp;<asp:TextBox ID="txtFireDamage" Width="190px" runat="server" SkinID="DollarFieldBox"
                                                                    onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="17"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Occurrence&nbsp;<span id="Span11" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:RadioButtonList ID="rdoOccurrenceLiability" runat="server" SkinID="YesNoType"
                                                                    TabIndex="6" />
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                Medical Expense&nbsp;<span id="Span12" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                $&nbsp;<asp:TextBox ID="txtMedicalExpense" Width="190px" runat="server" SkinID="DollarFieldBox"
                                                                    onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="18"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Personal & Advertising Injury&nbsp;<span id="Span13" style="color: Red; display: none;"
                                                                    runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                $&nbsp;<asp:TextBox ID="txtPersonalInjury" Width="190px" runat="server" SkinID="DollarFieldBox"
                                                                    onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="7"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                General Aggregate&nbsp;<span id="Span14" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                $&nbsp;<asp:TextBox ID="txtGeneralAggregate" Width="190px" runat="server" SkinID="DollarFieldBox"
                                                                    onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="19"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Products-Completed Operations&nbsp;<span id="Span15" style="color: Red; display: none;"
                                                                    runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                $&nbsp;<asp:TextBox ID="txtProductOperations" Width="190px" runat="server" SkinID="DollarFieldBox"
                                                                    onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="8"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                General Aggregate Limit Applies to&nbsp;<span id="Span16" style="color: Red; display: none;"
                                                                    runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:RadioButtonList ID="rdoGAappliesTo" runat="server" TabIndex="20">
                                                                    <asp:ListItem Text="Policy" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Project" Value="2"></asp:ListItem>
                                                                    <asp:ListItem Text="Location" Value="3"></asp:ListItem>
                                                                    <asp:ListItem Text="N/A" Value="0" Selected="True"></asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Other Liability1&nbsp;<span id="Span17" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtOtherLiability1" runat="server" Width="200px" MaxLength="50"
                                                                    TabIndex="9"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                Other Liability1&nbsp;<span id="Span18" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                $&nbsp;<asp:TextBox ID="txtOtherLiabilityCoverage1" Width="190px" runat="server"
                                                                    SkinID="DollarFieldBox" onkeypress="javascript:return FormatNumber(event,this.id,13,false);"
                                                                    TabIndex="21"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Other Liability2&nbsp;<span id="Span19" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtOtherLiability2" runat="server" Width="200px" MaxLength="50"
                                                                    TabIndex="9"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                Other Liability2&nbsp;<span id="Span20" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                $&nbsp;<asp:TextBox ID="txtOtherLiabilityCoverage2" Width="190px" runat="server"
                                                                    SkinID="DollarFieldBox" onkeypress="javascript:return FormatNumber(event,this.id,13,false);"
                                                                    TabIndex="21"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Stop Gap Endorsement&nbsp;<span id="Span21" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:RadioButtonList ID="rdoStopGapEndorsement" runat="server" SkinID="YesNoType"
                                                                    TabIndex="10" />
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                Stop Gap Endorsement&nbsp;<span id="Span22" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                $&nbsp;<asp:TextBox ID="txtStopGapCoverage" Width="190px" runat="server" SkinID="DollarFieldBox"
                                                                    onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="22"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                Auto (If no owned vehicles included in BOP)&nbsp;<span id="Span23" style="color: Red;
                                                                    display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdoAutoLiability" runat="server" SkinID="YesNoType" TabIndex="11" />
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left" valign="top">
                                                                Auto (If no owned vehicles included in BOP)&nbsp;<span id="Span24" style="color: Red;
                                                                    display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top">
                                                                $&nbsp;<asp:TextBox ID="txtAutoCoverage" runat="server" Width="190px" SkinID="DollarFieldBox"
                                                                    onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="23"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                Notes&nbsp;<span id="Span25" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" colspan="5" valign="top">
                                                                <uc:ctrlNotes ID="txtNotes" runat="server" TabIndex="12" Width="600" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height: 5px;" class="Spacer" colspan="7">
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
                                        <tr>
                                            <td class="Spacer" style="height: 10px;">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div id="dvView" runat="server" style="display: none;">
                                    <asp:Panel ID="Panel2" runat="server" Style="display: block; height: 100%">
                                        <div class="bandHeaderRow">
                                            General Liability Policies</div>
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
                                                    Commercial General Liability
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblCommercialLiability" runat="server" Width="35%" />
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
                                                    $&nbsp;<asp:Label ID="lblOccuranceCoverage" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    Product Liability
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblProductLiability" runat="server" Width="35%" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                    Fire Damage
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    $&nbsp;<asp:Label ID="lblFireDamage" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    Occurrence
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblOccurrenceLiability" runat="server" Width="35%" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                    Medical Expense
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    $&nbsp;<asp:Label ID="lblMedicalExpense" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    Personal & Advertising Injury
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    $&nbsp;<asp:Label ID="lblPersonalInjury" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                    General Aggregate
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    $&nbsp;<asp:Label ID="lblGeneralAggregate" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    Products-Completed Operations
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    $&nbsp;<asp:Label ID="lblProductOperations" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                    General Aggregate Limit Applies to
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblGaAppliesTo" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    Other Liability1
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblOtherLiability1" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                    Other Liability1
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    $&nbsp;<asp:Label ID="lblOtherLiabilityCoverage1" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    Other Liability2
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblOtherLiability2" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                    Other Liability2
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    $&nbsp;<asp:Label ID="lblOtherLiabilityCoverage2" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    Stop Gap Endorsement
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblStopGapEndorsement" runat="server" Width="35%" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                    Stop Gap Endorsement
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    $&nbsp;<asp:Label ID="lblStopGapCoverage" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">
                                                    Auto (If no owned vehicles included in BOP)
                                                </td>
                                                <td align="center" valign="top">
                                                    :
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:Label ID="lblAutoLiability" runat="server" Width="35%" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left" valign="top">
                                                    Auto (If no owned vehicles included in BOP)
                                                </td>
                                                <td align="center" valign="top">
                                                    :
                                                </td>
                                                <td align="left" valign="top">
                                                    $&nbsp;<asp:Label ID="lblAutoCoverage" runat="server"></asp:Label>
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
                                            <tr>
                                                <td style="height: 5px;" class="Spacer" colspan="7">
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
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
                                                            <td class="Spacer" style="height: 50px;">
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
                <td class="Spacer" style="height: 15px;">
                </td>
            </tr>
            <tr>
                <td class="Spacer" style="height: 15px;">
                </td>
                <td style="width: 5px;" class="Spacer">
                    &nbsp;
                </td>
                <td align="center">
                    <asp:Button ID="btnSave" runat="server" SkinID="SaveAndView" CausesValidation="true"
                        OnClick="btnSave_Click" ValidationGroup="vsErrorGroup" />&nbsp; &nbsp;&nbsp;&nbsp;
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
    <asp:Button ID="btnDummyForSave" runat="server" OnClick="btnDummyForSave_Click" CausesValidation="false"
        Style="display: none" />
    <input type="hidden" id="hdnPageName" runat="server" />
    <asp:CustomValidator ID="CustomValidator" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
        Display="None" ValidationGroup="vsErrorGroup" />
    <input id="hdnControlIDs" runat="server" type="hidden" />
    <input id="hdnErrorMsgs" runat="server" type="hidden" />
</asp:Content>
