<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Training_User_Reconciliation_Report.aspx.cs" Inherits="SONIC_Exposures_Training_User_Reconciliation_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100%" class="Spacer" style="height: 15px;"></td>
        </tr>
        <tr>
            <td width="100%" class="ghc">&nbsp;&nbsp;Training User Reconciliation Report
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 15px;"></td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="0" width="1000px" align="center">
                    <tr>
                        <td width="100%" align="left">
                            <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                <tr>
                                    <td align="right">
                                        <asp:LinkButton ID="lnkExportToExcel" runat="server" Text="Export To Excel" OnClick="lnkExportToExcel_Click"></asp:LinkButton>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Spacer" style="height: 15px;"></td>
                                </tr>
                                <tr>
                                    <td>
                                        <div runat="server" id="dvReport" style="overflow-x:scroll; overflow-y: hidden; text-align: left;">
                                            <asp:GridView ID="gvReport" AutoGenerateColumns="false" Width="1200px" runat="server"
                                                EnableTheming="false" HorizontalAlign="Left" CellPadding="0" CellSpacing="0"
                                                GridLines="None" CssClass="GridClass" EmptyDataText="No Record Found" OnRowCreated="gvReport_RowCreated"
                                                Style="word-wrap: normal; word-break: break-all;">
                                                <HeaderStyle CssClass="HeaderStyle" />
                                                <RowStyle CssClass="RowStyle" />
                                                <AlternatingRowStyle CssClass="AlterRowStyle" />
                                                <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="18px" />
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <table width="100%" cellpadding="4" cellspacing="0" style="font-weight: bold;" id="tblHeader" runat="server">
                                                                <tr>
                                                                    <td width="100px" align="left">First Name
                                                                    </td>
                                                                    <td width="100px" align="left">Last Name
                                                                    </td>
                                                                    <td width="150px" align="left">Social Security Number
                                                                    </td>
                                                                    <td width="150px" align="left">E-Mail Address
                                                                    </td>
                                                                    <td width="150px" align="left">Location
                                                                    </td>
                                                                    <td width="100px" align="left">Department
                                                                    </td>
                                                                    <td width="200px" align="left">Job Title
                                                                    </td>
                                                                    <td width="80px" align="left">Date of Hire
                                                                    </td>
                                                                    <td width="150px" align="left">Active InActive Leave
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <table width="100%" cellpadding="4" cellspacing="0" id="tblDetails" runat="server">
                                                                <tr valign="top">
                                                                    <td align="left" style="width: 100px" valign="top">
                                                                        <%# Eval("First_Name")%>
                                                                    </td>
                                                                    <td align="left" style="width: 100px" valign="top">
                                                                        <%# Eval("Last_Name")%>
                                                                    </td>
                                                                    <td align="left" style="width: 150px" valign="top">
                                                                        <%# Eval("Social_Security_Number")%>
                                                                    </td>
                                                                    <td align="left" style="width: 150px" valign="top">
                                                                        <%# Eval("Email")%>
                                                                    </td>
                                                                    <td align="left" style="width: 150px" valign="top">
                                                                        <%# Eval("dba")%>
                                                                    </td>
                                                                    <td align="left" style="width: 100px" valign="top">
                                                                        <%# Eval("Department") %>
                                                                    </td>
                                                                    <td align="left" style="width: 200px" valign="top">
                                                                        <%#Eval("Job_Title")%>
                                                                    </td>
                                                                    <td align="left" style="width: 80px" valign="top">
                                                                        <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Last_Date_Of_Hire"))%>
                                                                    </td>
                                                                    <td align="left" style="width: 150px" valign="top">
                                                                        <%#Eval("Active_InActive_Leave")%>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 15px;"></td>
        </tr>
    </table>
</asp:Content>

