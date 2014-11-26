<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Default.master" CodeFile="RiskProfileAddEdit.aspx.cs"
    Inherits="Admin_RiskProfileAddEdit" %>

<%@ Register Src="~/Controls/Calender/Calender.ascx" TagName="ctrlCalendar" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment_COI/Attachment_COI.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attachment_COI/AttachmentDetails_COI.ascx" TagName="ctrlAttachmentDetails"
    TagPrefix="uc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>JavaScript/calendar.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Date_Validation.js"></script>
    <script type="text/javascript">
        var currIndex = 1;
        function ShowPrevNext(index) {
            ShowPanel(parseInt(currIndex, 10) + parseInt(index, 10));
        }
        function CheckForValidation() {
            return AlertValidation('<%=Attachment.RequiredAttachTypeID%>', '<%=Attachment.RequiredAttachFileID%>');
        }
        function SetMenuStyle(index) {
            var i;
            for (i = 1; i <= 9; i++) {

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
            if (prev != null && next != null) {
                if (index == 1) {
                    prev.disabled = true;
                    next.disabled = false;
                }
                else if (index == 9) {
                    prev.disabled = false;
                    next.disabled = true;
                }
                else {
                    prev.disabled = false;
                    next.disabled = false;
                }
            }
            var prevview = document.getElementById('<%=btnPreviousView.ClientID%>');
            var nextview = document.getElementById('<%=btnNextView.ClientID%>');
            if (index == 1) {
                prevview.disabled = true;
                nextview.disabled = false;
            }
            else if (index == 9) {
                prevview.disabled = false;
                nextview.disabled = true;
            }
            else {
                prevview.disabled = false;
                nextview.disabled = false;
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
            var op = '<%=StrOperation%>';
            if (op == "view") {
                var prev = document.getElementById('<%=btnPrev.ClientID%>');
                var next = document.getElementById('<%=btnNext.ClientID%>');
                if (prev != null)
                    prev.style.display = "none";
                if (next != null)
                    next.style.display = "none";
                document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
                ShowPanelView(index);
            }
            else {

                if (index < 9) {
                    for (i = 1; i < 16; i++) {
                        document.getElementById("ctl00_ContentPlaceHolder1_Panel" + i).style.display = "none";
                    }
                    document.getElementById("ctl00_ContentPlaceHolder1_Panel" + index).style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_Div1").style.display = "none";

                    document.getElementById("<%=dvAttachment.ClientID%>").style.display = "none";
                }
                else {
                    for (i = 1; i < 16; i++) {
                        document.getElementById("ctl00_ContentPlaceHolder1_Panel" + i).style.display = "none";
                    }
                    document.getElementById("ctl00_ContentPlaceHolder1_Panel1").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_Div1").style.display = "block";

                    document.getElementById("<%=dvAttachment.ClientID%>").style.display = "block";
                }
                SetFocusOnFirstControl(index);
            }
        }

        function ShowPanelView(index) {
            SetMenuStyle(index);
            document.getElementById('<%=dvView.ClientID%>').style.display = "block";
            var i;
            if (index < 9) {
                for (i = 9; i <= 16; i++) {

                    document.getElementById("ctl00_ContentPlaceHolder1_Panel" + i).style.display = "none";
                }
                document.getElementById("ctl00_ContentPlaceHolder1_Panel" + (8 + index)).style.display = "block";
            }
            else {
                for (i = 9; i <= 16; i++) {
                    document.getElementById("ctl00_ContentPlaceHolder1_Panel" + i).style.display = "none";
                }
                document.getElementById("<%=dvAttachment.ClientID%>").style.display = "block";
            }
        }

        function SetFocusOnFirstControl(index) {
            switch (index) {
                case 1:
                    document.getElementById('ctl00_ContentPlaceHolder1_txtName').focus(); break;
                case 2:
                    document.getElementById('ctl00_ContentPlaceHolder1_txtGeneralOccur').focus(); break;
                case 3:
                    document.getElementById('ctl00_ContentPlaceHolder1_txtCombinedLimit').focus(); break;
                case 4:
                    document.getElementById('ctl00_ContentPlaceHolder1_txtExcessOccur').focus(); break;
                case 5:
                    document.getElementById('ctl00_ContentPlaceHolder1_txtWCEachAccident').focus(); break;
                case 6:
                    document.getElementById('ctl00_ContentPlaceHolder1_txtDeductible').focus(); break;
                case 7:
                    document.getElementById('ctl00_ContentPlaceHolder1_txtProfOccur').focus(); break;
                case 8:
                    document.getElementById('ctl00_ContentPlaceHolder1_txtLiquorOccur').focus(); break;
                case 9:
                    document.getElementById('ctl00_ContentPlaceHolder1_Attachment_drpAttachType').focus();
                    break;
                default:
                    break;
            }
        }
        function IfSave() {
            var values = '<%=ViewState["ProfileID"]%>';
            if (values == '' || values == '0') {
                alert('Please Save Risk Profile Record First');
                ShowPanel(1);
                return false;
            }
            else return Page_ClientValidate('AddAttachment');
        }

        function ValSave() {
            if (Page_ClientValidate("vsErrorGroup"))
                return true;
            else
                return false;
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
                <td class="leftMenu">
                    <table cellpadding="5" cellspacing="0" width="203px">
                        <tr>
                            <td style="height: 10px;" class="Spacer">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="100%">
                                <span id="Menu1" onclick="javascript:ShowPanel(1);" class="LeftMenuStatic">Identification</span>
                                <span id="MenuAsterisk1" runat="server" style="color:Red;display:none">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="100%">
                                <span id="Menu2" onclick="javascript:ShowPanel(2);" class="LeftMenuStatic">General – Minimum Limits</span>
                                <span id="MenuAsterisk2" runat="server" style="color:Red;display:none">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="100%">
                                <span id="Menu3" onclick="javascript:ShowPanel(3);" class="LeftMenuStatic">Auto – Minimum Limits</span>
                                <span id="MenuAsterisk3" runat="server" style="color:Red;display:none">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="100%">
                                <span id="Menu4" onclick="javascript:ShowPanel(4);" class="LeftMenuStatic">Excess – Minimum Limits</span>
                                <span id="MenuAsterisk4" runat="server" style="color:Red;display:none">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="100%">
                                <span id="Menu5" onclick="javascript:ShowPanel(5);" class="LeftMenuStatic">Worker’s Compensation – Minimum Limits</span>
                                <span id="MenuAsterisk5" runat="server" style="color:Red;display:none">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="100%">
                                <span id="Menu6" onclick="javascript:ShowPanel(6);" class="LeftMenuStatic">Property – Minimum Limits</span>
                                <span id="MenuAsterisk6" runat="server" style="color:Red;display:none">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="100%">
                                <span id="Menu7" onclick="javascript:ShowPanel(7);" class="LeftMenuStatic">Professional Liability – Minimum Limits</span>
                                <span id="MenuAsterisk7" runat="server" style="color:Red;display:none">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="100%">
                                <span id="Menu8" onclick="javascript:ShowPanel(8);" class="LeftMenuStatic">Other Liability – Minimum Limits</span>
                                <span id="MenuAsterisk8" runat="server" style="color:Red;display:none">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="100%">
                                <span id="Menu9" onclick="javascript:ShowPanel(9);" class="LeftMenuStatic">Attachment</span>                                
                            </td>
                        </tr>

                        <tr>
                            <td style="height: 10px;" class="Spacer">
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
                                    <asp:Panel ID="Panel1" runat="server" Style="display: block; height: 100%">
                                        <div class="bandHeaderRow">
                                            Identification</div>
                                        <table cellpadding="3" cellspacing="1" width="100%" border="0">
                                            <tr>
                                                <td colspan="7">
                                                    <a href="javascript:ShowDialogCOI('Search.aspx?tbl=<%=(int)clsGeneral.Tables.Risk_Profile%>');">
                                                        Find</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="20%" align="left">
                                                    Name&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td width="2%" align="center" valign="middle">
                                                    :
                                                </td>
                                                <td width="26%" align="left">
                                                    &nbsp;<asp:TextBox ID="txtName" runat="server" MaxLength="50" Width="215px" TabIndex="1"></asp:TextBox>                                                  
                                                </td>
                                                <td width="2%">
                                                    &nbsp;
                                                </td>
                                                <td width="20%" align="left">
                                                    Date of Profile&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td width="2%" align="center">
                                                    :
                                                </td>
                                                <td width="26%" align="left">
                                                    <asp:TextBox ID="txtDateofProfile" runat="server" MaxLength="10" Width="170px" SkinID="txtDate" TabIndex="3"></asp:TextBox>
                                                    <img alt="" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDateofProfile', 'mm/dd/y');"
                                                        onmouseover="javascript:this.style.cursor='hand';" src="<%=AppConfig.SiteURL%>JavaScript/iconPicDate.gif"
                                                        align="absmiddle" />
                                                    <asp:RegularExpressionValidator ID="revIssueDateFrom" runat="server" ControlToValidate="txtDateofProfile"
                                                       ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                                        ErrorMessage="Please Enter Valid [Identification]/Date of Profile." Display="none"
                                                        ValidationGroup="vsErrorGroup" SetFocusOnError="true">
                                                    </asp:RegularExpressionValidator>                                                 
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    Aggregate Minimum&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td align="center" valign="top">
                                                    :
                                                </td>
                                                <td align="left">
                                                    $&nbsp;<asp:TextBox ID="txtAggregateMin" Width="210px" runat="server" SkinID="DollarFieldBox"
                                                        onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="2" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                    Umbrella Minimum&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    $&nbsp;<asp:TextBox ID="txtUmbrellaMin" Width="160px" runat="server" SkinID="DollarFieldBox"
                                                        onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="4"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Spacer" style="height: 180px;">
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel2" runat="server" Style="display: none;">
                                        <div class="bandHeaderRow">
                                            General – Minimum Limits</div>
                                        <table cellpadding="3" cellspacing="1" width="100%">
                                            <tr>
                                                <td style="width: 10px;" class="Spacer" colspan="7">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="20%" align="left">
                                                    Each Occurrence&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td align="center" style="width: 11px;" valign="middle">
                                                    :
                                                </td>
                                                <td width="26%" align="left">
                                                    $&nbsp;<asp:TextBox ID="txtGeneralOccur" runat="server" SkinID="DollarFieldBox" onkeypress="javascript:return FormatNumber(event,this.id,13,false);"
                                                        TabIndex="1"></asp:TextBox>
                                                </td>
                                                <td width="2%">
                                                    &nbsp;
                                                </td>
                                                <td width="20%" align="left">
                                                    Fire Damage&nbsp;<span id="Span6" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td width="2%" align="center" valign="middle">
                                                    :
                                                </td>
                                                <td width="26%" align="left">
                                                    $&nbsp;<asp:TextBox ID="txtFireDamage" runat="server" SkinID="DollarFieldBox" onkeypress="javascript:return FormatNumber(event,this.id,13,false);"
                                                        TabIndex="5"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="height: 27px">
                                                    Medical Expense&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td align="center" style="width: 11px; height: 27px">
                                                    :
                                                </td>
                                                <td align="left" style="height: 27px">
                                                    $&nbsp;<asp:TextBox ID="txtMedicalExpense" runat="server" SkinID="DollarFieldBox"
                                                        onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="2"></asp:TextBox>
                                                </td>
                                                <td style="height: 27px">
                                                    &nbsp;
                                                </td>
                                                <td align="left" style="height: 27px">
                                                    Personal & Advertising Injury&nbsp;<span id="Span8" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td align="center" style="height: 27px">
                                                    :
                                                </td>
                                                <td align="left" style="height: 27px">
                                                    $&nbsp;<asp:TextBox ID="txtPersonalInjury" runat="server" SkinID="DollarFieldBox"
                                                        onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="6"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    General Aggregate&nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td align="center" style="width: 11px">
                                                    :
                                                </td>
                                                <td align="left">
                                                    $&nbsp;<asp:TextBox ID="txtGeneralAggregate" runat="server" SkinID="DollarFieldBox"
                                                        onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="3"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                    Completed Operations&nbsp;<span id="Span10" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    $&nbsp;<asp:TextBox ID="txtOperations" runat="server" SkinID="DollarFieldBox" onkeypress="javascript:return FormatNumber(event,this.id,13,false);"
                                                        TabIndex="7"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    Stop Gap Endorsement&nbsp;<span id="Span11" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td align="center" style="width: 11px">
                                                    :
                                                </td>
                                                <td align="left">
                                                    $&nbsp;<asp:TextBox ID="txtStopGap" runat="server" SkinID="DollarFieldBox" onkeypress="javascript:return FormatNumber(event,this.id,13,false);"
                                                        TabIndex="4"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                    Auto (If no owned vehicles in BOP)&nbsp;<span id="Span12" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    $&nbsp;<asp:TextBox ID="txtAutoCoverage" runat="server" SkinID="DollarFieldBox" onkeypress="javascript:return FormatNumber(event,this.id,13,false);"
                                                        TabIndex="8"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Spacer" style="height: 130px;">
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel3" runat="server" Style="display: none;">
                                        <div class="bandHeaderRow">
                                            Auto – Minimum Limits</div>
                                        <table cellpadding="3" cellspacing="1" width="100%">
                                            <tr>
                                                <td style="width: 10px;" class="Spacer" colspan="7">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="20%" align="left">
                                                    Combined Single Limit&nbsp;<span id="Span13" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td width="2%" align="center">
                                                    :
                                                </td>
                                                <td width="26%" align="left">
                                                    $&nbsp;<asp:TextBox ID="txtCombinedLimit" runat="server" SkinID="DollarFieldBox"
                                                        onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="1"></asp:TextBox>
                                                </td>
                                                <td width="2%">
                                                    &nbsp;
                                                </td>
                                                <td width="20%" align="left">
                                                    Bodily Injury (Per Person)&nbsp;<span id="Span14" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td width="2%" align="center">
                                                    :
                                                </td>
                                                <td width="26%" align="left">
                                                    $&nbsp;<asp:TextBox ID="txtBodilyInjuryPerson" runat="server" SkinID="DollarFieldBox"
                                                        onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="3"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    Bodily Injury (Per Accident)&nbsp;<span id="Span15" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    $&nbsp;<asp:TextBox ID="txtBodilyInjuryAccident" runat="server" SkinID="DollarFieldBox"
                                                        onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="2"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                    Property Damage&nbsp;<span id="Span16" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    $&nbsp;<asp:TextBox ID="txtPropertyDamage" runat="server" SkinID="DollarFieldBox"
                                                        onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="4"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Spacer" style="height: 200px;">
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel4" runat="server" Style="display: none;">
                                        <div class="bandHeaderRow">
                                            Excess – Minimum Limits</div>
                                        <table cellpadding="3" cellspacing="1" width="100%">
                                            <tr>
                                                <td style="width: 10px;" class="Spacer" colspan="7">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="20%" align="left">
                                                    Each Occurrence&nbsp;<span id="Span17" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td width="2%" align="center">
                                                    :
                                                </td>
                                                <td width="26%" align="left">
                                                    $&nbsp;<asp:TextBox ID="txtExcessOccur" runat="server" SkinID="DollarFieldBox" onkeypress="javascript:return FormatNumber(event,this.id,13,false);"
                                                        TabIndex="1"></asp:TextBox>
                                                </td>
                                                <td width="2%">
                                                    &nbsp;
                                                </td>
                                                <td width="20%" align="left">
                                                    Aggregate&nbsp;<span id="Span18" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td width="2%" align="center">
                                                    :
                                                </td>
                                                <td width="26%" align="left">
                                                    $&nbsp;<asp:TextBox ID="txtExcessAggregate" runat="server" SkinID="DollarFieldBox"
                                                        onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="4"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    Retention&nbsp;<span id="Span19" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    $&nbsp;<asp:TextBox ID="txtRetention" runat="server" SkinID="DollarFieldBox" onkeypress="javascript:return FormatNumber(event,this.id,13,false);"
                                                        TabIndex="2"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                    Accept Limits&nbsp;<span id="Span20" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    $&nbsp;<asp:TextBox ID="txtAcceptLimit" runat="server" SkinID="DollarFieldBox" onkeypress="javascript:return FormatNumber(event,this.id,13,false);"
                                                        TabIndex="5"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    Special Umbrella Limits&nbsp;<span id="Span21" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    $&nbsp;<asp:TextBox ID="txtUmbrellaLimit" runat="server" SkinID="DollarFieldBox"
                                                        onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="3"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Spacer" style="height: 180px;">
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel5" runat="server" Style="display: none;">
                                        <div class="bandHeaderRow">
                                            Worker’s Compensation – Minimum Limits</div>
                                        <table cellpadding="3" cellspacing="1" width="100%">
                                            <tr>
                                                <td style="width: 10px;" class="Spacer" colspan="7">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="20%" align="left">
                                                    Each Accident&nbsp;<span id="Span22" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td width="2%" align="center">
                                                    :
                                                </td>
                                                <td width="26%" align="left">
                                                    $&nbsp;<asp:TextBox ID="txtWCEachAccident" runat="server" SkinID="DollarFieldBox"
                                                        onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="1"></asp:TextBox>
                                                </td>
                                                <td width="2%">
                                                    &nbsp;
                                                </td>
                                                <td width="20%" align="left">
                                                    Disease – Each Employee&nbsp;<span id="Span23" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td width="2%" align="center">
                                                    :
                                                </td>
                                                <td width="26%" align="left">
                                                    $&nbsp;<asp:TextBox ID="txtDiseaseEmployee" runat="server" SkinID="DollarFieldBox"
                                                        onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="3"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    Disease – Policy Limit&nbsp;<span id="Span24" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    $&nbsp;<asp:TextBox ID="txtDiseacePolicyLimit" runat="server" SkinID="DollarFieldBox"
                                                        onkeypress="javascript:return FormatNumber(event,this.id,13,false);" TabIndex="2"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Spacer" style="height: 195px;">
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel6" runat="server" Style="display: none;">
                                        <div class="bandHeaderRow">
                                            Property – Minimum Limits</div>
                                               <table cellpadding="3" cellspacing="1" width="100%">
                                            <tr>
                                                <td style="width: 10px;" class="Spacer" colspan="7">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="26%" align="left">
                                                    Deductible&nbsp;<span id="Span25" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td width="2%" align="center">
                                                    :
                                                </td>
                                                <td width="26%" align="left">
                                                    $&nbsp;<asp:TextBox ID="txtDeductible" runat="server" SkinID="DollarFieldBox" onkeypress="javascript:return FormatNumber(event,this.id,13,false);"
                                                        TabIndex="1"></asp:TextBox>
                                                </td>
                                                <td width="2%">
                                                    &nbsp;
                                                </td>
                                                <td width="15%" align="left">
                                                   Building Value&nbsp;<span id="Span26" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td width="2%" align="center">
                                                    :
                                                </td>
                                                <td width="25%" align="left">
                                                    $&nbsp;<asp:TextBox ID="txtBuildingValue" runat="server" SkinID="DollarFieldBox" onkeypress="javascript:return FormatNumber(event,this.id,13,false);"
                                                        TabIndex="8"></asp:TextBox>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td class="Spacer" style="height: 15px;">&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                   Boiler and Machinery Required?&nbsp;<span id="Span27" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    <asp:RadioButtonList ID="rdBoilerandMachineryRequired" runat="server" SkinID="YesNoType" RepeatDirection="Horizontal"
                                                        TabIndex="1">
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                   Flood Required?&nbsp;<span id="Span28" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                     <asp:RadioButtonList ID="rdFloodRequired" runat="server" SkinID="YesNoType" RepeatDirection="Horizontal"
                                                        TabIndex="1">
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                   Earthquake Required?&nbsp;<span id="Span29" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td align="center" valign="top">
                                                    :
                                                </td>
                                                <td align="left" valign="top">
                                                   <asp:RadioButtonList ID="rdEarthquakeRequired" runat="server" SkinID="YesNoType" RepeatDirection="Horizontal"
                                                        TabIndex="1">
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                    &nbsp;
                                                </td>
                                                <td align="center">
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                    &nbsp;
                                                </td>
                                            </tr>                                           
                                            <tr>
                                                <td class="Spacer" style="height: 150px;">
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel7" runat="server" Style="display: none;">
                                        <div class="bandHeaderRow">
                                            Professional Liability – Minimum Limits</div>
                                        <table cellpadding="3" cellspacing="1" width="100%">
                                            <tr>
                                                <td style="width: 10px;" class="Spacer" colspan="7">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="20%" align="left">
                                                    Each Occurrence&nbsp;<span id="Span30" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td width="2%" align="center">
                                                    :
                                                </td>
                                                <td width="26%" align="left">
                                                    $&nbsp;<asp:TextBox ID="txtProfOccur" runat="server" SkinID="DollarFieldBox" onkeypress="javascript:return FormatNumber(event,this.id,13,false);"></asp:TextBox>
                                                </td>
                                                <td width="2%">
                                                    &nbsp;
                                                </td>
                                                <td width="20%" align="left">
                                                    Aggregate&nbsp;<span id="Span31" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td width="2%" align="center">
                                                    :
                                                </td>
                                                <td width="26%" align="left">
                                                    $&nbsp;<asp:TextBox ID="txtProfAggregate" runat="server" SkinID="DollarFieldBox"
                                                        onkeypress="javascript:return FormatNumber(event,this.id,13,false);" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Spacer" style="height: 225px;">
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel8" runat="server" Style="display: none;">
                                        <div class="bandHeaderRow">
                                            Other Liability – Minimum Limits</div>
                                        <table cellpadding="3" cellspacing="1" width="100%">
                                            <tr>
                                                <td style="width: 10px;" class="Spacer" colspan="7">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="20%" align="left">
                                                    Each Occurrence&nbsp;<span id="Span32" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td width="2%" align="center">
                                                    :
                                                </td>
                                                <td width="26%" align="left">
                                                    $&nbsp;<asp:TextBox ID="txtLiquorOccur" runat="server" SkinID="DollarFieldBox" onkeypress="javascript:return FormatNumber(event,this.id,13,false);"></asp:TextBox>
                                                </td>
                                                <td width="2%">
                                                    &nbsp;
                                                </td>
                                                <td width="20%" align="left">
                                                    Aggregate&nbsp;<span id="Span33" style="color: Red; display: none;" runat="server">*</span>
                                                </td>
                                                <td width="2%" align="center">
                                                    :
                                                </td>
                                                <td width="26%" align="left">
                                                    $&nbsp;<asp:TextBox ID="txtLiquorAggregate" runat="server" SkinID="DollarFieldBox"
                                                        onkeypress="javascript:return FormatNumber(event,this.id,13,false);" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Spacer" style="height: 225px;">
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <div id="Div1" runat="server" style="display: none;">
                                        <table cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td width="100%">
                                                    <uc:ctrlAttachment ID="Attachment" runat="Server" OnbtnHandler="Attachment_btnHandler" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Spacer" style="height: 10px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Spacer" style="height: 10px;">
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div id="dvView" runat="server" style="display: none;">
                                    <asp:Panel ID="Panel9" runat="server" Style="display: block; height: 100%">
                                        <div class="bandHeaderRow">
                                            Identification</div>
                                        <table cellpadding="5" cellspacing="1" width="100%">
                                            <tr>
                                                <td width="20%" align="left">
                                                    Name
                                                </td>
                                                <td width="2%" align="center">
                                                    :
                                                </td>
                                                <td width="26%" align="left">
                                                    <asp:Label ID="lblName" runat="server"></asp:Label>
                                                </td>
                                                <td width="2%">
                                                    &nbsp;
                                                </td>
                                                <td width="20%" align="left">
                                                    Date of Profile
                                                </td>
                                                <td width="2%" align="center">
                                                    :
                                                </td>
                                                <td width="26%" align="left">
                                                    <asp:Label ID="lblDateofProfile" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    Aggregate Minimum
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    $&nbsp;<asp:Label ID="lblAggregateMin" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                    Umbrella Minimum
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    $&nbsp;<asp:Label ID="lblUmbrellaMin" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Spacer" style="height: 210px;">
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel10" runat="server" Style="display: none; height: 100%">
                                        <div class="bandHeaderRow">
                                            General – Minimum Limits</div>
                                        <table cellpadding="5" cellspacing="1" width="100%">
                                            <tr>
                                                <td width="20%" align="left">
                                                    Each Occurrence
                                                </td>
                                                <td width="2%" align="center">
                                                    :
                                                </td>
                                                <td width="26%" align="left">
                                                    $&nbsp;<asp:Label ID="lblGeneralOccur" runat="server"></asp:Label>
                                                </td>
                                                <td width="2%">
                                                    &nbsp;
                                                </td>
                                                <td width="20%" align="left">
                                                    Fire Damage
                                                </td>
                                                <td width="2%" align="center">
                                                    :
                                                </td>
                                                <td width="26%" align="left">
                                                    $&nbsp;<asp:Label ID="lblFireDamage" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    Medical Expense
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    $&nbsp;<asp:Label ID="lblMedicalExpense" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                    Personal & Advertising Injury
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    $&nbsp;<asp:Label ID="lblPersonalInjury" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    General Aggregate
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    $&nbsp;<asp:Label ID="lblGeneralAggregate" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                    Completed Operations
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    $&nbsp;<asp:Label ID="lblOperations" runat="server"></asp:Label>
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
                                                    $&nbsp;<asp:Label ID="lblStopGap" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                    Auto (If no owned vehicles in BOP)
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    $&nbsp;<asp:Label ID="lblAutoCoverage" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Spacer" style="height: 160px;">
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel11" runat="server" Style="display: none; height: 100%">
                                        <div class="bandHeaderRow">
                                            Auto – Minimum Limits</div>
                                        <table cellpadding="5" cellspacing="1" width="100%">
                                            <tr>
                                                <td width="20%" align="left">
                                                    Combined Single Limit
                                                </td>
                                                <td width="2%" align="center">
                                                    :
                                                </td>
                                                <td width="26%" align="left">
                                                    $&nbsp;<asp:Label ID="lblCombinedLimit" runat="server"></asp:Label>
                                                </td>
                                                <td width="2%">
                                                    &nbsp;
                                                </td>
                                                <td width="20%" align="left">
                                                    Bodily Injury (Per Person)
                                                </td>
                                                <td width="2%" align="center">
                                                    :
                                                </td>
                                                <td width="26%" align="left">
                                                    $&nbsp;<asp:Label ID="lblBodilyInjuryPerson" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    Bodily Injury (Per Accident)
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    $&nbsp;<asp:Label ID="lblBodilyInjuryAccident" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                    Property Damage
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    $&nbsp;<asp:Label ID="lblPropertyDamage" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Spacer" style="height: 210px;">
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel12" runat="server" Style="display: none; height: 100%">
                                        <div class="bandHeaderRow">
                                            Excess – Minimum Limits</div>
                                        <table cellpadding="5" cellspacing="1" width="100%">
                                            <tr>
                                                <td width="20%" align="left">
                                                    Each Occurrence
                                                </td>
                                                <td width="2%" align="center">
                                                    :
                                                </td>
                                                <td width="26%" align="left">
                                                    $&nbsp;<asp:Label ID="lblExcessOccur" runat="server"></asp:Label>
                                                </td>
                                                <td width="2%">
                                                    &nbsp;
                                                </td>
                                                <td width="20%" align="left">
                                                    Aggregate
                                                </td>
                                                <td width="2%" align="center">
                                                    :
                                                </td>
                                                <td width="26%" align="left">
                                                    $&nbsp;<asp:Label ID="lblExcessAggregate" runat="server"></asp:Label>
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
                                                    $&nbsp;<asp:Label ID="lblRetention" runat="server"></asp:Label>
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
                                                    $&nbsp;<asp:Label ID="lblAcceptLimit" runat="server"></asp:Label>
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
                                                    $&nbsp;<asp:Label ID="lblUmbrellaLimit" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Spacer" style="height: 200px;">
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel13" runat="server" Style="display: none; height: 100%">
                                        <div class="bandHeaderRow">
                                            Worker’s Compensation – Minimum Limits</div>
                                        <table cellpadding="5" cellspacing="1" width="100%">
                                            <tr>
                                                <td width="20%" align="left">
                                                    Each Accident
                                                </td>
                                                <td width="2%" align="center">
                                                    :
                                                </td>
                                                <td width="26%" align="left">
                                                    $&nbsp;<asp:Label ID="lblWCEachAccident" runat="server"></asp:Label>
                                                </td>
                                                <td width="2%">
                                                    &nbsp;
                                                </td>
                                                <td width="20%" align="left">
                                                    Disease – Each Employee
                                                </td>
                                                <td width="2%" align="center">
                                                    :
                                                </td>
                                                <td width="26%" align="left">
                                                    $&nbsp;<asp:Label ID="lblDiseaseEmployee" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    Disease – Policy Limit
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    $&nbsp;<asp:Label ID="lblDiseacePolicyLimit" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Spacer" style="height: 220px;">
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel14" runat="server" Style="display: none; height: 100%">
                                        <div class="bandHeaderRow">
                                            Property – Minimum Limits</div>
                                             <table cellpadding="5" cellspacing="1" width="100%">
                                            <tr>
                                                <td width="26%" align="left">
                                                    Deductible
                                                </td>
                                                <td width="2%" align="center">
                                                    :
                                                </td>
                                                <td width="26%" align="left">
                                                    $&nbsp;<asp:Label ID="lblDeductible" runat="server"></asp:Label>
                                                </td>
                                                <td width="2%">
                                                    &nbsp;
                                                </td>
                                                <td width="15%" align="left">
                                                    Building Value
                                                </td>
                                                <td width="2%" align="center">
                                                    :
                                                </td>
                                                <td width="25%" align="left">
                                                    $&nbsp;<asp:Label ID="lblBuildingValue" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                   Boiler and Machinery Required?
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblBoilerandMachineryRequired" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                    Flood Required?
                                                </td>
                                                <td align="center">
                                                    :
                                                </td>
                                                <td align="left">
                                                   <asp:Label ID="lblFloodRequired" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    Earthquake Required?
                                                </td>
                                                <td align="center" valign="top">
                                                    :
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:Label ID="lblEarthquakeRequired" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                   &nbsp;
                                                </td>
                                                <td align="center">
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                    &nbsp;
                                                </td>
                                            </tr>                                           
                                            <tr>
                                                <td class="Spacer" style="height: 190px;">
                                                </td>
                                            </tr>
                                        </table>                                      
                                    </asp:Panel>
                                    <asp:Panel ID="Panel15" runat="server" Style="display: none; height: 100%">
                                        <div class="bandHeaderRow">
                                            Professional Liability – Minimum Limits</div>
                                        <table cellpadding="5" cellspacing="1" width="100%">
                                            <tr>
                                                <td width="20%" align="left">
                                                    Each Occurrence
                                                </td>
                                                <td width="2%" align="center">
                                                    :
                                                </td>
                                                <td width="26%" align="left">
                                                    $&nbsp;<asp:Label ID="lblProfOccur" runat="server"></asp:Label>
                                                </td>
                                                <td width="2%">
                                                    &nbsp;
                                                </td>
                                                <td width="20%" align="left">
                                                    Aggregate
                                                </td>
                                                <td width="2%" align="center">
                                                    :
                                                </td>
                                                <td width="26%" align="left">
                                                    $&nbsp;<asp:Label ID="lblProfAggregate" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Spacer" style="height: 240px;">
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel16" runat="server" Style="display: none; height: 100%">
                                        <div class="bandHeaderRow">
                                            Other Liability – Minimum Limits</div>
                                        <table cellpadding="5" cellspacing="1" width="100%">
                                            <tr>
                                                <td width="20%" align="left">
                                                    Each Occurrence
                                                </td>
                                                <td width="2%" align="center">
                                                    :
                                                </td>
                                                <td width="26%" align="left">
                                                    $&nbsp;<asp:Label ID="lblLiquorOccur" runat="server"></asp:Label>
                                                </td>
                                                <td width="2%">
                                                    &nbsp;
                                                </td>
                                                <td width="20%" align="left">
                                                    Aggregate
                                                </td>
                                                <td width="2%" align="center">
                                                    :
                                                </td>
                                                <td width="26%" align="left">
                                                    $&nbsp;<asp:Label ID="lblLiquorAggregate" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Spacer" style="height: 240px;">
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </div>
                                <asp:Panel ID="dvAttachment" runat="server" Width="100%" Style="display: none;">
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td width="100%" valign="top">
                                                <uc:ctrlAttachmentDetails ID="AttachDetails" runat="Server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="Spacer" style="height: 180px;">
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
                <td class="Spacer" style="height: 35px; width: 480px;">
                </td>
                <td style="width: 5px;" class="Spacer">
                    &nbsp;
                </td>
                <td width="100%" align="center">
                    <div id="dvSave" runat="server" style="display: none;">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td class="Spacer" style="height: 7px;" colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td width="36%" align="right" valign="top">
                                    <input id="btnPrev" runat="server" onclick="javascript:ShowPrevNext(-1);" type="button"
                                        value="Previous" style="background-position: left top; background-repeat: no-repeat;
                                        border-style: outset; color: Navy; font-weight: bold; cursor: pointer;" />&nbsp;
                                </td>
                                <td width="17%" align="center" valign="top">
                                    <asp:Button ID="btnSave" runat="server" SkinID="SaveAndView" CausesValidation="true"
                                        ValidationGroup="vsErrorGroup" OnClientClick="return ValSave();" OnClick="btnSave_Click" />&nbsp;
                                </td>
                                <td align="left" valign="top">
                                    <input id="btnNext" runat="server" onclick="javascript:ShowPrevNext(1);" style="background-position: left top;
                                        background-repeat: no-repeat; border-style: outset; color: Navy; font-weight: bold;
                                        cursor: pointer;" type="button" value=" Next " />
                                </td>
                            </tr>
                            <tr>
                                <td class="Spacer" style="height: 5px;" colspan="3">
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="dvBack" runat="server" style="display: none;">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td width="41%" align="right" valign="top">
                                    <input id="btnPreviousView" runat="server" onclick="javascript:ShowPrevNext(-1);"
                                        type="button" value="Previous" style="background-position: left top; background-repeat: no-repeat;
                                        border-style: outset; color: Navy; font-weight: bold; cursor: pointer;" />&nbsp;
                                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CausesValidation="false" Visible="false"
                                        OnClick="btnEdit_Click" />
                                </td>
                                <td width="12%" align="center" valign="top">
                                    <asp:Button ID="btnBack" runat="server" SkinID="Back" CausesValidation="false" OnClick="btnBack_Click" />
                                </td>
                                <td align="left" valign="top">
                                    <input id="btnNextView" runat="server" onclick="javascript:ShowPrevNext(1);" style="background-position: left top;
                                        background-repeat: no-repeat; border-style: outset; color: Navy; font-weight: bold;
                                        cursor: pointer;" type="button" value=" Next " />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <asp:CustomValidator ID="CustomValidator" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
        Display="None" ValidationGroup="vsErrorGroup" />
    <input id="hdnControlIDs" runat="server" type="hidden" />
    <input id="hdnErrorMsgs" runat="server" type="hidden" />
</asp:Content>
