<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_PM_Respiratory_Protection.aspx.cs"
    Inherits="SONIC_Pollution_AuditPopup_PM_Respiratory_Protection" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS Sonic :: PM Respiratory Protection Audit Trail</title>
</head>
<script language="javascript" type="text/javascript">
    function showAudit(divHeader, divGrid) {
        var divheight, i;

        divHeader.style.width = window.screen.availWidth - 510 + "px";
        divGrid.style.width = window.screen.availWidth - 510 + "px";

        divheight = divGrid.style.height;
        i = divheight.indexOf('px');

        if (i > -1)
            divheight = divheight.substring(0, i);
        if (divheight > (window.screen.availHeight - 480) && divGrid.style.height != "") {
            divGrid.style.height = window.screen.availHeight - 480;
        }
    }

    function ChangeScrollBar(f, s) {
        s.scrollTop = f.scrollTop;
        s.scrollLeft = f.scrollLeft;
    }
</script>
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
                <div style="overflow: hidden; width: 300px;" id="divPM_Respiratory_Protection_Header" runat="server">
                    <table cellpadding="4" cellspacing="0" style="width: 300px; border-collapse: collapse;">
                        <tbody>
                            <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                align="left">
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 110px;">Audit DateTime</span>
                                </th>
                                 <%--<th class="cols" align="left">
                                    <span style="display: inline-block; width: 160px;">PK_PM_Waste_Removal</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 160px;">FK_PM_Site_Information</span>
                                </th>--%>
                                 <th class="cols" align="left">
                                    <span style="display: inline-block; width: 110px;">Date</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">Associate</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">Event Type</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">Medical Evaluation</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">Training Completed</span>
                                </th>
                                <th class="cols" align="right">
                                    <span style="display: inline-block; width: 200px;">Fit Test Completed?</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">Vendor</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">Vendor Representative Name</span>
                                </th>
                                  <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">Vendor Street Address</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 150px;">Vendor City</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 180px;">Vendor State</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 180px;">Vendor Zip Code</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 120px;">Vendor Telephone</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 120px;">Vendor E-Mail</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 120px;">Updated By</span>
                                </th>
                                <th class="cols" align="left">
                                    <span style="display: inline-block; width: 117px;">Update Date</span>
                                </th>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div style="overflow: scroll; width: 300px; height: 400px;" id="divPM_Respiratory_Protection_Grid"
                    runat="server">
                    <asp:GridView ID="gvPMWasteRemoval" runat="server" AutoGenerateColumns="False" Style="word-wrap: normal; word-break: break-all;"
                        CellPadding="4" EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false">
                        <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <Columns>
                            <asp:TemplateField HeaderText="Audit_DateTime">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAudit_DateTime" runat="server" Text='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                        ToolTip='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                        Width="110px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <%--<asp:TemplateField HeaderText="PK_PM_Waste_Removal">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPK_PM_Waste_Removal" runat="server" Text='<%#Eval("PK_PM_Waste_Removal")%>'
                                        Width="160px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_PM_Site_Information">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_PM_Site_Information" runat="server" Text='<%#Eval("FK_PM_Site_Information")%>'
                                        Width="160px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                           <asp:TemplateField HeaderText="Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDate" runat="server" Text='<%#Eval("Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date"))) : ""%>'
                                        Width="110px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Employee Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_Employee" runat="server" Text='<%#Eval("EmployeeName")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Event Type">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_Event_Type" runat="server" Text='<%#Eval("EventType")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Medical Evaluation">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblMedical_Evaluation" runat="server" Text='<%#Eval("MedicalEvaluation")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Training Completed">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblTraining_Completed" runat="server" Text='<%#Eval("TrainingCompleted")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FitTest">
                                <ItemStyle CssClass="cols" HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFitTest" runat="server" Text='<%#Eval("FitTest")%>'
                                        Width="200px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Vendor">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblVendor" runat="server" Text='<%#Eval("Vendor")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Vendor_Representative">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblVendor_Representative" runat="server" Text='<%#Eval("Vendor_Representative")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Vendor_Address">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblVendor_Address" runat="server" Text='<%#Eval("Vendor_Address")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Vendor_City">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblVendor_City" runat="server" Text='<%#Eval("Vendor_City")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Vendor_State">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_Vendor_State" runat="server"  Text='<%#Eval("Vendor_State")%>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Vendor_Zip_Code">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblVendor_Zip_Code" runat="server" Text='<%#Eval("Vendor_Zip_Code")%>'
                                        Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Vendor Telephone">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblVendor_Telephone" runat="server" Text='<%#Eval("Vendor_Telephone")%>' Width="120px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Vendor E-Mail">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblVendor_EMail" runat="server" Text='<%#Eval("Vendor_EMail")%>' Width="120px" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Updated_By">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUpdated_By" runat="server" Text='<%#Eval("Updated_By")%>' Width="120px"></asp:Label>
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
    </form>
</body>
</html>
