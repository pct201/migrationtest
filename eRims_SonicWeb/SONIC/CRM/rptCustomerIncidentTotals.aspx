<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="rptCustomerIncidentTotals.aspx.cs" Inherits="SONIC_CRM_rptCustomerIncidentTotals" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ValidationSummary ID="valSummary" runat="server" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="vsErrorGroup" />

<script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>

<script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>

<script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>

<script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>

<table width="100%" cellpadding="0" cellspacing="2">
        <tr>
            <td width="100%" colspan="2">&nbsp;
            </td>
        </tr>
        <tr>
            <td align="left" class="ghc" colspan="2">
                Customer Relationship Incident Totals by Dealership
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 3px;" colspan="2">
            </td>
        </tr>
        <tr runat="server" id="trCriteria">
            <td align="center" width="100%">
                <table border="0" cellpadding="5" cellspacing="1" width="50%" align="center">
                    <tr>
                        <td align="left" valign="top" width="28%">
                            Time Period Begin&nbsp;<span style="color:Red">*</span>
                        </td>
                        <td width="2%" align="center" valign="top">
                            :
                        </td>
                        <td align="left" width="70%">
                            <asp:TextBox ID="txtBeginDate" runat="server" SkinID="txtDate" Width="145px" />
                            <img alt="Time Period Begin Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtBeginDate', 'mm/dd/y');"
                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif" align="middle" />
                            <asp:RegularExpressionValidator ID="revBeginDate" runat="server" ValidationGroup="vsErrorGroup"
                            Display="none" ErrorMessage="Time Period Begin Date is not a valid date" SetFocusOnError="true" 
                            ControlToValidate="txtBeginDate" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="rfvBeginDate" runat="server" ControlToValidate="txtBeginDate" Display="None" ErrorMessage="Please enter Time Period Begin Date" ValidationGroup="vsErrorGroup" SetFocusOnError="true" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" width="28%">
                            Time Period End&nbsp;<span style="color:Red">*</span>
                        </td>
                        <td width="2%" align="center" valign="top">
                            :
                        </td>
                        <td align="left" width="70%">
                            <asp:TextBox ID="txtEndDate" runat="server" SkinID="txtDate" Width="145px" />
                            <img alt="Time Period End Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtEndDate', 'mm/dd/y');"
                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                            align="middle" />
                            <asp:RegularExpressionValidator ID="revEndDate" runat="server" ValidationGroup="vsErrorGroup"
                            Display="none" ErrorMessage="Time Period End Date is not a valid date" SetFocusOnError="true" 
                            ControlToValidate="txtEndDate" ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"></asp:RegularExpressionValidator>
                            <asp:CompareValidator ID="cvTimePeriod" runat="server" ControlToValidate="txtEndDate" ControlToCompare="txtBeginDate" ErrorMessage="Time Period End Date must be greater than or equal to Begin Date"
                            SetFocusOnError="true" Type="Date" Operator="GreaterThanEqual" Display="None" ValidationGroup="vsErrorGroup" />
                            <asp:RequiredFieldValidator ID="rfvEndDate" runat="server" ControlToValidate="txtEndDate" Display="None" ErrorMessage="Please enter Time Period End Date" ValidationGroup="vsErrorGroup" SetFocusOnError="true" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" width="28%">
                            Location D/B/A
                        </td>
                        <td width="2%" align="center" valign="top">
                            :
                        </td>
                        <td align="left" width="70%">
                            <asp:ListBox ID="lstDBA" runat="server" Width="280px" SelectionMode="Multiple" Rows="7">                                
                            </asp:ListBox>
                        </td>
                    </tr>
                    <tr><td>&nbsp;</td></tr>
                    <tr>
                        <td colspan="3" align="center">
                            <asp:Button runat="server" ID="btnShowReport" Text="Show Report" OnClick="btnShowReport_Click"
                                CausesValidation="true" ValidationGroup="vsErrorGroup" />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnClearCriteria" runat="server" Text="Clear Criteria" ToolTip="Clear All"
                                OnClick="btnClearCriteria_Click" CausesValidation="false" />
                        </td>
                    </tr>
                    <tr><td>&nbsp;</td></tr>
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
                      <asp:LinkButton ID="lnkBack" Text="Back" runat="server" CausesValidation="false" OnClick="btnBack_Click" />
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
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

