<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="rptEarlyWarningRecipientsTerminations.aspx.cs" Inherits="COIReports_rptEarlyWarningRecipientsTerminations" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .ReportTable-td
        {
            border-left: none;
            border-right: 1px solid black;
            border-top: 1px solid black;
            border-bottom: 1px solid black;
            /*border: 1px solid red;*/
        }

        .ReportTable-td-first
        {
            border: 1px solid black;
        }
    </style>
    <table width="100%" cellpadding="0" cellspacing="2">
        <tr>
            <td width="100%" class="Spacer" style="height: 3px;" colspan="2"></td>
        </tr>
        <tr>
            <td align="left" class="ghc" colspan="2">Early Warning Recipients Terminations Report (Terminations in the Past 7 Days)</td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 3px;" colspan="2"></td>
        </tr>
        <tr runat="server" id="trCriteria">
            <td width="2%">&nbsp;
            </td>
            <td align="center">
                <asp:UpdatePanel ID="upReport" runat="server">
                    <ContentTemplate>
                        <table width="83%" align="center" style="text-align: left;" cellpadding="2" cellspacing="3" border="0">
                            <tr valign="top" align="left">
                                <td>Region
                                </td>
                                <td align="right">:
                                </td>
                                <td align="left">
                                    <asp:ListBox ID="lstRegion" runat="server" SelectionMode="Multiple" Width="250px" OnSelectedIndexChanged="lstRegion_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox>
                                </td>
                                <td>Market
                                </td>
                                <td align="right">:
                                </td>
                                <td align="left" colspan="4">
                                    <asp:ListBox ID="lstMarket" runat="server" SelectionMode="Multiple" Width="250px" OnSelectedIndexChanged="lstMarket_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox>
                                </td>
                            </tr>
                            <tr valign="top" align="left">
                                <td>Location
                                </td>
                                <td align="right">:
                                </td>
                                <td align="left" colspan="4">
                                    <asp:ListBox ID="lstLocation" runat="server" SelectionMode="Multiple" Width="250px"></asp:ListBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6" align="center">
                                    <asp:Button runat="server" ID="btnShowReport" Text="Show Report" OnClick="btnShowReport_Click" CausesValidation="true" />
                                    &nbsp;&nbsp;
                            <asp:Button ID="btnClearCriteria" runat="server" Text="Clear Criteria" ToolTip="Clear All"
                                OnClick="btnClearCriteria_Click" CausesValidation="false" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnShowReport" />
                    </Triggers>
                </asp:UpdatePanel>
                <asp:UpdateProgress runat="server" ID="upProgress" DisplayAfter="100">
                    <ProgressTemplate>
                        <div class="UpdatePanelloading" id="divProgress" style="width: 100%; position: fixed;">
                            <table id="ProgressTable" cellpadding="0" cellspacing="0" border="0" style="width: 100%; height: 100%;">
                                <tr align="center" valign="middle">
                                    <td class="LoadingText" align="center" valign="middle">
                                        <img src="../../Images/indicator.gif" alt="Loading" />&nbsp;&nbsp;&nbsp;Please Wait..
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
    <table id="tblReport" align="center" cellpadding="0" cellspacing="0" border="0" runat="server" width="100%">
        <tr valign="middle">
            <td align="right" width="100%">
                <asp:LinkButton ID="lbtExportToExcel" runat="server" Text="Export To Excel"
                    OnClick="lbtExportToExcel_Click"></asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
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
                        <td>&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btnBack" Text="Back" runat="server" CausesValidation="false" OnClick="btnBack_Click" />
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 10px;"></td>
        </tr>
    </table>
</asp:Content>

