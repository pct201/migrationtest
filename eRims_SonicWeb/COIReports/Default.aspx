<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Default.master"
    CodeFile="Default.aspx.cs" Inherits="COIReports_Default" %>

<%@ MasterType VirtualPath="~/Default.master" %>
<asp:Content ID="Content1" runat='server' ContentPlaceHolderID="contentPlaceHolder1">
 <div style="width: 100%" id="contmain">
    <table cellpadding="0" cellspacing="0" width="100%" align="left">
        <tr>
            <td width="100%" class="Spacer" style="height: 25px;">
            </td>
        </tr>
        <tr>
            <td class="dvContent">
                <table cellpadding="0" cellspacing="0" border="0"  Width="90%" align="center">
                    <tr>
                        <td align="left">
                            <table cellpadding="4" cellspacing="1" class="tblGrid" width="100%">
                                <tr>
                                    <td width="30%" class="headerrow">
                                        Report Name
                                    </td>
                                    <td class="headerrow">
                                        Report Description
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="normalrow2">
                                        <a target="_blank" href="Entity.aspx">Entity (Producer and Insurance Company)</a>
                                    </td>
                                    <td class="normalrow2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="normalrow2">
                                        <a target="_blank" href="LocationsByState.aspx">Locations by State</a>
                                    </td>
                                    <td class="normalrow2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="normalrow2">
                                        <a target="_blank" href="NonCompliantByEntity.aspx">Non Compliant (By Entity Name)</a>
                                    </td>
                                    <td class="normalrow2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="normalrow2">
                                        <a target="_blank" href="NonCompliantSummary.aspx">Non Compliant Summary</a>
                                    </td>
                                    <td class="normalrow2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="normalrow2">
                                        <a target="_blank" href="PoliciesExpiringIn90Days.aspx">Policies Expiring within 90
                                            Days (By Entity)</a>
                                    </td>
                                    <td class="normalrow2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="normalrow2">
                                        <a target="_blank" href="PoliciesExpirationDates.aspx">Policy Expiration Dates (By Entity
                                            Name)</a>
                                    </td>
                                    <td class="normalrow2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="normalrow2">
                                        <a target="_blank" href="Verification.aspx">Verification of Insurance</a>
                                    </td>
                                    <td class="normalrow2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="normalrow2">
                                        <a target="_blank" href="rptSubleaseReport.aspx">SubLease Report</a>
                                    </td>
                                    <td class="normalrow2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="normalrow2">
                                        <a target="_blank" href="rptLocationsLeaseandPolicyDates.aspx">Locations - Lease and Policy Dates</a>
                                    </td>
                                    <td class="normalrow2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td class="normalrow"><a target="_blank" href="AutoScheTesting.aspx">Auto Schedule Testing</a></td>
                                    <td class="normalrow">&nbsp;</td>
                                </tr>  
                                <tr>
                                    <td class="normalrow"><a target="_blank" href="PropertySchedule.aspx">Property Schedule Testing</a></td>
                                    <td class="normalrow">&nbsp;</td>
                                </tr>--%>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 50px;">
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
