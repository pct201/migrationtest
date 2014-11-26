<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_AP_Fraud_Events.aspx.cs"
    Inherits="SONIC_Exposures_AuditPopup_AP_Fraud_Events" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS Sonic :: AP Fraud Events Audit Trail</title>
    <script language="javascript" type="text/javascript">
        function showAudit(divHeader, divGrid) {
            var divheight, i;

            divHeader.style.width = window.screen.availWidth - 325 + "px";
            divGrid.style.width = window.screen.availWidth - 325 + "px";

            divheight = divGrid.style.height;
            i = divheight.indexOf('px');

            if (i > -1)
                divheight = divheight.substring(0, i);
            if (divheight > (window.screen.availHeight - 450) && divGrid.style.height != "") {
                divGrid.style.height = window.screen.availHeight - 450;
            }
        }

        function ChangeScrollBar(f, s) {
            s.scrollTop = f.scrollTop;
            s.scrollLeft = f.scrollLeft;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" align="left">
            <tr>
                <td align="left">
                    <asp:Label ID="lbltable_Name" runat="server" Font-Bold="true"></asp:Label>
                </td>
                <td align="right">
                    <a href="javascript:window.close();">Close Window</a>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div style="overflow: hidden; width: 650px;" id="divAP_Fraud_Events_Audit_Header"
                        runat="server">
                        <table cellpadding="4" cellspacing="0" style="width: 15037px; border-collapse: collapse;">
                            <tbody>
                                <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                    align="left">
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Audit DateTime</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Fraud Number</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Exposure Period Begin Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Exposure Period End Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Reported To</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Reported Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Description of Event</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Customer Relations Hotline</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Discovered Fraud through Audits</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px">Internal Audit Control Breakdown leading
                                            to Fraud Event</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Retail Lending</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Sonic Associates 1800 Hotline</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Store Red Flags</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Notification Other</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Other Notification Description</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Internal Review Purification Notes</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Fraud Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">HR Assignment</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">HR Associate Contacted</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Date HR Assigned</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Internal Audit Assignment</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Internal Audit Associate Contacted</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Date Internal Audit Assigned</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Store Controller Assignment</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Store Controller Associate Contacted</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Date Store Controller Assigned</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Regional Controller Assignment</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Regional Controller Associate Contacted</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Date Regional Controller Assigned</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Legal Department Assignment</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Legal Department Associate Contacted</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Date Legal Department Assigned</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Outside Legal Assignment</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Outside Legal Associate Contacted</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Date Outside Legal Assigned</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Operations Assignment</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Operations Associate Contacted</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Date Operations Assigned</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Retail Lending Assignment</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Retail Lending Associate Contacted</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Date Retail Lending Assigned</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">BT Security Assignment</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">BT Security Associate Contacted</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Date BT Security Assigned</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Other Assignment</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Associated Contacted</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Date Assigned</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">OnSite Findings</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">TLO Findings</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Statements Obtained</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Fact Finding andor Due Diligence</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Law Enforcement Involvement</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Civil Actrion</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Crimimal Action</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Further Investigation</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">ACC Suspension</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">ACC Termination</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">ACC Written</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">ACC Verbal</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Communication Strategy</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Disposition Game Plan Other</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Detailed Deisposition Game Plan Description</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Accounting Gaps and Controls</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Aging MFR Incentives</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Aging Warranties</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Account Payable Schemes</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Associate Collusion</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Billing Schemes</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">External Scam</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 220px">Improper Disclosure to Customer F
                                            and I Product Purchase</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px">Improper Disclosure to Customer Vehicle
                                            Purchase</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Inventory Schemes</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px">Operations No Adherence to Sonic Policy
                                            And Playbook</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Vendor Collusion</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Vendor Schemes</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Root Cause Other</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Detail Description of Root Cause</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Change a Control</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Current Systen Enhancement</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Implementation Policy</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">New System Change</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Results of Disposition Plan</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">ReTraining</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Training</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">CA Other</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px">Detail Description of Corrective Action
                                            andor Recommendation</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Close File</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Close Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Reopen File</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Reopen Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Comments</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px">Updated By</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 117px">Update Date</span>
                                    </th>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div style="overflow-y: scroll; width: 15020px; height: 425px;" id="divAP_Fraud_Events_Audit_Grid"
                        runat="server">
                        <asp:GridView ID="gvAP_Fraud_Events_Audit" runat="server" AutoGenerateColumns="False"
                            CellPadding="4" EnableTheming="true" EmptyDataText="No records found!" ShowHeader="false">
                            <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <Columns>
                                <asp:TemplateField HeaderText="Audit_DateTime">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAudit_DateTime" runat="server" Text='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                        ToolTip='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                        Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fraud_Number">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFraud_Number" runat="server" Text='<%#Eval("Fraud_Number")%>' Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Exposure_Period_Begin_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblExposure_Period_Begin_Date" runat="server" Text='<%#Eval("Exposure_Period_Begin_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Exposure_Period_Begin_Date"))) : ""%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Exposure_Period_End_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblExposure_Period_End_Date" runat="server" Text='<%#Eval("Exposure_Period_End_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Exposure_Period_End_Date"))) : ""%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Reported_To">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblReported_To" runat="server" Text='<%#Eval("Reported_To")%>' Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Reported_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblReported_Date" runat="server" Text='<%#Eval("Reported_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Reported_Date"))) : ""%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description_of_Event">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblDescription_of_Event" runat="server" Text='<%#Eval("Description_of_Event")%>'
                                            Width="160px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Customer_Relations_Hotline">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCustomer_Relations_Hotline" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Customer_Relations_Hotline"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Discovered_Fraud_through_Audits">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblDiscovered_Fraud_through_Audits" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Discovered_Fraud_through_Audits"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Internal_Audit_Control_Breakdown_leading_to_Fraud_Event">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblInternal_Audit_Control_Breakdown_leading_to_Fraud_Event" runat="server"
                                            Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Internal_Audit_Control_Breakdown_leading_to_Fraud_Event"))%>'
                                            Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Retail_Lending">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblRetail_Lending" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Retail_Lending"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sonic_Associates_1800_Hotline">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSonic_Associates_1800_Hotline" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Sonic_Associates_1800_Hotline"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Store_Red_Flags">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblStore_Red_Flags" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Store_Red_Flags"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Notification_Other">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblNotification_Other" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Notification_Other"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Other_Notification_Description">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblOther_Notification_Description" runat="server" Text='<%#Eval("Other_Notification_Description")%>'
                                            Width="160px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Internal_Review_Purification_Notes">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblInternal_Review_Purification_Notes" runat="server" Text='<%#Eval("Internal_Review_Purification_Notes")%>'
                                            Width="160px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fraud_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFraud_Date" runat="server" Text='<%#Eval("Fraud_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Fraud_Date"))) : ""%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="HR_Assignment">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblHR_Assignment" runat="server" Text='<%#Eval("HR_Assignment")%>'
                                            Width="160px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="HR_Associate_Contacted">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblHR_Associate_Contacted" runat="server" Text='<%#Eval("HR_Associate_Contacted")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_HR_Assigned">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate_HR_Assigned" runat="server" Text='<%#Eval("Date_HR_Assigned") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_HR_Assigned"))) : ""%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Internal_Audit_Assignment">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblInternal_Audit_Assignment" runat="server" Text='<%#Eval("Internal_Audit_Assignment")%>'
                                            Width="160px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Internal_Audit_Associate_Contacted">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblInternal_Audit_Associate_Contacted" runat="server" Text='<%#Eval("Internal_Audit_Associate_Contacted")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_Internal_Audit_Assigned">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate_Internal_Audit_Assigned" runat="server" Text='<%#Eval("Date_Internal_Audit_Assigned") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_Internal_Audit_Assigned"))) : ""%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Store_Controller_Assignment">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblStore_Controller_Assignment" runat="server" Text='<%#Eval("Store_Controller_Assignment")%>'
                                            Width="160px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Store_Controller_Associate_Contacted">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblStore_Controller_Associate_Contacted" runat="server" Text='<%#Eval("Store_Controller_Associate_Contacted")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_Store_Controller_Assigned">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate_Store_Controller_Assigned" runat="server" Text='<%#Eval("Date_Store_Controller_Assigned") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_Store_Controller_Assigned"))) : ""%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Regional_Controller_Assignment">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblRegional_Controller_Assignment" runat="server" Text='<%#Eval("Regional_Controller_Assignment")%>'
                                            Width="160px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Regional_Controller_Associate_Contacted">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblRegional_Controller_Associate_Contacted" runat="server" Text='<%#Eval("Regional_Controller_Associate_Contacted")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_Regional_Controller_Assigned">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate_Regional_Controller_Assigned" runat="server" Text='<%#Eval("Date_Regional_Controller_Assigned") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_Regional_Controller_Assigned"))) : ""%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Legal_Department_Assignment">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblLegal_Department_Assignment" runat="server" Text='<%#Eval("Legal_Department_Assignment")%>'
                                            Width="160px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Legal_Department_Associate_Contacted">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblLegal_Department_Associate_Contacted" runat="server" Text='<%#Eval("Legal_Department_Associate_Contacted")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_Legal_Department_Assigned">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate_Legal_Department_Assigned" runat="server" Text='<%#Eval("Date_Legal_Department_Assigned") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_Legal_Department_Assigned"))) : ""%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Outside_Legal_Assignment">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblOutside_Legal_Assignment" runat="server" Text='<%#Eval("Outside_Legal_Assignment")%>'
                                            Width="160px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Outside_Legal_Associate_Contacted">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblOutside_Legal_Associate_Contacted" runat="server" Text='<%#Eval("Outside_Legal_Associate_Contacted")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_Outside_Legal_Assigned">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate_Outside_Legal_Assigned" runat="server" Text='<%#Eval("Date_Outside_Legal_Assigned") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_Outside_Legal_Assigned"))) : ""%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Operations_Assignment">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblOperations_Assignment" runat="server" Text='<%#Eval("Operations_Assignment")%>'
                                            Width="160px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Operations_Associate_Contacted">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblOperations_Associate_Contacted" runat="server" Text='<%#Eval("Operations_Associate_Contacted")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_Operations_Assigned">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate_Operations_Assigned" runat="server" Text='<%#Eval("Date_Operations_Assigned") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_Operations_Assigned"))) : ""%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Retail_Lending_Assignment">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblRetail_Lending_Assignment" runat="server" Text='<%#Eval("Retail_Lending_Assignment")%>'
                                            Width="160px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Retail_Lending_Associate_Contacted">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblRetail_Lending_Associate_Contacted" runat="server" Text='<%#Eval("Retail_Lending_Associate_Contacted")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_Retail_Lending_Assigned">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate_Retail_Lending_Assigned" runat="server" Text='<%#Eval("Date_Retail_Lending_Assigned") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_Retail_Lending_Assigned"))) : ""%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="BT_Security_Assignment">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblBT_Security_Assignment" runat="server" Text='<%#Eval("BT_Security_Assignment")%>' CssClass="TextClip"
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="BT_Security_Associate_Contacted">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblBT_Security_Associate_Contacted" runat="server" Text='<%#Eval("BT_Security_Associate_Contacted")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_BT_Security_Assigned">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate_BT_Security_Assigned" runat="server" Text='<%#Eval("Date_BT_Security_Assigned") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_BT_Security_Assigned"))) : ""%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Other_Assignment">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblOther_Assignment" runat="server" Text='<%#Eval("Other_Assignment")%>' CssClass="TextClip"
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Other_Associate_Contacted">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblOther_Associate_Contacted" runat="server" Text='<%#Eval("Other_Associate_Contacted")%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date_Other_Assigned">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate_Other_Assigned" runat="server" Text='<%#Eval("Date_Other_Assigned") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_Other_Assigned"))) : ""%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="OnSite_Findings">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblOnSite_Findings" runat="server" Text='<%#Eval("OnSite_Findings")%>'
                                            Width="160px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="TLO_Findings">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblTLO_Findings" runat="server" Text='<%#Eval("TLO_Findings")%>' Width="160px"
                                            CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Statements_Obtained">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatements_Obtained" runat="server" Text='<%#Eval("Statements_Obtained")%>'
                                            Width="160px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fact_Finding_andor_Due_Diligence">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFact_Finding_andor_Due_Diligence" runat="server" Text='<%#Eval("Fact_Finding_andor_Due_Diligence")%>'
                                            Width="160px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Law_Enforcement_Involvement">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblLaw_Enforcement_Involvement" runat="server" Text='<%#Eval("Law_Enforcement_Involvement")%>'
                                            Width="160px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Civil_Actrion">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCivil_Actrion" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Civil_Actrion"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Crimimal_Action">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCrimimal_Action" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Crimimal_Action"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Further_Investigation">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFurther_Investigation" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Further_Investigation"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ACC_Suspension">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblACC_Suspension" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("ACC_Suspension"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ACC_Termination">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblACC_Termination" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("ACC_Termination"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ACC_Written">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblACC_Written" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("ACC_Written"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ACC_Verbal">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblACC_Verbal" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("ACC_Verbal"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Communication_Strategy">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCommunication_Strategy" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Communication_Strategy"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Disposition_Game_Plan_Other">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblDisposition_Game_Plan_Other" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Disposition_Game_Plan_Other"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Detailed_Deisposition_Game_Plan_Description">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblDetailed_Deisposition_Game_Plan_Description" runat="server" Text='<%#Eval("Detailed_Deisposition_Game_Plan_Description")%>'
                                            Width="160px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Accounting_Gaps_and_Controls">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAccounting_Gaps_and_Controls" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Accounting_Gaps_and_Controls"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Aging_MFR_Incentives">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAging_MFR_Incentives" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Aging_MFR_Incentives"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Aging_Warranties">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAging_Warranties" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Aging_Warranties"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Account_Payable_Schemes">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAccount_Payable_Schemes" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Account_Payable_Schemes"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Associate_Collusion">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAssociate_Collusion" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Associate_Collusion"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Billing_Schemes">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblBilling_Schemes" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Billing_Schemes"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="External_Scam">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblExternal_Scam" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("External_Scam"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Improper_Disclosure_to_Customer_F_and_I_Product_Purchase">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblImproper_Disclosure_to_Customer_F_and_I_Product_Purchase" runat="server"
                                            Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Improper_Disclosure_to_Customer_F_and_I_Product_Purchase"))%>'
                                            Width="220px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Improper_Disclosure_to_Customer_Vehicle_Purchase">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblImproper_Disclosure_to_Customer_Vehicle_Purchase" runat="server"
                                            Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Improper_Disclosure_to_Customer_Vehicle_Purchase"))%>'
                                            Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Inventory_Schemes">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblInventory_Schemes" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Inventory_Schemes"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Operations_No_Adherence_to_Sonic_Policy_And_Playbook">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblOperations_No_Adherence_to_Sonic_Policy_And_Playbook" runat="server"
                                            Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Operations_No_Adherence_to_Sonic_Policy_And_Playbook"))%>'
                                            Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vendor_Collusion">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblVendor_Collusion" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Vendor_Collusion"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vendor_Schemes">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblVendor_Schemes" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Vendor_Schemes"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Root_Cause_Other">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblRoot_Cause_Other" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Root_Cause_Other"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Detail_Description_of_Root_Cause">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblDetail_Description_of_Root_Cause" runat="server" Text='<%#Eval("Detail_Description_of_Root_Cause")%>'
                                            Width="160px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Change_a_Control">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblChange_a_Control" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Change_a_Control"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Current_Systen_Enhancement">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCurrent_Systen_Enhancement" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Current_Systen_Enhancement"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Implementation_Policy">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblImplementation_Policy" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Implementation_Policy"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="New_System_Change">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblNew_System_Change" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("New_System_Change"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Results_of_Disposition_Plan">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblResults_of_Disposition_Plan" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Results_of_Disposition_Plan"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ReTraining">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblReTraining" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("ReTraining"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Training">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblTraining" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Training"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CA_Other">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCA_Other" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("CA_Other"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Detail_Description_of_Corrective_Action_andor_Recommendation">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblDetail_Description_of_Corrective_Action_andor_Recommendation" runat="server"
                                            Text='<%#Eval("Detail_Description_of_Corrective_Action_andor_Recommendation")%>'
                                            Width="200px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Close_File">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblClose_File" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Close_File"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Close_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblClose_Date" runat="server" Text='<%#Eval("Close_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Close_Date"))) : ""%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Reopen_File">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblReopen_File" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Reopen_File"))%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Reopen_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblReopen_Date" runat="server" Text='<%#Eval("Reopen_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Reopen_Date"))) : ""%>'
                                            Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Comments">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblComments" runat="server" Text='<%#Eval("Comments")%>' Width="160px"
                                            CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Updated_By">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblUpdated_By" runat="server" Text='<%#Eval("Updated_By")%>' Width="160px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Update_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblUpdate_Date" runat="server" Text='<%#Eval("Update_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Update_Date"))) : ""%>'
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
