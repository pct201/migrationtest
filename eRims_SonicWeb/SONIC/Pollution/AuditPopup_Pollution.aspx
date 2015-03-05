<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_Pollution.aspx.cs"
    Inherits="SONIC_Pollution_AuditPopup_Pollution" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS Sonic :: Site Information Audit Trail</title>
    <style type="text/css">
        body {
            overflow: hidden;
        }
    </style>
</head>

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
                    <div style="overflow: hidden; width: 650px;" id="divPollution" runat="server">
                        <table cellpadding="4" cellspacing="0" style="width: 600px; border-collapse: collapse;">
                            <tbody>
                                <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                    align="left">
                                    <th class="cols" align="left">
                                        <span style="display: inline-block; width: 110px;">Audit DateTime</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Location</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">Building</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">County</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">SIC Code</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">NAICS Code</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Number of Employees</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Number of Shifts</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Days Per Week</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Weeks Per Year</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Facility Construction Completion Year</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Owner of Facility</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Latitude</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Longitude</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Federal Facility Identification Number</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">State Facility Identification Number</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Contact Name</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Contact Telephone</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Emergency Contact Name</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Emergency Contact Telephone</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 300px;">Remediation Notes</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 300px;">Waste Disposal Notes</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 300px;">Audit Inspections Notes</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 300px;">Violation Main Notes</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Updated by</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 117px;">Updated date</span>
                                    </th>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div style="overflow: scroll; width: 600px; height: 395px;" id="divPollution_Grid"
                        runat="server">
                        <asp:GridView ID="gvSIUtilityProvider" runat="server" AutoGenerateColumns="False"
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
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFK_LU_Location" runat="server" Text='<%#Eval("FK_LU_Location")%>'
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFK_Building" runat="server" Text='<%#Eval("FK_Building")%>'
                                            Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFLD_county" runat="server" Text='<%#Eval("FLD_county")%>'
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFK_LU_SIC" runat="server" Text='<%#Eval("FK_LU_SIC")%>'
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFK_LU_NAICS" runat="server" Text='<%#Eval("FK_LU_NAICS")%>'
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblNumber_Of_Employees" runat="server" Text='<%# string.Format("{0:N0}", Eval("Number_Of_Employees"))%>'
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblNumber_Of_Shift" runat="server" Text='<%#Eval("Number_Of_Shift")%>'
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblDays_Per_Week" runat="server" Text='<%#Eval("Days_Per_Week")%>'
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblWeeks_Per_Year" runat="server" Text='<%#Eval("Weeks_Per_Year")%>'
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFacility_Construction_Completion_Year" runat="server" Text='<%#Eval("Facility_Construction_Completion_Year")%>'
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblOwner_Of_Facility" runat="server" Text='<%#Eval("Owner_Of_Facility")%>'
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblLatitude" runat="server" Text='<%#Eval("Latitude")%>'
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblLongitude" runat="server" Text='<%#Eval("Longitude")%>'
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFederal_Facility_Identification_Number" runat="server" Text='<%#Eval("Federal_Facility_Identification_Number")%>'
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblState_Facility_Identification_Number" runat="server" Text='<%#Eval("State_Facility_Identification_Number")%>'
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblContact_Name" runat="server" Text='<%#Eval("Contact_Name")%>'
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblContact_Telephone" runat="server" Text='<%#Eval("Contact_Telephone")%>'
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmergency_Contact_Name" runat="server" Text='<%#Eval("Emergency_Contact_Name")%>'
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmergency_Telephone" runat="server" Text='<%#Eval("Emergency_Telephone")%>'
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:TemplateField>
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPK_PM_Remediation" runat="server" Text='<%#Eval("PK_PM_Remediation")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblRNotes" runat="server" Text='<%#Eval("RNotes")%>'
                                            Width="300px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblWNotes" runat="server" Text='<%#Eval("WNotes")%>'
                                            Width="300px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblANotes" runat="server" Text='<%#Eval("ANotes")%>'
                                            Width="300px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblVNotes" runat="server" Text='<%#Eval("VNotes")%>'
                                            Width="300px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Updated_By">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblUpdated_By" runat="server" Text='<%#Eval("Updated_By")%>' Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Update_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblUpdate_Date" runat="server" Text='<%#Eval("Update_Date")!= DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Update_Date"))) : ""%>'
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
