<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_PM_Paint_Inventory.aspx.cs"
    Inherits="SONIC_Pollution_AuditPopup_PM_Paint_Inventory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS Sonic :: PM Paint Inventory Audit Trail</title>
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
        if (divheight > (window.screen.availHeight - 465) && divGrid.style.height != "") {
            divGrid.style.height = window.screen.availHeight - 465;
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
                <div style="overflow: hidden; width: 300px;" id="divPM_Permits_Header" runat="server">
                    <table cellpadding="4" cellspacing="0" style="width: 300px; border-collapse: collapse;">
                        <tbody>
                            <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                align="left">
                                <th class="cols">
                                    <span style="display: inline-block; width: 110px;">Audit DateTime</span>
                                </th>
                                
                                <%--<th class="cols">
                                    <span style="display: inline-block; width: 100px;">Compliance Reporting</span>
                                </th>--%>
                                <th class="cols">
                                    <span style="display: inline-block; width: 140px;">Paint Type</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 140px;">CAS Number</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Pure Mixture</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Paint Color</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 200px;">Mixture Components</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 200px;">Product Identification Number</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Product Name</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Manufacturer</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 200px;">Synonyms</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Issue Date</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 150px;">Edition Number</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Chemical Family</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 200px;">MSDS Number</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 200px;">Emergency Overview</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 200px;">Composition Information</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Storage Type</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Storage Location</span>
                                </th>
                                <%--<th class="cols">
                                    <span style="display: inline-block; width: 100px;">Supplier</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Date Purchased</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Amount Purchased</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Units</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Start Date</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">End Date</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 110px;">Amount Used</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Ending Inventory</span>
                                </th>--%>
                                
                                <th class="cols">
                                    <span style="display: inline-block; width: 100px;">Updated By</span>
                                </th>
                                <th class="cols">
                                    <span style="display: inline-block; width: 117px;">Update Date</span>
                                </th>
                                
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div style="overflow: scroll; width: 300px; height: 400px;" id="divPM_Permits_Grid"
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
                            
                            <%--<asp:TemplateField HeaderText="FK_PM_Compliance_Reporting">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_PM_Compliance_Reporting" runat="server" Text='<%#Eval("FK_PM_Compliance_Reporting")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="FK_LU_Paint_Type">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_Paint_Type" runat="server" Text='<%#Eval("Paint_Type")%>'
                                        Width="140px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CAS_Number">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCAS_Number" runat="server" Text='<%#Eval("CAS_Number")%>' Width="140px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Pure_Mixture">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPure_Mixture" runat="server" Text='<%#(Eval("Pure_Mixture").ToString() == "" ? "" : (Eval("Pure_Mixture").ToString() == "M" ? "Mixture":"Pure"))%>' Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Paint_Color">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPaint_Color" runat="server" Text='<%#Eval("Paint_Color")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mixture_Components">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblMixture_Components" runat="server" Text='<%#Eval("Mixture_Components")%>'
                                        Width="200px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Product_Identification_Number">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblProduct_Identification_Number" runat="server" Text='<%#Eval("Product_Identification_Number")%>'
                                        Width="200px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Product_Name">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblProduct_Name" runat="server" Text='<%#Eval("Product_Name")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Manufacturer">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblManufacturer" runat="server" Text='<%#Eval("Manufacturer")%>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Synonyms">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSynonyms" runat="server" Text='<%#Eval("Synonyms")%>' Width="200px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Issue_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblIssue_Date" runat="server" Text='<%#Eval("Issue_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Issue_Date"))) : ""%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edition_Number">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblEdition_Number" runat="server" Text='<%#Eval("Edition_Number")%>'
                                        Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_LU_Chemical_Family">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_Chemical_Family" runat="server" Text='<%#Eval("Chemical_Family")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MSDS_Number">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblMSDS_Number" runat="server" Text='<%#Eval("MSDS_Number")%>' Width="200px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Emergency_Overview">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblEmergency_Overview" runat="server" Text='<%#Eval("Emergency_Overview")%>'
                                        Width="200px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Composition_Information">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblComposition_Information" runat="server" Text='<%#Eval("Composition_Information")%>'
                                        Width="200px" CssClass="TextClip"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_LU_Storage_Type">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_Storage_Type" runat="server" Text='<%#Eval("Storage_Type")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_LU_Storage_Location">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_Storage_Location" runat="server" Text='<%#Eval("Storage_Location")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="Supplier">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSupplier" runat="server" Text='<%#Eval("Supplier")%>' Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date_Purchased">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDate_Purchased" runat="server" Text='<%#Eval("Date_Purchased") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_Purchased"))) : ""%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount_Purchased">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAmount_Purchased" runat="server" Text='<%#Eval("Amount_Purchased")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FK_LU_Units">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFK_LU_Units" runat="server" Text='<%#Eval("Units")%>' Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Start_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblStart_Date" runat="server" Text='<%#Eval("Start_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Start_Date"))) : ""%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="End_Date">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblEnd_Date" runat="server" Text='<%#Eval("End_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("End_Date"))) : ""%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ammount_Used">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAmmount_Used" runat="server" Text='<%# string.Format("{0:N2}", Eval("Ammount_Used"))%>' Width="110px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ending_Inventory">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblEnding_Inventory" runat="server" Text='<%#Eval("Ending_Inventory")%>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            
                            <asp:TemplateField HeaderText="Updated_By">
                                <ItemStyle CssClass="cols" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUpdated_By" runat="server" Text='<%#Eval("Updated_By1")%>' Width="100px"></asp:Label>
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
