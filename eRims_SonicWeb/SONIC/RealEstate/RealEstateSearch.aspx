<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="RealEstateSearch.aspx.cs"
    Inherits="SONIC_RealEstate_RealEstateSearch" Title="Real Estate Search" %>

<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<%@ Register Src="../../Controls/RealEstateTab/RealEstate.ascx" TagName="RealEstate"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="search" CssClass="errormessage"></asp:ValidationSummary>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Date_Validation.js"></script>

    <script language="javascript" type="text/javascript">
     function ConfirmDelete()
	    {
	        return confirm('Are you sure you want to remove the selected data from eRIMS2? Once the data are removed, eRIMS2 does not have functionality to retrieve the data.');
	    }
    </script>

    <div style="width: 100%">
        <table width="100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <uc2:RealEstate ID="RE_Tab" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div style="width: 100%" id="dvSearch" runat="server">
        <table width="100%" cellspacing="0" cellpadding="0">
            <tr>
                <td class="groupHeaderBar" align="left">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="height: 20px" class="Spacer">
                </td>
            </tr>
            <tr>
                <td class="heading">
                    &nbsp;Real Estate Search
                </td>
            </tr>
            <tr>
                <td style="height: 15px;">
                </td>
            </tr>
            <tr>
                <td>
                    <table width="77%" align="center" style="text-align: left;" cellpadding="2" cellspacing="3"
                        border="0">
                        <tr valign="top" align="left" style="width: 20%;">
                            <td>
                                Dealership
                            </td>
                            <td style="width: 4%;" align="right">
                                :
                            </td>
                            <td colspan="4" style="width: 26%;">
                                <asp:DropDownList ID="ddlDealership" runat="server" SkinID="dropGen" Width="93%">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr valign="top" align="left">
                            <td>
                                Region
                            </td>
                            <td align="right">
                                :
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlRegion" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr valign="top" align="left">
                            <td>
                                Lease Commence Date From
                            </td>
                            <td align="right">
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtLCDateFrom" runat="server" MaxLength="10" SkinID="txtDate"></asp:TextBox>
                                <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtLCDateFrom.ClientID%>', 'mm/dd/y');"
                                    alt="Lease Commence Date From" src="../../Images/iconPicDate.gif" align="middle" />
                                <asp:RegularExpressionValidator ID="rvtxtLCDateFrom" runat="server" ControlToValidate="txtLCDateFrom"
                                    ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                    ErrorMessage="Lease Commence Date From is Not Valid." Display="none" ValidationGroup="search">
                                </asp:RegularExpressionValidator>
                            </td>
                            <td style="width: 13%;">
                                &nbsp;&nbsp;&nbsp;To
                            </td>
                            <td align="right">
                                :
                            </td>
                            <td style="width: 30%;">
                                <asp:TextBox ID="txtLCDateTo" runat="server" MaxLength="10" SkinID="txtDate"></asp:TextBox>
                                <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtLCDateTo.ClientID%>', 'mm/dd/y');"
                                    alt="Lease Commence Date To" src="../../Images/iconPicDate.gif" align="middle" />
                                <asp:RegularExpressionValidator ID="revtxtLCDateTo" runat="server" ControlToValidate="txtLCDateTo"
                                    ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                    ErrorMessage="Lease Commence Date To is Not Valid." Display="none" ValidationGroup="search">
                                </asp:RegularExpressionValidator>
                                <asp:CompareValidator ID="cfvLCD" runat="server" ControlToCompare="txtLCDateFrom"
                                    ValidationGroup="search" Display="None" Type="Date" Operator="GreaterThanEqual"
                                    ControlToValidate="txtLCDateTo" ErrorMessage="Lease Commence Date From Must Be Less Than Date To."></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr valign="top" align="left">
                            <td>
                                Lease Expiration Date From
                            </td>
                            <td align="right">
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtLEDateFrom" runat="server" MaxLength="10" SkinID="txtDate"></asp:TextBox>
                                <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtLEDateFrom.ClientID%>', 'mm/dd/y');"
                                    alt="Lease Expiration Date From" src="../../Images/iconPicDate.gif" align="middle" />
                                <asp:RegularExpressionValidator ID="revtxtLEDateFrom" runat="server" ControlToValidate="txtLEDateFrom"
                                    ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                    ErrorMessage="Lease Expiration Date From is not valid." Display="none" ValidationGroup="search">
                                </asp:RegularExpressionValidator>
                            </td>
                            <td>
                                &nbsp;&nbsp;&nbsp;To
                            </td>
                            <td align="right">
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtLEDateTo" runat="server" MaxLength="10" SkinID="txtDate"></asp:TextBox>
                                <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtLEDateTo.ClientID%>', 'mm/dd/y');"
                                    alt="Lease Expiration Date To" src="../../Images/iconPicDate.gif" align="middle" />
                                <asp:RegularExpressionValidator ID="revtxtLEDateTo" runat="server" ControlToValidate="txtLEDateTo"
                                    ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                    ErrorMessage="Lease Expiration Date To is Not Valid." Display="none" ValidationGroup="search">
                                </asp:RegularExpressionValidator>
                                <asp:CompareValidator ID="cfvLED" runat="server" ControlToCompare="txtLEDateFrom"
                                    ValidationGroup="search" Display="None" Type="Date" Operator="GreaterThanEqual"
                                    ControlToValidate="txtLEDateTo" ErrorMessage="Lease Expiration Date From Must Be Less Than Date To."></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr valign="top" align="left">
                            <td>
                                State
                            </td>
                            <td align="right">
                                :
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlState" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr valign="top" align="left">
                            <td>
                                Landlord
                            </td>
                            <td align="right">
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtLandlord" runat="server" MaxLength="75" Width="170px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr valign="top" align="left">
                            <td>
                                Date Acquired From
                            </td>
                            <td align="right">
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtDateAcquiredFrom" runat="server" MaxLength="10" SkinID="txtDate"></asp:TextBox>
                                <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtDateAcquiredFrom.ClientID%>', 'mm/dd/y');"
                                    alt="Date Acquired From From" src="../../Images/iconPicDate.gif" align="middle" />
                                <asp:RegularExpressionValidator ID="revtxtDateAcquiredFrom" runat="server" ControlToValidate="txtDateAcquiredFrom"
                                    ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                    ErrorMessage="Date Acquired From is not valid." Display="none" ValidationGroup="search">
                                </asp:RegularExpressionValidator>
                            </td>
                            <td>
                                &nbsp;&nbsp;&nbsp;To
                            </td>
                            <td align="right">
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtDateAcquiredTo" runat="server" MaxLength="10" SkinID="txtDate"></asp:TextBox>
                                <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('<%=txtDateAcquiredTo.ClientID%>', 'mm/dd/y');"
                                    alt="Lease Expiration Date To" src="../../Images/iconPicDate.gif" align="middle" />
                                <asp:RegularExpressionValidator ID="revtxtDateAcquiredTo" runat="server" ControlToValidate="txtDateAcquiredTo"
                                    ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([0-9])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([0-9])(\d{1})|(20)([0-9])(\d{1})))$"
                                    ErrorMessage="Date Acquired To is Not Valid." Display="none" ValidationGroup="search">
                                </asp:RegularExpressionValidator>
                                <asp:CompareValidator ID="cfvDateAcquired" runat="server" ControlToCompare="txtDateAcquiredFrom"
                                    ValidationGroup="search" Display="None" Type="Date" Operator="GreaterThanEqual"
                                    ControlToValidate="txtDateAcquiredTo" ErrorMessage="Date Acquired From Must Be Less Than Date To."></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr valign="top" align="left">
                            <td>
                                Lease Type
                            </td>
                            <td align="right">
                                :
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlLeaseType" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr valign="top" align="left">
                            <td>
                                Project Type
                            </td>
                            <td align="right">
                                :
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlProjectType" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnSearch" runat="server" ValidationGroup="search" Text="Search"
                        CausesValidation="true" OnClick="btnSearch_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnClear" runat="server" Text="Clear" CausesValidation="false" OnClick="btnClear_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div id="dvSearchResult" runat="server" style="display: none; width: 100%;">
        <table width="100%" cellspacing="0" cellpadding="0">
            <tr>
                <td align="left">
                    <table cellpadding="4" cellspacing="2" width="100%">
                        <tr>
                            <td width="45%">
                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                    <tr>
                                        <td align="left">
                                            &nbsp;<asp:Label ID="lblSearchHeader" runat="server" Text="Real Estate Search" CssClass="heading"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            &nbsp;
                                            <asp:Label ID="lblNumber" runat="server" Text="0"></asp:Label>&nbsp;Real Estate
                                            Records Found.
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td valign="top" align="right">
                                <uc:ctrlPaging ID="ctrlPager" runat="server" OnGetPage="GetPage" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 10px" colspan="2" class="Spacer">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvRealEstate" DataKeyNames="PK_RE_Information" runat="server" Width="100%"
                        OnRowCommand="gvRealEstate_RowCommand" AllowPaging="false" AllowSorting="True"
                        AutoGenerateColumns="False" OnSorting="gvRealEstate_Sorting" CellPadding="2"
                        CellSpacing="0" OnRowCreated="gvRealEstate_RowCreated" OnRowDataBound="gvRealEstate_DataRowBound"
                        BorderWidth="1px" BorderColor="silver">
                        <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center"></EmptyDataRowStyle>
                        <HeaderStyle VerticalAlign="Bottom" />
                        <Columns>
                            <asp:BoundField DataField="Dealership" SortExpression="Dealership" HeaderText="Dealership"
                                ItemStyle-Width="18%"></asp:BoundField>
                            <asp:BoundField DataField="Region" SortExpression="Region" HeaderText="Region" ItemStyle-Width="12%">
                            </asp:BoundField>
                            <asp:BoundField DataField="Lease_Commencement_Date" SortExpression="Lease_Commencement_Date"
                                HeaderText="LCD" DataFormatString="{0:MM/dd/yyyy}" ItemStyle-Width="8%" HtmlEncode="false">
                            </asp:BoundField>
                            <asp:BoundField DataFormatString="{0:MM/dd/yyyy}" SortExpression="Lease_Expiration_Date"
                                DataField="Lease_Expiration_Date" HeaderText="LED" ItemStyle-Width="8%" HtmlEncode="false">
                            </asp:BoundField>
                            <asp:BoundField SortExpression="Landlord" DataField="Landlord" HeaderText="Landlord"
                                ItemStyle-Width="10%"></asp:BoundField>
                            <asp:BoundField DataFormatString="{0:MM/dd/yyyy}" SortExpression="Date_Acquired"
                                DataField="Date_Acquired" HeaderText="Date Acquired" ItemStyle-Width="11%" HtmlEncode="false">
                            </asp:BoundField>
                            <asp:BoundField SortExpression="Lease_Type" DataField="Lease_Type" HeaderText="Lease Type"
                                ItemStyle-Width="11%" HtmlEncode="false"></asp:BoundField>
                            <asp:BoundField SortExpression="Project_Type" DataField="Project_Type" HeaderText="Project Type"
                                ItemStyle-Width="10%"></asp:BoundField>
                            <asp:TemplateField HeaderText="Disposition" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" Width="12%"></ItemStyle>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEdit" CommandName="EditItem" CommandArgument='<%#Eval("PK_RE_Information")%>'
                                        ToolTip="Edit Real Estate Information" runat="server">Edit</asp:LinkButton>
                                    &nbsp;&nbsp;
                                    <asp:LinkButton ID="lnkView" CommandName="ViewItem" CommandArgument='<%#Eval("PK_RE_Information")%>'
                                        ToolTip="View Real Estate Information" runat="server">View</asp:LinkButton>
                                    &nbsp;&nbsp;<asp:LinkButton ID="lnkDelete" CommandName="DeleteItem" CommandArgument='<%#Eval("PK_RE_Information")%>'
                                        ToolTip="Delete Real Estate Information" OnClientClick="return ConfirmDelete();"
                                        Visible='<%#(App_Access == AccessType.Administrative_Access) %>' runat="server">Delete</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            No data found.
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td style="height: 15px" class="Spacer">
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnBack" OnClick="btnBack_Click" CausesValidation="false" runat="server"
                        Text="Search"></asp:Button>&nbsp;&nbsp;
                    <asp:Button ID="btnAdd" runat="server" Text=" Add " CausesValidation="false" OnClick="btnAddNew_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
