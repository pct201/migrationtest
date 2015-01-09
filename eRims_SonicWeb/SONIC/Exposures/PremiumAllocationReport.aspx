<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="PremiumAllocationReport.aspx.cs" Inherits="SONIC_Exposures_PremiumAllocationReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ValidationSummary ID="valSummary" runat="server" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="vsError" />

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
               Premium Allocation Report
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
                            Year&nbsp;<span style="color:Red">*</span>
                        </td>
                        <td width="2%" align="center" valign="top">
                            :
                        </td>
                        <td align="left" width="70%">
                             <asp:TextBox ID="txtYear" runat="server" MaxLength="4" Width="245px" onpaste="return false" SkinID="txtYearWithRange">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="revtxtYear" runat="server" Display="None" ErrorMessage="Please Enter Year."
                                    ControlToValidate="txtYear" SetFocusOnError="true" ValidationGroup="vsError"></asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="rvtxtYearBuilt" runat="server" ControlToValidate="txtYear"
                                    ValidationGroup="vsError" Type="Integer" MinimumValue="1" MaximumValue="2100" ErrorMessage="Year is not valid."
                                    Display="None"></asp:RangeValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" width="28%">
                            Region
                        </td>
                        <td width="2%" align="center" valign="top">
                            :
                        </td>
                        <td align="left" width="70%">
                             <asp:DropDownList ID="drpRegion" runat="server" style="width:250px;">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" width="28%">
                            Market
                        </td>
                        <td width="2%" align="center" valign="top">
                            :
                        </td>
                        <td align="left" width="70%">
                             <asp:DropDownList ID="drpMarket" runat="server" style="width:250px;">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" width="28%">
                            State
                        </td>
                        <td width="2%" align="center" valign="top">
                            :
                        </td>
                        <td align="left" width="70%">
                             <asp:DropDownList ID="drpState" runat="server" style="width:250px;">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" width="28%">
                            Location
                        </td>
                        <td width="2%" align="center" valign="top">
                            :
                        </td>
                        <td align="left" width="70%">
                             <asp:DropDownList ID="drpLocation" runat="server" style="width:250px;">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr><td>&nbsp;</td></tr>
                    <tr>
                        <td colspan="3" align="center">
                            <asp:Button runat="server" ID="btnShowReport" Text="Show Report" OnClick="btnShowReport_Click"
                                CausesValidation="true" ValidationGroup="vsError" />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnClearCriteria" runat="server" Text="Clear Criteria" ToolTip="Clear All"
                                OnClick="btnClearCriteria_Click" CausesValidation="false" />
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
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnBack" Text="Back" runat="server" CausesValidation="false" OnClick="btnBack_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

