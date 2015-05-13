<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_Management.aspx.cs"
    Inherits="Management_AuditPopup_Management" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Risk Insurance Management System :: Management </title>
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
                <div style="overflow: hidden; width: 600px;" id="divgv_Management_Header" runat="server">
                    <table cellpadding="4" cellspacing="0" style="width: 600px; border-collapse: collapse;"
                        width="100%">
                        <tbody>
                            <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                align="left">
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Audit DateTime</span>
                                </th>
                                <%--<th class="cols">
                                    <span style="display: inline-block; width: 150px;">Company</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Company Phone</span>
                                </th>--%>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">DBA</span>
                                </th>
                                <%--<th class="cols">
                                    <span style="display: inline-block; width: 150px;">State</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">City</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Region</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">County</span>
                                </th>--%>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Location Code</span>
                                </th>
                               <%-- <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Camera Number</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Camera Type</span>
                                </th>--%>
                                 <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Date Scheduled</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Date Complete</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Work To Be Completed</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Work To Be Completed By</span>
                                </th>
                                <%--<th class="cols">
                                    <span style="display: inline-block; width: 150px;">Sonic Task</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">ACI Task</span>
                                </th>--%>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Service/Repair Cost</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">CR Approved</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Record Type</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Job #</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Order #</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Order Date</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Requested By</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Created By</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Previous Contract Amount</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Revised Contract Amount</span>
                                </th>
                                <%--<th class="cols">
                                    <span style="display: inline-block; width: 300px;">Camera Concern</span>
                                </th>--%>
                                <th class="cols">
                                    <span style="display: inline-block; width: 300px;">Reason for Request</span>
                                </th>

                                <th class="cols">
                                    <span style="display: inline-block; width: 300px;">Recommendation</span>
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
                <div style="overflow: scroll; width: 600px; height: 425px;" id="divgvManagement_Audit_Grid"
                    runat="server">
                    <asp:GridView ID="gvManagement_Audit" runat="server" AutoGenerateColumns="False" Style="word-wrap: normal; word-break: break-all;"
                        CellPadding="4" CellSpacing="0" EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false"
                        Width="100%">
                        <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <Columns>
                            <asp:TemplateField HeaderText="Audit_DateTime">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAudit_DateTime" runat="server" Text='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="Company">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCompany" runat="server" Text='<%#Eval("Company")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Company_Phone">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCompany_Phone" runat="server" Text='<%#Eval("Company_Phone")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Location">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_Location" runat="server" Text='<%#Eval("Location")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Location Code">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblLocation_Code" runat="server" Text='<%#Eval("Location_Code")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="State">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_State" runat="server" Text='<%#Eval("State")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="City">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCity" runat="server" Text='<%#Eval("City")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Region">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_Region" runat="server" Text='<%#Eval("Region")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="County">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCounty" runat="server" Text='<%#Eval("County")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Camera Number">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_Camera_Number" runat="server" Text='<%#Eval("Camera_Number")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Camera Type">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_Camera_Type" runat="server" Text='<%#Eval("CameraType")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                               <asp:TemplateField HeaderText="Date_Scheduled">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDate_Scheduled" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Date_Scheduled")) %>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date_Complete">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDate_Complete" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Date_Complete")) %>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Work Completed">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_Work_Completed" runat="server" Text='<%#Eval("Work_Completed")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="Work Completed By">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblWork_Completed_By" runat="server" Text='<%#Convert.ToString(Eval("Work_Completed_By"))=="Y"?"Yes":Convert.ToString(Eval("Work_Completed_By"))=="N"?"No":""%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                         <%--   <asp:TemplateField HeaderText="Client Issue">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_Client_Issue" runat="server" Text='<%#Convert.ToString(Eval("FK_LU_Client_Issue"))=="Y"?"Yes":Convert.ToString(Eval("FK_LU_Client_Issue"))=="N"?"No":""%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Facilities Issue">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_Facilities_Issue" runat="server" Text='<%#Convert.ToString(Eval("FK_LU_Facilities_Issue"))=="Y"?"Yes":Convert.ToString(Eval("FK_LU_Facilities_Issue"))=="N"?"No":""%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <%--<asp:TemplateField HeaderText="Cost">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCost" runat="server" Text='<%#Eval("Cost")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Service Cost">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblService_RepairCost" runat="server" Text='<%# string.Format("{0:C2}",Eval("Service_Repair_Cost")) %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="CR_Approved">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCR_Approved" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("CR_Approved")) %>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Record Type">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblRecord_Type" runat="server" Text='<%#Eval("Record_Type")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Job">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblJob" runat="server" Text='<%#Eval("Job")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Order">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblOrder" runat="server" Text='<%#Eval("Order")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Order_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblOrder_Date" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay(Eval("Order_Date")) %>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Requested_By">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblRequested_By" runat="server" Text='<%#Eval("Requested_By")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Created_By">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCreated_By" runat="server" Text='<%#Eval("Created_By")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Previous Contract Amount">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPrevious_Contract_Amount" runat="server" Text='<%# string.Format("{0:C2}",Eval("Previous_Contract_Amount")) %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Revised Contract Amount">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblRevised_Contract_Amount" runat="server" Text='<%# string.Format("{0:C2}",Eval("Revised_Contract_Amount")) %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                           <%-- <asp:TemplateField HeaderText="Camera_Concern">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCamera_Concern" runat="server" Text='<%#Eval("Camera_Concern")%>'
                                        Width="300px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                             <asp:TemplateField HeaderText="Reason_for_Request">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblReason_for_Request" runat="server" Text='<%#Eval("Reason_for_Request")%>'
                                        Width="300px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Recommendation">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblRecommendation" runat="server" Text='<%#Eval("Recommendation")%>'
                                        Width="300px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Updated_By">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUpdated_By" runat="server" Text='<%#Eval("Updated_By")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Updated_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUpdated_Date" runat="server" Text='<%#Eval("Update_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Update_Date"))) : ""%>'
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
