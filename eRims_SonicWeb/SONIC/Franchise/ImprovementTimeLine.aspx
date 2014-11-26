<%@ Page Title="Risk Insurance Management System :: Improvement Time Line" Language="C#"
    MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="ImprovementTimeLine.aspx.cs"
    Inherits="SONIC_Franchise_ImprovementTimeLine" %>

<%@ Register Src="~/Controls/ExposuresTab/ExposuresTab.ascx" TagName="CtlTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposureInfo/ExposureInfo.ascx" TagName="ctrlExposureInfo"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/NotesWithSpellCheck/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="<%=AppConfig.SiteURL%>JavaScript/calendar.js"></script>

    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar.js"></script>

    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Validator.js"></script>

    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Date_Validation.js"></script>

    <script language="javascript" type="text/javascript">
        function ValSave() {
            if (Page_ClientValidate("vsErrorGroup"))
                return true;
            else
                return false;
        }
        function OpenAuditPopUp() {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;

            obj = window.open('AuditPopup_Franchise_Improvements.aspx?id=<%=ViewState["PK_Franchise_Improvements"]%>', 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }
    </script>

    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100%" style="height: 50px;" valign="bottom" colspan="2">
                <uc:CtlTab runat="server" ID="Tab"></uc:CtlTab>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td class="Spacer" style="height: 15px;" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" colspan="2">
                            <asp:UpdatePanel ID="upPanel1" runat="server" UpdateMode="Always">
                                <ContentTemplate>
                                    <uc:ctrlExposureInfo ID="ucCtrlExposureInfo" runat="server" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" style="height: 15px;" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td class="leftMenu">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="height: 18px;" class="Spacer">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100%">
                                        &nbsp;&nbsp;<span id="FrenchiseGrid" class="LeftMenuSelected">Improvement Time Line</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 10px;" class="Spacer">
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td style="width: 5px">
                                        &nbsp;
                                    </td>
                                    <td style="width: 794px" valign="top" class="dvContainer">
                                        <div id="dvEdit" runat="server">
                                            <asp:Panel ID="pnlITLEdit" runat="server" Width="100%">
                                                <div class="bandHeaderRow" id="hdrITLView" runat="server">
                                                    Improvement Time Line</div>
                                                <table cellpadding="3" cellspacing="1" border="0" width="98%" id="tblITL" runat="server"
                                                    align="center">
                                                    <tr>
                                                        <td colspan="6" class="Spacer" style="height: 10px;">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="20%">
                                                            Improvement&nbsp;<span class="msg1">*</span>
                                                        </td>
                                                        <td align="center" width="2%">
                                                            :
                                                        </td>
                                                        <td align="left" width="30%">
                                                            <asp:TextBox ID="txtImprovement" runat="server" Width="150px" MaxLength="75"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtImprovement"
                                                                Display="none" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Improvement"
                                                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td colspan="3">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="20%" valign="top">
                                                            Description of Work
                                                        </td>
                                                        <td align="center" width="2%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="txtDescofWork" Width="550" ControlType="TextBox" runat="server"
                                                                IsRequired="true" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="20%" align="left">
                                                            Scheduled Start Date
                                                            <%--<span class="msg1">*</span>--%>
                                                        </td>
                                                        <td width="2%" align="center">
                                                            :
                                                        </td>
                                                        <td width="30%" align="left">
                                                            <asp:TextBox ID="txtScheduledStartDate" runat="server" MaxLength="10" Width="150px"
                                                                SkinID="txtDate"></asp:TextBox>
                                                            <img alt="" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtScheduledStartDate', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="<%=AppConfig.SiteURL%>JavaScript/iconPicDate.gif"
                                                                align="absmiddle" />
                                                            <asp:RegularExpressionValidator ID="revScheduleDateFrom" runat="server" ControlToValidate="txtScheduledStartDate"
                                                                ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                                                ErrorMessage="Please Enter Valid Scheduled Start Date" Display="none" ValidationGroup="vsErrorGroup"
                                                                SetFocusOnError="true">
                                                            </asp:RegularExpressionValidator>
                                                            <%-- <asp:RequiredFieldValidator ID="rqfvDateofProfile" runat="server" ControlToValidate="txtScheduledStartDate"
                                                                Display="none" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Scheduled Start Date "
                                                                SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                                                        </td>
                                                        <td width="18%" align="left">
                                                            Actual Start Date
                                                            <%--<span class="msg1">*</span>--%>
                                                        </td>
                                                        <td width="2%" align="center">
                                                            :
                                                        </td>
                                                        <td width="28%" align="left">
                                                            <asp:TextBox ID="txtActualStartDate" runat="server" MaxLength="10" Width="150px"
                                                                SkinID="txtDate"></asp:TextBox>
                                                            <img alt="" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtActualStartDate', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="<%=AppConfig.SiteURL%>JavaScript/iconPicDate.gif"
                                                                align="absmiddle" />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtActualStartDate"
                                                                ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                                                ErrorMessage="Please Enter Valid Actual Start Date" Display="none" ValidationGroup="vsErrorGroup"
                                                                SetFocusOnError="true">
                                                            </asp:RegularExpressionValidator>
                                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtActualStartDate"
                                                                Display="none" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Actual Start Date "
                                                                SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="20%" align="left">
                                                            Anticipated Completion Date
                                                            <%--<span class="msg1">*</span>--%>
                                                        </td>
                                                        <td width="2%" align="center">
                                                            :
                                                        </td>
                                                        <td width="30%" align="left">
                                                            <asp:TextBox ID="txtAnticipatedCompletionDate" runat="server" MaxLength="10" Width="150px"
                                                                SkinID="txtDate"></asp:TextBox>
                                                            <img alt="" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtAnticipatedCompletionDate', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="<%=AppConfig.SiteURL%>JavaScript/iconPicDate.gif"
                                                                align="absmiddle" />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtAnticipatedCompletionDate"
                                                                ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                                                ErrorMessage="Please Enter Valid Anticipated Completion Date" Display="none"
                                                                ValidationGroup="vsErrorGroup" SetFocusOnError="true">
                                                            </asp:RegularExpressionValidator>
                                                            <%-- <asp:RequiredFieldValidator ID="rqfvDateofProfile" runat="server" ControlToValidate="txtAnticipatedCompletionDate"
                                                                Display="none" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Anticipated Completion Date "
                                                                SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                                                        </td>
                                                        <td width="18%" align="left">
                                                            Actual Completion Date
                                                            <%--<span class="msg1">*</span>--%>
                                                        </td>
                                                        <td width="2%" align="center">
                                                            :
                                                        </td>
                                                        <td width="28%" align="left">
                                                            <asp:TextBox ID="txtActualCompletionDate" runat="server" MaxLength="10" Width="150px"
                                                                SkinID="txtDate"></asp:TextBox>
                                                            <img alt="" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtActualCompletionDate', 'mm/dd/y');"
                                                                onmouseover="javascript:this.style.cursor='hand';" src="<%=AppConfig.SiteURL%>JavaScript/iconPicDate.gif"
                                                                align="absmiddle" />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtActualCompletionDate"
                                                                ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                                                ErrorMessage="Please Enter Valid Actual Completion Date" Display="none" ValidationGroup="vsErrorGroup"
                                                                SetFocusOnError="true">
                                                            </asp:RegularExpressionValidator>
                                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtActualCompletionDate"
                                                                Display="none" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Actual Completion Date "
                                                                SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Actual Start Date Should Be Less Then Or Equal To Actual Completion Date"
                                                                ControlToValidate="txtActualCompletionDate" ControlToCompare="txtActualStartDate"
                                                                SetFocusOnError="true" Operator="GreaterThanEqual" Type="Date" Display="None" ValidationGroup="vsErrorGroup"></asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="18%">
                                                            Update
                                                        </td>
                                                        <td align="center" width="2%">
                                                            :
                                                        </td>
                                                        <td align="left" width="30%">
                                                            <asp:TextBox ID="txtUpdate" runat="server" MaxLength="75" Width="150px"></asp:TextBox>
                                                        </td>
                                                        <td colspan="3">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" class="Spacer" style="height: 10px;">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </div>
                                        <div id="dvView" runat="server" visible="false">
                                            <asp:Panel ID="pnlITLView" runat="server" Width="100%">
                                                <div class="bandHeaderRow" id="dvITLView" runat="server">
                                                    Improvement Time Line</div>
                                                <table cellpadding="5" cellspacing="1" border="0" width="98%" id="Table1" runat="server"
                                                    align="center">
                                                    <tr>
                                                        <td colspan="6" class="Spacer" style="height: 10px;">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="20%">
                                                            Improvement
                                                        </td>
                                                        <td align="center" width="2%">
                                                            :
                                                        </td>
                                                        <td align="left" width="30%">
                                                            <asp:Label ID="lblImprovement" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td colspan="3">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" width="20%" valign="top">
                                                            Description of Work
                                                        </td>
                                                        <td align="center" width="2%" valign="top">
                                                            :
                                                        </td>
                                                        <td align="left" colspan="4" valign="top">
                                                            <uc:ctrlMultiLineTextBox ID="lblDescofWork" Width="550" ControlType="Label" runat="server"
                                                                IsRequired="false" Text="" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="20%" align="left">
                                                            Scheduled Start Date
                                                        </td>
                                                        <td width="2%" align="center">
                                                            :
                                                        </td>
                                                        <td width="30%" align="left">
                                                            <asp:Label ID="lblScheduledStartDate" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td width="18%" align="left">
                                                            Actual Start Date
                                                        </td>
                                                        <td width="2%" align="center">
                                                            :
                                                        </td>
                                                        <td width="28%" align="left">
                                                            <asp:Label ID="lblActualStartDate" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="20%" align="left">
                                                            Anticipated Completion Date
                                                        </td>
                                                        <td width="2%" align="center">
                                                            :
                                                        </td>
                                                        <td width="30%" align="left">
                                                            <asp:Label ID="lblAnticipatedCompletionDate" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td width="18%" align="left">
                                                            Actual Completion Date
                                                        </td>
                                                        <td width="2%" align="center">
                                                            :
                                                        </td>
                                                        <td width="28%" align="left">
                                                            <asp:Label ID="lblActualCompletionDate" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Update
                                                        </td>
                                                        <td align="center">
                                                            :
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblUpdates" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td colspan="3">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" class="Spacer" style="height: 10px;">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
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
            <td style="height: 50px;" class="Spacer" colspan="2" align="center" runat="server"
                id="trButtonEdit">
                <asp:Button ID="btnSave" runat="server" SkinID="SaveAndView" CausesValidation="true"
                    ValidationGroup="vsErrorGroup" OnClientClick="return ValSave();" OnClick="btnSave_Click" />&nbsp;&nbsp;
                <asp:Button ID="btnReturn" runat="server" Text="Revert & Return" CausesValidation="false"
                    OnClick="btnReturn_Click" />&nbsp;&nbsp;
                <asp:Button ID="btnAuditEdit" runat="server" Text="View Audit Trail" CausesValidation="false"
                    OnClientClick="return OpenAuditPopUp();" />
            </td>
        </tr>
        <tr>
            <td style="height: 50px;" class="Spacer" colspan="2" align="center" runat="server"
                id="trButtonView" visible="false">
                <asp:Button ID="btnEdit" runat="server" Text=" Edit " CausesValidation="false" OnClick="btnEdit_Click" />&nbsp;&nbsp;
                <asp:Button ID="btnBack" runat="server" Text=" Back " CausesValidation="false" OnClick="btnBack_Click" />&nbsp;&nbsp;
                <asp:Button ID="btnAuditView" runat="server" Text="View Audit Trail" CausesValidation="false"
                    OnClientClick="return OpenAuditPopUp();" />
            </td>
        </tr>
    </table>
</asp:Content>
