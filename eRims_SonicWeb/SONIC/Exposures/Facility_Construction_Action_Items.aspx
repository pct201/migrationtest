<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Facility_Construction_Action_Items.aspx.cs" Inherits="SONIC_Exposures_Facility_Construction_Action_Items" %>

<%@ Register Src="~/Controls/ExposuresTab/ExposuresTab.ascx" TagName="CtlTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposureInfo/ExposureInfo.ascx" TagName="ctrlExposureInfo"
    TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <asp:UpdatePanel runat="server" ID="UpdSearch">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td class="groupHeaderBar" align="left">&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="Spacer" style="height: 20px;"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel runat="server" ID="pnlSearch">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td colspan="2" width="100%">&nbsp;&nbsp;<span class="heading">Construction Project Management Action Items Search Screen</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Spacer" style="height: 10px;"></td>
                                </tr>
                                <tr>
                                    <td class="Spacer" style="width: 50px;"></td>
                                    <td>
                                        <table cellpadding="3" cellspacing="1" width="100%" border="0">
                                            <tr>
                                                <td align="left" style="width: 16%">Location
                                                </td>
                                                <td align="center" style="width: 4%">:
                                                </td>
                                                <td align="left" style="width: 30%">
                                                    <asp:DropDownList ID="ddlLocation" SkinID="Default" Width="180px" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left" style="width: 16%">Project Number
                                                </td>
                                                <td align="center" style="width: 4%">:
                                                </td>
                                                <td align="left" style="width: 30%">
                                                    <asp:DropDownList ID="ddlProjectNumber" SkinID="Default" Width="180px" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Assigned By
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlAssignedBy" SkinID="Default" Width="180px" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>Assigned To
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlAssignedTo" SkinID="Default" Width="180px" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Completed By
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlCompletedBy" SkinID="Default" Width="180px" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left">Status
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <asp:RadioButtonList ID="rdlStatus" SkinID="rdlStatus" runat="server">
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Action Item Type
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlActionItemType" SkinID="Default" Width="180px" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left"></td>
                                                <td align="center"></td>
                                                <td align="left"></td>
                                            </tr>
                                            <tr>
                                                <td align="left">Date Due From
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtDateDueFrom" runat="server" SkinID="txtDate"></asp:TextBox>
                                                    <img alt="Date Due From" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDateDueFrom', 'mm/dd/y');"
                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                        align="middle" />
                                                    <asp:RangeValidator ID="revStartRangeDate" ControlToValidate="txtDateDueFrom"
                                                        MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="Date Due From is not Valid."
                                                        runat="server" ValidationGroup="vsErrorGroup" Display="none" />
                                                </td>
                                                <td align="left">Date Due To
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtDateDueTo" runat="server" SkinID="txtDate"></asp:TextBox>
                                                    <img alt="Date Due To" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDateDueTo', 'mm/dd/y');"
                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                        align="middle" />
                                                    <asp:RangeValidator ID="RangeValidator1" ControlToValidate="txtDateDueTo"
                                                        MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="Date Due To is not Valid."
                                                        runat="server" ValidationGroup="vsErrorGroup" Display="none" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Date Assigned From
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtDateAssignedFrom" runat="server" SkinID="txtDate"></asp:TextBox>
                                                    <img alt="Date Assigned To" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDateAssignedFrom', 'mm/dd/y');"
                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                        align="middle" />
                                                    <asp:RangeValidator ID="RangeValidator2" ControlToValidate="txtDateDueFrom"
                                                        MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="Date Assigned To is not Valid."
                                                        runat="server" ValidationGroup="vsErrorGroup" Display="none" />
                                                </td>
                                                <td align="left">Date Assigned To
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtDateAssignedTo" runat="server" SkinID="txtDate"></asp:TextBox>
                                                    <img alt="Date Assigned To" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDateAssignedTo', 'mm/dd/y');"
                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                        align="middle" />
                                                    <asp:RangeValidator ID="RangeValidator3" ControlToValidate="txtDateAssignedTo"
                                                        MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="Date Assigned To is not Valid."
                                                        runat="server" ValidationGroup="vsErrorGroup" Display="none" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Date Completed From
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtDateCompletedFrom" runat="server" SkinID="txtDate"></asp:TextBox>
                                                    <img alt="Date Due From" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDateCompletedFrom', 'mm/dd/y');"
                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                        align="middle" />
                                                    <asp:RangeValidator ID="RangeValidator4" ControlToValidate="txtDateCompletedFrom"
                                                        MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="Date Completed From is not Valid."
                                                        runat="server" ValidationGroup="vsErrorGroup" Display="none" />
                                                </td>
                                                <td align="left">Date Completed To
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtDateCompletedTo" runat="server" SkinID="txtDate"></asp:TextBox>
                                                    <img alt="Date Due From" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDateCompletedTo', 'mm/dd/y');"
                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                        align="middle" />
                                                    <asp:RangeValidator ID="RangeValidator5" ControlToValidate="txtDateCompletedTo"
                                                        MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="Date Due To is not Valid."
                                                        runat="server" ValidationGroup="vsErrorGroup" Display="none" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                            <tr>
                                                <td align="center" style="height: 24px">
                                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CausesValidation="true" ValidationGroup="vsErrorGroup"
                                                        ToolTip="Search" OnClick="btnSearch_Click" OnClientClick="return CheckDates();" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <asp:Panel runat="server" ID="Panel1">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td colspan="2" width="100%">&nbsp;&nbsp;<span class="heading">Construction Project Management Action Items Screen</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Spacer" style="height: 10px;"></td>
                                </tr>
                                <tr>
                                    <td class="Spacer" style="width: 50px;"></td>
                                    <td>
                                        <table cellpadding="3" cellspacing="1" width="100%" border="0">
                                            <tr>
                                                <td align="left" style="width: 16%">Project Number
                                                </td>
                                                <td align="center" style="width: 4%">:
                                                </td>
                                                <td align="left" style="width: 30%">
                                                    <asp:DropDownList ID="DropDownList1" SkinID="Default" Width="180px" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left" style="width: 16%">Action Item Category
                                                </td>
                                                <td align="center" style="width: 4%">:
                                                </td>
                                                <td align="left" style="width: 30%">
                                                    <asp:DropDownList ID="DropDownList2" SkinID="Default" Width="180px" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Date Assigned
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="TextBox3" runat="server" SkinID="txtDate"></asp:TextBox>
                                                    <img alt="Date Due From" onclick="return showCalendar('ctl00_ContentPlaceHolder1_TextBox3', 'mm/dd/y');"
                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                        align="middle" />
                                                    <asp:RangeValidator ID="RangeValidator8" ControlToValidate="TextBox3"
                                                        MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="Date Due From is not Valid."
                                                        runat="server" ValidationGroup="vsErrorGroup" Display="none" />
                                                </td>
                                                <td>Assigned By
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DropDownList4" SkinID="Default" Width="180px" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Date Due
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="TextBox4" runat="server" SkinID="txtDate"></asp:TextBox>
                                                    <img alt="Date Due From" onclick="return showCalendar('ctl00_ContentPlaceHolder1_TextBox4', 'mm/dd/y');"
                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                        align="middle" />
                                                    <asp:RangeValidator ID="RangeValidator9" ControlToValidate="TextBox4"
                                                        MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="Date Due From is not Valid."
                                                        runat="server" ValidationGroup="vsErrorGroup" Display="none" />
                                                </td>
                                                <td align="left">Assigned To
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left"></td>
                                            </tr>
                                            <tr>
                                                <td align="left">Date Completed
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="TextBox5" runat="server" SkinID="txtDate"></asp:TextBox>
                                                    <img alt="Date Due From" onclick="return showCalendar('ctl00_ContentPlaceHolder1_TextBox5', 'mm/dd/y');"
                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                        align="middle" />
                                                    <asp:RangeValidator ID="RangeValidator10" ControlToValidate="TextBox5"
                                                        MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="Date Due From is not Valid."
                                                        runat="server" ValidationGroup="vsErrorGroup" Display="none" />
                                                </td>
                                                <td align="left">Completed By</td>
                                                <td align="center">:</td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DropDownList7" SkinID="Default" Width="180px" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Status
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <asp:RadioButtonList ID="RadioButtonList1" SkinID="rdlStatus" runat="server">
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td align="left">Status Date
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="TextBox2" runat="server" SkinID="txtDate"></asp:TextBox>
                                                    <img alt="Date Due To" onclick="return showCalendar('ctl00_ContentPlaceHolder1_TextBox2', 'mm/dd/y');"
                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                        align="middle" />
                                                    <asp:RangeValidator ID="RangeValidator7" ControlToValidate="TextBox2"
                                                        MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="Date Due To is not Valid."
                                                        runat="server" ValidationGroup="vsErrorGroup" Display="none" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Action Item Grid<br />
                                                    <asp:LinkButton ID="LinkButton1" runat="server">Add</asp:LinkButton>
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left" colspan="4">Grid
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Alert Recipient Grid<br />
                                                    <br />
                                                    <asp:LinkButton ID="LinkButton2" runat="server">Add</asp:LinkButton>
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left" colspan="4">Grid
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:LinkButton ID="lnkViewActionItemCalendar" runat="server">View Action Item Calendar</asp:LinkButton>
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left"></td>
                                            </tr>

                                            <tr>
                                                <td colspan="2" align="center">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                        <tr>
                                                            <td align="center" style="height: 24px">
                                                                <asp:Button ID="Button1" runat="server" Text="Search" CausesValidation="true" ValidationGroup="vsErrorGroup"
                                                                    ToolTip="Search" OnClick="btnSearch_Click" OnClientClick="return CheckDates();" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <asp:Panel runat="server" ID="Panel2">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td colspan="2" width="100%">&nbsp;&nbsp;<span class="heading">Construction Project Management Action Items Screen</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Spacer" style="height: 10px;"></td>
                                </tr>
                                <tr>
                                    <td class="Spacer" style="width: 50px;"></td>
                                    <td>
                                        <table cellpadding="3" cellspacing="1" width="100%" border="0">
                                            <tr>
                                                <td align="left" style="width: 16%">Project Number
                                                </td>
                                                <td align="center" style="width: 4%">:
                                                </td>
                                                <td align="left" style="width: 30%">
                                                    <asp:DropDownList ID="DropDownList3" SkinID="Default" Width="180px" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left" style="width: 16%">Action Item Type
                                                </td>
                                                <td align="center" style="width: 4%">:
                                                </td>
                                                <td align="left" style="width: 30%">
                                                    <asp:DropDownList ID="DropDownList5" SkinID="Default" Width="180px" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Action Item Author
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="TextBox1" runat="server" SkinID="txtDate"></asp:TextBox>
                                                </td>
                                                <td>Action Item Date
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="TextBox9" runat="server" SkinID="txtDate"></asp:TextBox>
                                                    <img alt="Date Due From" onclick="return showCalendar('ctl00_ContentPlaceHolder1_TextBox9', 'mm/dd/y');"
                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                        align="middle" />
                                                    <asp:RangeValidator ID="RangeValidator6" ControlToValidate="TextBox9"
                                                        MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="Date Due From is not Valid."
                                                        runat="server" ValidationGroup="vsErrorGroup" Display="none" />
                                                </td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">Action Item Description
                                    </td>
                                    <td align="center">:
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="TextBox6" runat="server" colspan="4"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <asp:Panel runat="server" ID="Panel5">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td colspan="2" width="100%">&nbsp;&nbsp;<span class="heading">Construction Project Management Meetings and Walkthroughs</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Spacer" style="height: 10px;"></td>
                                </tr>
                                <tr>
                                    <td class="Spacer" style="width: 50px;"></td>
                                    <td>
                                        <table cellpadding="3" cellspacing="1" width="100%" border="0">
                                            <tr>
                                                <td align="left" style="width: 16%">Project Number
                                                </td>
                                                <td align="center" style="width: 4%">:
                                                </td>
                                                <td colspan="4" align="left" style="width: 30%">
                                                    <asp:DropDownList ID="DropDownList12" SkinID="Default" Width="180px" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Meeting Date
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="TextBox13" runat="server" SkinID="txtDate"></asp:TextBox>
                                                    <img alt="Date Due From" onclick="return showCalendar('ctl00_ContentPlaceHolder1_TextBox13', 'mm/dd/y');"
                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                        align="middle" />
                                                    <asp:RangeValidator ID="RangeValidator14" ControlToValidate="TextBox13"
                                                        MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="Date Due From is not Valid."
                                                        runat="server" ValidationGroup="vsErrorGroup" Display="none" />
                                                </td>
                                                <td>Meeting Time (HH:MM)
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
                                                </td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">Meeting Location
                                    </td>
                                    <td align="center">:
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlMeetingLocation" runat="server"></asp:DropDownList>
                                    </td>
                                    <td align="left">Meeting Type
                                    </td>
                                    <td align="center">:
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DropDownList13" runat="server"></asp:DropDownList>
                                    </td>
                                </tr>
                                 <tr>
                                    <td align="left">Meeting Attendees Grid<br /><asp:LinkButton ID="lnk" runat="server" />
                                    </td>
                                    <td align="center">:
                                    </td>
                                    <td align="left" colspan="4">
                                        Meeting Attendees Grid
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">Meeting Notes
                                    </td>
                                    <td align="center">:
                                    </td>
                                    <td align="left" colspan="4">
                                        <asp:TextBox ID="txtMeetingNotes" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <asp:Panel runat="server" ID="Panel3">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td colspan="2" width="100%">&nbsp;&nbsp;<span class="heading">Construction Project Management Action Items Screen</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Spacer" style="height: 10px;"></td>
                                </tr>
                                <tr>
                                    <td class="Spacer" style="width: 50px;"></td>
                                    <td>
                                        <table cellpadding="3" cellspacing="1" width="100%" border="0">
                                            <tr>
                                                <td align="left" style="width: 16%">Project Number
                                                </td>
                                                <td align="center" style="width: 4%">:
                                                </td>
                                                <td align="left" style="width: 30%">
                                                    <asp:DropDownList ID="DropDownList6" SkinID="Default" Width="180px" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left" style="width: 16%">Recipient
                                                </td>
                                                <td align="center" style="width: 4%">:
                                                </td>
                                                <td align="left" style="width: 30%">
                                                    <asp:DropDownList ID="DropDownList8" SkinID="Default" Width="180px" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Recipient Method
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                                                </td>
                                                <td>Send Alert Before Date Due (in Days)
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                                                </td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">Action Item Description
                                    </td>
                                    <td align="center">:
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="TextBox10" runat="server" colspan="4"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <asp:Panel runat="server" ID="Panel4">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td colspan="2" width="100%">&nbsp;&nbsp;<span class="heading">Construction Project Management Meetings and Walkthroughs Search Screen</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Spacer" style="height: 10px;"></td>
                                </tr>
                                <tr>
                                    <td class="Spacer" style="width: 50px;"></td>
                                    <td>
                                        <table cellpadding="3" cellspacing="1" width="100%" border="0">
                                            <tr>
                                                <td align="left" style="width: 16%">Location
                                                </td>
                                                <td align="center" style="width: 4%">:
                                                </td>
                                                <td align="left" style="width: 30%">
                                                    <asp:DropDownList ID="DropDownList9" SkinID="Default" Width="180px" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left" style="width: 16%">Project Number
                                                </td>
                                                <td align="center" style="width: 4%">:
                                                </td>
                                                <td align="left" style="width: 30%">
                                                    <asp:DropDownList ID="DropDownList10" SkinID="Default" Width="180px" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Meeting Date From
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                                                    <img alt="Date Due From" onclick="return showCalendar('ctl00_ContentPlaceHolder1_TextBox11', 'mm/dd/y');"
                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                        align="middle" />
                                                    <asp:RangeValidator ID="RangeValidator11" ControlToValidate="TextBox11"
                                                        MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="Date Due From is not Valid."
                                                        runat="server" ValidationGroup="vsErrorGroup" Display="none" />
                                                </td>
                                                <td>Meeting Date To
                                                </td>
                                                <td align="center">:
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                                                    <img alt="Date Due From" onclick="return showCalendar('ctl00_ContentPlaceHolder1_TextBox12', 'mm/dd/y');"
                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                        align="middle" />
                                                    <asp:RangeValidator ID="RangeValidator12" ControlToValidate="TextBox12"
                                                        MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="Date Due From is not Valid."
                                                        runat="server" ValidationGroup="vsErrorGroup" Display="none" />
                                                </td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">Meeting Type
                                    </td>
                                    <td align="center">:
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DropDownList11" SkinID="Default" Width="180px" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="PK_Facility_Construction_Action_Items">
                            <Columns>
                                <asp:TemplateField HeaderText="PK_Facility_Construction_Action_Items" InsertVisible="False" SortExpression="PK_Facility_Construction_Action_Items">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("PK_Facility_Construction_Action_Items") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_Due" SortExpression="Date_Due">
                                    <ItemTemplate>
                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("Date_Due") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_Completed" SortExpression="Date_Completed">
                                    <ItemTemplate>
                                        <asp:Label ID="Label10" runat="server" Text='<%# Bind("Date_Completed") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="Spacer" style="height: 20px;"></td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>

