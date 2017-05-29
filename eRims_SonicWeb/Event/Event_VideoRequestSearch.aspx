<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Event_VideoRequestSearch.aspx.cs" Inherits="Event_Event_VideoRequestSearch" %>

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

    function ResonRequestPopup() {
        var winHeight = 500;
        var winWidth = 500;

        obj = window.open("ACI_Approve_Deny.aspx", 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
        obj.focus();
    }

    function SelectValue(PK_Event_Video_Tracking_Request, strsid, strstatus)
    {
        var winHeight = 500;
        var winWidth = 800;
        obj = window.open("ACI_Approve_Deny.aspx?tid=" + PK_Event_Video_Tracking_Request + "&sid=" + strsid + "&status=" + strstatus + "&grp=0&aid=0&ispop=1", 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
        obj.focus();
        return false;
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
                    <b>Video Request Search</b>
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
                                Request Number
                            </td>
                            <td align="center" valign="top">
                                :
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtRequest_Number" runat="server" MaxLength="20" Width="170px"></asp:TextBox>
                            </td>
                            <td align="left" valign="top">
                                Request Type
                            </td>
                            <td align="center" valign="top">
                                :
                            </td>
                            <td align="left" valign="top">
                                <asp:DropDownList ID="drpRequestType" runat="server" Width="175px" SkinID="dropGen">
                                </asp:DropDownList>
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
                                Status
                            </td>
                            <td align="center" width="2%" valign="top">
                                :
                            </td>
                            <td align="left" valign="top" width="32%">
                                <asp:DropDownList ID="drpStatus" runat="server" Width="175px" SkinID="dropGen">
                                </asp:DropDownList>
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
                    <asp:Button runat="server" ID="btnAdd" Text="Add 3rd Party Video Request" OnClick="btnAdd_Click" />
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
                                &nbsp;<span class="heading">Video Request Search Results</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                &nbsp; &nbsp;<asp:Label ID="lblNumber" runat="server" Text="0"></asp:Label>&nbsp;Video Request
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
                                    <asp:GridView ID="gvVideo" runat="server" GridLines="None" CellPadding="4" CellSpacing="0"
                                        AutoGenerateColumns="false" AllowSorting="true" Width="1000px" EnableTheming="false"
                                        OnRowCommand="gvVideo_RowCommand" OnRowCreated="gvVideo_RowCreated" OnSorting="gvVideo_Sorting"
                                        OnRowDataBound="gvVideo_RowDataBound" DataKeyNames="PK_Event_Video_Tracking_Request">
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
                                                <ItemStyle Width="180px" HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnOpen" CommandName="OpenVideo" CommandArgument='<%#Eval("PK_Event_Video_Tracking_Request") + "," +Eval("FK_Event")%>'
                                                        runat="server" CausesValidation="false" Text="Open" ToolTip="Open" />&nbsp;&nbsp;
                                                    <asp:LinkButton ID="btnApporve" runat="server" Text="Approve" CommandName="ApproveVideo" 
                                                        ToolTip="Approve Video" CommandArgument='<%#Eval("PK_Event_Video_Tracking_Request")%>' CausesValidation="false" />&nbsp;&nbsp;
                                                    <asp:LinkButton ID="btnDeny" runat="server" Text="Deny" CommandName="DenyVideo" 
                                                        ToolTip="Deny Video" CommandArgument='<%#Eval("PK_Event_Video_Tracking_Request")%>' CausesValidation="false" />&nbsp;&nbsp;
                                                    <asp:LinkButton ID="btnEdit" CommandName="EditVideo" CommandArgument='<%#Eval("PK_Event_Video_Tracking_Request") + "," +Eval("FK_Event")%>'
                                                        runat="server" CausesValidation="false" Text="Edit" ToolTip="Edit" />&nbsp;&nbsp;
                                                    <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" CommandName="DeleteVideo" 
                                                        ToolTip="Delete Event" CommandArgument='<%#Eval("PK_Event_Video_Tracking_Request")%>' CausesValidation="false"
                                                        OnClientClick="return ConfirmDelete();" />&nbsp;&nbsp;
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                SortExpression="Status">
                                                <ItemStyle Width="150px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status")%>'></asp:Label>
                                                    <asp:Label ID="lblIs_Legal" runat="server" Text='<%# Eval("IS_Legal")%>' Style="display:none"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Request Number" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                SortExpression="Request_Number">
                                                <ItemStyle Width="150px" />
                                                <ItemTemplate>
                                                    <%# Eval("Request_Number")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Request Type" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                SortExpression="Request_Type">
                                                <ItemStyle Width="150px" />
                                                <ItemTemplate>
                                                    <%# Eval("Request_Type")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Event Date" HeaderStyle-HorizontalAlign="Left"
                                                ItemStyle-HorizontalAlign="Left" SortExpression="Date_of_Event">
                                                <ItemStyle Width="150px" />
                                                <ItemTemplate>
                                                    <%# Eval("Date_of_Event") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_of_Event"))) : ""%>
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
                                                <ItemStyle Width="150px" />
                                                <ItemTemplate>
                                                    <%# Eval("Location_Code")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Requsted By" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                SortExpression="Requsted_By">
                                                <ItemStyle Width="150px" />
                                                <ItemTemplate>
                                                    <%# Eval("Requsted_By")%>
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
                                <asp:Button ID="hdnbtnRefresh" runat="server" OnClick="hdnbtnRefresh_Click" Style="display:none;" />
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

