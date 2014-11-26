<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="EventSearch.aspx.cs" Inherits="SONIC_CalAtlantic_EventSearch" %>

<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>JavaScript/JFunctions.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar.js"></script>
    <script type="text/javascript">
    </script>
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    <asp:Panel ID="pnlSearchFilter" runat="server" Width="100%">
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
                            <td align="left" width="18%" valign="top">
                                Event Type
                            </td>
                            <td align="center" width="2%" valign="top">
                                :
                            </td>
                            <td align="left" valign="top" width="30%">
                                <asp:DropDownList ID="drpEventType" runat="server" Width="180px">
                                </asp:DropDownList>
                            </td>
                            <td align="left" width="18%" valign="top">
                                Event Number
                            </td>
                            <td align="center" width="2%" valign="top">
                                :
                            </td>
                            <td align="left" valign="top" width="30%">
                                <asp:TextBox ID="txtEventNumber" runat="server" MaxLength="20" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                Camera Number
                            </td>
                            <td align="center" valign="top">
                                :
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtCameraNumber" runat="server" MaxLength="20" Width="200px"></asp:TextBox>
                            </td>
                            <td align="left" valign="top">
                                Operator
                            </td>
                            <td align="center" valign="top">
                                :
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtOperator" runat="server" MaxLength="20" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                Alarm Type
                            </td>
                            <td align="center" valign="top">
                                :
                            </td>
                            <td align="left" valign="top">
                                <asp:DropDownList ID="drpAlarmType" runat="server" Width="205px">
                                </asp:DropDownList>
                            </td>
                            <td align="left" valign="top">
                                Camera Type
                            </td>
                            <td align="center" valign="top">
                                :
                            </td>
                            <td align="left" valign="top">
                                <asp:DropDownList ID="drpCameraType" runat="server" Width="205px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                Alarm Number
                            </td>
                            <td align="center" valign="top">
                                :
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtAlarmNumber" runat="server" MaxLength="20" Width="200px"></asp:TextBox>
                            </td>
                            <td align="left" valign="top" colspan="3">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                Alarm Time
                            </td>
                            <td align="center" valign="top">
                                :
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtAlarmTime" runat="server" MaxLength="20" Width="200px"></asp:TextBox>
                                <uc:MaskedEditExtender ID="mskTimeAlarm" runat="server" AutoComplete="true" MaskType="Time"
                                    Mask="99:99" TargetControlID="txtAlarmTime" AcceptNegative="Left" DisplayMoney="Left"
                                    MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                    CultureName="en-US">
                                </uc:MaskedEditExtender>
                                <asp:RegularExpressionValidator ID="rvIncidentTime" runat="server" ControlToValidate="txtAlarmTime"
                                    ValidationExpression="^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$"
                                    ErrorMessage="Alarm Time is Not Valid Time" Display="none" ValidationGroup="vsErrorGroup"
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
                                <asp:TextBox ID="txtToAlarmTime" runat="server" MaxLength="20" Width="200px"></asp:TextBox>
                                <uc:MaskedEditExtender ID="MaskedEditExtender5" runat="server" AutoComplete="true"
                                    MaskType="Time" Mask="99:99" TargetControlID="txtToAlarmTime" AcceptNegative="Left"
                                    DisplayMoney="Left" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                    OnInvalidCssClass="MaskedEditError" CultureName="en-US">
                                </uc:MaskedEditExtender>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtToAlarmTime"
                                    ValidationExpression="^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$"
                                    ErrorMessage="Alarm Time is Not Valid Time" Display="none" ValidationGroup="vsErrorGroup"
                                    SetFocusOnError="true" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                Photo Date
                            </td>
                            <td align="center" valign="top">
                                :
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtPhotoDate" runat="server" Width="180px" SkinID="txtDate" MaxLength="10"></asp:TextBox>
                                <img onclick="return showCalendar('<%= txtPhotoDate.ClientID %>', 'mm/dd/y');" onmouseover="javascript:this.style.cursor='hand';"
                                    alt="" src="<%=AppConfig.SiteURL%>Images/iconPicDate.gif" align="middle" id="img1" />
                                <br />
                                <asp:RegularExpressionValidator ID="rvPhotoDate" runat="server" ControlToValidate="txtPhotoDate"
                                    ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                    ErrorMessage="Photo Date is Not Valid Date" Display="none" ValidationGroup="vsErrorGroup"
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
                                <asp:TextBox ID="txtToPhotoDate" runat="server" Width="180px" SkinID="txtDate" MaxLength="10"></asp:TextBox>
                                <img onclick="return showCalendar('<%= txtToPhotoDate.ClientID %>', 'mm/dd/y');"
                                    onmouseover="javascript:this.style.cursor='hand';" alt="" src="<%=AppConfig.SiteURL%>Images/iconPicDate.gif"
                                    align="middle" id="img2" />
                                <br />
                                <asp:RegularExpressionValidator ID="rvToPhotoDate" runat="server" ControlToValidate="txtToPhotoDate"
                                    ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                    ErrorMessage="To Photo Date is Not Valid Date" Display="none" ValidationGroup="vsErrorGroup"
                                    SetFocusOnError="true">
                                </asp:RegularExpressionValidator>
                                <asp:CompareValidator ID="cvPhotoDate" runat="server" ControlToValidate="txtToPhotoDate"
                                    ControlToCompare="txtPhotoDate" ValidationGroup="vsErrorGroup" Display="None"
                                    Type="Date" Operator="GreaterThanEqual" ErrorMessage="Photo Date To must be greater than or equal to from date" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                Investigation Report Date
                            </td>
                            <td align="center" valign="top">
                                :
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtInvestigationReportDate" runat="server" Width="180px" SkinID="txtDate"
                                    MaxLength="10"></asp:TextBox>
                                <img onclick="return showCalendar('<%= txtInvestigationReportDate.ClientID %>', 'mm/dd/y');"
                                    onmouseover="javascript:this.style.cursor='hand';" alt="" src="<%=AppConfig.SiteURL%>Images/iconPicDate.gif"
                                    align="middle" id="img3" />
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtInvestigationReportDate"
                                    ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                    ErrorMessage="Investigation Report Date is Not Valid Date" Display="none" ValidationGroup="vsErrorGroup"
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
                                <asp:TextBox ID="txtToInvestigationReportDate" runat="server" Width="180px" SkinID="txtDate"
                                    MaxLength="10"></asp:TextBox>
                                <img onclick="return showCalendar('<%= txtToInvestigationReportDate.ClientID %>', 'mm/dd/y');"
                                    onmouseover="javascript:this.style.cursor='hand';" alt="" src="<%=AppConfig.SiteURL%>Images/iconPicDate.gif"
                                    align="middle" id="img4" />
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtToInvestigationReportDate"
                                    ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                    ErrorMessage="To Investigation Report Date is Not Valid Date" Display="none"
                                    ValidationGroup="vsErrorGroup" SetFocusOnError="true">
                                </asp:RegularExpressionValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtToInvestigationReportDate"
                                    ControlToCompare="txtInvestigationReportDate" ValidationGroup="vsErrorGroup"
                                    Display="None" Type="Date" Operator="GreaterThanEqual" ErrorMessage="Investigation Report Date To must be greater than or equal to from date" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                Event Report Date
                            </td>
                            <td align="center" valign="top">
                                :
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtEventReportDate" runat="server" Width="180px" SkinID="txtDate"
                                    MaxLength="10"></asp:TextBox>
                                <img onclick="return showCalendar('<%= txtEventReportDate.ClientID %>', 'mm/dd/y');"
                                    onmouseover="javascript:this.style.cursor='hand';" alt="" src="<%=AppConfig.SiteURL%>Images/iconPicDate.gif"
                                    align="middle" id="img5" />
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEventReportDate"
                                    ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                    ErrorMessage="Event Report Date is Not Valid Date" Display="none" ValidationGroup="vsErrorGroup"
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
                                <asp:TextBox ID="txtToEventReportDate" runat="server" Width="180px" SkinID="txtDate"
                                    MaxLength="10"></asp:TextBox>
                                <img onclick="return showCalendar('<%= txtToEventReportDate.ClientID %>', 'mm/dd/y');"
                                    onmouseover="javascript:this.style.cursor='hand';" alt="" src="<%=AppConfig.SiteURL%>Images/iconPicDate.gif"
                                    align="middle" id="img6" />
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtToEventReportDate"
                                    ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                    ErrorMessage="To Event Report Date is Not Valid Date" Display="none" ValidationGroup="vsErrorGroup"
                                    SetFocusOnError="true">
                                </asp:RegularExpressionValidator>
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtToEventReportDate"
                                    ControlToCompare="txtEventReportDate" ValidationGroup="vsErrorGroup" Display="None"
                                    Type="Date" Operator="GreaterThanEqual" ErrorMessage="Event Report Date To must be greater than or equal to from date" />
                            </td>
                        </tr>
                         <tr>
                            <td align="left" valign="top">
                                Date Opened
                            </td>
                            <td align="center" valign="top">
                                :
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtDate_Opened" runat="server" Width="180px" SkinID="txtDate" MaxLength="10"></asp:TextBox>
                                <img onclick="return showCalendar('<%= txtDate_Opened.ClientID %>', 'mm/dd/y');" onmouseover="javascript:this.style.cursor='hand';"
                                    alt="" src="<%=AppConfig.SiteURL%>Images/iconPicDate.gif" align="middle" id="img7" />
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtDate_Opened"
                                    ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                    ErrorMessage="Date Opened is Not Valid Date" Display="none" ValidationGroup="vsErrorGroup"
                                    SetFocusOnError="true">
                                </asp:RegularExpressionValidator>
                            </td>
                            <td align="left" valign="top">
                                Event Occurance Date
                            </td>
                            <td align="center" valign="top">
                                :
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtEvent_Occurance_Date" runat="server" Width="180px" SkinID="txtDate" MaxLength="10"></asp:TextBox>
                                <img onclick="return showCalendar('<%= txtEvent_Occurance_Date.ClientID %>', 'mm/dd/y');" onmouseover="javascript:this.style.cursor='hand';"
                                    alt="" src="<%=AppConfig.SiteURL%>Images/iconPicDate.gif" align="middle" id="img8" />
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtEvent_Occurance_Date"
                                    ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                    ErrorMessage="Event Occurance Date is Not Valid Date" Display="none" ValidationGroup="vsErrorGroup"
                                    SetFocusOnError="true">
                                </asp:RegularExpressionValidator>
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
                        OnClick="btnSearch_Click" CausesValidation="true" />
                    &nbsp;&nbsp;
                    <asp:Button runat="server" ID="btnClear" Text=" Clear " CausesValidation="false"
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
                                        AutoGenerateColumns="false" AllowSorting="true" Width="999px" EnableTheming="false"
                                        OnRowCommand="gvEvent_RowCommand" OnRowCreated="gvEvent_RowCreated" OnSorting="gvEvent_Sorting">
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
                                            <asp:TemplateField HeaderText="Event Number" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                SortExpression="Event_Number">
                                                <ItemStyle Width="125px" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkbtnEventNumber" runat="server" CommandName="ViewEvent" CommandArgument='<%#Eval("PK_Event") + "," +Eval("FK_Incident")%>'
                                                        CausesValidation="false">
                                                    <%# Eval("Event_Number")%>
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Event Description" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                SortExpression="Event_Desc">
                                                <ItemStyle Width="100px" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkbtnEvent_Desc" runat="server" CommandName="ViewEvent" CommandArgument='<%#Eval("PK_Event") + "," +Eval("FK_Incident")%>'
                                                        CausesValidation="false">
                                                        <%# Eval("Event_Desc")%>
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Location" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                SortExpression="FK_LU_Location">
                                                <ItemStyle Width="125px" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkbtnFK_LU_Location" runat="server" CommandName="ViewEvent" CommandArgument='<%#Eval("PK_Event") + "," +Eval("FK_Incident")%>'
                                                        CausesValidation="false">
                                                        <%# Eval("FK_LU_Location")%>
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Company" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                SortExpression="Company">
                                                <ItemStyle Width="125px" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkbtnCompany" runat="server" CommandName="ViewEvent" CommandArgument='<%#Eval("PK_Event") + "," +Eval("FK_Incident")%>'
                                                        CausesValidation="false">
                                                        <%# Eval("Company")%>
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Investigation Report Date" HeaderStyle-HorizontalAlign="Left"
                                                ItemStyle-HorizontalAlign="Left" SortExpression="Investigation_Report_Date">
                                                <ItemStyle Width="145px" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkbtnInvestigationReportDate" runat="server" CommandName="ViewEvent"
                                                        CommandArgument='<%#Eval("PK_Event") + "," +Eval("FK_Incident")%>' CausesValidation="false">
                                                        <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Investigation_Report_Date"))%>
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Event Report Date" HeaderStyle-HorizontalAlign="Left"
                                                ItemStyle-HorizontalAlign="Left" SortExpression="Event_Report_Date">
                                                <ItemStyle Width="135px" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkbtnEventReportDate" runat="server" CommandName="ViewEvent"
                                                        CommandArgument='<%#Eval("PK_Event") + "," +Eval("FK_Incident")%>' CausesValidation="false">
                                                        <%# clsGeneral.FormatDBNullDateToDisplay(Eval("Event_Report_Date"))%>
                                                    </asp:LinkButton>
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
