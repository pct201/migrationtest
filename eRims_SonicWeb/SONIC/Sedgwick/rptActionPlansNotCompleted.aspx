<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="rptActionPlansNotCompleted.aspx.cs" Inherits="SONIC_Sedgwick_rptActionPlansNotCompleted" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src='<%=AppConfig.SiteURL %>JavaScript/JFunctions.js'></script>
    <script type="text/javascript">
        function StopQuery() {
            var guid = '<%=strGUID%>';
            CancelReport.StopReportProcess(guid, OnGetReportComlete, OnTimeOut, onerror);
        }

        function OnGetReportComlete(result) {
            document.getElementById('<%=btnBack.ClientID %>').click();
        }

        function OnTimeOut(args) {
            alert("Time-out occured. Please contact us if this error persist.");
        }

        function OnError(args) {
            alert("Error calling web service. Please contact us if this error persist.");
        }

        var timeout;

        function LoadReport() {
            timeout = setTimeout('LoadIframe()', 500);
        }

    </script>
    <script type="text/javascript" language="javascript">

        function EnableDisableGroupVal() {
            var drpGroupBy2 = document.getElementById('<%=drpGroupBy2.ClientID%>');
            if (drpGroupBy2.selectedIndex == 0)
                ValidatorEnable(document.getElementById('<%=cmGroup.ClientID%>'), false);
            else
                ValidatorEnable(document.getElementById('<%=cmGroup.ClientID%>'), true);
        }
    </script>
    <asp:ValidationSummary ID="valSummay" runat="server" ValidationGroup="vsErrorGroup"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following field(s):" />
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td width="100%">&nbsp;
            </td>
        </tr>
        <tr id="trReportHeader" runat="server" visible="true">
            <td class="ghc">Action Plans Not Completed Report
            </td>
        </tr>
        <tr id="trReportbalnk" runat="server" visible="true">
            <td>&nbsp;
            </td>
        </tr>
        <tr id="trReportfilter" runat="server" visible="true">
            <td align="center">
                <table cellpadding="4" cellspacing="2" width="100%" align="center">
                    <tr>
                        <td align="left" colspan="9">&nbsp; <b>Group By/Sort By :</b>
                        </td>
                    </tr>
                    <tr>
                        <td width="13%">&nbsp;
                        </td>
                        <td width="15%" align="left" valign="top">First Group By&nbsp;<span style="color: Red">*</span>
                        </td>
                        <td width="2%" align="center" valign="top">:
                        </td>
                        <td align="left" valign="top" width="25%">
                            <asp:DropDownList ID="drpGroupBy1" runat="server" Width="200px" onchange="EnableDisableGroupVal();">
                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Sedgwick Claim Office" Value="Fld_Desc" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Year" Value="[Year]"></asp:ListItem>
                                <asp:ListItem Text="Quarter" Value="[Quarter]"></asp:ListItem>
                                <asp:ListItem Text="Claim Number" Value="Origin_Claim_Number"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpGroupBy1"
                                SetFocusOnError="true" ValidationGroup="vsErrorGroup" InitialValue="0" ErrorMessage="Please Select First Group By"
                                Display="None" />
                        </td>
                        <td>&nbsp;&nbsp;&nbsp;
                        </td>
                        <td width="15%" align="left" valign="top">Sorting
                        </td>
                        <td width="2%" align="center" valign="top">:
                        </td>
                        <td align="left" valign="top">
                            <asp:RadioButtonList ID="rdbSort1" runat="server" RepeatDirection="Horizontal" CellPadding="0"
                                CellSpacing="0">
                                <asp:ListItem Text="Ascending  " Value="ASC"></asp:ListItem>
                                <asp:ListItem Text="Descending" Value="DESC" Selected="True"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td width="13%">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                        <td align="left" valign="top">Second Group By
                        </td>
                        <td align="center" valign="top">:
                        </td>
                        <td align="left" valign="top">
                            <asp:DropDownList ID="drpGroupBy2" runat="server" Width="200px" onchange="EnableDisableGroupVal();">
                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Sedgwick Claim Office" Value="Fld_Desc"></asp:ListItem>
                                <asp:ListItem Text="Year" Value="[Year]"></asp:ListItem>
                                <asp:ListItem Text="Quarter" Value="[Quarter]"></asp:ListItem>
                                <asp:ListItem Text="Claim Number" Value="Origin_Claim_Number"></asp:ListItem>
                                <asp:ListItem Text="dba" Value="[dba]"></asp:ListItem>
                                <asp:ListItem Text="RLCM" Value="RLCM"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:CompareValidator ID="cmGroup" runat="server" ControlToValidate="drpGroupBy2"
                                Enabled="false" ControlToCompare="drpGroupBy1" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                InitialValue="0" ErrorMessage="First and second group by must be different."
                                Type="String" Display="None" Operator="NotEqual"></asp:CompareValidator>
                        </td>
                        <td>&nbsp;&nbsp;&nbsp;
                        </td>
                        <td align="left" valign="top">Sorting
                        </td>
                        <td align="center" valign="top">:
                        </td>
                        <td align="left" valign="top">
                            <asp:RadioButtonList ID="rdbSort2" runat="server" RepeatDirection="Horizontal" CellPadding="0"
                                CellSpacing="0">
                                <asp:ListItem Selected="True" Text="Ascending  " Value="ASC"></asp:ListItem>
                                <asp:ListItem Text="Descending" Value="DESC"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td width="13%">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="9">&nbsp; <b>Filter By :</b>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                        <td align="left" valign="top">Sedgwick Field Office
                        </td>
                        <td align="center" valign="top">:
                        </td>
                        <td align="left">
                            <asp:ListBox ID="lstSedgwick_Field_Office" Width="200px" runat="server" SelectionMode="Multiple"></asp:ListBox>
                        </td>
                        <td>&nbsp;
                        </td>
                        <td width="15%" align="left" valign="top">Claim Review Status
                        </td>
                        <td width="2%" align="center" valign="top">:
                        </td>
                        <td colspan="2" align="left" valign="top">
                            <asp:RadioButtonList ID="rblClaimReviewStatus" RepeatColumns="1" RepeatDirection="Vertical" runat="server" CellPadding="0"
                                CellSpacing="0">
                                <asp:ListItem Text="Completed" Value="Y"></asp:ListItem>
                                <asp:ListItem Text="Not Completed" Value="N"></asp:ListItem>
                                <asp:ListItem Text="Both Completed and Not Completed" Value="B" Selected="True"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <%--  <td width="13%">&nbsp;
                        </td>--%>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                        <td align="left" valign="top">Year
                        </td>
                        <td align="center" valign="top">:
                        </td>
                        <td colspan="6" align="left">
                            <asp:ListBox ID="lstYear" Width="200px" runat="server" SelectionMode="Multiple"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                        <td align="left" valign="top">Quarter
                        </td>
                        <td align="center" valign="top">:
                        </td>
                        <td align="left">
                            <%--<asp:ListBox ID="lstQuarter" Width="200px" runat="server" SelectionMode="Multiple">
                                <asp:ListItem Value="1" Text="1">
                                </asp:ListItem>
                                <asp:ListItem Value="2" Text="2">
                                </asp:ListItem>
                                <asp:ListItem Value="3" Text="3">
                                </asp:ListItem>
                                <asp:ListItem Value="4" Text="4">
                                </asp:ListItem>
                            </asp:ListBox>--%>
                            <asp:DropDownList ID="lstQuarter" Width="50px" runat="server">
                                 <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                <asp:ListItem Value="1" Text="1">
                                </asp:ListItem>
                                <asp:ListItem Value="'2','1'" Text="2">
                                </asp:ListItem>
                                <asp:ListItem Value="'3','2','1'" Text="3">
                                </asp:ListItem>
                                <asp:ListItem Value="'4','3','2','1'" Text="4">
                                </asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                        <td align="left" valign="top">Location Number
                        </td>
                        <td align="center" valign="top">:
                        </td>
                        <td colspan="6" align="left">
                            <asp:TextBox ID="txtLocation_Number" runat="server" MaxLength="20" onkeypress="return numberOnly(this);"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="9">&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="trReportspace" runat="server" visible="true">
            <td>&nbsp;
            </td>
        </tr>
        <tr id="trReportbutton" runat="server" visible="true">
            <td align="center">
                <asp:Button ID="btnGenerateReport" runat="server" Text="Generate Report" OnClick="btnGenerateReport_Click"
                    ValidationGroup="vsErrorGroup" />&nbsp;
                <asp:Button ID="btnClearCriteria" runat="server" Text="Clear Criteria" OnClick="btnClearCriteria_Click" />
            </td>
        </tr>
        <tr id="tr_Data" runat="server" visible="false">
            <td width="100%">
                <table width="100%">
                    <tr>
                        <td align="right" colspan="1">
                            <asp:LinkButton ID="lnkExportExcel" runat="server" Text="Export To Excel" OnClick="lnkExportExcel_Click"
                                CausesValidation="false"></asp:LinkButton>&nbsp;&nbsp;
                        </td>
                        <td width="3%">
                            <asp:LinkButton ID="lnkBackUp" runat="server" Text="Back" OnClick="btnBack_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="trResult" runat="server" visible="false">
            <td align="left">
                <asp:Label ID="lblClaimRecords" runat="server" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" style="padding-bottom: 7px">
                <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" Style="display: none" />&nbsp;
                <asp:Button ID="btnCancelExecution" runat="server" Text="Cancel" OnClick="btnBack_Click"
                    Visible="false" />
            </td>
        </tr>
    </table>
</asp:Content>
