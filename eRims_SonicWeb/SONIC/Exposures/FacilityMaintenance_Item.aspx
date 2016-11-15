<%@ Page Title="eRIMS Sonic :: Exposures :: Repair And Maintenance" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="FacilityMaintenance_Item.aspx.cs" Inherits="SONIC_Exposures_FacilityMaintenance_Item" %>

<%@ Register Src="~/Controls/ExposuresTab/ExposuresTab.ascx" TagName="CtlTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attchment-Exposures/Attachment.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposureInfo/ExposureInfo.ascx" TagName="ctrlExposureInfo"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
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

        function ConfirmRemove() {
            return confirm("Are you sure you want to remove attachment?");
        }

        function AddMaintenanceAttachment(id) {
            var popUpTitle = 'Attach Maintenance Documents';
            var PopUpURL = '<%=AppConfig.SiteURL%>SONIC/Exposures/MaintenanceAddAttachment.aspx';
            GB_showCenter(popUpTitle, PopUpURL + '?item=' + id + '&table=Facility_Construction_Maintenance_Item', 300, 500);
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
                                                <tr id="ctl00_ContentPlaceHolder1_mnuPropertyn0" onkeyup="Menu_Key(this)" onmouseover="Menu_HoverStatic(this)"
                                                    onmouseout="Menu_Unhover(this)">
                                                    <td>
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 100%; white-space: nowrap">
                                                                        <a href="javascript:void(1);">
                                                                            <table cellspacing="0" cellpadding="5" width="100%">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td align="left" width="100%">
                                                                                            <span class="LeftMenuStatic" id="PropertyMenu1" onclick="javascript:RedirectTo(1);">Property Cope </span>&nbsp;<span id="MenuAsterisk1" runat="server" style="color: Red; display: none">*</span>
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
                                                <tr id="ctl00_ContentPlaceHolder1_mnuPropertyn1" onkeyup="Menu_Key(this)" onmouseover="Menu_HoverStatic(this)"
                                                    onmouseout="Menu_Unhover(this)">
                                                    <td>
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 100%; white-space: nowrap">
                                                                        <a class="ctl00_ContentPlaceHolder1_mnuProperty_1" href="javascript:void(2);">
                                                                            <table cellspacing="0" cellpadding="5" width="100%">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td align="left" width="100%">
                                                                                            <span class="LeftMenuStatic" id="PropertyMenu2" onclick="javascript:RedirectTo(1);">Building Information</span>&nbsp;<span id="MenuAsterisk2" runat="server" style="color: Red; display: none">*</span>
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
                                                <tr id="ctl00_ContentPlaceHolder1_mnuPropertyn2" onkeyup="Menu_Key(this)" onmouseover="Menu_HoverStatic(this)"
                                                    onmouseout="Menu_Unhover(this)">
                                                    <td>
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 100%; white-space: nowrap">
                                                                        <a href="javascript:void(4);">
                                                                            <table cellspacing="0" cellpadding="5" width="100%">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td align="left" width="100%">
                                                                                            <span class="LeftMenuStatic" id="PropertyMenu4" onclick="javascript:RedirectTo(1);">Building Improvements</span>&nbsp;<span id="MenuAsterisk3" runat="server" style="color: Red; display: none">*</span>
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
                                                <tr id="ctl00_ContentPlaceHolder1_mnuPropertyn3" onkeyup="Menu_Key(this)" onmouseover="Menu_HoverStatic(this)"
                                                    onmouseout="Menu_Unhover(this)">
                                                    <td>
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 100%; white-space: nowrap">
                                                                        <a href="javascript:void(5);">
                                                                            <table cellspacing="0" cellpadding="5" width="100%">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td align="left" width="100%">
                                                                                            <span class="LeftMenuStatic" id="PropertyMenu5" onclick="javascript:RedirectTo(1);">Contacts
                                                                                            </span>&nbsp;<span id="MenuAsterisk4" runat="server" style="color: Red; display: none">*</span>
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
                                                                                            <span class="LeftMenuSelected" id="PropertyMenu7" onclick="javascript:void(0);">Facility Maintenance
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
                                                <tr id="ctl00_ContentPlaceHolder1_mnuPropertyn4" onkeyup="Menu_Key(this)" onmouseover="Menu_HoverStatic(this)"
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
                                                                                            <span class="LeftMenuStatic" id="PropertyMenu6" onclick="javascript:RedirectTo(9);">Facility Inspection
                                                                                            </span>&nbsp;<span id="MenuAsterisk5" runat="server" style="color: Red; display: none">*</span>
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
                                            <asp:Panel ID="pnlMaintenanceEdit" runat="server" Width="100%">
                                                <asp:UpdatePanel runat="server" ID="updInspectionEdit" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <div class="bandHeaderRow" id="hdrInspectionEdit" runat="server">
                                                            Facility Maintenance
                                                        </div>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%" id="tblMaintenanceArea" runat="server">
                                                            <tr>
                                                                <td align="left" width="18%" valign="top">Maintenance Action Number
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:TextBox ID="txtActionNumber" Width="170px" runat="server" SkinID="txtGeneral" onpaste="return false" Enabled="false"></asp:TextBox>
                                                                </td>
                                                                <td align="left" width="18%" valign="top">Location
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <%--<asp:DropDownList runat="server" ID="ddlProject" AutoPostBack="true" SkinID="ddlExposure" OnSelectedIndexChanged="ddlProject_SelectedIndexChanged">
                                                                    </asp:DropDownList>--%>
                                                                    <asp:DropDownList ID="ddlLocation" Width="175px" runat="server" AutoPostBack="true" SkinID="dropGen" OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Building Number <span id="Span1" runat="server" style="color: Red;">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:DropDownList runat="server" ID="ddlBuilding" SkinID="ddlExposure">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfvBuilding" runat="server" ErrorMessage="Please select Building Number"
                                                                        Display="None" SetFocusOnError="true" ControlToValidate="ddlBuilding"
                                                                        ValidationGroup="vsErrorPropertyCope" InitialValue="0"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td align="left" valign="top">Requester
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:DropDownList runat="server" ID="ddlRequester" SkinID="ddlExposure">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <%--<tr>
                                                                <td align="left" valign="top">Telephone
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtTelephone" MaxLength="12" Width="170px" runat="server" SkinID="txtPhone" onpaste="return false"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="regTelephone" ControlToValidate="txtTelephone"
                                                                        SetFocusOnError="true" runat="server" ValidationGroup="vsErrorPropertyCope" ErrorMessage="Please Enter Telephone Number in xxx-xxx-xxxx format."
                                                                        Display="none" Enabled="true" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="left" valign="top">Email
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtEmail" Width="170px" runat="server" SkinID="txtGeneral" onpaste="return false" MaxLength="75"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                                                                        ValidationGroup="vsErrorPropertyCope" Display="None" ErrorMessage="Email Address Is Invalid."
                                                                        SetFocusOnError="True" Text="*" ToolTip="Email Address Is Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>--%>
                                                            <tr>
                                                                <td align="left" width="18%" valign="top">Created Date
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:TextBox ID="txtInspectionDate" Width="170px" runat="server" SkinID="txtDate" onpaste="return false"></asp:TextBox>
                                                                    <img alt="Inspection Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtInspectionDate', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" />
                                                                </td>
                                                                <td align="left" valign="top">Focus Area
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:DropDownList runat="server" AutoPostBack="true" ID="ddlFocusArea" SkinID="ddlExposure" OnSelectedIndexChanged="ddlFocusArea_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <%--<td align="left" width="18%" valign="top">Inspector
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:DropDownList runat="server" ID="ddlInspector" SkinID="ddlExposure">
                                                                    </asp:DropDownList>
                                                                </td>--%>
                                                            </tr>
                                                            <%--<tr>
                                                                <td align="left" width="18%" valign="top">Date PCA Ordered
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:TextBox ID="txtDatePCAOrdered" Width="170px" runat="server" SkinID="txtDate" onpaste="return false"></asp:TextBox>
                                                                    <img alt="Date PCA Ordered" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDatePCAOrdered', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" />
                                                                </td>
                                                                <td align="left" width="18%" valign="top">Date PCA Conducted
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:TextBox ID="txtDatePCAConducted" Width="170px" runat="server" SkinID="txtDate" onpaste="return false"></asp:TextBox>
                                                                    <img alt="Date PCA Conducted" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDatePCAConducted', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" />
                                                                </td>
                                                            </tr>--%>
                                                            <tr>
                                                                <td align="left" width="18%" valign="top">Item
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:DropDownList runat="server" ID="ddlFocusAreaItem" SkinID="ddlExposure">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left" valign="top">Status
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:DropDownList runat="server" ID="ddlStatus" SkinID="ddlExposure">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <%--<tr>
                                                                <td align="left" width="18%" valign="top">PCA Conducted By
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:DropDownList runat="server" ID="ddlPCAConductedBy" SkinID="ddlExposure">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left" width="18%" valign="top">Scope Of Work
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:DropDownList runat="server" ID="ddlScopeOfWork" SkinID="ddlExposure">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>--%>
                                                            <%--<tr>
                                                                <td align="left" width="18%" valign="top">Estimated Start Date
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:TextBox ID="txtEstimatedStartDate" Width="170px" runat="server" AutoPostBack="true" SkinID="txtDate" onpaste="return false"></asp:TextBox>
                                                                    <img alt="Estimated Start Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtEstimatedStartDate', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" />
                                                                </td>
                                                                <td align="left" width="18%" valign="top">Scope Of Work
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:DropDownList runat="server" ID="ddlScopeOfWork" SkinID="ddlExposure">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>--%>
                                                            <%--<tr>
                                                                <td align="left" width="18%" valign="top">Estimated End Date
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:TextBox ID="txtEstimatedEndDate" Width="170px" AutoPostBack="true" runat="server" SkinID="txtDate" onpaste="return false"></asp:TextBox>
                                                                    <img alt="Estimated End Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtEstimatedEndDate', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" />
                                                                    <asp:CompareValidator ID="cvEstimatedEndDate" runat="server" ControlToCompare="txtEstimatedStartDate" ControlToValidate="txtEstimatedEndDate"
                                                                        ValidationGroup="vsErrorPropertyCope" Display="None" ErrorMessage="Estimated End Date Must be Greater Than Or Equal to Estimated Start Date"
                                                                        SetFocusOnError="true" Text="*" ToolTip="Estimated End Date Must be Greater Than Or Equal to Estimated Start Date"
                                                                        Type="Date" Operator="GreaterThanEqual"></asp:CompareValidator>
                                                                </td>
                                                                <td align="left" width="18%" valign="top">Actual Start Date
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:TextBox ID="txtActualStartDate" Width="170px" runat="server" SkinID="txtDate" onpaste="return false"></asp:TextBox>
                                                                    <img alt="Actual Start Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtActualStartDate', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" />
                                                                </td>
                                                                <td align="left" width="18%" valign="top">Number Of Days
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:TextBox ID="txtNumberOfDays" Width="170px" runat="server" SkinID="txtGeneral" onpaste="return false"></asp:TextBox>
                                                                </td>
                                                            </tr>--%>
                                                            <%--<tr>
                                                                <td align="left" valign="top">Maintenance Type
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:DropDownList runat="server" ID="ddlMaintenanceType" SkinID="ddlExposure">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left" width="18%" valign="top">Assigned
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:DropDownList runat="server" ID="ddlResponsibleParty" AutoPostBack="true" SkinID="ddlExposure" OnSelectedIndexChanged="ddlResponsibleParty_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>--%>
                                                            <%--  <tr>
                                                                
                                                                <td align="left" width="18%" valign="top">Approved By
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:DropDownList runat="server" ID="ddlApprovedBy" SkinID="ddlExposure">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Vendor
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:DropDownList runat="server" ID="ddlFirm" SkinID="ddlExposure">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left" width="18%" valign="top">Vendor Contact
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:TextBox ID="txtContactName" Width="170px" runat="server" SkinID="txtGeneral" onpaste="return false" MaxLength="75"></asp:TextBox>
                                                                </td>
                                                            </tr>--%>
                                                            <%--    <tr>
                                                                <td align="left" valign="top">Estimated Amount
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">$&nbsp;<asp:TextBox runat="server" ID="txtEstAmount" onpaste="return false" onkeypress="return FormatNumber(event,this.id,10 ,false);" MaxLength="11"></asp:TextBox>
                                                                </td>
                                                                <td align="left" width="18%" valign="top">Actual Amount
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">$&nbsp;<asp:TextBox runat="server" ID="txtActualAmount" onpaste="return false" onkeypress="return FormatNumber(event,this.id,10 ,false);" MaxLength="11"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Prposal Amount
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">$&nbsp;<asp:TextBox runat="server" ID="txtProposalAmount" onpaste="return false" onkeypress="return FormatNumber(event,this.id,10 ,false);" MaxLength="11"></asp:TextBox>
                                                                </td>
                                                                <td align="left" width="18%" valign="top">Variance
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">$&nbsp;<asp:TextBox runat="server" ID="txtVariance" onpaste="return false" onkeypress="return FormatNumber(event,this.id,10 ,false);" MaxLength="11"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>--%>
                                                            <tr>
                                                                <td align="left" valign="top">Title
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:TextBox ID="txtTitle" Width="170px" runat="server" SkinID="txtGeneral" onpaste="return false" MaxLength="75"></asp:TextBox>
                                                                </td>
                                                                <td align="left" valign="top">Priority
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:DropDownList runat="server" ID="ddlPriority" SkinID="ddlExposure">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">Repair Description&nbsp;<span id="Span104" style="color: Red; display: none;"
                                                                    runat="server">*</span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="txtRepairDescription" ControlType="textbox" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <div id="dvNote" runat="server">
                                                            <div class="bandHeaderRow">
                                                                Notes
                                                            </div>
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td colspan="3">
                                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                            <tr>
                                                                                <td width="45%"></td>
                                                                                <td valign="top" align="right">
                                                                                    <uc:ctrlPaging ID="ctrlPageSonicNotes" runat="server" OnGetPage="ctrlPageSonicNotes_GetPage" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td valign="top" style="width: 20%">Notes Grid<br />
                                                                        <asp:LinkButton ID="btnNotesAdd" runat="server" ValidationGroup="vsError" Text="--Add--" Visible="false" OnClick="btnNotesAdd_Click"></asp:LinkButton>
                                                                    </td>
                                                                    <td align="center" valign="top" style="width: 3%">:
                                                                    </td>
                                                                    <td style="margin-left: 40px" style="width: 650px" align="left">
                                                                        <asp:GridView ID="gvNotes" runat="server" AutoGenerateColumns="false" Width="100%" OnRowCommand="gvNotes_RowCommand">
                                                                            <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                                            <EmptyDataTemplate>
                                                                                <asp:Label ID="lblEmptyEmergencyMessage" runat="server" Text="No Record Found"></asp:Label>
                                                                            </EmptyDataTemplate>
                                                                            <Columns>
                                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                                    HeaderText="Note Date">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lbtNote_Date" runat="server" Text='<%# string.Format("{0:MM/dd/yyyy}", Eval("Note_Date")) %>'
                                                                                            CommandName="EditRecord" CommandArgument='<%#Eval("PK_Facility_Maintenance_Notes") %>' Width="80px"></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                                    HeaderText="Author">
                                                                                    <ItemStyle Width="30%" />
                                                                                    <ItemTemplate>
                                                                                        <%# Eval("AuthorName") %>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                                    HeaderText="Notes">
                                                                                    <ItemStyle Width="60%" />
                                                                                    <ItemTemplate>
                                                                                        <%# Eval("Note") %>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                                    HeaderText="Remove">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lbtDelete" runat="server" Text="Remove" CommandName="Remove"
                                                                                            CommandArgument='<%#Eval("PK_Facility_Maintenance_Notes") %>' OnClientClick="javascript:return confirm('Are you sure you want delete selected record?');"
                                                                                            Width="80px"></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                        <div id="dvAttachment" runat="server">
                                                            <div class="bandHeaderRow">
                                                                Attachments
                                                            </div>
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td valign="top" style="width: 20%">Attachments Grid<br />
                                                                        <asp:LinkButton ID="btnAttachmentAdd" runat="server" ValidationGroup="vsError" Text="--Add--" OnClick="btnAttachmentAdd_Click"></asp:LinkButton>
                                                                    </td>
                                                                    <td align="center" valign="top" style="width: 3%">:
                                                                    </td>
                                                                    <td style="margin-left: 40px" style="width: 650px" align="left">
                                                                        <asp:GridView ID="gvAttachmentDetails" runat="server" Width="100%" EmptyDataText="Currently there is no attachment." OnRowCommand="gvAttachmentDetails_RowCommand">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="File Name">
                                                                                    <ItemStyle Width="50%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkBuildingAttachFile" runat="server" Text='<%# Eval("Attachment_Description").ToString().Substring(12, (Eval("Attachment_Description").ToString().Length-1) - 11)%>' CommandArgument='<%# Eval("Attachment_Description") %>'
                                                                                            CommandName="DownloadAttachment" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                                    HeaderText="Attached By">
                                                                                    <ItemStyle Width="30%" />
                                                                                    <ItemTemplate>
                                                                                        <%# Eval("AttachedBy") %>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Remove">
                                                                                    <ItemStyle Width="20%" />
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkRemoveAttachment" runat="server" Text="Remove" CommandArgument='<%#Eval("PK_Attachment_Id") + ":" + Eval("Attachment_Description") %>'
                                                                                            CommandName="RemoveAttachment" OnClientClick="return ConfirmRemove();" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td colspan="6" width="100%" align="center">
                                                                    <asp:Button runat="server" ID="btnMaintenanceSave" Text="Save & View" CausesValidation="true" ValidationGroup="vsErrorPropertyCope" OnClick="btnMaintenanceSave_Click" />&nbsp;
                                                                    <asp:Button runat="server" ID="btnBindAttachmentGrid" Text="Bind Attachment" CausesValidation="true" ValidationGroup="vsErrorPropertyCope" OnClick="btnBindAttachmentGrid_Click" Style="display: none" />&nbsp;
                                                                    <asp:Button ID="btnViewAuditPropertyCOPE" runat="server" Text="View Audit Trail"
                                                                        OnClientClick="javascript:return AuditPopUp('COPE');" Visible="false" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlMaintenanceView" runat="server" Width="100%" Visible="false">
                                                <div class="bandHeaderRow" id="hdrInspectionView" runat="server">
                                                    Facility Maintenance
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%" id="Table1" runat="server">
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Maintenance Action Number
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblActionNumber" Width="170px" runat="server" SkinID="lblText"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Location
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <%--<asp:Label ID="lblProject" Width="170px" runat="server" SkinID="lblText"></asp:Label>--%>
                                                            <asp:Label ID="lblLocation" Width="170px" runat="server" SkinID="lblText"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Building Number
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblBuilding" Width="170px" runat="server" SkinID="lblText"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Requester
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblRequester" Width="170px" runat="server" SkinID="lblText"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <%--<tr>
                                                        <td align="left" valign="top">Telephone
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTelephone" Width="170px" runat="server" SkinID="lblText"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Email
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblEmail" Width="170px" runat="server" SkinID="lblText"></asp:Label>
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Created Date
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblInspectionDate" Width="170px" runat="server" SkinID="lblText"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Focus Area
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFocusArea" Width="170px" runat="server" SkinID="lblText"></asp:Label>
                                                        </td>
                                                        <%--<td align="left" width="18%" valign="top">Inspector
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblInspector" Width="170px" runat="server" SkinID="lblText"></asp:Label>
                                                        </td>--%>
                                                    </tr>
                                                    <%--<tr>
                                                        <td align="left" width="18%" valign="top">Date PCA Ordered
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblDatePCAOrdered" Width="170px" runat="server" SkinID="lblText"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Date PCA Conducted
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblDatePCAConducted" Width="170px" runat="server" SkinID="lblText"></asp:Label>
                                                        </td>
                                                    </tr>--%>
                                                    <%--<tr>
                                                        <td align="left" width="18%" valign="top">PCA Conducted By
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblPCAConductedBy" Width="170px" runat="server" SkinID="lblText"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Scope Of Work
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblScopeOfWork" Width="170px" runat="server" SkinID="lblText"></asp:Label>
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Item
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblFocusAreaItem" Width="170px" runat="server" SkinID="lblText"></asp:Label>
                                                        </td>
                                                         <td align="left" valign="top">Status
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblStatus" Width="170px" runat="server" SkinID="lblText"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <%--<tr>
                                                        <td align="left" width="18%" valign="top">Estimated Start Date
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblEstimatedStartDate" Width="170px" runat="server" SkinID="lblText"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Scope Of Work
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblScopeOfWork" Width="170px" runat="server" SkinID="lblText"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Estimated End Date
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblEstimatedEndDate" Width="170px" runat="server" SkinID="lblText"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Actual Start Date
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblActualStartDate" Width="170px" runat="server" SkinID="lblText"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Number Of Days
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblNumberOfDays" Width="170px" runat="server" SkinID="lblText"></asp:Label>
                                                        </td>
                                                    </tr>--%>
                                                    <%--<tr>
                                                        <td align="left" valign="top">Maintenance Type
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblMaintenanceType" Width="170px" runat="server" SkinID="lblText"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Assigned
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblResponsibleParty" Width="170px" runat="server" SkinID="lblText"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                       
                                                        <td align="left" width="18%" valign="top">Approved By
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblApprovedBy" Width="170px" runat="server" SkinID="lblText"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Vendor
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblFirm" Width="170px" runat="server" SkinID="lblText"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Vendor Contact
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label ID="lblContactName" Width="170px" runat="server" SkinID="lblText"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Estimated Amount
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">$&nbsp;<asp:Label ID="lblEstimatedAmmount" Width="170px" runat="server" SkinID="lblText"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Actual Amount
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">$&nbsp;<asp:Label ID="lblActualAmmount" Width="170px" runat="server" SkinID="lblText"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Prposal Amount
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">$&nbsp;<asp:Label ID="lblProposalAmount" Width="170px" runat="server" SkinID="lblText"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Variance
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">$&nbsp;<asp:Label ID="lblVariance" Width="170px" runat="server" SkinID="lblText"></asp:Label>
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="left" valign="top">Title
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblTitle" Width="170px" runat="server" SkinID="lblText"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Priority
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="lblPriority" Width="170px" runat="server" SkinID="lblText"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="6">Repair Description&nbsp;<span id="Span3" style="color: Red; display: none;"
                                                            runat="server">*</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="6">
                                                            <uc:ctrlMultiLineTextBox runat="server" ID="lblRepairDescription" ControlType="Label" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div id="divNotesView" runat="server">
                                                    <div class="bandHeaderRow">
                                                        Notes
                                                    </div>
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <td colspan="3">
                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                    <tr>
                                                                        <td width="45%"></td>
                                                                        <td valign="top" align="right">
                                                                            <uc:ctrlPaging ID="ctrlPageSonicNotesView" runat="server" OnGetPage="ctrlPageSonicNotesView_GetPage" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <td valign="top" style="width: 20%">Notes Grid                                                        
                                                            </td>
                                                            <td align="center" valign="top" style="width: 3%">:
                                                            </td>
                                                            <td style="margin-left: 40px" style="width: 650px" align="left">
                                                                <asp:GridView ID="gvNotesView" runat="server" AutoGenerateColumns="false" Width="100%" OnRowCommand="gvNotesView_RowCommand">
                                                                    <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                                    <EmptyDataTemplate>
                                                                        <asp:Label ID="lblEmptyEmergencyMessage" runat="server" Text="No Record Found"></asp:Label>
                                                                    </EmptyDataTemplate>
                                                                    <Columns>
                                                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                            HeaderText="Note Date">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lbtNoteView_Date" runat="server" Text='<%# string.Format("{0:MM/dd/yyyy}", Eval("Note_Date")) %>'
                                                                                    CommandName="EditRecord" CommandArgument='<%#Eval("PK_Facility_Maintenance_Notes") %>' Width="80px"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                            HeaderText="Author">
                                                                            <ItemStyle Width="30%" />
                                                                            <ItemTemplate>
                                                                                <%# Eval("AuthorName") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                            HeaderText="Notes">
                                                                            <ItemTemplate>
                                                                                <%# Eval("Note") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                            HeaderText="Remove">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lbtDeleteView" runat="server" Text="Remove" CommandName="Remove"
                                                                                    CommandArgument='<%#Eval("PK_Facility_Maintenance_Notes") %>' OnClientClick="javascript:return confirm('Are you sure you want delete selected record?');"
                                                                                    Width="80px"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <div id="divAttachmentView" runat="server">
                                                    <div class="bandHeaderRow">
                                                        Attachments
                                                    </div>
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <td valign="top" style="width: 20%">Attachments Grid
                                                            </td>
                                                            <td align="center" valign="top" style="width: 3%">:
                                                            </td>
                                                            <td style="margin-left: 40px" style="width: 650px" align="left">
                                                                <asp:GridView ID="gvAttachmentDetailsView" runat="server" Width="100%" EmptyDataText="Currently there is no attachment." OnRowCommand="gvAttachmentDetails_RowCommand">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="File Name">
                                                                            <ItemStyle Width="50%" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkAttachFileView" runat="server" Text='<%# Eval("Attachment_Description").ToString().Substring(12, (Eval("Attachment_Description").ToString().Length-1) - 11)%>' CommandArgument='<%# Eval("Attachment_Description") %>'
                                                                                    CommandName="DownloadAttachment" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-VerticalAlign="Top"
                                                                            HeaderText="Attached By">
                                                                            <ItemStyle Width="30%" />
                                                                            <ItemTemplate>
                                                                                <%# Eval("AttachedBy") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Remove">
                                                                            <ItemStyle Width="20%" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkRemoveAttachmentView" runat="server" Text="Remove" CommandArgument='<%#Eval("PK_Attachment_Id") + ":" + Eval("Attachment_Description") %>'
                                                                                    CommandName="RemoveAttachment" OnClientClick="return ConfirmRemove();" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <hr />
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td colspan="6" width="100%" align="center">
                                                            <asp:Button runat="server" ID="btnManitenanceEdit" Text="Edit" CausesValidation="true" ValidationGroup="vsErrorPropertyCope" OnClick="btnManitenanceEdit_Click" />&nbsp;                                                                    
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
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

