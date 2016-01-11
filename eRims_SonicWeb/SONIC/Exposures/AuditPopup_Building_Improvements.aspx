<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_Building_Improvements.aspx.cs" Inherits="SONIC_Exposures_AuditPopup_Building_Improvements" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eRIMS Sonic :: Building_Improvements Audit Trail</title>
</head>
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
                    <div style="overflow: hidden; width: 650px;" id="dvHeader" runat="server">
                        <table cellpadding="4" cellspacing="0" style="width: 3950px; border-collapse: collapse;">
                            <tbody>
                                <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                    align="left">
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Audit_DateTime</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px;">PK_Building_Improvements</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">FK_Building</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">Improvement_Description</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px;">Service_Capacity_Increase</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">Revised_Square_Footage_Sales</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 250px;">Revised_Square_Footage_Service</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">Revised_Square_Footage_Parts</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">Revised_Square_Footage_Other</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Improvement_Value</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 150px;">Completion_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 110px;">Updated_By</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 115px;">Updated_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 115px;">Project Number</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 115px;">Start_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">Target_Completion_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 115px;">Contact_Name</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 115px;">New_Build</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 115px;">Open</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">Project_Status_As_Of_Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 115px;">FK_LU_BI_Status</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 115px;">Status_Other</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">Revised_Square_Footage</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 250px;">Revised_Square_Footage_Service_Lane</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 200px;">Total_Square_Footage_Revised</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px;">Budget_Construction</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 115px;">Budget_Land</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 115px;">Budget_Misc</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px;">Budget_SubTotal_1</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 115px;">Budget_IT</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 115px;">Budget_Furniture</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 115px;">Budget_Equipment</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 115px;">Budget_Signage</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 130px;">Budget_SubTotal_2</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 132px;">Budget_Total</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 132px;">Item_1</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 132px;">Item_2</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 132px;">Item_3</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 132px;">Item_4</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 132px;">Item_5</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 132px;">Item_6</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 132px;">Item_7</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 260px;">Number_of_Havac_Before_Improvements</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 260px;">Number_of_Havac_After_Improvements</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 180px;">Roof_Improvement_Details</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 160px;">Additional_Replace</span>
                                    </th>

                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div style="overflow: scroll; width: 3950px; height: 425px;" id="dvGrid" runat="server">
                        <asp:GridView ID="gvBuildingImprovements" runat="server" AutoGenerateColumns="False"
                            CellPadding="4" EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false">
                            <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <Columns>
                                <asp:TemplateField HeaderText="Audit_DateTime">
                                    <ItemStyle CssClass="cols" Width="100px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAudit_DateTime" runat="server" Text='<%#Eval("Audit_DateTime") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Audit_DateTime"))) : ""%>' Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PK_Building_Improvements">
                                    <ItemStyle CssClass="cols" Width="180px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblPK_Building_Improvements" runat="server" Text='<%#Eval("PK_Building_Improvements")%>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_Property_Cope">
                                    <ItemStyle CssClass="cols" Width="150px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFK_Property_Cope" runat="server" Text='<%#Eval("FK_Property_Cope")%>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Improvement_Description">
                                    <ItemStyle CssClass="cols" Width="200px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblImprovement_Description" runat="server" Text='<%#Eval("Improvement_Description")%>' Width="200px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Service_Capacity_Increase">
                                    <ItemStyle CssClass="cols" Width="180px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblService_Capacity_Increase" runat="server" Text='<%#Eval("Service_Capacity_Increase")%>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Revised_Square_Footage_Sales">
                                    <ItemStyle CssClass="cols" Width="200px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblRevised_Square_Footage_Sales" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Revised_Square_Footage_Sales")).Replace(".00","")%>' Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Revised_Square_Footage_Service">
                                    <ItemStyle CssClass="cols" Width="250px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblRevised_Square_Footage_Service" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Revised_Square_Footage_Service")).Replace(".00","")%>' Width="250px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Revised_Square_Footage_Parts">
                                    <ItemStyle CssClass="cols" Width="200px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblRevised_Square_Footage_Parts" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Revised_Square_Footage_Parts")).Replace(".00","")%>' Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Revised_Square_Footage_Other">
                                    <ItemStyle CssClass="cols" Width="200px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblRevised_Square_Footage_Other" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Revised_Square_Footage_Other")).Replace(".00","")%>' Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Improvement_Value">
                                    <ItemStyle CssClass="cols" Width="150px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblImprovement_Value" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Improvement_Value"))%>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Completion_Date">
                                    <ItemStyle CssClass="cols" Width="150px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCompletion_Date" runat="server" Text='<%#Eval("Completion_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Completion_Date"))) : ""%>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Updated_By">
                                    <ItemStyle CssClass="cols" Width="110px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblUpdated_By" runat="server" Text='<%#Eval("user_Name")%>' Width="110px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Updated_Date">
                                    <ItemStyle CssClass="cols" Width="115px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblUpdated_Date" runat="server" Text='<%#Eval("Updated_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Updated_Date"))) : ""%>' Width="115px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Project_Number">
                                    <ItemStyle CssClass="cols" Width="115px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblProject_Number" runat="server" Text='<%#Eval("Project_Number")%>' Width="115px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Start_Date">
                                    <ItemStyle CssClass="cols" Width="115px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblStart_Date" runat="server" Text='<%#Eval("Start_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Start_Date"))) : ""%>' Width="115px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Target_Completion_Date">
                                    <ItemStyle CssClass="cols" Width="200px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblTarget_Completion_Date" runat="server" Text='<%#Eval("Target_Completion_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Target_Completion_Date"))) : ""%>' Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Contact_Name">
                                    <ItemStyle CssClass="cols" Width="115px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblContact_Name" runat="server" Text='<%#Eval("Contact_Name")%>' Width="115px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="New_Build">
                                    <ItemStyle CssClass="cols" Width="115px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblNew_Build" runat="server" Text='<%#Eval("New_Build")%>' Width="115px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Open">
                                    <ItemStyle CssClass="cols" Width="115px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblOpen" runat="server" Text='<%#Eval("Open")%>' Width="115px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Project_Status_As_Of_Date">
                                    <ItemStyle CssClass="cols" Width="200px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblProject_Status_As_Of_Date" runat="server" Text='<%#Eval("Project_Status_As_Of_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Project_Status_As_Of_Date"))) : ""%>' Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_LU_BI_Status">
                                    <ItemStyle CssClass="cols" Width="115px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFK_LU_BI_Status" runat="server" Text='<%#Eval("FK_LU_BI_Status")%>' Width="115px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status_Other">
                                    <ItemStyle CssClass="cols" Width="115px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus_Other" runat="server" Text='<%#Eval("Status_Other")%>' Width="115px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Revised_Square_Footage">
                                    <ItemStyle CssClass="cols" Width="200px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblRevised_Square_Footage" runat="server" Text='<%#Eval("Revised_Square_Footage")%>' Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Revised_Square_Footage_Service_Lane">
                                    <ItemStyle CssClass="cols" Width="250px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblRevised_Square_Footage_Service_Lane" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Revised_Square_Footage_Service_Lane")).Replace(".00","")%>' Width="250px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total_Square_Footage_Revised">
                                    <ItemStyle CssClass="cols" Width="200px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotal_Square_Footage_Revised" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Total_Square_Footage_Revised")).Replace(".00","")%>' Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Budget_Construction">
                                    <ItemStyle CssClass="cols" Width="130px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblBudget_Construction" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Budget_Construction"))%>' Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Budget_Land">
                                    <ItemStyle CssClass="cols" Width="115px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblBudget_Land" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Budget_Land"))%>' Width="115px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Budget_Misc">
                                    <ItemStyle CssClass="cols" Width="115px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblBudget_Misc" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Budget_Misc"))%>' Width="115px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Budget_SubTotal_1">
                                    <ItemStyle CssClass="cols" Width="115px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblBudget_SubTotal_1" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Budget_SubTotal_1"))%>' Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Budget_IT">
                                    <ItemStyle CssClass="cols" Width="115px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblBudget_IT" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Budget_IT"))%>' Width="115px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Budget_Furniture">
                                    <ItemStyle CssClass="cols" Width="115px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblBudget_Furniture" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Budget_Furniture"))%>' Width="115px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Budget_Equipment">
                                    <ItemStyle CssClass="cols" Width="115px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblBudget_Equipment" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Budget_Equipment"))%>' Width="115px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Budget_Signage">
                                    <ItemStyle CssClass="cols" Width="115px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblBudget_Signage" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Budget_Signage"))%>' Width="115px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Budget_SubTotal_2">
                                    <ItemStyle CssClass="cols" Width="130px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblBudget_SubTotal_2" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Budget_SubTotal_2"))%>' Width="130px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Budget_Total">
                                    <ItemStyle CssClass="cols" Width="132px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblBudget_Total" runat="server" Text='<%#clsGeneral.GetStringValue(Eval("Budget_Total"))%>' Width="132px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item_1">
                                    <ItemStyle CssClass="cols" Width="132px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_1" runat="server" Text='<%#Eval("Item_1")%>' Width="132px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item_2">
                                    <ItemStyle CssClass="cols" Width="132px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_2" runat="server" Text='<%#Eval("Item_2")%>' Width="132px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item_3">
                                    <ItemStyle CssClass="cols" Width="132px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_3" runat="server" Text='<%#Eval("Item_3")%>' Width="132px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item_4">
                                    <ItemStyle CssClass="cols" Width="132px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_4" runat="server" Text='<%#Eval("Item_4")%>' Width="132px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item_5">
                                    <ItemStyle CssClass="cols" Width="132px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_5" runat="server" Text='<%#Eval("Item_5")%>' Width="132px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item_6">
                                    <ItemStyle CssClass="cols" Width="132px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_6" runat="server" Text='<%#Eval("Item_6")%>' Width="132px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item_7">
                                    <ItemStyle CssClass="cols" Width="132px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_7" runat="server" Text='<%#Eval("Item_7")%>' Width="132px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Number_of_Havac_Before_Improvements">
                                    <ItemStyle CssClass="cols" Width="260px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblNumber_of_Havac_Before_Improvements" runat="server" Text='<%#Eval("Number_of_Havac_Before_Improvements")%>' Width="260px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Number_of_Havac_After_Improvements">
                                    <ItemStyle CssClass="cols" Width="260px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblNumber_of_Havac_After_Improvements" runat="server" Text='<%#Eval("Number_of_Havac_After_Improvements")%>' Width="260px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Roof_Improvement_Details">
                                    <ItemStyle CssClass="cols" Width="180px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblRoof_Improvement_Details" runat="server" Text='<%#Eval("Roof_Improvement_Details")%>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Additional_Replace">
                                    <ItemStyle CssClass="cols" Width="140px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAdditional_Replace" runat="server" Text='<%#Eval("Additional_Replace")%>' Width="140px"></asp:Label>
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
