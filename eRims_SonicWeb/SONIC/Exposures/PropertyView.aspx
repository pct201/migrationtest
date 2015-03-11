<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PropertyView.aspx.cs" MasterPageFile="~/Default.master"
    Inherits="SONIC_Exposures_PropertyView" Title="eRIMS Sonic :: Exposures :: Property Data" %>

<%@ Register Src="~/Controls/ExposuresTab/ExposuresTab.ascx" TagName="CtlTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposureInfo/ExposureInfo.ascx" TagName="ctrlExposureInfo"
    TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
        function seLocationBuildingNumber(str) {
            document.getElementById("ctl00_ContentPlaceHolder1_ucCtrlExposureInfo_lblRMLocationNumber").innerText = str;
        }
        function AuditPopUp(page) {
            var pageName = "";
            var ID = "";
            if (page == 'COPE') {
                pageName = "AuditPopup_PropertyCOPE.aspx"; ID = '<%=ViewState["PK_Property_Cope_ID"]%>';
            }
            else if (page == 'Building') {
                pageName = "AuditPopup_Building.aspx"; ID = document.getElementById('<%=hdnBuildingID.ClientID%>').value;
            }
            else if (page == 'Ownership') {
                // if ownership is "Owned"
                if (document.getElementById('<%=lblOwnership.ClientID%>').innerHTML == "Owned")
                    pageName = "AuditPopup_OwnershipDetail_Owned.aspx";
                else
                    pageName = "AuditPopup_OwnershipDetail_Leased.aspx";

                ID = document.getElementById('<%=hdnBuildingOwnershipID.ClientID%>').value;
            }
            else if (page == 'Additional_Insured') {
                pageName = "AuditPopup_Additional_Insured.aspx"; ID = document.getElementById('<%=hdnAdditionalInsured.ClientID%>').value;
            }
            else if (page == 'Loss_Payee') {
                pageName = "AuditPopup_Additional_Insured.aspx"; ID = document.getElementById('<%=hdnLossPayeeID.ClientID%>').value;
            }
            else if (page == 'Contacts') {
                pageName = "AuditPopup_Property_Contact.aspx"; ID = document.getElementById('<%=hdnBuildingID.ClientID%>').value;
            }
            else if (page == 'Sub_Lease') {
                pageName = "AuditPopup_BuildingOwnership_Sublease.aspx"; ID = document.getElementById('<%=hdnSubLeaseID.ClientID%>').value;
            }
    var winHeight = window.screen.availHeight - 300;
    var winWidth = window.screen.availWidth - 200;
    obj = window.open(pageName + "?id=" + ID, 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
    obj.focus();
    return false;
}

function ShowAuditPopUp(url) {
    var winHeight = window.screen.availHeight - 300;
    var winWidth = window.screen.availWidth - 200;
    obj = window.open(url, 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
    obj.focus();
    return false;
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
                                                                                            <span class="LeftMenuSelected" id="PropertyMenu1" onclick="javascript:ShowPanel(1);">Property Cope </span>
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
                                                                                            <span class="LeftMenuStatic" id="PropertyMenu2" onclick="javascript:ShowPanel(2);">Building
                                                                                                Information </span>
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
                                                                                            <span class="LeftMenuStatic" id="PropertyMenu4" onclick="javascript:ShowPanel(4);">Building Improvements
                                                                                                <span class="mf"></span></span>
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
                                                                                            <span class="LeftMenuStatic" id="PropertyMenu5" onclick="javascript:ShowPanel(5);">Contacts
                                                                                                <span class="mf"></span></span>
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
                                        <div id="dvView" runat="server">
                                            <asp:Panel ID="pnlPropertyCope" runat="server" Width="100%">
                                                <asp:UpdatePanel runat="server" ID="updPropertyCope">
                                                    <ContentTemplate>
                                                        <div class="bandHeaderRow" id="hdrPropertyCope" runat="server">
                                                            Property Cope
                                                        </div>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%" id="tblPropertyCope"
                                                            runat="server">
                                                            <tr>
                                                                <td align="left" width="18%" valign="top">Location d/b/a
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:Label runat="server" ID="lblLocationdba"></asp:Label>
                                                                </td>
                                                                <td align="left" width="18%" valign="top">Legal Entity Name
                                                                </td>
                                                                <td align="center" width="4%" valign="top">:
                                                                </td>
                                                                <td align="left" width="28%" valign="top">
                                                                    <asp:Label runat="server" ID="lblLegalEntity"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Location f/k/a
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label runat="server" ID="lblLocationfka"></asp:Label>
                                                                </td>
                                                                <td align="left" valign="top">Sonic Location Code
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label runat="server" ID="lblLocationRMNumber"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Status
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblStatus" runat="server"></asp:Label>
                                                                </td>
                                                                <td align="left" valign="top">Status as of Date
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblStatus_As_Of_Date" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6" id="tdDisposal" runat="server" style="display: none">
                                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                        <tr>
                                                                            <td align="left" width="18%" valign="top">Disposal Type
                                                                            </td>
                                                                            <td align="center" width="4%" valign="top">:
                                                                            </td>
                                                                            <td align="left" width="28%" valign="top">
                                                                                <asp:Label runat="server" ID="lblDisposal_Type" Width="170px"></asp:Label>
                                                                            </td>
                                                                            <td>&nbsp;
                                                                            </td>
                                                                            <td>&nbsp;
                                                                            </td>
                                                                            <td>&nbsp;
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Union Shop?
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label runat="server" ID="lblUnion_Shop"></asp:Label>
                                                                </td>
                                                                <td align="left" valign="top">Property Boundary Dimension
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label runat="server" ID="lblProperty_Boundry_Dimension" Width="170px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" width="100%">
                                                                    <b>Primary/Physical Address</b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Address 1
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblAddress_1" runat="server" Width="170px"></asp:Label>
                                                                </td>
                                                                <td align="left" valign="top">Telephone
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblTelephone" runat="server" Width="170px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Address 2
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblAddress_2" runat="server" Width="170px"></asp:Label>
                                                                </td>
                                                                <td align="left" valign="top">Web Site
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblWeb_Site" runat="server" Width="170px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">City
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:Label runat="server" ID="lblCity" Width="170px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">State
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label runat="server" ID="lblState" Width="170px"></asp:Label>
                                                                </td>
                                                                <td colspan="3">&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Zip
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:Label runat="server" ID="lblZip" Width="170px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <!-- Commented Below Section for ticket #3132 -->
                                                            <%--<tr>
                                                                <td colspan="6" width="100%">
                                                                    <b>Financial Limits(Summary of all buildings)</b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Valuation Date
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblValuation_Date" runat="server" Width="170px"></asp:Label>
                                                                </td>
                                                                <td align="left" valign="top">Building Limit
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblBuilding_Limit" runat="server" Width="170px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Leasehold Interests<br />
                                                                    Limit - Betterment
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblLeasehold_Interests_Limit_Betterment" runat="server" Width="170px"></asp:Label>
                                                                </td>
                                                                <td align="left" valign="top">Betterment Date Complete
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblBetterment_Date_Complate" runat="server" Width="170px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Leasehold Interests<br />
                                                                    Limit - Expansion
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblLeasehold_Interests_Limit_Expansion" runat="server" Width="170px"></asp:Label>
                                                                </td>
                                                                <td align="left" valign="top">Expansion Date Complete
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblExpansion_Date_Complate" runat="server" Width="170px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Associate Tools Limit
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblAssociate_Tools_Limit" runat="server" Width="170px"></asp:Label>
                                                                </td>
                                                                <td align="left" valign="top">Contents Limit
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblContents_Limit" runat="server" Width="170px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                                <td align="center" valign="top">&nbsp;
                                                                </td>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                                <td align="left" valign="top">Parts Limit
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblParts_Limit" runat="server" Width="170px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                                <td align="left" valign="top">RS Means Building Value
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblRS_Means_Building_Value_Total" runat="server" Width="170px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td colspan="6" width="100%">Business Interruption
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" width="100%">
                                                                    <asp:GridView ID="gvBusinessInterruption" runat="server" Width="100%" AutoGenerateColumns="false">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Type&nbsp;&nbsp;<i>Click to view detail</i>">
                                                                                <ItemStyle Width="70%" />
                                                                                <ItemTemplate>
                                                                                    <%# Eval("TypeDesc").ToString() != "Total" ? "<a href='#' onclick=\"OpenSelectYearPopup('" + Eval("Type") + "')\">" + Eval("TypeDesc") + "</a>" : "<b>Total</b>"%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Amount">
                                                                                <ItemStyle Width="30%" />
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount")%>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Inventory Levels
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label runat="server" ID="lblInventory_Levels" Width="170px"></asp:Label>
                                                                </td>
                                                                <td align="left" valign="top">TIV
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="lblCalculated" runat="server" Width="170px"></asp:Label>
                                                                </td>
                                                            </tr>--%>
                                                            <!-- Commented above Section for ticket #3132 -->
                                                            <tr>
                                                                <td valign="top">Saba Training Grid
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td colspan="4" align="left" valign="top">
                                                                    <asp:HiddenField ID="hdnPKPropertySabaTraning" runat="server" />
                                                                    <asp:GridView ID="gvSabaTraining" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                        OnRowCommand="gvSabaTraining_RowCommand">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Date">
                                                                                <ItemStyle Width="12%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lbnDate" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_Property_COPE_Saba_Training") %>'
                                                                                        Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Date")) %>'></asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Year">
                                                                                <ItemStyle Width="10%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lbnYear" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_Property_COPE_Saba_Training") %>'
                                                                                        Text='<%# Eval("Year") %>' Visible='<%# (Convert.ToInt32(Eval("PK_Property_COPE_Saba_Training")) > 0) %>'></asp:LinkButton>
                                                                                    <asp:Label ID="lblYear" runat="server" Text='<%# Eval("Year") %>' Visible='<%# (Convert.ToInt32(Eval("PK_Property_COPE_Saba_Training")) == 0) %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Quarter">
                                                                                <ItemStyle Width="15%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lbnQuarter" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_Property_COPE_Saba_Training") %>'
                                                                                        Text='<%# Eval("Quarter") %>' Visible='<%# (Convert.ToInt32(Eval("PK_Property_COPE_Saba_Training")) > 0) %>'></asp:LinkButton>
                                                                                    <asp:Label ID="lblQuarter" runat="server" Text='Running Total' Visible='<%# (Convert.ToInt32(Eval("PK_Property_COPE_Saba_Training")) == 0) %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Number of Associates To Train">
                                                                                <ItemStyle Width="15%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lbnEmployees" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_Property_COPE_Saba_Training") %>'
                                                                                        Text='<%# clsGeneral.GetStringValue(Eval("Number_of_Employees")).Replace(".00","")%>'
                                                                                        Visible='<%# (Convert.ToInt32(Eval("PK_Property_COPE_Saba_Training")) > 0) %>'></asp:LinkButton>
                                                                                    <asp:Label ID="lblEmployees" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Number_of_Employees")).Replace(".00","")%>'
                                                                                        Visible='<%# (Convert.ToInt32(Eval("PK_Property_COPE_Saba_Training")) == 0) %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Number of Associates Trained">
                                                                                <ItemStyle Width="20%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lbnEmployeesTrained" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_Property_COPE_Saba_Training") %>'
                                                                                        Text='<%# clsGeneral.GetStringValue(Eval("Number_Trained")).Replace(".00","")%>'
                                                                                        Visible='<%# (Convert.ToInt32(Eval("PK_Property_COPE_Saba_Training")) > 0) %>'></asp:LinkButton>
                                                                                    <asp:Label ID="lblEmployeesTrained" runat="server" Text='<%# clsGeneral.GetStringValue(Eval("Number_Trained")).Replace(".00","")%>'
                                                                                        Visible='<%# (Convert.ToInt32(Eval("PK_Property_COPE_Saba_Training")) == 0) %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Percent of Associates Trained">
                                                                                <ItemStyle Width="20%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lbnPercent" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_Property_COPE_Saba_Training") %>'
                                                                                        Text='<%# Eval("Percent_Trained") !=DBNull.Value ? Eval("Percent_Trained") + "%" : "" %>'
                                                                                        Visible='<%# (Convert.ToInt32(Eval("PK_Property_COPE_Saba_Training")) > 0) %>'></asp:LinkButton>
                                                                                    <asp:Label ID="lblPercent" runat="server" Text='<%# Eval("Percent_Trained") !=DBNull.Value ? Eval("Percent_Trained") + "%" : "" %>'
                                                                                        Visible='<%# (Convert.ToInt32(Eval("PK_Property_COPE_Saba_Training")) == 0) %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <EmptyDataTemplate>
                                                                            No Record Found !
                                                                        </EmptyDataTemplate>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" width="100%" align="center">
                                                                    <asp:Button ID="btnViewAuditPropertyCOPE" runat="server" Text="View Audit Trail"
                                                                        OnClientClick="javascript:return AuditPopUp('COPE');" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <asp:Panel ID="pnlSabaTraining" runat="server" Width="100%">
                                                            <div class="bandHeaderRow">
                                                                Saba Training
                                                            </div>
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" width="18%" valign="top">Date
                                                                    </td>
                                                                    <td width="4%" align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top" width="78%">
                                                                        <asp:Label ID="txtSaba_Training_Date" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="18%" valign="top">Year
                                                                    </td>
                                                                    <td width="4%" align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top" width="78%">
                                                                        <asp:Label ID="txtSaba_Training_Year" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="20%" valign="top">Quarter
                                                                    </td>
                                                                    <td width="4%" align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblQuarter" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">Number of Associates To Train
                                                                    </td>
                                                                    <td width="4%" align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label runat="server" ID="txtNumber_of_Employees"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">Number of Associates Trained
                                                                    </td>
                                                                    <td width="4%" align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label runat="server" ID="txtNumber_of_Employees_To_Date" Width="170px"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">Percent of Associates Trained
                                                                    </td>
                                                                    <td width="4%" align="center" valign="top">:
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label runat="server" ID="txtPercent_Employee_to_Date"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="3" align="left" valign="top">
                                                                        <table border="0" align="center" cellpadding="0" cellspacing="5">
                                                                            <tr>
                                                                                <td>
                                                                                    <%--<asp:Button ID="btnSaveSabaTraining" runat="server" Text="Save" OnClick="btnSaveSabaTraining_Click"
                                                                                        CausesValidation="true" ValidationGroup="vsErrorSabaTraining" />--%>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Button ID="btnViewAuditSabaTraining" runat="server" Text="View Audit Trail" />
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Button ID="btnBackSabaTraing" runat="server" Text="Back" OnClick="btnBackProperty_Click" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlBuildingInformation" runat="server" Width="100%" Style="display: none;">
                                                <div class="bandHeaderRow">
                                                    Building Information
                                                </div>
                                                <asp:UpdatePanel runat="server" ID="updBuildingInfo" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <input type="hidden" id="hdnBuildingID" runat="server" />
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <asp:GridView ID="gvBuildingEdit" runat="server" EmptyDataText="No Other Building Records Found"
                                                                        AutoGenerateColumns="false" OnRowDataBound="gvBuildingEdit_RowDataBound" Width="100%"
                                                                        OnRowCommand="gvBuildingEdit_RowCommand">
                                                                        <Columns>
                                                                            <asp:TemplateField>
                                                                                <ItemStyle Width="5%" HorizontalAlign="center" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkViewDetail" runat="server" Text='<%# Container.DataItemIndex + 1 %>'
                                                                                        CommandName="ViewBuildingDetail" CommandArgument='<%# Eval("PK_Building_ID")%>'></asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Building Number">
                                                                                <ItemStyle Width="20%" />
                                                                                <ItemTemplate>
                                                                                    <%# Eval("Building_Number")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Address">
                                                                                <ItemStyle Width="35%" />
                                                                                <ItemTemplate>
                                                                                    <%# clsGeneral.FormatAddress(Eval("Address_1"),Eval("Address_2"),Eval("City"),Eval("State"),Eval("Zip")) %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Occupancy">
                                                                                <ItemStyle Width="40%" />
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblOccupancy" runat="server" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div id="dvBuilding" runat="server" style="display: none;">
                                                                        <table cellpadding="3" cellspacing="0" width="100%">
                                                                            <tr>
                                                                                <td align="left" width="18%" valign="top">Status
                                                                                </td>
                                                                                <td align="center" width="4%" valign="top">:
                                                                                </td>
                                                                                <td align="left" width="28%" valign="top" colspan="4">
                                                                                    <asp:Label runat="server" ID="lblLocationStatus" Width="170px"> </asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <b>Ownership</b>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <asp:Label runat="server" ID="lblOwnership"> </asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr id="trLiability" runat="server" style="display: none">
                                                                                <td align="left" colspan="6">
                                                                                    <b>Liability</b><br />
                                                                                    <asp:Label ID="lblLiability" runat="server" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 8px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <b>Occupancy</b>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 8px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <table cellpadding="3" cellspacing="0" border="0" width="100%">
                                                                                        <tr>
                                                                                            <td width="23%" align="left">Sales - New
                                                                                            </td>
                                                                                            <td width="10%" align="left">
                                                                                                <asp:Label runat="server" ID="lblOccupancySalesNew"></asp:Label>
                                                                                            </td>
                                                                                            <td width="23%" align="left">Body Shop
                                                                                            </td>
                                                                                            <td width="10%" align="left">
                                                                                                <asp:Label runat="server" ID="lblOccupancyBodyShop"></asp:Label>
                                                                                            </td>
                                                                                            <td width="24%" align="left">Parking Lot
                                                                                            </td>
                                                                                            <td width="10%" align="left">
                                                                                                <asp:Label runat="server" ID="lblOccupancyParkingLot"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td width="23%" align="left">Sales - Used
                                                                                            </td>
                                                                                            <td width="10%" align="left">
                                                                                                <asp:Label runat="server" ID="lblOccupancySalesUsed"></asp:Label>
                                                                                            </td>
                                                                                            <td width="23%" align="left">Parts
                                                                                            </td>
                                                                                            <td width="10%" align="left">
                                                                                                <asp:Label runat="server" ID="lblOccupancyParts"></asp:Label>
                                                                                            </td>
                                                                                            <td width="24%" align="left">Raw Land
                                                                                            </td>
                                                                                            <td width="10%" align="left">
                                                                                                <asp:Label runat="server" ID="lblOccupancyRawLand"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td width="23%" align="left">Service
                                                                                            </td>
                                                                                            <td width="10%" align="left">
                                                                                                <asp:Label runat="server" ID="lblOccupancyService"></asp:Label>
                                                                                            </td>
                                                                                            <td width="23%" align="left">Office
                                                                                            </td>
                                                                                            <td width="10%" align="left">
                                                                                                <asp:Label runat="server" ID="lblOccupancyOffice"></asp:Label>
                                                                                            </td>
                                                                                            <td width="24%" align="left">Occupancy_Car_Wash
                                                                                            </td>
                                                                                            <td width="10%" align="left">
                                                                                                <asp:Label runat="server" ID="lblOccupancyCarWash"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td width="23%" align="left"></td>
                                                                                            <td width="10%" align="left"></td>
                                                                                            <td width="23%" align="left"></td>
                                                                                            <td width="10%" align="left"></td>
                                                                                            <td width="24%" align="left">Occupancy_Photo_Booth
                                                                                            </td>
                                                                                            <td width="10%" align="left">
                                                                                                <asp:Label runat="server" ID="lblOccupancyPhotoBooth"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 8px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <b>Address</b>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 8px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" width="18%" valign="top">Address 1
                                                                                </td>
                                                                                <td align="center" width="4%" valign="top">:
                                                                                </td>
                                                                                <td align="left" width="28%" valign="top">
                                                                                    <asp:Label runat="server" ID="lblBuildingAddress_1" Width="170px"></asp:Label>
                                                                                </td>
                                                                                <td align="left" width="18%" valign="top">&nbsp;
                                                                                </td>
                                                                                <td align="center" width="4%" valign="top">&nbsp;
                                                                                </td>
                                                                                <td align="left" width="28%" valign="top">&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">Address 2
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label runat="server" ID="lblBuildingAddress_2" Width="170px"></asp:Label>
                                                                                </td>
                                                                                <td align="left" valign="top">&nbsp;
                                                                                </td>
                                                                                <td align="center" valign="top">&nbsp;
                                                                                </td>
                                                                                <td align="left" valign="top">&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">City
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label runat="server" ID="lblBuilding_City" Width="170px"></asp:Label>
                                                                                </td>
                                                                                <td align="left" valign="top">&nbsp;
                                                                                </td>
                                                                                <td align="center" valign="top">&nbsp;
                                                                                </td>
                                                                                <td align="left" valign="top">&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">State
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label runat="server" ID="lblBuidingState"></asp:Label>
                                                                                </td>
                                                                                <td align="left" valign="top">&nbsp;
                                                                                </td>
                                                                                <td align="center" valign="top">&nbsp;
                                                                                </td>
                                                                                <td align="left" valign="top">&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">Zip
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label runat="server" ID="lblBuilding_Zip" Width="170px"></asp:Label>
                                                                                </td>
                                                                                <td align="left" valign="top">&nbsp;
                                                                                </td>
                                                                                <td align="center" valign="top">&nbsp;
                                                                                </td>
                                                                                <td align="left" valign="top">&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 8px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <b>Financial Limits</b>
                                                                                </td>
                                                                            </tr>
                                                                            <%--<tr>
                                                                                <td class="Spacer" style="height: 8px;">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">
                                                                                    Building Limit
                                                                                </td>
                                                                                <td align="center" valign="top">
                                                                                    :
                                                                                </td>
                                                                                <td align="left" colspan="4">
                                                                                    <asp:Label ID="lblFinancial_Building_Limit" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                             <tr>
                                                                                <td align="left" valign="top">
                                                                                    Leasehold Interests<br />
                                                                                    Limit - Betterment
                                                                                </td>
                                                                                <td align="center" valign="top">
                                                                                    :
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label ID="lblFinancial_Leasehold_Interests_Limit_Betterment" runat="server"
                                                                                        Width="170px"></asp:Label>
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    Betterment Date Complete
                                                                                </td>
                                                                                <td align="center" valign="top">
                                                                                    :
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label ID="lblFinancial_Betterment_Date_Complate" runat="server" Width="170px"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">
                                                                                    Leasehold Interests<br />
                                                                                    Limit - Expansion
                                                                                </td>
                                                                                <td align="center" valign="top">
                                                                                    :
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label ID="lblFinancial_Leasehold_Interests_Limit_Expansion" runat="server" Width="170px"></asp:Label>
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    Expansion Date Complete
                                                                                </td>
                                                                                <td align="center" valign="top">
                                                                                    :
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label ID="lblFinancial_Expansion_Date_Complate" runat="server" Width="170px"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">
                                                                                    Associate Tools Limit
                                                                                </td>
                                                                                <td align="center" valign="top">
                                                                                    :
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label ID="lblFinancial_Associate_Tools_Limit" runat="server" Width="170px"></asp:Label>
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    Contents Limit
                                                                                </td>
                                                                                <td align="center" valign="top">
                                                                                    :
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label ID="lblFinancial_Contents_Limit" runat="server" Width="170px"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">
                                                                                    Parts Limit
                                                                                </td>
                                                                                <td align="center" valign="top">
                                                                                    :
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label ID="lblFinancial_Parts_Limit" runat="server" Width="170px"></asp:Label>
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    Inventory Levels
                                                                                </td>
                                                                                <td align="center" valign="top">
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label runat="server" ID="lblFinancial_Inventory_Levels" Width="170px"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">
                                                                                    Total
                                                                                </td>
                                                                                <td align="center" valign="top">
                                                                                    :
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label runat="server" ID="lblFinancial_Total" Width="170px"></asp:Label>
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    RS Means Building Value
                                                                                </td>
                                                                                <td align="center" valign="top">
                                                                                    :
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label ID="lblRS_Means_Building_Value" runat="server" Width="170px"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                             <tr>
                                                                                <td class="Spacer" style="height: 5px;">
                                                                                </td>
                                                                            </tr>--%>
                                                                            <tr>
                                                                                <td align="left" valign="top">Financial Limits Grid
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top" colspan="4">
                                                                                    <asp:GridView ID="gvFinancialLimit" runat="server" Width="100%" OnRowCommand="gvFinancialLimit_RowCommand"
                                                                                        EmptyDataText="No Record Found">
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="Property Valuation Date">
                                                                                                <ItemStyle Width="50%" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:LinkButton ID="lnkPVDate" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Property_Valuation_Date"))%>'
                                                                                                        CommandArgument='<%#Eval("PK_Building_Financial_Limits")%>' CommandName="ShowDetails" />
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Total Value $">
                                                                                                <ItemStyle Width="50%" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:LinkButton ID="lnkTotal" runat="server" Text='<%# string.Format("{0:N2}",Eval("Total")) %>'
                                                                                                        CommandArgument='<%#Eval("PK_Building_Financial_Limits")%>' CommandName="ShowDetails" />
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 10px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <b>Exterior</b>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 10px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">Number of Parking Spaces
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label runat="server" ID="lblNumber_Of_Parking_Spaces" Width="170px"></asp:Label>
                                                                                </td>
                                                                                <td align="left" valign="top">Acreage
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label runat="server" ID="lblAcreage" Width="170px"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 10px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 8px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <b>Construction</b>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 8px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">Year Built
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label runat="server" ID="lblYear_Built" Width="170px"></asp:Label>
                                                                                </td>
                                                                                <td align="left" valign="top">Square Footage
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label runat="server" ID="lblSquare_Footage" Width="170px"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">Number of Stories
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label runat="server" ID="lblNumber_of_Stories" Width="170px"></asp:Label>
                                                                                </td>
                                                                                <td align="left" valign="top">&nbsp;
                                                                                </td>
                                                                                <td align="center" valign="top">&nbsp;
                                                                                </td>
                                                                                <td align="left" valign="top">&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 8px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <b>Construction of Roof</b>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 8px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <table cellpadding="3" cellspacing="0" border="0" width="100%">
                                                                                        <tr>
                                                                                            <td style="width: 23%">Reinforced Concrete
                                                                                            </td>
                                                                                            <td style="width: 10%">
                                                                                                <asp:Label runat="server" ID="lblRoof_Reinforced_Concrete" />
                                                                                            </td>
                                                                                            <td style="width: 23%">Concrete Panels
                                                                                            </td>
                                                                                            <td style="width: 10%">
                                                                                                <asp:Label runat="server" ID="lblRoof_Concrete_Panels" />
                                                                                            </td>
                                                                                            <td style="width: 24%">Steel Deck With Fasteners
                                                                                            </td>
                                                                                            <td style="width: 10%">
                                                                                                <asp:Label runat="server" ID="lblRoof_Steel_Deck_With_Fasteners" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" valign="top">Poured Concrete
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label runat="server" ID="lblRoof_Poured_Concrete" />
                                                                                            </td>
                                                                                            <td>Steel Deck
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label runat="server" ID="lblRoof_Steel_Deck" />
                                                                                            </td>
                                                                                            <td>Wood Joists
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label runat="server" ID="lblRoof_Wood_Joists" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 8px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <b>Construction of Floors</b>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 8px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                        <tr>
                                                                                            <td style="width: 23%">Reinforced Concrete
                                                                                            </td>
                                                                                            <td style="width: 10%">
                                                                                                <asp:Label runat="server" ID="lblFloors_Reinforced_Concrete" />
                                                                                            </td>
                                                                                            <td style="width: 23%">Poured Concrete
                                                                                            </td>
                                                                                            <td style="width: 10%">
                                                                                                <asp:Label runat="server" ID="lblFloors_Poured_Concrete" />
                                                                                            </td>
                                                                                            <td style="width: 24%">Wood Timber
                                                                                            </td>
                                                                                            <td style="width: 10%">
                                                                                                <asp:Label runat="server" ID="lblFloors_Wood_Timber" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 8px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <b>Construction of Exterior Walls</b>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 8px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                        <tr>
                                                                                            <td style="width: 23%">Reinforced Concrete
                                                                                            </td>
                                                                                            <td style="width: 10%">
                                                                                                <asp:Label runat="server" ID="lblExt_Walls_Reinforced_Concrete" />
                                                                                            </td>
                                                                                            <td style="width: 23%">Masonry
                                                                                            </td>
                                                                                            <td style="width: 10%">
                                                                                                <asp:Label runat="server" ID="lblExt_Walls_Masonry" />
                                                                                            </td>
                                                                                            <td style="width: 24%">Corrugated Metal Panels
                                                                                            </td>
                                                                                            <td style="width: 10%">
                                                                                                <asp:Label runat="server" ID="lblExt_Walls_Corrugated_Metal_Panels" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>Tilt-up Concrete
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label runat="server" ID="lblExt_Walls_Tilt_up_Concrete" />
                                                                                            </td>
                                                                                            <td>Glass and Steel Curtain
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label runat="server" ID="lblExt_Walls_Glass_and_Steel_Curtain" />
                                                                                            </td>
                                                                                            <td>Wood Frame
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label runat="server" ID="lblExt_Walls_Wood_Frame" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 8px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <b>Construction of Interior Walls</b>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 8px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                        <tr>
                                                                                            <td style="width: 23%">Masonry With Fire Doors
                                                                                            </td>
                                                                                            <td style="width: 10%">
                                                                                                <asp:Label runat="server" ID="lblInt_Walls_Masonry_With_Fire_Doors" />
                                                                                            </td>
                                                                                            <td style="width: 23%">Masonry with Openings
                                                                                            </td>
                                                                                            <td style="width: 10%">
                                                                                                <asp:Label runat="server" ID="lblInt_Walls_Masonry_with_Openings" />
                                                                                            </td>
                                                                                            <td style="width: 24%">No Interior Walls
                                                                                            </td>
                                                                                            <td style="width: 10%">
                                                                                                <asp:Label runat="server" ID="lblInt_Walls_No_Interior_Walls" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>Masonry
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label runat="server" ID="lblInt_Walls_Masonry" />
                                                                                            </td>
                                                                                            <td>Gypsum Board
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label runat="server" ID="lblInt_Walls_Gypsum_Board" />
                                                                                            </td>
                                                                                            <td>&nbsp;
                                                                                            </td>
                                                                                            <td>&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" valign="top">Do major interior masonry walls(fire walls) extend above roof line
                                                                                            </td>
                                                                                            <td align="left" valign="top">
                                                                                                <asp:Label runat="server" ID="lblInt_wall_extend_above_roof"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" valign="top">&nbsp;
                                                                                            </td>
                                                                                            <td align="center" valign="top">&nbsp;
                                                                                            </td>
                                                                                            <td align="left" valign="top">&nbsp;
                                                                                                <asp:Label runat="server" Visible="false" ID="lblNumber_of_Lifts" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                            <td>&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>

                                                                            <%--<tr>
                                                                                <td align="left" valign="top">
                                                                                    <%--  Number of Paint Booths
                                                                                </td>
                                                                                <td align="center" valign="top"></td>
                                                                                <td align="left" valign="top">
                                                                                    <%--<asp:Label runat="server" ID="lblNumber_of_Paint_Booths" Width="170px"></asp:Label>
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <%--Number of Lifts
                                                                                </td>
                                                                                <td align="center" valign="top"></td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label runat="server" Visible="false" ID="lblNumber_of_Lifts" Width="170px"></asp:Label>
                                                                                </td>
                                                                            </tr>--%>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 8px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <%--<asp:Panel ID="pnlInsuranceCope" runat="server">
                                                                                        <table cellpadding="0" width="100%">
                                                                                            <tr>
                                                                                                <td colspan="6">--%>
                                                                                    <table id="tblInsurance" runat="server" width="100%" cellpadding="0" cellspacing="0">
                                                                                        <tr>
                                                                                            <td colspan="6"><b>Insurance COPE</b><br />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <%--</td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </asp:Panel>--%>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 8px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <b>Protection</b>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 8px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <i>Automatic Sprinklers</i>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 10px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">Sales - New
                                                                                    <br />
                                                                                    % Sprinklered
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label runat="server" ID="lblSales_New_Sprinklered" Width="170px"></asp:Label>
                                                                                </td>
                                                                                <td align="left" valign="top">Sales - Used
                                                                                    <br />
                                                                                    % Sprinklered
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label runat="server" ID="lblSales_Used_Sprinklered" Width="170px"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">Service
                                                                                    <br />
                                                                                    % Sprinklered
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label runat="server" ID="lblService_Sprinklered" Width="170px"></asp:Label>
                                                                                </td>
                                                                                <td align="left" valign="top">Body Shop
                                                                                    <br />
                                                                                    % Sprinklered
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label runat="server" ID="lblBody_Shop_Sprinklered" Width="170px"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">Parts
                                                                                    <br />
                                                                                    % Sprinklered
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label runat="server" ID="lblParts_Sprinklered" Width="170px"></asp:Label>
                                                                                </td>
                                                                                <td align="left" valign="top">Office
                                                                                    <br />
                                                                                    % Sprinklered
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label runat="server" ID="lblOffice_Sprinklered" Width="170px"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 10px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <i>Water Supply</i>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 10px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <table cellpadding="3" cellspacing="0" border="0" width="100%">
                                                                                        <tr>
                                                                                            <td style="width: 23%">Public
                                                                                            </td>
                                                                                            <td style="width: 10%">
                                                                                                <asp:Label runat="server" ID="lblWater_Public" />
                                                                                            </td>
                                                                                            <td style="width: 23%">Private
                                                                                            </td>
                                                                                            <td style="width: 10%">
                                                                                                <asp:Label runat="server" ID="lblWater_Private" />
                                                                                            </td>
                                                                                            <td style="width: 24%">Boosted by Fire Pump
                                                                                            </td>
                                                                                            <td style="width: 10%">
                                                                                                <asp:Label runat="server" ID="lblWater_Boosted" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                        <tr>
                                                                                            <td class="Spacer" style="height: 10px;"></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">
                                                                                                <asp:Label ID="Label51" runat="server" Text="Design Densities for each area?" Width="146px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">
                                                                                                <asp:Label ID="Label52" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblDesign_Densities_for_each_area" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px">
                                                                                                <asp:Label ID="Label53" runat="server" Text="Hydrants located within 500 feet of buildings" Width="130px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">
                                                                                                <asp:Label ID="Label54" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblHydrants_within_500_ft" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 10px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <i>Supervisor Alarms Provided</i>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 10px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <table cellpadding="3" cellspacing="0" border="0" width="100%">
                                                                                        <tr>
                                                                                            <td style="width: 23%">UL Central Station
                                                                                            </td>
                                                                                            <td style="width: 10%">
                                                                                                <asp:Label runat="server" ID="lblAlarm_UL_Central_Station" />
                                                                                            </td>
                                                                                            <td style="width: 23%">Constant Attended
                                                                                            </td>
                                                                                            <td style="width: 10%">
                                                                                                <asp:Label runat="server" ID="lblAlarm_Constant_Attended" />
                                                                                            </td>
                                                                                            <td style="width: 24%">Sprinkler Valve Tamper
                                                                                            </td>
                                                                                            <td style="width: 10%">
                                                                                                <asp:Label runat="server" ID="lblAlarm_Sprinkler_Valve_Tamper" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>Non UL-Central Station
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label runat="server" ID="lblAlarm_Non_UL_Central_Station" />
                                                                                            </td>
                                                                                            <td>Local
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label runat="server" ID="lblAlarm_Local" />
                                                                                            </td>
                                                                                            <td>Smoke Detectors
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label runat="server" ID="lblAlarm_Smoke_Detectors" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>Proprietary
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label runat="server" ID="lblAlarm_Proprietary" />
                                                                                            </td>
                                                                                            <td>Sprinkler Waterflow
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label runat="server" ID="lblAlarm_Sprinkler_Waterflow" />
                                                                                            </td>
                                                                                            <td>Dry Pipe Air
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label runat="server" ID="lblAlarm_Dry_Pipe_Air" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>Remote
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label runat="server" ID="lblAlarm_Remote" />
                                                                                            </td>
                                                                                            <td>Fire Pump Alarms
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label runat="server" ID="lblAlarm_Fire_Pump_Alarms" />
                                                                                            </td>
                                                                                            <td>&nbsp;
                                                                                            </td>
                                                                                            <td>&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>Auto Fire Alarms
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label runat="server" ID="lblAlarm_Auto_Fire_Alarms"></asp:Label>
                                                                                            </td>
                                                                                            <td>&nbsp;</td>
                                                                                            <td>&nbsp;</td>
                                                                                            <td>&nbsp;</td>
                                                                                            <td>&nbsp;</td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <%--<tr>
                                                                                <td align="left" valign="top" style="width: 18%">Auto Fire Alarms
                                                                                </td>
                                                                                <td align="center" valign="top" style="width: 4%">:
                                                                                </td>
                                                                                <td align="left" colspan="4" style="width: 78%">
                                                                                    <asp:Label runat="server" ID="lblAlarm_Auto_Fire_Alarms"></asp:Label>
                                                                                </td>
                                                                            </tr>--%>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <b>Fire Inspection Company</b>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">
                                                                                                <asp:Label ID="Label1" runat="server" Text="Contact Name" Width="146px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">
                                                                                                <asp:Label ID="Label25" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblFireContactName" Width="170px" />
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px">
                                                                                                <asp:Label ID="Label2" runat="server" Text="Vendor Name" Width="130px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">
                                                                                                <asp:Label ID="Label26" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblFireVendorName" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">
                                                                                                <asp:Label ID="Label3" runat="server" Text="Contract Expiration Date" Width="146px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">
                                                                                                <asp:Label ID="Label27" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblFireContactExpiration" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px">
                                                                                                <asp:Label ID="Label4" runat="server" Text="Telephone Number" Width="130px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">
                                                                                                <asp:Label ID="Label28" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblFireTelephone" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">
                                                                                                <asp:Label ID="Label5" runat="server" Text="Address 1" Width="146px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">
                                                                                                <asp:Label ID="Label29" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblFireAddress1" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px">
                                                                                                <asp:Label ID="Label6" runat="server" Text="Alternate Number" Width="130px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">
                                                                                                <asp:Label ID="Label30" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblFireAlternateNumber" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">
                                                                                                <asp:Label ID="Label21" runat="server" Text="Address 2" Width="146px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">
                                                                                                <asp:Label ID="Label31" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblFireAddress2" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px">
                                                                                                <asp:Label ID="Label22" runat="server" Text="City" Width="130px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">
                                                                                                <asp:Label ID="Label32" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblFireCity" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">
                                                                                                <asp:Label ID="Label23" runat="server" Text="State" Width="146px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">
                                                                                                <asp:Label ID="Label33" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblFireState" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px">
                                                                                                <asp:Label ID="Label24" runat="server" Text="Email" Width="130px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">
                                                                                                <asp:Label ID="Label34" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblFireEmail" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%" valign="top">
                                                                                                <asp:Label ID="Label7" runat="server" Text="Zip" Width="146px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%" valign="top">
                                                                                                <asp:Label ID="Label35" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%" valign="top">
                                                                                                <asp:Label runat="server" ID="lblFireZipCode"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px">
                                                                                                <asp:Label ID="Label8" runat="server" Text="Comments" Width="130px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%" valign="top">
                                                                                                <asp:Label ID="Label36" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%" valign="top">
                                                                                                <asp:Label runat="server" ID="lblFireComments" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top" style="width: 18%">
                                                                                    <asp:Label ID="Label9" runat="server" Text="Security Cameras?" Width="140px"></asp:Label>
                                                                                </td>
                                                                                <td align="center" valign="top" style="width: 4%">
                                                                                    <asp:Label ID="Label11" runat="server" Text=":" Width="30px"></asp:Label>
                                                                                </td>
                                                                                <td align="left" colspan="4" style="width: 78%">
                                                                                    <asp:Label runat="server" ID="lblAlarm_Security_Cameras" Width="170px"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr runat="server" id="trSecurityCameras" style="display: none;">
                                                                                <td align="left" colspan="6" style="width: 100%">
                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">
                                                                                                <asp:Label ID="Label19" runat="server" Text="System" Width="146px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">
                                                                                                <asp:Label ID="Label45" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblsecuCam_System" Width="170px" />
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px">
                                                                                                <asp:Label ID="Label20" runat="server" Text="Contact Name" Width="130px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">
                                                                                                <asp:Label ID="Label46" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblSecuCam_Contact_Name" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">Vendor Name
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblSecuCam_Vendor_Name" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px">
                                                                                                <asp:Label ID="Label55" runat="server" Text="Contract Expiration Date" Width="130px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblSecuCam_Contact_Expiration_Date" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">Address 1
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblSecuCam_Address_1" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px">Telephone Number
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblSecuCam_Telephone_Number" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">Address 2
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblSecuCam_Address_2" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px">Alternate Number
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblSecuCam_Alternate_Number" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">City
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblSecuCam_City" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px">Email
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblSecuCam_Email" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%" valign="top">State
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%" valign="top">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%" valign="top">
                                                                                                <asp:Label runat="server" ID="lblSecuCam_State"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px">valign="top">Comments
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%" valign="top">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%" valign="top">
                                                                                                <asp:Label runat="server" ID="lblSecuCam_Comments" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">Zip
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblSecuCam_Zip" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px">&nbsp;
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">&nbsp;
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top" style="width: 18%">
                                                                                    <asp:Label ID="Label10" runat="server" Text="Security Guard Services" Width="140px"></asp:Label>
                                                                                </td>
                                                                                <td align="center" valign="top" style="width: 4%">
                                                                                    <asp:Label ID="Label12" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                </td>
                                                                                <td align="left" colspan="4" style="width: 78%">
                                                                                    <asp:Label runat="server" ID="lblGuard_System" Width="170px"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr runat="server" id="trGuardSystem" style="display: none;">
                                                                                <td align="left" colspan="6">
                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">
                                                                                                <asp:Label ID="Label37" runat="server" Text="System" Width="146px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">
                                                                                                <asp:Label ID="Label38" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblGuard_System_Name" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px">
                                                                                                <asp:Label ID="Label40" runat="server" Text="Contact Name" Width="130px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">
                                                                                                <asp:Label ID="Label39" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblGuard_Contact_Name" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">Vendor Name
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblGuard_Vendor_Name" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px">Contract Expiration Date
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblGuard_Contact_Expiration_Date" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">Address 1
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblGuard_Address_1" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px">Telephone Number
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblGuard_Telephone_Number" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">Address 2
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblGuard_Address_2" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px">Alternate Number
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblGuard_Alternate_Number" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">City
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblGuard_City" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px">Email
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblGuard_Email" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%" valign="top">State
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%" valign="top">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%" valign="top">
                                                                                                <asp:Label runat="server" ID="lblGuard_State"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px">Comments
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%" valign="top">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%" valign="top">
                                                                                                <asp:Label runat="server" ID="lblGuard_Comments" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">Zip
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblGuard_Zip" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px">&nbsp;
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">&nbsp;
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top" style="width: 18%">
                                                                                    <asp:Label ID="Label16" runat="server" Text="Intrusion Alarms" Width="140px"></asp:Label>
                                                                                </td>
                                                                                <td align="center" valign="top" style="width: 4%">
                                                                                    <asp:Label ID="Label13" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                </td>
                                                                                <td align="left" colspan="4" style="width: 78%">
                                                                                    <asp:Label runat="server" ID="lblIntru_System"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr runat="server" id="trIntrusionAlarms" style="display: none;">
                                                                                <td align="left" colspan="6">
                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">
                                                                                                <asp:Label ID="Label41" runat="server" Text="System" Width="146px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">
                                                                                                <asp:Label ID="Label42" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblIntru_System_Name" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px">
                                                                                                <asp:Label ID="Label43" runat="server" Text="Contact Name" Width="130px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">
                                                                                                <asp:Label ID="Label44" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblIntru_Contact_Name" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">Vendor Name
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblIntru_Vendor_Name" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px">Alarm type
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblIntru_Contact_Alarm_Type">
                                                                                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                                                <asp:ListItem Text="Beam" Value="Beam"></asp:ListItem>
                                                                                                <asp:ListItem Text="Motion" Value="Motion"></asp:ListItem>
                                                                                                <asp:ListItem Text="Ultrasound" Value="Ultrasound"></asp:ListItem>
                                                                                                </asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">Address 1
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblIntru_Address_1" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px">Contract Expiration Date
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblIntru_Contact_Expiration_Date" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">Address 2
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblIntru_Address_2" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px">Telephone Number
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblIntru_Telephone_Number" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">City
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblIntru_City" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px">Alternate Number
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblIntru_Alternate_Number" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">State
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblIntru_State"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px">Email
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblIntru_Email" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%" valign="top">Zip
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%" valign="top">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%" valign="top">
                                                                                                <asp:Label runat="server" ID="lblIntru_Zip" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px" valign="top">Comments
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%" valign="top">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%" valign="top">
                                                                                                <asp:Label runat="server" ID="lblIntru_Comments" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top" style="width: 18%">
                                                                                    <asp:Label ID="Label17" runat="server" Text="Fence" Width="140px"></asp:Label>
                                                                                </td>
                                                                                <td align="center" valign="top" style="width: 4%">
                                                                                    <asp:Label ID="Label14" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                </td>
                                                                                <td align="left" colspan="4" style="width: 78%">
                                                                                    <asp:Label runat="server" ID="lblFence" Width="170px"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr runat="server" id="trFence" style="display: none;">
                                                                                <td align="left">&nbsp;
                                                                                </td>
                                                                                <td align="center">&nbsp;
                                                                                </td>
                                                                                <td align="left" colspan="4">
                                                                                    <table cellpadding="3" cellspacing="0" border="0" width="100%">
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">Razor Wire
                                                                                            </td>
                                                                                            <td align="left" style="width: 4%">&nbsp;
                                                                                            </td>
                                                                                            <td align="left" style="width: 78%" colspan="4">
                                                                                                <asp:Label runat="server" ID="lblRazor_Wire" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">Electrified
                                                                                            </td>
                                                                                            <td align="left" style="width: 4%">&nbsp;
                                                                                            </td>
                                                                                            <td align="left" style="width: 78%" colspan="4">
                                                                                                <asp:Label runat="server" ID="lblFence_Electrified" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top" style="width: 18%">
                                                                                    <asp:Label ID="Label18" runat="server" Text="Generator" Width="140px"></asp:Label>
                                                                                </td>
                                                                                <td align="center" valign="top" style="width: 4%">
                                                                                    <asp:Label ID="Label15" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                </td>
                                                                                <td align="left" colspan="4" style="width: 78%">
                                                                                    <asp:Label runat="server" ID="lblGenerator" Width="170px"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr runat="server" id="trGenerator" style="display: none;">
                                                                                <td align="left" colspan="6">
                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">
                                                                                                <asp:Label ID="Label47" runat="server" Text="Make" Width="146px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">
                                                                                                <asp:Label ID="Label48" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblGenerator_Make" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px">
                                                                                                <asp:Label ID="Label49" runat="server" Text="Model" Width="130px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">
                                                                                                <asp:Label ID="Label50" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblGenerator_Model" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">Size
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblGenerator_Size" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%; padding-left: 9px">&nbsp;
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">&nbsp;
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 10px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <i>Public Fire Department</i>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 10px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">Type
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label runat="Server" ID="lblFireDeptType"></asp:Label>
                                                                                </td>
                                                                                <td align="left" valign="top">Distance
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label runat="server" ID="lblDistance"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 8px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <b>Service Capacity</b>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 8px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">Number of Bays
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label ID="lblNumberOfBays" runat="server" />
                                                                                </td>
                                                                                <td align="left" valign="top">Number of Lifts
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label ID="lblNumberOfLifts" runat="server" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">Number of Prep Areas
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label ID="lblNumberOfPrepAreas" runat="server" />
                                                                                </td>
                                                                                <td align="left" valign="top">Number of Car Wash Stations
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label ID="lblNumberOfCarWashStations" runat="server" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">Number of Paint Booths
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label runat="server" ID="lblNumber_of_Paint_Booths" Width="170px"></asp:Label>
                                                                                </td>
                                                                                <td colspan="3"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 8px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <b>Improvements</b>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 8px;"></td>
                                                                            </tr>

                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <b>Exposure</b>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 8px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">Tier 1 County
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" colspan="4">
                                                                                    <asp:Label runat="server" ID="lblTier_1_County"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">Earthquake Zone/Fault Line
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" colspan="4">
                                                                                    <asp:Label runat="server" ID="lblEarthquake_Zone_Fault_Line"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">Neighboring Buildings within 100 ft.
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label runat="server" ID="lblNeighboring_Buildings_within_100_ft"></asp:Label>
                                                                                </td>
                                                                                <td colspan="3">
                                                                                    <table cellpadding="0" cellspacing="0" width="100%" id="tblNeighboringOccupancy"
                                                                                        style="display: none;" runat="server">
                                                                                        <tr>
                                                                                            <td align="left" valign="top" width="35%">Occupancy
                                                                                            </td>
                                                                                            <td align="center" valign="top" width="10%">:
                                                                                            </td>
                                                                                            <td align="left" valign="top">
                                                                                                <asp:Label runat="server" ID="lblNeighbor_Occupancy" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">Distance from body of water<br />
                                                                                    (creek, river, ocean)
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label runat="server" ID="lblDistance_from_body_of_water">                                                
                                                                                    </asp:Label>
                                                                                </td>
                                                                                <td align="left" valign="top">&nbsp;
                                                                                </td>
                                                                                <td align="center" valign="top">&nbsp;
                                                                                </td>
                                                                                <td align="left" valign="top">&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">Prior Flood History
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label runat="server" ID="lblPrior_Flood_History"></asp:Label>
                                                                                </td>
                                                                                <td align="left" valign="top">&nbsp;
                                                                                </td>
                                                                                <td align="center" valign="top">&nbsp;
                                                                                </td>
                                                                                <td align="left" valign="top">&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr runat="server" id="trFloodHistory" style="display: none;">
                                                                                <td align="left" valign="top">Describe
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" colspan="4" valign="top">
                                                                                    <uc:ctrlMultiLineTextBox ControlType="Label" ID="lblFlood_History_Descr" runat="server" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">Lowest finish floor elevation<br />
                                                                                    (above sea level)
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label runat="server" ID="lblLowest_finish_floor_elevation" Width="170px"></asp:Label>
                                                                                </td>
                                                                                <td align="left" valign="top">&nbsp;
                                                                                </td>
                                                                                <td align="center" valign="top">&nbsp;
                                                                                </td>
                                                                                <td align="left" valign="top">&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">Property Damage Losses in the Past 5 years
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" valign="top">
                                                                                    <asp:Label runat="server" ID="lblProperty_Damage_Losses_in_the_Past_5_years"></asp:Label>
                                                                                </td>
                                                                                <td align="left" valign="top">&nbsp;
                                                                                </td>
                                                                                <td align="center" valign="top">&nbsp;
                                                                                </td>
                                                                                <td align="left" valign="top">&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr runat="server" id="trPropertyDamageLoss" style="display: none;">
                                                                                <td align="left" valign="top">Describe
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" colspan="4" valign="top">
                                                                                    <uc:ctrlMultiLineTextBox ControlType="Label" ID="lblProperty_Loss_Descr" runat="server" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">Flood Zone
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" colspan="4">
                                                                                    <asp:Label runat="server" ID="lblFlood_Zone"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">National Flood Policy
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td align="left" colspan="4">
                                                                                    <asp:Label runat="server" ID="lblNational_Flood_Policy"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr runat="server" id="trNational_Flood_Policy" style="display: none;">
                                                                                <td align="left" colspan="6">
                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">
                                                                                                <asp:Label ID="Label56" runat="server" Text="Carrier" Width="146px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">
                                                                                                <asp:Label ID="Label57" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblFlood_Carrier" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%">
                                                                                                <asp:Label ID="Label58" runat="server" Text="Policy Inception Date" Width="146px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">
                                                                                                <asp:Label ID="Label59" runat="server" Text=":" Width="31px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblFlood_Policy_Inception_Date" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">Policy Number
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblFlood_Policy_Number" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%">Policy Expiration Date
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblFlood_Policy_Expiration_Date" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">Premium
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblFlood_Premium" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%">Deductible
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblFlood_Deductible" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="6">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width: 18%">Policy Limits - Contents
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblFlood_Polciy_Limits_Contents" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                            <td align="left" style="width: 18%">Policy Limits - Building
                                                                                            </td>
                                                                                            <td align="center" style="width: 4%">:
                                                                                            </td>
                                                                                            <td align="left" style="width: 28%">
                                                                                                <asp:Label runat="server" ID="lblFlood_Policy_Limits_Building" Width="170px"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 10px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">
                                                                                    <b>GGKL Renewal Information Grid</b>
                                                                                </td>
                                                                                <td align="center" valign="top">:
                                                                                </td>
                                                                                <td colspan="4" valign="top">
                                                                                    <asp:GridView ID="gvGGKL" runat="server" Width="100%" OnRowCommand="gvGGKL_RowCommand"
                                                                                        EmptyDataText="No Records Found !">
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="Date">
                                                                                                <ItemStyle Width="50%" HorizontalAlign="Left" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:LinkButton ID="lnkDate" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Date")) %>'
                                                                                                        CommandArgument='<%#Eval("PK_Building_GGKL") %>' CommandName="ShowDetails" />
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Total">
                                                                                                <ItemStyle Width="50%" HorizontalAlign="Left" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:LinkButton ID="lnkTotal" runat="server" Text='<%# string.Format("{0:N0}",Eval("Total")) %>'
                                                                                                        CommandArgument='<%#Eval("PK_Building_GGKL") %>' CommandName="ShowDetails" />
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 10px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <b>Other Building Attachments</b><br />
                                                                                    <i>Click to view detail</i>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 10px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="6">
                                                                                    <asp:GridView ID="gvBuildingAttachmentDetails" runat="server" Width="100%" OnRowDataBound="gvBuildingAttachmentDetails_RowDataBound"
                                                                                        EmptyDataText="Currently there is no attachment<br/>Please add one or more attachment">
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="File Name">
                                                                                                <ItemStyle Width="50%" />
                                                                                                <ItemTemplate>
                                                                                                    <a id="lnkBuildingAttachFile" runat="server" href="#">
                                                                                                        <%# Eval("FileName").ToString().Substring(12, (Eval("FileName").ToString().Length-1) - 11)%>
                                                                                                    </a>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Type">
                                                                                                <ItemStyle Width="50%" />
                                                                                                <ItemTemplate>
                                                                                                    <%# Eval("Type") %>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="Spacer" style="height: 10px;"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">Other Building Comments
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="6">
                                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="lblComments" ControlType="Label" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="6" width="100%" align="center">
                                                                                    <table>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:Button ID="btnViewAuditBuilding" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp('Building');"
                                                                                                    Visible="false" />
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Button ID="btnViewOwnerShip" runat="server" Text="Ownership Details" Visible="false"
                                                                                                    OnClientClick="javascript:ShowPanel(3);return false;" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlOwnershipDetails" runat="server" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Ownership Details
                                                </div>
                                                <asp:UpdatePanel runat="server" ID="updOwnerShip">
                                                    <ContentTemplate>
                                                        <input type="hidden" id="hdnBuildingOwnershipID" runat="server" />
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <%--<tr runat="server" id="trOwned" style="display: none;">
                                                                <td align="left" colspan="6">
                                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                        <tr>
                                                                            <td align="left" width="18%" valign="top">
                                                                                Mortgagee Name
                                                                            </td>
                                                                            <td align="center" width="4%" valign="top">
                                                                                :
                                                                            </td>
                                                                            <td align="left" width="28%" valign="top">
                                                                                <asp:Label runat="server" ID="lblOwner_Name" Width="170px"></asp:Label>
                                                                            </td>
                                                                            <td align="left" width="18%" valign="top">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td align="center" width="4%" valign="top">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td align="left" width="28%" valign="top">
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" valign="top">
                                                                                Address 1
                                                                            </td>
                                                                            <td align="center" valign="top">
                                                                                :
                                                                            </td>
                                                                            <td align="left" valign="top">
                                                                                <asp:Label runat="server" ID="lblOwner_Address_1" Width="170px"></asp:Label>
                                                                            </td>
                                                                            <td align="left" valign="top">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td align="center" valign="top">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td align="left" valign="top">
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" valign="top">
                                                                                Address 2
                                                                            </td>
                                                                            <td align="center" valign="top">
                                                                                :
                                                                            </td>
                                                                            <td align="left" valign="top">
                                                                                <asp:Label runat="server" ID="lblOwner_Address_2" Width="170px"></asp:Label>
                                                                            </td>
                                                                            <td align="left" valign="top">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td align="center" valign="top">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td align="left" valign="top">
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" valign="top">
                                                                                City
                                                                            </td>
                                                                            <td align="center" valign="top">
                                                                                :
                                                                            </td>
                                                                            <td align="left" valign="top">
                                                                                <asp:Label runat="server" ID="lblOwner_City" Width="170px"></asp:Label>
                                                                            </td>
                                                                            <td align="left" valign="top">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td align="center" valign="top">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td align="left" valign="top">
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" valign="top">
                                                                                State
                                                                            </td>
                                                                            <td align="center" valign="top">
                                                                                :
                                                                            </td>
                                                                            <td align="left" valign="top">
                                                                                <asp:Label runat="server" ID="lblOwner_State"></asp:Label>
                                                                            </td>
                                                                            <td align="left" valign="top">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td align="center" valign="top">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td align="left" valign="top">
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" valign="top">
                                                                                Zip
                                                                            </td>
                                                                            <td align="center" valign="top">
                                                                                :
                                                                            </td>
                                                                            <td align="left" valign="top">
                                                                                <asp:Label runat="server" ID="lblOwner_Zip" Width="170px"></asp:Label>
                                                                            </td>
                                                                            <td align="left" valign="top">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td align="center" valign="top">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td align="left" valign="top">
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>--%>
                                                            <tr id="trLeased" runat="server">
                                                                <td align="left" colspan="6">
                                                                    <table cellpadding="3" cellspacing="0" width="100%">
                                                                        <tr>
                                                                            <td width="50%" align="left" valign="top">
                                                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                    <tr>
                                                                                        <td align="left" width="38%" valign="top">Landlord Name
                                                                                        </td>
                                                                                        <td align="center" width="6%" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" width="56%" valign="top">
                                                                                            <asp:Label runat="server" ID="lblLandlord_Name" Width="170px"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">Address 1
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label runat="server" ID="lblLandlord_Address_1" Width="170px"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">Address 2
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label runat="server" ID="lblLandlord_Address_2" Width="170px"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">City
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:Label runat="server" ID="lblLandlord_City" Width="170px"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">State
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label runat="server" ID="lblLandlord_State"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">Zip
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label runat="server" ID="lblLandlord_Zip" Width="170px"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td align="left" valign="top">
                                                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                    <%--<tr id="trLegalEntiry" runat="server" style="display: block">--%>
                                                                                    <tr>
                                                                                        <td align="left" width="38%" valign="top">Landlord Legal Entity
                                                                                        </td>
                                                                                        <td align="center" width="6%" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" width="56%" valign="top">
                                                                                            <asp:Label runat="server" ID="lblLandlordLegalEntity"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" width="38%" valign="top">Lease ID
                                                                                        </td>
                                                                                        <td align="center" width="6%" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" width="56%" valign="top">
                                                                                            <asp:Label runat="server" ID="lblLease_ID" Width="170px"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">Commencement Date
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label runat="server" ID="lblCommencement_Date" Width="170px"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">Expiration Date
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label runat="server" ID="lblExpiration_Date" Width="170px"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trgvSubLease" runat="server" style="display: none;">
                                                                            <td valign="top" colspan="2">
                                                                                <i><b>Sub-Lease<br />
                                                                                    Click to view detail</b></i>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td id="gridSubLease" runat="server" colspan="2" style="display: none;">
                                                                                <asp:GridView ID="gvSubLease" runat="server" EmptyDataText="No Additional Sub Lease Record Exists"
                                                                                    OnRowCommand="gvSubLease_OnRowCommand" Width="100%">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="">
                                                                                            <ItemStyle Width="5%" />
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton ID="lnkViewSubLeaseDetails" CausesValidation="false" runat="server"
                                                                                                    Text='<%# Container.DataItemIndex + 1 %>' CommandName="ViewSubLeaseDetails" CommandArgument='<%#Eval("PK_Building_Ownership_Sublease")%>'></asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Sub-Lease Name">
                                                                                            <ItemStyle Width="20%" />
                                                                                            <ItemTemplate>
                                                                                                <%# Eval("Sublease_Name") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Sub-Lease LandLord">
                                                                                            <ItemStyle Width="20%" />
                                                                                            <ItemTemplate>
                                                                                                <%# Eval("SubLease_Landlord")%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Sub-Lease First Name">
                                                                                            <ItemStyle Width="20%" />
                                                                                            <ItemTemplate>
                                                                                                <%# Eval("Sublease_FirstName")%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Sub-Lease Last Name">
                                                                                            <ItemStyle Width="20%" />
                                                                                            <ItemTemplate>
                                                                                                <%# Eval("Sublease_LastName")%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Sub-Lease Phone">
                                                                                            <ItemStyle Width="20%" />
                                                                                            <ItemTemplate>
                                                                                                <%# Eval("Sublease_Phone")%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trSubLease" runat="server" style="display: none">
                                                                            <td align="left" valign="top">
                                                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                    <tr>
                                                                                        <td align="left" width="38%" valign="top">Sub-Lease Name
                                                                                        </td>
                                                                                        <td align="center" width="6%" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" width="56%" valign="top">
                                                                                            <asp:Label runat="server" ID="lblSubLease_Name" Width="170px"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">Address 1
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label runat="server" ID="lblSublease_Address_1" Width="170px" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">Address 2
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label runat="server" ID="lblSublease_Address_2" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">City
                                                                                        </td>
                                                                                        <td align="center">:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:Label runat="server" ID="lblSublease_City" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">State
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label runat="server" ID="lblSublease_State" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">Zip
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label runat="server" ID="lblSublease_Zip" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>&nbsp;
                                                                                        </td>
                                                                                        <td>&nbsp;
                                                                                        </td>
                                                                                        <td>&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>&nbsp;
                                                                                        </td>
                                                                                        <td>&nbsp;
                                                                                        </td>
                                                                                        <td>&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td valign="top">
                                                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                    <tr>
                                                                                        <td align="left" width="38%" valign="top">Sub-Lease Landlord
                                                                                        </td>
                                                                                        <td align="center" width="6%" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" width="56%" valign="top">
                                                                                            <asp:Label runat="server" ID="lblSublandlord" Width="170px"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" width="38%" valign="top">Sub-Lease First Name
                                                                                        </td>
                                                                                        <td align="center" width="6%" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" width="56%" valign="top">
                                                                                            <asp:Label runat="server" ID="lblSubLeaseFirstName" Width="170px"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" width="38%" valign="top">Sub-Lease Last Name
                                                                                        </td>
                                                                                        <td align="center" width="6%" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" width="56%" valign="top">
                                                                                            <asp:Label runat="server" ID="lblSubLeaseLastName" Width="170px"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" width="38%" valign="top">Sub-Lease Title
                                                                                        </td>
                                                                                        <td align="center" width="6%" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" width="56%" valign="top">
                                                                                            <asp:Label runat="server" ID="lblSubLeaseTitle" Width="170px"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" width="38%" valign="top">Sub-Lease Phone
                                                                                        </td>
                                                                                        <td align="center" width="6%" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" width="56%" valign="top">
                                                                                            <asp:Label runat="server" ID="lblSubLeasePhone" Width="170px"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" width="38%" valign="top">Sub-Lease Fax
                                                                                        </td>
                                                                                        <td align="center" width="6%" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" width="56%" valign="top">
                                                                                            <asp:Label runat="server" ID="lblSubLeaseFax" Width="170px"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" width="38%" valign="top">Sub-Lease Email
                                                                                        </td>
                                                                                        <td align="center" width="6%" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" width="56%" valign="top">
                                                                                            <asp:Label runat="server" ID="lblSubLeaseEmail" Width="170px"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trAuditTrail" runat="server" style="display: none;">
                                                                            <td valign="top" colspan="2">
                                                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                    <tr>
                                                                                        <td width="38%" align="right" valign="top">
                                                                                            <input type="hidden" id="hdnSubLeaseID" runat="server" value="View Audit Trail" style="display: none;" />
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Button ID="btnLeaseAuditTrail" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp('Sub_Lease');" />&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                        <tr style="height: 2px">
                                                                            <td align="left" width="18%" valign="top"></td>
                                                                            <td align="center" width="4%" valign="top"></td>
                                                                            <td align="left" width="28%" valign="top"></td>
                                                                            <td align="left" width="18%" valign="top"></td>
                                                                            <td align="center" width="4%" valign="top"></td>
                                                                            <td align="left" width="28%" valign="top"></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="6" width="100%">
                                                                                <i><b>Named Additional Insured<br />
                                                                                    Click to view detail</b></i>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="6" align="left">
                                                                                <asp:GridView ID="gvAdditionalInsureds" runat="server" OnRowCommand="gvAdditionalInsureds_RowCommand"
                                                                                    EmptyDataText="No Other Additional Insured Records Exists" Width="100%">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="">
                                                                                            <ItemStyle Width="5%" />
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton ID="lnkViewDetails" runat="server" Text='<%# Container.DataItemIndex + 1 %>'
                                                                                                    CommandName="ViewDetails" CommandArgument='<%#Eval("PK_Building_Additional_Insureds_Payees_ID")%>'></asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Name">
                                                                                            <ItemStyle Width="30%" />
                                                                                            <ItemTemplate>
                                                                                                <%# Eval("Named") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Address">
                                                                                            <ItemStyle Width="35%" />
                                                                                            <ItemTemplate>
                                                                                                <%# Eval("Address_1")%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="City">
                                                                                            <ItemStyle Width="30%" />
                                                                                            <ItemTemplate>
                                                                                                <%# Eval("City")%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </td>
                                                                        </tr>
                                                                        <tr runat="server" id="trAdditionalInsured" style="display: none;">
                                                                            <td align="left" colspan="6">
                                                                                <input type="hidden" id="hdnAdditionalInsured" runat="server" />
                                                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                    <tr>
                                                                                        <td align="left" width="18%" valign="top">Named Insured
                                                                                        </td>
                                                                                        <td align="center" width="4%" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" width="28%" valign="top">
                                                                                            <asp:Label runat="server" ID="lblAdditional_Insureds_Named" Width="170px"></asp:Label>
                                                                                        </td>
                                                                                        <td align="left" width="18%" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="center" width="4%" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="left" width="28%" valign="top">&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">Address 1
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label runat="server" ID="lblAdditional_Insureds_Address_1" Width="170px"></asp:Label>
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="center" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">Address 2
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label runat="server" ID="lblAdditional_Insureds_Address_2" Width="170px"></asp:Label>
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="center" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">City
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label runat="server" ID="lblAdditional_Insureds_City" Width="170px"></asp:Label>
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="center" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">State
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label runat="server" ID="lblAdditional_Insureds_State"></asp:Label>
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="center" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">Zip
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label runat="server" ID="lblAdditional_Insureds_Zip" Width="170px"></asp:Label>
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="center" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="6" width="100%" align="center">
                                                                                            <asp:Button ID="btnViewAuditAdditionalInsured" runat="server" Text="View Audit Trail"
                                                                                                OnClientClick="javascript:return AuditPopUp('Additional_Insured');" Style="display: none;" />&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="6" width="100%">
                                                                                <i><b>Named Loss Payees<br />
                                                                                    Click to view detail</b></i>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="6" align="left">
                                                                                <asp:GridView ID="gvPayee" runat="server" OnRowCommand="gvPayee_RowCommand" EmptyDataText="No Other Payee Records Exists"
                                                                                    Width="100%">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="">
                                                                                            <ItemStyle Width="5%" />
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton ID="lnkViewDetails" runat="server" Text='<%# Container.DataItemIndex + 1 %>'
                                                                                                    CommandName="ViewDetails" CommandArgument='<%#Eval("PK_Building_Additional_Insureds_Payees_ID")%>'></asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Name">
                                                                                            <ItemStyle Width="30%" />
                                                                                            <ItemTemplate>
                                                                                                <%# Eval("Named") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Address">
                                                                                            <ItemStyle Width="35%" />
                                                                                            <ItemTemplate>
                                                                                                <%# Eval("Address_1")%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="City">
                                                                                            <ItemStyle Width="30%" />
                                                                                            <ItemTemplate>
                                                                                                <%# Eval("City")%>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trNamedLossPayees" runat="server" style="display: none;">
                                                                            <td align="left" colspan="6">
                                                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                                    <tr>
                                                                                        <td align="left" width="18%" valign="top">Named Insured
                                                                                        </td>
                                                                                        <td align="center" width="4%" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" width="28%" valign="top">
                                                                                            <asp:Label runat="server" ID="lblLoss_Payees_Named" Width="170px"></asp:Label>
                                                                                        </td>
                                                                                        <td align="left" width="18%" valign="top">Type
                                                                                        </td>
                                                                                        <td align="center" width="4%" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" width="28%" valign="top">
                                                                                            <asp:Label runat="server" ID="lblLoss_Payees_Type"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">Address 1
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label runat="server" ID="lblLoss_Payees_Address_1" Width="170px"></asp:Label>
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="center" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">Address 2
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label runat="server" ID="lblLoss_Payees_Address_2" Width="170px"></asp:Label>
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="center" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">City
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label runat="server" ID="lblLoss_Payees_City" Width="170px"></asp:Label>
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="center" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">State
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label runat="server" ID="lblLoss_Payees_State"></asp:Label>
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="center" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">Zip
                                                                                        </td>
                                                                                        <td align="center" valign="top">:
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label runat="server" ID="lblLoss_Payees_Zip" Width="170px"></asp:Label>
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="center" valign="top">&nbsp;
                                                                                        </td>
                                                                                        <td align="left" valign="top">&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="6" width="100%" align="center">
                                                                                            <input type="hidden" id="hdnLossPayeeID" runat="server" value="View Audit Trail"
                                                                                                style="display: none;" />
                                                                                            <asp:Button ID="btnViewAuditLossPayee" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp('Loss_Payee');"
                                                                                                Style="display: none;" />&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" valign="top">Special Wording for the Certificate of Insurance
                                                                            </td>
                                                                            <td align="center" valign="top">&nbsp;
                                                                            </td>
                                                                            <td align="left" valign="top">&nbsp;
                                                                            </td>
                                                                            <td align="left" valign="top">&nbsp;
                                                                            </td>
                                                                            <td align="center" valign="top">&nbsp;
                                                                            </td>
                                                                            <td align="left" valign="top">&nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" colspan="6">
                                                                                <uc:ctrlMultiLineTextBox runat="server" ID="lblCOI_Wording" ControlType="Label" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="6">
                                                                                <table cellpadding="3" cellspacing="0" width="100%">
                                                                                    <tr>
                                                                                        <td width="18%" align="left" valign="top">
                                                                                            <b>Insurance Requirements</b>
                                                                                        </td>
                                                                                        <td width="6%">&nbsp;
                                                                                        </td>
                                                                                        <td width="10%" align="left" valign="top">Sub-Tenant<br />
                                                                                            Responsible
                                                                                        </td>
                                                                                        <td width="22%" align="left" valign="top">View<br />
                                                                                            COI
                                                                                        </td>
                                                                                        <td width="10%" align="left" valign="top">Date
                                                                                        </td>
                                                                                        <td>&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">Workers Compensation
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label ID="lblREQWC" runat="server" Text="" />
                                                                                        </td>
                                                                                        <td align="center" valign="top">
                                                                                            <asp:Label ID="lblWCTenant" runat="server" />
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:LinkButton ID="lnkCOI_WC" runat="server" OnClientClick="return ViewCOI('WC');" />
                                                                                            <input type="hidden" id="hdnCOI_WC_URL" runat="server" />
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label ID="lblCOI_WC_Date" runat="server" />
                                                                                        </td>
                                                                                        <td valign="top">
                                                                                            <table cellpadding="3" cellspacing="0" width="100%" id="tblWCLimit" runat="server"
                                                                                                style="display: none;">
                                                                                                <tr>
                                                                                                    <td align="left" valign="top" width="30%">Required Limit
                                                                                                    </td>
                                                                                                    <td align="center" valign="top" width="15%">:
                                                                                                    </td>
                                                                                                    <td align="left" valign="top">
                                                                                                        <asp:Label ID="lblReqLim_WC" runat="server" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">Employers Liability
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label ID="lblREQEL" runat="server" />
                                                                                        </td>
                                                                                        <td align="center" valign="top">
                                                                                            <asp:Label ID="lblELTenant" runat="server" />
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:LinkButton ID="lnkCOI_EL" runat="server" OnClientClick="return ViewCOI('EL');" />
                                                                                            <input type="hidden" id="hdnCOI_EL_URL" runat="server" />
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label ID="lblCOI_EL_Date" runat="server" />
                                                                                        </td>
                                                                                        <td valign="top">
                                                                                            <table cellpadding="3" cellspacing="0" width="100%" id="tblELLimit" runat="server"
                                                                                                style="display: none;">
                                                                                                <tr>
                                                                                                    <td align="left" valign="top" width="30%">Required Limit
                                                                                                    </td>
                                                                                                    <td align="center" valign="top" width="15%">:
                                                                                                    </td>
                                                                                                    <td align="left" valign="top">
                                                                                                        <asp:Label ID="lblReqLim_EL" runat="server" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">General Liability
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label ID="lblREQGL" runat="server" />
                                                                                        </td>
                                                                                        <td align="center" valign="top">
                                                                                            <asp:Label ID="lblGLTenant" runat="server" />
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:LinkButton ID="lnkCOI_GL" runat="server" OnClientClick="return ViewCOI('GL');" />
                                                                                            <input type="hidden" id="hdnCOI_GL_URL" runat="server" />
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label ID="lblCOI_GL_Date" runat="server" />
                                                                                        </td>
                                                                                        <td valign="top">
                                                                                            <table cellpadding="3" cellspacing="0" width="100%" id="tblGLLimit" runat="server"
                                                                                                style="display: none;">
                                                                                                <tr>
                                                                                                    <td align="left" valign="top" width="30%">Required Limit
                                                                                                    </td>
                                                                                                    <td align="center" valign="top" width="15%">:
                                                                                                    </td>
                                                                                                    <td align="left" valign="top">
                                                                                                        <asp:Label ID="lblReqLim_GL" runat="server" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">Pollution
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label ID="lblREQPollution" runat="server" Text="" />
                                                                                        </td>
                                                                                        <td align="center" valign="top">
                                                                                            <asp:Label ID="lblPollutionTenant" runat="server" />
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:LinkButton ID="lnkCOI_Pollution" runat="server" OnClientClick="return ViewCOI('Pollution');" />
                                                                                            <input type="hidden" id="hdnCOI_Pollution_URL" runat="server" />
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label ID="lblCOI_Pollution_Date" runat="server" />
                                                                                        </td>
                                                                                        <td valign="top">
                                                                                            <table cellpadding="3" cellspacing="0" width="100%" id="tblPollutionLimit" runat="server"
                                                                                                style="display: none;">
                                                                                                <tr>
                                                                                                    <td align="left" valign="top" width="30%">Required Limit
                                                                                                    </td>
                                                                                                    <td align="center" valign="top" width="15%">:
                                                                                                    </td>
                                                                                                    <td align="left" valign="top">
                                                                                                        <asp:Label ID="lblReqLim_Pollution" runat="server" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">Property
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label ID="lblREQProperty" runat="server" />
                                                                                        </td>
                                                                                        <td align="center" valign="top">
                                                                                            <asp:Label ID="lblPropertyTenant" runat="server" />
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:LinkButton ID="lnkCOI_Property" runat="server" OnClientClick="return ViewCOI('Property');" />
                                                                                            <input type="hidden" id="hdnCOI_Property_URL" runat="server" />
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label ID="lblCOI_Property_Date" runat="server" />
                                                                                        </td>
                                                                                        <td valign="top">
                                                                                            <table cellpadding="3" cellspacing="0" width="100%" id="tblPropertyLimit" runat="server"
                                                                                                style="display: none;">
                                                                                                <tr>
                                                                                                    <td align="left" valign="top" width="30%">Required Limit
                                                                                                    </td>
                                                                                                    <td align="center" valign="top" width="15%">:
                                                                                                    </td>
                                                                                                    <td align="left" valign="top">
                                                                                                        <asp:Label ID="lblReqLim_Property" runat="server" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">Flood
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label ID="lblREQFlood" runat="server" />
                                                                                        </td>
                                                                                        <td align="center" valign="top">
                                                                                            <asp:Label ID="lblFloodTenant" runat="server" />
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:LinkButton ID="lnkCOI_Flood" runat="server" OnClientClick="return ViewCOI('Flood');" />
                                                                                            <input type="hidden" id="hdnCOI_Flood_URL" runat="server" />
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label ID="lblCOI_Flood_Date" runat="server" />
                                                                                        </td>
                                                                                        <td valign="top">
                                                                                            <table cellpadding="3" cellspacing="0" width="100%" id="tblFloodLimit" runat="server"
                                                                                                style="display: none;">
                                                                                                <tr>
                                                                                                    <td align="left" valign="top" width="30%">Required Limit
                                                                                                    </td>
                                                                                                    <td align="center" valign="top" width="15%">:
                                                                                                    </td>
                                                                                                    <td align="left" valign="top">
                                                                                                        <asp:Label ID="lblReqLim_Flood" runat="server" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">EQ
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label ID="lblREQEQ" runat="server" />
                                                                                        </td>
                                                                                        <td align="center" valign="top">
                                                                                            <asp:Label ID="lblEQTenant" runat="server" />
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:LinkButton ID="lnkCOI_EQ" runat="server" OnClientClick="return ViewCOI('EQ');" />
                                                                                            <input type="hidden" id="hdnCOI_EQ_URL" runat="server" />
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label ID="lblCOI_EQ_Date" runat="server" />
                                                                                        </td>
                                                                                        <td valign="top">
                                                                                            <table cellpadding="3" cellspacing="0" width="100%" id="tblEQLimit" runat="server"
                                                                                                style="display: none;">
                                                                                                <tr>
                                                                                                    <td align="left" valign="top" width="30%">Required Limit
                                                                                                    </td>
                                                                                                    <td align="center" valign="top" width="15%">:
                                                                                                    </td>
                                                                                                    <td align="left" valign="top">
                                                                                                        <asp:Label ID="lblReqLim_EQ" runat="server" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" valign="top">Waiver of Subrogation
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label ID="lblREQWaiver" runat="server" />
                                                                                        </td>
                                                                                        <td align="center" valign="top">
                                                                                            <asp:Label ID="lblWaiverTenant" runat="server" />
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:LinkButton ID="lnkCOI_Waiver" runat="server" OnClientClick="return ViewCOI('Waiver');" />
                                                                                            <input type="hidden" id="hdnCOI_Waiver_URL" runat="server" />
                                                                                        </td>
                                                                                        <td align="left" valign="top">
                                                                                            <asp:Label ID="lblCOI_Waiver_Date" runat="server" />
                                                                                        </td>
                                                                                        <td valign="top">
                                                                                            <table cellpadding="3" cellspacing="0" width="100%" id="tblWaiverLimit" runat="server"
                                                                                                style="display: none;">
                                                                                                <tr>
                                                                                                    <td align="left" valign="top" width="30%">Required Limit
                                                                                                    </td>
                                                                                                    <td align="center" valign="top" width="15%">:
                                                                                                    </td>
                                                                                                    <td align="left" valign="top">
                                                                                                        <asp:Label ID="lblReqLim_Waiver" runat="server" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="6" width="100%">
                                                                                <i><b>Sub-Lease Attachments<br />
                                                                                    Click to view detail</b></i>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="6" width="100%">
                                                                                <asp:GridView ID="gvLeaseAttachmentDetails" runat="server" Width="100%" OnRowDataBound="gvLeaseAttachmentDetails_RowDataBound"
                                                                                    EmptyDataText="Currently there is no attachment<br/>Please add one or more attachment">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="File Name">
                                                                                            <ItemStyle Width="50%" />
                                                                                            <ItemTemplate>
                                                                                                <a id="lnkLeaseAttachFile" runat="server" href="#">
                                                                                                    <%# Eval("FileName").ToString().Substring(12, (Eval("FileName").ToString().Length-1) - 11)%>
                                                                                                </a>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Type">
                                                                                            <ItemStyle Width="50%" />
                                                                                            <ItemTemplate>
                                                                                                <%# Eval("Type") %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="6">
                                                                    <asp:Button ID="btnViewAuditOwnership" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp('Ownership');"
                                                                        Visible="false" />&nbsp;
                                                                    <asp:Button ID="btnBackToBuilding" runat="server" Text="Back To Building Information"
                                                                        OnClientClick="javascript:ShowPanel(2);return false;" Width="220" SkinID="btnGen" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlBuildingImprovements" runat="server" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Building Improvements
                                                </div>
                                                <asp:UpdatePanel runat="server" ID="updBuildingImprovements">
                                                    <ContentTemplate>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" colspan="6">Building Improvements Grid<br />
                                                                    <b><i>Click to view detail</i></b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    <asp:GridView ID="gvBuildingImprovements" runat="server" Width="100%" OnRowCommand="gvBuildingImprovements_RowCommand"
                                                                        EmptyDataText="No Improvement Record Exists">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Building">
                                                                                <ItemStyle Width="10%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkBuilding" runat="server" Text='<%#Eval("Building_Number")%>'
                                                                                        CommandArgument='<%#Eval("PK_Building_Improvements_Buildings")%>' CommandName="ShowDetails" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Project Number">
                                                                                <ItemStyle Width="15%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkProjectNumber" runat="server" Text='<%#Eval("Project_Number")%>'
                                                                                        CommandArgument='<%#Eval("PK_Building_Improvements_Buildings")%>' CommandName="ShowDetails" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Project Description">
                                                                                <ItemStyle Width="35%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkProjectDesc" runat="server" Text='<%#Eval("Project_Description")%>'
                                                                                        CommandArgument='<%#Eval("PK_Building_Improvements_Buildings")%>' CommandName="ShowDetails" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Start Date">
                                                                                <ItemStyle Width="15%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkStartDate" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Start_Date"))%>'
                                                                                        CommandArgument='<%#Eval("PK_Building_Improvements_Buildings")%>' CommandName="ShowDetails" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Target Date">
                                                                                <ItemStyle Width="15%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkCompletionDate" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Target_Completion_Date"))%>'
                                                                                        CommandArgument='<%#Eval("PK_Building_Improvements_Buildings")%>' CommandName="ShowDetails" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlContacts" runat="server" Width="100%">
                                                <div class="bandHeaderRow">
                                                    Contacts
                                                </div>
                                                <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                                                    <ContentTemplate>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <b>Facility Contact</b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Name
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label runat="server" ID="lblName" Width="170px"></asp:Label>
                                                                </td>
                                                                <td align="left" valign="top">Cell Phone
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label runat="server" ID="lblCell_Phone" Width="170px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Facility Telephone
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label runat="server" ID="lblPhone" Width="170px"></asp:Label>
                                                                </td>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                                <td align="center" valign="top">&nbsp;
                                                                </td>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <b>After Hours Contact</b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Name
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label runat="server" ID="lblAfter_Hours_Contact_Name" Width="170px"></asp:Label>
                                                                </td>
                                                                <td align="left" valign="top">Cell Phone
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label runat="server" ID="lblAfter_Hours_Contact_Cell_Phone" Width="170px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">Facility Telephone
                                                                </td>
                                                                <td align="center" valign="top">:
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label runat="server" ID="lblAfter_Hours_Contact_Phone" Width="170px"></asp:Label>
                                                                </td>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                                <td align="center" valign="top">&nbsp;
                                                                </td>
                                                                <td align="left" valign="top">&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <b>Emergency Contacts</b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <asp:GridView ID="gvEmergencyContact" runat="server" Width="100%" OnRowCommand="gvEmergencyContact_RowCommand"
                                                                        EmptyDataText="No Emergency Contact Record Exists">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Type">
                                                                                <ItemStyle Width="15%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkType" runat="server" Text='<%# Eval("Type") %>' CommandArgument='<%# Eval("PK_Property_Contact_ID")%>'
                                                                                        CommandName="ViewDetails" CausesValidation="false" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Organization">
                                                                                <ItemStyle Width="28%" />
                                                                                <ItemTemplate>
                                                                                    <%# Eval("Organization")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Contact">
                                                                                <ItemStyle Width="20%" />
                                                                                <ItemTemplate>
                                                                                    <%# Eval("Name")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Phone">
                                                                                <ItemStyle Width="12%" />
                                                                                <ItemTemplate>
                                                                                    <%# Eval("Phone")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Email">
                                                                                <ItemStyle Width="25%" />
                                                                                <ItemTemplate>
                                                                                    <%# Eval("email") %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <b>Utility Contacts</b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <asp:GridView ID="gvUtilityContacts" runat="server" Width="100%" OnRowCommand="gvUtilityContacts_RowCommand"
                                                                        EmptyDataText="No Utility Contact Record Exists">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Type">
                                                                                <ItemStyle Width="15%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkType" runat="server" Text='<%# Eval("Type") %>' CommandArgument='<%# Eval("PK_Property_Contact_ID")%>'
                                                                                        CommandName="ViewDetails" CausesValidation="false" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Organization">
                                                                                <ItemStyle Width="28%" />
                                                                                <ItemTemplate>
                                                                                    <%# Eval("Organization")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Contact">
                                                                                <ItemStyle Width="20%" />
                                                                                <ItemTemplate>
                                                                                    <%# Eval("Name")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Phone">
                                                                                <ItemStyle Width="12%" />
                                                                                <ItemTemplate>
                                                                                    <%# Eval("Phone")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Email">
                                                                                <ItemStyle Width="25%" />
                                                                                <ItemTemplate>
                                                                                    <%# Eval("email") %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <b>Other Contacts</b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="6">
                                                                    <asp:GridView ID="gvOtherContacts" runat="server" Width="100%" OnRowCommand="gvOtherContacts_RowCommand"
                                                                        EmptyDataText="No Other Contact Record Exists">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Type">
                                                                                <ItemStyle Width="15%" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkType" runat="server" Text='<%# Eval("Type") %>' CommandArgument='<%# Eval("PK_Property_Contact_ID")%>'
                                                                                        CommandName="ViewDetails" CausesValidation="false" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Organization">
                                                                                <ItemStyle Width="28%" />
                                                                                <ItemTemplate>
                                                                                    <%# Eval("Organization")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Contact">
                                                                                <ItemStyle Width="20%" />
                                                                                <ItemTemplate>
                                                                                    <%# Eval("Name")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Phone">
                                                                                <ItemStyle Width="12%" />
                                                                                <ItemTemplate>
                                                                                    <%# Eval("Phone")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Email">
                                                                                <ItemStyle Width="25%" />
                                                                                <ItemTemplate>
                                                                                    <%# Eval("email") %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="6">
                                                                    <asp:Button ID="btnViewAuditContacts" runat="server" Text="View Audit Trail" OnClientClick="javascript:return AuditPopUp('Contacts');"
                                                                        Visible="false" />&nbsp;
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
                    <tr>
                        <td style="height: 10px" class="Spacer"></td>
                    </tr>
                    <tr>
                        <td colspan="2" width="100%" align="center">
                            <asp:Button ID="btnBack" runat="server" Text="Edit" OnClick="btnBack_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px" class="Spacer"></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <script language="javascript" type="text/javascript">
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

        //Used to set Menu Style
        function SetMenuStyle(index) {
            var i;
            if (index == 3)
                index = 2;
            for (i = 1; i <= 5; i++) {
                var tb = document.getElementById("PropertyMenu" + i);
                if (tb != null) {
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
        }
        //Show panel
        function ShowPanel(index) {
            SetMenuStyle(index);
            var op = '<%=strOperation%>';
            if (op == "edit") {

            }
            else {
                //check if index is 1 than display Property Cope Section.
                if (index == 1) {
                    document.getElementById("<%=pnlPropertyCope.ClientID%>").style.display = "";
                    document.getElementById("<%=hdrPropertyCope.ClientID%>").style.display = "";
                    document.getElementById("<%=tblPropertyCope.ClientID%>").style.display = "";
                    document.getElementById("<%=pnlSabaTraining.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlBuildingInformation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlOwnershipDetails.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlBuildingImprovements.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlContacts.ClientID%>").style.display = "none";
                }
                //check if index is 2 than display Building Informaiton Section.
                if (index == 2) {
                    document.getElementById("<%=pnlPropertyCope.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlSabaTraining.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlBuildingInformation.ClientID%>").style.display = "";
                    document.getElementById("<%=pnlOwnershipDetails.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlBuildingImprovements.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlContacts.ClientID%>").style.display = "none";
                }
                //check if index is 3 than display Owner ship Details Section.
                if (index == 3) {
                    document.getElementById("<%=pnlPropertyCope.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlSabaTraining.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlBuildingInformation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlOwnershipDetails.ClientID%>").style.display = "";
                    document.getElementById("<%=pnlBuildingImprovements.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlContacts.ClientID%>").style.display = "none";
                    window.scrollTo(0, 0);
                }
                //check if index is 4 than display CProperty Condition Section.
                if (index == 4) {
                    document.getElementById("<%=pnlPropertyCope.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlBuildingInformation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlOwnershipDetails.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlBuildingImprovements.ClientID%>").style.display = "";
                    document.getElementById("<%=pnlContacts.ClientID%>").style.display = "none";
                }
                //check if index is 5 than display Contacts Section.
                if (index == 5) {
                    document.getElementById("<%=pnlPropertyCope.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlSabaTraining.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlBuildingInformation.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlOwnershipDetails.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlBuildingImprovements.ClientID%>").style.display = "none";
                    document.getElementById("<%=pnlContacts.ClientID%>").style.display = "";
                }
            }
        }
        function OpenSelectYearPopup(strType) {
            GB_showCenter('Select Year', '<%=AppConfig.SiteURL%>SONIC/Exposures/PropetySelectYear.aspx?loc=<%=Request.QueryString["loc"]%>&type=' + strType, 300, 500);
        }

        function ViewCOI(type) {
            var popUpTitle = 'Attach Sub-Tenant Certificate of Insurance';
            var PopUpURL = '<%=AppConfig.SiteURL%>SONIC/Exposures/PropertyAddCOI.aspx';
            if (type == 'WC') {
                var lnkCOI_WC = document.getElementById('<%=lnkCOI_WC.ClientID %>');
                var strURL = document.getElementById('<%=hdnCOI_WC_URL.ClientID%>').value;
                if (strURL != '')
                    window.open(strURL);
                return false;
            }
            else if (type == 'EL') {
                var strURL = document.getElementById('<%=hdnCOI_EL_URL.ClientID%>').value;
                if (strURL != '')
                    window.open(strURL);
                return false;
            }
            else if (type == 'GL') {
                var strURL = document.getElementById('<%=hdnCOI_GL_URL.ClientID%>').value;
                if (strURL != '')
                    window.open(strURL);
                return false;
            }
            else if (type == 'Pollution') {
                var strURL = document.getElementById('<%=hdnCOI_Pollution_URL.ClientID%>').value;
                if (strURL != '')
                    window.open(strURL);
                return false;
            }
            else if (type == 'Property') {
                var strURL = document.getElementById('<%=hdnCOI_Property_URL.ClientID%>').value;
                if (strURL != '')
                    window.open(strURL);
                return false;
            }
            else if (type == 'Flood') {
                var strURL = document.getElementById('<%=hdnCOI_Flood_URL.ClientID%>').value;
                if (strURL != '')
                    window.open(strURL);
                return false;
            }
            else if (type == 'EQ') {
                var strURL = document.getElementById('<%=hdnCOI_EQ_URL.ClientID%>').value;
                if (strURL != '')
                    window.open(strURL);
                return false;
            }
            else if (type == 'Waiver') {
                var strURL = document.getElementById('<%=hdnCOI_Waiver_URL.ClientID%>').value;
                    if (strURL != '')
                        window.open(strURL);
                    return false;
                }

}

function OpenPropertyDetailPopup(PK, FK) {
    GB_showCenter('Contact Details', '<%=AppConfig.SiteURL%>SONIC/Exposures/PropertyContactDetails.aspx?PK=' + PK + '&FK=' + FK + '&op=view', 300, 500);
}

    </script>
</asp:Content>
