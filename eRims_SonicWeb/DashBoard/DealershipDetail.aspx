
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DealershipDetail.aspx.cs"
    Inherits="DealershipDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dealership Details</title>
</head>
<body>
    <form id="form1" runat="server">

        <asp:Panel ID="pnlAggregatePerformance" runat="server" Visible="false">
            <table width="100%" style="text-align: left" cellpadding="2" cellspacing="3">
                <tr align="left" style="width: 55%">
                    <td>Dealership Name
                    </td>
                    <td align="center" style="width: 5%">:
                    </td>
                    <td style="width: 40%">
                        <asp:Label ID="lblAggregateDelearship" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left"><b>Category</b></td>
                    <td>&nbsp;</td>
                    <td align="left"><b>Score</b></td>
                </tr>
                <tr>
                    <td align="left" valign="top">Safety Leadership Team</td>
                    <td align="center" valign="top">:</td>
                    <td align="left" valign="top">
                        <asp:Label ID="lblScoreSLT" runat="server" /></td>
                </tr>
                <tr>
                    <td align="left" valign="top">EHS Facility Inspection</td>
                    <td align="center" valign="top">:</td>
                    <td align="left" valign="top">
                        <asp:Label ID="lblScoreFacility" runat="server" /></td>
                </tr>
                <tr>
                    <td align="left" valign="top">Safety Training</td>
                    <td align="center" valign="top">:</td>
                    <td align="left" valign="top">
                        <asp:Label ID="lblScoreTraining" runat="server" /></td>
                </tr>
                <tr>
                    <td align="left" valign="top">Incident Investigation</td>
                    <td align="center" valign="top">:</td>
                    <td align="left" valign="top">
                        <asp:Label ID="lblScoreIncidentInvestigation" runat="server" /></td>
                </tr>
                <tr>
                    <td align="left" valign="top">Worker's Compensation Claims Management</td>
                    <td align="center" valign="top">:</td>
                    <td align="left" valign="top">
                        <asp:Label ID="lblScoreWCClaim" runat="server" /></td>
                </tr>
                <tr>
                    <td align="left" valign="top">Incident Reduction</td>
                    <td align="center" valign="top">:</td>
                    <td align="left" valign="top">
                        <asp:Label ID="lblScoreIncidentReduction" runat="server" /></td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top">Total</td>
                    <td align="center" valign="top">:</td>
                    <td align="left" valign="top">
                        <asp:Label ID="lblScoreTotal" runat="server" />&nbsp;out of possible 100</td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top">Resulting Score</td>
                    <td align="center" valign="top">:</td>
                    <td align="left" valign="top">
                        <asp:Label ID="lblResultingScore" runat="server" /></td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlFacilityInspection" runat="server" Visible="false">
            <table width="100%" style="text-align: left" cellpadding="2" cellspacing="3">
                <tr align="left" style="width: 40%">
                    <td>Dealership Name
                    </td>
                    <td align="center" style="width: 5%">:
                    </td>
                    <td style="width: 55%">
                        <asp:Label ID="lblDealership" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>Number of Repeat Deficiencies
                    </td>
                    <td align="center" style="width: 5%">:
                    </td>
                    <td>
                        <asp:Label ID="lblDeficiencies" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Average Number of Days Open
                    </td>
                    <td align="center" style="width: 5%">:
                    </td>
                    <td>
                        <asp:Label ID="lblDaysOpen" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>Performance Level
                    </td>
                    <td align="center" style="width: 5%">:
                    </td>
                    <td>
                        <asp:Label ID="lblPerformance" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlIncidentInvestigation" runat="server" Visible="false">
            <table width="100%" style="text-align: left" cellpadding="2" cellspacing="3">
                <tr align="left" style="width: 40%">
                    <td>Dealership Name
                    </td>
                    <td align="center" style="width: 5%">:
                    </td>
                    <td style="width: 55%">
                        <asp:Label ID="lblIIDealerShip" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>Total Number of Investigations for Calendar Year
                    </td>
                    <td align="center" style="width: 5%">:
                    </td>
                    <td>
                        <asp:Label ID="lblNoofInvestigations" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Average Investigative Quality Score
                    </td>
                    <td align="center" style="width: 5%">:
                    </td>
                    <td>
                        <asp:Label ID="AvgInvestigation" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>Performance Level
                    </td>
                    <td align="center" style="width: 5%">:
                    </td>
                    <td>
                        <asp:Label ID="lblIIPerLevel" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlSabaTraining" runat="server" Visible="false">
            <table width="100%" style="text-align: left" cellpadding="2" cellspacing="3">
                <tr align="left">
                    <td style="width: 50%">Dealership Name
                    </td>
                    <td align="center" style="width: 5%">:
                    </td>
                    <td colspan="4">
                        <asp:Label ID="lblSabaDealerShipName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
              <%--  <tr>
                    <td>Date
                    </td>
                    <td align="center" style="width: 5%">:
                    </td>
                    <td colspan="4">
                        <asp:Label ID="lblSabaTrainingDate" runat="server" Text=""></asp:Label>
                    </td>
                </tr>--%>
                <tr>
                    <td>Year
                    </td>
                    <td align="center" style="width: 5%">:
                    </td>
                    <td colspan="4">
                        <asp:Label ID="lblSabaTrainingYear" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Quarter
                    </td>
                    <td align="center" style="width: 5%">:
                    </td>
                    <td >Q1
                    </td>
                    <td >Q2
                    </td>
                    <td >Q3
                    </td >
                    <td >Q4
                    </td>
                </tr>
                <tr>
                    <td>Total Number of Associates To Train
                    </td>
                    <td align="center" style="width: 5%">:
                    </td>
                    <td >
                        <asp:LinkButton ID="lblSabaNumberEmployees1" runat="server" OnClick="lblSabaNumberEmployees_Click" Text="0"></asp:LinkButton>
                    </td>
                    <td >
                        <asp:LinkButton ID="lblSabaNumberEmployees2" runat="server" OnClick="lblSabaNumberEmployees_Click" Text="0"></asp:LinkButton>
                    </td>
                    <td >
                        <asp:LinkButton ID="lblSabaNumberEmployees3" runat="server" OnClick="lblSabaNumberEmployees_Click" Text="0"></asp:LinkButton>
                    </td>
                    <td >
                        <asp:LinkButton ID="lblSabaNumberEmployees4" runat="server" OnClick="lblSabaNumberEmployees_Click" Text="0"></asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td>Total Number of Associates Trained
                    </td>
                    <td align="center" style="width: 5%">:
                    </td>
                    <td >
                        <asp:LinkButton ID="lblSabaEmployeesTrained1" runat="server" OnClick="lblSabaNumberEmployees_Click" Text="0"></asp:LinkButton>
                    </td>
                    <td >
                        <asp:LinkButton ID="lblSabaEmployeesTrained2" runat="server" OnClick="lblSabaNumberEmployees_Click" Text="0"></asp:LinkButton>
                    </td>
                    <td >
                        <asp:LinkButton ID="lblSabaEmployeesTrained3" runat="server" OnClick="lblSabaNumberEmployees_Click" Text="0"></asp:LinkButton>
                    </td>
                    <td >
                        <asp:LinkButton ID="lblSabaEmployeesTrained4" runat="server" OnClick="lblSabaNumberEmployees_Click" Text="0"></asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td>Percent of Associates Trained
                    </td>
                    <td align="center" style="width: 5%">:
                    </td>
                    <td >
                        <asp:Label ID="lblSabaPercentTrained1" runat="server" Text="0"></asp:Label>
                    </td>
                    <td >
                        <asp:Label ID="lblSabaPercentTrained2" runat="server" Text="0"></asp:Label>
                    </td>
                    <td >
                        <asp:Label ID="lblSabaPercentTrained3" runat="server" Text="0"></asp:Label>
                    </td>
                    <td >
                        <asp:Label ID="lblSabaPercentTrained4" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>Aggregate Performance (YTD)
                    </td>
                    <td align="center" style="width: 5%">:
                    </td>
                    <td colspan="4">
                        <asp:Label ID="lblSabaPerformance" runat="server" ></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlInvestigationReduction" runat="server" Visible="false">
            <table width="100%" style="text-align: left" cellpadding="2" cellspacing="3">
                <tr align="left" style="width: 40%">
                    <td>Dealership Name
                    </td>
                    <td align="center" style="width: 5%">:
                    </td>
                    <td style="width: 55%">
                        <asp:Label ID="lblRedDealerShip" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr align="left" style="width: 40%">
                    <td>Number of Incidents with S1 Causes
                    </td>
                    <td align="center" style="width: 5%">:
                    </td>
                    <td style="width: 55%">
                        <asp:Label ID="lblRedS1" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
                <tr align="left" style="width: 40%">
                    <td>Number of Incidents with S0-1 Causes
                    </td>
                    <td align="center" style="width: 5%">:
                    </td>
                    <td style="width: 55%">
                        <asp:Label ID="lblRedS01" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
                <tr align="left" style="width: 40%">
                    <td>Number of Incidents with S2 Causes
                    </td>
                    <td align="center" style="width: 5%">:
                    </td>
                    <td style="width: 55%">
                        <asp:Label ID="lblRedS2" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
                <tr align="left" style="width: 40%">
                    <td>Number of Incidents with S0-2 Causes
                    </td>
                    <td align="center" style="width: 5%">:
                    </td>
                    <td style="width: 55%">
                        <asp:Label ID="lblRedS02" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr align="left" style="width: 40%">
                    <td>Performance Level
                    </td>
                    <td align="center" style="width: 5%">:
                    </td>
                    <td style="width: 55%">
                        <asp:Label ID="lblRedPerformance" runat="server" Text="Platinum"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlWCClaimMgmt" runat="server" Visible="false">
            <table width="100%" style="text-align: left" cellpadding="2" cellspacing="3">
                <tr align="left" style="width: 40%">
                    <td>Dealership Name
                    </td>
                    <td align="center" style="width: 5%">:
                    </td>
                    <td style="width: 55%">
                        <asp:Label ID="lblDealershipWCClaim" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>Average Claim Closure for past 200 days
                    </td>
                    <td align="center" style="width: 5%">:
                    </td>
                    <td>
                        <asp:Label ID="lblAverageClaimClosure" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>Performance Level
                    </td>
                    <td align="center" style="width: 5%">:
                    </td>
                    <td>
                        <asp:Label ID="lblPerformanceLevelWC" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlSLT" runat="server" Visible="false">
            <table width="100%" style="text-align: left" cellpadding="2" cellspacing="3">
                <tr align="left" style="width: 40%">
                    <td>Dealership Name
                    </td>
                    <td align="center" style="width: 5%">:
                    </td>
                    <td style="width: 55%">
                        <asp:Label ID="lblSlt_location" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>Meeting held and 100% Participation
                    </td>
                    <td align="center" style="width: 5%">:
                    </td>
                    <td>
                        <asp:Label ID="lblMeeting_points" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Find It and Fix It Conducted
                    </td>
                    <td align="center" style="width: 5%">:
                    </td>
                    <td>
                        <asp:Label ID="lblSafety_Walk_points" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>Incident Review Conducted
                    </td>
                    <td align="center" style="width: 5%">:
                    </td>
                    <td>
                        <asp:Label ID="lblIncident_points" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>Quality Review
                    </td>
                    <td align="center" style="width: 5%">:
                    </td>
                    <td>
                        <asp:Label ID="lblQuality_Review_Points" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>Total Points
                    </td>
                    <td align="center" style="width: 5%">:
                    </td>
                    <td>
                        <asp:Label ID="lblSlt_Total_Points" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>Performance Level
                    </td>
                    <td align="center" style="width: 5%">:
                    </td>
                    <td>
                        <asp:Label ID="lblSLT_Performance" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>

    </form>
</body>
</html>
