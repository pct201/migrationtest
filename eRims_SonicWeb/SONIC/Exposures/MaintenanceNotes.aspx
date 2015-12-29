<%@ Page Title="eRIMS Sonic :: Exposures :: Repair And Maintenance Notes" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="MaintenanceNotes.aspx.cs" Inherits="SONIC_Exposures_MaintenanceNotes" %>

<%@ Register Src="~/Controls/ExposuresTab/ExposuresTab.ascx" TagName="CtlTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attchment-Exposures/Attachment.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposureInfo/ExposureInfo.ascx" TagName="ctrlExposureInfo"
    TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript">
        var GB_ROOT_DIR = '<%=AppConfig.SiteURL%>greybox/';     
    </script>
    <link href="<%=AppConfig.SiteURL%>greybox/gb_styles.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/gb_scripts.js"></script>
    <script type="text/javascript" language="javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(pageLoaded);

        function pageLoaded(sender, args) {
            window.scrollTo(0, 0);
        }
    </script>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields :" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorPropertyCope" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100%" style="height: 50px;" valign="bottom" colspan="2">
                <uc:CtlTab runat="server" ID="Tab"></uc:CtlTab>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td class="Spacer" style="height: 15px;" colspan="2"></td>
                    </tr>
                    <tr>
                        <td width="100%" colspan="2">
                            <asp:UpdatePanel ID="upPanel1" runat="server" UpdateMode="Always">
                                <ContentTemplate>
                                    <uc:ctrlExposureInfo ID="ucCtrlExposureInfo" runat="server" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" style="height: 15px;" colspan="2"></td>
                    </tr>
                    <tr>
                        <td class="leftMenu">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="height: 18px;" class="Spacer"></td>
                                </tr>
                                <tr>
                                    <td width="100%">
                                        <table class="ctl00_ContentPlaceHolder1_mnuProperty_2" id="ctl00_ContentPlaceHolder1_mnuProperty"
                                            cellspacing="0" cellpadding="0" border="0">
                                            <tbody>
                                                <tr id="ctl00_ContentPlaceHolder1_mnuPropertyn5" onkeyup="Menu_Key(this)" onmouseover="Menu_HoverStatic(this)"
                                                    onmouseout="Menu_Unhover(this)">
                                                    <td>
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 100%; white-space: nowrap">
                                                                        <a href="javascript:void(6);">
                                                                            <table cellspacing="0" cellpadding="5" width="100%">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td align="left" width="100%">
                                                                                            <span class="LeftMenuSelected" id="PropertyMenu7" onclick="javascript:void(0);">Notes
                                                                                            </span>&nbsp;<span id="Span2" runat="server" style="color: Red; display: none">*</span>
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </a>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 5px;" class="Spacer"></td>
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
                                                    <table id="ProgressTable" cellpadding="0" cellspacing="0" border="0" style="width: 100%; height: 100%;">
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
                                    <td style="width: 5px">&nbsp;
                                    </td>
                                    <td style="width: 794px" valign="top" class="dvContainer">
                                        <div id="dvEdit" runat="server">
                                            <asp:UpdatePanel runat="server" ID="updInspectionEdit" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:Panel ID="pnlNotesEdit" runat="server" Width="100%">
                                                        <div class="bandHeaderRow" id="hdrInspectionEdit" runat="server">
                                                            Facility Maintenance - Notes
                                                        </div>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%" id="tblMaintenanceArea" runat="server">
                                                            <tr>
                                                                <td align="left" width="18%" valign="top">Note Date
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:TextBox ID="txtNoteDate" Width="170px" runat="server" SkinID="txtDate" onpaste="return false"></asp:TextBox>
                                                                    <img alt="Note Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtNoteDate', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" />
                                                                </td>
                                                                <td align="left" width="18%" valign="top">&nbsp;
                                                                </td>
                                                                <td align="center" width="4%" valign="top">&nbsp;
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">Note
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="txtNote" ControlType="textbox" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td colspan="6" width="100%" align="center">
                                                                    <asp:Button runat="server" ID="btnNoteSave" Text="Save & View" CausesValidation="true" ValidationGroup="vsErrorPropertyCope" OnClick="btnNoteSave_Click" />&nbsp;
                                                                    <asp:Button runat="server" ID="btnRevertAndReturn" Text="Revert And Return" CausesValidation="true" ValidationGroup="vsErrorPropertyCope" OnClick="btnRevertAndReturn_Click" />&nbsp;
                                                                    <asp:Button ID="btnViewAuditPropertyCOPE" runat="server" Text="View Audit Trail"
                                                                        OnClientClick="javascript:return AuditPopUp('COPE');" Visible="false" />
                                                                </td>
                                                            </tr>
                                                        </table>

                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlNotesView" runat="server" Width="100%" Visible="false">
                                                        <div class="bandHeaderRow" id="hdrInspectionView" runat="server">
                                                            Facility Maintenance - Notes
                                                        </div>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%" id="Table1" runat="server">
                                                            <tr>
                                                                <td align="left" width="18%" valign="top">Note Date
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:Label ID="lblNoteDate" Width="170px" runat="server" SkinID="lblText"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">Note
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="lblNote" ControlType="Label" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <hr />
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td colspan="6" width="100%" align="center">
                                                                    <asp:Button runat="server" ID="btnNoteEdit" Text="Edit" CausesValidation="true" ValidationGroup="vsErrorPropertyCope" OnClick="btnNoteEdit_Click" />&nbsp;
                                                                    <asp:Button runat="server" ID="btnRevertAndReturnView" Text="Return" CausesValidation="true" ValidationGroup="vsErrorPropertyCope" OnClick="btnRevertAndReturn_Click" />&nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
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

