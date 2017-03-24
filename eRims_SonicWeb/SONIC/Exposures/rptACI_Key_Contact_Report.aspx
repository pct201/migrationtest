<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="rptACI_Key_Contact_Report.aspx.cs" Inherits="SONIC_Exposures_rptACI_Key_Contact_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage" />
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script language="javascript" type="text/javascript">
     
    </script>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td width="100%" class="Spacer" style="height: 10px;">
            </td>
        </tr>
        <tr>
            <td align="left" class="ghc">
                ACI Key Contact Report
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 10px;">
            </td>
        </tr>
        <tr runat="server" id="trSearch">
            <td align="center">
                <table cellpadding="3" cellspacing="2" border="0" width="80%">
                    <tr>
                     <%--   <td align="left" valign="top" width="15%">
                            Region
                        </td>
                        <td align="center" valign="top" width="2%">
                            :
                        </td>
                        <td align="left" valign="top" width="33%">
                            <asp:ListBox ID="lstRegions" runat="server" SelectionMode="Multiple" ToolTip="Select Region"
                                AutoPostBack="false" Width="220px" Rows="5"></asp:ListBox>
                        </td>--%>
                        <td align="left" valign="top" width="15%">
                            Location D/B/A
                        </td>
                        <td align="center" valign="top" width="2%">
                            :
                        </td>
                        <td align="left" valign="top" width="33%">
                            <asp:ListBox ID="lstLocationDBA" runat="server" SelectionMode="Multiple" ToolTip="Select Location DBA"
                                AutoPostBack="false" Width="220px" Rows="5"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            Job Title
                        </td>
                        <td align="center" valign="top">:</td>
                        <td align="left" valign="top">
                            <asp:ListBox ID="lstJob_Titles" runat="server" SelectionMode="Multiple" Width="220px" Rows="5">
                                <asp:ListItem Text="General Manager" Value="'General Manager'" />
                                <asp:ListItem Text="Service Manager" Value="'Service Manager'" />
                                <asp:ListItem Text="Parts Manager" Value="'Parts Manager'" />
                                <asp:ListItem Text="Regional Loss Control Manager" Value="'Regional Loss Control Manager'" />
                                <asp:ListItem Text="Executive General Manager - EP" Value="'Executive General Manager - EP'" />
                                <asp:ListItem Text="Div Fixed Ops Dir  - EP" Value="'Div Fixed Ops Dir  - EP'" />
                                <asp:ListItem Text="Service Director" Value="'Service Director'" />
                            </asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" align="center">
                            <asp:Button runat="server" ID="btnShowReport" Text="Show Report" OnClick="btnShowReport_Click"
                                CausesValidation="true"  /><%--ValidationGroup="vsErrorGroup"--%>
                            &nbsp;&nbsp;
                            <asp:Button ID="btnClearCriteria" runat="server" Text="Clear Criteria" ToolTip="Clear All"
                                OnClick="btnClearCriteria_Click" CausesValidation="false" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr runat="server" id="trResult" visible="false">
            <td>
                <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                    <tr valign="middle">
                        <td align="right" width="100%">
                            <asp:LinkButton ID="lbtExportToExcel" runat="server" Text="Export To Excel" OnClick="lbtExportToExcel_Click"></asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" class="Spacer" style="height: 5px;">
                        </td>
                    </tr>
                    <tr id="trGrid" runat="server">
                        <td>
                            <div style="overflow: auto; width: 997px; height: 398px;">
                                <asp:GridView ID="gvKey_Contact" EnableTheming="false" runat="server" AutoGenerateColumns="false"
                                GridLines="None" EmptyDataText="No Record Found !" CellPadding="4" 
                                CellSpacing="0">
                                <HeaderStyle CssClass="HeaderStyle" />
                                <RowStyle CssClass="RowStyle" />
                                <AlternatingRowStyle CssClass="AlterRowStyle" BackColor="White" />
                                <FooterStyle ForeColor="Black" Font-Bold="true" />
                                <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="22px" Font-Bold="true" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Location D/B/A" ItemStyle-Width="250px">
                                        <ItemTemplate>
                                            <%#Eval("DBA")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Store Address 1" ItemStyle-Width="150px">
                                        <ItemTemplate>
                                            <%#Eval("address_1")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Store Address 2" ItemStyle-Width="150px">
                                        <ItemTemplate>
                                            <%#Eval("address_2")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Store City" ItemStyle-Width="100px">
                                        <ItemTemplate>
                                            <%#Eval("city")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Store State" ItemStyle-Width="100px">
                                        <ItemTemplate>
                                            <%#Eval("State")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Store Zip" ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <ItemStyle HorizontalAlign="Left"/>
                                        <ItemTemplate>
                                            <%#Eval("zip_code")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Location Code" ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <ItemStyle HorizontalAlign="Left"/>
                                        <ItemTemplate>
                                            <%#Eval("Sonic_Location_Code")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Job Title" ItemStyle-Width="120px">
                                        <ItemTemplate>
                                            <%#Eval("job_title")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="First Name" ItemStyle-Width="100px">
                                        <ItemTemplate>
                                            <%#Eval("first_name")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Last Name" ItemStyle-Width="100px">
                                        <ItemTemplate>
                                            <%#Eval("last_name")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email Address" ItemStyle-Width="170px">
                                        <ItemTemplate>
                                            <%#Eval("email")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cell Phone" ItemStyle-Width="100px">
                                        <ItemTemplate>
                                            <%#Eval("employee_cell_Phone")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Work Phone" ItemStyle-Width="100px">
                                        <ItemTemplate>
                                            <%#Eval("work_Phone")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cost Center" ItemStyle-Width="100px">
                                        <ItemTemplate>
                                            <%#Eval("FK_Cost_Center")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Secondary Cost Center" ItemStyle-Width="170px">
                                        <ItemTemplate>
                                            <%#Eval("Secondary_Cost_Center")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    No Record Found !
                                </EmptyDataTemplate>
                            </asp:GridView>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" style="height: 15px;">
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button runat="server" ID="btnBack" OnClick="btnBack_Click" Text="Back" />
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" style="height: 10px;">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
