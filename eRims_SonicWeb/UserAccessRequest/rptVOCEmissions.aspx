<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="rptVOCEmissions.aspx.cs" Inherits="UserAccessRequest_rptVOCEmissions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">

        function CheckValidation() {
            var lstLocation = document.getElementById("<%=lstLocation.ClientID %>");
            var cnt = 0;
            for (var i = 0; i < lstLocation.options.length; i++) {
                var isSelected = lstLocation.options[i].selected;
                if (isSelected)
                    cnt = cnt + 1;
            }

            if (Page_ClientValidate("vsErrorGroup")) {
                if (cnt > 1) {
                    alert("Please select only one Location.");
                    return false;
                }
            }
        }

        var oWnd;
        function OpenMailPopUp() {
            oWnd = window.open('<%=AppConfig.SiteURL%>SONIC/Exposures/Asset_Protection_SendMail.aspx?Tab=VOC_Graph', "Erims", "location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=600,height=300");
            oWnd.moveTo(450, 300);
            return false;
        }

        function CloseMailPopup() {
            oWnd = window.open('<%=AppConfig.SiteURL%>SONIC/Exposures/Asset_Protection_SendMail.aspx?Tab=VOC_Graph', "Erims", "location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=600,height=300");
            alert('Mail Sent Successfully');
            oWnd.close();
        }

    </script>
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Validator.js"></script>

    <script language="Javascript" src="<%=AppConfig.SiteURL%>FusionCharts/default.js" type="text/javascript"></script>
    <script language="Javascript" src="<%=AppConfig.SiteURL%>FusionCharts/FusionCharts.js" type="text/javascript"></script>
    <script language="Javascript" src="<%=AppConfig.SiteURL%>FusionCharts/FusionChartsExportComponent.js" type="text/javascript"></script>
    <table width="100%" cellpadding="0" cellspacing="2">
        <tr>
            <td width="100%" class="Spacer" style="height: 3px;" colspan="2"></td>
        </tr>
        <tr>
            <td align="left" class="ghc" colspan="2">
                VOC Report
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 3px;" colspan="2"></td>
        </tr>
        <tr runat="server" id="trCriteria">
            <td align="center" width="100%">
                <table border="0" cellpadding="5" cellspacing="1" width="50%" align="center">
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
                            <%--<asp:DropDownList ID="ddlLocation" width="175px" runat="server" skinid="dropGen"> </asp:DropDownList>--%>
                            <asp:ListBox ID="lstLocation" runat="server" SelectionMode="Multiple" Width="250px"></asp:ListBox>
                            <asp:RequiredFieldValidator ControlToValidate="lstLocation" ID="rfvLocation" Display="None"
                                ValidationGroup="vsErrorGroup" ErrorMessage="Please select Location" InitialValue="" runat="server">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3" align="center">
                            <asp:Button runat="server" ID="btnShowReport" Text="Show Report" OnClick="btnShowReport_Click"/>
                            &nbsp;&nbsp;
                            <asp:Button ID="btnClearCriteria" runat="server" Text="Clear Criteria" ToolTip="Clear All"
                                OnClick="btnClearCriteria_Click" CausesValidation="false" />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnShow_VOC_Graph" runat="server" Text="Show VOC Graph" ToolTip="Show VOC Graph"
                                OnClick="btnShow_VOC_Graph_Click" CausesValidation="true" ValidationGroup="vsErrorGroup" />
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
    <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0" runat="server"
        id="tblGraph" visible="false">
        <tr valign="middle">
            <td align="right" width="100%">
                <asp:LinkButton ID="lnkSendMail" runat="server" Text="Send Mail" OnClientClick="return OpenMailPopUp();"></asp:LinkButton>&nbsp;&nbsp;
                <asp:LinkButton ID="lnkExportToPDF" runat="server" Text="Export To PDF" OnClick="lnkExportToPDF_Click"></asp:LinkButton>&nbsp;&nbsp;
                      <asp:LinkButton ID="lnkBackGraph" Text="Back" runat="server" CausesValidation="false" OnClick="btnBackGraph_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 5px;"></td>
        </tr>
        <tr>
            <td width="100%" valign="top" style="border: 1px solid #666666;" colspan="2" align="center">
                <div id="divchart1" runat="server" style="margin: 10px;" />
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 5px;"></td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btnBackGraph" Text="Back" runat="server" CausesValidation="false" OnClick="btnBackGraph_Click" />
                <asp:Button ID="btnReload" runat="server" OnClick="btnReload_Click" Style="display: none;" />
                <asp:HiddenField ID="hdnto" runat="server" />
                <asp:HiddenField ID="hdnSubject" runat="server" />
                <asp:HiddenField ID="hdnBody" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>

