<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="ManagementSearch.aspx.cs" Inherits="Management_ManagementSearch" %>

<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>JavaScript/JFunctions.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Date_Validation.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/jquery.maskedinput.js"></script>
    <script language="javascript" type="text/javascript">
        function ConfirmDelete() {
            return confirm("Are you sure that you want to delete the selected information and all of its subordinate data (if exists)?");
        }

        jQuery(function ($) {
            $("#<%=txtDate_Scheduled.ClientID%>").mask("99/99/9999");
            $("#<%=txtTo_Date_Scheduled.ClientID%>").mask("99/99/9999");
            $("#<%=txtDate_Complete.ClientID%>").mask("99/99/9999");
            $("#<%=txtTo_Date_Complete.ClientID%>").mask("99/99/9999");
            $("#<%=txtCR_Approved.ClientID%>").mask("99/99/9999");
            $("#<%=txtTo_CR_Approved.ClientID%>").mask("99/99/9999");
        });
    </script>
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    <asp:Panel ID="pnlSearchFilter" runat="server" Width="100%">
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td class="ghc">
                    <b>Management Search</b>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <table width="100%" cellpadding="1" cellspacing="1" border="0">
            <tr>
                <td style="padding-left: 40px;" align="center">
                    <table width="90%" cellpadding="3" cellspacing="1" border="0">
                        <tr>
                            <%-- <td align="left" width="16%" valign="top">
                                Company
                            </td>
                            <td align="center" width="2%" valign="top">
                                :
                            </td>
                            <td align="left" valign="top" width="32%">
                                <asp:TextBox ID="txtCompany" runat="server" MaxLength="50" Width="200px"></asp:TextBox>
                            </td>--%>
                            <td align="left" width="16%" valign="top">DBA
                            </td>
                            <td align="center" width="2%" valign="top">:
                            </td>
                            <td align="left" valign="top" width="32%">
                                <asp:DropDownList ID="drpLocation" runat="server" Width="205px" SkinID="dropGen">
                                </asp:DropDownList>
                            </td>
                            <td align="left" width="16%" valign="top">Location Code
                            </td>
                            <td align="center" width="2%" valign="top">:
                            </td>
                            <td align="left" valign="top" width="32%">
                                <asp:TextBox ID="txtLocation_Code" runat="server" Width="200px" MaxLength="4" autocomplete="off"
                                    onKeyPress="return FormatInteger(event);" onpaste="return false" />
                            </td>
                        </tr>
                        <%-- <tr>
                            <td align="left" valign="top">
                                State
                            </td>
                            <td align="center" valign="top">
                                :
                            </td>
                            <td align="left" valign="top">
                                <asp:DropDownList ID="drpState" runat="server" Width="205px">
                                </asp:DropDownList>
                            </td>
                            <td align="left" valign="top">
                                City
                            </td>
                            <td align="center" valign="top">
                                :
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtCity" runat="server" MaxLength="100" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                Region
                            </td>
                            <td align="center" valign="top">
                                :
                            </td>
                            <td align="left" valign="top">
                                <asp:DropDownList ID="drpRegion" runat="server" Width="205px">
                                </asp:DropDownList>
                            </td>
                            <td align="left" valign="top">
                                County
                            </td>
                            <td align="center" valign="top">
                                :
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtCounty" runat="server" MaxLength="50" Width="200px"></asp:TextBox>
                            </td>
                        </tr>--%>
                        <tr>
                            <%--<td align="left" valign="top">
                                Camera Number
                            </td>
                            <td align="center" valign="top">
                                :
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtCamera_Number" runat="server" MaxLength="30" Width="200px"></asp:TextBox>
                            </td>--%>
                            <td align="left" valign="top">Work To Be Completed
                            </td>
                            <td align="center" valign="top">:
                            </td>
                            <td align="left" valign="top">
                                <asp:DropDownList ID="drpWorkToBeCompleted" runat="server" Width="205px" SkinID="dropGen">
                                </asp:DropDownList>
                            </td>
                            <%-- <td align="left" valign="top">
                                Camera Type
                            </td>
                            <td align="center" valign="top">
                                :
                            </td>
                            <td align="left" valign="top">
                                <asp:DropDownList ID="drpCamera_Type" runat="server" Width="205px" SkinID="dropGen">
                                </asp:DropDownList>
                            </td>--%>
                            <td align="left" valign="top">Other
                            </td>
                            <td align="center" valign="top">:
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtOtherWorkType" runat="server" MaxLength="50" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <%--<td align="left" valign="top">
                                Sonic Task
                            </td>
                            <td align="center" valign="top">
                                :
                            </td>
                            <td align="left" valign="top">
                                <asp:DropDownList ID="drpClient_Issue" runat="server" Width="205px" SkinID="dropGen">
                                </asp:DropDownList>
                            </td>
                            <td align="left" valign="top">
                                ACI Task
                            </td>
                            <td align="center" valign="top">
                                :
                            </td>
                            <td align="left" valign="top">
                                <asp:DropDownList ID="drpFacilities_Issue" runat="server" Width="205px" SkinID="dropGen">
                                </asp:DropDownList>
                            </td>--%>
                            <td align="left" valign="top">Work To Be Completed By
                            </td>
                            <td align="center" valign="top">:
                            </td>
                            <td align="left" valign="top">
                                <asp:RadioButtonList ID="rdbWorkToBeCompletedBy" runat="server">
                                    <asp:ListItem Text="ACI" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Sonic" Value="0"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td align="left" valign="top">Task Complete?
                            </td>
                            <td align="center" valign="top">:
                            </td>
                            <td align="left" valign="top">
                                <asp:RadioButtonList ID="rdbTaskComplete" runat="server" SkinID="YesNoTypeNullSelection" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">Record Type
                            </td>
                            <td align="center" valign="top">:
                            </td>
                            <td align="left" valign="top">
                                <asp:DropDownList ID="drpRecordType" runat="server" Width="205px" SkinID="dropGen">
                                </asp:DropDownList>
                            </td>
                            <td align="left" valign="top">Other
                            </td>
                            <td align="center" valign="top">:
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtOtherRecordType" runat="server" MaxLength="50" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">Job #
                            </td>
                            <td align="center" valign="top">:
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtJob" runat="server" MaxLength="50" Width="200px"></asp:TextBox>
                            </td>
                            <td align="left" valign="top">Order #
                            </td>
                            <td align="center" valign="top">:
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtOrder" runat="server" MaxLength="50" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">Created By
                            </td>
                            <td align="center" valign="top">:
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtCreatedBy" runat="server" MaxLength="50" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <%--<tr>
                            <td align="left" valign="top">
                                Cost
                            </td>
                            <td align="center" valign="top">
                                :
                            </td>
                            <td align="left" valign="top">
                                $<asp:TextBox ID="txtCost" runat="server" Width="195px" onkeypress="javascript:return FormatNumber(event,this.id,12,false,true);" onpaste="return false;" autocomplete="off"/>
                            </td>
                            
                        </tr>--%>
                        <tr>
                            <td align="left" valign="top">Date Scheduled
                            </td>
                            <td align="center" valign="top">:
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtDate_Scheduled" runat="server" SkinID="txtDate" MaxLength="10"
                                    Width="180px" />
                                <img alt="Scheduled Date" onclick="return showCalendar('<%= txtDate_Scheduled.ClientID %>', 'mm/dd/y');"
                                    onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                    align="middle" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationGroup="vsErrorGroup"
                                    Display="none" ErrorMessage="[Management]/Date Scheduled is not a valid date"
                                    SetFocusOnError="true" ControlToValidate="txtDate_Scheduled" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                            </td>
                            <td align="left" valign="top">To
                            </td>
                            <td align="center" valign="top">:
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtTo_Date_Scheduled" runat="server" SkinID="txtDate" MaxLength="10"
                                    Width="180px" />
                                <img alt="Scheduled Date" onclick="return showCalendar('<%= txtTo_Date_Scheduled.ClientID %>', 'mm/dd/y');"
                                    onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                    align="middle" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="vsErrorGroup"
                                    Display="none" ErrorMessage="[Management]/To Date Scheduled is not a valid date"
                                    SetFocusOnError="true" ControlToValidate="txtTo_Date_Scheduled" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                <asp:CompareValidator ID="cvDateOfScheduled" runat="server" ControlToValidate="txtTo_Date_Scheduled"
                                    ControlToCompare="txtDate_Scheduled" ValidationGroup="vsErrorGroup" Display="None"
                                    Type="Date" Operator="GreaterThanEqual" ErrorMessage="Date Scheduled To must be greater than or equal to from date" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">Date Complete
                            </td>
                            <td align="center" valign="top">:
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtDate_Complete" runat="server" SkinID="txtDate" MaxLength="10"
                                    Width="180px" />
                                <img alt="Complete Date" onclick="return showCalendar('<%= txtDate_Complete.ClientID %>', 'mm/dd/y');"
                                    onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                    align="middle" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="vsErrorGroup"
                                    Display="none" ErrorMessage="[Management]/Date Complete is not a valid date"
                                    SetFocusOnError="true" ControlToValidate="txtDate_Complete" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                            </td>
                            <td align="left" valign="top">To
                            </td>
                            <td align="center" valign="top">:
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtTo_Date_Complete" runat="server" SkinID="txtDate" MaxLength="10"
                                    Width="180px" />
                                <img alt="Complete Date" onclick="return showCalendar('<%= txtTo_Date_Complete.ClientID %>', 'mm/dd/y');"
                                    onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                    align="middle" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ValidationGroup="vsErrorGroup"
                                    Display="none" ErrorMessage="[Management]/To Date Comlete is not a valid date"
                                    SetFocusOnError="true" ControlToValidate="txtTo_Date_Complete" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                <asp:CompareValidator ID="cvDateCompleted" runat="server" ControlToValidate="txtTo_Date_Complete"
                                    ControlToCompare="txtDate_Complete" ValidationGroup="vsErrorGroup" Display="None"
                                    Type="Date" Operator="GreaterThanEqual" ErrorMessage="Date Completed To must be greater than or equal to from date" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">CR Approved
                            </td>
                            <td align="center" valign="top">:
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtCR_Approved" runat="server" SkinID="txtDate" MaxLength="10" Width="180px" />
                                <img alt="CR Approved" onclick="return showCalendar('<%= txtCR_Approved.ClientID %>', 'mm/dd/y');"
                                    onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                    align="middle" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ValidationGroup="vsErrorGroup"
                                    Display="none" ErrorMessage="[Management]/CR Approved is not a valid date" SetFocusOnError="true"
                                    ControlToValidate="txtCR_Approved" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                            </td>
                            <td align="left" valign="top">To
                            </td>
                            <td align="center" valign="top">:
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtTo_CR_Approved" runat="server" SkinID="txtDate" Width="180px" />
                                <img alt="To CR Approved" onclick="return showCalendar('<%= txtTo_CR_Approved.ClientID %>', 'mm/dd/y');"
                                    onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                    align="middle" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ValidationGroup="vsErrorGroup"
                                    Display="none" ErrorMessage="[Management]/To Date Comlete is not a valid date"
                                    SetFocusOnError="true" ControlToValidate="txtTo_CR_Approved" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                                <asp:CompareValidator ID="cvCRApproved" runat="server" ControlToValidate="txtTo_CR_Approved"
                                    ControlToCompare="txtCR_Approved" ValidationGroup="vsErrorGroup" Display="None"
                                    Type="Date" Operator="GreaterThanEqual" ErrorMessage="CR Approved To must be greater than or equal to from date" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button runat="server" ID="btnSearch" Text="Search" ValidationGroup="vsErrorGroup"
                        OnClick="btnSearch_Click" CausesValidation="true" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnAdd" runat="server" Text="  Add New " OnClick="btnAdd_Click" />
                    &nbsp;&nbsp;
                    <asp:Button runat="server" ID="btnClear" Text=" Clear " CausesValidation="false"
                        OnClick="btnSearchAgain_Click" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlSearchResult" runat="server" Width="100%" Visible="false">
        <br />
        <br />
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td style="width: 45%">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td class="Spacer" style="height: 10px;"></td>
                        </tr>
                        <tr>
                            <td align="left">&nbsp;<span class="heading">Management Search Results</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">&nbsp; &nbsp;<asp:Label ID="lblNumber" runat="server" Text="0"></asp:Label>&nbsp;Management
                                Found
                            </td>
                        </tr>
                    </table>
                </td>
                <td valign="top" align="right">
                    <uc:ctrlPaging ID="ctrlPageProperty" runat="server" OnGetPage="GetPage" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table cellpadding="0" cellspacing="0" border="0" style="text-align: right; width: 100%;">
                        <tr>
                            <td>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 5px;" align="left">
                                <div style="overflow-x: scroll; overflow-y: none; text-align: left; width: 998px;"
                                    id="dvSearchResult" runat="server">
                                    <asp:GridView ID="gvManagement" runat="server" GridLines="None" CellPadding="4" CellSpacing="0"
                                        AutoGenerateColumns="false" AllowSorting="true" Width="660px" EnableTheming="false" Style="word-wrap: normal; word-break: break-all;"
                                        OnRowCommand="gvManagement_RowCommand" OnRowCreated="gvManagement_RowCreated"
                                        OnSorting="gvManagement_Sorting" OnRowDataBound="gvManagement_RowDataBound">
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Names="Tahoma"
                                            Font-Size="8pt" />
                                        <RowStyle BackColor="#EAEAEA" Font-Names="Tahoma" Font-Size="8pt" />
                                        <EditRowStyle BackColor="#2461BF" Font-Names="Tahoma" Font-Size="8pt" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" Font-Names="Tahoma"
                                            Font-Size="8pt" />
                                        <PagerStyle BackColor="#7f7f7f" ForeColor="White" HorizontalAlign="Center" Font-Names="Tahoma"
                                            Font-Size="8pt" />
                                        <HeaderStyle BackColor="#7f7f7f" Font-Bold="True" ForeColor="White" Font-Names="Tahoma"
                                            Font-Size="8pt" VerticalAlign="Bottom" />
                                        <AlternatingRowStyle BackColor="White" Font-Names="Tahoma" Font-Size="8pt" />
                                        <EmptyDataRowStyle CssClass="emptyrow" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Disposition" HeaderStyle-HorizontalAlign="Left">
                                                <ItemStyle Width="110px" HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnView" CommandName="ViewManagement" CommandArgument='<%#Eval("PK_Management_ID")%>'
                                                        runat="server" CausesValidation="false" Text="View" ToolTip="View Management" />&nbsp;&nbsp;
                                                    <asp:LinkButton ID="btnEdit" CommandName="EditManagement" CommandArgument='<%#Eval("PK_Management_ID")%>'
                                                        runat="server" CausesValidation="false" Text="Edit" ToolTip="Edit Management" />&nbsp;&nbsp;
                                                    <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" CommandName="DeleteManagement"
                                                        ToolTip="Delete Management" CommandArgument='<%#Eval("PK_Management_ID")%>' CausesValidation="false"
                                                        OnClientClick="return ConfirmDelete();" />&nbsp;&nbsp;
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:TemplateField HeaderText="Company" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                SortExpression="Company">
                                                <ItemStyle Width="110px" />
                                                <ItemTemplate>
                                                    <%# Eval("Company")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <%--<asp:TemplateField HeaderText="Camera Number" HeaderStyle-HorizontalAlign="Left"
                                                ItemStyle-HorizontalAlign="Left" SortExpression="Camera_Number">
                                                <ItemStyle Width="110px" />
                                                <ItemTemplate>
                                                    <%# Eval("Camera_Number")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="DBA" HeaderStyle-HorizontalAlign="Left"
                                                ItemStyle-HorizontalAlign="Left" SortExpression="dba">
                                                <ItemStyle Width="110px" />
                                                <ItemTemplate>
                                                    <%# Eval("dba")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:TemplateField HeaderText="Camera Type" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                SortExpression="FK_LU_Camera_Type">
                                                <ItemStyle Width="110px" />
                                                <ItemTemplate>
                                                    <%# Eval("FK_LU_Camera_Type")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Work To Be Completed" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                SortExpression="WorkToBeCompleted">
                                                <ItemStyle Width="110px" />
                                                <ItemTemplate>
                                                    <%# Eval("WorkToBeCompleted")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:TemplateField HeaderText="Date Scheduled" HeaderStyle-HorizontalAlign="Left"
                                                ItemStyle-HorizontalAlign="Left" SortExpression="Date_Scheduled">
                                                <ItemStyle Width="110px" />
                                                <ItemTemplate>
                                                    <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Date_Scheduled"))%>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Order #" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                SortExpression="[Order]">
                                                <ItemStyle Width="110px" />
                                                <ItemTemplate>
                                                    <%# Eval("Order")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:TemplateField HeaderText="Task Complete" HeaderStyle-HorizontalAlign="Left"
                                                ItemStyle-HorizontalAlign="Left" SortExpression="Task_Complete">
                                                <ItemStyle Width="110px" />
                                                <ItemTemplate>
                                                    <%# Eval("Task_Complete")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Job #" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                SortExpression="Job">
                                                <ItemStyle Width="110px" />
                                                <ItemTemplate>
                                                    <%# Eval("Job")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Created By" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                SortExpression="Created_By">
                                                <ItemStyle Width="110px" />
                                                <ItemTemplate>
                                                    <%# Eval("Created_By")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                        <EmptyDataTemplate>
                                            <b>No Record found</b>
                                        </EmptyDataTemplate>
                                        <PagerSettings Visible="False" />
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnSearchAgain" runat="server" Text="Search Again" OnClick="btnSearchAgain_Click" />
                                <asp:Button ID="btnSaveToExcel" runat="server" Text="Export to Excel" OnClick="btnSaveToExcel_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;">&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
