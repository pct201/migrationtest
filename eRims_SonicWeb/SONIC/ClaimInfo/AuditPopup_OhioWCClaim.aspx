<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_OhioWCClaim.aspx.cs"
    Inherits="SONIC_FirstReport_AuditPopup_OhioWCClaim" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Risk Insurance Management System</title>

    <script language="javascript" type="text/javascript">
        function showAudit(divHeader, divGrid) {
            var divheight, i;

            divHeader.style.width = window.screen.availWidth - 255 + "px";
            divGrid.style.width = window.screen.availWidth - 255 + "px";

            divheight = divGrid.style.height;
            i = divheight.indexOf('px');

            if (i > -1)
                divheight = divheight.substring(0, i);
            if (divheight > (window.screen.availHeight - 350) && divGrid.style.height != "") {
                divGrid.style.height = window.screen.availHeight - 350;
            }

            //if (divHeader.style.width.substring(0, divHeader.style.width.indexOf('px')) > 1100)
            //{ divHeader.style.width = '1100px'; divGrid.style.width = '1100px'; }

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
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="lbltable_Name" runat="server" Text="Workers_Comp_Claims_OH_Audit"
                            Font-Bold="true"></asp:Label>
                    </td>
                    <td align="right">
                        <a href="javascript:window.close();">Close Window</a>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="left">
                        <div style="overflow: hidden; width: 1100px;" id="divWC_FR_Header" runat="server">
                            <table align="left" cellpadding="4" cellspacing="0" style="border-collapse: collapse; width: 900px;">
                                <tbody>
                                    <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                        align="left">
                                        <th class="cols">
                                            <span style="display: inline-block; width: 150px">Audit_DateTime</span>
                                        </th>
                                      <%--  <th class="cols">
                                            <span style="display: inline-block; width: 140px">FK_WC_RD_Id</span>
                                        </th>--%>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 140px">Claim Number</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 140px">FROI_Number</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 140px">Sonic Location Code</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 140px">Associate Name</span>
                                        </th>                                    
                                        <th class="cols">
                                            <span style="display: inline-block; width: 120px">Date Entered</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 120px">Date Closed</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 120px">Date Reopened</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 120px">Active_Inactive</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 160px">Date_Of_First_Transaction</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 140px">Total_Paid_To_Date</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 140px">Date_Of_Incident</span>
                                        </th>
                                        <%--<th class="cols">
                                            <span style="display: inline-block; width: 120px">Type</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 120px">Total_Medical</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 120px">Total_Comp</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 120px">Total_Reserve</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 120px">Unlimited_Cost</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 120px">Limited_to_MV</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 120px">HC_Percent</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 120px">HC_Relief</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 120px">Subrogation_Collected</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 120px">Claim_Activity</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 120px">Total_Charged</span>
                                        </th>--%>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 120px">Imported</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 120px">Updated By</span>
                                        </th>
                                        <th class="cols">
                                            <span style="display: inline-block; width: 117px">Update Date</span>
                                        </th>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div style="overflow: scroll; width: 1100px; height: 425px;" id="divWC_FR_Grid" runat="server">
                            <asp:GridView ID="gvWC_FRName" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                EnableTheming="true" EmptyDataText="No records found!" ShowHeader="false">
                                <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Audit Date Time">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblAudit_DateTime" runat="server" Text='<%#Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                                ToolTip='<%#Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                                Width="150px"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                   <%-- <asp:TemplateField HeaderText="FK_WC_RD_Id">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label Width="140px" ID="lblFK_WC_RD_Id" runat="server" Text='<%#Eval("FK_WC_RD_Id")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Claim_Number">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label Width="140px" ID="lblClaim_Number" runat="server" Text='<%#Eval("Origin_Claim_Number")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="FROI_Number">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label Width="140px" ID="lblFROI_Number" runat="server" Text='<%#Eval("FROI_Number")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sonic_Location_Code">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label Width="140px" ID="lblSonic_Location_Code" runat="server" Text='<%#Eval("Sonic_Location_Code")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date_Entered">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label Width="140px" ID="lblDate_Entered" runat="server" Text='<%#Eval("Associate_Name")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Date_Claim_Opened">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label Width="120px" ID="lblDate_Claim_Opened" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Date_Claim_Opened"))%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date_Closed">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label Width="120px" ID="lblDate_Closed" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Date_Claim_Closed"))%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date_Reopened">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label Width="120px" ID="lblDate_Reopened" runat="server" Text=' <%#clsGeneral.FormatDBNullDateToDisplay(Eval("Date_Claim_Reopened"))%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Active_Inactive">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label Width="120px" ID="lblActive_Inactive" runat="server" Text='<%#Eval("Claim_Status")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Date_Of_First_Transaction">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label Width="160px" ID="lblDate_Of_First_Transaction" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Date_Of_First_Transaction"))%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Total_Paid_To_Date">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label Width="140px" ID="lblTotal_Paid_To_Date" runat="server" Text='<%#Eval("Total_Paid_To_Date")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date_Of_Incident">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label Width="140px" ID="lblDate_Of_Incident" runat="server" Text='<%#Eval("Date_Of_Incident")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
         <%--                           <asp:TemplateField HeaderText="Type">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label Width="120px" ID="lblType" runat="server" Text='<%#Eval("Type")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total_Medical">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label Width="120px" ID="lblTotal_Medical" runat="server" Text='<%#Eval("Total_Medical")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total_Comp">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label Width="120px" ID="lblTotal_Comp" runat="server" Text='<%#Eval("Total_Comp")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total_Reserve">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label Width="120px" ID="lblTotal_Reserve" runat="server" Text='<%#Eval("Total_Reserve")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unlimited_Cost">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label Width="120px" ID="lblUnlimited_Cost" runat="server" Text='<%#Eval("Unlimited_Cost")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Limited_to_MV">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label Width="120px" ID="lblLimited_to_MV" runat="server" Text='<%#Eval("Limited_to_MV")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="HC_Percent">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label Width="120px" ID="lblHC_Percent" runat="server" Text='<%#Eval("HC_Percent")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="HC_Relief">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label Width="120px" ID="lblHC_Relief" runat="server" Text='<%#Eval("HC_Relief")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Subrogation_Collected">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label Width="120px" ID="lblSubrogation_Collected" runat="server" Text='<%#Eval("Subrogation_Collected")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Claim_Activity">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label Width="120px" ID="lblClaim_Activity" runat="server" Text='<%#Eval("Claim_Activity")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total_Charged">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label Width="120px" ID="lblTotal_Charged" runat="server" Text='<%#Eval("Total_Charged")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Imported">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label Width="120px" ID="lblImported" runat="server" Text='<%#Eval("Imported")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Updated_By">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label Width="120px" ID="lblUpdated_By" runat="server" Text=' <%#Eval("Updated_By")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Update_Date">
                                        <ItemStyle CssClass="cols" />
                                        <ItemTemplate>
                                            <asp:Label Width="100px" ID="lblUpdate_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Update_Date"))%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
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
