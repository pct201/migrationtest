<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="EventSearch_New.aspx.cs" Inherits="Event_EventSearch_New" %>

<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript" language="javascript" src="../JavaScript/Calendar_new.js"></script>
<script type="text/javascript" language="javascript" src="../JavaScript/calendar-en.js"></script>
<script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"></script>
<script type="text/javascript" language="javascript" src="../JavaScript/Validator.js"></script>
<script type="text/javascript" language="javascript" src="../JavaScript/jquery-1.5.min.js"></script>
<script type="text/javascript" language="javascript" src="../JavaScript/jquery.maskedinput.js"></script>
<script type="text/javascript" language="javascript" src="../JavaScript/Date_Validation.js"></script>
<script language="javascript" type="text/javascript">
    function ConfirmDelete() {
        return confirm("Are you sure that you want to delete the selected information and all of its subordinate data (if exists)?");
    }
    </script>
   <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    <asp:Panel ID="pnlSearchFilter" runat="server" Width="100%" DefaultButton="btnSearch">
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="ghc">
                    <b>Event Search</b>
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
                            <td align="left" valign="top">
                                Event Number
                            </td>
                            <td align="center" valign="top">
                                :
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtEventNumber" runat="server" MaxLength="20" Width="170px"></asp:TextBox>
                            </td>
                            <td align="left" valign="top">
                                Event Type
                            </td>
                            <td align="center" valign="top">
                                :
                            </td>
                            <td align="left" valign="top">
                                <asp:DropDownList ID="drpEventType" runat="server" Width="175px" SkinID="dropGen">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                Camera Name
                            </td>
                            <td align="center" valign="top">
                                :
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox runat="server" ID="txtCameraName" MaxLength="50" Width="170px"></asp:TextBox>
                            </td>
                            <td align="left" valign="top">
                                Camera Number
                            </td>
                            <td align="center" valign="top">
                                :
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtCameraNumber" runat="server" MaxLength="20" Width="170px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="16%" valign="top">
                                Location
                            </td>
                            <td align="center" width="2%" valign="top">
                                :
                            </td>
                            <td align="left" valign="top" width="32%">
                                <asp:DropDownList ID="drpLocation" runat="server" Width="175px" SkinID="dropGen">
                                </asp:DropDownList>
                            </td>
                            <td align="left" width="16%" valign="top">
                                ACI Event ID
                            </td>
                            <td align="center" width="2%" valign="top">
                                :
                            </td>
                            <td align="left" valign="top" width="32%">
                                <asp:TextBox ID="txtACI_EventID" runat="server" MaxLength="30" Width="170px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                Event Date
                            </td>
                            <td align="center" valign="top">
                                :
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtEvent_Date_From" runat="server" Width="150px" SkinID="txtDate"
                                    MaxLength="10"></asp:TextBox>
                                <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtEvent_Date_From', 'mm/dd/y');"
                                    onmouseover="javascript:this.style.cursor='hand';" alt="" src="../Images/iconPicDate.gif"
                                    align="middle" id="img3" />
                                <br />
                                <asp:RegularExpressionValidator ID="revtxtEvent_Date" runat="server" ControlToValidate="txtEvent_Date_From"
                                    ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                    ErrorMessage="Event Date is Not Valid Date" Display="none" ValidationGroup="vsErrorGroup"
                                    SetFocusOnError="true">
                                </asp:RegularExpressionValidator>
                            </td>
                            <td align="left" valign="top">
                                To
                            </td>
                            <td align="center" valign="top">
                                :
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtEvent_Date_To" runat="server" Width="150px" SkinID="txtDate"
                                    MaxLength="10"></asp:TextBox>
                                <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtEvent_Date_To', 'mm/dd/y');"
                                    onmouseover="javascript:this.style.cursor='hand';" alt="" src="../Images/iconPicDate.gif"
                                    align="middle" id="img4" />
                                <br />
                                <asp:RegularExpressionValidator ID="revtxtEvent_Date_To" runat="server" ControlToValidate="txtEvent_Date_To"
                                    ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                    ErrorMessage="To Event Date is Not Valid Date" Display="none"
                                    ValidationGroup="vsErrorGroup" SetFocusOnError="true">
                                </asp:RegularExpressionValidator>
                                <asp:CompareValidator ID="cmptxtEvent_Date_To" runat="server" ControlToValidate="txtEvent_Date_To"
                                    ControlToCompare="txtEvent_Date_From" ValidationGroup="vsErrorGroup"
                                    Display="None" Type="Date" Operator="GreaterThanEqual" ErrorMessage="Event Date To must be greater than or equal to from date" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                Actionable Event to be Included in Grid
                            </td>
                             <td align="left" valign="top">
                                 :
                            </td>
                             <td align="left" valign="top">
                                 <asp:RadioButtonList ID="rdoStatus_Sonic" runat="server" Width="100%">
                                    <asp:ListItem Text="Open" Value="O" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Closed" Value="C"></asp:ListItem>
                                    <asp:ListItem Text="All" Value="A"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td colspan="3">
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
                    <asp:Button runat="server" ID="btnSearch" Text="Search" ValidationGroup="vsErrorGroup"
                        OnClick="btnSearch_Click"  />
                    &nbsp;&nbsp;
                    <asp:Button runat="server" ID="btnAdd" Text=" Add New " OnClick="btnAdd_Click" />
                    &nbsp;&nbsp;
                    <asp:Button runat="server" ID="btnClear" Text=" Clear " 
                        OnClick="btnSearchAgain_Click" /> 
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
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
                            <td class="Spacer" style="height: 10px;">
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                &nbsp;<span class="heading">Event Search Results</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                &nbsp; &nbsp;<asp:Label ID="lblNumber" runat="server" Text="0"></asp:Label>&nbsp;Events
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
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 5px;" align="left">
                                <div style="overflow-x: scroll; overflow-y: none; text-align: left; width: 999px;"
                                    id="dvSearchResult" runat="server">
                                    <asp:GridView ID="gvEvent" runat="server" GridLines="None" CellPadding="4" CellSpacing="0"
                                        AutoGenerateColumns="false" AllowSorting="true" Width="1130px" EnableTheming="false"
                                        OnRowCommand="gvEvent_RowCommand" OnRowCreated="gvEvent_RowCreated" OnSorting="gvEvent_Sorting"
                                        OnRowDataBound="gvEvent_RowDataBound">
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
                                                <ItemStyle Width="130px" HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnSelect" CommandName="SelectEvent" CommandArgument='<%#Eval("PK_Event") + "," +Eval("FK_Incident")%>'
                                                        runat="server" CausesValidation="false" Text="Select" ToolTip="Select Event" />&nbsp;&nbsp;
                                                    <asp:LinkButton ID="btnOpen" CommandName="OpenEvent" CommandArgument='<%#Eval("PK_Event") + "," +Eval("FK_Incident")%>'
                                                        runat="server" CausesValidation="false" Text="Open" ToolTip="Open Event" />&nbsp;&nbsp;
                                                    <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" CommandName="DeleteEvent" 
                                                        ToolTip="Delete Event" CommandArgument='<%#Eval("PK_Event")%>' CausesValidation="false"
                                                        OnClientClick="return ConfirmDelete();" />&nbsp;&nbsp;
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Event Number" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                SortExpression="Event_Number">
                                                <ItemStyle Width="100px" />
                                                <ItemTemplate>
                                                    <%# Eval("Event_Number")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ACI Event ID" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                SortExpression="ACI_EventID">
                                                <ItemStyle Width="150px" />
                                                <ItemTemplate>
                                                    <%# Eval("ACI_EventID")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Event Date" HeaderStyle-HorizontalAlign="Left"
                                                ItemStyle-HorizontalAlign="Left" SortExpression="Event_Start_Date">
                                                <ItemStyle Width="150px" />
                                                <ItemTemplate>
                                                    <%# Eval("Event_Start_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Event_Start_Date"))) : ""%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DBA" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                SortExpression="FK_LU_Location">
                                                <ItemStyle Width="200px" />
                                                <ItemTemplate>
                                                    <%# Eval("FK_LU_Location")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Location Code" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                SortExpression="Location_Code">
                                                <ItemStyle Width="100px" />
                                                <ItemTemplate>
                                                    <%# Eval("Location_Code")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Event Status" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                SortExpression="Event_Status">
                                                <ItemStyle Width="150px" />
                                                <ItemTemplate>
                                                    <%# Eval("Event_Status")%>
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
                            <td style="text-align: left;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnSearchAgain" runat="server" Text="Search Again" OnClick="btnSearchAgain_Click" />
                                <asp:Button ID="btnSaveToExcel" runat="server" Text="Save to Excel" OnClick="btnSaveToExcel_Click" />
                                <%--<asp:Button ID="btnAdd" runat="server" Text="  Add New " OnClick="btnAdd_Click" />--%>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

