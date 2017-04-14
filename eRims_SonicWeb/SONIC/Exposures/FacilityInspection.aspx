<%@ Page Title="eRIMS Sonic :: Exposures :: Inspection" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="FacilityInspection.aspx.cs" Inherits="SONIC_Exposures_FacilityInspection" %>

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
    <script type="text/javascript" language="javascript">
        var popUpId = '';

        function SetPopUpId(id) {
            popUpId = id;
        }

        function AddMaintenanceAttachment(id) {
            var popUpTitle = 'Attach Maintenance Documents';
            var PopUpURL = '<%=AppConfig.SiteURL%>SONIC/Exposures/MaintenanceAddAttachment.aspx';
            GB_showCenter(popUpTitle, PopUpURL + '?item=' + id, 300, 500);
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
                                                                                            <span class="LeftMenuStatic" id="PropertyMenu7" onclick="javascript:RedirectTo(10);">Facility Maintenance
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
                                                                                            <span class="LeftMenuSelected" id="PropertyMenu6" onclick="javascript:void(0);">EHS Inspection
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
                                            <asp:Panel ID="pnlInspectionEdit" runat="server" Width="100%">
                                                <asp:UpdatePanel runat="server" ID="updInspectionEdit" UpdateMode="Always">
                                                    <ContentTemplate>
                                                        <div class="bandHeaderRow" id="hdrInspectionEdit" runat="server">
                                                            EHS Inspection
                                                        </div>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%" id="tblInspectionArea" runat="server">
                                                            <tr>
                                                                <td align="left" valign="top">Location
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <%--<asp:DropDownList runat="server" AutoPostBack="true" ID="ddlProject" SkinID="ddlExposure" OnSelectedIndexChanged="ddlProject_SelectedIndexChanged">
                                                                    </asp:DropDownList>--%>
                                                                    <asp:DropDownList ID="ddlLocation" Width="175px" runat="server" AutoPostBack="true" SkinID="dropGen" OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left" valign="top">Building Number <span id="Span1" runat="server" style="color: Red;">*</span>
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:DropDownList runat="server" ID="ddlBuilding" SkinID="ddlExposure" AutoPostBack="true" OnSelectedIndexChanged="ddlBuilding_SelectedIndexChanged" >
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfvBuilding" runat="server" ErrorMessage="Please select Building Number"
                                                                        Display="None" SetFocusOnError="true" ControlToValidate="ddlBuilding"
                                                                        ValidationGroup="vsErrorPropertyCope" InitialValue="0"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" width="18%" valign="top">Inspection Date
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:TextBox ID="txtInspectionDate" Width="170px" runat="server" SkinID="txtDate" onpaste="return false"></asp:TextBox>
                                                                    <img alt="Inspection Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtInspectionDate', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" />
                                                                </td>
                                                                <td align="left" width="18%" valign="top">Inspector
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:DropDownList runat="server" ID="ddlInspector" SkinID="ddlExposure">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Focus Area
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:DropDownList runat="server" AutoPostBack="true" ID="ddlFocusArea" SkinID="ddlExposure" OnSelectedIndexChanged="ddlFocusArea_SelectedIndexChanged"  >
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <hr />
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" valign="top" width="8%">
                                                                    <b>Item</b>
                                                                </td>
                                                                <td align="left" valign="top" width="10%">
                                                                    <b>Condition</b>
                                                                </td>
                                                                <td colspan="3" align="left" valign="top" width="8%">
                                                                    <b>Problem Description</b>
                                                                </td>
                                                               <%-- <td align="left" valign="top" width="8%">
                                                                    <b>Est. Cost</b>
                                                                </td>
                                                                <td align="left" valign="top" width="22%">
                                                                    <b>Est. Start Date</b>
                                                                </td>
                                                                <td align="left" valign="top" width="15%">
                                                                    <b>Assign</b>
                                                                </td>--%>
                                                                <td align="left" valign="top" width="5%">
                                                                    <b>Add Maint.</b>
                                                                </td>
                                                                <td align="left" valign="top" width="5%">
                                                                    <b>Attachment</b>
                                                                </td>
                                                            </tr>
                                                            <asp:Repeater ID="rptFocusAreaItem" runat="server" OnItemDataBound="rptFocusAreaItem_ItemDataBound">
                                                                <ItemTemplate>
                                                                    <tr>
                                                                        <td align="left" valign="top">
                                                                            <asp:Label runat="server" ID="lblFocusAreaItem"><%# Eval("Description") %></asp:Label>
                                                                            <asp:HiddenField runat="server" ID="hdnFocusAreaItemId" Value='<%# Eval("PK_LU_Facility_Inspection_Item") %>'></asp:HiddenField>
                                                                            <asp:HiddenField runat="server" ID="hdnMaintenanceItemId" Value=''></asp:HiddenField>
                                                                            <asp:HiddenField runat="server" ID="hdnFacility_Construction_Inspection_Item" Value=''></asp:HiddenField>
                                                                        </td>
                                                                        <td align="left" valign="top">
                                                                            <asp:DropDownList runat="server" ID="ddlCondition">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td colspan="3" align="left" valign="top"><asp:TextBox runat="server" ID="txtProblemDescription" MaxLength="30"></asp:TextBox>
                                                                        </td>
                                                                       <%-- <td align="left" valign="top">$&nbsp;<asp:TextBox runat="server" ID="txtEstCost" onpaste="return false" onkeypress="return FormatNumber(event,this.id,10 ,false);" MaxLength="11"></asp:TextBox>
                                                                        </td>
                                                                        <td align="left" valign="top">
                                                                            <asp:TextBox ID='txtEstStartDate' runat="server" SkinID="txtDate" onpaste="return false"></asp:TextBox>
                                                                            <img alt="Est Start Date" onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                                align="middle" runat="server" id="imgCalendar" />
                                                                        </td>
                                                                        <td align="left" valign="top">
                                                                            <asp:DropDownList runat="server" ID="ddlAssignedTo">
                                                                            </asp:DropDownList>
                                                                        </td>--%>
                                                                        <td align="left" valign="top">                                                                            
                                                                            <asp:ImageButton ID="btnAddMaintenance" runat="server" ImageUrl="~/Images/Add-maint.png" OnClick="btnAddMaintenance_Click" CommandArgument='<%# Eval("PK_LU_Facility_Inspection_Item") %>' />
                                                                        </td>
                                                                        <td align="left" valign="top">                                                                            
                                                                            <asp:ImageButton ID="btnAttachment" runat="server" ImageUrl="~/Images/Add-attachment.png" OnClick="btnAttachment_Click" CommandArgument='<%# Eval("PK_LU_Facility_Inspection_Item") %>' />
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </table>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td colspan="6" width="100%" align="center">
                                                                    <asp:Button runat="server" ID="btnInspectionSave" Text="Save & View" CausesValidation="true" ValidationGroup="vsErrorPropertyCope" OnClick="btnInspectionSave_Click" />&nbsp;
                                                                    <asp:Button ID="btnViewAuditPropertyCOPE" runat="server" Text="View Audit Trail"
                                                                        OnClientClick="javascript:return AuditPopUp('COPE');" Visible="false" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlInspectionView" runat="server" Width="100%" Visible="false">
                                                <div class="bandHeaderRow" id="hdrInspectionView" runat="server">
                                                    EHS Inspection
                                                </div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%" id="Table1" runat="server">
                                                    <tr>
                                                        <%--<td align="left" valign="top">Project
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label runat="server" ID="lblProject"></asp:Label>
                                                        </td>--%>
                                                        <td align="left" valign="top">Location
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label runat="server" ID="lblLocation"></asp:Label>
                                                        </td>
                                                        <td align="left" valign="top">Building
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label runat="server" ID="lblBuilding"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%" valign="top">Inspection Date
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label runat="server" ID="lblInspectionDate"></asp:Label>
                                                        </td>
                                                        <td align="left" width="18%" valign="top">Inspector
                                                        </td>
                                                        <td align="center" width="4%" valign="top">:
                                                        </td>
                                                        <td align="left" width="28%" valign="top">
                                                            <asp:Label runat="server" ID="lblInspector"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">Focus Area
                                                        </td>
                                                        <td align="center" valign="top">:
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <asp:Label runat="server" ID="lblFocusArea"></asp:Label>
                                                        </td>                                                        
                                                    </tr>                                                    
                                                </table>
                                                <hr />
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td align="left" valign="top" width="30%">
                                                            <b>Item</b>
                                                        </td>
                                                        <td align="left" valign="top" width="30%">
                                                            <b>Condition</b>
                                                        </td>
                                                        <%--<td align="left" valign="top" width="10%">
                                                            <b>Est. Cost</b>
                                                        </td>
                                                        <td align="left" valign="top" width="10%">
                                                            <b>Est. Start Date</b>
                                                        </td>
                                                        <td align="left" valign="top" width="10%">
                                                            <b>Assign</b>
                                                        </td>--%>
                                                        <td align="left" colspan="3" valign="top" width="30%">
                                                            <b>Problem Description</b>
                                                        </td>
                                                    </tr>
                                                    <asp:Repeater ID="rptFocusAreaItemView" runat="server">
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td align="left" valign="top" width="30%">
                                                                    <asp:Label runat="server" ID="lblFocusAreaItem"><%# Eval("Description") %></asp:Label>
                                                                </td>
                                                                <td align="left" valign="top" width="30%">
                                                                    <asp:Label runat="server" ID="lblCondition"><%# Convert.ToString(Eval("Inspection_Condition_Rank")) =="0" ? "" :Convert.ToString(Eval("Inspection_Condition_Rank")) %></asp:Label>
                                                                </td>
                                                                <td align="left" colspan="3" valign="top" width="30%"><asp:Label runat="server" ID="lblProblemDesc"><%# Convert.ToString(Eval("Problem_Description")) %></asp:Label>
                                                                </td>
                                                                <%--<td align="left" valign="top" width="10%">$&nbsp;<asp:Label runat="server" ID="lblEstCost"><%# clsGeneral.FormatCommaSeperatorCurrency(Eval("Estimated_Cost")) %></asp:Label>
                                                                </td>
                                                                <td align="left" valign="top" width="10%">
                                                                    <asp:Label runat="server" ID="lblEstStartDate"><%# clsGeneral.FormatDBNullDateToDisplay(Eval("Estimate_Start_Date").ToString()) %></asp:Label>
                                                                </td>
                                                                <td align="left" valign="top" width="10%">
                                                                    <asp:Label runat="server" ID="Label1"><%# Eval("AssignedTo") %></asp:Label>
                                                                </td>--%>
                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </table>
                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                    <tr>
                                                        <td colspan="6" width="100%" align="center">
                                                            <asp:Button runat="server" ID="btnInspectionEdit" Text="Edit" CausesValidation="true" ValidationGroup="vsErrorPropertyCope" OnClick="btnInspectionEdit_Click" />&nbsp;                                                                    
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

