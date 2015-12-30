<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="rptVOCEmissions.aspx.cs" Inherits="UserAccessRequest_rptVOCEmissions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
         <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Validator.js"></script>

    <table width="100%" cellpadding="0" cellspacing="2">
        <tr>
            <td width="100%" class="Spacer" style="height: 3px;" colspan="2"></td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 3px;" colspan="2"></td>
        </tr>
        <tr runat="server" id="trCriteria">
            <td align="center" width="100%">
                <table border="0" cellpadding="5" cellspacing="1" width="45%" align="center">
                    <tr>
                        <td align="left" valign="top" width="40%">Start Date &nbsp;<span style="color: Red; font-weight: bold;">*</span>
                        </td>
                        <td align="center" valign="top" width="5%">:
                        </td>
                        <td align="left" width="60%">
                            <asp:TextBox runat="server" ID="txtStartDate" Width="140px" SkinID="txtDate"></asp:TextBox>
                            <img alt="Start Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtStartDate', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif" align="middle" /><br />
                            <asp:RequiredFieldValidator ID="rfvDate" runat="server" ControlToValidate="txtStartDate" ErrorMessage="Please enter Start Date"
                                SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none" />
                            <asp:RangeValidator ID="revDate" ControlToValidate="txtStartDate" MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date"
                                ErrorMessage="Start Date is not valid." runat="server" SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" width="40%">End Date  &nbsp;<span style="color: Red; font-weight: bold;">*</span>
                        </td>
                        <td align="center" valign="top" width="5%">:
                        </td>
                        <td align="left" width="60%">
                            <asp:TextBox runat="server" ID="txtEndDate" Width="140px" SkinID="txtDate"></asp:TextBox>
                            <img alt="Date Approved Denied End" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtEndDate', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif" align="middle" /><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtStartDate" ErrorMessage="Please enter End Date"
                                SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none" />
                            <asp:RangeValidator ID="RangeValidator1" ControlToValidate="txtEndDate" MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date"
                                ErrorMessage="DateApprovedDeniedBegin is not valid." runat="server" SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none" />
                            <asp:CompareValidator ID="cvDate" runat="server" Type="Date" ControlToValidate="txtEndDate" ControlToCompare="txtStartDate"
                                Operator="GreaterThanEqual" ErrorMessage="End Date must be greater than Start Date" Display="None" SetFocusOnError="true" ValidationGroup="vsErrorGroup" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" width="40%">Location &nbsp;<span style="color: Red; font-weight: bold;">*</span>
                        </td>
                        <td align="center" valign="top" width="5%">:
                        </td>
                        <td align="left" width="60%">
                             <asp:DropDownList ID="ddlLocation" width="175px" runat="server" skinid="dropGen"> </asp:DropDownList>
                            <asp:RequiredFieldValidator ControlToValidate="ddlLocation" ID="rfvLocation" Display="None"
                                ValidationGroup="vsErrorGroup" ErrorMessage="Please select Location" InitialValue="0" runat="server">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3" align="center">
                            <asp:Button runat="server" ID="btnShowReport" Text="Show Report" OnClick="btnShowReport_Click"
                                CausesValidation="true" ValidationGroup="vsErrorGroup" />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnClearCriteria" runat="server" Text="Clear Criteria" ToolTip="Clear All"
                                OnClick="btnClearCriteria_Click" CausesValidation="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td> 
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
                      <asp:LinkButton ID="lnkBack" Text="Back" runat="server" CausesValidation="false" OnClick="btnBack_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 5px;"></td>
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
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnBack" Text="Back" runat="server" CausesValidation="false" OnClick="btnBack_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

