<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="ExposureSearchResult.aspx.cs"
    Inherits="SONIC_Exposures_ExposureSearchResult" Title="eRIMS Sonic :: Exposures :: Search Results" %>

<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        var GB_ROOT_DIR = '<%=AppConfig.SiteURL%>' + 'greybox/';
    </script>
    <link href="<%=AppConfig.SiteURL%>greybox/gb_styles.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>greybox/gb_scripts.js"></script>
    <script type="text/javascript">
        function ConfirmDelete() {
            return confirm("Are you sure to delete?");
        }
        function OpenLocationPopup(intLocationID) {
            var options = { caption: "", height: 400, width: 750, fullscreen: false, center_win: true, show_close_img: true }
            var win = new GB_Window(options);
            return win.show('<%=AppConfig.SiteURL%>SONIC/Exposures/DealershipDBA_Pupup.aspx?id=' + intLocationID);
        }
    </script>
    <table cellpadding="0" cellspacing="0" width="98%" align="center">
        <tr>
            <td width="100%" class="Spacer" style="height: 20px;">
            </td>
        </tr>
        <tr>
            <td align="left">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td width="45%">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td align="left">
                                        <span class="heading">Exposures Results Grid</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        &nbsp;
                                        <asp:Label ID="lblNumber" runat="server" Text="0"></asp:Label>&nbsp;Found
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top" align="right">
                            <uc:ctrlPaging ID="ctrlPageExposure" runat="server" OnGetPage="GetPage" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 10px;">
            </td>
        </tr>
        <tr>
            <td class="groupHeaderBar">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 20px;">
            </td>
        </tr>
        <tr>
            <td>
               <div id="dvGrid" runat="server" style="width: 999px; overflow-x: scroll; overflow-y: hidden">
                            <asp:GridView ID="gvExposure" runat="server" AutoGenerateColumns="false" Width="999px"
                                AllowSorting="True" OnSorting="gvExposure_Sorting" OnRowCreated="gvExposure_RowCreated"
                                OnRowDataBound="gvExposure_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sonic Location Code" SortExpression="Sonic_Location_Code" ItemStyle-CssClass="position: fixed;z-index: 100;">
                                        <ItemStyle HorizontalAlign="Left" Width="90px" />
                                        <ItemTemplate>
                                            <% if (App_RealEstateAccess == AccessType.Administrative_Access)
                                               { %>
                                            <a href="javascript:void(0);" onclick="javascript:OpenLocationPopup(<%#Eval("PK_LU_Location_ID") %>);"
                                                title="Edit Location">
                                                <%# Eval("Sonic_Location_Code")%></a>
                                            <%}
                                               else
                                               {%>
                                            <%# Eval("Sonic_Location_Code")%>
                                            <%} %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sonic Location d/b/a" SortExpression="dba">
                                        <ItemStyle HorizontalAlign="Left" Width="230px" />
                                        <ItemTemplate>
                                            <% if (App_RealEstateAccess == AccessType.Administrative_Access)
                                               { %>
                                            <a href="javascript:void(0);" onclick="javascript:OpenLocationPopup(<%#Eval("PK_LU_Location_ID") %>);"
                                                title="">
                                                <%#Eval("dba")%></a>
                                            <%}
                                               else
                                               {%>
                                            <%# Eval("dba")%>
                                            <%} %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Property">
                                        <ItemStyle HorizontalAlign="Left" Width="65px" />
                                        <ItemTemplate>
                                            <a href='<%# Convert.ToInt32(Eval("PropertyCount")) > 0 ? "PropertyView.aspx?loc=" + Encryption.Encrypt(Eval("PK_LU_Location_ID").ToString()) : "Property.aspx?loc=" + Encryption.Encrypt(Eval("PK_LU_Location_ID").ToString()) %>'>
                                                <%# App_Access == AccessType.NotAssigned ? "" : Convert.ToInt32(Eval("PropertyCount")) > 0  ? Eval("Active").ToString() == "N" ? "" : "View" : (App_Access == AccessType.View_Only || Eval("Active").ToString() == "N") ? "" : "Add New"%>
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Franchise">
                                        <ItemStyle HorizontalAlign="Left" Width="65px" />
                                        <ItemTemplate>
                                            <a href='#' runat="server" id="lnkFranchise" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="EHS">
                                        <ItemStyle HorizontalAlign="Left" Width="65px" />
                                        <ItemTemplate>
                                            <%--<a href='<%# Convert.ToInt32(Eval("PollutionCount")) > 0 ? AppConfig.SiteURL + "SONIC/Pollution/Pollution.aspx?loc=" + Encryption.Encrypt(Eval("PK_LU_Location_ID").ToString())+"&op=view" : AppConfig.SiteURL + "SONIC/Pollution/Pollution.aspx?loc=" + Encryption.Encrypt(Eval("PK_LU_Location_ID").ToString()) %>'>
                                                <%# App_Access == AccessType.NotAssigned ? "" : Convert.ToInt32(Eval("PollutionCount")) > 0 ? (Eval("Active").ToString() == "N" ? "" : "View") : (App_Access == AccessType.View_Only || Eval("Active").ToString() == "N") ? "" : "Add New"%>
                                            </a>--%>
                                            <%--<a href='<%# Convert.ToInt32(Eval("PollutionCount")) > 0 ? AppConfig.SiteURL + "SONIC/Pollution/BuildingList.aspx?loc=" + Encryption.Encrypt(Eval("PK_LU_Location_ID").ToString())+"&op=view" : AppConfig.SiteURL + "SONIC/Pollution/Pollution.aspx?loc=" + Encryption.Encrypt(Eval("PK_LU_Location_ID").ToString()) %>'>
                                                <%# App_Access == AccessType.NotAssigned ? "" : Convert.ToInt32(Eval("PollutionCount")) > 0 ? (Eval("Active").ToString() == "N" ? "" : "View") : (App_Access == AccessType.View_Only || Eval("Active").ToString() == "N") ? "" : "Add New"%>
                                            </a>--%>
                                            <a href='<%# AppConfig.SiteURL + "SONIC/Pollution/BuildingList.aspx?loc=" + Encryption.Encrypt(Eval("PK_LU_Location_ID").ToString())+"&op=view" %>'>
                                                <%# App_Access == AccessType.NotAssigned ? "" : Convert.ToInt32(Eval("PollutionCount")) > 0 ? (Eval("Active").ToString() == "N" ? "" : "View") : (App_Access == AccessType.View_Only || Eval("Active").ToString() == "N") ? "" : "Add New"%>
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>

