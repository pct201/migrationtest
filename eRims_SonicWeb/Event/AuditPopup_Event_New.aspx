<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_Event_New.aspx.cs"
    Inherits="Event_AuditPopup_New_Event" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Risk Insurance Management System :: Event</title>
     <script language="javascript" type="text/javascript">
         function showAudit(divHeader, divGrid) {
             var divheight, i;

             divHeader.style.width = window.screen.availWidth - 225 + "px";
             divGrid.style.width = window.screen.availWidth - 225 + "px";

             divheight = divGrid.style.height;
             i = divheight.indexOf('px');

             if (i > -1)
                 divheight = divheight.substring(0, i);
             if (divheight > (window.screen.availHeight - 350) && divGrid.style.height != "") {
                 divGrid.style.height = window.screen.availHeight - 350;
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
                <div style="overflow: hidden; width: 600px;" id="divgv_Event_Header" runat="server">
                    <table cellpadding="4" cellspacing="0" style="width: 600px; border-collapse: collapse;"
                        width="100%">
                        <tbody>
                            <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                align="left">
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Audit DateTime</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Event Number</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">ACI Event ID</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Date of Event</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Location</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Investigator Name</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Investigator Email</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Investigator Phone</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Agency Name</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Officer Name</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Officer Phone</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Police Report Number</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Event Status</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Date Closed</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Police Called</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Monitoring Hours</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Sonic Contact Name</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Sonic Contact Email</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Sonic Contact Phone</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Financial Loss</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Updated By</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Update Date</span>
                                </th>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div style="overflow: scroll; width: 600px; height: 425px;" id="divgvEvent_Audit_Grid"
                    runat="server">
                    <asp:GridView ID="gvEvent_Audit" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        CellSpacing="0" EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false"
                        Width="93%">
                        <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <Columns>
                            <asp:TemplateField HeaderText="Audit_DateTime">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAudit_DateTime" runat="server" Text='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Event_Number">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblEvent_Number" runat="server" Text='<%#Eval("Event_Number")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Event_Id">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblEvent_Id" runat="server" Text='<%#Eval("ACI_EventID")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date_of_Event">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDate_of_Event" runat="server" Text='<%#Eval("Event_Start_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Event_Start_Date"))) : ""%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Location">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblLocation" runat="server" Text='<%#Eval("Location")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Investigator_Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblInvestigator_Name" runat="server" Text='<%#Eval("Investigator_Name")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Investigator_Email">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblInvestigator_Email" runat="server" Text='<%#Eval("Investigator_Email")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Investigator_Phone">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblInvestigator_Phone" runat="server" Text='<%#Eval("Investigator_Phone")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Agency_name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAgency_name" runat="server" Text='<%#Eval("Agency_name")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Officer_Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblOfficer_Name" runat="server" Text='<%#Eval("Officer_Name")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Officer_Phone">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblOfficer_Phone" runat="server" Text='<%#Eval("Officer_Phone")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Police_Report_Number">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPolice_Report_Number" runat="server" Text='<%#Eval("Police_Report_Number")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Event_Status")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date_Closed">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDate_Closed" runat="server" Text='<%#Eval("Date_Closed") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_Closed"))) : ""%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Police_Called">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPolice_Called" runat="server" Text='<%#Eval("Police_Called")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Monitoring_Hours">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblMonitoring_Hours" runat="server" Text='<%#Eval("Monitoring_Hours")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sonic_Contact_Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSonic_Contact_Name" runat="server" Text='<%#Eval("Sonic_Contact_Name")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sonic_Contact_Email">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSonic_Contact_Email" runat="server" Text='<%#Eval("Sonic_Contact_Email")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Sonic_Contact_Phone">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSonic_Contact_Phone" runat="server" Text='<%#Eval("Sonic_Contact_Phone")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Financial_Loss">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFinancial_Loss" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Financial_Loss"))%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Updated_By">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUpdated_By" runat="server" Text='<%#Eval("Updated_By")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Update_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUpdate_Date" runat="server" Text='<%#Eval("Update_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Update_Date"))) : ""%>'
                                        Width="133px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
