<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="PremiumAllocation_EditLocation.aspx.cs" Inherits="SONIC_Exposures_PremiumAllocation_EditLocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Date_Validation.js"></script>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" CssClass="errormessage" ValidationGroup="vsError"
            BorderColor="DimGray" BorderWidth="1" HeaderText="Verify the following fields:"
            ShowMessageBox="true" ShowSummary="false"></asp:ValidationSummary>
    </div>
    <table cellpadding="3" cellspacing="1" width="100%">
            <tr>
            <td width="100%" colspan="2">&nbsp;
            </td>
        </tr>
        <tr>
            <td align="left" class="ghc" colspan="2">
               Premium Allocation Edit Location
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 3px;" colspan="2">
            </td>
        </tr>
        <tr runat="server" id="trCriteria">
            <td>
                <asp:Panel ID="pnlEdit" runat="server">
                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                        <tr>
                            <td colspan="3">
                                <asp:Label ID="lblError" runat="server" Visible="False" Font-Bold="True" CssClass="error"></asp:Label>
                            </td>
                        </tr>
                        <tr valign="top">
                            <td align="left" valign="top" width="18%">
                                Year <span style="color: Red;">*</span>
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                 <asp:DropDownList ID="ddlYear" runat="server" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged"
                                                AutoPostBack="true" SkinID="dropGen" Width="245px">
                                 </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="revddlYear" runat="server" Display="None" ErrorMessage="Please Select Year."
                                    ControlToValidate="ddlYear" InitialValue="0" SetFocusOnError="true" ValidationGroup="vsError"></asp:RequiredFieldValidator>
                              <%--  <asp:RangeValidator ID="rvtxtYearBuilt" runat="server" ControlToValidate="txtYear"
                                    ValidationGroup="vsError" Type="Integer" MinimumValue="1" MaximumValue="2100"
                                    ErrorMessage="Year is not valid." Display="None"></asp:RangeValidator>--%>
                            </td>
                            <td align="left" valign="top" width="18%">
                                &nbsp;
                            </td>
                            <td width="4%" align="center" valign="top">
                                &nbsp;
                            </td>
                            <td align="left" width="28%">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top" width="18%">
                                Location <span style="color: Red;">*</span>
                            </td>
                            <td width="4%" align="center" valign="top">
                                :
                            </td>
                            <td align="left" width="28%">
                                <asp:DropDownList ID="drpLocation" runat="server" Style="width: 245px;" OnSelectedIndexChanged="drpLocation_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="revdrpLocation" runat="server" Display="None" ErrorMessage="Please Select Location."
                                    ControlToValidate="drpLocation" InitialValue="0" SetFocusOnError="true" ValidationGroup="vsError"></asp:RequiredFieldValidator>
                            </td>
                            <td align="left" width="18%">
                                Non Texas Payroll
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                <asp:TextBox ID="txtNon_Texas_Payroll" runat="server" Width="240px" onkeypress="return FormatNumberToDec(event,this.id,16,false,2);"
                                    onpaste="return false" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="18%">
                                Texas Payroll
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                <asp:TextBox ID="txtTexas_Payroll" runat="server" Width="240px" onkeypress="return FormatNumberToDec(event,this.id,16,false,2);"
                                    onpaste="return false" />
                            </td>
                            <td align="left" width="18%">
                                Number of Employees
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left" width="28%">
                                <asp:TextBox ID="txtNumber_Of_Employees" runat="server" Width="240px" onkeypress="return FormatNumberToDec(event,this.id,10,true);"
                                    onpaste="return false" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center">
                               <asp:Button runat="server" ID="btnShowReport" Text="Generate Report" OnClick="btnShowReport_Click"
                                CausesValidation="true" ValidationGroup="vsError" />
                                 &nbsp;&nbsp;
                            <asp:Button ID="btnClearCriteria" runat="server" Text="Clear Criteria" ToolTip="Clear All"
                                OnClick="btnClearCriteria_Click" CausesValidation="false" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
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
