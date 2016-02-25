<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_PM_Hearing_Conservation.aspx.cs" Inherits="SONIC_Pollution_AuditPopup_PM_Hearing_Conservation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS Sonic :: PM Hearing Conservation Audit Trail</title>
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

        function showAudit_Financial(divHeader, divGrid) {
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

        function ChangeScrollBar_Financial(f, s) {
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
                        <div style="overflow: hidden; width: 650px;" id="divPM_Hearing_Conservation_Audit_Header"
                            runat="server">
                            <table cellpadding="4" cellspacing="0" style="width: 600px; border-collapse: collapse;">
                                <tbody>
                                    <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                        align="left">
                                        <th class="cols">
                                            <span style="display: inline-block; width: 160px">Audit DateTime</span>
                                        </th>
                                         <th class="cols">
                                            <span style="display: inline-block; width: 160px">Date of Test</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 160px">Associate</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 160px">Event Type</span>
                                        </th>
                                      <%--  <th class="cols">
                                            <span style="display: inline-block; width: 160px">Did the Location Exceed Noise Levels at the Time of the Test?</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 160px">Did the Test Results Show a Standard Threshold Shift?</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 160px">Has a Retest been Scheduled?</span>
                                        </th>--%>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 160px">Notes</span>
                                        </th>
                                      <%--  <th class="cols">
                                            <span style="display: inline-block; width: 160px">Building(s)</span>
                                        </th>--%>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 160px">Vendor</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 160px">Vendor Contact Name</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 160px">Vendor Address</span>  <%--Change Header text from Cal Atlantic to ACI as per client's request Bug ID = 2552--%>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 160px">Vendor City</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 160px">Vendor State</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 160px">Vendor Zip Code</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 160px">Vendor Telephone</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 160px">Vendor E-Mail</span>
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
                        <div style="overflow: scroll; width: 600px; height: 425px;" id="divPM_Hearing_Conservation_Audit_Grid"
                            runat="server">
                            <asp:GridView ID="gvPM_Hearing_Conservation_Audit" runat="server" AutoGenerateColumns="False"
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
                                    <asp:TemplateField HeaderText="Date_Of_Test">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblDate_Of_Test" runat="server" Text='<%#Eval("Date_Of_Test")%>' Style="word-wrap: normal; word-break: break-all"
                                                Width="160px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="FK_LU_Employee">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblFK_LU_Employee" runat="server" Text='<%#Eval("FK_LU_Employee")%>' Style="word-wrap: normal; word-break: break-all"
                                                Width="160px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="FK_LU_Hearing_Conservation_Test_Type">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblFK_LU_Hearing_Conservation_Test_Type" runat="server" Text='<%#Eval("FK_LU_Hearing_Conservation_Test_Type")%>' Style="word-wrap: normal; word-break: break-all"
                                                Width="160px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                 <%--   <asp:TemplateField HeaderText="Location_Exceed_Noise_Level">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblLocation_Exceed_Noise_Level" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Location_Exceed_Noise_Level"))%>' Style="word-wrap: normal; word-break: break-all"
                                                Width="160px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="STS_Shift">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblSTS_Shift" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("STS_Shift"))%>'
                                                Width="160px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Retest_Scheduled">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblRetest_Scheduled" runat="server" Text='<%#clsGeneral.FormatYesNoToDisplay(Eval("Retest_Scheduled"))%>'
                                                Width="160px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rested_Date">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblRested_Date" runat="server" Text='<%# clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Rested_Date")))%>'
                                                Width="160px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Notes">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblNotes" runat="server" style="word-wrap:normal;word-break:break-all;" Text='<%#Eval("Notes")%>'
                                                Width="160px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Vendor">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblVendor" runat="server" Text='<%#Eval("Vendor")%>'
                                                Width="160px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Vendor_Representative">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblVendor_Representative" runat="server" Text='<%#Eval("Vendor_Representative")%>'
                                                Width="160px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Vendor_Address">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblVendor_Address" runat="server" Text='<%#Eval("Vendor_Address")%>'
                                                Width="160px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Vendor_City">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblVendor_City" runat="server" Text='<%#Eval("Vendor_City")%>'
                                                Width="160px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="FK_Vendor_State">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblFK_Vendor_State" runat="server" Text='<%#Eval("FK_Vendor_State")%>'
                                                Width="160px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Vendor_Zip_Code">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblVendor_Zip_Code" runat="server" Text='<%#Eval("Vendor_Zip_Code")%>'
                                                Width="160px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Vendor_Telephone">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblVendor_Telephone" runat="server" Text='<%#Eval("Vendor_Telephone")%>'
                                                Width="160px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Vendor_EMail">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblVendor_EMail" runat="server" Text='<%#Eval("Vendor_EMail")%>'
                                                Width="160px"></asp:Label>
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
                        <br />
                        <br />
                        <table>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblPM_Hearing_Conservation_Buildings" runat="server" Style="font-weight: bold"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <div style="overflow-x: hidden; width: auto;" id="dvHeader" runat="server">
                            <table cellpadding="4" cellspacing="0" style="width: 600px; border-collapse: collapse;">
                                <tbody>
                                    <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                        align="left">
                                        <th class="cols">
                                            <span style="display: inline-block; width: 160px;">Audit DateTime</span>
                                        </th>                           
                                        <th class="cols">
                                            <span style="display: inline-block; width: 200px">Building Id</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 250px">Building Details</span>
                                        </th>                                     
                                        <th class="cols">
                                            <span style="display: inline-block; width: 160px;">Updated By</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 117px;">Update Date</span>
                                        </th>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div style="overflow-y: scroll; width: auto; height: 395px;" id="dvGrid" runat="server">
                            <asp:GridView ID="gvPM_Hearing_Conservation_Biuldings_Audit" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false">
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
                                    <%--                            <asp:TemplateField HeaderText="FK_AP_Property_Security">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_AP_Property_Security" runat="server" Text='<%#Eval("FK_AP_Property_Security")%>'
                                        Width="130px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="FK_Building">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblFK_Building" runat="server" Text='<%#Eval("FK_Building")%>'
                                                Width="200px" CssClass="TextClip"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Building_Details">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblBuilding_Details" runat="server" Text='<%#(Eval("Building_Details"))%>' Width="250px"></asp:Label>
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
                                                Width="117px"></asp:Label>
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
