<%@ Page Title="eRIMS Sonic :: Exposures :: Repair And Maintenance List" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="FacilityMaintenance_ItemList.aspx.cs" Inherits="SONIC_Exposures_FacilityMaintenance_ItemList" %>

<%@ Register Src="~/Controls/ExposuresTab/ExposuresTab.ascx" TagName="CtlTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attchment-Exposures/Attachment.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposureInfo/ExposureInfo.ascx" TagName="ctrlExposureInfo"
    TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                                                                                            <span class="LeftMenuStatic" id="PropertyMenu2" onclick="javascript:RedirectTo(1, '&pnl=2');">Building Information</span>&nbsp;<span id="MenuAsterisk2" runat="server" style="color: Red; display: none">*</span>
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
                                                                                            <span class="LeftMenuStatic" id="PropertyMenu4" onclick="javascript:RedirectTo(1, '&panel=4');">Building Improvements</span>&nbsp;<span id="MenuAsterisk3" runat="server" style="color: Red; display: none">*</span>
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
                                                                                            <span class="LeftMenuStatic" id="PropertyMenu5" onclick="javascript:RedirectTo(1, '&contactPanel=5');">Contacts
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
                                                                                            <span class="LeftMenuStatic" id="PropertyMenu6" onclick="javascript:RedirectTo(9);">EHS Inspection
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
                                            <asp:Panel ID="pnlPropertyCope" runat="server" Width="100%">
                                                <asp:UpdatePanel runat="server" ID="updPropertyCope" UpdateMode="Always">
                                                    <ContentTemplate>
                                                        <div id="Div1" class="bandHeaderRow" runat="server">
                                                            Maintenance
                                                        </div>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:GridView ID="gvMaintenance" runat="server" EmptyDataText="No Facility Maintenance Information Exists"
                                                                        AutoGenerateColumns="false" Width="100%" OnRowCommand="gvMaintenance_RowCommand" >
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Maintenance Number">
                                                                                <ItemStyle Width="20%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkViewMaintenanceDetail1" CausesValidation="false" runat="server" Text='<%# Eval("Item_Number")%>'
                                                                                        CommandName="MaintenanceDetails" CommandArgument='<%# Eval("PK_Facility_Construction_Maintenance_Item")%>'></asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Building Number">
                                                                                <ItemStyle Width="20%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkViewMaintenanceDetail2" CausesValidation="false" runat="server" Text='<%# Eval("Building_Number")%>'
                                                                                        CommandName="MaintenanceDetails" CommandArgument='<%# Eval("PK_Facility_Construction_Maintenance_Item")%>'></asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Type">
                                                                                <ItemStyle Width="20%" />
                                                                                <ItemTemplate>
                                                                                    <%# Eval("Maintenance_Type")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Title">
                                                                                <ItemStyle Width="35%" />
                                                                                <ItemTemplate>
                                                                                    <%# Eval("Title") %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Status">
                                                                                <ItemStyle Width="35%" />
                                                                                <ItemTemplate>
                                                                                    <%# Eval("Maintenance_Status") %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>                                                                            
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr runat="server" id="trAddNew" visible="false">
                                                                <td align="left">
                                                                    <asp:LinkButton ID="lnkAddNewMaintenance" runat="server"
                                                                        Text="Add New" OnClick="lnkAddNewMaintenance_Click" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" width="100%" align="center">
                                                                    <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />                                                                    
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
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

