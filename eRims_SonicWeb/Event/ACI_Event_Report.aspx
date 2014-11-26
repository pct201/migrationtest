<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="ACI_Event_Report.aspx.cs" Inherits="ACI_Event_Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="<%=AppConfig.SiteURL%>JavaScript/JFunctions.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Date_Validation.js"></script>
    <script language="javascript" type="text/javascript">
        function showAudit(divHeader, divGrid) {
            var divheight, i;

            divHeader.style.width = window.screen.availWidth - 225 + "px";
            divGrid.style.width = window.screen.availWidth - 225 + "px";

            divheight = divGrid.style.height;
            i = divheight.indexOf('px');

            if (i > -1)
                divheight = divheight.substring(0, i);
            if (divheight > (window.screen.availHeight - 350) && divGrid.style.height != "") {
                divGrid.style.height = window.screen.availHeight - 350;
            }
        }

        function ChangeScrollBar(f, s) {
            s.scrollTop = f.scrollTop;
            s.scrollLeft = f.scrollLeft;
        }
    </script>
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    <table width="100%" cellpadding="0" cellspacing="2">
        <tr>
            <td width="100%" class="Spacer" style="height: 3px;">
            </td>
        </tr>
        <tr>
            <td align="left" class="ghc" >
                <asp:Label ID="lblHeading" runat="server" Text="ACI Event Report"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 3px;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 3px;">
                &nbsp;
            </td>
        </tr>
        <tr runat="server" id="trCriteria">
            <td align="center" width="100%">
                <table border="0" cellpadding="5" cellspacing="1" width="80%" align="center">
                    <tr>
                        <td align="left" valign="top">
                            Date of Event
                        </td>
                        <td align="center" valign="top">
                            :
                        </td>
                        <td align="left" valign="top">
                            <asp:TextBox ID="txtFrom_Date_Of_Event" runat="server" Width="160px" SkinID="txtDate"  autocomplete="off"
                                MaxLength="10"></asp:TextBox>
                            <img onclick="return showCalendar('<%= txtFrom_Date_Of_Event.ClientID %>', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" alt="" src="../Images/iconPicDate.gif"
                                align="middle" id="img5" />
                            <br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtFrom_Date_Of_Event"
                                ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                ErrorMessage="Date of Event is Not Valid Date" Display="none" ValidationGroup="vsErrorGroup"
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
                            <asp:TextBox ID="txtTo_Date_Of_Event" runat="server" Width="160px" SkinID="txtDate" autocomplete="off"
                                MaxLength="10"></asp:TextBox>
                            <img onclick="return showCalendar('<%= txtTo_Date_Of_Event.ClientID %>', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" alt="" src="../Images/iconPicDate.gif"
                                align="middle" id="img6" />
                            <br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtTo_Date_Of_Event"
                                ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                ErrorMessage="To Date of Event is Not Valid Date" Display="none" ValidationGroup="vsErrorGroup"
                                SetFocusOnError="true">
                            </asp:RegularExpressionValidator>
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtTo_Date_Of_Event"
                                ControlToCompare="txtFrom_Date_Of_Event" ValidationGroup="vsErrorGroup" Display="None"
                                Type="Date" Operator="GreaterThanEqual" ErrorMessage="To Date of Event must be greater than or equal to from date" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" align="center">
                            <asp:Button runat="server" ID="btnShowReport" Text="Show Report" OnClick="btnShowReport_Click"
                                CausesValidation="true" ValidationGroup="vsErrorGroup" />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnClearCriteria" runat="server" Text="Clear Criteria" ToolTip="Clear All"
                                OnClick="btnClearCriteria_Click" CausesValidation="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0" runat="server"
        id="tblReport" visible="false">
        <tr valign="middle">
            <td align="right" width="100%">
                <asp:LinkButton Visible="false" ID="lbtExportToExcel" runat="server" Text="Export To Excel"
                    OnClick="lbtExportToExcel_Click"></asp:LinkButton>&nbsp;&nbsp;
                <asp:LinkButton ID="lnkBack" Text="Back" runat="server" CausesValidation="false"
                    OnClick="btnBack_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 5px;">
            </td>
        </tr>
        <tr id="trGrid" runat="server">
            <td align="left">
                <table width="100%">
                    <tr>
                        <td style="width: 100%">
                            <asp:Label ID="lblReport" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnBack" Text="Back" runat="server" CausesValidation="false" OnClick="btnBack_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