<%--
                                    <asp:TemplateField HeaderText="Environmental Old">
                                        <ItemStyle HorizontalAlign="Left" Width="200px" />
                                        <ItemTemplate>
                                            <a href='<%# Convert.ToInt32(Eval("EnvCount")) > 0 ? "ViewEnvironmental.aspx?loc=" + Encryption.Encrypt(Eval("PK_LU_Location_ID").ToString()) : "Environmental.aspx?loc=" + Encryption.Encrypt(Eval("PK_LU_Location_ID").ToString()) %>'>
                                                <%# App_Access == AccessType.NotAssigned ? "" : Convert.ToInt32(Eval("EnvCount")) > 0 ? (Eval("Active").ToString() == "N" ? "" : "View") : (App_Access == AccessType.View_Only || Eval("Active").ToString() == "N") ? "" : "Add New"%>
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
--%>

                                    <asp:TemplateField HeaderText="Env Proj Mgmt">
                                        <ItemStyle HorizontalAlign="Left" Width="65px" />
                                        <ItemTemplate>
                                            <a href='<%# Convert.ToInt32(Eval("EPMCount")) > 0 ? "Project_Management_Add.aspx?loc=" + Encryption.Encrypt(Eval("PK_LU_Location_ID").ToString()) : "Project_Management.aspx?loc=" + Encryption.Encrypt(Eval("PK_LU_Location_ID").ToString()) +"&id="+Encryption.Encrypt("0")+"&op=add" %>'>
                                                <%# App_Access == AccessType.NotAssigned ? "" : Convert.ToInt32(Eval("EPMCount")) > 0 ? (Eval("Active").ToString() == "N" ? "" : "View") : (App_Access == AccessType.View_Only || Eval("Active").ToString() == "N") ? "" : "Add New"%>
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Inspection">
                                        <ItemStyle HorizontalAlign="Left" Width="65px" />
                                        <ItemTemplate>
                                            <a href='Inspections.aspx?loc=<%#Encryption.Encrypt(Eval("PK_LU_Location_ID").ToString())%>'>
                                                <%# App_Access == AccessType.NotAssigned ? "" : Convert.ToInt32(Eval("InspectionCount")) > 0 ? Eval("Active").ToString() == "N" ? "" : "View" : (App_Access == AccessType.View_Only || Eval("Active").ToString() == "N") ? "" : "Add New"%>
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Asset Protection">
                                        <ItemStyle HorizontalAlign="Left" Width="65px" />
                                        <ItemTemplate>
                                            <a href='Asset_Protection.aspx?loc=<%#Encryption.Encrypt(Eval("PK_LU_Location_ID").ToString())%>'>
                                                <%# Asset_Protection == AccessType.NotAssigned ? "" : Convert.ToInt32(Eval("AssetProtectionCount")) > 0 ? Eval("Active").ToString() == "N" ? "" : "View" : (Asset_Protection == AccessType.View_Only || Eval("Active").ToString() == "N") ? "" : "Add New"%>
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ACI" visible= "false"> <%--Change Header text from Cal Atlantic to ACI as per client's request Bug ID = 2552--%>
                                        <ItemStyle HorizontalAlign="Left" Width="75px" />
                                        <ItemTemplate>
                                            <%--<a href='../CalAtlantic/EventSearch.aspx?loc=<%#Encryption.Encrypt(Eval("PK_LU_Location_ID").ToString())%>'>--%>
                                            <a href='../../Event/EventSearch_New.aspx?loc=<%#Encryption.Encrypt(Eval("PK_ACI_LU_Location").ToString())%>'>
                                                View
                                            </a>
                                            <%--Add 'Add' Link for ACI Event as per client's request Bug ID = 2701 And Mail Sub: ACI - Sonic bugs--%>
                                            /<a href='../../Event/Event_New.aspx?mode=add&loc=<%#Encryption.Encrypt(Eval("PK_ACI_LU_Location").ToString())%>'>
                                                Add
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Leases">
                                        <ItemStyle HorizontalAlign="Left" Width="55px" />
                                        <ItemTemplate>
                                            <a href="../RealEstate/Lease.aspx?loc=<%#Encryption.Encrypt(Eval("PK_LU_Location_ID").ToString())%>">
                                                <%# App_RealEstateAccess == AccessType.NotAssigned ? "" : Convert.ToInt32(Eval("LeaseCount")) > 0 ? Eval("Active").ToString() == "N" ? "" : "View" : (App_RealEstateAccess == AccessType.View_Only || Eval("Active").ToString() == "N") ? "" : "Add New"%>
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Construction">
                                        <ItemStyle HorizontalAlign="Left" Width="55px" />
                                        <ItemTemplate>
                                            <a href='#' runat="server" id="lnkConstruction" />
                                            <%--<a href="../Exposures/ConstructionProjectManagement.aspx?loc=<%#Encryption.Encrypt(Eval("PK_LU_Location_ID").ToString())%>">
                                                <%# App_Access == AccessType.NotAssigned ? "" : Convert.ToInt32(Eval("ConstructionProjectCount")) > 0 ? Eval("Active").ToString() == "N" ? "" : "View" : (App_Access == AccessType.View_Only || Eval("Active").ToString() == "N") ? "" : "Add New"%>--%>
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Map">
                                        <ItemStyle HorizontalAlign="Left" Width="55px" />
                                        <ItemTemplate>
                                            <a href='http://maps.google.com/maps?f=q&source=embed&hl=en&geocode=&q=<%#Eval("Address").ToString().Trim(',')%>'
                                                target="_blank" title="View Location In Map">
                                                <%# Eval("Active").ToString() == "N" ? "" : "View"%></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <table cellpadding="4" cellspacing="0" width="100%">
                                        <tr>
                                            <td width="100%" align="center" style="border: 1px solid #cccccc;">
                                                <asp:Label ID="lblEmptyHeaderGridMessage" runat="server" Text="No Record Found"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>
                            </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 20px;">
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td width="100%" align="center">
                            <asp:Button ID="btnSearch" runat="server" Text="Search Again" OnClick="btnSearch_Click"
                                ToolTip="Search Again" />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnAddLocation" runat="server" Text="Add Location" OnClientClick="javascript:return OpenLocationPopup(0)"
                                ToolTip="Add Location" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 20px;">
            </td>
        </tr>
    </table>
</asp:Content>
