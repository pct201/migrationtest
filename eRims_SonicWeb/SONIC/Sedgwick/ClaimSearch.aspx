<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="ClaimSearch.aspx.cs" Inherits="SONIC_Sedgwick_ClaimSearch" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery.maskedinput.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Date_Validation.js"></script>
    <div>
        <asp:ValidationSummary ID="vsSearchInvestigation" runat="server" HeaderText="Please verify following fields:"
            ShowMessageBox="true" ShowSummary="false" ValidationGroup="vsSearch" />
    </div>
    <table cellspacing="0" cellpadding="0" width="100%">
        <tbody>
            <tr>
                <td class="groupHeaderBar" align="left">&nbsp; </td>
            </tr>
            <tr>
                <td style="height: 20px" class="Spacer"></td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="pnlSearch" runat="server" DefaultButton="btnSearch">
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tbody>
                                <tr>
                                    <td style="width: 150px"><span class="heading">Claim Search</span> </td>
                                    <td class="Spacer"></td>
                                </tr>
                                <tr>
                                    <td class="Spacer"></td>
                                    <td>
                                        <table cellspacing="1" cellpadding="3" width="100%" border="0">
                                            <tbody>
                                                <tr>
                                                    <td style="width: 15%" align="left">Year <span class="mf">*</span> </td>
                                                    <td style="width: 4%" align="center">: </td>
                                                    <td style="width: 32%" align="left">
                                                        <asp:Label ID="lblYear" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="width: 18%" align="left">Quarter</td>
                                                    <td style="width: 4%" align="center">: </td>
                                                    <td style="width: 28%" align="left">
                                                        <asp:Label ID="lblQuarter" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 15%" align="left">Sedgwick Claim Office <span class="mf">*</span>
                                                    </td>
                                                    <td style="width: 4%" align="center">: </td>
                                                    <td style="width: 32%" align="left">
                                                        <asp:DropDownList ID="ddlSedgwickClaimOffice" runat="server" AutoPostBack="true"
                                                            Width="170px" OnSelectedIndexChanged="ddlSedgwickClaimOffice_SelectedIndexChanged"
                                                            Enabled="false">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rfvdrpOffice" runat="server" ControlToValidate="ddlSedgwickClaimOffice"
                                                            InitialValue="0" Display="None" ValidationGroup="vsSearch" ErrorMessage="Please select office"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td style="width: 18%" align="left">State</td>
                                                    <td style="width: 4%" align="center">: </td>
                                                    <td style="width: 28%" align="left">
                                                        <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="true" Width="170px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">Claim Type </td>
                                                    <td align="center">: </td>
                                                    <td align="left" colspan="4">
                                                        <asp:CheckBoxList ID="chklClaimType" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="Worker’s Compensation" Value="WC" style="padding-right:10px;"></asp:ListItem>
                                                            <asp:ListItem Text="Texas NS" Value="NS"></asp:ListItem>
                                                        </asp:CheckBoxList>
                                                    </td>
                                                </tr>
                                                <tr valign="top">
                                                    <td align="left"></td>
                                                    <td align="center"></td>
                                                    <td align="left" colspan="4">
                                                        <table>
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:RadioButtonList ID="rblLT_Med_Only_FlagForWC" runat="server" RepeatDirection="Vertical" RepeatColumns="1">
                                                                        <asp:ListItem Text="Other than Medical Only" Value="L"></asp:ListItem>
                                                                        <asp:ListItem Text="Medical Only" Value="M"></asp:ListItem>
                                                                        <asp:ListItem Text="Both" Value="O" Selected="True"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:RadioButtonList ID="rblLT_Med_Only_FlagForNS" runat="server" RepeatDirection="Vertical" RepeatColumns="1">
                                                                        <asp:ListItem Text="Other than Medical Only" Value="L"></asp:ListItem>
                                                                        <asp:ListItem Text="Medical Only" Value="M"></asp:ListItem>
                                                                        <asp:ListItem Text="Both" Value="O" Selected="True"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">Date of Loss Period </td>
                                                    <td align="center"></td>
                                                    <td align="left"></td>
                                                    <td></td>
                                                    <td align="center"></td>
                                                    <td align="left"></td>
                                                </tr>
                                                <tr>
                                                    <td align="left">From Date </td>
                                                    <td align="center">: </td>
                                                    <td align="left">
                                                        <asp:TextBox runat="server" ID="txtFromDate" Width="100px" SkinID="txtDate"></asp:TextBox>
                                                        <img alt="Prior Valuation Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtFromDate', 'mm/dd/y');"
                                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                            align="middle" /><br />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFromDate"
                                                            ErrorMessage="Please enter From Date" SetFocusOnError="true" Display="none" />
                                                        <asp:RangeValidator ID="RangeValidator2" ControlToValidate="txtFromDate" MinimumValue="01/01/1753"
                                                            MaximumValue="12/31/9999" Type="Date" ErrorMessage="From Date is not valid" runat="server"
                                                            SetFocusOnError="true" Display="none" />
                                                    </td>
                                                    <td align="left">To Date </td>
                                                    <td align="center">: </td>
                                                    <td align="left">
                                                        <asp:TextBox runat="server" ID="txtToDate" Width="100px" SkinID="txtDate"></asp:TextBox>
                                                        <img alt="Prior Valuation Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtToDate', 'mm/dd/y');"
                                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                            align="middle" /><br />
                                                        <asp:RequiredFieldValidator ID="rfvDateTo1" runat="server" ControlToValidate="txtToDate"
                                                            ErrorMessage="Please enter To Date" SetFocusOnError="true" Display="none" />
                                                        <asp:RangeValidator ID="revDateTo1" ControlToValidate="txtToDate" MinimumValue="01/01/1753"
                                                            MaximumValue="12/31/9999" Type="Date" ErrorMessage="To Date is not valid" runat="server"
                                                            SetFocusOnError="true" Display="none" />
                                                        <asp:CompareValidator ID="cvDate1" runat="server" Type="Date" ControlToValidate="txtToDate"
                                                            ControlToCompare="txtFromDate" Operator="GreaterThanEqual" ErrorMessage="To Date must be greater than From Date"
                                                            Display="None" SetFocusOnError="true" />
                                                    </td>
                                                </tr>
                                                <tr valign="top">
                                                    <td align="left">Claims Indicator</td>
                                                    <td align="center">: </td>
                                                    <td align="left">
                                                        <asp:RadioButtonList ID="rdoClaim" runat="server" RepeatDirection="Vertical" RepeatColumns="1">
                                                            <asp:ListItem Text="Both Opened and Closed" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Closed Only" Value="C"></asp:ListItem>
                                                            <asp:ListItem Text="Open Only" Value="O"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 14%" align="left">SONIC Location Code </td>
                                                    <td style="width: 4%" align="center">: </td>
                                                    <td style="width: 32%" align="left">
                                                        <asp:DropDownList ID="ddlRMLocationNumber" runat="server" AutoPostBack="true" Width="170px"
                                                            OnSelectedIndexChanged="ddlRMLocationNumber_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>First Report Number </td>
                                                    <td align="center">: </td>
                                                    <td align="left">
                                                        <asp:TextBox runat="server" ID="txtFirstReportNumber" Width="180px" onKeyPress="return FormatInteger(event);"
                                                            MaxLength="12"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="REVFirstReportNumber" runat="server" ControlToValidate="txtFirstReportNumber"
                                                            Display="none" SetFocusOnError="true" ErrorMessage="First Report Number must be numeric"
                                                            ValidationExpression="^\d+$" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">Location d/b/a </td>
                                                    <td align="center">: </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="ddlLocationdba" runat="server" AutoPostBack="true" Width="170px"
                                                            OnSelectedIndexChanged="ddlLocationdba_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="left">Sedgwick Claim Number(s) </td>
                                                    <td align="center">: </td>
                                                    <td align="left" style="vertical-align: middle">
                                                        <asp:TextBox ID="txtClaimNumber" runat="server" Width="180px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" width="14%"></td>
                                                    <td align="center" width="4%"></td>
                                                    <td align="left" width="32%"></td>
                                                    <td align="right"></td>
                                                    <td align="center"></td>
                                                    <td align="left">
                                                        <p style="font-size: 11px;">
                                                            Note : Please add multiple claim numbers separated by comma (',').
                                                        </p>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">&nbsp; </td>
                                </tr>
                            </tbody>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tbody>
                            <tr>
                                <td style="height: 24px" align="center">
                                    <asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" ValidationGroup="vsSearch"
                                        Text="Search Claims" CausesValidation="true" ToolTip="Search"></asp:Button>&nbsp;&nbsp;&nbsp;
									<asp:Button ID="btnBack" OnClick="btnBack_Click" CausesValidation="false" runat="server" Text="Back" ToolTip="Back"></asp:Button>&nbsp;&nbsp;&nbsp; </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="height: 20px" class="Spacer"></td>
            </tr>
        </tbody>
    </table>
</asp:Content>
