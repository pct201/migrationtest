<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SchedulerptAdHocWriter.aspx.cs"
    Inherits="SchedulerptAdHocWriter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta name="robots" content="noindex"/>
    <title>Schedule Ad Hoc Report Writer</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <script type="text/javascript" language="javascript" src='<%=AppConfig.SiteURL %>JavaScript/JFunctions.js'></script>
        <script type="text/javascript" language="javascript" src='<%=AppConfig.SiteURL %>JavaScript/Calendar_new.js'></script>
        <script type="text/javascript" language="javascript" src='<%=AppConfig.SiteURL %>JavaScript/calendar-en.js'></script>
        <script type="text/javascript" language="javascript" src='<%=AppConfig.SiteURL %>JavaScript/Calendar.js'></script>
        <div>
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left" class="ghc">
                        Schedule Ad Hoc Report Writer
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr style="height: 60%;" align="center" valign="middle">
                    <td valign="middle" align="center">
                        <table width="75%" cellpadding="3" cellspacing="0" style="border: 1pt; border-color: #7f7f7f;
                            border-style: solid; text-align: center; height: 70px;">
                            <div>
                                <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
                                    HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
                                    EnableClientScript="true" ValidationGroup="vsErrorGroup" CssClass="errormessage">
                                </asp:ValidationSummary>
                                <asp:CustomValidator ID="cvErrorMsg" runat="server" ErrorMessage="" EnableClientScript="true"
                                    ValidationGroup="vsErrorGroup" Display="None"></asp:CustomValidator>
                                <asp:Label ID="lblMessage" runat="server" SkinID="lblError" EnableViewState="false"></asp:Label>
                            </div>
                            <tr>
                                <td style="padding-top: 9px;">
                                    <table cellpadding="4" cellspacing="4">
                                        <tr>
                                            <td align="left" width="18%" valign="top">
                                                Scheduled Date<span class="mf">*</span>
                                            </td>
                                            <td align="center" width="4%" valign="top">
                                                :
                                            </td>
                                            <td align="left" width="28%" valign="top">
                                                <asp:TextBox runat="server" ID="txtScheduleDate" SkinID="txtDate"></asp:TextBox>
                                                <img onclick="return showCalendar('<%=txtScheduleDate.ClientID %>', 'mm/dd/y');"
                                                    onmouseover="javascript:this.style.cursor='hand';" src="<%=AppConfig.ImageURL %>/iconPicDate.gif"
                                                    align="middle" /><br />
                                                <asp:RequiredFieldValidator ValidationGroup="vsErrorGroup" ID="RequiredFieldValidator4"
                                                    runat="server" ControlToValidate="txtScheduleDate" ErrorMessage="Schedule Date must not be Blank."
                                                    SetFocusOnError="true" Display="none" />
                                                <asp:RangeValidator ValidationGroup="vsErrorGroup" ID="RangeValidator1" ControlToValidate="txtScheduleDate"
                                                    MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="Schedule Date is not valid."
                                                    runat="server" SetFocusOnError="true" Display="none" />
                                                <asp:CustomValidator ID="cstValidator" runat="server" ErrorMessage="Scheduled Date must greater than current date."
                                                    ClientValidationFunction="CheckScheduleDate" Display="None" SetFocusOnError="false"
                                                    ValidationGroup="vsErrorGroup" Text=""></asp:CustomValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="18%" valign="top">
                                                Scheduled End Date<span class="mf">*</span>
                                            </td>
                                            <td align="center" width="4%" valign="top">
                                                :
                                            </td>
                                            <td align="left" width="28%" valign="top">
                                                <asp:TextBox runat="server" ID="txtScheduleEndDate" SkinID="txtDate"></asp:TextBox>
                                                <img onclick="return showCalendar('<%=txtScheduleEndDate.ClientID %>', 'mm/dd/y');"
                                                    onmouseover="javascript:this.style.cursor='hand';" src="<%=AppConfig.ImageURL %>/iconPicDate.gif"
                                                    align="middle" /><br />
                                                <asp:RequiredFieldValidator ValidationGroup="vsErrorGroup" ID="RequiredFieldValidator5"
                                                    runat="server" ControlToValidate="txtScheduleEndDate" ErrorMessage="Schedule End Date must not be Blank."
                                                    SetFocusOnError="true" Display="none" />
                                                <asp:RangeValidator ValidationGroup="vsErrorGroup" ID="RangeValidator2" ControlToValidate="txtScheduleEndDate"
                                                    MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="Schedule End Date is not valid."
                                                    runat="server" SetFocusOnError="true" Display="none" />
                                                <asp:CompareValidator ValidationGroup="vsErrorGroup" ID="CompareValidator1" runat="server"
                                                    ControlToValidate="txtScheduleEndDate" ControlToCompare="txtScheduleDate" Display="None"
                                                    ErrorMessage="Scheduled End Date must be greater than Scheduled Start Date" SetFocusOnError="true"
                                                    Type="date" Operator="GreaterThanEqual" />
                                                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Scheduled End Date must greater than current date."
                                                    Display="None" SetFocusOnError="false" Text="" ValidationGroup="vsErrorGroup"></asp:CustomValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Recurring Period<span class="mf">*</span>
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="drpRecurringPeriod" runat="server" EnableTheming="True" Width="166px"
                                                    SkinID="dropGen">
                                                    <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                    <%--<asp:ListItem Value="4" Text="Daily"></asp:ListItem>--%>
                                                    <asp:ListItem Value="1" Text="Weekly"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Monthly"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="Quarterly"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvdrpRecurringPeriod" runat="server" ErrorMessage="Please Select Recurring Period."
                                                    Font-Bold="true" Display="none" Text="*" ControlToValidate="drpRecurringPeriod"
                                                    ValidationGroup="vsErrorGroup" InitialValue="0" SetFocusOnError="false"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Recipient List<span class="mf">*</span>
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="drpRecipientList" runat="server" EnableTheming="True" SkinID="dropGen"
                                                    Width="166px" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Select Recipient List"
                                                    Font-Bold="true" Display="none" Text="*" ControlToValidate="drpRecipientList"
                                                    InitialValue="0" SetFocusOnError="false" ValidationGroup="vsErrorGroup"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Report Name<span class="mf">*</span>
                                            </td>
                                            <td align="center">
                                                :
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:TextBox runat="server" ID="txtReportName" Width="160px" MaxLength="50"></asp:TextBox>
                                                <asp:RequiredFieldValidator ValidationGroup="vsErrorGroup" ID="rfvdReportName" runat="server"
                                                    ControlToValidate="txtReportName" ErrorMessage="Please Enter Report Name." SetFocusOnError="true"
                                                    Display="none" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <asp:Label ID="lblError" runat="server" SkinID="lblError" EnableViewState="false"></asp:Label>
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
                                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CausesValidation="true"
                                        ToolTip="Select" ValidationGroup="vsErrorGroup" />
                                    <input type="hidden" id="hdntxtID" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <script type="text/javascript" language="javascript">
        function CheckScheduleDate(obj, args) {
            var retVal = true;
            if (document.getElementById('<%=txtScheduleDate.ClientID %>').value != '') {
                var dateSelected = new Date(document.getElementById('<%=txtScheduleDate.ClientID %>').value);
                var dateToday = new Date();
                if (dateSelected < dateToday) {
                    args.IsValid = false;
                    retVal = false;
                }
            }
            return retVal;
        }

        function SaveSchedule(fk_schedileID,fk_reportID) {
            parent.parent.document.getElementById('ctl00_ContentPlaceHolder1_hdnScheduleID').value = fk_schedileID;
            parent.parent.document.getElementById('ctl00_ContentPlaceHolder1_hdnReportId').value = fk_reportID;
            parent.parent.document.getElementById('ctl00_ContentPlaceHolder1_btnHdnScheduling').click();
            parent.parent.GB_hide();
        }       
    </script>
    </form>
</body>
</html>
