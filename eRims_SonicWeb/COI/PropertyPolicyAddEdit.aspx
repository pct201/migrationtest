<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" MasterPageFile="~/Default.master"
    CodeFile="PropertyPolicyAddEdit.aspx.cs" Inherits="Admin_PropertyPolicyAddEdit" %>

<%@ Register Src="~/Controls/Calender/Calender.ascx" TagName="ctrlCalendar" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment_COI/Attachment_COI.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlNotes" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment_COI/AttachmentDetails_COI.ascx" TagName="ctrlAttachmentDetails"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/COIInfo/COIInfo.ascx" TagName="ctrlCOIInfo" TagPrefix="uc" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Validator.js"></script>
    <script type="text/javascript" src="../../JavaScript/JFunctions.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>JavaScript/calendar.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar.js"></script>
    <script type="text/javascript">
        function CheckForValidation() {
            return AlertValidation('<%=Attachment.RequiredAttachTypeID%>', '<%=Attachment.RequiredAttachFileID%>');
        }
        function Navigate_URL(PageName) {
            var strOpr = '<%=Request.QueryString["op"]%>';
            if (strOpr != null && strOpr == "view")
                RedirectToPage(PageName);
            else {
                Page_ClientValidate('vsErrorGroup');
                if (Page_IsValid == true) {
                    document.getElementById('<%=hdnPageName.ClientID%>').value = PageName;
                    document.getElementById('<%=btnDummyForSave.ClientID%>').click();
                }
            }
        }

        function RedirectToPage(PageName) {

            if (PageName.indexOf("?") > 0)
                window.location.href = PageName + '&Page=PP&prop=<%=Encryption.Encrypt(PK_COI_Property_Policies.ToString())%>&coi=<%=Encryption.Encrypt(FK_COI.ToString())%>&op=<%=Request.QueryString["op"]%>';
            else
                window.location.href = PageName + '?Page=PP&prop=<%=Encryption.Encrypt(PK_COI_Property_Policies.ToString())%>&coi=<%=Encryption.Encrypt(FK_COI.ToString())%>';

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
                document.getElementById('<%=btnBackToCOI.ClientID%>').style.display = "inline";
                document.getElementById('<%=btnSaveReturn.ClientID%>').style.display = "inline";
                document.getElementById('<%=btnBack.ClientID%>').style.display = "none";
                document.getElementById('<%=lblNote.ClientID%>').style.display = "block";
                document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";

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
            document.getElementById('<%=btnBackToCOI.ClientID%>').style.display = "none";
            document.getElementById('<%=btnSaveReturn.ClientID%>').style.display = "none";
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
                <td style="height: 10px;" class="Spacer">
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
                    <table cellpadding="5" cellspacing="0" width="190px">
                        <tr>
                            <td style="height: 10px;" class="Spacer">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="100%">
                                <span id="Menu1" onclick="javascript:ShowPanel(1);" class="LeftMenuStatic">Property
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
                        <%--<tr>
                            <td style="padding-left: 5px;">
                                <asp:Menu ID="mnuProperty" runat="server" Width="100%" DataSourceID="dsPropertyMenu"
                                    StaticEnableDefaultPopOutImage="false">
                                    <StaticItemTemplate>
                                        <table cellpadding="5" cellspacing="0" width="100%">
                                            <tr>
                                                <td align="left" width="100%">
                                                    <span id="mnuProperty<%#Container.ItemIndex+1%>" onclick="javascript:ShowPanel(<%#Container.ItemIndex+1%>);"
                                                        class="LeftMenuStatic">
                                                        <%#Eval("Text")%>
                                                    </span>
                                                </td>
                                            </tr>
                                        </table>
                                    </StaticItemTemplate>
                                </asp:Menu>
                                <asp:SiteMapDataSource ID="dsPropertyMenu" runat="server" SiteMapProvider="COIPropertyPolicyProvider"
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
                                            <td class="tblGrid" align="left" width="100%">
                                                <asp:Panel ID="Panel1" runat="server" Style="display: block; height: 100%">
                                                    <div class="bandHeaderRow">
                                                        Property Policies</div>
                                                    <table cellpadding="3" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td style="width: 40%" align="left">
                                                                Insurance Company&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" style="width: 2%">
                                                                :
                                                            </td>
                                                            <td style="width: 18%" align="left">
                                                                <asp:DropDownList ID="drpCompany" runat="server" Width="155px" SkinID="Default" TabIndex="1">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="width: 2%">
                                                                &nbsp;
                                                            </td>
                                                            <td style="width: 18%" align="left">
                                                                Policy Number&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td style="width: 2%" align="center">
                                                                :
                                                            </td>
                                                            <td align="left" style="width: 18%">
                                                                <asp:TextBox ID="txtPolicyNumber" runat="server" Width="140px" MaxLength="35" TabIndex="5"></asp:TextBox>
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
                                                                <asp:TextBox ID="txtIssueDate" runat="server" SkinID="txtdate" MaxLength="10" TabIndex="12"
                                                                    Width="130px"></asp:TextBox>
                                                                <img alt="" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtIssueDate', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="<%=AppConfig.SiteURL%>JavaScript/iconPicDate.gif"
                                                                    align="absmiddle" />
                                                                <asp:RegularExpressionValidator ID="revDateOfProfile" runat="server" ControlToValidate="txtIssueDate"
                                                                    ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                                                    ErrorMessage="Please enter Valid [Property Policies]/Issue Date" Display="none"
                                                                    SetFocusOnError="true" ValidationGroup="vsErrorGroup">
                                                                </asp:RegularExpressionValidator>
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
                                                                <asp:TextBox ID="txtEffectiveDate" runat="server" SkinID="txtdate" MaxLength="10"
                                                                    Width="130px" TabIndex="12"></asp:TextBox>
                                                                <img alt="" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtEffectiveDate', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="<%=AppConfig.SiteURL%>JavaScript/iconPicDate.gif"
                                                                    align="absmiddle" />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEffectiveDate"
                                                                    ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                                                    ErrorMessage="Please enter Valid [Property Policies]/Effective Date" Display="none"
                                                                    SetFocusOnError="true" ValidationGroup="vsErrorGroup">
                                                                </asp:RegularExpressionValidator>
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
                                                                <asp:TextBox ID="txtExpirationDate" runat="server" SkinID="txtdate" MaxLength="10"
                                                                    TabIndex="12" Width="130px"></asp:TextBox>
                                                                <img alt="" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtExpirationDate', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="<%=AppConfig.SiteURL%>JavaScript/iconPicDate.gif"
                                                                    align="absmiddle" />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtExpirationDate"
                                                                    ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                                                    ErrorMessage="Please enter Valid Expiration Date" Display="none" SetFocusOnError="true"
                                                                    ValidationGroup="vsErrorGroup">
                                                                </asp:RegularExpressionValidator>
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
                                                                <asp:TextBox ID="txtCancellationDate" runat="server" SkinID="txtdate" MaxLength="10"
                                                                    TabIndex="12" Width="130px"></asp:TextBox>
                                                                <img alt="" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtCancellationDate', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="<%=AppConfig.SiteURL%>JavaScript/iconPicDate.gif"
                                                                    align="absmiddle" />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtCancellationDate"
                                                                    ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                                                    ErrorMessage="Please enter Valid Cancellation Date" Display="none" SetFocusOnError="true"
                                                                    ValidationGroup="vsErrorGroup">
                                                                </asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Deductible&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                $&nbsp;<asp:TextBox ID="txtDeductible" runat="server" SkinID="DollarFieldBox" onkeypress="javascript:return FormatNumber(event,this.id,13,false);"
                                                                    Width="135px" TabIndex="1"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                Building Value&nbsp;<span id="Span8" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                $&nbsp;<asp:TextBox ID="txtBuildingValue" runat="server" SkinID="DollarFieldBox"
                                                                    Width="135px" onkeypress="javascript:return FormatNumber(event,this.id,13,false);"
                                                                    TabIndex="8"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                Is Boiler and Machinery coverage included on the Property Policy?
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdIsBoilerandMachineryRequired" runat="server" SkinID="YesNoType"
                                                                    RepeatDirection="Horizontal" TabIndex="1">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td valign="top">
                                                                &nbsp;
                                                            </td>
                                                            <td align="left" valign="top">
                                                                If No, is there a separate Boiler and Machinery policy?
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdNoBoilerandMachineryRequired" runat="server" SkinID="YesNoType"
                                                                    RepeatDirection="Horizontal" TabIndex="1">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                Is Flood coverage included on the Property Policy?
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdIsFloodRequired" runat="server" SkinID="YesNoType" RepeatDirection="Horizontal"
                                                                    TabIndex="1">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td valign="top">
                                                                &nbsp;
                                                            </td>
                                                            <td align="left" valign="top">
                                                                If No, is there a separate Flood policy?
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdNoFloodRequired" runat="server" SkinID="YesNoType" RepeatDirection="Horizontal"
                                                                    TabIndex="1">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                Is Earthquake coverage included on the Property Policy?
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdIsEarthquakeRequired" runat="server" SkinID="YesNoType"
                                                                    RepeatDirection="Horizontal" TabIndex="1">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td valign="top">
                                                                &nbsp;
                                                            </td>
                                                            <td align="left" valign="top">
                                                                If No, is there a separate Earthquake policy?
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RadioButtonList ID="rdNoEarthquakeRequired" runat="server" SkinID="YesNoType"
                                                                    RepeatDirection="Horizontal" TabIndex="1">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                Notes&nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" colspan="5" valign="top">
                                                                <uc:ctrlNotes ID="txtNotes" runat="server" TabIndex="4" Width="600" />
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
                                                        Property Policies</div>
                                                    <table cellpadding="5" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td width="40%" align="left" valign="top">
                                                                Insurance Company
                                                            </td>
                                                            <td width="2%" align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td width="18%" align="left" valign="top">
                                                                <asp:Label ID="lblCompany" runat="server"></asp:Label>
                                                            </td>
                                                            <td width="2%" valign="top">
                                                                &nbsp;
                                                            </td>
                                                            <td width="18%" align="left" valign="top">
                                                                Policy Number
                                                            </td>
                                                            <td width="2%" align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td width="18%" align="left" valign="top">
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
                                                                Deductible
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                $&nbsp;<asp:Label ID="lblDeductible" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                Building Value
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                $&nbsp;<asp:Label ID="lblBuildingValue" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                Is Boiler and Machinery coverage included on the Property Policy?
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblIsBoilerandMachineryRequired" runat="server">
                                                                </asp:Label>
                                                            </td>
                                                            <td valign="top">
                                                                &nbsp;
                                                            </td>
                                                            <td align="left" valign="top">
                                                                If No, is there a separate Boiler and Machinery policy?
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblNoBoilerandMachineryRequired" runat="server">
                                                                </asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                Is Flood coverage included on the Property Policy?
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblIsFloodRequired" runat="server">
                                                                </asp:Label>
                                                            </td>
                                                            <td valign="top">
                                                                &nbsp;
                                                            </td>
                                                            <td align="left" valign="top">
                                                                If No, is there a separate Flood policy?
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblNoFloodRequired" runat="server">
                                                                </asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                Is Earthquake coverage included on the Property Policy?
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblIsEarthquakeRequired" runat="server">
                                                                </asp:Label>
                                                            </td>
                                                            <td valign="top">
                                                                &nbsp;
                                                            </td>
                                                            <td align="left" valign="top">
                                                                If No, is there a separate Earthquake policy?
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblNoEarthquakeRequired" runat="server">
                                                                </asp:Label>
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
                                                            <td class="Spacer" style="height: 80px;">
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
                                                                <asp:GridView ID="gvAI" runat="server" Width="100%" OnRowCommand="gvAI_RowCommand">
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
                <td class="Spacer" style="height: 10px;">
                </td>
                <td style="width: 5px;" class="Spacer">
                    &nbsp;
                </td>
                <td align="center">
                    <asp:Label ID="lblNote" runat="server" SkinID="MessageOrNote"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="Spacer" style="height: 10px;">
                </td>
                <td style="width: 5px;" class="Spacer">
                    &nbsp;
                </td>
                <td class="Spacer" style="height: 10px;">
                </td>
            </tr>
            <tr>
                <td class="Spacer" style="height: 10px;">
                </td>
                <td style="width: 5px;" class="Spacer">
                    &nbsp;
                </td>
                <td align="center">
                    <asp:Button ID="btnSave" runat="server" SkinID="Save" CausesValidation="true" OnClick="btnSave_Click"
                        ValidationGroup="vsErrorGroup" />&nbsp;
                    <asp:Button ID="btnBackToCOI" runat="server" SkinID="revert&Return" CausesValidation="false"
                        OnClick="btnBackToCOI_Click" />&nbsp;
                    <asp:Button ID="btnSaveReturn" runat="server" OnClick="btnSaveReturn_Click" SkinID="save&return"
                        CausesValidation="true" ValidationGroup="vsErrorGroup" />
                    <asp:Button ID="btnBack" runat="server" SkinID="Back" OnClick="btnBack_Click" CausesValidation="false" />
                </td>
            </tr>
            <tr>
                <td class="Spacer" style="height: 10px;">
                </td>
                <td style="width: 5px;" class="Spacer">
                    &nbsp;
                </td>
                <td class="Spacer" style="height: 10px;">
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
