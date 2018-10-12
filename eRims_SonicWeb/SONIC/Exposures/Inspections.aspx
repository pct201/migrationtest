<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Inspections.aspx.cs"
    Inherits="Exposures_Inspections" Title="eRIMS Sonic :: Exposures :: Inspection Data" %>

<%@ Register Src="~/Controls/ExposuresTab/ExposuresTab.ascx" TagName="CtlTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Attchment-Exposures/Attachment.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposureInfo/ExposureInfo.ascx" TagName="ctrlExposureInfo"
    TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript">
        function AuditPopUp(page) {
            var ID = "";
            ID = document.getElementById('<%=hdnInspectionID.ClientID %>').value;
            var strOp = '<%=strOperation%>';
            var drp;
            if (strOp == "view")
                drp = document.getElementById('<%=drpFocusAreasView.ClientID%>');
            else
                drp = document.getElementById('<%=drpFocusAreasEdit.ClientID%>');

            var focusArea = drp.options[drp.selectedIndex].innerHTML;

            var winHeight = window.screen.availHeight - 280;
            var winWidth = window.screen.availWidth - 200;

            obj = window.open("AuditPopup_ExpInspections.aspx?id=" + ID + "&focusarea=" + focusArea, 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }

        function AlertNoDeficiencies() {
            if (document.getElementById('<%=chkNoDeficiency.ClientID%>').checked) {
                alert('By selecting this option, any deficiencies marked Yes will not be entered.');
            }
        }

        function ValSave() {

            var grid = document.getElementById("<%= gvInspectionEdit.ClientID %>");

            if (grid.rows.length > 0) {
                //loop starts from 1. rows[0] points to the header.
                for (i = 0; i < grid.rows.length; i++) {

                    if (i + 2 < 10) { xzzy = '0' } else { xzzy = '' };

                    if (document.getElementById('ctl00_ContentPlaceHolder1_gvInspectionEdit_ctl' + xzzy + (i + 2) + '_rdoDefeciancy_0').checked) {
                        document.getElementById('ctl00_ContentPlaceHolder1_gvInspectionEdit_ctl' + xzzy + (i + 2) + '_regActualCompletionDate').enabled = true;
                        document.getElementById('ctl00_ContentPlaceHolder1_gvInspectionEdit_ctl' + xzzy + (i + 2) + '_cmptxtActualCompletionDate').enabled = true;
                        if (document.getElementById('ctl00_ContentPlaceHolder1_gvInspectionEdit_ctl' + xzzy + (i + 2) + '_hdnDeficientAnswer').value == 'Y') {
                            document.getElementById('ctl00_ContentPlaceHolder1_gvInspectionEdit_ctl' + xzzy + (i + 2) + '_rfvDateOpened').enabled = true;
                            document.getElementById('ctl00_ContentPlaceHolder1_gvInspectionEdit_ctl' + xzzy + (i + 2) + '_regTargetCompleteDate').enabled = true;
                            document.getElementById('ctl00_ContentPlaceHolder1_gvInspectionEdit_ctl' + xzzy + (i + 2) + '_revDateOpened').enabled = true;
                            document.getElementById('ctl00_ContentPlaceHolder1_gvInspectionEdit_ctl' + xzzy + (i + 2) + '_rfvTargetCompletionDate').enabled = true;
                        }
                        else {
                            document.getElementById('ctl00_ContentPlaceHolder1_gvInspectionEdit_ctl' + xzzy + (i + 2) + '_rfvDateOpened').enabled = false;
                            document.getElementById('ctl00_ContentPlaceHolder1_gvInspectionEdit_ctl' + xzzy + (i + 2) + '_regTargetCompleteDate').enabled = false;
                            document.getElementById('ctl00_ContentPlaceHolder1_gvInspectionEdit_ctl' + xzzy + (i + 2) + '_revDateOpened').enabled = false;
                            document.getElementById('ctl00_ContentPlaceHolder1_gvInspectionEdit_ctl' + xzzy + (i + 2) + '_rfvTargetCompletionDate').enabled = false;
                        }
                    }
                    else {
                        document.getElementById('ctl00_ContentPlaceHolder1_gvInspectionEdit_ctl' + xzzy + (i + 2) + '_rfvDateOpened').enabled = false;
                        document.getElementById('ctl00_ContentPlaceHolder1_gvInspectionEdit_ctl' + xzzy + (i + 2) + '_revDateOpened').enabled = false;
                        document.getElementById('ctl00_ContentPlaceHolder1_gvInspectionEdit_ctl' + xzzy + (i + 2) + '_rfvTargetCompletionDate').enabled = false;
                        document.getElementById('ctl00_ContentPlaceHolder1_gvInspectionEdit_ctl' + xzzy + (i + 2) + '_regTargetCompleteDate').enabled = false;
                        document.getElementById('ctl00_ContentPlaceHolder1_gvInspectionEdit_ctl' + xzzy + (i + 2) + '_regActualCompletionDate').enabled = false;
                        document.getElementById('ctl00_ContentPlaceHolder1_gvInspectionEdit_ctl' + xzzy + (i + 2) + '_cmptxtActualCompletionDate').enabled = false;
                    }

                    if (document.getElementById('ctl00_ContentPlaceHolder1_gvInspectionEdit_ctl' + xzzy + (i + 2) + '_rdoMaintenance_0').checked) {
                        document.getElementById('ctl00_ContentPlaceHolder1_gvInspectionEdit_ctl' + xzzy + (i + 2) + '_revTitle').enabled = true;
                        document.getElementById('ctl00_ContentPlaceHolder1_gvInspectionEdit_ctl' + xzzy + (i + 2) + '_txtProblemDescription_rfvNotes').enabled = true;
                    }
                    else
                    {
                        document.getElementById('ctl00_ContentPlaceHolder1_gvInspectionEdit_ctl' + xzzy + (i + 2) + '_revTitle').enabled = false;
                        document.getElementById('ctl00_ContentPlaceHolder1_gvInspectionEdit_ctl' + xzzy + (i + 2) + '_txtProblemDescription_rfvNotes').enabled = false;

                    }
                }
            }
            if (Page_ClientValidate('vsInspection')) {
                return true;
            }
            else
                return false;
        }

        function openWindow(strURL) {
            oWnd = window.open(strURL, "Erims", "location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=300");
            //oWnd.moveTo(260,180);
            //return false;
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
                        case "select-multiple": if (ctrl.selectedIndex == -1) bEmpty = true; break;
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
    <asp:CustomValidator ID="CustomValidator" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
        Display="None" ValidationGroup="vsInspection" />
    <input id="hdnControlIDs" runat="server" type="hidden" />
    <input id="hdnErrorMsgs" runat="server" type="hidden" />
    <asp:ValidationSummary ID="valInspection" runat="server" ValidationGroup="vsInspection"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following fields:"
        BorderWidth="1" BorderColor="DimGray" CssClass="errormessage" />
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
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100%" style="height: 50px;" valign="bottom" colspan="2">
                <uc:CtlTab runat="server" ID="Tab"></uc:CtlTab>
            </td>
        </tr>
        <tr>
            <td>
                <%--<asp:UpdatePanel runat="server" ID="updtOtherInspections" UpdateMode="Always">
                    <ContentTemplate>--%>
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td class="Spacer" width="100%" style="height: 15px;" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" colspan="2">
                            <uc:ctrlExposureInfo ID="ucCtrlExposureInfo" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" style="height: 5px;" colspan="2" width="100%">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:GridView ID="gvOtherInspections" runat="server" AutoGenerateColumns="false"
                                OnSorting="gvOtherInspections_Sorting" OnRowCommand="gvOtherInspections_RowCommand"
                                Width="98%" EmptyDataText="No Inspection Record Found" OnRowCreated="gvOtherInspections_RowCreated"
                                AllowPaging="true" PageSize="5" OnPageIndexChanging="gvOtherInspections_PageIndexChanging"
                                DataKeyNames="PK_Inspection_ID" AllowSorting="true">
                                <Columns>
                                    <asp:TemplateField HeaderText="">
                                        <ItemStyle Width="10%" HorizontalAlign="left" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkViewDetails" runat="server" CommandArgument='<%# Eval("PK_Inspection_ID")%>'
                                                CommandName="ViewDetails" Text='<%# Container.DataItemIndex + 1 %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Inspection Date" HeaderStyle-HorizontalAlign="left"
                                        SortExpression="date">
                                        <ItemStyle Width="20%" HorizontalAlign="left" />
                                        <ItemTemplate>
                                            <%# Eval("date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("date"))) : string.Empty %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Inspector Name" HeaderStyle-HorizontalAlign="left"
                                        SortExpression="Inspector_Name">
                                        <ItemStyle Width="25%" HorizontalAlign="left" />
                                        <ItemTemplate>
                                            <%# Eval("Inspector_Name")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Inspection Area" HeaderStyle-HorizontalAlign="left"
                                        SortExpression="Fld_Desc">
                                        <ItemStyle Width="20%" HorizontalAlign="left" />
                                        <ItemTemplate>
                                            <%# Eval("Fld_Desc")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Number of Deficiencies" HeaderStyle-HorizontalAlign="left"
                                        SortExpression="Deficiency_Count">
                                        <ItemStyle Width="15%" HorizontalAlign="left" />
                                        <ItemTemplate>
                                            <%# Eval("Deficiency_Count")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Report" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle Width="20%" HorizontalAlign="center" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkView" runat="server" Text="Prepare" CommandArgument='<%# Eval("PK_Inspection_ID")%>'
                                                CommandName="ViewAllInspections" />&nbsp;
                                            <%--<a href='javascript:ShowEmailPopUp(<%#Eval("PK_Inspection_ID")%>);'>
                                                            Email</a>--%>
                                            <asp:LinkButton ID="lnkMail" runat="server" Text="Mail" CommandArgument='<%# Eval("PK_Inspection_ID")%>'
                                                CommandName="SendMail" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemStyle Width="10%" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkRemove" runat="server" CommandArgument='<%# Eval("PK_Inspection_ID")%>'
                                                CommandName="RemoveInspection" Text='Remove' OnClientClick="return confirm('Are you sure to delete?');" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" style="height: 5px;" colspan="2" width="100%">
                        </td>
                    </tr>
                    <tr>
                        <td width="50%" align="left" valign="top">
                            <table width="100%">
                                <tr>
                                    <td width="50%" align="left">
                                        &nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lnkAddNew" runat="server" Text="Add New"
                                            OnClick="lnkAddNew_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" style="height: 5px;" colspan="2" width="100%">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" width="100%">
                            <input type="hidden" id="hdnInspectionID" runat="server" />
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td style="width: 100%" valign="top" class="dvContainer">
                                        <div id="dvEdit" runat="server" style="width: 100%;">
                                            <asp:Panel ID="pnlInspections" runat="server" Width="100%">
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" width="15%">
                                                            Inspection Date&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="31%">
                                                            <asp:TextBox runat="server" ID="txtDate" Width="170px" SkinID="txtDate"></asp:TextBox>
                                                            <img alt="Date Opened" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                align="middle" /><br />
                                                            <asp:RangeValidator ID="revDate" ControlToValidate="txtDate" MinimumValue="01/01/1753"
                                                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="Inspection Date is not valid."
                                                                runat="server" SetFocusOnError="true" ValidationGroup="vsInspection" Display="none" />
                                                        </td>
                                                        <td align="left" width="15%">
                                                            Inspector Name&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="31%">
                                                            <asp:TextBox ID="txtInspectorName" runat="server" MaxLength="50" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="15%">
                                                            Inspection Area&nbsp;<span style="color: Red;">*</span>
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="31%">
                                                            <asp:DropDownList runat="server" ID="drpInspectionArea" Width="170px" SkinID="drpInspectionArea" OnSelectedIndexChanged="drpInspectionArea_SelectedIndexChanged" AutoPostBack="true">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="reqdrp" runat="server" ValidationGroup="vsInspection"
                                                                ControlToValidate="drpInspectionArea" ErrorMessage="Please Select Inspection Area"
                                                                SetFocusOnError="true" InitialValue="0" Display="None"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td align="left" width="15%">
                                                            Date Inspection Report was Initially Distributed
                                                        </td>
                                                        <td align="center" width="4%">
                                                            :
                                                        </td>
                                                        <td align="left" width="31%">
                                                            <asp:Label ID="lblDateofInitialDistributionReportEdit" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Number of Deficiencies for this Inspection
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblNumberofDeficienciesInspectionEdit" runat="server" />
                                                        </td>
                                                        <td align="left">
                                                            Number of Repeat Deficiencies Noted on this Inspection
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblNumberofRepeatDeficienciesEdit" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            RLCM Verified?
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:RadioButtonList ID="rdoRLCMVerified" runat="server" SkinID="YesNoType" />
                                                        </td>
                                                        <td align="left">
                                                            No Deficiencies Found
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:CheckBox ID="chkNoDeficiency" runat="server" onclick="return AlertNoDeficiencies();" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            Overall Inspection Comments&nbsp;<span id="Span3" style="color: Red; display: none;"
                                                                runat="server">*</span>
                                                        </td>
                                                        <td align="center" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtOverallInspectionComments" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                      <%--  <td colspan="6">
                                                            <table cellpadding="0" cellspacing="0" width="100%" align="center">
                                                                <tr>--%>
                                                                    <td align="left" valign="middle">
                                                                        <b>Select Focus Area</b>
                                                                    </td>
                                                                    <td align="center" valign="middle">
                                                                        :
                                                                    </td>
                                                                    <td align="left"  width="37%">
                                                                        <asp:DropDownList ID="drpFocusAreasEdit" runat="server" AutoPostBack="true" CausesValidation="false"
                                                                            OnSelectedIndexChanged="drpFocusAreas_SelectedIndedChanged" />
                                                                    </td>
                                                                <td colspan="3">
                                                                        &nbsp;
                                                                    </td>
                                                               <%--     </tr>
                                                            </table>
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td class="Spacer" style="height: 10px;">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <b>Focus Area</b>
                                                        </td>
                                                        <td align="center">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            <b>Question Text</b>
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center">
                                                            <table>
                                                                <tr>
                                                                    <td align="left">
                                                                        <div style="width:80px;">
                                                                        <b>Deficiency</b>
                                                                        </div>
                                                                    </td>
                                                                    <td align="right">
                                                                         <div style="width:100px;">
                                                                        <b>Maintenance</b>
                                                                             </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="6">
                                                            <asp:GridView ID="gvInspectionEdit" runat="server" Width="100%" ShowHeader="false"
                                                                AutoGenerateColumns="false" DataKeyNames="PK_Inspection_Questions_ID" SkinID="Default"
                                                                OnRowDataBound="gvInspectionEdit_OnRowDataBound">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="19%" VerticalAlign="top" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblFocus_Area" runat="server" Text='<%# Container.DataItemIndex == 0 ? Eval("Item_Number_Focus_Area") : ""%>' />
                                                                            <input type="hidden" id="hdnResponseID" runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="81%" VerticalAlign="top" />
                                                                        <ItemTemplate>
                                                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                                                <tr>
                                                                                    <td width="100%">
                                                                                        <table cellpadding="2" cellspacing="1" width="100%">
                                                                                            <tr>
                                                                                                <td width="3%" align="left">
                                                                                                    <%#Eval("Question_Number")%>
                                                                                                </td>
                                                                                                <td width="75%" align="left">
                                                                                                    <%#Eval("Question_Text")%>
                                                                                                </td>
                                                                                                <td align="left" width="22%">
                                                                                                    <table>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RadioButtonList ID="rdoDefeciancy" runat="server" SkinID="YesNoType" Width="100px" />
                                                                                                                <input type="hidden" id="hdnDeficientAnswer" runat="server" value='<%#Eval("Deficient_Answer")%>' />
                                                                                                            </td>
                                                                                                            <td>&nbsp;&nbsp;</td>
                                                                                                            <td>
                                                                                                                <asp:RadioButtonList ID="rdoMaintenance" runat="server" SkinID="YesNoType" Width="100px" />
                                                                                                                <input type="hidden" id="hdnMaintenance" runat="server" value='<%# !string.IsNullOrEmpty(Convert.ToString(Eval("Title"))) ? "Y" : "N" %>' />
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left">
                                                                                                    <img id="imgGuidance" runat="server" src="../../Images/plus.jpg" alt="" style="cursor: pointer;" />
                                                                                                </td>
                                                                                                <td colspan="2">
                                                                                                    Guidance
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left">
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                                <td colspan="2">
                                                                                                    <table cellpadding="0" cellspacing="0" width="100%">
                                                                                                        <tr>
                                                                                                            <td width="100%" id="tdGuidanceText" runat="server">
                                                                                                                <%#Eval("Guidance_Text")%>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td width="100%" id="tdResponseDetails" runat="server" style="display: none;">
                                                                                                                <table cellpadding="3" cellspacing="1" width="100%">
                                                                                                                    <tr>
                                                                                                                        <td width="18%" align="left" valign="top">
                                                                                                                            Repeat Deficiency?
                                                                                                                        </td>
                                                                                                                        <td width="4%" align="center" valign="top">
                                                                                                                            :
                                                                                                                        </td>
                                                                                                                        <td align="left" valign="top">
                                                                                                                            <asp:RadioButtonList ID="rdoRepeatDeficiency" runat="server" SkinID="YesNoType" Enabled='<%# Convert.ToString(Eval("Question_Text")).Contains("Misc") ? true : false %>' />
                                                                                                                        </td>
                                                                                                                        <td colspan="3">
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td width="18%" align="left" valign="top">
                                                                                                                            Department
                                                                                                                        </td>
                                                                                                                        <td width="4%" align="center" valign="top">
                                                                                                                            :
                                                                                                                        </td>
                                                                                                                        <td align="left" valign="top" colspan="4">
                                                                                                                            <%--<asp:DropDownList ID="drpDepartment" runat="server" Width="170px" EnableViewState="false" />--%>
                                                                                                                            <asp:CheckBoxList ID="chkDepartments" runat="server" Width="100%" RepeatColumns="3" />
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td align="left">
                                                                                                                            Date opened&nbsp;<span style="color: Red;">*</span>
                                                                                                                        </td>
                                                                                                                        <td align="center">
                                                                                                                            :
                                                                                                                        </td>
                                                                                                                        <td align="left">
                                                                                                                            <asp:TextBox ID="txtDateOpened" runat="server" Width="140px" SkinID="txtDate"></asp:TextBox>
                                                                                                                            <img id="imgDateOpened" runat="server" alt="Date Opened" onmouseover="javascript:this.style.cursor='hand';"
                                                                                                                                src="../../Images/iconPicDate.gif" align="middle" /><br />
                                                                                                                            <asp:RequiredFieldValidator ID="rfvDateOpened" runat="Server" ValidationGroup="vsInspection"
                                                                                                                                ErrorMessage="Please Select Date opened" SetFocusOnError="true" Display="none"
                                                                                                                                ControlToValidate="txtDateOpened">        
                                                                                                                            </asp:RequiredFieldValidator>
                                                                                                                            <asp:RangeValidator ID="revDateOpened" ControlToValidate="txtDateOpened" MinimumValue="01/01/1753"
                                                                                                                                MaximumValue="12/31/9999" Type="Date" ErrorMessage='<%# "Focus area [" + Eval("Item_Number_Focus_Area") + "], Question [" + Eval("Question_Number") + "] Date Opened is not valid." %>'
                                                                                                                                runat="server" SetFocusOnError="true" ValidationGroup="vsInspection" Display="none" />
                                                                                                                        </td>
                                                                                                                        <td align="left" width="18%">
                                                                                                                            Days Open
                                                                                                                        </td>
                                                                                                                        <td align="center" width="4%">
                                                                                                                            :
                                                                                                                        </td>
                                                                                                                        <td align="left" width="28%">
                                                                                                                            <asp:Label ID="lblDays" runat="server" />
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td align="left" colspan="6">
                                                                                                                            Corrective Action:
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td colspan="6">
                                                                                                                            <uc:ctrlMultiLineTextBox ID="txtAction" runat="server" MaxLength="4000" />
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td align="left">
                                                                                                                            Target Completion Date&nbsp;<span style="color: Red;">*</span>
                                                                                                                        </td>
                                                                                                                        <td align="center">
                                                                                                                            :
                                                                                                                        </td>
                                                                                                                        <td align="left">
                                                                                                                            <asp:TextBox ID="txtTargetCompleteDate" runat="server" Width="140px" SkinID="txtDate"></asp:TextBox>
                                                                                                                            <img id="imgTargetCompletionDate" runat="server" alt="Target Completion Date" onmouseover="javascript:this.style.cursor='hand';"
                                                                                                                                src="../../Images/iconPicDate.gif" align="middle" /><br />
                                                                                                                            <asp:RequiredFieldValidator ID="rfvTargetCompletionDate" runat="Server" ValidationGroup="vsInspection"
                                                                                                                                ErrorMessage="Please Select Target Completion Date" SetFocusOnError="true" Display="none"
                                                                                                                                ControlToValidate="txtTargetCompleteDate">        
                                                                                                                            </asp:RequiredFieldValidator>
                                                                                                                            <asp:RangeValidator ID="regTargetCompleteDate" ControlToValidate="txtTargetCompleteDate"
                                                                                                                                MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage='<%# "Focus area [" + Eval("Item_Number_Focus_Area") + "], Question [" + Eval("Question_Number") + "] Target Complete Date is not valid."%>'
                                                                                                                                runat="server" SetFocusOnError="true" ValidationGroup="vsInspection" Display="none" />
                                                                                                                        </td>
                                                                                                                        <td align="left">
                                                                                                                            Actual Completion Date
                                                                                                                        </td>
                                                                                                                        <td align="center">
                                                                                                                            :
                                                                                                                        </td>
                                                                                                                        <td align="left">
                                                                                                                            <asp:TextBox ID="txtActualCompletionDate" runat="server" Width="140px" SkinID="txtDate"></asp:TextBox>
                                                                                                                            <img id="imgActualCompletionDate" runat="server" alt="Actual Completion Date" onmouseover="javascript:this.style.cursor='hand';"
                                                                                                                                src="../../Images/iconPicDate.gif" align="middle" /><br />
                                                                                                                            <asp:RangeValidator ID="regActualCompletionDate" ControlToValidate="txtActualCompletionDate"
                                                                                                                                MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage='<%# "Focus area [" + Eval("Item_Number_Focus_Area") + "], Question [" + Eval("Question_Number") + "] Actual Completion Date is not valid."%>'
                                                                                                                                runat="server" SetFocusOnError="true" ValidationGroup="vsInspection" Display="none" />
                                                                                                                            <asp:CompareValidator ID="cmptxtActualCompletionDate" runat="server" ControlToValidate="txtActualCompletionDate"
                                                                                                                                ControlToCompare="txtDateOpened" Type="Date" Operator="GreaterThanEqual" ValidationGroup="vsInspection"
                                                                                                                                ErrorMessage="Actual Completion Date must be Greater Than or Equal To Date opened."
                                                                                                                                Display="None"></asp:CompareValidator>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td align="left" colspan="6">
                                                                                                                            Notes:
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td colspan="6">
                                                                                                                            <uc:ctrlMultiLineTextBox ID="txtNotes" runat="server" MaxLength="4000" />
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                </table>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td colspan="6">
                                                                                                                &nbsp;
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                       <tr>
                                                                                                           <td width="100%" id="tdMaintDetails" runat="server" style="display: none;">
                                                                                                                <table cellpadding="3" cellspacing="1" width="100%">
                                                                                                                 <tr>
                                                                                                                     <td width="18%" align="left" valign="top">
                                                                                                                         <b>Title</b>&nbsp;<span id="Span1" style="color: Red;" runat="server">*</span>
                                                                                                                     </td>
                                                                                                                     <td width="4%" align="center" valign="top">
                                                                                                                         :
                                                                                                                     </td>
                                                                                                                     <td align="left" valign="top" colspan="4" width="78%">
                                                                                                                         <asp:TextBox ID="txtTitle" runat="server" Width="400px"></asp:TextBox>
                                                                                                                         <asp:RequiredFieldValidator ID="revTitle" ControlToValidate="txtTitle" runat="server" ErrorMessage="Please Enter Title" SetFocusOnError="true" Display="none" ValidationGroup="vsInspection">
                                                                                                                         </asp:RequiredFieldValidator>
                                                                                                                     </td>
                                                                                                                 </tr>
                                                                                                                 <tr>
                                                                                                                     <td  align="left" valign="top" width="18%">
                                                                                                                         <b>Problem Description</b>&nbsp;<span id="Span4" style="color: Red;" runat="server">*</span>
                                                                                                                     </td>
                                                                                                                     <td  align="center" valign="top" width="4%">
                                                                                                                         :
                                                                                                                     </td>
                                                                                                                     <td align="left" valign="top" colspan="4" width="78%">
                                                                                                                     </td>
                                                                                                                 </tr>
                                                                                                                    <tr>
                                                                                                                        <td colspan="6">
                                                                                                                             <uc:ctrlMultiLineTextBox ID="txtProblemDescription" runat="server" MaxLength="300" ControlType="TextBox" ValidationGroup="vsInspection" IsRequired="true" 
                                                                                                                                 RequiredFieldMessage="Please Enter Problem Description" SetFocusOnError="true" />
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                              </table>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Spacer" style="height: 10px;">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="6">
                                                            <b>Focus Area Attachments</b><br />
                                                            <i>Click to view detail</i>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Spacer" style="height: 10px;">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="6">
                                                            <asp:GridView ID="gvFocusAreaAttachmentEdit" runat="server" Width="100%" OnRowDataBound="gvFocusAreaAttachement_RowDataBound"
                                                                OnRowCommand="gvFocusAreaAttachmentEdit_RowCommand" EmptyDataText="Currently there is no attachment<br/>Please add one or more attachment">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="File Name">
                                                                        <ItemStyle Width="35%" />
                                                                        <ItemTemplate>
                                                                            <a id="lnkAttachFile" runat="server" href="#">
                                                                                <%# Eval("FileName").ToString().Substring(12, (Eval("FileName").ToString().Length-1) - 11)%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Type">
                                                                        <ItemStyle Width="35%" />
                                                                        <ItemTemplate>
                                                                            <%# Eval("Type") %></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle Width="30%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemoveAttachment" runat="server" Text="Remove" CommandArgument='<%#Eval("PK_Inspection_Responses_Attachments_ID") + ":" + Eval("FileName") %>'
                                                                                CommandName="RemoveAttachment" OnClientClick="return confirm('Are you sure to remove this attachment?')" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Spacer" style="height: 5px;">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="6">
                                                            <asp:LinkButton ID="lnkAddNewFAAttach" runat="server" Text="--Add New--" OnClick="lnkAddNewFAAttach_Click"
                                                                CausesValidation="true" ValidationGroup="vsInspection" OnClientClick="javascript:return ValSave();"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr id="trAttachmentFA" runat="server" style="display: none;">
                                                        <td align="left" colspan="6">
                                                            <uc:ctrlAttachment runat="server" ID="ucInspectionFocusAreaAttachment" OnFileSelection="UploadFocusArea_Attachment" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Spacer" style="height: 10px;">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="6">
                                                            <b>Inspection Attachments</b><br />
                                                            <i>Click to view detail</i>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Spacer" style="height: 10px;">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="6">
                                                            <asp:GridView ID="gvAttachmentDetails" runat="server" Width="100%" OnRowDataBound="gvAttachmentDetails_RowDataBound"
                                                                OnRowCommand="gvAttachmentDetails_RowCommand" EmptyDataText="Currently there is no attachment<br/>Please add one or more attachment">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="File Name">
                                                                        <ItemStyle Width="35%" />
                                                                        <ItemTemplate>
                                                                            <a id="lnkAttachFile" runat="server" href="#">
                                                                                <%# Eval("FileName").ToString().Substring(12, (Eval("FileName").ToString().Length-1) - 11)%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Type">
                                                                        <ItemStyle Width="35%" />
                                                                        <ItemTemplate>
                                                                            <%# Eval("Type") %></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remove">
                                                                        <ItemStyle Width="30%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRemoveAttachment" runat="server" Text="Remove" CommandArgument='<%#Eval("PK_Inspection_Attachments_ID") + ":" + Eval("FileName") %>'
                                                                                CommandName="RemoveAttachment" OnClientClick="return confirm('Are you sure to remove this attachment?')" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Spacer" style="height: 5px;">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="6">
                                                            <asp:LinkButton ID="lnkAddAttachment" runat="server" Text="--Add New--" OnClick="lnkAddAttachment_Click"
                                                                CausesValidation="true" ValidationGroup="vsInspection" OnClientClick="javascript:return ValSave();"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr id="trAttachment" runat="server" style="display: none;">
                                                        <td align="left" colspan="6">
                                                            <uc:ctrlAttachment runat="server" ID="ucInspectionAttachment" OnFileSelection="Upload_Attachment" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="6">
                                                            <%--<asp:Button ID="btnPrevious" runat="server" Text="Previous" OnClick="btnPrevious_Click" CausesValidation="false" />&nbsp;&nbsp;
                                                                <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" CausesValidation="false" />&nbsp;&nbsp;--%>
                                                            <asp:Button ID="btnSaveAndNext" runat="server" Text="Save & Next" OnClick="btnSave_Click"
                                                                CausesValidation="true" ValidationGroup="vsInspection" OnClientClick="javascript:return ValSave();" />&nbsp;
                                                            <asp:Button ID="btnSaveAndView" runat="server" Text="Save & View" OnClick="btnSaveView_Click"
                                                                CausesValidation="true" ValidationGroup="vsInspection" OnClientClick="javascript:return ValSave();" />&nbsp;
                                                            <asp:Button ID="btnViewAudit" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </div>
                                        <div id="dvView" runat="server" style="display: none;">
                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                <tr>
                                                    <td align="left" width="15%">
                                                        Inspection Date
                                                    </td>
                                                    <td align="center" width="4%">
                                                        :
                                                    </td>
                                                    <td align="left" width="31%">
                                                        <asp:Label runat="server" ID="lblDate" Width="170px"></asp:Label>
                                                    </td>
                                                    <td align="left" width="15%">
                                                        Inspector Name
                                                    </td>
                                                    <td align="center" width="4%">
                                                        :
                                                    </td>
                                                    <td align="left" width="31%">
                                                        <asp:Label runat="server" ID="lblInspectorName" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" width="15%">
                                                        Inspection Area
                                                    </td>
                                                    <td align="center" width="4%">
                                                        :
                                                    </td>
                                                    <td align="left" width="31%">
                                                        <asp:Label runat="server" ID="lblInspectionArea" Width="170px"></asp:Label>
                                                    </td>
                                                    <td align="left" width="15%">
                                                        Date Inspection Report was Initially Distributed
                                                    </td>
                                                    <td align="center" width="4%">
                                                        :
                                                    </td>
                                                    <td align="left" width="31%">
                                                        <asp:Label ID="lblDateofInitialDistributionReport" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        Number of Deficiencies for this Inspection
                                                    </td>
                                                    <td align="center">
                                                        :
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblNumberofDeficienciesInspection" runat="server" />
                                                    </td>
                                                    <td align="left">
                                                        Number of Repeat Deficiencies Noted on this Inspection
                                                    </td>
                                                    <td align="center">
                                                        :
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblNumberofRepeatDeficiencies" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        RLCM Verified?
                                                    </td>
                                                    <td align="center">
                                                        :
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblRLCMVerified" runat="server" />
                                                    </td>
                                                    <td align="left">
                                                        No Deficiencies Found
                                                    </td>
                                                    <td align="center">
                                                        :
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblNoDeficiencies" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top">
                                                        Overall Inspection Comments
                                                    </td>
                                                    <td align="center" valign="top">
                                                        :
                                                    </td>
                                                    <td align="left" valign="top" colspan="4">
                                                        <uc:ctrlMultiLineTextBox ID="lblOverallInspectionComments" runat="server" ControlType="Label" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6">
                                                        <table cellpadding="5" cellspacing="0" width="100%" align="center">
                                                            <tr>
                                                                <td align="left" width="15%" valign="top">
                                                                    <b>Select Focus Area</b>
                                                                </td>
                                                                <td align="center" width="3%" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" width="37%">
                                                                    <asp:DropDownList ID="drpFocusAreasView" runat="server" AutoPostBack="true" CausesValidation="false"
                                                                        OnSelectedIndexChanged="drpFocusAreas_SelectedIndedChanged" />
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <b>Focus Area</b>
                                                    </td>
                                                    <td align="center">
                                                        &nbsp;
                                                    </td>
                                                    <td align="left">
                                                        <b>Question Text</b>
                                                    </td>
                                                    <td align="left">
                                                        &nbsp;
                                                    </td>
                                                    <td align="center">
                                                        &nbsp;
                                                    </td>
                                                    <td align="center">
                                                        <%--<asp:Label ID="Label1" runat="server" Width="20px">&nbsp;</asp:Label>--%>
                                                        <table>
                                                            <tr>
                                                                <td align="right">
                                                                     <div style="width:130px;">
                                                                        <b>Deficiency</b>
                                                                      </div>
                                                                </td>
                                                                <td align="right">
                                                                    <div style="width:80px;">
                                                                    <b>Maintenance</b>
                                                                     </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="6">
                                                        <asp:GridView ID="gvInspectionView" runat="server" Width="100%" ShowHeader="false"
                                                            AutoGenerateColumns="false" SkinID="Default" OnRowDataBound="gvInspectionView_OnRowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <ItemStyle Width="19%" VerticalAlign="top" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblFocus_Area" runat="server" Text='<%# Container.DataItemIndex == 0 ? Eval("Item_Number_Focus_Area") : ""%>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemStyle Width="81%" VerticalAlign="top" />
                                                                    <ItemTemplate>
                                                                        <table cellpadding="0" cellspacing="0" width="100%">
                                                                            <tr>
                                                                                <td width="100%">
                                                                                    <table cellpadding="0" cellspacing="0" width="100%">
                                                                                        <tr>
                                                                                            <td width="3%" align="left">
                                                                                                <%#Eval("Question_Number")%>
                                                                                            </td>
                                                                                            <td width="73%" align="left">
                                                                                                <%#Eval("Question_Text")%>
                                                                                            </td>
                                                                                            <td align="left" width="22%">
                                                                                                <table>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <%# Eval("Deficiency_Noted") != DBNull.Value ? (Convert.ToString(Eval("Deficiency_Noted")) == "Y" ? "YES" : "NO") : "NO" %>
                                                                                                            <input type="hidden" id="hdnDeficientAnswer" runat="server" value='<%#Eval("Deficient_Answer")%>' />
                                                                                                        </td>
                                                                                                        <td align="right" style="padding-left:25px;">
                                                                                                            <asp:Label ID="Label1" runat="server" Width="70px" Text=' <%# !String.IsNullOrEmpty(Convert.ToString(Eval("Title"))) ? "YES" : "NO" %> ' ></asp:Label>
                                                                                                             <input type="hidden" id="hdnMaintenance" runat="server" value=' <%# !String.IsNullOrEmpty(Convert.ToString(Eval("Title"))) ? "YES" : "NO" %> ' />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                               
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="3" class="Spacer" style="height: 5px;">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left">
                                                                                                <img id="imgGuidance" runat="server" src="../../Images/plus.jpg" style="cursor: pointer;"
                                                                                                    alt="" />
                                                                                            </td>
                                                                                            <td colspan="2">
                                                                                                Guidance
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="3" class="Spacer" style="height: 5px;">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left">
                                                                                                &nbsp;
                                                                                            </td>
                                                                                            <td colspan="2">
                                                                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                                                                    <tr>
                                                                                                        <td width="100%" id="tdGuidanceText" runat="server">
                                                                                                            <%#Eval("Guidance_Text")%>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td class="Spacer" style="height: 5px;">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td width="100%" id="tdResponseDetails" style='display: <%# (Convert.ToString(Eval("Deficiency_Noted")) == "Y" && Convert.ToString(Eval("Deficient_Answer")) == "Y" ) ? "" : "none" %>;'>
                                                                                                            <table cellpadding="3" cellspacing="1" width="100%">
                                                                                                                <tr>
                                                                                                                    <td width="18%" align="left" valign="top">
                                                                                                                        Repeat Deficiency?
                                                                                                                    </td>
                                                                                                                    <td width="4%" align="center" valign="top">
                                                                                                                        :
                                                                                                                    </td>
                                                                                                                    <td align="left" valign="top">
                                                                                                                        <%#(Convert.ToString(Eval("Repeat_Deficiency")) == "Y") ? "Yes" : "No"%>
                                                                                                                    </td>
                                                                                                                    <td colspan="3">
                                                                                                                        &nbsp;
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td width="18%" align="left" valign="top">
                                                                                                                        Department
                                                                                                                    </td>
                                                                                                                    <td width="4%" align="center" valign="top">
                                                                                                                        :
                                                                                                                    </td>
                                                                                                                    <td align="left" valign="top" colspan="4">
                                                                                                                        <%--<%# Eval("Department")%>    --%>
                                                                                                                        <asp:DataList ID="rptDepartment" runat="server" Width="100%" RepeatColumns="3">
                                                                                                                            <ItemTemplate>
                                                                                                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                                                                                                    <tr>
                                                                                                                                        <td width="60%" align="left">
                                                                                                                                            <%# Eval("Description") %>
                                                                                                                                            <input type="hidden" id="hdnDeptID" runat="server" value='<%#Eval("PK_LU_Department_ID") %>' />
                                                                                                                                        </td>
                                                                                                                                        <td align="left">
                                                                                                                                            <asp:Label ID="lblValue" runat="server" Text="No" />
                                                                                                                                        </td>
                                                                                                                                    </tr>
                                                                                                                                </table>
                                                                                                                            </ItemTemplate>
                                                                                                                        </asp:DataList>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td align="left">
                                                                                                                        Date opened
                                                                                                                    </td>
                                                                                                                    <td align="center">
                                                                                                                        :
                                                                                                                    </td>
                                                                                                                    <td align="left" width="28%">
                                                                                                                        <%# Eval("Date_Opened") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_Opened"))) : string.Empty %>
                                                                                                                    </td>
                                                                                                                    <td align="left" width="18%">
                                                                                                                        Days Open
                                                                                                                    </td>
                                                                                                                    <td align="center" width="4%">
                                                                                                                        :
                                                                                                                    </td>
                                                                                                                    <td align="left" width="28%">
                                                                                                                        <asp:Label ID="lblDays" runat="server" />
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td align="left" colspan="6">
                                                                                                                        Corrective Action:
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td colspan="6">
                                                                                                                        <uc:ctrlMultiLineTextBox ID="lblAction" runat="server" ControlType="Label" Text='<%# Eval("Recommended_Action")%>' />
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td align="left">
                                                                                                                        Target Completion Date
                                                                                                                    </td>
                                                                                                                    <td align="center">
                                                                                                                        :
                                                                                                                    </td>
                                                                                                                    <td align="left">
                                                                                                                        <%# Eval("Target_Completion_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Target_Completion_Date"))) : string.Empty %>
                                                                                                                    </td>
                                                                                                                    <td align="left">
                                                                                                                        Actual Completion Date
                                                                                                                    </td>
                                                                                                                    <td align="center">
                                                                                                                        :
                                                                                                                    </td>
                                                                                                                    <td align="left">
                                                                                                                        <%# Eval("Actual_Completion_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Actual_Completion_Date"))) : string.Empty %>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td align="left" colspan="6">
                                                                                                                        Notes:
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td colspan="6">
                                                                                                                        <uc:ctrlMultiLineTextBox ID="lblNotes" runat="server" ControlType="Label" Text='<%# Eval("Notes")%>' />
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>

                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                    <td width="100%" id="tdMaintDetails" style='display: <%# !String.IsNullOrEmpty(Convert.ToString(Eval("Title"))) ? "" : "none" %>;'>
                                                                                                          <table cellpadding="3" cellspacing="1" width="100%">
                                                                                                              <tr>
                                                                                                                  <td width="18%" align="left" valign="top">
                                                                                                                      <b>Title</b>
                                                                                                                  </td>
                                                                                                                  <td width="4%" align="center" valign="top">
                                                                                                                      :
                                                                                                                  </td>
                                                                                                                  <td align="left" valign="top" colspan="4" width="78%">
                                                                                                                      <%# Eval("Title") != DBNull.Value ? (Eval("Title")) : string.Empty %>
                                                                                                                     <%-- <asp:Label ID="lblTitle" runat="server"></asp:Label>--%>
                                                                                                                  </td>
                                                                                                                <%--  <td colspan="3">
                                                                                                                  </td>--%>
                                                                                                               </tr>
                                                                                                               <tr>
                                                                                                                  <td width="18%" align="left" valign="top">
                                                                                                                      <b>Problem Description</b>
                                                                                                                  </td>
                                                                                                                  <td width="4%" align="center" valign="top">
                                                                                                                      :
                                                                                                                  </td>
                                                                                                                  <td width="78%" align="left" valign="top" colspan="4">
                                                                                                                  </td>
                                                                                                              </tr>
                                                                                                              <tr>
                                                                                                                  <td colspan="6">
                                                                                                                      <uc:ctrlMultiLineTextBox ID="lblProblemDescription" ControlType="Label" runat="server" MaxLength="4000" Text='<%# Eval("Problem_Description")%>' />
                                                                                                                  </td>
                                                                                                              </tr>
                                                                                                         </table>
                                                                                                      </td>
                                                                                                  </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <PagerTemplate>
                                                                <span></span>
                                                            </PagerTemplate>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="Spacer" style="height: 10px;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="6">
                                                        <b>Focus Area Attachments</b><br />
                                                        <i>Click to view detail</i>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="Spacer" style="height: 10px;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="6">
                                                        <asp:GridView ID="gvFocusAreaAttachementView" runat="server" Width="100%" OnRowDataBound="gvFocusAreaAttachement_RowDataBound"
                                                            EmptyDataText="Currently there is no attachment<br/>Please add one or more attachment">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="File Name">
                                                                    <ItemStyle Width="50%" />
                                                                    <ItemTemplate>
                                                                        <a id="lnkAttachFile" runat="server" href="#">
                                                                            <%# Eval("FileName").ToString().Substring(12, (Eval("FileName").ToString().Length-1) - 11)%>
                                                                        </a>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Type">
                                                                    <ItemStyle Width="50%" />
                                                                    <ItemTemplate>
                                                                        <%# Eval("Type") %></ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="Spacer" style="height: 10px;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="6">
                                                        <b>Inspection Attachments</b><br />
                                                        <i>Click to view detail</i>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="Spacer" style="height: 10px;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="6">
                                                        <asp:GridView ID="gvAttachmentDetailsView" runat="server" Width="100%" OnRowDataBound="gvAttachmentDetails_RowDataBound"
                                                            EmptyDataText="Currently there is no attachment<br/>Please add one or more attachment">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="File Name">
                                                                    <ItemStyle Width="50%" />
                                                                    <ItemTemplate>
                                                                        <a id="lnkAttachFile" runat="server" href="#">
                                                                            <%# Eval("FileName").ToString().Substring(12, (Eval("FileName").ToString().Length-1) - 11)%>
                                                                        </a>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Type">
                                                                    <ItemStyle Width="50%" />
                                                                    <ItemTemplate>
                                                                        <%# Eval("Type") %></ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="Spacer" style="height: 10px;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6" align="center">
                                                        <asp:Button ID="btnBack" runat="server" Text="Edit" OnClick="btnBack_Click" />&nbsp;
                                                        <asp:Button ID="btnViewAudit2" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp();" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="dvAllInspections" runat="server" style="display: none;">
                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td style="height: 30px;" valign="middle" align="center">
                                                        <asp:Label ID="lblReportHeader" runat="server"><b>Only Questions with Deficiency Noted are Shown</b><br />
                                                        </asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                <tr>
                                                    <td align="left" width="15%">
                                                        Inspection Date
                                                    </td>
                                                    <td align="center" width="4%">
                                                        :
                                                    </td>
                                                    <td align="left" width="31%">
                                                        <asp:Label runat="server" ID="lblViewAllInspectionDate" Width="170px"></asp:Label>
                                                    </td>
                                                    <td align="left" width="15%">
                                                        Inspector Name
                                                    </td>
                                                    <td align="center" width="4%">
                                                        :
                                                    </td>
                                                    <td align="left" width="31%">
                                                        <asp:Label runat="server" ID="lblViewAllInspectionName" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" width="15%">
                                                        Inspection Area
                                                    </td>
                                                    <td align="center" width="4%">
                                                        :
                                                    </td>
                                                    <td align="left" width="31%">
                                                        <asp:Label runat="server" ID="lblAllInspectionArea" Width="170px"></asp:Label>
                                                    </td>
                                                    <td align="left" width="15%">
                                                        Date Inspection Report was Initially Distributed
                                                    </td>
                                                    <td align="center" width="4%">
                                                        :
                                                    </td>
                                                    <td align="left" width="31%">
                                                        <asp:Label ID="lblDateofInitialDistributionReportPrepare" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top">
                                                        Number of Deficiencies for this Inspection
                                                    </td>
                                                    <td align="center" valign="top">
                                                        :
                                                    </td>
                                                    <td align="left" valign="top">
                                                        <asp:Label ID="lblNumberOfDeficiencies" runat="server" />
                                                    </td>
                                                    <td align="left">
                                                        Number of Repeat Deficiencies Noted on this Inspection
                                                    </td>
                                                    <td align="center">
                                                        :
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblvwNumberofRepeatDeficiencies" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        RLCM Verified?
                                                    </td>
                                                    <td align="center">
                                                        :
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblRLCMVerifiedReport" runat="server" />
                                                    </td>
                                                    <td align="left">
                                                        No Deficiencies Found
                                                    </td>
                                                    <td align="center">
                                                        :
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblNoDeficiencyReport" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top">
                                                        Overall Inspection Comments
                                                    </td>
                                                    <td align="center" valign="top">
                                                        :
                                                    </td>
                                                    <td align="left" valign="top" colspan="4">
                                                        <uc:ctrlMultiLineTextBox ID="lblOverallCommentsReport" runat="server" ControlType="Label" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <b>Focus Area</b>
                                                    </td>
                                                    <td align="center">
                                                        &nbsp;
                                                    </td>
                                                    <td align="left">
                                                        <b>Question Text</b>
                                                    </td>
                                                    <td align="left">
                                                        &nbsp;
                                                    </td>
                                                    <td align="center">
                                                        &nbsp;
                                                    </td>
                                                    <td align="center">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label2" runat="server" Width="36px">&nbsp;</asp:Label>
                                                                    <b>Deficiency</b>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label3" runat="server" Width="36px">&nbsp;</asp:Label>
                                                                    <b>Maintenance</b>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="6">
                                                        <asp:GridView ID="gvAllInspections" runat="server" Width="100%" ShowHeader="false"
                                                            AutoGenerateColumns="false" SkinID="Default" OnRowDataBound="gvInspectionView_OnRowDataBound"
                                                            EnableViewState="false">
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <ItemStyle Width="19%" VerticalAlign="top" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblFocus_Area" runat="server" Text='<%#Eval("Focus_Area")%>' Style="display: none;"></asp:Label>&nbsp;
                                                                        <%--<%# Container.DataItemIndex == 0 ? Eval("Focus_Area") : ""%>--%></ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemStyle Width="81%" VerticalAlign="top" />
                                                                    <ItemTemplate>
                                                                        <table cellpadding="0" cellspacing="0" width="100%">
                                                                            <tr>
                                                                                <td width="100%">
                                                                                    <table cellpadding="0" cellspacing="0" width="100%">
                                                                                        <tr>
                                                                                            <td width="3%" align="left">
                                                                                                <%#Eval("Question_Number")%>
                                                                                            </td>
                                                                                            <td width="73%" align="left">
                                                                                                <%#Eval("Question_Text")%>
                                                                                            </td>
                                                                                            <td align="left">
                                                                                                <table>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <%# Convert.ToString(Eval("Deficiency_Noted")) == "Y" ? "YES" : "NO" %>
                                                                                                            <input type="hidden" id="hdnDeficientAnswer" runat="server" value='<%#Eval("Deficient_Answer")%>' />
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:Label ID="Label1" runat="server" Width="70px">&nbsp;</asp:Label>
                                                                                                            <%# !string.IsNullOrEmpty(Convert.ToString(Eval("Title"))) ? "Y" : "N" %>
                                                                                                            <input type="hidden" id="hdnMaintenance" runat="server" value=' <%# !string.IsNullOrEmpty(Convert.ToString(Eval("Title"))) ? "Y" : "N" %>' />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="3" class="Spacer" style="height: 5px;">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left">
                                                                                                <img id="imgGuidance" alt="" runat="server" src="../../Images/plus.jpg" style="cursor: pointer;" />
                                                                                            </td>
                                                                                            <td colspan="2">
                                                                                                Guidance
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="3" class="Spacer" style="height: 5px;">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left">
                                                                                                &nbsp;
                                                                                            </td>
                                                                                            <td colspan="2">
                                                                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                                                                    <tr>
                                                                                                        <td width="100%" id="tdGuidanceText" runat="server">
                                                                                                            <%#Eval("Guidance_Text")%>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td class="Spacer" style="height: 5px;">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td width="100%" id="tdResponseDetails" style='display: <%# (Convert.ToString(Eval("Deficiency_Noted")) == "Y" && Convert.ToString(Eval("Deficient_Answer")) == "Y")? "" : "none" %>;'>
                                                                                                            <table cellpadding="3" cellspacing="1" width="100%">
                                                                                                                <tr>
                                                                                                                    <td width="18%" align="left" valign="top">
                                                                                                                        Repeat Deficiency?
                                                                                                                    </td>
                                                                                                                    <td width="4%" align="center" valign="top">
                                                                                                                        :
                                                                                                                    </td>
                                                                                                                    <td align="left" valign="top">
                                                                                                                        <%#(Convert.ToString(Eval("Repeat_Deficiency")) == "Y") ? "Yes" : "No"%>
                                                                                                                    </td>
                                                                                                                    <td colspan="3">
                                                                                                                        &nbsp;
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td width="18%" align="left" valign="top">
                                                                                                                        Department
                                                                                                                    </td>
                                                                                                                    <td width="4%" align="center" valign="top">
                                                                                                                        :
                                                                                                                    </td>
                                                                                                                    <td align="left" valign="top" colspan="4">
                                                                                                                        <asp:DataList ID="rptDepartment" runat="server" Width="100%" RepeatColumns="3">
                                                                                                                            <ItemTemplate>
                                                                                                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                                                                                                    <tr>
                                                                                                                                        <td width="60%" align="left">
                                                                                                                                            <%# Eval("Description") %>
                                                                                                                                            <input type="hidden" id="hdnDeptID" runat="server" value='<%#Eval("PK_LU_Department_ID") %>' />
                                                                                                                                        </td>
                                                                                                                                        <td align="left">
                                                                                                                                            <asp:Label ID="lblValue" runat="server" Text="No" />
                                                                                                                                        </td>
                                                                                                                                    </tr>
                                                                                                                                </table>
                                                                                                                            </ItemTemplate>
                                                                                                                        </asp:DataList>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td align="left">
                                                                                                                        Date opened
                                                                                                                    </td>
                                                                                                                    <td align="center">
                                                                                                                        :
                                                                                                                    </td>
                                                                                                                    <td align="left" width="28%">
                                                                                                                        <%# Eval("Date_Opened") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_Opened"))) : string.Empty %>
                                                                                                                    </td>
                                                                                                                    <td align="left" width="18%">
                                                                                                                        Days Open
                                                                                                                    </td>
                                                                                                                    <td align="center" width="4%">
                                                                                                                        :
                                                                                                                    </td>
                                                                                                                    <td align="left" width="28%">
                                                                                                                        <asp:Label ID="lblDays" runat="server" />
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td align="left" colspan="6">
                                                                                                                        Corrective Action:
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td colspan="6">
                                                                                                                        <uc:ctrlMultiLineTextBox ID="lblAction" runat="server" ControlType="Label" Text='<%# Eval("Recommended_Action")%>' />
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td align="left">
                                                                                                                        Target Completion Date
                                                                                                                    </td>
                                                                                                                    <td align="center">
                                                                                                                        :
                                                                                                                    </td>
                                                                                                                    <td align="left">
                                                                                                                        <%# Eval("Target_Completion_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Target_Completion_Date"))) : string.Empty %>
                                                                                                                    </td>
                                                                                                                    <td align="left">
                                                                                                                        Actual Completion Date
                                                                                                                    </td>
                                                                                                                    <td align="center">
                                                                                                                        :
                                                                                                                    </td>
                                                                                                                    <td align="left">
                                                                                                                        <%# Eval("Actual_Completion_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Actual_Completion_Date"))) : string.Empty %>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td align="left" colspan="6">
                                                                                                                        Notes:
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td colspan="6">
                                                                                                                        <uc:ctrlMultiLineTextBox ID="lblNotes" runat="server" ControlType="Label" Text='<%# Eval("Notes")%>' />
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left">
                                                                                    <asp:DataList ID="dlAttachmentImages" Width="100%" runat="server" RepeatColumns="2"
                                                                                        CellPadding="5" CellSpacing="5" BorderWidth="0">
                                                                                        <ItemTemplate>
                                                                                            <table width="100%" cellpadding="5" cellspacing="0" border="0">
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        <b>File Name :</b>
                                                                                                        <%# Eval("FileName").ToString().Substring(12, (Eval("FileName").ToString().Length-1) - 11)%>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        <img alt="" src='<%# AppConfig.InspectionFocusAreaDocURL +  clsGeneral.Encode_Url(Eval("FileName").ToString())%>'
                                                                                                            width="350px" height="250px" style="border: solid 1px black;" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </ItemTemplate>
                                                                                    </asp:DataList>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <PagerTemplate>
                                                                <span></span>
                                                            </PagerTemplate>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <%--  </ContentTemplate>
                </asp:UpdatePanel>--%>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        window.onscroll = getScrollHeight;
        //window.onload=getScrollHeight;
        //used to get height of scrollbar and add to total screen height +  scollbar height
        function getScrollHeight() {
            var h = window.pageYOffset ||
               document.body.scrollTop ||
               document.documentElement.scrollTop;
            document.getElementById('divProgress').style.height = screen.height + h;
            document.getElementById('ProgressTable').style.height = screen.height + h;
        }
        function ShowHideGuidanceText(imgID, tdTxtID) {
            var img = document.getElementById(imgID);
            var tdTxt = document.getElementById(tdTxtID);
            if (tdTxt.style.display == "none") {
                tdTxt.style.display = "";
                img.src = "../../Images/minus.jpg";
            }
            else {
                tdTxt.style.display = "none";
                img.src = "../../Images/plus.jpg";
            }
        }

        function ShowHideDetails(rdoID, tdDtl, strDefcientAnswer) {
            var rdoYes = document.getElementById(rdoID + "_0");
            if (rdoYes.checked && strDefcientAnswer == "Y") {
                tdDtl.style.display = "";
                ValidatorEnable(document.getElementById(rdoID.replace("rdoDefeciancy", "revDateOpened")), true);
                ValidatorEnable(document.getElementById(rdoID.replace("rdoDefeciancy", "regTargetCompleteDate")), true);
                ValidatorEnable(document.getElementById(rdoID.replace("rdoDefeciancy", "regActualCompletionDate")), true);
            }
            else {
                tdDtl.style.display = "none";
                ValidatorEnable(document.getElementById(rdoID.replace("rdoDefeciancy", "revDateOpened")), false);
                ValidatorEnable(document.getElementById(rdoID.replace("rdoDefeciancy", "regTargetCompleteDate")), false);
                ValidatorEnable(document.getElementById(rdoID.replace("rdoDefeciancy", "regActualCompletionDate")), false);
            }
        }

        function ShowHideMaintenanceDetails(rdoID, tdDtl, strDefcientAnswer,txtTitle,txtProblemDescription) {
           
            var rdoYes = document.getElementById(rdoID + "_0");
            var grid = document.getElementById("<%= gvInspectionEdit.ClientID %>");
            if (rdoYes.checked) {
                tdDtl.style.display = "";
            }
            else {
                tdDtl.style.display = "none";
                //document.getElementById(txtTitle).value = '';
                //document.getElementById(txtProblemDescription).value = '';
            }
        }

        function ValidateDateOpened(ctrlIDs) {
            var arrCtrlIDs = ctrlIDs.split(',');
            var txtID = arrCtrlIDs[0];
            var lblID = arrCtrlIDs[1];
            var txtActualID = arrCtrlIDs[2];
            var strDtOpen = document.getElementById(txtID).value;
            var strDtActual = document.getElementById(txtActualID).value;
            if (strDtOpen != "") {
                var today = new Date();
                var dtOpen = new Date(strDtOpen);
                if (dtOpen > today) {
                    alert("Date Opened Can not be a future date");
                    document.getElementById(txtID).value = '';
                    document.getElementById(txtID).focus();
                    document.getElementById(lblID).innerHTML = '';
                }
                else {

                    if (IsValidDate(strDtActual) == '' && strDtActual != '')
                        CountDaysOpen(strDtOpen, lblID, strDtActual);
                }
            }
            else
                document.getElementById(lblID).innerHTML = '';
        }

        function CountDaysOpen(strDtOpen, lblID, strDtActual) {
            //var strDtOpen = document.getElementById(txtID).value;            
            if (strDtOpen != null && strDtOpen != "" && strDtOpen.indexOf("1753") == -1 && strDtActual != null && strDtActual != "" && strDtActual.indexOf("1753") == -1) {
                var today = new Date(strDtActual);
                var dtOpen = new Date(strDtOpen);
                var millennium = new Date(2000, 0, 1) //Month is 0-11 in JavaScript

                //Get 1 day in milliseconds
                var one_day = 1000 * 60 * 60 * 24

                var days = Math.ceil((today.getTime() - dtOpen.getTime()) / (one_day));
                //days = days - 1;
                document.getElementById(lblID).innerHTML = days >= 0 ? days : '';

            }
        }

        function ShowAttachment() {
            var pk = document.getElementById('<%= hdnInspectionID.ClientID %>').value;
            pk = Number(pk);
            if (pk > 0) {
                document.getElementById('<%=trAttachment.ClientID%>').style.display = "block";
            }
            else {
                alert("Please select/enter the Inspection details");
            }

        }

        function ShowAttachmentFA() {
            var pk = document.getElementById('<%= hdnInspectionID.ClientID %>').value;
            pk = Number(pk);
            if (pk > 0) {
                document.getElementById('<%=trAttachmentFA.ClientID%>').style.display = "block";
            }
            else {
                alert("Please select/enter the Inspection details");
            }

        }
        //        function CheckForDate() {
        //            
        //            var hdnValue = document.getElementById('<%= hdnForDate.ClientID %>').value;
        //            var PK = '<%= ViewState["PK_Inspection_ID"] %>';
        //            if (hdnValue.value == PK.value) {
        //                var obj = new Date();
        //                document.getElementById('<%= lblDateofInitialDistributionReport.ClientID%>').innerHtml=obj.getDate();
        //            }
        //            
        //        }

    </script>
    <script type="text/javascript">
        var GB_ROOT_DIR = '<%=AppConfig.SiteURL%>greybox/';
        //OPen Audit Popup
        function ShowEmailPopUp(PK_Inspection, filepath) {
            var AllowSendMail = '<%=AppConfig.AllowMailSending%>'
            if (AllowSendMail.toLowerCase() == "true")
                GB_showCenter('Email Inspection Report', "<%=AppConfig.SiteURL%>SONIC/Exposures/InspectionsEmail.aspx?Pk_Inspection=" + PK_Inspection + "&fpath=" + filepath, 350, 500);
            else
                alert("Report cannot be sent as mailing option is disabled");
        }
    </script>
    <link href="<%=AppConfig.SiteURL%>greybox/gb_styles.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/gb_scripts.js"></script>
    <asp:HiddenField ID="hdnForDate" runat="server" />
    <asp:HiddenField ID="hdnForDateEdit" runat="server" />
</asp:Content>
